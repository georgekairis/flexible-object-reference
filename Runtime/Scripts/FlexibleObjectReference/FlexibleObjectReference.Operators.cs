namespace GK.FlexibleObjectReference
{

    public partial class Flexible<TObject>
    {

        /// <summary>
        /// Implicitly converts the flexible reference container 
        /// to the underlying object of type TObject.
        /// </summary>
        public static implicit operator TObject(Flexible<TObject> source)
        {
            return source.Load();
        }

    }

}
