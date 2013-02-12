; dmx-web desktop installer
; based on NSIS Modern User Interface example script written by Joost Verburg

;--------------------------------
;Include Modern UI

  !AddIncludeDir "..\..\..\target"

  !include "MUI.nsh"
  !include "internet-shortcut.nsh"
  !include LogicLib.nsh
  !include "project.nsh"

  !addplugindir "..\..\..\target"

;--------------------------------
;General

  ;Name and file
  Name "SerialInput4Win"
  ;OutFile set by maven
  ;OutFile "..\..\build\exe\SerialInput4Win-v0.1.exe"

  ;Default installation folder
  InstallDir "$PROGRAMFILES\SerialInput4Win"

  ;Get installation folder from registry if available
  InstallDirRegKey HKCU "Software\Randomnoun\SerialInput4Win" "InstallDir"


;--------------------------------
;Variables

  Var MUI_TEMP
  Var STARTMENU_FOLDER

;--------------------------------
;Interface Settings

  !define MUI_ABORTWARNING
  !define VERSION "0.1"


;--------------------------------
;Pages

  !insertmacro MUI_PAGE_WELCOME
  ; !insertmacro MUI_PAGE_LICENSE "${NSISDIR}\Docs\Modern UI\License.txt"
  !insertmacro MUI_PAGE_LICENSE "License.txt"
  !insertmacro MUI_PAGE_COMPONENTS
  !insertmacro MUI_PAGE_DIRECTORY

  ;Start Menu Folder Page Configuration
  !define MUI_STARTMENUPAGE_REGISTRY_ROOT "HKCU" 
  !define MUI_STARTMENUPAGE_REGISTRY_KEY "Software\Randomnoun\SerialInput4Win" 
  !define MUI_STARTMENUPAGE_REGISTRY_VALUENAME "Start Menu Folder"
  !define MUI_STARTMENUPAGE_DEFAULTFOLDER "SerialInput4Win"
  !insertmacro MUI_PAGE_STARTMENU Application $STARTMENU_FOLDER

  !insertmacro MUI_PAGE_INSTFILES
  !insertmacro MUI_PAGE_FINISH

  !insertmacro MUI_UNPAGE_WELCOME
  !insertmacro MUI_UNPAGE_CONFIRM
  !insertmacro MUI_UNPAGE_INSTFILES
  !insertmacro MUI_UNPAGE_FINISH

;--------------------------------
;Languages

  !insertmacro MUI_LANGUAGE "English"


;--------------------------------
;Functions
Function .onInit
  ;Extract InstallOptions INI files
  ; !insertmacro MUI_INSTALLOPTIONS_EXTRACT "AdditionalTasksPage.ini"  
FunctionEnd





;--------------------------------
;Installer Sections

