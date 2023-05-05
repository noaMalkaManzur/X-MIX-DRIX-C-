using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex02.ConsoleUtils;

namespace UI_X_MIX
{
    class Board
    {
        int m_Size;
        char [,] m_Board;
        
        public void initBoard(int i_Size)
        {
            m_Size = i_Size;
            m_Board = new char[i_Size, i_Size];

            for (int i = 0; i < i_Size; i++)
            {
                for (int j = 0; j < i_Size; j++)
                {
                    m_Board[i, j] = ' ';
                }
            }
            Screen.Clear();
            PrintBoard();
        }
        public void PrintBoard()
        {
            Console.Write("  ");
            for (int i = 1; i <= m_Size; i++)
            {
                Console.Write(i + " | ");
            }
            Console.WriteLine();

            for (int i = 0; i < m_Size; i++)
            {
                Console.Write((i + 1) + " ");
                for (int j = 0; j < m_Size; j++)
                {
                    Console.Write(m_Board[i , j] + " | ");
                }
                Console.WriteLine();
            }
        }
        public bool updateBoardInPosition(char i_Symbol, Point i_Position)
        {
            Screen.Clear();
            m_Board[i_Position.x, i_Position.y ] = i_Symbol;
            bool wonGame = checkIfWon( i_Position);
            PrintBoard();

            return wonGame;
        }
        public bool IsSymbolAtCoordinate(Point i_Coordinate)
        {
            return m_Board[i_Coordinate.x, i_Coordinate.y] == ' ';
        }
        
        private bool checkIfWon(Point i_Position)
        {

            bool rowWonGame = true;
            bool colWonGame = true;
            bool diaWonGame1 = true;
            bool diaWonGame2 = true;

            for (int i = 0; i < m_Size - 1; i++)
            {   
                if (m_Board[i_Position.x , i] != m_Board[i_Position.x, i + 1] )
                {
                    rowWonGame = false;
                }
                if (m_Board[i, i_Position.y] != m_Board[i + 1, i_Position.y])
                {
                    colWonGame = false;
                }
                if (m_Board[i, i] != m_Board[i + 1, i + 1] || m_Board[i, i] == ' ')
                {
                    diaWonGame1 = false;
                }         
                if (m_Board[i, m_Size - i - 1] != m_Board[i + 1, m_Size - i - 2] ||  m_Board[i + 1, m_Size - i - 2] == ' ')
                {
                    diaWonGame2 = false;
                }
                
            }     
            return rowWonGame || colWonGame || diaWonGame1 || diaWonGame2;
        }

        /*public static Point FindWinningMove(Board board, char player)
        {
            int size = board.Size;

            // Check rows
            for (int i = 0; i < size; i++)
            {
                int rowSum = 0;
                int emptyRowCol = -1;

                for (int j = 0; j < size; j++)
                {
                    char cell = board.GetCell(new Point(i, j));
                    if (cell == player)
                    {
                        rowSum++;
                    }
                    else if (cell == Board.k_EmptyCell)
                    {
                        emptyRowCol = j;
                    }
                    else
                    {
                        // This row doesn't contain a winning move for the player
                        break;
                    }

                    if (j == size - 1 && rowSum == size - 1 && emptyRowCol != -1)
                    {
                        return new Point(i, emptyRowCol);
                    }
                }
            }

            // Check columns
            for (int j = 0; j < size; j++)
            {
                int colSum = 0;
                int emptyColRow = -1;

                for (int i = 0; i < size; i++)
                {
                    char cell = board.GetCell(new Point(i, j));
                    if (cell == player)
                    {
                        colSum++;
                    }
                    else if (cell == Board.k_EmptyCell)
                    {
                        emptyColRow = i;
                    }
                    else
                    {
                        // This column doesn't contain a winning move for the player
                        break;
                    }

                    if (i == size - 1 && colSum == size - 1 && emptyColRow != -1)
                    {
                        return new Point(emptyColRow, j);
                    }
                }
            }

            // Check diagonals
            int diagSum = 0;
            int emptyDiagRow = -1;
            for (int i = 0; i < size; i++)
            {
                char cell = board.GetCell(new Point(i, i));
                if (cell == player)
                {
                    diagSum++;
                }
                else if (cell == Board.k_EmptyCell)
                {
                    emptyDiagRow = i;
                }
                else
                {
                    // This diagonal doesn't contain a winning move for the player
                    break;
                }

                if (i == size - 1 && diagSum == size - 1 && emptyDiagRow != -1)
                {
                    return new Point(emptyDiagRow, emptyDiagRow);
                }
            }

            int reverseDiagSum = 0;
            int emptyReverseDiagRow = -1;
            for (int i = 0; i < size; i++)
            {
                char cell = board.GetCell(new Point(i, size - 1 - i));
                if (cell == player)
                {
                    reverseDiagSum++;
                }
                else if (cell == Board.k_EmptyCell)
                {
                    emptyReverseDiagRow = i;
                }
                else
                {
                    // This diagonal doesn't contain a winning move for the player
                    break;
                }

                if (i == size - 1 && reverseDiagSum == size - 1 && emptyReverseDiagRow != -1)
                {
                    return new Point(emptyReverseDiagRow, size - 1 - emptyReverseDiagRow);
                }
            }

            return Point.Empty;
        }*/
    }
}
