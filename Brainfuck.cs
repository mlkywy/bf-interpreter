class Brainfuck
{
    private List<char> code = new List<char>();
    private List<byte> memory = new List<byte>();

    private string program = "++++++++[>++++[>++>+++>+++>+<<<<-]>+>+>->>+[<]<-]>>.>---.+++++++..+++.>>.<-.<.+++.------.--------.>>+.>++.";

    private int ip = 0; // instruction pointer
    private int dp = 0; // data pointer

    public Brainfuck()
    {
        ReadCode();
        memory.Add(0);
    }

    private void ReadCode()
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
                    code.Add(program[i]);
                    break;
            }
        }
    }

    public void Run()
    {
        while (ip < code.Count)
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
                IncrementData();
            }
            else if (c == '-')
            {
                DecrementData();
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


    private void MoveRight()
    {
        dp++;
        memory.Add(0);
    }

    private void MoveLeft()
    {
        dp--;
    }

    private void IncrementData()
    {
        memory[dp]++; 
    }

    private void DecrementData()
    {
        memory[dp]--;
    }

    private void OutputChar()
    {
        char character = (char)memory[dp];
        Console.Write(character);
    }

    private void InputChar()
    {
        byte input = Convert.ToByte(Console.Read());
        memory[dp] = input;
    }

    private void JumpForward()
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

    private void JumpBackward()
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