using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Web.Mvc;
using CRM.General.Calendar;
using CRM.General.IO.FTP;
using CRM.General.Security;
using CRM.General.Utilities;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace CRMIdeal.Areas.Telegram.Controllers;

public class FileTransferController : Controller
{
	private CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	[DynamicAuthorize(ControllerName = "frmTelegram", ActionName = "actTransferTelegramFile")]
	public ActionResult SelectTransferType(int msgId, int cmpId, int prsId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		GetTransferType();
		base.ViewBag.CmpName = CRMIdeal.Classes.Helper.Company.GetCompanyNameWithTitle(cmpId);
		base.ViewBag.PrsName = CRMIdeal.Classes.Helper.Company.GetCmpPersonFullName(prsId);
		base.ViewBag.CmpId = cmpId;
		base.ViewBag.PrsId = prsId;
		base.ViewBag.MsgId = msgId;
		return View();
	}

	[AjaxOnly]
	public JsonResult GetTransferType()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			List<CRMspSelectFileDirectoryTypeOpr_Result> list2 = Enumerable.ToList<CRMspSelectFileDirectoryTypeOpr_Result>(Enumerable.Where<CRMspSelectFileDirectoryTypeOpr_Result>((IEnumerable<CRMspSelectFileDirectoryTypeOpr_Result>)_db.CRMspSelectFileDirectoryTypeOpr(lCID, result), (Func<CRMspSelectFileDirectoryTypeOpr_Result, bool>)((CRMspSelectFileDirectoryTypeOpr_Result model) => model.FileDirectoryTypeOprId != 2 && model.FileDirectoryTypeOprId != 3 && model.FileDirectoryTypeOprId != 40)));
			list.Add(new SelectListItem
			{
				Text = Labels.SelectedListDefValue,
				Value = "-1",
				Selected = true
			});
			list.AddRange(Enumerable.Select<CRMspSelectFileDirectoryTypeOpr_Result, SelectListItem>((IEnumerable<CRMspSelectFileDirectoryTypeOpr_Result>)list2, (Func<CRMspSelectFileDirectoryTypeOpr_Result, SelectListItem>)((CRMspSelectFileDirectoryTypeOpr_Result item) => new SelectListItem
			{
				Text = item.FileDirectoryTypeOpr,
				Value = item.FileDirectoryTypeOprId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.TypeList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[DynamicAuthorize(ControllerName = "frmTelegram", ActionName = "actTransferTelegramFile")]
	public ActionResult Index(int msgId, int oprId, int cmpId, int prsId, string type)
	{
		base.ViewBag.TelegMsgId = msgId;
		base.ViewBag.Type = type;
		base.ViewBag.TypeId = oprId;
		base.ViewBag.CmpName = CRMIdeal.Classes.Helper.Company.GetCompanyNameWithTitle(cmpId);
		base.ViewBag.PrsName = CRMIdeal.Classes.Helper.Company.GetCmpPersonFullName(prsId);
		return View();
	}

	[AjaxOnly]
	public ActionResult OrdersForTelegram_Read([DataSourceRequest] DataSourceRequest request, int cmpId, int typeOprId, string fromDate, string toDate)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectOperations_Result> enumerable = new List<CRMspSelectOperations_Result>();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			if (!string.IsNullOrEmpty(fromDate) && !string.IsNullOrEmpty(toDate) && typeOprId > 0 && cmpId > 0)
			{
				string text = fromDate.Replace("/", "");
				string text2 = toDate.Replace("/", "");
				DateTime value = DateTime.Parse(PersianDate.GetFormatetdDate(text.Replace("/", "")) + " 00:00:00");
				DateTime value2 = DateTime.Parse(PersianDate.GetFormatetdDate(text2.Replace("/", "")) + " 23:59:59");
				enumerable = Enumerable.ToList<CRMspSelectOperations_Result>((IEnumerable<CRMspSelectOperations_Result>)_db.CRMspSelectOperations(cmpId, UserLogin.CurrentUser.UserId, typeOprId, value, value2, lCID, result, 1, 10, result2));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(((IEnumerable)enumerable).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[HttpPost]
	public JsonResult DoTransfer(int currentId, int currentTypeOprId, int telegMsgId, int cmpId, int prsId, int prjId, string pathFileInLocal, int settingId)
	{
		CommonReturnResultViewModel commonReturnResultViewModel = new CommonReturnResultViewModel();
		commonReturnResultViewModel.IsDone = true;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
			if (defLangID <= 0)
			{
				defLangID = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int? num = null;
			if (UserLogin.CurrentUser != null)
			{
				num = UserLogin.CurrentUser.UserLastCId;
			}
			int? fileCId = null;
			if (num.GetValueOrDefault() != 0)
			{
				fileCId = num;
			}
			if (telegMsgId > 0 && !string.IsNullOrEmpty(pathFileInLocal))
			{
				if (!System.IO.File.Exists(pathFileInLocal))
				{
					commonReturnResultViewModel.IsDone = false;
					commonReturnResultViewModel.Message = Messages.msgErrorNotFilePath;
					return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
				}
				bool flag = false;
				if (settingId > 0)
				{
					CRMSpEntities db = _db;
					long? chatId = 0L;
					long? messageId = 0L;
					int? num2 = 0;
					if (Enumerable.FirstOrDefault<CRMspSelectTelegChatMessage_Result>((IEnumerable<CRMspSelectTelegChatMessage_Result>)db.CRMspSelectTelegChatMessage(telegChatMessageId: telegMsgId, telegContactId: num2, languageID: lCID, defaultLanguageID: defLangID, pageNumber: 0, pageSize: 0, chatId: chatId, messageId: messageId, settingId: settingId)) != null)
					{
						flag = true;
					}
				}
				else if (settingId == -1)
				{
					CRMSpEntities db2 = _db;
					long? chatId2 = 0L;
					long? messageId2 = 0L;
					int? num3 = 0;
					if (Enumerable.FirstOrDefault<CRMspSelectTelegBotChatMessage_Result>((IEnumerable<CRMspSelectTelegBotChatMessage_Result>)db2.CRMspSelectTelegBotChatMessage(telegBotChatMessageId: telegMsgId, telegBotContactId: num3, languageID: lCID, defaultLanguageID: defLangID, chatId: chatId2, messageId: messageId2, pageNumber: 0, pageSize: 0)) != null)
					{
						flag = true;
					}
				}
				if (flag)
				{
					DateTime now = DateTime.Now;
					CrmFilesDirectory crmFilesDirectory = new CrmFilesDirectory
					{
						UserId = UserLogin.CurrentUser.UserId,
						Year1 = short.Parse(Financial.Get().Id.ToString()),
						Month1 = short.Parse(now.ToString("MM", new PersianCulture())),
						GUId = System.Guid.NewGuid(),
						RegisterDate = now,
						RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture()),
						DocDateTime = now,
						DocTime = now.ToString("HH:mm:ss"),
						DocDay = PersianDate.GetNumberWeekOfDay(now.ToString("yyyy/MM/dd", new PersianCulture())).ToString(),
						DocDate = now.ToString("yyyyMMdd", new PersianCulture()),
						Title = Labels.TelegramTransferFileTile,
						AppType = Configuration.AppType,
						LanguageID = defLangID,
						FirstRegisterUserId = UserLogin.CurrentUser.UserId,
						FirstRegisterDate = now,
						FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture()),
						FileCId = fileCId
					};
					_dbTbl.CrmFilesDirectory.Add(crmFilesDirectory);
					_dbTbl.SaveChanges();
					if (crmFilesDirectory.FileDirectoryID > 0)
					{
						foreach (Languages item in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)Language.Get(), (Func<Languages, bool>)((Languages m) => m.LanguageID != defLangID))))
						{
							CrmFilesDirectory_Lang entity = new CrmFilesDirectory_Lang
							{
								LanguageID = item.LanguageID,
								FileDirectoryID = crmFilesDirectory.FileDirectoryID,
								Title = MyResource.GetResourceString("TelegramTransferFileTile", item.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly)
							};
							_dbTbl.CrmFilesDirectory_Lang.Add(entity);
							_dbTbl.SaveChanges();
						}
						string mainDirectoryPath = Configuration.MainDirectoryPath;
						string text = "";
						string[] array = Path.GetFileName(pathFileInLocal).Split(new char[1] { '.' });
						switch (currentTypeOprId)
						{
						case 10:
							crmFilesDirectory.FileDirectoryTypeId = -10;
							crmFilesDirectory.TypeOprObjectId = currentId;
							crmFilesDirectory.MasterId = cmpId;
							crmFilesDirectory.SubDetailId = prjId;
							crmFilesDirectory.FileName = currentId + "-" + crmFilesDirectory.FileDirectoryID + "." + array[^1];
							crmFilesDirectory.FolderName = cmpId.ToString();
							text = "";
							break;
						case 20:
							crmFilesDirectory.FileDirectoryTypeId = -20;
							crmFilesDirectory.TypeOprObjectId = currentId;
							crmFilesDirectory.MasterId = cmpId;
							crmFilesDirectory.SubDetailId = prjId;
							crmFilesDirectory.FileName = currentId + "-" + crmFilesDirectory.FileDirectoryID + "." + array[^1];
							crmFilesDirectory.FolderName = cmpId.ToString();
							text = "";
							break;
						case 30:
							crmFilesDirectory.FileDirectoryTypeId = -30;
							crmFilesDirectory.TypeOprObjectId = currentId;
							crmFilesDirectory.MasterId = cmpId;
							crmFilesDirectory.SubDetailId = prjId;
							crmFilesDirectory.FileName = currentId + "-" + crmFilesDirectory.FileDirectoryID + "." + array[^1];
							crmFilesDirectory.FolderName = cmpId.ToString();
							text = "";
							break;
						case 50:
							crmFilesDirectory.FileDirectoryTypeId = -50;
							crmFilesDirectory.TypeOprObjectId = currentId;
							crmFilesDirectory.MasterId = cmpId;
							crmFilesDirectory.SubDetailId = prjId;
							crmFilesDirectory.FileName = currentId + "-" + crmFilesDirectory.FileDirectoryID + "." + array[^1];
							crmFilesDirectory.FolderName = cmpId.ToString();
							text = "";
							break;
						case 1:
							crmFilesDirectory.FileDirectoryTypeId = -1;
							crmFilesDirectory.MasterId = cmpId;
							crmFilesDirectory.SubDetailId = prjId;
							crmFilesDirectory.FileName = cmpId + "-" + crmFilesDirectory.FileDirectoryID + "." + array[^1];
							crmFilesDirectory.FolderName = cmpId.ToString();
							break;
						}
						string text2 = mainDirectoryPath + text + crmFilesDirectory.FolderName + "/";
						string destination = mainDirectoryPath + text;
						string facadeFtp = Configuration.FacadeFtp;
						string pathFtp = Configuration.PathFtp;
						string userNameFtp = Configuration.UserNameFtp;
						string passwordFtp = Configuration.PasswordFtp;
						bool usePassiveFtp = Configuration.UsePassiveFtp;
						FacadeFTP facadeFTP = new FacadeFTP(facadeFtp);
						bool flag2 = facadeFTP.ExistsDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, destination, crmFilesDirectory.FolderName + "/", usePassiveFtp);
						if (!flag2)
						{
							flag2 = facadeFTP.CreateDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, destination, crmFilesDirectory.FolderName + "/", usePassiveFtp);
						}
						if (flag2)
						{
							if (facadeFTP.UploadFtpFormTable(pathFtp, userNameFtp, passwordFtp, text2 + crmFilesDirectory.FileName, pathFileInLocal, usePassiveFtp))
							{
								crmFilesDirectory.FilePath = text2 + crmFilesDirectory.FileName;
								_dbTbl.Entry(crmFilesDirectory).State = EntityState.Modified;
								_dbTbl.SaveChanges();
								commonReturnResultViewModel.Message = Messages.msgSuccessAction;
							}
							else
							{
								commonReturnResultViewModel.IsDone = false;
								commonReturnResultViewModel.Message = Messages.msgErrorFileTransfer;
							}
						}
						else
						{
							commonReturnResultViewModel.IsDone = false;
							commonReturnResultViewModel.Message = Messages.frmErrorInSendingFile;
						}
						if (System.IO.File.Exists(pathFileInLocal))
						{
							System.IO.File.Delete(pathFileInLocal);
						}
					}
					else
					{
						commonReturnResultViewModel.IsDone = false;
						commonReturnResultViewModel.Message = Messages.msgErrorRunFunction;
					}
				}
				else
				{
					commonReturnResultViewModel.IsDone = false;
					commonReturnResultViewModel.Message = Messages.ErrorNotFound;
				}
			}
			else
			{
				commonReturnResultViewModel.IsDone = false;
				commonReturnResultViewModel.Message = Messages.msgErrorRunFunction;
			}
		}
		catch (DbEntityValidationException ex)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)ex);
			commonReturnResultViewModel.IsDone = false;
			commonReturnResultViewModel.Message = Messages.msgErrorRunFunction + "<br />" + ((Exception)(object)ex).Message;
		}
		catch (Exception ex2)
		{
			ErrorSignal.FromCurrentContext().Raise(ex2);
			commonReturnResultViewModel.IsDone = false;
			commonReturnResultViewModel.Message = Messages.msgErrorRunFunction + "<br />" + ex2.Message;
		}
		return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		base.Dispose(disposing);
	}
}
