using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace đồ_án_ctdl_gt
{
    public class AccountNode
    {
        public string Username;
        public string Password;
        public AccountNode Left;
        public AccountNode Right;

        public AccountNode(string user, string pass)
        {
            Username = user;
            Password = pass;
            Left = null;
            Right = null;
        }
    }
    public static class SignInAccount
    {
        // Sử dụng List (Tuple) để lưu trữ tài khoản trong RAM
        public static List<(string Username, string Password)> Accounts = new List<(string, string)>
    {
         // Tài khoản mặc định
        ("admin", "123")
    };

        // Hàm kiểm tra đăng nhập 
        public static bool CheckLogin(string user, string pass)
        {
            // Duyệt danh sách để tìm tài khoản khớp
            foreach (var acc in Accounts)
            {
                if (acc.Username == user && acc.Password == pass)
                    return true;
            }
            return false;
        }

        public static bool IsExists(string user)
        {
            foreach (var acc in Accounts)
            {
                if (acc.Username == user) return true;
            }
            return false;
        }

    }
}
