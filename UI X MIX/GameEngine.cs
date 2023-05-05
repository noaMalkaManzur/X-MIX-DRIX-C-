using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UI_X_MIX
{
    class GameEngine
    {
        char m_Player1 = 'X';
        char m_Player2 = 'O';
        int m_Player1Points = 0;
        int m_Player2Points = 0;

        public static void StartGame(int i_SizeBoard, int i_Mode)
        {
            GameEngine game = new GameEngine();
            Board m_Board = new Board();
            bool userContinue = true;

            while(userContinue)
            {
                m_Board.initBoard(i_SizeBoard);
                game.PlayerMode(m_Board, i_SizeBoard);
                userContinue = UI.IsPlayerContinuing();
            } 
        }
        
        public void PlayerMode(Board i_Board, int i_SizeBoard)
        {
            bool player1Won = false;
            bool player2Won = false;
            int moveCounter = 1;

            while (!player1Won && !player2Won && moveCounter <= i_SizeBoard * i_SizeBoard)
            {
                Point pointPlayer1 = UI.GetPositionInput(i_SizeBoard, i_Board);
                if (pointPlayer1.x == -1)
                {
                    Console.WriteLine("Player 1 quit");
                    break;
                }

                player1Won = i_Board.updateBoardInPosition(m_Player1, pointPlayer1);

                if (player1Won)
                {
                    m_Player1Points++;
                    Console.WriteLine("X won!!!");
                    break;
                }

                moveCounter++;

                if (moveCounter > i_SizeBoard * i_SizeBoard)
                {
                    Console.WriteLine("it is a tie");
                    break;
                }

                Point pointPlayer2 = UI.GetPositionInput(i_SizeBoard, i_Board);
                if (pointPlayer2.x == -1)
                {
                    Console.WriteLine("Player 2 quit");
                    break;
                }

                player2Won = i_Board.updateBoardInPosition(m_Player2, pointPlayer2);

                if (player2Won)
                {
                    m_Player2Points++;
                    Console.WriteLine("O won!!!");
                    break;
                }

                moveCounter++;
            }
            Console.WriteLine("X:{0} points\nO:{1} points", m_Player1Points, m_Player2Points);
        }

      
    }
}
/*
        public void AIMode(Board i_Board, int i_SizeBoard)
        {
            bool player1Won = false;
            bool player2Won = false;
            int moveCounter = 1;

            while (player1Won == false && player2Won == false && moveCounter < i_SizeBoard * i_SizeBoard)
            {
                // Player 1's turn
                Point pointPlayer1 = UI.GetPositionInput();
                if (pointPlayer1.x != -1)
                {
                    player1Won = i_Board.updateBoardInPosition(m_Player1, pointPlayer1);
                    if (!player1Won && moveCounter < i_SizeBoard * i_SizeBoard)
                    {
                        // Computer's turn
                        Point pointPlayer2 = new Point(-1, -1);
                        if (moveCounter == 1)
                        {
                            // If the computer is the first to move, place a mark in a random corner
                            List<Point> corners = new List<Point>()
                    {
                        new Point(0, 0),
                        new Point(0, i_SizeBoard - 1),
                        new Point(i_SizeBoard - 1, 0),
                        new Point(i_SizeBoard - 1, i_SizeBoard - 1)
                    };
                            pointPlayer2 = corners[new Random().Next(corners.Count)];
                        }
                        else
                        {
                            // Check for winning move
                            pointPlayer2 = i_Board.FindWinningMove(m_Player2);
                            if (pointPlayer2.x == -1)
                            {
                                // Check for blocking move
                                pointPlayer2 = i_Board.FindWinningMove(m_Player1);
                                if (pointPlayer2.x == -1)
                                {
                                    // Choose a random move
                                    pointPlayer2 = i_Board.FindRandomEmptyPosition();
                                }
                            }
                        }
                        player2Won = i_Board.updateBoardInPosition(m_Player2, pointPlayer2);
                        moveCounter++;
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    return;
                }
            }

            if (player1Won || player2Won)
            {
                Console.WriteLine(player1Won ? "X won!!!" : "O won!!! ");
            }
            else
            {
                Console.WriteLine("it is a tie");
            }
        }*/