using Functions;
using System;
using System.Collections.Generic;
using System.Windows.Forms;


internal class Password_generator
{
    static void Main()
    {
        ConsoleKeyInfo action = Password.menu();
        switch (action.Key) 
        {
            case ConsoleKey.D1:
                Console.Clear();

                /*
                List<string> data_values = Password.enter_data_values();

                string service_name = data_values[0];
                string service_login = data_values[1];
                string service_password = data_values[2];
                */

                List<char> symbols = Password.Symbols();

                Console.WriteLine("Enter the count of symbols you want to use");
                int lenght = Console.Read();
                

                string password =  Password.Genearate(symbols, lenght);

                Console.WriteLine(password);

                Console.WriteLine("Press any key to continiue");
                Console.Read();

                break;
        }
    }
}