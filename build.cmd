set PATH=C:\Program Files (x86)\MSBuild\14.0\Bin;%PATH%
dnvm install 1.0.0-beta6
dnu restore C:\projects\csharp-library\src\BaelorNet
dnu build C:\projects\csharp-library\src\BaelorNet
