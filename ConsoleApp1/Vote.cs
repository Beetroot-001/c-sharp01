using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Vote : Base
    {
        public static List<Vote> votes  { get; set; } = new List<Vote>();
        public List<Question> Questions { get; set; } = new List<Question>();

        public Vote(string title)
        {
            Title = title;
        }
    }
}
