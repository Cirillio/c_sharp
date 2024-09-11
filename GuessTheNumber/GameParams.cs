using GuessTheNumber.Output;
using GuessTheNumber.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace GuessTheNumber
{
    internal class GameParams

    {
        public double FirstBorder { get; set; }
        public double SecondBorder { get; set; }
        public DifficultyLevel? GameDifficulty { get; private set; }

        public OutPutConsole? Print = new OutPutConsole();
        public InputConsole? Input = new InputConsole();

        private string?[] TmpValues = new string[3];

        public GameParams()
        {
            FirstBorder = 1;
            SecondBorder = 100;
            GameDifficulty = new DifficultyLevel(1); // легкий уровень по дефолту
        }

        public void InputParams(int wtd = 0)
        {
            switch (wtd)
            {
                case 1:
                    Print?.Print("Введите первую границу: ");
                    TmpValues[0] = Input?.Input();
                    break;

                case 2:
                    Print?.Print("Введите вторую границу:");
                    TmpValues[1] = Input?.Input();
                    break;

                case 3:
                    Print?.Print("Укажите сложность игры.\n" +
                        "1 - Легкая | 100 попыток | 50 подсказок\n" +
                        "2 - Средняя | 25 попыток | 5 подсказок\n" +
                        "3 - Хардкор | 10 попыток | 1 подсказка");
                    TmpValues[2] = Input?.Input();
                    break;

                default:
                    Print?.Print("Введите первую границу: ");
                    TmpValues[0] = Input?.Input();
                    Print?.Print("Введите вторую границу:");
                    TmpValues[1] = Input?.Input();
                    Print?.Print("Укажите сложность игры.\n" +
                        "1 - Легкая | 100 попыток | 50 подсказок\n" +
                        "2 - Средняя | 25 попыток | 5 подсказок\n" +
                        "3 - Хардкор | 10 попыток | 1 подсказка");
                    TmpValues[2] = Input?.Input();
                    break;
            }
        }

        public bool CheckParamInputs()
        {
            Print?.Print("Нажмите 'Enter' для продолжения");
            ConsoleKeyInfo OK;
            while (true) {
            OK = Console.ReadKey();
                if (OK.Key == ConsoleKey.Enter) {
                    break;
                } else {
                    Print?.PrintError("Нажмите 'Enter' для продолжения");
                }
            }

            for (int i = 1; i < 4; i++)
            {
                try
                {
                    switch (i)
                    {
                        case 1:
                            FirstBorder = Convert.ToDouble(TmpValues[i-1]);
                            break;

                        case 2:
                            SecondBorder = Convert.ToDouble(TmpValues[i-1]);
                            break;

                        case 3:
                            GameDifficulty = new DifficultyLevel(Convert.ToInt32(TmpValues[i-1]));
                            break;

                        default: break;
                    };
                }
                catch (Exception)
                {
                    Print?.PrintError("Введите правильное значение");
                    InputParams(i);
                    i = 1;
                }
            }
            if (FirstBorder == SecondBorder)
            {
                Print?.Print("Границы не должны быть равны\n1 - Изменить первую границу.\n2 - Изменить вторую границу.");
            }
            while (FirstBorder == SecondBorder) {
                try {
                    ConsoleKeyInfo ChangeBorder = Console.ReadKey();
                    switch (ChangeBorder.Key)
                    {
                        case ConsoleKey.D1:
                            InputParams(1);
                            FirstBorder = Convert.ToDouble(TmpValues[0]);
                            break;
                        case ConsoleKey.D2:
                            InputParams(2);
                            SecondBorder = Convert.ToDouble(TmpValues[1]);
                            break;
                        default:
                            continue;
                    }
                }
                catch (Exception error) {
                    Print?.Print(error.Message);
                }
            }
            if (FirstBorder > SecondBorder)
            {
                (FirstBorder, SecondBorder) = (SecondBorder, FirstBorder);
            }
            return true;
        }
    }
}