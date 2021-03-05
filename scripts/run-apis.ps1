cd ..\SearchEngine.API

$numOfProc = $args[0]

if ($numOfProc -lt 2) { $numOfProc = 1 }

for ($i = 1; $i -lt $numOfProc; $i+=1) 
{
    start powershell { dotnet watch run --urls=http://localhost:5002/ }
}

dotnet watch run --urls=http://localhost:5000/