namespace FormulaBasketball
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
            this.otherTeamGrid = new System.Windows.Forms.DataGridView();
            this.mainTeamTradeInfo = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.obje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.otherTeamTradeInfo = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.o = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.confirmButton = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.button1 = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.Trade = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Position = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Overall = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Potential = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.capHit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Obj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Object = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.mainTeamGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.otherTeamGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainTeamTradeInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.otherTeamTradeInfo)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
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
            this.Position,
            this.Overall,
            this.Potential,
            this.capHit,
            this.Obj});
            this.tableLayoutPanel1.SetColumnSpan(this.mainTeamGrid, 3);
            this.mainTeamGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTeamGrid.Location = new System.Drawing.Point(3, 3);
            this.mainTeamGrid.MultiSelect = false;
            this.mainTeamGrid.Name = "mainTeamGrid";
            this.mainTeamGrid.RowHeadersVisible = false;
            this.mainTeamGrid.Size = new System.Drawing.Size(426, 210);
            this.mainTeamGrid.TabIndex = 0;
            this.mainTeamGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.mainTeamGrid_CellContentClick);
            // 
            // teamList
            // 
            this.teamList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.teamList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.teamList.FormattingEnabled = true;
            this.teamList.Location = new System.Drawing.Point(521, 241);
            this.teamList.Name = "teamList";
            this.teamList.Size = new System.Drawing.Size(253, 21);
            this.teamList.TabIndex = 2;
            this.teamList.SelectedIndexChanged += new System.EventHandler(this.teamList_SelectedIndexChanged);
            // 
            // upButton
            // 
            this.upButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.upButton.Location = new System.Drawing.Point(455, 240);
            this.upButton.Name = "upButton";
            this.upButton.Size = new System.Drawing.Size(60, 23);
            this.upButton.TabIndex = 3;
            this.upButton.Text = "▲";
            this.upButton.UseVisualStyleBackColor = true;
            this.upButton.Click += new System.EventHandler(this.upButton_Click);
            // 
            // downButton
            // 
            this.downButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.downButton.Location = new System.Drawing.Point(780, 240);
            this.downButton.Name = "downButton";
            this.downButton.Size = new System.Drawing.Size(60, 23);
            this.downButton.TabIndex = 4;
            this.downButton.Text = "▼";
            this.downButton.UseVisualStyleBackColor = true;
            this.downButton.Click += new System.EventHandler(this.downButton_Click);
            // 
            // otherTeamGrid
            // 
            this.otherTeamGrid.AllowUserToAddRows = false;
            this.otherTeamGrid.AllowUserToDeleteRows = false;
            this.otherTeamGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.otherTeamGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn1,
            this.dataGridViewTextBoxColumn1,
            this.pos,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.Object});
            this.tableLayoutPanel1.SetColumnSpan(this.otherTeamGrid, 3);
            this.otherTeamGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.otherTeamGrid.Location = new System.Drawing.Point(435, 3);
            this.otherTeamGrid.MultiSelect = false;
            this.otherTeamGrid.Name = "otherTeamGrid";
            this.otherTeamGrid.RowHeadersVisible = false;
            this.otherTeamGrid.Size = new System.Drawing.Size(426, 210);
            this.otherTeamGrid.TabIndex = 5;
            this.otherTeamGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.otherTeamGrid_CellContentClick);
            // 
            // mainTeamTradeInfo
            // 
            this.mainTeamTradeInfo.AllowUserToAddRows = false;
            this.mainTeamTradeInfo.AllowUserToDeleteRows = false;
            this.mainTeamTradeInfo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.mainTeamTradeInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mainTeamTradeInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5,
            this.obje});
            this.tableLayoutPanel1.SetColumnSpan(this.mainTeamTradeInfo, 3);
            this.mainTeamTradeInfo.Location = new System.Drawing.Point(97, 291);
            this.mainTeamTradeInfo.MultiSelect = false;
            this.mainTeamTradeInfo.Name = "mainTeamTradeInfo";
            this.mainTeamTradeInfo.RowHeadersVisible = false;
            this.mainTeamTradeInfo.Size = new System.Drawing.Size(237, 136);
            this.mainTeamTradeInfo.TabIndex = 6;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn5.FillWeight = 200F;
            this.dataGridViewTextBoxColumn5.HeaderText = "Player Name";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // obje
            // 
            this.obje.HeaderText = "Object";
            this.obje.Name = "obje";
            this.obje.Visible = false;
            // 
            // otherTeamTradeInfo
            // 
            this.otherTeamTradeInfo.AllowUserToAddRows = false;
            this.otherTeamTradeInfo.AllowUserToDeleteRows = false;
            this.otherTeamTradeInfo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.otherTeamTradeInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.otherTeamTradeInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn6,
            this.o});
            this.tableLayoutPanel1.SetColumnSpan(this.otherTeamTradeInfo, 3);
            this.otherTeamTradeInfo.Location = new System.Drawing.Point(529, 291);
            this.otherTeamTradeInfo.MultiSelect = false;
            this.otherTeamTradeInfo.Name = "otherTeamTradeInfo";
            this.otherTeamTradeInfo.RowHeadersVisible = false;
            this.otherTeamTradeInfo.Size = new System.Drawing.Size(237, 136);
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
            // o
            // 
            this.o.HeaderText = "Object";
            this.o.Name = "o";
            this.o.Visible = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Controls.Add(this.mainTeamGrid, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.mainTeamTradeInfo, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.otherTeamTradeInfo, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.otherTeamGrid, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.upButton, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.downButton, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.teamList, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.confirmButton, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.99834F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66945F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33222F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(864, 434);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // confirmButton
            // 
            this.confirmButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.confirmButton.Location = new System.Drawing.Point(34, 240);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(75, 23);
            this.confirmButton.TabIndex = 8;
            this.confirmButton.Text = "Confirm";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(288, 216);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.loadButton);
            this.splitContainer1.Size = new System.Drawing.Size(144, 72);
            this.splitContainer1.SplitterDistance = 39;
            this.splitContainer1.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.Location = new System.Drawing.Point(12, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 22);
            this.button1.TabIndex = 10;
            this.button1.Text = "Load Trade Response";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // loadButton
            // 
            this.loadButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.loadButton.Location = new System.Drawing.Point(12, 2);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(121, 22);
            this.loadButton.TabIndex = 9;
            this.loadButton.Text = "Load Trade";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // Trade
            // 
            this.Trade.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Trade.FillWeight = 20F;
            this.Trade.HeaderText = "Trade";
            this.Trade.Name = "Trade";
            this.Trade.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Trade.Width = 41;
            // 
            // name
            // 
            this.name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.name.FillWeight = 200F;
            this.name.HeaderText = "Player Name";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // Position
            // 
            this.Position.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Position.HeaderText = "Position";
            this.Position.Name = "Position";
            this.Position.Width = 69;
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
            // Obj
            // 
            this.Obj.HeaderText = "Object";
            this.Obj.Name = "Obj";
            this.Obj.Visible = false;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewCheckBoxColumn1.FillWeight = 20F;
            this.dataGridViewCheckBoxColumn1.HeaderText = "Trade";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCheckBoxColumn1.Width = 41;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.FillWeight = 200F;
            this.dataGridViewTextBoxColumn1.HeaderText = "Player Name";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // pos
            // 
            this.pos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.pos.HeaderText = "Position";
            this.pos.Name = "pos";
            this.pos.Width = 69;
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
            this.dataGridViewTextBoxColumn4.Width = 67;
            // 
            // Object
            // 
            this.Object.HeaderText = "Object";
            this.Object.Name = "Object";
            this.Object.Visible = false;
            // 
            // TradeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 434);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "TradeForm";
            this.Text = "TradeForm";
            ((System.ComponentModel.ISupportInitialize)(this.mainTeamGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.otherTeamGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainTeamTradeInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.otherTeamTradeInfo)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView mainTeamGrid;
        private System.Windows.Forms.ComboBox teamList;
        private System.Windows.Forms.Button upButton;
        private System.Windows.Forms.Button downButton;
        private System.Windows.Forms.DataGridView otherTeamGrid;
        private System.Windows.Forms.DataGridView mainTeamTradeInfo;
        private System.Windows.Forms.DataGridView otherTeamTradeInfo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn obje;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn o;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Trade;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Position;
        private System.Windows.Forms.DataGridViewTextBoxColumn Overall;
        private System.Windows.Forms.DataGridViewTextBoxColumn Potential;
        private System.Windows.Forms.DataGridViewTextBoxColumn capHit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Obj;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn pos;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Object;
    }
}