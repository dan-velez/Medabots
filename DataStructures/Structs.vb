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

    Structure group
        Public name

        Public Sub New(value As String)
            name = value
        End Sub
    End Structure

    sub main_2 ()
        Dim listGroups As New List(Of group)
        listGroups.Add(New group("group 1"))
        Dim groupName As string = listGroups.Last().name
    end sub
end module