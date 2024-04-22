using DotNet_Core_Fundamentals.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DotNet_Core_Fundamentals.Controllers
{
    /// <summary>
    /// Home page 
    /// </summary>
    public class HomeController : Controller
    {
        #region Private Members

        /// <summary>
        /// ILogger
        /// </summary>
        private readonly ILogger<HomeController> _logger;

        #endregion

        #region Constructor

        /// <summary>
        /// takes reference of ILogger object
        /// </summary>
        /// <param name="logger"></param>
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        #endregion

        #region Public Methods

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /// <summary>
        /// Test method which returns hello message
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/test")]
        public IActionResult Hello()
        {
            return Ok("Hello from Yash");
        }

        #endregion
    }
}