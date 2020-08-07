using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KINO_PROJECT
{
    static class KinoHelper
    {
        public static void PlayKino()
        {
            Console.Clear();
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            string separator = "__________________________________________";

            Console.WriteLine("Welcome to KINO.\nThese are the numbers of our game:\n");
            showNumbers();
            Console.WriteLine("\nIn each round 20 numbers of the above are drawn.\nYou win 2 times your bet if you have correctly predicted ONLY or EVEN \nand 4 times your bet if you have correctly predicted DRAW.");

            Console.WriteLine("\nYou bet if most of the KINO lottery numbers are ONLY, EVEN or if it will be DRAW.");
            string choice = playersChoice();
            Console.WriteLine("\nYou chose: {0}", choice);
            Console.WriteLine(separator);

            Console.WriteLine("\nPlease choose how much money you want to bet per draw.");
            int money = moneyBet();
            Console.WriteLine("\nYou want to bet: {0}\u20AC", money);
            Console.WriteLine(separator);

            Console.WriteLine("\nPlease chose how many rounds you want to play.");
            int numberofDraws = numberOfRounds();
            Console.WriteLine("\nYou will bet for {0} rounds.",numberofDraws);
            Console.WriteLine(separator);

            KINO kino = new KINO(choice, money, numberofDraws);

            Console.WriteLine("\nResults:\n");
            kino.runDraw();
            Console.WriteLine("\nTotal bet: {0}", money * numberofDraws);
            Console.WriteLine("Total Earnings: {0}", kino.totalEarnings);
        }
        public static int numberOfRounds()
        {
            int[] menu3 = new int[] { 2, 3, 4, 5, 6, 10, 20, 50, 100, 200 };
            int numberofDraws = menuSelect(menu3);
            return numberofDraws;
        }
        public static int moneyBet()
        {
            string symbol = "\u20AC";
            string[] menu2 = new string[] { $"1{symbol}", $"2{symbol}", $"3{symbol}", $"5{symbol}", $"10{symbol}", $"15{symbol}", $"20{symbol}", $"30{symbol}", $"50{symbol}", $"100{symbol}" };
            string playersChoice2 = menuSelect(menu2);
            int moneyBet = Convert.ToInt32(playersChoice2.Substring(0, playersChoice2.Length - 1));
            return moneyBet;
        }
        public static string playersChoice()
        {
            string[] menu1 = new string[] { "ONLY", "EVEN", "DRAW" };
            string playersChoice = menuSelect(menu1);
            return playersChoice;
        }
        public static void showNumbers()
        {
            for (int i = 1; i <= 80; i++)
            {
                if (i < 10)
                    Console.Write("{0}  ", i);
                else
                    Console.Write("{0} ", i);
                if (i % 10 == 0)
                    Console.WriteLine();
            }
        }

        public static T menuSelect<T>(T[] menuChoices)
        {
            //The menuChoices is an array e.g. {1, 20, 5, 15}, {"start", "continue", "end"}
            //The selection is done with the Left/Right arrows and the choice is returned as the Type of the array

            Console.WriteLine("Use Arrow Left/Right and press Enter to choose\n");
            for (int i = 0; i < menuChoices.Count(); i++)
            {
                Console.Write(menuChoices[i].ToString() + " ");
            }

            ConsoleKey k;
            int cursorPositionX = 0;
            int cursorPositionY = Console.CursorTop;

            int windowInitialize = Console.WindowWidth;

            int choice = 0;
            do
            {
                int previusChoice = choice;
                Console.CursorVisible = false;
                Console.CursorLeft = cursorPositionX;

                Console.BackgroundColor = ConsoleColor.Cyan;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write(menuChoices[choice]);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write(".");
                Console.ResetColor();

                Console.CursorLeft = cursorPositionX;

                k = Console.ReadKey(true).Key;
                if (Console.WindowWidth < windowInitialize)
                    Console.WindowWidth = windowInitialize;

                if (k == ConsoleKey.RightArrow)
                {
                    if (choice < menuChoices.Count() - 1)
                    {
                        cursorPositionX += (menuChoices[choice].ToString().Length + 1);
                        choice++;
                    }
                }
                else if (k == ConsoleKey.LeftArrow)
                {
                    if (choice > 0)
                    {
                        choice--;
                        cursorPositionX -= (menuChoices[choice].ToString().Length + 1);
                    }
                }

                Console.Write(menuChoices[previusChoice]);
                Console.CursorLeft = cursorPositionX;

            } while (k != ConsoleKey.Enter);
            Console.CursorTop += 1;
            Console.CursorLeft = 0;
            Console.CursorVisible = true;
            return menuChoices[choice];
        }
    }
}
