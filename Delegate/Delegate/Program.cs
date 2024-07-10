using System.IO;
using System;

class Program
{
    delegate void DelegateMethod(string text);
    delegate void DelegateEquation(string Note, int A, int B);
    static void Main(string[] args)
    {
        Logfiles log = new Logfiles();
        Math_Opreation mp = new Math_Opreation();

        DelegateMethod consoleDisplay, logFileSave, Multiple;
        DelegateEquation show_Result, save_Result, multiple;

        consoleDisplay = new DelegateMethod(log.ConsoleDisplay);

        logFileSave = new DelegateMethod(log.LogFileSave);

        show_Result = new DelegateEquation(mp.Show_Result);
        save_Result = new DelegateEquation(mp.Save_Result);


        Multiple = consoleDisplay + logFileSave;
        multiple = show_Result + save_Result;
        Console.WriteLine("Write a Note");

        var note = Console.ReadLine();

        Multiple(note);

        Console.WriteLine("Write a Note:");
        var Note = Console.ReadLine();

        Console.WriteLine("Enter value for A:");
        int A = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter value for B:");
        int B = int.Parse(Console.ReadLine());

        multiple(Note, A, B);

        Console.ReadKey();

    }
}

public class Logfiles
{
    public void ConsoleDisplay(string text)
    {
        Console.WriteLine($"Welcome to {text}. The Time is: {DateTime.Now} ");
    }

    public void LogFileSave(string text)
    {
        using (StreamWriter sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log.txt"), true))
        {
            sw.WriteLine($"{DateTime.Now}: {text}");
        }
    }
}
public class Math_Opreation
{
    public void Show_Result(string note, int a, int b)
    {
        int result = (a + b) * (a - b);
        Console.WriteLine($"Result = ({a} + {b}) * ({a} - {b}) = {note}:{result}");

    }

    public void Save_Result(string note, int a, int b)
    {
        int result = (a + b) * (a - b);
        using (StreamWriter sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log.txt"), true))
        {
            sw.WriteLine($"{DateTime.Now}: Note: {note}. Result = ({a} + {b}) * ({a} - {b}) = {result}");
        }
    }
}