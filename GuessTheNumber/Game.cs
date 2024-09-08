using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumber
{
    internal class Game
    {
        public GameParams GameParams { get; private set; }
        private bool _gameIsSetUp { get; set; }
        public Game()
        {
            _gameIsSetUp = false;
            GameParams = new GameParams();
        }
        public void PlayGame()
        {
            if (Convert.ToBoolean(GameParams.SetGameParams()))
            {
                _gameIsSetUp = true;
                Console.WriteLine("Игра началась");
            }
        }
    }
}



