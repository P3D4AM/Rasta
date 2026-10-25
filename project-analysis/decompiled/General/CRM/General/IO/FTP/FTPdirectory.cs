using System;
using System.Collections.Generic;

namespace CRM.General.IO.FTP;

public class FTPdirectory : List<FTPfileInfo>
{
	private const char slash = '/';

	public FTPdirectory()
	{
	}

	public FTPdirectory(string dir, string path)
	{
		string[] array = dir.Replace("\n", "").Split(new char[1] { Convert.ToChar('\r') });
		foreach (string text in array)
		{
			if (text != "")
			{
				Add(new FTPfileInfo(text, path));
			}
		}
	}

	public FTPdirectory GetFiles(string ext)
	{
		return GetFileOrDir(FTPfileInfo.DirectoryEntryTypes.File, ext);
	}

	public FTPdirectory GetDirectories()
	{
		return GetFileOrDir(FTPfileInfo.DirectoryEntryTypes.Directory, "");
	}

	private FTPdirectory GetFileOrDir(FTPfileInfo.DirectoryEntryTypes type, string ext)
	{
		FTPdirectory fTPdirectory = new FTPdirectory();
		using Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			FTPfileInfo current = enumerator.Current;
			if (current.FileType == type)
			{
				if (ext == "")
				{
					fTPdirectory.Add(current);
				}
				else if (ext == current.Extension)
				{
					fTPdirectory.Add(current);
				}
			}
		}
		return fTPdirectory;
	}

	public bool FileExists(string filename)
	{
		using (Enumerator enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.Filename == filename)
				{
					return true;
				}
			}
		}
		return false;
	}

	public static string GetParentDirectory(string dir)
	{
		string text = dir.TrimEnd(new char[1] { '/' });
		int num = text.LastIndexOf('/');
		if (num > 0)
		{
			return text.Substring(0, num - 1);
		}
		throw new ApplicationException("No parent for root");
	}
}
