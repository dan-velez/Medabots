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
    "|              #  |        |" & environment.newLine & _
    "|                 |        |" & environment.newLine & _
    "|======           |        |" & environment.newLine & _
    "|      |          =========|" & environment.newLine & _
    "|      |     @             |" & environment.newLine & _
    "|      |                   |" & environment.newLine & _
    "|       ======      |      |" & environment.newLine & _
    "|                   |      |" & environment.newLine & _
    "|                   |      |" & environment.newLine & _
    "============================" & environment.newLine

    ' List of all objects in the current level.
    public property gameObjects as List(Of GameObject)
    public property name as string = "Home"
    ' public readonly property types as Dictionary(Of string, GameObject)

    '' Generate Objects ''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    public sub genObjects ()
        ' Generate objects based on icons in the LevelString.
        me.gameObjects = new List(Of GameObject)
        
        ' Variables used to generate gameObjects.
        dim vlevelLines() as string = me.levelString.split(chr(13))
        dim vnewLines as new List(Of string)
        dim x as integer = 0, y as integer = 0

        ' Loop through lines. Generate Gameobjects and replace with blank.
        ' Then render function will replace the objects as they move.
        for each vline as string in vlevelLines
            ' newLine will be eventually just be walls.
            dim vnewLine as string = vline
            x = 0

            for each vchar as char in vline
                ' User icon.
                if vchar = "@" then
                    GAME.GDEBUGGER.log("Found user at: " & x.toString)
                    me.gameObjects.add(GAME.USER)
                    GAME.USER.setPosition(x, y)
                    vnewline = me.subchar(vline, " ", x)

                ' Rokusho icon.
                else if vchar = "#"
                    me.gameObjects.add(new Rokusho(x, y))
                end if

                ' Process next character.
                x += 1
            next
            vnewLines.add(vnewLine)
            y += 1
        next
        
        ' New level lines is just the levels with walls. GameObject are created
        ' with their coordinates and stored in GameObjects list.
        me.levelString = join(vnewLines.toArray, chr(13).toString)
    end sub 

    '' Collisions ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    public function collideWith (byval x as integer, 
                                 byval y as integer) as GameObject
        return new GameObject
    end function

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

    '' Utils '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    
    public function subchar (byval srepl as string,
                            byval vchar as string, 
                            byval pos as integer) as string
        ' Replace a character in string by position. Useful for rendering
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
        vlevelLines(GAME.USER.y) = subchar(vlevelLines(GAME.USER.y), 
                                           GAME.user.icon, GAME.USER.x)
        ' console.writeLine("(" & me.name & ")")
        console.writeLine(join(vlevelLines, chr(13).toString))
    end sub

    '' Update ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    public sub update ()
        ' Run every gameObject's update method.
        for each go as GameObject in me.gameObjects
            go.update
        next
    end sub
end class