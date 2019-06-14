using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RpgApp_Model;
using System.Data.SqlClient;
using System.Data;

namespace RpgApp_Data
{
    public class UserContext
    {
        ConnectionString connString = new ConnectionString();

        public User LoginUser(string name, string password)
        {
            User user = new User();

            using (connString.connectionString)
            {
                connString.connectionString.Open();

                SqlCommand cmd = new SqlCommand("LoginUser", connString.connectionString);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@password", password);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            user.CharacterId = reader.GetInt32(0);
                            user.Name = reader.GetString(1);
                            user.Level = reader.GetInt32(2);
                            user.MaxHp = reader.GetInt32(3);
                            user.Attack = reader.GetInt32(4);
                            user.Defense = reader.GetInt32(5);
                            user.Speed = reader.GetInt32(6);
                            user.Class = reader.GetString(8);
                            user.CurrentExp = reader.GetInt32(9);
                            user.NextExp = reader.GetInt32(10);
                            user.TotalExp = reader.GetInt32(11);

                            //double half = user.MaxHp * 0.5;
                            //Math.Round(half, 0, MidpointRounding.AwayFromZero);
                            //user.HalfHp = Convert.ToInt32(half);

                            //double min = user.MaxHp * 0.15;
                            //Math.Round(min, 0, MidpointRounding.AwayFromZero);
                            //user.LowHp = Convert.ToInt32(min);
                        }

                        connString.connectionString.Close();
                        return user;
                    }
                    else
                    {
                        user = null;

                        connString.connectionString.Close();
                        return user;
                    }
                }
            }
        }

        public void RegisterUser(User user)
        {
            using (connString.connectionString)
            {
                connString.connectionString.Open();

                SqlCommand cmd = new SqlCommand(RegisterClass(user.Class), connString.connectionString);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", user.Name);
                cmd.Parameters.AddWithValue("@password", user.Password);
                cmd.Parameters.AddWithValue("@class", user.Class);

                cmd.ExecuteNonQuery();

                connString.connectionString.Close();
            }
        }

        public string RegisterClass(string klasse)
        {
            string q = null;

            switch (klasse)
            {
                case "Knight":
                    q = "RegisterKnight";
                    break;
                case "Valkyrie":
                    q = "RegisterValkyrie";
                    break;
                case "Spooky":
                    q = "RegisterSpooky";
                    break;
            }

            return q;
        }

        public User SummaryUser(string username)
        {
            using (connString.connectionString)
            {
                User u = new User();

                SqlCommand cmd = new SqlCommand("SummaryUser", connString.connectionString);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", username);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            u.Name = reader.GetString(0);
                            u.Level = reader.GetInt32(1);
                            u.MaxHp = reader.GetInt32(2);
                            u.Attack = reader.GetInt32(3);
                            u.Defense = reader.GetInt32(4);
                            u.Speed = reader.GetInt32(5);
                            u.Class = reader.GetString(6);
                            u.CurrentExp = reader.GetInt32(7);
                            u.NextExp = reader.GetInt32(8);
                            u.TotalExp = reader.GetInt32(9);
                        }

                        connString.connectionString.Close();
                        return u;
                    }
                    else
                    {
                        connString.connectionString.Close();
                        return u;
                    }
                }
            }
        }

        public void UpdateUser(User user)
        {
            using (connString.connectionString)
            {
                connString.connectionString.Open();

                SqlCommand cmd = new SqlCommand("UpdateUser", connString.connectionString);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@characterid", user.CharacterId);
                cmd.Parameters.AddWithValue("@level", user.Level);
                cmd.Parameters.AddWithValue("@maxhp", user.MaxHp);
                cmd.Parameters.AddWithValue("@attack", user.Attack);
                cmd.Parameters.AddWithValue("@defense", user.Defense);
                cmd.Parameters.AddWithValue("@speed", user.Speed);
                cmd.Parameters.AddWithValue("@class", user.Class);
                cmd.Parameters.AddWithValue("@currentexp", user.CurrentExp);
                cmd.Parameters.AddWithValue("@nextexp", user.NextExp);
                cmd.Parameters.AddWithValue("@totalexp", user.TotalExp);
                cmd.ExecuteNonQuery();

                connString.connectionString.Close();
            }
        }

        public void AddBattleLog(User user, Enemy enemy)
        {
            ConnectionString connString = new ConnectionString();

            using (connString.connectionString)
            {
                connString.connectionString.Open();

                SqlCommand cmd = new SqlCommand("AddBattleLog", connString.connectionString);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userid", user.CharacterId);
                cmd.Parameters.AddWithValue("@enemyid", enemy.CharacterId);
                cmd.Parameters.AddWithValue("@username", user.Name);
                cmd.Parameters.AddWithValue("@enemyname", enemy.Name);
                cmd.Parameters.AddWithValue("@battleresult", user.Result);

                cmd.ExecuteNonQuery();

                connString.connectionString.Close();
            }
        }
    }
}
