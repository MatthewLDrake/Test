namespace FormulaBasketball
{
    partial class DepthChart
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
            this.depthChartGrid = new System.Windows.Forms.DataGridView();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.OtherName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Overall = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Potential = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Age = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ratings = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Stats = new System.Windows.Forms.DataGridViewButtonColumn();
            this.PlayerObject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.swapButton = new System.Windows.Forms.Button();
            this.upButton = new System.Windows.Forms.Button();
            this.downButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.confirmButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.depthChartGrid)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // depthChartGrid
            // 
            this.depthChartGrid.AllowUserToAddRows = false;
            this.depthChartGrid.AllowUserToDeleteRows = false;
            this.depthChartGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.depthChartGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OtherName,
            this.Overall,
            this.Potential,
            this.Age,
            this.Ratings,
            this.Stats,
            this.PlayerObject});
            this.tableLayoutPanel1.SetColumnSpan(this.depthChartGrid, 3);
            this.depthChartGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.depthChartGrid.Location = new System.Drawing.Point(7, 38);
            this.depthChartGrid.Margin = new System.Windows.Forms.Padding(7);
            this.depthChartGrid.Name = "depthChartGrid";
            this.depthChartGrid.RowHeadersVisible = false;
            this.depthChartGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.depthChartGrid.Size = new System.Drawing.Size(398, 133);
            this.depthChartGrid.TabIndex = 0;
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.tableLayoutPanel1.SetColumnSpan(this.comboBox1, 3);
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Centers",
            "Power Forwards",
            "Small Forwards",
            "Shooting Guards",
            "Point Guards"});
            this.comboBox1.Location = new System.Drawing.Point(288, 5);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.depthChartGrid, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.downButton, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.confirmButton, 2, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(412, 211);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // OtherName
            // 
            this.OtherName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.OtherName.HeaderText = "Name";
            this.OtherName.Name = "OtherName";
            this.OtherName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Overall
            // 
            this.Overall.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Overall.HeaderText = "Overall";
            this.Overall.Name = "Overall";
            this.Overall.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Overall.Width = 46;
            // 
            // Potential
            // 
            this.Potential.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Potential.HeaderText = "Potential";
            this.Potential.Name = "Potential";
            this.Potential.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Potential.Width = 54;
            // 
            // Age
            // 
            this.Age.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Age.HeaderText = "Age";
            this.Age.Name = "Age";
            this.Age.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Age.Width = 32;
            // 
            // Ratings
            // 
            this.Ratings.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Ratings.HeaderText = "Ratings";
            this.Ratings.Name = "Ratings";
            this.Ratings.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Ratings.Width = 49;
            // 
            // Stats
            // 
            this.Stats.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Stats.HeaderText = "Stats";
            this.Stats.Name = "Stats";
            this.Stats.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Stats.Width = 37;
            // 
            // PlayerObject
            // 
            this.PlayerObject.HeaderText = "PlayerObject";
            this.PlayerObject.Name = "PlayerObject";
            this.PlayerObject.Visible = false;
            // 
            // swapButton
            // 
            this.swapButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.swapButton.Location = new System.Drawing.Point(55, 2);
            this.swapButton.Margin = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.swapButton.Name = "swapButton";
            this.swapButton.Size = new System.Drawing.Size(75, 23);
            this.swapButton.TabIndex = 7;
            this.swapButton.Text = "Swap";
            this.swapButton.UseVisualStyleBackColor = true;
            this.swapButton.Click += new System.EventHandler(this.swapButton_Click);
            // 
            // upButton
            // 
            this.upButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.upButton.Location = new System.Drawing.Point(140, 2);
            this.upButton.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.upButton.Name = "upButton";
            this.upButton.Size = new System.Drawing.Size(60, 23);
            this.upButton.TabIndex = 6;
            this.upButton.Text = "▲";
            this.upButton.UseVisualStyleBackColor = true;
            this.upButton.Click += new System.EventHandler(this.upButton_Click);
            // 
            // downButton
            // 
            this.downButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.downButton.Location = new System.Drawing.Point(209, 183);
            this.downButton.Name = "downButton";
            this.downButton.Size = new System.Drawing.Size(60, 23);
            this.downButton.TabIndex = 5;
            this.downButton.Text = "▼";
            this.downButton.UseVisualStyleBackColor = true;
            this.downButton.Click += new System.EventHandler(this.downButton_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.upButton, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.swapButton, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 181);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(200, 27);
            this.tableLayoutPanel2.TabIndex = 8;
            // 
            // confirmButton
            // 
            this.confirmButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.confirmButton.Location = new System.Drawing.Point(323, 183);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(75, 23);
            this.confirmButton.TabIndex = 9;
            this.confirmButton.Text = "Confirm";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // DepthChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 211);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "DepthChart";
            this.Text = "DepthChart";
            ((System.ComponentModel.ISupportInitialize)(this.depthChartGrid)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView depthChartGrid;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn OtherName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Overall;
        private System.Windows.Forms.DataGridViewTextBoxColumn Potential;
        private System.Windows.Forms.DataGridViewTextBoxColumn Age;
        private System.Windows.Forms.DataGridViewButtonColumn Ratings;
        private System.Windows.Forms.DataGridViewButtonColumn Stats;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlayerObject;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button upButton;
        private System.Windows.Forms.Button swapButton;
        private System.Windows.Forms.Button downButton;
        private System.Windows.Forms.Button confirmButton;
    }
}