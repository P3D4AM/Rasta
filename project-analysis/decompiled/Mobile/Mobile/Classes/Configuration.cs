using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using CRM.General.Security;
using CRM.General.Utilities;
using CRM.Resources;
using Elmah;
using Mobile.Cache.Setting;
using Mobile.Models;

namespace Mobile.Classes;

public static class Configuration
{
	private static string _cacheUniqueName = "";

	private static string _cacheDefaultName = "";

	private static string _cacheDefaultTimeInMinutes = "";

	private static string _maxCountCrmShop = "";

	private static string _maxCenterCount = "";

	private static string _maxFoCount = "";

	public static string CacheUniqueName
	{
		get
		{
			if (_cacheUniqueName != "")
			{
				return _cacheUniqueName;
			}
			try
			{
				_cacheUniqueName = ApplicationSettings.GetValue("CacheUniqueName");
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
			}
			return _cacheUniqueName;
		}
		set
		{
			_cacheUniqueName = value;
		}
	}

	public static string CacheDefaultName
	{
		get
		{
			if (_cacheDefaultName != "")
			{
				return _cacheDefaultName;
			}
			try
			{
				_cacheDefaultName = ApplicationSettings.GetValue("CacheDefaultName");
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
			}
			return _cacheDefaultName;
		}
		set
		{
			_cacheDefaultName = value;
		}
	}

	public static int CacheDefaultTimeInMinutes
	{
		get
		{
			int result = 0;
			if (_cacheDefaultTimeInMinutes != "")
			{
				int.TryParse(_cacheDefaultTimeInMinutes, out result);
			}
			else
			{
				try
				{
					_cacheDefaultTimeInMinutes = ApplicationSettings.GetValue("CacheDefaultTimeInMinutes");
					int.TryParse(_cacheDefaultTimeInMinutes, out result);
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
				}
			}
			return result;
		}
		set
		{
			int num = value;
			_cacheDefaultTimeInMinutes = num.ToString();
		}
	}

	public static string FacadeFtp
	{
		get
		{
			string result = "";
			List<MobspSelectCrmWebSetting_Result> list = WebSetting.Get();
			if (list != null)
			{
				MobspSelectCrmWebSetting_Result mobspSelectCrmWebSetting_Result = Enumerable.FirstOrDefault<MobspSelectCrmWebSetting_Result>((IEnumerable<MobspSelectCrmWebSetting_Result>)list, (Func<MobspSelectCrmWebSetting_Result, bool>)((MobspSelectCrmWebSetting_Result c) => c.Key.Equals("FacadeFTP")));
				if (mobspSelectCrmWebSetting_Result != null)
				{
					result = ((mobspSelectCrmWebSetting_Result.Type.ToLower() == "selector") ? (mobspSelectCrmWebSetting_Result.IsDecoded ? CodeDecode.DeCodding(mobspSelectCrmWebSetting_Result.Value) : mobspSelectCrmWebSetting_Result.Value).Split(new char[1] { ':' })[0] : ((!(mobspSelectCrmWebSetting_Result.Type.ToLower() == "text")) ? (mobspSelectCrmWebSetting_Result.IsDecoded ? CodeDecode.DeCodding(mobspSelectCrmWebSetting_Result.Value) : mobspSelectCrmWebSetting_Result.Value) : (mobspSelectCrmWebSetting_Result.IsDecoded ? CodeDecode.DeCodding(mobspSelectCrmWebSetting_Result.Value) : mobspSelectCrmWebSetting_Result.Value)));
				}
			}
			return result;
		}
	}

	public static string PathFtp
	{
		get
		{
			string result = "";
			List<MobspSelectCrmWebSetting_Result> list = WebSetting.Get();
			if (list != null)
			{
				MobspSelectCrmWebSetting_Result mobspSelectCrmWebSetting_Result = Enumerable.FirstOrDefault<MobspSelectCrmWebSetting_Result>((IEnumerable<MobspSelectCrmWebSetting_Result>)list, (Func<MobspSelectCrmWebSetting_Result, bool>)((MobspSelectCrmWebSetting_Result c) => c.Key.Equals("PathFTP")));
				if (mobspSelectCrmWebSetting_Result != null)
				{
					result = (mobspSelectCrmWebSetting_Result.IsDecoded ? CodeDecode.DeCodding(mobspSelectCrmWebSetting_Result.Value) : mobspSelectCrmWebSetting_Result.Value);
				}
			}
			return result;
		}
	}

