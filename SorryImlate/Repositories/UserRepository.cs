using MySql.Data.MySqlClient;
using SorryImlate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorryImlate.Repositories
{
    public class UserRepository
    {
        // XAMPPのデフォルトに合わせてpasswordを空（password=）に修正しました
        private string connString = "server=localhost;user=root;database=sorry;port=3306;password=";

        public User GetUserByCode(string userCode)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                string sql = "SELECT * FROM users WHERE user_code = @code";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@code", userCode);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new User
                        {
                            UserId = reader.GetInt32("user_id"),
                            UserCode = reader.GetString("user_code"),
                            Password = reader.GetString("password"),
                            Name = reader.GetString("name"),
                            Role = reader.GetString("role")
                        };
                    }
                }
            }
            return null;
        }
    }
}