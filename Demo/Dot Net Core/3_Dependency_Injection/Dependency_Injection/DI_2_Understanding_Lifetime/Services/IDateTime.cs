namespace DI_2_Understanding_Lifetime.Services
{
    /// <summary>
    /// Method contaiins GetDate
    /// </summary>
    public interface IDateTime
    {
        #region Public Methods

        /// <summary>
        /// Get Date & Time
        /// </summary>
        /// <returns> Date & Time in string format </returns>
        public string GetDate();

        #endregion

    }
}
