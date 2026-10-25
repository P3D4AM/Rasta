using System;
using System.Diagnostics;
using System.IO;

namespace CRMIdeal.Classes.Security;

public static class WindowsDefenderScanner
{
	public static bool IsAvailable()
	{
		try
		{
			string path = "C:\\Program Files\\Microsoft Defender\\MpCmdRun.exe";
			return File.Exists("C:\\Program Files\\Windows Defender\\MpCmdRun.exe") || File.Exists(path);
		}
		catch
		{
			return false;
		}
	}

	private static string GetExecutable()
	{
		string text = "C:\\Program Files\\Windows Defender\\MpCmdRun.exe";
		if (File.Exists(text))
		{
			return text;
		}
		string text2 = "C:\\Program Files\\Microsoft Defender\\MpCmdRun.exe";
		if (File.Exists(text2))
		{
			return text2;
		}
		return null;
	}

	public static bool Scan(string filePath, out string result)
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		result = "";
		try
		{
			string executable = GetExecutable();
			if (string.IsNullOrWhiteSpace(executable))
			{
				result = "Windows Defender Not Found";
				return true;
			}
			Process val = new Process();
			val.StartInfo.FileName = executable;
			val.StartInfo.Arguments = "-Scan -ScanType 3 -File \"" + filePath + "\"";
			val.StartInfo.UseShellExecute = false;
			val.StartInfo.RedirectStandardOutput = true;
			val.StartInfo.RedirectStandardError = true;
			val.StartInfo.CreateNoWindow = true;
			val.Start();
			string text = val.StandardOutput.ReadToEnd();
			string text2 = val.StandardError.ReadToEnd();
			val.WaitForExit();
			result = text + Environment.NewLine + text2;
			if (val.ExitCode == 0)
			{
				return true;
			}
			if (result.IndexOf("threat", StringComparison.OrdinalIgnoreCase) >= 0 || result.IndexOf("virus", StringComparison.OrdinalIgnoreCase) >= 0 || result.IndexOf("malware", StringComparison.OrdinalIgnoreCase) >= 0)
			{
				return false;
			}
			if (result.IndexOf("0x800106ba", StringComparison.OrdinalIgnoreCase) >= 0)
			{
				return true;
			}
			return val.ExitCode switch
			{
				0 => true, 
				2 => false, 
				_ => true, 
			};
		}
		catch (Exception ex)
		{
			result = ex.Message;
			return true;
		}
	}
}
