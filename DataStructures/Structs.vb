module Module1
    public structure name
        dim fname as string
        dim lname as string
        dim mname as string
    end structure

    public sub main ()
        dim myname as name
        myname.fname = "Daniel"
        myname.lname = "Velez"
    end sub
end module