	public static string UserNameFtp
	{
		get
		{
			string result = "";
			List<MobspSelectCrmWebSetting_Result> list = WebSetting.Get();
			if (list != null)
			{
				MobspSelectCrmWebSetting_Result mobspSelectCrmWebSetting_Result = Enumerable.FirstOrDefault<MobspSelectCrmWebSetting_Result>((IEnumerable<MobspSelectCrmWebSetting_Result>)list, (Func<MobspSelectCrmWebSetting_Result, bool>)((MobspSelectCrmWebSetting_Result c) => c.Key.Equals("UserNameFTP")));
				if (mobspSelectCrmWebSetting_Result != null)
				{
					result = (mobspSelectCrmWebSetting_Result.IsDecoded ? CodeDecode.DeCodding(mobspSelectCrmWebSetting_Result.Value) : mobspSelectCrmWebSetting_Result.Value);
				}
			}
			return result;
		}
	}

	public static string PasswordFtp
	{
		get
		{
			string result = "";
			List<MobspSelectCrmWebSetting_Result> list = WebSetting.Get();
			if (list != null)
			{
				MobspSelectCrmWebSetting_Result mobspSelectCrmWebSetting_Result = Enumerable.FirstOrDefault<MobspSelectCrmWebSetting_Result>((IEnumerable<MobspSelectCrmWebSetting_Result>)list, (Func<MobspSelectCrmWebSetting_Result, bool>)((MobspSelectCrmWebSetting_Result c) => c.Key.Equals("PasswordFTP")));
				if (mobspSelectCrmWebSetting_Result != null)
				{
					result = (mobspSelectCrmWebSetting_Result.IsDecoded ? CodeDecode.DeCodding(mobspSelectCrmWebSetting_Result.Value) : mobspSelectCrmWebSetting_Result.Value);
				}
			}
			return result;
		}
	}

	public static bool UsePassiveFtp
	{
		get
		{
			bool result = true;
			List<MobspSelectCrmWebSetting_Result> list = WebSetting.Get();
			if (list != null)
			{
				MobspSelectCrmWebSetting_Result mobspSelectCrmWebSetting_Result = Enumerable.FirstOrDefault<MobspSelectCrmWebSetting_Result>((IEnumerable<MobspSelectCrmWebSetting_Result>)list, (Func<MobspSelectCrmWebSetting_Result, bool>)((MobspSelectCrmWebSetting_Result c) => c.Key.Equals("UsePassiveFTP")));
				if (mobspSelectCrmWebSetting_Result != null)
				{
					bool.TryParse(mobspSelectCrmWebSetting_Result.IsDecoded ? CodeDecode.DeCodding(mobspSelectCrmWebSetting_Result.Value) : mobspSelectCrmWebSetting_Result.Value, out result);
				}
			}
			return result;
		}
	}

	public static string FacadeFtpRecording
	{
		get
		{
			string result = "";
			List<MobspSelectCrmWebSetting_Result> list = WebSetting.Get();
			if (list != null)
			{
				MobspSelectCrmWebSetting_Result mobspSelectCrmWebSetting_Result = Enumerable.FirstOrDefault<MobspSelectCrmWebSetting_Result>((IEnumerable<MobspSelectCrmWebSetting_Result>)list, (Func<MobspSelectCrmWebSetting_Result, bool>)((MobspSelectCrmWebSetting_Result c) => c.Key.Equals("FacadeFTPRecording")));
				if (mobspSelectCrmWebSetting_Result != null)
				{
					result = ((mobspSelectCrmWebSetting_Result.Type.ToLower() == "selector") ? (mobspSelectCrmWebSetting_Result.IsDecoded ? CodeDecode.DeCodding(mobspSelectCrmWebSetting_Result.Value) : mobspSelectCrmWebSetting_Result.Value).Split(new char[1] { ':' })[0] : ((!(mobspSelectCrmWebSetting_Result.Type.ToLower() == "text")) ? (mobspSelectCrmWebSetting_Result.IsDecoded ? CodeDecode.DeCodding(mobspSelectCrmWebSetting_Result.Value) : mobspSelectCrmWebSetting_Result.Value) : (mobspSelectCrmWebSetting_Result.IsDecoded ? CodeDecode.DeCodding(mobspSelectCrmWebSetting_Result.Value) : mobspSelectCrmWebSetting_Result.Value)));
				}
			}
			return result;
		}
	}

