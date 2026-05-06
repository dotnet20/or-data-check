namespace or_data_check
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dgvExcel = new DataGridView();
            btnLoad = new Button();
            dgvDatabase = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            clbKeyColumns = new CheckedListBox();
            clbValueColumns = new CheckedListBox();
            btnCompare = new Button();
            lblKey = new Label();
            lblValue = new Label();
            clbDbColumns = new CheckedListBox();
            lblDbKey = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvExcel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDatabase).BeginInit();
            SuspendLayout();
            // 
            // dgvExcel
            // 
            dgvExcel.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvExcel.Location = new Point(14, 45);
            dgvExcel.Margin = new Padding(4, 3, 4, 3);
            dgvExcel.Name = "dgvExcel";
            dgvExcel.Size = new Size(429, 293);
            dgvExcel.TabIndex = 0;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(14, 479);
            btnLoad.Margin = new Padding(4, 3, 4, 3);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(140, 27);
            btnLoad.TabIndex = 1;
            btnLoad.Text = "Load Data";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // dgvDatabase
            // 
            dgvDatabase.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDatabase.Location = new Point(490, 45);
            dgvDatabase.Margin = new Padding(4, 3, 4, 3);
            dgvDatabase.Name = "dgvDatabase";
            dgvDatabase.Size = new Size(429, 293);
            dgvDatabase.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.Location = new Point(14, 20);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(36, 15);
            label1.TabIndex = 3;
            label1.Text = "Excel";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(490, 20);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 4;
            label2.Text = "Database";
            // 
            // clbKeyColumns
            // 
            clbKeyColumns.FormattingEnabled = true;
            clbKeyColumns.Location = new Point(14, 369);
            clbKeyColumns.Margin = new Padding(4, 3, 4, 3);
            clbKeyColumns.Name = "clbKeyColumns";
            clbKeyColumns.Size = new Size(198, 76);
            clbKeyColumns.TabIndex = 5;
            // 
            // clbValueColumns
            // 
            clbValueColumns.FormattingEnabled = true;
            clbValueColumns.Location = new Point(245, 369);
            clbValueColumns.Margin = new Padding(4, 3, 4, 3);
            clbValueColumns.Name = "clbValueColumns";
            clbValueColumns.Size = new Size(198, 76);
            clbValueColumns.TabIndex = 6;
            // 
            // btnCompare
            // 
            btnCompare.BackColor = SystemColors.Control;
            btnCompare.Font = new Font("Segoe UI", 9F);
            btnCompare.Location = new Point(187, 479);
            btnCompare.Margin = new Padding(4, 3, 4, 3);
            btnCompare.Name = "btnCompare";
            btnCompare.Size = new Size(140, 27);
            btnCompare.TabIndex = 7;
            btnCompare.Text = "Compare";
            btnCompare.UseVisualStyleBackColor = false;
            btnCompare.Click += btnCompare_Click;
            // 
            // lblKey
            // 
            lblKey.AutoSize = true;
            lblKey.Location = new Point(14, 351);
            lblKey.Margin = new Padding(4, 0, 4, 0);
            lblKey.Name = "lblKey";
            lblKey.Size = new Size(140, 15);
            lblKey.TabIndex = 8;
            lblKey.Text = "Select Unique ID column:";
            // 
            // lblValue
            // 
            lblValue.AutoSize = true;
            lblValue.Location = new Point(245, 351);
            lblValue.Margin = new Padding(4, 0, 4, 0);
            lblValue.Name = "lblValue";
            lblValue.Size = new Size(119, 15);
            lblValue.TabIndex = 9;
            lblValue.Text = "Select Excel columns:";
            // 
            // clbDbColumns
            // 
            clbDbColumns.FormattingEnabled = true;
            clbDbColumns.Location = new Point(490, 369);
            clbDbColumns.Name = "clbDbColumns";
            clbDbColumns.Size = new Size(198, 76);
            clbDbColumns.TabIndex = 10;
            // 
            // lblDbKey
            // 
            lblDbKey.AutoSize = true;
            lblDbKey.Location = new Point(490, 351);
            lblDbKey.Name = "lblDbKey";
            lblDbKey.Size = new Size(157, 15);
            lblDbKey.TabIndex = 11;
            lblDbKey.Text = "Select Matching DB column:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(933, 519);
            Controls.Add(lblDbKey);
            Controls.Add(clbDbColumns);
            Controls.Add(lblValue);
            Controls.Add(lblKey);
            Controls.Add(btnCompare);
            Controls.Add(clbValueColumns);
            Controls.Add(clbKeyColumns);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvDatabase);
            Controls.Add(btnLoad);
            Controls.Add(dgvExcel);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form1";
            Text = "Form";
            ((System.ComponentModel.ISupportInitialize)dgvExcel).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDatabase).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.DataGridView dgvExcel;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.DataGridView dgvDatabase;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox clbKeyColumns;
        private System.Windows.Forms.CheckedListBox clbValueColumns;
        private System.Windows.Forms.Button btnCompare;
        private System.Windows.Forms.Label lblKey;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.CheckedListBox clbDbColumns;
        private System.Windows.Forms.Label lblDbKey;
    }
}