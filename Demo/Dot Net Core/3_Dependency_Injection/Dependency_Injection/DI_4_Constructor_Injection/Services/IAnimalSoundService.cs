namespace DI_4_Constructor_Injection.Services
{
    /// <summary>
    /// Interface of animal sound service consists methods
    /// </summary>
    public interface IAnimalSoundService
    {
        #region Abstract Methods

        /// <summary>
        /// Provides list which contains all animal sounds 
        /// </summary>
        /// <returns> list of animal sounds </returns>
        public List<string> PlaySounds();

        #endregion

    }
}
