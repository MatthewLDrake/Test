namespace FormulaBasketball
{
    partial class newLeague
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
            this.startSeasonButton = new System.Windows.Forms.Button();
            this.newPlayerButton = new System.Windows.Forms.Button();
            this.listOfTeams = new System.Windows.Forms.DataGridView();
            this.teamName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.threeLetter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Division = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.listOfPlayers = new System.Windows.Forms.DataGridView();
            this.playerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.team = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.playerHolder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.scrimmage = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.teamSave = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.teamLoad = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.playerLoad = new System.Windows.Forms.Button();
            this.playerSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.listOfTeams)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listOfPlayers)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // startSeasonButton
            // 
            this.startSeasonButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.startSeasonButton.Location = new System.Drawing.Point(245, 8);
            this.startSeasonButton.Name = "startSeasonButton";
            this.startSeasonButton.Size = new System.Drawing.Size(110, 23);
            this.startSeasonButton.TabIndex = 0;
            this.startSeasonButton.Text = "Start Season";
            this.startSeasonButton.UseVisualStyleBackColor = true;
            this.startSeasonButton.Click += new System.EventHandler(this.newTeamButton_Click);
            // 
            // newPlayerButton
            // 
            this.newPlayerButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.newPlayerButton.Location = new System.Drawing.Point(392, 8);
            this.newPlayerButton.Name = "newPlayerButton";
            this.newPlayerButton.Size = new System.Drawing.Size(110, 23);
            this.newPlayerButton.TabIndex = 1;
            this.newPlayerButton.Text = "Create New Player";
            this.newPlayerButton.UseVisualStyleBackColor = true;
            this.newPlayerButton.Click += new System.EventHandler(this.newPlayerButton_Click);
            // 
            // listOfTeams
            // 
            this.listOfTeams.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listOfTeams.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.teamName,
            this.threeLetter,
            this.Division});
            this.listOfTeams.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listOfTeams.Location = new System.Drawing.Point(0, 0);
            this.listOfTeams.MultiSelect = false;
            this.listOfTeams.Name = "listOfTeams";
            this.listOfTeams.ReadOnly = true;
            this.listOfTeams.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.listOfTeams.RowHeadersVisible = false;
            this.listOfTeams.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.listOfTeams.Size = new System.Drawing.Size(352, 355);
            this.listOfTeams.TabIndex = 2;
            this.listOfTeams.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.listOfTeams_CellDoubleClick);
            // 
            // teamName
            // 
            this.teamName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.teamName.HeaderText = "Team Name";
            this.teamName.Name = "teamName";
            this.teamName.ReadOnly = true;
            // 
            // threeLetter
            // 
            this.threeLetter.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.threeLetter.HeaderText = "Abbreviation";
            this.threeLetter.Name = "threeLetter";
            this.threeLetter.ReadOnly = true;
            this.threeLetter.Width = 91;
            // 
            // Division
            // 
            this.Division.HeaderText = "Division";
            this.Division.Name = "Division";
            this.Division.ReadOnly = true;
            // 
            // listOfPlayers
            // 
            this.listOfPlayers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listOfPlayers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.playerName,
            this.team,
            this.playerHolder});
            this.listOfPlayers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listOfPlayers.Location = new System.Drawing.Point(0, 0);
            this.listOfPlayers.MultiSelect = false;
            this.listOfPlayers.Name = "listOfPlayers";
            this.listOfPlayers.ReadOnly = true;
            this.listOfPlayers.RowHeadersVisible = false;
            this.listOfPlayers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.listOfPlayers.Size = new System.Drawing.Size(356, 355);
            this.listOfPlayers.TabIndex = 3;
            this.listOfPlayers.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.listOfPlayers_CellContentDoubleClick);
            // 
            // playerName
            // 
            this.playerName.HeaderText = "Player Name";
            this.playerName.Name = "playerName";
            this.playerName.ReadOnly = true;
            this.playerName.Width = 250;
            // 
            // team
            // 
            this.team.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.team.HeaderText = "Team";
            this.team.Name = "team";
            this.team.ReadOnly = true;
            // 
            // playerHolder
            // 
            this.playerHolder.HeaderText = "player";
            this.playerHolder.Name = "playerHolder";
            this.playerHolder.ReadOnly = true;
            this.playerHolder.Visible = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0008F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0008F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0008F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.9988F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.9988F));
            this.tableLayoutPanel1.Controls.Add(this.scrimmage, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.newPlayerButton, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.startSeasonButton, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 3, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(899, 401);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // scrimmage
            // 
            this.scrimmage.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.scrimmage.Location = new System.Drawing.Point(540, 8);
            this.scrimmage.Name = "scrimmage";
            this.scrimmage.Size = new System.Drawing.Size(110, 23);
            this.scrimmage.TabIndex = 4;
            this.scrimmage.Text = "Play Scrimmage";
            this.scrimmage.UseVisualStyleBackColor = true;
            this.scrimmage.Click += new System.EventHandler(this.scrimmage_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(361, 43);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(173, 355);
            this.panel1.TabIndex = 6;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(49, 259);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 43);
            this.button4.TabIndex = 8;
            this.button4.Text = "Select Team";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(49, 180);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 50);
            this.button3.TabIndex = 7;
            this.button3.Text = "Start Draft";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(49, 102);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 50);
            this.button2.TabIndex = 6;
            this.button2.Text = "Generate Players for Draft";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.Location = new System.Drawing.Point(31, 35);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 34);
            this.button1.TabIndex = 5;
            this.button1.Text = "Fill Teams with Random Players";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel2, 2);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.listOfTeams);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 43);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(352, 355);
            this.panel2.TabIndex = 7;
            // 
            // teamSave
            // 
            this.teamSave.Dock = System.Windows.Forms.DockStyle.Left;
            this.teamSave.Location = new System.Drawing.Point(0, 0);
            this.teamSave.Name = "teamSave";
            this.teamSave.Size = new System.Drawing.Size(127, 51);
            this.teamSave.TabIndex = 3;
            this.teamSave.Text = "Save Team";
            this.teamSave.UseVisualStyleBackColor = true;
            this.teamSave.Click += new System.EventHandler(this.teamSave_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.teamLoad);
            this.panel3.Controls.Add(this.teamSave);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 304);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(352, 51);
            this.panel3.TabIndex = 4;
            // 
            // teamLoad
            // 
            this.teamLoad.Dock = System.Windows.Forms.DockStyle.Right;
            this.teamLoad.Location = new System.Drawing.Point(226, 0);
            this.teamLoad.Name = "teamLoad";
            this.teamLoad.Size = new System.Drawing.Size(126, 51);
            this.teamLoad.TabIndex = 4;
            this.teamLoad.Text = "Load Team";
            this.teamLoad.UseVisualStyleBackColor = true;
            this.teamLoad.Click += new System.EventHandler(this.teamLoad_Click);
            // 
            // panel4
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel4, 2);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Controls.Add(this.listOfPlayers);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(540, 43);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(356, 355);
            this.panel4.TabIndex = 8;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.playerLoad);
            this.panel5.Controls.Add(this.playerSave);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 304);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(356, 51);
            this.panel5.TabIndex = 5;
            // 
            // playerLoad
            // 
            this.playerLoad.Dock = System.Windows.Forms.DockStyle.Right;
            this.playerLoad.Location = new System.Drawing.Point(230, 0);
            this.playerLoad.Name = "playerLoad";
            this.playerLoad.Size = new System.Drawing.Size(126, 51);
            this.playerLoad.TabIndex = 4;
            this.playerLoad.Text = "Load Player";
            this.playerLoad.UseVisualStyleBackColor = true;
            this.playerLoad.Click += new System.EventHandler(this.playerLoad_Click);
            // 
            // playerSave
            // 
            this.playerSave.Dock = System.Windows.Forms.DockStyle.Left;
            this.playerSave.Location = new System.Drawing.Point(0, 0);
            this.playerSave.Name = "playerSave";
            this.playerSave.Size = new System.Drawing.Size(127, 51);
            this.playerSave.TabIndex = 3;
            this.playerSave.Text = "Save Player";
            this.playerSave.UseVisualStyleBackColor = true;
            this.playerSave.Click += new System.EventHandler(this.playerSave_Click);
            // 
            // newLeague
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 401);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "newLeague";
            this.Text = "newLeague";
            ((System.ComponentModel.ISupportInitialize)(this.listOfTeams)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listOfPlayers)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button startSeasonButton;
        private System.Windows.Forms.Button newPlayerButton;
        private System.Windows.Forms.DataGridView listOfTeams;
        private System.Windows.Forms.DataGridViewTextBoxColumn teamName;
        private System.Windows.Forms.DataGridViewTextBoxColumn threeLetter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Division;
        private System.Windows.Forms.DataGridView listOfPlayers;
        private System.Windows.Forms.DataGridViewTextBoxColumn playerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn team;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button scrimmage;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn playerHolder;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button teamLoad;
        private System.Windows.Forms.Button teamSave;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button playerLoad;
        private System.Windows.Forms.Button playerSave;
    }
}