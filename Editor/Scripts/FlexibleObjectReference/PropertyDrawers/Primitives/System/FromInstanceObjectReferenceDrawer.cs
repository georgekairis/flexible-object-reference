namespace GK.FlexibleObjectReference.Editor.Drawers
{
    using GK.FlexibleObjectReference.Primitives;
    using GK.FlexibleObjectReference.Editor.Abstracts;
    using UnityEditor;


    /// <summary>
    /// Custom property drawer for the primitive FromInstanceObjectReference property.
    /// </summary>
    [CustomPropertyDrawer(typeof(FromInstanceObjectReference<>))]
    public class FromInstanceObjectReferenceDrawer : AbstractSystemObjectReferenceDrawer
    {
    
    }

}
