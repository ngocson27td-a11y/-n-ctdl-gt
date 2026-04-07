using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace đồ_án_ctdl_gt
{
    public class Transaction
    {
        public string TransactionID { get; set; }
        public string Account { get; set; }
        public DateTime TransactionDate { get; set; }
        public string TransactionType { get; set; }
        public int Amount { get; set; }

        public Transaction(string transactionID, string account, DateTime transactionDate, string transactionType, int amount)
        {
            TransactionID = transactionID;
            Account = account;
            TransactionDate = transactionDate;
            TransactionType = transactionType;
            Amount = amount;
        }
        public static List<Transaction> GetTransaction()
        {
            List<Transaction> transactions = new List<Transaction>();
            transactions.Add(new Transaction("GD00001", "IT0001", new DateTime(2026, 07, 27, 08, 19, 22), " Nhận tiền", 750000));
            transactions.Add(new Transaction("GD00002", "IT0002", new DateTime(2026, 09, 25, 12, 15, 10), " Nhận tiền", 500000));
            transactions.Add(new Transaction("GD00003", "IT0003", new DateTime(2026, 05, 19, 19, 26, 11), " Nhận tiền", 30000));
            transactions.Add(new Transaction("GD00004", "IT0004", new DateTime(2026, 03, 29, 09, 47, 5), " Chuyển tiền", 12000));
            transactions.Add(new Transaction("GD00005", "IT0005", new DateTime(2026, 01, 04, 08, 19, 22), " Chuyển tiền", 50000));
            transactions.Add(new Transaction("GD00006", "IT0006", new DateTime(2026, 04, 09, 12, 15, 10), " Chuyển tiền", 100000));
            transactions.Add(new Transaction("GD00007", "IT0004", new DateTime(2026, 08, 10, 09, 47, 5), " Nhận tiền", 250000));
            transactions.Add(new Transaction("GD00008", "IT0005", new DateTime(2026, 02, 23, 10, 27, 31), " Nhận tiền", 600000));
            transactions.Add(new Transaction("GD00005", "IT0007", new DateTime(2026, 05, 17, 08, 19, 22), " Chuyển tiền", 90000));
            transactions.Add(new Transaction("GD00006", "IT0002", new DateTime(2026, 11, 05, 12, 15, 10), " Chuyển tiền", 100000));
            transactions.Add(new Transaction("GD00007", "IT0008", new DateTime(2026, 09, 09, 09, 47, 5), " Nhận tiền", 300000));
            transactions.Add(new Transaction("GD00008", "IT0001", new DateTime(2026, 07, 01, 10, 27, 31), " Nhận tiền", 200000));
            return transactions;
        }

        public static List<(DateTime, string, int)> FindTransInfo(string AccountID, List<Transaction> infolist)
        {
            List<Transaction> info = GetTransactionsInfo(AccountID, infolist);
            var result = new List<(DateTime, string, int)>();
            foreach (var i in info)
            {
                result.Add((i.TransactionDate, i.TransactionType, i.Amount));
            }
            return result;
        }
        public static List<Transaction> GetTransactionsInfo(string AccountID, List<Transaction> info)
        {
            List<Transaction> transactions = new List<Transaction>();
            foreach (Transaction transaction in info)
            {
                if (transaction.Account.Equals(AccountID))
                {
                    transactions.Add(transaction);
                }
            }
            return transactions;
        }
    }

}
