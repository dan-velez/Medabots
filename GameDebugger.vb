' Displays stats and info of the current game.

imports System.IO

public class GameDebugger
    ' Size of debug field columns.
    private csize as integer = 16
    public property lastKey as string = ""
    private logFilePath as string = "Medabots.log"

    '' Constructors ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    
    public sub new ()
        ' Append new entry into log file.
        me.log("")
        me.log("Medabots started.")
    end sub

    '' Log to File '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    public sub log (byval mesg as string)
        File.AppendAllText(me.logFilePath, mesg + environment.newLine)
    end sub

    '' Dump gameObjects ''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    public sub dumpGameObjects ()
        ' Print all the game objects and their attributes to a JSON file.
        dim jsonString as string = "{"
        for each go as GameObject in GAME.LEVEL.gameObjects
            jsonString += "STRAWBERRY"
        next
    end sub

    '' Render Debugger Stats '''''''''''''''''''''''''''''''''''''''''''''''''''

    public sub render ()
        ' Render stats to console.
        console.writeLine("DEBUGGER")
        console.writeLine("--------")
        
        ' Last key pressed.
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