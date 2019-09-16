#!/bin/bash

pathToProject="$(pwd)/Server"

dotnet_command="dotnet run -p $pathToProject"

full_command='tell app "Terminal"
  do script "'"$dotnet_command"'"
end tell'

osascript -e "$full_command"
