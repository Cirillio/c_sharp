using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumber
{
    internal class Game
    {
        public int MinNumber { get; set; }
        public int MaxNumber { get; set; }

        public DifficultyLevel GameDifficulty = new();

        public Game()
        {
            MinNumber = 1;
            MaxNumber = 100;
        }

        public bool StartGame()
        {
            while (true)
            {
                Console.WriteLine("Укажите минимальное число:");
                int MinNum = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Укажите максимальное число:");
                int MaxNum = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Укажите сложность игры.\n1 - Легкая | 100 попыток | 50 подсказок\n2 - Средняя | 25 попыток | 5 подсказок\n 3 - Харкор | 10 попыток | 1 подсказка");
                string GameDifficultyID = Console.ReadLine();
                int DifficultyID;
                try
                {
                    DifficultyID = Convert.ToInt32(GameDifficultyID);
                    if (DifficultyID < 1 || DifficultyID > 3)
                    {
                        throw new InvalidOperationException("Неверный выбор.");
                    }
                    this.SetParameters(MaxNum, MinNum, DifficultyID);
                    return false;
                }
                catch (Exception error)
                {
                    Console.WriteLine($"Произошла ошибка: {error.Message}\nПовторите попытку.");
                }

            }
        }

        public void SetParameters(int maxNumber, int minNumber, int Difficulty)
        {
            this.MaxNumber = maxNumber;
            this.MinNumber = minNumber;
            switch (Difficulty)
            {
                case 1:
                    this.GameDifficulty.SetDifficulty(Difficulty);
                    break;
                case 2:
                    this.GameDifficulty.SetDifficulty(Difficulty);
                    break;
                case 3:
                    this.GameDifficulty.SetDifficulty(Difficulty);
                    break;
                default:
                    break;
            }
        }

    }
}
