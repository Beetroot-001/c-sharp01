using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal interface IBuyer
    {
        public string Name { get; }
        public string PersonalInfo {get;}

        public void GetReceipt(IReceipt receipt);

        public void ShowBoughtProducts();
      

    }
}
