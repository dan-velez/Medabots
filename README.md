# Medabots #
Create a text-based console game using VB to learn about .NET development.
Can recreate digimon, medabots. Create a text game engine and API, then use it
to code custom game logic.

## About ##
Recreate medabots as a text console game. Similar to old galidor RPG.
* Simple text based game.
* Player is medabot, walk through dungeon
* Encounter enemies
* Collect parts
* Collect items
* Modify stats

## TODO ##
* Game Engine
    * Code hot swapper
    * WindowManager (set window size, clear)
    * Remove screen flicker
* Game Logic
    * Player movement
    * Walls

## Game Engine Core ##
* Main
* Game  -> gameLoop(), update(), render()
* Level
* GameObject

## Medabots Game Classes ##
* MedabotsGame <> Game
* Wall <> GameObject
* Buff <> GameObject
* EnergyRefill <> GameObject
* Medabot <> GameObject
* Player <> Medabot
* GruntBot <> Medabot
* Metabee <> Medabot
* Rokusho <> Medabot
* Sumilidon <> Medabot
* BlackRam <> Medabot
* KiloBot <> Medabot
* WarBandit <> Medabot

## User Medabot Customization ##
* Can create medabots from JSON file. Power level must not exceed certain amount
* Use arrow keys to move ; hot keys ; input commands
* Compile and code own characters using medabots API. 

## Gameplay ##
* Can start game through console, continue where left off.
* Procedually generated, advancing level of difficulty.
* Catch input, be able to move around level.
* When command key is pressed, listen for command. Otherwise, continue gameLoop.
```

** Medabots v1.0.0 **

====================
|                # |
|                  |
|                  |
|                  |
|                  |
|                  |
|                  |
|                  |
|                  |
|@                 |
====================

botConsole> Attack Right Main

-----------------
BotName
-----------------
HP    10    SPD  1
ENG   10    
ATK    1
CRIT   1

WMAIN bCannon
WSUB  zSword
```