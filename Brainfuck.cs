using System;
using System.Collections.Generic;
using bf_interpreter.Exceptions;

namespace bf_interpreter
{
    class Brainfuck
    {
        private readonly List<char> _code = new ();
        private readonly List<byte> _memory = new ();

        /// <summary>
        /// Valid Brainfuck tokens 
        /// </summary>
        private readonly List<char> _tokens = new()
        {
            '>',
            '<',
            '+',
            '-',
            '.',
            ',',
            '[',
            ']'
        };

        private readonly string _program;
        /// <summary>
        /// Instruction pointer
        /// </summary>
        private int _ip;
        
        /// <summary>
        /// Data pointer
        /// </summary>
        private int _dp; 

        public Brainfuck(string input)
        {
            _program = input;
            ReadCode();
            _memory.Add(0);
        }

        private void ReadCode()
        {
            // Reading program into code array
            foreach (var t in _program)
            {
                if (_tokens.Contains(t))
                {
                    _code.Add(t);
                }
            }
        }

        public void Run()
        {
            while (_ip < _code.Count)
            {
                var c = _code[_ip];
            
                switch (c)
                {
                    case '>':
                        MoveRight();
                        break;
                    case '<':
                        MoveLeft();
                        break;
                    case '+':
                        IncrementData();
                        break;
                    case '-':
                        DecrementData();
                        break;
                    case '.':
                        OutputChar();
                        break;
                    case ',':
                        InputChar();
                        break;
                    case '[':
                        JumpForward();
                        break;
                    case ']':
                        JumpBackward();
                        break;
                    default:
                        throw new InvalidOperationException();
                }

                _ip++;
            }
        }


        private void MoveRight()
        {
            _dp++;
            if (_dp == _memory.Count)
            {
                _memory.Add(0);
            }
        }

        private void MoveLeft()
        {
            _dp--;
            if (_dp < 0)
            {
                var memoryError = new InvalidMemoryAccess(_dp);
                Console.WriteLine(memoryError.ErrorMessage);
                throw memoryError;
            }
        }

        private void IncrementData()
        {
            _memory[_dp]++;
        }

        private void DecrementData()
        {
            _memory[_dp]--;
        }

        private void OutputChar() => Console.Write((char)_memory[_dp]);

        private void InputChar() => _memory[_dp] = Convert.ToByte(Console.Read());

        private void JumpForward()
        {
            if (_memory[_dp] == 0)
            {
                int opening = 1;
                while (opening != 0)
                {
                    _ip++;
                    switch (_code[_ip])
                    {
                        case '[':
                            opening++;
                            break;
                        case ']':
                            opening--;
                            break;
                    }
                }
            }
        }

        private void JumpBackward()
        {
            if (_memory[_dp] != 0)
            {
                int closing = 1;
                while (closing != 0)
                {
                    _ip--;
                    switch (_code[_ip])
                    {
                        case ']':
                            closing++;
                            break;
                        case '[':
                            closing--;
                            break;
                    }
                }
            }
        }
    }
}