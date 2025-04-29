using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_system
{
    public partial class adminLoginForm : Form
    {
        public adminLoginForm()
        {
            InitializeComponent();
        }
        private Color defaultColor = Color.Black;
        private Color hoverColor = Color.FromArgb(255, 248, 160, 28);
        private void adminLoginForm_Load(object sender, EventArgs e)
        {
            RoundedButtonHelper.ApplyRoundedCorners(btnENTER, 18);
            btnENTER.MouseLeave += Button_MouseLeave;
            btnENTER.MouseEnter += Button_MouseEnter;
        }


        private void Button_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.BackColor = hoverColor;
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.BackColor = defaultColor;
        }
            private void btnENTER_Click(object sender, EventArgs e)
        {
            string enteredPin = txtPIN.Text.Trim();
            if (enteredPin == "0000")
            {
                
            }
            else
            {
                MessageBox.Show("The PIN is incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPIN.Clear();
                txtPIN.Focus();
            }
        
            this.Hide();
            adminForm adminForm = new adminForm();
            adminForm.Show();

        }
    }
}
