# Medabots.exe compilation script.
cls

echo "(* Build) Compiling Medabots.exe..."

&$env:vbc `
`
Main.vb `
MedabotsGame.vb `
Level.vb `
GameObject.vb `
GameDebugger.vb `
Medabot.vb `
User.vb `
WindowManager.vb `
/out:Medabots.exe /nologo /nowarn

echo "(* Build) Compilation done."

# Run the game.
# ./Medabots.exe
invoke-expression 'cmd /c start powershell -Command { ./Medabots.exe }'