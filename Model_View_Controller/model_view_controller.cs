using System;
using System.Collections.Generic; // Aggiunto il using directive per System.Collections.Generic
using System.Linq;

/*
    Model:

    - Rappresenta i dati dell'applicazione e la logica di business.
    - Gestisce l'accesso, la modifica e la manipolazione dei dati.
    - Notifica le modifiche ai dati agli altri componenti.


    View:

    - Si occupa della presentazione dei dati al cliente o all'utente.
    - Riceve input dall'utente e lo trasmette al controller per l'elaborazione.
    - Aggiorna l'interfaccia utente in base alle modifiche apportate al model.


    Controller:

    - Riceve gli input dall'utente tramite la vista.
    - Elabora le richieste dell'utente, interagendo con il modello se necessario.
    - Aggiorna la vista in base alle modifiche apportate al model.
*/

namespace ModelViewController
{
    public class TaskModel
    {
        public TaskModel(string _TaskName, bool _IsCompleted = false) 
        {
            TaskName = _TaskName;
            IsCompleted = _IsCompleted;
        }
        public string TaskName { get; set; }
        public bool IsCompleted { get; set; }

        public string GetInfo() => $"{TaskName} - {(IsCompleted ? "Completed" : "Not Completed")}";
    }

    public class TaskView
    {
        public void DisplayTasks(List<TaskModel> tasks)
        {
            Console.WriteLine("Task List:");
            foreach (var task in tasks)
                Console.WriteLine(task.GetInfo());
            Console.WriteLine("");
        }

        public string GetUserInput()
        {
            Console.Write("Enter task name: ");
            return Console.ReadLine();
        }
    }

    public class TaskController
    {
        private List<TaskModel> tasks = new List<TaskModel>();
        private TaskView view = new TaskView();

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

        public void Run()
        {
            while(true)
            {
                view.DisplayTasks(tasks);
                var taskName = view.GetUserInput();

                if(string.IsNullOrWhiteSpace(taskName))
                    break;

                if(tasks.Any(t => t.TaskName == taskName))
                    MarkTaskAsCompleted(taskName);
                else
                    AddTask(taskName);
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