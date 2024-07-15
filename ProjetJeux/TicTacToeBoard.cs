using System;
using System.Collections.Generic;

namespace projet_jeux
{
    public class TicTacToeBoard
    {
        private List<List<char>> _board = NewEmptyBoard();
        
        public static List<List<char>> NewEmptyBoard()
        {
            List<List<char>> board = new List<List<char>>();
            for (int i = 0; i < 3; i++)
            {
                board.Add(new List<char>());
                for (int j = 0; j < 3; j++)
                {
                    board[i].Add(' ');    
                }
            }

            return board;
        }

        public void SetBoard(List<List<char>> board)
        {
            _board = board;
        }

        public bool IsEmpty()
        {
            foreach (var chars in _board)
            {
                foreach (var cell in chars)
                {
                    if (cell != ' ')
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public void Set(int x, int y, char c)
        {
            if (x < 0 || x >= 3 || y < 0 || y >= 3)
            {
                throw new ArgumentOutOfRangeException("The position is outside the board");
            }
            
            _board[x][y] = c;
        }

        public char Get(int x, int y)
        {
            if (x < 0 || x >= 3 || y < 0 || y >= 3)
            {
                throw new ArgumentOutOfRangeException("The position is outside the board");
            }
            return _board[x][y];
        }
    }
}