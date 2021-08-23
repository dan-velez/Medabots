' Load and run the game code. 
' Also contains global utility routines.

public module Main
    ' Expose global namespace GAME object.
    ' GAME contains all core game engine components.
    ' GAME will act as a global API for game functions.
    public GAME as MedabotsGame

    '' Global Utils ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    public sub printColored (byval vmesg as string, 
                      optional byval vcolor as string="black")
        ' Shortcut to printing a colored string.
        select case vcolor.toUpper
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
        console.writeLine(vmesg)
        console.resetColor
    end sub

    '' Main ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    public sub main ()
        ' Load up the main game code and start it.
        try
            GAME = new MedabotsGame
            GAME.init
            console.writeLine("Medabots exiting.")
            console.resetColor
        catch e as Exception
            console.writeLine("ERROR:")
            console.writeLine(e.message)
            console.writeLine(e.stackTrace)
            ' TODO: Dump game state and game objects array!
            console.writeLine("Press any key to continue...")
            console.readKey
        end try
    end sub
end module