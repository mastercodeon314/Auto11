# Auto11
## What is this?
This is a tool designed to make doing an in-place upgrade on windows easy once again.

## Support
Big thanks to [k0mraid3](https://github.com/k0mraid3) for extensive research and testing with me on this project!
You can join our discord server for Stobaugh Group.
We have channels for chat, support, and releases of auto11.
https://discord.gg/v8PqMRHcHh

## Features
- Bypasses all system requirements for the Windows 11 installer when doing an in-place upgrade
- Enablement of flight signing mode via bcdedit
- Ability to mount a windows installer iso via simple GUI
- Automatic reboot of windows when enabling flight signing
- Automatic restart off app when rebooting from enabling flight signing
- Automatic fix for "couldn’t update system reserved partition" error
- Fixes the big delay when auto starting an app from the Run registry key.

## Usage
- You may need to install the .NET 8.0 Runtime for desktop, if so download the installer [here](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-desktop-8.0.3-windows-x64-installer) and follow instructions for installation.

- Enable flight signing mode and reboot
  ![image](https://github.com/mastercodeon314/Auto11/assets/78676320/7951807d-f128-41fa-bb1b-335baddef859)
  
- Once flight signing is enabled, simply select your iso for the windows installer and mount the iso.
  ![image](https://github.com/mastercodeon314/Auto11/assets/78676320/3e1c6f98-a4ea-4bf9-a825-42dfe43c040e)

- Now that your iso is mounted, just click the Start Upgrade button then the installer will be launched, as well as all requirements being bypassed!
  ![image](https://github.com/mastercodeon314/Auto11/assets/78676320/c1d3523d-a774-42c5-92d1-0e8056504669)

## Notes
- Usage depends on what build of windows you are upgrading from.
- This is because flight signing mode must be turned on when upgrading to a windows insider build.
- If you are already on an insider build, you will skip the Enabling flight signing mode step. 
- Enabling flight signing mode will require a reboot, and the program will not allow you to continue. 
- Also note that currently, there is no detection of the version of windows you are upgrading to from this app. 
  That means that for now, there is no support for upgrading from an older release build (flight signing will be off in this case), to a newer release build.

## Roadmap
- Creation of a tab that can patch a windows installer iso for TPM requirements.
- Support for non Insider releases of Windows, not requiring Flight Signing enablement.
- Optimization of app startup

## Donation links
Anything is super helpful! Anything donated helps me keep developing this program and others!
- https://www.paypal.com/paypalme/lifeline42

## References
- https://superuser.com/questions/1799420/how-to-fix-startupdelayinmsec-trick-does-not-work-anymore/1835433#1835433
- https://github.com/AveYo/MediaCreationTool.bat
- https://forum.bigfix.com/t/fixing-a-system-reserve-partition/39684
- https://winaero.com/microsoft-has-patched-the-product-server-for-tpm-check-bypass/
- https://learn.microsoft.com/en-us/windows-hardware/manufacture/desktop/bcdedit-command-line-options?view=windows-11
- https://www.elevenforum.com/t/no-insider-options.1108/post-27032

## Compile Yourself
- Requires Visual Studio 2022
- Requires [.NET Desktop Runtime 8.0.3](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-desktop-8.0.3-windows-x64-installer)