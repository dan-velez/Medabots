' Displays stats and info of the current game.

public class GameDebugger
    ' Size of debug field columns.
    private csize as integer = 16
    public property lastKey as string = ""

    public sub dumpGameObjects ()
        ' Print all the game objects and their attributes to a JSON file.
    end sub

    public sub render ()
        ' Render stats to console.
        console.writeLine("DEBUGGER")
        console.writeLine("--------")

        ' Level Size.
        console.write("Level: ".padRight(me.csize))
        console.write(GAME.LEVEL.name.padLeft(me.csize))
        
        ' Last key pressed.
        console.writeLine("")
        console.write("User Keypress: ".padRight(me.csize)) 
        console.write(me.lastKey.padLeft(me.csize))
        console.writeLine("")
        console.write("User X:".padRight(me.csize))
        console.write(GAME.USER.x.toString.padLeft(me.csize))
        console.writeLine("")
        console.write("User Y:".padRight(me.csize))
        console.write(GAME.USER.y.toString.padLeft(me.csize))
    end sub
end class