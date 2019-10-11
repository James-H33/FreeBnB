#!/bin/bash

pathToProject="$(pwd)/Client"


if [ $1 == "serve" ]
then
  dotnet_command="dotnet watch -p $pathToProject run"
else
  dotnet_command="dotnet watch -p $pathToProject build"
fi


full_command='tell app "Terminal"
  do script "'"$dotnet_command"'"
end tell'


osascript -e 'tell app "Terminal"
  do script "cd '"$pathToProject"'; npm start"
end tell'


osascript -e "$full_command"
