# bf-interpreter

## About

This project is an interpreter of `Brainfuck`, an esoteric programming language created in 1993 by Urban Müller that features 8 commands.
```brainfuck
> = Increment the pointer.
< = Decrement the pointer.
+ = Increment the byte at the pointer.
- = Decrement the byte at the pointer.
[ = Output the byte at the pointer.
] = Input a byte and store it in the byte at the pointer.
, = Jump forward past the matching ] if the byte at the pointer is zero.
. = Jump backward to the matching [ unless the byte at the pointer is zero.
```
 
### Built With
- [#C](https://docs.microsoft.com/en-us/dotnet/csharp/)
- [.NET 6.0](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)

## Getting Started

In order to run the program, you must setup a .NET environment.

```
dotnet run
```

After running the program, you will be prompted to enter a line of Brainfuck code. The following example should return, ```Hello, World!``` in the terminal.
```bf 
++++++++[>++++[>++>+++>+++>+<<<<-]>+>+>->>+[<]<-]>>.>---.+++++++..+++.>>.<-.<.+++.------.--------.>>+.>++.
```
The Main function will also take a filename string as an argument, and the program will read any .bf files in the root of the directory. The following command will read the ```program.bf``` file and output ```Hello, World!```

```
dotnet run "program.bf"
```

## Contributors

