' Main game code. Holds gameloop and all major game objects.

imports System.Collections.Generic

public class MedabotsGame
    ' Core GameObjects.
    public property USER as User
    public property LEVEL as GameLevel
    public property WMANAGER as WindowManager
    public property GDEBUGGER as GameDebugger
    public property MENU as GameMenu
    public property MESSAGEBOX as MessageBox

    ' Window properties.
    public title as string = "Medabots"
    private winWidth as integer = 64
    private winHeight as integer = 40

    ' Input.
    public property inputMode as string = "Explore" '| Interact | Convo | Battle
    public property primaryKey as string = "A"
    public property secondaryKey as string = "B"

    ' Other properties.
    public property cycles as integer = 0

    '' Loading Routines ''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    public sub init ()
        ' Initalize core game engine components.
        USER = new User(2, 2)
        LEVEL = new GameLevel
        MENU = new GameMenu
        WMANAGER = new WindowManager(winWidth, winHeight)
        MESSAGEBOX = new MessageBox
        GDEBUGGER = new GameDebugger

        WMANAGER.setWindowSize(me.winWidth, me.winHeight)

        ' Generate the level
        LEVEL.genObjects

        ' Clear console initially.
        console.setCursorPosition(0, 0)
        console.clear
        me.gameLoop()
    end sub

    '' Game Loop '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    private sub gameLoop ()
        ' Poll input from user.
        ' Each poll to the user for input is one game cycle.
        while true
            me.WMANAGER.clearConsoleAll
            me.render
            ' Update all gameObjects.
            me.LEVEL.update
            me.handleUserInput
            me.cycles += 1
        end while
    end sub

    '' Render ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    private sub render ()
        ' Render the main game screen with the user's bot.
        ' Collect the items render() results into one string and
        ' render with stringBuilder for best performance.
        dim gameString as string = ""

        ' Render logo.
        console.writeLine("")
        ' console.writeLine(me.title & " - " & me.LEVEL.name)
        console.writeLine("(" & me.LEVEL.name & ")")
        
        ' Render level.
        LEVEL.render

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
            USER.move(0, -1)
        elseif userInput.key = consoleKey.downArrow then 
            userKey = "DOWN" 
            USER.move(0, 1)
        elseif userInput.key = consoleKey.leftArrow then 
            userKey = "LEFT" 
            USER.move(-1, 0)
        elseif userInput.key = consoleKey.rightArrow then 
            userKey = "RIGHT" 
            USER.move(1, 0)
        end if

        ' Interaction with a GameObject.
        dim vsurroundings as List(of GameObject) = _
            LEVEL.surroundingObjects(USER.x, USER.y)
        if userKey = "A" then
            ' Interact with first surrounding object.
            if vsurroundings(0).type.toUpper = "MEDABOT" then
                ' Interact with Medabot.
                user.interactWith(vsurroundings(0))
            end if
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

    '' Input Modes '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    sub initBattle (byref mbot as Medabot)
        ' Initiate the battle state between user and other medabot.
    end sub

    sub exitBattle ()
        ' Reset game state to explore.
    end sub
end class