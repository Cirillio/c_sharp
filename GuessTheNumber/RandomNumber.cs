using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuessTheNumber.GameInterfaces;

namespace GuessTheNumber
{
    internal class RandomNumber : IRandomNumber
    {
        public int GetRandomNumber(IGameParams _parameters)
        {
            return Random.Shared.Next(_parameters.minNum, _parameters.maxNum+1);
        }
    }
}
