using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiSXI
{
    public class BinaryTreeNode
    {
        public string Subscriber { get; set; }
        public int Phone_number { get; set; }
        public int Ads { get; set; }
        public double Score { get; set; }

        public BinaryTreeNode Left, Right, Parent;

        public BinaryTreeNode(string s)
        {
            string[] args = s.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            Subscriber = args[0];
            Phone_number = Convert.ToInt32(args[1]);
            Ads = Convert.ToInt32(args[2]);
            Score = Convert.ToDouble(args[3]);
            Left = null;
            Right = null;
        }

        public override string ToString()
        {
            return Subscriber + ' ' + Phone_number + ' ' + Ads + ' '  + Score;
        }
    }
}
