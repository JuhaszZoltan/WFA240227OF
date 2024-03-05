namespace WFA240227OF
{
    partial class MovieForm
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
            lblUI01 = new Label();
            lblUI02 = new Label();
            lblUI03 = new Label();
            lblUI04 = new Label();
            txbTitle = new TextBox();
            txbID = new TextBox();
            nudYear = new NumericUpDown();
            cbxGenres = new ComboBox();
            btnAdapter = new Button();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)nudYear).BeginInit();
            SuspendLayout();
            // 
            // lblUI01
            // 
            lblUI01.AutoSize = true;
            lblUI01.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblUI01.Location = new Point(25, 27);
            lblUI01.Name = "lblUI01";
            lblUI01.Size = new Size(31, 21);
            lblUI01.TabIndex = 0;
            lblUI01.Text = "ID:";
            // 
            // lblUI02
            // 
            lblUI02.AutoSize = true;
            lblUI02.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblUI02.Location = new Point(25, 83);
            lblUI02.Name = "lblUI02";
            lblUI02.Size = new Size(48, 21);
            lblUI02.TabIndex = 0;
            lblUI02.Text = "Title:";
            // 
            // lblUI03
            // 
            lblUI03.AutoSize = true;
            lblUI03.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblUI03.Location = new Point(25, 139);
            lblUI03.Name = "lblUI03";
            lblUI03.Size = new Size(110, 21);
            lblUI03.TabIndex = 0;
            lblUI03.Text = "Release Year:";
            // 
            // lblUI04
            // 
            lblUI04.AutoSize = true;
            lblUI04.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblUI04.Location = new Point(25, 195);
            lblUI04.Name = "lblUI04";
            lblUI04.Size = new Size(59, 21);
            lblUI04.TabIndex = 0;
            lblUI04.Text = "Genre:";
            // 
            // txbTitle
            // 
            txbTitle.Location = new Point(150, 80);
            txbTitle.Name = "txbTitle";
            txbTitle.Size = new Size(186, 29);
            txbTitle.TabIndex = 1;
            // 
            // txbID
            // 
            txbID.Enabled = false;
            txbID.Location = new Point(150, 24);
            txbID.Name = "txbID";
            txbID.Size = new Size(66, 29);
            txbID.TabIndex = 1;
            txbID.TextAlign = HorizontalAlignment.Right;
            // 
            // nudYear
            // 
            nudYear.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            nudYear.Location = new Point(150, 137);
            nudYear.Margin = new Padding(4, 4, 4, 4);
            nudYear.Maximum = new decimal(new int[] { 2050, 0, 0, 0 });
            nudYear.Name = "nudYear";
            nudYear.Size = new Size(66, 29);
            nudYear.TabIndex = 2;
            nudYear.TextAlign = HorizontalAlignment.Right;
            nudYear.Value = new decimal(new int[] { 2024, 0, 0, 0 });
            // 
            // cbxGenres
            // 
            cbxGenres.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxGenres.FormattingEnabled = true;
            cbxGenres.Location = new Point(150, 192);
            cbxGenres.Name = "cbxGenres";
            cbxGenres.Size = new Size(125, 29);
            cbxGenres.TabIndex = 3;
            // 
            // btnAdapter
            // 
            btnAdapter.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnAdapter.Location = new Point(12, 254);
            btnAdapter.Name = "btnAdapter";
            btnAdapter.Size = new Size(348, 55);
            btnAdapter.TabIndex = 4;
            btnAdapter.Text = "#placeholder#";
            btnAdapter.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 10F);
            button1.Location = new Point(281, 192);
            button1.Name = "button1";
            button1.Size = new Size(79, 29);
            button1.TabIndex = 5;
            button1.Text = "add genre";
            button1.UseVisualStyleBackColor = true;
            // 
            // MovieForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(372, 321);
            Controls.Add(button1);
            Controls.Add(btnAdapter);
            Controls.Add(cbxGenres);
            Controls.Add(nudYear);
            Controls.Add(txbID);
            Controls.Add(txbTitle);
            Controls.Add(lblUI04);
            Controls.Add(lblUI03);
            Controls.Add(lblUI02);
            Controls.Add(lblUI01);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4, 4, 4, 4);
            Name = "MovieForm";
            Text = "MovieForm";
            ((System.ComponentModel.ISupportInitialize)nudYear).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUI01;
        private Label lblUI02;
        private Label lblUI03;
        private Label lblUI04;
        private TextBox txbTitle;
        private TextBox txbID;
        private NumericUpDown nudYear;
        private ComboBox cbxGenres;
        private Button btnAdapter;
        private Button button1;
    }
}