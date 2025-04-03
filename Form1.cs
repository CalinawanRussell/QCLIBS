using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Globalization;
using System.Security.Policy;
using System.Text.RegularExpressions;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Linq;

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

            dashboard_from_dtp.MaxDate = DateTime.Now.AddDays(-1);
            dashboard_from_dtp.Value = DateTime.Now.AddDays(-7);

            dashboard_to_dtp.MaxDate = DateTime.Now.AddSeconds(1);
            dashboard_to_dtp.Value = DateTime.Now;

            language_cms.Items.Add("English");
            language_cms.Items.Add("Filipino");
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

            loadUsers(); // Load users from the database
        }

        //ADD BOOKS CLICK
        private void add_books_click(object sender, EventArgs e)
        {
            dashboard_panel.Visible = false;
            user_panel.Visible = false;
            book_panel.Visible = true;
            borrow_record_panel.Visible = false;

            loadBooks(); // Load books from the database
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
        private void disableall(Panel enabledPanel) //DISABLE ALL PANELS EXCEPT THE ONE THAT IS ENABLED
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

        public void enableall(Panel disabledPanel) //ENABLE ALL PANELS
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

        public void loadUsers() //LOAD USER
        {
            //REFERENCE TABLE:
            //CREATE TABLE users
            // ("STUDENT_ID" VARCHAR2(10),
            //  "FIRST_NAME" VARCHAR2(25),
            //  "LAST_NAME" VARCHAR2(25),
            //  "EMAIL" VARCHAR2(50)
            // )
            users_dgv.Rows.Clear(); // Clear existing rows in the DataGridView
            try
            {
                string connectionString = "User Id=xeroj; Password=Xeroj456519; Data Source=localhost:1521/XE;";
                using (OracleConnection conn = new OracleConnection(connectionString))
                {
                    string query = "SELECT STUDENT_ID, FIRST_NAME, LAST_NAME, EMAIL FROM users";
                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        conn.Open();
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                users_dgv.Rows.Add(
                                    reader["STUDENT_ID"].ToString(),
                                    reader["FIRST_NAME"].ToString() + " " + reader["LAST_NAME"].ToString(),
                                    reader["EMAIL"].ToString()
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        public void loadBooks() //LOAD BOOKS
        {
            //REFERENCE TABLE:
            //CREATE TABLE books
            // ("TITLE" VARCHAR2(255),
            //  "AUTHOR" VARCHAR2(255),
            //  "PUBLISHER" VARCHAR2(255),
            //  "PUBLICATION_DATE" DATE,
            //  "GENRE" VARCHAR2(100),
            //  "BOOK_LANGUAGE" VARCHAR2(50),
            //  "PAGE_COUNT" NUMBER(*, 0),
            //  "QUANTITY" NUMBER(*, 0)
            // )
            books_dgv.Rows.Clear(); // Clear existing rows in the DataGridView
            try
            {
                string connectionString = "User Id=xeroj; Password=Xeroj456519; Data Source=localhost:1521/XE;";
                using (OracleConnection conn = new OracleConnection(connectionString))
                {
                    string query = "SELECT TITLE, AUTHOR, PUBLICATION_DATE, GENRE, QUANTITY FROM books";
                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        conn.Open();
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                books_dgv.Rows.Add(
                                    reader["TITLE"].ToString(),
                                    reader["AUTHOR"].ToString(),
                                    reader["PUBLICATION_DATE"].ToString(),
                                    reader["GENRE"].ToString(),
                                    Convert.ToInt32(reader["QUANTITY"])
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
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

        //SMALL FUNCTIONS
        private void languages_cms_dropdown(object sender, EventArgs e)
        {
            language_cms.Width = addbook_language_txtbox.Width;
            language_cms.Show(addbook_language_txtbox, new Point(0, addbook_language_txtbox.Height));
        }

        private void language_cms_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripMenuItem clickedItem = e.ClickedItem as ToolStripMenuItem;
            if (clickedItem != null)
            {
                addbook_language_txtbox.Text = clickedItem.Text;
            }
        }
    }
}
