' Monitor a directory for file changes. Recompile and run on change.
' BUG: Need to spawn in background focus
' TODO: Log changed file info
' TODO: Changes in nested directory
' TODO: Recompile


imports System.IO
imports System.Diagnostics

module Main
     Declare Function SetForegroundWindow Lib "user32.dll" (ByVal hwnd As Integer) As Integer 

    private watchFolder as FileSystemWatcher
    private promptString as string = "codeHotSwapper>"

    ' Number of changes that have been made in lifecycle of swapper.
    private changes as integer = 0

    ' The process to swap when code or file is changed.
    private swapProcessPath as string = Path.GetFullPath("..\Medabots.exe")
    private  swapProcessBuildScript as string = Path.GetFullPath("..\Build.ps1")
    private swapProcess as Process

    '' Main FileWatcher ''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    sub main()
        console.writeLine(swapProcessBuildScript)
        ' Parse CLI args.
        dim clArgs() as string = Environment.GetCommandLineArgs
        dim dirPath as string = Path.GetFullPath(clArgs(1))

        ' Log info.
        console.writeLine("(*) Watching folder: " & dirPath & environment.newLine)

        ' Init watchDog.
        watchfolder = New System.IO.FileSystemWatcher()
        watchFolder.path = dirPath

        ' Register file event listeners.
        AddHandler watchfolder.Changed, AddressOf logchange
        AddHandler watchfolder.Created, AddressOf logchange
        AddHandler watchfolder.Deleted, AddressOf logchange
        AddHandler watchfolder.Renamed, AddressOf logrename

        ' Start watching.
        watchfolder.EnableRaisingEvents = true

        ' Start game here. Restart program on changes.
        swapProcess = System.Diagnostics.Process.Start(swapProcessPath)

        ' Start infinite loop for swapper.
        dim vcommand as string = ""
        while vcommand.tolower <> "exit"
            console.write("codeHotSwapper> ")
            vcommand = console.readline
            if vcommand.toUpper = "SWAP" then restartProcess
        end while
        printm(promptString & " Exit hot swapper.")
    end sub

    '' Events ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    sub logchange(ByVal source As Object, 
                  ByVal e As System.IO.FileSystemEventArgs)
        ' A file in the directory has changed.
        changes += 1
        printm("(*) Change " & changes.toString)
        restartProcess
    end sub

    sub logrename(ByVal source As Object, ByVal e As _
                  System.IO.RenamedEventArgs)
        ' A file has been renamed.
        changes += 1
        printm("(*) Change " & changes.toString)
        restartProcess
    end sub

    '' Process Subs ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    sub restartProcess()
        ' Code or resource has changed. Stop process and start again.
        try
            swapProcess.kill()
        catch e as exception
        end try

        swapProcess = System.Diagnostics.Process.Start(swapProcessPath)
        ' SwitchToThisWindow(ideProc.mainWindowHandle, true)
        ' dim ideProc = Process.GetCurrentProcess().MainWindowHandle
        dim ideProc = Process.GetProcessesByName("Code").FirstOrDefault.MainWindowHandle
        SetForegroundWindow(ideProc)

        ' Restart game, dont focus.
        ' shell(swapProcessPath, AppWinStyle.NormalFocus)
        ' swapProcess = System.Diagnostics.Process.Start(swapProcessBuildScript)

        ' Change dir to build script.
        ' Compile in shell mode.
        
        ' shell("cd ..\ ; " & swapProcessBuildScript)
        ' swapProcess = System.Diagnostics.Process.Start(swapProcessPath)
        ' shell(swapProcessPath)

    end sub

    '' Utils '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    sub printm(byval mesg as string)
        ' Modified print routine for this process.
        console.writeLine("")
        console.writeLine(mesg)
        console.write(promptString & " ")
    end sub
end module