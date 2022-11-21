using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace sbas_homework_28_Entity_Framework
{
    internal class Product
    {
        public Guid ProductId { get; set; }
        public string Data { get; set; }
        public float Prise { get; set; }

    }
}
