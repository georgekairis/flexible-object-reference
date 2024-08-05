namespace GK.FlexibleObjectReference
{
    using GK.FlexibleObjectReference.Abstracts;
    using GK.FlexibleObjectReference.Interfaces;
    using System;
    using UnityEngine;


    /// <summary>
    /// Flexible object reference for System.Object and UnityEngine.Object derived classes 
    /// with synchronous and asynchronous loading support.
    /// </summary>
    [Serializable]                                
    public partial class Flexible<TObject> : IObjectReference<TObject>
        where TObject : class, new()
    {

        #region CONSTRUCTORS
        /// <summary>
        /// Initializes a new instance of the Flexible class.
        /// </summary>
        public Flexible()
        {

        }

        /// <summary>
        /// Initializes a new instance of the Flexible class 
        /// with a pre-loaded reference.
        /// </summary>
        public Flexible(IObjectReference<TObject> reference)
        {
            _reference = reference;
        }
        #endregion






        #region FIELDS
        /// <summary>
        /// Contains the wrapped primitive object reference.
        /// </summary>
        [SerializeReference]
        protected IObjectReference _reference;
        #endregion






        /// <summary>
        /// Synchronously loads the object reference.
        /// </summary>
        public T Load<T>()
            where T : class
        {
            return LoadInternal<T>(_reference);
        }


        /// <summary>
        /// Synchronously loads the object reference.
        /// </summary>
        public TObject Load()
        {
            return LoadInternal<TObject>(_reference);
        }




        /// <summary>
        /// Internal method for synchronously loading the object reference.
        /// </summary>
        protected virtual T LoadInternal<T>(IObjectReference reference) 
            where T : class
        {
            return IsScriptableContainer(typeof(T)) ?
                reference.Load<AbstractScriptableContainer<T>>() :
                reference.Load<T>();
        }






        /// <summary>
        /// Asynchronously loads the object reference.
        /// </summary>
        public async Awaitable<T> LoadAsync<T>()
            where T : class
        {
            return await LoadAsyncInternal<T>(_reference);
        }


        /// <summary>
        /// Asynchronously loads the object reference.
        /// </summary>
        public async Awaitable<TObject> LoadAsync()
        {
            return await LoadAsyncInternal<TObject>(_reference);
        }




        /// <summary>
        /// Internal method for loading asynchronously the object reference.
        /// </summary>
        protected virtual async Awaitable<T> LoadAsyncInternal<T>(IObjectReference reference)
            where T : class
        {
            return IsScriptableContainer(typeof(T)) ?
                await reference.LoadAsync<AbstractScriptableContainer<T>>() :
                await reference.LoadAsync<T>();
        }






        /// <summary>
        /// Checks if a type implements the IUnityObjectReference interface.
        /// </summary>
        protected bool IsUnityObjectReference(Type type)
        {
            foreach (var i in type.GetInterfaces())
            {
                if (i.IsGenericType && 
                    i.GetGenericTypeDefinition() == typeof(IUnityObjectReference<>))
                    return true;
            }

            return false;
        }


        /// <summary>
        /// Checks if a type is a subclass of UnityEngine.Object.
        /// </summary>
        protected bool IsUnityObject(Type type)
        {
            return type.IsSubclassOf(typeof(UnityEngine.Object));
        }






        /// <summary>
        /// Checks if the type is wrapped inside a scriptable container.
        /// </summary>
        protected bool IsScriptableContainer(Type type)
        {
            return IsUnityObjectReference(_reference.GetType()) && 
                !IsUnityObject(type);
        }






        /// <summary>
        /// Releases any stored operation results or handles
        /// and cleans up the cached object reference if caching is implemented.
        /// </summary>
        public void Release()
        {
            _reference.Release();
        }

    }

}
