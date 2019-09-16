#!/bin/bash

pathToProject="$(pwd)/Client"

dotnet_command="dotnet watch -p $pathToProject build"

full_command='tell app "Terminal" 
  do script "'"$dotnet_command"'"
end tell'

osascript -e "$full_command"