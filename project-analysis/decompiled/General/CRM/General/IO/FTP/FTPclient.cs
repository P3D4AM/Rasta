using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using CRM.General.Utilities;

namespace CRM.General.IO.FTP;

public class FTPclient
{
	private NetworkCredential _credentials;

	private string _lastDirectory = "";

	private string _hostname;

	private string _username;

	private string _password;

	private string _currentDirectory = "/";

	private bool _enableSSL;

	private bool _keepAlive;

	private bool _usePassive;

	private IWebProxy _proxy;

	public string Hostname
	{
		get
		{
			if (_hostname.StartsWith("ftp://"))
			{
				return _hostname;
			}
			return "ftp://" + _hostname;
		}
		set
		{
			_hostname = value;
		}
	}

	public string Username
	{
		get
		{
			if (!(_username == ""))
			{
				return _username;
			}
			return "anonymous";
		}
		set
		{
			_username = value;
		}
	}

	public string Password
	{
		get
		{
			return _password;
		}
		set
		{
			_password = value;
		}
	}

	public string CurrentDirectory
	{
		get
		{
			return _currentDirectory + (_currentDirectory.EndsWith("/") ? "" : "/").ToString();
		}
		set
		{
			if (!value.StartsWith("/"))
			{
				throw new ApplicationException("Directory should start with /");
			}
			_currentDirectory = value;
		}
	}

	public bool EnableSSL
	{
		get
		{
			return _enableSSL;
		}
		set
		{
			_enableSSL = value;
		}
	}

	public bool KeepAlive
	{
		get
		{
			return _keepAlive;
		}
		set
		{
			_keepAlive = value;
		}
	}

	public bool UsePassive
	{
		get
		{
			return _usePassive;
		}
		set
		{
			_usePassive = value;
		}
	}

	public IWebProxy Proxy
	{
		get
		{
			return _proxy;
		}
		set
		{
			_proxy = value;
		}
	}

	public FTPclient(bool usePassive)
	{
		_usePassive = usePassive;
	}

	public FTPclient(string Hostname, bool usePassive)
	{
		_hostname = Hostname;
		_usePassive = usePassive;
	}

	public FTPclient(string Hostname, string Username, string Password, bool usePassive)
	{
		_hostname = Hostname;
		_username = Username;
		_password = Password;
		_usePassive = usePassive;
	}

	public FTPclient(string Hostname, string Username, string Password, bool KeepAlive, bool usePassive)
	{
		_hostname = Hostname;
		_username = Username;
		_password = Password;
		_keepAlive = KeepAlive;
		_usePassive = usePassive;
	}

	public List<string> ListDirectory(string directory)
	{
		string directory2 = GetDirectory(directory);
		FtpWebRequest request = GetRequest(directory2);
		((WebRequest)request).Method = "NLST";
		string stringResponse = GetStringResponse(request);
		stringResponse = stringResponse.Replace("\r\n", "\r").TrimEnd(new char[1] { '\r' });
		List<string> list = new List<string>();
		if (UsePassive)
		{
			list.AddRange(stringResponse.Split(new char[1] { '\r' }));
		}
		return list;
	}

	public FTPdirectory ListDirectoryDetail()
	{
		return ListDirectoryDetail("", doDateTimeStamp: false);
	}

	public FTPdirectory ListDirectoryDetail(string directory)
	{
		return ListDirectoryDetail(directory, doDateTimeStamp: false);
	}

	public FTPdirectory ListDirectoryDetail(string directory, bool doDateTimeStamp)
	{
		string directory2 = GetDirectory(directory);
		FtpWebRequest request = GetRequest(directory2);
		((WebRequest)request).Method = "LIST";
		FTPdirectory fTPdirectory = new FTPdirectory(GetStringResponse(request).Replace("\r\n", "\r").TrimEnd(new char[1] { '\r' }), _lastDirectory);
		if (doDateTimeStamp)
		{
			foreach (FTPfileInfo item in fTPdirectory)
			{
				item.FileDateTime = GetDateTimestamp(item);
			}
		}
		return fTPdirectory;
	}

	public bool Upload(string localFilename, string targetFilename)
	{
		if (!System.IO.File.Exists(localFilename))
		{
			throw new ApplicationException("File " + localFilename + " not found");
		}
		FileInfo fi = new FileInfo(localFilename);
		return Upload(fi, targetFilename);
	}

	public bool Upload(FileInfo fi, string targetFilename)
	{
		string targetFilename2 = ((!string.IsNullOrEmpty(targetFilename)) ? targetFilename : (CurrentDirectory + fi.Name));
		using FileStream fileStream = fi.OpenRead();
		try
		{
			return Upload(fileStream, targetFilename2);
		}
		catch (Exception)
		{
			throw;
		}
		finally
		{
			fileStream.Close();
		}
	}

