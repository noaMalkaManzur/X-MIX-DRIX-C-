using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace UI_X_MIX
{
    class Program
    {
        public static void Main()
        {
            //showMenu();
            Console.WriteLine("Please select your board size from 3 to 9");
            Board b = new Board();
            b.initBoard(5);
            b.PrintBoard();

            
        }
        private static void showMenu()
        {
            Console.WriteLine("Please select your board size from 3 to 9");
            int sizeBoard = getSizeBoard();
            Console.WriteLine("Please press 1 to compete against human Or press 2 to compete computer");
            int userMode = getUserMode();
        }
        private static void getUserPosition()
        {
            Point coordinateUser = new Point();
            Console.WriteLine("Please enter coordinate");
            coordinateUser.x = int.Parse(Console.ReadLine());

        }
        
    }
}
