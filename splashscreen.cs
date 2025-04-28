using System;
using System.Drawing;
using System.Windows.Forms;

namespace Library_system
{
    public partial class splashscreen : Form
    {
        private ColoredProgressBar coloredProgressBar1;

        public splashscreen()
        {
            InitializeComponent();
        }

        private void splashscreen_Load(object sender, EventArgs e)
        {
            // Create and configure the custom orange progress bar
            coloredProgressBar1 = new ColoredProgressBar();
            coloredProgressBar1.Location = new Point(123, 299); // Adjust as needed
            coloredProgressBar1.Size = new Size(428, 11);      // Adjust as needed
            coloredProgressBar1.BarColor = Color.FromArgb(248, 160, 28); // QCLIBS orange
            coloredProgressBar1.Minimum = 0;
            coloredProgressBar1.Maximum = 100;
            coloredProgressBar1.Value = 0;

            // Add to form
            this.Controls.Add(coloredProgressBar1);

            // Start the timer
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            coloredProgressBar1.Increment(100); // Adjust to control speed

            if (coloredProgressBar1.Value >= 100)
            {
                timer1.Stop();
                this.Hide();
                homepageForm form = new homepageForm();
                form.Show();
            }
        }
    }
}