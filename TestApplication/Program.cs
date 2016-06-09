using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var warning = dwdWarnings.Warnings.GetWarningsById(109172000);
            Console.Read();
        }
    }
}
