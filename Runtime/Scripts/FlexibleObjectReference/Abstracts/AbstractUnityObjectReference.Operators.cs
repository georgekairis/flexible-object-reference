namespace GK.FlexibleObjectReference.Abstracts
{

    public abstract partial class AbstractUnityObjectReference<TReference, TObject>
    {

        /// <summary>
        /// Implicitly converts the reference container 
        /// to the underlying Unity Object of type TObject.
        /// </summary>
        public static implicit operator TObject(AbstractUnityObjectReference<TReference, TObject> source)
        {
            return source.Load();
        }

    }

}
