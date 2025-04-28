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
            flpDASHBOARD = new FlowLayoutPanel();
            pnlCHECKIN = new Panel();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            pnlBORROW = new Panel();
            pictureBox2 = new PictureBox();
            label2 = new Label();
            pnlBOOKMARKS = new Panel();
            pictureBox3 = new PictureBox();
            label3 = new Label();
            panel1 = new Panel();
            pictureBox4 = new PictureBox();
            label4 = new Label();
            pnlCHECK = new Panel();
            lblTIME = new Label();
            btnCHECK = new Button();
            pnlDGV = new Panel();
            pnlRECEIPT = new Panel();
            lblGENRE = new Label();
            lblAUTHOR = new Label();
            lblLANGUAGE = new Label();
            lblTITLE = new Label();
            btnCONFIRM = new Button();
            label7 = new Label();
            label6 = new Label();
            label10 = new Label();
            label9 = new Label();
            label5 = new Label();
            btnBOOKMARK = new Button();
            btnBORROW = new Button();
            booksDGV = new DataGridView();
            BOOK_ID = new DataGridViewTextBoxColumn();
            BOOK_LANGUAGE = new DataGridViewTextBoxColumn();
            TITLE = new DataGridViewTextBoxColumn();
            AUTHOR = new DataGridViewTextBoxColumn();
            GENRE = new DataGridViewTextBoxColumn();
            AVAILABLE = new DataGridViewTextBoxColumn();
            flpDASHBOARD.SuspendLayout();
            pnlCHECKIN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            pnlBORROW.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            pnlBOOKMARKS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            pnlCHECK.SuspendLayout();
            pnlDGV.SuspendLayout();
            pnlRECEIPT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)booksDGV).BeginInit();
            SuspendLayout();
            // 
            // pnlHEADER
            // 
            pnlHEADER.BackColor = SystemColors.ActiveCaptionText;
            pnlHEADER.Location = new Point(-9, -1);
            pnlHEADER.Name = "pnlHEADER";
            pnlHEADER.Size = new Size(1084, 55);
            pnlHEADER.TabIndex = 0;
            // 
            // flpDASHBOARD
            // 
            flpDASHBOARD.BackColor = SystemColors.ButtonHighlight;
            flpDASHBOARD.Controls.Add(pnlCHECKIN);
            flpDASHBOARD.Controls.Add(pnlBORROW);
            flpDASHBOARD.Controls.Add(pnlBOOKMARKS);
            flpDASHBOARD.Controls.Add(panel1);
            flpDASHBOARD.Location = new Point(0, 53);
            flpDASHBOARD.Name = "flpDASHBOARD";
            flpDASHBOARD.Size = new Size(194, 733);
            flpDASHBOARD.TabIndex = 1;
            // 
            // pnlCHECKIN
            // 
            pnlCHECKIN.BackColor = SystemColors.ButtonHighlight;
            pnlCHECKIN.Controls.Add(pictureBox1);
            pnlCHECKIN.Controls.Add(label1);
            pnlCHECKIN.Cursor = Cursors.Hand;
            pnlCHECKIN.Location = new Point(3, 3);
            pnlCHECKIN.Name = "pnlCHECKIN";
            pnlCHECKIN.Size = new Size(184, 49);
            pnlCHECKIN.TabIndex = 2;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.check_in;
            pictureBox1.Location = new Point(11, 8);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(32, 32);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Trebuchet MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(71, 14);
            label1.Name = "label1";
            label1.Size = new Size(77, 22);
            label1.TabIndex = 3;
            label1.Text = "CHECK IN";
            // 
            // pnlBORROW
            // 
            pnlBORROW.BackColor = SystemColors.ButtonHighlight;
            pnlBORROW.Controls.Add(pictureBox2);
            pnlBORROW.Controls.Add(label2);
            pnlBORROW.Location = new Point(3, 58);
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
            // pnlBOOKMARKS
            // 
            pnlBOOKMARKS.BackColor = SystemColors.ButtonHighlight;
            pnlBOOKMARKS.Controls.Add(pictureBox3);
            pnlBOOKMARKS.Controls.Add(label3);
            pnlBOOKMARKS.Location = new Point(3, 113);
            pnlBOOKMARKS.Name = "pnlBOOKMARKS";
            pnlBOOKMARKS.Size = new Size(184, 49);
            pnlBOOKMARKS.TabIndex = 3;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.booksmark;
            pictureBox3.Location = new Point(11, 8);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(32, 32);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 5;
            pictureBox3.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Trebuchet MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(66, 13);
            label3.Name = "label3";
            label3.Size = new Size(96, 22);
            label3.TabIndex = 5;
            label3.Text = "BOOKMARKS";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ButtonHighlight;
            panel1.Controls.Add(pictureBox4);
            panel1.Controls.Add(label4);
            panel1.Location = new Point(3, 168);
            panel1.Name = "panel1";
            panel1.Size = new Size(184, 49);
            panel1.TabIndex = 6;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = Properties.Resources.video_book;
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
            label4.Location = new Point(60, 13);
            label4.Name = "label4";
            label4.Size = new Size(108, 22);
            label4.TabIndex = 5;
            label4.Text = "VIEW LIBRARY";
            // 
            // pnlCHECK
            // 
            pnlCHECK.BackColor = Color.Gainsboro;
            pnlCHECK.Controls.Add(lblTIME);
            pnlCHECK.Controls.Add(btnCHECK);
            pnlCHECK.Location = new Point(483, 140);
            pnlCHECK.Name = "pnlCHECK";
            pnlCHECK.Size = new Size(281, 325);
            pnlCHECK.TabIndex = 2;
            pnlCHECK.Paint += pnlCHECK_Paint;
            // 
            // lblTIME
            // 
            lblTIME.AutoSize = true;
            lblTIME.ForeColor = SystemColors.ActiveCaptionText;
            lblTIME.Location = new Point(73, 89);
            lblTIME.Name = "lblTIME";
            lblTIME.Size = new Size(0, 15);
            lblTIME.TabIndex = 1;
            // 
            // btnCHECK
            // 
            btnCHECK.BackColor = SystemColors.Desktop;
            btnCHECK.FlatStyle = FlatStyle.Flat;
            btnCHECK.ForeColor = SystemColors.ControlLightLight;
            btnCHECK.Location = new Point(62, 246);
            btnCHECK.Name = "btnCHECK";
            btnCHECK.Size = new Size(163, 44);
            btnCHECK.TabIndex = 0;
            btnCHECK.Text = "CHECK IN";
            btnCHECK.UseVisualStyleBackColor = false;
            btnCHECK.Click += btnCHECK_Click;
            // 
            // pnlDGV
            // 
            pnlDGV.Controls.Add(pnlRECEIPT);
            pnlDGV.Controls.Add(btnBOOKMARK);
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
            pnlRECEIPT.Controls.Add(lblGENRE);
            pnlRECEIPT.Controls.Add(lblAUTHOR);
            pnlRECEIPT.Controls.Add(lblLANGUAGE);
            pnlRECEIPT.Controls.Add(lblTITLE);
            pnlRECEIPT.Controls.Add(btnCONFIRM);
            pnlRECEIPT.Controls.Add(label7);
            pnlRECEIPT.Controls.Add(label6);
            pnlRECEIPT.Controls.Add(label10);
            pnlRECEIPT.Controls.Add(label9);
            pnlRECEIPT.Controls.Add(label5);
            pnlRECEIPT.Location = new Point(290, 55);
            pnlRECEIPT.Name = "pnlRECEIPT";
            pnlRECEIPT.Size = new Size(281, 354);
            pnlRECEIPT.TabIndex = 3;
            // 
            // lblGENRE
            // 
            lblGENRE.AutoSize = true;
            lblGENRE.Location = new Point(114, 223);
            lblGENRE.Name = "lblGENRE";
            lblGENRE.Size = new Size(44, 15);
            lblGENRE.TabIndex = 12;
            lblGENRE.Text = "label13";
            // 
            // lblAUTHOR
            // 
            lblAUTHOR.AutoSize = true;
            lblAUTHOR.Location = new Point(114, 177);
            lblAUTHOR.Name = "lblAUTHOR";
            lblAUTHOR.Size = new Size(44, 15);
            lblAUTHOR.TabIndex = 11;
            lblAUTHOR.Text = "label12";
            // 
            // lblLANGUAGE
            // 
            lblLANGUAGE.AutoSize = true;
            lblLANGUAGE.Location = new Point(128, 129);
            lblLANGUAGE.Name = "lblLANGUAGE";
            lblLANGUAGE.Size = new Size(44, 15);
            lblLANGUAGE.TabIndex = 10;
            lblLANGUAGE.Text = "label11";
            // 
            // lblTITLE
            // 
            lblTITLE.AutoSize = true;
            lblTITLE.Location = new Point(98, 79);
            lblTITLE.Name = "lblTITLE";
            lblTITLE.Size = new Size(38, 15);
            lblTITLE.TabIndex = 9;
            lblTITLE.Text = "label8";
            // 
            // btnCONFIRM
            // 
            btnCONFIRM.BackColor = SystemColors.ActiveCaptionText;
            btnCONFIRM.FlatStyle = FlatStyle.Flat;
            btnCONFIRM.ForeColor = SystemColors.Control;
            btnCONFIRM.Location = new Point(92, 283);
            btnCONFIRM.Name = "btnCONFIRM";
            btnCONFIRM.Size = new Size(104, 28);
            btnCONFIRM.TabIndex = 8;
            btnCONFIRM.Text = "CONFIRM";
            btnCONFIRM.UseVisualStyleBackColor = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Trebuchet MS", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(45, 77);
            label7.Name = "label7";
            label7.Size = new Size(47, 18);
            label7.TabIndex = 7;
            label7.Text = "TITLE:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Trebuchet MS", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(45, 127);
            label6.Name = "label6";
            label6.Size = new Size(77, 18);
            label6.TabIndex = 6;
            label6.Text = "LANGUAGE:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Trebuchet MS", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(45, 174);
            label10.Name = "label10";
            label10.Size = new Size(63, 18);
            label10.TabIndex = 5;
            label10.Text = "AUTHOR:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Trebuchet MS", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(45, 220);
            label9.Name = "label9";
            label9.Size = new Size(52, 18);
            label9.TabIndex = 4;
            label9.Text = "GENRE:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Trebuchet MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(58, 29);
            label5.Name = "label5";
            label5.Size = new Size(173, 22);
            label5.TabIndex = 0;
            label5.Text = "BORROWER'S RECEIPT";
            // 
            // btnBOOKMARK
            // 
            btnBOOKMARK.Location = new Point(580, 398);
            btnBOOKMARK.Name = "btnBOOKMARK";
            btnBOOKMARK.Size = new Size(127, 23);
            btnBOOKMARK.TabIndex = 2;
            btnBOOKMARK.Text = "ADD TO BOOKMARK";
            btnBOOKMARK.UseVisualStyleBackColor = true;
            // 
            // btnBORROW
            // 
            btnBORROW.Location = new Point(726, 398);
            btnBORROW.Name = "btnBORROW";
            btnBORROW.Size = new Size(127, 23);
            btnBORROW.TabIndex = 1;
            btnBORROW.Text = "BORROW";
            btnBORROW.UseVisualStyleBackColor = true;
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
            Controls.Add(pnlCHECK);
            Controls.Add(flpDASHBOARD);
            Controls.Add(pnlHEADER);
            FormBorderStyle = FormBorderStyle.None;
            Name = "userPage";
            Text = "userPage";
            Load += userPage_Load;
            flpDASHBOARD.ResumeLayout(false);
            pnlCHECKIN.ResumeLayout(false);
            pnlCHECKIN.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            pnlBORROW.ResumeLayout(false);
            pnlBORROW.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            pnlBOOKMARKS.ResumeLayout(false);
            pnlBOOKMARKS.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            pnlCHECK.ResumeLayout(false);
            pnlCHECK.PerformLayout();
            pnlDGV.ResumeLayout(false);
            pnlRECEIPT.ResumeLayout(false);
            pnlRECEIPT.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)booksDGV).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHEADER;
        private FlowLayoutPanel flpDASHBOARD;
        private Panel pnlCHECKIN;
        private Panel pnlBORROW;
        private Panel pnlBOOKMARKS;
        private Label label1;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Label label2;
        private PictureBox pictureBox3;
        private Label label3;
        private Panel panel1;
        private PictureBox pictureBox4;
        private Label label4;
        private Panel pnlCHECK;
        private Button btnCHECK;
        private Label lblTIME;
        private Panel pnlDGV;
        private DataGridView booksDGV;
        private DataGridViewCellEventHandler booksDGV_CellContentClick;
        private Button btnBORROW;
        private Button btnBOOKMARK;
        private Panel pnlRECEIPT;
        private Label label6;
        private Label label10;
        private Label label9;
        private Label label5;
        private Label lblGENRE;
        private Label lblAUTHOR;
        private Label lblLANGUAGE;
        private Label lblTITLE;
        private Button btnCONFIRM;
        private Label label7;
        private DataGridViewTextBoxColumn BOOK_ID;
        private DataGridViewTextBoxColumn BOOK_LANGUAGE;
        private DataGridViewTextBoxColumn TITLE;
        private DataGridViewTextBoxColumn AUTHOR;
        private DataGridViewTextBoxColumn GENRE;
        private DataGridViewTextBoxColumn AVAILABLE;
    }
}