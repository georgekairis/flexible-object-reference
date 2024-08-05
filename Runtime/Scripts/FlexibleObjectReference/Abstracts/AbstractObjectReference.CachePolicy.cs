namespace GK.FlexibleObjectReference.Abstracts
{

    public abstract partial class AbstractObjectReference<TReference, TObject>
    {

        /// <summary>
        /// Specifies the caching behavior for object references.
        /// </summary>
        public enum CachePolicy
        {

            /// <summary>
            /// The object reference should not be cached.
            /// </summary>
            NoCache,


            /// <summary>
            /// The object reference should always be cached.
            /// </summary>
            CacheAlways

        }

    }

}
