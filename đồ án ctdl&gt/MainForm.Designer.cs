namespace đồ_án_ctdl_gt
{
    partial class MainForm
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
            this.lblUser = new System.Windows.Forms.Label();
            this.btnQLTK = new System.Windows.Forms.Button();
            this.btnQLGD = new System.Windows.Forms.Button();
            this.btnDangxuat = new System.Windows.Forms.Button();
            this.panelmain = new System.Windows.Forms.Panel();
            this.btnSort = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelmain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblUser.Location = new System.Drawing.Point(3, 7);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(53, 20);
            this.lblUser.TabIndex = 0;
            this.lblUser.Text = "label1";
            // 
            // btnQLTK
            // 
            this.btnQLTK.BackColor = System.Drawing.Color.White;
            this.btnQLTK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnQLTK.Location = new System.Drawing.Point(39, 44);
            this.btnQLTK.Name = "btnQLTK";
            this.btnQLTK.Size = new System.Drawing.Size(202, 37);
            this.btnQLTK.TabIndex = 1;
            this.btnQLTK.Text = "Quản lý tài khoản";
            this.btnQLTK.UseVisualStyleBackColor = true;
            this.btnQLTK.Click += new System.EventHandler(this.btnQLTK_Click_1);
            // 
            // btnQLGD
            // 
            this.btnQLGD.BackColor = System.Drawing.Color.White;
            this.btnQLGD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnQLGD.Location = new System.Drawing.Point(262, 44);
            this.btnQLGD.Name = "btnQLGD";
            this.btnQLGD.Size = new System.Drawing.Size(198, 37);
            this.btnQLGD.TabIndex = 2;
            this.btnQLGD.Text = "Quản lý giao dịch";
            this.btnQLGD.UseVisualStyleBackColor = true;
            this.btnQLGD.Click += new System.EventHandler(this.btnQLGD_Click);
            // 
            // btnDangxuat
            // 
            this.btnDangxuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnDangxuat.Location = new System.Drawing.Point(612, 405);
            this.btnDangxuat.Name = "btnDangxuat";
            this.btnDangxuat.Size = new System.Drawing.Size(142, 33);
            this.btnDangxuat.TabIndex = 3;
            this.btnDangxuat.Text = "Đăng xuất";
            this.btnDangxuat.UseVisualStyleBackColor = true;
            this.btnDangxuat.Click += new System.EventHandler(this.btnDangxuat_Click);
            // 
            // panelmain
            // 
            this.panelmain.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panelmain.Controls.Add(this.btnSort);
            this.panelmain.Controls.Add(this.lblUser);
            this.panelmain.Controls.Add(this.btnQLTK);
            this.panelmain.Controls.Add(this.btnQLGD);
            this.panelmain.Location = new System.Drawing.Point(27, 2);
            this.panelmain.Name = "panelmain";
            this.panelmain.Size = new System.Drawing.Size(727, 91);
            this.panelmain.TabIndex = 4;
            // 
            // btnSort
            // 
            this.btnSort.BackColor = System.Drawing.Color.White;
            this.btnSort.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnSort.Location = new System.Drawing.Point(476, 44);
            this.btnSort.Name = "btnSort";
            this.btnSort.Size = new System.Drawing.Size(198, 37);
            this.btnSort.TabIndex = 3;
            this.btnSort.Text = "Sắp xếp tài khoản";
            this.btnSort.UseVisualStyleBackColor = true;
            this.btnSort.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::đồ_án_ctdl_gt.Properties.Resources.z7680006328814_c8cdf8d6d3adc0d47cd905c1da20a517;
            this.pictureBox1.Location = new System.Drawing.Point(27, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(727, 436);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.UseWaitCursor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 450);
            this.Controls.Add(this.panelmain);
            this.Controls.Add(this.btnDangxuat);
            this.Controls.Add(this.pictureBox1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.panelmain.ResumeLayout(false);
            this.panelmain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Button btnQLTK;
        private System.Windows.Forms.Button btnQLGD;
        private System.Windows.Forms.Button btnDangxuat;
        private System.Windows.Forms.Panel panelmain;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnSort;
    }
}