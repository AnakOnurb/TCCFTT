using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CARE_Web_API.Models
{
    public class IOperator
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Cellphone { get; set; }
        public string Password { get; set; }
        public int TypeId { get; set; }
        public bool Active { get; set; }
   
        public IOperator()
        { }

        public IOperator(string login, string email, string name, string cellphone, int typeId, bool active)
        {
            Login = login;
            Email = email;
            Name = name;
            Cellphone = cellphone;
            TypeId = typeId;
            Active = active;
        }

        public IOperator(int id, string login, string email, string name, string cellphone, int typeId, bool active)
        {
            Id = id;
            Login = login;
            Email = email;
            Name = name;
            Cellphone = cellphone;
            TypeId = typeId;
            Active = active;
        }
    }
}
