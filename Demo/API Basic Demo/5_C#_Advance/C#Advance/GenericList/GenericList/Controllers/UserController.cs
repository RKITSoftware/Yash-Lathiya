using GenericList.Models;

namespace GenericList.Controllers
{
    /// <summary>
    /// User Controller is inheriting properties from Generic Controller where T = Usr01
    /// </summary>
    public class UserController : GenericController<Usr01>
    {
        /// <summary>
        /// Implemented method which identifies entity by id 
        /// </summary>
        /// <param name="objPro01"> Object of Usr01 class </param>
        /// <returns></returns>
        protected override int GetEntityId(Usr01 objUsr01)
        {
            return (int)objUsr01.GetType().GetProperty("r01f01").GetValue(objUsr01);
        }
    }
}
