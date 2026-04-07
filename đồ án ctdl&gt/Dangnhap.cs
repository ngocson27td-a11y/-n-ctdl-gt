using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace đồ_án_ctdl_gt
{
    public partial class Dangnhap : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);
        public Dangnhap()
        {
            InitializeComponent();

        }

        private void Dangnhap_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            AutoCompleteStringCollection data = new AutoCompleteStringCollection();
            txtUser.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtUser.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtUser.AutoCompleteCustomSource = data;
            SendMessage(txtUser.Handle, 0x1501, 0, " \"admin\"");
            SendMessage(txtPass.Handle, 0x1501, 0, "\"123\"");

        }
        private void AddUsernamesToAutocomplete(AccountNode node, AutoCompleteStringCollection data)
        {
            if (node == null) return;
            AddUsernamesToAutocomplete(node.Left, data);
            data.Add(node.Username);
            AddUsernamesToAutocomplete(node.Right, data);
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text.Trim();
            string pass = txtPass.Text;

            if (SignInAccount.CheckLogin(user, pass))
            {
                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Mở form chính
                MainForm main = new MainForm(user);
                main.Show();
                // Ẩn form đăng nhập
                this.Hide();
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            TaoTK f = new TaoTK();
            f.ShowDialog();
            

        }
    }
}
