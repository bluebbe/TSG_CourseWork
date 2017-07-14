using BattleShip.BLL.Requests;
using BattleShip.BLL.Ships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    public class Input
    {

        public static string RequestingName(int player)
        {
            string output = "";
            // query and store his/her name
            Console.Write($"Please Enter Name for Player #{player+1}: ");
            output = Console.ReadLine();

            return output;

        }


        public static Coordinate RequstingCoordinates(Player player, string ship)
        {

            // This function is requesting Coordinates during the Placement of Ship(s)
            string output;
            Coordinate coordinate;
            bool verifiedCoordinates = false;


            do
            {
                Console.WriteLine();
                Console.WriteLine($"{player.PlayerName}, We need to deploy your {ship}.");
                Console.Write($"Please Enter Coordinates: ");
                output = Console.ReadLine();

                coordinate = ConvertCorridates(output);
                if (coordinate.XCoordinate == 0 || coordinate.YCoordinate == 0) verifiedCoordinates = false;
                else verifiedCoordinates = true;
            } while (!verifiedCoordinates);

            return coordinate;

        }

        public static Coordinate RequestingAttackCoordinates(Player attacker, Player opponent)
        {

            // This function is requesting Coordinates for the FireShot per Player

            string output = "";
          
            Console.WriteLine();
            Console.Write($"{attacker.PlayerName}, Enter your attack Coordinates: ");

            output = Console.ReadLine();

            return ConvertCorridates(output);
            

        }
        public static ShipDirection RequstingDirection(Player player, string ship)
        {
            // This function is requesting Direction during the Placement of Ship(s)

            ShipDirection output = ShipDirection.Up;

            int menuChoice = -1;

            while (menuChoice < 0)
            {
                Console.WriteLine($"Please Enter Direction of your {ship} ship,");
                Console.Write("0)Up 1)Down 2)Left 3)Right : ");

                if (int.TryParse(Console.ReadLine(), out menuChoice))
                {
                    if (menuChoice >= 0 && menuChoice <= 3)
                        break;
                    else
                        menuChoice = -1;
                }

            }

            switch (menuChoice)
            {
                case 0:
                    output = ShipDirection.Up;
                    break;
                case 1:
                    output = ShipDirection.Down;
                    break;
                case 2:
                    output = ShipDirection.Left;
                    break;
                case 3:
                    output = ShipDirection.Right;
                    break;

            }



            return output;
        }

        private static Coordinate ConvertCorridates(string userInput)
        {

            // Verify Coordinates are vaild for userInput
            //if not valid, default Coordiantes (0,0) are returning.  These will not allow any ship
            //to be placed on the board.

            int x = 0;
            int y = 0;
            
           
                if (!string.IsNullOrEmpty(userInput))
                {
                    if (userInput.Length <= 3)
                    {

                        if (int.TryParse(userInput.Substring(1, userInput.Length - 1), out y))
                        {
                            if (y > 0 && y < 11)

                            {

                                switch (userInput.Substring(0, 1))
                                {
                                    case "a":
                                    case "A":
                                        x = 1;
                                        break;

                                    case "b":
                                    case "B":
                                        x = 2;
                                        break;

                                    case "c":
                                    case "C":
                                        x = 3;
                                        break;

                                    case "d":
                                    case "D":
                                        x = 4;
                                        break;

                                    case "e":
                                    case "E":
                                        x = 5;
                                        break;

                                    case "f":
                                    case "F":
                                        x = 6;
                                        break;

                                    case "g":
                                    case "G":
                                        x = 7;
                                        break;

                                    case "h":
                                    case "H":
                                        x = 8;
                                        break;

                                    case "i":
                                    case "I":
                                        x = 9;
                                        break;

                                    case "j":
                                    case "J":
                                        x = 10;
                                        break;

                                    default:
                                        x = 0;
                                        break;
                                }


                            }
                            else y = 0;


                        }

                    }

                }
            
            return new Coordinate(x, y);

        }

        public static void PromptForNextPlayer(string playerName)
        {

            Console.WriteLine($"Press Any Key for {playerName}'s Turn");
            Console.ReadKey();
            Console.Clear();

        }

        public static bool VictoryPlayAgain()
        {
            // Prompt to PlayAgain
            string output ="";
            bool quit = true;
            Console.WriteLine("You won the Game");
         
                do
                {
                    Console.Write("Do you wish to go Again? (Y/N)");
                    output = Console.ReadLine();
                } while (output.Length != 1);


                output = output.ToUpper();
                if (output[0] == 'Y') { quit = true; }
                if (output[0] == 'N') { quit = false; }
                
            return quit;
            
        }
    }
}
