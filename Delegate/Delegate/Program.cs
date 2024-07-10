class Program
{
    delegate void DelegateMethod(string text);
    delegate void DelegateMethodAssigment (int number1,int number2,string text);
    static void Main(string[] args)
    {
        Logfiles log = new Logfiles();

        DelegateMethod consoleDisplay, logFileSave, Multiple;
        DelegateMethodAssigment consoleDisplayAssigment;

        consoleDisplay = new DelegateMethod(log.ConsoleDisplay);

        logFileSave = new DelegateMethod(log.LogFileSave);

        consoleDisplayAssigment = new DelegateMethodAssigment(log.DotheAssigment);

        Multiple = consoleDisplay + logFileSave;
        Console.WriteLine("Input the first number");
       
        var numberA = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Input the second number");
        var numberB = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter Note");

        var note = Console.ReadLine();

        consoleDisplayAssigment(numberA , numberB,note);

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
    public void DotheAssigment (int number1, int number2 , string text)
    {
        var calculatedValue= (number1+ number2) * (number1-number2);
        Console.WriteLine($"{text}{calculatedValue}");
    }
}
