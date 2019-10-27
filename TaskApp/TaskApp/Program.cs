using System;

namespace TaskApp
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskManager taskManager = new TaskManager();
            string command = "";
            do
            {
                ExConsole.PrintMenu();
                command = Console.ReadLine();
                if (command == "add") taskManager.AddTask();
                else if (command == "show") taskManager.PrintTask();
                else if (command == "save") taskManager.Save();
                else if (command == "load") taskManager.Load();
                else if (command == "clear") taskManager.Clear();
                else if (command == "remove") taskManager.Remove();
                else if (command == "printStartDateSort") taskManager.Sort();
                else if (command == "selectFiveEarly") taskManager.SelectFiveToEarly();
            } while (command != "exit");
        }
    }
}
