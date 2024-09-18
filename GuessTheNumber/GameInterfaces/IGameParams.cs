using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumber.GameInterfaces
{
    internal interface IGameParams
    {
        public int minNum { get; set; }

        public int maxNum { get; set; }

        public int difficultyLevel { get; set; }

        public int attempts { get; set; }

        public int clues { get; set; }

        public void SetParams();

        public int InputParam(string msg);

    }
}
