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
    public partial class homepageForm : Form
    {
        private Color defaultColor = Color.Black;
        private Color hoverColor = Color.FromArgb(255, 248, 160, 28);

        public homepageForm()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            RoundedButtonHelper.ApplyRoundedCorners(btnADMIN, 20);
            RoundedButtonHelper.ApplyRoundedCorners(btnSTUDENT, 20);

            btnADMIN.BackColor = defaultColor;
            btnSTUDENT.BackColor = defaultColor;
            btnADMIN.ForeColor = Color.White;
            btnSTUDENT.ForeColor = Color.White;


            btnADMIN.MouseEnter += Button_MouseEnter;
            btnADMIN.MouseLeave += Button_MouseLeave;

            btnSTUDENT.MouseEnter += Button_MouseEnter;
            btnSTUDENT.MouseLeave += Button_MouseLeave;
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

        private void btnSTUDENT_Click(object sender, EventArgs e)
        {
            loginForm loginForm = new loginForm();
            loginForm.Show();
            this.Hide();
        }

        private void btnADMIN_Click(object sender, EventArgs e)
        {
            this.Hide();
            adminForm adminForm = new adminForm();
            adminForm.Show();

        }
    }
}

