' Main game code. Holds gameloop and all major game objects.

imports System.Collections.Generic

public class MedabotsGame
    public property USER as User
    public property LEVEL as GameLevel
    public property WMANAGER as WindowManager
    public property GDEBUGGER as GameDebugger
    ' public property MENU as GameMenu
    ' public property PROMPT as GamePrompt

    private logo as string = "** Medabots v1.0.0 **"
    private prompt as string = "medabots> "
    private winWidth as integer = 100
    private winHeight as integer = 100

    '' Loading Routines ''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    public sub init ()
        ' Load game, initialize main gameobjects.
        LEVEL = new GameLevel
        USER = new User
        GDEBUGGER = new GameDebugger(me)
        WMANAGER = new WindowManager
        
        ' WMANAGER.setWindowSize(me.winWidth, me.winHeight)
        ' me.gameLoop()
    end sub

    '' Game Loop '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    private sub gameLoop ()
        ' Poll input from user.
        ' Each poll to the user for input is one game cycle.
        while true
            WMANAGER.clearConsole
            me.render
            me.handleUserInput
        end while
    end sub

    '' Render ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    private sub render ()
        ' Render the main game screen with the user's bot.

        ' Render logo.
        console.writeLine("")
        console.writeLine(" " & me.logo)
        console.writeLine("")
        
        ' Render level.
        me.currentLevel.render

        ' Render prompt.
        console.write(" " & prompt)
        console.writeLine("")
        console.writeLine("")

        ' Render user bot's stats.
        me.user.renderStats
        console.writeLine("")

        ' Render debug information.
        me.debugger.render()
    end sub

    '' User Input ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    sub handleUserInput ()
        ' Can be cursor key or hotkey.
        ' Check if in command mode.
        dim userInput as consoleKeyInfo = console.readKey(false)
        GDEBUGGER.lastKey = me.userInput.keyChar.toString

        ' User Movement.
        if me.userInput.key = consoleKey.upArrow then 
            userKey = "UP"
            USER.move("UP")
        elseif me.userInput.key = consoleKey.downArrow then 
            userKey = "DOWN" 
            USER.move("DOWN")
        elseif me.userInput.key = consoleKey.leftArrow then 
            me.userKey = "LEFT" 
            USER.user.move("LEFT")
        elseif me.userInput.key = consoleKey.rightArrow then 
            me.userKey = "RIGHT" 
            USER.user.move("RIGHT")
        end if
    end sub
end class