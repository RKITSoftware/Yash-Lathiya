namespace _2_Generics.Generics
{
    /// <summary>
    /// Class consisting generic method
    /// </summary>
    public class GenericMethod
    {
        #region Public Method

        /// <summary>
        /// Generic method which can accept any type of information
        /// </summary>
        /// <typeparam name="T"> Type of information </typeparam>
        /// <param name="information"></param>
        /// <returns> Information </returns>
        public T GenericMethodOfClass<T>(T information)
        {
            return information;
        }

        #endregion
    }
}