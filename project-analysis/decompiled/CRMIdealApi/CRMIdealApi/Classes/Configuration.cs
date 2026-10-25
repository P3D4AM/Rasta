using System;
using System.Collections.Generic;
using System.Linq;
using CRM.General.Security;
using CRMIdealApi.ApiModels;

namespace CRMIdealApi.Classes;

public static class Configuration
{
	public static string PictureDirectoryPath => "Picture";

	public static string FilesDirectoryPath => "Files";

	public static string AppType => "api";

	public static string FacadeFtp
	{
		get
		{
			string result = "";
			CRMEntities cRMEntities = new CRMEntities();
			List<ApispSelectCrmWebSetting_Result> list = Enumerable.ToList<ApispSelectCrmWebSetting_Result>((IEnumerable<ApispSelectCrmWebSetting_Result>)cRMEntities.ApispSelectCrmWebSetting());
			if (list != null)
			{
				ApispSelectCrmWebSetting_Result apispSelectCrmWebSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmWebSetting_Result>((IEnumerable<ApispSelectCrmWebSetting_Result>)list, (Func<ApispSelectCrmWebSetting_Result, bool>)((ApispSelectCrmWebSetting_Result c) => c.Key.Equals("FacadeFTP")));
				if (apispSelectCrmWebSetting_Result != null)
				{
					result = ((apispSelectCrmWebSetting_Result.Type.ToLower() == "selector") ? (apispSelectCrmWebSetting_Result.IsDecoded ? CodeDecode.DeCodding(apispSelectCrmWebSetting_Result.Value) : apispSelectCrmWebSetting_Result.Value).Split(new char[1] { ':' })[0] : ((!(apispSelectCrmWebSetting_Result.Type.ToLower() == "text")) ? (apispSelectCrmWebSetting_Result.IsDecoded ? CodeDecode.DeCodding(apispSelectCrmWebSetting_Result.Value) : apispSelectCrmWebSetting_Result.Value) : (apispSelectCrmWebSetting_Result.IsDecoded ? CodeDecode.DeCodding(apispSelectCrmWebSetting_Result.Value) : apispSelectCrmWebSetting_Result.Value)));
				}
			}
			cRMEntities?.Dispose();
			return result;
		}
	}

	public static string PathFtp
	{
		get
		{
			string result = "";
			CRMEntities cRMEntities = new CRMEntities();
			List<ApispSelectCrmWebSetting_Result> list = Enumerable.ToList<ApispSelectCrmWebSetting_Result>((IEnumerable<ApispSelectCrmWebSetting_Result>)cRMEntities.ApispSelectCrmWebSetting());
			if (list != null)
			{
				ApispSelectCrmWebSetting_Result apispSelectCrmWebSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmWebSetting_Result>((IEnumerable<ApispSelectCrmWebSetting_Result>)list, (Func<ApispSelectCrmWebSetting_Result, bool>)((ApispSelectCrmWebSetting_Result c) => c.Key.Equals("PathFTP")));
				if (apispSelectCrmWebSetting_Result != null)
				{
					result = (apispSelectCrmWebSetting_Result.IsDecoded ? CodeDecode.DeCodding(apispSelectCrmWebSetting_Result.Value) : apispSelectCrmWebSetting_Result.Value);
				}
			}
			cRMEntities?.Dispose();
			return result;
		}
	}

	public static string UserNameFtp
	{
		get
		{
			string result = "";
			CRMEntities cRMEntities = new CRMEntities();
			List<ApispSelectCrmWebSetting_Result> list = Enumerable.ToList<ApispSelectCrmWebSetting_Result>((IEnumerable<ApispSelectCrmWebSetting_Result>)cRMEntities.ApispSelectCrmWebSetting());
			if (list != null)
			{
				ApispSelectCrmWebSetting_Result apispSelectCrmWebSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmWebSetting_Result>((IEnumerable<ApispSelectCrmWebSetting_Result>)list, (Func<ApispSelectCrmWebSetting_Result, bool>)((ApispSelectCrmWebSetting_Result c) => c.Key.Equals("UserNameFTP")));
				if (apispSelectCrmWebSetting_Result != null)
				{
					result = (apispSelectCrmWebSetting_Result.IsDecoded ? CodeDecode.DeCodding(apispSelectCrmWebSetting_Result.Value) : apispSelectCrmWebSetting_Result.Value);
				}
			}
			cRMEntities?.Dispose();
			return result;
		}
	}

