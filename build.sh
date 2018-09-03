#!/bin/bash

# Install .NET Core on Ubuntu 14.04
# cd ..
wget https://download.microsoft.com/download/E/8/A/E8AF2EE0-5DDA-4420-A395-D1A50EEFD83E/dotnet-sdk-2.1.401-linux-x64.tar.gz
mkdir dotnet
tar -zxf dotnet-sdk-2.1.401-linux-x64.tar.gz -C dotnet

./dotnet/dotnet build ./Source/Sagitta.Docs/Sagitta.Docs.csproj