	public static string PathFtpRecording
	{
		get
		{
			string result = "";
			List<MobspSelectCrmWebSetting_Result> list = WebSetting.Get();
			if (list != null)
			{
				MobspSelectCrmWebSetting_Result mobspSelectCrmWebSetting_Result = Enumerable.FirstOrDefault<MobspSelectCrmWebSetting_Result>((IEnumerable<MobspSelectCrmWebSetting_Result>)list, (Func<MobspSelectCrmWebSetting_Result, bool>)((MobspSelectCrmWebSetting_Result c) => c.Key.Equals("PathFTPRecording")));
				if (mobspSelectCrmWebSetting_Result != null)
				{
					result = (mobspSelectCrmWebSetting_Result.IsDecoded ? CodeDecode.DeCodding(mobspSelectCrmWebSetting_Result.Value) : mobspSelectCrmWebSetting_Result.Value);
				}
			}
			return result;
		}
	}

	public static string UserNameFtpRecording
	{
		get
		{
			string result = "";
			List<MobspSelectCrmWebSetting_Result> list = WebSetting.Get();
			if (list != null)
			{
				MobspSelectCrmWebSetting_Result mobspSelectCrmWebSetting_Result = Enumerable.FirstOrDefault<MobspSelectCrmWebSetting_Result>((IEnumerable<MobspSelectCrmWebSetting_Result>)list, (Func<MobspSelectCrmWebSetting_Result, bool>)((MobspSelectCrmWebSetting_Result c) => c.Key.Equals("UserNameFTPRecording")));
				if (mobspSelectCrmWebSetting_Result != null)
				{
					result = (mobspSelectCrmWebSetting_Result.IsDecoded ? CodeDecode.DeCodding(mobspSelectCrmWebSetting_Result.Value) : mobspSelectCrmWebSetting_Result.Value);
				}
			}
			return result;
		}
	}

	public static string PasswordFtpRecording
	{
		get
		{
			string result = "";
			List<MobspSelectCrmWebSetting_Result> list = WebSetting.Get();
			if (list != null)
			{
				MobspSelectCrmWebSetting_Result mobspSelectCrmWebSetting_Result = Enumerable.FirstOrDefault<MobspSelectCrmWebSetting_Result>((IEnumerable<MobspSelectCrmWebSetting_Result>)list, (Func<MobspSelectCrmWebSetting_Result, bool>)((MobspSelectCrmWebSetting_Result c) => c.Key.Equals("PasswordFTPRecording")));
				if (mobspSelectCrmWebSetting_Result != null)
				{
					result = (mobspSelectCrmWebSetting_Result.IsDecoded ? CodeDecode.DeCodding(mobspSelectCrmWebSetting_Result.Value) : mobspSelectCrmWebSetting_Result.Value);
				}
			}
			return result;
		}
	}

	public static bool UsePassiveFtpRecording
	{
		get
		{
			bool result = true;
			List<MobspSelectCrmWebSetting_Result> list = WebSetting.Get();
			if (list != null)
			{
				MobspSelectCrmWebSetting_Result mobspSelectCrmWebSetting_Result = Enumerable.FirstOrDefault<MobspSelectCrmWebSetting_Result>((IEnumerable<MobspSelectCrmWebSetting_Result>)list, (Func<MobspSelectCrmWebSetting_Result, bool>)((MobspSelectCrmWebSetting_Result c) => c.Key.Equals("UsePassiveFTPRecording")));
				if (mobspSelectCrmWebSetting_Result != null)
				{
					bool.TryParse(mobspSelectCrmWebSetting_Result.IsDecoded ? CodeDecode.DeCodding(mobspSelectCrmWebSetting_Result.Value) : mobspSelectCrmWebSetting_Result.Value, out result);
				}
			}
			return result;
		}
	}

