using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day8 {
    class Program {
        static void Main(string[] args) {
            //The image you received is 25 pixels wide and 6 pixels tall.
            //To make sure the image wasn't corrupted during transmission, 
            //the Elves would like you to find the layer that contains the fewest 0 digits. 
            //On that layer, what is the number of 1 digits multiplied by the number of 2 digits?

            int width = 25;
            int height = 6;
            List<int> allInput = GetInput();
            var layers = SplitinputIntoLayers(allInput, width * height);
            var neededLayer = FindFewestZeros(layers);

            //Part1
            var numberOf1 = neededLayer.Where(c => c == 1).Count();
            var numberOf2 = neededLayer.Where(c => c == 2).Count();
            Console.WriteLine(numberOf1 * numberOf2);
            //Part2
            // 0 is black, 1 is white, and 2 is transparent.

            for(int i = 0;i < width * height;i++) {
                var n = layers.Select(el => el[i]);
                Console.ForegroundColor = ConsoleColor.Red;
                int element = n.Where(el => el != 2).First();
                if(element == 0) {
                    Console.ForegroundColor = ConsoleColor.Black;
                } else { Console.ForegroundColor = ConsoleColor.White; }


                Console.Write(element);
                if (((i+1) % 25 == 0) &&(i != 0)) {
                    Console.WriteLine();
                }
            }



            Console.ReadLine();

        }

        private static List<int> FindFewestZeros(List<List<int>> layers) {
            var minZerosNumber = int.MaxValue;
            var currentLayer = new List<int>();
            foreach(var l in layers) {
                var currentZero = l.Where(el => el == 0).Count();
                if(currentZero < minZerosNumber) {
                    minZerosNumber = currentZero;
                    currentLayer = l;
                }
            }
            return currentLayer;
        }

        private static List<List<int>> SplitinputIntoLayers(List<int> allInput, int size) {
            var list = new List<List<int>>();

            for(int i = 0;i < allInput.Count;i += size) {
                list.Add(allInput.GetRange(i, Math.Min(size, allInput.Count - i)));
            }

            return list;
        }



        private static List<int> GetInput() {
            string text = File.ReadAllText("InputFile.txt");
            List<char> datalist = new List<char>();
            datalist.AddRange(text);
            var digits = datalist.Select(el => int.Parse(el.ToString())).ToList();
            return digits;
        }
    }
}
