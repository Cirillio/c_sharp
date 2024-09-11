using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuessTheNumber.Output;
using GuessTheNumber.Input;

namespace GuessTheNumber
{
    internal class Game
    {
        public OutPutConsole? Print = new OutPutConsole();
        public InputConsole? Input = new InputConsole();
        public GameParams GameParams { get; private set; }
        private bool GameIsSetUp { get; set; }
        public Game()
        {
            GameIsSetUp = false;
            GameParams = new GameParams();
        }
        public void PlayGame()
        {
            GameParams.InputParams();
            GameIsSetUp = GameParams.CheckParamInputs();
            if (GameIsSetUp)
            {
                Print?.PrintClear();
                Print?.Print("Игра началась!");
                Print?.Print("Попробуй отгадать!");
                Print?.Print($"Начальная граница: {GameParams.FirstBorder}\n" +
                    $"Конечная граница: {GameParams.SecondBorder}");
            }
        }
    }
}



