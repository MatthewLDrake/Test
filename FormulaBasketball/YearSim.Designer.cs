namespace FormulaBasketball
{
    partial class YearSim
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
            this.seasonsPlayed = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.confirmButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.seasonsPlayed)).BeginInit();
            this.SuspendLayout();
            // 
            // seasonsPlayed
            // 
            this.seasonsPlayed.Location = new System.Drawing.Point(-1, 178);
            this.seasonsPlayed.Maximum = 100;
            this.seasonsPlayed.Minimum = 1;
            this.seasonsPlayed.Name = "seasonsPlayed";
            this.seasonsPlayed.Size = new System.Drawing.Size(582, 45);
            this.seasonsPlayed.TabIndex = 1;
            this.seasonsPlayed.Value = 1;
            this.seasonsPlayed.Scroll += new System.EventHandler(this.gamesPlayed_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(235, 249);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Current Value: 1";
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(108, 81);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(75, 23);
            this.confirmButton.TabIndex = 4;
            this.confirmButton.Text = "Confirm";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(243, 81);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 5;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(391, 81);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Exit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // YearSim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 320);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.seasonsPlayed);
            this.Name = "YearSim";
            this.Text = "YearSim";
            ((System.ComponentModel.ISupportInitialize)(this.seasonsPlayed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar seasonsPlayed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button button1;
    }
}