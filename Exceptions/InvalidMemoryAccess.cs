using System;

namespace bf_interpreter.Exceptions
{
    public class InvalidMemoryAccess : Exception
    {
        public InvalidMemoryAccess(int _dp)
        {
            dp = _dp;
        }

        public int dp { get; set; }
        public string ErrorMessage => $"The data pointer was set to {dp} which is out of bounds";
    }
}