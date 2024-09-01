# use PowerShell instead of sh:
#set shell := ["pwsh.exe", "-c"]
set windows-shell := ["pwsh", "-NoLogo", "-NoProfileLoadTime", "-Command"]
set ignore-comments

# Notice that running the recipe prints each command before it is executed. Let's suppress this output using a @ prefix. This is quite similar to how Makefiles work. We can add this prefix on each line we want to suppress, or add it to the recipe name to suppress the output for all lines.

[private]
@default:
  just --justfile '.\kluska.justfile' --list --unsorted

@hello:
  Write-Host "Hello, I'm Kluska CLI from {{justfile()}}"

# Show arch and os name
@os-info:
  Write-Host "Arch: {{arch()}}"
  Write-Host "OS: {{os()}}"

# location of the project
@dir:
  pwd

# build solution
@build:
  dotnet build ./KluskaJustExample.sln

@run:
  dotnet run --project .\KluskaJustExample.AppHost\KluskaJustExample.AppHost.csproj

# run helper console app with arguments: `kluska run-helper-tool abc=1 cde`
@helper-tool *args:
  #!pwsh
  cd "utilities/HelperTool"
  dotnet run --project HelperTool.csproj -- {{args}}

# git example scoped to this repo only
git *args:
  @git {{args}}