using System;
using System.Collections.Generic;


namespace Functions
{
    static class Password
    {
        public static ConsoleKeyInfo menu()
        {
            Console.WriteLine("This is a beta version of program");
            Console.WriteLine("Chose an action:\n(1) Generate a password\n(2) Show a password");
            ConsoleKeyInfo action_key = Console.ReadKey(true);

            return action_key;
        }

        public static List<string> enter_data_values()
        {
            List<string> values = new List<string>();

            Console.WriteLine("Enter the service name:\n");
            string name = Console.ReadLine();
            values.Add(name);


            Console.WriteLine("Enter the service login:\n");
            string login = Console.ReadLine();
            values.Add(login);

            Console.WriteLine("Enter the service password:\n");
            string password = Console.ReadLine();
            values.Add(password);

            return values;
        }

        public static List<char> Symbols()
        {

            List<char> symbols = new List<char>();

            for (char i = 'а'; i <= 'z'; i++)
            {
                symbols.Add(i);
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

        public static string Genearate(List<char> symbols, int lenght)
        {
            Random random = new Random();
            string result_password = "";

            for (int i=0; i <= lenght; i++)
            {
                int randomIndex = random.Next(symbols.Count);
                result_password += symbols[randomIndex];
            }

            Console.WriteLine(result_password);

            return result_password;
        }
    }
}