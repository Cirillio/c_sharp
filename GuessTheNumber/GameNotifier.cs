using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumber
{
    internal class GameNotifier
    {
        private int searchedX;
        private int minNum;
        private int maxNum;

        private int half;

        private int lastNum;
        private int lastDiff;

        public GameNotifier(int randomNumber, int _minNum, int _maxNum) {

            searchedX = randomNumber;
            minNum = _minNum;
            maxNum = _maxNum;

            if (minNum > maxNum) 
            {
                (minNum, maxNum) = (maxNum, minNum);
            }

            half = (maxNum - minNum) / 2;

            if (searchedX > half)
            {
                lastNum = minNum;
            }
            else {
                lastNum = maxNum;
            }

            if (searchedX > lastNum) {
                lastDiff = searchedX - lastNum;
            }
            else {
                lastDiff = lastNum - searchedX;
            }


        }


        public string GetClue() {
            int clues = 2;

            if (minNum < 0 && maxNum > 0) {
                clues++;
            }

            switch (Random.Shared.Next(1, clues+1)) {
                case 1:
                    if (searchedX < half)
                    {
                        return "Число меньше половины.";
                    }
                    else {
                        return "Число больше половины.";
                    }
                case 2:
                    if (searchedX % 2 == 0)
                    {
                        return "Число четное.";
                    }
                    else {
                        return "Число нечетное.";
                    }
                case 3:
                    if (searchedX < 0)
                    {
                        return "Число меньше нуля.";
                    }
                    else {
                        return "Число больше нуля.";
                    }
            }
            return "";
        }

        public string GetNotify(int newNum) {

            if (newNum < minNum || newNum > maxNum)
            {
                return "Вы ввели число за пределами диапазона.";
            }

            switch (Random.Shared.Next(1, 3)) 
            {
                case 1:
                    int newDiff;
                    if (searchedX > newNum)
                    {
                        newDiff = searchedX - newNum;
                    }
                    else
                    {
                        newDiff = newNum - searchedX;
                    }
                    if (newDiff < lastDiff)
                    {
                        lastDiff = newDiff;
                        return "Вы стали ближе.";
                    }
                    else
                    {
                        lastDiff = newDiff;
                        return "Вы отдалились.";
                    }
                case 2:
                    if (newNum > searchedX)
                    {
                        if ((newNum - searchedX) <= 20)
                        {
                            if ((newNum - searchedX) <= 10)
                            {
                                return "Очень горячо.";
                            }
                            else
                            {
                                return "Горячо.";
                            }
                        }
                        else
                        {
                            if ((newNum - searchedX) > 40)
                            {
                                return "Очень холодно.";
                            }
                            else
                            {
                                return "Холодно";
                            }
                        }
                    }
                    else {
                        if ((searchedX - newNum) <= 20)
                        {
                            if ((searchedX - newNum) <= 10)
                            {
                                return "Очень горячо.";
                            }
                            else
                            {
                                return "Горячо.";
                            }
                        }
                        else
                        {
                            if ((searchedX - newNum) > 40)
                            {
                                return "Очень холодно.";
                            }
                            else
                            {
                                return "Холодно";
                            }
                        }
                    }
            }
            return "";
        }
    }
}
