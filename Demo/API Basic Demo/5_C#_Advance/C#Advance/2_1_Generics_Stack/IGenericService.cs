using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2_1_Generics_Stack
{
   
        /// <summary>
        /// Represents a generic service interface for basic CRUD operations.
        /// </summary>
        /// <typeparam name="T">The type of entity managed by the service.</typeparam>
        public interface IGenericService<T>
        {
            /// <summary>
            /// Gets all entities of type T.
            /// </summary>
            /// <returns>A list of entities.</returns>
            Stack<T> GetAll();

            /// <summary>
            /// Gets an entity of type T by its unique identifier.
            /// </summary>
            /// <param name="id">The unique identifier of the entity.</param>
            /// <returns>The entity with the specified identifier.</returns>
            T GetById(int id);

            /// <summary>
            /// Inserts a new entity of type T.
            /// </summary>
            /// <param name="entity">The entity to be inserted.</param>
            /// <returns>A list of entities after the insertion operation.</returns>
            Stack<T> Insert(T entity);

            /// <summary>
            /// Deletes an entity of type T by its unique identifier.
            /// </summary>
            /// <param name="id">The unique identifier of the entity to be deleted.</param>
            /// <returns>A list of entities after the deletion operation.</returns>
            Stack<T> Delete(int id);
        }
    }