	public bool Upload(Stream sourceStream, string targetFilename)
	{
		if (string.IsNullOrEmpty(targetFilename))
		{
			throw new ApplicationException("Target filename must be specified");
		}
		string uRI = CreateURI(targetFilename);
		FtpWebRequest request = GetRequest(uRI);
		((WebRequest)request).Method = "STOR";
		request.UseBinary = true;
		((WebRequest)request).ContentLength = sourceStream.Length;
		byte[] buffer = new byte[2048];
		using (sourceStream)
		{
			try
			{
				sourceStream.Position = 0L;
				using (Stream stream = ((WebRequest)request).GetRequestStream())
				{
					int num;
					do
					{
						num = sourceStream.Read(buffer, 0, 2048);
						stream.Write(buffer, 0, num);
					}
					while (num >= 2048);
					stream.Close();
				}
				return true;
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				sourceStream.Close();
				request = null;
			}
		}
	}

	public bool Download(string sourceFilename, string localFilename, bool PermitOverwrite)
	{
		FileInfo targetFI = new FileInfo(localFilename);
		return Download(sourceFilename, targetFI, PermitOverwrite);
	}

	public bool Download(FTPfileInfo file, string localFilename, bool PermitOverwrite)
	{
		return Download(file.FullName, localFilename, PermitOverwrite);
	}

	public bool Download(FTPfileInfo file, FileInfo localFI, bool PermitOverwrite)
	{
		return Download(file.FullName, localFI, PermitOverwrite);
	}

	public bool Download(string sourceFilename, FileInfo targetFI, bool PermitOverwrite)
	{
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		if (targetFI.Exists && !PermitOverwrite)
		{
			throw new ApplicationException("Target file already exists");
		}
		if (string.IsNullOrEmpty(sourceFilename))
		{
			throw new ApplicationException("File not specified");
		}
		string uRI = CreateURI(sourceFilename);
		FtpWebRequest request = GetRequest(uRI);
		((WebRequest)request).Method = "RETR";
		request.UseBinary = true;
		try
		{
			FtpWebResponse val = (FtpWebResponse)((WebRequest)request).GetResponse();
			try
			{
				using (Stream stream = ((WebResponse)val).GetResponseStream())
				{
					using (FileStream fileStream = targetFI.OpenWrite())
					{
						try
						{
							byte[] array = new byte[2048];
							int num = 0;
							do
							{
								num = stream.Read(array, 0, array.Length);
								fileStream.Write(array, 0, num);
							}
							while (num != 0);
							stream.Close();
							fileStream.Flush();
							fileStream.Close();
						}
						catch (Exception)
						{
							fileStream.Close();
							targetFI.Delete();
							throw;
						}
					}
					stream.Close();
				}
				((WebResponse)val).Close();
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}
		catch (WebException)
		{
			return false;
		}
		return true;
	}

	public byte[] GetBytesResponse(string sourceFilename)
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Expected O, but got Unknown
		if (string.IsNullOrEmpty(sourceFilename))
		{
			return null;
		}
		string uRI = CreateURI(sourceFilename);
		FtpWebRequest request = GetRequest(uRI);
		((WebRequest)request).Method = "RETR";
		request.UseBinary = true;
		try
		{
			FtpWebResponse val = (FtpWebResponse)((WebRequest)request).GetResponse();
			try
			{
				using Stream stream = ((WebResponse)val).GetResponseStream();
				using MemoryStream memoryStream = new MemoryStream();
				stream.CopyTo(memoryStream);
				return memoryStream.ToArray();
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}
		catch (WebException)
		{
			return null;
		}
	}

	public bool FtpDelete(string filename)
	{
		string uRI = CreateURI(filename);
		FtpWebRequest request = GetRequest(uRI);
		((WebRequest)request).Method = "DELE";
		try
		{
			GetStringResponse(request);
		}
		catch (Exception)
		{
			return false;
		}
		return true;
	}

	public bool FtpFileExists(string filename)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Expected O, but got Unknown
		try
		{
			GetFileSize(filename);
			return true;
		}
		catch (WebException val)
		{
			val.Response.Close();
			if (((Exception)val).Message.Contains("550"))
			{
				return false;
			}
			throw;
		}
		catch
		{
			throw;
		}
	}

	public bool FtpDirectoryExists(string remoteDir)
	{
		//IL_0071: Expected O, but got Unknown
		try
		{
			List<string> list = ListDirectory(remoteDir);
			if (list.Count > 0)
			{
				string value = ApplicationSettings.GetValue("CheckDirInFtp");
				if (!string.IsNullOrEmpty(value) && value.Trim().ToLower() == "true" && list.Count == 1 && (list[0] == null || list[0] == ""))
				{
					return false;
				}
				return true;
			}
			return false;
		}
		catch (WebException val)
		{
			((Exception)val).Message.Contains("550");
			return false;
		}
		catch
		{
			throw;
		}
	}

	public long GetFileSize(string filename)
	{
		string uRI = CreateURI(filename);
		FtpWebRequest request = GetRequest(uRI);
		((WebRequest)request).Method = "SIZE";
		GetStringResponse(request);
		return GetSize(request);
	}

