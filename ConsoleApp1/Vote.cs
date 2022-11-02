using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Vote : Base
    {   
        public List<Question> Questions { get; set; } = new List<Question>();

        public Vote(string title)
        {
            Title = title;
        }       
    }
}
