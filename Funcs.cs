using System;
using System.Text;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;


namespace Functions
{
    class Password
    {

        //Menu
        public static ConsoleKeyInfo Menu()
        {
            Console.WriteLine("This is a beta version of program");
            Console.WriteLine("Chose an action:\n(1) Generate a password\n(2) Save a password\n");
            Console.WriteLine("(3) Show symbols !!!EXTRA!!!");
            ConsoleKeyInfo action_key = Console.ReadKey(true);

            return action_key;
        }

        //Creating the list with symbols
        public static List<char> Symbols()
        {

            List<char> symbols = new List<char>();

            for (char k = 'a'; k <= 'z'; k++)
            {
                symbols.Add(k);
            }

            for (char i = 'A'; i <= 'Z'; i++)
            {
                symbols.Add(i);
            }

            for (char i = '0'; i <= '9'; i++)
            {
                symbols.Add(i);
            }

            symbols.Add('!');
            symbols.Add('@');
            symbols.Add('#');
            symbols.Add('?');

            return symbols;
        }


        //Write a list
        public static string Show_list()
        {
            List<char> Symbols_list = Symbols();

            string ShowList = "";

            foreach (char i in Symbols_list)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine(ShowList);

            return ShowList;
        }

        public static string Genearate(List<char> symbols, byte lenght)
        {
            Random rnd = new Random();
            StringBuilder result = new StringBuilder();

            for (byte i = 0; i < lenght; i++)
            {
                int randomIndex = rnd.Next(symbols.Count);
                result.Append(symbols[randomIndex]);
            }
            Console.WriteLine(result.ToString());

            return result.ToString();
        }
    }



    class Data
    {
        static SqliteConnection connection;
        static SqliteCommand command;
        static string db = "Passwords.db";


        //Entering data
        public static List<string> EnterDataValues()
        {
            List<string> Values = new List<string>();

            Console.WriteLine("Enter the service name:");
            string name = Console.ReadLine();
            Values.Add(name);

            Console.WriteLine("Enter the service login:");
            string login = Console.ReadLine();
            Values.Add(login);

            Console.WriteLine("Enter the service password:");
            string password = Console.ReadLine();
            Values.Add(password);

            return Values;
        }

        static bool connect()
        {
            try
            {
                connection = new SqliteConnection("Data Source=" + db + ";Version=3;FailIfMissing=False");
                connection.Open();
                return true;
            }
            catch (SqliteException ex)
            {
                Console.WriteLine($"Ошибка доступа к базе данных. Исключение: {ex.Message}");
                return false;
            }
        }   

        public static void Save(List<string> Values)
        {
            if (connect())
            {
                Console.WriteLine("Подключено");
            }
            else
            {
                Console.WriteLine("Ошбика");
            }
            Console.WriteLine("Нажмите любую кнопку чтобы продолжить");
            Console.ReadKey();
        }



    
    }
}