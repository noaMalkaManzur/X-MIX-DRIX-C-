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
            Board board = new Board();
            bool userContinue = true;

            while (userContinue)
            {
                board.initBoard(i_SizeBoard);
                //game.PlayerMode(board);
                game.AIMode(board, 'O');
                userContinue = UI.IsPlayerContinuing();
            }
        }

        public void PlayerMode(Board i_Board)
        {
            bool player1Won = false;
            bool player2Won = false;
            int moveCounter = 1;

            while (!player1Won && !player2Won && moveCounter <= i_Board.Size * i_Board.Size)
            {
                Point pointPlayer1 = UI.GetPositionInput(i_Board);
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

                if (moveCounter > i_Board.Size * i_Board.Size)
                {
                    Console.WriteLine("it is a tie");
                    break;
                }

                Point pointPlayer2 = UI.GetPositionInput(i_Board);
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
        public void AIMode(Board i_Board, int i_SizeBoard)
        {
            bool playerWon = false;
            int moveCounter = 1;

            while (!playerWon && moveCounter <= i_SizeBoard * i_SizeBoard)
            {
                Point pointPlayer = UI.GetPositionInput(i_Board);
                if (pointPlayer.x == -1)
                {
                    Console.WriteLine("Player quit");
                    break;
                }

                playerWon = i_Board.updateBoardInPosition(m_Player1, pointPlayer);

                if (playerWon)
                {
                    m_Player1Points++;
                    Console.WriteLine("Player won!!!");
                    break;
                }

                moveCounter++;

                if (moveCounter >= i_SizeBoard * i_SizeBoard)
                {
                    Console.WriteLine("it is a tie");
                    break;
                }

                Point pointAI = i_Board.FindStrategicMove(m_Player2);
                playerWon = i_Board.updateBoardInPosition(m_Player2, pointAI);

                if (playerWon)
                {
                    m_Player2Points++;
                    Console.WriteLine("Computer won!!!");
                    break;
                }

                moveCounter++;
            }
            Console.WriteLine("Player:{0} points\nComputer:{1} points", m_Player1Points, m_Player2Points);
        }

    }

}
/* public void AIMode(Board i_Board, int i_SizeBoard)
        {
            bool playerWon = false;
            int moveCounter = 1;

            while (!playerWon && moveCounter <= i_SizeBoard * i_SizeBoard)
            {
                Point pointPlayer = UI.GetPositionInput(i_Board);
                if (pointPlayer.x == -1)
                {
                    Console.WriteLine("Player quit");
                    break;
                }

                playerWon = i_Board.updateBoardInPosition(m_Player1, pointPlayer);

                if (playerWon)
                {
                    m_Player1Points++;
                    Console.WriteLine("Player won!!!");
                    break;
                }

                moveCounter++;

                if (moveCounter > i_SizeBoard * i_SizeBoard)
                {
                    Console.WriteLine("it is a tie");
                    break;
                }

                Point pointAI = i_Board.GetRandomEmptyPosition();
                playerWon = i_Board.updateBoardInPosition(m_Player2, pointAI);

                if (playerWon)
                {
                    m_Player2Points++;
                    Console.WriteLine("Computer won!!!");
                    break;
                }

                moveCounter++;
            }
            Console.WriteLine("Player:{0} points\nComputer:{1} points", m_Player1Points, m_Player2Points);
        }*/