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

            dgvUsers.Columns[0].Width = 30; //column size for ID

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            User user = new User();

            if(txtName.Text == "")
            {
                MessageBox.Show("Please enter your name", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName.Focus();
            }
            else if(txtUsername.Text == "")
            {
                MessageBox.Show("Please enter your username", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUsername.Focus();
            }
            else if (txtPassword.Text == "" || txtConfirmPassword.Text == "")
            {
                MessageBox.Show("Please enter your password", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPassword.Focus();
            }
            else
            {

                if(txtPassword.Text != txtConfirmPassword.Text)
                {
                    MessageBox.Show("Password and Confirm password do not match!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtConfirmPassword.Focus();
                }
                else
                {

                    sql = "SELECT * FROM users WHERE username = '" + txtUsername.Text + "'";
                    config.singleResult(sql);
                    if (config.dt.Rows.Count > 0)
                    {
                        MessageBox.Show("Username is already exists!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtUsername.Focus();
                    }
                    else
                    {
                        user.Register_User(txtName.Text, txtUsername.Text, txtPassword.Text);
                        FrmUsers_Load(sender,e);
                    }
                   
                }
                
            }

            
        }

        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
