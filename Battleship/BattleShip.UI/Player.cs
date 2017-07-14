using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;

namespace BattleShip.UI
{
    enum Players
    { Player1, Player2
    }

    public class Player
    {

        public Board PlayerBoard { get; set; } = new Board();
     

        public string PlayerName
        {
            get; set;
        }


        public int PlayerNumber
        {       
            get; private set;
        }


        public Player(int playerNumber)
        {
            PlayerNumber = playerNumber;
        }
    }
}
