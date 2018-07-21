namespace FormulaBasketball
{
    partial class Form2
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
            this.options = new System.Windows.Forms.ComboBox();
            this.exitButton = new System.Windows.Forms.Button();
            this.selectGames = new System.Windows.Forms.Button();
            this.playSeason = new System.Windows.Forms.Button();
            this.doPlayoffs = new System.Windows.Forms.Button();
            this.restartSeason = new System.Windows.Forms.Button();
            this.doRound = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // options
            // 
            this.options.FormattingEnabled = true;
            this.options.Items.AddRange(new object[] {
            "Play Games Between",
            "Play Rest Of Season",
            "Change Starter",
            "Trade",
            "Exit",
            "Print",
            "Change Name",
            "Add Player",
            "Remove Player",
            "Mock Playoffs",
            "Reload",
            "Wipe Stats"});
            this.options.Location = new System.Drawing.Point(291, 26);
            this.options.Name = "options";
            this.options.Size = new System.Drawing.Size(121, 21);
            this.options.TabIndex = 0;
            this.options.Visible = false;
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(45, 172);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(180, 23);
            this.exitButton.TabIndex = 1;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.button_Click);
            // 
            // selectGames
            // 
            this.selectGames.Location = new System.Drawing.Point(45, 24);
            this.selectGames.Name = "selectGames";
            this.selectGames.Size = new System.Drawing.Size(180, 23);
            this.selectGames.TabIndex = 2;
            this.selectGames.Text = "Select Games to Play...";
            this.selectGames.UseVisualStyleBackColor = true;
            this.selectGames.Click += new System.EventHandler(this.button_Click);
            // 
            // playSeason
            // 
            this.playSeason.Location = new System.Drawing.Point(45, 75);
            this.playSeason.Name = "playSeason";
            this.playSeason.Size = new System.Drawing.Size(180, 23);
            this.playSeason.TabIndex = 3;
            this.playSeason.Text = "Play Rest of Season";
            this.playSeason.UseVisualStyleBackColor = true;
            this.playSeason.Click += new System.EventHandler(this.button_Click);
            // 
            // doPlayoffs
            // 
            this.doPlayoffs.Location = new System.Drawing.Point(45, 121);
            this.doPlayoffs.Name = "doPlayoffs";
            this.doPlayoffs.Size = new System.Drawing.Size(180, 23);
            this.doPlayoffs.TabIndex = 4;
            this.doPlayoffs.Text = "Play Entire Playoofs";
            this.doPlayoffs.UseVisualStyleBackColor = true;
            this.doPlayoffs.Click += new System.EventHandler(this.button_Click);
            // 
            // restartSeason
            // 
            this.restartSeason.Location = new System.Drawing.Point(253, 75);
            this.restartSeason.Name = "restartSeason";
            this.restartSeason.Size = new System.Drawing.Size(180, 23);
            this.restartSeason.TabIndex = 5;
            this.restartSeason.Text = "Restart Season";
            this.restartSeason.UseVisualStyleBackColor = true;
            this.restartSeason.Click += new System.EventHandler(this.button_Click);
            // 
            // doRound
            // 
            this.doRound.Location = new System.Drawing.Point(253, 121);
            this.doRound.Name = "doRound";
            this.doRound.Size = new System.Drawing.Size(180, 23);
            this.doRound.TabIndex = 6;
            this.doRound.Text = "Do Next Round";
            this.doRound.UseVisualStyleBackColor = true;
            this.doRound.Click += new System.EventHandler(this.button_Click);
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(253, 172);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(180, 23);
            this.Save.TabIndex = 7;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.button_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 230);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.doRound);
            this.Controls.Add(this.restartSeason);
            this.Controls.Add(this.doPlayoffs);
            this.Controls.Add(this.playSeason);
            this.Controls.Add(this.selectGames);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.options);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox options;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button selectGames;
        private System.Windows.Forms.Button playSeason;
        private System.Windows.Forms.Button doPlayoffs;
        private System.Windows.Forms.Button restartSeason;
        private System.Windows.Forms.Button doRound;
        private System.Windows.Forms.Button Save;
    }
}