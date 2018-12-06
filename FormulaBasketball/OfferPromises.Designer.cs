namespace FormulaBasketball
{
    partial class OfferPromises
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
            this.promiseGrid = new System.Windows.Forms.DataGridView();
            this.confirmButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Promise = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.PromiseDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PromiseObject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.promiseGrid)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // promiseGrid
            // 
            this.promiseGrid.AllowUserToAddRows = false;
            this.promiseGrid.AllowUserToDeleteRows = false;
            this.promiseGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.promiseGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Promise,
            this.PromiseDesc,
            this.PromiseObject});
            this.tableLayoutPanel1.SetColumnSpan(this.promiseGrid, 2);
            this.promiseGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.promiseGrid.Location = new System.Drawing.Point(3, 3);
            this.promiseGrid.Name = "promiseGrid";
            this.promiseGrid.RowHeadersVisible = false;
            this.promiseGrid.Size = new System.Drawing.Size(272, 242);
            this.promiseGrid.TabIndex = 0;
            this.promiseGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.promiseGrid_CellContentClick);
            // 
            // confirmButton
            // 
            this.confirmButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.confirmButton.Location = new System.Drawing.Point(61, 251);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(75, 23);
            this.confirmButton.TabIndex = 1;
            this.confirmButton.Text = "Confirm";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(142, 251);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.promiseGrid, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cancelButton, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.confirmButton, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(278, 277);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // Promise
            // 
            this.Promise.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Promise.HeaderText = "Promise";
            this.Promise.Name = "Promise";
            this.Promise.Width = 50;
            // 
            // PromiseDesc
            // 
            this.PromiseDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PromiseDesc.HeaderText = "Promise Description";
            this.PromiseDesc.Name = "PromiseDesc";
            this.PromiseDesc.ReadOnly = true;
            this.PromiseDesc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PromiseObject
            // 
            this.PromiseObject.HeaderText = "Column1";
            this.PromiseObject.Name = "PromiseObject";
            this.PromiseObject.ReadOnly = true;
            this.PromiseObject.Visible = false;
            // 
            // OfferPromises
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 277);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "OfferPromises";
            this.Text = "OfferPromises";
            ((System.ComponentModel.ISupportInitialize)(this.promiseGrid)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView promiseGrid;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Promise;
        private System.Windows.Forms.DataGridViewTextBoxColumn PromiseDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn PromiseObject;
    }
}