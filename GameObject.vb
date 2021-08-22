' An object in the gameworld. 
' Holds the object's grid coordinates.
' One of the core game engine classes.

public class GameObject
    public sub new()
        ' Spawn the GameObject in the level.
        console.writeline("(*) New GameObject.")
    end sub

    public sub move()
        ' Move the users character in the level grid.
    end sub
end class