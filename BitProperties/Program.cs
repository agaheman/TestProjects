using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace BitProperties
{
    class Program
    {
        [Flags]
        public enum Option
        {
            White = 1,                  //0b00000000   =   2^0
            Delicious = 2,              //0b00000001   =   2^1
            Expensive = 4,              //0b00000010   =   2^2
        }

        static void Main(string[] args)
        {
            var listOfOptions = new List<Option>
            {
                Option.White,
                Option.Expensive
            };

            int savedValue = SaveOptions(listOfOptions); // 5

            List<Option> restoredOptions = LoadOptions(savedValue);

            Console.ReadLine();
        }

        private static List<Option> LoadOptions(int savedValue)
        {
            var optionsRestored = (Option)Enum.Parse(typeof(Option), savedValue.ToString());

            Console.WriteLine("LoadOptions");
            Console.WriteLine("_".PadRight(50, '_'));

            ShowDetails(optionsRestored);

            var options = optionsRestored.ToString()
                                   .Replace(" ", null)
                                   .Split(',').ToList()
                                   .Select(str => (Option)Enum.Parse(typeof(Option), str));

            return options.ToList();
        }

        private static int SaveOptions(List<Option> listOfOptions)
        {
            var optionsToStore = new Option();
            foreach (var option in listOfOptions)
            {
                optionsToStore = option | optionsToStore;
            }

            Console.WriteLine("SaveOptions");
            Console.WriteLine("_".PadRight(50,'_'));

            ShowDetails(optionsToStore);

            return (int)optionsToStore;
        }

        private static void ShowDetails(Option options)
        {
            var Options = options.ToString()
                                   .Replace(" ", null)
                                   .Split(',').ToList()
                                   .Select(str => (Option)Enum.Parse(typeof(Option), str));

            foreach (var option in Options)
            {
                var optionNames = option.ToString("G").PadRight(20);
                var optionsValue = option.ToString("D").PadRight(20);
                Console.Write(($"{optionNames}:{optionsValue}:").PadRight(40));
                Console.WriteLine($"{Convert.ToString((int)option, 2).PadLeft(8, '0')}");
            }

            Console.WriteLine(new string(' ', 42) + new string('-', 8));
            Console.Write(":".PadLeft(42, ' '));
            Console.WriteLine($"{Convert.ToString((int)options, 2).PadLeft(8, '0')}");
            Console.WriteLine();
        }
    }
}
