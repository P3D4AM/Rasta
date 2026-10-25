using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Web;
using System.Web.Mvc;
using CRM.General.IO.FTP;
using CRM.General.Security;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using Elmah;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace CRMIdeal.Areas.Cartables.Controllers;

public class VoiceRecordController : Controller
{
	private CRMSpEntities _db = new CRMSpEntities();

	[LoginAuthorize]
	public ActionResult Index(int position, int cmpId = 0)
	{
		string text = "";
		string text2 = "";
		switch (position)
		{
		case 1:
			text = "frmMain";
			text2 = "actcOpenRecordingFile";
			break;
		case 2:
			text = "frmCompanyI";
			text2 = "actShowCIVoiceRecordInformation";
			break;
		default:
			return RedirectToAction("Login", "Account", (object)new
			{
				area = "",
				d = DateTime.Now
			});
		}
		if (!UserLogin.IsUserAccess(text, text2, UserLogin.CurrentUser))
		{
			return RedirectToAction("Login", "Account", (object)new
			{
				area = "",
				d = DateTime.Now
			});
		}
		base.ViewBag.cmpId = cmpId;
		base.ViewBag.IsBuying = VersionBuyer.Recorder || VersionBuyer.CallerId;
		return View();
	}

	[AjaxOnly]
	public ActionResult _PartialVoiceRecordFiles(int cmpId = 0)
	{
		base.ViewBag.cmpId = cmpId;
		return PartialView();
	}

