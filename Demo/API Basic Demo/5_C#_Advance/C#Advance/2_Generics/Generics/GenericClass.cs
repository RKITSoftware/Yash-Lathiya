namespace _2_Generics.Generics
{
    /// <summary>
    ///  Generic Class
    /// </summary>
    /// <typeparam name="T"> Any type of information </typeparam>
    public class GenericClass<T>
    {
        #region Public Constructor

        /// <summary>
        /// Information will be printed on Output tab
        /// </summary>
        /// <param name="information"></param>
        public GenericClass(T information) 
        {
            System.Diagnostics.Debug.WriteLine(information);
        }

        #endregion
    }
}