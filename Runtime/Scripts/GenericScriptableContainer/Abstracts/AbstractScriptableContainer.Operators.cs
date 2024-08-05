namespace GK.FlexibleObjectReference.Abstracts
{

    public abstract partial class AbstractScriptableContainer<T>
    {

        /// <summary>
        /// Implicitly converts the scriptable container 
        /// to the underlying object of type T.
        /// </summary>
        public static implicit operator T(AbstractScriptableContainer<T> source)
        {
            return source.Object;
        }

    }

}
