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
    [Route("api/session")]
    [ApiController]
    public class session : ControllerBase
    {
        // POST: api/<session>
        [HttpPost]
        public string Post([FromBody] ILogin login)
        {
            Logger.Log("Iniciando login");

            IUser user = userObject.ReadByEmail(login.Email);

            if(user != null)
            {
                string savedPass = userObject.ReadPasswordById(user.Id);
                if (Hasher.Verify(login.Password, savedPass))
                {
                    Logger.Log("Usuario valido");                    
                    string json = JsonConvert.SerializeObject(user);
                    return json;
                }
            }            

            Logger.Log("Usuario invalido");
            return null;
        }
    }
}
