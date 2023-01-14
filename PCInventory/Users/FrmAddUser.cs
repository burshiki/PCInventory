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
    public partial class FrmAddUser : Form
    {

        MySQLConfig config = new MySQLConfig();
        UsableFunction funct = new UsableFunction();
        string sql;
        


        public FrmAddUser()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {

            User user = new User();
           

            if (txtName.Text == "")
            {
                MessageBox.Show("Please enter your name", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName.Focus();
            }
            else if (txtUsername.Text == "")
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

                if (txtPassword.Text != txtConfirmPassword.Text)
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
                        funct.clearTxt(gbCreateUser);

                        FrmUsers frm = Application.OpenForms["FrmUsers"] as FrmUsers;
                        if (frm != null)
                        {
                            frm.FrmUsers_Load(sender, e);
                            frm.BringToFront();
                        }
                        else
                        {
                            frm = new FrmUsers();
                            frm.FrmUsers_Load(sender, e);
                            frm.Show();
                        }

                    }

                }

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to cancel Adding User?", "Question", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                funct.clearTxt(gbCreateUser);
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
        }
    }
}