	public static string FacadeFtpRecordingII
	{
		get
		{
			string result = "";
			List<MobspSelectCrmWebSetting_Result> list = WebSetting.Get();
			if (list != null)
			{
				MobspSelectCrmWebSetting_Result mobspSelectCrmWebSetting_Result = Enumerable.FirstOrDefault<MobspSelectCrmWebSetting_Result>((IEnumerable<MobspSelectCrmWebSetting_Result>)list, (Func<MobspSelectCrmWebSetting_Result, bool>)((MobspSelectCrmWebSetting_Result c) => c.Key.Equals("FacadeFTPRecordingII")));
				if (mobspSelectCrmWebSetting_Result != null)
				{
					result = ((mobspSelectCrmWebSetting_Result.Type.ToLower() == "selector") ? (mobspSelectCrmWebSetting_Result.IsDecoded ? CodeDecode.DeCodding(mobspSelectCrmWebSetting_Result.Value) : mobspSelectCrmWebSetting_Result.Value).Split(new char[1] { ':' })[0] : ((!(mobspSelectCrmWebSetting_Result.Type.ToLower() == "text")) ? (mobspSelectCrmWebSetting_Result.IsDecoded ? CodeDecode.DeCodding(mobspSelectCrmWebSetting_Result.Value) : mobspSelectCrmWebSetting_Result.Value) : (mobspSelectCrmWebSetting_Result.IsDecoded ? CodeDecode.DeCodding(mobspSelectCrmWebSetting_Result.Value) : mobspSelectCrmWebSetting_Result.Value)));
				}
			}
			return result;
		}
	}

	public static string PathFtpRecordingII
	{
		get
		{
			string result = "";
			List<MobspSelectCrmWebSetting_Result> list = WebSetting.Get();
			if (list != null)
			{
				MobspSelectCrmWebSetting_Result mobspSelectCrmWebSetting_Result = Enumerable.FirstOrDefault<MobspSelectCrmWebSetting_Result>((IEnumerable<MobspSelectCrmWebSetting_Result>)list, (Func<MobspSelectCrmWebSetting_Result, bool>)((MobspSelectCrmWebSetting_Result c) => c.Key.Equals("PathFTPRecordingII")));
				if (mobspSelectCrmWebSetting_Result != null)
				{
					result = (mobspSelectCrmWebSetting_Result.IsDecoded ? CodeDecode.DeCodding(mobspSelectCrmWebSetting_Result.Value) : mobspSelectCrmWebSetting_Result.Value);
				}
			}
			return result;
		}
	}

	public static string UserNameFtpRecordingII
	{
		get
		{
			string result = "";
			List<MobspSelectCrmWebSetting_Result> list = WebSetting.Get();
			if (list != null)
			{
				MobspSelectCrmWebSetting_Result mobspSelectCrmWebSetting_Result = Enumerable.FirstOrDefault<MobspSelectCrmWebSetting_Result>((IEnumerable<MobspSelectCrmWebSetting_Result>)list, (Func<MobspSelectCrmWebSetting_Result, bool>)((MobspSelectCrmWebSetting_Result c) => c.Key.Equals("UserNameFTPRecordingII")));
				if (mobspSelectCrmWebSetting_Result != null)
				{
					result = (mobspSelectCrmWebSetting_Result.IsDecoded ? CodeDecode.DeCodding(mobspSelectCrmWebSetting_Result.Value) : mobspSelectCrmWebSetting_Result.Value);
				}
			}
			return result;
		}
	}

