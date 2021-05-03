Turn Based Prototypes

This repository contains prototypes for turn-based systems.

The first is a vaguely grid-based system that involves two teams of 3 characters each. The functionality of this prototype is very basic.
  - Pieces move forward on their turn (if on user's side, they move when clicked)
  - Enemy pieces move upward if they do not detect an opponent ahead of them
  - Upon colliding with an opposing piece, they sustain damage
  - When health is depleted, the pieces explode

The second is a Pokemon-based system
  - Each character starts with 100 health.
  - On every turn, players can:
    - Attack: Deals 15 damage (with a 10% chance to deal 1.5x damage)
    - Block: Deflects 70% of incoming damage
    - Dodge: 30% chance to avoid all incoming damage
  - The player can select a button to move on each turn
  - The enemy player selects a random move on each turn
  - When health = 0, the character is dead.
