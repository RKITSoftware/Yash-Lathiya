namespace DotNet_Core_Fundamentals.Models
{
    /// <summary>
    /// Errror View Model
    /// </summary>
    public class ErrorViewModel
    {
        #region Public Members

        /// <summary>
        /// Request Id
        /// </summary>
        public string? RequestId { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Show Request ID
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        #endregion
    }
}