REM Merge assemblies
ILMerge /out:"Chirpy.dll" "TempChirpy.dll" "EcmaScript.NET.modified.dll" "Yahoo.YUI.Compressor.dll" "dotless.Core.dll" "AjaxMin.dll" "Jurassic.dll" /targetplatform:v4,C:\Windows\Microsoft.NET\Framework\v4.0.30319
REM Create VSI file
del Chirpy.vsi
del Chirpy.zip
7za.exe u Chirpy.zip Chirpy.dll Chirpy.vscontent Zippy.AddIn "compiler.jar" "SassAndCoffee.Core.dll" "Microsoft.Dynamic.dll" "Microsoft.Scripting.dll" "Microsoft.Scripting.Metadata.dll" "IronRuby.dll" "IronRuby.Libraries.dll" "IronRuby.Libraries.Yaml.dll"
rename Chirpy.zip Chirpy.vsi
REM copy file to setup project
copy "Zippy.AddIn" "../Zippy.Setup.VS10/Zippy.AddIn"
copy "Chirpy.dll" "../Zippy.Setup.VS10/Chirpy.dll"
copy "compiler.jar" "../Zippy.Setup.VS10/compiler.jar"
REM copy SassAndCoffee.Core.dll ../Zippy.Setup.VS10/SassAndCoffee.Core.dll
REM copy Microsoft.Dynamic.dll ../Zippy.Setup.VS10/Microsoft.Dynamic.dll
REM copy Microsoft.Scripting.dll ../Zippy.Setup.VS10/Microsoft.Scripting.dll
REM copy Microsoft.Scripting.Metadata.dll ../Zippy.Setup.VS10/Microsoft.Scripting.Metadata.dll
REM copy IronRuby.dll ../Zippy.Setup.VS10/IronRuby.dll
REM copy IronRuby.Libraries.dll ../Zippy.Setup.VS10/IronRuby.Libraries.dll
REM copy IronRuby.Libraries.Yaml.dll ../Zippy.Setup.VS10/IronRuby.Libraries.Yaml.dll
REM Done