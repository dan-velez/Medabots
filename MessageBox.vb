' MessageBox holds all the messages that the game sends to the player. It will
' store and display any messages from other medabots as well.

imports System.Collections.Generic

public class MessageBox
    private filter as string = "INFO" ' | DEBUG
    private maxLineSize as integer = 32
    private messages as List(of string())
    private messageBufferSize = 4

    '' Utils '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    public sub splitLine (byval vlen as string)
        ' Split a line by words to a max length.
        dim res as string = ""
    end sub

    '' Constructors ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    public sub new ()
        ' Init new messages struct with default messages.
        me.messages = new List(of string())
        me.maxLineSize = GAME.WMANAGER.width - 1
        me.addMessage("Welcome to medabots!")
        me.addMessage("You are in level ("& GAME.LEVEL.name &")")
        me.addMessage("Your medabot " & GAME.USER.name & " is ready to battle.")
        me.addMessage("Press M and N to cycle through medabots menus.")
    end sub

    '' Render ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    public function render () as string
        ' Renders  all messages to screen.
        dim res as string = ""
        res = res & "Messages" & environment.newLine & _ 
              "".padRight(me.maxLineSize+1, "-") & environment.newLine
        
        ' Render last message with different icon.
        dim i as integer = 0
        dim buffer = messages.skip(messages.count - messageBufferSize)
        for each mesg as string() in buffer
            if i = buffer.count - 1 then
                res += "> " & mesg(0)
            else
                res += "* " & mesg(0)
            end if
            res += environment.newLine
            i+=1
        next
        console.write(res)
        return res
    end function

    '' Add to Messages '''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    public sub addMessage (byval mesg as string, 
                           optional byval level as string="INFO")
        ' Send a message to message box console.
        me.messages.add({mesg, level})
    end sub
end class