using Oracle.ManagedDataAccess.Client;
using System.Security.Policy;
using System.Text.RegularExpressions;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Library_system
{
    public partial class Form1 : Form
    {

        //BASAHIN MAIGI:
        //TO DO:
        // 1. Connect to oracle sql database
        // 2. insert datas to the database from add panels
        // IMPORTANT NOTE: burat burat haha tangina mo russell

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dashboard_panel.Visible = true;
            user_panel.Visible = false;
            book_panel.Visible = false;
            borrow_record_panel.Visible = false;

            addbook_publicationDate_dtp.MaxDate = DateTime.Now;

            //TRIAL connection

            //string connectionString = "User Id=xeroj; Password=Xeroj456519; Data Source=localhost:1521/XE;";
            //OracleConnection conn = new OracleConnection(connectionString);

            //string query = "INSERT INTO users VALUES('23-1854', 'Xeroj', 'Ulgasan', 'Xerojulgasan@gmail.com')";

            //OracleCommand cmd = new OracleCommand(query, conn);

            //conn.Open();
            //cmd.ExecuteNonQuery();
            //MessageBox.Show("Data Inserted");
            //conn.Close();
        }

        private void status_btn_Click(object sender, EventArgs e)
        {
            status_cms.Show(status_btn, new Point(0, status_btn.Height));
        }

        //TAB CLICKS TO DO
        // Dashboard
        // Users
        // Books
        // Borrow records

        //DASHBOARD CLICK
        private void dashboard_click(object sender, EventArgs e)
        {
            dashboard_panel.Visible = true;
            user_panel.Visible = false;
            book_panel.Visible = false;
            borrow_record_panel.Visible = false;
        }

        //USERS CLICK
        private void user_click(object sender, EventArgs e)
        {
            dashboard_panel.Visible = false;
            user_panel.Visible = true;
            book_panel.Visible = false;
            borrow_record_panel.Visible = false;
        }

        //ADD BOOKS CLICK
        private void add_books_click(object sender, EventArgs e)
        {
            dashboard_panel.Visible = false;
            user_panel.Visible = false;
            book_panel.Visible = true;
            borrow_record_panel.Visible = false;
        }

        //BORROW RECORDS CLICK
        private void borrow_record_click(object sender, EventArgs e)
        {
            dashboard_panel.Visible = false;
            user_panel.Visible = false;
            book_panel.Visible = false;
            borrow_record_panel.Visible = true;
        }

        //ADD BOOK CLICK
        private void addbook_popup(object sender, EventArgs e)
        {
            disableall(addbook_panel);
        }

        private void addbook_popup_exit(object sender, EventArgs e)
        {
            enableall(addbook_panel);
        }

        private void addbook(object sender, EventArgs e)
        {
            //DATABASE BOOK TABLE REFERENCE :

            //CREATE TABLE books(
            //    title VARCHAR(255),
            //    author VARCHAR(255),
            //    publisher VARCHAR(255),
            //    publication_date DATE,
            //    genre VARCHAR(100),
            //    book_language VARCHAR(50),
            //    page_count INT,
            //    quantity INT NOT NULL
            //);

            string title = addbook_title_txtbox.Text;
            string author = addbook_author_txtbox.Text;
            string publisher = addbook_publisher_txtbox.Text;
            DateTime publication_date = addbook_publicationDate_dtp.Value;
            string genre = addbook_genre_txtbox.Text;
            string book_language = addbook_language_txtbox.Text;
            int page_count = (int)addbook_pagecount_num.Value;
            int quantity = (int)addbook_quantity_num.Value;

            DialogResult result = MessageBox.Show("Do you confirm the data that you have entered?", "Confirm Book Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Insert data into the database
                try
                {
                    string connectionString = "User Id=xeroj; Password=Xeroj456519; Data Source=localhost:1521/XE;";
                    using (OracleConnection conn = new OracleConnection(connectionString))
                    {
                        string query = "INSERT INTO books (title, author, publisher, publication_date, genre, book_language, page_count, quantity) " +
                                        "VALUES(:title, :author, :publisher, :publication_date, :genre, :book_language, :page_count, :quantity)";


                        using (OracleCommand cmd = new OracleCommand(query, conn))
                        {
                            cmd.Parameters.Add(new OracleParameter("title", title));
                            cmd.Parameters.Add(new OracleParameter("author", author));
                            cmd.Parameters.Add(new OracleParameter("publisher", publisher));
                            cmd.Parameters.Add(new OracleParameter("publication_date", publication_date));
                            cmd.Parameters.Add(new OracleParameter("genre", genre));
                            cmd.Parameters.Add(new OracleParameter("book_language", book_language));
                            cmd.Parameters.Add(new OracleParameter("page_count", page_count));
                            cmd.Parameters.Add(new OracleParameter("quantity", quantity));

                            conn.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Book data inserted successfully.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Book data insertion canceled.");
            }
        }

        //FUNCTIONS 
        private void disableall(Panel enabledPanel)
        {
            foreach (Control control in this.Controls)
            {
                if (control is Panel panel)
                {
                    panel.Enabled = false;
                }
            }

            foreach (Control control in enabledPanel.Parent.Controls)
            {
                if (enabledPanel.Parent != null)
                {
                    enabledPanel.Parent.Enabled = true;

                    if (control == enabledPanel)
                    {
                        control.Enabled = true;
                        control.Visible = true;
                        control.Focus();
                    }
                    else
                    {
                        control.Enabled = false;
                    }
                }
            }
        }

        public void enableall(Panel disabledPanel)
        {
            foreach (Control control in this.Controls)
            {
                if (control is Panel panel)
                {
                    panel.Enabled = true;
                }
            }

            foreach (Control control in disabledPanel.Parent.Controls)
            {
                if (disabledPanel.Parent != null)
                {
                    //disabledPanel.Parent.Enabled = true;

                    if (control == disabledPanel)
                    {
                        control.Enabled = false;
                        control.Visible = false;
                    }
                    else
                    {
                        control.Enabled = true;
                    }
                }
            }
        }

        //VALIDATION FUNCTIONS TO BE RECYCLED IN ACCOUNT REGISTRATION
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private bool IsValidStudentNumber(string studnum)
        {
            // Student number format: YY-NNNN
            string pattern = @"^\d{2}-\d{4}$";
            return Regex.IsMatch(studnum, pattern);
        }
    }
}
