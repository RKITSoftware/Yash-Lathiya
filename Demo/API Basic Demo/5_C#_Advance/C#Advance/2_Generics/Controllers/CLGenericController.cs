using System.Web.Http;

namespace _2_Generics.Controllers
{
    /// <summary>
    /// Generic Controller implementation
    /// </summary>
    /// <typeparam name="T"> Any type of information </typeparam>
    public class CLGenericController<T> : ApiController
    {
        #region Public Method

        /// <summary>
        /// Any tiype of information retrieved
        /// </summary>
        /// <param name="information"></param>
        /// <returns> Information </returns>
        public T GetInformation(T information)
        {
            return information;
        }

        #endregion
    }
}
