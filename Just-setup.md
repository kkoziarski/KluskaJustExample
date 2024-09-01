# Kluska CLI setup
Based on https://blog.chay.dev/create-an-internal-cli/

## Prerequisites

`just`: Install just [here](https://github.com/casey/just/blob/master/README.md#installation)

## Installation

Clone this repo:
...

Set up the `kluska` alias in pwsh (powershell core):

```powershell
notepad $profile
function Just-Kluska { just --justfile 'd:\_git\KluskaJustExample\kluska.justfile' $args }
Set-Alias -Name kluska -Value Just-Kluska
```

## Usage

List all available recipes:
...