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
            this.resignPlayersButton = new System.Windows.Forms.Button();
            this.viewRoster = new System.Windows.Forms.Button();
            this.viewDLeagueRoster = new System.Windows.Forms.Button();
            this.scoutButton = new System.Windows.Forms.Button();
            this.awardsButton = new System.Windows.Forms.Button();
            this.advanceButtons = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // resignPlayersButton
            // 
            this.resignPlayersButton.Location = new System.Drawing.Point(58, 40);
            this.resignPlayersButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.resignPlayersButton.Name = "resignPlayersButton";
            this.resignPlayersButton.Size = new System.Drawing.Size(256, 44);
            this.resignPlayersButton.TabIndex = 2;
            this.resignPlayersButton.Text = "Resign Players";
            this.resignPlayersButton.UseVisualStyleBackColor = true;
            this.resignPlayersButton.Click += new System.EventHandler(this.resignPlayersButton_Click);
            // 
            // viewRoster
            // 
            this.viewRoster.Location = new System.Drawing.Point(326, 40);
            this.viewRoster.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.viewRoster.Name = "viewRoster";
            this.viewRoster.Size = new System.Drawing.Size(256, 44);
            this.viewRoster.TabIndex = 4;
            this.viewRoster.Text = "View Roster";
            this.viewRoster.UseVisualStyleBackColor = true;
            this.viewRoster.Click += new System.EventHandler(this.viewRoster_Click);
            // 
            // viewDLeagueRoster
            // 
            this.viewDLeagueRoster.Location = new System.Drawing.Point(326, 96);
            this.viewDLeagueRoster.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.viewDLeagueRoster.Name = "viewDLeagueRoster";
            this.viewDLeagueRoster.Size = new System.Drawing.Size(256, 44);
            this.viewDLeagueRoster.TabIndex = 5;
            this.viewDLeagueRoster.Text = "View DLeague Roster";
            this.viewDLeagueRoster.UseVisualStyleBackColor = true;
            this.viewDLeagueRoster.Click += new System.EventHandler(this.viewDLeagueRoster_Click);
            // 
            // scoutButton
            // 
            this.scoutButton.Location = new System.Drawing.Point(58, 96);
            this.scoutButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.scoutButton.Name = "scoutButton";
            this.scoutButton.Size = new System.Drawing.Size(256, 44);
            this.scoutButton.TabIndex = 6;
            this.scoutButton.Text = "Scout";
            this.scoutButton.UseVisualStyleBackColor = true;
            this.scoutButton.Click += new System.EventHandler(this.scoutButton_Click);
            // 
            // awardsButton
            // 
            this.awardsButton.Location = new System.Drawing.Point(58, 152);
            this.awardsButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.awardsButton.Name = "awardsButton";
            this.awardsButton.Size = new System.Drawing.Size(256, 44);
            this.awardsButton.TabIndex = 8;
            this.awardsButton.Text = "Awards Voting";
            this.awardsButton.UseVisualStyleBackColor = true;
            this.awardsButton.Click += new System.EventHandler(this.awardsButton_Click);
            // 
            // advanceButtons
            // 
            this.advanceButtons.Location = new System.Drawing.Point(326, 152);
            this.advanceButtons.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.advanceButtons.Name = "advanceButtons";
            this.advanceButtons.Size = new System.Drawing.Size(256, 44);
            this.advanceButtons.TabIndex = 9;
            this.advanceButtons.Text = "Advance";
            this.advanceButtons.UseVisualStyleBackColor = true;
            this.advanceButtons.Click += new System.EventHandler(this.button2_Click);
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(58, 208);
            this.loadButton.Margin = new System.Windows.Forms.Padding(6);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(256, 44);
            this.loadButton.TabIndex = 10;
            this.loadButton.Text = "Load File";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 592);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.advanceButtons);
            this.Controls.Add(this.awardsButton);
            this.Controls.Add(this.scoutButton);
            this.Controls.Add(this.viewDLeagueRoster);
            this.Controls.Add(this.viewRoster);
            this.Controls.Add(this.resignPlayersButton);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "Menu";
            this.Text = "Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button resignPlayersButton;
        private System.Windows.Forms.Button viewRoster;
        private System.Windows.Forms.Button viewDLeagueRoster;
        private System.Windows.Forms.Button scoutButton;
        private System.Windows.Forms.Button awardsButton;
        private System.Windows.Forms.Button advanceButtons;
        private System.Windows.Forms.Button loadButton;
    }
}