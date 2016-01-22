Name "BlueRoseLauncher"

Outfile "BlueRoseLauncher Debug.exe"

RequestExecutionLevel admin

Page directory
Page instfiles

InstallDir "$PROFILE\FreeSO"

Section "Main"

	SetOutPath '$INSTDIR'

	File "BlueRoseWinForms\bin\Debug\BlueRoseLauncher.exe"
	File "BlueRoseWinForms\bin\Debug\BlueRoseLauncher.exe.config"
	File "BlueRoseWinForms\bin\Debug\BlueRoseLauncher.pdb"
	
	 # create the uninstaller
    WriteUninstaller "$INSTDIR\Uninstall BlueRoseLauncher.exe"
	
	# create start menu shortcut
	CreateDirectory "$SMPROGRAMS\FreeSO\"
    CreateShortCut "$SMPROGRAMS\FreeSO\FreeSO.lnk" "$INSTDIR\BlueRoseLauncher.exe"
	CreateShortCut "$SMPROGRAMS\FreeSO\Uninstall BlueRoseLauncher.lnk" "$INSTDIR\Uninstall BlueRoseLauncher.exe"

	# create desktop shortcut
  	CreateShortCut "$DESKTOP\FreeSO.lnk" "$INSTDIR\BlueRoseLauncher.exe"
	
SectionEnd


Section "Uninstall"
 
    # first, delete installed files
    Delete "$INSTDIR\Uninstall BlueRoseLauncher.exe"
	Delete "$INSTDIR\BlueRoseLauncher.exe"
	Delete "$INSTDIR\BlueRoseLauncher.exe.config"
	Delete "$INSTDIR\BlueRoseLauncher.pdb"
 
    # second, the shortcuts
    Delete "$DESKTOP\FreeSO.lnk"
	Delete "$SMPROGRAMS\FreeSO\FreeSO.lnk"
	Delete "$SMPROGRAMS\FreeSO\Uninstall BlueRoseLauncher.lnk"
	Delete "$SMPROGRAMS\FreeSO\"
 
SectionEnd