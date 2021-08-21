' Monitor a directory for file changes. 
' Recompile on change.
' Run program with last compile error as argument.

imports System.IO
imports System.Diagnostics

module Main
    private watchFolder as FileSystemWatcher
    private changes as integer = 0
    
    sub main()
        ' Parse CLI args.
        dim clArgs() as string = Environment.GetCommandLineArgs
        dim dirPath as string = Path.GetFullPath(clArgs(1))

        ' Log info.
        console.writeLine("(*) DirPath: " & dirPath & environment.newLine)

        ' Init watchDog.
        watchfolder = New System.IO.FileSystemWatcher()
        watchFolder.path = dirPath

        ' Set filter for events to watch for.
        ' watchfolder.NotifyFilter = IO.NotifyFilters.DirectoryName
        ' watchfolder.NotifyFilter = watchfolder.NotifyFilter Or _
        '                            IO.NotifyFilters.FileName
        ' watchfolder.NotifyFilter = watchfolder.NotifyFilter Or _ 
        '                            IO.NotifyFilters.Attributes
        ' watchfolder.NotifyFilter = watchfolder.NotifyFilter Or _ 
        '                            IO.NotifyFilters.Attributes
        
        ' Set event handlers.
        AddHandler watchfolder.Changed, AddressOf logchange
        AddHandler watchfolder.Created, AddressOf logchange
        AddHandler watchfolder.Deleted, AddressOf logchange
        AddHandler watchfolder.Renamed, AddressOf logrename

        ' Start watching.
        watchfolder.EnableRaisingEvents = true

        ' Start gameLoop here.
        System.Diagnostics.Process.Start("..\Medabots.exe")
        dim vexit as string = console.readline
        while vexit.tolower <> "exit"
            vexit = console.readline
        end while
    end sub

    sub logchange(ByVal source As Object, 
                  ByVal e As System.IO.FileSystemEventArgs)
        ' A file in the directory has changed.
        changes += 1
        console.writeLine("(*) Change " & changes.toString)
    end sub

    sub logrename(ByVal source As Object, ByVal e As _
                  System.IO.RenamedEventArgs)
        ' A file has been renamed.
        console.writeLine("(*) Change " & changes.toString)
        changes += 1
    end sub

end module