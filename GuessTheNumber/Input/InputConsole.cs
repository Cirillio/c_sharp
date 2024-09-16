using GuessTheNumber.Input.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumber.Input
{
    internal class InputConsole : IInputMsg
    {
        public string? Input()
        {
            return Console.ReadLine();
        }
    }
}
