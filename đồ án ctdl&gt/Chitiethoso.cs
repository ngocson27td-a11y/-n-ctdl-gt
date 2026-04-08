using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace đồ_án_ctdl_gt
{
    public partial class Chitiethoso : Form
    {
        List<Account> allAccounts = new List<Account>();
        BinarySearchTree myBST = new BinarySearchTree();
        List<Customer> allCustomers = new List<Customer>();
        List<Transaction> allTransactions = new List<Transaction>();
        

        public Chitiethoso()
        {
            InitializeComponent();
            LoadDummyData(); // Gọi hàm nạp dữ liệu mẫu
            // Thêm các lựa chọn vào ComboBox
            cbSearchType.Items.Add("Số Tài khoản");
            cbSearchType.Items.Add("Tên Tài khoản");
            cbSearchType.Items.Add("Thời gian");
            cbSearchType.SelectedIndex = 0;
            tabPage1.Text = "Tìm kiếm";
            tabPage2.Text = "Chỉnh sửa";

        }
        
      
        void LoadDummyData()
        {
            allCustomers = Customer.GetCustomers();
            allTransactions = Transaction.GetTransaction(); 
            allAccounts = new List<Account>();
            allAccounts.Add(new Account("IT0001", allCustomers, allTransactions));
            allAccounts.Add(new Account("IT0002", allCustomers, allTransactions));
            allAccounts.Add(new Account("IT0003", allCustomers, allTransactions));
            allAccounts.Add(new Account("IT0004", allCustomers, allTransactions));
            allAccounts.Add(new Account("IT0005", allCustomers, allTransactions));
            allAccounts.Add(new Account("IT0006", allCustomers, allTransactions));
            allAccounts.Add(new Account("IT0007", allCustomers, allTransactions));
            allAccounts.Add(new Account("IT0008", allCustomers, allTransactions));
            // Đưa vào cây và hiển thị
            myBST = new BinarySearchTree();
            foreach (var acc in allAccounts) myBST.Insert(acc);
            dgvData.DataSource = allAccounts;

            //  Đổi tên cột hiển thị (Tiếng Việt)
            dgvData.Columns["AccountID"].HeaderText = "Số Tài khoản";
            dgvData.Columns["AccountName"].HeaderText = "Tên Tài khoản";
            dgvData.Columns["Balance"].HeaderText = "Số dư";
            dgvData.Columns["TransactionNum"].HeaderText = "Số giao dịch";
            dgvData.Columns["AccountDate"].HeaderText = "Ngày lập Tài khoản";

        }
       
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Lấy mục đang chọn
            string selected = cbSearchType.SelectedItem.ToString();
            if (selected == "Số Tài khoản")
            {
                lblInput.Text = "Nhập Số Tài khoản:";
                txtKeyword.Visible = true; 
                txtKeyword.Clear();  
                lblFrom.Visible = false;
                lblTo.Visible = false;
                dtpFrom.Visible = false;   
                dtpTo.Visible = false;  
            }
            else if (selected == "Tên Tài khoản")
            {
                lblInput.Text = "Nhập Tên Tài khoản:";
                txtKeyword.Visible = true;
                txtKeyword.Clear();
                lblFrom.Visible = false;  
                lblTo.Visible = false;
                dtpFrom.Visible = false;
                dtpTo.Visible = false;
               
            }
            if (selected == "Thời gian")
            {
                // HIỆN các thành phần liên quan đến ngày tháng
                lblFrom.Visible = true;  
                lblTo.Visible = true;
                dtpFrom.Visible = true;
                dtpTo.Visible = true;
                lblInput.Visible = false;
                txtKeyword.Visible = false;    
            }
            else
            {
                lblFrom.Visible = false; 
                lblTo.Visible = false; 
                dtpFrom.Visible = false;
                dtpTo.Visible = false;
                // HIỆN các thành phần tìm kiếm theo chữ
                lblInput.Visible = true;
                txtKeyword.Visible = true;
                lblInput.Text = "Nhập " + selected + ":";
            }
        }

        private void cbSearchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = cbSearchType.SelectedItem.ToString();

            if (selected == "Thời gian")
            {
                lblInput.Text = "Từ khoảng:";
                lblTo.Visible = true; 
                lblTo.Text = "Đến khoảng:";
                txtKeyword.Visible = false;
                dtpFrom.Visible = true;
                dtpTo.Visible = true;
            }
            else
            {
                lblInput.Text = "Nhập " + selected;
                lblTo.Visible = false;
                txtKeyword.Visible = true;
                dtpFrom.Visible = false;
                dtpTo.Visible = false;
            }
        }




        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Kiểm tra lựa chọn trong ComboBox
            if (cbSearchType.SelectedItem == null) return;
            string selected = cbSearchType.SelectedItem.ToString().Trim();

            // Gọi các hàm tìm kiếm của BST
            if (selected == "Số Tài khoản")
            {
                string id = txtKeyword.Text.Trim();
                // BST.SearchByID trả về 1 đối tượng đơn lẻ
                Account found = myBST.FindByAccountID(id);
                if (found != null)
                {
                    List<Account> res = new List<Account> { found };
                    HienThiLenLuoi(res);
                }
                else
                {
                    ThongBaoLoi();
                }
            }
            else if (selected == "Tên Tài khoản")
            {
                string name = txtKeyword.Text.Trim();
                // BST.SearchByName thường trả về 1 List vì tên có thể trùng
                List<Account> res = myBST.FindByName(name);
                HienThiLenLuoi(res);
            }
            else if (selected == "Thời gian")
            {
                DateTime start = dtpFrom.Value.Date;
                DateTime end = dtpTo.Value.Date;
                // BST.SearchByDateRange lọc các nút trong khoảng thời gian
                List<Account> res = myBST.FindByDateRange(start, end);
                HienThiLenLuoi(res);
            }
        }


        // Hàm hỗ trợ hiển thị
        private void HienThiLenLuoi(List<Account> data)
        {
            dgvData.DataSource = null;
            if (data != null && data.Count > 0)
            {
                dgvData.DataSource = data;
            }
            else
            {
                ThongBaoLoi();
            }
        }


        private void ThongBaoLoi()
        {
            MessageBox.Show("Không tìm thấy tài khoản nào!", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MainForm fMain = new MainForm("Admin");
            fMain.Show();
            this.Close();
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem người dùng có nhấn vào dòng dữ liệu không 
            if (e.RowIndex >= 0)
            {
                // 1. Lấy đối tượng Account từ dòng được chọn
                Account selectedAccount = dgvData.Rows[e.RowIndex].DataBoundItem as Account;
                if (selectedAccount != null)
                {
                    chitietTK frmChiTiet = new chitietTK(selectedAccount, allCustomers, allTransactions);
                    frmChiTiet.ShowDialog();
                }
            }
        }

        private bool CheckInput(string transactionID, string customerName, string iD, string phoneNumber, DateTime birthdate, string Email)
        {
            bool check = false;
            if (!(Regex.IsMatch(transactionID.Trim(), "^GD[0-9]{5}$")))
            {
                label20.Text = "Mã giao dịch phải bắt đầu bằng\n'GD' và 5 chữ số ở cuối";
                label2.Visible = true;
                return true;
            }
            else
            {
                if (allTransactions.Find(x => x.TransactionID.Equals(transactionID)) != null)
                {
                    label20.Text = "Mã giao dịch đã tồn tại,\nnhập lại mã giao dịch mới";
                    return true;
                }
            }

            //\p{L} khớp với tất cả các ký tự chữ (letter) trong bất kỳ bảng mã ngôn ngữ nào
            if (!(Regex.IsMatch(customerName.Trim(), @"^[\p{L}\s]+$")))
            {
                label20.Text = "Tên tài khoản không hợp lệ";
                label20.Visible = true;
                return true;
            }

            //Mã tài khoản là chuỗi gồm 7 kí tự
            if (!(Regex.IsMatch(iD.Trim(), @"^.{6}$")))
            {
                label20.Text = "Mã tài khoản phải là chuỗi 6 ký tự";
                label20.Visible = true;
                return true;
            }

            //SDT là chuỗi 10 chữ số 
            if (!(Regex.IsMatch(phoneNumber.Trim(), @"^[0-9]{10}$")))
            {
                label20.Text = "Số điện thoại phải là\nchuỗi 10 chữ số!";
                label20.Visible = true;
                return true;
            }

            //tuổi phải đủ 16
            if (DateTime.Now.CompareTo(birthdate.AddYears(16)) < 0)
            {
                label20.Text = "Khách hàng chưa đủ 16 tuổi\nđể mở tài khoản!";
                label20.Visible = true;
                return true;
            }

            //Email phải có dạng @gmail.com
            if (!(Regex.IsMatch(Email, @"^[a-zA-z0-9]{3,30}@gmail.com$")))
            {
                label20.Text = "Email không hợp lệ";
                label20.Visible = true;
                return true;
            }
            return check;

        }

        private void btnSearch1_Click(object sender, EventArgs e)
        {
            string searchID = txtSearchID.Text.Trim(); // Ô nhập số tài khoản

            // Tìm trong cây BST hoặc List tổng
            Account result = allAccounts.Find(x => x.AccountID == searchID);

            if (result != null)
            {
                // Gán dữ liệu vào các ô bên cạnh
                txtResName.Text = result.AccountName;       // Ô Tên TK
                txtResBalance.Text = result.Balance.ToString("N0"); // Ô Số dư (định dạng số)
                txtResTransNum.Text = result.TransactionNum.ToString(); // Ô Số giao dịch
                dtpResDate.Value = result.AccountDate;    // Ô Ngày lập
                MessageBox.Show("Đã tìm thấy và hiển thị thông tin!");
            }
            else
            {
                MessageBox.Show("Không tìm thấy số tài khoản này!");
            }
        }

        private void btnDelete1_Click(object sender, EventArgs e)
        {
            //Lấy mã tài khoản từ ô nhập liệu
            string idToDelete = txtSearchID.Text.Trim();

            if (string.IsNullOrEmpty(idToDelete))
            {
                MessageBox.Show("Vui lòng nhập số tài khoản cần xóa!");
                return;
            }

            // Tìm tài khoản trong danh sách allAccounts để xác nhận tồn tại
            Account accFound = allAccounts.Find(x => x.AccountID == idToDelete);
            if (accFound != null)
            {
                // Hỏi xác nhận trước khi xóa để tránh nhầm lẫn
                var confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa tài khoản {idToDelete}?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
                    //Xóa khỏi danh sách lưu trữ chính
                    allAccounts.Remove(accFound);
                    //Cập nhật lại cây BST 
                    myBST = new BinarySearchTree();
                    foreach (var acc in allAccounts)
                    {
                        myBST.Insert(acc);
                    }
                    // Cập nhật giao diện
                    UpdatePreview(); 
                    ClearDetailFields(); // Hàm phụ để xóa trắng các ô thông tin bên cạnh
                    MessageBox.Show("Đã xóa tài khoản thành công!");
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy tài khoản này để xóa!");
            }
        }

        private void ClearDetailFields()
        {
            txtSearchID.Clear();
            txtResName.Clear();     
            txtResBalance.Clear();       
            txtResTransNum.Clear();       
            dtpResDate.Value = DateTime.Now; // Đưa ngày về mặc định
        }
        private void UpdatePreview()
        {
            //Xóa nguồn dữ liệu cũ để tránh lỗi nạp chồng
            dgvPreview.DataSource = null;
            // Sử dụng danh sách allAccounts để hiển thị
            if (allAccounts != null && allAccounts.Count > 0)
            {
                // Sắp xếp danh sách theo AccountID để giống thứ tự cây nhị phân
                var danhSachHienThi = allAccounts.OrderBy(x => x.AccountID).ToList();
                dgvPreview.DataSource = danhSachHienThi;
                if (dgvPreview.Columns["Balance"] != null)
                {
                    dgvPreview.Columns["Balance"].DefaultCellStyle.Format = "N0";
                }
            }
        }

        private void btnAddNewAccount_Click(object sender, EventArgs e)
        {
            //Lấy dữ liệu từ giao diện
            string cccd = txtNewCCCD.Text.Trim();
            string tenTK = txtNewName.Text.Trim();
            string diaChi = txtNewAddress.Text.Trim();
            string sdt = txtNewPhone.Text.Trim();
            string email = txtNewEmail.Text.Trim();
            DateTime ngaySinh = dtpNewBirth.Value;
            string maGD = txtNewTransID.Text.Trim();
            string loaiGD = cboTransType.Text; 
            int soTien = (int)numAmount.Value; 
            DateTime ngayGD = dtpTransDate.Value;
            if (CheckInput(maGD, tenTK, cccd, sdt, ngaySinh, email))
            {
                return;
            }
            // Tạo các đối tượng mới
            // Tạo khách hàng mới
            Customer newCustomer = new Customer(cccd, tenTK, sdt, ngaySinh, diaChi, email, cccd);
            allCustomers.Add(newCustomer);
            // Tạo giao dịch đầu tiên cho tài khoản này
            Transaction newTrans = new Transaction(maGD, cccd, ngayGD, loaiGD, soTien);
            allTransactions.Add(newTrans);
            //  Tạo Tài khoản mới và chèn vào cây BST
            Account newAccount = new Account(cccd, allCustomers, allTransactions);
            allAccounts.Add(newAccount);
            myBST.Insert(newAccount);

            // Cập nhật giao diện và thông báo
            UpdatePreview(); 
            ClearAddFields(); 

            MessageBox.Show("Thêm tài khoản và giao dịch thành công!", "Thông báo");
        }

        private void ClearAddFields()
        {
            txtNewCCCD.Clear();
            txtNewName.Clear();
            txtNewAddress.Clear();
            txtNewPhone.Clear();
            txtNewEmail.Clear();
            txtNewTransID.Clear();
            numAmount.Value = 0;
            label20.Visible = false; 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Khởi tạo lại MainForm
            MainForm fMain = new MainForm("Admin");
            // Hiển thị MainForm lên
            fMain.Show();
            // Đóng Form hiện tại (Chitiethoso)
            this.Close();
        }
    }
}
