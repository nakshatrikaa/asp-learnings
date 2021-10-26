using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Learn.DependencyInjection.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries =
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly IAnotherDependencyService _anotherDependencyService;
        private readonly IEnumerable<IOperationSingletonInstance> _singletonInstances;
        private readonly IDependencyService _dependencyService;

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IDependencyService dependencyService,
                                         IAnotherDependencyService anotherDependencyService,
                                         IEnumerable<IOperationSingletonInstance> singletonInstances)
        {
            _logger = logger;
            _dependencyService = dependencyService;
            _anotherDependencyService = anotherDependencyService;
            _singletonInstances = singletonInstances;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            foreach (var operationSingletonInstance in _singletonInstances)
            {
                Console.WriteLine(operationSingletonInstance.OperationId);
            }
            _dependencyService.Write();
            _anotherDependencyService.Write();
            return Enumerable.Empty<WeatherForecast>();
        }
    }
}