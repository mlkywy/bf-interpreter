static class Program
{
    static void Main(string[] args)
    {  
        string code = "";

        if (args.Length > 0)
        {
            string filename = args[0];
            string path = Path.GetFullPath(@$"{AppDomain.CurrentDomain.BaseDirectory}\..\..\..\{filename}");
            
            if (File.Exists(path))
            {
                code = ReadFile(path);
            }
            else
            {
                Console.WriteLine($"Couldn't find file: {filename}");
            }
        }
        else
        {
            Console.WriteLine("Enter your code!");
            Console.Write("# ");
            code = Console.ReadLine()!;
        }

        Brainfuck bf = new Brainfuck(code);
        bf.Run();
    }

    static string ReadFile(string path)
    {
        string program = "";
        program = File.ReadAllText(path);
        return program;
    }
}

