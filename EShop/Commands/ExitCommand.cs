using System;

namespace EShop.Commands;

/// <summary>
/// Команда завершения программы
/// </summary>
public static class ExitCommand
{
    /// <summary>
    /// Наименование команды
    /// </summary>
    public const string Name = "Exit";
    
    /// <summary>
    /// Описание команды
    /// </summary>
    public const string Description = "завершить";

    /// <summary>
    /// Выполнить команду
    /// </summary>
    public static string Execute(string[]? args)
    {
        if (args is null || args.Length == 0)
            System.Environment.Exit(0);
        else
            return $"Некорректное число аргументов для команды {Name}";
        
        return string.Empty;
    }
}