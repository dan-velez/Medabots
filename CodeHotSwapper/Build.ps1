# Build CodeHotSwapper.exe
cls

echo ("(* Build) Compiling CodeHotSwapper.exe...")
&$env:vbc `
CodeHotSwapper.vb `
/out:CodeHotSwapper.exe `
/nowarn /nologo
echo ("(* Build) Compilation done. CodeHotSwapper.exe is ready.")
echo("")

./CodeHotSwapper.exe ../ .