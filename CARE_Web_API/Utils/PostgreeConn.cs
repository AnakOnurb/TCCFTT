using Microsoft.AspNetCore.Connections;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CARE_Web_API.Utils
{
    class PostgreeConn
    {
        public static NpgsqlConnection Connect()
        {
            var connString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ConnectionStrings")["CARE_Dev"];
            NpgsqlConnection conn = new NpgsqlConnection(connString);
            conn.Open();
            return conn;
        }
    }
}
