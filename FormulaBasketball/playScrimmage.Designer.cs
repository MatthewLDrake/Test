namespace FormulaBasketball
{
    partial class playScrimmage
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
            this.playGame = new System.Windows.Forms.Button();
            this.teamOneName = new System.Windows.Forms.Label();
            this.teamTwoName = new System.Windows.Forms.Label();
            this.playQuarter = new System.Windows.Forms.Button();
            this.teamOneScore = new System.Windows.Forms.Label();
            this.teamTwoScore = new System.Windows.Forms.Label();
            this.quarterNum = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // playGame
            // 
            this.playGame.Location = new System.Drawing.Point(172, 47);
            this.playGame.Name = "playGame";
            this.playGame.Size = new System.Drawing.Size(75, 23);
            this.playGame.TabIndex = 0;
            this.playGame.Text = "Play Game";
            this.playGame.UseVisualStyleBackColor = true;
            this.playGame.Click += new System.EventHandler(this.playGame_Click);
            // 
            // teamOneName
            // 
            this.teamOneName.AutoSize = true;
            this.teamOneName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.teamOneName.Location = new System.Drawing.Point(139, 105);
            this.teamOneName.Name = "teamOneName";
            this.teamOneName.Size = new System.Drawing.Size(157, 24);
            this.teamOneName.TabIndex = 1;
            this.teamOneName.Text = "Team One Name";
            // 
            // teamTwoName
            // 
            this.teamTwoName.AutoSize = true;
            this.teamTwoName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.teamTwoName.Location = new System.Drawing.Point(518, 105);
            this.teamTwoName.Name = "teamTwoName";
            this.teamTwoName.Size = new System.Drawing.Size(157, 24);
            this.teamTwoName.TabIndex = 2;
            this.teamTwoName.Text = "Team Two Name";
            // 
            // playQuarter
            // 
            this.playQuarter.Location = new System.Drawing.Point(553, 47);
            this.playQuarter.Name = "playQuarter";
            this.playQuarter.Size = new System.Drawing.Size(75, 23);
            this.playQuarter.TabIndex = 3;
            this.playQuarter.Text = "Play Quarter";
            this.playQuarter.UseVisualStyleBackColor = true;
            this.playQuarter.Click += new System.EventHandler(this.playQuarter_Click);
            // 
            // teamOneScore
            // 
            this.teamOneScore.AutoSize = true;
            this.teamOneScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.teamOneScore.Location = new System.Drawing.Point(187, 164);
            this.teamOneScore.Name = "teamOneScore";
            this.teamOneScore.Size = new System.Drawing.Size(40, 24);
            this.teamOneScore.TabIndex = 4;
            this.teamOneScore.Text = "000";
            // 
            // teamTwoScore
            // 
            this.teamTwoScore.AutoSize = true;
            this.teamTwoScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.teamTwoScore.Location = new System.Drawing.Point(574, 164);
            this.teamTwoScore.Name = "teamTwoScore";
            this.teamTwoScore.Size = new System.Drawing.Size(40, 24);
            this.teamTwoScore.TabIndex = 5;
            this.teamTwoScore.Text = "000";
            // 
            // quarterNum
            // 
            this.quarterNum.AutoSize = true;
            this.quarterNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quarterNum.Location = new System.Drawing.Point(381, 105);
            this.quarterNum.Name = "quarterNum";
            this.quarterNum.Size = new System.Drawing.Size(35, 24);
            this.quarterNum.TabIndex = 6;
            this.quarterNum.Text = "Q1";
            // 
            // playScrimmage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 426);
            this.Controls.Add(this.quarterNum);
            this.Controls.Add(this.teamTwoScore);
            this.Controls.Add(this.teamOneScore);
            this.Controls.Add(this.playQuarter);
            this.Controls.Add(this.teamTwoName);
            this.Controls.Add(this.teamOneName);
            this.Controls.Add(this.playGame);
            this.Name = "playScrimmage";
            this.Text = "playScrimmage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button playGame;
        private System.Windows.Forms.Label teamOneName;
        private System.Windows.Forms.Label teamTwoName;
        private System.Windows.Forms.Button playQuarter;
        private System.Windows.Forms.Label teamOneScore;
        private System.Windows.Forms.Label teamTwoScore;
        private System.Windows.Forms.Label quarterNum;
    }
}