' The user's medabot. A controllable medabot object.
' User medabot is controlled by cursor keys and through bot commands.

public class User 
    inherits Medabot

    public overrides property icon as string = "@"
    public overrides property name as string = "Medabot00"

    '' Constructors ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    
    public sub new ()
        myBase.new
        me.load()
    end sub

    public sub load ()
        ' Load player data from disk.
        me.weaponMain = new GameObject
        me.weaponSub = new GameObject
    end sub
end class