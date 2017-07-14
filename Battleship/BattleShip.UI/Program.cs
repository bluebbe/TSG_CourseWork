using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Workflow game = new Workflow();
            game.StartAndConfigure();
            game.DeclareWar();   // DeclareWare function will not start until 
                                //  StartAndConfigure is ran first
                                //  StartAndConfigure needs to setup players 
                                // first BEFORE Declare War can run.
        }
    }
}
