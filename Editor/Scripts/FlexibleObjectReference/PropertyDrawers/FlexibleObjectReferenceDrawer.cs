namespace GK.FlexibleObjectReference.Editor.Drawers
{
    using GK.FlexibleObjectReference.Abstracts;
    using GK.FlexibleObjectReference.Interfaces;
    using GK.FlexibleObjectReference.Primitives;
    using GK.FlexibleObjectReference.Editor.Abstracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    using UnityEditor;


    /// <summary>
    /// Custom property drawer for the generic Flexible<T> object reference property.
    /// </summary>
    [CustomPropertyDrawer(typeof(Flexible<>))]
    public class FlexibleObjectReferenceDrawer : AbstractObjectReferenceDrawer
    {

        #region PROPERTIES
        /// <summary>
        /// Reference type options.
        /// </summary>
        protected virtual Dictionary<Type, Dictionary<string, Type>> Options => new()
        {
            { 
                SystemObjectType, SystemObjectOptions 
            },
            { 
                UnityObjectType, UnityObjectOptions
            }
        };




        /// <summary>
        /// System.Object base type.
        /// </summary>
        protected Type SystemObjectType
        {
            get => typeof(object);
        }

        /// <summary>
        /// UnityEngine.Object base type.
        /// </summary>
        protected Type UnityObjectType
        {
            get => typeof(UnityEngine.Object);
        }




        /// <summary>
        /// System.Object based object reference options.
        /// </summary>
        protected virtual Dictionary<string, Type> SystemObjectOptions => new()
        {
            { 
                FromInstanceObjectReferenceOptionName,    typeof(FromInstanceObjectReference<>) 
            },
            { 
                FromAssetObjectReferenceOptionName,       typeof(IUnityObjectReference<>) 
            },
        };

        /// <summary>
        /// UnityEngine.Object based object reference options.
        /// </summary>
        protected virtual Dictionary<string, Type> UnityObjectOptions => new()
        {
            { 
                StandardUnityObjectReferenceOptionName,   typeof(StandardUnityObjectReference<>) 
            },
            { 
                ResourcesUnityObjectReferenceOptionName,  typeof(ResourcesUnityObjectReference<>) 
            },
#if ADDRESSABLE_OBJECT_REFERENCE
            {
                AddressableUnitybjectReferenceOptionName, typeof(AddressableUnityObjectReference<>) 
            },
#endif
        };
        #endregion






        #region PRIMITIVES
        /// <summary>
        /// Option name for the reference type selection toolbar.
        /// </summary>
        protected const string FromInstanceObjectReferenceOptionName = "From Instance";

        /// <summary>
        /// Option name for the reference type selection toolbar.
        /// </summary>
        protected const string FromAssetObjectReferenceOptionName = "From Asset";


        /// <summary>
        /// Option name for the reference type selection toolbar.
        /// </summary>
        protected const string StandardUnityObjectReferenceOptionName = "Standard";

        /// <summary>
        /// Option name for the reference type selection toolbar.
        /// </summary>
        protected const string ResourcesUnityObjectReferenceOptionName = "Resources";

        /// <summary>
        /// Option name for the reference type selection toolbar.
        /// </summary>
        protected const string AddressableUnitybjectReferenceOptionName = "Address";
        #endregion






        #region FIELDS
        /// <summary>
        /// Contains the current reference type.
        /// </summary>
        private Type _referenceType;

        /// <summary>
        /// Contains the current object type.
        /// </summary>
        private Type _objectType;
        #endregion




        

        /// <summary>
        /// Determines whether the contained object is a Unity object reference.
        /// </summary>
        protected override bool ContainsUnityObject()
        {
            return IsUnityObject(_objectType ?? GetGenericArgument());
        }






        /// <summary>
        /// Draws the reference field and associated GUI elements.
        /// </summary>
        protected override Rect ReferenceField(Rect position, SerializedProperty property, GUIContent label)
        {
            var reference = initializeReference(property);

            position = PropertyLabel(position, label);
            position = referenceTypeSelection(position, reference);
            position = PropertyField(position, property, label, out Rect suffix);
            PropertySuffix(suffix, SuffixMargin, new(SuffixLabel));

            return position;


            SerializedProperty initializeReference(SerializedProperty property)
            {
                var reference = property.FindPropertyRelative(ReferencePropertyName);

                _objectType ??= GetGenericArgument();
                _referenceType ??= GetReferenceType(reference) ??
                    GetDefaultReferenceType(_objectType);

                reference.managedReferenceValue ??= CreateReference(_referenceType, _objectType);

                return reference;
            }

            Rect referenceTypeSelection(Rect position, SerializedProperty property)
            {
                position.height = EditorGUIUtility.singleLineHeight;
                position = SystemObjectReferenceTypeSelectionToolbar(position, ref _referenceType);
                position = UnityObjectReferenceTypeSelectionToolbar(position, ref _referenceType);

                if (IsUnityObjectContainer(_referenceType) && !IsUnityObject(_objectType))
                    _objectType = typeof(AbstractScriptableContainer<>).MakeGenericType(_objectType);

                if (!IsUnityObjectContainer(_referenceType) && IsUnityObject(_objectType))
                    _objectType = GetGenericArgument();

                if (GetReferenceType(property) == _referenceType)
                    return position;

                property.managedReferenceValue = CreateReference(_referenceType, _objectType);
                property.serializedObject.ApplyModifiedProperties();

                return position;
            }
        }






        /// <summary>
        /// Draws the selection toolbar of the reference type for system objects.
        /// </summary>
        protected virtual Rect SystemObjectReferenceTypeSelectionToolbar(Rect position, ref Type containerType)
        {
            var data = Options[SystemObjectType];
            var options = data.Keys.ToArray();
            var types = data.Values.ToList();

            if (IsUnityObject(GetGenericArgument()))
                return position;

            var current = IsUnityObjectContainer(containerType) ?
                types.IndexOf(typeof(IUnityObjectReference<>)) :
                types.IndexOf(containerType);

            var selection = TypeSelectionToolbarField(position, options, current);
            position.y += GetSignleLineHeight();

            if (IsUnityObjectContainer(containerType) &&
                selection == types.IndexOf(typeof(IUnityObjectReference<>)))
                return position;

            containerType = data[options[selection]];
            return position;
        }


        /// <summary>
        /// Draws the selection toolbar of the reference type for Unity objects.
        /// </summary>
        protected virtual Rect UnityObjectReferenceTypeSelectionToolbar(Rect position, ref Type containerType)
        {
            var data = Options[UnityObjectType];
            var options = data.Keys.ToArray();
            var types = data.Values.ToList();

            if (containerType == typeof(IUnityObjectReference<>) &&
                containerType.IsInterface)
                containerType = data.First().Value;

            if (!IsUnityObjectContainer(containerType))
                return position;

            var current = types.IndexOf(containerType);

            var selection = TypeSelectionToolbarField(position, options, current);
            position.y += GetSignleLineHeight();

            containerType = data[options[selection]];
            return position;
        }






        /// <summary>
        /// Draws a generic toolbar.
        /// </summary>
        protected virtual int TypeSelectionToolbarField(Rect position, string[] options, int current)
        {
            return GUI.Toolbar(position, current, options);
        }






        /// <summary>
        /// Gets the height of the property.
        /// </summary>
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            var containsWrappedSystemObject = ContainsUnityObject() &&
                !IsUnityObject(GetGenericArgument());
            var toolbars = containsWrappedSystemObject ? 2 : 1;

            return toolbars * GetSignleLineHeight() + base.GetPropertyHeight(property, label);
        }






        /// <summary>
        /// Gets the current refrence type based on the stored serialized property.
        /// </summary>
        protected virtual Type GetReferenceType(SerializedProperty property)
        {
            return property.managedReferenceValue?.GetType()
                .GetGenericTypeDefinition();
        }


        /// <summary>
        /// Gets the default container type based on the object type.
        /// </summary>
        protected virtual Type GetDefaultReferenceType(Type objectType)
        {
            return IsUnityObject(objectType) ?
                Options[UnityObjectType].First().Value :
                Options[SystemObjectType].First().Value;
        }






        /// <summary>
        /// Create a reference container based on the given reference and object types.
        /// </summary>
        protected virtual object CreateReference(Type referenceType, Type objectType)
        {
            return Activator.CreateInstance(
                referenceType.MakeGenericType(objectType));
        }

    }

}
