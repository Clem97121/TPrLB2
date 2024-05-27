using System;

namespace MyConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создаем экземпляр хранилища задач
            var taskRepository = new InMemoryTaskRepository();

            // Создаем экземпляр менеджера задач с внедрением зависимости хранилища
            var taskManager = new TaskManager(taskRepository);

            // Добавляем задачи
            taskManager.AddTask(new Task { Title = "Task 1", Description = "Description for Task 1" });
            taskManager.AddTask(new Task { Title = "Task 2", Description = "Description for Task 2" });

            // Отмечаем первую задачу как выполненную
            var taskToComplete = taskRepository.GetTaskByTitle("Task 1");
            if (taskToComplete != null)
            {
                taskManager.MarkAsCompleted(taskToComplete);
            }

            // Выводим список задач
            taskManager.PrintTasks();

            Console.ReadLine(); // Чтобы консольное окно не закрывалось сразу после выполнения кода
        }
    }
}
