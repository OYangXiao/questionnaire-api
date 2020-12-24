using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using questionnaire_api.Models;

namespace questionnaire_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<UserItem> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new UserItem
            {
                Id = index,
                Name = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
