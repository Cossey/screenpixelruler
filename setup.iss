
#define MyAppName "Screen Pixel Ruler"
#define MyAppVersion "1.0.0.0"
#define MyAppPublisher "Stewart Cossey"
#define MyAppURL "https://www.github.com/Cossey/screenpixelruler"
#define MyAppExeName "ScreenPixelRuler.exe"

[Setup]
AppId={{58E7DF2D-8A3E-4241-A546-C49B90D647FB}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={pf}\{#MyAppName}
DisableDirPage=yes
DisableProgramGroupPage=yes
LicenseFile=LICENSE
OutputBaseFilename=ScreenPixelRulerSetup
SetupIconFile=ScreenPixelRuler\app.ico
Compression=lzma
SolidCompression=yes
DisableReadyPage=yes
OutputDir=..\

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "ScreenPixelRuler\bin\Release\ScreenPixelRuler.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "LICENSE"; DestDir: "{app}"; Flags: ignoreversion
Source: "README.md"; DestDir: "{app}"; Flags: ignoreversion
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{commonprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{commondesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

