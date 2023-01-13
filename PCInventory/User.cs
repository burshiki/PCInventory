using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCInventory.Includes;

namespace PCInventory
{
   

    internal class User
    {
        MySQLConfig config = new MySQLConfig();
        UsableFunction funct = new UsableFunction();
        string sql;

        public string username { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string is_active { get; set; }

        public List<User> get_all_user(DataGridView dtg) 
        {
            List<User> users = new List<User>();

            sql = "SELECT id AS ID, username AS Username, name AS Name, CASE is_active WHEN 1 THEN 'active' ELSE 'inactive' END AS Status, created_at AS 'Date Created', updated_at AS 'Date Updated' " +
                "FROM users " +
                "ORDER BY id DESC";
            config.Load_DVG(sql, dtg);

            return users;
        }

        public void Register_User(string username, string password, string name)
        {
            sql = "INSERT INTO users (username, password, name) VALUES ('" + username + "', sha('" + password + "'), '" + name + "')";
            config.Execute_CUD(sql, "error to execute.", "User has been saved to database.");
        }



    }
}
