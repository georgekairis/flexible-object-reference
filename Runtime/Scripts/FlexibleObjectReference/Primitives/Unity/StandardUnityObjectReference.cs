namespace GK.FlexibleObjectReference.Primitives
{
    using GK.FlexibleObjectReference.Abstracts;
    using GK.FlexibleObjectReference.Utilities;
    using System;
    using UnityEngine;


    /// <summary>
    /// Self-contained Unity Object reference with synchronous and asynchronous loading support.
    /// </summary>
    [Serializable]
    public class StandardUnityObjectReference<TObject> : AbstractUnityObjectReference<TObject, TObject>
        where TObject : UnityEngine.Object
    {

        #region CONSTRUCTORS
        /// <summary>
        /// Initializes a new instance of the StandardUnityObjectReference class.
        /// </summary>
        public StandardUnityObjectReference() :
            base((TObject)(UnityEngine.Object)null)
        {
        
        }

        /// <summary>
        /// Initializes a new instance of the StandardUnityObjectReference class 
        /// with a pre-loaded reference.
        /// </summary>
        public StandardUnityObjectReference(TObject obj) : 
            base(obj) 
        {
        
        }
        #endregion






        #region PROPERTIES
        /// <summary>
        /// Specifies whether or not the loaded object reference will be cached.
        /// </summary>
        protected override CachePolicy ObjectReferenceCachePolicy
        {
            get => CachePolicy.NoCache;
        }
        #endregion






        /// <summary>
        /// Synchronously loads the object reference.
        /// </summary>
        protected override TObject LoadFromReference(TObject reference)
        {
            return reference;
        }


        /// <summary>
        /// Asynchronously loads the object reference.
        /// </summary>
        protected override async Awaitable<TObject> LoadFromReferenceAsync(TObject reference)
        {
            return await InternalAwaitableUtility.FromResult(
                LoadFromReference(reference));
        }

    }

}
