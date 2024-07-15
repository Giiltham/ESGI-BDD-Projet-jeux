using System;
using System.Collections.Generic;
using projet_jeux.Exceptions;

namespace projet_jeux
{
    public class Tennis
    {
        public int Player1Score { get; private set; }
        public int Player2Score { get; private set; }
        public int Player1Games { get; private set; }
        public int Player2Games { get; private set; }
        
        public int Player1Match { get; private set; }
        
        public int Player2Match { get; private set; }

        public List<int> SetsPlayer1 { get; private set; } = new List<int>();
        public List<int> SetsPlayer2 { get; private set; } = new List<int>();
        
        public bool GameEnded { get; private set; }


        public Tennis()
        {
            Reset();
        }

        public void Reset()
        {
            Player1Match = 0;
            Player2Match = 0;
            
            NewGame();
        }
        
        public void NewGame()
        {
            Player1Score = 0;
            Player2Score = 0;

            Player1Games = 0;
            Player2Games = 0;   
         
            SetsPlayer1 =  new List<int>();
            SetsPlayer2 =  new List<int>();

            GameEnded = false;
        }
        
        public void Player1Scores()
        {
            if (GameEnded) throw new GameEndedException();
            
            Player1Score++;
            CheckGame();
        }

        public void Player2Scores()
        {
            if (GameEnded) throw new GameEndedException();

            Player2Score++;
            CheckGame();
        }

        public void Player1WinsGame()
        {
            if (GameEnded) throw new GameEndedException();

            Player1Games++;
            Player1Score = 0;
            Player2Score = 0;
            CheckSet();
        }

        public void Player2WinsGame()
        {
            if (GameEnded) throw new GameEndedException();

            Player2Games++;
            Player1Score = 0;
            Player2Score = 0;
            CheckSet();
        }
        
        private void CheckGame()
        {
            // Check if we are in tie-break situation
            if (Player1Games == 6 && Player2Games == 6)
            {
                if (Player1Score >= 7 && Player1Score >= Player2Score + 2)
                {
                    Player1WinsGame();
                }
                else if (Player2Score >= 7 && Player2Score >= Player1Score + 2)
                {
                    Player2WinsGame();
                }
            }
            else
            {
                if (Player1Score >= 4 && Player1Score >= Player2Score + 2)
                {
                    Player1WinsGame();
                }
                else if (Player2Score >= 4 && Player2Score >= Player1Score + 2)
                {
                    Player2WinsGame();
                }
            }

        }

        private void CheckSet()
        {
            if ((Player1Games >= 6 && Player1Games >= Player2Games + 2) || Player1Games == 7)
            {
                SetsPlayer1.Add(Player1Games);
                SetsPlayer2.Add(Player2Games);
                Player1Games = 0;
                Player2Games = 0;
            }
            else if ((Player2Games >= 6 && Player2Games >= Player1Games + 2) || Player2Games == 7)
            {
                SetsPlayer1.Add(Player1Games);
                SetsPlayer2.Add(Player2Games);
                Player1Games = 0;
                Player2Games = 0;
            }

            if (SetsWonByPlayers()[0] == 2)
            {
                Player1WinsMatch();
            }

            if (SetsWonByPlayers()[1] == 2)
            {
                Player2WinsMatch();
            }
        }

        public void Player1WinsMatch()
        {
            Player1Match += 1;
            EndGame();
        }
        
        public void Player2WinsMatch()
        {
            Player2Match += 1;
            EndGame();
        }

        public void EndGame()
        {
            GameEnded = true;
        }
        
        public int[] SetsWonByPlayers()
        {
            int[] sets = { 0, 0 };
            for (int i = 0; i < SetsPlayer1.Count; i++)
            {
                if (SetsPlayer1[i] > SetsPlayer2[i])
                {
                    sets[0] += 1;
                }
                else
                {
                    sets[1] += 1;
                }
            }
            
            return sets;
        }

        public void Player1ForceWinSet()
        {
            Player1Games = 6;
            Player2Games = 0;
            Player1Score = 0;
            Player2Score = 0;
            CheckSet();
        }

        public void Player2ForceWinSet()
        {
            Player2Games = 6;
            Player1Games = 0;
            Player1Score = 0;
            Player2Score = 0;
            CheckSet();
        }
    }
}