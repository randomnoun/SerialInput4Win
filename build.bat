rem an attempt to get environment vars set up before building packetmap

rem call "C:\Program Files\Microsoft Visual Studio 8\VC\vcvarsall.bat" x86

call "c:\program files\microsoft visual studio 10.0\common7\tools\vsvars32"

echo VS80COMNTOOLS is %VS80COMNTOOLS%
echo PATH is %PATH%

rem msbuild SerialInput4Win.sln
C:\Windows\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe SerialInput4Win.sln

