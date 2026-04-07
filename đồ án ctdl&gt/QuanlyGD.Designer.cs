namespace đồ_án_ctdl_gt
{
    partial class QuanlyGD
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
            this.txtMaGDSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboLoaiDV = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMaTKGD = new System.Windows.Forms.TextBox();
            this.dtpNgayGD = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.numtien = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.btXoa = new System.Windows.Forms.Button();
            this.btThem = new System.Windows.Forms.Button();
            this.btadd = new System.Windows.Forms.Button();
            this.dgvGiaoDich = new System.Windows.Forms.DataGridView();
            this.labelloi = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Exit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numtien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGiaoDich)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtMaGDSearch
            // 
            this.txtMaGDSearch.Location = new System.Drawing.Point(3, 31);
            this.txtMaGDSearch.Name = "txtMaGDSearch";
            this.txtMaGDSearch.Size = new System.Drawing.Size(159, 22);
            this.txtMaGDSearch.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nhập mã giao dịch";
            // 
            // cboLoaiDV
            // 
            this.cboLoaiDV.FormattingEnabled = true;
            this.cboLoaiDV.Items.AddRange(new object[] {
            "Nhận tiền",
            "Chuyển tiền"});
            this.cboLoaiDV.Location = new System.Drawing.Point(478, 29);
            this.cboLoaiDV.Name = "cboLoaiDV";
            this.cboLoaiDV.Size = new System.Drawing.Size(121, 24);
            this.cboLoaiDV.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(474, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Loại giao dịch";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(249, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Mã tài khoản";
            // 
            // txtMaTKGD
            // 
            this.txtMaTKGD.Location = new System.Drawing.Point(253, 31);
            this.txtMaTKGD.Name = "txtMaTKGD";
            this.txtMaTKGD.Size = new System.Drawing.Size(100, 22);
            this.txtMaTKGD.TabIndex = 5;
            // 
            // dtpNgayGD
            // 
            this.dtpNgayGD.Location = new System.Drawing.Point(215, 95);
            this.dtpNgayGD.Name = "dtpNgayGD";
            this.dtpNgayGD.Size = new System.Drawing.Size(200, 22);
            this.dtpNgayGD.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(249, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Ngày giao dịch\r\n";
            // 
            // numtien
            // 
            this.numtien.Location = new System.Drawing.Point(478, 92);
            this.numtien.Name = "numtien";
            this.numtien.Size = new System.Drawing.Size(120, 22);
            this.numtien.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.Location = new System.Drawing.Point(474, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Số tiền";
            // 
            // btXoa
            // 
            this.btXoa.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btXoa.Location = new System.Drawing.Point(90, 69);
            this.btXoa.Name = "btXoa";
            this.btXoa.Size = new System.Drawing.Size(72, 23);
            this.btXoa.TabIndex = 10;
            this.btXoa.Text = "Xóa";
            this.btXoa.UseVisualStyleBackColor = false;
            this.btXoa.Click += new System.EventHandler(this.btXoa_Click);
            // 
            // btThem
            // 
            this.btThem.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btThem.Location = new System.Drawing.Point(6, 69);
            this.btThem.Name = "btThem";
            this.btThem.Size = new System.Drawing.Size(78, 23);
            this.btThem.TabIndex = 11;
            this.btThem.Text = "Thêm";
            this.btThem.UseVisualStyleBackColor = false;
            this.btThem.Click += new System.EventHandler(this.btThem_Click);
            // 
            // btadd
            // 
            this.btadd.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btadd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btadd.Location = new System.Drawing.Point(713, 26);
            this.btadd.Name = "btadd";
            this.btadd.Size = new System.Drawing.Size(75, 63);
            this.btadd.TabIndex = 12;
            this.btadd.Text = "Thêm GD";
            this.btadd.UseVisualStyleBackColor = false;
            this.btadd.Click += new System.EventHandler(this.btadd_Click);
            // 
            // dgvGiaoDich
            // 
            this.dgvGiaoDich.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGiaoDich.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGiaoDich.Location = new System.Drawing.Point(0, 158);
            this.dgvGiaoDich.Name = "dgvGiaoDich";
            this.dgvGiaoDich.RowHeadersWidth = 51;
            this.dgvGiaoDich.RowTemplate.Height = 24;
            this.dgvGiaoDich.Size = new System.Drawing.Size(802, 295);
            this.dgvGiaoDich.TabIndex = 13;
            // 
            // labelloi
            // 
            this.labelloi.AutoSize = true;
            this.labelloi.Location = new System.Drawing.Point(409, 135);
            this.labelloi.Name = "labelloi";
            this.labelloi.Size = new System.Drawing.Size(0, 16);
            this.labelloi.TabIndex = 14;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel1.Controls.Add(this.Exit);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.labelloi);
            this.panel1.Controls.Add(this.txtMaGDSearch);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btadd);
            this.panel1.Controls.Add(this.txtMaTKGD);
            this.panel1.Controls.Add(this.btXoa);
            this.panel1.Controls.Add(this.btThem);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cboLoaiDV);
            this.panel1.Controls.Add(this.numtien);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.dtpNgayGD);
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(802, 157);
            this.panel1.TabIndex = 15;
            // 
            // Exit
            // 
            this.Exit.BackColor = System.Drawing.Color.FloralWhite;
            this.Exit.Location = new System.Drawing.Point(702, 122);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(86, 29);
            this.Exit.TabIndex = 15;
            this.Exit.Text = "Quay lại";
            this.Exit.UseVisualStyleBackColor = false;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // QuanlyGD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvGiaoDich);
            this.Name = "QuanlyGD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QuanlyGD";
            ((System.ComponentModel.ISupportInitialize)(this.numtien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGiaoDich)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtMaGDSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboLoaiDV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMaTKGD;
        private System.Windows.Forms.DateTimePicker dtpNgayGD;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numtien;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btXoa;
        private System.Windows.Forms.Button btThem;
        private System.Windows.Forms.Button btadd;
        private System.Windows.Forms.DataGridView dgvGiaoDich;
        private System.Windows.Forms.Label labelloi;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Exit;
    }
}