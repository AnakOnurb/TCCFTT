using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CARE_Web_API.Models
{
    public class ILocation
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public string Name { get; set; }
        public ICoordinate Coordinate { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public string Pais { get; set; }

        public ILocation()
        { }

        public ILocation(int typeId, string name, ICoordinate coordinate, string logradouro, int numero, string bairro, string complemento, string cep, string cidade, string uf, string pais)
        {
            TypeId = typeId;
            Name = name;
            Coordinate = coordinate;
            Logradouro = logradouro;
            Numero = numero;
            Bairro = bairro;
            Complemento = complemento;
            Cep = cep;
            Cidade = cidade;
            Uf = uf;
            Pais = pais;
        }

        public ILocation(int id, int typeId, string name, ICoordinate coordinate, string logradouro, int numero, string bairro, string complemento, string cep, string cidade, string uf, string pais)
        {
            Id = id;
            TypeId = typeId;
            Name = name;
            Coordinate = coordinate;
            Logradouro = logradouro;
            Numero = numero;
            Bairro = bairro;
            Complemento = complemento;
            Cep = cep;
            Cidade = cidade;
            Uf = uf;
            Pais = pais;
        }
    }
}
