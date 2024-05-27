using System;
using System.Collections.Generic;
using System.Linq;

// Задача
public class Task
{
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
}

// Класс для работы с задачами
public class TaskManager
{
    private List<Task> tasks = new List<Task>();

    // Добавление новой задачи
    public void AddTask(Task task)
    {
        tasks.Add(task);
    }

    // Удаление задачи
    public void RemoveTask(Task task)
    {
        tasks.Remove(task);
    }

    // Отметка задачи как выполненной
    public void MarkAsCompleted(Task task)
    {
        task.IsCompleted = true;
    }
    public Task GetTaskByTitle(string title)
    {
        // Ищем задачу с указанным заголовком
        return tasks.FirstOrDefault(task => task.Title == title);
    }

    // Вывод списка задач
    public void PrintTasks()
    {
        foreach (var task in tasks)
        {
            Console.WriteLine($"Title: {task.Title}, Description: {task.Description}, Completed: {task.IsCompleted}");
        }
    }
}

