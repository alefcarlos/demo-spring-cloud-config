using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Steeltoe.Extensions.Configuration.ConfigServer;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IOptionsSnapshot<ConfigServerData> _configServerData { get; set; }

        public ValuesController(IOptionsSnapshot<ConfigServerData> configServerData)
        {
            _configServerData = configServerData;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<object>> Get()
        {
            var data = _configServerData.Value;

            return new object[] { data.ConfigurationA, data.ConfigurationB, data.ConfigurationD?.E };
        }
    }
}
