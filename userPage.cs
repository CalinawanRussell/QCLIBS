using System;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace Library_system
{
    public partial class userPage : Form
    {
        public userPage()
        {
            InitializeComponent();

            // Attach event handler for CONFIRM button
            btnCONFIRM.Click += btnConfirm_Click;
            // Attach event handler for Borrow button
            btnBORROW.Click += btnBorrow_Click;
        }

        private void userPage_Load(object sender, EventArgs e)
        {
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
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Book successfully borrowed!", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Hide the receipt panel after confirmation
            pnlRECEIPT.Visible = false;
        }
    }
}