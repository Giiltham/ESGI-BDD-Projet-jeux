Feature: TicTacToe
	Jeux de morpion


Scenario: Lancement de la partie, le joueur X commence
	Given la partie est lancée
	Then le plateau doit être vide
	And ce doit être le tour de joueurX

Scenario: Lancement d'une nouvelle partie
	Given la partie est lancée
	When joueurX place un X en (0,0)
	And on met fin a la partie
	And on lance une nouvelle partie
	Then le plateau doit être vide
	And ce doit être le tour de joueurX
	And le score de joueurX doit être 0
	And le score de joueurO doit être 0

Scenario: joueurX place un X
	Given la partie est lancée
	When joueurX place un X en (0,0)
	Then il doit y avoir un X en (0,0)
	And ce doit être le tour de joueurO

Scenario: joueurO place un O
	Given le plateau:
	  |   |   |   |
	  | _ | _ | _ |
	  | _ | _ | _ |
	  | X | _ | _ |
    And c'est le tour de joueurO
	When joueurO place un O en (0,0)
	Then il doit y avoir un O en (0,0)
	And ce doit être le tour de joueurX
	
	
Scenario: joueurO place un O sur une case déjà occupée
	Given le plateau:
	  |   |   |   |
	  | _ | _ | _ |
	  | _ | _ | _ |
	  | X | _ | _ |
	And c'est le tour de joueurO
	When joueurO place un O en (0,2)
	Then il doit y avoir un X en (0,2)
	And ce doit être le tour de joueurO
	
Scenario: joueurX gagne horizontalement
	Given le plateau:
	  |   |   |   |
	  | X | X | _ |
	  | O | O | _ |
	  | _ | _ | _ |
	And c'est le tour de joueurX
	When joueurX place un X en (2,0)
	And on met fin a la partie
	Then le score de joueurX doit être 1
	And le score de joueurO doit être 0


Scenario: joueurX gagne verticalement
	Given le plateau:
	  |   |   |   |
	  | X | O | _ |
	  | X | O | _ |
	  | _ | _ | _ |
	And c'est le tour de joueurX
	When joueurX place un X en (0,2)
	And on met fin a la partie
	Then le score de joueurX doit être 1
	And le score de joueurO doit être 0

	
Scenario: joueurX gagne diagonalement
	Given le plateau:
	  |   |   |   |
	  | X | O | _ |
	  | O | X | _ |
	  | _ | _ | _ |
	And c'est le tour de joueurX
	When joueurX place un X en (2,2)
	And on met fin a la partie
	Then le score de joueurX doit être 1
	And le score de joueurO doit être 0

Scenario: joueurO gagne horizontalement
	Given le plateau:
	  |   |   |   |
	  | X | _ | X |
	  | O | O | _ |
	  | _ | X | _ |
	And c'est le tour de joueurO
	When joueurO place un O en (2,1)
	And on met fin a la partie
	Then le score de joueurO doit être 1
	And le score de joueurX doit être 0

Scenario: joueurO gagne verticalement
	Given le plateau:
	  |   |   |   |
	  | _ | O | X |
	  | X | O | _ |
	  | X | _ | _ |
	And c'est le tour de joueurO
	When joueurO place un O en (1,2)
	And on met fin a la partie
	Then le score de joueurO doit être 1
	And le score de joueurX doit être 0

Scenario: joueurO gagne diagonalement
	Given le plateau:
	  |   |   |   |
	  | X | _ | O |
	  | _ | _ | X |
	  | O | _ | X |
	And c'est le tour de joueurO
	When joueurO place un O en (1,1)
	And on met fin a la partie
	Then le score de joueurO doit être 1
	And le score de joueurX doit être 0
