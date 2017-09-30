if "%PROCESSOR_ARCHITECTURE%"=="x86" goto regasm_for_x86
if "%PROCESSOR_ARCHITECTURE%"=="X86" goto regasm_for_x86
if "%PROCESSOR_ARCHITECTURE%"=="amd64" goto regasm_for_x64
if "%PROCESSOR_ARCHITECTURE%"=="AMD64" goto regasm_for_x64

:regasm_for_x86
RegAsm32.exe ..\NurdocControl.dll /codebase NurdocControl.NurPatContrl
goto end

:regasm_for_x64
RegAsm64.exe ..\NurdocControl.dll /codebase NurdocControl.NurPatContrl
goto end

:end
pause