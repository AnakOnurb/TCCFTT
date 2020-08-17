using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CARE_Web_API.Models;

namespace CARE_Web_API.Utils
{
    public class ISession
    {
        private string token;
        private DateTime timeStamp;
        private IUser user;
        private bool status;

        public ISession(DateTime timeStamp, IUser user)
        {
            //this.timeStamp = timeStamp;
            //this.user = user;
            //token = user.Id + "" + timeStamp.Millisecond.ToString();
            //status = true;
        }
    }
}
