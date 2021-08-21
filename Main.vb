' Load and run the game code. 
' Main module also houses some utilities.

imports MedabotsGame

public module Main
    '' Utils '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    public sub setWindowSize()
        ' Adjust the games window.
        console.setWindowSize(1, 1)
        console.setBufferSize(200, 200)
        console.setWindowSize(200, 200)
        ' console.setWindowPosition(0, 0)
    end sub

    public sub clearConsoleHistory()
        ' Clears the terminal. Windows only for now.
        ' System.Diagnostics.Process.Start("cls")
        console.clear
    end sub

    public sub printc(byval mesg as string, 
                      optional byval color as string="black")
        ' Shortcut to printing a colored string.
        select case color.toUpper
            case "BLACK"
                console.foregroundColor = consoleColor.black
            case "WHITE"
                console.foregroundColor = consoleColor.white
            case "BLUE"
                console.foregroundColor = consoleColor.blue
            case "RED"
                console.foregroundColor = consoleColor.red
            case "YELLOW"
                console.foregroundColor = consoleColor.yellow
            case "GREEN"
                console.foregroundColor = consoleColor.green
        end select
        console.writeLine(mesg)
        console.resetColor
    end sub

    '' Main ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    public sub main()
        ' Load up the main game code and start it.
        setWindowSize
        dim medabots as new MedabotsGame
        medabots.start
    end sub
end module