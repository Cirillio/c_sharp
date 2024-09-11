using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuessTheNumber.Output.Interfaces;

namespace GuessTheNumber.Output
{
    internal class OutPutConsole : IOutputMsg
    {

        public void Print(string msg)
        {
            Console.WriteLine(msg);
        }
        public void PrintError(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg);
            Console.ResetColor();
        }

        public void PrintClear() {
            Console.Clear();

        }
    }
}
