' Functions dealing with the console window / terminal.
' Use the global Console object to deal with window attributes.

public class WindowManager
    ' Position of console on screen.
    private xpos as integer 
    private ypos as integer

    ' Width and height in COLUMNS and ROWS of text.
    public property width as integer
    public property height as integer

    public sub new (byval w as integer, byval h as integer)
        ' Initialize window settings for console game.
        ' Load window settings from disk (w, h, x, y, color).
        me.width = w
        me.height = h
        console.cursorVisible = false
        console.title = GAME.title
        ' console.backgroundColor = consoleColor.black
    end sub

    public sub setWindowPosition (byval x as integer, byval y as integer)
        ' Set the console window to a starting position.
        me.xpos = x
        me.ypos = y
        console.setWindowPosition(x, y)
    end sub

    public sub setWindowSize (optional byval w as integer = 40, 
                              optional byval h as integer = 32)
        ' Adjust the games window.
        ' Default: 32, 40
        ' TODO: Uses default values for now.
        me.width = w
        me.height = h
        ' Set Columns, Rows
        ' TODO: Set buffer to bigger, then set the window size.
        console.setWindowSize(w, h)
        console.bufferWidth = console.windowWidth
        console.bufferHeight = console.windowHeight
    end sub

    public sub clearConsole ()
        ' Clears the terminal. Windows only for now.
        console.clear
    end sub
end class