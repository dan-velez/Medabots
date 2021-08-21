imports Timing

module main

class Point
    private x as integer
    private y as integer

    public sub New()
        x = 0
        y = 0
    end sub

    public sub new(byval xcor as integer, byval ycor as integer)
        x = xcor
        y = ycor
    end sub

    public property xval as integer
        get
            return x
        end get

        set(byval value as integer)
            x = value
        end set
    end property

    public overrides function ToString() as string
        return x & ", " & y
    end function

    public function equal(byval p as point) as boolean
        if (me.x = p.x) and (me.y = p.y) then
            return true
        else
            return false
        end if
    end function
end class


public class Circle 
    Inherits Point
    
    private radius as single

    public sub new(byval x as integer, byval y as integer, byval r as single)
        mybase.new(x, y)
        setRadius(r)
    end sub

    private sub setRadius(byval value as single)
        if (value > 0) then
            radius = value
        else
            radius = 0.0
        end if
    end sub

    public readonly property getRadius() as single
        get
            return radius
        end get
    end property

    public function area() as single
        return Math.PI * radius * radius
    end function
end class

sub buildArray(byval arr() as integer)
    dim index as integer
    for index = 0 to 99999
        arr(index) = index
    next
end sub

sub displayNums(byval arr() as integer)
    dim index as integer
    for index = 0 to arr.getUpperBound(0)
        console.writeline(arr(index))
    next
end sub

sub main()
    console.writeline("VB Tester")
    displayNums({1, 2, 3, 4})
end sub

end module