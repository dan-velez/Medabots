' Holds gameloop and all major game objects.
' Use this class to initialize and run the game.

imports System.Collections.Generic

public class MedabotsGame
    private  property userInput as consoleKeyInfo
    public property userKey as string = ""
    private property currentLevel as Level
    private property user as User
    private debugger as GameDebugger
    private prompt as string = "botConsole> "
    private logo as string = "** Medabots v1.0.0 **"

    '' Loading Routines ''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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

    '' Render ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    private sub renderGameScreen()
        ' Render the main game screen with the user's bot.

        ' Render logo.
        console.writeLine(me.logo)
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
    end sub

    '' User Input ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    sub handleUserInput()
        ' Can be cursor key or hotkey.
        ' Check if in command mode.
        me.userInput = console.readKey(false)
        me.userKey = me.userInput.keyChar.toString

        ' User Movement.
        if me.userInput.key = consoleKey.upArrow then me.userKey = "UP"
        if me.userInput.key = consoleKey.downArrow then me.userKey = "DOWN" 
        if me.userInput.key = consoleKey.leftArrow then me.userKey = "LEFT" 
        if me.userInput.key = consoleKey.rightArrow then me.userKey = "RIGHT" 
    end sub

    '' Game Loop '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    private sub gameLoop()
        ' Poll input from user.
        ' Each poll to the user for input is one game cycle.
        console.cursorVisible = false

        while true
            clearConsoleHistory
            me.renderGameScreen
            me.handleUserInput
        end while
    end sub
end class