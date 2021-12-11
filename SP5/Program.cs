using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {

        new E3(args);

    }
}
class E3
{
    public E3(string[] args)
    {

        Dictionary<char, string> registrationLocation = new Dictionary<char, string>();
        using (var reader = new StreamReader(@"F:\reg_loc.csv"))
        {
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (line == null) continue;
                var values = line.Split(',');
                registrationLocation.Add(char.Parse(values[0]), values[1]);
            }
        }

        while (args[0] == "help") { 
                Help();
                break;
        }
        string carReg = Convert.ToString(args[0].ToUpper());
        string regLetters = new string(carReg.Where(char.IsLetter).ToArray());
        char[] input = regLetters.ToCharArray();
        if (registrationLocation.ContainsKey(input[0]))
        {
            string location = registrationLocation[input[0]];
            string regNumbers = new string(carReg.Where(char.IsDigit).ToArray());
            try
            {
                if (regNumbers[0] >= '5')
                {
                    int output = Convert.ToInt32(regNumbers) - 50 + 2000;
                    Console.WriteLine("your car was Registered in " + location + " in the second half of " + output);
                }
                else
                {
                    int output2 = Convert.ToInt32(regNumbers) + 2000;
                    Console.WriteLine("your car was Registered in " + location + " in the first half of " + output2);
                }
            }
            catch (IndexOutOfRangeException)
            {
                string error = "The index was out of the range";
                string logFile = @"C:\Temp\error.txt";
                if (File.Exists(logFile))
                {
                    File.Delete(logFile);
                    File.Create(logFile);
                }
                using (StreamWriter writer = new StreamWriter(logFile)) 
                {
                    writer.WriteLine(error);
                }
            }
        }
        else
        {
            Console.WriteLine("Error: This input is not valid.");
            Help();
        }
        void Help()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Commands to help you if your stuck");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("How to search your vehicle registration number");
            Console.WriteLine("SP5 SV51 YLF (your registration in this format)");
            Console.WriteLine("How to Clear your Command Window");
            Console.WriteLine("cls");
            Console.ResetColor();
        }
    }





}


