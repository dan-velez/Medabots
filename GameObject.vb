' An object in the gameworld. Holds the object's grid coordinates.
' A core TextGameEngine class.

public class GameObject
    public property x as integer
    public property y as integer
    public overridable property name as string = "GO"
    public overridable property icon as string = "O"
    public overridable property type as string = "GameObject"
    '' Constructors ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    public sub new ()
        ' Default constructor.
        me.x = 2
        me.y = 2
    end sub

    public sub new (byval _x as integer, byval _y as integer)
        ' Spawn gameObject at a coord in game grid.
        me.type = "GameObject"
        me.x = _x
        me.y = _y
    end sub

    public sub new (byval type as string, byval _x as integer, 
                    byval _y as integer)
        ' Spawn gameObject at a coord in game grid.
        me.type = type
        me.x = _x
        me.y = _y
    end sub

    '' Update ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    
    public overridable sub update ()
        ' run this method once every game cycle for all gameObjects in level.
    end sub 

    '' Set Position ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    public sub setPosition (byval _x as integer, byval _y as integer)
        ' Shortcut to set this GameObject's location on the screen.
        me.x = _x
        me.y = _y
    end sub
end class