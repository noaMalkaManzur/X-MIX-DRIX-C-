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
        public void updateBoardInPosition(char i_Symbol, Point i_Position)
        {
            Screen.Clear();
            m_Board[i_Position.x, i_Position.y] = i_Symbol;
            PrintBoard();
        }


    }
}
