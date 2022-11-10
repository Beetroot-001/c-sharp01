using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Vote
    {
        private string _title;
        private List<VoteOption> _options;
        private int _votesCount;

        public Vote(string title = "standart title")
        {
            _title = title;
            _options = new List<VoteOption>();
            _votesCount = 0;
        }

        public void VoteMethod(int optionNum)
        {
            if (optionNum < 0 || optionNum >= _options.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            _votesCount++;
            _options[optionNum].Vote();
            _options[optionNum].SetPercentage(_votesCount);
        }

        public List<VoteOption> Options => _options;

        public override string ToString()
        {
            return _title;
        }
    }
}
