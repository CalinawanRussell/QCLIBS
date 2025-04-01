using Oracle.ManagedDataAccess.Client;
using System.Windows.Forms.DataVisualization.Charting;

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

        //ADD USER CLICK
        private void adduser_popup(object sender, EventArgs e)
        {
            disableall(adduser_panel);
        }

        private void adduser_popup_exit(object sender, EventArgs e)
        {
            enableall(adduser_panel);
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
    }
}
