' An object in the gameworld. Holds the object's grid coordinates.
' A core TextGameEngine class.

public class GameObject
    protected x as integer
    protected y as integer

    public sub new()
        ' Default constructor.
    end sub

    public sub new(byval _x as integer, byval _y as integer)
        me.x = _x
        me.y = _y
    end sub
end class