	public static string PasswordFtpRecordingII
	{
		get
		{
			string result = "";
			List<MobspSelectCrmWebSetting_Result> list = WebSetting.Get();
			if (list != null)
			{
				MobspSelectCrmWebSetting_Result mobspSelectCrmWebSetting_Result = Enumerable.FirstOrDefault<MobspSelectCrmWebSetting_Result>((IEnumerable<MobspSelectCrmWebSetting_Result>)list, (Func<MobspSelectCrmWebSetting_Result, bool>)((MobspSelectCrmWebSetting_Result c) => c.Key.Equals("PasswordFTPRecordingII")));
				if (mobspSelectCrmWebSetting_Result != null)
				{
					result = (mobspSelectCrmWebSetting_Result.IsDecoded ? CodeDecode.DeCodding(mobspSelectCrmWebSetting_Result.Value) : mobspSelectCrmWebSetting_Result.Value);
				}
			}
			return result;
		}
	}

	public static bool UsePassiveFtpRecordingII
	{
		get
		{
			bool result = true;
			List<MobspSelectCrmWebSetting_Result> list = WebSetting.Get();
			if (list != null)
			{
				MobspSelectCrmWebSetting_Result mobspSelectCrmWebSetting_Result = Enumerable.FirstOrDefault<MobspSelectCrmWebSetting_Result>((IEnumerable<MobspSelectCrmWebSetting_Result>)list, (Func<MobspSelectCrmWebSetting_Result, bool>)((MobspSelectCrmWebSetting_Result c) => c.Key.Equals("UsePassiveFTPRecordingII")));
				if (mobspSelectCrmWebSetting_Result != null)
				{
					bool.TryParse(mobspSelectCrmWebSetting_Result.IsDecoded ? CodeDecode.DeCodding(mobspSelectCrmWebSetting_Result.Value) : mobspSelectCrmWebSetting_Result.Value, out result);
				}
			}
			return result;
		}
	}

	public static string AppType => "mob";

	public static string MainDirectoryPath => "/Files/DoNotChange/";

	public static string IntmsgDirectoryPath => "Intmsg/";

	public static string KnlgTDirectoryPath => "KnlgT/";

	public static string CnvsDirectoryPath => "Cnvs/";

	public static string UploadFileDirectoryPath => "UploadFile/";

	public static string CmsGalleryDirectoryPath => "CmsGallery/";

	public static string CmsNewsDirectoryPath => "CmsNews/";

	public static string PictureDirectoryPath => "Picture";

	public static string FilesDirectoryPath => "Files";

	public static string StockSupplyDirectoryPath => "StockSupply/";

	public static string HostTempFilesPath
	{
		get
		{
			string result = "";
			List<MobspSelectCrmWebSetting_Result> list = WebSetting.Get();
			if (list != null)
			{
				MobspSelectCrmWebSetting_Result mobspSelectCrmWebSetting_Result = Enumerable.FirstOrDefault<MobspSelectCrmWebSetting_Result>((IEnumerable<MobspSelectCrmWebSetting_Result>)list, (Func<MobspSelectCrmWebSetting_Result, bool>)((MobspSelectCrmWebSetting_Result c) => c.Key.Equals("HostTempFilesPath")));
				if (mobspSelectCrmWebSetting_Result != null)
				{
					result = (mobspSelectCrmWebSetting_Result.IsDecoded ? CodeDecode.DeCodding(mobspSelectCrmWebSetting_Result.Value) : mobspSelectCrmWebSetting_Result.Value);
				}
			}
			return result;
		}
	}

	public static string DyDirectoryPath => "Dy/";

	public static string DyFormFileTmpDirectoryPath => "DyFormFileTmp/";

	public static string FundDirectoryPath => "Fund/";

	public static string UserDirectoryPath => "Users/";

	public static string PrdGroupDirectoryPath => "ProductGroups/";

	public static string SmsWsDomainNamed => "ideal";

	public static string ForgotPassword => "Forgotten password IN FO";

