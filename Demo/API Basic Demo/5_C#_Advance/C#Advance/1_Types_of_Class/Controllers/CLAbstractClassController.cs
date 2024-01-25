using _1_Types_of_Class.Class.Abstract_Class;
using System.Web.Http;

namespace _1_Types_of_Class.Controllers
{
    /// <summary>
    /// Demonstrates use of abstract class
    /// </summary>
    public class CLAbstractClassController : ApiController
    {
        /// <summary>
        ///     Demonstrate abstract method in child class -> parent class is Abstract class
        /// </summary>
        /// <returns> Identity of the method </returns>
        [HttpGet]
        [Route("AbstractClass/who")]
        public IHttpActionResult Who()
        {
            ChildClass childClass = new ChildClass();  
            
            return Ok(childClass.Who());
            
        }

        /// <summary>
        /// Demonstartes non-abstract method in child class -> parent class is abstract class
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("AbstractClass/greeting")]
        public IHttpActionResult Greeting(string name)
        {
            ChildClass childClass = new ChildClass();

            return Ok(childClass.Greetings(name));

        }
    }
}
