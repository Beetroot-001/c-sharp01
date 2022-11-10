using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class VoteOption
    {
        private string _optionName;
        private int _votesCount;
        private float _percentage;

        public VoteOption(string name)
        {
            _optionName = name;
        }

        public float Percentage
        {
            get => _percentage;
        }

        public void Vote()
        {
            _votesCount++;
        }

        public void SetPercentage(int allVotesCount)
        {
            _percentage = _votesCount / allVotesCount / 100;
        }

        public override string ToString()
        {
            return $"{_optionName} votes count: {_votesCount}, percentage: {_percentage}";
        }
    }
}