	public static string PasswordFtp
	{
		get
		{
			string result = "";
			CRMEntities cRMEntities = new CRMEntities();
			List<ApispSelectCrmWebSetting_Result> list = Enumerable.ToList<ApispSelectCrmWebSetting_Result>((IEnumerable<ApispSelectCrmWebSetting_Result>)cRMEntities.ApispSelectCrmWebSetting());
			if (list != null)
			{
				ApispSelectCrmWebSetting_Result apispSelectCrmWebSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmWebSetting_Result>((IEnumerable<ApispSelectCrmWebSetting_Result>)list, (Func<ApispSelectCrmWebSetting_Result, bool>)((ApispSelectCrmWebSetting_Result c) => c.Key.Equals("PasswordFTP")));
				if (apispSelectCrmWebSetting_Result != null)
				{
					result = (apispSelectCrmWebSetting_Result.IsDecoded ? CodeDecode.DeCodding(apispSelectCrmWebSetting_Result.Value) : apispSelectCrmWebSetting_Result.Value);
				}
			}
			cRMEntities?.Dispose();
			return result;
		}
	}

	public static bool UsePassiveFtp
	{
		get
		{
			bool result = true;
			CRMEntities cRMEntities = new CRMEntities();
			List<ApispSelectCrmWebSetting_Result> list = Enumerable.ToList<ApispSelectCrmWebSetting_Result>((IEnumerable<ApispSelectCrmWebSetting_Result>)cRMEntities.ApispSelectCrmWebSetting());
			if (list != null)
			{
				ApispSelectCrmWebSetting_Result apispSelectCrmWebSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmWebSetting_Result>((IEnumerable<ApispSelectCrmWebSetting_Result>)list, (Func<ApispSelectCrmWebSetting_Result, bool>)((ApispSelectCrmWebSetting_Result c) => c.Key.Equals("UsePassiveFTP")));
				if (apispSelectCrmWebSetting_Result != null)
				{
					string value = (apispSelectCrmWebSetting_Result.IsDecoded ? CodeDecode.DeCodding(apispSelectCrmWebSetting_Result.Value) : apispSelectCrmWebSetting_Result.Value);
					bool.TryParse(value, out result);
				}
			}
			cRMEntities?.Dispose();
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

	public static string PrdDirectoryPath => "Products/";

	public static string CmsNewsDirectoryPath => "CmsNews/";

	public static string CmsGalleryDirectoryPath => "CmsGallery/";

	public static string FoSettingDirectoryPath => "FoSetting/";

	public static string UploadFileDirectoryPath => "UploadFile/";

	public static string HostTempFilesPath
	{
		get
		{
			string result = "";
			CRMEntities cRMEntities = new CRMEntities();
			List<ApispSelectCrmWebSetting_Result> list = Enumerable.ToList<ApispSelectCrmWebSetting_Result>((IEnumerable<ApispSelectCrmWebSetting_Result>)cRMEntities.ApispSelectCrmWebSetting());
			if (list != null)
			{
				ApispSelectCrmWebSetting_Result apispSelectCrmWebSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmWebSetting_Result>((IEnumerable<ApispSelectCrmWebSetting_Result>)list, (Func<ApispSelectCrmWebSetting_Result, bool>)((ApispSelectCrmWebSetting_Result c) => c.Key.Equals("HostTempFilesPath")));
				if (apispSelectCrmWebSetting_Result != null)
				{
					result = (apispSelectCrmWebSetting_Result.IsDecoded ? CodeDecode.DeCodding(apispSelectCrmWebSetting_Result.Value) : apispSelectCrmWebSetting_Result.Value);
				}
			}
			cRMEntities?.Dispose();
			return result;
		}
	}

	public static string MobAppProjectName => "mobCRM";

	public static string MobHRMAppProjectName => "mobHRM";

	public static List<string> MaliciousFileExtensions
	{
		get
		{
			List<string> list = new List<string>();
			list.Add("exe");
			list.Add("dll");
			list.Add("lnk");
			list.Add("sys");
			list.Add("jar");
			list.Add("gzquar");
			list.Add("scr");
			list.Add("js");
			list.Add("com");
			list.Add("ocx");
			list.Add("bat");
			list.Add("vbs");
			list.Add("bin");
			list.Add("class");
			list.Add("ws");
			list.Add("drv");
			list.Add("ozd");
			list.Add("wmf");
			list.Add("aru");
			list.Add("shs");
			list.Add("chm");
			list.Add("dev");
			list.Add("pgm");
			list.Add("xnxx");
			list.Add("pif");
			list.Add("vbe");
			list.Add("vxd");
			list.Add("tps");
			list.Add("vba");
			list.Add("pcx");
			list.Add("0_full_0_tgod_signed");
			list.Add("boo");
			list.Add("386");
			list.Add("sop");
			list.Add("hlp");
			list.Add("tsa");
			list.Add("vb");
			list.Add("scr");
			list.Add("dxz");
			list.Add("exe1");
			list.Add("bkd");
			list.Add("exe_renamed");
			list.Add("rhk");
			list.Add("lik");
			list.Add("vbx");
			list.Add("osa");
			list.Add("cih");
			list.Add("mjz");
			list.Add(".9");
			list.Add("php3");
			list.Add("wsc");
			list.Add("dlb");
			list.Add("dyz");
			list.Add("dom");
			list.Add("hlw");
			list.Add("cla");
			list.Add("s7p");
			list.Add("mjg");
			list.Add("mfu");
			list.Add("dyv");
			list.Add("kcd");
			list.Add("spam");
			list.Add("bup");
			list.Add("rsc_tmp");
			list.Add("mcq");
			list.Add("wsh");
			list.Add("upa");
			list.Add("bhx");
			list.Add("txs");
			list.Add("bxz");
			list.Add("dli");
			list.Add("cxq");
			list.Add("xir");
			list.Add("fnr");
			list.Add("xdu");
			list.Add("wlpginstall");
			list.Add("ska");
			list.Add("cfxxe");
			list.Add("tti");
			list.Add("smtmp");
			list.Add("dllx");
			list.Add("vexe");
			list.Add("qrn");
			list.Add("xtbl");
			list.Add("fag");
			list.Add("oar");
			list.Add("ceo");
			list.Add("tko");
			list.Add("uzy");
			list.Add("bll");
			list.Add("dbd");
			list.Add("plc");
			list.Add("smm");
			list.Add("ssy");
			list.Add("blf");
			list.Add("zvz");
			list.Add("cc");
			list.Add("ce0");
			list.Add("nls");
			list.Add("ctbl");
			list.Add("hsq");
			list.Add("crypt1");
			list.Add("iws");
			list.Add("vzr");
			list.Add("lkh");
			list.Add("ezt");
			list.Add("rna");
			list.Add("aepl");
			list.Add("hts");
			list.Add("let");
			list.Add("atm");
			list.Add("fuj");
			list.Add("buk");
			list.Add("fjl");
			list.Add("aut");
			list.Add("delf");
			list.Add("bps");
			list.Add("capxml");
			list.Add("cyw");
			list.Add("bmw");
			list.Add("iva");
			list.Add("pid");
			list.Add("dx");
			list.Add("lpaq5");
			list.Add("bqf");
			list.Add("qit");
			list.Add("pr");
			list.Add("lok");
			list.Add("xnt");
			list.Add("rdb");
			return list;
		}
	}
}
