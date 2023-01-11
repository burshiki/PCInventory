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

            sql = "SELECT id AS ID, username AS Username, name AS Name, is_active AS 'is active?' FROM users";
            config.Load_DVG(sql, dtg);

            return users;
        }

    }
}
