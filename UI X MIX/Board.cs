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
        char[,] m_Board;

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
                    Console.Write(m_Board[i, j] + " | ");
                }
                Console.WriteLine();
            }
        }
        public bool updateBoardInPosition(char i_Symbol, Point i_Position)
        {
            Screen.Clear();
            m_Board[i_Position.x, i_Position.y] = i_Symbol;
            bool wonGame = checkIfWon(i_Position);
            PrintBoard();

            return wonGame;
        }
        public bool IsSymbolAtCoordinate(Point i_Coordinate)
        {
            return m_Board[i_Coordinate.x, i_Coordinate.y] == ' ';
        }
        public int Size
        {
            get{
                 return m_Size;
            }
        }

        private bool checkIfWon(Point i_Position)
        {

            bool rowWonGame = true;
            bool colWonGame = true;
            bool diaWonGame1 = true;
            bool diaWonGame2 = true;

            for (int i = 0; i < m_Size - 1; i++)
            {
                if (m_Board[i_Position.x, i] != m_Board[i_Position.x, i + 1])
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
                if (m_Board[i, m_Size - i - 1] != m_Board[i + 1, m_Size - i - 2] || m_Board[i + 1, m_Size - i - 2] == ' ')
                {
                    diaWonGame2 = false;
                }

            }
            return rowWonGame || colWonGame || diaWonGame1 || diaWonGame2;
        }
        public Point? FindWinningMove(char symbol)
        {
            // Check all rows
            for (int row = 0; row < m_Size; row++)
            {
                int emptyCount = 0;
                int symbolCount = 0;
                int emptyCol = -1;

                for (int col = 0; col < m_Size; col++)
                {
                    if (getSymbolAtCoordinate(new Point(row, col)) == ' ')
                    {
                        emptyCount++;
                        emptyCol = col;
                    }
                    else if (getSymbolAtCoordinate(new Point(row, col)) == symbol)
                    {
                        symbolCount++;
                    }
                }

                if (emptyCount == 1 && symbolCount == m_Size - 1)
                {
                    return new Point(row, emptyCol);
                }
            }

            // Check all columns
            for (int col = 0; col < m_Size; col++)
            {
                int emptyCount = 0;
                int symbolCount = 0;
                int emptyRow = -1;

                for (int row = 0; row < m_Size; row++)
                {
                    if (getSymbolAtCoordinate(new Point(row, col)) == ' ')
                    {
                        emptyCount++;
                        emptyRow = row;
                    }
                    else if (getSymbolAtCoordinate(new Point(row, col)) == symbol)
                    {
                        symbolCount++;
                    }
                }

                if (emptyCount == 1 && symbolCount == m_Size - 1)
                {
                    return new Point(emptyRow, col);
                }
            }

            // Check diagonal from top-left to bottom-right
            int diagCount = 0;
            int emptyDiagRow = -1;
            int emptyDiagCol = -1;

            for (int i = 0; i < m_Size; i++)
            {
                char symbolAtCoordinate = getSymbolAtCoordinate(new Point(i, i));

                if (symbolAtCoordinate == symbol)
                {
                    diagCount++;
                }
                else if (symbolAtCoordinate == ' ')
                {
                    emptyDiagRow = i;
                    emptyDiagCol = i;
                }
            }

            if (diagCount == m_Size - 1 && emptyDiagRow != -1 && emptyDiagCol != -1)
            {
                return new Point(emptyDiagRow, emptyDiagCol);
            }

            // Check diagonal from bottom-left to top-right
            diagCount = 0;
            emptyDiagRow = -1;
            emptyDiagCol = -1;

            for (int i = 0; i < m_Size; i++)
            {
                char symbolAtCoordinate = getSymbolAtCoordinate(new Point(i, m_Size - i - 1));

                if (symbolAtCoordinate == symbol)
                {
                    diagCount++;
                }
                else if (symbolAtCoordinate == ' ')
                {
                    emptyDiagRow = i;
                    emptyDiagCol = m_Size - i - 1;
                }
            }

            if (diagCount == m_Size - 1 && emptyDiagRow != -1 && emptyDiagCol != -1)
            {
                return new Point(emptyDiagRow, emptyDiagCol);
            }

            // No winning move found
            return null;
        }

        private char getSymbolAtCoordinate(Point i_Coordinate)
        {
            return m_Board[i_Coordinate.x, i_Coordinate.y];
        }
        public Point FindStrategicMove(char i_AISymbol)
        {
            List<Point> potentialWins = new List<Point>();
            List<Point> opponentPotentialWins = new List<Point>();

            // Check for potential winning moves for both players
            for (int i = 0; i < m_Size; i++)
            {
                for (int j = 0; j < m_Size; j++)
                {
                    Point point = new Point(i, j);

                    if (IsSymbolAtCoordinate(point))
                    {
                        updateBoardInPosition(i_AISymbol, point);

                        if (checkIfWon(point))
                        {
                            potentialWins.Add(point);
                        }
                        //maybe i_player2 the other symbol
                       updateBoardInPosition('X', point);

                        if (checkIfWon(point))
                        {
                            opponentPotentialWins.Add(point);
                        }

                        updateBoardInPosition(' ', point);
                    }
                }
            }

            // If there are potential winning moves for the current player, return one of them
            if (potentialWins.Count > 0)
            {
                return potentialWins[0];
            }
            // If there are potential winning moves for the opponent, return a move that blocks them
            else if (opponentPotentialWins.Count > 0)
            {
                return opponentPotentialWins[0];
            }
            // Otherwise, return a random empty position on the board
            else
            {
                return GetRandomEmptyPosition();
            }

        }
        public Point GetRandomEmptyPosition()
        {
            Random rnd = new Random();
           
            // Find all empty positions on the board
            List<Point> emptyPositions = new List<Point>();
            for (int i = 0; i < m_Size; i++)
            {
                for (int j = 0; j < m_Size; j++)
                {
                    if (IsSymbolAtCoordinate(new Point(i, j)))
                    {
                        emptyPositions.Add(new Point(i, j));
                    }
                }
            }

            // Select a random empty position from the list
            if (emptyPositions.Count > 0)
            {
                int randomIndex = rnd.Next(0, emptyPositions.Count);
                return emptyPositions[randomIndex];
            }
            else
            {
                // If there are no empty positions, return (-1,-1) to indicate an error
                return new Point(-1, -1);
            }
        }
        private int CountPotentialWins(Point position, char player)
        {
            int rowWins = 0, colWins = 0, diag1Wins = 0, diag2Wins = 0;

            // count potential row wins
            for (int i = 0; i < m_Size; i++)
            {
                if (i != position.y)
                {
                    if (m_Board[position.x, i] == player)
                    {
                        rowWins++;
                    }
                }
            }

            // count potential column wins
            for (int i = 0; i < m_Size; i++)
            {
                if (i != position.x)
                {
                    if (m_Board[i, position.y] == player)
                    {
                        colWins++;
                    }
                }
            }

            // count potential diagonal wins
            if (position.x == position.y)
            {
                for (int i = 0; i < m_Size; i++)
                {
                    if (i != position.x)
                    {
                        if (m_Board[i, i] == player)
                        {
                            diag1Wins++;
                        }
                    }
                }
            }

            if (position.x + position.y == m_Size - 1)
            {
                for (int i = 0; i < m_Size; i++)
                {
                    if (i != position.x)
                    {
                        if (m_Board[i, m_Size - 1 - i] == player)
                        {
                            diag2Wins++;
                        }
                    }
                }
            }

            return rowWins + colWins + diag1Wins + diag2Wins;
        }
    } 
}
