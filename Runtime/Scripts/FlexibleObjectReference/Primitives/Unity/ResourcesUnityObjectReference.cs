namespace GK.FlexibleObjectReference.Primitives
{
    using GK.FlexibleObjectReference.Abstracts;
    using GK.FlexibleObjectReference.Utilities;
    using System;
    using UnityEngine;


    /// <summary>
    /// UnityEngine.Resources based Unity object reference class 
    /// with synchronous and asynchronous loading support.
    /// </summary>
    [Serializable]
    public class ResourcesUnityObjectReference<TObject> : AbstractUnityObjectReference<string, TObject>
        where TObject : UnityEngine.Object
    {

        #region CONSTRUCTORS
        /// <summary>
        /// Initializes a new instance of the ResourcesUnityObjectReference class.
        /// </summary>
        public ResourcesUnityObjectReference() :
            base(string.Empty)
        {

        }

        /// <summary>
        /// Initializes a new instance of the ResourcesUnityObjectReference class 
        /// with a pre-loaded reference.
        /// </summary>
        public ResourcesUnityObjectReference(string tag) : 
            base(tag) 
        { 
        
        }

        /// <summary>
        /// Initializes a new instance of the ResourcesUnityObjectReference class 
        /// with pre-loaded reference and object.
        /// </summary>
        public ResourcesUnityObjectReference(string tag, TObject obj) : 
            base(tag, obj) 
        {
        
        }
        #endregion






        #region PROPERTIES
        /// <summary>
        /// Specifies whether or not the loaded object reference will be cached.
        /// </summary>
        protected override CachePolicy ObjectReferenceCachePolicy
        {
            get => CachePolicy.CacheAlways;
        }
        #endregion






        /// <summary>
        /// Synchronously loads the Unity object using Resources API.
        /// </summary>
        protected override TObject LoadFromReference(string reference)
        {
            return Resources.Load<TObject>(reference);
        }


        /// <summary>
        /// Aynchronously loads the Unity object using Resources API.
        /// </summary>
        protected override async Awaitable<TObject> LoadFromReferenceAsync(string reference)
        {
            return await InternalAwaitableUtility.FromResult(
                LoadFromReference(reference));
        }

    }

}