	public static int MaxFileSizeForUploadMb
	{
		get
		{
			int result = 0;
			List<MobspSelectCrmWebSetting_Result> list = WebSetting.Get();
			if (list != null)
			{
				MobspSelectCrmWebSetting_Result mobspSelectCrmWebSetting_Result = Enumerable.FirstOrDefault<MobspSelectCrmWebSetting_Result>((IEnumerable<MobspSelectCrmWebSetting_Result>)list, (Func<MobspSelectCrmWebSetting_Result, bool>)((MobspSelectCrmWebSetting_Result c) => c.Key.Equals("MaxFileSizeForUploadMB")));
				if (mobspSelectCrmWebSetting_Result != null)
				{
					int.TryParse(mobspSelectCrmWebSetting_Result.IsDecoded ? CodeDecode.DeCodding(mobspSelectCrmWebSetting_Result.Value) : mobspSelectCrmWebSetting_Result.Value, out result);
				}
			}
			return result;
		}
	}

	public static List<string> MaliciousFileExtensions => new List<string>
	{
		"exe", "dll", "lnk", "sys", "jar", "gzquar", "scr", "js", "com", "ocx",
		"bat", "vbs", "bin", "class", "ws", "drv", "ozd", "wmf", "aru", "shs",
		"chm", "dev", "pgm", "xnxx", "pif", "vbe", "vxd", "tps", "vba", "pcx",
		"0_full_0_tgod_signed", "boo", "386", "sop", "hlp", "tsa", "vb", "scr", "dxz", "exe1",
		"bkd", "exe_renamed", "rhk", "lik", "vbx", "osa", "cih", "mjz", ".9", "php3",
		"wsc", "dlb", "dyz", "dom", "hlw", "cla", "s7p", "mjg", "mfu", "dyv",
		"kcd", "spam", "bup", "rsc_tmp", "mcq", "wsh", "upa", "bhx", "txs", "bxz",
		"dli", "cxq", "xir", "fnr", "xdu", "wlpginstall", "ska", "cfxxe", "tti", "smtmp",
		"dllx", "vexe", "qrn", "xtbl", "fag", "oar", "ceo", "tko", "uzy", "bll",
		"dbd", "plc", "smm", "ssy", "blf", "zvz", "cc", "ce0", "nls", "ctbl",
		"hsq", "crypt1", "iws", "vzr", "lkh", "ezt", "rna", "aepl", "hts", "let",
		"atm", "fuj", "buk", "fjl", "aut", "delf", "bps", "capxml", "cyw", "bmw",
		"iva", "pid", "dx", "lpaq5", "bqf", "qit", "pr", "lok", "xnt", "rdb"
	};

	public static int FileDirectoryTitleLength => 1000;

	public static int MaxFileCount
	{
		get
		{
			int result = 0;
			List<MobspSelectCrmWebSetting_Result> list = WebSetting.Get();
			if (list != null)
			{
				MobspSelectCrmWebSetting_Result mobspSelectCrmWebSetting_Result = Enumerable.FirstOrDefault<MobspSelectCrmWebSetting_Result>((IEnumerable<MobspSelectCrmWebSetting_Result>)list, (Func<MobspSelectCrmWebSetting_Result, bool>)((MobspSelectCrmWebSetting_Result c) => c.Key.Equals("MaxFileCountForUpload")));
				if (mobspSelectCrmWebSetting_Result != null)
				{
					int.TryParse(mobspSelectCrmWebSetting_Result.IsDecoded ? CodeDecode.DeCodding(mobspSelectCrmWebSetting_Result.Value) : mobspSelectCrmWebSetting_Result.Value, out result);
				}
			}
			return result;
		}
	}

	public static int MaxFileCountToDwonload => 10;

	public static string MobAppProjectName => "mobCRM";

	public static string MobHRMAppProjectName => "mobHRM";

