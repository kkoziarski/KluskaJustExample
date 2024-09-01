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
