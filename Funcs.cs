using System;
using System.Text;
using System.Collections.Generic;
using System.Windows.Forms;


namespace Functions
{
    class Password
    {

        //Menu
        public static ConsoleKeyInfo Menu()
        {
            Console.WriteLine("This is a beta version of program");
            Console.WriteLine("Chose an action:\n(1) Generate a password\n(2) Show a password\n");
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
        //Entering data
        public static List<string> Enter_data_values()
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
    }
}