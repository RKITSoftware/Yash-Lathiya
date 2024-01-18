using GenericList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GenericList.Controllers
{
    public class ProductController : GenericController<Pro01>
    {
        protected override int GetEntityId(Pro01 objPro01)
        {
            return (int)objPro01.GetType().GetProperty("o01f01").GetValue(objPro01);
        }
    }
}