	[AjaxOnly]
	public ActionResult VoiceRecordFiles_Read([DataSourceRequest] DataSourceRequest request, string cmpId)
	{
		List<mct_CRMspReturnCIRecordVoiceInformation_Result> list = new List<mct_CRMspReturnCIRecordVoiceInformation_Result>();
		if (cmpId != "" && cmpId != "0")
		{
			int result = 0;
			int value = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result);
				value = UserLogin.CurrentUser.UserId;
			}
			list = Enumerable.ToList<mct_CRMspReturnCIRecordVoiceInformation_Result>((IEnumerable<mct_CRMspReturnCIRecordVoiceInformation_Result>)_db.CRMspReturnCmpCIRecordVoiceInformation(cmpId, value, result));
			foreach (mct_CRMspReturnCIRecordVoiceInformation_Result item in list)
			{
				item.CallDate = (item.CallDateTime.HasValue ? item.CallDateTime.Value.ToString("yyyy/MM/dd") : "");
			}
		}
		return Json(((IEnumerable)list).ToDataSourceResult(request));
	}

	[DynamicAuthorize(ControllerName = "frmCompanyI", ActionName = "actShowCIVoiceRecordInformation")]
	[AjaxOnly]
	public string GetFilePath(string filePath, int devType = 1)
	{
		string text = "";
		try
		{
			if (filePath != null)
			{
				devType = devType;
				string text2 = "";
				string text3 = "";
				string text4 = "";
				string text5 = "";
				string text6 = "";
				bool flag = false;
				if (!string.IsNullOrEmpty(Configuration.PathFtpRecording) && devType == 1)
				{
					text2 = filePath.ToLower().Replace(Configuration.PathFtpRecording.ToLower(), "");
					text3 = Configuration.FacadeFtpRecording;
					text4 = Configuration.PathFtpRecording;
					text5 = Configuration.UserNameFtpRecording;
					text6 = Configuration.PasswordFtpRecording;
					flag = Configuration.UsePassiveFtpRecording;
				}
				else if (!string.IsNullOrEmpty(Configuration.PathFtpRecordingII) && devType == 2)
				{
					text2 = filePath.ToLower().Replace(Configuration.PathFtpRecordingII.ToLower(), "");
					text3 = Configuration.FacadeFtpRecordingII;
					text4 = Configuration.PathFtpRecordingII;
					text5 = Configuration.UserNameFtpRecordingII;
					text6 = Configuration.PasswordFtpRecordingII;
					flag = Configuration.UsePassiveFtpRecordingII;
				}
				else
				{
					if (filePath.IndexOf("CRMRecording\\", StringComparison.Ordinal) < 0)
					{
						filePath = "CRMRecording\\" + filePath;
					}
					text2 = filePath.ToLower().Replace(Configuration.PathFtp.ToLower(), "");
					text3 = Configuration.FacadeFtp;
					text4 = Configuration.PathFtp;
					text5 = Configuration.UserNameFtp;
					text6 = Configuration.PasswordFtp;
					flag = Configuration.UsePassiveFtp;
				}
				if (text2 != "")
				{
					FilesManager filesManager = new FilesManager();
					string text7 = filesManager.SetNameDirectory(UserLogin.CurrentUser.UserId);
					if (filesManager.CreateDirectory(text7))
					{
						char c = '/';
						if (text2.Contains("\\"))
						{
							c = '\\';
						}
						else if (text2.Contains("/"))
						{
							c = '/';
						}
						string[] array = text2.Split(new char[1] { c });
						text7 += (text7.EndsWith("\\") ? "" : "\\");
						text = HttpContext.Current.Server.MapPath(text7 + array[^1]);
						if (!new FacadeFTP(text3).Download(text4, text5, text6, text, text2, overwrite: true, flag))
						{
							text = "";
							string path = HttpContext.Current.Server.MapPath(text7);
							if (Directory.Exists(path))
							{
								DirectoryInfo directoryInfo = new DirectoryInfo(path);
								FileInfo[] files = directoryInfo.GetFiles();
								for (int i = 0; i < files.Length; i++)
								{
									files[i].Delete();
								}
								DirectoryInfo[] directories = directoryInfo.GetDirectories();
								for (int i = 0; i < directories.Length; i++)
								{
									directories[i].Delete(recursive: true);
								}
								if (Directory.Exists(path))
								{
									Directory.Delete(path);
								}
							}
						}
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return text;
	}

	public string ClickToCall(string caller, string callee)
	{
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Expected O, but got Unknown
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		string text = "";
		try
		{
			string text2 = "";
			string text3 = "";
			string text4 = "";
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			string text5 = "";
			if (currentUser != null)
			{
				text5 = currentUser.CallPreNumber ?? "";
			}
			if (!string.IsNullOrWhiteSpace(text5) && !string.IsNullOrWhiteSpace(callee))
			{
				callee = text5 + callee;
			}
			if (CISetting.Get() != null)
			{
				text2 = CISetting.Get().VoipUDPIpAddress ?? "";
				text3 = CISetting.Get().VoipUDPPort ?? "";
				text4 = CISetting.Get().VoipApiType ?? "";
			}
			if (string.IsNullOrEmpty(text2))
			{
				return "false|**|" + Messages.errorInReadingSetting;
			}
			if (string.IsNullOrEmpty(caller))
			{
				return "false|**|" + string.Format(Messages.msgErrorIsNotSelectedItem, Labels.UserExtensionLbl);
			}
			if (string.IsNullOrEmpty(callee))
			{
				return "false|**|" + Messages.msgErrorNoTelNumberSelected;
			}
			if (text4.ToLower().Trim() == "host")
			{
				if (!text2.EndsWith("/"))
				{
					text2 += "/";
				}
				return text2 + "call?caller=" + caller + "&callee=" + callee;
			}
			if (string.IsNullOrEmpty(text3))
			{
				return "false|**|" + Messages.errorInReadingSetting;
			}
			UdpClient val = new UdpClient();
			IPEndPoint val2 = new IPEndPoint(IPAddress.Parse(text2), int.Parse(text3));
			byte[] bytes = Encoding.ASCII.GetBytes("call:" + caller + ":" + callee);
			val.Send(bytes, bytes.Length, val2);
			val.Close();
			return "true|**|ok";
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return "false|**|" + Messages.msgErrorRunFunction;
		}
	}

	public string ClickToCall_Old(string caller, string callee)
	{
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Expected O, but got Unknown
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		string text = "";
		try
		{
			string text2 = "";
			string text3 = "";
			if (CISetting.Get() != null)
			{
				text2 = CISetting.Get().VoipUDPIpAddress ?? "";
				text3 = CISetting.Get().VoipUDPPort ?? "";
			}
			if (string.IsNullOrEmpty(text2) || string.IsNullOrEmpty(text3))
			{
				return "false|**|" + Messages.errorInReadingSetting;
			}
			if (!string.IsNullOrEmpty(caller) && !string.IsNullOrEmpty(callee))
			{
				UdpClient val = new UdpClient();
				IPEndPoint val2 = new IPEndPoint(IPAddress.Parse(text2), int.Parse(text3));
				byte[] bytes = Encoding.ASCII.GetBytes("call:" + caller + ":" + callee);
				val.Send(bytes, bytes.Length, val2);
				val.Close();
				return "true|**|ok";
			}
			if (string.IsNullOrEmpty(caller))
			{
				return "false|**|" + string.Format(Messages.msgErrorIsNotSelectedItem, Labels.UserExtensionLbl);
			}
			if (string.IsNullOrEmpty(callee))
			{
				return "false|**|" + Messages.msgErrorNoTelNumberSelected;
			}
			return "false|**|" + Messages.msgErrorRunFunction;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return "false|**|" + Messages.msgErrorRunFunction;
		}
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		base.Dispose(disposing);
	}
}
