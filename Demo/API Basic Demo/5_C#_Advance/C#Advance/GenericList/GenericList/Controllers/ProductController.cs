using GenericList.Models;

namespace GenericList.Controllers
{
    /// <summary>
    /// Product Controller is inheriting properties from Generic Controller where T = Pro01
    /// </summary>
    public class ProductController : GenericController<Pro01>
    {
        /// <summary>
        /// Implemented method which identifies entity by id 
        /// </summary>
        /// <param name="objPro01"> Object of Pro01 class </param>
        /// <returns></returns>
        protected override int GetEntityId(Pro01 objPro01)
        {
            return (int)objPro01.GetType().GetProperty("o01f01").GetValue(objPro01);
        }
    }
}
