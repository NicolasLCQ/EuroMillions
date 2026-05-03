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

$dbPath = (Resolve-Path (Join-Path $repoRoot "database\\EuroMillions.db")).Path
$infraProject = Join-Path $repoRoot "server\\EuroMillions.Infrastructure\\EuroMillions.Infrastructure.csproj"
$startupProject = Join-Path $repoRoot "server\\EuroMillions.API\\EuroMillions.API.csproj"

try {
    $null = & dotnet ef --version 2>$null
    if ($LASTEXITCODE -ne 0) {
        throw "dotnet-ef manquant. Installe-le avec: dotnet tool install --global dotnet-ef"
    }

    Write-Host "Scaffolding from: $dbPath"

    Push-Location $repoRoot
    try {
        & dotnet ef dbcontext scaffold "Data Source=$dbPath" "Microsoft.EntityFrameworkCore.Sqlite" `
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
