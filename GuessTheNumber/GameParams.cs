using GuessTheNumber.Output;
using GuessTheNumber.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Microsoft.Extensions.DependencyInjection;
using GuessTheNumber.Input.Interfaces;
using GuessTheNumber.Output.Interfaces;

namespace GuessTheNumber
{
    internal class GameParams (IInputMsg input, IOutputMsg output)
    {
        public int minNum { get; set; }

        public int maxNum { get; set; }

        public int difficultyLevel { get; set; }

        public int attempts { get; set; }

        public int clues { get; set; }

        private IInputMsg _input = input;

        private IOutputMsg _output = output;

        public void SetParams() {
            while (true) {
                try
                {
                    minNum = InputParam("Введите минимальное число: ");
                    maxNum = InputParam("Введите максимальное число: ");
                    if (maxNum == minNum)
                    {
                        throw new Exception("Границы не должны совпадать.");
                    }
                    difficultyLevel = InputParam("Выберите уровень сложности:\n"+"" +
                        "1 - легкий (100 попыток, 50 подсказок)\n" + 
                        "2 - средний (50 попыток, 25 подсказок)\n"+
                        "3 - хардкор (10 попыток, 1 подсказка)");
                    if (difficultyLevel < 1 || difficultyLevel > 3) {
                        throw new Exception("Неверное значение. Повторите попытку.");
                    }

                    switch (difficultyLevel) {
                        case 1:
                            attempts = 100;
                            clues = 50;
                            break;

                        case 2:
                            attempts = 50;
                            clues = 25;
                            break;

                        case 3:
                            attempts = 10;
                            clues = 1;
                            break;

                        default:
                            break;
                    }

                    return;
                }
                catch (Exception error) { 
                _output.PrintError(error.Message + "\nПовторите попытку.");
                }
            }
        }


        public int InputParam(string msg) {
            while (true)
            {
                try {
                    _output.Print(msg);
                    var param = Convert.ToInt32(Console.ReadLine());
                    return param;
                }
                catch (Exception error) {
                    throw new Exception(error.Message);
                }
            }
        }
    }
}