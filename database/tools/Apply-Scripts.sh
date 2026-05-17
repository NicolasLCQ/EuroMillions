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

db_path="$repo_root/database/EuroMillions.db"
scripts_dir="$repo_root/database/Scripts"

if ! command -v sqlite3 >/dev/null 2>&1; then
    echo "sqlite3 manquant. Installe-le ou ajoute-le au PATH." >&2
    wait_for_user "Une erreur est survenue. Appuie sur Entree pour fermer."
    exit 1
fi

if [ ! -d "$scripts_dir" ]; then
    echo "Dossier introuvable: $scripts_dir" >&2
    wait_for_user "Une erreur est survenue. Appuie sur Entree pour fermer."
    exit 1
fi

echo "Base de donnees: $db_path"
echo "Dossier scripts: $scripts_dir"

found_script=false

while IFS= read -r sql_script; do
    found_script=true
    echo "Application de: $(basename "$sql_script")"
    sqlite3 "$db_path" < "$sql_script"
done < <(find "$scripts_dir" -maxdepth 1 -type f -name '*.sql' | sort)

if [ "$found_script" = false ]; then
    echo "Aucun script .sql trouve dans: $scripts_dir" >&2
    wait_for_user "Une erreur est survenue. Appuie sur Entree pour fermer."
    exit 1
fi

echo "Tous les scripts ont ete appliques."
wait_for_user "Execution terminee. Appuie sur Entree pour fermer."
