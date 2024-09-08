using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumber
{
    internal class DifficultyLevel
    {
        public int DifficultyID { get; set; }
        public string Name { get; set; }
        public int Attempts { get; set; }
        public int Clues { get; set; }

        public DifficultyLevel()
        {
            DifficultyID = 1;
            Name = "Easy";
            Attempts = 100;
            Clues = 50;
        }

        public DifficultyLevel(int difficultyID)
        {
            switch (difficultyID)
            {
                case 1:
                    DifficultyID = 1;
                    Name = "Easy";
                    Attempts = 100;
                    Clues = 50;
                    break;

                case 2:
                    DifficultyID = 2;
                    Name = "Medium";
                    Attempts = 25;
                    Clues = 5;
                    break;

                case 3:
                    DifficultyID = 3;
                    Name = "Hard";
                    Attempts = 10;
                    Clues = 1;
                    break;

                default:
                    throw new InvalidOperationException("Неверный выбор сложности.");
            }
        }
    }
}