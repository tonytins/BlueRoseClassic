Name "Blue Rose 2.0 Beta"

Outfile "BlueRoseBeta.exe"

RequestExecutionLevel admin

Page directory
Page instfiles

InstallDir "$PROFILE\FreeSO"

Section "Main"

	SetOutPath '$INSTDIR'

	File "BlueRose\bin\Debug\BlueRoseLauncher.exe"
	File "BlueRose\bin\Debug\BlueRoseLauncher.exe.config"
	File "BlueRose\bin\Debug\BlueRoseLauncher.pdb"
	File "BlueRose\bin\Debug\BlueRose.Distro.dll"
	File "BlueRose\bin\Debug\BlueRose.Distro.pdb"
	File "BlueRose\bin\Debug\Ionic.Zip.dll"
	File "BlueRose\bin\Debug\Ionic.Zip.xml"
	
	 # create the uninstaller
    WriteUninstaller "$INSTDIR\Uninstall BlueRoseLauncher.exe"
	
	# create start menu shortcut
	CreateDirectory "$SMPROGRAMS\FreeSO\"
    CreateShortCut "$SMPROGRAMS\FreeSO\FreeSO.lnk" "$INSTDIR\BlueRoseLauncher.exe"
	CreateShortCut "$SMPROGRAMS\FreeSO\Uninstall Blue Rose.lnk" "$INSTDIR\Uninstall BlueRoseLauncher.exe"

	# create desktop shortcut
  	CreateShortCut "$DESKTOP\FreeSO.lnk" "$INSTDIR\BlueRoseLauncher.exe"
	
SectionEnd


Section "Uninstall"
 
    # first, delete installed files
	Delete "$INSTDIR\BlueRoseLauncher.exe"
	Delete "$INSTDIR\BlueRoseLauncher.exe.config"
	Delete "$INSTDIR\BlueRoseLauncher.pdb"
	Delete "$INSTDIR\BlueRose.Distro.dll"
	Delete "$INSTDIR\BlueRose.Distro.pdb"
	Delete "$INSTDIR\Ionic.Zip.dll"
	Delete "$INSTDIR\Ionic.Zip.xml"
	Delete "$INSTDIR\Uninstall BlueRoseLauncher.exe"
 
    # second, the shortcuts
    Delete "$DESKTOP\FreeSO.lnk"
	Delete "$SMPROGRAMS\FreeSO\FreeSO.lnk"
	Delete "$SMPROGRAMS\FreeSO\Uninstall Blue Rose.lnk"
	Delete "$SMPROGRAMS\FreeSO\"
 
SectionEnd