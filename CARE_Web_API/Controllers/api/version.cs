using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using CARE_Web_API.Utils;
using CARE_Web_API.Models;

namespace CARE_Web_API.Controllers.api
{
    [Route("api/version")]
    [ApiController]
    public class version : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            string output = "{\"current\":\"v1.0\"}";
            JObject json = JObject.Parse(output);
            return json.ToString();
        }
    }
}
