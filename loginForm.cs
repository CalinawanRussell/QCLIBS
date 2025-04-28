using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using System.Drawing;

namespace Library_system
{
    public partial class loginForm : Form
    {
        private readonly string connectionString = "User Id=RUSSELL;Password=Russell_2700;Data Source=localhost:1521/XE;";

        public loginForm()
        {
            InitializeComponent();

            picboxSHOWlogpass.Visible = true;
            picboxHIDElogpass.Visible = false;
        }

        private Color defaultColor = Color.Black;
        private Color hoverColor = Color.FromArgb(255, 248, 160, 28);

        private void loginForm_Load(object sender, EventArgs e)
        {
            RoundedButtonHelper.ApplyRoundedCorners(btnLOGIN, 18);
            btnLOGIN.MouseLeave += Button_MouseLeave;
            btnLOGIN.MouseEnter += Button_MouseEnter;
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

        private void lblSIGNUP_Click(object sender, EventArgs e)
        {
            this.Hide();
            signupForm signupForm = new signupForm();
            var result = signupForm.ShowDialog();
            this.Show();
            if (result == DialogResult.OK)
            {
                MessageBox.Show("You may now log in using your new account.");
                txtboxUNAME.Clear();
                txtboxPASS.Clear();
            }
        }

        private void btnLOGIN_Click(object sender, EventArgs e)
        {
            string userInput = txtboxUNAME.Text.Trim();
            string password = txtboxPASS.Text;

            if (string.IsNullOrWhiteSpace(userInput) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter your Student Number (or Email) and Password.");
                return;
            }

            string passwordHash = HashPassword(password);

            if (AuthenticateUser(userInput, passwordHash))
            {
                MessageBox.Show("Login successful!");
                this.Hide();
                userPage userPage = new userPage();
                userPage.Show();
            }
            else
            {
                MessageBox.Show("Invalid Student Number/Email or Password.");
            }
        }

        private bool AuthenticateUser(string userInput, string passwordHash)
        {
            try
            {
                using (OracleConnection conn = new OracleConnection(connectionString))
                {
                    string query = @"
                        SELECT COUNT(*) FROM STUDENTS
                        WHERE (STUDENT_NUMBER = :StudentNumber OR EMAIL = :Email)
                        AND PASSWORD_HASH = :PasswordHash
                    ";

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.Parameters.Add(new OracleParameter("StudentNumber", userInput));
                        cmd.Parameters.Add(new OracleParameter("Email", userInput));
                        cmd.Parameters.Add(new OracleParameter("PasswordHash", passwordHash));

                        conn.Open();
                        int userCount = Convert.ToInt32(cmd.ExecuteScalar());
                        return userCount > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
                return false;
            }
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                    builder.Append(b.ToString("x2"));
                return builder.ToString();
            }
        }
        private void picboxSHOWlogpass_Click(object sender, EventArgs e)
        {
            txtboxPASS.UseSystemPasswordChar = false;      // Show password
            picboxSHOWlogpass.Visible = false;             // Hide the "show" icon
            picboxHIDElogpass.Visible = true;              // Show the "hide" icon
        }

        private void picboxHIDElogpass_Click(object sender, EventArgs e)
        {
            txtboxPASS.UseSystemPasswordChar = true;       // Hide password
            picboxSHOWlogpass.Visible = true;              // Show the "show" icon
            picboxHIDElogpass.Visible = false;             // Hide the "hide" icon
        }
    }
}