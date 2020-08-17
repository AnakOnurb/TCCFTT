using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using CARE_Web_API.Utils;
using CARE_Web_API.Models;
using CARE_Web_API.Utils.DataAccess;

namespace CARE_Web_API.Controllers.api
{
    [Route("api/user")]
    [ApiController]
    public class user : ControllerBase
    {
        // GET: api/<user>
        [HttpGet]
        public string Get()
        {
            return null;
        }

        // GET api/<user>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            Logger.Log("User Get c/ Id recebido");

            IUser user = userObject.ReadById(id);
            string json = JsonConvert.SerializeObject(user);
            return json;
        }

        // POST api/<user>
        [HttpPost]
        public string Post([FromBody] IUser user)
        {
            Logger.Log("User Post recebido");

            bool result;
            if (userObject.ReadByEmail(user.Email) == null)
                result = userObject.Create(user);
            else
                result = false;

            if (result)
            {
                Logger.Log("Sucesso");
                return "{\"status\":\"success\"}";
            }                         
            else
            {
                Logger.Log("Falha");
                return "{\"status\":\"error\"}";
            }                
        }

        // PUT api/<user>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<user>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
