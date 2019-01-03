namespace FormulaBasketball
{
    partial class OfferedTrade
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
            this.teamOneLabel = new System.Windows.Forms.Label();
            this.teamTwoLabel = new System.Windows.Forms.Label();
            this.teamOneGrid = new System.Windows.Forms.DataGridView();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Overall = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Potential = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.capHit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Obj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.teamTwoGrid = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.acceptButton = new System.Windows.Forms.Button();
            this.negotiateButton = new System.Windows.Forms.Button();
            this.declineButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.teamOneGrid)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teamTwoGrid)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // teamOneLabel
            // 
            this.teamOneLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.teamOneLabel.AutoSize = true;
            this.teamOneLabel.Location = new System.Drawing.Point(283, 13);
            this.teamOneLabel.Name = "teamOneLabel";
            this.teamOneLabel.Size = new System.Drawing.Size(112, 25);
            this.teamOneLabel.TabIndex = 0;
            this.teamOneLabel.Text = "Team One";
            // 
            // teamTwoLabel
            // 
            this.teamTwoLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.teamTwoLabel.AutoSize = true;
            this.teamTwoLabel.Location = new System.Drawing.Point(963, 13);
            this.teamTwoLabel.Name = "teamTwoLabel";
            this.teamTwoLabel.Size = new System.Drawing.Size(112, 25);
            this.teamTwoLabel.TabIndex = 1;
            this.teamTwoLabel.Text = "Team Two";
            // 
            // teamOneGrid
            // 
            this.teamOneGrid.AllowUserToAddRows = false;
            this.teamOneGrid.AllowUserToDeleteRows = false;
            this.teamOneGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.teamOneGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.Overall,
            this.Potential,
            this.capHit,
            this.Obj});
            this.teamOneGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.teamOneGrid.Location = new System.Drawing.Point(6, 57);
            this.teamOneGrid.Margin = new System.Windows.Forms.Padding(6);
            this.teamOneGrid.MultiSelect = false;
            this.teamOneGrid.Name = "teamOneGrid";
            this.teamOneGrid.RowHeadersVisible = false;
            this.teamOneGrid.Size = new System.Drawing.Size(667, 350);
            this.teamOneGrid.TabIndex = 2;
            // 
            // name
            // 
            this.name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.name.FillWeight = 200F;
            this.name.HeaderText = "Player Name";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // Overall
            // 
            this.Overall.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Overall.HeaderText = "Overall";
            this.Overall.Name = "Overall";
            this.Overall.ReadOnly = true;
            this.Overall.Width = 125;
            // 
            // Potential
            // 
            this.Potential.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Potential.HeaderText = "Potential";
            this.Potential.Name = "Potential";
            this.Potential.ReadOnly = true;
            this.Potential.Width = 141;
            // 
            // capHit
            // 
            this.capHit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.capHit.HeaderText = "Cap Hit";
            this.capHit.Name = "capHit";
            this.capHit.ReadOnly = true;
            this.capHit.Width = 96;
            // 
            // Obj
            // 
            this.Obj.HeaderText = "Object";
            this.Obj.Name = "Obj";
            this.Obj.Visible = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.teamTwoGrid, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.teamTwoLabel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.teamOneGrid, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.teamOneLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1359, 518);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // teamTwoGrid
            // 
            this.teamTwoGrid.AllowUserToAddRows = false;
            this.teamTwoGrid.AllowUserToDeleteRows = false;
            this.teamTwoGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.teamTwoGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.teamTwoGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.teamTwoGrid.Location = new System.Drawing.Point(685, 57);
            this.teamTwoGrid.Margin = new System.Windows.Forms.Padding(6);
            this.teamTwoGrid.MultiSelect = false;
            this.teamTwoGrid.Name = "teamTwoGrid";
            this.teamTwoGrid.RowHeadersVisible = false;
            this.teamTwoGrid.Size = new System.Drawing.Size(668, 350);
            this.teamTwoGrid.TabIndex = 3;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.FillWeight = 200F;
            this.dataGridViewTextBoxColumn1.HeaderText = "Player Name";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn2.HeaderText = "Overall";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 125;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn3.HeaderText = "Potential";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 141;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn4.HeaderText = "Cap Hit";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 96;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Object";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Visible = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 2);
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Controls.Add(this.declineButton, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.negotiateButton, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.acceptButton, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 416);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1353, 99);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // acceptButton
            // 
            this.acceptButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.acceptButton.Location = new System.Drawing.Point(296, 21);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(151, 57);
            this.acceptButton.TabIndex = 0;
            this.acceptButton.Text = "Accept";
            this.acceptButton.UseVisualStyleBackColor = true;
            this.acceptButton.Click += new System.EventHandler(this.acceptButton_Click);
            // 
            // negotiateButton
            // 
            this.negotiateButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.negotiateButton.Location = new System.Drawing.Point(599, 21);
            this.negotiateButton.Name = "negotiateButton";
            this.negotiateButton.Size = new System.Drawing.Size(151, 57);
            this.negotiateButton.TabIndex = 1;
            this.negotiateButton.Text = "Negotiate";
            this.negotiateButton.UseVisualStyleBackColor = true;
            this.negotiateButton.Click += new System.EventHandler(this.negotiateButton_Click);
            // 
            // declineButton
            // 
            this.declineButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.declineButton.Location = new System.Drawing.Point(903, 21);
            this.declineButton.Name = "declineButton";
            this.declineButton.Size = new System.Drawing.Size(151, 57);
            this.declineButton.TabIndex = 2;
            this.declineButton.Text = "Decline";
            this.declineButton.UseVisualStyleBackColor = true;
            this.declineButton.Click += new System.EventHandler(this.declineButton_Click);
            // 
            // OfferedTrade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1359, 518);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "OfferedTrade";
            this.Text = "OfferedTrade";
            ((System.ComponentModel.ISupportInitialize)(this.teamOneGrid)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teamTwoGrid)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label teamOneLabel;
        private System.Windows.Forms.Label teamTwoLabel;
        private System.Windows.Forms.DataGridView teamOneGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Overall;
        private System.Windows.Forms.DataGridViewTextBoxColumn Potential;
        private System.Windows.Forms.DataGridViewTextBoxColumn capHit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Obj;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView teamTwoGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button declineButton;
        private System.Windows.Forms.Button negotiateButton;
        private System.Windows.Forms.Button acceptButton;
    }
}