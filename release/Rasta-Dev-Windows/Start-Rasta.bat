@echo off
rem ─────────────────────────────────────────────────────────────
rem  Rasta CRM — Dev Release launcher (Windows 10/11)
rem  This wrapper runs the real PowerShell launcher so users do
rem  not need to change the execution policy manually.
rem ─────────────────────────────────────────────────────────────
title Rasta CRM (Dev Release)
powershell.exe -NoProfile -ExecutionPolicy Bypass -File "%~dp0Start-Rasta.ps1" %*
echo.
echo  (This window can be closed. Rasta keeps running in the)
echo  (background. To stop it, run Stop-Rasta.ps1.)
pause
