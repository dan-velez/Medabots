# Medabots.exe compilation script.
cls

echo "(* Build) Compiling Medabots.exe..."
# &$env:vbc Main.vb MedabotsGame.vb GameObject.vb Medabot.vb Player.vb /out:Medabots.exe /nologo /nowarn
&$env:vbc Main.vb MedabotsGame.vb Level.vb /out:Medabots.exe /nologo /nowarn
echo "(* Build) Compilation done."

# Run the game.
# ./Medabots.exe