	public static int MaxCountCrmShop
	{
		get
		{
			int result = 0;
			if (_maxCountCrmShop != "")
			{
				int.TryParse(_maxCountCrmShop, out result);
			}
			else
			{
				try
				{
					MobspSelectCrmsysSetting_Result mobspSelectCrmsysSetting_Result = SysSeting.Get();
					if (mobspSelectCrmsysSetting_Result != null)
					{
						string lockSerial = mobspSelectCrmsysSetting_Result.LockSerial;
						string value = ApplicationSettings.GetValue("RegisterCode");
						if (value != null)
						{
							string[] array = CodeDecode.RegDeCodding(value).Split(new char[1] { '|' });
							if (CodeDecode.RegDeCodding(array[0].Split(new char[1] { '@' })[1]) == lockSerial)
							{
								string text = CodeDecode.RegDeCodding(array[0].Split(new char[1] { '@' })[0]);
								if (!string.IsNullOrWhiteSpace(text))
								{
									if (text.IndexOf("CRMShopCnt") < 0)
									{
										text = "0";
									}
									else if (text.IndexOf("CRMShopCnt") >= 0)
									{
										string[] array2 = text.Split(new string[1] { "UsrMob" }, StringSplitOptions.None);
										if (array2 != null && array2.Length == 2)
										{
											text = array2[1];
										}
										if (!string.IsNullOrWhiteSpace(text) && text.IndexOf("CRMShopCnt") >= 0)
										{
											string[] array3 = text.Split(new string[1] { "CRMShopCnt" }, StringSplitOptions.None);
											if (array3 != null && array3.Length == 2)
											{
												text = array3[1];
												if (!string.IsNullOrWhiteSpace(text))
												{
													if (text.IndexOf("AccDbCnt") >= 0)
													{
														string[] array4 = text.Split(new string[1] { "AccDbCnt" }, StringSplitOptions.None);
														if (array4 != null && array4.Length == 2)
														{
															text = array4[0];
															text = CodeDecode.RegDeCodding(text);
														}
													}
													else
													{
														text = CodeDecode.RegDeCodding(text);
													}
												}
												else
												{
													text = CodeDecode.RegDeCodding(text);
												}
											}
										}
									}
								}
								if (text != "0")
								{
									text = text.Remove(text.Length - 5);
									text = text.Substring(6);
								}
								_maxCountCrmShop = text;
								int.TryParse(_maxCountCrmShop, out result);
							}
							else
							{
								Exception e = new Exception("Different lock Serial in Security Code!");
								ErrorSignal.FromCurrentContext().Raise(e);
								result = -1;
							}
						}
					}
				}
				catch (Exception e2)
				{
					ErrorSignal.FromCurrentContext().Raise(e2);
					result = 0;
				}
			}
			return result;
		}
		set
		{
			int num = value;
			_maxCountCrmShop = num.ToString();
		}
	}

	public static int MaxCenterCount
	{
		get
		{
			int result = 0;
			if (_maxCenterCount != "")
			{
				int.TryParse(_maxCenterCount, out result);
			}
			else
			{
				try
				{
					MobspSelectCrmsysSetting_Result mobspSelectCrmsysSetting_Result = SysSeting.Get();
					if (mobspSelectCrmsysSetting_Result != null)
					{
						string lockSerial = mobspSelectCrmsysSetting_Result.LockSerial;
						string value = ApplicationSettings.GetValue("RegisterCode");
						if (value != null)
						{
							string[] array = CodeDecode.RegDeCodding(value).Split(new char[1] { '|' });
							if (CodeDecode.RegDeCodding(array[0].Split(new char[1] { '@' })[1]) == lockSerial)
							{
								string text = CodeDecode.RegDeCodding(array[0].Split(new char[1] { '@' })[0]);
								if (!string.IsNullOrWhiteSpace(text))
								{
									if (text.IndexOf("CCnt") < 0)
									{
										text = "0";
									}
									else if (text.IndexOf("CCnt") >= 0)
									{
										string[] array2 = text.Split(new string[1] { "UsrMob" }, StringSplitOptions.None);
										if (array2 != null && array2.Length == 2)
										{
											text = array2[1];
										}
										if (!string.IsNullOrWhiteSpace(text) && text.IndexOf("CCnt") >= 0)
										{
											string[] array3 = text.Split(new string[1] { "CCnt" }, StringSplitOptions.None);
											if (array3 != null && array3.Length == 2)
											{
												text = array3[1];
												text = CodeDecode.RegDeCodding(text);
											}
										}
									}
								}
								if (text != "0")
								{
									text = text.Remove(text.Length - 5);
									text = text.Substring(6);
								}
								_maxCenterCount = text;
								int.TryParse(_maxCenterCount, out result);
							}
							else
							{
								Exception e = new Exception("Different lock Serial in Security Code!");
								ErrorSignal.FromCurrentContext().Raise(e);
								result = -1;
							}
						}
					}
				}
				catch (Exception e2)
				{
					ErrorSignal.FromCurrentContext().Raise(e2);
					result = 0;
				}
			}
			return result;
		}
		set
		{
			int num = value;
			_maxCenterCount = num.ToString();
		}
	}

