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
    public class EnemyContext
    {
        ConnectionString connString = new ConnectionString();

        public Enemy GenerateEnemy(int number)
        {
            using (connString.connectionString)
            {
                connString.connectionString.Open();

                Enemy e = new Enemy();

                SqlCommand cmd = new SqlCommand("GenerateEnemy", connString.connectionString);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@number", number);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            e.CharacterId = reader.GetInt32(0);
                            e.Name = reader.GetString(1);
                            e.Level = reader.GetInt32(2);
                            e.MaxHp = reader.GetInt32(3);
                            e.Attack = reader.GetInt32(4);
                            e.Defense = reader.GetInt32(5);
                            e.Speed = reader.GetInt32(6);
                            e.Type = reader.GetString(7);

                            //double half = e.MaxHp * 0.5;
                            //Math.Round(half, 0, MidpointRounding.AwayFromZero);
                            //e.HalfHp = Convert.ToInt32(half);

                            //double min = e.MaxHp * 0.15;
                            //Math.Round(min, 0, MidpointRounding.AwayFromZero);
                            //e.LowHp = Convert.ToInt32(min);
                        }

                        connString.connectionString.Close();
                        return e;
                    }
                    else
                    {
                        connString.connectionString.Close();
                        return e;
                    }
                }
            }
        }
    }
}
