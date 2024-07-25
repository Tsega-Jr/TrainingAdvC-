using System;

class Program
{
    static void Main(string[] args)
    {
        //var result = new Result { Value = 10, IsSuccess = true };
        //var display = new display { Note = "Advanced c# Generics", IsSuccess = false };

        var GenericResult = new GenericResult<string, bool> { Value = "Generic String", IsSuccess = false };
        var GenericResult1 = new GenericResult<int, bool> { Value = 5, IsSuccess = false };

        Console.WriteLine(GenericResult.Value);
        Console.WriteLine(GenericResult1.IsSuccess);
        Console.ReadKey();
    }
}

public class GenericResult<T, T1>
{
    public T Value { get; set; }
    public T1 IsSuccess { get; set; }
}

//public class Result
//{
//    public int Value { get; set; }
//    public bool IsSuccess { get; set; }
//}

//public class display
//{
//    public string Note { get; set; }
//    public bool IsSuccess { get; set; }
//}


