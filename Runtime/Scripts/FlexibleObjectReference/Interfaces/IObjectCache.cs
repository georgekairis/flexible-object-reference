namespace GK.FlexibleObjectReference.Interfaces
{

    /// <summary>
    /// Interface for a generic object cache container.
    /// </summary>
    public interface IObjectCache<T>
        where T : class
    {

        /// <summary>
        /// Reads the cache container 
        /// and returns the cached object reference.
        /// </summary>
        public T Read();


        /// <summary>
        /// Writes the specified object to the cache container
        /// and returns the cached object reference.
        /// </summary>
        public T Write(T obj);




        /// <summary>
        /// Clears the cached object reference.
        /// </summary>
        public void Clear();

    }

}
