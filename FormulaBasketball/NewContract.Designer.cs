namespace FormulaBasketball
{
    partial class NewContract
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.yearsNumber = new System.Windows.Forms.NumericUpDown();
            this.years = new System.Windows.Forms.Label();
            this.amountNumber = new System.Windows.Forms.NumericUpDown();
            this.bonusAmount = new System.Windows.Forms.NumericUpDown();
            this.maxDiff = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yearsNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.amountNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bonusAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxDiff)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64F));
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.yearsNumber, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.years, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.amountNumber, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.bonusAmount, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.maxDiff, 1, 3);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(86, 12);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(279, 173);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Max Diff:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Bonus:";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Amount:";
            // 
            // yearsNumber
            // 
            this.yearsNumber.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.yearsNumber.Location = new System.Drawing.Point(103, 12);
            this.yearsNumber.Maximum = new decimal(new int[] {
            20,
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
            this.years.Location = new System.Drawing.Point(60, 16);
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
            this.amountNumber.Location = new System.Drawing.Point(103, 57);
            this.amountNumber.Maximum = new decimal(new int[] {
            30,
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
            // bonusAmount
            // 
            this.bonusAmount.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.bonusAmount.DecimalPlaces = 1;
            this.bonusAmount.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.bonusAmount.Location = new System.Drawing.Point(103, 104);
            this.bonusAmount.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.bonusAmount.Name = "bonusAmount";
            this.bonusAmount.Size = new System.Drawing.Size(120, 20);
            this.bonusAmount.TabIndex = 8;
            // 
            // maxDiff
            // 
            this.maxDiff.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.maxDiff.DecimalPlaces = 2;
            this.maxDiff.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.maxDiff.Location = new System.Drawing.Point(103, 146);
            this.maxDiff.Maximum = new decimal(new int[] {
            33,
            0,
            0,
            131072});
            this.maxDiff.Minimum = new decimal(new int[] {
            33,
            0,
            0,
            -2147352576});
            this.maxDiff.Name = "maxDiff";
            this.maxDiff.Size = new System.Drawing.Size(120, 20);
            this.maxDiff.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(189, 237);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(189, 191);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Promises";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // NewContract
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 325);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "NewContract";
            this.Text = "NewContract";
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yearsNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.amountNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bonusAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxDiff)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown yearsNumber;
        private System.Windows.Forms.Label years;
        private System.Windows.Forms.NumericUpDown amountNumber;
        private System.Windows.Forms.NumericUpDown bonusAmount;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown maxDiff;
    }
}