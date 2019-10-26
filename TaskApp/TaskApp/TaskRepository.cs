using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TaskApp
{
    public static class TaskRepository
    {

        private const string PATHFILE = "date.csv";
        public static void LoadToFile(List<TaskModel> taskModels)
        {
            var stringBuilder = new StringBuilder();
            foreach (var task in taskModels)
            {
                stringBuilder.Append($"{task.Description}|{task.StartDate}|{task.EndDate}|{task.IsAllDay}|{task.IsImportant}");
            }
            File.WriteAllText(PATHFILE, stringBuilder.ToString());
        }

        public static bool TryLoadFromFile(out List<TaskModel> taskList)
        {
            var tempList = new List<TaskModel>();
            if (!File.Exists(PATHFILE))
            {
                taskList = null;
                return false;
            }
            var splitTasks = File.ReadAllLines(PATHFILE);
            foreach (var task in splitTasks)
            {
                var splitOneTask = task.Split("|");
                tempList.Add(new TaskModel(splitOneTask[0], Convert.ToDateTime(splitOneTask[1]), Convert.ToDateTime(splitOneTask[2]), Convert.ToBoolean(splitOneTask[3]), Convert.ToBoolean(splitOneTask[4])));
            }
            taskList = tempList;
            return true;
        }
    }
}
