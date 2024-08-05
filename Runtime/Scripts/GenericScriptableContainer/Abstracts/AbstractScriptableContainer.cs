namespace GK.FlexibleObjectReference.Abstracts
{
    using GK.FlexibleObjectReference.Interfaces;
    using UnityEngine;


    /// <summary>
    /// Abstract scriptable object that contains 
    /// a reference of type T.
    /// </summary>
    public abstract partial class AbstractScriptableContainer<T> : ScriptableObject, IScriptableContainer<T>
        where T : class
    {

        #region PROPERTIES
        /// <summary>
        /// The object reference of type T stored in the 
        /// scriptable object.
        /// </summary>
        public abstract T Object { get; }
        #endregion

    }

}
