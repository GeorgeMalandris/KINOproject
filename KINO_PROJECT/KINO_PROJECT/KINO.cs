using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KINO_PROJECT
{
    class KINO : IKino
    {
        public int moneyBet { get; set; }
        public int numberofDraws { get; set; }
        public int totalEarnings { get; set; }

        public string choice { get; private set; }
        string result;

        Random ran = new Random();
        List<int> drawNumbers;

        public KINO(string choice, int moneyBet, int numberofDraws)
        {
            this.choice = choice;
            this.moneyBet = moneyBet;
            this.numberofDraws = numberofDraws;

            drawNumbers = new List<int>();
            result = "";
        }

        public void ShowDrawNumbers()
        {
            foreach (int number in drawNumbers)
            {
                if (number < 10)
                    Console.Write("{0}  ", number);
                else
                    Console.Write("{0} ", number);
            }
            Console.Write("   {0}",result);
        }
        public void calcEarning()
        {
            int onlyCounter = 0;
            int evenCounter = 0;
            foreach (int number in drawNumbers)
            {
                if (number % 2 == 0)
                    evenCounter++;
                else
                    onlyCounter++;
            }
            if (evenCounter > onlyCounter)
                result = "EVEN";
            else if (evenCounter < onlyCounter)
                result = "ODD";
            else
                result = "DRAW";
            if (choice == result && result != "DRAW")
                totalEarnings += 2 * moneyBet;
            else if (choice == result)
                totalEarnings += 4 * moneyBet;
        }

        public void runDraw()
        {
            for (int i = 1; i <= numberofDraws; i++)
            {
                drawNumbers.Clear();
                do
                {
                    int nextDraw = ran.Next(1, 81);
                    if (!drawNumbers.Contains(nextDraw))
                        drawNumbers.Add(nextDraw);
                } while (drawNumbers.Count < 20);
                calcEarning();
                ShowDrawNumbers();
                Console.WriteLine();
            }
        }  
    }
}
