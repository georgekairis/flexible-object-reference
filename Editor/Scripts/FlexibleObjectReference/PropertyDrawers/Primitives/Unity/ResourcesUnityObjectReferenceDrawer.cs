namespace GK.FlexibleObjectReference.Editor.Drawers
{
    using GK.FlexibleObjectReference.Primitives;
    using GK.FlexibleObjectReference.Editor.Abstracts;
    using UnityEditor;


    /// <summary>
    /// Custom property drawer for the primitive ResourcesUnityObjectReference property.
    /// </summary>
    [CustomPropertyDrawer(typeof(ResourcesUnityObjectReference<>))]
    public class ResourcesUnityObjectReferenceDrawer : AbstractUnityObjectReferenceDrawer
    {

        #region PROPERTIES
        protected override string SuffixLabel
        {
            get => "path";
        }

        protected override int SuffixMargin
        {
            get => 4;
        }
        #endregion

    }

}
