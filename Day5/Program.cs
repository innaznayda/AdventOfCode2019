using Day5;
using System;
using System.IO;
using System.Linq;

namespace Day2 {
    class Program {
        private static int[] Sequence;

        static void Main(string[] args) {
            Sequence = GetContent();
            
            var IntComputer = new IntComputer(Sequence);
            IntComputer.ProcessSequence(5);
           
            Console.ReadLine();

        }

        
        private static int[] GetContent() {
            string text = File.ReadAllText("InputFile.txt");
            var moduleMassText = text.Split(new[] { ',' }, StringSplitOptions.None);
            return moduleMassText.Select(el => Int32.Parse(el)).ToArray();

        }
    }
}
