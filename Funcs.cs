using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;

/// <summary>
/// Summary description for Class1
/// </summary>
public static class Funcs
{
    static string connectionString = "Data Source=Passwords.db;Mode=ReadWriteCreate;Version=3"; //Строка подключения, которая задает режим чтения и записи

    public static int Create_table()
    {
        //string connectionString = "Data Source=Passwords.db;Mode=ReadWriteCreate;Version=3"; //Строка подключения, которая задает режим чтения и записи
        string sql = "CREATE TABLE IF NOT EXISTS Passwords (ID INTEGER PRIMARY KEY, NAME TEXT, LOGIN TEXT, PASSWORD TEXT)";

        using (var con = new SqliteConnection(connectionString))
        {
            con.Open();
            using (var cmd = new SqliteCommand(sql, con))
            {
                var rc = cmd.ExecuteNonQuery();

                if (rc != null)
                {
                    Console.WriteLine("Таблица уже существует");
                    return 0;
                }
                if (rc == null)
                {
                    Console.WriteLine("Таблица успешно создана");
                    return 0;
                }
                else
                {
                    Console.WriteLine("Ошибка! Таблица не создалась!");
                    return 1;
                }
            }
        }
    }
    public static int Save(string name, string login, string password)
    {
        string sql = "";
        using (var con = new SqliteConnection(connectionString))
        {
            con.Open();

            using (var cmd = new SqliteCommand())
            {

            }
        }


        return 0;
    }
}
