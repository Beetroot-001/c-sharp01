using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class GetsID
    {
        static public int Id { get; private set; } = 1;
        
        static public int GetID()
        {
            return Id += 1;
        }
        
    }
}
