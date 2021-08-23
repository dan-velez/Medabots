' The user's medabot. A controllable medabot object.
' User medabot is controlled by cursor keys and through bot commands.

public class User 
    inherits Medabot

    public overrides property icon as string = "@"
    public overrides property name as string = "Medabot01"

    '' Move ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    
    public sub move (byval vdir as string)
        select case vdir.toUpper
            case "UP"
                if not GAME.LEVEL.isWall(me.x, me.y-1) then me.y -= 1
            case "DOWN"
                if not GAME.LEVEL.isWall(me.x, me.y+1) then me.y +=1
            case "LEFT"
                if not GAME.LEVEL.isWall(me.x-1, me.y) then me.x -= 1
            case "RIGHT"
                if not GAME.LEVEL.isWall(me.x+1, me.y) then me.x += 1
        end select
    end sub

    '' Collisions ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    private function collide (byval x as integer, 
                              byval y as integer) as boolean
        return GAME.LEVEL.iswall(x, y)
    end function

    '' User Stats Menu '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '' TODO: Move to GameMenu class.
    
    public sub renderStats ()
        ' Render users stats to console.
        console.writeLine("User Stats")
        console.writeLine("".padRight(me.name.length, "-"c))
        console.writeLine("HP: " & me.hp)
        console.writeLine("Attack: " & me.attack)
        console.writeLine("Speed: " & me.speed)
    end sub
end class