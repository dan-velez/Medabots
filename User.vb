' The user's medabot. A controllable medabot object.
' User medabot is controlled by cursor keys and through bot commands.

public class User
    inherits Medabot

    public sub renderStats()
        ' Render users stats to console.
        console.writeLine(me.name)
        console.writeLine("".padRight(me.name.length, "-"c))
        console.writeLine("HP: " & me.HP)
    end sub
end class