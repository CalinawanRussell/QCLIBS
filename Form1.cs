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
            users_dgv.Rows.Add("23-1854", "Ulgasan, Xeroj N.", "Xerojulgasan@gmail.com", "10");
            users_dgv.Rows.Add("23-1854", "Ulgasan, Xeroj N.", "Xerojulgasan@gmail.com", "10");
            users_dgv.Rows.Add("23-1854", "Ulgasan, Xeroj N.", "Xerojulgasan@gmail.com", "10");
            users_dgv.Rows.Add("23-1854", "Ulgasan, Xeroj N.", "Xerojulgasan@gmail.com", "10");
            users_dgv.Rows.Add("23-1854", "Ulgasan, Xeroj N.", "Xerojulgasan@gmail.com", "10");
        }

        private void status_btn_Click(object sender, EventArgs e)
        {
            status_cms.Show(status_btn, new Point(0, status_btn.Height));
        }
    }
}
