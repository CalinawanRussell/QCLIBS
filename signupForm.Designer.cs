namespace Library_system
{
    partial class signupForm
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
            txtboxFirstname = new TextBox();
            txtboxLastname = new TextBox();
            txtboxStudnum = new TextBox();
            txtboxEmail = new TextBox();
            txtboxPass = new TextBox();
            txtboxConfirm = new TextBox();
            btnEnter = new Button();
            picboxSHOWPASS = new PictureBox();
            picboxHIDEPASS = new PictureBox();
            picboxSHOWCONFIRM = new PictureBox();
            picboxHIDECONFIRM = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)picboxSHOWPASS).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picboxHIDEPASS).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picboxSHOWCONFIRM).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picboxHIDECONFIRM).BeginInit();
            SuspendLayout();
            // 
            // txtboxFirstname
            // 
            txtboxFirstname.Location = new Point(554, 120);
            txtboxFirstname.Name = "txtboxFirstname";
            txtboxFirstname.Size = new Size(144, 23);
            txtboxFirstname.TabIndex = 0;
            // 
            // txtboxLastname
            // 
            txtboxLastname.Location = new Point(554, 161);
            txtboxLastname.Name = "txtboxLastname";
            txtboxLastname.Size = new Size(144, 23);
            txtboxLastname.TabIndex = 1;
            // 
            // txtboxStudnum
            // 
            txtboxStudnum.Location = new Point(554, 201);
            txtboxStudnum.Name = "txtboxStudnum";
            txtboxStudnum.Size = new Size(144, 23);
            txtboxStudnum.TabIndex = 2;
            // 
            // txtboxEmail
            // 
            txtboxEmail.Location = new Point(554, 240);
            txtboxEmail.Name = "txtboxEmail";
            txtboxEmail.Size = new Size(144, 23);
            txtboxEmail.TabIndex = 3;
            // 
            // txtboxPass
            // 
            txtboxPass.Location = new Point(554, 278);
            txtboxPass.Name = "txtboxPass";
            txtboxPass.Size = new Size(144, 23);
            txtboxPass.TabIndex = 4;
            txtboxPass.UseSystemPasswordChar = true;
            // 
            // txtboxConfirm
            // 
            txtboxConfirm.Location = new Point(554, 320);
            txtboxConfirm.Name = "txtboxConfirm";
            txtboxConfirm.Size = new Size(144, 23);
            txtboxConfirm.TabIndex = 5;
            txtboxConfirm.UseSystemPasswordChar = true;
            // 
            // btnEnter
            // 
            btnEnter.BackColor = SystemColors.ActiveCaptionText;
            btnEnter.FlatStyle = FlatStyle.Flat;
            btnEnter.Font = new Font("Georgia", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEnter.ForeColor = SystemColors.ControlLightLight;
            btnEnter.Location = new Point(514, 380);
            btnEnter.Name = "btnEnter";
            btnEnter.Size = new Size(114, 30);
            btnEnter.TabIndex = 6;
            btnEnter.Text = "SIGN IN";
            btnEnter.UseVisualStyleBackColor = false;
            btnEnter.Click += btnEnter_Click;
            // 
            // picboxSHOWPASS
            // 
            picboxSHOWPASS.BackColor = SystemColors.Window;
            picboxSHOWPASS.Image = Properties.Resources.showpass;
            picboxSHOWPASS.Location = new Point(679, 280);
            picboxSHOWPASS.Name = "picboxSHOWPASS";
            picboxSHOWPASS.Size = new Size(20, 20);
            picboxSHOWPASS.SizeMode = PictureBoxSizeMode.Zoom;
            picboxSHOWPASS.TabIndex = 7;
            picboxSHOWPASS.TabStop = false;
            picboxSHOWPASS.Click += picboxSHOWPASS_Click;
            // 
            // picboxHIDEPASS
            // 
            picboxHIDEPASS.BackColor = SystemColors.Window;
            picboxHIDEPASS.Image = Properties.Resources.hidepass;
            picboxHIDEPASS.Location = new Point(679, 280);
            picboxHIDEPASS.Name = "picboxHIDEPASS";
            picboxHIDEPASS.Size = new Size(20, 20);
            picboxHIDEPASS.SizeMode = PictureBoxSizeMode.Zoom;
            picboxHIDEPASS.TabIndex = 8;
            picboxHIDEPASS.TabStop = false;
            picboxHIDEPASS.Click += picboxHIDEPASS_Click;
            // 
            // picboxSHOWCONFIRM
            // 
            picboxSHOWCONFIRM.BackColor = SystemColors.Window;
            picboxSHOWCONFIRM.Image = Properties.Resources.showpass;
            picboxSHOWCONFIRM.Location = new Point(679, 322);
            picboxSHOWCONFIRM.Name = "picboxSHOWCONFIRM";
            picboxSHOWCONFIRM.Size = new Size(20, 20);
            picboxSHOWCONFIRM.SizeMode = PictureBoxSizeMode.Zoom;
            picboxSHOWCONFIRM.TabIndex = 9;
            picboxSHOWCONFIRM.TabStop = false;
            picboxSHOWCONFIRM.Click += picboxSHOWCONFIRM_Click;
            // 
            // picboxHIDECONFIRM
            // 
            picboxHIDECONFIRM.BackColor = SystemColors.Window;
            picboxHIDECONFIRM.Image = Properties.Resources.hidepass;
            picboxHIDECONFIRM.Location = new Point(679, 322);
            picboxHIDECONFIRM.Name = "picboxHIDECONFIRM";
            picboxHIDECONFIRM.Size = new Size(20, 20);
            picboxHIDECONFIRM.SizeMode = PictureBoxSizeMode.Zoom;
            picboxHIDECONFIRM.TabIndex = 10;
            picboxHIDECONFIRM.TabStop = false;
            picboxHIDECONFIRM.Click += picboxHIDECONFIRM_Click;
            // 
            // signupForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.SIGNUP1;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(717, 433);
            Controls.Add(picboxHIDECONFIRM);
            Controls.Add(picboxSHOWCONFIRM);
            Controls.Add(picboxHIDEPASS);
            Controls.Add(picboxSHOWPASS);
            Controls.Add(btnEnter);
            Controls.Add(txtboxConfirm);
            Controls.Add(txtboxPass);
            Controls.Add(txtboxEmail);
            Controls.Add(txtboxStudnum);
            Controls.Add(txtboxLastname);
            Controls.Add(txtboxFirstname);
            FormBorderStyle = FormBorderStyle.None;
            Name = "signupForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = " ";
            Load += signupForm_Load;
            ((System.ComponentModel.ISupportInitialize)picboxSHOWPASS).EndInit();
            ((System.ComponentModel.ISupportInitialize)picboxHIDEPASS).EndInit();
            ((System.ComponentModel.ISupportInitialize)picboxSHOWCONFIRM).EndInit();
            ((System.ComponentModel.ISupportInitialize)picboxHIDECONFIRM).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtboxFirstname;
        private TextBox txtboxLastname;
        private TextBox txtboxStudnum;
        private TextBox txtboxEmail;
        private TextBox txtboxPass;
        private TextBox txtboxConfirm;
        private Button btnEnter;
        private PictureBox picboxSHOWPASS;
        private PictureBox picboxHIDEPASS;
        private PictureBox picboxSHOWCONFIRM;
        private PictureBox picboxHIDECONFIRM;
    }
}