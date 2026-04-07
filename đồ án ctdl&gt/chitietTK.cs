using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;


namespace đồ_án_ctdl_gt
{
    public partial class chitietTK : Form
    {
        public static List<Customer> Customers;
        public static Account accountFound;
        public chitietTK()
        {
            InitializeComponent();   
        }

        public chitietTK(Account account, List<Customer> customers, List<Transaction> transactions)
        {
            InitializeComponent();
            Customers = customers;
            accountFound = account;
            tenTK.ReadOnly = true;
            SDT.ReadOnly = true;
            Email.ReadOnly = true;
            DiaChi.ReadOnly = true;
            Birth.Enabled = false; 
            solanGD.ReadOnly = true;
            soduTK.ReadOnly = true;
            NgaytaoTK.Enabled = false;

            soTK.Text = account.AccountID;
            tenTK.Text = account.AccountName;
            soduTK.Text = account.Balance.ToString("N0"); // Định dạng 400,000

            // Hiển thị số lần giao dịch và ngày tạo
            solanGD.Text = account.TransactionNum.ToString();
            NgaytaoTK.Value = account.AccountDate; 
            var customerInfo = Customer.FindInfo(account.AccountID, customers);
            if (customerInfo != null)
            {
                Birth.Value = customerInfo.Birthday;
                SDT.Text = customerInfo.PhoneNumber;
                Email.Text = customerInfo.Email;
                DiaChi.Text = customerInfo.Address;
            }
            else
            {
                SDT.Text = "N/A";
                Email.Text = "N/A";
                DiaChi.Text = "N/A";
            }
            //Lịch sử giao dịch 
            var filteredTransactions = Transaction.GetTransactionsInfo(account.AccountID, transactions);
            AddTransaction(filteredTransactions);
        }
        public void AddTransaction(List<Transaction> transactions)
        {
            dgvHistory.DataSource = null; // Xóa dữ liệu cũ
            if (transactions != null && transactions.Count > 0)
            {
                dgvHistory.DataSource = transactions;
                dgvHistory.Columns["Amount"].DefaultCellStyle.Format = "N0";
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        { 
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            tenTK.ReadOnly = false;
            SDT.ReadOnly = false;
            Email.ReadOnly = false;
            DiaChi.ReadOnly = false;
            NgaytaoTK.Enabled = true;
            Birth.Enabled = true;
            solanGD.ReadOnly = false;
            soduTK.ReadOnly = false;
            // Thay đổi màu nền để báo hiệu đang ở chế độ sửa
            tenTK.BackColor = Color.White;
            btnEdit.BackColor = Color.LightYellow;
        }

        private void update_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu đầu vào
            if (CheckUpdate(tenTK.Text.Trim(), Birth.Value, SDT.Text.Trim(), Email.Text.Trim()))
            {
                return; // Nếu có lỗi thì dừng lại
            }
            try
            {
                // Gọi hàm Update trong class Customer
                Customer.Update(soTK.Text.Trim(), tenTK.Text.Trim(), Birth.Value, SDT.Text.Trim(), DiaChi.Text.Trim(), Email.Text.Trim(), Customers);
                // Làm mới lại thông tin Account hiện tại
                accountFound.AccountName = tenTK.Text.Trim();
                accountFound.Refresh(soTK.Text.Trim(), Customers);
                // Khóa các ô nhập liệu lại
                tenTK.ReadOnly = true;
                SDT.ReadOnly = true;
                Email.ReadOnly = true;
                DiaChi.ReadOnly = true;
                Birth.Enabled = false;
                solanGD.ReadOnly = true;
                btnEdit.BackColor = SystemColors.Control;
                MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                label12.Visible = false; 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        
        private bool CheckUpdate(string customerName, DateTime birthdate, string phoneNumber, string Email)
        {
            bool check = false;
            if (!(Regex.IsMatch(customerName.Trim(), @"^[\p{L}\s]+$")))
            {
                label12.Text = "Tên tài khoản không hợp lệ";
                label12.Visible = true;
                return true;
            }
            //tuổi phải đủ 16
            if (DateTime.Now.CompareTo(birthdate.AddYears(16)) < 0)
            {
                label12.Text = "Khách hàng chưa đủ 16 tuổi\nđể mở tài khoản!";
                label12.Visible = true;
                return true;
            }
            //SDT là chuỗi 10 chữ số không được trùng
            if (!(Regex.IsMatch(phoneNumber.Trim(), @"^[0-9]{10}$")))
            {
                label12.Text = "Số điện thoại phải là\nchuỗi 10 chữ số!";
                label12.Visible = true;
                return true;
            }
            if (!(Regex.IsMatch(Email, @"^[a-zA-Z0-9._%+-]{3,64}@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")))
            {
                label12.Text = "Email không hợp lệ";
                label12.Visible = true;
                return true;
            }
            return check;
        }
    }
}

