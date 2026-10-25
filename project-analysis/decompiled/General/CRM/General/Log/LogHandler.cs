using System;
using System.IO;
using System.Text;
using System.Threading;

namespace CRM.General.Log;

public class LogHandler : IDisposable
{
	private string _LogFileName;

	private short _LogFileLevel;

	private static Mutex oMutex;

	private FileStream _FileStream;

	public LogHandler(string LogFileName, short LogFileLevel)
	{
		try
		{
			string path = LogFileName.Replace(LogFileName.Split(new char[1] { '\\' })[^1], "");
			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}
			_LogFileName = LogFileName;
			_LogFileLevel = LogFileLevel;
			_FileStream = File.Open(_LogFileName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read);
			_FileStream.Position = _FileStream.Length;
			oMutex = new Mutex();
		}
		catch
		{
		}
	}

	public void LogError(string ClassName, string MethodName, string err)
	{
		string empty = string.Empty;
		if (_LogFileLevel >= 1)
		{
			empty = CreateHeaderLog("Error\t\t", ClassName, MethodName, err);
			Log(empty);
		}
	}

	public void LogWarning(string ClassName, string MethodName, string Warning)
	{
		string empty = string.Empty;
		if (_LogFileLevel >= 2)
		{
			empty = CreateHeaderLog("Warning\t\t", ClassName, MethodName, Warning);
			Log(empty);
		}
	}

	public void LogInfo(string ClassName, string MethodName, string Info)
	{
		string empty = string.Empty;
		if (_LogFileLevel >= 3)
		{
			empty = CreateHeaderLog("Information\t", ClassName, MethodName, Info);
			Log(empty);
		}
	}

	public void LogSuccess(string ClassName, string MethodName, string Success)
	{
		string empty = string.Empty;
		if (_LogFileLevel >= 4)
		{
			empty = CreateHeaderLog("Success\t\t", ClassName, MethodName, Success);
			Log(empty);
		}
	}

	public void LogDebug(string ClassName, string MethodName, string DebugStr)
	{
		string empty = string.Empty;
		if (_LogFileLevel >= 5)
		{
			empty = CreateHeaderLog("Debug\t\t", ClassName, MethodName, DebugStr);
			Log(empty);
		}
	}

	private string CreateHeaderLog(string LogType, string ClassName, string MethodName, string msg)
	{
		string text = string.Empty;
		try
		{
			text = text + DateTime.Now.ToString("yyyy/MM/dd | HH:mm:ss.ff") + " | ";
			text = text + Thread.CurrentThread.ManagedThreadId + " | ";
			text = text + LogType + " | ";
			text = text + ClassName + "\t\t\t| ";
			text = text + MethodName + "\t\t\t| ";
			text += msg;
		}
		catch
		{
		}
		return text;
	}

	private void Log(string str)
	{
		try
		{
			oMutex.WaitOne();
			byte[] bytes = Encoding.ASCII.GetBytes(str);
			_FileStream.Write(bytes, 0, str.Length);
			_FileStream.WriteByte(13);
			_FileStream.WriteByte(10);
			_FileStream.Flush();
			bytes = null;
			oMutex.ReleaseMutex();
		}
		catch
		{
		}
	}

	public void Dispose()
	{
		if (_FileStream != null)
		{
			_FileStream.Flush();
			_FileStream.Close();
			_FileStream.Dispose();
			_FileStream = null;
		}
		if (oMutex != null)
		{
			oMutex = null;
		}
	}
}
