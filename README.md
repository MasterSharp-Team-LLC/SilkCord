# Silk Client

Silk Client is a Windows desktop utility built with .NET and Windows Forms that lets you configure and publish a custom Discord Rich Presence for a running Discord client. The project provides a small graphical interface for entering the application ID, status text, and artwork metadata, then sends the updated presence to Discord in real time.

The application is intentionally lightweight and focused: it offers a custom modern UI, theme customization, and configuration save/load support in a single executable.

## Overview

At a high level, the project has three responsibilities:

- Detect whether Discord is running and wait for it before the client starts
- Present a form where the user can define Discord Rich Presence information
- Push the configured presence to Discord using the Discord RPC library

This makes it useful for users who want a clean, compact custom presence editor without needing to use a larger Discord client or external web tool.

## Features

- Discord session detection before launch
- Rich Presence configuration:
  - Application ID
  - Details
  - State
  - Activity type: Playing, Watching, or Listening
  - Large image and text
  - Small image and text
- Custom round-trip window styling with a draggable title bar
- Modern/Classic theme toggle
- Accent color selection
- Save and load configuration files in `.cfg` format
- Top-most desktop window behavior for quick access while gaming or working

## Technology Stack

- C#
- .NET 10 Windows desktop framework
- Windows Forms (WinForms)
- DiscordRichPresence library (`DiscordRPC`)

## Project Structure

- `Program.cs`  
  Entry point. Waits until a Discord process is detected before launching the app.

- `Silk.cs`  
  Main form logic. Handles the Discord RPC client, UI theming, blur effects, draggable title bar, and form actions.

- `SettingsWindow.cs`  
  Secondary window for user preferences such as accent color and classic vs modern theme.

- `Silk.Designer.cs`  
  WinForms-generated UI definition for the main application window.

- `SettingsWindow.Designer.cs`  
  WinForms-generated UI definition for the settings window.

- `Silk Client.csproj`  
  .NET project configuration and dependency declaration.

- `Silk.resx` / `SettingsWindow.resx`  
  Embedded resources for the WinForms forms.

## How It Works

### 1. Startup check
When the application starts, `Program.Main()` searches for a process named `Discord`.

If Discord is not running, the program keeps polling every few seconds and prints a message until the user opens Discord.

Once a Discord process is found, the app clears the console and launches the main Windows form.

### 2. Main UI
The main form, `Silk`, exposes controls for:

- Application ID
- Details text
- State text
- Activity category
- Large and small image keys/text

When the user clicks the action button, the app creates or updates a `DiscordRpcClient` instance and sends a `RichPresence` payload.

### 3. Presence update
The `ApplyDiscordRPC_Click` handler does the following:

- Validates the Application ID
- Reuses the existing client if the application ID matches
- Chooses the correct activity type (`Playing`, `Watching`, `Listening`)
- Sets the Rich Presence details and assets
- Updates the button text to `Update` after the first successful launch

### 4. Theme and appearance
The application implements a custom Windows composition effect to create a glass/blurred-look form. It also supports:

- a modern translucent theme
- a classic solid theme
- a selectable accent color

The secondary `SettingsWindow` allows the user to change these preferences and save them.

### 5. Save and load configuration
The app supports loading and saving a configuration file using a simple `key=value` format. For example:

```ini
Application=123456789012345678
Activity=Playing
Details=Listening to music
State=on Silk Client
Large=logo
LargeText=Silk Client
Small=mic
SmallText=Discord
Color=-16777063
Theme=Modern
```

This file is saved from the settings window and can be reused to restore the same Discord presence setup.

## Requirements

- Windows 10 or later
- A running Discord client
- .NET 10 SDK for Windows
- A valid Discord Application ID from the Discord Developer Portal

## Build and Run

### From Visual Studio

1. Open the solution file `Silk Client.slnx` in Visual Studio.
2. Restore NuGet packages.
3. Build the solution.
4. Run the project.

### From the command line

```bash
dotnet restore

dotnet build "Silk Client.csproj"

dotnet run --project "Silk Client.csproj"
```

## Important Notes

- The app expects Discord to be running before it starts; otherwise it waits and keeps checking.
- The Application ID must be a valid Discord application ID; otherwise the presence cannot be published correctly.
- The project uses Windows-specific APIs and cannot be run natively on Linux or macOS.
- The form is designed for Windows desktop usage and uses WinForms with composition effects that are specific to Microsoft Windows.

## Typical Use Case

This project is ideal for:

- personal Discord status customization
- developer or streaming presence presets
- quick testing of Discord Rich Presence metadata
- creating a lightweight local utility to manage presence fields without a browser-based configuration tool

## License

This project does not currently include a dedicated license file, so the repository should be checked for any explicit licensing terms before redistribution or commercial use.

## Summary

Silk Client is a focused Windows desktop Rich Presence editor for Discord. With a small but functional interface, it gives users direct control over the information displayed on their Discord profile while remaining easy to customize and reuse with saved config files.
