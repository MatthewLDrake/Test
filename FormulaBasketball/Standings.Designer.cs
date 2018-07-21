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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.divisionD = new FormulaBasketball.Division();
            this.divisionC = new FormulaBasketball.Division();
            this.conferenceTwo = new FormulaBasketball.Division();
            this.conferenceOne = new FormulaBasketball.Division();
            this.divisionA = new FormulaBasketball.Division();
            this.divisionB = new FormulaBasketball.Division();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
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
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(597, 618);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.divisionD, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.divisionC, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.conferenceTwo, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(606, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(597, 618);
            this.tableLayoutPanel2.TabIndex = 2;
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
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1206, 624);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // divisionD
            // 
            this.divisionD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.divisionD.Location = new System.Drawing.Point(3, 312);
            this.divisionD.Name = "divisionD";
            this.divisionD.Size = new System.Drawing.Size(292, 303);
            this.divisionD.TabIndex = 4;
            this.divisionD.DoubleClick += new System.EventHandler(this.doubleClick);
            // 
            // divisionC
            // 
            this.divisionC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.divisionC.Location = new System.Drawing.Point(3, 3);
            this.divisionC.Name = "divisionC";
            this.divisionC.Size = new System.Drawing.Size(292, 303);
            this.divisionC.TabIndex = 3;
            this.divisionC.DoubleClick += new System.EventHandler(this.doubleClick);
            // 
            // conferenceTwo
            // 
            this.conferenceTwo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.conferenceTwo.Location = new System.Drawing.Point(301, 3);
            this.conferenceTwo.Name = "conferenceTwo";
            this.tableLayoutPanel2.SetRowSpan(this.conferenceTwo, 2);
            this.conferenceTwo.Size = new System.Drawing.Size(293, 612);
            this.conferenceTwo.TabIndex = 1;
            this.conferenceTwo.DoubleClick += new System.EventHandler(this.doubleClick);
            // 
            // conferenceOne
            // 
            this.conferenceOne.Dock = System.Windows.Forms.DockStyle.Fill;
            this.conferenceOne.Location = new System.Drawing.Point(3, 3);
            this.conferenceOne.Name = "conferenceOne";
            this.tableLayoutPanel1.SetRowSpan(this.conferenceOne, 2);
            this.conferenceOne.Size = new System.Drawing.Size(292, 612);
            this.conferenceOne.TabIndex = 0;
            this.conferenceOne.DoubleClick += new System.EventHandler(this.doubleClick);
            // 
            // divisionA
            // 
            this.divisionA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.divisionA.Location = new System.Drawing.Point(301, 3);
            this.divisionA.Name = "divisionA";
            this.divisionA.Size = new System.Drawing.Size(293, 303);
            this.divisionA.TabIndex = 1;
            this.divisionA.DoubleClick += new System.EventHandler(this.doubleClick);
            // 
            // divisionB
            // 
            this.divisionB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.divisionB.Location = new System.Drawing.Point(301, 312);
            this.divisionB.Name = "divisionB";
            this.divisionB.Size = new System.Drawing.Size(293, 303);
            this.divisionB.TabIndex = 2;
            this.divisionB.DoubleClick += new System.EventHandler(this.doubleClick);
            // 
            // Standings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1206, 624);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Name = "Standings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Standings";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
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
    }
}