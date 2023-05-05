using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UI_X_MIX
{
    class UI
    {
        public static void ShowMenu()
        {
            UI ui = new UI();
            Console.WriteLine("Please select your board size from 3 to 9");
            int sizeBoard = ui.getSizeBoard();
            Console.WriteLine("Please choose a game mode\nPress 1 to compete against human\nPress 2 to compete computer");
            int userMode = ui.getUserMode();

            GameEngine.StartGame(sizeBoard, 1);
        }
        public static bool IsPlayerContinuing()
        {
            Console.WriteLine("Do you want to play again?\n press 1 to continue \n press 0 to quit");
            int userChoice = int.Parse(Console.ReadLine());// move to function that checks for valid input
            return userChoice == 1;

        }
        public static bool CanPlaceSymbolWithinBoundaries(Point i_Coordinate, int i_BoardSize, Board i_Board)
        {
            bool validCoordinate = true;

            if (i_Coordinate.x < 0 || i_Coordinate.x >= i_BoardSize || i_Coordinate.y < 0 || i_Coordinate.y >= i_BoardSize)
            {
                Console.WriteLine("Invalid coordinate. Please enter a coordinate within the board boundaries.");
                validCoordinate = false;
            }
            else if (!i_Board.IsSymbolAtCoordinate(i_Coordinate))
            {
                Console.WriteLine("A symbol is already at this coordinate. Please choose another coordinate.");
                validCoordinate = false;
            }
            return validCoordinate;
        }
        public static Point GetPositionInput(int i_BoardSize, Board i_Board)
        {
            Point coordinateUser;
            while (true)
            {
                Console.WriteLine("Please enter coordinate");

                string input = Console.ReadLine();
                if (input.ToUpper() == "Q")
                {
                    coordinateUser = new Point(-1, -1);
                    break;
                }
                string[] parts = input.Split(' ');
                if (parts.Length != 2)
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    continue;
                }
                int x = int.Parse(parts[0]);
                int y = int.Parse(parts[1]);

                coordinateUser = new Point(x - 1, y - 1);
                if (!CanPlaceSymbolWithinBoundaries(coordinateUser, i_BoardSize, i_Board))
                {
                    continue;
                }
                break;
            }
            return coordinateUser;
        }
        private int getUserMode()
        {   // to check if char?
            int userMode = int.Parse(Console.ReadLine());

            while (userMode != 1 && userMode != 2)
            {
                Console.WriteLine("Please enter a vaild input");
                userMode = int.Parse(Console.ReadLine());
            }
            return userMode;
        }
        private int getSizeBoard()
        {
            int sizeBoard = int.Parse(Console.ReadLine());

            while (sizeBoard < 3 || sizeBoard > 9)
            {
                Console.WriteLine("Please enter a vaild input");
                sizeBoard = int.Parse(Console.ReadLine());
            }
            return sizeBoard;
        }  
        public int GetUserChoiceOfContinuation()
        {
            int userContinuateGame = int.Parse(Console.ReadLine());

            while (userContinuateGame != 0 && userContinuateGame != 1)
            {
                Console.WriteLine("Please enter a vaild input");
                userContinuateGame = int.Parse(Console.ReadLine());
            }
            return userContinuateGame;
        }
    }
}