Section "!SerialInput4Win" SecMain
  
  ; mandatory section
  SectionIn RO

  SetOutPath "$INSTDIR"
  File ..\..\..\SerialInput4Win\bin\debug\SerialInput4Win.exe
  
  ; !insertmacro CheckDotNET

  ;Store installation folder
  WriteRegStr HKCU "Software\Randomnoun\SerialInput4Win" "InstallDir" $INSTDIR

  ;Create uninstaller
  ; Write the uninstall keys for Windows
  WriteRegStr HKEY_LOCAL_MACHINE "Software\Microsoft\Windows\CurrentVersion\Uninstall\SerialInput4Win" "DisplayVersion" "${VERSION}"
  WriteRegStr HKEY_LOCAL_MACHINE "Software\Microsoft\Windows\CurrentVersion\Uninstall\SerialInput4Win" "DisplayName" "SerialInput4Win ${VERSION}"
  WriteRegStr HKEY_LOCAL_MACHINE "Software\Microsoft\Windows\CurrentVersion\Uninstall\SerialInput4Win" "UninstallString" '"$INSTDIR\uninstall.exe"'
  WriteRegStr HKEY_LOCAL_MACHINE "Software\Microsoft\Windows\CurrentVersion\Uninstall\SerialInput4Win" "Publisher" "Randomnoun, http://www.randomnoun.com"
  WriteRegStr HKEY_LOCAL_MACHINE "Software\Microsoft\Windows\CurrentVersion\Uninstall\SerialInput4Win" "HelpLink" "mailto:knoxg+SerialInput4Win@randomnoun.com"
  WriteRegStr HKEY_LOCAL_MACHINE "Software\Microsoft\Windows\CurrentVersion\Uninstall\SerialInput4Win" "URLInfoAbout" "http://www.randomnoun.com/wp/2013/02/03/serial-input-for-windows/?about=1"
  WriteRegStr HKEY_LOCAL_MACHINE "Software\Microsoft\Windows\CurrentVersion\Uninstall\SerialInput4Win" "URLUpdateInfo" "http://www.randomnoun.com/wp/2013/02/03/serial-input-for-windows/?updateInfo=1"
  WriteRegDWORD HKEY_LOCAL_MACHINE "Software\Microsoft\Windows\CurrentVersion\Uninstall\SerialInput4Win" "NoModify" 1
  WriteRegDWORD HKEY_LOCAL_MACHINE "Software\Microsoft\Windows\CurrentVersion\Uninstall\SerialInput4Win" "NoRepair" 1
  WriteUninstaller "uninstall.exe"

  WriteUninstaller "$INSTDIR\Uninstall.exe"

  !insertmacro MUI_STARTMENU_WRITE_BEGIN Application
    
  ;Create shortcuts
  CreateDirectory "$SMPROGRAMS\$STARTMENU_FOLDER"
  CreateShortCut "$SMPROGRAMS\$STARTMENU_FOLDER\Uninstall.lnk" "$INSTDIR\Uninstall.exe"
  CreateShortCut "$SMPROGRAMS\$STARTMENU_FOLDER\SerialInput4Win.lnk" "$INSTDIR\SerialInput4Win.exe"

  !insertmacro CreateInternetShortcut \
    "$SMPROGRAMS\$STARTMENU_FOLDER\randomnoun" \
    "http://www.randomnoun.com/wp/2013/02/03/serial-input-for-windows" \
    "$INSTDIR\setup\nsis1-install.ico" "0"
  
  !insertmacro MUI_STARTMENU_WRITE_END

SectionEnd


;--------------------------------
;Descriptions

  ;Language strings
  LangString DESC_SecMain ${LANG_ENGLISH} "The SerialInput4Win application"

  ;Assign language strings to sections
  !insertmacro MUI_FUNCTION_DESCRIPTION_BEGIN
  !insertmacro MUI_DESCRIPTION_TEXT ${SecMain} $(DESC_SecMain)
  !insertmacro MUI_FUNCTION_DESCRIPTION_END

;--------------------------------
;Uninstaller Section

Section "Uninstall"

  ;ADD YOUR OWN FILES HERE...
  Delete $INSTDIR\SerialInput4Win.exe

  Delete "$INSTDIR\Uninstall.exe"

  RMDir "$INSTDIR"

  !insertmacro MUI_STARTMENU_GETFOLDER Application $MUI_TEMP
    
  Delete "$SMPROGRAMS\$MUI_TEMP\Uninstall.lnk"
  Delete "$SMPROGRAMS\$MUI_TEMP\SerialInput4Win.lnk"
  
  ; remove uninstall registry entry and settings
  DeleteRegKey HKEY_LOCAL_MACHINE "Software\Microsoft\Windows\CurrentVersion\Uninstall\SerialInput4Win"
  DeleteRegKey HKEY_LOCAL_MACHINE "Software\Randomnoun\SerialInput4Win"
  
  ; keep settings
  ; DeleteRegKey HKEY_LOCAL_MACHINE "Software\Randomnoun\Packetmap"
  
  ;Delete empty start menu parent diretories
  StrCpy $MUI_TEMP "$SMPROGRAMS\$MUI_TEMP"
 
startMenuDeleteLoop:
  ClearErrors
  RMDir $MUI_TEMP
  GetFullPathName $MUI_TEMP "$MUI_TEMP\.."
    
  IfErrors startMenuDeleteLoopDone
  
  StrCmp $MUI_TEMP $SMPROGRAMS startMenuDeleteLoopDone startMenuDeleteLoop
  startMenuDeleteLoopDone:

  DeleteRegKey /ifempty HKCU "Software\Randomnoun\SerialInput4Win"

SectionEnd


;!include "GetWindowsVersion.nsh"
!include WinMessages.nsh

;Var NPF_START ;declare variable for holding the value of a registry key



