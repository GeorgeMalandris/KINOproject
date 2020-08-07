using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace KINO_PROJECT
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKey k;
            do
            {
                KinoHelper.PlayKino();
                Console.WriteLine("\nTo exit press Esc, to play again press Enter");
                do
                {
                    k = Console.ReadKey(true).Key;
                } while (k != ConsoleKey.Escape && k != ConsoleKey.Enter);
            } while (k != ConsoleKey.Escape);
        }
    }
}
