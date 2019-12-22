using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day6 {
    public class Couple {
        public string FirstNode;
        public string SecondNode;

        public Couple(string v1, string v2) {
            this.FirstNode = v1;
            this.SecondNode = v2;
        }
    }

    class Program {
        static void Main(string[] args) {
            var content = GetContent();
            Console.WriteLine($"Number of lines : {content.Distinct().Count()}");
            List<string> elements = new List<string>();
            List<Couple> couples = new List<Couple>();


            foreach (var s in content) {
                var elems = s.Split(new char[] { ')' });
                couples.Add(new Couple(elems[0], elems[1]));
                elements.AddRange(new List<string>(elems));
            }
            couples.Reverse();
            var dist = elements.Distinct();
            Console.WriteLine($"Number of distinct nodes : {dist.Count()}");

            var currentValue = "";
            var total = 0;
            foreach (var el in dist) {
                total += OrbitNumber(couples, el);
            }

            var YouOrbit = couples.Where(elem => elem.SecondNode == "YOU").First().FirstNode;
            var SanOrbit = couples.Where(elem => elem.SecondNode == "SAN").First().FirstNode;

            var pathToYou = OrbitPath(couples,YouOrbit);
            var pathToSan = OrbitPath(couples, SanOrbit);

            var common = pathToSan.Intersect(pathToYou).FirstOrDefault();

            var numberOfSteps = pathToSan.IndexOf(common) + pathToYou.IndexOf(common);

            Console.WriteLine(numberOfSteps);

            Console.WriteLine(total);

            Console.ReadLine();

        }

        private static int OrbitNumber(List<Couple> couples, string el) {
            var count = 0;
            var nod = couples.Find(elem => elem.SecondNode == el);
            while (nod != null) {
                count++;
                nod = couples.Find(elem => elem.SecondNode == nod.FirstNode);
            }

            return count;
        }

        private static List<string> OrbitPath (List<Couple> couples, string el) {
            List < string > path = new List<string>() { el };
            var nod = couples.Find(elem => elem.SecondNode == el);
            while (nod != null) {
                path.Add(nod.FirstNode);
                nod = couples.Find(elem => elem.SecondNode == nod.FirstNode);
            }

            return path;
        }

        private static List<string> GetContent() {
            string text = File.ReadAllText("InputFile.txt");
            var allText = text.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            return new List<string>(allText);
        }
    }
}
