using PCInventory.Users;

namespace PCInventory
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void CloseChildForm()
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
        }

        private void ShowFrm(Form frm)
        {
            this.IsMdiContainer = true;
            frm.MdiParent = this;
            frm.Show();
        }

        private void tsbUsers_Click(object sender, EventArgs e)
        {
            CloseChildForm();
            ShowFrm(new FrmUsers());
        }
    }
}