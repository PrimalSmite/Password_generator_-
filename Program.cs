using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace C__test
{
    internal class Program
    {
        string password = "";
        ref string xPassword = ref password;

        //Описание меню
        static void Menu()
        {
            Console.WriteLine("Программа находится в разработке. При обноружении багов сообщите разработчику.");
            Console.WriteLine("Выберите действие:\n(1) Создание пароля\n(2) Сохранение пароля");
        }

        //Описание генерации пароля
        static string Password_generate(int amount)
        {
            Random random = new Random();
            //string password = "";

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

            return password;
        }

        // Описание сохранения пароля
        static void Save()
        {
            //Строка подключения, которая задает режим чтения и записи
            string connectionString = "Data Source=Passwords.db;Mode=ReadWriteCreate";

            using (var con = new SqliteConnection(connectionString))
            {
                con.Open();
            }
        }

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

                    Console.WriteLine("Хотите сохранить пароль?\n(1) Да\n(2) Нет");
                    keyInfo = Console.ReadKey(true);
                    if (keyInfo.Key == ConsoleKey.D1)
                    {
                        Clipboard.SetText();
                    }

                    Console.WriteLine("Нажмите любую кнопку, чтобы продолжить");
                    Console.ReadKey(); // Пауза

                    Console.Clear(); // Очистка консоли
                    Menu();
                }

                // Сохранение пароля
                else if (keyInfo.Key == ConsoleKey.D2)
                {
                    Console.Clear(); // Очистка консоли

                    Save();

                }
            }

        }
    }
}
