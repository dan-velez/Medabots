# Medabots #
![Medabots](Medabots.gif)

Medabots is a text based console RPG game. User can move through procedurally 
generated levels to upgrade and modify their character. Gameplay will be loosly 
based on old Medabots games where the user can exchange parts with other 
Medabots that they defeat in battle. Medabots implements a custom 
TextGameEngine API. There are no dependancies to compile this game other than 
the base .NET namespace, `System`.

## TODO ##
* Render to retrieve strings from objects.
* GamMenu object -> Hook to hotkey
* Prompt object
* Weapon classes, other medabot classes.
* Code until can create different medabot classes.

## Game Architecture ##
* **Core Game Engine Components**:
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

## Screenshots ##

Example screen showing user stats and debugger:
```
Medabots - Home
============================
|                          |
|@                |        |
|                 |        |
|======           |        |
|      |          =========|
|      |                   |
|      |                   |
|       ======      |      |
|                   |      |
|                   |      |
============================

Medabot00> Show weapons

User Stats
----------
HP: 10
Attack: 1
Speed: 1
```


Player Message Box:
```
Medabots - MB_Tournament
============================
|                          |
|@ #              |        |
|                 |        |
|======        !  |        |
|      |          =========|
|      |                   |
|      |               $   |
|       ======      |      |
|             +     |      |
|                   |      |
============================

Medabot00> Run custom commands

Messages
--------
* You encounterd a medabot.
* You picked up an item.
* You ran into a wall.
* Command not found.
> Rokusho wants to battle!

User Stats
------------------------
HP: 10        Speed:   1
Attack: 1     EXP:     0
```


## Battle Mode ## : 
* Like pokemon 
* Cannot exit / move / change menu until done.
* Enemy will have radius where you must encounter them.

```
Medabots - MB_Tournament
============================
|                          |
|@ #              |        |
|                 |        |
|======        !  |        |
|      |          =========|
|      |                   |
|      |               $   |
|       ======      |      |
|             +     |      |
|                   |      |
============================

Messages
--------------------------------
* You picked up an item.
* You encounterd a medabot.
* You picked up weapon 'zcannon'.
* Rokusho wants to battle!
> You are now battling Rokusho.
--------------------------------

Battle
------------------------
Attack *       Status
Run            Item
------------------------
``` 