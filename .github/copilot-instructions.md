# Copilot Instructions for AppTracker

<!-- Use this file to provide workspace-specific custom instructions to Copilot. For more details, visit https://code.visualstudio.com/docs/copilot/copilot-customization#_use-a-githubcopilotinstructionsmd-file -->

## Project Overview
This is a Windows C# application that tracks application usage by running in the system tray and monitoring active windows.

## Key Features
- System tray application that runs minimized by default
- Polls currently active application and logs window titles with timestamps
- Configurable polling rate (default: 30 seconds)
- Daily usage summaries showing time spent in each application
- Windows Forms UI for configuration and viewing summaries

## Technical Requirements
- Use Windows API calls to get active window information
- Implement system tray functionality with NotifyIcon
- Use SQLite or file-based storage for usage data
- Follow Windows application best practices
- Handle application startup/shutdown gracefully
