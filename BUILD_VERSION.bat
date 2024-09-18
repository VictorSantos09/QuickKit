@echo off

REM Executando o build da solução
echo Executando build da solução...
dotnet build

echo Criando output "dist"
mkdir dist

echo.

echo copiando QuickKit.dll
copy QuickKit\bin\debug\net7.0\QuickKit.dll ..\QuickKit\dist

echo copiando QuickKit.AspNetCore.dll
copy QuickKit.AspNetCore\bin\debug\net7.0\QuickKit.AspNetCore.dll ..\QuickKit\dist

echo copiando QuickKit.Cmd.dll
copy QuickKit.Cmd\bin\debug\net7.0\QuickKit.Cmd.dll ..\QuickKit\dist

echo copiando QuickKit.ResultTypes.dll
copy QuickKit.ResultTypes\bin\debug\net7.0\QuickKit.ResultTypes.dll ..\QuickKit\dist

echo copiando QuickKit.Security.dll
copy QuickKit.Security\bin\debug\net7.0\QuickKit.Security.dll ..\QuickKit\dist

echo copiando QuickKit.Shared
copy QuickKit.Shared\bin\debug\net7.0\QuickKit.Shared.dll ..\QuickKit\dist

echo copiando QuickKit.Blazor
copy QuickKit.Blazor\bin\debug\net8.0\QuickKit.Blazor.dll ..\QuickKit\dist

if exist "dist\dist.zip" del "dist\dist.zip"

REM Compacta os arquivos na pasta "dist" usando 7-Zip
echo Compactando arquivos...
"C:\Program Files\7-Zip\7z.exe" a -r dist\dist.zip dist\*


echo Finalizado

pause done