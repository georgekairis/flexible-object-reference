namespace GK.FlexibleObjectReference.Interfaces
{
    using System;
    using UnityEngine;


    /// <summary>
    /// Interface for an object reference 
    /// with synchronous and asynchronous loading support.
    /// </summary>
    public interface IObjectReference
    {

        /// <summary>
        /// Synchronously loads the object reference of type T.
        /// </summary>
        public T Load<T>() 
            where T : class;




        /// <summary>
        /// Asynchronously loads the object reference of type T.
        /// </summary>
        public Awaitable<T> LoadAsync<T>()
            where T : class;


        /// <summary>
        /// Asynchronously loads the object reference of type T 
        /// with a callback on completion.
        /// </summary>
        public async void LoadAsync<T>(Action<T> onComplete = null)
            where T : class
        {
            onComplete?.Invoke(await LoadAsync<T>());
        }




        /// <summary>
        /// Releases any stored operation results or handles
        /// and cleans up the cached object reference if caching is implemented.
        /// </summary>
        public void Release();

    }



    /// <summary>
    /// Interface for an object reference of specific type 
    /// with synchronous and asynchronous loading support.
    /// </summary>
    public interface IObjectReference<TObject> : IObjectReference
        where TObject : class
    {

        /// <summary>
        /// Synchronously loads the object reference.
        /// </summary>
        public TObject Load();




        /// <summary>
        /// Asynchronously loads the object reference.
        /// </summary>
        public Awaitable<TObject> LoadAsync();


        /// <summary>
        /// Asynchronously loads the object reference 
        /// with a callback on completion.
        /// </summary>
        public async void LoadAsync(Action<TObject> onComplete = null)
        {
            onComplete?.Invoke(await LoadAsync());
        }

    }

}
