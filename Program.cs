Operation mySum = Functions.Sum;
Console.WriteLine(mySum(3, 7));

Show myMessage = Functions.Message;
myMessage("Hello Samuel!");

Operation myMulti = Functions.Multi;
Console.WriteLine(myMulti(3, 7));

Show show = Console.WriteLine;
show += Functions.UpperMessage;
//show("some day");

Functions.ShowUser("Samuel", "Valerín", show);

#region Action
Action<string> showMessage = Console.WriteLine;
Action<int, int> SumLambda = (a, b) => Console.WriteLine(a + b); 
Functions.SomeAction("John", "Doe",showMessage);
Functions.Sum(2, 3, SumLambda);
#endregion

#region Delegados
public delegate int Operation(int a, int b);
public delegate void Show(string msg);
public delegate void SomeAction(string msg);
public delegate void Sum(int a, int b);
#endregion

public class Functions
{
    public static int Sum(int a, int b) => a + b;
    public static void Message(string msg) => Console.WriteLine(msg);
    public static int Multi(int a, int b) => a * b;
    public static void UpperMessage(string msg) => Console.WriteLine(msg.ToUpper());
    public static void ShowUser(string name, string lastName, Show fn)
    {
        Console.WriteLine("User info");
        fn($"Name: {name} Last name: {lastName}");
        Console.WriteLine("Operation finished.");
    }

    public static void SomeAction(string name, string lastName, Action<string> fn)
    {
        Console.WriteLine("Inicio");
        fn($"{name} {lastName}");
        Console.WriteLine("Final");
    }
    
    public static void Sum(int a, int b, Action<int, int> fn)
    {
        Console.WriteLine("Lambda Action");
        fn(a, b);
        Console.WriteLine("Lambda final");
    }
}
