namespace DI_4_Constructor_Injection.Services
{
    /// <summary>
    /// Interface of Dog sound Service
    /// </summary>
    public interface IDogSoundService
    {
        #region Public Methods

        /// <summary>
        /// Provides Dog Sound
        /// </summary>
        /// <returns> dog sound in string format </returns>
        public string GetSound();

        #endregion

    }
}
