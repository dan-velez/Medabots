# Compilation Script.
cls

echo "(* Build) Compiling Utils.exe..."

&$env:vbc `
`
Utils.vb `
`
/out:Utils.exe /nologo /nowarn

echo "(* Build) Compilation done."

# Run the program.
./Utils.exe