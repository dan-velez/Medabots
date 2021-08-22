# Medabots #
Medabots is a ext based console RPG game. User can move through procedurally 
generated levels and upgrade and modify their character as they move through the
game levels. Gameplay will be loosly based on old Medabots games where the user
can exchange parts with the boss characters. Medabots implements a custom 
TextGameEngine.

## TODO ##
* Collision check for player
* Global gameObjects array
* Level generator
* Prompt object

* Game Engine
    * MedaBotsGame subclass TextGame class
    * CodeHotSwapper

* Game Logic
    * Player movement

## Game Architecture ##
* `GAME`, `LEVEL`, `USER`, `WMANAGER`, `GDEBUGGER`, `MENU`, `PROMPT`

`Main` module will have a `WindowManager` and `Game` class, which is all the 
games code.
`WindowManager` is publicly available for `Game` class to alter.
`Game` class will adjust the window through `WindowManager`.
`Game` class will inherit `render` and `update` routines to implement custom 
 game code.

Render method will draw the level and player.
Update method will deal with user input.

Level will have a game objects array which includes player.

## User Medabot Customization ##
* Can create medabots from JSON file. Power level must not exceed certain amount
* Use arrow keys to move ; hot keys ; input commands
* Compile and code own characters using medabots API. 

## Gameplay ##
* Can start game through console, continue where left off.
* Procedually generated, advancing level of difficulty.
* Catch input, be able to move around level.
* When command key is pressed, listen for command. Otherwise, continue gameLoop.
* Player can select their icon: [@ ]
* Player can create **custom commands** that are shortcuts to actions.
* Player can encounter with and talk with different medabots. Some medabots can
  help the user and have special functions. Some are just there to battle.

```
** Medabots v1.0.0 **
(HOME)
====================
|    |           # |
|    |             |
|=====             |
|       *          |
|=======           |
|      %           |
|            ====  |
|            +     |
|                  |
|@                 |
====================

metabee> Help?

Stats
-----
HP    10    SPD  1
ENG   10    
ATK    1
CRIT   1
```