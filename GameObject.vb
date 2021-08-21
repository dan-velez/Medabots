class GameObject
    property x as integer
    property y as integer

    public sub new()
        ' Spawn the GameObject in the level.
        console.writeline("(*) New GameObject.")
    end sub
end class