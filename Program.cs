using System;

// Уровни логирования с помощью перечисления
public enum LogLevel
{
    Info = 1,
    Warning = 2,
    Error = 3
}

// Базовый обработчик Handler, абстрактный класс - потому что нужен исключительно для наследования. Как базовый класс он нигде не должен использоваться.
abstract class Logger
{
    protected Logger _next;
    protected LogLevel _level;

    public Logger(LogLevel level) => _level = level;

    public void SetNext(Logger next) => _next = next;

    public void Log(LogLevel level, string message)
    {
        if (_level <= level)
            WriteMessage(message);

        _next?.Log(level, message);
    }

    protected abstract void WriteMessage(string message); // абстрактный метод, потому что хочу унаследовать этот метод в конкретных обработчиках.
}

// Конкретные обработчики ConcreteHandler
class ConsoleLogger : Logger
{
    public ConsoleLogger(LogLevel level) : base(level) { }
    protected override void WriteMessage(string message) // унаследовал метод с помощью override - виртуальный метод
        => Console.WriteLine($"Console: {message}");
}

class FileLogger : Logger
{
    public FileLogger(LogLevel level) : base(level) { }
    protected override void WriteMessage(string message) // идентичное наследование
        => Console.WriteLine($"File: {message}");
}


class Program
{
    static void Main()
    {
        // Настраиваем цепочку
        var console = new ConsoleLogger(LogLevel.Info);
        var file = new FileLogger(LogLevel.Warning);

        console.SetNext(file);

        // Тестируем
        Console.WriteLine("Обработка информации:");
        console.Log(LogLevel.Info, "Тестовое сообщение");

        Console.WriteLine("\nОбработка предупеждения:");
        console.Log(LogLevel.Warning, "Предупреждение");

        Console.WriteLine("\nОбработка ошибки:");
        console.Log(LogLevel.Error, "КРИТИЧЕСКАЯ ОШИБКА");
    }
}