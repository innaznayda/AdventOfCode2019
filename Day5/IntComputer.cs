using System;

namespace Day5 {
    public class IntComputer {
        private int[] Sequence;

        public IntComputer(int[] sequence) {
            Sequence = sequence;
        }

        public void ProcessSequence(int input) {
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
                    case 5:
                        currentPosition = HandleJumpIfTrue(currentPosition);
                        break;
                    case 6:
                        currentPosition = HandleJumpIfFalse(currentPosition);
                        break;
                        break;
                    case 7:
                        HandleLessThan(currentPosition);
                        currentPosition = currentPosition + 4;
                        break;
                    case 8:
                        HandleEquals(currentPosition);
                        currentPosition = currentPosition + 4;
                        break;
                    case 99:
                        currentPosition = -1;
                        break;
                    default: break;
                }
            }
        }

        private void HandleEquals(int currentPosition) {
            //Opcode 8 is equals: if the first parameter is equal to the second parameter, 
            //it stores 1 in the position given by the third parameter.Otherwise, it stores 0.
            var fisrtMode = (Sequence[currentPosition] / 100) % 10;
            var secondMode = (Sequence[currentPosition] / 1000) % 10;
            var outputMode = (Sequence[currentPosition] / 10000) % 10;
            var fisrtParam = fisrtMode == 0 ? Sequence[Sequence[currentPosition + 1]] : Sequence[currentPosition + 1];
            var secondParam = secondMode == 0 ? Sequence[Sequence[currentPosition + 2]] : Sequence[currentPosition + 2];
            var resultPostion = Sequence[currentPosition + 3];
            if (fisrtParam == secondParam) {
                Sequence[resultPostion] = 1;
            } else {
                Sequence[resultPostion] = 0;
            }

        }

        private void HandleLessThan(int currentPosition) {
            //Opcode 7 is less than: if the first parameter is less than the second parameter,
            //it stores 1 in the position given by the third parameter.Otherwise, it stores 0.
            var fisrtMode = (Sequence[currentPosition] / 100) % 10;
            var secondMode = (Sequence[currentPosition] / 1000) % 10;
            var outputMode = (Sequence[currentPosition] / 10000) % 10;
            var fisrtParam = fisrtMode == 0 ? Sequence[Sequence[currentPosition + 1]] : Sequence[currentPosition + 1];
            var secondParam = secondMode == 0 ? Sequence[Sequence[currentPosition + 2]] : Sequence[currentPosition + 2];
            var resultPostion = Sequence[currentPosition + 3];
            if (fisrtParam < secondParam) {
                Sequence[resultPostion] = 1;
            } else {
                Sequence[resultPostion] = 0;
            }

        }

        private int HandleJumpIfFalse(int currentPosition) {
            //Opcode 6 is jump -if-false: if the first parameter is zero, it sets
            //the instruction pointer to the value from the second parameter.Otherwise, it does nothing.
            var fisrtMode = (Sequence[currentPosition] / 100) % 10;
            var secondMode = (Sequence[currentPosition] / 1000) % 10;
            var outputMode = (Sequence[currentPosition] / 10000) % 10;
            var fisrtParam = fisrtMode == 0 ? Sequence[Sequence[currentPosition + 1]] : Sequence[currentPosition + 1];
            var secondParam = secondMode == 0 ? Sequence[Sequence[currentPosition + 2]] : Sequence[currentPosition + 2];
            if (fisrtParam == 0) {
                return secondParam;
            } else {
                return currentPosition + 3;
            }
        }

        private int HandleJumpIfTrue(int currentPosition) {
            //Opcode 5 is jump-if-true: if the first parameter is non-zero, it sets the instruction 
            //pointer to the value from the second parameter. Otherwise, it does nothing.
            var fisrtMode = (Sequence[currentPosition] / 100) % 10;
            var secondMode = (Sequence[currentPosition] / 1000) % 10;
            var outputMode = (Sequence[currentPosition] / 10000) % 10;
            var fisrtParam = fisrtMode == 0 ? Sequence[Sequence[currentPosition + 1]] : Sequence[currentPosition + 1];
            var secondParam = secondMode == 0 ? Sequence[Sequence[currentPosition + 2]] : Sequence[currentPosition + 2];
            if (fisrtParam != 0) {
                return secondParam;
            } else {
                return currentPosition + 3;
            }
        }

        private void HandleOpcode3(int currentPosition, int input) {
            //the instruction 3,50 would take an input value and store it at address 50
            var resultPosition = Sequence[currentPosition + 1];
            Sequence[resultPosition] = input;
        }

        private void HandleOpcode4(int currentPosition) {
            //Opcode 4 outputs the value of its only parameter. For example, the instruction 4,50 would output the value at address 50.
            var resultPosition = Sequence[currentPosition + 1];
            Console.WriteLine(Sequence[resultPosition]);
        }

        private void HandleMultiply(int currentPosition) {
            var fisrtMode = (Sequence[currentPosition] / 100) % 10;
            var secondMode = (Sequence[currentPosition] / 1000) % 10;
            var outputMode = (Sequence[currentPosition] / 10000) % 10;
            var fisrtAdder = fisrtMode == 0 ? Sequence[Sequence[currentPosition + 1]] : Sequence[currentPosition + 1];
            var secondAdder = secondMode == 0 ? Sequence[Sequence[currentPosition + 2]] : Sequence[currentPosition + 2];


            var resultPostion = Sequence[currentPosition + 3];
            Sequence[resultPostion] = fisrtAdder * secondAdder;
        }

        private void HandleSum(int currentPosition) {

            var fisrtMode = (Sequence[currentPosition] / 100) % 10;
            var secondMode = (Sequence[currentPosition] / 1000) % 10;
            var outputMode = (Sequence[currentPosition] / 10000) % 10;
            var fisrtAdder = fisrtMode == 0 ? Sequence[Sequence[currentPosition + 1]] : Sequence[currentPosition + 1];
            var secondAdder = secondMode == 0 ? Sequence[Sequence[currentPosition + 2]] : Sequence[currentPosition + 2];


            var resultPostion = Sequence[currentPosition + 3];
            Sequence[resultPostion] = fisrtAdder + secondAdder;
        }

    }
}
