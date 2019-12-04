using System;
using System.Linq;

namespace Day4 {
    class Program {
        static void Main(string[] args) {
            int counter = 0;
            int counterAdvanced = 0;
            for (int i = 145852; i <= 616942; i++) {
                var digits = i.ToString().ToCharArray().Select(el => Int32.Parse(el.ToString())).ToArray();
                if (SameAdjacentDigits(digits) && NeverDecreaseDigits(digits)) {
                    counter++;
                }
                if (SameAdjacentDigitsAdvanced(digits) && NeverDecreaseDigits(digits)) {
                    counterAdvanced++;
                }

            }
            Console.WriteLine(counter);
            Console.WriteLine(counterAdvanced);
            Console.ReadLine();
        }

        private static bool NeverDecreaseDigits(int[] digits) {
            for (int i = 0; i < digits.Length - 1; i++) {
                if (digits[i] > digits[i + 1]) {
                    return false;
                }
            }
            return true;
        }

        private static bool SameAdjacentDigits(int[] digits) {
            for (int i = 0; i < digits.Length - 1; i++) {
                if (digits[i] == digits[i + 1]) {
                    return true;
                }
            }
            return false;
        }

        private static bool SameAdjacentDigitsAdvanced(int[] digits) {
            int counter = 1;
            bool found = false;
            for (int i = 0; i < digits.Length - 1; i++) {
                if (digits[i] == digits[i + 1]) {
                    counter++;
                } else {
                    if (counter == 2) {
                        found = true;
                    }
                    counter = 1;
                }
            }
            return found || counter == 2;
        }
    }
}
