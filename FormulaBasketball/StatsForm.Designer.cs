namespace FormulaBasketball
{
    partial class StatsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.upButton = new System.Windows.Forms.Button();
            this.teamList = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.downButton = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.team = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Minutes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Assists = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Points = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShotsTaken = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shotsMade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fgPercent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThreesTaken = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThreesMade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Turnovers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Steals = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rebounds = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DefensiveRebounds = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OffensiveRebounds = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fouls = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OpponentShotsTaken = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shotsMadeAgainst = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OFGP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlusMinus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 3);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1527, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Stats Viewer";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.team,
            this.name,
            this.Minutes,
            this.Assists,
            this.Points,
            this.ShotsTaken,
            this.shotsMade,
            this.fgPercent,
            this.ThreesTaken,
            this.ThreesMade,
            this.Turnovers,
            this.Steals,
            this.Rebounds,
            this.DefensiveRebounds,
            this.OffensiveRebounds,
            this.Fouls,
            this.OpponentShotsTaken,
            this.shotsMadeAgainst,
            this.OFGP,
            this.PlusMinus});
            this.tableLayoutPanel1.SetColumnSpan(this.dataGridView1, 3);
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 59);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(1527, 513);
            this.dataGridView1.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.upButton, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.teamList, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1533, 575);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // upButton
            // 
            this.upButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.upButton.Location = new System.Drawing.Point(243, 31);
            this.upButton.Name = "upButton";
            this.upButton.Size = new System.Drawing.Size(60, 22);
            this.upButton.TabIndex = 6;
            this.upButton.Text = "▲";
            this.upButton.UseVisualStyleBackColor = true;
            // 
            // teamList
            // 
            this.teamList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.teamList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.teamList.FormattingEnabled = true;
            this.teamList.Location = new System.Drawing.Point(309, 31);
            this.teamList.Name = "teamList";
            this.teamList.Size = new System.Drawing.Size(913, 21);
            this.teamList.TabIndex = 5;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.45454F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.54546F));
            this.tableLayoutPanel2.Controls.Add(this.downButton, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.checkBox1, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(1225, 28);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(308, 28);
            this.tableLayoutPanel2.TabIndex = 7;
            // 
            // downButton
            // 
            this.downButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.downButton.Location = new System.Drawing.Point(3, 3);
            this.downButton.Name = "downButton";
            this.downButton.Size = new System.Drawing.Size(60, 22);
            this.downButton.TabIndex = 9;
            this.downButton.Text = "▼";
            this.downButton.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(142, 5);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(73, 17);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.Text = "Per Game";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // team
            // 
            this.team.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.team.HeaderText = "Team";
            this.team.Name = "team";
            this.team.ReadOnly = true;
            this.team.Width = 59;
            // 
            // name
            // 
            this.name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.name.HeaderText = "Name";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 60;
            // 
            // Minutes
            // 
            this.Minutes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Minutes.HeaderText = "Minutes";
            this.Minutes.Name = "Minutes";
            this.Minutes.ReadOnly = true;
            this.Minutes.Width = 69;
            // 
            // Assists
            // 
            this.Assists.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Assists.HeaderText = "Assists";
            this.Assists.Name = "Assists";
            this.Assists.ReadOnly = true;
            this.Assists.Width = 64;
            // 
            // Points
            // 
            this.Points.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Points.HeaderText = "Points";
            this.Points.Name = "Points";
            this.Points.ReadOnly = true;
            this.Points.Width = 61;
            // 
            // ShotsTaken
            // 
            this.ShotsTaken.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ShotsTaken.HeaderText = "Shots Taken";
            this.ShotsTaken.Name = "ShotsTaken";
            this.ShotsTaken.ReadOnly = true;
            this.ShotsTaken.Width = 86;
            // 
            // shotsMade
            // 
            this.shotsMade.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.shotsMade.HeaderText = "Shots Made";
            this.shotsMade.Name = "shotsMade";
            this.shotsMade.ReadOnly = true;
            this.shotsMade.Width = 82;
            // 
            // fgPercent
            // 
            this.fgPercent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.fgPercent.HeaderText = "FG%";
            this.fgPercent.Name = "fgPercent";
            this.fgPercent.ReadOnly = true;
            this.fgPercent.Width = 54;
            // 
            // ThreesTaken
            // 
            this.ThreesTaken.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ThreesTaken.HeaderText = "Threes Taken";
            this.ThreesTaken.Name = "ThreesTaken";
            this.ThreesTaken.ReadOnly = true;
            this.ThreesTaken.Width = 91;
            // 
            // ThreesMade
            // 
            this.ThreesMade.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ThreesMade.HeaderText = "ThreesMade";
            this.ThreesMade.Name = "ThreesMade";
            this.ThreesMade.ReadOnly = true;
            this.ThreesMade.Width = 92;
            // 
            // Turnovers
            // 
            this.Turnovers.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Turnovers.HeaderText = "Turnovers";
            this.Turnovers.Name = "Turnovers";
            this.Turnovers.ReadOnly = true;
            this.Turnovers.Width = 80;
            // 
            // Steals
            // 
            this.Steals.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Steals.HeaderText = "Steals";
            this.Steals.Name = "Steals";
            this.Steals.ReadOnly = true;
            this.Steals.Width = 61;
            // 
            // Rebounds
            // 
            this.Rebounds.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Rebounds.HeaderText = "Rebounds";
            this.Rebounds.Name = "Rebounds";
            this.Rebounds.ReadOnly = true;
            this.Rebounds.Width = 81;
            // 
            // DefensiveRebounds
            // 
            this.DefensiveRebounds.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.DefensiveRebounds.HeaderText = "Def Rebounds";
            this.DefensiveRebounds.Name = "DefensiveRebounds";
            this.DefensiveRebounds.ReadOnly = true;
            this.DefensiveRebounds.Width = 93;
            // 
            // OffensiveRebounds
            // 
            this.OffensiveRebounds.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.OffensiveRebounds.HeaderText = "Off Rebounds";
            this.OffensiveRebounds.Name = "OffensiveRebounds";
            this.OffensiveRebounds.ReadOnly = true;
            this.OffensiveRebounds.Width = 90;
            // 
            // Fouls
            // 
            this.Fouls.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Fouls.HeaderText = "Fouls";
            this.Fouls.Name = "Fouls";
            this.Fouls.ReadOnly = true;
            this.Fouls.Width = 57;
            // 
            // OpponentShotsTaken
            // 
            this.OpponentShotsTaken.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.OpponentShotsTaken.HeaderText = "Shots Taken Against";
            this.OpponentShotsTaken.Name = "OpponentShotsTaken";
            this.OpponentShotsTaken.ReadOnly = true;
            this.OpponentShotsTaken.Width = 120;
            // 
            // shotsMadeAgainst
            // 
            this.shotsMadeAgainst.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.shotsMadeAgainst.HeaderText = "Shots Made Against";
            this.shotsMadeAgainst.Name = "shotsMadeAgainst";
            this.shotsMadeAgainst.ReadOnly = true;
            this.shotsMadeAgainst.Width = 116;
            // 
            // OFGP
            // 
            this.OFGP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.OFGP.HeaderText = "OFG%";
            this.OFGP.Name = "OFGP";
            this.OFGP.ReadOnly = true;
            this.OFGP.Width = 62;
            // 
            // PlusMinus
            // 
            this.PlusMinus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.PlusMinus.HeaderText = "+/-";
            this.PlusMinus.Name = "PlusMinus";
            this.PlusMinus.ReadOnly = true;
            this.PlusMinus.Width = 46;
            // 
            // StatsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1533, 575);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "StatsForm";
            this.Text = "StatsForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button upButton;
        private System.Windows.Forms.ComboBox teamList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button downButton;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn team;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Minutes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Assists;
        private System.Windows.Forms.DataGridViewTextBoxColumn Points;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShotsTaken;
        private System.Windows.Forms.DataGridViewTextBoxColumn shotsMade;
        private System.Windows.Forms.DataGridViewTextBoxColumn fgPercent;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThreesTaken;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThreesMade;
        private System.Windows.Forms.DataGridViewTextBoxColumn Turnovers;
        private System.Windows.Forms.DataGridViewTextBoxColumn Steals;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rebounds;
        private System.Windows.Forms.DataGridViewTextBoxColumn DefensiveRebounds;
        private System.Windows.Forms.DataGridViewTextBoxColumn OffensiveRebounds;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fouls;
        private System.Windows.Forms.DataGridViewTextBoxColumn OpponentShotsTaken;
        private System.Windows.Forms.DataGridViewTextBoxColumn shotsMadeAgainst;
        private System.Windows.Forms.DataGridViewTextBoxColumn OFGP;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlusMinus;
    }
}