namespace MainProgram.MulticastTask;

public delegate void MulticastDelegate(string input);

class Multicast
{
    public static void PrintInput(string input)
    {
        Console.WriteLine($"\nInput:\n\n{input}");
    }

    public static void WriteToFile(string input)
    {
        string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "text.txt")))
        {
            outputFile.WriteLine(input);
        }

        Console.WriteLine("\nSuccesfully written text into a file.");
    }
}
