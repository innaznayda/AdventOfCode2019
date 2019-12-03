using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day3 {
    class Program {
        private static string[] fisrtWire;
        private static string[] secondWire;

        class Point {
            public Point(int v1, int v2,int v3) {
                this.X = v1;
                this.Y = v2;
                this.Steps = v3;
            }

            public int X { get; set; }
            public int Y { get; set; }
            public int Steps { get; set; }
        }

        class PointComparer : IEqualityComparer<Point> {
            // Products are equal if their names and product numbers are equal.
            public bool Equals(Point x, Point y) {


                //Check whether the products' properties are equal.
                return x.X == y.X && x.Y == y.Y && x.Steps <= y.Steps;
            }


            // If Equals() returns true for a pair of objects 
            // then GetHashCode() must return the same value for these objects.

            public int GetHashCode(Point product) {
                //Check whether the object is null
                if (Object.ReferenceEquals(product, null)) return 0;

                //Get hash code for the Name field if it is not null.
                int hashProductName = product.X == null ? 0 : product.X.GetHashCode();

                //Get hash code for the Code field.
                int hashProductCode = product.Y.GetHashCode();

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

            //????????Console.WriteLine(common.Select(point => point.Steps).Min());
            Console.ReadLine();
        }

        private static List<Point> BuildPath(string[] wire) {
            List<Point> points = new List<Point>();
            var fisrtPoint = new Point(0, 0,0);
            points.Add(fisrtPoint);
            foreach (var s in wire) {
                var number = Int32.Parse(s.Remove(0, 1));
                switch (s[0]) {
                    case 'R':                        
                        var rng = Enumerable.Range(points.Last().X + 1, number);
                        foreach (var x in rng) {
                            points.Add(new Point(x, points.Last().Y, points.Last().Steps + number));
                        }

                        break;
                    case 'L':
                        var rng2 = Enumerable.Range(points.Last().X - number, number).Reverse();
                        foreach (var x in rng2) {
                            points.Add(new Point(x, points.Last().Y, points.Last().Steps + number));
                        }                        
                        break;
                    case 'U':
                        var rng3 = Enumerable.Range(points.Last().Y+1, number);
                        foreach (var y in rng3) {
                            points.Add(new Point(points.Last().X, y, points.Last().Steps + number));
                        }
                        break;
                    case 'D':
                        var rng4 = Enumerable.Range(points.Last().Y - number, number).Reverse();
                        foreach (var y in rng4) {
                            points.Add(new Point(points.Last().X, y, points.Last().Steps + number));
                        }
                        break;
                    default: break;
                }
            }
            return points;
        }

        private static void GetContent() {
            // text = File.ReadAllText("InputFile.txt");
            string text = "R8,U5,L5,D3\r\nU7,R6,D4,L4";
            var allText = text.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            fisrtWire = allText[0].Split(new[] { ',' });
            secondWire = allText[1].Split(new[] { ',' }); ;
        }

        public static int CalculateManhattanDistanceToCenter(int x, int y) {
            return Math.Abs(x - 0) + Math.Abs(y - 0);
        }
    }
}
