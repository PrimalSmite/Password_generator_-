using Functions;
using System;
using System.Collections.Generic;


internal class Password_generator
{
    static int Main()
    {
        ConsoleKeyInfo action = Password.Menu();

        while (action.Key != ConsoleKey.D0)
        {
            switch (action.Key)
            {
                case ConsoleKey.D1:
                    Console.Clear();

                    List<char> symbols = Password.Symbols();

                    Console.WriteLine("Enter the count of symbols you want to use:");
                    byte lenght = 0;
                    var lenght_i = Console.ReadLine();
                    while (lenght == 0)
                    {
                        if (byte.TryParse(lenght_i, out lenght))
                        {
                            Password.Genearate(symbols, lenght);
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Enter the count from 1 to 255");
                            lenght_i = Console.ReadLine();
                            Console.Clear();
                        }

                    }
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();

                    Console.Clear();

                    Password.Menu();

                    break;

                case ConsoleKey.D2:
                    Console.Clear();

                    List<char> Symbols = Password.Symbols();
                    List<string> Values = Data.EnterDataValues();
                    Data.Save(Values);
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();

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
        return 0;
    }
}