using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DIMS_Core.Controllers
{
    public abstract class BaseController : Controller
    {
        protected readonly IMapper Mapper;
        protected readonly ILogger Logger;

        /// <summary>
        /// Base constructor which need to implement in each child class.
        /// </summary>
        /// <param name="mapper">DI mapper</param>
        /// <param name="logger">Here need generic variant of logger ILogger where T is current controller.</param>
        protected BaseController(IMapper mapper, ILogger logger)
        {
            Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    }
}