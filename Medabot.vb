' Medabot object. Contains stats and items for a medabot.
' Medabots are found throughout game world and can be interacted with.
' They can have special functions and battle with the user.

public class Medabot
    inherits GameObject

    ' Medabot name.
    public overridable property name as string

    ' Stats.
    protected dim hp as integer = 10
    protected dim attack as integer = 1
    protected dim speed as integer = 1

    ' Collections.
    protected dim buffs() as GameObject
    protected dim items() as GameObject
    
    ' Parts.
    protected dim medal as GameObject
    protected dim head as GameObject
    protected dim legs as GameObject
    protected dim arm1 as GameObject
    protected dim arm2 as GameObject

    ' Weapons.
    protected dim weaponMain as GameObject
    protected dim weaponSub as GameObject
    protected dim maxAmmo as integer = 5
    protected dim ammo as integer = me.maxAmmo
end class