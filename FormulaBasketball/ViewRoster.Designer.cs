namespace FormulaBasketball
{
    partial class ViewRoster
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
            this.rosterGrid = new System.Windows.Forms.DataGridView();
            this.playerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Position = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Age = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Overall = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Potential = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ratings = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Stats = new System.Windows.Forms.DataGridViewButtonColumn();
            this.CapHit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlayerObject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.rosterGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // rosterGrid
            // 
            this.rosterGrid.AllowUserToAddRows = false;
            this.rosterGrid.AllowUserToDeleteRows = false;
            this.rosterGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rosterGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.playerName,
            this.Position,
            this.Age,
            this.Overall,
            this.Potential,
            this.Ratings,
            this.Stats,
            this.CapHit,
            this.PlayerObject});
            this.rosterGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rosterGrid.Location = new System.Drawing.Point(0, 0);
            this.rosterGrid.MultiSelect = false;
            this.rosterGrid.Name = "rosterGrid";
            this.rosterGrid.RowHeadersVisible = false;
            this.rosterGrid.Size = new System.Drawing.Size(664, 320);
            this.rosterGrid.TabIndex = 5;
            this.rosterGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellContentClick);
            // 
            // playerName
            // 
            this.playerName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.playerName.HeaderText = "Player Name";
            this.playerName.Name = "playerName";
            // 
            // Position
            // 
            this.Position.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Position.HeaderText = "Position";
            this.Position.Name = "Position";
            this.Position.Width = 69;
            // 
            // Age
            // 
            this.Age.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Age.HeaderText = "Age";
            this.Age.Name = "Age";
            this.Age.Width = 51;
            // 
            // Overall
            // 
            this.Overall.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Overall.HeaderText = "Overall";
            this.Overall.Name = "Overall";
            this.Overall.ReadOnly = true;
            this.Overall.Width = 65;
            // 
            // Potential
            // 
            this.Potential.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Potential.HeaderText = "Potential";
            this.Potential.Name = "Potential";
            this.Potential.Width = 73;
            // 
            // Ratings
            // 
            this.Ratings.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Ratings.HeaderText = "Ratings";
            this.Ratings.Name = "Ratings";
            this.Ratings.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Ratings.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Ratings.Width = 68;
            // 
            // Stats
            // 
            this.Stats.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Stats.HeaderText = "Stats";
            this.Stats.Name = "Stats";
            this.Stats.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Stats.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Stats.Width = 56;
            // 
            // CapHit
            // 
            this.CapHit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.CapHit.HeaderText = "Cap Hit";
            this.CapHit.Name = "CapHit";
            this.CapHit.Width = 67;
            // 
            // PlayerObject
            // 
            this.PlayerObject.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.PlayerObject.HeaderText = "PlayerObject";
            this.PlayerObject.Name = "PlayerObject";
            this.PlayerObject.Visible = false;
            this.PlayerObject.Width = 92;
            // 
            // ViewRoster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 320);
            this.Controls.Add(this.rosterGrid);
            this.Name = "ViewRoster";
            this.Text = "ViewRoster";
            ((System.ComponentModel.ISupportInitialize)(this.rosterGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView rosterGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn playerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Position;
        private System.Windows.Forms.DataGridViewTextBoxColumn Age;
        private System.Windows.Forms.DataGridViewTextBoxColumn Overall;
        private System.Windows.Forms.DataGridViewTextBoxColumn Potential;
        private System.Windows.Forms.DataGridViewButtonColumn Ratings;
        private System.Windows.Forms.DataGridViewButtonColumn Stats;
        private System.Windows.Forms.DataGridViewTextBoxColumn CapHit;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlayerObject;

    }
}