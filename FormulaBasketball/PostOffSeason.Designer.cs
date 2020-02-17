namespace FormulaBasketball
{
    partial class PostOffSeason
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button2 = new System.Windows.Forms.Button();
            this.resignPlayersButton = new System.Windows.Forms.Button();
            this.viewRoster = new System.Windows.Forms.Button();
            this.advanceButtons = new System.Windows.Forms.Button();
            this.scoutButton = new System.Windows.Forms.Button();
            this.viewDLeagueRoster = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.awardsButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.eventCounter = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(76, 213);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(6, 65);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(92, 17);
            this.radioButton3.TabIndex = 17;
            this.radioButton3.Tag = "19";
            this.radioButton3.Text = "Dotruga Falno";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.teamSelected);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(6, 42);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(93, 17);
            this.radioButton2.TabIndex = 16;
            this.radioButton2.Tag = "7";
            this.radioButton2.Text = "Solea Geysers";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.teamSelected);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 19);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(78, 17);
            this.radioButton1.TabIndex = 15;
            this.radioButton1.Tag = "2";
            this.radioButton1.Text = "Calto Cows";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.teamSelected);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.button2, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.resignPlayersButton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.viewRoster, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.advanceButtons, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.scoutButton, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.viewDLeagueRoster, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.loadButton, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.awardsButton, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(41, 43);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(271, 164);
            this.tableLayoutPanel1.TabIndex = 17;
            this.tableLayoutPanel1.Visible = false;
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Location = new System.Drawing.Point(138, 131);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(130, 30);
            this.button2.TabIndex = 15;
            this.button2.Text = "View Free Agents";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // resignPlayersButton
            // 
            this.resignPlayersButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resignPlayersButton.Location = new System.Drawing.Point(3, 3);
            this.resignPlayersButton.Name = "resignPlayersButton";
            this.resignPlayersButton.Size = new System.Drawing.Size(129, 26);
            this.resignPlayersButton.TabIndex = 2;
            this.resignPlayersButton.Text = "Change Depth Chart";
            this.resignPlayersButton.UseVisualStyleBackColor = true;
            this.resignPlayersButton.Click += new System.EventHandler(this.resignPlayersButton_Click);
            // 
            // viewRoster
            // 
            this.viewRoster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewRoster.Location = new System.Drawing.Point(138, 3);
            this.viewRoster.Name = "viewRoster";
            this.viewRoster.Size = new System.Drawing.Size(130, 26);
            this.viewRoster.TabIndex = 4;
            this.viewRoster.Text = "View Roster";
            this.viewRoster.UseVisualStyleBackColor = true;
            this.viewRoster.Click += new System.EventHandler(this.viewRoster_Click);
            // 
            // advanceButtons
            // 
            this.advanceButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advanceButtons.Location = new System.Drawing.Point(138, 67);
            this.advanceButtons.Name = "advanceButtons";
            this.advanceButtons.Size = new System.Drawing.Size(130, 26);
            this.advanceButtons.TabIndex = 9;
            this.advanceButtons.Text = "Save";
            this.advanceButtons.UseVisualStyleBackColor = true;
            this.advanceButtons.Click += new System.EventHandler(this.advanceButtons_Click);
            // 
            // scoutButton
            // 
            this.scoutButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scoutButton.Location = new System.Drawing.Point(3, 35);
            this.scoutButton.Name = "scoutButton";
            this.scoutButton.Size = new System.Drawing.Size(129, 26);
            this.scoutButton.TabIndex = 6;
            this.scoutButton.Text = "Draft";
            this.scoutButton.UseVisualStyleBackColor = true;
            this.scoutButton.Click += new System.EventHandler(this.scoutButton_Click);
            // 
            // viewDLeagueRoster
            // 
            this.viewDLeagueRoster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewDLeagueRoster.Location = new System.Drawing.Point(138, 35);
            this.viewDLeagueRoster.Name = "viewDLeagueRoster";
            this.viewDLeagueRoster.Size = new System.Drawing.Size(130, 26);
            this.viewDLeagueRoster.TabIndex = 5;
            this.viewDLeagueRoster.Text = "View DLeague Roster";
            this.viewDLeagueRoster.UseVisualStyleBackColor = true;
            this.viewDLeagueRoster.Click += new System.EventHandler(this.viewDLeagueRoster_Click);
            // 
            // loadButton
            // 
            this.loadButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loadButton.Location = new System.Drawing.Point(3, 99);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(129, 26);
            this.loadButton.TabIndex = 10;
            this.loadButton.Text = "Load File";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // awardsButton
            // 
            this.awardsButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.awardsButton.Location = new System.Drawing.Point(3, 67);
            this.awardsButton.Name = "awardsButton";
            this.awardsButton.Size = new System.Drawing.Size(129, 26);
            this.awardsButton.TabIndex = 8;
            this.awardsButton.Text = "Trade";
            this.awardsButton.UseVisualStyleBackColor = true;
            this.awardsButton.Click += new System.EventHandler(this.awardsButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.eventCounter);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 131);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(129, 30);
            this.panel1.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 30);
            this.button1.TabIndex = 14;
            this.button1.Text = "View League";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // eventCounter
            // 
            this.eventCounter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.eventCounter.AutoSize = true;
            this.eventCounter.BackColor = System.Drawing.Color.Red;
            this.eventCounter.ForeColor = System.Drawing.Color.White;
            this.eventCounter.Location = new System.Drawing.Point(113, 0);
            this.eventCounter.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.eventCounter.Name = "eventCounter";
            this.eventCounter.Size = new System.Drawing.Size(13, 13);
            this.eventCounter.TabIndex = 13;
            this.eventCounter.Text = "0";
            this.eventCounter.Visible = false;
            // 
            // PostOffSeason
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 357);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "PostOffSeason";
            this.Text = "PostOffSeason";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button resignPlayersButton;
        private System.Windows.Forms.Button viewRoster;
        private System.Windows.Forms.Button advanceButtons;
        private System.Windows.Forms.Button scoutButton;
        private System.Windows.Forms.Button viewDLeagueRoster;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Button awardsButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label eventCounter;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}