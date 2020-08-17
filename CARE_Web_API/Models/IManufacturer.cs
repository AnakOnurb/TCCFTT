using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CARE_Web_API.Models
{
    public class IManufacturer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IManufacturer()
        { }

        public IManufacturer(string name)
        {
            Name = name;
        }

        public IManufacturer(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
