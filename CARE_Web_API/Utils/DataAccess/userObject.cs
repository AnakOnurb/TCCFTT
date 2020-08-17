using CARE_Web_API.Models;
using Npgsql;
using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace CARE_Web_API.Utils.DataAccess
{
    class userObject
    {
        public static bool Create(IUser user)
        {
            bool result;
            string safePass = Hasher.Hash(user.Password);

            Logger.Log("Iniciando Create para IUser");

            NpgsqlConnection connection = PostgreeConn.Connect();

            Logger.Log("Conexão aberta");

            try
            {
                string sqlString = String.Format("SET datestyle = \"ISO, DMY\";" +
                    "INSERT INTO cidadao (email, dtnascimento, nome, cpf, rg, codigosus, celular, senha) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}')", 
                    user.Email, user.BirthDate, user.Name, user.Cpf, user.Rg, user.Sus, user.Cellphone, safePass);                

                NpgsqlCommand command = new NpgsqlCommand(sqlString, connection);

                command.ExecuteNonQuery();

                Logger.Log("Sucesso");
                result = true;
            }
            catch (Exception e)
            {
                Logger.Log("Falha: " + e.Message);
                result = false;
            }
            finally
            {
                connection.Close();
                Logger.Log("Conexão encerrada");                
            }

            return result;
        }

        public static IUser ReadById(int userId)
        {
            IUser result;

            Logger.Log("Iniciando Read para IUser: " + userId);

            NpgsqlConnection connection = PostgreeConn.Connect();

            Logger.Log("Conexão aberta");

            try
            {
                //(id, email, dtnascimento, nome, cpf, rg, codigosus, celular)
                string sqlString = "SELECT id, email, dtnascimento, nome, cpf, rg, codigosus, celular FROM cidadao WHERE id = " + userId;

                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(sqlString, connection);

                DataTable tempTable = new DataTable();
                adapter.Fill(tempTable);

                DataRow row = tempTable.Rows[0];
                result = new IUser(Convert.ToInt32(row["id"]), row["email"].ToString(), row["dtnascimento"].ToString(), row["nome"].ToString(), row["cpf"].ToString(), row["rg"].ToString(), row["codigosus"].ToString(), row["celular"].ToString());

                Logger.Log("Sucesso");
                return result;
            }
            catch (Exception e)
            {
                Logger.Log("Falha: " + e.Message);
            }
            finally
            {
                connection.Close();
                Logger.Log("Conexão encerrada");
            }

            return null;
        }

        public static IUser ReadByEmail(string userEmail)
        {
            IUser result;

            Logger.Log("Iniciando Read para E-mail: " + userEmail);

            NpgsqlConnection connection = PostgreeConn.Connect();

            Logger.Log("Conexão aberta");

            try
            {
                //(id, email, dtnascimento, nome, cpf, rg, codigosus, celular)
                string sqlString = "SELECT id, email, dtnascimento, nome, cpf, rg, codigosus, celular FROM cidadao WHERE email = '" + userEmail + "'";

                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(sqlString, connection);

                DataTable tempTable = new DataTable();
                adapter.Fill(tempTable);

                if(tempTable.Rows.Count == 1)
                {
                    DataRow row = tempTable.Rows[0];
                    result = new IUser(Convert.ToInt32(row["id"]), row["email"].ToString(), row["dtnascimento"].ToString(), row["nome"].ToString(), row["cpf"].ToString(), row["rg"].ToString(), row["codigosus"].ToString(), row["celular"].ToString());

                    Logger.Log("Sucesso");
                    return result;
                }
            }
            catch (Exception e)
            {
                Logger.Log("Falha: " + e.Message);
            }
            finally
            {
                connection.Close();
                Logger.Log("Conexão encerrada");
            }

            return null;
        }

        public static string ReadPasswordById(int userId)
        {
            string result;

            Logger.Log("Iniciando Read de senha para id: " + userId);

            NpgsqlConnection connection = PostgreeConn.Connect();

            Logger.Log("Conexão aberta");

            try
            {
                //(id, email, dtnascimento, nome, cpf, rg, codigosus, celular)
                string sqlString = "SELECT senha FROM cidadao WHERE id = " + userId;

                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(sqlString, connection);

                DataTable tempTable = new DataTable();
                adapter.Fill(tempTable);

                if (tempTable.Rows.Count == 1)
                {
                    DataRow row = tempTable.Rows[0];
                    result = row["senha"].ToString();

                    Logger.Log("Sucesso");
                    return result;
                }
            }
            catch (Exception e)
            {
                Logger.Log("Falha: " + e.Message);
            }
            finally
            {
                connection.Close();
                Logger.Log("Conexão encerrada");
            }

            return null;
        }

        public static bool Update(IUser user)
        {
            bool result;

            Logger.Log("Iniciando Update para IUser");

            NpgsqlConnection connection = PostgreeConn.Connect();

            Logger.Log("Conexão aberta");

            try
            {
                string sqlString = String.Format("SET datestyle = \"ISO, DMY\";" +
                    "UPDATE cidadao SET email='{0}', dtnascimento='{1}', nome='{2}', cpf='{3}', rg='{4}', codigosus='{5}', celular='{6}'" +
                    "WHERE cidadao.id={7}",
                    user.Email, user.BirthDate, user.Name, user.Cpf, user.Rg, user.Sus, user.Cellphone, user.Id);

                NpgsqlCommand command = new NpgsqlCommand(sqlString, connection);

                command.ExecuteNonQuery();

                Logger.Log("Sucesso");
                result = true;
            }
            catch (Exception e)
            {
                Logger.Log("Falha: " + e.Message);
                result = false;
            }
            finally
            {
                connection.Close();
                Logger.Log("Conexão encerrada");
            }

            return result;
        }

        public static bool Delete(int userId)
        {
            bool result;

            Logger.Log("Iniciando Delete para IUser");

            NpgsqlConnection connection = PostgreeConn.Connect();

            Logger.Log("Conexão aberta");

            try
            {
                string sqlString = String.Format(
                    "DELETE FROM cidadao WHERE cidadao.id={0}", userId);

                NpgsqlCommand command = new NpgsqlCommand(sqlString, connection);

                command.ExecuteNonQuery();

                Logger.Log("Sucesso");
                result = true;
            }
            catch (Exception e)
            {
                Logger.Log("Falha: " + e.Message);
                result = false;
            }
            finally
            {
                connection.Close();
                Logger.Log("Conexão encerrada");
            }

            return result;
        }

    }
}
