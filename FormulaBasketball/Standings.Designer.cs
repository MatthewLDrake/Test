namespace FormulaBasketball
{
    partial class Standings
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.conferenceOne = new FormulaBasketball.Division();
            this.divisionA = new FormulaBasketball.Division();
            this.divisionB = new FormulaBasketball.Division();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.divisionD = new FormulaBasketball.Division();
            this.divisionC = new FormulaBasketball.Division();
            this.conferenceTwo = new FormulaBasketball.Division();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.conferenceOne, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.divisionA, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.divisionB, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(597, 646);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // conferenceOne
            // 
            this.conferenceOne.Dock = System.Windows.Forms.DockStyle.Fill;
            this.conferenceOne.Location = new System.Drawing.Point(3, 3);
            this.conferenceOne.Name = "conferenceOne";
            this.tableLayoutPanel1.SetRowSpan(this.conferenceOne, 2);
            this.conferenceOne.Size = new System.Drawing.Size(292, 600);
            this.conferenceOne.TabIndex = 0;
            this.conferenceOne.DoubleClick += new System.EventHandler(this.doubleClick);
            // 
            // divisionA
            // 
            this.divisionA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.divisionA.Location = new System.Drawing.Point(301, 3);
            this.divisionA.Name = "divisionA";
            this.divisionA.Size = new System.Drawing.Size(293, 297);
            this.divisionA.TabIndex = 1;
            this.divisionA.DoubleClick += new System.EventHandler(this.doubleClick);
            // 
            // divisionB
            // 
            this.divisionB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.divisionB.Location = new System.Drawing.Point(301, 306);
            this.divisionB.Name = "divisionB";
            this.divisionB.Size = new System.Drawing.Size(293, 297);
            this.divisionB.TabIndex = 2;
            this.divisionB.DoubleClick += new System.EventHandler(this.doubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 2);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Consolas", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 606);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(591, 40);
            this.label1.TabIndex = 3;
            this.label1.Text = "Universalis Basketball Association";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.divisionD, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.divisionC, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.conferenceTwo, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(606, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(597, 646);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // divisionD
            // 
            this.divisionD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.divisionD.Location = new System.Drawing.Point(3, 306);
            this.divisionD.Name = "divisionD";
            this.divisionD.Size = new System.Drawing.Size(292, 297);
            this.divisionD.TabIndex = 4;
            this.divisionD.DoubleClick += new System.EventHandler(this.doubleClick);
            // 
            // divisionC
            // 
            this.divisionC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.divisionC.Location = new System.Drawing.Point(3, 3);
            this.divisionC.Name = "divisionC";
            this.divisionC.Size = new System.Drawing.Size(292, 297);
            this.divisionC.TabIndex = 3;
            this.divisionC.DoubleClick += new System.EventHandler(this.doubleClick);
            // 
            // conferenceTwo
            // 
            this.conferenceTwo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.conferenceTwo.Location = new System.Drawing.Point(301, 3);
            this.conferenceTwo.Name = "conferenceTwo";
            this.tableLayoutPanel2.SetRowSpan(this.conferenceTwo, 2);
            this.conferenceTwo.Size = new System.Drawing.Size(293, 600);
            this.conferenceTwo.TabIndex = 1;
            this.conferenceTwo.DoubleClick += new System.EventHandler(this.doubleClick);
            // 
            // panel1
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.panel1, 2);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 609);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(591, 34);
            this.panel1.TabIndex = 6;
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBox1.Location = new System.Drawing.Point(3, 0);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(99, 31);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "View D League";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Visible = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(74, -3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(341, 37);
            this.label2.TabIndex = 5;
            this.label2.Text = "Official Standings";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1206, 652);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // Standings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1206, 652);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Name = "Standings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Standings";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Division conferenceOne;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Division conferenceTwo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private Division divisionA;
        private Division divisionB;
        private Division divisionD;
        private Division divisionC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label2;
    }
}