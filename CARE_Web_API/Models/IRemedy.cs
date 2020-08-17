using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CARE_Web_API.Models
{
    public class IRemedy
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ManufacturerId { get; set; }

        public IRemedy()
        { }

        public IRemedy(string name, int manufacturerId)
        {
            Name = name;
            ManufacturerId = manufacturerId;
        }

        public IRemedy(int id, string name, int manufacturerId)
        {
            Id = id;
            Name = name;
            ManufacturerId = manufacturerId;
        }
    }
}
