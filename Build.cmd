@echo off
"%WINDIR%\Microsoft.NET\Framework\v3.5\msbuild.exe" /p:"Configuration=Release" "%CD%\PangyaUccViewer.sln"
pause