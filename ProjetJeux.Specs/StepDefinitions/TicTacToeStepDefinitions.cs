using FluentAssertions;
using projet_jeux;

namespace SpecFlowProjetJeux;

[Binding]
public class TicTacToeStepDefinitions
{
    private TicTacToe _ticTacToe = new ();
    
    [Given(@"la partie est lancée")]
    public void GivenLaPartieEstLancee()
    {
        _ticTacToe.NewGame();
    }

    [Then(@"le plateau doit être vide")]
    public void ThenLePlateauDoitEtreVide()
    {
        _ticTacToe.Board.IsEmpty().Should().Be(true);
    }

    [Then(@"ce doit être le tour de joueurX")]
    public void ThenCeDoitEtreLeTourDeJoueurX()
    {
        _ticTacToe.CurrentPlayer.Should().Be('X');
    }

    [When(@"joueurX place un X en \((.*),(.*)\)")]
    public void WhenJoueurXPlaceUnXEn(int x, int y)
    {
        _ticTacToe.Place(x, y);
    }

    [Then(@"il doit y avoir un X en \((.*),(.*)\)")]
    public void ThenIlDoitYAvoirUnXEn(int x, int y)
    {
        _ticTacToe.Board.Get(x, y).Should().Be('X');
    }

    [Then(@"ce doit être le tour de joueurO")]
    public void ThenCeDoitEtreLeTourDeJoueurO()
    {
        _ticTacToe.CurrentPlayer.Should().Be('O');
    }

    [Given(@"le plateau:")]
    public void GivenLePlateau(Table table)
    {
        _ticTacToe.NewGame();
        
        List<List<char>> board = TicTacToeBoard.NewEmptyBoard();
        for (int row = 0; row < table.Rows.Count; row++)
        {
            for (int col = 0; col < table.Rows[row].Count; col++)
            {
                char c = table.Rows[row][col][0];
                if (c == '_')
                {
                    board[col][row] = ' ';
                }
                else
                {
                    board[col][row] = c;
                }
            }
        }
        _ticTacToe.Board.SetBoard(board);
    }

    [When(@"joueurO place un O en \((.*),(.*)\)")]
    public void WhenJoueurOPlaceUnOEn(int x, int y)
    {
        _ticTacToe.Place(x,y);
    }

    [Then(@"il doit y avoir un O en \((.*),(.*)\)")]
    public void ThenIlDoitYAvoirUnOEn(int x, int y)
    {
        _ticTacToe.Board.Get(x, y).Should().Be('O');
    }

    [Given(@"c'est le tour de joueurX")]
    public void GivenCestLeTourDeJoueurX()
    {
        _ticTacToe.ForceSwitchPlayer('X');
    }
    
    [Given(@"c'est le tour de joueurO")]
    public void GivenCestLeTourDeJoueurO()
    {
        _ticTacToe.ForceSwitchPlayer('O');
    }


    [When(@"on met fin a la partie")]
    public void WhenOnMetFinALaPartie()
    {
        _ticTacToe.EndGame();
    }

    [Then(@"le score de joueurX doit être (.*)")]
    public void ThenLeScoreDeJoueurXDoitEtre(int p0)
    {
        _ticTacToe.ScorePlayerX.Should().Be(p0);
    }

    [Then(@"le score de joueurO doit être (.*)")]
    public void ThenLeScoreDeJoueurODoitEtre(int p0)
    {
        _ticTacToe.ScorePlayerO.Should().Be(p0);
    }

    [When(@"on lance une nouvelle partie")]
    public void WhenOnLanceUneNouvellePartie()
    {
       _ticTacToe.NewGame(); 
    }


}