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
                    me.gameObjects.add(GAME.USER)
                    GAME.USER.setPosition(x, y)
                    vnewline = me.subchar(vline, " ", x)

                ' Rokusho icon.
                else if vchar = "#"
                    me.gameObjects.add(new Rokusho(x, y))
                    vnewline = me.subchar(vline, " ", x)
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

    public function checkCollision (byval x as integer, 
                                 byval y as integer) as GameObject
        ' Check if a space is occupied by a GameObject.
        for each go as GameObject in me.gameObjects
            if go.x = x and go.y = y then return go
        next
        return nothing
    end function

    public function surroundingObjects (byval x as integer, 
                                        byval y as integer) _ 
                                        as List(of GameObject)
        ' Returns list of GameObjects surrouding this coordinate.
        dim results = new List(of GameObject)
        
        ' Check around object and add in what is found.
        dim vtop as GameObject =  checkCollision(x, y-1)
        if not vtop is nothing then results.add(vtop)

        dim vbot as GameObject =  checkCollision(x, y+1)
        if not vbot is nothing then results.add(vbot)

        dim vleft as GameObject =  checkCollision(x-1, y)
        if not vleft is nothing then results.add(vleft)

        dim vright as GameObject =  checkCollision(x-1, y)
        if not vright is nothing then results.add(vright)

        ' Return list of objects surrounding coordinate.
        return results
    end function

    public function isWall (byval x as integer, byval y as integer) as boolean
        ' Determine if this coordinate is a wall or not.
        dim vlevelLines() as string = me.levelString.split(chr(13))
        dim vchar as char = vlevelLines(y)(x)

        ' Use wall icons to determine if this is a wall.
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
        
        ' Loop through me.gameObjects array and interpolate it into level.
        for each go in me.GameObjects
            ' TODO: Need to downcast objects to their respective types.
            GAME.GDEBUGGER.log("(* LEVEL) Render: "& go.name &" ["& go.icon &"]")
            vlevelLines(go.y) = subchar(vlevelLines(go.y), go.icon, go.x)
        next

        ' Render interpolated level with GameObject icons.
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