using Functions;
using System;
using System.Collections.Generic;


internal class Password_generator
{
    static void Main()
    {
        ConsoleKeyInfo action = Password.Menu();
        switch (action.Key) 
        {
            case ConsoleKey.D1:
                Console.Clear();

                List<char> symbols = Password.Symbols();

                Console.WriteLine("Enter the count of symbols you want to use:");
                int lenght = Console.Read();
                

                string password = Password.Genearate(symbols, lenght);

                Console.WriteLine(password);

                Console.WriteLine("Press any key to continiue");
                Console.Read();

                //Password.Menu();

                break;
            case ConsoleKey.D2:

                List<char> Symbols = Password.Symbols();

                Console.WriteLine(Symbols);

                break;
            case ConsoleKey.D3:
                Console.Clear();

                Password.Show_list();

                Console.WriteLine("Press any key to continiu");
                ConsoleKeyInfo key = Console.ReadKey(true);
                Console.Clear();

                break;
        }
    }
}