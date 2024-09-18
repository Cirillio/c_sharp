using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuessTheNumber.Output;
using GuessTheNumber.Input;
using Microsoft.Extensions.DependencyInjection;
using GuessTheNumber.Output.Interfaces;
using GuessTheNumber.Input.Interfaces;
using GuessTheNumber.GameInterfaces;


namespace GuessTheNumber
{
    internal class Game (IGameParams _parameters, IRandomNumber _randomNumber, IOutputMsg output, IInputMsg input) : IGame
    {
        private IOutputMsg _output = output;
        private IInputMsg _input = input;

        private readonly IGameParams parameters = _parameters;
        private readonly IRandomNumber randomNumber = _randomNumber;

        private GameNotifier? Notify;

        private int guessedNumber;
        private int attempts;
        private int clues;

        private bool Victory = false;

        public void SetupGame() {

            parameters.SetParams();
            attempts = parameters.attempts;
            clues = parameters.clues;
            guessedNumber = randomNumber.GetRandomNumber(parameters);
            Notify = new GameNotifier(guessedNumber, parameters.minNum, parameters.maxNum);
            _output.PrintClear();
            _output.Print("Игра начата.");
            _output.Print("Сложность: " + parameters.difficultyLevel);
            _output.Print("Границы: [" + parameters.minNum + "] - [" + parameters.maxNum + "]");
            _output.Print("Количество попыток: " + attempts);
            _output.Print("Количество подсказок: " + clues);
            _output.Print("Загаданное число: " + guessedNumber);

        }

        public void PlayGame() {

            while (Victory != true)
            {
                try
                {
                    _output.Print("Введите число: ");
                    int guessNum = Convert.ToInt32(_input.Input());
                    attempts--;


                    if (guessNum == guessedNumber) {
                        _output.Print("Победа! Вы угадали число.");
                        Victory = true;
                        _output.Print("Игра окончена. Спасибо за участие.");
                        break;
                    }

                    _output.Print(Notify.GetNotify(guessNum));

                    _output.Print("Границы: [" + parameters.minNum + "] - [" + parameters.maxNum + "]");
                    _output.Print("Количество попыток: " + attempts);
                    _output.Print("Количество подсказок: " + clues);

                    _output.Print("Выберите действие:");
                    _output.Print("1 - Ввести число\n2 - Подсказка\n3 - Выход");

                    while (true) {

                        var wtd = _input.Press();
                        switch (wtd.Key)
                        {

                            case ConsoleKey.D1:
                                break;
                            case ConsoleKey.D2:
                                if(clues == 0) {
                                    _output.PrintError("Подсказки исчерпаны(");
                                    break;
                                }
                                clues--;
                                _output.Print(Notify.GetClue());
                                break;
                            case ConsoleKey.D3:
                                _output.Print("Игра завершена.");
                                Victory = true;
                                break;
                            default:
                                _output.PrintError("Неверное значение. Повторите попытку.");
                                continue;
                        }
                        break;
                    }

                    if (attempts == 0) {
                        Victory = true;
                        _output.Print("Попытки закончились. Игра завершена.");
                    }

                }
                catch (Exception error)
                {
                    _output.PrintError(error.Message + "\nПопробуйте еще раз.");
                }
            }

        }


        

    }
}



