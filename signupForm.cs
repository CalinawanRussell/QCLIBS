using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace Library_system
{
    public partial class signupForm : Form
    {
        private readonly string connectionString = "User Id=RUSSELL;Password=Russell_2700;Data Source=localhost:1521/XE;";

        public signupForm()
        {
            InitializeComponent();
            picboxSHOWPASS.Visible = true;
            picboxHIDEPASS.Visible = false;
            picboxSHOWCONFIRM.Visible = true;
            picboxHIDECONFIRM.Visible = false;
        }

        private Color defaultColor = Color.Black;
        private Color hoverColor = Color.FromArgb(255, 248, 160, 28);

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (!ValidateInput(out string firstName, out string lastName, out string studentNumber, out string email, out string password))
                return;

            string passwordHash = HashPassword(password);

            if (RegisterStudent(firstName, lastName, studentNumber, email, passwordHash))
            {
                MessageBox.Show("Registration successful!");
                ClearFields();
                this.DialogResult = DialogResult.OK; // Signal success to the caller
                // this.Close(); // No need, DialogResult will close ShowDialog()
            }
        }

        private bool ValidateInput(out string firstName, out string lastName, out string studentNumber, out string email, out string password)
        {
            firstName = txtboxFirstname.Text.Trim();
            lastName = txtboxLastname.Text.Trim();
            studentNumber = txtboxStudnum.Text.Trim();
            email = txtboxEmail.Text.Trim();
            password = txtboxPass.Text;
            string confirmPassword = txtboxConfirm.Text;

            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) ||
                string.IsNullOrWhiteSpace(studentNumber) || string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("Please fill in all fields.");
                return false;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.");
                return false;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(studentNumber, @"^[0-9\-]+$"))
            {
                MessageBox.Show("Student Number must contain only digits and dashes.");
                return false;
            }
            return true;
        }

        private bool RegisterStudent(string firstName, string lastName, string studentNumber, string email, string passwordHash)
        {
            try
            {
                using (OracleConnection conn = new OracleConnection(connectionString))
                using (OracleCommand cmd = new OracleCommand(@"INSERT INTO STUDENTS 
                        (FIRST_NAME, LAST_NAME, STUDENT_NUMBER, EMAIL, PASSWORD_HASH)
                        VALUES (:FirstName, :LastName, :StudentNumber, :Email, :PasswordHash)", conn))
                {
                    cmd.Parameters.Add(new OracleParameter("FirstName", firstName));
                    cmd.Parameters.Add(new OracleParameter("LastName", lastName));
                    cmd.Parameters.Add(new OracleParameter("StudentNumber", studentNumber));
                    cmd.Parameters.Add(new OracleParameter("Email", email));
                    cmd.Parameters.Add(new OracleParameter("PasswordHash", passwordHash));

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                        return true;
                    else
                        MessageBox.Show("Registration failed. Please try again.");
                }
            }
            catch (OracleException ex)
            {
                if (ex.Number == 1) // Unique constraint violation
                    MessageBox.Show("Email or Student Number already exists.");
                else
                    MessageBox.Show("Database error: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return false;
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

        private void ClearFields()
        {
            txtboxFirstname.Clear();
            txtboxLastname.Clear();
            txtboxStudnum.Clear();
            txtboxEmail.Clear();
            txtboxPass.Clear();
            txtboxConfirm.Clear();
        }

        private void picboxSHOWPASS_Click(object sender, EventArgs e)
        {
            txtboxPass.UseSystemPasswordChar = false;
            picboxSHOWPASS.Visible = false;
            picboxHIDEPASS.Visible = true;
        }

        private void picboxHIDEPASS_Click(object sender, EventArgs e)
        {
            txtboxPass.UseSystemPasswordChar = true;
            picboxSHOWPASS.Visible = true;
            picboxHIDEPASS.Visible = false;
        }

        private void picboxSHOWCONFIRM_Click(object sender, EventArgs e)
        {
            txtboxConfirm.UseSystemPasswordChar = false;
            picboxSHOWCONFIRM.Visible = false;
            picboxHIDECONFIRM.Visible = true;
        }

        private void picboxHIDECONFIRM_Click(object sender, EventArgs e)
        {
            txtboxConfirm.UseSystemPasswordChar = true;
            picboxSHOWCONFIRM.Visible = true;
            picboxHIDECONFIRM.Visible = false;
        }

        private void signupForm_Load(object sender, EventArgs e)
        {
            RoundedButtonHelper.ApplyRoundedCorners(btnEnter, 18);
           
            btnEnter.BackColor = defaultColor;
            btnEnter.ForeColor = Color.White;


            btnEnter.MouseEnter += Button_MouseEnter;
            btnEnter.MouseLeave += Button_MouseLeave;
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
    }
}