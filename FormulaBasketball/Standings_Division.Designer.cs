namespace FormulaBasketball
{
    partial class Standings_Division
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.place = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.teamName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wins = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.losses = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pointsScored = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pointsAgainst = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Streak = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(545, 36);
            this.label1.TabIndex = 0;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.place,
            this.teamName,
            this.wins,
            this.losses,
            this.pointsScored,
            this.pointsAgainst,
            this.Streak});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 36);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(545, 330);
            this.dataGridView1.TabIndex = 2;
            // 
            // place
            // 
            this.place.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.place.FillWeight = 60.9137F;
            this.place.HeaderText = "#";
            this.place.Name = "place";
            this.place.ReadOnly = true;
            this.place.Width = 39;
            // 
            // teamName
            // 
            this.teamName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.teamName.FillWeight = 107.8173F;
            this.teamName.HeaderText = "Team Name";
            this.teamName.Name = "teamName";
            this.teamName.ReadOnly = true;
            this.teamName.Width = 90;
            // 
            // wins
            // 
            this.wins.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.wins.FillWeight = 107.8173F;
            this.wins.HeaderText = "Wins";
            this.wins.Name = "wins";
            this.wins.ReadOnly = true;
            this.wins.Width = 56;
            // 
            // losses
            // 
            this.losses.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.losses.FillWeight = 107.8173F;
            this.losses.HeaderText = "Losses";
            this.losses.Name = "losses";
            this.losses.ReadOnly = true;
            this.losses.Width = 65;
            // 
            // pointsScored
            // 
            this.pointsScored.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.pointsScored.FillWeight = 107.8173F;
            this.pointsScored.HeaderText = "Points Scored";
            this.pointsScored.Name = "pointsScored";
            this.pointsScored.ReadOnly = true;
            this.pointsScored.Width = 98;
            // 
            // pointsAgainst
            // 
            this.pointsAgainst.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.pointsAgainst.FillWeight = 107.8173F;
            this.pointsAgainst.HeaderText = "Points Against";
            this.pointsAgainst.Name = "pointsAgainst";
            this.pointsAgainst.ReadOnly = true;
            this.pointsAgainst.Width = 99;
            // 
            // Streak
            // 
            this.Streak.HeaderText = "Streak";
            this.Streak.Name = "Streak";
            this.Streak.ReadOnly = true;
            // 
            // Standings_Division
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Name = "Standings_Division";
            this.Size = new System.Drawing.Size(545, 366);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn place;
        private System.Windows.Forms.DataGridViewTextBoxColumn teamName;
        private System.Windows.Forms.DataGridViewTextBoxColumn wins;
        private System.Windows.Forms.DataGridViewTextBoxColumn losses;
        private System.Windows.Forms.DataGridViewTextBoxColumn pointsScored;
        private System.Windows.Forms.DataGridViewTextBoxColumn pointsAgainst;
        private System.Windows.Forms.DataGridViewTextBoxColumn Streak;
    }
}
