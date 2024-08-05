namespace GK.FlexibleObjectReference.Editor.Abstracts
{
    using System;
    using UnityEditor;


    /// <summary>
    /// Extensions methods for the Unity Editor API.
    /// </summary>
    public static partial class EditorExtensionMethods
    {

        /// <summary>
        /// Gets the name of the parent property of the given SerializedProperty.
        /// </summary>
        public static string GetParentName(this SerializedProperty property)
        {
            if (!property.propertyPath.Contains('.'))
                return string.Empty;

            return property.propertyPath.Split('.')[^2];
        }




        /// <summary>
        /// Iterates over the children of the given serialized property and 
        /// performs the specified action on each child.
        /// </summary>
        public static void IterateChildren(this SerializedProperty property, Action<SerializedProperty> action)
        {
            var children = property.Copy()
                .GetEnumerator();
            
            while (children.MoveNext())
                action.Invoke((SerializedProperty)children.Current);
        }

    }

}

