' Default level class. Other levels can inherit from this.
' Default level acts as the "home" level for the player. This is where the 
' player will first spawn and can tansmit to other levels from home.

imports System.Collections.Generic

public class GameLevel
    ' LevelString describes the level structure and all the GameObjects in it.
    ' Level will create according GameObject according to a legend. GameObject
    ' Creation is done when the level is initialized.

    protected Dim levelString As String = _
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
    "|                          |" & environment.newLine & _
    "============================" & environment.newLine

    ' List of all objects in the current level.
    protected property gameObjects as List(Of GameObject)

    '' Constructors ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    public sub new ()
        ' Generate objects based on LevelString. Add to array.
        me.gameObjects = new List(Of GameObject)
        ' for each char
        ' type = legend[char]
        ' if type is XGO.add(new GO(x, y)
        ' if type is User(GO.add(GAME.USER)), USER.setPosition
    end sub 

    '' Utils '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    public function isWall (byval x as integer, byval y as integer) as boolean
        ' Determine if this coordinate is a wall or not.
        dim vlevelLines() as string = me.levelString.split(chr(13))
        dim vchar as char = vlevelLines(y)(x)
        if (vchar = "|"c or vchar = "="c) then
            return true
        else 
            return false
        end if 
    end function

    public function subchar (byval srepl as string,
                            byval vchar as string, 
                            byval pos as integer) as string
        ' Replace a character in level with another. Useful for rendering
        ' gameobject icons.
        dim vres as string = srepl.substring(0, pos) & _
                             vchar & _
                             srepl.substring(pos+1)
        return vres
    end function

    '' Render ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    public sub render ()
        ' Interpolate gameObjects into the level string and output to console.
        dim vlevelLines() as string = me.levelString.split(chr(13))
        ' TODO: Loop through me.gameObjects array.

        ' Render USER.
        vlevelLines(USER.y) = subchar(vlevelLines(USER.y), user.icon, USER.x)
        console.writeLine(join(vlevelLines, chr(13).toString))
    end sub
end class