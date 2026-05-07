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
            tlpMain = new TableLayoutPanel();
            tlpLeft = new TableLayoutPanel();
            label1 = new Label();
            dgvExcel = new DataGridView();
            tlpExcelLists = new TableLayoutPanel();
            lblKey = new Label();
            lblValue = new Label();
            excelIdColumnList = new CheckedListBox();
            excelValueColumnList = new CheckedListBox();
            tlpRight = new TableLayoutPanel();
            label2 = new Label();
            dgvDatabase = new DataGridView();
            lblDbKey = new Label();
            dbIdColumnList = new CheckedListBox();
            flpButtons = new FlowLayoutPanel();
            btnLoad = new Button();
            btnCompare = new Button();
            tlpMain.SuspendLayout();
            tlpLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvExcel).BeginInit();
            tlpExcelLists.SuspendLayout();
            tlpRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDatabase).BeginInit();
            flpButtons.SuspendLayout();
            SuspendLayout();
            // 
            // tlpMain
            // 
            tlpMain.ColumnCount = 2;
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpMain.Controls.Add(tlpLeft, 0, 0);
            tlpMain.Controls.Add(tlpRight, 1, 0);
            tlpMain.Controls.Add(flpButtons, 0, 1);
            tlpMain.Dock = DockStyle.Fill;
            tlpMain.Location = new Point(0, 0);
            tlpMain.Name = "tlpMain";
            tlpMain.Padding = new Padding(10);
            tlpMain.RowCount = 2;
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tlpMain.Size = new Size(933, 519);
            tlpMain.TabIndex = 0;
            // 
            // tlpLeft
            // 
            tlpLeft.ColumnCount = 1;
            tlpLeft.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpLeft.Controls.Add(label1, 0, 0);
            tlpLeft.Controls.Add(dgvExcel, 0, 1);
            tlpLeft.Controls.Add(tlpExcelLists, 0, 2);
            tlpLeft.Dock = DockStyle.Fill;
            tlpLeft.Location = new Point(13, 13);
            tlpLeft.Name = "tlpLeft";
            tlpLeft.RowCount = 3;
            tlpLeft.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tlpLeft.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpLeft.RowStyles.Add(new RowStyle(SizeType.Absolute, 110F));
            tlpLeft.Size = new Size(450, 453);
            tlpLeft.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(36, 15);
            label1.TabIndex = 3;
            label1.Text = "Excel";
            // 
            // dgvExcel
            // 
            dgvExcel.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvExcel.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvExcel.Dock = DockStyle.Fill;
            dgvExcel.Location = new Point(3, 28);
            dgvExcel.Name = "dgvExcel";
            dgvExcel.Size = new Size(444, 312);
            dgvExcel.TabIndex = 0;
            // 
            // tlpExcelLists
            // 
            tlpExcelLists.ColumnCount = 2;
            tlpExcelLists.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpExcelLists.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpExcelLists.Controls.Add(lblKey, 0, 0);
            tlpExcelLists.Controls.Add(lblValue, 1, 0);
            tlpExcelLists.Controls.Add(excelIdColumnList, 0, 1);
            tlpExcelLists.Controls.Add(excelValueColumnList, 1, 1);
            tlpExcelLists.Dock = DockStyle.Fill;
            tlpExcelLists.Location = new Point(3, 346);
            tlpExcelLists.Name = "tlpExcelLists";
            tlpExcelLists.RowCount = 2;
            tlpExcelLists.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlpExcelLists.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpExcelLists.Size = new Size(444, 104);
            tlpExcelLists.TabIndex = 4;
            // 
            // lblKey
            // 
            lblKey.AutoSize = true;
            lblKey.Location = new Point(3, 0);
            lblKey.Name = "lblKey";
            lblKey.Size = new Size(140, 15);
            lblKey.TabIndex = 8;
            lblKey.Text = "Select Unique ID column:";
            // 
            // lblValue
            // 
            lblValue.AutoSize = true;
            lblValue.Location = new Point(225, 0);
            lblValue.Name = "lblValue";
            lblValue.Size = new Size(119, 15);
            lblValue.TabIndex = 9;
            lblValue.Text = "Select Excel columns:";
            // 
            // excelIdColumnList
            // 
            excelIdColumnList.Dock = DockStyle.Fill;
            excelIdColumnList.FormattingEnabled = true;
            excelIdColumnList.Location = new Point(3, 23);
            excelIdColumnList.Name = "excelIdColumnList";
            excelIdColumnList.Size = new Size(216, 78);
            excelIdColumnList.TabIndex = 5;
            // 
            // excelValueColumnList
            // 
            excelValueColumnList.Dock = DockStyle.Fill;
            excelValueColumnList.FormattingEnabled = true;
            excelValueColumnList.Location = new Point(225, 23);
            excelValueColumnList.Name = "excelValueColumnList";
            excelValueColumnList.Size = new Size(216, 78);
            excelValueColumnList.TabIndex = 6;
            // 
            // tlpRight
            // 
            tlpRight.ColumnCount = 1;
            tlpRight.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpRight.Controls.Add(label2, 0, 0);
            tlpRight.Controls.Add(dgvDatabase, 0, 1);
            tlpRight.Controls.Add(lblDbKey, 0, 2);
            tlpRight.Controls.Add(dbIdColumnList, 0, 3);
            tlpRight.Dock = DockStyle.Fill;
            tlpRight.Location = new Point(469, 13);
            tlpRight.Name = "tlpRight";
            tlpRight.RowCount = 4;
            tlpRight.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tlpRight.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpRight.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlpRight.RowStyles.Add(new RowStyle(SizeType.Absolute, 90F));
            tlpRight.Size = new Size(451, 453);
            tlpRight.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 4;
            label2.Text = "Database";
            // 
            // dgvDatabase
            // 
            dgvDatabase.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvDatabase.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDatabase.Dock = DockStyle.Fill;
            dgvDatabase.Location = new Point(3, 28);
            dgvDatabase.Name = "dgvDatabase";
            dgvDatabase.Size = new Size(445, 312);
            dgvDatabase.TabIndex = 2;
            // 
            // lblDbKey
            // 
            lblDbKey.AutoSize = true;
            lblDbKey.Location = new Point(3, 343);
            lblDbKey.Name = "lblDbKey";
            lblDbKey.Size = new Size(157, 15);
            lblDbKey.TabIndex = 11;
            lblDbKey.Text = "Select Matching DB column:";
            // 
            // dbIdColumnList
            // 
            dbIdColumnList.Dock = DockStyle.Fill;
            dbIdColumnList.FormattingEnabled = true;
            dbIdColumnList.Location = new Point(3, 366);
            dbIdColumnList.Name = "dbIdColumnList";
            dbIdColumnList.Size = new Size(445, 84);
            dbIdColumnList.TabIndex = 10;
            // 
            // flpButtons
            // 
            tlpMain.SetColumnSpan(flpButtons, 2);
            flpButtons.Controls.Add(btnLoad);
            flpButtons.Controls.Add(btnCompare);
            flpButtons.Dock = DockStyle.Fill;
            flpButtons.Location = new Point(13, 472);
            flpButtons.Name = "flpButtons";
            flpButtons.Size = new Size(907, 34);
            flpButtons.TabIndex = 2;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(3, 3);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(140, 27);
            btnLoad.TabIndex = 1;
            btnLoad.Text = "Load Data";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnCompare
            // 
            btnCompare.Location = new Point(149, 3);
            btnCompare.Name = "btnCompare";
            btnCompare.Size = new Size(140, 27);
            btnCompare.TabIndex = 7;
            btnCompare.Text = "Compare";
            btnCompare.Click += btnCompare_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(933, 519);
            Controls.Add(tlpMain);
            MinimumSize = new Size(900, 500);
            Name = "Form1";
            Text = "Form 1";
            tlpMain.ResumeLayout(false);
            tlpLeft.ResumeLayout(false);
            tlpLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvExcel).EndInit();
            tlpExcelLists.ResumeLayout(false);
            tlpExcelLists.PerformLayout();
            tlpRight.ResumeLayout(false);
            tlpRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDatabase).EndInit();
            flpButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView dgvExcel;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.DataGridView dgvDatabase;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox excelIdColumnList;
        private System.Windows.Forms.CheckedListBox excelValueColumnList;
        private System.Windows.Forms.Button btnCompare;
        private System.Windows.Forms.Label lblKey;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.CheckedListBox dbIdColumnList;
        private System.Windows.Forms.Label lblDbKey;
        private TableLayoutPanel tlpMain;
        private TableLayoutPanel tlpLeft;
        private TableLayoutPanel tlpExcelLists;
        private TableLayoutPanel tlpRight;
        private FlowLayoutPanel flpButtons;
    }
}