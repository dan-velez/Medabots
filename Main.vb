' Load and run the game code. 
' Main module also houses some utilities.

imports MedabotsGame

module Main
    sub printc(byval mesg as string, optional byval color as string="black")
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

    sub main()
        ' Load up the main game code and start it.
        dim medabots as new MedabotsGame()
        medabots.start()
    end sub
end module