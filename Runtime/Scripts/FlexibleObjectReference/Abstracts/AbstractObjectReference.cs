namespace GK.FlexibleObjectReference.Abstracts
{
    using GK.FlexibleObjectReference.Interfaces;
    using System;
    using UnityEngine;


    /// <summary>
    /// Abstract implementation of an object reference of specific type 
    /// with synchronous and asynchronous loading support.
    /// </summary>
    [Serializable]
    public abstract partial class AbstractObjectReference<TReference, TObject> : IObjectReference<TObject>
        where TObject : class
    {

        #region CONSTRUCTORS
        /// <summary>
        /// Initializes a new instance of the AbstractObjectReference class.
        /// </summary>
        public AbstractObjectReference()
        {

        }

        /// <summary>
        /// Initializes a new instance of the AbstractObjectReference class 
        /// with a pre-loaded reference.
        /// </summary>
        public AbstractObjectReference(TReference reference) 
        {
            _reference = reference;
        }

        /// <summary>
        /// Initializes a new instance of the AbstractObjectReference class 
        /// with pre-loaded reference and object.
        /// </summary>
        public AbstractObjectReference(TReference reference, TObject obj) :
            this(reference)
        {
            WriteToCache(obj);
        }
        #endregion






        #region PROPERTIES
        /// <summary>
        /// Protected enum to be implemented derived classes, 
        /// specifying whether or not the loaded object reference will be cached.
        /// </summary>
        protected abstract CachePolicy ObjectReferenceCachePolicy { get; }
        #endregion






        #region FIELDS
        /// <summary>
        /// Contains the stored reference.
        /// </summary>
        [SerializeField]
        private TReference _reference;

        /// <summary>
        /// Contains the cache container for the loaded object reference.
        /// </summary>
        private IObjectCache<TObject> _cache;
        #endregion






        /// <summary>
        /// Synchronously loads the object reference.
        /// </summary>
        public TObject Load()
        {
            return SupportsCaching(ObjectReferenceCachePolicy) ?
                LoadFromCache(_reference) :
                LoadFromReference(_reference);
        }


        /// <summary>
        /// Synchronously loads the object reference.
        /// </summary>
        public T Load<T>()
            where T : class
        {
            return Cast<T>(
                Load());
        }


        /// <summary>
        /// Returns the cached object reference. If the reference is not already loaded,
        /// this method loads the reference synchronously and caches it for future access.        
        /// </summary>
        protected TObject LoadFromCache(TReference reference)
        {
            return ReadFromCache() ?? WriteToCache(
                LoadFromReference(reference));
        }


        /// <summary>
        /// Protected method to be implemented by derived classes 
        /// for synchronously loading the object reference.
        /// </summary>
        protected abstract TObject LoadFromReference(TReference reference);






        /// <summary>
        /// Asynchronously loads the object reference.
        /// </summary>
        public async Awaitable<TObject> LoadAsync()
        {
            await Awaitable.MainThreadAsync();

            return SupportsCaching(ObjectReferenceCachePolicy) ?
                await LoadFromCacheAsync(_reference) :
                await LoadFromReferenceAsync(_reference);
        }


        /// <summary>
        /// Asynchronously loads the object reference.
        /// </summary>
        public async Awaitable<T> LoadAsync<T>()
            where T : class
        {
            return Cast<T>(
                await LoadAsync());
        }


        /// <summary>
        /// Returns the cached object reference. If the reference is not already loaded,
        /// this method loads the reference asynchronously and caches it for future access.        
        /// </summary>
        protected async Awaitable<TObject> LoadFromCacheAsync(TReference reference)
        {
            return ReadFromCache() ?? WriteToCache(
                await LoadFromReferenceAsync(reference));
        }


        /// <summary>
        /// Protected method to be implemented by derived classes 
        /// for asynchronously loading the object reference.
        /// </summary>
        protected abstract Awaitable<TObject> LoadFromReferenceAsync(TReference reference);






        /// <summary>
        /// Converts an object to the specified type.
        /// </summary>
        protected T Cast<T>(object obj)
            where T : class
        {
            return (T)obj;
        }






        /// <summary>
        /// Specifies whether or not the current implementation 
        /// supprots caching by evaluating the specified cache policy.
        /// </summary>
        protected virtual bool SupportsCaching(CachePolicy policy)
        {
            return policy != CachePolicy.NoCache;
        }


        /// <summary>
        /// Returns the stored cache container.
        /// If the container does not exist, a new one is instantiated.
        /// </summary>
        protected IObjectCache<TObject> GetCacheContainer()
        {
            return _cache ??= CreateCacheContainer();
        }


        /// <summary>
        /// Returns a newly instantiated cache container.
        /// Can be overriden to implement custom cache containers.
        /// </summary>
        protected virtual IObjectCache<TObject> CreateCacheContainer()
        {
            return new Cache();
        }






        /// <summary>
        /// Returns the cached object reference.
        /// </summary>
        protected TObject ReadFromCache()
        {
            return GetCacheContainer()
                .Read();
        }


        /// <summary>
        /// Caches the specified object reference.
        /// </summary>
        protected TObject WriteToCache(TObject obj)
        {
            return GetCacheContainer()
                .Write(obj);
        }


        /// <summary>
        /// Clears the cache container.
        /// </summary>
        protected void ClearCache()
        {
            GetCacheContainer()
                .Clear();
        }






        /// <summary>
        /// Releases any stored operation results or handles
        /// and cleans up the cached object reference if caching is implemented.
        /// </summary>
        public virtual void Release()
        {
            if (SupportsCaching(ObjectReferenceCachePolicy))
                ClearCache();
        }

    }

}
