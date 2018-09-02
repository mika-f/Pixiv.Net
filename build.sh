#!/bin/bash

# Install .NET Core on Ubuntu 14.04
wget -q https://packages.microsoft.com/config/ubuntu/14.04/packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb

sudo apt-get install apt-transport-https
sudo apt-get update
sudo apt-get install dotnet-sdk-2.1

dotnet build ./Source/Sagitta.Docs/Sagitta.Docs.csproj
