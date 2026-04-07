using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace đồ_án_ctdl_gt
{
    internal class Node
    {
        public Account AccountData { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node(Account account)
        {
            AccountData = account;
            Left = Right = null;
        }
    }
}
