namespace GK.FlexibleObjectReference.Interfaces
{

    /// <summary>
    /// Interface for a scriptable object that contains 
    /// a reference of type T.
    /// </summary>
    public interface IScriptableContainer<T>
        where T : class
    {

        /// <summary>
        /// The object reference of type T stored in the 
        /// scriptable object.
        /// </summary>
        public T Object { get; }

    }

}
