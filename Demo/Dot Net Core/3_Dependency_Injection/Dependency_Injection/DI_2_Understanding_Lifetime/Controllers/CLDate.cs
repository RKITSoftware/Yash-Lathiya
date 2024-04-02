﻿using DI_2_Understanding_Lifetime.Middleware;
using DI_2_Understanding_Lifetime.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DI_2_Understanding_Lifetime.Controllers
{
    /// <summary>
    /// Shows working of service lifetime 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CLDate : ControllerBase
    {
        private readonly IDateTime _date;

        /// <summary>
        /// added dependency of service IDateTime
        /// </summary>
        /// <param name="date"></param>
        public CLDate(IDateTime date) 
        { 
            _date = date;
        }

        /// <summary>
        /// Which will compare both the date from middleware & from this controller 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("TestServiceLifetime")]
        public IActionResult TestServiceLifetime()
        {
            string date = _date.GetDate();
            Console.WriteLine("** From Controller : " + date);

            return Ok(" ### Check result in terminal ### ");
        }
    }
}