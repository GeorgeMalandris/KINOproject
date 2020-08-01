using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KINO_PROJECT
{
    interface IKino
    {
        int moneyBet { get; set; }
        int numberofDraws { get; set; }
        int totalEarnings { get; set; }

        void ShowDrawNumbers();
        void calcEarning();
        void runDraw();
    }
}
