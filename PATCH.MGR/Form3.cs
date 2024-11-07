using System;
using System.Windows.Forms;

namespace PATCH.MGR
{
    public partial class Form3 : Form
    {
        public string Username { get; private set; }
        public string Password { get; private set; }

        public Form3()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Username = txtUsername.Text;
            Password = txtPassword.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}