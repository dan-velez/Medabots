' Functions dealing with the console window / terminal.
' Use the global Console object to deal with window attributes.

public class WindowManager
    private xpos as integer 
    private ypos as integer 
    private width as integer
    private height as integer

    public sub setWindowPosition(byval x as integer, byval y as integer)
        ' Set the console window to a starting position.
        me.xpos = x
        me.ypos = y
        console.setWindowPosition(x, y)
    end sub

    public sub setWindowSize(byval w as integer, byval h as integer)
        ' Adjust the games window.
        me.width = w
        me.height = h
        console.setWindowSize(40, 30)
        ' console.setWindowSize(55, 55)
        console.setBufferSize(80, 80)
    end sub

    public sub clearConsole()
        ' Clears the terminal. Windows only for now.
        ' System.Diagnostics.Process.Start("cls")
        console.clear
    end sub
end class