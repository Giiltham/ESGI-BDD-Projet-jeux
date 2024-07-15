using System;
using projet_jeux.Exceptions;

namespace projet_jeux
{
    public class TicTacToe
    {
        public char CurrentPlayer { get; private set; }
        public TicTacToeBoard Board { get; private set; }

        public int ScorePlayerX { get; private set; }
        public int ScorePlayerO { get; private set; }

        public char? CurrentWinner { get; private set; }

        public bool GameEnded { get; private set; } = true;
        
        public void NewGame()
        {
            CurrentPlayer = 'X';
            Board = new TicTacToeBoard();
            GameEnded = false;
        }

        public void Place(int x, int y)
        {
            if (GameEnded)
            {
                throw new GameEndedException("Can't place if the game has ended, run NewGame() to start a new game");
            }
            
            if (Board.Get(x, y) != ' ')
            {
                return;
            }
            
            Board.Set(x, y, CurrentPlayer);

            CurrentWinner = Winner();
            
            if(CurrentWinner == null)
            {
                SwitchPlayer();
            }
            else
            {
                EndGame();
            }
        }

        public void EndGame()
        {
            if (GameEnded) return;
            
            CurrentWinner = Winner();
            
            if (CurrentWinner == 'X')
            {
                ScorePlayerX += 1;
            }
            else if (CurrentWinner == 'O')
            {
                ScorePlayerO += 1;
            }

            GameEnded = true;
        }
        
        public char? Winner()
        {
            for (int i = 0; i < 3; i++)
            {
                if (Board.Get(i, 0) == Board.Get(i, 1) && Board.Get(i, 1) == Board.Get(i, 2) && Board.Get(i, 0) != ' ')
                {
                    return Board.Get(i, 0);
                }
            }

            for (int i = 0; i < 3; i++)
            {
                if (Board.Get(0, i) == Board.Get(1, i) && Board.Get(1, i) == Board.Get(2, i) && Board.Get(0, i) != ' ')
                {
                    return Board.Get(0, i);
                }
            }

            if (Board.Get(0, 0) == Board.Get(1, 1) && Board.Get(1, 1) == Board.Get(2, 2) && Board.Get(0, 0) != ' ')
            {
                return Board.Get(0, 0);
            }

            if (Board.Get(0, 2) == Board.Get(1, 1) && Board.Get(1, 1) == Board.Get(2, 0) && Board.Get(0, 2) != ' ')
            {
                return Board.Get(0, 2);
            }

            return null;
        }

        public void ForceSwitchPlayer(char player)
        {
            if (player != 'X' && player != 'O')
            {
                throw new ArgumentException("Player should be X or O");
            }

            CurrentPlayer = player;
        }
        
        private void SwitchPlayer()
        {
            CurrentPlayer = CurrentPlayer == 'X' ? 'O' : 'X';
        }
    }
}