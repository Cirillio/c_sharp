using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumber.GameInterfaces
{
    internal interface IGame
    {
        public void SetupGame();
        public void PlayGame();
    }
}
