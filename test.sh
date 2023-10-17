#!/bin/bash

MAX_JOBS=4

RED='\033[0;31m'
GREEN='\033[0;32m'
NC='\033[0m' # No Color

file_path="./locales.txt"

# Check if the file exists
if [[ ! -f $file_path ]]; then
  echo "File $file_path not found."
  exit 1
fi

echo "Building and restoring before running"
dotnet restore
dotnet build -c Release

echo "Running tests"

run_test() {
  lang="$1"

  # Skip empty lines
  if [[ -z "$lang" ]]; then
    return
  fi

  # Run the dotnet test with TESTLANG environment variable set
  TESTLANG=$lang dotnet test --configuration Release --no-build --no-restore --logger:"console;verbosity=minimal" > /dev/null 2>&1

  # Check the exit status of the dotnet test command
  if [[ $? -eq 1 ]]; then
    printf "%-14s: ${RED}Failed${NC}\n" "$lang"
  fi
}
export -f run_test

cat "$file_path" | parallel run_test
