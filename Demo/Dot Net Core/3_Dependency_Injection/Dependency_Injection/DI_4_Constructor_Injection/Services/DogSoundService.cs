namespace DI_4_Constructor_Injection.Services
{
    /// <summary>
    /// Implements IdogSoundService
    /// </summary>
    public class DogSoundService : IDogSoundService
    {
        /// <summary>
        /// Provides dog sound
        /// </summary>
        /// <returns> dog sound in string format </returns>
        public string GetSound()
        {
            return "Woof";
        }
    }
}
