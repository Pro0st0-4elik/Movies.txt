using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static List<string> movies = new List<string>();
    static string filePath = @"C:\Users\user.INFOP\Desktop\Богдан Киричек\movies.txt";
    static bool RemoveMovie(string filePath, string movieTitle)
    {
        string[] lines = File.ReadAllLines(filePath);
        var updatedLines = new System.Collections.Generic.List<string>();
        foreach ( string line in lines ) 
        {
            if(!line.StartsWith(movieTitle))
            {
                updatedLines.Add(line);
            }
        }
        File.WriteAllLines(filePath, updatedLines);
        return true;
    }

    static void Main(string[] args)
    {
        LoadMovies();
        Console.WriteLine();

        while (true)
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Добавить фильм");
            Console.WriteLine("2. Удалить фильм");
            Console.WriteLine("3. Отобразить весь каталог");
            Console.WriteLine("4. Сохранить изменения и выйти");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice) // Проверка ввода пользователя и вызов определенной функции
            {
                case 1:
                    AddMovie();
                    break;
                case 2:
                    DeleteMovie();
                    break;
                case 3:
                    DisplayMovies();
                    break;
                case 4:
                    SaveAndExit();
                    return;
                default:
                    Console.WriteLine("Ошибка, попробуйте снова!");
                    break;
            }
        }
    }

    static void LoadMovies()
    {
        List<string> data = new List<string>();

        data = File.ReadAllLines(filePath).ToList();
        foreach (string item in data) 
        { 
            Console.WriteLine(item);
        }
    }

    static void SaveMovies()
    {
        File.WriteAllLines("movies.txt", movies); // Сохраняет все данные из списка в файл
    }

    static void AddMovie()
    {
        Console.WriteLine("Введите название фильма: ");
        string movieTitle = Console.ReadLine();

        using (StreamWriter sw = File.AppendText(filePath))
        {
            sw.WriteLine($"{movieTitle}");
            Console.WriteLine("Фильм добавлен!");
            Console.WriteLine();
        }
        LoadMovies();
        Console.WriteLine();
    }

    static void DeleteMovie()
    {
        Console.WriteLine("Введите название фильма для удаления: ");
        string movieTitleRemove = Console.ReadLine();

        if(RemoveMovie(filePath, movieTitleRemove))
        {
            Console.WriteLine($"Фильм '{movieTitleRemove}' удален из списка");
        }
        Console.WriteLine();
        LoadMovies();
        Console.WriteLine();
    }

    static void DisplayMovies()
    {
        LoadMovies();
        Console.WriteLine();
    }

    static void SaveAndExit()
    {
        SaveMovies();
    }
}
