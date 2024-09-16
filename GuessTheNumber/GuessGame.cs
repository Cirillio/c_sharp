using GuessTheNumber;
using System;
using GuessTheNumber.Output;
using GuessTheNumber.Output.Interfaces;
using GuessTheNumber.Input;
using GuessTheNumber.Input.Interfaces;
using Microsoft.Extensions.DependencyInjection;


namespace GuessTheNumber
{
    class GuessGame
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection()
                .AddSingleton<IInputMsg, InputConsole>()
                .AddSingleton<IOutputMsg, OutPutConsole>()
                .AddSingleton<GameParams>();

            var serviceProvider = services.BuildServiceProvider();
            var parameters = serviceProvider.GetService<GameParams>();
            parameters?.SetParams();
            Console.WriteLine(parameters?.minNum);


        }
    }
}