using System.Windows.Forms.DataVisualization.Charting;

namespace Library_system
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dashboard_panel.Visible = true;
            user_panel.Visible = false;
            add_book_panel.Visible = false;
            borrow_record_panel.Visible = false;
        }

        private void status_btn_Click(object sender, EventArgs e)
        {
            status_cms.Show(status_btn, new Point(0, status_btn.Height));
        }

        //TAB CLICKS TO DO
        // Dashboard
        // Users
        // Add Books
        // Borrow records

        //DASHBOARD CLICK
        private void dashboard_click(object sender, EventArgs e)
        {
            dashboard_panel.Visible = true;
            user_panel.Visible = false;
            add_book_panel.Visible = false;
            borrow_record_panel.Visible = false;
        }

        //USERS CLICK
        private void user_click(object sender, EventArgs e)
        {
            dashboard_panel.Visible = false;
            user_panel.Visible = true;
            add_book_panel.Visible = false;
            borrow_record_panel.Visible = false;
        }

        //ADD BOOKS CLICK
        private void add_books_click(object sender, EventArgs e)
        {
            dashboard_panel.Visible = false;
            user_panel.Visible = false;
            add_book_panel.Visible = true;
            borrow_record_panel.Visible = false;
        }

        //BORROW RECORDS CLICK
        private void borrow_record_click(object sender, EventArgs e)
        {
            dashboard_panel.Visible = false;
            user_panel.Visible = false;
            add_book_panel.Visible = false;
            borrow_record_panel.Visible = true;
        }
    }
}
