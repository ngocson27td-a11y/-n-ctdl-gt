using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace đồ_án_ctdl_gt
{
    public partial class QuanlyGD : Form
    {
        List<Transaction> allTransactions = new List<Transaction>();
        public QuanlyGD()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.QuanlyGD_Load);
            txtMaTKGD.Visible = false;
            cboLoaiDV.Visible = false;
            dtpNgayGD.Visible = false;
            numtien.Visible = false;
            btadd.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
        }

        private void QuanlyGD_Load(object sender, EventArgs e)
        {
            // Lấy dữ liệu mẫu từ hàm static đã viết
            allTransactions = Transaction.GetTransaction();
            // Đưa danh sách này xuống bảng
            LoadGiaoDichToGrid(allTransactions);
        }

        public void LoadGiaoDichToGrid(List<Transaction> danhSach)
        { 
            //  Xóa sạch DataSource và các cột cũ để tránh xung đột
            dgvGiaoDich.DataSource = null;
            dgvGiaoDich.Columns.Clear();
            dgvGiaoDich.AutoGenerateColumns = false; 

            // Cột Mã giao dịch
            DataGridViewTextBoxColumn colID = new DataGridViewTextBoxColumn();
            colID.Name = "TransactionID"; 
            colID.HeaderText = "Mã giao dịch"; 
            colID.DataPropertyName = "TransactionID"; 
            dgvGiaoDich.Columns.Add(colID);

            // Cột Số Tài khoản
            DataGridViewTextBoxColumn colAcc = new DataGridViewTextBoxColumn();
            colAcc.Name = "Account";
            colAcc.HeaderText = "Số Tài khoản";
            colAcc.DataPropertyName = "Account";
            dgvGiaoDich.Columns.Add(colAcc);

            // Cột Ngày giao dịch
            DataGridViewTextBoxColumn colDate = new DataGridViewTextBoxColumn();
            colDate.Name = "TransactionDate";
            colDate.HeaderText = "Ngày giao dịch";
            colDate.DataPropertyName = "TransactionDate";
            colDate.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss"; // Định dạng ngày giờ
            dgvGiaoDich.Columns.Add(colDate);

            // Cột Loại giao dịch
            DataGridViewTextBoxColumn colType = new DataGridViewTextBoxColumn();
            colType.Name = "TransactionType";
            colType.HeaderText = "Loại giao dịch";
            colType.DataPropertyName = "TransactionType";
            dgvGiaoDich.Columns.Add(colType);

            // Cột Số tiền
            DataGridViewTextBoxColumn colAmount = new DataGridViewTextBoxColumn();
            colAmount.Name = "Amount";
            colAmount.HeaderText = "Số tiền";
            colAmount.DataPropertyName = "Amount";
            colAmount.DefaultCellStyle.Format = "N0"; // Định dạng số có dấu phẩy
            dgvGiaoDich.Columns.Add(colAmount);

            //Gán danh sách vào và làm mới
            dgvGiaoDich.DataSource = danhSach;
            dgvGiaoDich.Refresh();
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem đã nhập Mã giao dịch chưa
            if (string.IsNullOrWhiteSpace(txtMaGDSearch.Text))
            {
                labelloi.Text = "Vui lòng nhập Mã giao dịch trước!";
                return;
            }

            // Kiểm tra định dạng Mã giao dịch (Bắt đầu bằng GD và có 5 số cuối)
            string maGD = txtMaGDSearch.Text;
            if (!maGD.StartsWith("GD") || maGD.Length != 7)
            {
                labelloi.Text = "Mã GD phải bắt đầu bằng 'GD' và có 5 chữ số ở cuối!";
                return;
            }

            // Nếu hợp lệ, hiện các ô còn lại để người dùng điền thông tin
            txtMaTKGD.Visible = true;
            cboLoaiDV.Visible = true;
            dtpNgayGD.Visible = true;
            numtien.Visible = true;
            btadd.Visible = true;

            // Hiện các Label tương ứng 
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;

            // Đổi tên nút hoặc hiện thêm một nút "Xác nhận" để thực sự lưu dữ liệu
            labelloi.Text = "Mời bạn nhập tiếp thông tin.";
        }

        private void btadd_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy dữ liệu từ các ô nhập liệu trên giao diện
                string maGD = txtMaGDSearch.Text;
                string maTK = txtMaTKGD.Text;
                DateTime ngayGD = dtpNgayGD.Value;
                string loaiGD = cboLoaiDV.Text;
                int soTien = (int)numtien.Value;

                // Kiểm tra dữ liệu đầu vào cơ bản
                if (string.IsNullOrWhiteSpace(maGD) || string.IsNullOrWhiteSpace(maTK))
                {
                    labelloi.Text = "Lỗi: Vui lòng nhập đầy đủ Mã GD và Mã tài khoản!";
                    return;
                }

                // Tạo đối tượng Transaction mới từ Constructor đã có
                Transaction moi = new Transaction(maGD, maTK, ngayGD, loaiGD, soTien);
                //Thêm vào danh sách tổng
                allTransactions.Add(moi);
                //Cập nhật lại DataGridView để hiển thị dòng mới
                LoadGiaoDichToGrid(allTransactions);
                // Xóa trắng các ô nhập và ẩn chúng đi để quay lại trạng thái ban đầu
                ResetGiaoDienSauKhiThem();
                MessageBox.Show("Thêm giao dịch mới thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }

        private void ResetGiaoDienSauKhiThem()
        {
            // Xóa nội dung cũ
            txtMaGDSearch.Clear();
            txtMaTKGD.Clear();
            numtien.Value = 0;
            labelloi.Text = "";
            // Ẩn lại các ô nhập liệu
            txtMaTKGD.Visible = false;
            cboLoaiDV.Visible = false;
            dtpNgayGD.Visible = false;
            numtien.Visible = false;
            btadd.Visible = false; 
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            btThem.Text = "Thêm";
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            MainForm fMain = new MainForm("Admin");
            fMain.Show();
            this.Close();
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            Transaction selected = null;
            string maCanXoa = txtMaGDSearch.Text.Trim();
            // Nếu người dùng có nhập mã vào TextBox, tìm theo mã đó
            if (!string.IsNullOrEmpty(maCanXoa))
            {
                selected = allTransactions.FirstOrDefault(t => t.TransactionID == maCanXoa);
                if (selected == null)
                {
                    MessageBox.Show("Không tìm thấy mã giao dịch này trong hệ thống!");
                    return;
                }
            }
            // Nếu TextBox trống, kiểm tra xem người dùng có đang chọn dòng nào trên bảng không
            else if (dgvGiaoDich.CurrentRow != null)
            {
                selected = (Transaction)dgvGiaoDich.CurrentRow.DataBoundItem;
            }
            // Nếu cả TextBox trống và không chọn dòng nào
            else
            {
                MessageBox.Show("Vui lòng nhập mã hoặc chọn một giao dịch trong bảng để xóa!");
                return;
            }
            //  Tiến hành xóa
            DialogResult dr = MessageBox.Show($"Bạn có chắc chắn muốn xóa giao dịch {selected.TransactionID} không?", "Xác nhận", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                // Xóa khỏi danh sách tổng
                allTransactions.Remove(selected);
                // Cập nhật lại bảng hiển thị
                LoadGiaoDichToGrid(allTransactions);
                MessageBox.Show("Đã xóa giao dịch thành công!");
            }
        }
    }

}
