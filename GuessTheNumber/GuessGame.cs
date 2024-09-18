using System;
using GuessTheNumber.Output;
using GuessTheNumber.Output.Interfaces;
using GuessTheNumber.Input;
using GuessTheNumber.Input.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using GuessTheNumber.GameInterfaces;


namespace GuessTheNumber
{
    class GuessGame
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection()
                .AddSingleton<IInputMsg, InputConsole>()
                .AddSingleton<IOutputMsg, OutPutConsole>()
                .AddSingleton<IGameParams, GameParams>()
                .AddSingleton<IRandomNumber, RandomNumber>()
                .AddSingleton<Game>();

            var serviceProvider = services.BuildServiceProvider();


            var Game = serviceProvider.GetService<Game>();

            Game?.StartGame();
            Console.WriteLine("Для продолжения нажмите любую клавишу");
            Console.ReadKey(true);
            Console.Clear();
            Game?.PlayGame();




        }
    }
}