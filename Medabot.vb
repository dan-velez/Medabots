public class Medabot
    inherits GameObject

    ' Medabot name.
    dim name as string = "Bot"

    ' Which direction player is facing.
    dim direction as string = "N"

    ' Stats.
    dim hp as integer = 10
    dim attack as integer = 1
    dim jump as integer = 1
    dim dodge as integer = 1
    dim speed as integer = 1

    ' Collections.
    dim buffs() as GameObject
    dim items() as GameObject
    
    ' Parts.
    dim medal as GameObject
    dim head as GameObject
    dim legs as GameObject
    dim arm1 as GameObject
    dim arm2 as GameObject
    dim weaponMain as GameObject
    dim weaponSub as GameObject

    sub loadFromFile(byval filePath as string)
        ' Load medabots data from a JSON file.
    end sub
end class