using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using CRM.General.Security;
using CRM.General.Utilities;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using Elmah;

namespace CRMIdeal.Classes.Common;

public static class Configuration
{
	private static string _cacheUniqueName = "";

	private static string _cacheDefaultName = "";

	private static string _cacheDefaultTimeInMinutes = "";

	private static string _minimumTimeoutLoginInMin = "";

	private static string _maxCountOfOnlineUser = "";

	private static string _maxCountOfOnlineUserInMob = "";

	private static string _maxCountOfOnlineUserDeActive = "";

	private static string _maxCountOfOnlineUserInHrm = "";

	private static string _maxCountWarehouse = "";

	private static string _maxCountCic = "";

	private static string _maxCountCrmShop = "";

	private static string _maxAccDbCount = "";

	private static string _maxViopCount = "";

	private static string _maxViopTrunkCount = "";

	private static string _maxFoCount = "";

	private static string _maxCenterCount = "";

	private static string _topCountCompany = "";

	private static string _topCountPreOrder = "";

	private static string _topCountOrder = "";

	public static readonly HashSet<string> MaliciousEmailFileExtensions;

	public static readonly HashSet<string> MaliciousMimeTypes;

	public static string AppType => "web";

	public static string AppTypeMailServer => "mailServer";

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
			CRMSpEntities cRMSpEntities = new CRMSpEntities();
			try
			{
				_cacheDefaultName = ApplicationSettings.GetValue("CacheDefaultName");
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
			}
			finally
			{
				cRMSpEntities.Dispose();
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
				CRMTabelEntities cRMTabelEntities = new CRMTabelEntities();
				try
				{
					CrmWebSetting crmWebSetting = Enumerable.FirstOrDefault<CrmWebSetting>((IEnumerable<CrmWebSetting>)Enumerable.ToList<CrmWebSetting>((IEnumerable<CrmWebSetting>)cRMTabelEntities.CrmWebSetting), (Func<CrmWebSetting, bool>)((CrmWebSetting c) => c.Key.Equals("CacheDefaultTimeInMinutes")));
					if (crmWebSetting != null)
					{
						_cacheDefaultTimeInMinutes = (crmWebSetting.IsDecoded ? CodeDecode.DeCodding(crmWebSetting.Value) : crmWebSetting.Value);
						int.TryParse(_cacheDefaultTimeInMinutes, out result);
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
				}
				finally
				{
					cRMTabelEntities.Dispose();
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
			List<CrmWebSetting> list = WebSetting.Get();
			if (list != null)
			{
				CrmWebSetting crmWebSetting = Enumerable.FirstOrDefault<CrmWebSetting>((IEnumerable<CrmWebSetting>)list, (Func<CrmWebSetting, bool>)((CrmWebSetting c) => c.Key.Equals("FacadeFTP")));
				if (crmWebSetting != null)
				{
					result = ((crmWebSetting.Type.ToLower() == "selector") ? (crmWebSetting.IsDecoded ? CodeDecode.DeCodding(crmWebSetting.Value) : crmWebSetting.Value).Split(new char[1] { ':' })[0] : ((!(crmWebSetting.Type.ToLower() == "text")) ? (crmWebSetting.IsDecoded ? CodeDecode.DeCodding(crmWebSetting.Value) : crmWebSetting.Value) : (crmWebSetting.IsDecoded ? CodeDecode.DeCodding(crmWebSetting.Value) : crmWebSetting.Value)));
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
			List<CrmWebSetting> list = WebSetting.Get();
			if (list != null)
			{
				CrmWebSetting crmWebSetting = Enumerable.FirstOrDefault<CrmWebSetting>((IEnumerable<CrmWebSetting>)list, (Func<CrmWebSetting, bool>)((CrmWebSetting c) => c.Key.Equals("PathFTP")));
				if (crmWebSetting != null)
				{
					result = (crmWebSetting.IsDecoded ? CodeDecode.DeCodding(crmWebSetting.Value) : crmWebSetting.Value);
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
			List<CrmWebSetting> list = WebSetting.Get();
			if (list != null)
			{
				CrmWebSetting crmWebSetting = Enumerable.FirstOrDefault<CrmWebSetting>((IEnumerable<CrmWebSetting>)list, (Func<CrmWebSetting, bool>)((CrmWebSetting c) => c.Key.Equals("UserNameFTP")));
				if (crmWebSetting != null)
				{
					result = (crmWebSetting.IsDecoded ? CodeDecode.DeCodding(crmWebSetting.Value) : crmWebSetting.Value);
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
			List<CrmWebSetting> list = WebSetting.Get();
			if (list != null)
			{
				CrmWebSetting crmWebSetting = Enumerable.FirstOrDefault<CrmWebSetting>((IEnumerable<CrmWebSetting>)list, (Func<CrmWebSetting, bool>)((CrmWebSetting c) => c.Key.Equals("PasswordFTP")));
				if (crmWebSetting != null)
				{
					result = (crmWebSetting.IsDecoded ? CodeDecode.DeCodding(crmWebSetting.Value) : crmWebSetting.Value);
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
			List<CrmWebSetting> list = WebSetting.Get();
			if (list != null)
			{
				CrmWebSetting crmWebSetting = Enumerable.FirstOrDefault<CrmWebSetting>((IEnumerable<CrmWebSetting>)list, (Func<CrmWebSetting, bool>)((CrmWebSetting c) => c.Key.Equals("UsePassiveFTP")));
				if (crmWebSetting != null)
				{
					bool.TryParse(crmWebSetting.IsDecoded ? CodeDecode.DeCodding(crmWebSetting.Value) : crmWebSetting.Value, out result);
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
			List<CrmWebSetting> list = WebSetting.Get();
			if (list != null)
			{
				CrmWebSetting crmWebSetting = Enumerable.FirstOrDefault<CrmWebSetting>((IEnumerable<CrmWebSetting>)list, (Func<CrmWebSetting, bool>)((CrmWebSetting c) => c.Key.Equals("FacadeFTPRecording")));
				if (crmWebSetting != null)
				{
					result = ((crmWebSetting.Type.ToLower() == "selector") ? (crmWebSetting.IsDecoded ? CodeDecode.DeCodding(crmWebSetting.Value) : crmWebSetting.Value).Split(new char[1] { ':' })[0] : ((!(crmWebSetting.Type.ToLower() == "text")) ? (crmWebSetting.IsDecoded ? CodeDecode.DeCodding(crmWebSetting.Value) : crmWebSetting.Value) : (crmWebSetting.IsDecoded ? CodeDecode.DeCodding(crmWebSetting.Value) : crmWebSetting.Value)));
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
			List<CrmWebSetting> list = WebSetting.Get();
			if (list != null)
			{
				CrmWebSetting crmWebSetting = Enumerable.FirstOrDefault<CrmWebSetting>((IEnumerable<CrmWebSetting>)list, (Func<CrmWebSetting, bool>)((CrmWebSetting c) => c.Key.Equals("PathFTPRecording")));
				if (crmWebSetting != null)
				{
					result = (crmWebSetting.IsDecoded ? CodeDecode.DeCodding(crmWebSetting.Value) : crmWebSetting.Value);
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
			List<CrmWebSetting> list = WebSetting.Get();
			if (list != null)
			{
				CrmWebSetting crmWebSetting = Enumerable.FirstOrDefault<CrmWebSetting>((IEnumerable<CrmWebSetting>)list, (Func<CrmWebSetting, bool>)((CrmWebSetting c) => c.Key.Equals("UserNameFTPRecording")));
				if (crmWebSetting != null)
				{
					result = (crmWebSetting.IsDecoded ? CodeDecode.DeCodding(crmWebSetting.Value) : crmWebSetting.Value);
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
			List<CrmWebSetting> list = WebSetting.Get();
			if (list != null)
			{
				CrmWebSetting crmWebSetting = Enumerable.FirstOrDefault<CrmWebSetting>((IEnumerable<CrmWebSetting>)list, (Func<CrmWebSetting, bool>)((CrmWebSetting c) => c.Key.Equals("PasswordFTPRecording")));
				if (crmWebSetting != null)
				{
					result = (crmWebSetting.IsDecoded ? CodeDecode.DeCodding(crmWebSetting.Value) : crmWebSetting.Value);
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
			List<CrmWebSetting> list = WebSetting.Get();
			if (list != null)
			{
				CrmWebSetting crmWebSetting = Enumerable.FirstOrDefault<CrmWebSetting>((IEnumerable<CrmWebSetting>)list, (Func<CrmWebSetting, bool>)((CrmWebSetting c) => c.Key.Equals("UsePassiveFTPRecording")));
				if (crmWebSetting != null)
				{
					bool.TryParse(crmWebSetting.IsDecoded ? CodeDecode.DeCodding(crmWebSetting.Value) : crmWebSetting.Value, out result);
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
			List<CrmWebSetting> list = WebSetting.Get();
			if (list != null)
			{
				CrmWebSetting crmWebSetting = Enumerable.FirstOrDefault<CrmWebSetting>((IEnumerable<CrmWebSetting>)list, (Func<CrmWebSetting, bool>)((CrmWebSetting c) => c.Key.Equals("FacadeFTPRecordingII")));
				if (crmWebSetting != null)
				{
					result = ((crmWebSetting.Type.ToLower() == "selector") ? (crmWebSetting.IsDecoded ? CodeDecode.DeCodding(crmWebSetting.Value) : crmWebSetting.Value).Split(new char[1] { ':' })[0] : ((!(crmWebSetting.Type.ToLower() == "text")) ? (crmWebSetting.IsDecoded ? CodeDecode.DeCodding(crmWebSetting.Value) : crmWebSetting.Value) : (crmWebSetting.IsDecoded ? CodeDecode.DeCodding(crmWebSetting.Value) : crmWebSetting.Value)));
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
			List<CrmWebSetting> list = WebSetting.Get();
			if (list != null)
			{
				CrmWebSetting crmWebSetting = Enumerable.FirstOrDefault<CrmWebSetting>((IEnumerable<CrmWebSetting>)list, (Func<CrmWebSetting, bool>)((CrmWebSetting c) => c.Key.Equals("PathFTPRecordingII")));
				if (crmWebSetting != null)
				{
					result = (crmWebSetting.IsDecoded ? CodeDecode.DeCodding(crmWebSetting.Value) : crmWebSetting.Value);
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
			List<CrmWebSetting> list = WebSetting.Get();
			if (list != null)
			{
				CrmWebSetting crmWebSetting = Enumerable.FirstOrDefault<CrmWebSetting>((IEnumerable<CrmWebSetting>)list, (Func<CrmWebSetting, bool>)((CrmWebSetting c) => c.Key.Equals("UserNameFTPRecordingII")));
				if (crmWebSetting != null)
				{
					result = (crmWebSetting.IsDecoded ? CodeDecode.DeCodding(crmWebSetting.Value) : crmWebSetting.Value);
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
			List<CrmWebSetting> list = WebSetting.Get();
			if (list != null)
			{
				CrmWebSetting crmWebSetting = Enumerable.FirstOrDefault<CrmWebSetting>((IEnumerable<CrmWebSetting>)list, (Func<CrmWebSetting, bool>)((CrmWebSetting c) => c.Key.Equals("PasswordFTPRecordingII")));
				if (crmWebSetting != null)
				{
					result = (crmWebSetting.IsDecoded ? CodeDecode.DeCodding(crmWebSetting.Value) : crmWebSetting.Value);
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
			List<CrmWebSetting> list = WebSetting.Get();
			if (list != null)
			{
				CrmWebSetting crmWebSetting = Enumerable.FirstOrDefault<CrmWebSetting>((IEnumerable<CrmWebSetting>)list, (Func<CrmWebSetting, bool>)((CrmWebSetting c) => c.Key.Equals("UsePassiveFTPRecordingII")));
				if (crmWebSetting != null)
				{
					bool.TryParse(crmWebSetting.IsDecoded ? CodeDecode.DeCodding(crmWebSetting.Value) : crmWebSetting.Value, out result);
				}
			}
			return result;
		}
	}

	public static string FacadeFtpFo
	{
		get
		{
			string result = "";
			List<CrmWebSetting> list = WebSetting.Get();
			if (list != null)
			{
				CrmWebSetting crmWebSetting = Enumerable.FirstOrDefault<CrmWebSetting>((IEnumerable<CrmWebSetting>)list, (Func<CrmWebSetting, bool>)((CrmWebSetting c) => c.Key.Equals("FacadeFTPFO")));
				if (crmWebSetting != null)
				{
					result = ((crmWebSetting.Type.ToLower() == "selector") ? (crmWebSetting.IsDecoded ? CodeDecode.DeCodding(crmWebSetting.Value) : crmWebSetting.Value).Split(new char[1] { ':' })[0] : ((!(crmWebSetting.Type.ToLower() == "text")) ? (crmWebSetting.IsDecoded ? CodeDecode.DeCodding(crmWebSetting.Value) : crmWebSetting.Value) : (crmWebSetting.IsDecoded ? CodeDecode.DeCodding(crmWebSetting.Value) : crmWebSetting.Value)));
				}
			}
			return result;
		}
	}

	public static string PathFtpFo
	{
		get
		{
			string result = "";
			List<CrmWebSetting> list = WebSetting.Get();
			if (list != null)
			{
				CrmWebSetting crmWebSetting = Enumerable.FirstOrDefault<CrmWebSetting>((IEnumerable<CrmWebSetting>)list, (Func<CrmWebSetting, bool>)((CrmWebSetting c) => c.Key.Equals("PathFTPFO")));
				if (crmWebSetting != null)
				{
					result = (crmWebSetting.IsDecoded ? CodeDecode.DeCodding(crmWebSetting.Value) : crmWebSetting.Value);
				}
			}
			return result;
		}
	}

	public static string UserNameFtpFo
	{
		get
		{
			string result = "";
			List<CrmWebSetting> list = WebSetting.Get();
			if (list != null)
			{
				CrmWebSetting crmWebSetting = Enumerable.FirstOrDefault<CrmWebSetting>((IEnumerable<CrmWebSetting>)list, (Func<CrmWebSetting, bool>)((CrmWebSetting c) => c.Key.Equals("UserNameFTPFO")));
				if (crmWebSetting != null)
				{
					result = (crmWebSetting.IsDecoded ? CodeDecode.DeCodding(crmWebSetting.Value) : crmWebSetting.Value);
				}
			}
			return result;
		}
	}

	public static string PasswordFtpFo
	{
		get
		{
			string result = "";
			List<CrmWebSetting> list = WebSetting.Get();
			if (list != null)
			{
				CrmWebSetting crmWebSetting = Enumerable.FirstOrDefault<CrmWebSetting>((IEnumerable<CrmWebSetting>)list, (Func<CrmWebSetting, bool>)((CrmWebSetting c) => c.Key.Equals("PasswordFTPFO")));
				if (crmWebSetting != null)
				{
					result = (crmWebSetting.IsDecoded ? CodeDecode.DeCodding(crmWebSetting.Value) : crmWebSetting.Value);
				}
			}
			return result;
		}
	}

	public static bool UsePassiveFtpFo
	{
		get
		{
			bool result = true;
			List<CrmWebSetting> list = WebSetting.Get();
			if (list != null)
			{
				CrmWebSetting crmWebSetting = Enumerable.FirstOrDefault<CrmWebSetting>((IEnumerable<CrmWebSetting>)list, (Func<CrmWebSetting, bool>)((CrmWebSetting c) => c.Key.Equals("UsePassiveFTPFO")));
				if (crmWebSetting != null)
				{
					bool.TryParse(crmWebSetting.IsDecoded ? CodeDecode.DeCodding(crmWebSetting.Value) : crmWebSetting.Value, out result);
				}
			}
			return result;
		}
	}

	public static int MinimumTimeoutLoginInMin
	{
		get
		{
			int result = 0;
			if (_minimumTimeoutLoginInMin != "")
			{
				int.TryParse(_minimumTimeoutLoginInMin, out result);
			}
			else
			{
				CRMTabelEntities cRMTabelEntities = new CRMTabelEntities();
				try
				{
					CrmWebSetting crmWebSetting = Enumerable.FirstOrDefault<CrmWebSetting>((IEnumerable<CrmWebSetting>)Enumerable.ToList<CrmWebSetting>((IEnumerable<CrmWebSetting>)cRMTabelEntities.CrmWebSetting), (Func<CrmWebSetting, bool>)((CrmWebSetting c) => c.Key.Equals("MinimumTimeoutLoginInMin")));
					if (crmWebSetting != null)
					{
						_minimumTimeoutLoginInMin = (crmWebSetting.IsDecoded ? CodeDecode.DeCodding(crmWebSetting.Value) : crmWebSetting.Value);
						int.TryParse(_minimumTimeoutLoginInMin, out result);
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
				}
				finally
				{
					cRMTabelEntities.Dispose();
				}
			}
			return result;
		}
		set
		{
			int num = value;
			_minimumTimeoutLoginInMin = num.ToString();
		}
	}

	public static string SmsWsDomainNamed => "ideal";

	public static string BeginCultureName
	{
		get
		{
			string result = "";
			List<CrmWebSetting> list = WebSetting.Get();
			if (list != null)
			{
				CrmWebSetting crmWebSetting = Enumerable.FirstOrDefault<CrmWebSetting>((IEnumerable<CrmWebSetting>)list, (Func<CrmWebSetting, bool>)((CrmWebSetting c) => c.Key.Equals("BeginCultureName")));
				if (crmWebSetting != null)
				{
					result = ((crmWebSetting.Type.ToLower() == "selector") ? (crmWebSetting.IsDecoded ? CodeDecode.DeCodding(crmWebSetting.Value) : crmWebSetting.Value).Split(new char[1] { ':' })[0] : ((!(crmWebSetting.Type.ToLower() == "text")) ? (crmWebSetting.IsDecoded ? CodeDecode.DeCodding(crmWebSetting.Value) : crmWebSetting.Value) : (crmWebSetting.IsDecoded ? CodeDecode.DeCodding(crmWebSetting.Value) : crmWebSetting.Value)));
				}
			}
			return result;
		}
	}

	public static string MainDirectoryPath => "/Files/DoNotChange/";

	public static string IntmsgDirectoryPath => "Intmsg/";

	public static string TelegDirectoryPath => "Teleg/";

	public static string KnlgTDirectoryPath => "KnlgT/";

	public static string DyDirectoryPath => "Dy/";

	public static string CnvsDirectoryPath => "Cnvs/";

	public static string FundDirectoryPath => "Fund/";

	public static string UserDirectoryPath => "Users/";

	public static string PrdDirectoryPath => "Products/";

	public static string PrdGroupDirectoryPath => "ProductGroups/";

	public static string CmsNewsDirectoryPath => "CmsNews/";

	public static string PictureDirectoryPath => "Picture";

	public static string FilesDirectoryPath => "Files";

	public static string CmsGalleryDirectoryPath => "CmsGallery/";

	public static string FoSettingDirectoryPath => "FoSetting/";

	public static string SysSettingDirectoryPath => "SysSetting/";

	public static string RecEmailDirectoryPath => "RecEmail/";

	public static string DyFormFileTmpDirectoryPath => "DyFormFileTmp/";

	public static string StockSupplyDirectoryPath => "StockSupply/";

	public static string HostTempFilesPath
	{
		get
		{
			string result = "";
			List<CrmWebSetting> list = WebSetting.Get();
			if (list != null)
			{
				CrmWebSetting crmWebSetting = Enumerable.FirstOrDefault<CrmWebSetting>((IEnumerable<CrmWebSetting>)list, (Func<CrmWebSetting, bool>)((CrmWebSetting c) => c.Key.Equals("HostTempFilesPath")));
				if (crmWebSetting != null)
				{
					result = (crmWebSetting.IsDecoded ? CodeDecode.DeCodding(crmWebSetting.Value) : crmWebSetting.Value);
				}
			}
			return result;
		}
	}

	public static string TmpFileDirectoryPath => "TmpFileDirectory/";

	public static string ForgotPassword => "Forgotten password IN FO";

	public static int MaxImageSizeForUploadKb
	{
		get
		{
			int result = 0;
			List<CrmWebSetting> list = WebSetting.Get();
			if (list != null)
			{
				CrmWebSetting crmWebSetting = Enumerable.FirstOrDefault<CrmWebSetting>((IEnumerable<CrmWebSetting>)list, (Func<CrmWebSetting, bool>)((CrmWebSetting c) => c.Key.Equals("MaxImageSizeForUploadKb")));
				if (crmWebSetting != null)
				{
					int.TryParse(crmWebSetting.IsDecoded ? CodeDecode.DeCodding(crmWebSetting.Value) : crmWebSetting.Value, out result);
				}
			}
			return result;
		}
	}

	public static int NumberConversationForMoreInfo
	{
		get
		{
			int result = 0;
			List<CrmWebSetting> list = WebSetting.Get();
			if (list != null)
			{
				CrmWebSetting crmWebSetting = Enumerable.FirstOrDefault<CrmWebSetting>((IEnumerable<CrmWebSetting>)list, (Func<CrmWebSetting, bool>)((CrmWebSetting c) => c.Key.Equals("NumberConversationForMoreInfo")));
				if (crmWebSetting != null)
				{
					int.TryParse(crmWebSetting.IsDecoded ? CodeDecode.DeCodding(crmWebSetting.Value) : crmWebSetting.Value, out result);
				}
			}
			return result;
		}
	}

	public static int MaxCountOfOnlineUser
	{
		get
		{
			int result = 0;
			if (_maxCountOfOnlineUser != "")
			{
				int.TryParse(_maxCountOfOnlineUser, out result);
			}
			else
			{
				CRMTabelEntities cRMTabelEntities = new CRMTabelEntities();
				try
				{
					CrmsysSetting crmsysSetting = Queryable.FirstOrDefault<CrmsysSetting>((IQueryable<CrmsysSetting>)cRMTabelEntities.CrmsysSetting);
					if (crmsysSetting != null)
					{
						string lockSerial = crmsysSetting.LockSerial;
						string value = ApplicationSettings.GetValue("RegisterCode");
						if (value != null)
						{
							string[] array = CodeDecode.RegDeCodding(value).Split(new char[1] { '|' });
							if (CodeDecode.RegDeCodding(array[0].Split(new char[1] { '@' })[1]) == lockSerial)
							{
								string text = CodeDecode.RegDeCodding(array[0].Split(new char[1] { '@' })[0]);
								if (!string.IsNullOrWhiteSpace(text))
								{
									string[] array2 = text.Split(new string[1] { "UsrMob" }, StringSplitOptions.None);
									if (array2 != null && array2.Length == 2)
									{
										text = array2[0];
										text = CodeDecode.RegDeCodding(text);
									}
								}
								text = text.Remove(text.Length - 5);
								text = text.Substring(6);
								_maxCountOfOnlineUser = text;
								int.TryParse(_maxCountOfOnlineUser, out result);
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
				finally
				{
					cRMTabelEntities.Dispose();
				}
			}
			return result;
		}
		set
		{
			int num = value;
			_maxCountOfOnlineUser = num.ToString();
		}
	}

	public static int MaxCountOfOnlineUserInMob
	{
		get
		{
			int result = 0;
			if (_maxCountOfOnlineUserInMob != "")
			{
				int.TryParse(_maxCountOfOnlineUserInMob, out result);
			}
			else
			{
				CRMTabelEntities cRMTabelEntities = new CRMTabelEntities();
				try
				{
					CrmsysSetting crmsysSetting = Queryable.FirstOrDefault<CrmsysSetting>((IQueryable<CrmsysSetting>)cRMTabelEntities.CrmsysSetting);
					if (crmsysSetting != null)
					{
						string lockSerial = crmsysSetting.LockSerial;
						string value = ApplicationSettings.GetValue("RegisterCode");
						if (value != null)
						{
							string[] array = CodeDecode.RegDeCodding(value).Split(new char[1] { '|' });
							if (CodeDecode.RegDeCodding(array[0].Split(new char[1] { '@' })[1]) == lockSerial)
							{
								string text = CodeDecode.RegDeCodding(array[0].Split(new char[1] { '@' })[0]);
								if (!string.IsNullOrWhiteSpace(text))
								{
									if (text.IndexOf("UsrDeAct") < 0)
									{
										string[] array2 = text.Split(new string[1] { "UsrMob" }, StringSplitOptions.None);
										if (array2 != null && array2.Length == 2)
										{
											text = array2[1];
											text = CodeDecode.RegDeCodding(text);
										}
									}
									else if (text.IndexOf("UsrDeAct") >= 0)
									{
										string[] array3 = text.Split(new string[1] { "UsrMob" }, StringSplitOptions.None);
										if (array3 != null && array3.Length == 2)
										{
											text = array3[1];
										}
										if (!string.IsNullOrWhiteSpace(text) && text.IndexOf("UsrDeAct") >= 0)
										{
											string[] array4 = text.Split(new string[1] { "UsrDeAct" }, StringSplitOptions.None);
											if (array4 != null && array4.Length == 2)
											{
												text = array4[0];
												text = CodeDecode.RegDeCodding(text);
											}
										}
									}
								}
								text = text.Remove(text.Length - 5);
								text = text.Substring(6);
								_maxCountOfOnlineUserInMob = text;
								int.TryParse(_maxCountOfOnlineUserInMob, out result);
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
				finally
				{
					cRMTabelEntities.Dispose();
				}
			}
			return result;
		}
		set
		{
			int num = value;
			_maxCountOfOnlineUserInMob = num.ToString();
		}
	}

	public static int MaxCountOfOnlineUserDeActive
	{
		get
		{
			int result = 0;
			if (_maxCountOfOnlineUserDeActive != "")
			{
				int.TryParse(_maxCountOfOnlineUserDeActive, out result);
			}
			else
			{
				CRMTabelEntities cRMTabelEntities = new CRMTabelEntities();
				try
				{
					CrmsysSetting crmsysSetting = Queryable.FirstOrDefault<CrmsysSetting>((IQueryable<CrmsysSetting>)cRMTabelEntities.CrmsysSetting);
					if (crmsysSetting != null)
					{
						string lockSerial = crmsysSetting.LockSerial;
						string value = ApplicationSettings.GetValue("RegisterCode");
						if (value != null)
						{
							string[] array = CodeDecode.RegDeCodding(value).Split(new char[1] { '|' });
							if (CodeDecode.RegDeCodding(array[0].Split(new char[1] { '@' })[1]) == lockSerial)
							{
								string text = CodeDecode.RegDeCodding(array[0].Split(new char[1] { '@' })[0]);
								if (!string.IsNullOrWhiteSpace(text))
								{
									if (text.IndexOf("UsrDeAct") < 0)
									{
										text = "0";
									}
									else if (text.IndexOf("UsrDeAct") >= 0)
									{
										string[] array2 = text.Split(new string[1] { "UsrMob" }, StringSplitOptions.None);
										if (array2 != null && array2.Length == 2)
										{
											text = array2[1];
										}
										if (!string.IsNullOrWhiteSpace(text) && text.IndexOf("UsrDeAct") >= 0)
										{
											string[] array3 = text.Split(new string[1] { "UsrDeAct" }, StringSplitOptions.None);
											if (array3 != null && array3.Length == 2)
											{
												text = array3[1];
											}
										}
										if (!string.IsNullOrWhiteSpace(text))
										{
											if (text.IndexOf("UsrHrm") >= 0)
											{
												string[] array4 = text.Split(new string[1] { "UsrHrm" }, StringSplitOptions.None);
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
								if (text != "0")
								{
									text = text.Remove(text.Length - 5);
									text = text.Substring(6);
								}
								_maxCountOfOnlineUserDeActive = text;
								int.TryParse(_maxCountOfOnlineUserDeActive, out result);
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
				finally
				{
					cRMTabelEntities.Dispose();
				}
			}
			return result;
		}
		set
		{
			int num = value;
			_maxCountOfOnlineUserDeActive = num.ToString();
		}
	}

	public static int MaxCountOfOnlineUserInHrm
	{
		get
		{
			int result = 0;
			if (_maxCountOfOnlineUserInHrm != "")
			{
				int.TryParse(_maxCountOfOnlineUserInHrm, out result);
			}
			else
			{
				CRMTabelEntities cRMTabelEntities = new CRMTabelEntities();
				try
				{
					CrmsysSetting crmsysSetting = Queryable.FirstOrDefault<CrmsysSetting>((IQueryable<CrmsysSetting>)cRMTabelEntities.CrmsysSetting);
					if (crmsysSetting != null)
					{
						string lockSerial = crmsysSetting.LockSerial;
						string value = ApplicationSettings.GetValue("RegisterCode");
						if (value != null)
						{
							string[] array = CodeDecode.RegDeCodding(value).Split(new char[1] { '|' });
							if (CodeDecode.RegDeCodding(array[0].Split(new char[1] { '@' })[1]) == lockSerial)
							{
								string text = CodeDecode.RegDeCodding(array[0].Split(new char[1] { '@' })[0]);
								if (!string.IsNullOrWhiteSpace(text))
								{
									if (text.IndexOf("UsrHrm") < 0)
									{
										text = "0";
									}
									else if (text.IndexOf("UsrHrm") >= 0)
									{
										string[] array2 = text.Split(new string[1] { "UsrMob" }, StringSplitOptions.None);
										if (array2 != null && array2.Length == 2)
										{
											text = array2[1];
										}
										if (!string.IsNullOrWhiteSpace(text) && text.IndexOf("UsrHrm") >= 0)
										{
											string[] array3 = text.Split(new string[1] { "UsrHrm" }, StringSplitOptions.None);
											if (array3 != null && array3.Length == 2)
											{
												text = array3[1];
												if (!string.IsNullOrWhiteSpace(text))
												{
													if (text.IndexOf("WhCnt") >= 0)
													{
														string[] array4 = text.Split(new string[1] { "WhCnt" }, StringSplitOptions.None);
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
								_maxCountOfOnlineUserInHrm = text;
								int.TryParse(_maxCountOfOnlineUserInHrm, out result);
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
				finally
				{
					cRMTabelEntities.Dispose();
				}
			}
			return result;
		}
		set
		{
			int num = value;
			_maxCountOfOnlineUserInHrm = num.ToString();
		}
	}

	public static int MaxCountWarehouse
	{
		get
		{
			int result = 0;
			if (_maxCountWarehouse != "")
			{
				int.TryParse(_maxCountWarehouse, out result);
			}
			else
			{
				CRMTabelEntities cRMTabelEntities = new CRMTabelEntities();
				try
				{
					CrmsysSetting crmsysSetting = Queryable.FirstOrDefault<CrmsysSetting>((IQueryable<CrmsysSetting>)cRMTabelEntities.CrmsysSetting);
					if (crmsysSetting != null)
					{
						string lockSerial = crmsysSetting.LockSerial;
						string value = ApplicationSettings.GetValue("RegisterCode");
						if (value != null)
						{
							string[] array = CodeDecode.RegDeCodding(value).Split(new char[1] { '|' });
							if (CodeDecode.RegDeCodding(array[0].Split(new char[1] { '@' })[1]) == lockSerial)
							{
								string text = CodeDecode.RegDeCodding(array[0].Split(new char[1] { '@' })[0]);
								if (!string.IsNullOrWhiteSpace(text))
								{
									if (text.IndexOf("WhCnt") < 0)
									{
										text = "0";
									}
									else if (text.IndexOf("WhCnt") >= 0)
									{
										string[] array2 = text.Split(new string[1] { "UsrMob" }, StringSplitOptions.None);
										if (array2 != null && array2.Length == 2)
										{
											text = array2[1];
										}
										if (!string.IsNullOrWhiteSpace(text) && text.IndexOf("WhCnt") >= 0)
										{
											string[] array3 = text.Split(new string[1] { "WhCnt" }, StringSplitOptions.None);
											if (array3 != null && array3.Length == 2)
											{
												text = array3[1];
												if (!string.IsNullOrWhiteSpace(text))
												{
													if (text.IndexOf("CicCnt") >= 0)
													{
														string[] array4 = text.Split(new string[1] { "CicCnt" }, StringSplitOptions.None);
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
								_maxCountWarehouse = text;
								int.TryParse(_maxCountWarehouse, out result);
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
				finally
				{
					cRMTabelEntities.Dispose();
				}
			}
			return result;
		}
		set
		{
			int num = value;
			_maxCountWarehouse = num.ToString();
		}
	}

	public static int MaxCountCic
	{
		get
		{
			int result = 0;
			if (_maxCountCic != "")
			{
				int.TryParse(_maxCountCic, out result);
			}
			else
			{
				CRMTabelEntities cRMTabelEntities = new CRMTabelEntities();
				try
				{
					CrmsysSetting crmsysSetting = Queryable.FirstOrDefault<CrmsysSetting>((IQueryable<CrmsysSetting>)cRMTabelEntities.CrmsysSetting);
					if (crmsysSetting != null)
					{
						string lockSerial = crmsysSetting.LockSerial;
						string value = ApplicationSettings.GetValue("RegisterCode");
						if (value != null)
						{
							string[] array = CodeDecode.RegDeCodding(value).Split(new char[1] { '|' });
							if (CodeDecode.RegDeCodding(array[0].Split(new char[1] { '@' })[1]) == lockSerial)
							{
								string text = CodeDecode.RegDeCodding(array[0].Split(new char[1] { '@' })[0]);
								if (!string.IsNullOrWhiteSpace(text))
								{
									if (text.IndexOf("CicCnt") < 0)
									{
										text = "0";
									}
									else if (text.IndexOf("CicCnt") >= 0)
									{
										string[] array2 = text.Split(new string[1] { "UsrMob" }, StringSplitOptions.None);
										if (array2 != null && array2.Length == 2)
										{
											text = array2[1];
										}
										if (!string.IsNullOrWhiteSpace(text) && text.IndexOf("CicCnt") >= 0)
										{
											string[] array3 = text.Split(new string[1] { "CicCnt" }, StringSplitOptions.None);
											if (array3 != null && array3.Length == 2)
											{
												text = array3[1];
												if (!string.IsNullOrWhiteSpace(text))
												{
													if (text.IndexOf("CRMShopCnt") >= 0)
													{
														string[] array4 = text.Split(new string[1] { "CRMShopCnt" }, StringSplitOptions.None);
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
								_maxCountCic = text;
								int.TryParse(_maxCountCic, out result);
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
				finally
				{
					cRMTabelEntities.Dispose();
				}
			}
			return result;
		}
		set
		{
			int num = value;
			_maxCountCic = num.ToString();
		}
	}

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
				CRMTabelEntities cRMTabelEntities = new CRMTabelEntities();
				try
				{
					CrmsysSetting crmsysSetting = Queryable.FirstOrDefault<CrmsysSetting>((IQueryable<CrmsysSetting>)cRMTabelEntities.CrmsysSetting);
					if (crmsysSetting != null)
					{
						string lockSerial = crmsysSetting.LockSerial;
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
				finally
				{
					cRMTabelEntities.Dispose();
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

	public static int MaxAccDbCount
	{
		get
		{
			int result = 0;
			if (_maxAccDbCount != "")
			{
				int.TryParse(_maxAccDbCount, out result);
			}
			else
			{
				CRMTabelEntities cRMTabelEntities = new CRMTabelEntities();
				try
				{
					CrmsysSetting crmsysSetting = Queryable.FirstOrDefault<CrmsysSetting>((IQueryable<CrmsysSetting>)cRMTabelEntities.CrmsysSetting);
					if (crmsysSetting != null)
					{
						string lockSerial = crmsysSetting.LockSerial;
						string value = ApplicationSettings.GetValue("RegisterCode");
						if (value != null)
						{
							string[] array = CodeDecode.RegDeCodding(value).Split(new char[1] { '|' });
							if (CodeDecode.RegDeCodding(array[0].Split(new char[1] { '@' })[1]) == lockSerial)
							{
								string text = CodeDecode.RegDeCodding(array[0].Split(new char[1] { '@' })[0]);
								if (!string.IsNullOrWhiteSpace(text))
								{
									if (text.IndexOf("AccDbCnt") < 0)
									{
										text = "0";
									}
									else if (text.IndexOf("AccDbCnt") >= 0)
									{
										string[] array2 = text.Split(new string[1] { "UsrMob" }, StringSplitOptions.None);
										if (array2 != null && array2.Length == 2)
										{
											text = array2[1];
										}
										if (!string.IsNullOrWhiteSpace(text) && text.IndexOf("AccDbCnt") >= 0)
										{
											string[] array3 = text.Split(new string[1] { "AccDbCnt" }, StringSplitOptions.None);
											if (array3 != null && array3.Length == 2)
											{
												text = array3[1];
												if (!string.IsNullOrWhiteSpace(text))
												{
													if (text.IndexOf("VoipCnt") >= 0)
													{
														string[] array4 = text.Split(new string[1] { "VoipCnt" }, StringSplitOptions.None);
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
								_maxAccDbCount = text;
								int.TryParse(_maxAccDbCount, out result);
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
				finally
				{
					cRMTabelEntities.Dispose();
				}
			}
			return result;
		}
		set
		{
			int num = value;
			_maxAccDbCount = num.ToString();
		}
	}

	public static int MaxViopCount
	{
		get
		{
			int result = 0;
			if (_maxViopCount != "")
			{
				int.TryParse(_maxViopCount, out result);
			}
			else
			{
				CRMTabelEntities cRMTabelEntities = new CRMTabelEntities();
				try
				{
					CrmsysSetting crmsysSetting = Queryable.FirstOrDefault<CrmsysSetting>((IQueryable<CrmsysSetting>)cRMTabelEntities.CrmsysSetting);
					if (crmsysSetting != null)
					{
						string lockSerial = crmsysSetting.LockSerial;
						string value = ApplicationSettings.GetValue("RegisterCode");
						if (value != null)
						{
							string[] array = CodeDecode.RegDeCodding(value).Split(new char[1] { '|' });
							if (CodeDecode.RegDeCodding(array[0].Split(new char[1] { '@' })[1]) == lockSerial)
							{
								string text = CodeDecode.RegDeCodding(array[0].Split(new char[1] { '@' })[0]);
								if (!string.IsNullOrWhiteSpace(text))
								{
									if (text.IndexOf("VoipCnt") < 0)
									{
										text = "0";
									}
									else if (text.IndexOf("VoipCnt") >= 0)
									{
										string[] array2 = text.Split(new string[1] { "UsrMob" }, StringSplitOptions.None);
										if (array2 != null && array2.Length == 2)
										{
											text = array2[1];
										}
										if (!string.IsNullOrWhiteSpace(text) && text.IndexOf("VoipCnt") >= 0)
										{
											string[] array3 = text.Split(new string[1] { "VoipCnt" }, StringSplitOptions.None);
											if (array3 != null && array3.Length == 2)
											{
												text = array3[1];
												if (!string.IsNullOrWhiteSpace(text))
												{
													if (text.IndexOf("VoipTunkCnt") >= 0)
													{
														string[] array4 = text.Split(new string[1] { "VoipTunkCnt" }, StringSplitOptions.None);
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
								_maxViopCount = text;
								int.TryParse(_maxViopCount, out result);
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
				finally
				{
					cRMTabelEntities.Dispose();
				}
			}
			return result;
		}
		set
		{
			int num = value;
			_maxViopCount = num.ToString();
		}
	}

	public static int MaxViopTrunkCount
	{
		get
		{
			int result = 0;
			if (_maxViopTrunkCount != "")
			{
				int.TryParse(_maxViopTrunkCount, out result);
			}
			else
			{
				CRMTabelEntities cRMTabelEntities = new CRMTabelEntities();
				try
				{
					CrmsysSetting crmsysSetting = Queryable.FirstOrDefault<CrmsysSetting>((IQueryable<CrmsysSetting>)cRMTabelEntities.CrmsysSetting);
					if (crmsysSetting != null)
					{
						string lockSerial = crmsysSetting.LockSerial;
						string value = ApplicationSettings.GetValue("RegisterCode");
						if (value != null)
						{
							string[] array = CodeDecode.RegDeCodding(value).Split(new char[1] { '|' });
							if (CodeDecode.RegDeCodding(array[0].Split(new char[1] { '@' })[1]) == lockSerial)
							{
								string text = CodeDecode.RegDeCodding(array[0].Split(new char[1] { '@' })[0]);
								if (!string.IsNullOrWhiteSpace(text))
								{
									if (text.IndexOf("VoipTunkCnt") < 0)
									{
										text = "0";
									}
									else if (text.IndexOf("VoipTunkCnt") >= 0)
									{
										string[] array2 = text.Split(new string[1] { "UsrMob" }, StringSplitOptions.None);
										if (array2 != null && array2.Length == 2)
										{
											text = array2[1];
										}
										if (!string.IsNullOrWhiteSpace(text) && text.IndexOf("VoipTunkCnt") >= 0)
										{
											string[] array3 = text.Split(new string[1] { "VoipTunkCnt" }, StringSplitOptions.None);
											if (array3 != null && array3.Length == 2)
											{
												text = array3[1];
												if (!string.IsNullOrWhiteSpace(text))
												{
													if (text.IndexOf("FoCnt") >= 0)
													{
														string[] array4 = text.Split(new string[1] { "FoCnt" }, StringSplitOptions.None);
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
								_maxViopTrunkCount = text;
								int.TryParse(_maxViopTrunkCount, out result);
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
				finally
				{
					cRMTabelEntities.Dispose();
				}
			}
			return result;
		}
		set
		{
			int num = value;
			_maxViopTrunkCount = num.ToString();
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
				CRMTabelEntities cRMTabelEntities = new CRMTabelEntities();
				try
				{
					CrmsysSetting crmsysSetting = Queryable.FirstOrDefault<CrmsysSetting>((IQueryable<CrmsysSetting>)cRMTabelEntities.CrmsysSetting);
					if (crmsysSetting != null)
					{
						string lockSerial = crmsysSetting.LockSerial;
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
				finally
				{
					cRMTabelEntities.Dispose();
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
				CRMTabelEntities cRMTabelEntities = new CRMTabelEntities();
				try
				{
					CrmsysSetting crmsysSetting = Queryable.FirstOrDefault<CrmsysSetting>((IQueryable<CrmsysSetting>)cRMTabelEntities.CrmsysSetting);
					if (crmsysSetting != null)
					{
						string lockSerial = crmsysSetting.LockSerial;
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
				finally
				{
					cRMTabelEntities.Dispose();
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

	public static int TopCountCompany
	{
		get
		{
			int result = 0;
			List<CrmWebSetting> list = WebSetting.Get();
			if (list != null)
			{
				CrmWebSetting crmWebSetting = Enumerable.FirstOrDefault<CrmWebSetting>((IEnumerable<CrmWebSetting>)list, (Func<CrmWebSetting, bool>)((CrmWebSetting c) => c.Key.Equals("TopCountCompany")));
				if (crmWebSetting != null)
				{
					_topCountCompany = (crmWebSetting.IsDecoded ? CodeDecode.DeCodding(crmWebSetting.Value) : crmWebSetting.Value);
					int.TryParse(_topCountCompany, out result);
				}
			}
			return result;
		}
		set
		{
			int num = value;
			_topCountCompany = num.ToString();
		}
	}

	public static int TopCountPreOrder
	{
		get
		{
			int result = 0;
			List<CrmWebSetting> list = WebSetting.Get();
			if (list != null)
			{
				CrmWebSetting crmWebSetting = Enumerable.FirstOrDefault<CrmWebSetting>((IEnumerable<CrmWebSetting>)list, (Func<CrmWebSetting, bool>)((CrmWebSetting c) => c.Key.Equals("TopCountPreOrder")));
				if (crmWebSetting != null)
				{
					_topCountPreOrder = (crmWebSetting.IsDecoded ? CodeDecode.DeCodding(crmWebSetting.Value) : crmWebSetting.Value);
					int.TryParse(_topCountPreOrder, out result);
				}
			}
			return result;
		}
		set
		{
			int num = value;
			_topCountPreOrder = num.ToString();
		}
	}

	public static int TopCountOrder
	{
		get
		{
			int result = 0;
			List<CrmWebSetting> list = WebSetting.Get();
			if (list != null)
			{
				CrmWebSetting crmWebSetting = Enumerable.FirstOrDefault<CrmWebSetting>((IEnumerable<CrmWebSetting>)list, (Func<CrmWebSetting, bool>)((CrmWebSetting c) => c.Key.Equals("TopCountOrder")));
				if (crmWebSetting != null)
				{
					_topCountOrder = (crmWebSetting.IsDecoded ? CodeDecode.DeCodding(crmWebSetting.Value) : crmWebSetting.Value);
					int.TryParse(_topCountOrder, out result);
				}
			}
			return result;
		}
		set
		{
			int num = value;
			_topCountOrder = num.ToString();
		}
	}

	public static string ReportDesignerDownloadPath
	{
		get
		{
			string result = "";
			List<CrmWebSetting> list = WebSetting.Get();
			if (list != null)
			{
				CrmWebSetting crmWebSetting = Enumerable.FirstOrDefault<CrmWebSetting>((IEnumerable<CrmWebSetting>)list, (Func<CrmWebSetting, bool>)((CrmWebSetting c) => c.Key.Equals("ReportDesignerDownloadPath")));
				if (crmWebSetting != null)
				{
					result = (crmWebSetting.IsDecoded ? CodeDecode.DeCodding(crmWebSetting.Value) : crmWebSetting.Value);
				}
			}
			return result;
		}
	}

	public static int MaxFileCount
	{
		get
		{
			int result = 0;
			List<CrmWebSetting> list = WebSetting.Get();
			if (list != null)
			{
				CrmWebSetting crmWebSetting = Enumerable.FirstOrDefault<CrmWebSetting>((IEnumerable<CrmWebSetting>)list, (Func<CrmWebSetting, bool>)((CrmWebSetting c) => c.Key.Equals("MaxFileCountForUpload")));
				if (crmWebSetting != null)
				{
					int.TryParse(crmWebSetting.IsDecoded ? CodeDecode.DeCodding(crmWebSetting.Value) : crmWebSetting.Value, out result);
				}
			}
			return result;
		}
	}

	public static int MaxFileSizeForUploadMb
	{
		get
		{
			int result = 0;
			List<CrmWebSetting> list = WebSetting.Get();
			if (list != null)
			{
				CrmWebSetting crmWebSetting = Enumerable.FirstOrDefault<CrmWebSetting>((IEnumerable<CrmWebSetting>)list, (Func<CrmWebSetting, bool>)((CrmWebSetting c) => c.Key.Equals("MaxFileSizeForUploadMB")));
				if (crmWebSetting != null)
				{
					int.TryParse(crmWebSetting.IsDecoded ? CodeDecode.DeCodding(crmWebSetting.Value) : crmWebSetting.Value, out result);
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
		"iva", "pid", "dx", "lpaq5", "bqf", "qit", "pr", "lok", "xnt", "rdb",
		"cmd", "ps1", "jse", "msi", "cpl", "hta", "reg", "iso", "img"
	};

	public static int FileDirectoryTitleLength => 1000;

	public static int MaxFileCountToDwonload => 10;

	public static string MobAppProjectName => "mobCRM";

	public static string MobHRMAppProjectName => "mobHRM";

	public static string MobCICAppProjectName => "mobCIC";

	public static int MaxFileSizeDyFormDigitalSignature => 20;

	public static string ExtensionFileSizeDyFormDigitalSignature => ".png,.gif,.jpg,.jpeg,.pjpeg";

	public static string KaraAfzarLockSerial => "3110-9202-2572";

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

	static Configuration()
	{
		HashSet<string> obj = new HashSet<string>((IEqualityComparer<string>)StringComparer.OrdinalIgnoreCase);
		obj.Add("exe");
		obj.Add("dll");
		obj.Add("com");
		obj.Add("scr");
		obj.Add("cpl");
		obj.Add("ocx");
		obj.Add("sys");
		obj.Add("drv");
		obj.Add("bat");
		obj.Add("cmd");
		obj.Add("vbs");
		obj.Add("vbe");
		obj.Add("js");
		obj.Add("jse");
		obj.Add("ws");
		obj.Add("wsh");
		obj.Add("wsc");
		obj.Add("wsf");
		obj.Add("hta");
		obj.Add("ps1");
		obj.Add("ps1xml");
		obj.Add("psc1");
		obj.Add("psc2");
		obj.Add("sct");
		obj.Add("prf");
		obj.Add("msi");
		obj.Add("msp");
		obj.Add("mst");
		obj.Add("reg");
		obj.Add("lnk");
		obj.Add("pif");
		obj.Add("scf");
		obj.Add("inf");
		obj.Add("jar");
		obj.Add("class");
		obj.Add("vba");
		obj.Add("xlm");
		obj.Add("docm");
		obj.Add("dotm");
		obj.Add("xlsm");
		obj.Add("xltm");
		obj.Add("xlam");
		obj.Add("pptm");
		obj.Add("ppsm");
		obj.Add("potm");
		obj.Add("sldm");
		obj.Add("xll");
		obj.Add("chm");
		obj.Add("hlp");
		obj.Add("img");
		obj.Add("vhd");
		obj.Add("vhdx");
		obj.Add("sh");
		obj.Add("bash");
		obj.Add("ksh");
		obj.Add("csh");
		obj.Add("apk");
		obj.Add("app");
		obj.Add("pkg");
		obj.Add("dmg");
		obj.Add("bin");
		obj.Add("psm1");
		obj.Add("psd1");
		obj.Add("msh");
		obj.Add("msh1");
		obj.Add("msh2");
		obj.Add("mshxml");
		obj.Add("cer");
		obj.Add("crt");
		obj.Add("php");
		obj.Add("php3");
		obj.Add("php4");
		obj.Add("php5");
		obj.Add("phtml");
		obj.Add("asp");
		obj.Add("aspx");
		obj.Add("ashx");
		obj.Add("asmx");
		obj.Add("cgi");
		obj.Add("pl");
		obj.Add("py");
		obj.Add("rb");
		obj.Add("msc");
		obj.Add("settingcontent-ms");
		obj.Add("library-ms");
		obj.Add("search-ms");
		obj.Add("url");
		obj.Add("website");
		obj.Add("shb");
		obj.Add("oft");
		obj.Add("applicationref-ms");
		obj.Add("msix");
		obj.Add("msixbundle");
		obj.Add("appinstaller");
		obj.Add("ex_");
		obj.Add("exe_");
		obj.Add("run");
		obj.Add("command");
		obj.Add("command");
		obj.Add("scpt");
		obj.Add("osax");
		obj.Add("job");
		obj.Add("fxp");
		obj.Add("node");
		obj.Add("gadget");
		obj.Add("application");
		obj.Add("action");
		obj.Add("workflow");
		MaliciousEmailFileExtensions = obj;
		HashSet<string> obj2 = new HashSet<string>((IEqualityComparer<string>)StringComparer.OrdinalIgnoreCase);
		obj2.Add("application/x-msdownload");
		obj2.Add("application/x-msdos-program");
		obj2.Add("application/x-exe");
		obj2.Add("application/octet-stream");
		obj2.Add("application/x-ms-installer");
		obj2.Add("application/x-msi");
		obj2.Add("application/javascript");
		obj2.Add("text/javascript");
		obj2.Add("application/x-javascript");
		obj2.Add("application/ecmascript");
		obj2.Add("text/ecmascript");
		obj2.Add("application/x-bat");
		obj2.Add("application/x-cmd");
		obj2.Add("application/x-powershell");
		obj2.Add("application/x-ms-wsh");
		obj2.Add("application/hta");
		obj2.Add("application/x-reg");
		obj2.Add("application/java-archive");
		obj2.Add("application/x-java-archive");
		obj2.Add("application/x-sh");
		obj2.Add("application/x-shellscript");
		obj2.Add("application/x-dosexec");
		MaliciousMimeTypes = obj2;
	}
}
