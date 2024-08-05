namespace GK.FlexibleObjectReference.Abstracts
{
    using GK.FlexibleObjectReference.Interfaces;
    using UnityEngine;


    public abstract partial class AbstractObjectReference<TReference, TObject>
    {

        /// <summary>
        /// Standard object refence cache container.
        /// </summary>
        public class Cache : IObjectCache<TObject>
        {

            #region CONSTRUCTORS
            /// <summary>
            /// Initializes a new instance of the AbstractObjectReference.Cache class.
            /// </summary>
            public Cache()
            {

            }

            /// <summary>
            /// Initializes a new instance of the AbstractObjectReference.Cache class 
            /// with a pre-loaded object.
            /// </summary>
            public Cache(TObject obj)
            {
                _object = obj;
            }
            #endregion






            #region FIELDS
            /// <summary>
            /// Contains the cached object.
            /// </summary>
            private TObject _object;
            #endregion






            /// <summary>
            /// Returns the cached object.
            /// </summary>
            public TObject Read()
            {
                return _object;
            }


            /// <summary>
            /// Caches the specified object.
            /// </summary>
            public TObject Write(TObject obj)
            {
                return _object = obj;
            }






            /// <summary>
            /// Disposes the cached object.
            /// </summary>
            public void Clear()
            {
                _object = null;
            }

        }

    }

}
