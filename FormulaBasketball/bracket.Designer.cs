namespace FormulaBasketball
{
    partial class bracket
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.topScore = new System.Windows.Forms.Label();
            this.bottomScore = new System.Windows.Forms.Label();
            this.firstName = new System.Windows.Forms.Label();
            this.secondName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // topScore
            // 
            this.topScore.AutoSize = true;
            this.topScore.Location = new System.Drawing.Point(18, 16);
            this.topScore.Name = "topScore";
            this.topScore.Size = new System.Drawing.Size(13, 13);
            this.topScore.TabIndex = 0;
            this.topScore.Text = "0";
            // 
            // bottomScore
            // 
            this.bottomScore.AutoSize = true;
            this.bottomScore.Location = new System.Drawing.Point(18, 68);
            this.bottomScore.Name = "bottomScore";
            this.bottomScore.Size = new System.Drawing.Size(13, 13);
            this.bottomScore.TabIndex = 1;
            this.bottomScore.Text = "0";
            // 
            // firstName
            // 
            this.firstName.AutoSize = true;
            this.firstName.Location = new System.Drawing.Point(37, 16);
            this.firstName.Name = "firstName";
            this.firstName.Size = new System.Drawing.Size(87, 13);
            this.firstName.TabIndex = 2;
            this.firstName.Text = "First Team Name";
            this.firstName.Visible = false;
            // 
            // secondName
            // 
            this.secondName.AutoSize = true;
            this.secondName.Location = new System.Drawing.Point(37, 68);
            this.secondName.Name = "secondName";
            this.secondName.Size = new System.Drawing.Size(105, 13);
            this.secondName.TabIndex = 3;
            this.secondName.Text = "Second Team Name";
            this.secondName.Visible = false;
            // 
            // bracket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.secondName);
            this.Controls.Add(this.firstName);
            this.Controls.Add(this.bottomScore);
            this.Controls.Add(this.topScore);
            this.Name = "bracket";
            this.Size = new System.Drawing.Size(227, 99);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label topScore;
        private System.Windows.Forms.Label bottomScore;
        private System.Windows.Forms.Label firstName;
        private System.Windows.Forms.Label secondName;
    }
}
