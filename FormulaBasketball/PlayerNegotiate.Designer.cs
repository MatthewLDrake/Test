namespace FormulaBasketball
{
    partial class PlayerNegotiate
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
            this.confirmButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.yearsNumber = new System.Windows.Forms.NumericUpDown();
            this.years = new System.Windows.Forms.Label();
            this.amountNumber = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.bonusAmount = new System.Windows.Forms.NumericUpDown();
            this.retractButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yearsNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.amountNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bonusAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(41, 199);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(75, 23);
            this.confirmButton.TabIndex = 0;
            this.confirmButton.Text = "Confirm";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(166, 199);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.yearsNumber, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.years, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.amountNumber, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.bonusAmount, 1, 2);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(41, 12);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(200, 115);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Amount:";
            // 
            // yearsNumber
            // 
            this.yearsNumber.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.yearsNumber.Location = new System.Drawing.Point(75, 9);
            this.yearsNumber.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.yearsNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.yearsNumber.Name = "yearsNumber";
            this.yearsNumber.Size = new System.Drawing.Size(120, 20);
            this.yearsNumber.TabIndex = 2;
            this.yearsNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // years
            // 
            this.years.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.years.AutoSize = true;
            this.years.Location = new System.Drawing.Point(32, 12);
            this.years.Name = "years";
            this.years.Size = new System.Drawing.Size(37, 13);
            this.years.TabIndex = 3;
            this.years.Text = "Years:";
            // 
            // amountNumber
            // 
            this.amountNumber.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.amountNumber.DecimalPlaces = 1;
            this.amountNumber.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.amountNumber.Location = new System.Drawing.Point(75, 47);
            this.amountNumber.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.amountNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.amountNumber.Name = "amountNumber";
            this.amountNumber.Size = new System.Drawing.Size(120, 20);
            this.amountNumber.TabIndex = 4;
            this.amountNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Bonus:";
            // 
            // bonusAmount
            // 
            this.bonusAmount.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.bonusAmount.DecimalPlaces = 1;
            this.bonusAmount.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.bonusAmount.Location = new System.Drawing.Point(75, 85);
            this.bonusAmount.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.bonusAmount.Name = "bonusAmount";
            this.bonusAmount.Size = new System.Drawing.Size(120, 20);
            this.bonusAmount.TabIndex = 7;
            // 
            // retractButton
            // 
            this.retractButton.Location = new System.Drawing.Point(41, 228);
            this.retractButton.Name = "retractButton";
            this.retractButton.Size = new System.Drawing.Size(200, 23);
            this.retractButton.TabIndex = 5;
            this.retractButton.Text = "Retract Previous Offer";
            this.retractButton.UseVisualStyleBackColor = true;
            this.retractButton.Visible = false;
            this.retractButton.Click += new System.EventHandler(this.retractButton_Click);
            // 
            // PlayerNegotiate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.retractButton);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.confirmButton);
            this.Name = "PlayerNegotiate";
            this.Text = "PlayerNegotiate";
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yearsNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.amountNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bonusAmount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown yearsNumber;
        private System.Windows.Forms.Label years;
        private System.Windows.Forms.NumericUpDown amountNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown bonusAmount;
        private System.Windows.Forms.Button retractButton;
    }
}