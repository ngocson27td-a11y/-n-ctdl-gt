using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace đồ_án_ctdl_gt
{
    public class Customer
    {
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Birthday { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string AccountID { get; set; }


        public Customer(string customerID, string customerName, string phoneNumber, DateTime birthday, string address, string email, string accountID)
        {
            CustomerID = customerID;
            CustomerName = customerName;
            PhoneNumber = phoneNumber;
            Birthday = birthday;
            Address = address;
            Email = email;
            AccountID = accountID;
        }

        public static List<Customer> GetCustomers()
        {
            List<Customer> customer = new List<Customer>();
            customer.Add(new Customer("IT0001", "Nguyễn Ngọc Sơn", "0348637100", new DateTime(2006, 03, 18), "Nguyễn Văn Đậu, Quận Bình Thạnh, TP.Hồ Chí Minh", "sonnguyen.31251026798@st.ueh.edu.vn", "IT0001"));
            customer.Add(new Customer("IT0002", "Mai Đinh Thế Anh", "0988155409", new DateTime(2006, 09, 06), "Linh Xuân, Quận Thủ Đức, TP.Hồ Chí Minh", "anhdinh.31251022162@st.ueh.edu.vn", "IT0002"));
            customer.Add(new Customer("IT0003", "Nguyễn Lê Minh Nghĩa", "0346789910", new DateTime(2006, 12, 05), "Phạm Văn Hai, Quận Tân Bình, TP.Hồ Chí Minh", "nghianguyen.31251024669@st.ueh.edu.vn", "IT0003"));
            customer.Add(new Customer("IT0004", "Nguyễn Chí Kiệt", "037941732", new DateTime(2006, 04, 24), "Nguyễn Văn Linh, Huyện Bình Chánh, TP.Hồ Chí Minh", "kietchi.31251026739@st.ueh.edu.vn", "IT0004"));
            customer.Add(new Customer("IT0005", "Huỳnh Châu Gia Hưng", "0935594813", new DateTime(2006, 03, 18), "Nguyễn Văn Đậu, Quận Bình Thạnh, TP.Hồ Chí Minh", "hunghuynh.31251026688@st.ueh.edu.vn", "IT0005"));
            customer.Add(new Customer("IT0006", "Lê Đỗ Anh Khoa", "0902159560", new DateTime(2006, 09, 06), "Linh Xuân, Quận Thủ Đức, TP.Hồ Chí Minh", "khoaanh.31251022162@st.ueh.edu.vn", "IT0006"));
            customer.Add(new Customer("IT0007", "Nguyễn Thị Phương Thảo", "0774807235", new DateTime(2006, 12, 05), "Phạm Văn Hai, Quận Tân Bình, TP.Hồ Chí Minh", "thaophuong.31251022345@st.ueh.edu.vn", "IT0007"));
            customer.Add(new Customer("IT0008", "Nguyễn Nữ My Na", "0983841732", new DateTime(2006, 04, 24), "Nguyễn Văn Linh, Huyện Bình Chánh, TP.Hồ Chí Minh", "namy.31251025839@st.ueh.edu.vn", "IT0008"));
            return customer;
        }

        //Tìm tên
        public static string FindName(string accountID, List<Customer> customers)
        {
            foreach (Customer customer in customers)
            {
                if (customer.AccountID == accountID)
                {
                    return customer.CustomerName;
                }
            }
            return null;
        }

        //Tìm thông tin
        public static Customer FindInfo(string accountID, List<Customer> customers)
        {
            foreach (Customer customer in customers)
            {
                if (customer.AccountID == accountID)
                {
                    return customer;
                }
            }
            return null;
        }

        //Cập nhật thông tin
        public static void Update(string customerID, string name, DateTime birth, string phone, string address, string email, List<Customer> list)
        {
            Customer customer = FindInfo(customerID, list);
            customer.CustomerName = name;
            customer.Address = address;
            customer.Email = email;
            customer.Birthday = birth;
            customer.PhoneNumber = phone;
            list.Remove(customer);
            list.Add(customer);
        }
    }
}

