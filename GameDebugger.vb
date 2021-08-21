' Displays stats and info of the current game.

public class GameDebugger
    private game as MedabotsGame

    ' Size of debug field columns.
    private csize as integer = 16

    public sub new(byref game as MedabotsGame)
        ' Get stats from game object.
        me.game = game
    end sub

    public sub render()
        ' Render stats to console.
        console.writeLine("DEBUGGER")
        console.writeLine("--------")

        ' Level Size.
        console.write("LEVEL SIZE: ".padRight(me.csize))
        console.write("10".padLeft(me.csize))
        
        ' Last key pressed.
        console.writeLine("")
        console.write("User Keypress: ".padRight(me.csize)) 
        console.write(me.game.userKey.padLeft(me.csize))
    end sub
end class