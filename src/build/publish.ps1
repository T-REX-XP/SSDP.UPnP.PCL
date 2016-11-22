.\build.ps1

$version = [Reflection.AssemblyName]::GetAssemblyName((resolve-path '..\interfaces\bin\release\ISSDP.UPnP.PCL.dll')).Version.ToString(3)

Nuget.exe push ".\NuGet\SSDP.UPnP.PCL.$version.symbols.nupkg" -Source https://www.nuget.org