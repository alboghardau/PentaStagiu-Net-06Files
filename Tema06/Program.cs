using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Tema06
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> goodNumbers = new List<string>();
            List<string> badNumbers = new List<string>();
            string[] file;

            string filename = "numbers.txt";

            if (File.Exists(filename))
            {
                file = File.ReadAllLines(filename);

                foreach (string line in file)
                {
                    if (TryParse(line))
                    {
                        goodNumbers.Add(line);
                    }
                    else
                    {
                        badNumbers.Add(line);
                    }
                }

                Console.WriteLine("GOOD NUMBERS:");
                goodNumbers.ForEach(number => Console.WriteLine(number.ToString()));
                Console.WriteLine("BAD NUMBERS:");
                badNumbers.ForEach(number => Console.WriteLine(number.ToString()));

                MyWriter goodBoy = new MyWriter(goodNumbers, "correctNumbers.txt");
                goodBoy.WriteAll();

                MyWriter badBoy = new MyWriter(badNumbers, "incorrectNumbers.txt");
                badBoy.WriteAll();
            }
            else
            {
                Console.WriteLine("Input file not found!");
            }
        }

        private static Boolean TryParse(string line)
        {
            try
            {
                int.Parse(line);
                return true;
            }catch(Exception e)
            {
                return false;
            }
        }

    }
}
