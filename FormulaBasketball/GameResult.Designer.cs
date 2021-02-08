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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.teamTwoGrid = new System.Windows.Forms.DataGridView();
            this.HomeTeamEvent = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.advanceTime = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.AwayEvent = new System.Windows.Forms.Button();
            this.PlayerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TwoMade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThreeMade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FTMade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Assists = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OffRebound = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Steals = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Blocks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TOs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fouls = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddStats = new System.Windows.Forms.DataGridViewButtonColumn();
            this.AddInjury = new System.Windows.Forms.DataGridViewButtonColumn();
            this.PlayerObj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FoulsA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewButtonColumn2 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Player = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.teamOneGrid)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teamTwoGrid)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
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
            this.TwoMade,
            this.ThreeMade,
            this.FTMade,
            this.Assists,
            this.OffRebound,
            this.Steals,
            this.Blocks,
            this.TOs,
            this.Fouls,
            this.AddStats,
            this.AddInjury,
            this.PlayerObj});
            this.tableLayoutPanel1.SetColumnSpan(this.teamOneGrid, 2);
            this.teamOneGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.teamOneGrid.Location = new System.Drawing.Point(3, 36);
            this.teamOneGrid.Name = "teamOneGrid";
            this.teamOneGrid.RowHeadersVisible = false;
            this.teamOneGrid.Size = new System.Drawing.Size(1058, 265);
            this.teamOneGrid.TabIndex = 0;
            this.teamOneGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.teamOneGrid_CellContentClick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.teamTwoGrid, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.HomeTeamEvent, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.teamOneGrid, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.advanceTime, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.AwayEvent, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1064, 679);
            this.tableLayoutPanel1.TabIndex = 2;
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
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.FoulsA,
            this.dataGridViewButtonColumn1,
            this.dataGridViewButtonColumn2,
            this.Player});
            this.tableLayoutPanel1.SetColumnSpan(this.teamTwoGrid, 2);
            this.teamTwoGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.teamTwoGrid.Location = new System.Drawing.Point(3, 340);
            this.teamTwoGrid.Name = "teamTwoGrid";
            this.teamTwoGrid.RowHeadersVisible = false;
            this.teamTwoGrid.Size = new System.Drawing.Size(1058, 265);
            this.teamTwoGrid.TabIndex = 8;
            this.teamTwoGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.teamTwoGrid_CellContentClick);
            // 
            // HomeTeamEvent
            // 
            this.HomeTeamEvent.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.HomeTeamEvent.Location = new System.Drawing.Point(725, 310);
            this.HomeTeamEvent.Name = "HomeTeamEvent";
            this.HomeTeamEvent.Size = new System.Drawing.Size(146, 21);
            this.HomeTeamEvent.TabIndex = 5;
            this.HomeTeamEvent.Text = "Home Team Event";
            this.HomeTeamEvent.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(230, 314);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Home Team: ";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(231, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Away Team: ";
            // 
            // advanceTime
            // 
            this.advanceTime.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.advanceTime.Location = new System.Drawing.Point(208, 621);
            this.advanceTime.Name = "advanceTime";
            this.advanceTime.Size = new System.Drawing.Size(115, 44);
            this.advanceTime.TabIndex = 6;
            this.advanceTime.Text = "Advance Time";
            this.advanceTime.UseVisualStyleBackColor = true;
            this.advanceTime.Click += new System.EventHandler(this.advanceTime_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.numericUpDown1, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(535, 611);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(526, 65);
            this.tableLayoutPanel2.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(257, 65);
            this.label3.TabIndex = 0;
            this.label3.Text = "label3";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDown1.Location = new System.Drawing.Point(266, 22);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(257, 20);
            this.numericUpDown1.TabIndex = 1;
            // 
            // AwayEvent
            // 
            this.AwayEvent.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AwayEvent.Location = new System.Drawing.Point(725, 6);
            this.AwayEvent.Name = "AwayEvent";
            this.AwayEvent.Size = new System.Drawing.Size(146, 21);
            this.AwayEvent.TabIndex = 4;
            this.AwayEvent.Text = "Away Team Event";
            this.AwayEvent.UseVisualStyleBackColor = true;
            // 
            // PlayerName
            // 
            this.PlayerName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PlayerName.HeaderText = "Player Name";
            this.PlayerName.Name = "PlayerName";
            this.PlayerName.ReadOnly = true;
            // 
            // TwoMade
            // 
            this.TwoMade.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TwoMade.HeaderText = "2\'s";
            this.TwoMade.Name = "TwoMade";
            this.TwoMade.Width = 45;
            // 
            // ThreeMade
            // 
            this.ThreeMade.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ThreeMade.HeaderText = "3\'s";
            this.ThreeMade.Name = "ThreeMade";
            this.ThreeMade.Width = 45;
            // 
            // FTMade
            // 
            this.FTMade.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.FTMade.HeaderText = "FT";
            this.FTMade.Name = "FTMade";
            this.FTMade.Width = 45;
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
            this.OffRebound.HeaderText = "Rebounds";
            this.OffRebound.Name = "OffRebound";
            this.OffRebound.Width = 81;
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
            // Fouls
            // 
            this.Fouls.HeaderText = "Fouls";
            this.Fouls.Name = "Fouls";
            // 
            // AddStats
            // 
            this.AddStats.HeaderText = "AddStats";
            this.AddStats.Name = "AddStats";
            // 
            // AddInjury
            // 
            this.AddInjury.HeaderText = "Add Injury";
            this.AddInjury.Name = "AddInjury";
            // 
            // PlayerObj
            // 
            this.PlayerObj.HeaderText = "PlayerObj";
            this.PlayerObj.Name = "PlayerObj";
            this.PlayerObj.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.HeaderText = "Player Name";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn3.HeaderText = "2\'s";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 45;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn4.HeaderText = "3\'s";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 45;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn5.HeaderText = "FT";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 45;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn6.HeaderText = "Assists";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 64;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn7.HeaderText = "Rebounds";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 81;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn8.HeaderText = "Steals";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 61;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn9.HeaderText = "Blocks";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Width = 64;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn10.HeaderText = "Turnovers";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Width = 80;
            // 
            // FoulsA
            // 
            this.FoulsA.HeaderText = "Fouls";
            this.FoulsA.Name = "FoulsA";
            // 
            // dataGridViewButtonColumn1
            // 
            this.dataGridViewButtonColumn1.HeaderText = "AddStats";
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            // 
            // dataGridViewButtonColumn2
            // 
            this.dataGridViewButtonColumn2.HeaderText = "Add Injury";
            this.dataGridViewButtonColumn2.Name = "dataGridViewButtonColumn2";
            // 
            // Player
            // 
            this.Player.HeaderText = "Player";
            this.Player.Name = "Player";
            this.Player.Visible = false;
            // 
            // GameResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 679);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "GameResult";
            this.Text = "GameResult";
            ((System.ComponentModel.ISupportInitialize)(this.teamOneGrid)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teamTwoGrid)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView teamOneGrid;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button HomeTeamEvent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button AwayEvent;
        private System.Windows.Forms.Button advanceTime;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView teamTwoGrid;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlayerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TwoMade;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThreeMade;
        private System.Windows.Forms.DataGridViewTextBoxColumn FTMade;
        private System.Windows.Forms.DataGridViewTextBoxColumn Assists;
        private System.Windows.Forms.DataGridViewTextBoxColumn OffRebound;
        private System.Windows.Forms.DataGridViewTextBoxColumn Steals;
        private System.Windows.Forms.DataGridViewTextBoxColumn Blocks;
        private System.Windows.Forms.DataGridViewTextBoxColumn TOs;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fouls;
        private System.Windows.Forms.DataGridViewButtonColumn AddStats;
        private System.Windows.Forms.DataGridViewButtonColumn AddInjury;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlayerObj;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn FoulsA;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Player;
    }
}