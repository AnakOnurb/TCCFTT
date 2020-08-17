using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace CARE_Web_API.Models
{
    public class IUser
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string Sus { get; set; }
        public string Cellphone { get; set; }
        public string Password { get; set; }

        public IUser() 
        { }

        public IUser(string email, string birthdate, string name, string cpf, string rg, string sus, string cellphone)
        {
            Email = email;
            BirthDate = DateTime.Parse(birthdate);
            Name = name;
            Cpf = cpf;
            Rg = rg;
            Sus = sus;
            Cellphone = cellphone;
        }

        public IUser(int id, string email, string birthdate, string name, string cpf, string rg, string sus, string cellphone)
        {
            Id = id;
            Email = email;
            BirthDate = DateTime.Parse(birthdate);
            Name = name;
            Cpf = cpf;
            Rg = rg;
            Sus = sus;
            Cellphone = cellphone;
        }
    }
}
