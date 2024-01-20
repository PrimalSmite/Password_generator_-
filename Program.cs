using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using System.Windows.Forms;
using static Funcs;

namespace C__test
{
    internal class Program
    {

        //Описание меню
        static void Menu()
        {
            Console.WriteLine("Программа находится в разработке. При обноружении багов сообщите разработчику.");
            Console.WriteLine("Выберите действие:\n(1) Создание пароля\n(2) Сохранение пароля");
        }

        //Описание генерации пароля
        static int Password_generate(int amount)
        {
            Random random = new Random();
            string password = "";

            List<char> characters = new List<char>();

            // Добавляем буквы нижнего регистра
            for (char c = 'a'; c <= 'z'; c++)
            {
                characters.Add(c);
            }

            // Добавляем буквы верхнего регистра
            for (char c = 'A'; c <= 'Z'; c++)
            {
                characters.Add(c);
            }

            // Добавляем цифры от 0 до 9
            for (char c = '0'; c <= '9'; c++)
            {
                characters.Add(c);
            }

            // Добавляем символы ! @ # %?
            characters.Add('!');
            characters.Add('@');
            characters.Add('#');
            characters.Add('%');
            characters.Add('?');


            // Генерация пароля
            for (int i = 0; i < amount; i++)
            {
                int randomIndex = random.Next(characters.Count);
                password += characters[randomIndex];
            }

            Console.WriteLine(password);

            Console.WriteLine("Хотите сохранить пароль?\n(1) Да\n(2) Нет");
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            if (keyInfo.Key == ConsoleKey.D1)
            {
                Clipboard.SetData(DataFormats.Text, password); // Добавление пароля в буфер обмена  !!!ИСКЛЮЧЕНИЕ!!!
                Console.WriteLine("Пароль сохранен в буфер обмена.\nНажмите любую клавишу, чтобы продолжить");
                Console.ReadKey(true); // Пауза
                Console.Clear();

                // Проверка работы класса
                int status = Create_table();
                if (status == 0) Console.WriteLine("0");
                else Console.WriteLine("1");

                // Ввод данных
                /*
                Console.WriteLine("Введите название сервиса");
                string service_name = Console.ReadLine();
                string login = Console.ReadLine();
                string service_password = Console.ReadLine();

                Save(service_name, login, service_password);
                */

                return 0;
            }
            else return 0;

        }


        /* Описание сохранения пароля
        static int Create_table(string name, string login, string password)
        {
            string connectionString = "Data Source=Passwords.db;Mode=ReadWriteCreate;Version=3"; //Строка подключения, которая задает режим чтения и записи
            string sql = "CREATE TABLE IF NOT EXISTS Passwords (ID INTEGER PRIMARY KEY, NAME TEXT, LOGIN TEXT, PASSWORD TEXT)";

            using (var con = new SqliteConnection(connectionString))
            {
                con.Open();
                using (var cmd = new SqliteCommand(sql, con))
                {
                    var rc = cmd.ExecuteNonQuery();

                    if(rc != null)
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
            //return 0;
        }
        */

        [STAThread]
        static void Main(string[] args)
        {
            //Вызов меню
            Menu();


            // Создание перменной, которая будет отслеживать нажатие клавиш
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            while (keyInfo.Key != ConsoleKey.D0)
            {

                // Создание пароля
                if (keyInfo.Key == ConsoleKey.D1)
                {
                    Console.Clear(); // Очистка консоли

                    Console.WriteLine("Введите количество символов в пароле:");
                    int amount = Convert.ToInt32(Console.ReadLine());
                    Password_generate(amount);
                    Console.WriteLine(Password_generate(amount));

                    Console.WriteLine("Нажмите любую кнопку, чтобы продолжить");
                    Console.ReadKey(true); // Пауза

                    Console.Clear(); // Очистка консоли
                    Menu();
                }

                // Сохранение пароля
                else if (keyInfo.Key == ConsoleKey.D2)
                {
                    Console.Clear(); // Очистка консоли

                    //Save();

                }
            }

        }
    }
}
