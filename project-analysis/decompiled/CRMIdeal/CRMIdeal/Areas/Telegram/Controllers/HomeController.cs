using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.Objects;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading;
using System.Web.Mvc;
using CRM.General.IO.FTP;
using CRM.General.Security;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Cache.User;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.Telegram.Controllers;

public class HomeController : Controller
{
	private CRMSpEntities _db = new CRMSpEntities();

	private CRMSpIEntities _dbI = new CRMSpIEntities();

	private CRMSpIIEntities _dbII = new CRMSpIIEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	[LoginAuthorize]
	public ActionResult Index(int position = 0, int cmpId = 0, int prsId = 0, int oprId = 0, string prsMobile = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		string text2 = "";
		string text3 = "";
		switch (position)
		{
		case 0:
			text = "frmCompanyI";
			text2 = "actGoToTelegram";
			text3 = "CMP";
			break;
		case 1:
			text = "frmPreOrder";
			text2 = "actGoToTelegram";
			text3 = "PORD";
			break;
		case 2:
			text = "frmOrder";
			text2 = "actGoToTelegram";
			text3 = "ORD";
			break;
		case 3:
			text = "frmBuyOrder";
			text2 = "actGoToTelegram";
			text3 = "BORD";
			break;
		case 4:
			text = "frmPreOrder";
			text2 = "actSendToTelegram";
			text3 = "PORD";
			break;
		case 5:
			text = "frmOrder";
			text2 = "actSendToTelegram";
			text3 = "ORD";
			break;
		case 6:
			text = "frmBuyOrder";
			text2 = "actSendToTelegram";
			text3 = "BORD";
			break;
		case 7:
			text = "frmMain";
			text2 = "actcTelegram";
			text3 = "";
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
		base.ViewBag.CmpId = cmpId;
		base.ViewBag.PrsId = prsId;
		base.ViewBag.OprName = text3;
		base.ViewBag.OprId = oprId;
		base.ViewBag.PrsMobile = prsMobile;
		GetTelegSetting();
		try
		{
			dynamic viewBag = base.ViewBag;
			DbSet<CrmFilesDirectory> crmFilesDirectory = _dbTbl.CrmFilesDirectory;
			ParameterExpression val = Expression.Parameter(typeof(CrmFilesDirectory), "c");
			viewBag.CntFileId = Queryable.Any<CrmFilesDirectory>((IQueryable<CrmFilesDirectory>)crmFilesDirectory, Expression.Lambda<Func<CrmFilesDirectory, bool>>((Expression)(object)Expression.GreaterThan((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)10, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return View();
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		base.Dispose(disposing);
	}

	public ActionResult _PartialLoadTelegProfilePicture(int settingId)
	{
		base.ViewBag.SettingId = settingId;
		return PartialView();
	}

	[AjaxOnly]
	public ActionResult _PartialTelegContact(int settingId, string searchVal = null)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		base.ViewBag.SettingId = settingId;
		List<CRMspSelectTelegContact_Result> model = new List<CRMspSelectTelegContact_Result>();
		try
		{
			searchVal = ((searchVal == "") ? null : searchVal);
			model = Enumerable.ToList<CRMspSelectTelegContact_Result>((IEnumerable<CRMspSelectTelegContact_Result>)_dbI.CRMspSelectTelegContact(0, searchVal, languageID: lCID, defaultLanguageID: result, settingId: settingId, userId: UserLogin.CurrentUser.UserId));
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return PartialView(model);
	}

	[AjaxOnly]
	public ActionResult _PartialTelegChatMessage(int mode, int chatId, int settingId, int oldChatId, int oldMainPageIndex, int mainPageIndex = 1, int pageIndex = 1, int pageSize = 20, string chatType = "Private")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int num = 0;
		int result2 = 0;
		base.ViewBag.SettingId = settingId;
		List<CRMspSelectTelegChatMessage_Result> list = new List<CRMspSelectTelegChatMessage_Result>();
		try
		{
			List<CRMspSelectTelegChatMessage_Result> list2 = TelegramMsg.Get(chatId, mainPageIndex, settingId, UserLogin.CurrentUser.UserId);
			if (Enumerable.Any<CRMspSelectTelegChatMessage_Result>((IEnumerable<CRMspSelectTelegChatMessage_Result>)list2))
			{
				list = ((list2.Count >= pageSize) ? Enumerable.ToList<CRMspSelectTelegChatMessage_Result>(Enumerable.Take<CRMspSelectTelegChatMessage_Result>(Enumerable.Skip<CRMspSelectTelegChatMessage_Result>((IEnumerable<CRMspSelectTelegChatMessage_Result>)list2, (pageIndex - 1) * pageSize), pageSize)) : Enumerable.ToList<CRMspSelectTelegChatMessage_Result>(Enumerable.Take<CRMspSelectTelegChatMessage_Result>((IEnumerable<CRMspSelectTelegChatMessage_Result>)list2, pageSize)));
			}
			if (Enumerable.Any<CRMspSelectTelegChatMessage_Result>((IEnumerable<CRMspSelectTelegChatMessage_Result>)list2))
			{
				num = ((list2.Count - list2.Count / pageSize * pageSize != 0) ? (list2.Count / pageSize + 1) : (list2.Count / pageSize));
				CRMspSelectTelegChatMessage_Result cRMspSelectTelegChatMessage_Result = Enumerable.FirstOrDefault<CRMspSelectTelegChatMessage_Result>((IEnumerable<CRMspSelectTelegChatMessage_Result>)list2);
				if (cRMspSelectTelegChatMessage_Result != null)
				{
					int.TryParse(cRMspSelectTelegChatMessage_Result.TotalPage.ToString(), out result2);
				}
			}
			foreach (CRMspSelectTelegChatMessage_Result item in list)
			{
				if (lCID != 1065)
				{
					item.DatePerWithSlash = (item.Date ?? DateTime.Now).ToString("yyyy/MM/dd", new CultureInfo("en-US"));
					item.EditDatePerWithSlash = (item.EditDate ?? DateTime.Now).ToString("yyyy/MM/dd", new CultureInfo("en-US"));
					item.SendDatePerWithSlash = (item.SendDateTime ?? DateTime.Now).ToString("yyyy/MM/dd", new CultureInfo("en-US"));
					item.SentDatePerWithSlash = (item.SentDateTime ?? DateTime.Now).ToString("yyyy/MM/dd", new CultureInfo("en-US"));
					item.ReadDatePerWithSlash = (item.ReadDateTime ?? DateTime.Now).ToString("yyyy/MM/dd", new CultureInfo("en-US"));
					item.AppType = (item.Date ?? DateTime.Now).ToString("dddd, MMMM dd, yyyy ", new CultureInfo("en-US"));
				}
				else
				{
					item.AppType = (item.Date ?? DateTime.Now).ToString("dddd, MMMM dd, yyyy ", new PersianCulture());
				}
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		base.ViewBag.TotalPage = num;
		base.ViewBag.MainTotal = result2;
		base.ViewBag.MainPageIndex = mainPageIndex;
		return PartialView(list);
	}

	[AjaxOnly]
	public int UpdateTelegChatMessage(int mode, int chatId, int settingId, string chatType = "Private")
	{
		int result = 0;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			if (mode == 1)
			{
				string appType = Configuration.AppType;
				DateTime now = DateTime.Now;
				now.ToString("yyyyMMdd", new PersianCulture());
				short.Parse(now.ToString("MM", new PersianCulture()));
				short.Parse(now.ToString("yyyy", new PersianCulture()));
				CRMSpEntities db = _db;
				int? chatId2 = chatId;
				string appType2 = appType;
				db.CRMspUpdateTelegChatMessage(chatId2, settingId, appType2);
				result = 1;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = 0;
		}
		return result;
	}

	[AjaxOnly]
	public string ActDownload(int msgId, int mode, int settingId)
	{
		string text = "";
		if (msgId != 0)
		{
			try
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
				if (result <= 0)
				{
					result = 1065;
				}
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				string text2 = "";
				string text3 = "";
				string text4 = "";
				switch (mode)
				{
				case 1:
				{
					CRMspSelectTelegChatMessage_Result cRMspSelectTelegChatMessage_Result = Enumerable.FirstOrDefault<CRMspSelectTelegChatMessage_Result>((IEnumerable<CRMspSelectTelegChatMessage_Result>)_db.CRMspSelectTelegChatMessage(0L, 0L, msgId, 0, languageID: lCID, defaultLanguageID: result, settingId: settingId, pageNumber: null, pageSize: null));
					if (cRMspSelectTelegChatMessage_Result != null)
					{
						text2 = ((!string.IsNullOrEmpty(cRMspSelectTelegChatMessage_Result.FileId)) ? (cRMspSelectTelegChatMessage_Result.FileId + ((!string.IsNullOrEmpty(cRMspSelectTelegChatMessage_Result.FileExensions)) ? cRMspSelectTelegChatMessage_Result.FileExensions : "")) : "");
						text3 = ((!string.IsNullOrEmpty(cRMspSelectTelegChatMessage_Result.DownloadFilePath)) ? cRMspSelectTelegChatMessage_Result.DownloadFilePath : "");
						text4 = (cRMspSelectTelegChatMessage_Result.CompanyId.HasValue ? cRMspSelectTelegChatMessage_Result.CompanyId.ToString() : cRMspSelectTelegChatMessage_Result.ChatId.ToString());
					}
					break;
				}
				case 2:
					text = "";
					break;
				}
				if (!string.IsNullOrEmpty(text2) && !string.IsNullOrEmpty(text4) && !string.IsNullOrEmpty(text3))
				{
					text = AppDomain.CurrentDomain.BaseDirectory + "TempFiles\\Telegram\\" + text4 + "\\" + text2;
					if (!new FacadeFTP(Configuration.FacadeFtp).Download(Configuration.PathFtp, Configuration.UserNameFtp, Configuration.PasswordFtp, text, text3, overwrite: true, Configuration.UsePassiveFtp))
					{
						text = "";
					}
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
			}
		}
		return text;
	}

	public FileResult GetProfilePictrue(int contactId, int mode, int settingId)
	{
		byte[] array = null;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			switch (mode)
			{
			case 1:
			{
				CRMspSelectTelegContact_Result cRMspSelectTelegContact_Result = Enumerable.FirstOrDefault<CRMspSelectTelegContact_Result>((IEnumerable<CRMspSelectTelegContact_Result>)_dbI.CRMspSelectTelegContact(contactId, null, languageID: lCID, defaultLanguageID: result, settingId: settingId, userId: UserLogin.CurrentUser.UserId));
				if (cRMspSelectTelegContact_Result != null)
				{
					array = cRMspSelectTelegContact_Result.Picture;
					MemoryStream memoryStream2 = new MemoryStream(array, writable: false);
					Image.FromStream((Stream)memoryStream2);
					memoryStream2.Dispose();
				}
				break;
			}
			case 2:
			{
				mct_CRMspSelectTelegBotContact_Result mct_CRMspSelectTelegBotContact_Result = Enumerable.FirstOrDefault<mct_CRMspSelectTelegBotContact_Result>((IEnumerable<mct_CRMspSelectTelegBotContact_Result>)_db.CRMspSelectTelegBotContact(contactId, null, languageID: lCID, defaultLanguageID: result, userId: UserLogin.CurrentUser.UserId));
				if (mct_CRMspSelectTelegBotContact_Result != null)
				{
					array = mct_CRMspSelectTelegBotContact_Result.Picture;
					MemoryStream memoryStream = new MemoryStream(array, writable: false);
					Image.FromStream((Stream)memoryStream);
					memoryStream.Dispose();
				}
				break;
			}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return File(array, "image/jpeg");
	}

	[AjaxOnly]
	public JsonResult ActDeleteTelegramFiles()
	{
		CommonReturnResultViewModel commonReturnResultViewModel = new CommonReturnResultViewModel();
		try
		{
			if (!UserLogin.IsUserAccess("frmTelegram", "actDeleteAllTelegramFilesFromAllUsers", UserLogin.CurrentUser))
			{
				commonReturnResultViewModel.Message = Messages.DoNotHaveAccess;
				commonReturnResultViewModel.IsDone = false;
				return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
			}
			string path = base.Server.MapPath(Configuration.HostTempFilesPath) + "\\Telegram\\";
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
			}
			commonReturnResultViewModel.Message = Messages.msgSuccessAction;
			commonReturnResultViewModel.IsDone = true;
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			commonReturnResultViewModel.Message = ex.Message;
			commonReturnResultViewModel.IsDone = false;
		}
		return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult ActDeleteTelegramFilesUser()
	{
		CommonReturnResultViewModel commonReturnResultViewModel = new CommonReturnResultViewModel();
		try
		{
			if (!UserLogin.IsUserAccess("frmTelegram", "actDeleteTelegramFilesFromCurrentUser", UserLogin.CurrentUser))
			{
				commonReturnResultViewModel.Message = Messages.DoNotHaveAccess;
				commonReturnResultViewModel.IsDone = false;
				return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
			}
			string path = base.Server.MapPath(Configuration.HostTempFilesPath) + "\\Telegram\\" + UserLogin.CurrentUser.UserId + "\\";
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
			commonReturnResultViewModel.Message = Messages.msgSuccessAction;
			commonReturnResultViewModel.IsDone = true;
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			commonReturnResultViewModel.Message = ex.Message;
			commonReturnResultViewModel.IsDone = false;
		}
		return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
	}

	public FileResult GetCompanyProfilePicture(int settingId)
	{
		byte[] array = null;
		try
		{
			CRMspSelectTelegSetting_Result cRMspSelectTelegSetting_Result = Enumerable.FirstOrDefault<CRMspSelectTelegSetting_Result>((IEnumerable<CRMspSelectTelegSetting_Result>)TelegramSeting.Get(), (Func<CRMspSelectTelegSetting_Result, bool>)((CRMspSelectTelegSetting_Result m) => m.TelegSettingId == settingId));
			if (cRMspSelectTelegSetting_Result != null)
			{
				array = cRMspSelectTelegSetting_Result.ProfilePicture;
				new MemoryStream();
				MemoryStream memoryStream = new MemoryStream(array, writable: false);
				Image.FromStream((Stream)memoryStream);
				memoryStream.Dispose();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return File(array, "image/jpeg");
	}

	[AjaxOnly]
	public JsonResult GetTelegSetting()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectTelegSetting_Result> list2 = Enumerable.ToList<CRMspSelectTelegSetting_Result>((IEnumerable<CRMspSelectTelegSetting_Result>)TelegramSeting.Get());
			list.AddRange(Enumerable.Select<CRMspSelectTelegSetting_Result, SelectListItem>((IEnumerable<CRMspSelectTelegSetting_Result>)list2, (Func<CRMspSelectTelegSetting_Result, SelectListItem>)((CRMspSelectTelegSetting_Result item) => new SelectListItem
			{
				Text = item.AppTitle,
				Value = item.TelegSettingId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.TeleSettingList = list;
		base.ViewBag.TeleSettingListJs = JsonConvert.SerializeObject(list);
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public List<CRMspSelectTelegSetting_Result> GetTelegSettingList()
	{
		List<CRMspSelectTelegSetting_Result> result = new List<CRMspSelectTelegSetting_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			result = Enumerable.ToList<CRMspSelectTelegSetting_Result>((IEnumerable<CRMspSelectTelegSetting_Result>)TelegramSeting.Get());
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[AjaxOnly]
	public JsonResult GetTelegSettingSelectListItem(int selectedId = 0)
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			List<CRMspSelectTelegSetting_Result> telegSettingList = GetTelegSettingList();
			list.AddRange(Enumerable.Select<CRMspSelectTelegSetting_Result, SelectListItem>((IEnumerable<CRMspSelectTelegSetting_Result>)telegSettingList, (Func<CRMspSelectTelegSetting_Result, SelectListItem>)((CRMspSelectTelegSetting_Result item) => new SelectListItem
			{
				Text = item.AppTitle,
				Value = item.TelegSettingId.ToString(),
				Selected = (selectedId == item.TelegSettingId)
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.TeleSettingList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult DeleteLocalTelegramInfo(int settingId)
	{
		CommonReturnResultViewModel commonReturnResultViewModel = new CommonReturnResultViewModel();
		try
		{
			if (!UserLogin.IsUserAccess("frmTelegram", "actDeleteLocalTelegramInfo", UserLogin.CurrentUser))
			{
				commonReturnResultViewModel.Message = Messages.DoNotHaveAccess;
				commonReturnResultViewModel.IsDone = false;
				return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
			}
			if (settingId < 0)
			{
				commonReturnResultViewModel.Message = Messages.msgErrorTelegramSettingIsNotSelected;
				commonReturnResultViewModel.IsDone = false;
				return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
			}
			ObjectResult<int?> objectResult = _db.CRMspDeleteLocalTelegInfo(settingId);
			int result = 0;
			int.TryParse(objectResult.ToString(), out result);
			if (result >= 0)
			{
				commonReturnResultViewModel.Message = Messages.msgSuccessAction;
				commonReturnResultViewModel.IsDone = true;
			}
			else
			{
				commonReturnResultViewModel.Message = Messages.msgErrorRunFunction;
				commonReturnResultViewModel.IsDone = false;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			commonReturnResultViewModel.Message = ex.Message;
			commonReturnResultViewModel.IsDone = false;
		}
		return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult DeleteLocalTelegramChat(int settingId, long chatId)
	{
		CommonReturnResultViewModel commonReturnResultViewModel = new CommonReturnResultViewModel();
		try
		{
			if (!UserLogin.IsUserAccess("frmTelegram", "actDeleteLocalTelegramChat", UserLogin.CurrentUser))
			{
				commonReturnResultViewModel.Message = Messages.DoNotHaveAccess;
				commonReturnResultViewModel.IsDone = false;
				return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
			}
			if (settingId < 0)
			{
				commonReturnResultViewModel.Message = Messages.msgErrorTelegramSettingIsNotSelected;
				commonReturnResultViewModel.IsDone = false;
				return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
			}
			if (chatId < 0)
			{
				commonReturnResultViewModel.Message = Messages.msgErrorTelegContactIsNotSelected;
				commonReturnResultViewModel.IsDone = false;
				return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
			}
			ObjectResult<int?> obj = _db.CRMspDeleteTelegChatMessage(2, settingId: settingId, chatId: chatId, telegChatMessageId: 0);
			int result = 0;
			int.TryParse(obj.ToString(), out result);
			if (result >= 0)
			{
				commonReturnResultViewModel.Message = Messages.msgSuccessAction;
				commonReturnResultViewModel.IsDone = true;
			}
			else
			{
				commonReturnResultViewModel.Message = Messages.msgErrorRunFunction;
				commonReturnResultViewModel.IsDone = false;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			commonReturnResultViewModel.Message = ex.Message;
			commonReturnResultViewModel.IsDone = false;
		}
		return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
	}
}
