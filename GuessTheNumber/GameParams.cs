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

        private void PrintWelcome()
        {
            Print?.Print("Нажмите 'Enter' для продолжения");
            ConsoleKeyInfo OK;
            while (true)
            {
                OK = Console.ReadKey();
                if (OK.Key == ConsoleKey.Enter)
                {
                    break;
                }
                else
                {
                    Print?.PrintError("Нажмите 'Enter' для продолжения");
                }
            }
        }

        private double GetValidBorder(int index)
        {
            while (true)
            {
                try
                {
                    return Convert.ToDouble(TmpValues[index - 1]);
                }
                catch (Exception)
                {
                    Print?.PrintError("Введите правильное значение");
                    InputParams(index);
                }
            }
        }

        private int GetValidDifficulty(int index)
        {
            while (true)
            {
                try
                {
                    int Diff = Convert.ToInt32(TmpValues[index - 1]);
                    DifficultyLevel tmp = new DifficultyLevel(Diff);
                    return Diff;
                }
                catch (Exception)
                {
                    Print?.PrintError("Введите правильное значение");
                    InputParams(index);
                }
            }
        }

        private void ValidateBorders(double first, double second)

        {
            if (first == second)

            {
                Print?.Print("Границы не должны быть равными. Попробуйте ещё раз.");

                HandleBorderChange();
            }

            if (first > second)

            {
                (first, second) = (second, first);
            }
        }

        private void HandleBorderChange()
        {
            while (true)
            {
                Print?.Print("1 - Изменить первую границу.\n2 - Изменить вторую границу.");
                try
                {
                    ConsoleKeyInfo ChangeBorder = Console.ReadKey();
                    Print?.Print("\n");
                    switch (ChangeBorder.Key)

                    {
                        case ConsoleKey.D1:
                            InputParams(1);
                            FirstBorder = GetValidBorder(1);
                            break;

                        case ConsoleKey.D2:
                            InputParams(2);
                            SecondBorder = GetValidBorder(2);
                            break;

                        default:
                            continue;
                    }
                }
                catch (Exception error)
                {
                    Print?.Print(error.Message);
                }
            }
        }

        public bool CheckParamInputs() // теперь надо это разбить на отдельные методы
        {
            PrintWelcome();
            FirstBorder = GetValidBorder(1);
            SecondBorder = GetValidBorder(2);
            GameDifficulty = new DifficultyLevel(GetValidDifficulty(3));
            ValidateBorders(FirstBorder, SecondBorder);
            return true;
        }
    }
}