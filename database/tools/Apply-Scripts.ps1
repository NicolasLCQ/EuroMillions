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
$repoRoot = (Resolve-Path (Join-Path $scriptDir "..\..")).Path

$dbPath = Join-Path $repoRoot "database\EuroMillions.db"
$scriptsDir = Join-Path $repoRoot "database\Scripts"

try {
    $sqliteCommand = Get-Command sqlite3 -ErrorAction SilentlyContinue
    if ($null -eq $sqliteCommand) {
        throw "sqlite3 manquant. Installe-le ou ajoute-le au PATH."
    }

    if (-not (Test-Path $scriptsDir -PathType Container)) {
        throw "Dossier introuvable: $scriptsDir"
    }

    Write-Host "Base de donnees: $dbPath"
    Write-Host "Dossier scripts: $scriptsDir"

    $sqlScripts = @(Get-ChildItem -Path $scriptsDir -Filter "*.sql" -File | Sort-Object Name)
    if ($sqlScripts.Count -eq 0) {
        throw "Aucun script .sql trouve dans: $scriptsDir"
    }

    foreach ($sqlScript in $sqlScripts) {
        Write-Host "Application de: $($sqlScript.Name)"
        Get-Content -Path $sqlScript.FullName -Raw | & sqlite3 "$dbPath"

        if ($LASTEXITCODE -ne 0) {
            throw "Le script $($sqlScript.Name) a echoue avec le code $LASTEXITCODE"
        }
    }

    Write-Host "Tous les scripts ont ete appliques."
    Wait-ForUser "Execution terminee. Appuie sur Entree pour fermer."
}
catch {
    Write-Error $_
    Wait-ForUser "Une erreur est survenue. Appuie sur Entree pour fermer."
    throw
}
