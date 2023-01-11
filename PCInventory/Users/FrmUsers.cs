using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PCInventory.Includes;



namespace PCInventory.Users
{
    public partial class FrmUsers : Form
    {

        MySQLConfig config = new MySQLConfig();
        UsableFunction funct = new UsableFunction();
        string sql;

        public FrmUsers()
        {
            InitializeComponent();
        }

        private void FrmUsers_Load(object sender, EventArgs e)
        {

            User user = new User(); 
            List<User> dt = user.get_all_user(dgvUsers);

            dgvUsers.DataSource = dt;

            dgvUsers.Columns[0].Width = 30; //column size for ID

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {

        }

        
    }
}
