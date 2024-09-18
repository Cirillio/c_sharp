using System;
using GuessTheNumber.Output;
using GuessTheNumber.Output.Interfaces;
using GuessTheNumber.Input;
using GuessTheNumber.Input.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using GuessTheNumber.GameInterfaces;

namespace GuessTheNumber
{
    internal class NewGame
    {

        ServiceCollection services = new ServiceCollection();
        ServiceProvider serviceProvider;
        IGame? Game;
        IOutputMsg? Output;
        IInputMsg? Input;


        public NewGame()
        {
            services.AddSingleton<IInputMsg, InputConsole>()
            .AddSingleton<IOutputMsg, OutPutConsole>()
            .AddSingleton<IGameParams, GameParams>()
            .AddSingleton<IRandomNumber, RandomNumber>()
            .AddSingleton<Game>();

            serviceProvider = services.BuildServiceProvider();

            Game = serviceProvider.GetService<Game>();
            Output = serviceProvider.GetService<IOutputMsg>();
            Input = serviceProvider.GetService<IInputMsg>();

        }

        public void Setup() {
            Game?.SetupGame();
            Output?.Print("Для продолжения нажмите любую клавишу...");
            Input?.Press();
            Output?.PrintClear();
        }

        public void Play() { 
            Game?.PlayGame();
        }
    }
}