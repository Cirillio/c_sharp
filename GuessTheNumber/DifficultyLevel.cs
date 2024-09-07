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
        private static int _nextID = 1;
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

        public DifficultyLevel(string name, int attempts, int clues)
        {
            DifficultyID = _nextID++;
            Name = name;
            Attempts = attempts;
            Clues = clues;
        }

        public void SetDifficulty(int DifficultyID)
        {
            switch(DifficultyID)
            {
                case 1:
                    this.Name = "Easy";
                    this.Attempts = 100;
                    this.Clues = 50;
                    break;

                case 2:
                    this.Name = "Medium";
                    this.Attempts = 25;
                    this.Clues = 5;
                    break;

                case 3:
                    this.Name = "Hard";
                    this.Attempts = 10;
                    this.Clues = 1;
                    break;
                default:
                    break;
            }
        }


    }
}


//                    
