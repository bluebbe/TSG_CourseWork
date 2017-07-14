using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    public class Workflow
    {
        
        private Player[] _players = { new Player(0), new Player(1) };
        
        private static Random _rng = new Random();
        private int _currentTurn;
        private bool _boardReset;   // If players like to restart game.
        private bool _playersReady;  // Determine if Players has place ships on the board
        

        public void StartAndConfigure()
        {
            Output.SplashScreen();
            Setup();

            

        }

        public Workflow()
        {
            _currentTurn = _rng.Next(0, 2); // generate who goes first.
            _boardReset = false;
            _playersReady = false;


        }

        private void ResetBoardOnly()
        {
            Player[] newBoards = { new Player(0), new Player(1) };
            newBoards[0].PlayerName = _players[0].PlayerName;
            newBoards[1].PlayerName = _players[1].PlayerName;
            _players = newBoards;
            _boardReset = true;
            

        }

        private void Setup()
        {

            PlaceShipRequest request = new PlaceShipRequest();
            ShipPlacement response;
            

            if (!_boardReset)
            {
                _players[0].PlayerName = Input.RequestingName(0);
                _players[1].PlayerName = Input.RequestingName(1);
            }
            Console.Clear();

            for (int player = 0; player < _players.Length; player++)
            {

                for (int ship = 0; ship < Enum.GetValues(typeof(ShipType)).Length; ship++)

                {

                    request.ShipType = (ShipType)Enum.Parse(typeof(ShipType), (Enum.GetName(typeof(ShipType), ship)));

                    request.Coordinate = Input.RequstingCoordinates(_players[player], Enum.GetName(typeof(ShipType), ship));
                    request.Direction = Input.RequstingDirection(_players[player], Enum.GetName(typeof(ShipType), ship));
                    response = _players[player].PlayerBoard.PlaceShip(request);
                    if (response != ShipPlacement.Ok)
                    {
                        
                        ship--; //redo ship by decrease ship index by -1;
                        
                    }
                  
                    Output.ResponseFromPlaceShip(response, request.ShipType);
                }

                Console.Clear();

            }

            _playersReady = true;

        }

        private bool LetsGoToWar()
        {
            Coordinate request;
            FireShotResponse response;
           
            int attacker=1;
            int opponent=0;
            
            do
            {
                // determine's player turn
                if (_currentTurn == 1)  
                {
                    attacker = 0;
                    opponent = 1;
                    _currentTurn = 0;
                }
                else
                {
                    attacker = 1;
                    opponent = 0;
                    _currentTurn = 1;
                }

            
                Output.DisplayBoard(_players[opponent]);

                do
                {
                    request = Input.RequestingAttackCoordinates(_players[attacker], _players[opponent]);
                    response = _players[opponent].PlayerBoard.FireShot(request);

                    Output.FireShotReponse(response);

                    
                } while (response.ShotStatus == ShotStatus.Duplicate || response.ShotStatus == ShotStatus.Invalid);
                if (response.ShotStatus != ShotStatus.Victory)
                {

                    Input.PromptForNextPlayer(_players[opponent].PlayerName);
                
                }

               
            } while (response.ShotStatus != ShotStatus.Victory);
            
            return Input.VictoryPlayAgain();
        }


        public void DeclareWar()
        {

          

            bool runAgain = false;

            do
            {
                if (!_playersReady) break;  // _playersReady breaks while loop to prevent LetsGoToWar run. 
                                            // Players need to place ships before continuing code.

                runAgain = LetsGoToWar();
                if (runAgain)
                {
                    _playersReady = false;
                    ResetBoardOnly();
                    Setup();
                }

            } while (runAgain);

        }

    }
}
