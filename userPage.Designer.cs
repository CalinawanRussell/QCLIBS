namespace Library_system
{
    partial class userPage
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
            pnlHEADER = new Panel();
            picEXIT = new PictureBox();
            picMINI = new PictureBox();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            flpDASHBOARD = new FlowLayoutPanel();
            pnlBORROW = new Panel();
            pictureBox2 = new PictureBox();
            label2 = new Label();
            panel1 = new Panel();
            pictureBox4 = new PictureBox();
            label4 = new Label();
            pnlDGV = new Panel();
            pnlRECEIPT = new Panel();
            lblSTUDENTNUM = new Label();
            lblNAME = new Label();
            lblGENRE = new Label();
            lblAUTHOR = new Label();
            lblLANGUAGE = new Label();
            lblTITLE = new Label();
            btnCONFIRM = new Button();
            btnBORROW = new Button();
            booksDGV = new DataGridView();
            BOOK_ID = new DataGridViewTextBoxColumn();
            BOOK_LANGUAGE = new DataGridViewTextBoxColumn();
            TITLE = new DataGridViewTextBoxColumn();
            AUTHOR = new DataGridViewTextBoxColumn();
            GENRE = new DataGridViewTextBoxColumn();
            AVAILABLE = new DataGridViewTextBoxColumn();
            pnlHEADER.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picEXIT).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picMINI).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            flpDASHBOARD.SuspendLayout();
            pnlBORROW.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            pnlDGV.SuspendLayout();
            pnlRECEIPT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)booksDGV).BeginInit();
            SuspendLayout();
            // 
            // pnlHEADER
            // 
            pnlHEADER.BackColor = SystemColors.ControlLightLight;
            pnlHEADER.Controls.Add(picEXIT);
            pnlHEADER.Controls.Add(picMINI);
            pnlHEADER.Controls.Add(label1);
            pnlHEADER.Controls.Add(pictureBox1);
            pnlHEADER.Location = new Point(-9, -1);
            pnlHEADER.Name = "pnlHEADER";
            pnlHEADER.Size = new Size(1084, 55);
            pnlHEADER.TabIndex = 0;
            // 
            // picEXIT
            // 
            picEXIT.Image = Properties.Resources.exit;
            picEXIT.Location = new Point(1033, 17);
            picEXIT.Name = "picEXIT";
            picEXIT.Size = new Size(18, 18);
            picEXIT.SizeMode = PictureBoxSizeMode.StretchImage;
            picEXIT.TabIndex = 11;
            picEXIT.TabStop = false;
            picEXIT.Click += picEXIT_Click;
            // 
            // picMINI
            // 
            picMINI.Image = Properties.Resources.minimize_sign;
            picMINI.Location = new Point(996, 17);
            picMINI.Name = "picMINI";
            picMINI.Size = new Size(18, 18);
            picMINI.SizeMode = PictureBoxSizeMode.StretchImage;
            picMINI.TabIndex = 10;
            picMINI.TabStop = false;
            picMINI.Click += picMINI_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(61, 17);
            label1.Name = "label1";
            label1.Size = new Size(70, 24);
            label1.TabIndex = 8;
            label1.Text = "QCLIBS";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Library_icon;
            pictureBox1.Location = new Point(21, 13);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(32, 32);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // flpDASHBOARD
            // 
            flpDASHBOARD.BackColor = SystemColors.ButtonHighlight;
            flpDASHBOARD.Controls.Add(pnlBORROW);
            flpDASHBOARD.Controls.Add(panel1);
            flpDASHBOARD.Location = new Point(0, 53);
            flpDASHBOARD.Name = "flpDASHBOARD";
            flpDASHBOARD.Size = new Size(194, 733);
            flpDASHBOARD.TabIndex = 1;
            // 
            // pnlBORROW
            // 
            pnlBORROW.BackColor = SystemColors.ButtonHighlight;
            pnlBORROW.Controls.Add(pictureBox2);
            pnlBORROW.Controls.Add(label2);
            pnlBORROW.Location = new Point(3, 3);
            pnlBORROW.Name = "pnlBORROW";
            pnlBORROW.Size = new Size(184, 49);
            pnlBORROW.TabIndex = 3;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.book_borrow_icon;
            pictureBox2.Location = new Point(11, 9);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(32, 32);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 4;
            pictureBox2.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Trebuchet MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(52, 14);
            label2.Name = "label2";
            label2.Size = new Size(119, 22);
            label2.TabIndex = 4;
            label2.Text = "BORROW BOOK";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ButtonHighlight;
            panel1.Controls.Add(pictureBox4);
            panel1.Controls.Add(label4);
            panel1.Location = new Point(3, 58);
            panel1.Name = "panel1";
            panel1.Size = new Size(184, 49);
            panel1.TabIndex = 6;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = Properties.Resources.logout;
            pictureBox4.Location = new Point(11, 8);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(32, 32);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 5;
            pictureBox4.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Trebuchet MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(64, 13);
            label4.Name = "label4";
            label4.Size = new Size(75, 22);
            label4.TabIndex = 5;
            label4.Text = "LOG OUT";
            // 
            // pnlDGV
            // 
            pnlDGV.Controls.Add(pnlRECEIPT);
            pnlDGV.Controls.Add(btnBORROW);
            pnlDGV.Controls.Add(booksDGV);
            pnlDGV.Location = new Point(193, 56);
            pnlDGV.Name = "pnlDGV";
            pnlDGV.Size = new Size(866, 446);
            pnlDGV.TabIndex = 3;
            // 
            // pnlRECEIPT
            // 
            pnlRECEIPT.BackColor = SystemColors.ActiveCaption;
            pnlRECEIPT.BackgroundImage = Properties.Resources.BORROWERRECEIPT__1_;
            pnlRECEIPT.BackgroundImageLayout = ImageLayout.Stretch;
            pnlRECEIPT.Controls.Add(lblSTUDENTNUM);
            pnlRECEIPT.Controls.Add(lblNAME);
            pnlRECEIPT.Controls.Add(lblGENRE);
            pnlRECEIPT.Controls.Add(lblAUTHOR);
            pnlRECEIPT.Controls.Add(lblLANGUAGE);
            pnlRECEIPT.Controls.Add(lblTITLE);
            pnlRECEIPT.Controls.Add(btnCONFIRM);
            pnlRECEIPT.Location = new Point(288, 3);
            pnlRECEIPT.Name = "pnlRECEIPT";
            pnlRECEIPT.Size = new Size(281, 434);
            pnlRECEIPT.TabIndex = 3;
            // 
            // lblSTUDENTNUM
            // 
            lblSTUDENTNUM.AutoSize = true;
            lblSTUDENTNUM.BackColor = SystemColors.ActiveCaptionText;
            lblSTUDENTNUM.Font = new Font("Times New Roman", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSTUDENTNUM.ForeColor = SystemColors.ControlLightLight;
            lblSTUDENTNUM.Location = new Point(150, 326);
            lblSTUDENTNUM.Name = "lblSTUDENTNUM";
            lblSTUDENTNUM.Size = new Size(124, 17);
            lblSTUDENTNUM.TabIndex = 14;
            lblSTUDENTNUM.Text = "lblSTUDENTNUM";
            // 
            // lblNAME
            // 
            lblNAME.AutoSize = true;
            lblNAME.BackColor = SystemColors.ActiveCaptionText;
            lblNAME.Font = new Font("Times New Roman", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNAME.ForeColor = SystemColors.ControlLightLight;
            lblNAME.Location = new Point(100, 277);
            lblNAME.Name = "lblNAME";
            lblNAME.Size = new Size(65, 17);
            lblNAME.TabIndex = 13;
            lblNAME.Text = "lblNAME";
            // 
            // lblGENRE
            // 
            lblGENRE.AutoSize = true;
            lblGENRE.BackColor = SystemColors.ActiveCaptionText;
            lblGENRE.Font = new Font("Times New Roman", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblGENRE.ForeColor = SystemColors.ControlLightLight;
            lblGENRE.Location = new Point(116, 180);
            lblGENRE.Name = "lblGENRE";
            lblGENRE.Size = new Size(49, 17);
            lblGENRE.TabIndex = 12;
            lblGENRE.Text = "label13";
            // 
            // lblAUTHOR
            // 
            lblAUTHOR.AutoSize = true;
            lblAUTHOR.BackColor = SystemColors.ActiveCaptionText;
            lblAUTHOR.Font = new Font("Times New Roman", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAUTHOR.ForeColor = SystemColors.ControlLightLight;
            lblAUTHOR.Location = new Point(127, 130);
            lblAUTHOR.Name = "lblAUTHOR";
            lblAUTHOR.Size = new Size(49, 17);
            lblAUTHOR.TabIndex = 11;
            lblAUTHOR.Text = "label12";
            // 
            // lblLANGUAGE
            // 
            lblLANGUAGE.AutoSize = true;
            lblLANGUAGE.BackColor = SystemColors.ActiveCaptionText;
            lblLANGUAGE.Font = new Font("Times New Roman", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLANGUAGE.ForeColor = SystemColors.ControlLightLight;
            lblLANGUAGE.Location = new Point(150, 228);
            lblLANGUAGE.Name = "lblLANGUAGE";
            lblLANGUAGE.Size = new Size(48, 17);
            lblLANGUAGE.TabIndex = 10;
            lblLANGUAGE.Text = "label11";
            // 
            // lblTITLE
            // 
            lblTITLE.AutoSize = true;
            lblTITLE.BackColor = SystemColors.ActiveCaptionText;
            lblTITLE.Font = new Font("Times New Roman", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTITLE.ForeColor = SystemColors.Control;
            lblTITLE.Location = new Point(106, 83);
            lblTITLE.Name = "lblTITLE";
            lblTITLE.Size = new Size(42, 17);
            lblTITLE.TabIndex = 9;
            lblTITLE.Text = "label8";
            // 
            // btnCONFIRM
            // 
            btnCONFIRM.BackColor = SystemColors.ButtonFace;
            btnCONFIRM.FlatStyle = FlatStyle.Flat;
            btnCONFIRM.ForeColor = SystemColors.ActiveCaptionText;
            btnCONFIRM.Location = new Point(89, 388);
            btnCONFIRM.Name = "btnCONFIRM";
            btnCONFIRM.Size = new Size(109, 30);
            btnCONFIRM.TabIndex = 8;
            btnCONFIRM.Text = "CONFIRM";
            btnCONFIRM.UseVisualStyleBackColor = false;
            btnCONFIRM.Click += btnCONFIRM_Click_1;
            // 
            // btnBORROW
            // 
            btnBORROW.BackColor = SystemColors.ActiveCaptionText;
            btnBORROW.FlatStyle = FlatStyle.Flat;
            btnBORROW.ForeColor = SystemColors.ControlLightLight;
            btnBORROW.Location = new Point(725, 391);
            btnBORROW.Name = "btnBORROW";
            btnBORROW.Size = new Size(128, 35);
            btnBORROW.TabIndex = 1;
            btnBORROW.Text = "BORROW";
            btnBORROW.UseVisualStyleBackColor = false;
            btnBORROW.Click += btnBorrow_Click;
            // 
            // booksDGV
            // 
            booksDGV.BackgroundColor = SystemColors.Control;
            booksDGV.Columns.AddRange(new DataGridViewColumn[] { BOOK_ID, BOOK_LANGUAGE, TITLE, AUTHOR, GENRE, AVAILABLE });
            booksDGV.GridColor = Color.Orange;
            booksDGV.Location = new Point(0, 0);
            booksDGV.Name = "booksDGV";
            booksDGV.ReadOnly = true;
            booksDGV.Size = new Size(866, 374);
            booksDGV.TabIndex = 0;
            // 
            // BOOK_ID
            // 
            BOOK_ID.FillWeight = 61.19951F;
            BOOK_ID.HeaderText = "BOOK ID";
            BOOK_ID.Name = "BOOK_ID";
            BOOK_ID.ReadOnly = true;
            BOOK_ID.Width = 75;
            // 
            // BOOK_LANGUAGE
            // 
            BOOK_LANGUAGE.HeaderText = "LANGUAGE";
            BOOK_LANGUAGE.Name = "BOOK_LANGUAGE";
            BOOK_LANGUAGE.ReadOnly = true;
            BOOK_LANGUAGE.Width = 120;
            // 
            // TITLE
            // 
            TITLE.FillWeight = 83.1229553F;
            TITLE.HeaderText = "TITLE";
            TITLE.Name = "TITLE";
            TITLE.ReadOnly = true;
            TITLE.Width = 200;
            // 
            // AUTHOR
            // 
            AUTHOR.FillWeight = 102.363022F;
            AUTHOR.HeaderText = "AUTHOR";
            AUTHOR.Name = "AUTHOR";
            AUTHOR.ReadOnly = true;
            AUTHOR.Width = 170;
            // 
            // GENRE
            // 
            GENRE.FillWeight = 119.24807F;
            GENRE.HeaderText = "GENRE";
            GENRE.Name = "GENRE";
            GENRE.ReadOnly = true;
            GENRE.Width = 150;
            // 
            // AVAILABLE
            // 
            AVAILABLE.FillWeight = 134.066452F;
            AVAILABLE.HeaderText = "AVAILABLE BOOKS";
            AVAILABLE.Name = "AVAILABLE";
            AVAILABLE.ReadOnly = true;
            AVAILABLE.Width = 120;
            // 
            // userPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1058, 502);
            Controls.Add(pnlDGV);
            Controls.Add(flpDASHBOARD);
            Controls.Add(pnlHEADER);
            FormBorderStyle = FormBorderStyle.None;
            Name = "userPage";
            Text = "userPage";
            Load += userPage_Load;
            pnlHEADER.ResumeLayout(false);
            pnlHEADER.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picEXIT).EndInit();
            ((System.ComponentModel.ISupportInitialize)picMINI).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            flpDASHBOARD.ResumeLayout(false);
            pnlBORROW.ResumeLayout(false);
            pnlBORROW.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            pnlDGV.ResumeLayout(false);
            pnlRECEIPT.ResumeLayout(false);
            pnlRECEIPT.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)booksDGV).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHEADER;
        private FlowLayoutPanel flpDASHBOARD;
        private Panel pnlBORROW;
        private PictureBox pictureBox2;
        private Label label2;
        private Panel panel1;
        private PictureBox pictureBox4;
        private Label label4;
        private Panel pnlDGV;
        private DataGridView booksDGV;
        private DataGridViewCellEventHandler booksDGV_CellContentClick;
        private Button btnBORROW;
        private Panel pnlRECEIPT;
        private Label lblGENRE;
        private Label lblAUTHOR;
        private Label lblLANGUAGE;
        private Label lblTITLE;
        private Button btnCONFIRM;
        private DataGridViewTextBoxColumn BOOK_ID;
        private DataGridViewTextBoxColumn BOOK_LANGUAGE;
        private DataGridViewTextBoxColumn TITLE;
        private DataGridViewTextBoxColumn AUTHOR;
        private DataGridViewTextBoxColumn GENRE;
        private DataGridViewTextBoxColumn AVAILABLE;
        private Label lblSTUDENTNUM;
        private Label lblNAME;
        private PictureBox pictureBox1;
        private Label label1;
        private PictureBox picMINI;
        private PictureBox picEXIT;
    }
}