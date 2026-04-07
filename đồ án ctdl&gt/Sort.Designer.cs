namespace đồ_án_ctdl_gt
{
    partial class Sort
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
            this.button1 = new System.Windows.Forms.Button();
            this.SortType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvtime = new System.Windows.Forms.DataGridView();
            this.sapxep = new System.Windows.Forms.Button();
            this.dgvNap = new System.Windows.Forms.DataGridView();
            this.cbthuattoan = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvtime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNap)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(247, 37);
            this.button1.TabIndex = 0;
            this.button1.Text = "Thêm dữ liệu";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SortType
            // 
            this.SortType.FormattingEnabled = true;
            this.SortType.Items.AddRange(new object[] {
            "Tăng dần",
            "Giảm dần"});
            this.SortType.Location = new System.Drawing.Point(317, 45);
            this.SortType.Name = "SortType";
            this.SortType.Size = new System.Drawing.Size(87, 24);
            this.SortType.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(294, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Chọn kiểu sắp xếp";
            // 
            // dgvtime
            // 
            this.dgvtime.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvtime.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvtime.Location = new System.Drawing.Point(-6, 325);
            this.dgvtime.Name = "dgvtime";
            this.dgvtime.RowHeadersWidth = 51;
            this.dgvtime.RowTemplate.Height = 24;
            this.dgvtime.Size = new System.Drawing.Size(813, 124);
            this.dgvtime.TabIndex = 3;
            // 
            // sapxep
            // 
            this.sapxep.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.sapxep.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.sapxep.Location = new System.Drawing.Point(634, 88);
            this.sapxep.Name = "sapxep";
            this.sapxep.Size = new System.Drawing.Size(97, 29);
            this.sapxep.TabIndex = 4;
            this.sapxep.Text = "Sắp xếp";
            this.sapxep.UseVisualStyleBackColor = false;
            this.sapxep.Click += new System.EventHandler(this.sapxep_Click);
            // 
            // dgvNap
            // 
            this.dgvNap.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNap.Location = new System.Drawing.Point(-1, 142);
            this.dgvNap.Name = "dgvNap";
            this.dgvNap.RowHeadersWidth = 51;
            this.dgvNap.RowTemplate.Height = 24;
            this.dgvNap.Size = new System.Drawing.Size(801, 143);
            this.dgvNap.TabIndex = 5;
            // 
            // cbthuattoan
            // 
            this.cbthuattoan.FormattingEnabled = true;
            this.cbthuattoan.Items.AddRange(new object[] {
            "Selection Sort",
            "",
            "",
            "Bubble Sort",
            "",
            "",
            "Heap Sort",
            "",
            "",
            "Insertion Sort",
            "",
            "",
            "Quick Sort",
            "",
            "",
            "Merge Sort"});
            this.cbthuattoan.Location = new System.Drawing.Point(500, 45);
            this.cbthuattoan.Name = "cbthuattoan";
            this.cbthuattoan.Size = new System.Drawing.Size(121, 24);
            this.cbthuattoan.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(473, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(190, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Chọn thuật toán sắp xếp";
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(717, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(83, 27);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "Quay lại";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.AntiqueWhite;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label3.Location = new System.Drawing.Point(307, 296);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(198, 26);
            this.label3.TabIndex = 9;
            this.label3.Text = "BẢNG ĐO THỜI GIAN";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.AntiqueWhite;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label4.Location = new System.Drawing.Point(288, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(230, 26);
            this.label4.TabIndex = 10;
            this.label4.Text = "DANH SÁCH TÀI KHOẢN";
            // 
            // Sort
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbthuattoan);
            this.Controls.Add(this.dgvNap);
            this.Controls.Add(this.sapxep);
            this.Controls.Add(this.dgvtime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SortType);
            this.Controls.Add(this.button1);
            this.Name = "Sort";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sort";
            ((System.ComponentModel.ISupportInitialize)(this.dgvtime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox SortType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvtime;
        private System.Windows.Forms.Button sapxep;
        private System.Windows.Forms.DataGridView dgvNap;
        private System.Windows.Forms.ComboBox cbthuattoan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}