using System;
using System.Collections.Generic;
using System.Text;

namespace TaskApp
{
    static class ExConsole
    {
        public static void PrintMenu()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Menu:");
            Console.WriteLine("add");
            Console.WriteLine("show");
            Console.WriteLine("save");
            Console.WriteLine("load");
            Console.WriteLine("clear");
            Console.WriteLine("remove");
            Console.WriteLine("exit\n");
            Console.WriteLine("Podaj polecenie:");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void WriteLine(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void Error(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
