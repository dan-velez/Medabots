' Load and run the game code. 
' Main module also contains global utility routines.

public module Main
    private vmedabots as MedabotsGame
    public vwmanager as WindowManager 

    '' Global Utils ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    public sub printc(byval vmesg as string, 
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
    public sub main()
        ' Load up the main game code and start it.
        try
            vwmanager = new WindowManager 
            vmedabots = new MedabotsGame
            vmedabots.start
        catch e as Exception
            console.writeLine("ERROR:")
            console.writeLine(e.message)
            console.writeLine("Press any key to continue...")
            console.readKey
        end try
    end sub
end module