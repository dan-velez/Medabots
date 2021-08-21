' Displays stats and info of the current game.

public class GameDebugger
    public sub new(byref game as MedabotsGame)
        ' Get stats from game object.
    end sub

    public sub render()
        ' Render stats to console.
        console.writeLine("DEBUG")
        console.writeLine("-----")
        console.write("LEVEL SIZE: ".padRight(16))
        console.write("10".padLeft(16))
        console.write("")
    end sub
end class