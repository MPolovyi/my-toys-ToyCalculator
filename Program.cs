using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            string line = " ";
            Parser parser = new Parser();
            while (!exit)
            {
                line = Console.ReadLine();
                parser.TryParse(line);
                Console.WriteLine(parser.Result);
                exit = true;
            }
            Console.ReadKey();
        }
    }
}
