' Main game code. Holds gameloop and all major game objects.

imports System.Collections.Generic

public class MedabotsGame
    public property USER as User
    public property LEVEL as GameLevel
    public property WMANAGER as WindowManager
    public property GDEBUGGER as GameDebugger
    public property MENU as GameMenu
    public property MESSAGEBOX as MessageBox
    ' public property PROMPT as GamePrompt

    public title as string = "Medabots"
    private winWidth as integer = 64
    private winHeight as integer = 40   

    '' Loading Routines ''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    public sub init ()
        ' Initalize core game engine components.
        USER = new User
        LEVEL = new GameLevel
        MENU = new GameMenu
        WMANAGER = new WindowManager(winWidth, winHeight)
        MESSAGEBOX = new MessageBox
        GDEBUGGER = new GameDebugger

        WMANAGER.setWindowSize(me.winWidth, me.winHeight)
        LEVEL.genObjects

        me.gameLoop()
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
        ' console.writeLine(me.title & " - " & me.LEVEL.name)
        console.writeLine("(" & me.LEVEL.name & ")")
        
        ' Render level.
        LEVEL.render

        ' Render prompt.
        ' console.write(USER.name & "> ")
        ' console.writeLine("")
        ' console.writeLine("")

        ' Render game messages box.
        MESSAGEBOX.render
        console.writeLine("")

        ' Render user menu.
        MENU.render
        console.writeLine("")

        ' Render debug information.
        GDEBUGGER.render()
        console.writeLine("")
    end sub

    '' User Input ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    sub handleUserInput ()
        ' Get input from user. Update debugger with input information.
        ' Can be cursor key or hotkey. Check if game is in command mode.
        dim userInput as consoleKeyInfo = console.readKey(false)
        dim userKey as string = userInput.key.toString.toUpper

        ' User Movement.
        if userInput.key = consoleKey.upArrow then 
            userKey = "UP"
            USER.move("UP")
        elseif userInput.key = consoleKey.downArrow then 
            userKey = "DOWN" 
            USER.move("DOWN")
        elseif userInput.key = consoleKey.leftArrow then 
            userKey = "LEFT" 
            USER.move("LEFT")
        elseif userInput.key = consoleKey.rightArrow then 
            userKey = "RIGHT" 
            USER.move("RIGHT")
        end if
        
        ' Menu switch hotkey.
        if userKey = "M" then 
            MENU.nextMenu
        elseif userKey = "N" then 
            MENU.previousMenu
        end if

        ' Update debugger with semantic key info.
        GDEBUGGER.lastKey = userKey
    end sub
end class