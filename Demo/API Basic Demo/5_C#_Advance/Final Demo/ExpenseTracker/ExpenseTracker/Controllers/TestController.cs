using ExpenseTracker.Models;
using ExpenseTracker.Static;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ExpenseTracker.Controllers
{
    public class TestController : ApiController
    {
        [HttpGet]
        public IHttpActionResult PocoToDto(DTOCre01 objDTOCre01)
        {
            Cre01 objCre01 = objDTOCre01.ConvertModel<Cre01>();
            return Ok(objCre01);
        }
    }
}
