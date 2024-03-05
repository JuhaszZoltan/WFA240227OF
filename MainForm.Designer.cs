namespace WFA240227OF
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgv = new DataGridView();
            btnDelete = new Button();
            btnInsert = new Button();
            btnModifies = new Button();
            clmID = new DataGridViewTextBoxColumn();
            clmTitle = new DataGridViewTextBoxColumn();
            clmYear = new DataGridViewTextBoxColumn();
            clmGenre = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            SuspendLayout();
            // 
            // dgv
            // 
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeColumns = false;
            dgv.AllowUserToResizeRows = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv.Columns.AddRange(new DataGridViewColumn[] { clmID, clmTitle, clmYear, clmGenre });
            dgv.Location = new Point(12, 12);
            dgv.Name = "dgv";
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.Size = new Size(692, 312);
            dgv.TabIndex = 0;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Salmon;
            btnDelete.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnDelete.Location = new Point(12, 461);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(271, 54);
            btnDelete.TabIndex = 1;
            btnDelete.Text = "DELETE selected movie";
            btnDelete.TextAlign = ContentAlignment.MiddleLeft;
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnInsert
            // 
            btnInsert.BackColor = Color.SpringGreen;
            btnInsert.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnInsert.Location = new Point(12, 341);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(271, 54);
            btnInsert.TabIndex = 1;
            btnInsert.Text = "INSERT new movie";
            btnInsert.TextAlign = ContentAlignment.MiddleLeft;
            btnInsert.UseVisualStyleBackColor = false;
            // 
            // btnModifies
            // 
            btnModifies.BackColor = Color.LightSkyBlue;
            btnModifies.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnModifies.Location = new Point(12, 401);
            btnModifies.Name = "btnModifies";
            btnModifies.Size = new Size(271, 54);
            btnModifies.TabIndex = 1;
            btnModifies.Text = "MODIFIES existing movie";
            btnModifies.TextAlign = ContentAlignment.MiddleLeft;
            btnModifies.UseVisualStyleBackColor = false;
            // 
            // clmID
            // 
            clmID.FillWeight = 1F;
            clmID.HeaderText = "ID";
            clmID.Name = "clmID";
            clmID.Visible = false;
            // 
            // clmTitle
            // 
            clmTitle.FillWeight = 2F;
            clmTitle.HeaderText = "Title";
            clmTitle.Name = "clmTitle";
            // 
            // clmYear
            // 
            clmYear.FillWeight = 1F;
            clmYear.HeaderText = "Year";
            clmYear.Name = "clmYear";
            // 
            // clmGenre
            // 
            clmGenre.FillWeight = 1F;
            clmGenre.HeaderText = "Genre";
            clmGenre.Name = "clmGenre";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(716, 527);
            Controls.Add(btnModifies);
            Controls.Add(btnInsert);
            Controls.Add(btnDelete);
            Controls.Add(dgv);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4);
            Name = "MainForm";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgv;
        private Button btnDelete;
        private Button btnInsert;
        private Button btnModifies;
        private DataGridViewTextBoxColumn clmID;
        private DataGridViewTextBoxColumn clmTitle;
        private DataGridViewTextBoxColumn clmYear;
        private DataGridViewTextBoxColumn clmGenre;
    }
}
