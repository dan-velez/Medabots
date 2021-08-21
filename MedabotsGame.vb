' Holds gameloop and all major game objects.
' Use this class to initialize and run the game.

imports System.Collections.Generic

public class MedabotsGame
    dim prompt as string = "medabots> "
    dim logo as string = "** Medabots v1.0.0 **"
    dim userInput as consoleKeyInfo
    dim currentLevel as Level
    ' dim player as Player

    sub loadGame()
        ' Load state. Current level and player.
        printc("(* Medabots) Loading game...")
        me.currentLevel = new Level 
    end sub

    sub start()
        ' Game intro text, start first level.
        me.loadGame()
        me.gameLoop()
    end sub

    sub gameLoop()
        ' Poll input from user.
        ' Each poll to the user for input is one game cycle.

        while true
            console.clear
            console.writeLine(me.logo)
            console.writeLine("User Keypress: " & me.userInput.keyChar.toString)
            ' Render level.
            console.writeLine("")
            me.currentLevel.render
            ' Render prompt.
            console.writeLine("")
            console.write(prompt)
            me.userInput = console.readKey
        end while
    end sub

    sub testSub()
    end sub
end class