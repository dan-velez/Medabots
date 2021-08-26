' User Medabot. A controllable medabot object.
' Medabot is controlled by movement keys and through bot commands.

public class User 
    inherits Medabot

    public overrides property icon as string = "@"
    public overrides property name as string = "Medabot00"

    '' Constructors ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    
    public sub new (x, y)
        myBase.new(x, y)
        me.load()
    end sub

    public sub load ()
        ' Load player data from disk.
        me.weaponMain = new GameObject
        me.weaponSub = new GameObject
    end sub

    '' World Interaction '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    public sub interactWith (byref mbot as Medabot)
        ' Change input mode to 'Interaction'.
        ' Render Talk menu.
    end sub

    public sub pickUpItem (byref item as GameObject)
        ' Attempt to pick up a surrounding item.
    end sub

    '' Move ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    
    public overrides sub move (byval x as integer, byval y as integer)
        ' A more flexible version of move function.
        dim collider as GameObject = GAME.LEVEL.checkCollision(
            me.x + x, me.y+y)
        if not collider is nothing then
            ' Check GameObject type.
            GAME.MESSAGEBOX.addMessage(
                "Press O to interact with " & collider.name)
        end if
        ' Check if wall. TODO: Remove this. Cannot overlap any GameObject. 
        dim isWall = GAME.LEVEL.isWall(me.x + x, me.y + y)
        if not isWall and collider is nothing then
            me.x += x
            me.y += y
            GAME.MESSAGEBOX.addMessage(
                GAME.USER.name & " moved "&  x.toString &","& y.toString)
        end If
    end sub
end class