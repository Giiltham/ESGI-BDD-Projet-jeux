Feature: Tennis
	Jeu de Tennis

	Scenario: Joueur1 marque un point 
		Given le match est lancé
		When Joueur1 marque 1 points
		Then Joueur1 doit avoir 1 points
	
	Scenario: Joueur2 marque un point 
		Given le match est lancé
		When Joueur2 marque 1 points
		Then Joueur2 doit avoir 1 points
	
	Scenario: Joueur1 remporte un jeu
		Given le match est lancé
		When Joueur1 marque 4 points
		Then Joueur1 doit avoir 1 jeux
		
	Scenario: Joueur2 remporte un jeu
		Given le match est lancé
		When Joueur1 marque 2 points
		And Joueur2 marque 4 points
		Then Joueur2 doit avoir 1 jeux
		
	Scenario: Joueur1 remporte un jeu par avantage
		Given le match est lancé
		When Joueur1 marque 3 points
		And Joueur2 marque 3 points
		And Joueur1 marque 1 points
		And Joueur1 marque 1 points
		Then Joueur1 doit avoir 1 jeux
		
	Scenario: Joueur2 remporte un jeu par avantage
		Given le match est lancé
		When Joueur2 marque 3 points
		And Joueur1 marque 4 points
		And Joueur2 marque 1 points
		And Joueur2 marque 1 points
		And Joueur2 marque 1 points
		Then Joueur2 doit avoir 1 jeux
		
	Scenario: Joueur1 remporte un set
		Given le match est lancé
		When Joueur1 gagne 6 jeux
		Then Joueur1 doit avoir 1 sets
		And Joueur1 doit avoir 0 jeux

	Scenario: Joueur2 remporte un set
		Given le match est lancé
		When Joueur1 gagne 4 jeux
		And Joueur2 gagne 6 jeux
		Then Joueur2 doit avoir 1 sets
		And Joueur2 doit avoir 0 jeux

	Scenario: Joueur1 remporte un set au tie-break
		Given le match est lancé
		When Joueur1 gagne 5 jeux
		And Joueur2 gagne 6 jeux
		And Joueur1 gagne 1 jeux
		And Joueur1 gagne 1 jeux
		Then Joueur1 doit avoir 1 sets
		And Joueur1 doit avoir 0 jeux

	Scenario: Joueur2 remporte un set au tie-break
		Given le match est lancé
		When Joueur2 gagne 5 jeux
		And Joueur1 gagne 6 jeux
		And Joueur2 gagne 1 jeux
		And Joueur1 marque 6 points
		And Joueur2 marque 7 points
		And Joueur1 marque 2 points
		And Joueur2 marque 2 points
		And Joueur2 marque 1 points
		Then Joueur2 doit avoir 1 sets
		And Joueur2 doit avoir 0 jeux

	Scenario: Joueur1 remporte le match
		Given le match est lancé
		When Joueur1 gagne 2 sets
		Then Joueur1 doit remporter le match

	Scenario: Joueur2 remporte le match
		Given le match est lancé
		When Joueur1 gagne 1 sets
		And Joueur2 gagne 2 sets
		Then Joueur2 doit remporter le match