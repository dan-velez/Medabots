' Rokusho medabot. First enemy medabot, testing out battle system design.

class Rokusho 
    inherits Medabot

    '' Constructors ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    public sub new (byval x as integer, byval y as integer)
        mybase.new(x, y)
        me.name = "Rokusho"
    end sub

    '' Update ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
 
    public overrides sub update ()
        ' Move in a pattern. User should identify pattern to run into 
        ' Rokusho and choose to battle him.
        GAME.MESSAGEBOX.addMessage("Rokusho!!")
    end sub
end class