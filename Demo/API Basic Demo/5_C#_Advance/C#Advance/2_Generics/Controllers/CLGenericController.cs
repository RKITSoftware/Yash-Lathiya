using _2_Generics.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml.Linq;

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
