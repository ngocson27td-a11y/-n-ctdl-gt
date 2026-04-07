using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace đồ_án_ctdl_gt
{
    public partial class TaoTK : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);
        public TaoTK()
        {
            InitializeComponent();

        }
        private void Register(string username, string password)
        {
            // Thêm tài khoản mới vào danh sách Accounts của class SignInAccount
            SignInAccount.Accounts.Add((username, password));
        }


        private void btnRegister_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text.Trim();
            string pass = txtPass.Text.Trim();

            if (user == "" || pass == "")
            {
                missingValue.Text = "Vui lòng nhập đủ tên và mật khẩu";
                missingValue.Show();
                return;
            }

            if (txtConfirm.Text.Trim() == "1234")
            {
                if (SignInAccount.IsExists(user))
                {
                    MessageBox.Show("Tài khoản đã tồn tại!");
                    return;
                }
                // Thêm vào List
                SignInAccount.Accounts.Add((user, pass));
                MessageBox.Show("Đăng ký thành công!");
           
            }
            else
            {
                missingValue.Text = "Mã xác thực sai!";
                missingValue.Show();
            } 
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dangnhap f = new Dangnhap();
            f.ShowDialog();
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TaoTK_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            SendMessage(txtConfirm.Handle, 0x1501, 0, "Nhập \"1234\"");

        }
    }
    
}
