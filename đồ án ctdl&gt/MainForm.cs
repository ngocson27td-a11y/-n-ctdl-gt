using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace đồ_án_ctdl_gt
{
    public partial class MainForm : Form
    {
        string username;
        public MainForm(string user)
        {
            InitializeComponent();
            username = user;
            this.Load += MainForm_Load;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lblUser.Text = "Xin chào " + username +"!";
        }

        private void btnDangxuat_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo);

            if (r == DialogResult.Yes)
            {
                Dangnhap f = new Dangnhap();
                f.Show();
                this.Close();
            }
        }

        private void btnQLTK_Click(object sender, EventArgs e)
        {
            Chitiethoso f = new Chitiethoso();
            //  Hiển thị Form đó lên
            f.Show();
            this.Hide();
        }

        private void btnQLGD_Click(object sender, EventArgs e)
        {
            QuanlyGD formGD = new QuanlyGD();
            formGD.Show();
        }

        private void btnQLTK_Click_1(object sender, EventArgs e)
        {
            Chitiethoso f = new Chitiethoso();
               f.Show();
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            Sort f = new Sort();
            f.Show();

        }
    }
}
