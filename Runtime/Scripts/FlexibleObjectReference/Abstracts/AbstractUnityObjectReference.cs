namespace GK.FlexibleObjectReference.Abstracts
{
    using GK.FlexibleObjectReference.Interfaces;
    using System;
    using UnityEngine;


    /// <summary>
    /// Abstract implementation of a Unity object reference of specific type 
    /// with synchronous and asynchronous loading support.
    /// </summary>
    [Serializable]
    public abstract partial class AbstractUnityObjectReference<TReference, TObject> : AbstractObjectReference<TReference, TObject>, IUnityObjectReference<TObject>
        where TObject : UnityEngine.Object
    {

        #region CONSTRUCTORS
        /// <summary>
        /// Initializes a new instance of the AbstractUnityObjectReference class.
        /// </summary>
        public AbstractUnityObjectReference() :
            base(default)
        {
        
        }

        /// <summary>
        /// Initializes a new instance of the AbstractUnityObjectReference class 
        /// with a pre-loaded reference.
        /// </summary>
        public AbstractUnityObjectReference(TReference reference) :
            base(reference)
        {

        }

        /// <summary>
        /// Initializes a new instance of the AbstractUnityObjectReference class 
        /// with pre-loaded reference and object.
        /// </summary>
        public AbstractUnityObjectReference(TReference reference, TObject obj) :
            base(reference, obj)
        {

        }
        #endregion






        /// <summary>
        /// Synchronously loads the object reference.
        /// </summary>
        public new T Load<T>()
            where T : UnityEngine.Object
        {
            return base.Load<T>();
        }

        T IObjectReference.Load<T>()
            where T : class
        {
            return base.Load<T>();
        }






        /// <summary>
        /// Asynchronously loads the object reference.
        /// </summary>
        public new Awaitable<T> LoadAsync<T>()
            where T : UnityEngine.Object
        {
            return base.LoadAsync<T>();
        }

        Awaitable<T> IObjectReference.LoadAsync<T>()
            where T : class
        {
            return base.LoadAsync<T>();
        }

    }

}
