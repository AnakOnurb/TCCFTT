using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CARE_Web_API.Models
{
    public class IOperatorType
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public IOperatorType()
        { }

        public IOperatorType(string type)
        {
            Type = type;
        }

        public IOperatorType(int id, string type)
        {
            Id = id;
            Type = type;
        }
    }
}
