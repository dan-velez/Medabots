' Holds gameloop and all major game objects.
' Use this class to initialize and run the game.

imports System.Collections.Generic

public class MedabotsGame
    private dim prompt as string = "botConsole> "
    private dim logo as string = "** Medabots v1.0.0 **"
    private dim userInput as consoleKeyInfo
    private dim currentLevel as Level
    private dim user as User 
    ' Need to reference user here and in level array.
    private dim debugger as GameDebugger

    public sub start()
        ' Game intro text, start first level.
        me.loadGame()
        me.debugger = new GameDebugger(me)
        me.gameLoop()
    end sub

    private sub loadGame()
        ' Load state. Load level and player.
        ' TODO: Just create new level and player each time.
        printc("(* Medabots) Loading game...")
        me.currentLevel = new Level
        me.user = new User
    end sub

    private sub gameLoop()
        ' Poll input from user.
        ' Each poll to the user for input is one game cycle.
        console.cursorVisible = false

        while true
            console.clear
            console.writeLine(me.logo)
            console.writeLine("User Keypress: " & me.userInput.keyChar.toString)
            console.writeLine("")
            
            ' Render level.
            me.currentLevel.render

            ' Render prompt.
            console.write(prompt)
            console.writeLine("")
            console.writeLine("")

            ' Render user bot's stats.
            me.user.renderStats
            console.writeLine("")

            ' Render debug information.
            me.debugger.render()

            ' Handle user input.
            me.userInput = console.readKey(false)
        end while
    end sub
end class