//using System;
//using System.Collections.Generic;
//using System.Web.Http;

//[RoutePrefix("api/stack")]
//public class CLGenericStackController<T> : ApiController
//{
//    private Stack<T> _stack = new Stack<T>();

//    public Stack<T> Stack
//    {
//        get { return _stack; }
//        set { _stack = value; }
//    }

//    [HttpGet]
//    [Route("")]
//    public IHttpActionResult GetStack()
//    {
//        return Ok(_stack.ToArray());
//    }

//    [HttpPost]
//    [Route("")]
//    public IHttpActionResult PushToStack(T item)
//    {
//        _stack.Push(item);
//        return Ok(item);
//    }

//    [HttpDelete]
//    [Route("")]
//    public IHttpActionResult PopFromStack()
//    {
//        try
//        {
//            if (_stack.Count == 0)
//            {
//                return NotFound();
//            }

//            var topItem = _stack.Pop();
//            return Ok(topItem);
//        }
//        catch (InvalidOperationException)
//        {
//            return NotFound();
//        }
//    }
//}
