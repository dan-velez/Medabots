' The user's medabot. A controllable medabot object.
' User medabot is controlled by cursor keys and through bot commands.

public class User 
    inherits Medabot

    public overrides property icon as string = "@"
    public overrides property name as string = "Medabot00"

    '' Constructors ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    
    public sub new ()
        myBase.new
        me.load()
    end sub

    public sub load ()
        ' Load player data from disk.
        me.weaponMain = new GameObject
        me.weaponSub = new GameObject
    end sub

    '' Move ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    
    public overrides sub move (byval vdir as string)
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
end class