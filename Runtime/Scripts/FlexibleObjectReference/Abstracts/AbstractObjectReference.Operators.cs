namespace GK.FlexibleObjectReference.Abstracts
{

    public abstract partial class AbstractObjectReference<TReference, TObject>
    {

        /// <summary>
        /// Implicitly converts the reference container 
        /// to the underlying object of type TObject.
        /// </summary>
        public static implicit operator TObject(AbstractObjectReference<TReference, TObject> source)
        {
            return source.Load();
        }

    }

}
