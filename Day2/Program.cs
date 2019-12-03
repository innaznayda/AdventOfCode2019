using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day2 {
    class Program {
        private static int[] Sequence;

        static void Main(string[] args) {
            Sequence = GetContent();
            ProcessSequence();
            Console.WriteLine(Sequence[0]);

            FindArguments(19690720);

            Console.ReadLine();

        }

        private static void FindArguments(int v) {

            for (int i = 0; i < 100; i++) {
                if (Sequence[0] == v) {
                    break;
                }
                for (int j = 0; j < 100; j++) {
                    Sequence = GetContent();
                    Sequence[1] = i;
                    Sequence[2] = j;
                    ProcessSequence();
                    if (Sequence[0] == v) {
                        break;
                    }
                }                
            }

            Console.WriteLine(Sequence[0]);
            Console.WriteLine(Sequence[1]);
            Console.WriteLine(Sequence[2]);
        }

        //6327510 12,2
        //19690720


        private static void ProcessSequence() {
            var currentPosition = 0;
            while (currentPosition >= 0) {
                switch (Sequence[currentPosition]) {
                    case 1:
                        HandleSum(currentPosition);
                        currentPosition = currentPosition + 4;
                        break;
                    case 2:
                        HandleMultiply(currentPosition);
                        currentPosition = currentPosition + 4;
                        break;
                    case 99:
                        currentPosition = -1;
                        break;
                    default: break;
                }
            }
        }

        private static void HandleMultiply(int currentPosition) {
            var firstAdderPosition = Sequence[currentPosition + 1];
            var secondAdderPosition = Sequence[currentPosition + 2];
            var resultPostion = Sequence[currentPosition + 3];
            Sequence[resultPostion] = Sequence[firstAdderPosition] * Sequence[secondAdderPosition];
        }

        private static void HandleSum(int currentPosition) {
            //For example, if your Intcode computer encounters 
            //1,10,20,30, it should read the values at positions 10 and 20, 
            //add those values, and then overwrite the value at position 30 with their sum.
            var firstAdderPosition = Sequence[currentPosition + 1];
            var secondAdderPosition = Sequence[currentPosition + 2];
            var resultPostion = Sequence[currentPosition + 3];
            Sequence[resultPostion] = Sequence[firstAdderPosition] + Sequence[secondAdderPosition];
        }

        private static int[] GetContent() {
            string text = File.ReadAllText("InputFile.txt");
            var moduleMassText = text.Split(new[] { ',' }, StringSplitOptions.None);
            return moduleMassText.Select(el => Int32.Parse(el)).ToArray();

        }
    }
}
