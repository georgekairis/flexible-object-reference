namespace GK.FlexibleObjectReference.Editor.Drawers
{
#if ADDRESSABLE_OBJECT_REFERENCE

    using GK.FlexibleObjectReference.Primitives;
    using GK.FlexibleObjectReference.Editor.Abstracts;
    using UnityEditor;


    /// <summary>
    /// Custom property drawer for the primitive AddressableUnityObjectReference property.
    /// </summary>
    [CustomPropertyDrawer(typeof(AddressableUnityObjectReference<>))]
    public class AddressableUnityObjectReferenceDrawer : AbstractUnityObjectReferenceDrawer
    {

        #region PROPERTIES
        protected override string SuffixLabel
        {
            get => "label";
        }

        protected override int SuffixMargin
        {
            get => 18;
        }
        #endregion

    }

#endif
}
