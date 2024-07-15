using FluentAssertions;
using projet_jeux;

namespace SpecFlowProjetJeux;

[Binding]
public class TennisStepDefinitions
{
    private Tennis _tennis = new();
    
    [Given(@"le match est lancé")]
    public void GivenLeMatchEstLance()
    {
        _tennis.NewGame();
    }

    [When(@"Joueur(.*) marque (.*) points")]
    public void WhenJoueurMarquePoints(int player, int points)
    {
        for (int i = 0; i < points; i++)
        {
            if (player == 1)
            {
                _tennis.Player1Scores();
            }
            else
            {
                _tennis.Player2Scores();
            }
        }
    }

    [Then(@"Joueur(.*) doit avoir (.*) points")]
    public void ThenJoueurDoitAvoirPoints(int player, int points)
    {
        if (player == 1)
        {
            _tennis.Player1Score.Should().Be(points);
        }
        else
        {
            _tennis.Player2Score.Should().Be(points);
        }
    }

    [Then(@"Joueur(.*) doit avoir (.*) jeux")]
    public void ThenJoueurDoitAvoirJeux(int player, int games)
    {
        if (player == 1)
        {
            _tennis.Player1Games.Should().Be(games);
        }
        else
        {
            _tennis.Player2Games.Should().Be(games);
        }
    }

    [When(@"Joueur(.*) gagne (.*) jeux")]
    public void WhenJoueurGagneJeux(int player, int games)
    {
        for (int i = 0; i < games; i++)
        {
            if (player == 1)
            {
                _tennis.Player1WinsGame();
            }
            else
            {
                _tennis.Player2WinsGame();
            }
        }
    }

    [Then(@"Joueur(.*) doit avoir (.*) sets")]
    public void ThenJoueurDoitAvoirSets(int player, int sets)
    {
        if (player == 1)
        {
            _tennis.SetsWonByPlayers()[0].Should().Be(sets);
        }
        else
        {
            _tennis.SetsWonByPlayers()[1].Should().Be(sets);
        }
    }

    [When(@"Joueur(.*) gagne (.*) sets")]
    public void WhenJoueurGagneSets(int player, int sets)
    {
        for (int i = 0; i < sets; i++)
        {
            if (player == 1)
            {
                _tennis.Player1ForceWinSet();
            }
            else
            {
                _tennis.Player2ForceWinSet();
            }
        }
    }

    [Then(@"Joueur(.*) doit remporter le match")]
    public void ThenJoueurDoitRemporterLeMatch(int player)
    {
        if (player == 1)
        {
            _tennis.Player1Match.Should().Be(1);
        }
        else
        {
            _tennis.Player2Match.Should().Be(1);
        }
    }
}