using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumber
{
    internal class GameParams
    {
        public int FirstBorder { get; set; }
        public int SecondBorder { get; set; }
        public DifficultyLevel? GameDifficulty { get; private set; }

        public GameParams()
        {
            FirstBorder = 1;
            SecondBorder = 100;
            GameDifficulty = new DifficultyLevel(1); // легкий уровень по дефолту

        }

        public int SetGameParams()
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Укажите первую границу:");
                    FirstBorder = Convert.ToInt32(Console.ReadLine()); // 100
                    Console.WriteLine("Укажите вторую границу:");
                    SecondBorder = Convert.ToInt32(Console.ReadLine()); // -100

                    if (FirstBorder > SecondBorder)
                    {
                        (SecondBorder, FirstBorder) = (FirstBorder, SecondBorder);
                    }
                    else if (FirstBorder == SecondBorder)
                    {
                        throw new ArgumentException("Значения границ должны различаться.");
                    }

                    Console.WriteLine("Укажите сложность игры.\n" +
                    "1 - Легкая | 100 попыток | 50 подсказок\n" +
                    "2 - Средняя | 25 попыток | 5 подсказок\n" +
                    "3 - Харкор | 10 попыток | 1 подсказка");

                    GameDifficulty = new DifficultyLevel(Convert.ToInt32(Console.ReadLine()));

                    return 1;
                }
                catch (Exception error)
                {
                    Console.WriteLine($"Произошла ошибка: {error.Message}\nПовторите попытку.");
                }
            }

        }

    }
}
