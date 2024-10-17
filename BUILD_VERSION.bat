@echo off

:inicio
cls
REM Solicitar caminho de destino
call :getDestinationPath

REM Solicitar quais DLLs copiar
call :getUserChoices

REM Executar build
call :buildSolution

REM Copiar DLLs com base nas escolhas do usuário
call :copyDlls

REM Compactar arquivos
call :zipFiles

REM Loop para regenerar, reiniciar ou encerrar
call :menuOptions
goto fim

:getDestinationPath
REM Pergunta o caminho de destino ao usuário
set /p destPath=Informe o caminho onde deseja copiar as DLLs (ex: C:\destino): 

REM Verifica se o usuário inseriu o caminho
if "%destPath%"=="" (
    echo Caminho nao informado. O script sera encerrado.
    pause
    exit /b
)

REM Criar a pasta de saída, se não existir
if not exist "%destPath%" (
    mkdir "%destPath%"
)
exit /b

:getUserChoices
REM Perguntar sobre cada DLL
set /p copyQuickKit=Deseja copiar QuickKit.dll? (S/N): 
set /p copyAspNetCore=Deseja copiar QuickKit.AspNetCore.dll? (S/N): 
set /p copyCmd=Deseja copiar QuickKit.Cmd.dll? (S/N): 
set /p copyResultTypes=Deseja copiar QuickKit.ResultTypes.dll? (S/N): 
set /p copySecurity=Deseja copiar QuickKit.Security.dll? (S/N): 
set /p copyShared=Deseja copiar QuickKit.Shared.dll? (S/N): 
set /p copyBlazor=Deseja copiar QuickKit.Blazor.dll? (S/N): 
exit /b

:buildSolution
echo Executando build da solução...
dotnet build
exit /b

:copyDlls
echo Copiando DLLs selecionadas...

REM Copiar as DLLs com base na escolha do usuário
if /i "%copyQuickKit%"=="S" (
    echo copiando QuickKit.dll
    copy QuickKit\bin\debug\net8.0\QuickKit.dll "%destPath%"
)

if /i "%copyAspNetCore%"=="S" (
    echo copiando QuickKit.AspNetCore.dll
    copy QuickKit.AspNetCore\bin\debug\net8.0\QuickKit.AspNetCore.dll "%destPath%"
)

if /i "%copyCmd%"=="S" (
    echo copiando QuickKit.Cmd.dll
    copy QuickKit.Cmd\bin\debug\net8.0\QuickKit.Cmd.dll "%destPath%"
)

if /i "%copyResultTypes%"=="S" (
    echo copiando QuickKit.ResultTypes.dll
    copy QuickKit.ResultTypes\bin\debug\net8.0\QuickKit.ResultTypes.dll "%destPath%"
)

if /i "%copySecurity%"=="S" (
    echo copiando QuickKit.Security.dll
    copy QuickKit.Security\bin\debug\net8.0\QuickKit.Security.dll "%destPath%"
)

if /i "%copyShared%"=="S" (
    echo copiando QuickKit.Shared.dll
    copy QuickKit.Shared\bin\debug\net8.0\QuickKit.Shared.dll "%destPath%"
)

if /i "%copyBlazor%"=="S" (
    echo copiando QuickKit.Blazor.dll
    copy QuickKit.Blazor\bin\debug\net8.0\QuickKit.Blazor.dll "%destPath%"
)
exit /b

:zipFiles
echo Compactando arquivos...
if exist "%destPath%\dist.zip" del "%destPath%\dist.zip"
"C:\Program Files\7-Zip\7z.exe" a -r "%destPath%\dist.zip" "%destPath%\*"
exit /b

:menuOptions
echo Escolha uma opcao:
echo 1. Regenerar no mesmo caminho
echo 2. Informar novo caminho
echo 3. Encerrar
set /p option=Digite o numero da opcao e pressione Enter: 

if "%option%"=="1" (
    call :copyDlls
    call :zipFiles
    goto menuOptions
)

if "%option%"=="2" goto inicio
if "%option%"=="3" goto fim

echo Opcao invalida, tente novamente.
goto menuOptions

:fim
echo Script finalizado.
pause
exit
