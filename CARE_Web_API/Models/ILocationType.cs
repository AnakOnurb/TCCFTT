using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CARE_Web_API.Models
{
    public class ILocationType
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public ILocationType()
        { }

        public ILocationType(string type)
        {
            Type = type;
        }

        public ILocationType(int id, string type)
        {
            Id = id;
            Type = type;
        }
    }
}
