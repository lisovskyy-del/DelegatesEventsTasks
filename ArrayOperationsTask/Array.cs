namespace MainProgram.ArrayOperationsTask;

public delegate void FilteredArray(Array array);

public class Array
{
    public int[] Data { get; private set; }
    public int Count { get; private set; }

    public Array(int capacity)
    {
        this.Data = new int[capacity];
        this.Count = 0;
    }

    public void Add(int value)
    {
        if (Count == Data.Length)
        {
            Resize(Data.Length * 2);
        }

        Data[Count] = value;
        Count++;
    }

    public void Resize(int newSize)
    {
        int[] temp = new int[newSize];

        for (int i = 0; i < Count; i++)
        {
            temp[i] = Data[i];
        }

        Data = temp;
    }

    public static void ShowEven(Array array)
    {
        Console.WriteLine("\nAll even elements of array:\n");

        for (int i = 0; i < array.Count; i++)
        {
            if (array.Data[i] % 2 == 0)
            {
                Console.Write($"{array.Data[i]} ");
            }
        }
        Console.WriteLine();
    }

    public static void ShowOdd(Array array)
    {
        Console.WriteLine("\nAll odd elements of array:\n");

        for (int i = 0; i < array.Count; i++)
        {
            if (array.Data[i] % 2 != 0)
            {
                Console.Write($"{array.Data[i]} ");
            }
        }
        Console.WriteLine();
    }

    private static bool IsPrime(int number)
    {
        if (number < 2)
        {
            return false;
        }

        for (int i = 2; i * i <= number; i++)
        {
            if (number % i == 0)
            {
                return false;
            }
        }

        return true;
    }

    private static bool IsPerfectSquare(int x)
    {
        int s = (int)Math.Sqrt(x);

        return s * s == x;
    }

    private static bool IsFibonacci(int number)
    {
        if (number < 0)
        {
            return false;
        }

        return IsPerfectSquare(5 * number * number + 4) || IsPerfectSquare(5 * number * number - 4);
    }

    public static void ShowPrime(Array array)
    {
        Console.WriteLine("\nAll prime elements of array:\n");

        for (int i = 0; i < array.Count; i++)
        {
            if (IsPrime(array.Data[i]))
            {
                Console.Write($"{array.Data[i]} ");
            }
        }
    }

    public static void ShowFibonacci(Array array)
    {
        Console.WriteLine("\nAll fibonacci elements of array:\n");

        for (int i = 0; i < array.Count; i++)
        {
            if (IsFibonacci(array.Data[i]))
            {
                Console.Write($"{array.Data[i]} ");
            }
        }
    }
}