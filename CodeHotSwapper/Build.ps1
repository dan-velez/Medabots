# Build CodeHotSwapper.exe
cls

echo ("(* Build) Compiling CodeHotSwapper.exe...")
&$env:vbc `
CodeHotSwapper.vb `
/out:CodeHotSwapper1.1.exe `
/nowarn /nologo
echo ("(* Build) Compilation done. CodeHotSwapper.exe is ready.")
echo("")

./CodeHotSwapper1.1.exe ../ .