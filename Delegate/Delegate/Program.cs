using System;
using System.IO;

class Program
{
    delegate void DelegateMethod(string text, int a, int b);

    static void Main(string[] args)
    {
        Logfiles log = new Logfiles();

        DelegateMethod consoleDisplay, logFileSave, Multiple;

        consoleDisplay = new DelegateMethod(log.ConsoleDisplay);
        logFileSave = new DelegateMethod(log.LogFileSave);

        Multiple = consoleDisplay + logFileSave;

        Console.WriteLine("Enter a note:");
        var note = Console.ReadLine();

        Console.WriteLine("Enter Value of A:");
        int valueA = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter Value of B:");
        int valueB = int.Parse(Console.ReadLine());

        Multiple(note, valueA, valueB);

        Console.ReadKey();
    }
}

public class Logfiles
{
    public void ConsoleDisplay(string text, int a, int b)
    {
        int result = (a + b) * (a - b);
        Console.WriteLine($"{text}. Result = ({a} + {b}) * ({a} - {b}) = {result}. The Time is: {DateTime.Now}");
    }

    public void LogFileSave(string text, int a, int b)
    {
        int result = (a + b) * (a - b);
        using (StreamWriter sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log.txt"), true))
        {
            sw.WriteLine($"{DateTime.Now}: {text}. Result = ({a} + {b}) * ({a} - {b}) = {result}");
        }
    }
}
