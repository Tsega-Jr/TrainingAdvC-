class Program
{
    delegate void DelegateMethod(string text);
    delegate void DelegateMethod1(int a, int b);
    static void Main(string[] args)
    {
        Logfiles log = new Logfiles();

        DelegateMethod consoleDisplay, logFileSave, Multiple;
        DelegateMethod1 sum;
        consoleDisplay = new DelegateMethod(log.ConsoleDisplay);
        sum = new DelegateMethod1(log.ProductOfSumandSUb);
        Console.WriteLine("Write first number");
        int a = int.Parse(Console.ReadLine());
        Console.WriteLine("Write second number");
        int b = int.Parse(Console.ReadLine());
        // Calling sum delegate
        sum(a, b);
        // var note = Console.ReadLine();
        //Multiple(note);

        Console.ReadKey();

    }
}

public class Logfiles
{
    public void ConsoleDisplay(string text)
    {
        Console.WriteLine($"Welcome to {text}. The Time is: {DateTime.Now} ");
    }
  public void ProductOfSumandSUb(int a, int b)
    {
        int sum1 = a + b;
        int sub1 = a - b;
       //int mul = sum * sub;
        Console.WriteLine("result of "+sub1*sum1);
    }
    public void LogFileSave(string text)
    {
        using (StreamWriter sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log.txt"), true))
        {
            sw.WriteLine($"{DateTime.Now}: {text}");
        }
    }
}