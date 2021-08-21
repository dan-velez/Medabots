class Player
    inherits Medabot

    public sub new(optional byval playerFile as string)
        ' Initialize or load saved player.
    end sub

    public sub attack()
        ' Attempt to deal damage to a GameObject.
        console.writeLine(me.attack)
    end sub
end class