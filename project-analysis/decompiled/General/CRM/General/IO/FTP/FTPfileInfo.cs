using System;
using System.Text.RegularExpressions;

namespace CRM.General.IO.FTP;

public class FTPfileInfo
{
	public enum DirectoryEntryTypes
	{
		File,
		Directory
	}

	private string _filename;

	private string _path;

	private DirectoryEntryTypes _fileType;

	private long _size;

	private DateTime _fileDateTime;

	private string _permission;

	private static string[] _ParseFormats = new string[6] { "(?<dir>[\\-d])(?<permission>([\\-r][\\-w][\\-xs]){3})\\s+\\d+\\s+\\w+\\s+\\w+\\s+(?<size>\\d+)\\s+(?<timestamp>\\w+\\s+\\d+\\s+\\d{4})\\s+(?<name>.+)", "(?<dir>[\\-d])(?<permission>([\\-r][\\-w][\\-xs]){3})\\s+\\d+\\s+\\d+\\s+(?<size>\\d+)\\s+(?<timestamp>\\w+\\s+\\d+\\s+\\d{4})\\s+(?<name>.+)", "(?<dir>[\\-d])(?<permission>([\\-r][\\-w][\\-xs]){3})\\s+\\d+\\s+\\d+\\s+(?<size>\\d+)\\s+(?<timestamp>\\w+\\s+\\d+\\s+\\d{1,2}:\\d{2})\\s+(?<name>.+)", "(?<dir>[\\-d])(?<permission>([\\-r][\\-w][\\-xs]){3})\\s+\\d+\\s+\\w+\\s+\\w+\\s+(?<size>\\d+)\\s+(?<timestamp>\\w+\\s+\\d+\\s+\\d{1,2}:\\d{2})\\s+(?<name>.+)", "(?<dir>[\\-d])(?<permission>([\\-r][\\-w][\\-xs]){3})(\\s+)(?<size>(\\d+))(\\s+)(?<ctbit>(\\w+\\s\\w+))(\\s+)(?<size2>(\\d+))\\s+(?<timestamp>\\w+\\s+\\d+\\s+\\d{2}:\\d{2})\\s+(?<name>.+)", "(?<timestamp>\\d{2}\\-\\d{2}\\-\\d{2}\\s+\\d{2}:\\d{2}[Aa|Pp][mM])\\s+(?<dir>\\<\\w+\\>){0,1}(?<size>\\d+){0,1}\\s+(?<name>.+)" };

	public string FullName => Path + Filename;

	public string Filename => _filename;

	public string Path => _path + (_path.EndsWith("/") ? "" : "/");

	public DirectoryEntryTypes FileType => _fileType;

	public long Size => _size;

	public DateTime FileDateTime
	{
		get
		{
			return _fileDateTime;
		}
		internal set
		{
			_fileDateTime = value;
		}
	}

	public string Permission => _permission;

	public string Extension
	{
		get
		{
			int num = Filename.LastIndexOf(".");
			if (num >= 0 && num < Filename.Length - 1)
			{
				return Filename.Substring(num + 1);
			}
			return "";
		}
	}

	public string NameOnly
	{
		get
		{
			int num = Filename.LastIndexOf(".");
			if (num > 0)
			{
				return Filename.Substring(0, num);
			}
			return Filename;
		}
	}

	public FTPfileInfo(string line, string path)
	{
		Match matchingRegex = GetMatchingRegex(line);
		if (matchingRegex == null)
		{
			throw new ApplicationException("Unable to parse line: " + line);
		}
		_filename = ((Capture)matchingRegex.Groups["name"]).Value;
		_path = path;
		long.TryParse(((Capture)matchingRegex.Groups["size"]).Value, out _size);
		_permission = ((Capture)matchingRegex.Groups["permission"]).Value;
		string value = ((Capture)matchingRegex.Groups["dir"]).Value;
		if (value != "" && value != "-")
		{
			_fileType = DirectoryEntryTypes.Directory;
		}
		else
		{
			_fileType = DirectoryEntryTypes.File;
		}
	}

	private Match GetMatchingRegex(string line)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		for (int i = 0; i <= _ParseFormats.Length - 1; i++)
		{
			Match val = new Regex(_ParseFormats[i]).Match(line);
			if (((Group)val).Success)
			{
				return val;
			}
		}
		return null;
	}
}
