Name "Blue Rose 2.1 Slim"

Outfile "BlueRoseOnline.exe"

RequestExecutionLevel admin

Page directory
Page instfiles

InstallDir "$PROFILE\FreeSO"

Section "Main"

	SetOutPath '$INSTDIR'

	File "BlueRoseUpdate\bin\Release\SimplyUpdate.exe"
	File "BlueRoseUpdate\bin\Release\SimplyUpdate.exe.config"
	File "BlueRoseUpdate\bin\Release\SimplyUpdate.pdb"
	File "BlueRoseUpdate\bin\Release\ZACKUpdater.dll"
	File "BlueRoseUpdate\bin\Release\ZACKUpdater.pdb"
	
	 # create the uninstaller
    WriteUninstaller "$INSTDIR\Uninstall Blue Rose.exe"
	
	# create start menu shortcut
	CreateDirectory "$SMPROGRAMS\FreeSO\"
    CreateShortCut "$SMPROGRAMS\FreeSO\FreeSO.lnk" "$INSTDIR\BlueRoseLauncher.exe"
	CreateShortCut "$SMPROGRAMS\FreeSO\Uninstall Blue Rose.lnk" "$INSTDIR\Uninstall Blue Rose.exe"

	# create desktop shortcut
  	CreateShortCut "$DESKTOP\FreeSO.lnk" "$INSTDIR\BlueRoseLauncher.exe"
	
SectionEnd


Section "Uninstall"
 
    # first, delete installed files
	Delete "$INSTDIR\BlueRoseLauncher.exe"
	Delete "$INSTDIR\BlueRoseLauncher.exe.config"
	Delete "$INSTDIR\BlueRoseLauncher.pdb"
	Delete "$INSTDIR\Ionic.Zip.dll"
	Delete "$INSTDIR\Ionic.Zip.xml"
	Delete "$INSTDIR\SimplyUpdate.exe"
	Delete "$INSTDIR\SimplyUpdate.exe.config"
	Delete "$INSTDIR\SimplyUpdate.pdb"
	Delete "$INSTDIR\ZACKUpdater.dll"
	Delete "$INSTDIR\ZACKUpdater.xml"
	Delete "$INSTDIR\Uninstall BlueRoseLauncher.exe"
 
    # second, the shortcuts
    Delete "$DESKTOP\FreeSO.lnk"
	Delete "$SMPROGRAMS\FreeSO\FreeSO.lnk"
	Delete "$SMPROGRAMS\FreeSO\Uninstall Blue Rose.lnk"
	Delete "$SMPROGRAMS\FreeSO\"
 
SectionEnd