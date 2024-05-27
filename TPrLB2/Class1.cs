using System;
using System.Collections.Generic;
using System.Linq;

namespace MyConsoleApp
{
    // Задача
    public class Task
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
    }

    // Интерфейс хранилища задач
    public interface ITaskRepository
    {
        void AddTask(Task task);
        void RemoveTask(Task task);
        IEnumerable<Task> GetAllTasks();
        Task GetTaskByTitle(string title);
    }

    // Реализация хранилища задач в памяти
    public class InMemoryTaskRepository : ITaskRepository
    {
        private List<Task> tasks = new List<Task>();

        public void AddTask(Task task)
        {
            tasks.Add(task);
        }

        public void RemoveTask(Task task)
        {
            tasks.Remove(task);
        }

        public IEnumerable<Task> GetAllTasks()
        {
            return tasks;
        }

        public Task GetTaskByTitle(string title)
        {
            return tasks.FirstOrDefault(task => task.Title == title);
        }
    }

    // Класс для работы с задачами
    public class TaskManager
    {
        private readonly ITaskRepository taskRepository;

        public TaskManager(ITaskRepository taskRepository)
        {
            this.taskRepository = taskRepository;
        }

        // Добавление новой задачи
        public void AddTask(Task task)
        {
            taskRepository.AddTask(task);
        }

        // Удаление задачи
        public void RemoveTask(Task task)
        {
            taskRepository.RemoveTask(task);
        }

        // Отметка задачи как выполненной
        public void MarkAsCompleted(Task task)
        {
            task.IsCompleted = true;
        }

        // Вывод списка задач
        public void PrintTasks()
        {
            foreach (var task in taskRepository.GetAllTasks())
            {
                Console.WriteLine($"Title: {task.Title}, Description: {task.Description}, Completed: {task.IsCompleted}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Создание экземпляра хранилища задач
            var taskRepository = new InMemoryTaskRepository();

            // Создание экземпляра менеджера задач с внедрением зависимости хранилища
            var taskManager = new TaskManager(taskRepository);

            // Добавление задач
            taskManager.AddTask(new Task { Title = "Task 1", Description = "Description for Task 1" });
            taskManager.AddTask(new Task { Title = "Task 2", Description = "Description for Task 2" });

            // Отметка задачи как выполненной
            var taskToComplete = taskRepository.GetTaskByTitle("Task 1");
            if (taskToComplete != null)
            {
                taskManager.MarkAsCompleted(taskToComplete);
            }

            // Вывод списка задач
            taskManager.PrintTasks();

            Console.ReadLine(); // Чтобы консольное окно не закрывалось сразу после выполнения кода
        }
    }
}
