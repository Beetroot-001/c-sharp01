using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Question : Base
    {
        public List<Answer> Answers { get; set; } = new List<Answer>();

        public Question(string title)
        {
            Title = title;
        }
    }
}
