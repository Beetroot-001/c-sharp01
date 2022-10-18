using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Answer
    {
        public string Data { get; private set; }
        public int Count { get; private set; }

        public Answer(string textQuestion)
        {
            this.Data = textQuestion;
            this.Count = 0;
        }

        /// <summary>
        /// Increases the count by one
        /// </summary>
        public void IncreaseCount() => this.Count++;


        /// <summary>
        /// Resets Count. Count = 0;
        /// </summary>
        public void ResetCount() => this.Count = 0;

        public void ReName(string newName) => this.Data = newName;

    }
}
