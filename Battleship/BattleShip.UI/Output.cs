using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using System.Threading;
using BattleShip.BLL.Ships;

namespace BattleShip.UI
{
    public static class Output
    {
        public static void SplashScreen()
        {
            // Display information about the Game

            Console.WriteLine("BattleShip - A Software Guild Production");
            Console.WriteLine();
            Console.WriteLine("In Battleship, each player has their own hidden board");
            Console.WriteLine("which is a 10 x 10 grid where the row are denoted by A-J ");
            Console.WriteLine("and the columns by the by the numbers 1-10");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("     1   2   3   4   5   6   7   8   9   10");
            Console.WriteLine(" A | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |");
            Console.WriteLine(" B | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |");
            Console.WriteLine(" C | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |");
            Console.WriteLine(" D | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |");
            Console.WriteLine(" E | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |");
            Console.WriteLine(" F | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |");
            Console.WriteLine(" G | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |");
            Console.WriteLine(" H | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |");
            Console.WriteLine(" I | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |");
            Console.WriteLine(" J | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |");

            Console.WriteLine();
            Console.WriteLine("Destroyer - 2 spaces");
            Console.WriteLine("Cruiser - 3 spaces");
            Console.WriteLine("Submarine - 3 spaces");
            Console.WriteLine("Battleship - 4 spaces");
            Console.WriteLine("Carrier - 5 spaces");
            Thread.Sleep(10000);
            Console.Clear();
        }


        public static void DisplayBoard(Player opponent)
        {

            // Display attack's history shots made on opponent's game board

            string output = "";
            ShotHistory response;

            for (int displayNumber = 1; displayNumber <= 10; displayNumber++)
            {
                // Create to column coordinate numbers
                if (displayNumber == 1) { output = "   "; }

                output += $"  {displayNumber} ";
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(output);

            for (int xCoordinate = 1; xCoordinate <= 10; xCoordinate++)
            {
                output = "";

                // Create row Letters per line.
                output += $" {Convert.ToChar(65 + xCoordinate - 1)} |";


                for (int yCoordinate = 1; yCoordinate <= 10; yCoordinate++)

                {
                    Console.Write(output);
                    output = "";

                    response = opponent.PlayerBoard.CheckCoordinate(new Coordinate(xCoordinate, yCoordinate));

                    switch (response)
                    {

                        case ShotHistory.Hit:
                            Console.ForegroundColor = ConsoleColor.Red;
                            output += " H"; // Text turns to Red for 'Hit'
                            Console.Write(output);
                            break;

                        case ShotHistory.Miss:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            output += " M"; // Text turns to Yellow for 'Missed'
                            Console.Write(output);
                            break;

                        case ShotHistory.Unknown:
                            Console.ForegroundColor = ConsoleColor.Blue;
                            output += " 0"; // Text turn to Blue for Unknown Location, where no FireShots have been made to
                            Console.Write(output);
                            break;

                    }

                    output = "";
                    Console.ForegroundColor = ConsoleColor.White;
                    output += " |";

                }

                Console.WriteLine(output);
            }

        }

        public static void ResponseFromPlaceShip(ShipPlacement response, ShipType ship)
        {
            // Display's feed to user's input during placement of Ships Location.
            if (response != ShipPlacement.Ok)
            {

                if (response == ShipPlacement.NotEnoughSpace) Console.WriteLine($"Not Enough Space for {ship}");
                if (response == ShipPlacement.Overlap) Console.WriteLine($"You were trying to overlap your {ship} onto prexisting ship");

            }
            else Console.WriteLine(ship + " was deployed!");
        }

        public static void FireShotReponse(FireShotResponse response)
        {

            //Display's output to user response from the FireShot function
           
            string output = "";

            switch (response.ShotStatus)
            {

                case ShotStatus.Duplicate:
                    output = "Duplicate";  // Attempt to FireShot at previouse location, try again
                    break;
                case ShotStatus.Hit:
                    output = "Hit";  // Fire shot and hit a Ship
                    break;
                case ShotStatus.HitAndSunk:
                    output = $"Hit And Sunk {response.ShipImpacted}"; // Fire shot and new Ship and sunk it.
                    break;
                case ShotStatus.Invalid:  // Invalid input when FireShot was called
                    output = "Invalid";
                    break;
                case ShotStatus.Miss:
                    output = "Miss";  // Fire shot and missed a Ship
                    break;
                case ShotStatus.Victory:
                    output = "Victory";  // Last Shot has been fired and all opponent's have been sunk.
                    break;


            }
            Console.WriteLine();
            Console.WriteLine("Result from Attack : " + output);
        }

    }
}
