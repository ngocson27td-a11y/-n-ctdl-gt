using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace đồ_án_ctdl_gt
{
    public class Account
    {
        public string AccountID { get; set; }
        public string AccountName { get; set; }
        public double Balance { get; set; } = 0;
        public int TransactionNum { get; set; } = 0;
        public DateTime AccountDate { get; set; }

        public Account(string accountID, string accountName, DateTime accountDate, double balance)
        {
            AccountID = accountID;
            AccountName = accountName;
            AccountDate = accountDate;
            Balance = balance;
            TransactionNum = 0; 
        }

        public Account(string accountID, List<Customer> customers, List<Transaction> transactions)
        {
            AccountID = accountID;
            // Tìm tên từ danh sách customers truyền vào
            AccountName = Customer.FindName(accountID, customers);

            List<(DateTime, string, int)> TransInfo = Transaction.FindTransInfo(accountID, transactions);

            // Kiểm tra nếu có giao dịch thì mới tính toán
            if (TransInfo != null && TransInfo.Count > 0)
            {
                AccountDate = TransInfo[0].Item1;
                for (int i = 0; i < TransInfo.Count; i++)
                {
                    TransactionNum++;
                    // So sánh để lấy ngày giao dịch đầu tiên làm ngày tạo
                    if (AccountDate.CompareTo(TransInfo[i].Item1) > 0)
                    {
                        AccountDate = TransInfo[i].Item1;
                    }
                    if (TransInfo[i].Item2.Trim().Equals("Nhận tiền"))
                    {
                        Balance += TransInfo[i].Item3;
                    }
                    else
                    {
                        Balance -= TransInfo[i].Item3;
                    }
                }
            }
            else
            {
                // Mặc định nếu không có giao dịch
                AccountDate = DateTime.Now;
                Balance = 0;
                TransactionNum = 0;
            }
        }

        // Thêm constructor rỗng để không bị lỗi ở các chỗ nạp dữ liệu cũ
        public Account() { }  
        
        public void Refresh(List<Transaction> transactions)
        {
            TransactionNum = 0;
            Balance = 0;
            List<(DateTime, string, int)> TransInfo = Transaction.FindTransInfo(AccountID, transactions);
            foreach (var item in TransInfo)
            {
                TransactionNum++;
                if (item.Item2.Trim().Equals("Nhận tiền")) Balance += item.Item3;
                else Balance -= item.Item3;
            }
        }

        public void Refresh(string accountid, List<Customer> customers)
        {
            AccountName = Customer.FindName(accountid, customers);
        }
        }
    }

