#define Sachin
//#define Maahi
using System.Web.Http;

namespace Debugging.Controllers
{
    /// <summary>
    /// This controller demonstrates usecase of breakpoint & debugging
    /// </summary>
    public class CLDebugController : ApiController
    {
        /// <summary>
        ///     GET : api/breakpoint
        ///     We can understand the behaviour of debugging by using breakpoint at starting of for loop.
        /// </summary>
        /// <returns> Message contains count & name </returns>
        [HttpGet]
        [Route("api/breakpoint")]
        public IHttpActionResult BreakpointsDemo()
        {
            char[] letters = { 'S', 'a', 'c', 'h', 'i', 'n', '&', 'M', 'S', 'D' };
            string name = "";

            int[] count = new int[10];

            string myMessage = "";

            for (int i = 0; i < letters.Length; i++)
            {
                name += letters[i];
                count[i] = i + 1;
                myMessage = SendMessage(name, count[i]);
            }
            
            return Ok(myMessage);
        }

        /// <summary>
        /// takes argument as name & count and structure response sentence
        /// </summary>
        /// <param name="name"> name </param>
        /// <param name="count"> count </param>
        /// <returns> structured response </returns>
        private string SendMessage(string name, int count)
        {
            string message = "Hello " + name + ", My current count is " + count;

            return message;
        }

        /// <summary>
        /// Conditional compilation, It compiles on the bases of defined condition at above the script
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("conditionalCompilation")]
        public IHttpActionResult ConditionalCompilation() 
        {
#if Sachin
            return Ok("Sachin Tendulkar");
#elif Maahi  
            return Ok("Mahendra Singh Dhoni");
#else
            return Ok("Yash");
#endif
        }
    }
}
