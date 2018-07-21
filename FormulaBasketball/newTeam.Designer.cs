namespace FormulaBasketball
{
    partial class newTeam
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.divisionA = new System.Windows.Forms.RadioButton();
            this.divisionB = new System.Windows.Forms.RadioButton();
            this.divisionC = new System.Windows.Forms.RadioButton();
            this.divisionD = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.threeLetters = new System.Windows.Forms.TextBox();
            this.name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.submitButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.divisionD);
            this.panel1.Controls.Add(this.divisionC);
            this.panel1.Controls.Add(this.divisionB);
            this.panel1.Controls.Add(this.divisionA);
            this.panel1.Location = new System.Drawing.Point(450, 69);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 100);
            this.panel1.TabIndex = 1;
            // 
            // divisionA
            // 
            this.divisionA.AutoSize = true;
            this.divisionA.Checked = true;
            this.divisionA.Location = new System.Drawing.Point(50, 4);
            this.divisionA.Name = "divisionA";
            this.divisionA.Size = new System.Drawing.Size(72, 17);
            this.divisionA.TabIndex = 0;
            this.divisionA.TabStop = true;
            this.divisionA.Text = "Division A";
            this.divisionA.UseVisualStyleBackColor = true;
            // 
            // divisionB
            // 
            this.divisionB.AutoSize = true;
            this.divisionB.Location = new System.Drawing.Point(50, 28);
            this.divisionB.Name = "divisionB";
            this.divisionB.Size = new System.Drawing.Size(72, 17);
            this.divisionB.TabIndex = 1;
            this.divisionB.Text = "Division B";
            this.divisionB.UseVisualStyleBackColor = true;
            // 
            // divisionC
            // 
            this.divisionC.AutoSize = true;
            this.divisionC.Location = new System.Drawing.Point(50, 52);
            this.divisionC.Name = "divisionC";
            this.divisionC.Size = new System.Drawing.Size(72, 17);
            this.divisionC.TabIndex = 2;
            this.divisionC.Text = "Division C";
            this.divisionC.UseVisualStyleBackColor = true;
            // 
            // divisionD
            // 
            this.divisionD.AutoSize = true;
            this.divisionD.Location = new System.Drawing.Point(50, 75);
            this.divisionD.Name = "divisionD";
            this.divisionD.Size = new System.Drawing.Size(73, 17);
            this.divisionD.TabIndex = 3;
            this.divisionD.Text = "Division D";
            this.divisionD.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(80, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Team Name: ";
            // 
            // threeLetters
            // 
            this.threeLetters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.threeLetters.Location = new System.Drawing.Point(157, 296);
            this.threeLetters.MaxLength = 3;
            this.threeLetters.Name = "threeLetters";
            this.threeLetters.Size = new System.Drawing.Size(149, 20);
            this.threeLetters.TabIndex = 1;
            // 
            // name
            // 
            this.name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.name.Location = new System.Drawing.Point(157, 92);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(149, 20);
            this.name.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 300);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Three Letter Abbreviation:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.name, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.threeLetters, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(309, 409);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(509, 280);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(75, 23);
            this.submitButton.TabIndex = 14;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // newTeam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 409);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Name = "newTeam";
            this.Text = "newTeam";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton divisionD;
        private System.Windows.Forms.RadioButton divisionC;
        private System.Windows.Forms.RadioButton divisionB;
        private System.Windows.Forms.RadioButton divisionA;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox threeLetters;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button submitButton;
    }
}