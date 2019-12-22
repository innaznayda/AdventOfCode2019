using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day2 {
    class Program {
        private static int[] Sequence;

        static void Main(string[] args) {
            Sequence = GetContent();

            ProcessSequence(1);
            //Console.WriteLine(Sequence[0]);


            Console.ReadLine();

        }

        private static void ProcessSequence(int input) {
            var currentPosition = 0;
            while (currentPosition >= 0) {
                switch (Sequence[currentPosition] % 100) {
                    case 1:
                        HandleSum(currentPosition);
                        currentPosition = currentPosition + 4;
                        break;
                    case 2:
                        HandleMultiply(currentPosition);
                        currentPosition = currentPosition + 4;
                        break;
                    case 3:
                        HandleOpcode3(currentPosition, input);
                        currentPosition = currentPosition + 2;
                        break;
                    case 4:
                        HandleOpcode4(currentPosition);
                        currentPosition = currentPosition + 2;
                        break;
                    case 99:
                        currentPosition = -1;
                        break;
                    default: break;
                }
            }
        }

        private static void HandleOpcode3(int currentPosition, int input) {
            //the instruction 3,50 would take an input value and store it at address 50
            var resultPosition = Sequence[currentPosition + 1];
            Sequence[resultPosition] = input;
        }

        private static void HandleOpcode4(int currentPosition) {
            //Opcode 4 outputs the value of its only parameter. For example, the instruction 4,50 would output the value at address 50.
            var resultPosition = Sequence[currentPosition + 1];
            Console.WriteLine(Sequence[resultPosition]);
        }

        private static void HandleMultiply(int currentPosition) {
            var fisrtMode = (Sequence[currentPosition] / 100) % 10;
            var secondMode = (Sequence[currentPosition] / 1000) % 10;
            var outputMode = (Sequence[currentPosition] / 10000) % 10;
            var fisrtAdder = fisrtMode == 0 ? Sequence[Sequence[currentPosition + 1]] : Sequence[currentPosition + 1];
            var secondAdder = secondMode == 0 ? Sequence[Sequence[currentPosition + 2]] : Sequence[currentPosition + 2];


            var resultPostion = Sequence[currentPosition + 3];
            Sequence[resultPostion] = fisrtAdder * secondAdder;
        }

        private static void HandleSum(int currentPosition) {

            var fisrtMode = (Sequence[currentPosition] / 100) % 10;
            var secondMode = (Sequence[currentPosition] / 1000) % 10;
            var outputMode = (Sequence[currentPosition] / 10000) % 10;
            var fisrtAdder = fisrtMode == 0 ? Sequence[Sequence[currentPosition + 1]] : Sequence[currentPosition + 1];
            var secondAdder = secondMode == 0 ? Sequence[Sequence[currentPosition + 2]] : Sequence[currentPosition + 2];


            var resultPostion = Sequence[currentPosition + 3];
            Sequence[resultPostion] = fisrtAdder + secondAdder;
        }

        private static int[] GetContent() {
            string text = File.ReadAllText("InputFile.txt");
            var moduleMassText = text.Split(new[] { ',' }, StringSplitOptions.None);
            return moduleMassText.Select(el => Int32.Parse(el)).ToArray();

        }
    }
}
