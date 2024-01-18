using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GenericList.Controllers
{
    public class GenericController<T>: ApiController where T : class
    {
        static List<T> entities = new List<T>();

        // Endpoint to get all entities
        [HttpGet]
        public IHttpActionResult GetAllEntities()
        {
            return Ok(entities);
        }

        // Endpoint to get an entity by ID
        [HttpGet]
        public IHttpActionResult GetEntityById(int id)
        {
            T entity3 = entities.Find(e => GetEntityId(e) == id);
            if (entity3 != null)
            {
                return Ok(entity3);
            }
            else
            {
                return NotFound();
            }
        }

        // Endpoint to add a new entity
        [HttpPost]
        public IHttpActionResult AddEntity([FromBody] T entity)
        {
            entities.Add(entity);
            return Ok("Entity added successfully");
        }

        // Endpoint to update an existing entity
        [HttpPut]
        public IHttpActionResult UpdateEntity(int id, [FromBody] T updatedEntity)
        {
            T existingEntity = entities.Find(e => GetEntityId(e) == id);
            if (existingEntity != null)
            {
                // Update properties of the existing entity
                // (You may need to implement your update logic based on your entity structure)
                // For simplicity, we are replacing the entire entity in this example
                entities.Remove(existingEntity);
                entities.Add(updatedEntity);
                return Ok("Entity updated successfully");
            }
            else
            {
                return NotFound();
            }
        }

        // Endpoint to delete an entity by ID
        [HttpDelete]
        public IHttpActionResult DeleteEntity(int id)
        {
            T entity = entities.Find(e => GetEntityId(e) == id);
            if (entity != null)
            {
                entities.Remove(entity);
                return Ok("Entity deleted successfully");
            }
            else
            {
                return NotFound();
            }
        }

        // We need to implement this method in your derived classes to get the ID of the entity
        protected virtual int GetEntityId(T entity)
        {
            // This method can be overridden in derived classes for custom implementations
            return 0;

        }
    }
}
