using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal interface IBuyer
    {
        string Name { get; }
        string PersonalInfo {get;}

        void GetReceipt(IReceipt receipt);

        void ShowBoughtProducts();
      

    }
}
