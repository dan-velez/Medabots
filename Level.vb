' Base level class. Other levels can inherit from this.

imports System.Collections.Generic

public class Level
    protected Dim levelString As String = "" & environment.newLine & _
    "============================" & environment.newLine & _
    "|                          |" & environment.newLine & _
    "|                          |" & environment.newLine & _
    "|                          |" & environment.newLine & _
    "|                          |" & environment.newLine & _
    "|                          |" & environment.newLine & _
    "|                          |" & environment.newLine & _
    "|                          |" & environment.newLine & _
    "|                          |" & environment.newLine & _
    "|                          |" & environment.newLine & _
    "| @                        |" & environment.newLine & _
    "============================" & environment.newLine

    protected dim objects as List(Of GameObject)

    public sub new()
        me.objects = new List(Of GameObject)
    end sub 

    public sub render()
        ' Output the level string to the console.
        ' console.writeLine(me.levelString.length)
        ' Parse objects into level string.
        console.writeLine(me.levelString)
    end sub
end class