	public static int MaxFOCount
	{
		get
		{
			int result = 0;
			if (_maxFoCount != "")
			{
				int.TryParse(_maxFoCount, out result);
			}
			else
			{
				try
				{
					MobspSelectCrmsysSetting_Result mobspSelectCrmsysSetting_Result = SysSeting.Get();
					if (mobspSelectCrmsysSetting_Result != null)
					{
						string lockSerial = mobspSelectCrmsysSetting_Result.LockSerial;
						string value = ApplicationSettings.GetValue("RegisterCode");
						if (value != null)
						{
							string[] array = CodeDecode.RegDeCodding(value).Split(new char[1] { '|' });
							if (CodeDecode.RegDeCodding(array[0].Split(new char[1] { '@' })[1]) == lockSerial)
							{
								string text = CodeDecode.RegDeCodding(array[0].Split(new char[1] { '@' })[0]);
								if (!string.IsNullOrWhiteSpace(text))
								{
									if (text.IndexOf("FoCnt") < 0)
									{
										text = "0";
									}
									else if (text.IndexOf("FoCnt") >= 0)
									{
										string[] array2 = text.Split(new string[1] { "UsrMob" }, StringSplitOptions.None);
										if (array2 != null && array2.Length == 2)
										{
											text = array2[1];
										}
										if (!string.IsNullOrWhiteSpace(text) && text.IndexOf("FoCnt") >= 0)
										{
											string[] array3 = text.Split(new string[1] { "FoCnt" }, StringSplitOptions.None);
											if (array3 != null && array3.Length == 2)
											{
												text = array3[1];
												if (!string.IsNullOrWhiteSpace(text))
												{
													if (text.IndexOf("CCnt") >= 0)
													{
														string[] array4 = text.Split(new string[1] { "CCnt" }, StringSplitOptions.None);
														if (array4 != null && array4.Length == 2)
														{
															text = array4[0];
															text = CodeDecode.RegDeCodding(text);
														}
													}
													else
													{
														text = CodeDecode.RegDeCodding(text);
													}
												}
												else
												{
													text = CodeDecode.RegDeCodding(text);
												}
											}
										}
									}
								}
								if (text != "0")
								{
									text = text.Remove(text.Length - 5);
									text = text.Substring(6);
								}
								_maxFoCount = text;
								int.TryParse(_maxFoCount, out result);
							}
							else
							{
								Exception e = new Exception("Different lock Serial in Security Code!");
								ErrorSignal.FromCurrentContext().Raise(e);
								result = -1;
							}
						}
					}
				}
				catch (Exception e2)
				{
					ErrorSignal.FromCurrentContext().Raise(e2);
					result = 0;
				}
			}
			return result;
		}
		set
		{
			int num = value;
			_maxFoCount = num.ToString();
		}
	}

	public static string GetAppType(string appType)
	{
		string text = "";
		try
		{
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			if (!string.IsNullOrEmpty(appType))
			{
				text = appType switch
				{
					"win" => Labels.AppTypeInWin, 
					"web" => Labels.AppTypeInWeb, 
					"fo" => Labels.AppTypeInFo, 
					"mob" => Labels.AppTypeInMob, 
					"api" => Labels.AppTypeInApiRegCmp, 
					_ => appType ?? "", 
				};
			}
			text = text ?? "";
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return text;
	}
}
