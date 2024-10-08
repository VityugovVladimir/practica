using System;
using System.Collections.Generic;

class Program
{
    static List<string> tasks = new List<string>();
    static List<bool> completed = new List<bool>();

    static void Main(string[] args)
    {
        Console.WriteLine("Добро пожаловать в приложение 'Список дел'!");
        string command;
        do
        {
            Console.WriteLine("\nДоступные команды: добавить, список, выполнить, выход");
            Console.Write("Введите команду: ");
            command = Console.ReadLine().ToLower();

            switch (command)
            {
                case "добавить":
                    AddTask();
                    break;
                case "список":
                    ListTasks();
                    break;
                case "выполнить":
                    CompleteTask();
                    break;
                case "выход":
                    Console.WriteLine("Выход из приложения...");
                    break;
                default:
                    Console.WriteLine("Неизвестная команда. Попробуйте снова.");
                    break;
            }
        } while (command != "выход");
    }

    static void AddTask()
    {
        Console.Write("Введите новую задачу: ");
        string task = Console.ReadLine();
        tasks.Add(task);
        completed.Add(false);
        Console.WriteLine($"Задача '{task}' добавлена!");
    }

    static void ListTasks()
    {
        Console.WriteLine("\nВаши задачи:");
        for (int i = 0; i < tasks.Count; i++)
        {
            string status = completed[i] ? "[Выполнена]" : "[В процессе]";
            Console.WriteLine($"{i + 1}. {tasks[i]} {status}");
        }
    }

    static void CompleteTask()
    {
        Console.Write("Введите номер задачи для отметки как выполненной: ");
        if (int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber <= tasks.Count && taskNumber > 0)
        {
            completed[taskNumber - 1] = true;
            Console.WriteLine($"Задача {taskNumber} отмечена как выполненная!");
        }
        else
        {
            Console.WriteLine("Неверный номер задачи.");
        }
    }
}
