using System;
using System.Collections.Generic;
using System.Linq;

namespace ModelViewController
{
    public class TaskModel
    {
        public TaskModel(string taskName, bool isCompleted = false)
        {
            TaskName = taskName;
            IsCompleted = isCompleted;
        }

        public string TaskName { get; set; }
        public bool IsCompleted { get; set; }

        public string GetInfo() => $"{TaskName} - {(IsCompleted ? "Completed" : "Not Completed")}";
    }

    public class TaskView
    {
        public void DisplayTasks(IEnumerable<TaskModel> tasks)
        {
            Console.WriteLine("Task List:");
            foreach (var task in tasks)
                Console.WriteLine(task.GetInfo());
            Console.WriteLine();
        }

        public string GetUserInput()
        {
            Console.Write("Enter task name: ");
            return Console.ReadLine();
        }
    }

    public class TaskController
    {
        private readonly List<TaskModel> tasks = new List<TaskModel>();
        private readonly TaskView view = new TaskView();

        public void AddTask(string taskName)
        {
            tasks.Add(new TaskModel(taskName));
        }

        public void MarkTaskAsCompleted(string taskName)
        {
            var task = tasks.FirstOrDefault(t => t.TaskName == taskName);
            if (task != null)
                task.IsCompleted = true;
        }

        private void DisplayOptions()
        {
            Console.WriteLine("Options:");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. Mark Task as Completed");
            Console.WriteLine("3. Sort by Completed");
            Console.WriteLine("4. Sort by Not Completed");
            Console.WriteLine("5. Exit");
        }

        public void Run()
        {
            while (true)
            {
                view.DisplayTasks(tasks);
                DisplayOptions();

                Console.Write("\nEnter an option: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        var taskName = view.GetUserInput();
                        AddTask(taskName);
                        break;
                    case "2":
                        taskName = view.GetUserInput();
                        MarkTaskAsCompleted(taskName);
                        break;
                    case "3":
                        tasks.Sort((a, b) => b.IsCompleted.CompareTo(a.IsCompleted));
                        break;
                    case "4":
                        tasks.Sort((a, b) => a.IsCompleted.CompareTo(b.IsCompleted));
                        break;
                    case "5":
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
                Console.WriteLine();
            }
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var controller = new TaskController();
            controller.Run();
        }
    }
}
