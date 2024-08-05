namespace GK.FlexibleObjectReference.Editor.Abstracts
{

    /// <summary>
    /// Base property drawer for primitive UnityEngine.Object reference properties.
    /// </summary>
    public abstract class AbstractUnityObjectReferenceDrawer : AbstractObjectReferenceDrawer
    {

        /// <summary>
        /// Determines whether the contained object 
        /// is a Unity Object reference.
        /// </summary>
        protected override bool ContainsUnityObject()
        {
            return true;
        }

    }

}
