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
        public int is_active { get; set; }

        public int id { get; set; }

        public List<User> get_all_user(DataGridView dtg) 
        {
            List<User> users = new List<User>();

            //sql = "SELECT id, username, name, CASE is_active WHEN 1 THEN 'active' ELSE 'inactive' END as 'is active?', created_at, updated_at " +
            //"FROM users " +
            //"ORDER BY id DESC";
            sql = "SELECT id, name, username, is_active, created_at, updated_at " +
            "FROM users " +
            "ORDER BY id DESC";

            //sql = "SELECT * FROM users ORDER BY id DESC";
            config.Load_DVG(sql, dtg);

            return users;
        }

        public void Register_User(string username, string password, string name)
        {
            sql = "INSERT INTO users (username, password, name) VALUES ('" + username + "', sha('" + password + "'), '" + name + "')";
            config.Execute_CUD(sql, "error to execute.", "User has been saved to database.");
        }

        public void Update_User(string username, string password, string name, int id)
        {
            sql = "UPDATE users SET name = '" + name + "', '" + username + "', '" + password + "' WHERE id = '" + id + "'";
            config.Execute_CUD(sql, "error tot execute.", "User has been updated.");
        }

        public void Update_User_Active(int is_active, int id)
        {
            sql = "UPDATE users SET is_active = '" + is_active + "' WHERE id = '" + id + "'";
            config.Execute_CUD(sql, "error tot execute.", "User has change to inactive.");
        }


    }
}
