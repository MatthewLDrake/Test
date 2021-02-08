namespace FormulaBasketball
{
    partial class AddInjuryForm
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
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewComboBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Overall = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Move = new System.Windows.Forms.DataGridViewButtonColumn();
            this.PlayerObj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.randomButton = new System.Windows.Forms.RadioButton();
            this.minorInjury = new System.Windows.Forms.RadioButton();
            this.moderateInjury = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.seasonEndingInjury = new System.Windows.Forms.RadioButton();
            this.majorInjury = new System.Windows.Forms.RadioButton();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToResizeColumns = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewComboBoxColumn1,
            this.Overall,
            this.Move,
            this.PlayerObj});
            this.dataGridView2.Location = new System.Drawing.Point(32, 54);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.Size = new System.Drawing.Size(581, 301);
            this.dataGridView2.TabIndex = 2;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn1.HeaderText = "Position";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 69;
            // 
            // dataGridViewComboBoxColumn1
            // 
            this.dataGridViewComboBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewComboBoxColumn1.HeaderText = "Player";
            this.dataGridViewComboBoxColumn1.Name = "dataGridViewComboBoxColumn1";
            this.dataGridViewComboBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewComboBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Overall
            // 
            this.Overall.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Overall.HeaderText = "Overall";
            this.Overall.Name = "Overall";
            this.Overall.Width = 65;
            // 
            // Move
            // 
            this.Move.HeaderText = "Add Injury";
            this.Move.Name = "Move";
            // 
            // PlayerObj
            // 
            this.PlayerObj.HeaderText = "PlayerObj";
            this.PlayerObj.Name = "PlayerObj";
            this.PlayerObj.Visible = false;
            // 
            // randomButton
            // 
            this.randomButton.AutoSize = true;
            this.randomButton.Location = new System.Drawing.Point(30, 3);
            this.randomButton.Name = "randomButton";
            this.randomButton.Size = new System.Drawing.Size(93, 17);
            this.randomButton.TabIndex = 3;
            this.randomButton.TabStop = true;
            this.randomButton.Text = "Random Injury";
            this.randomButton.UseVisualStyleBackColor = true;
            // 
            // minorInjury
            // 
            this.minorInjury.AutoSize = true;
            this.minorInjury.Location = new System.Drawing.Point(30, 26);
            this.minorInjury.Name = "minorInjury";
            this.minorInjury.Size = new System.Drawing.Size(79, 17);
            this.minorInjury.TabIndex = 4;
            this.minorInjury.TabStop = true;
            this.minorInjury.Text = "Minor Injury";
            this.minorInjury.UseVisualStyleBackColor = true;
            // 
            // moderateInjury
            // 
            this.moderateInjury.AutoSize = true;
            this.moderateInjury.Location = new System.Drawing.Point(30, 49);
            this.moderateInjury.Name = "moderateInjury";
            this.moderateInjury.Size = new System.Drawing.Size(98, 17);
            this.moderateInjury.TabIndex = 5;
            this.moderateInjury.TabStop = true;
            this.moderateInjury.Text = "Moderate Injury";
            this.moderateInjury.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.seasonEndingInjury);
            this.panel1.Controls.Add(this.majorInjury);
            this.panel1.Controls.Add(this.randomButton);
            this.panel1.Controls.Add(this.moderateInjury);
            this.panel1.Controls.Add(this.minorInjury);
            this.panel1.Location = new System.Drawing.Point(217, 391);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 116);
            this.panel1.TabIndex = 6;
            // 
            // seasonEndingInjury
            // 
            this.seasonEndingInjury.AutoSize = true;
            this.seasonEndingInjury.Location = new System.Drawing.Point(30, 95);
            this.seasonEndingInjury.Name = "seasonEndingInjury";
            this.seasonEndingInjury.Size = new System.Drawing.Size(125, 17);
            this.seasonEndingInjury.TabIndex = 7;
            this.seasonEndingInjury.TabStop = true;
            this.seasonEndingInjury.Text = "Season Ending Injury";
            this.seasonEndingInjury.UseVisualStyleBackColor = true;
            // 
            // majorInjury
            // 
            this.majorInjury.AutoSize = true;
            this.majorInjury.Location = new System.Drawing.Point(30, 72);
            this.majorInjury.Name = "majorInjury";
            this.majorInjury.Size = new System.Drawing.Size(79, 17);
            this.majorInjury.TabIndex = 6;
            this.majorInjury.TabStop = true;
            this.majorInjury.Text = "Major Injury";
            this.majorInjury.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(188, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(292, 21);
            this.comboBox1.TabIndex = 7;
            this.comboBox1.Visible = false;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // AddInjuryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 540);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView2);
            this.Name = "AddInjuryForm";
            this.Text = "AddInjuryForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewComboBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Overall;
        private System.Windows.Forms.DataGridViewButtonColumn Move;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlayerObj;
        private System.Windows.Forms.RadioButton randomButton;
        private System.Windows.Forms.RadioButton minorInjury;
        private System.Windows.Forms.RadioButton moderateInjury;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton seasonEndingInjury;
        private System.Windows.Forms.RadioButton majorInjury;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}