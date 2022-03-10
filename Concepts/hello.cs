using System;
/*
    Everything in C# is an object;
        when a script is compiled (using 'csc script.cs' in cmd),
            it creates a .exe of the same name
        the executable can be run via 'mono script.exe' in cmd.

    When a C# script starts, it looks for a function named 'Main'
        as an entry point.
*/
namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, world!");
        }
    }
}

