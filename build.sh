#!/bin/bash

# Install .NET Core on Ubuntu 14.04
wget -q https://packages.microsoft.com/config/ubuntu/14.04/packages-microsoft-prod.deb
dpkg -i packages-microsoft-prod.deb

apt-get install apt-transport-https
apt-get update
apt-get install dotnet-sdk-2.1

dotnet build ./Source/Sagitta.Docs/Sagitta.Docs.csproj
