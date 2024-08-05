namespace GK.FlexibleObjectReference.Interfaces
{
    using System;
    using UnityEngine;


    /// <summary>
    /// Interface for a Unity object reference 
    /// with synchronous and asynchronous loading support.
    /// </summary>
    public interface IUnityObjectReference : IObjectReference
    {
    
        /// <summary>
        /// Synchronously loads the Unity object reference of type T.
        /// </summary>
        public new T Load<T>()
            where T : UnityEngine.Object;
    
    


        /// <summary>
        /// Asynchronously loads the Unity object reference of type T.
        /// </summary>
        public new Awaitable<T> LoadAsync<T>()
            where T : UnityEngine.Object;
    

        /// <summary>
        /// Asynchronously loads the Unity object reference of type T 
        /// with a callback on completion.
        /// </summary>
        public new async void LoadAsync<T>(Action<T> onComplete = null)
            where T : UnityEngine.Object
        {
            onComplete?.Invoke(await LoadAsync<T>());
        }
    
    }



    /// <summary>
    /// Interface for a Unity object reference of specific type 
    /// with synchronous and asynchronous loading support.
    /// </summary>
    public interface IUnityObjectReference<TObject> : IObjectReference<TObject>, IUnityObjectReference
        where TObject : UnityEngine.Object
    {

    }

}
