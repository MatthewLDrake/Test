namespace FormulaBasketball
{
    partial class Menu
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
            this.freeAgencyButton = new System.Windows.Forms.Button();
            this.tradeButton = new System.Windows.Forms.Button();
            this.resignPlayersButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.viewRoster = new System.Windows.Forms.Button();
            this.viewDLeagueRoster = new System.Windows.Forms.Button();
            this.scoutButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.awardsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // freeAgencyButton
            // 
            this.freeAgencyButton.Location = new System.Drawing.Point(29, 273);
            this.freeAgencyButton.Name = "freeAgencyButton";
            this.freeAgencyButton.Size = new System.Drawing.Size(128, 23);
            this.freeAgencyButton.TabIndex = 0;
            this.freeAgencyButton.Text = "Free Agency";
            this.freeAgencyButton.UseVisualStyleBackColor = true;
            this.freeAgencyButton.Click += new System.EventHandler(this.freeAgencyButton_Click);
            // 
            // tradeButton
            // 
            this.tradeButton.Location = new System.Drawing.Point(163, 227);
            this.tradeButton.Name = "tradeButton";
            this.tradeButton.Size = new System.Drawing.Size(128, 23);
            this.tradeButton.TabIndex = 1;
            this.tradeButton.Text = "Trade";
            this.tradeButton.UseVisualStyleBackColor = true;
            this.tradeButton.Click += new System.EventHandler(this.tradeButton_Click);
            // 
            // resignPlayersButton
            // 
            this.resignPlayersButton.Location = new System.Drawing.Point(29, 21);
            this.resignPlayersButton.Name = "resignPlayersButton";
            this.resignPlayersButton.Size = new System.Drawing.Size(128, 23);
            this.resignPlayersButton.TabIndex = 2;
            this.resignPlayersButton.Text = "Resign Players";
            this.resignPlayersButton.UseVisualStyleBackColor = true;
            this.resignPlayersButton.Click += new System.EventHandler(this.resignPlayersButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(163, 273);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(128, 23);
            this.exitButton.TabIndex = 3;
            this.exitButton.Text = "Save";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // viewRoster
            // 
            this.viewRoster.Location = new System.Drawing.Point(163, 21);
            this.viewRoster.Name = "viewRoster";
            this.viewRoster.Size = new System.Drawing.Size(128, 23);
            this.viewRoster.TabIndex = 4;
            this.viewRoster.Text = "View Roster";
            this.viewRoster.UseVisualStyleBackColor = true;
            this.viewRoster.Click += new System.EventHandler(this.viewRoster_Click);
            // 
            // viewDLeagueRoster
            // 
            this.viewDLeagueRoster.Location = new System.Drawing.Point(163, 50);
            this.viewDLeagueRoster.Name = "viewDLeagueRoster";
            this.viewDLeagueRoster.Size = new System.Drawing.Size(128, 23);
            this.viewDLeagueRoster.TabIndex = 5;
            this.viewDLeagueRoster.Text = "View DLeague Roster";
            this.viewDLeagueRoster.UseVisualStyleBackColor = true;
            this.viewDLeagueRoster.Click += new System.EventHandler(this.viewDLeagueRoster_Click);
            // 
            // scoutButton
            // 
            this.scoutButton.Location = new System.Drawing.Point(29, 50);
            this.scoutButton.Name = "scoutButton";
            this.scoutButton.Size = new System.Drawing.Size(128, 23);
            this.scoutButton.TabIndex = 6;
            this.scoutButton.Text = "Scout";
            this.scoutButton.UseVisualStyleBackColor = true;
            this.scoutButton.Click += new System.EventHandler(this.scoutButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(29, 227);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Change Depth Chart";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // awardsButton
            // 
            this.awardsButton.Location = new System.Drawing.Point(29, 79);
            this.awardsButton.Name = "awardsButton";
            this.awardsButton.Size = new System.Drawing.Size(128, 23);
            this.awardsButton.TabIndex = 8;
            this.awardsButton.Text = "Awards Voting";
            this.awardsButton.UseVisualStyleBackColor = true;
            this.awardsButton.Click += new System.EventHandler(this.awardsButton_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 308);
            this.Controls.Add(this.awardsButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.scoutButton);
            this.Controls.Add(this.viewDLeagueRoster);
            this.Controls.Add(this.viewRoster);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.resignPlayersButton);
            this.Controls.Add(this.tradeButton);
            this.Controls.Add(this.freeAgencyButton);
            this.Name = "Menu";
            this.Text = "Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button freeAgencyButton;
        private System.Windows.Forms.Button tradeButton;
        private System.Windows.Forms.Button resignPlayersButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button viewRoster;
        private System.Windows.Forms.Button viewDLeagueRoster;
        private System.Windows.Forms.Button scoutButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button awardsButton;
    }
}