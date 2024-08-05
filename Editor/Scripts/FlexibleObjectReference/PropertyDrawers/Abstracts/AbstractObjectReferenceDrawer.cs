namespace GK.FlexibleObjectReference.Editor.Abstracts
{
    using GK.FlexibleObjectReference.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    using UnityEditor;


    /// <summary>
    /// Base property drawer for primitive and flexible object reference properties.
    /// </summary>
    public abstract class AbstractObjectReferenceDrawer : PropertyDrawer
    {

        #region CONSTANTS
        /// <summary>
        /// The serialized property name for the reference field.
        /// </summary>
        protected const string ReferencePropertyName = "_reference";

        /// <summary>
        /// The internal property name used by Unity for 
        /// serialized properties containing lists & arrays.
        /// </summary>
        protected const string ArrayPropertyName = "Array";
        #endregion






        #region PROPERTIES
        /// <summary>
        /// The suffix label to be displayed next to 
        /// the serialized property field.
        /// </summary>
        protected virtual string SuffixLabel
        {
            get => string.Empty;
        }

        /// <summary>
        /// The margin for the suffix label in pixels.
        /// </summary>
        protected virtual int SuffixMargin
        {
            get => 2;
        }

        /// <summary>
        /// The width of the label for child properties.
        /// </summary>
        protected virtual float ChildLabelWidth
        {
            get => 100;
        }
        #endregion






        /// <summary>
        /// Protected method to be implemented by derived classes for determining
        /// whether the contained object is a Unity Object reference.
        /// </summary>
        protected abstract bool ContainsUnityObject();






        /// <summary>
        /// Handles the GUI rendering for the custom serialized property drawer.
        /// </summary>
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);
            {
                ReferenceField(position, property, label);
                property.serializedObject.ApplyModifiedProperties();
            }
            EditorGUI.EndProperty();
        }






        /// <summary>
        /// Draws the reference field and associated GUI elements and
        /// returns the next serialized property area.
        /// </summary>
        protected virtual Rect ReferenceField(Rect position, SerializedProperty property, GUIContent label)
        {
            position = PropertyLabel(position, label);
            position = PropertyField(position, property, label, out Rect suffix);
            PropertySuffix(suffix, SuffixMargin, new(SuffixLabel));

            return position;
        }






        /// <summary>
        /// Draws the label for the serialized property field and
        /// returns the control area.
        /// </summary>
        protected Rect PropertyLabel(Rect position, GUIContent label)
        {
            if (label == GUIContent.none ||
                string.IsNullOrEmpty(label.text))
                return position;

            return EditorGUI.PrefixLabel(position, label);
        }




        /// <summary>
        /// Draws the serialized property field based on the type 
        /// of object reference and returns the next property area and suffix position.
        /// </summary>
        protected Rect PropertyField(Rect position, SerializedProperty property, GUIContent label, 
            out Rect suffix)
        {            
            suffix = new Rect(
                position.x,
                position.y,
                position.width,
                EditorGUIUtility.singleLineHeight);

            return PropertyField(position, property, label);
        }


        /// <summary>
        /// Draws the serialized property field based on the type 
        /// of object reference and returns the next property area.
        /// </summary>
        protected Rect PropertyField(Rect position, SerializedProperty property, GUIContent label)
        {
            var defaultLabelWidth = EditorGUIUtility.labelWidth;
            var childLabelWidth = getChildLabelWidth(label);

            IterateProperty(property, child =>
            {
                position = drawChild(position, child);
            });

            return new Rect(
                position.x - EditorGUIUtility.labelWidth,
                position.y,
                position.width + EditorGUIUtility.labelWidth,
                EditorGUIUtility.singleLineHeight);


            float getChildLabelWidth(GUIContent label)
            {
                return label == GUIContent.none ?
                    EditorGUIUtility.labelWidth : ChildLabelWidth;
            }

            Rect drawChild(Rect position, SerializedProperty property)
            {
                var label = property.name == ReferencePropertyName ?
                        GUIContent.none : null;

                EditorGUIUtility.labelWidth = childLabelWidth;
                {
                    EditorGUI.PropertyField(position, property, label, true);
                    position.y += property.isExpanded ? 
                        EditorGUI.GetPropertyHeight(property) : 
                        GetSignleLineHeight();
                }
                EditorGUIUtility.labelWidth = defaultLabelWidth;

                return position;
            }

        }




        /// <summary>
        /// Draws a suffix label for the serialized property field.
        /// </summary>
        protected void PropertySuffix(Rect position, int padding, GUIContent label)
        {
            if (string.IsNullOrEmpty(label.text))
                return;

            var style = new GUIStyle()
            {
                alignment = TextAnchor.MiddleRight,
                fontSize = 10,
                normal = new GUIStyleState()
                {
                    textColor = new Color(1, 1, 1, 0.4f)
                }
            };

            position.width -= padding;
            EditorGUI.LabelField(position, label, style);
        }






        /// <summary>
        /// Gets the height of the serialized property.
        /// </summary>
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            var height = 0.0f;
            var count = 0;

            IterateProperty(property, child =>
            {
                height += EditorGUI.GetPropertyHeight(child);
                count++;
            });

            return height + EditorGUIUtility.standardVerticalSpacing * (count - 1);
        }


        /// <summary>
        /// Gets the height of a single line.
        /// </summary>
        protected virtual float GetSignleLineHeight()
        {
            return EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
        }






        /// <summary>
        /// Checks whether a type is a subclass of UnityEngine.Object.
        /// </summary>
        protected bool IsUnityObject(Type type)
        {
            return type.IsSubclassOf(typeof(UnityEngine.Object));
        }


        /// <summary>
        /// Checks whether a type implements the IUnityObjectReference interface.
        /// </summary>
        protected bool IsUnityObjectContainer(Type type)
        {
            return type.GetInterfaces()
                .Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IUnityObjectReference<>));
        }






        /// <summary>
        /// Gets the generic type definition from field info.
        /// </summary>
        protected Type GetGenericType()
        {
            if (HasGenericArgument(fieldInfo.FieldType, out _))
                return fieldInfo.FieldType.GetGenericTypeDefinition();

            if (HasGenericArgument(fieldInfo.DeclaringType, out _))
                return fieldInfo.DeclaringType.GetGenericTypeDefinition();

            throw new Exception($"Invalid reference type. Type does not contain generic argument.");
        }


        /// <summary>
        /// Gets the generic argument type from field info.
        /// </summary>
        protected Type GetGenericArgument()
        {
            if (HasGenericArgument(fieldInfo.FieldType, out Type arg))
                return arg;

            if (HasGenericArgument(fieldInfo.DeclaringType, out arg))
                return arg;

            throw new Exception($"Invalid reference type. Type does not contain generic argument.");
        }






        /// <summary>
        /// Checks if a type has a generic argument and retrieves it.
        /// </summary>
        protected bool HasGenericArgument(Type type, out Type argument)
        {
            var args = type.GetGenericArguments();

            argument = null;
            if (args == null ||
                args.Length == 0)
                return false;

            argument = args[0];
            return true;
        }






        /// <summary>
        /// Performs a filtered iteration over the children of the given serialized property 
        /// and performs the specified action on each child.
        /// </summary>
        protected virtual void IterateProperty(SerializedProperty property, Action<SerializedProperty> action)
        {
            var containsUnityObject = ContainsUnityObject();
            var invokedProperties = new List<string>();

            property.IterateChildren(child =>
            {
                if (!containsUnityObject && 
                    child.name == ReferencePropertyName)
                    return;

                var parent = child.GetParentName();
                if (invokedProperties.Contains(parent) ||
                    parent.Contains(ArrayPropertyName))
                    return;

                action.Invoke(child);
                invokedProperties.Add(child.name);
            });
        }

    }

}
