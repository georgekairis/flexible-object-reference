namespace GK.FlexibleObjectReference.Editor.Drawers
{
    using GK.FlexibleObjectReference.Primitives;
    using GK.FlexibleObjectReference.Editor.Abstracts;
    using UnityEditor;


    /// <summary>
    /// Custom property drawer for the primitive StandardUnityObjectReference property.
    /// </summary>
    [CustomPropertyDrawer(typeof(StandardUnityObjectReference<>))]
    public class StandardUnityObjectReferenceDrawer : AbstractUnityObjectReferenceDrawer
    {
        
        #region PROPERTIES
        protected override string SuffixLabel
        {
            get => "reference";
        }

        protected override int SuffixMargin
        {
            get => 22;
        }
        #endregion

    }

}
