using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumber.Output.Interfaces
{
    internal interface IOutputMsg
    {
        void Print(string msg) { }
        void PrintError(string msg) { }

    }
}
