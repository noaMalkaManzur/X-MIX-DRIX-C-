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
            int  moveCounter = 1;

            while (player1Won == false && player2Won == false && moveCounter < i_SizeBoard * i_SizeBoard)
            {
                Point pointPlayer1 = UI.GetPositionInput();
                if (pointPlayer1.x != -1)
                {
                    player1Won = i_Board.updateBoardInPosition(m_Player1, pointPlayer1);
                    if (!player1Won && moveCounter < i_SizeBoard * i_SizeBoard)
                    {
                        Point pointPlayer2 = UI.GetPositionInput();
                        if (pointPlayer2.x != -1)
                        {
                            player2Won = i_Board.updateBoardInPosition(m_Player2, pointPlayer2);
                        }
                        else
                        {
                            return;
                        }
                    }
                    moveCounter++;
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

        }
        
    }
}
