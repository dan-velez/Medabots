' Medabot object. Contains stats and items for a medabot.

public class Medabot
    inherits GameObject

    ' Medabot name.
    protected dim name as string = "MyMedabot"

    ' Which direction player is facing.
    protected dim direction as string = "N"

    ' Stats.
    protected dim hp as integer = 10
    protected dim attack as integer = 1
    protected dim jump as integer = 1
    protected dim dodge as integer = 1
    protected dim speed as integer = 1
    protected dim maxAmmo as integer = 5
    protected dim ammo as integer = me.maxAmmo

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
end class