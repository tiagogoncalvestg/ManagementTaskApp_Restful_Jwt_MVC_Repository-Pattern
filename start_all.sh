#!/bin/bash

cd ToDoApp.Api/ || exit
dotnet run &

cd ..

cd ToDoApp.Frontend/ || exit
dotnet run &

wait
