namespace FormulaBasketball
{
    partial class PlayerRetirement
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.PlayerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Team = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Age = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PeakStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PeakEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Overall = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaxOverall = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Retire = new System.Windows.Forms.DataGridViewButtonColumn();
            this.PlayerOBJ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YearsLeft = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MoneyPerYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewContract = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PlayerName,
            this.Team,
            this.Age,
            this.PeakStart,
            this.PeakEnd,
            this.Overall,
            this.MaxOverall,
            this.Retire,
            this.PlayerOBJ,
            this.YearsLeft,
            this.MoneyPerYear,
            this.NewContract});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(1295, 736);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // PlayerName
            // 
            this.PlayerName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PlayerName.HeaderText = "Player Name";
            this.PlayerName.Name = "PlayerName";
            // 
            // Team
            // 
            this.Team.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Team.HeaderText = "Team";
            this.Team.Name = "Team";
            this.Team.Width = 59;
            // 
            // Age
            // 
            this.Age.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Age.HeaderText = "Age";
            this.Age.Name = "Age";
            this.Age.Width = 51;
            // 
            // PeakStart
            // 
            this.PeakStart.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.PeakStart.HeaderText = "Peak Start";
            this.PeakStart.Name = "PeakStart";
            this.PeakStart.Width = 82;
            // 
            // PeakEnd
            // 
            this.PeakEnd.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.PeakEnd.HeaderText = "Peak End";
            this.PeakEnd.Name = "PeakEnd";
            this.PeakEnd.Width = 79;
            // 
            // Overall
            // 
            this.Overall.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Overall.HeaderText = "Overall";
            this.Overall.Name = "Overall";
            this.Overall.Width = 65;
            // 
            // MaxOverall
            // 
            this.MaxOverall.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MaxOverall.HeaderText = "Max Overall";
            this.MaxOverall.Name = "MaxOverall";
            this.MaxOverall.Width = 88;
            // 
            // Retire
            // 
            this.Retire.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Retire.HeaderText = "Retire";
            this.Retire.Name = "Retire";
            this.Retire.Width = 41;
            // 
            // PlayerOBJ
            // 
            this.PlayerOBJ.HeaderText = "Player";
            this.PlayerOBJ.Name = "PlayerOBJ";
            this.PlayerOBJ.Visible = false;
            // 
            // YearsLeft
            // 
            this.YearsLeft.HeaderText = "Years Left";
            this.YearsLeft.Name = "YearsLeft";
            // 
            // MoneyPerYear
            // 
            this.MoneyPerYear.HeaderText = "Money Per Year";
            this.MoneyPerYear.Name = "MoneyPerYear";
            // 
            // NewContract
            // 
            this.NewContract.HeaderText = "NewContract";
            this.NewContract.Name = "NewContract";
            // 
            // PlayerRetirement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1295, 736);
            this.Controls.Add(this.dataGridView1);
            this.Name = "PlayerRetirement";
            this.Text = "PlayerRetirement";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlayerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Team;
        private System.Windows.Forms.DataGridViewTextBoxColumn Age;
        private System.Windows.Forms.DataGridViewTextBoxColumn PeakStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn PeakEnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn Overall;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaxOverall;
        private System.Windows.Forms.DataGridViewButtonColumn Retire;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlayerOBJ;
        private System.Windows.Forms.DataGridViewTextBoxColumn YearsLeft;
        private System.Windows.Forms.DataGridViewTextBoxColumn MoneyPerYear;
        private System.Windows.Forms.DataGridViewButtonColumn NewContract;
    }
}