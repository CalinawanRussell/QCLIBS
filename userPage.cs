using System;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static Library_system.loginForm;

namespace Library_system
{
    public partial class userPage : Form
    {
        public userPage()
        {
            InitializeComponent();

            // Attach event handler for CONFIRM button
            btnCONFIRM.Click += btnCONFIRM_Click;
            // Attach event handler for Borrow button
            btnBORROW.Click += btnBorrow_Click;
        }

        private Color defaultColor = Color.Black;
        private Color hoverColor = Color.FromArgb(255, 248, 160, 28);

        private int StudentID { get; set; }

        public userPage(int studentId)
        {
            InitializeComponent();
            StudentID = studentId; // Set the logged-in user's ID
        }

        private void userPage_Load(object sender, EventArgs e)
        {
            lblNAME.Text = loginForm.Session.FirstName + " " + loginForm.Session.LastName;
            lblSTUDENTNUM.Text = loginForm.Session.StudentID.ToString();

            RoundedButtonHelper.ApplyRoundedCorners(btnBORROW, 18);
            RoundedButtonHelper.ApplyRoundedCorners(btnCONFIRM, 18);

            btnBORROW.MouseLeave += Button_MouseLeave;
            btnBORROW.MouseEnter += Button_MouseEnter;

            btnCONFIRM.MouseEnter += Button_MouseEnter;

            // Hide both Check-in controls and DGV at start
            HideCheckInControls();
            HideDataGridView();
            pnlRECEIPT.Visible = false; // Hide receipt panel at start

            // Make both panels and their children clickable
            pnlBORROW.Cursor = Cursors.Hand;
            pnlBORROW.Click += pnlBORROW_Click;
            foreach (Control ctl in pnlBORROW.Controls)
                ctl.Click += pnlBORROW_Click;

            pnlCHECKIN.Cursor = Cursors.Hand;
            pnlCHECKIN.Click += pnlCHECKIN_Click;
            foreach (Control ctl in pnlCHECKIN.Controls)
                ctl.Click += pnlCHECKIN_Click;

            SetupBooksDGV();
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

        private void pnlBORROW_Click(object sender, EventArgs e)
        {
            ShowDataGridView();
            HideCheckInControls();
            pnlRECEIPT.Visible = false;
            LoadBooks();
        }

        private void pnlCHECKIN_Click(object sender, EventArgs e)
        {
            ShowCheckInControls();
            HideDataGridView();
            pnlRECEIPT.Visible = false;
        }

        private void ShowCheckInControls()
        {
            pnlCHECK.Visible = true;
            lblTIME.Visible = true;
            btnCHECK.Visible = true;
        }

        private void HideCheckInControls()
        {
            pnlCHECK.Visible = false;
            lblTIME.Visible = false;
            btnCHECK.Visible = false;
        }

        private void ShowDataGridView()
        {
            pnlDGV.Visible = true;
            booksDGV.Visible = true;
        }

        private void HideDataGridView()
        {
            pnlDGV.Visible = false;
            booksDGV.Visible = false;
        }


        private void SetupBooksDGV()
        {
            if (booksDGV.Columns.Count > 0) return;

            booksDGV.AutoGenerateColumns = false;
            booksDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            booksDGV.MultiSelect = false;
            booksDGV.AllowUserToAddRows = false;
            booksDGV.ReadOnly = true;

            booksDGV.Columns.Add("BOOK_ID", "Book ID");
            booksDGV.Columns.Add("BOOK_LANGUAGE", "Language");
            booksDGV.Columns.Add("TITLE", "Title");
            booksDGV.Columns.Add("AUTHOR", "Author");
            booksDGV.Columns.Add("GENRE", "Genre");
            booksDGV.Columns.Add("AVAILABLE", "Available");
            booksDGV.Columns["BOOK_ID"].Visible = false;
        }

        private void LoadBooks()
        {
            booksDGV.Rows.Clear();
            string connectionString = "User Id=RUSSELL; Password=Russell_2700; Data Source=localhost:1521/XE;";
            using (var conn = new OracleConnection(connectionString))
            {
                string query = @"
                    SELECT 
                        book_id, 
                        book_language,
                        title, 
                        author, 
                        genre, 
                        (quantity - NVL((SELECT COUNT(*) FROM borrowed_books bb WHERE bb.book_id = b.book_id AND bb.status = 'Borrowed'), 0)) AS available
                    FROM books b";
                using (var cmd = new OracleCommand(query, conn))
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            booksDGV.Rows.Add(
                                reader["book_id"].ToString(),
                                reader["book_language"].ToString(),
                                reader["title"].ToString(),
                                reader["author"].ToString(),
                                reader["genre"].ToString(),
                                reader["available"].ToString()
                            );
                        }
                    }
                }
            }
        }

        private void pnlCHECK_Paint(object sender, PaintEventArgs e)
        {
            // Custom painting logic if needed
        }

        private void btnCHECK_Click(object sender, EventArgs e)
        {
            string currentTime = DateTime.Now.ToString("hh:mmtt");
            lblTIME.Text = $"You checked in at: {currentTime}";
        }

        // --- Borrowing Receipt Logic ---

        // When user clicks the "Borrow" button under the DGV
        private void btnBorrow_Click(object sender, EventArgs e)
        {
            var id = Session.StudentID;
            var name = Session.FirstName + " " + Session.LastName;

            if (booksDGV.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a book to borrow.");
                return;
            }

            var row = booksDGV.SelectedRows[0];

            // Set the receipt panel labels to the selected book's details
            lblTITLE.Text = row.Cells["TITLE"].Value.ToString();
            lblLANGUAGE.Text = row.Cells["BOOK_LANGUAGE"].Value.ToString();
            lblAUTHOR.Text = row.Cells["AUTHOR"].Value.ToString();
            lblGENRE.Text = row.Cells["GENRE"].Value.ToString();

            // Show the receipt panel
            pnlRECEIPT.Visible = true;
        }

        // When user clicks the "CONFIRM" button on the receipt panel
        private void btnCONFIRM_Click(object sender, EventArgs e)
        {
            // (Optional: Validate input or session)
            string title = lblTITLE.Text;
            string author = lblAUTHOR.Text;
            string genre = lblGENRE.Text;
            string language = lblLANGUAGE.Text;

            string connectionString = "User Id=RUSSELL; Password=Russell_2700; Data Source=localhost:1521/XE;";

            using (var conn = new OracleConnection(connectionString))
            {
                conn.Open();
                string query = @"
            INSERT INTO borrowed_books 
                (borrower_id, borrow_date, borrow_due, status, book_id)
            VALUES 
                (
                    :borrower_id,
                    SYSDATE,
                    SYSDATE + 7,
                    'Borrowed',
                    (SELECT book_id FROM books WHERE title = :title AND author = :author AND genre = :genre AND book_language = :language)
                )";

                using (var cmd = new OracleCommand(query, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("borrower_id", Session.StudentID));
                    cmd.Parameters.Add(new OracleParameter("title", title));
                    cmd.Parameters.Add(new OracleParameter("author", author));
                    cmd.Parameters.Add(new OracleParameter("genre", genre));
                    cmd.Parameters.Add(new OracleParameter("language", language));
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Book successfully borrowed!", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);


            // (Optional) Any additional code: hide receipt panel, reload books, etc.

            pnlRECEIPT.Visible = false; // Hide receipt panel
            LoadBooks(); // Reload books
        }
        private void pnlHEADER_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCONFIRM_Click_1(object sender, EventArgs e)
        {

        }

        private void txtNAME_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSTUD_TextChanged(object sender, EventArgs e)
        {

        }
    }
}