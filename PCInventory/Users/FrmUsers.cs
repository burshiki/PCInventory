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

        
        
 

        public FrmUsers()
        {
            InitializeComponent();
        }

        public void FrmUsers_Load(object sender, EventArgs e)
        {

            User user = new User(); 
            List<User> dt = user.get_all_user(dgvUsers);

            dgvUsers.Columns[0].Width = 30; //column size for ID

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            

            
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            User user = new User();

            if (dgvUsers.Columns[e.ColumnIndex].HeaderText == "Delete")
            {
                int id;
                id = Convert.ToInt32(dgvUsers.Rows[e.RowIndex].Cells["IDColumn"].Value);
                //MessageBox.Show(id.ToString());

                user.Update_User_Active(0, id);
                FrmUsers_Load(sender, e);
            }


        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            FrmAddUser frm_add_user = new FrmAddUser();
            frm_add_user.Show();

        }
    }
}
