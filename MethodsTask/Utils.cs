namespace MainProgram.MethodsTask;

public class Utils
{
    public static void ShowCurrentTime()
    {
        Console.WriteLine($"Time: {DateTime.Now:HH:mm:ss}");
    }

    public static void ShowCurrentDate()
    {
        Console.WriteLine($"Date: {DateTime.Now:dd:MM:yyyy}");
    }

    public static void ShowCurrentDay()
    {
        Console.WriteLine($"Day: {DateTime.Now.DayOfWeek}");
    }

    public static double TriangleArea(double a, double h)
    {
        return 0.5 * a * h;
    }

    public static double RectangleArea(double a, double b)
    {
        return a * b;
    }
}
