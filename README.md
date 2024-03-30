# Auto11

## What's new v1.1
+ Added a selector box to select a USB drive instead of mounting an iso
+ Added a setting to enable the USB selector box.
+ Fixed spelling mistake in Iso mount box
+ Repo Code cleanup

![image](https://github.com/mastercodeon314/Auto11/assets/78676320/bb67e3c0-ed8f-45d0-9f9a-1b80971ff0a0)

## So what is this thing?
Auto11 is a tool specifically designed to make doing an in-place upgrade on a Windows OS easy and to upgrade from a release build to an insider build reliably and without (Expected) any of the standard requirements, such as TPM.

## So how does it work?!

![image](https://github.com/mastercodeon314/Auto11/assets/78676320/858f7076-39ae-429b-97e9-1b7cfb729d2d)

It allows you to enable flight signing with a proper GUI, and then easily mount and dismount a Windows Installer iso.
Once the iso is mounted, a button has been implemented to execute the installer with the right command line arguments to bypass system requirements. 

## Support
Big thanks to my colleague, [k0mraid3](https://github.com/k0mraid3) for extensive research and testing with me on this project!

Also, Credit to [dongle-the-gadget](https://github.com/dongle-the-gadget) for their [WinverUWP](https://github.com/dongle-the-gadget/WinverUWP) source code that allowed me to get the real version info for the "About" page!

You can join our discord server for Stobaugh Group.
We have channels for chat, support, and releases of Auto11.
```https://discord.gg/v8PqMRHcHh```

## Features
- Bypasses all system requirements for the Windows 11 installer when doing an in-place upgrade
- Enablement of flight signing mode via ```bcdedit```
- Ability to mount a Windows installer iso via simple GUI
- Automatic reboot of Windows when enabling flight signing
- Automatic restart of the app when rebooting from enabling flight signing
- Automatic fix for "couldn’t update system reserved partition" error
- Fixes the big delay when auto-starting an app from the Run registry key.

## Usage
- You may need to install the .NET 8.0 Runtime for desktop, if so, download the installer [here](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-desktop-8.0.3-windows-x64-installer) and follow instructions for installation.

- Enable flight signing mode and reboot
  ![Enable Flight Signing](https://github.com/mastercodeon314/Auto11/assets/78676320/ba964fda-8148-4250-9a4f-eec3db539621)
  
- Once flight signing is enabled, simply select your iso for the Windows installer and mount the iso.
  ![Mount Iso](https://github.com/mastercodeon314/Auto11/assets/78676320/081a4a14-b877-481c-bed7-8d5386ff19a8)

- Now that your iso is mounted, click the "Start Upgrade" button then the installer will be launched, and will bypass all of the (Rather ridiculous) requirements Microsoft imposes!
  ![Start Upgrade](https://github.com/mastercodeon314/Auto11/assets/78676320/950c7f64-7846-402b-839f-09f2176e7fba)

## Important Notes
- Usage depends on what build of windows you are upgrading from.
- This is the result of a low-level requirement that specifies flight signing mode must be turned on before being allowed to upgrade to a Windows insider build.
- If you are ALREADY on an insider build, you should skip the step for Enabling flight signing mode. 
- Enabling flight signing mode will require a reboot, and the program will not allow you to continue. 
- A final note. Currently, there is no implementation of a detection mechanism that checks the version of Windows you are trying to upgrade to from this app. 
  This is very important to consider, because until it is implemented, this tool does not yet support upgrading from an older release build (flight signing will be off in this case), to a newer release build.

## Roadmap
- Creation of a tab that can patch a Windows installer iso for TPM requirements.
- Support for non-Insider releases of Windows, not requiring Flight Signing enablement.
- Optimization of app startup

## Donation Links
Anything is super helpful! Your kindness allows me to continue developing this program and many others well into the future.
- https://www.paypal.com/paypalme/lifeline42

## References
- https://superuser.com/questions/1799420/how-to-fix-startupdelayinmsec-trick-does-not-work-anymore/1835433#1835433
- https://github.com/AveYo/MediaCreationTool.bat
- https://github.com/dongle-the-gadget/WinverUWP
- https://forum.bigfix.com/t/fixing-a-system-reserve-partition/39684
- https://winaero.com/microsoft-has-patched-the-product-server-for-tpm-check-bypass/
- https://learn.microsoft.com/en-us/windows-hardware/manufacture/desktop/bcdedit-command-line-options?view=windows-11
- https://www.elevenforum.com/t/no-insider-options.1108/post-27032

## Compile Yourself
- Requires Visual Studio 2022
- Requires [.NET Desktop Runtime 8.0.3](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-desktop-8.0.3-windows-x64-installer)
