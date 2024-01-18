using GenericList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GenericList.Controllers
{
    public class UserController : GenericController<Usr01>
    {
        protected override int GetEntityId(Usr01 objUsr01)
        {
            return (int)objUsr01.GetType().GetProperty("r01f01").GetValue(objUsr01);
        }
    }
}
