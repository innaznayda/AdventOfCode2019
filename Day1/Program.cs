using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day1 {
    class Program {
        static void Main(string[] args) {
            //read ana parse input
            var input = GetContent();
            //calculate fuel for each module and sum up      

            Console.WriteLine(input.Select(module =>CalculateFuelForModule(module)).Sum());
            Console.WriteLine(input.Select(module => CalculateFuelForModuleAndFuel(module)).Sum());           

            Console.ReadLine();

        }

        private static List<int> GetContent() {
            string text = File.ReadAllText("InputFile.txt");            
            var moduleMassText = text.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            return moduleMassText.Select(el => Int32.Parse(el)).ToList();

        }

        private static int CalculateFuelForModule(int mass) {   
            
            return mass / 3 - 2;
        }

        private static int CalculateFuelForModuleAndFuel(int mass) {
            var result = 0;
            int fuel = CalculateFuelForModule(mass);
            while (fuel >= 0) {
                result += fuel;
                fuel = CalculateFuelForModule(fuel);
            }

            return result;
        }
    }
}
