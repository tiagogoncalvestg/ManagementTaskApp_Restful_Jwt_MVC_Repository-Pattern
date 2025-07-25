#!/bin/bash

# Inicia o projeto API
cd ToDoApp.Api/ 
dotnet run
echo "API iniciada."

# Inicia o projeto Web (exemplo)
cd ToDoApp.Frontend/ 
dotnet run
echo "Frontend iniciado."

# Aguarda todos os processos terminarem
wait