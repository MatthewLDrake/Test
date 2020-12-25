namespace FormulaBasketball
{
    partial class GameResult
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
            this.teamOneGrid = new System.Windows.Forms.DataGridView();
            this.teamTwoGrid = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Minutes1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlayerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Minutes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TwoMade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TwosAttempted = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThreeMade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThreeAttempted = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FTMade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FTAtt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Assists = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OffRebound = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DefReb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Steals = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Blocks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TOs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.AwayEvent = new System.Windows.Forms.Button();
            this.HomeTeamEvent = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.teamOneGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teamTwoGrid)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // teamOneGrid
            // 
            this.teamOneGrid.AllowUserToAddRows = false;
            this.teamOneGrid.AllowUserToDeleteRows = false;
            this.teamOneGrid.AllowUserToResizeColumns = false;
            this.teamOneGrid.AllowUserToResizeRows = false;
            this.teamOneGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.teamOneGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PlayerName,
            this.Minutes,
            this.TwoMade,
            this.TwosAttempted,
            this.ThreeMade,
            this.ThreeAttempted,
            this.FTMade,
            this.FTAtt,
            this.Assists,
            this.OffRebound,
            this.DefReb,
            this.Steals,
            this.Blocks,
            this.TOs});
            this.tableLayoutPanel1.SetColumnSpan(this.teamOneGrid, 2);
            this.teamOneGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.teamOneGrid.Location = new System.Drawing.Point(3, 30);
            this.teamOneGrid.Name = "teamOneGrid";
            this.teamOneGrid.RowHeadersVisible = false;
            this.teamOneGrid.Size = new System.Drawing.Size(1058, 243);
            this.teamOneGrid.TabIndex = 0;
            // 
            // teamTwoGrid
            // 
            this.teamTwoGrid.AllowUserToAddRows = false;
            this.teamTwoGrid.AllowUserToDeleteRows = false;
            this.teamTwoGrid.AllowUserToResizeColumns = false;
            this.teamTwoGrid.AllowUserToResizeRows = false;
            this.teamTwoGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.teamTwoGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.Minutes1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13});
            this.tableLayoutPanel1.SetColumnSpan(this.teamTwoGrid, 2);
            this.teamTwoGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.teamTwoGrid.Location = new System.Drawing.Point(3, 306);
            this.teamTwoGrid.Name = "teamTwoGrid";
            this.teamTwoGrid.RowHeadersVisible = false;
            this.teamTwoGrid.Size = new System.Drawing.Size(1058, 246);
            this.teamTwoGrid.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.HeaderText = "Player Name";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // Minutes1
            // 
            this.Minutes1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Minutes1.HeaderText = "Minutes";
            this.Minutes1.Name = "Minutes1";
            this.Minutes1.Width = 69;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn2.HeaderText = "2\'s Made";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 75;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn3.HeaderText = "2\'s Attm";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 69;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn4.HeaderText = "3\'s Made";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 75;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn5.HeaderText = "3\'s Attm";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 69;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn6.HeaderText = "FT Made";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 75;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn7.HeaderText = "FT Attm";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 69;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn8.HeaderText = "Assists";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 64;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn9.HeaderText = "Off Reb";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Width = 69;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn10.HeaderText = "DefReb";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Width = 69;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn11.HeaderText = "Steals";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.Width = 61;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn12.HeaderText = "Blocks";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.Width = 64;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn13.HeaderText = "Turnovers";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.Width = 80;
            // 
            // PlayerName
            // 
            this.PlayerName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PlayerName.HeaderText = "Player Name";
            this.PlayerName.Name = "PlayerName";
            this.PlayerName.ReadOnly = true;
            // 
            // Minutes
            // 
            this.Minutes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Minutes.HeaderText = "Minutes";
            this.Minutes.Name = "Minutes";
            this.Minutes.Width = 69;
            // 
            // TwoMade
            // 
            this.TwoMade.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TwoMade.HeaderText = "2\'s Made";
            this.TwoMade.Name = "TwoMade";
            this.TwoMade.Width = 75;
            // 
            // TwosAttempted
            // 
            this.TwosAttempted.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TwosAttempted.HeaderText = "2\'s Attm";
            this.TwosAttempted.Name = "TwosAttempted";
            this.TwosAttempted.Width = 69;
            // 
            // ThreeMade
            // 
            this.ThreeMade.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ThreeMade.HeaderText = "3\'s Made";
            this.ThreeMade.Name = "ThreeMade";
            this.ThreeMade.Width = 75;
            // 
            // ThreeAttempted
            // 
            this.ThreeAttempted.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ThreeAttempted.HeaderText = "3\'s Attm";
            this.ThreeAttempted.Name = "ThreeAttempted";
            this.ThreeAttempted.Width = 69;
            // 
            // FTMade
            // 
            this.FTMade.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.FTMade.HeaderText = "FT Made";
            this.FTMade.Name = "FTMade";
            this.FTMade.Width = 75;
            // 
            // FTAtt
            // 
            this.FTAtt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.FTAtt.HeaderText = "FT Attm";
            this.FTAtt.Name = "FTAtt";
            this.FTAtt.Width = 69;
            // 
            // Assists
            // 
            this.Assists.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Assists.HeaderText = "Assists";
            this.Assists.Name = "Assists";
            this.Assists.Width = 64;
            // 
            // OffRebound
            // 
            this.OffRebound.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.OffRebound.HeaderText = "Off Reb";
            this.OffRebound.Name = "OffRebound";
            this.OffRebound.Width = 69;
            // 
            // DefReb
            // 
            this.DefReb.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DefReb.HeaderText = "DefReb";
            this.DefReb.Name = "DefReb";
            this.DefReb.Width = 69;
            // 
            // Steals
            // 
            this.Steals.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Steals.HeaderText = "Steals";
            this.Steals.Name = "Steals";
            this.Steals.Width = 61;
            // 
            // Blocks
            // 
            this.Blocks.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Blocks.HeaderText = "Blocks";
            this.Blocks.Name = "Blocks";
            this.Blocks.Width = 64;
            // 
            // TOs
            // 
            this.TOs.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TOs.HeaderText = "Turnovers";
            this.TOs.Name = "TOs";
            this.TOs.Width = 80;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.HomeTeamEvent, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.teamOneGrid, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.teamTwoGrid, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.AwayEvent, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1064, 555);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(231, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Away Team: ";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(230, 283);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Home Team: ";
            // 
            // AwayEvent
            // 
            this.AwayEvent.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AwayEvent.Location = new System.Drawing.Point(725, 3);
            this.AwayEvent.Name = "AwayEvent";
            this.AwayEvent.Size = new System.Drawing.Size(146, 21);
            this.AwayEvent.TabIndex = 4;
            this.AwayEvent.Text = "Away Team Event";
            this.AwayEvent.UseVisualStyleBackColor = true;
            // 
            // HomeTeamEvent
            // 
            this.HomeTeamEvent.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.HomeTeamEvent.Location = new System.Drawing.Point(725, 279);
            this.HomeTeamEvent.Name = "HomeTeamEvent";
            this.HomeTeamEvent.Size = new System.Drawing.Size(146, 21);
            this.HomeTeamEvent.TabIndex = 5;
            this.HomeTeamEvent.Text = "Home Team Event";
            this.HomeTeamEvent.UseVisualStyleBackColor = true;
            // 
            // GameResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 555);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "GameResult";
            this.Text = "GameResult";
            ((System.ComponentModel.ISupportInitialize)(this.teamOneGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teamTwoGrid)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView teamOneGrid;
        private System.Windows.Forms.DataGridView teamTwoGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlayerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Minutes;
        private System.Windows.Forms.DataGridViewTextBoxColumn TwoMade;
        private System.Windows.Forms.DataGridViewTextBoxColumn TwosAttempted;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThreeMade;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThreeAttempted;
        private System.Windows.Forms.DataGridViewTextBoxColumn FTMade;
        private System.Windows.Forms.DataGridViewTextBoxColumn FTAtt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Assists;
        private System.Windows.Forms.DataGridViewTextBoxColumn OffRebound;
        private System.Windows.Forms.DataGridViewTextBoxColumn DefReb;
        private System.Windows.Forms.DataGridViewTextBoxColumn Steals;
        private System.Windows.Forms.DataGridViewTextBoxColumn Blocks;
        private System.Windows.Forms.DataGridViewTextBoxColumn TOs;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Minutes1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button HomeTeamEvent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button AwayEvent;
    }
}