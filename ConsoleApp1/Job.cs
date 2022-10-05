using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    public class Job
    {
        private Status status;
        private DateTime startTime;
        private DateTime finishTime;
        private Task task;

        public Status Status
        {
            get => status;
            set
            {
                this.status = value;
            }
        }

        public Task Task
        {
            get => task;
            set
            {
                this.task = value;
            }
        }
    }
}