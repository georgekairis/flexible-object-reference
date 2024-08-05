namespace GK.FlexibleObjectReference.Primitives
{
#if ADDRESSABLE_OBJECT_REFERENCE

    using GK.FlexibleObjectReference.Abstracts;
    using System;
    using UnityEngine;
    using UnityEngine.AddressableAssets;
    using UnityEngine.ResourceManagement.AsyncOperations;


    /// <summary>
    /// UnityEngine.AddressableAssets based Unity object reference class 
    /// with synchronous and asynchronous loading support.
    /// </summary>
    [Serializable]
    public partial class AddressableUnityObjectReference<TObject> : AbstractUnityObjectReference<AssetLabelReference, TObject>
        where TObject : UnityEngine.Object
    {

        #region CONSTRUCTORS
        /// <summary>
        /// Initializes a new instance of the AddressableUnityObjectReference class.
        /// </summary>
        public AddressableUnityObjectReference() :
            base(new AssetLabelReference())
        {
        
        }

        /// <summary>
        /// Initializes a new instance of the AddressableUnityObjectReference class 
        /// with a pre-loaded reference.
        /// </summary>
        public AddressableUnityObjectReference(AssetLabelReference label) :
            base(label)
        { 
        
        }

        /// <summary>
        /// Initializes a new instance of the AddressableUnityObjectReference class 
        /// with pre-loaded reference and object.
        /// </summary>
        public AddressableUnityObjectReference(AssetLabelReference label, TObject obj) :
            base(label, obj)
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
        /// Synchronously loads the Unity object using Addressables API.
        /// </summary>
        protected override TObject LoadFromReference(AssetLabelReference reference)
        {
            var handle = GetOperationHandle(reference);
            var result = handle.WaitForCompletion();

            ReleaseOperationHandle(handle);
            return result;
        }


        /// <summary>
        /// Asynchronously loads the Unity object using Addressables API.
        /// </summary>
        protected override async Awaitable<TObject> LoadFromReferenceAsync(AssetLabelReference reference)
        {
            var handle = GetOperationHandle(reference);
            var result = await handle.Task;

            ReleaseOperationHandle(handle);
            return result;
        }






        /// <summary>
        /// Gets the async operation handle for loading 
        /// an asset using Addressables.
        /// </summary>
        protected virtual AsyncOperationHandle<TObject> GetOperationHandle(AssetLabelReference reference)
        {
            return Addressables.LoadAssetAsync<TObject>(reference);
        }


        /// <summary>
        /// Releases the async operation handle.
        /// </summary>
        protected virtual void ReleaseOperationHandle(AsyncOperationHandle<TObject> handle)
        {
            Addressables.Release(handle);
        }

    }

#endif
}
