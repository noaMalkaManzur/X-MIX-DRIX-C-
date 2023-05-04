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
            Console.WriteLine("Please select your board size from 3 to 9");
            int sizeBoard = getSizeBoard();
            Console.WriteLine("Please press 1 to compete against human Or press 2 to compete computer");
            //int userMode = getUserMode();

            GameEngine.StartGame(sizeBoard, 1);
        }

        private static int getSizeBoard()
        {
            int sizeBoard = int.Parse(Console.ReadLine());
            
            while (sizeBoard < 3 || sizeBoard > 9)
            {
                Console.WriteLine("Please enter a vaild input");
                sizeBoard = int.Parse(Console.ReadLine());
            }
            return sizeBoard;
        }

        public static Point GetPositionInput()
        {
            Point coordinateUser = new Point();
            Console.WriteLine("Please enter coordinate");

            string input = Console.ReadLine();
            if (input == "Q")
            {
                coordinateUser.x = -1;
                coordinateUser.y = -1;
            }
            else
            {
                string[] parts = input.Split(' ');
                coordinateUser.x = int.Parse(parts[0]) - 1;
                coordinateUser.y = int.Parse(parts[1]) - 1;
            }
            
            return coordinateUser;
        }
        public static bool IsPlayerContinuing()
        {
            Console.WriteLine("Do you want to play again?\n press 1 to continue \n press 0 to quit");
            int userChoice = int.Parse(Console.ReadLine());// move to function that checks for valid input
            return userChoice == 1;
 
        }
    }
}
