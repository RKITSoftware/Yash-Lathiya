namespace DI_4_Constructor_Injection.Services
{
    /// <summary>
    /// Class which will collect data from options interface 
    /// </summary>
    public class CowOptions
    {
        #region Public Members 

        /// <summary>
        /// CowSound - Data collects from appSettings.json by options interface
        /// </summary>
        public string CowSound { get; set; }

        #endregion

    }
}
