class Program
{
    delegate void DelegateMethod(string text);
    delegate void DelegateMethod1(int a,int b);
    static void Main(string[] args)
    {
        Logfiles log = new Logfiles();
        
        DelegateMethod consoleDisplay, logFileSave, Multiple;
        DelegateMethod1 sum, test;

       consoleDisplay = new DelegateMethod(log.ConsoleDisplay);
 
       logFileSave = new DelegateMethod(log.LogFileSave);
        sum = new DelegateMethod1(log.Sum);
        test = new DelegateMethod1(log.Test);
        Multiple = consoleDisplay + logFileSave;
        Console.WriteLine("Write a Note");
        var note = Console.ReadLine();
        
        Console.WriteLine("Enter the first number");
        int a =Convert.ToInt32( Console.ReadLine());
        Console.WriteLine("Enter the second number");
        int b = Convert.ToInt32(Console.ReadLine());
        Multiple(note);
        sum(a, b);
        test(a, b);

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
    public void Sum(int a, int b)
    {
        Console.WriteLine("The sum of " + a + " and " + b + " is " + (a + b));
    }
    public void Test(int a, int b)
    {
        Console.WriteLine("The result is: " + (a + b) * (a - b));
    }
}