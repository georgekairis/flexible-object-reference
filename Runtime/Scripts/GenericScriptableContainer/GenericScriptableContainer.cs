namespace GK.FlexibleObjectReference
{
    using GK.FlexibleObjectReference.Abstracts;
    using UnityEngine;


    /// <summary>
    /// Generic scriptable object that contains 
    /// an instance of type T.
    /// </summary>
    public class GenericScriptableContainer<T> : AbstractScriptableContainer<T>
        where T : class
    {

        #region PROPERTIES
        /// <summary>
        /// The object reference of type T stored in the 
        /// scriptable object.
        /// </summary>
        public override T Object
        {
            get => _object;
        }
        #endregion






        #region FIELDS
        /// <summary>
        /// Contains the stored instance of type T.
        /// </summary>
        [SerializeField]
        protected T _object;
        #endregion

    }

}
