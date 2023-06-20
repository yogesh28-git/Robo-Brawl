# **Robo-Brawl**

## Game
[CLICK HERE TO PLAY](https://y0-0go.itch.io/robo-brawl)

## Details

A singleplayer 3D shooting game invloving a boss enemy that sapwns multiple small enemies. Defeat the boss within time limit to win the game.

## Technical Description
- Model-View-Controller-Service(MVC-S) pattern:
    - Player and Enemy has Model, View and Controller.
    - A Service class used to Create/Spawn the characters.
- Singletons: 
    - Services like UI, GameManager, AudioManager, PlayerService are created as Singletons.
- State Machine Pattern:<br>
    &nbsp;&nbsp; &nbsp;  Enemies have the following States in Enemy AI.
    - PATROL state 
    - CHASE state
    - ATTACK state:
- Navmesh:
    - Navmesh was used for enemies chasing the player.
- Object Pooling:
    - small enemies and bullets are made available when required using object pooling.
- Observer Pattern:
    - OnGameOver, OnGameStart, OnGameWin, OnGameLost etc are some examples of custom events used. 

## Screenshots
![image](https://github.com/yogesh28-git/Robo-Brawl/assets/85812175/29489af1-4bf0-4406-b4ef-cd61401cf93e)
![image](https://github.com/yogesh28-git/Robo-Brawl/assets/85812175/a9e91d68-f1cd-4272-a3e2-730abc4d727f)