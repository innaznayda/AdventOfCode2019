using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day3 {
    class Program {
        private static string[] fisrtWire;
        private static string[] secondWire;

        class Point {
            public Point(int v1, int v2, int v3) {
                this.X = v1;
                this.Y = v2;
                this.Steps = v3;
            }
            public Point(int v1, int v2) {
                this.X = v1;
                this.Y = v2;

            }

            public int X { get; set; }
            public int Y { get; set; }
            public int Steps { get; set; }
        }

        class PointComparer : IEqualityComparer<Point> {            
            public bool Equals(Point x, Point y) {
                return x.X == y.X && x.Y == y.Y;
            }
            
            public int GetHashCode(Point point) {
                //Check whether the object is null
                if (Object.ReferenceEquals(point, null)) return 0;

                //Get hash code for the Name field if it is not null.
                int hashProductName = point.X == null ? 0 : point.X.GetHashCode();

                //Get hash code for the Code field.
                int hashProductCode = point.Y.GetHashCode();

                //Calculate the hash code for the product.
                return hashProductName ^ hashProductCode;
            }
        }

        static void Main(string[] args) {
            GetContent();
            var firstPath = BuildPath(fisrtWire);
            var secondPath = BuildPath(secondWire);

            var common = firstPath.Intersect(secondPath, new PointComparer()).Skip(1);

            Console.WriteLine(common.Select(point => CalculateManhattanDistanceToCenter(point.X, point.Y)).Min());

            List<int> steps = new List<int>();
            foreach (var elem in common) {
                var f = firstPath.Where(el => el.X == elem.X && el.Y == elem.Y).First().Steps + secondPath.Where(el => el.X == elem.X && el.Y == elem.Y).First().Steps;
                steps.Add(f);
            }

            Console.WriteLine(steps.Min());
            Console.ReadLine();
        }

        private static List<Point> BuildPath(string[] wire) {
            List<Point> points = new List<Point>();
            var fisrtPoint = new Point(0, 0, 0);
            points.Add(fisrtPoint);
            foreach (var s in wire) {
                var number = Int32.Parse(s.Remove(0, 1));
                switch (s[0]) {
                    case 'R':
                        var rng = Enumerable.Range(points.Last().X + 1, number);
                        foreach (var x in rng) {
                            points.Add(new Point(x, points.Last().Y, points.Last().Steps + 1));
                        }

                        break;
                    case 'L':
                        var rng2 = Enumerable.Range(points.Last().X - number, number).Reverse();
                        foreach (var x in rng2) {
                            points.Add(new Point(x, points.Last().Y, points.Last().Steps + 1));
                        }
                        break;
                    case 'U':
                        var rng3 = Enumerable.Range(points.Last().Y + 1, number);
                        foreach (var y in rng3) {
                            points.Add(new Point(points.Last().X, y, points.Last().Steps + 1));
                        }
                        break;
                    case 'D':
                        var rng4 = Enumerable.Range(points.Last().Y - number, number).Reverse();
                        foreach (var y in rng4) {
                            points.Add(new Point(points.Last().X, y, points.Last().Steps + 1));
                        }
                        break;
                    default: break;
                }
            }
            return points;
        }

        private static void GetContent() {
            string text = File.ReadAllText("InputFile.txt");
            var allText = text.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            fisrtWire = allText[0].Split(new[] { ',' });
            secondWire = allText[1].Split(new[] { ',' }); ;
        }

        private static int CalculateManhattanDistanceToCenter(int x, int y) {
            return Math.Abs(x - 0) + Math.Abs(y - 0);
        }
    }
}
