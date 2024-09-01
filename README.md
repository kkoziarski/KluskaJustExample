# Kluska CLI setup
Based on https://blog.chay.dev/create-an-internal-cli/

This repo is to show how to create and use project related CLI using [just](https://github.com/casey/just/blob/master/README.md)

## Prerequisites

`just`: Install just [here](https://github.com/casey/just/blob/master/README.md#installation)

```
winget install --id Casey.Just --exact
```

## Installation

Clone this repo:
...

Set up the `kluska` alias in `pwsh` (PowerShell Core):

```powershell
notepad $profile
function Just-Kluska { just --justfile 'd:\_git\KluskaJustExample\kluska.justfile' $args }
Set-Alias -Name kluska -Value Just-Kluska
```
Restart shell

## Usage
```powershell
kluska #list all available commands

kluska hello
kluska build
kluska run
kluska run-helper-tool abc=1 cde
```
