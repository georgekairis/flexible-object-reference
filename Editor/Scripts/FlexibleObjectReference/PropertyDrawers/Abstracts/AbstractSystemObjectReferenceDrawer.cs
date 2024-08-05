namespace GK.FlexibleObjectReference.Editor.Abstracts
{

    /// <summary>
    /// Base property drawer for primitive System.Object reference properties.
    /// </summary>
    public abstract class AbstractSystemObjectReferenceDrawer : AbstractObjectReferenceDrawer
    {

        /// <summary>
        /// Determines whether the contained object 
        /// is a Unity Object reference.
        /// </summary>
        protected override bool ContainsUnityObject()
        {
            return IsUnityObject(GetGenericArgument());
        }

    }

}
