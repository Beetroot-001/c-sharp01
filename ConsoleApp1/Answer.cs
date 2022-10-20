using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Answer : Base
    {
        public int Count { get; set; }
        
        public Answer(string title)
        {
            Title = title;
        }
    }
}
