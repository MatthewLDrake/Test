namespace FormulaBasketball
{
    partial class soloScreen
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
            this.division = new FormulaBasketball.Standings_Division();
            this.SuspendLayout();
            // 
            // division
            // 
            this.division.Dock = System.Windows.Forms.DockStyle.Fill;
            this.division.Location = new System.Drawing.Point(0, 0);
            this.division.Name = "division";
            this.division.Size = new System.Drawing.Size(854, 368);
            this.division.TabIndex = 0;
            // 
            // soloScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 368);
            this.Controls.Add(this.division);
            this.Name = "soloScreen";
            this.Text = "soloScreen";
            this.ResumeLayout(false);

        }

        #endregion

        private Standings_Division division;
    }
}