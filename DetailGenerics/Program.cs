class Program
{
    static void Main(string[] args)
    {
        //var result = new Result { Value = 10, IsSuccess = true };
        //var display = new display { Note = "Advanced c# Generics", IsSuccess = false };
        Console.WriteLine("Enter your Ambition !!");
        string data =Console.ReadLine();

        Console.WriteLine("Enter your faborite  !!");
        int faborite = Convert.ToInt32(Console.ReadLine());




        var GenericResult = new GenericResult<string,bool> { Value = data, IsSuccess = true };
        var GenericResult1 = new GenericResult<int,bool> { Value = faborite, IsSuccess = false };
       
        Console.WriteLine("-------------your Ambition------------");
        Console.WriteLine($"your best ambition is :{GenericResult.Value}");
        Console.WriteLine($"If you hard work it will be :{GenericResult.IsSuccess}");
        Console.WriteLine("-------------Faborite Food------------");
        Console.WriteLine($"your faborite Food is number : {GenericResult1.Value}");
        Console.WriteLine($"Is Exist : {GenericResult1.IsSuccess}");

        Console.ReadKey();
    }
}

public class GenericResult<T,B>
{
    public T Value { get; set; }
    public B IsSuccess { get; set; }
}

public class Result
{
    public int Value { get; set; }
    public bool IsSuccess { get; set; }
}

public class display
{
    public string Note { get; set; }
    public bool IsSuccess { get; set; }
}


