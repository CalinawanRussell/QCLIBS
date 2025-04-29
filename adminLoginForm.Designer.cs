namespace Library_system
{
    partial class adminLoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            txtPIN = new TextBox();
            btnENTER = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.adminlogin22o;
            pictureBox1.Location = new Point(12, 65);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(175, 128);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // txtPIN
            // 
            txtPIN.Location = new Point(16, 297);
            txtPIN.Name = "txtPIN";
            txtPIN.Size = new Size(165, 23);
            txtPIN.TabIndex = 1;
            // 
            // btnENTER
            // 
            btnENTER.BackColor = SystemColors.ActiveCaptionText;
            btnENTER.FlatStyle = FlatStyle.Flat;
            btnENTER.Font = new Font("Georgia", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnENTER.ForeColor = SystemColors.ButtonFace;
            btnENTER.Location = new Point(29, 372);
            btnENTER.Name = "btnENTER";
            btnENTER.Size = new Size(136, 42);
            btnENTER.TabIndex = 2;
            btnENTER.Text = "Enter";
            btnENTER.UseVisualStyleBackColor = false;
            btnENTER.Click += btnENTER_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Trebuchet MS", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(32, 258);
            label1.Name = "label1";
            label1.Size = new Size(130, 18);
            label1.TabIndex = 3;
            label1.Text = "Enter your ADMIN Pin";
            // 
            // adminLoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(200, 460);
            Controls.Add(label1);
            Controls.Add(btnENTER);
            Controls.Add(txtPIN);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "adminLoginForm";
            Text = "adminLoginForm";
            Load += adminLoginForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private TextBox txtPIN;
        private Button btnENTER;
        private Label label1;
    }
}