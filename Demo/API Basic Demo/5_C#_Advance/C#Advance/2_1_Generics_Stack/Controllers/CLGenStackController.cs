using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _2_1_Generics_Stack.Controllers
{
    public class CLGenStackController<T> : ApiController where T : class
    {


        public IGenericService<T> _genericService;

        /// <summary>
        /// Initializes a new instance of the GenericController{T} class.
        /// </summary>
        /// <param name="genericService">The generic service used by the controller.</param>
        public CLGenStackController(IGenericService<T> genericService)
        {
            _genericService = genericService;
        }

        /// <summary>
        /// Gets all entities of type T.
        /// </summary>
        /// <returns>A list of entities.</returns>
        [HttpGet]
        public Stack<T> Get()
        {
            return _genericService.GetAll();
        }

        /// <summary>
        /// Gets an entity of type T by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the entity.</param>
        /// <returns>The entity with the specified identifier.</returns>
        [HttpGet]
        public T Get(int id)
        {
            return _genericService.GetById(id);
        }
        /// <summary>
        /// Inserts a new entity of type T.
        /// </summary>
        /// <param name="value">The entity to be inserted.</param>
        /// <returns>A list of entities after the insertion operation.</returns>

        [HttpPost]
        public Stack<T> Post([FromBody] T value)
        {
            return _genericService.Insert(value);
        }

        /// <summary>
        /// Deletes an entity of type T by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the entity to be deleted.</param>
        /// <returns>A list of entities after the deletion operation.</returns>
        [HttpDelete]
        public Stack<T> Delete(int id)
        {
            return _genericService.Delete(id);
        }
    }
    
}

