﻿using System;
using System.Diagnostics;
using DIMS_Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DIMS_Core.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        ///     You can look examples of logger events if you will run the action.
        /// </summary>
        /// <returns></returns>
        public IActionResult CheckLogger()
        {
            _logger.LogTrace("Trace log message");
            _logger.LogDebug("Debug log message");
            _logger.LogInformation("Info log message");
            _logger.LogWarning("Warn log message");
            _logger.LogError("Error log message");
            _logger.LogCritical("Fatal log message");

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
                        {
                            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
                        });
        }
    }
}