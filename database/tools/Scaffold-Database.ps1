param(
    [switch]$NoPause
)

Set-StrictMode -Version Latest
$ErrorActionPreference = "Stop"

function Wait-ForUser([string]$Message) {
    if (-not $NoPause) {
        $null = Read-Host $Message
    }
}

$scriptDir = Split-Path -Parent $PSCommandPath
$repoRoot = (Resolve-Path (Join-Path $scriptDir "..\\.." )).Path
$serverDir = Join-Path $repoRoot "server"

$dbPath = (Resolve-Path (Join-Path $repoRoot "database\\EuroMillions.db")).Path
$infraProject = Join-Path $repoRoot "server\\EuroMillions.Infrastructure\\EuroMillions.Infrastructure.csproj"
$startupProject = Join-Path $repoRoot "server\\EuroMillions.API\\EuroMillions.API.csproj"

try {
    $dotnetCommand = Get-Command dotnet -ErrorAction SilentlyContinue
    if ($null -eq $dotnetCommand) {
        throw "dotnet est introuvable dans le PATH. Verifie l'installation du SDK .NET avec: dotnet --info"
    }

    $null = & dotnet tool run dotnet-ef --version 2>$null
    if ($LASTEXITCODE -ne 0) {
        Write-Host "Restauration de l'outil local dotnet-ef..."

        Push-Location $serverDir
        try {
            & dotnet tool restore
            if ($LASTEXITCODE -ne 0) {
                throw "dotnet tool restore a echoue avec le code $LASTEXITCODE"
            }
        }
        finally {
            Pop-Location
        }
    }

    Write-Host "Scaffolding from: $dbPath"

    Push-Location $serverDir
    try {
        $null = & dotnet tool run dotnet-ef --version 2>$null
        if ($LASTEXITCODE -ne 0) {
            throw "dotnet-ef est introuvable ou son execution echoue. Essaie depuis le dossier server: dotnet tool restore"
        }

        & dotnet tool run dotnet-ef dbcontext scaffold "Data Source=$dbPath" "Microsoft.EntityFrameworkCore.Sqlite" `
            --project "$infraProject" `
            --startup-project "$startupProject" `
            --context "EuroMillionsDbContext" `
            --context-dir "Context" `
            --output-dir "Entities" `
            --context-namespace "EuroMillions.Infrastructure.Context" `
            --namespace "EuroMillions.Infrastructure.Entities" `
            --no-onconfiguring `
            --use-database-names `
            --force

        if ($LASTEXITCODE -ne 0) {
            throw "Scaffold failed with exit code $LASTEXITCODE"
        }

        Write-Host "Scaffold termine."
    }
    finally {
        Pop-Location
    }

    Wait-ForUser "Execution terminee. Appuie sur Entree pour fermer."
}
catch {
    Write-Error $_
    Wait-ForUser "Une erreur est survenue. Appuie sur Entree pour fermer."
    throw
}
