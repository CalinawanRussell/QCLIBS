namespace Library_system
{
    partial class loginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(loginForm));
            btnLOGIN = new Button();
            picQCLIBS = new PictureBox();
            txtboxUNAME = new TextBox();
            txtboxPASS = new TextBox();
            lblDONTACC = new Label();
            lblSIGNUP = new Label();
            picboxSHOWlogpass = new PictureBox();
            picboxHIDElogpass = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)picQCLIBS).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picboxSHOWlogpass).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picboxHIDElogpass).BeginInit();
            SuspendLayout();
            // 
            // btnLOGIN
            // 
            btnLOGIN.BackColor = Color.Black;
            btnLOGIN.Cursor = Cursors.Hand;
            btnLOGIN.FlatStyle = FlatStyle.Flat;
            btnLOGIN.Font = new Font("Georgia", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLOGIN.ForeColor = Color.White;
            btnLOGIN.Location = new Point(33, 375);
            btnLOGIN.Name = "btnLOGIN";
            btnLOGIN.Size = new Size(132, 35);
            btnLOGIN.TabIndex = 2;
            btnLOGIN.Text = "Access Library";
            btnLOGIN.UseVisualStyleBackColor = false;
            btnLOGIN.Click += btnLOGIN_Click;
            // 
            // picQCLIBS
            // 
            picQCLIBS.Image = (Image)resources.GetObject("picQCLIBS.Image");
            picQCLIBS.Location = new Point(12, 52);
            picQCLIBS.Name = "picQCLIBS";
            picQCLIBS.Size = new Size(175, 128);
            picQCLIBS.SizeMode = PictureBoxSizeMode.Zoom;
            picQCLIBS.TabIndex = 3;
            picQCLIBS.TabStop = false;
            // 
            // txtboxUNAME
            // 
            txtboxUNAME.Font = new Font("Cascadia Code", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtboxUNAME.Location = new Point(12, 222);
            txtboxUNAME.Name = "txtboxUNAME";
            txtboxUNAME.PlaceholderText = "USERNAME";
            txtboxUNAME.Size = new Size(175, 20);
            txtboxUNAME.TabIndex = 4;
            // 
            // txtboxPASS
            // 
            txtboxPASS.Font = new Font("Cascadia Code", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtboxPASS.Location = new Point(12, 279);
            txtboxPASS.Name = "txtboxPASS";
            txtboxPASS.PlaceholderText = "PASSWORD";
            txtboxPASS.Size = new Size(175, 20);
            txtboxPASS.TabIndex = 5;
            txtboxPASS.UseSystemPasswordChar = true;
            // 
            // lblDONTACC
            // 
            lblDONTACC.AutoSize = true;
            lblDONTACC.Font = new Font("Trebuchet MS", 8F);
            lblDONTACC.ForeColor = SystemColors.ControlDark;
            lblDONTACC.Location = new Point(12, 316);
            lblDONTACC.Name = "lblDONTACC";
            lblDONTACC.Size = new Size(122, 16);
            lblDONTACC.TabIndex = 6;
            lblDONTACC.Text = "Don't have an Account?";
            // 
            // lblSIGNUP
            // 
            lblSIGNUP.AutoSize = true;
            lblSIGNUP.Cursor = Cursors.Hand;
            lblSIGNUP.Font = new Font("Trebuchet MS", 8F);
            lblSIGNUP.ForeColor = Color.DodgerBlue;
            lblSIGNUP.Location = new Point(131, 316);
            lblSIGNUP.Name = "lblSIGNUP";
            lblSIGNUP.Size = new Size(43, 16);
            lblSIGNUP.TabIndex = 7;
            lblSIGNUP.Text = "Sign Up";
            lblSIGNUP.Click += lblSIGNUP_Click;
            // 
            // picboxSHOWlogpass
            // 
            picboxSHOWlogpass.BackColor = SystemColors.Window;
            picboxSHOWlogpass.Image = Properties.Resources.showpass;
            picboxSHOWlogpass.Location = new Point(166, 282);
            picboxSHOWlogpass.Name = "picboxSHOWlogpass";
            picboxSHOWlogpass.Size = new Size(20, 15);
            picboxSHOWlogpass.SizeMode = PictureBoxSizeMode.Zoom;
            picboxSHOWlogpass.TabIndex = 13;
            picboxSHOWlogpass.TabStop = false;
            picboxSHOWlogpass.Click += picboxSHOWlogpass_Click;
            // 
            // picboxHIDElogpass
            // 
            picboxHIDElogpass.BackColor = SystemColors.Window;
            picboxHIDElogpass.Image = Properties.Resources.hidepass;
            picboxHIDElogpass.Location = new Point(166, 282);
            picboxHIDElogpass.Name = "picboxHIDElogpass";
            picboxHIDElogpass.Size = new Size(20, 15);
            picboxHIDElogpass.SizeMode = PictureBoxSizeMode.Zoom;
            picboxHIDElogpass.TabIndex = 14;
            picboxHIDElogpass.TabStop = false;
            picboxHIDElogpass.Click += picboxHIDElogpass_Click;
            // 
            // loginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(199, 457);
            Controls.Add(picboxHIDElogpass);
            Controls.Add(picboxSHOWlogpass);
            Controls.Add(lblSIGNUP);
            Controls.Add(lblDONTACC);
            Controls.Add(txtboxPASS);
            Controls.Add(txtboxUNAME);
            Controls.Add(picQCLIBS);
            Controls.Add(btnLOGIN);
            FormBorderStyle = FormBorderStyle.None;
            Name = "loginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "loginForm";
            Load += loginForm_Load;
            ((System.ComponentModel.ISupportInitialize)picQCLIBS).EndInit();
            ((System.ComponentModel.ISupportInitialize)picboxSHOWlogpass).EndInit();
            ((System.ComponentModel.ISupportInitialize)picboxHIDElogpass).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnLOGIN;
        private PictureBox picQCLIBS;
        private TextBox txtboxUNAME;
        private TextBox txtboxPASS;
        private Label lblDONTACC;
        private Label lblSIGNUP;
        private PictureBox picboxSHOWlogpass;
        private PictureBox picboxHIDElogpass;
    }
}