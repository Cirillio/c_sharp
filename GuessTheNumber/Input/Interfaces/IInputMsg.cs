﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumber.Input.Interfaces
{
    internal interface IInputMsg
    {
        public string? Input();

        public ConsoleKeyInfo Press();
    }
}
