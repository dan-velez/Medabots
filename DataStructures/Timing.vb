' Testing VB.NET OOP features.

public class Timing
    private startingTime as TimeSpan
    private duration as TimeSpan

    public sub new()
        startingTime = new TimeSpan(0)
        duration = new TimeSpan(0)
    end sub
end class


module main
    sub prinf(byval mesg as string)
        console.writeline(mesg)
    end sub

    sub main()
        console.foregroundColor = consoleColor.green
        console.writeline("Timing class file.")
        dim t as new Timing
    end sub
end module