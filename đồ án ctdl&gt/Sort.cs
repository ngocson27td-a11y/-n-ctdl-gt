using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace đồ_án_ctdl_gt
{
    public partial class Sort : Form
    {
        BinarySearchTree myBST = new BinarySearchTree();
        List<Transaction> currentList = new List<Transaction>();
        List<Account> originalList = new List<Account>();
        public Sort()
        {
            InitializeComponent();
        }

        // Hàm bơm dữ liệu vào cây
        public void PumpDataToBST(int count)
        {
            myBST = new BinarySearchTree(); // Làm mới cây
            Random rand = new Random();
            for (int i = 0; i < count; i++)
            {
                //Tạo dữ liệu giả cho Account
                string maTK = "IT" + (1000 + i).ToString(); // Ví dụ: IT1000, IT1001...
                string TenTK = "User " + i.ToString();
                DateTime ngayTao = DateTime.Now.AddDays(-rand.Next(1, 1000)); // Ngày tạo ngẫu nhiên trong quá khứ
                int soDu = rand.Next(50000, 100000000); 
                // Tạo đối tượng Account mới (Đảm bảo Constructor của class Account khớp với thứ tự này)
                Account temp = new Account(maTK, TenTK, ngayTao, soDu);
                // Chèn vào cây (Lúc này hàm Insert trong BST phải nhận vào kiểu Account)
                myBST.Insert(temp);
            }
            MessageBox.Show($"Đã bơm {count} tài khoản vào cây!");
        }

        // Hàm chuyển dữ liệu từ cây sang List
        public List<Account> ConvertBSTToList()
        {
            List<Account> list = new List<Account>();
            DuyetCayLNR(myBST.root, list);
            return list;
        }


        // Hàm duyệt cây In-order (Trái - Gốc - Phải)
        private void DuyetCayLNR(Node node, List<Account> list)
        {
            if (node == null) return;
            DuyetCayLNR(node.Left, list);
            list.Add(node.AccountData); // Add Account vào list
            DuyetCayLNR(node.Right, list);
        }

        //  Hàm chuẩn bị dữ liệu cho 3 trường hợp
        private List<Account> GetScenarioData(string scenario, bool isAscending)
        {
            // Tạo bản sao để tránh hỏng dữ liệu gốc
            List<Account> data = new List<Account>(originalList);
            SortAlgorithms sa = new SortAlgorithms(); // Gọi class chứa thuật toán của bạn
            if (scenario == "Best")
            {
                if (isAscending)
                    sa.QuickSortAsc(data, 0, data.Count - 1);
                else
                    sa.QuickSortDesc(data, 0, data.Count - 1);
                return data;
            }
            else if (scenario == "Worst")
            {
                // Để tạo Worst Case, ta chủ động sắp xếp NGƯỢC lại 
                if (isAscending)
                    sa.QuickSortDesc(data, 0, data.Count - 1); 
                else
                    sa.QuickSortAsc(data, 0, data.Count - 1);
                return data;
            }
            // Average case: Giữ nguyên mảng ngẫu nhiên ban đầu
            return data;
        }

        private void sapxep_Click(object sender, EventArgs e)
        {
            if (originalList == null || originalList.Count == 0)
            {
                MessageBox.Show("Vui lòng nạp dữ liệu trước!");
                return;
            }
            if (cbthuattoan.SelectedItem == null || SortType.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn đủ Thuật toán và Kiểu sắp xếp!");
                return;
            }
            string selectedAlgo = cbthuattoan.SelectedItem.ToString();
            bool isAsc = (SortType.SelectedItem.ToString() == "Tăng dần");
            SortAlgorithms sa = new SortAlgorithms();
            // CHẠY SẮP XẾP VÀ HIỂN THỊ LÊN BẢNG CHÍNH (dgvNap) ---
            List<Account> displayData = new List<Account>(originalList);
            ExecuteSpecificSort(selectedAlgo, isAsc, displayData, sa);
            dgvNap.DataSource = null;
            dgvNap.DataSource = displayData;

            // ĐO THỜI GIAN 3 TRƯỜNG HỢP VÀ ĐỔ VÀO dgvtime ---
            DataTable dt = new DataTable();
            dt.Columns.Add("Trường hợp");
            dt.Columns.Add("Thời gian (ms)");

            string[] scenarios = { "Best", "Average", "Worst" };
            int iterations = 100; // Chạy 100 lần lấy trung bình cho mỗi trường hợp
            Timing time = new Timing();
            foreach (string scene in scenarios)
            {
                double totalMs = 0;
                for (int i = 0; i < iterations; i++)
                {
                    // Chuẩn bị dữ liệu 
                    List<Account> testData = GetScenarioData(scene, isAsc);
                    time.startTime(); // Gọi hàm của lớp Timing
                    ExecuteSpecificSort(selectedAlgo, isAsc, testData, sa);
                    time.StopTime(); // Gọi hàm của lớp Timing
                    totalMs += time.Result().TotalMilliseconds;
                }
                DataRow row = dt.NewRow();
                row["Trường hợp"] = scene;
                row["Thời gian (ms)"] = (totalMs / iterations).ToString("F4");
                dt.Rows.Add(row);
            }
            dgvtime.DataSource = dt;
            MessageBox.Show("Đã đo thời gian cho 3 trường hợp!");
        }

        // Hàm phụ để gọi đúng thuật toán tránh lặp lại code
        private void ExecuteSpecificSort(string algo, bool isAsc, List<Account> data, SortAlgorithms sa)
        {
            int n = data.Count;
            switch (algo)
            {
                case "Selection Sort":
                    if (isAsc) sa.SelectionSortAsc(data); else sa.SelectionSortDesc(data);
                    break;
                case "Bubble Sort":
                    if (isAsc) sa.BubbleSortAsc(data); else sa.BubbleSortDesc(data);
                    break;
                case "Insertion Sort":
                    if (isAsc) sa.InsertionSortAsc(data); else sa.InsertionSortDesc(data);
                    break;
                case "Quick Sort":
                    if (isAsc) sa.QuickSortAsc(data, 0, n - 1); else sa.QuickSortDesc(data, 0, n - 1);
                    break;
                case "Merge Sort":
                    if (isAsc) sa.MergeSortAsc(data, 0, n - 1); else sa.MergeSortDesc(data, 0, n - 1);
                    break;
                case "Heap Sort":
                    if (isAsc) sa.HeapSortAsc(data); else sa.HeapSortDesc(data);
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Nạp dữ liệu giả vào cây BST
            // Giả sử nạp 1000 mẫu dữ liệu
            PumpDataToBST(1000);
            // Chuyển dữ liệu từ cây sang List thông qua duyệt LNR
            originalList = ConvertBSTToList();
            // Lấy dữ liệu từ cây đổ ra danh sách
            originalList = ConvertBSTToList();
            // Hiển thị dữ liệu lên DataGridView
            dgvNap.DataSource = null; // Làm mới bảng
            dgvNap.DataSource = originalList; // Gán danh sách tài khoản vào bảng
            // Thông báo hoàn tất
            MessageBox.Show($"Đã hiển thị {originalList.Count} tài khoản lên bảng!");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            MainForm fMain = new MainForm("Admin");
            fMain.Show();
            this.Close();
        }
    }
}
