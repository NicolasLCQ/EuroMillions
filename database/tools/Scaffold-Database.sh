#!/usr/bin/env bash
set -euo pipefail

no_pause=false

for arg in "$@"; do
    case "$arg" in
        --no-pause)
            no_pause=true
            ;;
        -h|--help)
            echo "Usage: $(basename "$0") [--no-pause]"
            exit 0
            ;;
        *)
            echo "Unknown argument: $arg" >&2
            echo "Usage: $(basename "$0") [--no-pause]" >&2
            exit 1
            ;;
    esac
done

wait_for_user() {
    local message="$1"

    if [ "$no_pause" = false ]; then
        read -r -p "$message" _
    fi
}

script_dir="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
repo_root="$(cd "$script_dir/../.." && pwd)"
server_dir="$repo_root/server"

db_path="$repo_root/database/EuroMillions.db"
infra_project="$repo_root/server/EuroMillions.Infrastructure/EuroMillions.Infrastructure.csproj"
startup_project="$repo_root/server/EuroMillions.API/EuroMillions.API.csproj"

# Finder/Rider can launch scripts with a reduced PATH compared to an interactive shell.
export PATH="$PATH:/usr/local/share/dotnet:$HOME/.dotnet/tools:/opt/homebrew/bin:/usr/local/bin"

if ! command -v dotnet >/dev/null 2>&1; then
    echo "dotnet est introuvable dans le PATH." >&2
    echo "Verifie l'installation du SDK .NET avec: dotnet --info" >&2
    wait_for_user "Une erreur est survenue. Appuie sur Entree pour fermer."
    exit 1
fi

ef_command=(dotnet tool run dotnet-ef)

if ! "${ef_command[@]}" --version >/dev/null 2>&1; then
    echo "Restauration de l'outil local dotnet-ef..."
    (
        cd "$server_dir"
        dotnet tool restore
    )
fi

echo "Scaffolding from: $db_path"

(
    cd "$server_dir"

    if ! "${ef_command[@]}" --version >/dev/null 2>&1; then
        echo "dotnet-ef est introuvable ou son execution echoue." >&2
        echo "Essaie depuis le dossier server: dotnet tool restore" >&2
        echo "Puis: dotnet tool run dotnet-ef --version" >&2
        exit 1
    fi

    "${ef_command[@]}" dbcontext scaffold "Data Source=$db_path" "Microsoft.EntityFrameworkCore.Sqlite" \
        --project "$infra_project" \
        --startup-project "$startup_project" \
        --context "EuroMillionsDbContext" \
        --context-dir "Context" \
        --output-dir "Entities" \
        --context-namespace "EuroMillions.Infrastructure.Context" \
        --namespace "EuroMillions.Infrastructure.Entities" \
        --no-onconfiguring \
        --use-database-names \
        --force
)

echo "Scaffold termine."
wait_for_user "Execution terminee. Appuie sur Entree pour fermer."
