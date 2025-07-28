#!/bin/bash

# Inicia o projeto API
cd ToDoApp.Api/ 
dotnet run &&

# Inicia o projeto Web (exemplo)
cd ToDoApp.Frontend/ 
dotnet run
