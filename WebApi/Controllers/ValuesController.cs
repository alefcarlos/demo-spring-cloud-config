using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IOptionsSnapshot<ConfigServerData> _configServerData { get; set; }

        private IConfigurationRoot _config { get; set; }

        public ValuesController(IConfigurationRoot config, IOptionsSnapshot<ConfigServerData> configServerData)
        {
            _configServerData = configServerData;
            _config = config;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var data = _configServerData.Value;

            return new string[] { data.ConfigurationA, data.ConfigurationB };
        }
    }
}
