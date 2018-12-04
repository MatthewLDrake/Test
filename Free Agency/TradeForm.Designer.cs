namespace Free_Agency
{
    partial class TradeForm
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
            this.mainTeamGrid = new System.Windows.Forms.DataGridView();
            this.teamList = new System.Windows.Forms.ComboBox();
            this.upButton = new System.Windows.Forms.Button();
            this.downButton = new System.Windows.Forms.Button();
            this.Trade = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Overall = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Potential = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.capHit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.otherTeamGrid = new System.Windows.Forms.DataGridView();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainTeamTradeInfo = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.otherTeamTradeInfo = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.mainTeamGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.otherTeamGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainTeamTradeInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.otherTeamTradeInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // mainTeamGrid
            // 
            this.mainTeamGrid.AllowUserToAddRows = false;
            this.mainTeamGrid.AllowUserToDeleteRows = false;
            this.mainTeamGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mainTeamGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Trade,
            this.name,
            this.Overall,
            this.Potential,
            this.capHit});
            this.mainTeamGrid.Location = new System.Drawing.Point(12, 54);
            this.mainTeamGrid.MultiSelect = false;
            this.mainTeamGrid.Name = "mainTeamGrid";
            this.mainTeamGrid.RowHeadersVisible = false;
            this.mainTeamGrid.Size = new System.Drawing.Size(358, 160);
            this.mainTeamGrid.TabIndex = 0;
            this.mainTeamGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.mainTeamGrid_CellContentClick);
            // 
            // teamList
            // 
            this.teamList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.teamList.FormattingEnabled = true;
            this.teamList.Location = new System.Drawing.Point(422, 229);
            this.teamList.Name = "teamList";
            this.teamList.Size = new System.Drawing.Size(164, 21);
            this.teamList.TabIndex = 2;
            this.teamList.SelectedIndexChanged += new System.EventHandler(this.teamList_SelectedIndexChanged);
            // 
            // upButton
            // 
            this.upButton.Location = new System.Drawing.Point(356, 227);
            this.upButton.Name = "upButton";
            this.upButton.Size = new System.Drawing.Size(60, 23);
            this.upButton.TabIndex = 3;
            this.upButton.Text = "▲";
            this.upButton.UseVisualStyleBackColor = true;
            this.upButton.Click += new System.EventHandler(this.upButton_Click);
            // 
            // downButton
            // 
            this.downButton.Location = new System.Drawing.Point(592, 227);
            this.downButton.Name = "downButton";
            this.downButton.Size = new System.Drawing.Size(60, 23);
            this.downButton.TabIndex = 4;
            this.downButton.Text = "▼";
            this.downButton.UseVisualStyleBackColor = true;
            this.downButton.Click += new System.EventHandler(this.downButton_Click);
            // 
            // Trade
            // 
            this.Trade.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Trade.FillWeight = 20F;
            this.Trade.HeaderText = "Trade";
            this.Trade.Name = "Trade";
            this.Trade.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Trade.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Trade.Width = 60;
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
            this.Overall.Width = 65;
            // 
            // Potential
            // 
            this.Potential.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Potential.HeaderText = "Potential";
            this.Potential.Name = "Potential";
            this.Potential.ReadOnly = true;
            this.Potential.Width = 73;
            // 
            // capHit
            // 
            this.capHit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.capHit.HeaderText = "Cap Hit";
            this.capHit.Name = "capHit";
            this.capHit.ReadOnly = true;
            this.capHit.Width = 67;
            // 
            // otherTeamGrid
            // 
            this.otherTeamGrid.AllowUserToAddRows = false;
            this.otherTeamGrid.AllowUserToDeleteRows = false;
            this.otherTeamGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.otherTeamGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn1,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.otherTeamGrid.Location = new System.Drawing.Point(376, 54);
            this.otherTeamGrid.MultiSelect = false;
            this.otherTeamGrid.Name = "otherTeamGrid";
            this.otherTeamGrid.RowHeadersVisible = false;
            this.otherTeamGrid.Size = new System.Drawing.Size(384, 160);
            this.otherTeamGrid.TabIndex = 5;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewCheckBoxColumn1.FillWeight = 20F;
            this.dataGridViewCheckBoxColumn1.HeaderText = "Trade";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCheckBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewCheckBoxColumn1.Width = 60;
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
            this.dataGridViewTextBoxColumn2.Width = 65;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn3.HeaderText = "Potential";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 73;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn4.HeaderText = "Cap Hit";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 51;
            // 
            // mainTeamTradeInfo
            // 
            this.mainTeamTradeInfo.AllowUserToAddRows = false;
            this.mainTeamTradeInfo.AllowUserToDeleteRows = false;
            this.mainTeamTradeInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mainTeamTradeInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5});
            this.mainTeamTradeInfo.Location = new System.Drawing.Point(85, 267);
            this.mainTeamTradeInfo.MultiSelect = false;
            this.mainTeamTradeInfo.Name = "mainTeamTradeInfo";
            this.mainTeamTradeInfo.RowHeadersVisible = false;
            this.mainTeamTradeInfo.Size = new System.Drawing.Size(237, 143);
            this.mainTeamTradeInfo.TabIndex = 6;
            this.mainTeamTradeInfo.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.mainTeamTradeInfo_CellValueChanged);
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn5.FillWeight = 200F;
            this.dataGridViewTextBoxColumn5.HeaderText = "Player Name";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // otherTeamTradeInfo
            // 
            this.otherTeamTradeInfo.AllowUserToAddRows = false;
            this.otherTeamTradeInfo.AllowUserToDeleteRows = false;
            this.otherTeamTradeInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.otherTeamTradeInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn6});
            this.otherTeamTradeInfo.Location = new System.Drawing.Point(466, 267);
            this.otherTeamTradeInfo.MultiSelect = false;
            this.otherTeamTradeInfo.Name = "otherTeamTradeInfo";
            this.otherTeamTradeInfo.RowHeadersVisible = false;
            this.otherTeamTradeInfo.Size = new System.Drawing.Size(237, 143);
            this.otherTeamTradeInfo.TabIndex = 7;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn6.FillWeight = 200F;
            this.dataGridViewTextBoxColumn6.HeaderText = "Player Name";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // TradeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 422);
            this.Controls.Add(this.otherTeamTradeInfo);
            this.Controls.Add(this.mainTeamTradeInfo);
            this.Controls.Add(this.otherTeamGrid);
            this.Controls.Add(this.downButton);
            this.Controls.Add(this.upButton);
            this.Controls.Add(this.teamList);
            this.Controls.Add(this.mainTeamGrid);
            this.Name = "TradeForm";
            this.Text = "TradeForm";
            ((System.ComponentModel.ISupportInitialize)(this.mainTeamGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.otherTeamGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainTeamTradeInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.otherTeamTradeInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView mainTeamGrid;
        private System.Windows.Forms.ComboBox teamList;
        private System.Windows.Forms.Button upButton;
        private System.Windows.Forms.Button downButton;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Trade;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Overall;
        private System.Windows.Forms.DataGridViewTextBoxColumn Potential;
        private System.Windows.Forms.DataGridViewTextBoxColumn capHit;
        private System.Windows.Forms.DataGridView otherTeamGrid;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridView mainTeamTradeInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridView otherTeamTradeInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
    }
}