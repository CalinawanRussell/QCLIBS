using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Globalization;
using System.Security.Policy;
using System.Text.RegularExpressions;
using System.Xml;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Linq;
//using System.Windows.Forms.DataVisualization.Charting;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView.WinForms;
using LiveChartsCore.SkiaSharpView;
using SkiaSharp;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.VisualElements;
using LiveChartsCore.Themes;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Reflection.Metadata.BlobBuilder;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;


//TODO:
// SETTINGS
// Change default timeframe. Give choices such ddaily, weekly, monthly 

//DASHBOARD:
// FILL UP borrowed books, returnd books, overdue books, misssing books,
// total books, visitors, and new members depending on the chosen date.

// FINISH STATISTICS

// BORROWED BOOKS:
// Each table row items should be clickable and enables the user to set the book as returned, missing, or overdue.

namespace Library_system
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            InitializeChart();
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

            addborrow_returnDate_dtp.Value = DateTime.Now.AddDays(7);

            language_cms.Items.Add("English");
            language_cms.Items.Add("Filipino");

            loadDashboard(); // Load dashboard data from the database
        }

        //DASHBOARD CLICK
        private void dashboard_click(object sender, EventArgs e)
        {
            dashboard_panel.Visible = true;
            user_panel.Visible = false;
            book_panel.Visible = false;
            borrow_record_panel.Visible = false;

            dashboard_from_dtp.MaxDate = DateTime.Now.AddDays(-1);
            dashboard_from_dtp.Value = DateTime.Now.AddDays(-7);

            dashboard_to_dtp.MaxDate = DateTime.Now.AddSeconds(1);
            dashboard_to_dtp.Value = DateTime.Now;

            //DASHBOARD LOAD QUERY
            //note: visitors missing, waiting for check in and check out table
            //note: change to date depending on the user's choice (dashboard_from_dtp and dashboard_to_dtp)

            loadDashboard(); // Load dashboard data from the database
        }
        private void dashboard_date_changed(object sender, EventArgs e)
        {
            loadDashboard(); // Load dashboard data from the database
            InitializeChart(); // Update the chart with new data
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
        private void user_search_text_changed(object sender, EventArgs e)
        {
            string searchText = user_search_txtbox.Text.ToLower();

            foreach (DataGridViewRow row in users_dgv.Rows)
            {
                bool rowVisible = false;

                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null && cell.Value.ToString().ToLower().Contains(searchText))
                    {
                        rowVisible = true;
                        break;
                    }
                }

                row.Visible = rowVisible;
            }
        }

        //BORROW RECORDS CLICK
        private void borrow_record_click(object sender, EventArgs e)
        {
            dashboard_panel.Visible = false;
            user_panel.Visible = false;
            book_panel.Visible = false;
            borrow_record_panel.Visible = true;

            loadBorrow(); // Load borrowed books from the database
        }

        private void borrow_record_search_text_change(object sender, EventArgs e)
        {
            string searchText = borrow_record_search_txtbox.Text.ToLower();

            foreach (DataGridViewRow row in borrow_dgv.Rows)
            {
                bool rowVisible = false;

                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null && cell.Value.ToString().ToLower().Contains(searchText))
                    {
                        rowVisible = true;
                        break;
                    }
                }

                row.Visible = rowVisible;
            }
        }

        private void addborrow_popup(object sender, EventArgs e)
        {
            disableall(addborrow_panel);
        }

        private void addborrow_popup_exit(object sender, EventArgs e)
        {
            enableall(addborrow_panel);

            addborrow_studId_txtbox.Text = "";
            addborrow_title_txtbox.Text = "";
            addborrow_returnDate_dtp.Value = DateTime.Now.AddDays(7);
        }

        private void addborrow(object sender, EventArgs e) //INPUT BORROW DATA TO THE DATABASE
        {
            if (string.IsNullOrWhiteSpace(addborrow_studId_txtbox.Text) ||
                string.IsNullOrWhiteSpace(addborrow_title_txtbox.Text) ||
                string.IsNullOrWhiteSpace(addborrow_returnDate_dtp.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            string student_id = addborrow_studId_txtbox.Text;
            string book_title = addborrow_title_txtbox.Text;
            DateTime return_date = addborrow_returnDate_dtp.Value;

            if (!IsValidStudentNumber(student_id))
            {
                MessageBox.Show("Invalid student number format.");
                return;
            }

            DialogResult result = MessageBox.Show("Do you confirm the data that you have entered?", "Confirm Book Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    string connectionString = "User Id=xeroj; Password=Xeroj456519; Data Source=localhost:1521/XE;";
                    using (OracleConnection conn = new OracleConnection(connectionString))
                    {
                        conn.Open();

                        // Check if the student ID exists
                        string checkStudentQuery = "SELECT COUNT(*) FROM users WHERE student_id = :student_id";
                        using (OracleCommand checkStudentCmd = new OracleCommand(checkStudentQuery, conn))
                        {
                            checkStudentCmd.Parameters.Add(new OracleParameter("student_id", student_id));
                            int studentCount = Convert.ToInt32(checkStudentCmd.ExecuteScalar());
                            if (studentCount == 0)
                            {
                                MessageBox.Show("Student ID does not exist.");
                                return;
                            }
                        }

                        // Check if the book title exists
                        string checkBookQuery = "SELECT COUNT(*) FROM books WHERE book_id = :book_id";
                        using (OracleCommand checkBookCmd = new OracleCommand(checkBookQuery, conn))
                        {
                            checkBookCmd.Parameters.Add(new OracleParameter("book_id", book_title));
                            int bookCount = Convert.ToInt32(checkBookCmd.ExecuteScalar());
                            if (bookCount == 0)
                            {
                                MessageBox.Show("Book title does not exist.");
                                return;
                            }
                        }

                        // Insert the borrow record
                        string query = @"
                            INSERT INTO borrowed_books (borrower_id, borrower_ln, borrower_fn, book_id, borrow_due, borrow_date, status)
                            SELECT 
                                u.student_id, 
                                u.last_name, 
                                u.first_name, 
                                b.book_id, 
                                :return_date, 
                                SYSDATE, 
                                'Borrowed'
                            FROM 
                                users u
                            JOIN 
                                books b ON b.book_id = :book_id
                            WHERE 
                                u.student_id = :student_id";

                        using (OracleCommand cmd = new OracleCommand(query, conn))
                        {
                            cmd.Parameters.Add(new OracleParameter("return_date", return_date));
                            cmd.Parameters.Add(new OracleParameter("book_id", book_title));
                            cmd.Parameters.Add(new OracleParameter("student_id", student_id));

                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Book data inserted successfully.");
                        }

                        enableall(addborrow_panel); // Enable all panels after insertion

                        loadBorrow(); // Reload borrowed books after insertion

                        addborrow_studId_txtbox.Text = "";
                        addborrow_title_txtbox.Text = "";
                        addborrow_returnDate_dtp.Value = DateTime.Now.AddDays(7);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void status_filter(object sender, ToolStripItemClickedEventArgs e)
        {
            // FILTER STATUS FROM borrow_dgv TABLE

            string selectedStatus = e.ClickedItem.Text;
            foreach (DataGridViewRow row in borrow_dgv.Rows)
            {
                if (row.Cells[6].Value.ToString().Contains(selectedStatus))
                {
                    row.Visible = true;
                }
                else
                {
                    row.Visible = false;
                }
            }
        }

        //ADD BOOK CLICK
        private void add_books_click(object sender, EventArgs e)
        {
            dashboard_panel.Visible = false;
            user_panel.Visible = false;
            book_panel.Visible = true;
            borrow_record_panel.Visible = false;

            loadBooks(); // Load books from the database
        }

        private void addbook_popup(object sender, EventArgs e)
        {
            disableall(addbook_panel);
        }

        private void addbook_popup_exit(object sender, EventArgs e)
        {
            enableall(addbook_panel);

            addbook_title_txtbox.Text = "";
            addbook_author_txtbox.Text = "";
            addbook_publisher_txtbox.Text = "";
            addbook_publicationDate_dtp.Value = DateTime.Now.AddMinutes(-1);
            addbook_genre_txtbox.Text = "";
            addbook_language_txtbox.Text = "";
            addbook_pagecount_num.Value = 0;
            addbook_quantity_num.Value = 1;
        }

        private void addbook(object sender, EventArgs e) //INPUTS BOOK DATA TO THE DATABASE
        {
            //DATABASE BOOK TABLE REFERENCE :

            //CREATE TABLE books(
            //    title VARCHAR(255) NOT NULL,
            //    author VARCHAR(255) NOT NULL,
            //    publisher VARCHAR(255) NOT NULL,
            //    publication_date DATE NOT NULL,
            //    genre VARCHAR(100) NOT NULL,
            //    book_language VARCHAR(50) NOT NULL,
            //    page_count INT,
            //    quantity INT NOT NULL,
            //    Last_updated TIMESTAMP
            //);

            if (string.IsNullOrWhiteSpace(addbook_title_txtbox.Text) ||
                string.IsNullOrWhiteSpace(addbook_author_txtbox.Text) ||
                string.IsNullOrWhiteSpace(addbook_publisher_txtbox.Text) ||
                string.IsNullOrWhiteSpace(addbook_genre_txtbox.Text) ||
                string.IsNullOrWhiteSpace(addbook_language_txtbox.Text) ||
                string.IsNullOrWhiteSpace(addbook_quantity_num.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

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

                        loadBooks(); // Reload books after insertion

                        enableall(addbook_panel); // Enable all panels after insertion

                        addbook_title_txtbox.Text = "";
                        addbook_author_txtbox.Text = "";
                        addbook_publisher_txtbox.Text = "";
                        addbook_publicationDate_dtp.Value = DateTime.Now.AddMinutes(-1);
                        addbook_genre_txtbox.Text = "";
                        addbook_language_txtbox.Text = "";
                        addbook_pagecount_num.Value = 0;
                        addbook_quantity_num.Value = 1;
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

        //LOAD FUNCTIONS
        public void loadDashboard()
        {
            string connectionString = "User Id=xeroj; Password=Xeroj456519; Data Source=localhost:1521/XE;";

            //COUNTERS
            //COUNTERS
            //COUNTERS
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                string query = @"
                               SELECT 
                                   (SELECT COUNT(*) 
                                    FROM borrowed_books 
                                    WHERE BORROW_DATE BETWEEN :from_date AND :to_date 
                                      AND status = 'Borrowed') AS borrowed_books,

                                   (SELECT COUNT(*) 
                                    FROM borrowed_books 
                                    WHERE BORROW_DATE BETWEEN :from_date AND :to_date 
                                      AND status = 'Returned') AS returned_books,

                                   (SELECT COUNT(*) 
                                    FROM borrowed_books 
                                    WHERE BORROW_DATE BETWEEN :from_date AND :to_date 
                                      AND SYSDATE > BORROW_DUE
                                      AND status != 'Returned') AS overdue_books,

                                   (SELECT COUNT(*) 
                                    FROM borrowed_books 
                                    WHERE BORROW_DATE BETWEEN :from_date AND :to_date 
                                      AND status = 'Missing') AS missing_books,

                                   (SELECT SUM(QUANTITY) FROM books) AS total_books,

                                   (SELECT COUNT(*)
                                    FROM users
                                    WHERE DATE_CREATED BETWEEN :from_date AND :to_date) AS new_members
                               FROM dual";

                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("from_date", dashboard_from_dtp.Value));
                    cmd.Parameters.Add(new OracleParameter("to_date", dashboard_to_dtp.Value));
                    conn.Open();
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            borrow_label.Text = reader["borrowed_books"].ToString();
                            returned_label.Text = reader["returned_books"].ToString();
                            overdue_label.Text = reader["overdue_books"].ToString();
                            missing_label.Text = reader["missing_books"].ToString();
                            total_label.Text = reader["total_books"].ToString();
                            member_label.Text = reader["new_members"].ToString();
                        }
                    }
                }
            }
            //COUNTERS
            //COUNTERS
            //COUNTERS

            //OVERDUE HISTORY
            //OVERDUE HISTORY
            //OVERDUE HISTORY
            overview_history_dgv.Rows.Clear();

            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                string query = @"
                                SELECT 
                                    bb.borrower_id,
                                    b.title,
                                    bb.borrow_due,
                                    bb.borrow_date
                                FROM borrowed_books bb
                                JOIN books b
                                    ON b.book_id = bb.book_id
                                WHERE SYSDATE > borrow_due AND
                                    STATUS != 'Returned'";
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    conn.Open();
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            overview_history_dgv.Rows.Add(  reader["borrower_id"].ToString(),
                                                            reader["title"].ToString(),
                                                            Convert.ToDateTime(reader["borrow_due"]).ToString("MMMM d, yyyy"),
                                                            Convert.ToDateTime(reader["borrow_date"]).ToString("MMMM d, yyyy"));
                        }
                    }
                }
            }
            //OVERDUE HISTORY
            //OVERDUE HISTORY
            //OVERDUE HISTORY
        }

        public void loadUsers() //LOAD USER
        {
            //REFERENCE TABLE:
            //CREATE TABLE users
            // ("STUDENT_ID" VARCHAR2(10),
            //  "FIRST_NAME" VARCHAR2(25),
            //  "LAST_NAME" VARCHAR2(25),
            //  "EMAIL" VARCHAR2(50),
            //  "DATE_CREATED" DATE
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
            //CREATE TABLE "XEROJ"."BOOKS"
            // ("TITLE" VARCHAR2(255 BYTE),
            //  "AUTHOR" VARCHAR2(255 BYTE),
            //  "PUBLISHER" VARCHAR2(255 BYTE),
            //  "PUBLICATION_DATE" DATE,
            //  "GENRE" VARCHAR2(255 BYTE),
            //  "BOOK_LANGUAGE" VARCHAR2(50 BYTE),
            //  "PAGE_COUNT" NUMBER(*, 0),
            //  "QUANTITY" NUMBER(*, 0),
            //  "LAST_UPDATED" TIMESTAMP(6),
            //  "BOOK_ID" NUMBER
            // )
            books_dgv.Rows.Clear(); // Clear existing rows in the DataGridView
            try
            {
                string connectionString = "User Id=xeroj; Password=Xeroj456519; Data Source=localhost:1521/XE;";
                using (OracleConnection conn = new OracleConnection(connectionString))
                {
                    string query = @"
                                        SELECT 
                                            book_id,
                                            title,
                                            author,
                                            publication_date,
                                            genre,
                                            quantity,
                                            (quantity - (SELECT COUNT(*) 
                                                         FROM borrowed_books bb
                                                         WHERE b.book_id = bb.book_id)) AS available
                                        FROM books b";

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        conn.Open();
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                books_dgv.Rows.Add(
                                    Convert.ToInt32(reader["BOOK_ID"]),
                                    reader["TITLE"].ToString(),
                                    reader["AUTHOR"].ToString(),
                                    Convert.ToDateTime(reader["PUBLICATION_DATE"].ToString()).ToString("MMMM d, yyyy"),
                                    reader["GENRE"].ToString(),
                                    Convert.ToInt32(reader["QUANTITY"]),
                                    Convert.ToInt32(reader["AVAILABLE"])
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

        public void loadBorrow() //LOAD BORROWED BOOKS
        {
            //REFERENCE TABLE:
            //CREATE TABLE borrowed_books
            // ("BORROW_ID" NUMBER,
            //  "BORROWER_ID" VARCHAR2(10),
            //  "BORROWER_LN" VARCHAR2(25),
            //  "BORROWER_FN" VARCHAR2(25),
            //  "BOOK_TITLE" VARCHAR2(255),
            //  "BORROW_DUE" DATE,
            //  "BORROW_DATE" DATE,
            //  "STATUS" VARCHAR2(20)
            // )
            borrow_dgv.Rows.Clear(); // Clear existing rows in the DataGridView
            try
            {
                string connectionString = "User Id=xeroj; Password=Xeroj456519; Data Source=localhost:1521/XE;";
                using (OracleConnection conn = new OracleConnection(connectionString))
                {
                    string query = "SELECT BORROW_ID, BORROWER_ID, BORROWER_LN, BORROWER_FN, BOOK_ID, BORROW_DUE, BORROW_DATE, STATUS FROM borrowed_books";
                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        conn.Open();
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                borrow_dgv.Rows.Add(
                                    reader["BORROW_ID"].ToString(),
                                    reader["BORROWER_ID"].ToString(),
                                    reader["BORROWER_LN"].ToString() + ", " + reader["BORROWER_FN"].ToString(),
                                    Convert.ToInt32(reader["BOOK_ID"]),
                                    Convert.ToDateTime(reader["BORROW_DATE"]).ToString("MMMMM d, yyyy"),
                                    Convert.ToDateTime(reader["BORROW_DUE"]).ToString("MMMMM d, yyyy"),
                                    reader["STATUS"].ToString()
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

        private void status_btn_Click(object sender, EventArgs e)
        {
            status_cms.Show(status_btn, new Point(0, status_btn.Height));
        }

        private void statistics_dropdown(object sender, EventArgs e)
        {
            statistics_cms.Show(statistics_txtbox, new Point(0, statistics_txtbox.Height));
        }
        private void statistics_cms_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem != null)
            {
                statistics_txtbox.Text = e.ClickedItem.Text;
            }
        }
        private void statistics_chart_changed(object sender, EventArgs e)
        {
            statistics_cms.Hide();
            InitializeChart();
        }

        //CHART INITIALIZATION
        private void InitializeChart()
        {
            // Clear any existing chart
            chart_panel.Controls.Clear();

            var cartesianChart = new CartesianChart
            {
                Dock = DockStyle.Fill,
                BackColor = System.Drawing.Color.White
            };

            // Set tooltip configuration for smaller appearance
            cartesianChart.TooltipPosition = LiveChartsCore.Measure.TooltipPosition.Top;
            cartesianChart.TooltipBackgroundPaint = new SolidColorPaint(SKColors.White.WithAlpha(230));
            cartesianChart.TooltipTextSize = 9; // Smaller text size
            cartesianChart.TooltipTextPaint = new SolidColorPaint(SKColors.Black);

            // Modern gradient colors
            var gradientPaint = new LinearGradientPaint(
                new[] {
                    new SKColor(48, 63, 159, 180),  // Dark blue with transparency
                    new SKColor(41, 182, 246, 150)  // Light blue with transparency
                },
                new SKPoint(0, 0),
                new SKPoint(0, 1)
            );

            string selectedStatistic = statistics_txtbox.Text;
            string chartTitle = "Library Statistics";
            string yAxisName = "Count";
            string seriesName = selectedStatistic;

            List<double> values = new List<double>();
            List<string> dates = new List<string>();
            DateTime fromDate = dashboard_from_dtp.Value;
            DateTime toDate = dashboard_to_dtp.Value;

            // Set up the database connection
            string connectionString = "User Id=xeroj; Password=Xeroj456519; Data Source=localhost:1521/XE;";
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "";

                    switch (selectedStatistic)
                    {
                        case "Visitors":
                            chartTitle = "Visitor Statistics";
                            values = Enumerable.Repeat(0.0, 10).ToList();
                            dates = Enumerable.Range(0, 10)
                                .Select(i => fromDate.AddDays(i).ToString("MMM dd"))
                                .ToList();
                            seriesName = "No Visitor Data";
                            break;

                        case "New Members":
                            query = @"
                                    SELECT COUNT(*) AS count, TRUNC(date_created) AS created_date
                                    FROM users
                                    WHERE date_created BETWEEN :from_date AND :to_date
                                    GROUP BY TRUNC(date_created)
                                    ORDER BY TRUNC(date_created)";
                            chartTitle = "New Member Registrations";
                            seriesName = "New Members";
                            break;

                        case "Borrowed Books":
                            query = @"
                                    SELECT COUNT(*) AS count, TRUNC(borrow_date) AS created_date
                                    FROM borrowed_books
                                    WHERE status = 'Borrowed' AND 
                                        borrow_date BETWEEN :from_date AND :to_date
                                    GROUP BY TRUNC(borrow_date)
                                    ORDER BY TRUNC(borrow_date)";
                            chartTitle = "Books Borrowed Over Time";
                            seriesName = "Borrowed Books";
                            break;

                        case "Returned Books":
                            query = @"
                                    SELECT COUNT(*) AS count, TRUNC(borrow_date) AS created_date
                                    FROM borrowed_books
                                    WHERE status = 'Returned' AND 
                                        borrow_date BETWEEN :from_date AND :to_date
                                    GROUP BY TRUNC(borrow_date)
                                    ORDER BY TRUNC(borrow_date)";
                            chartTitle = "Books Returned Over Time";
                            seriesName = "Returned Books";
                            break;

                        case "Overdue Books":
                            query = @"
                                    SELECT COUNT(*) AS count, TRUNC(borrow_due) AS created_date
                                    FROM borrowed_books
                                    WHERE SYSDATE > borrow_due 
                                        AND status != 'Returned'
                                        AND borrow_due BETWEEN :from_date AND :to_date
                                    GROUP BY TRUNC(borrow_due)
                                    ORDER BY TRUNC(borrow_due)";
                            chartTitle = "Overdue Books Over Time";
                            seriesName = "Overdue Books";
                            break;

                        case "Missing Books":
                            query = @"
                                    SELECT COUNT(*) AS count, TRUNC(borrow_date) AS created_date
                                    FROM borrowed_books
                                    WHERE status = 'Missing' AND
                                        borrow_date BETWEEN :from_date AND :to_date
                                    GROUP BY TRUNC(borrow_date)
                                    ORDER BY TRUNC(borrow_date)";
                            chartTitle = "Missing Books Over Time";
                            seriesName = "Missing Books";
                            break;

                        case "Total Books":
                            query = @"
                                    SELECT SUM(QUANTITY) AS count, TRUNC(LAST_UPDATED) AS created_date
                                    FROM books
                                    WHERE LAST_UPDATED BETWEEN :from_date AND :to_date
                                    GROUP BY TRUNC(LAST_UPDATED)
                                    ORDER BY TRUNC(LAST_UPDATED)";
                            chartTitle = "Total Book Inventory Over Time";
                            seriesName = "Total Books";
                            break;

                        default:
                            values = Enumerable.Repeat(0.0, 10).ToList();
                            dates = Enumerable.Range(0, 10)
                                .Select(i => fromDate.AddDays(i).ToString("MMM dd"))
                                .ToList();
                            chartTitle = "Select a Statistic";
                            seriesName = "No Data";
                            break;
                    }

                    if (!string.IsNullOrEmpty(query))
                    {
                        var dataByDate = new Dictionary<DateTime, double>();

                        for (var day = fromDate.Date; day <= toDate.Date; day = day.AddDays(1))
                        {
                            dataByDate[day] = 0;
                        }

                        using (OracleCommand cmd = new OracleCommand(query, conn))
                        {
                            cmd.Parameters.Add(new OracleParameter("from_date", fromDate));
                            cmd.Parameters.Add(new OracleParameter("to_date", toDate));

                            using (OracleDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    DateTime date = Convert.ToDateTime(reader["created_date"]);
                                    double count = Convert.ToDouble(reader["count"]);

                                    dataByDate[date.Date] = count;
                                }
                            }
                        }

                        var sortedData = dataByDate.OrderBy(kvp => kvp.Key).ToList();
                        values = sortedData.Select(kvp => kvp.Value).ToList();
                        dates = sortedData.Select(kvp => kvp.Key.ToString("MMM dd")).ToList();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading chart data: {ex.Message}");

                    values = Enumerable.Repeat(0.0, 10).ToList();
                    dates = Enumerable.Range(0, 10)
                        .Select(i => fromDate.AddDays(i).ToString("MMM dd"))
                        .ToList();
                }
            }

            cartesianChart.Series = new ISeries[]
            {
                new LineSeries<double>
                {
                    Name = seriesName,
                    Values = values.ToArray(),
                    Stroke = new SolidColorPaint(SKColors.DodgerBlue) { StrokeThickness = 3 },
                    Fill = gradientPaint,
                    GeometrySize = 2,
                    LineSmoothness = 0.5
                }
            };

            cartesianChart.XAxes = new Axis[]
            {
                new Axis
                {
                    Name = "Date",
                    Labels = dates.ToArray(),
                    TextSize = 10,
                    SeparatorsPaint = new SolidColorPaint(SKColors.LightGray) { StrokeThickness = 1 },
                    TicksPaint = new SolidColorPaint(SKColors.LightGray) { StrokeThickness = 1 },
                    LabelsPaint = new SolidColorPaint(SKColors.Gray)
                }
            };

            cartesianChart.YAxes = new Axis[]
            {
                new Axis
                {
                    Name = yAxisName,
                    TextSize = 10,
                    SeparatorsPaint = new SolidColorPaint(SKColors.LightGray) { StrokeThickness = 1 },
                    TicksPaint = new SolidColorPaint(SKColors.LightGray) { StrokeThickness = 1 },
                    LabelsPaint = new SolidColorPaint(SKColors.Gray),
                    MinLimit = 0
                }
            };

            cartesianChart.Title = new LabelVisual
            {
                Text = chartTitle,
                TextSize = 16,
                Paint = new SolidColorPaint(SKColors.DarkSlateBlue)
            };

            cartesianChart.LegendPosition = LiveChartsCore.Measure.LegendPosition.Top;
            cartesianChart.LegendTextPaint = new SolidColorPaint(SKColors.DarkSlateBlue);
            cartesianChart.LegendTextSize = 6;

            chart_panel.Controls.Add(cartesianChart);
        }
    }
}