	public bool FtpRename(string sourceFilename, string newName)
	{
		string fullPath = GetFullPath(sourceFilename);
		if (!FtpFileExists(fullPath))
		{
			throw new FileNotFoundException("File " + fullPath + " not found");
		}
		string text = (newName.StartsWith("..") ? newName : GetFullPath(newName));
		if (text == fullPath)
		{
			throw new ApplicationException("Source and target are the same");
		}
		if (FtpFileExists(text))
		{
			throw new ApplicationException("Target file " + text + " already exists");
		}
		string uRI = CreateURI(fullPath);
		FtpWebRequest request = GetRequest(uRI);
		((WebRequest)request).Method = "RENAME";
		request.RenameTo = text;
		request.UseBinary = true;
		try
		{
			GetStringResponse(request);
		}
		catch (Exception)
		{
			throw;
		}
		return true;
	}

	public bool FtpCreateDirectory(string dirpath)
	{
		string uRI = CreateURI(dirpath);
		FtpWebRequest request = GetRequest(uRI);
		((WebRequest)request).Method = "MKD";
		try
		{
			GetStringResponse(request);
		}
		catch (Exception)
		{
			return false;
		}
		return true;
	}

	public bool FtpDeleteDirectory(string dirpath)
	{
		string uRI = CreateURI(dirpath);
		FtpWebRequest request = GetRequest(uRI);
		((WebRequest)request).Method = "RMD";
		try
		{
			GetStringResponse(request);
		}
		catch (Exception)
		{
			return false;
		}
		return true;
	}

	public DateTime GetDateTimestamp(FTPfileInfo file)
	{
		return file.FileDateTime = GetDateTimestamp(file.Filename);
	}

	public DateTime GetDateTimestamp(string filename)
	{
		string uRI = CreateURI(filename);
		FtpWebRequest request = GetRequest(uRI);
		((WebRequest)request).Method = "MDTM";
		return GetLastModified(request);
	}

	private string CreateURI(string filename)
	{
		string path = ((!filename.Contains("/")) ? (CurrentDirectory + filename) : AdjustDir(filename));
		string escapedPath = GetEscapedPath(path);
		string text = Hostname + escapedPath;
		if (text.StartsWith(Hostname + "/%5C"))
		{
			text = text.Replace(Hostname + "/%5C", Hostname + "/");
		}
		return text;
	}

	private FtpWebRequest GetRequest(string URI)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Expected O, but got Unknown
		FtpWebRequest val = (FtpWebRequest)WebRequest.Create(URI);
		((WebRequest)val).Credentials = GetCredentials();
		val.EnableSsl = EnableSSL;
		val.KeepAlive = KeepAlive;
		val.UsePassive = UsePassive;
		((WebRequest)val).Proxy = Proxy;
		return val;
	}

	private string GetEscapedPath(string path)
	{
		string[] array = path.Split(new char[1] { '/' });
		string text = "";
		string[] array2 = array;
		foreach (string text2 in array2)
		{
			if (!string.IsNullOrEmpty(text2))
			{
				text = text + "/" + Uri.EscapeDataString(text2);
			}
		}
		return text;
	}

	private ICredentials GetCredentials()
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		if (_credentials == null)
		{
			_credentials = new NetworkCredential(Username, Password);
		}
		return (ICredentials)(object)_credentials;
	}

	private string GetFullPath(string file)
	{
		if (file.Contains("/"))
		{
			return AdjustDir(file);
		}
		return CurrentDirectory + file;
	}

	private string AdjustDir(string path)
	{
		return (path.StartsWith("/") ? "" : "/").ToString() + path;
	}

	private string GetDirectory(string directory)
	{
		string result;
		if (directory == "")
		{
			result = Hostname + CurrentDirectory;
			_lastDirectory = CurrentDirectory;
		}
		else
		{
			if (!directory.StartsWith("/"))
			{
				throw new ApplicationException("Directory should start with /");
			}
			result = Hostname + directory;
			_lastDirectory = directory;
		}
		return result;
	}

	private string GetStringResponse(FtpWebRequest ftp)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected O, but got Unknown
		string result = "";
		FtpWebResponse val = (FtpWebResponse)((WebRequest)ftp).GetResponse();
		try
		{
			try
			{
				_ = ((WebResponse)val).ContentLength;
				using Stream stream = ((WebResponse)val).GetResponseStream();
				using (StreamReader streamReader = new StreamReader(stream, Encoding.UTF8))
				{
					result = streamReader.ReadToEnd();
				}
				stream.Close();
				return result;
			}
			catch (Exception)
			{
				return string.Empty;
			}
			finally
			{
				((WebResponse)val).Close();
			}
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	private long GetSize(FtpWebRequest ftp)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		FtpWebResponse val = (FtpWebResponse)((WebRequest)ftp).GetResponse();
		try
		{
			long contentLength = ((WebResponse)val).ContentLength;
			((WebResponse)val).Close();
			return contentLength;
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	private DateTime GetLastModified(FtpWebRequest ftp)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		FtpWebResponse val = (FtpWebResponse)((WebRequest)ftp).GetResponse();
		try
		{
			DateTime lastModified = val.LastModified;
			((WebResponse)val).Close();
			return lastModified;
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}
}
