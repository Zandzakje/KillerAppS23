using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RpgApp_Model;
using System.Data.SqlClient;
using System.Data;

namespace RpgApp_Data
{
    public class ClassSql
    {
        SqlConnection ConnectionDB;

        public void ConnString()
        {
            const string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Gebruiker\Desktop\School\Visual Studio\ICT_Software\Semester 2\RpgApp\RpgApp\App_Data\RpgDB.mdf; Integrated Security = True";
            ConnectionDB = new SqlConnection(connectionString);

            ConnOpen();
        }
        
        public User LoginCheck(User user)
        {
            ConnString();

            SqlCommand cmd = new SqlCommand("Login", ConnectionDB);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", user.Name);
            cmd.Parameters.AddWithValue("@password", user.Password);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while(reader.Read())
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

                        double half = user.MaxHp * 0.5;
                        Math.Round(half, 0, MidpointRounding.AwayFromZero);
                        user.HalfHp = Convert.ToInt32(half);

                        double min = user.MaxHp * 0.15;
                        Math.Round(min, 0, MidpointRounding.AwayFromZero);
                        user.MinHp = Convert.ToInt32(min);
                    }

                    ConnClose();
                    return user;
                }
                else
                {
                    user = null;

                    ConnClose();
                    return user;
                }
            }
        }

        public void Registry(User user)
        {
            ConnString();

            SqlCommand cmd = new SqlCommand(RegistryClass(user.Class), ConnectionDB);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", user.Name);
            cmd.Parameters.AddWithValue("@password", user.Password);
            cmd.Parameters.AddWithValue("@class", user.Class);

            cmd.ExecuteNonQuery();

            ConnClose();
        }

        public string RegistryClass(string klasse)
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

        public User Summary(string username)
        {
            ConnString();

            User u = new User();

            SqlCommand cmd = new SqlCommand("Summary", ConnectionDB);
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
                    ConnClose();
                    return u;
                }
                else
                {
                    ConnClose();
                    return u;
                }
            }
        }

        public Enemy NewEnemy(int number)
        {
            ConnString();

            Enemy e = new Enemy();

            SqlCommand cmd = new SqlCommand("GetEnemy", ConnectionDB);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@number", number);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        e.Name = reader.GetString(0);
                        e.Level = reader.GetInt32(1);
                        e.MaxHp = reader.GetInt32(2);
                        e.Attack = reader.GetInt32(3);
                        e.Defense = reader.GetInt32(4);
                        e.Speed = reader.GetInt32(5);
                        e.Type = reader.GetString(6);

                        double half = e.MaxHp * 0.5;
                        Math.Round(half, 0, MidpointRounding.AwayFromZero);
                        e.HalfHp = Convert.ToInt32(half);

                        double min = e.MaxHp * 0.15;
                        Math.Round(min, 0, MidpointRounding.AwayFromZero);
                        e.MinHp = Convert.ToInt32(min);
                    }
                    ConnClose();
                    return e;
                }
                else
                {
                    ConnClose();
                    return e;
                }
            }
        }

        public void UpdateUser(User user)
        {
            ConnString();

            SqlCommand cmd = new SqlCommand("UpdateUser", ConnectionDB);
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

            ConnClose();
        }

        public void ConnOpen()
        {
            ConnectionDB.Open();
        }

        public void ConnClose()
        {
            ConnectionDB.Close();
        }
    }
}