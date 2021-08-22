' Monitor a directory for file changes. Recompile and run on change.
' BUG: Need to spawn in background focus
' TODO: Log changed file info
' TODO: Changes in nested directory
' TODO: Recompile -> USE shell("powershell <FNAME>")


imports System.IO
imports System.Diagnostics
imports System.Runtime.InteropServices

module Main
    ' <DllImport("user32.dll")>
    ' Function FindWindow(ByVal strclassName As String, ByVal strWindowName As String) As Integer
    ' End Function

    '  Declare Function SetForegroundWindow Lib "user32.dll" _
    '                   (ByVal hwnd As Integer) As Integer 

    ' Declare Sub SwitchToThisWindow Lib "user32.dll" ( _
    '     hWnd As IntPtr, fAltTab As Boolean)


    private watchFolder as FileSystemWatcher
    private promptString as string = "codeHotSwapper>"

    ' Number of changes that have been made in lifecycle of swapper.
    private changes as integer = 0

    ' The process to swap when code or file is changed.
    private swapProcessDirPath as string
    private swapProcessPath as string = Path.GetFullPath("..\Medabots.exe")
    private swapProcessBuildScript as string = Path.GetFullPath("..\Build.ps1")
    private swapProcess as Process

    '' Main FileWatcher ''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    sub main()
        console.writeLine(swapProcessBuildScript)
        ' Parse CLI args.
        dim clArgs() as string = Environment.GetCommandLineArgs
        swapProcessDirPath = Path.GetFullPath(clArgs(1))

        ' Log info.
        console.writeLine("(*) Watching folder: " & _
                          swapProcessDirPath & environment.newLine)

        ' Init watchDog.
        watchfolder = New System.IO.FileSystemWatcher()
        watchFolder.path = swapProcessDirPath

        ' Register file event listeners.
        AddHandler watchfolder.Changed, AddressOf logchange
        AddHandler watchfolder.Created, AddressOf logchange
        AddHandler watchfolder.Deleted, AddressOf logchange
        AddHandler watchfolder.Renamed, AddressOf logrename

        ' Start watching.
        watchfolder.EnableRaisingEvents = true

        ' Start game here. Restart program on changes.
        swapProcess = new Process
        swapProcess.startInfo = new ProcessStartInfo(swapProcessPath)
        ' swapProcess.startInfo.WindowStyle = ProcessWindowStyle.Minimized
        swapProcess.start

        ' Start infinite loop for swapper.
        ' dim vcommand as string = ""
        ' while vcommand.tolower <> "exit"
        '     console.write("codeHotSwapper> ")
        '     vcommand = console.readline
        '     if vcommand.toUpper = "SWAP" then restartProcess
        ' end while
        ' printm(promptString & " Exit hot swapper.")
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
            ' Process was previously closed by user.
        end try

        ' Recompile program.
        FileSystem.chdir(swapProcessDirPath)
        console.writeLine(FileSystem.CurDir)
        for each s as string in directory.getFiles(FileSystem.CurDir)
            console.writeLine("(*) File: " & s)
        next

        ' dim pid = Interaction.Shell("Build.ps1", false, -1)

        ' Start the new, recompiled program.
        swapProcess.start()
        
        ' Threading.Thread.Sleep(3000)
        ' Dim theHandle As IntPtr
        ' theHandle = FindWindow(Nothing, 
        ' "CodeHotSwapper.vb - Medabots - Visual Studio Code")
        ' SetForegroundWindow(theHandle)

        ' dim ideProc = Process.GetCurrentProcess().MainWindowHandle
        ' SwitchToThisWindow(ideProc, true)
        ' dim ideProc = Process.GetProcessesByName("Code").FirstOrDefault
        '    .MainWindowHandle
        ' SetForegroundWindow(ideProc)
    end sub

    '' Utils '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    sub printm(byval mesg as string)
        ' Modified print routine for this process.
        console.writeLine("")
        console.writeLine(mesg)
        console.write(promptString & " ")
    end sub
end module