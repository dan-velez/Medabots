' Functions dealing with the console window / terminal.
' Use the global Console object to deal with window attributes.

imports System.Text

public class WindowManager
    ' Position of console on screen.
    private xpos as integer 
    private ypos as integer

    ' Width and height in COLUMNS and ROWS of text.
    public property width as integer
    public property height as integer

    '' Constructors ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    public sub new (byval w as integer, byval h as integer)
        ' Initialize window settings for console game.
        ' Load window settings from disk (w, h, x, y, color).
        me.width = w
        me.height = h
        console.cursorVisible = false
        console.title = GAME.title
        console.backgroundColor = consoleColor.black
        console.foregroundColor = consoleColor.white
    end sub

    '' Size & Position '''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    public sub setWindowPosition (byval x as integer, byval y as integer)
        ' Set the console window to a starting position.
        me.xpos = x
        me.ypos = y
        console.setWindowPosition(x, y)
    end sub

    public sub setWindowSize (optional byval w as integer = 40, 
                              optional byval h as integer = 32)
        ' Adjust the games window.
        me.width = w
        me.height = h
        ' Set Columns, Rows
        ' TODO: Set buffer to bigger, then set the window size.
        console.setWindowSize(10, 10)
        console.bufferWidth = w
        console.bufferHeight = h
        console.setWindowSize(w, h)
    end sub

    '' Clear Console '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    public sub clearConsole ()
        ' Clears the terminal. Windows only for now.
        console.setCursorPosition(0, 0)
        ' console.clear
        ' me.clearConsoleAll
    end sub

    public sub clearConsoleAll ()
        ' Clear the console and prevent flickering from normal clear console
        ' function in Console class.
        dim sBuilder as new StringBuilder 

        console.setCursorPosition(0, 0)
        for i as integer = 0 to me.height
            for j as integer = 0 to me.width
                sBuilder.append(" ")
            next
            sBuilder.append(chr(13))
        next

        console.write(sBuilder.toString)
    end sub
end class