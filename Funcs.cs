using Microsoft.Data.Sqlite;
using System;

/// <summary>
/// Summary description for Class1
/// </summary>
public static class Funcs
{
    static string connectionString = "Data Source=Passwords.db;Mode=ReadWriteCreate;Version=3"; //Строка подключения, которая задает режим чтения и записи

    public static int Save(string name, string login, string passowrd)
    {
        string connectionString = "Data Source=Passwords.db;Mode=ReadWriteCreate;Version=3"; //Строка подключения, которая задает режим чтения и записи
        string table = "CREATE TABLE IF NOT EXISTS Passwords (ID INTEGER PRIMARY KEY, NAME TEXT, LOGIN TEXT, PASSWORD TEXT)"; // Запрос на создание таблицы 
        string save_string = "INSERT INTO Passwords (NAME TEXT, LOGIN TEXT, PASSWORD TEXT) VALUES (@name, @login, @password)";

        using (var con = new SqliteConnection(connectionString))
        {
            con.Open();
            using (var cmd = new SqliteCommand(table, con))
            {
                var rc = cmd.ExecuteNonQuery();

                if (rc != null || rc == null)
                {
                    using (var save = new SqliteCommand( , con))
                    {
                        var saving = cmd.ExecuteNonQuery ();

                        if (saving != null || saving == null)
                        {

                        }
                        else
                        {
                            Console.WriteLine("Данные не сохраненны!");
                        }
                    }

                    return 0;
                }
                else
                {
                    Console.WriteLine("Ошибка при создании таблицы!");
                    return 1;
                }
            }

        }
    }
}