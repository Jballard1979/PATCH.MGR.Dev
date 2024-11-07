using System;
using System.Windows.Forms;

namespace PATCH.MGR
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void BtnCmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HelpRichTB_TextChanged(object sender, EventArgs e)
        {
            //
        }
    }
}
