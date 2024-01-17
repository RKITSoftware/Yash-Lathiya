using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _2_Generics.Controllers
{
    public class CLGenericStackController<T> : ApiController
    {
        private Stack<T> stack = new Stack<T>();

        [HttpGet]
        [Route("api/stack")]
        public IHttpActionResult GetStack()
        {
            return Ok(stack.ToArray());
        }

        [HttpPost]
        [Route("api/stack")]
        public IHttpActionResult PushToStack(T item)
        {
            stack.Push(item);
            return Ok(item);
        }

        [HttpDelete]
        [Route("api/stack")]
        public IHttpActionResult PopFromStack()
        {
            if (stack.Count == 0)
            {
                return NotFound();
            }

            var topItem = stack.Pop();
            return Ok(topItem);
        }
    }
}
