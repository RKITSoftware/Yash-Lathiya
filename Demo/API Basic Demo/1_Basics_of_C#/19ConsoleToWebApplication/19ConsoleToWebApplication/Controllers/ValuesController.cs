using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _19ConsoleToWebApplication.Controllers
{
    /// <summary>
    /// Implements methods for Routing  
    /// </summary>
    [ApiController]
    [Route("[action]/[controller]")] // Controller = ValuesController & action = getall (Method Name)
    public class ValuesController : ControllerBase
    {
        #region Public Routing Methods

        /// <summary>
        /// Routing 
        /// </summary>
        /// <returns>Content in webpage</returns>

        [Route("api/get-all")]
        [Route("getall")]
        [Route("get-all")]
        public string GetAll()
        {
            return "hello from get all ";
        }

        /// <summary>
        /// Routing 
        /// </summary>
        /// <returns>Content in webpage</returns>
        
        [Route("api/get-all-authors")]
        //[Route("getall")] this is not possible
        public string GetAllAuthors()
        {
            return "hello from get all authors";
        }

        /// <summary>
        /// Routing 
        /// </summary>
        /// <returns>Content in webpage</returns>
        
        [Route("books/{id}")]
        public string GetById(int id)
        {
            return "Hello " + id;
        }

        /// <summary>
        /// Routing 
        /// </summary>
        /// <returns>Content in webpage</returns>
        
        [Route("books/{id}/author/{authorId}")]
        public string GetAuthorAddressById(int id, int authorId)
        {
            return "Hello author address" + id + authorId;
        }

        /// <summary>
        /// for url/search?name=yash&id=95&price=850
        /// </summary>
        /// <param name="id"></param>
        /// <param name="authorId"></param>
        /// <param name="name"></param>
        /// <param name="rating"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        [Route("search")]
        public string SearchBooks(int id, int authorId, string name, int rating, int price)
        {
            return "Hello from search ";
        }

        #endregion
    }
}
