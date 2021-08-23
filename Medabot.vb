' Medabot object. Contains stats and items for a medabot.
' Medabots are found throughout game world and can be interacted with.
' They can have special functions and battle with the user.

public class Medabot
    inherits GameObject

    '' Medabot Attributes ''''''''''''''''''''''''''''''''''''''''''''''''''''''

    ' Medabot name.
    public overridable property name as string

    ' Stats.
    public hp as integer = 10
    public attack as integer = 1
    public speed as integer = 1
    public level as integer = 0 

    ' Collections.
    public augments() as GameObject
    public inventory() as GameObject
    
    ' Parts.
    public medal as GameObject
    public head as GameObject
    public legs as GameObject
    public arm1 as GameObject
    public arm2 as GameObject

    ' Weapons.
    public weaponMain as GameObject
    public weaponSub as GameObject
    public maxAmmo as integer = 5
    public ammo as integer = me.maxAmmo

    '' Constructors ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    
    public sub new ()
        myBase.new
    end sub

    public sub new (byval _x as integer, byval _y as integer)
        ' Spawn gameObject at a coord in game grid.
        myBase.new(_x, _y)
    end sub

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

    '' Trade '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    public sub trade (byref obj as GameObject, byref otherObj as GameObject)
        ' Replace items in 2 medabot's inventories.
    end sub
end class