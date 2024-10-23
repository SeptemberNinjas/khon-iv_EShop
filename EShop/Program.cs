using System;
using System.Diagnostics;
using System.Linq;
using System.Xml;
using EShop;
using EShop.Commands;

namespace Eshop;

class Program
{
    private static readonly ApplicationContext Context = new();
    private static void Main(string[] args)
    {
        Console.WriteLine(ApplicationContext.Title);
        Console.WriteLine(Context.ExecuteStartupCommand() + $"{Environment.NewLine}");
        while (true)
        {
            var command = Console.ReadLine();
            Execute(command);
        }
    }

    /// <summary>
    /// Выполнить команду
    /// </summary>
    private static void Execute(string? command)
    {
        if (string.IsNullOrEmpty(command) || string.IsNullOrWhiteSpace(command)) 
        {
            Console.WriteLine("Введите команду");
            return;
        }
        
        var wordsOfCommand = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var commandName = wordsOfCommand[0];
        var commandArgs = wordsOfCommand.Skip(1).ToArray();

        Console.WriteLine(Context.ExecuteCommandByName(commandName, commandArgs) + $"{Environment.NewLine}");
    } 
}