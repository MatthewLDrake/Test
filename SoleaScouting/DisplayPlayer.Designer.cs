namespace SoleaScouting
{
    partial class DisplayPlayer
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
            this.list = new System.Windows.Forms.DataGridView();
            this.theName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Age = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShootingPercentage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Points = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Assists = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rebounds = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OpponentShoot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Country = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.University = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.list)).BeginInit();
            this.SuspendLayout();
            // 
            // list
            // 
            this.list.AllowUserToAddRows = false;
            this.list.AllowUserToDeleteRows = false;
            this.list.AllowUserToOrderColumns = true;
            this.list.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.list.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.theName,
            this.Age,
            this.ShootingPercentage,
            this.Points,
            this.Assists,
            this.Rebounds,
            this.OpponentShoot,
            this.Country,
            this.University});
            this.list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.list.Location = new System.Drawing.Point(0, 0);
            this.list.Name = "list";
            this.list.ReadOnly = true;
            this.list.RowHeadersVisible = false;
            this.list.Size = new System.Drawing.Size(802, 112);
            this.list.TabIndex = 0;
            // 
            // theName
            // 
            this.theName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.theName.HeaderText = "Name";
            this.theName.Name = "theName";
            this.theName.ReadOnly = true;
            this.theName.Width = 60;
            // 
            // Age
            // 
            this.Age.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Age.HeaderText = "Age";
            this.Age.Name = "Age";
            this.Age.ReadOnly = true;
            this.Age.Width = 51;
            // 
            // ShootingPercentage
            // 
            this.ShootingPercentage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ShootingPercentage.HeaderText = "shootPercent";
            this.ShootingPercentage.Name = "ShootingPercentage";
            this.ShootingPercentage.ReadOnly = true;
            this.ShootingPercentage.Width = 95;
            // 
            // Points
            // 
            this.Points.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Points.HeaderText = "Points";
            this.Points.Name = "Points";
            this.Points.ReadOnly = true;
            this.Points.Width = 61;
            // 
            // Assists
            // 
            this.Assists.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Assists.HeaderText = "Assists";
            this.Assists.Name = "Assists";
            this.Assists.ReadOnly = true;
            this.Assists.Width = 64;
            // 
            // Rebounds
            // 
            this.Rebounds.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Rebounds.HeaderText = "Rebounds";
            this.Rebounds.Name = "Rebounds";
            this.Rebounds.ReadOnly = true;
            this.Rebounds.Width = 81;
            // 
            // OpponentShoot
            // 
            this.OpponentShoot.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.OpponentShoot.HeaderText = "OpponentShoot";
            this.OpponentShoot.Name = "OpponentShoot";
            this.OpponentShoot.ReadOnly = true;
            this.OpponentShoot.Width = 107;
            // 
            // Country
            // 
            this.Country.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Country.HeaderText = "Country";
            this.Country.Name = "Country";
            this.Country.ReadOnly = true;
            this.Country.Width = 68;
            // 
            // University
            // 
            this.University.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.University.HeaderText = "University";
            this.University.Name = "University";
            this.University.ReadOnly = true;
            // 
            // DisplayPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 112);
            this.Controls.Add(this.list);
            this.Name = "DisplayPlayer";
            this.Text = "DisplayPlayer";
            ((System.ComponentModel.ISupportInitialize)(this.list)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView list;
        private System.Windows.Forms.DataGridViewTextBoxColumn theName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Age;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShootingPercentage;
        private System.Windows.Forms.DataGridViewTextBoxColumn Points;
        private System.Windows.Forms.DataGridViewTextBoxColumn Assists;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rebounds;
        private System.Windows.Forms.DataGridViewTextBoxColumn OpponentShoot;
        private System.Windows.Forms.DataGridViewTextBoxColumn Country;
        private System.Windows.Forms.DataGridViewTextBoxColumn University;
    }
}