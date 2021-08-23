' Functions dealing with the console window / terminal.
' Use the global Console object to deal with window attributes.

public class WindowManager
    ' Position of console on screen.
    private xpos as integer 
    private ypos as integer

    ' Width and height in COLUMNS and ROWS of text.
    private width as integer
    private height as integer

    public sub new ()
        ' Initialize window settings for console game.
        console.cursorVisible = false
    end sub

    public sub setWindowPosition (byval x as integer, byval y as integer)
        ' Set the console window to a starting position.
        me.xpos = x
        me.ypos = y
        console.setWindowPosition(x, y)
    end sub

    public sub setWindowSize (byval w as integer, byval h as integer)
        ' Adjust the games window.
        ' TODO: Uses default values for now.
        me.width = w
        me.height = h
        ' Set Columns, Rows
        console.setWindowSize(40, 32)
        console.bufferWidth = console.windowWidth
        console.bufferHeight = console.windowHeight
    end sub

    public sub clearConsole ()
        ' Clears the terminal. Windows only for now.
        console.clear
    end sub
end class