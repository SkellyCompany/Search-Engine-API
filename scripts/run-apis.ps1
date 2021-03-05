cd ..\SearchEngine.API

$numOfProc = $args[0]

if ($numOfProc -lt 2) { $numOfProc = 1 }

if ($numOfProc -gt 10) { Write-Error 'No more than 10 processes!' }

$commands = @()

for ($i = 0; $i -lt $numOfProc; $i+=1)
{
    $commands += "dotnet watch run --urls=https://localhost:500" + ($i).ToString() + "/;http://localhost:510" + ($i).ToString() + "/"
}

foreach($command in $commands) 
{
    $startCommand = "start powershell { " + $command + "; Read-Host }"
    Invoke-Expression $startCommand
}