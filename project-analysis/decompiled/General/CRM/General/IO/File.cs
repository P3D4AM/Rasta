using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Web.Hosting;
using Microsoft.Win32;

namespace CRM.General.IO;

public static class File
{
	[Flags]
	public enum MoveFileFlags
	{
		MOVEFILE_REPLACE_EXISTING = 1,
		MOVEFILE_COPY_ALLOWED = 2,
		MOVEFILE_DELAY_UNTIL_REBOOT = 4,
		MOVEFILE_WRITE_THROUGH = 8,
		MOVEFILE_CREATE_HARDLINK = 0x10,
		MOVEFILE_FAIL_IF_NOT_TRACKABLE = 0x20
	}

	[DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern bool MoveFileEx(string lpExistingFileName, string lpNewFileName, MoveFileFlags dwFlags);

	public static string Read(string pathName)
	{
		if (pathName == null)
		{
			return string.Empty;
		}
		pathName = pathName.Trim();
		if (pathName == string.Empty)
		{
			return string.Empty;
		}
		if (!System.IO.File.Exists(pathName))
		{
			return string.Empty;
		}
		string result = string.Empty;
		StreamReader streamReader = null;
		try
		{
			streamReader = new StreamReader(pathName, Encoding.UTF8);
			result = streamReader.ReadToEnd();
		}
		catch
		{
		}
		finally
		{
			if (streamReader != null)
			{
				streamReader.Dispose();
				streamReader = null;
			}
		}
		return result;
	}

	public static bool Write(string pathName, string text, bool append)
	{
		if (pathName == null)
		{
			return false;
		}
		pathName = pathName.Trim();
		if (pathName == string.Empty)
		{
			return false;
		}
		if (text == null)
		{
			text = string.Empty;
		}
		StreamWriter streamWriter = null;
		try
		{
			streamWriter = new StreamWriter(pathName, append, Encoding.UTF8);
			streamWriter.Write(text);
			return true;
		}
		catch
		{
			return false;
		}
		finally
		{
			if (streamWriter != null)
			{
				streamWriter.Dispose();
				streamWriter = null;
			}
		}
	}

	public static bool Append(string pathName, string text)
	{
		return Write(pathName, text, append: true);
	}

	public static bool Overwrite(string pathName, string text)
	{
		return Write(pathName, text, append: false);
	}

	private static string GetCurrentCultureName()
	{
		return Thread.CurrentThread.CurrentCulture.Name;
	}

	public static string GetFileNameByCulture(string name, string cultureName, string extension)
	{
		string arg = name;
		if (string.Compare(cultureName, "en-US", ignoreCase: true) != 0)
		{
			arg = $"{arg}.{cultureName}";
		}
		return $"{arg}.{extension}";
	}

	public static string GetFileNameByCurrentCulture(string fileName, string extension)
	{
		return GetFileNameByCulture(fileName, GetCurrentCultureName(), extension);
	}

	public static string GetPathNameByCulture(string rootRelativePath, string name, string cultureName, string extension)
	{
		string fileNameByCulture = GetFileNameByCulture(name, cultureName, extension);
		return HostingEnvironment.MapPath($"{rootRelativePath}/{fileNameByCulture}");
	}

	public static string GetPathNameByCurrentCulture(string rootRelativePath, string name, string extension)
	{
		return GetPathNameByCulture(rootRelativePath, name, GetCurrentCultureName(), extension);
	}

	public static string GetFileFormatByteSize(double bytes)
	{
		string[] array = new string[9] { "B", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
		int num = 0;
		do
		{
			bytes /= 1024.0;
			num++;
		}
		while (bytes >= 1024.0);
		return $"{bytes:0.00} {array[num]}";
	}

	public static string GetDefaultExtension(string mimeType)
	{
		RegistryKey val = Registry.ClassesRoot.OpenSubKey("MIME\\Database\\Content Type\\" + mimeType, false);
		object obj = ((val != null) ? val.GetValue("Extension", (object)null) : null);
		if (obj == null)
		{
			return string.Empty;
		}
		return obj.ToString();
	}

	public static string GetMimeTypeFromExtension(string extension)
	{
		if (!extension.StartsWith("."))
		{
			extension = "." + extension;
		}
		RegistryKey val = Registry.ClassesRoot.OpenSubKey(extension, false);
		object obj = ((val != null) ? val.GetValue("Content Type", (object)null) : null);
		if (obj == null)
		{
			return string.Empty;
		}
		return obj.ToString();
	}

	public static bool SaveBytesToFile(string filename, byte[] bytesToWrite)
	{
		bool result = true;
		try
		{
			if (!string.IsNullOrEmpty(filename) && bytesToWrite != null)
			{
				if (!System.IO.Directory.Exists(Path.GetDirectoryName(filename)))
				{
					System.IO.Directory.CreateDirectory(Path.GetDirectoryName(filename));
				}
				FileStream fileStream = System.IO.File.Create(filename);
				fileStream.Write(bytesToWrite, 0, bytesToWrite.Length);
				fileStream.Close();
			}
		}
		catch
		{
			result = false;
		}
		return result;
	}
}
