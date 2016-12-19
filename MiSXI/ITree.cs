using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiSXI
{
    public interface ITree
    {
        void Add(string s);
        void Delete(object obj);
        string Find(object obj);
    }
}
