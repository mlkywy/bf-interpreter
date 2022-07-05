static class Program
{
    static char[] code = new char[30_000];
    static byte[] memory = new byte[30_000];

    static string program = "++++++++[>++++[>++>+++>+++>+<<<<-]>+>+>->>+[<]<-]>>.>---.+++++++..+++.>>.<-.<.+++.------.--------.>>+.>++.";

    static int ip = 0; // instruction pointer
    static int dp = 0; // data pointer
    static int codeLength = 0;

    static void Main()
    {
        // Brainfuck bf = new Brainfuck();
        ReadCode();
        Run();
    }

    static void ReadCode()
    {
        // Reading program into code array
        for (int i = 0; i < program.Length; i++)
        {
            switch (program[i])
            {
                case '>':
                case '<':
                case '+':
                case '-':
                case '.':
                case ',':
                case '[':
                case ']':
                    code[codeLength] = program[i];
                    codeLength++;
                    break;
            }
        }
    }

    static void Run()
    {
        while (ip < codeLength)
        {
            char c = code[ip];
            
            if (c == '>')
            {
                MoveRight();
            }
            else if (c == '<')
            {
                MoveLeft();
            }
            else if (c == '+')
            {
                IncrementMemory();
            }
            else if (c == '-')
            {
                DecrementMemory();
            }
            else if (c == '.')
            {
                OutputChar();
            }
            else if (c == ',')
            {
                InputChar();
            }
            else if (c == '[')
            {
                JumpForward();
            }
            else if (c == ']')
            {
                JumpBackward();
            }

            ip++;
        }
    }


    static void MoveRight()
    {
        dp++;
    }

    static void MoveLeft()
    {
        dp--;
    }

    static void IncrementMemory()
    {
        memory[dp]++;
    }

    static void DecrementMemory()
    {
        memory[dp]--;
    }

    static void OutputChar()
    {
        char character = (char)memory[dp];
        Console.Write(character);
    }

    static void InputChar()
    {
        byte input = Convert.ToByte(Console.Read());
        memory[dp] = input;
    }

    static void JumpForward()
    {
        if (memory[dp] == 0)
        {
            int opening = 1;
            while (opening != 0)
            {
                ip++;
                if (code[ip] == '[')
                {
                    opening++;
                }
                else if (code[ip] == ']')
                {
                    opening--;
                }
            }
        }
    }

    static void JumpBackward()
    {
        if (memory[dp] != 0)
        {
            int closing = 1;
            while (closing != 0)
            {
                ip--;
                if (code[ip] == ']')
                {
                    closing++;
                }
                else if (code[ip] == '[')
                {
                    closing--;
                }
            }
        }
    }
}

