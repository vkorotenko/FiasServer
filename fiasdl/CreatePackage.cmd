REM https://github.com/qmfrederik/dotnet-packaging/issues/148

REM dotnet tool install --global dotnet-zip
REM dotnet tool install --global dotnet-tarball
REM dotnet tool install --global dotnet-rpm
REM dotnet tool install --global dotnet-deb

REM dotnet zip install
REM dotnet tarball install
REM dotnet rpm install
REM dotnet deb install


dotnet restore # first restore
dotnet zip --no-restore -c Release -r win-x64
dotnet deb --no-restore -c Release -r linux-x64