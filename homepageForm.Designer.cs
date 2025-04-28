namespace Library_system
{
    partial class homepageForm
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
            btnADMIN = new Button();
            btnSTUDENT = new Button();
            SuspendLayout();
            // 
            // btnADMIN
            // 
            btnADMIN.BackColor = SystemColors.ActiveCaptionText;
            btnADMIN.Cursor = Cursors.Hand;
            btnADMIN.FlatAppearance.BorderSize = 0;
            btnADMIN.FlatStyle = FlatStyle.Flat;
            btnADMIN.ForeColor = SystemColors.ControlLightLight;
            btnADMIN.Location = new Point(459, 142);
            btnADMIN.Name = "btnADMIN";
            btnADMIN.Size = new Size(140, 35);
            btnADMIN.TabIndex = 0;
            btnADMIN.Text = "ADMIN";
            btnADMIN.UseVisualStyleBackColor = false;
            btnADMIN.Click += btnADMIN_Click;
            // 
            // btnSTUDENT
            // 
            btnSTUDENT.BackColor = SystemColors.ActiveCaptionText;
            btnSTUDENT.Cursor = Cursors.Hand;
            btnSTUDENT.FlatAppearance.BorderSize = 0;
            btnSTUDENT.FlatStyle = FlatStyle.Flat;
            btnSTUDENT.ForeColor = SystemColors.ControlLightLight;
            btnSTUDENT.Location = new Point(459, 252);
            btnSTUDENT.Name = "btnSTUDENT";
            btnSTUDENT.Size = new Size(140, 35);
            btnSTUDENT.TabIndex = 1;
            btnSTUDENT.Text = "STUDENT";
            btnSTUDENT.UseVisualStyleBackColor = false;
            btnSTUDENT.Click += btnSTUDENT_Click;
            // 
            // homepageForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.final1;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(655, 420);
            Controls.Add(btnSTUDENT);
            Controls.Add(btnADMIN);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "homepageForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form2";
            Load += Form2_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnADMIN;
        private Button btnSTUDENT;
       
    }
}