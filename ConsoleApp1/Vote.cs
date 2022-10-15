using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Vote
    {
        private string name;
        private Dictionary<int, string> answers = new Dictionary<int, string>();

        public Vote(string name, Dictionary<int, string> answers)
        {
            this.name = name;
            this.answers = answers;
        }
        

    }
}
