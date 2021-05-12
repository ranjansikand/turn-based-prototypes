# turn-based-prototypes
Prototypes of implementations of turn-based systems

This repository includes three different prototyped turn-based systems.

The first is a board-based game with 3 randomly placed pieces on either side.
  - Player pieces can only move forward
  - Enemy pieces move forward if they detect a player piece ahead of them
    - Otherwise, they switch rows
  - Colliding with a piece of the opposite color reduces health by 1
  - When health reaches zero, the piece explodes
  
The second is a Pokemon-based system, in which players can attack, guard, or move on every turn.

The third, named "Persona," is another Pokemon-based system, but was aesthetically influenced by the interfaces from Persona games. This is the most-fully functional and fully-realized of the three prototypes.

Features:
  - Includes a fight log that describes player and enemy actions
  - On each move, characters can:
    - Attack, to deal a set amount of damage
    - Dodge, to avoid all damage with a 50% success rate
    - Guard, to reduce incoming damage by half
  - Health bars that track character health
  - Dynamic systems that start and end the battle
  
 Issues:
  - There is currently no incentive to dodge or guard. Attacking on every turn will always yield the best result.
  - The fight log does not include enough messages.
  - No animations for character actions
