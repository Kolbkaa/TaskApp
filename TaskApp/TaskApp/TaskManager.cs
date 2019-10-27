using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskApp
{
    class TaskManager
    {
        private List<TaskModel> taskList;

        private List<TaskModel> TaskList { get => taskList; set => taskList = value; }

        public TaskManager()
        {
            TaskList = new List<TaskModel>();
        }
        public void AddTask()
        {

            Console.Clear();
            ExConsole.WriteLine("Podaj opis:");
            var desc = Console.ReadLine();

            ExConsole.WriteLine("Podaj date startu w formacie: dd.mm.yy ");
            var stringStartDate = Console.ReadLine();
            var startDate = Convert.ToDateTime(stringStartDate);
            if (startDate == null)
            {
                ExConsole.Error($"Bład konwersji daty {stringStartDate}");
                return;
            }

            ExConsole.WriteLine("Podaj date zakończenia w formacie: dd.mm.yy");
            ExConsole.WriteLine("Jeżeli zadanie ma być całodniowe wciśnij enter.");
            var stringEndDate = Console.ReadLine();
            DateTime? endDate = null;
            if (!string.IsNullOrWhiteSpace(stringEndDate))
            {
                endDate = Convert.ToDateTime(stringEndDate);
                if (endDate == null)
                {
                    ExConsole.Error($"Bład konwersji daty {stringEndDate}");
                    return;
                }
            }

            ExConsole.WriteLine("Czy zadanie jest ważne T/N");
            var stringIsImportant = Console.ReadLine();
            bool isImporant = false;
            if (stringIsImportant.ToUpper() == "T")
            {
                isImporant = true;
            }
            else if (stringIsImportant.ToUpper() == "N")
            {
                isImporant = false;
            }
            else
            {
                ExConsole.Error($"Bład konwersji {stringIsImportant}");
                return;
            }

            TaskList.Add(new TaskModel(desc, startDate, endDate, isImporant));
        }

        public void PrintTask()
        {
            Console.Clear();
            int counter = 1;
            foreach (var task in TaskList)
            {
                Console.WriteLine($"{counter}. { task.StartDate.ToShortDateString()} - {task.EndDate.Value.ToShortDateString()}, Całodniowe:{task.IsAllDay}, Ważne: {task.IsImportant} ");
                Console.WriteLine("Opis:");
                Console.WriteLine(task.Description);
                Console.WriteLine();
                counter++;
            }
            Console.ReadKey();
        }
        private void PrintTask(List<TaskModel> listTask)
        {
            Console.Clear();
            int counter = 1;
            foreach (var task in listTask)
            {
                Console.WriteLine($"{counter}. { task.StartDate.ToShortDateString()} - {task.EndDate.Value.ToShortDateString()}, Całodniowe:{task.IsAllDay}, Ważne: {task.IsImportant} ");
                Console.WriteLine("Opis:");
                Console.WriteLine(task.Description);
                Console.WriteLine();
                counter++;
            }
            Console.ReadKey();
        }

        public void Save()
        {
            Console.Clear();
            Console.WriteLine("Zapisywanie do pliku...");
            TaskRepository.LoadToFile(TaskList);
            Console.WriteLine("Zapisano.");
        }
        public void Clear()
        {
            Console.Clear();
            Console.WriteLine("Wyczyszczono liste");
            TaskList.Clear();
        }
        public void Load()
        {
            Console.Clear();
            if (!TaskRepository.TryLoadFromFile(out taskList))
            {
                ExConsole.Error("Bład odczytu pliku");
                return;
            }
            Console.WriteLine($"Odczytano rekorów: {taskList.Count}");
        }
        public void Remove()
        {
            Console.WriteLine("Podaj numer indexu do usunięcia");
            string stringCount = Console.ReadLine();
            int index = 0;
            if(int.TryParse(stringCount,out index)&& index >0 && index <= taskList.Count)
            {
                TaskList.RemoveAt(index-1);
                Console.WriteLine($"Usunięto zadanie o id {index}");
            }
            else
            {
                ExConsole.Error("Błąd usuwania");
            }
            
        }
        public void Sort()
        {
            PrintTask(taskList.OrderBy(x => x.StartDate).ToList());
        }
        public void SelectFiveToEarly()
        {
            PrintTask(taskList.OrderBy(x => x.StartDate).Take(5).ToList());
        }
    }
}
