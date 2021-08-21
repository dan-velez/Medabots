' Base level class. Other levels can inherit from this.

public class Level

    Dim levelString As String = "" & environment.newLine & _
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
    "============================" & environment.newLine & _
    ""

    sub render()
        ' Output the level string to the console.
        ' console.writeLine(me.levelString.length)
        console.writeLine(me.levelString)
    end sub
end class