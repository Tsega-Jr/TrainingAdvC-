using System;
using System.IO;

namespace DelegateExample
{
    class Program
    {
        delegate void DelegateEquation(string Note, int A, int B);

        static void Main(string[] args)
        {
            Math_Opreation mp = new Math_Opreation();

            DelegateEquation show_Result, save_Result, multiple;

            consoleDisplay = new DelegateEquation(mp.Show_Result);
            logFileSave = new DelegateEquation(mp.Save_Result);

            multiple = consoleDisplay + logFileSave;

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

    public class Math_Opreation
    {
        public void Show_Result(string note, int a, int b)
        {
            int result = (a + b) * (a - b);
            Console.WriteLine($"Result = ({a} + {b}) * ({a} - {b}) = {result}");
            Console.WriteLine($"Note: {note}. The Time is: {DateTime.Now}");
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
}
