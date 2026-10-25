using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CRM.General.IO;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Cache.User;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.GSD.Globalization;
using Elmah;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace CRMIdeal.Areas.CompanyReport.Controllers;

public class SendCmpNotifToMobController : Controller
{
	private CRMSpEntities _db = new CRMSpEntities();

	private CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private CRMSpIIEntities _dbII = new CRMSpIIEntities();

	[DynamicAuthorize(ControllerName = "frmCompanyReport", ActionName = "actSendCmpNotifToMob")]
	public ActionResult Index()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		SendCmpNotifToMobViewModel sendCmpNotifToMobViewModel = new SendCmpNotifToMobViewModel();
		try
		{
			CRMspSelectMobSetting_Result cRMspSelectMobSetting_Result = Enumerable.FirstOrDefault<CRMspSelectMobSetting_Result>((IEnumerable<CRMspSelectMobSetting_Result>)_dbII.CRMspSelectMobSetting(lCID, result));
			if (cRMspSelectMobSetting_Result != null)
			{
				sendCmpNotifToMobViewModel.msgBody = cRMspSelectMobSetting_Result.CmpNotifCnvsDesc;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return View(sendCmpNotifToMobViewModel);
	}

	[HttpPost]
	public JsonResult ActSendCmpNotifToMob(string parameters)
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		string text = "";
		string text2 = "";
		CommonResultStatusViewModel commonResultStatusViewModel = CommonResultStatusViewModel.Success;
		CommonResultViewModel<string> data;
		try
		{
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
			if (!string.IsNullOrWhiteSpace(parameters))
			{
				SendCmpNotifToMobViewModel sendCmpNotifToMobViewModel = new JavaScriptSerializer().Deserialize<SendCmpNotifToMobViewModel>(parameters);
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
				if (result <= 0)
				{
					result = 1065;
				}
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				DateTime now = DateTime.Now;
				DateTime value = now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				short value3 = short.Parse(Financial.Get().Id.ToString());
				int userId = UserLogin.CurrentUser.UserId;
				DateTime value4 = now.AddSeconds(-7.0);
				_ = Messages.FOTicketErjaShow;
				short value5 = short.Parse(now.ToString("yyyy", new PersianCulture()));
				string registerDay = DateTimeClass.DefineDayeOfWeekStartWith7(now.DayOfWeek.ToString());
				string registerTime = now.ToString("HH:mm:ss");
				string text3 = "";
				int num = 0;
				if (!UserLogin.IsUserAccess("frmCompanyReport", "actSendCmpNotifToMob", UserLogin.CurrentUser))
				{
					text3 = text3 + Messages.ErrorNotAccess + "<br>";
					num++;
				}
				List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(sendCmpNotifToMobViewModel.msgSubject_Lang))
				{
					list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(sendCmpNotifToMobViewModel.msgSubject_Lang);
				}
				list.Add(new CommonMultiLanguageViewModel
				{
					Value = sendCmpNotifToMobViewModel.msgSubject,
					LanguageId = lCID
				});
				List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(sendCmpNotifToMobViewModel.msgBody_Lang))
				{
					list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(sendCmpNotifToMobViewModel.msgBody_Lang);
				}
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = sendCmpNotifToMobViewModel.msgBody,
					LanguageId = lCID
				});
				if (sendCmpNotifToMobViewModel.msgBody == null && sendCmpNotifToMobViewModel.msgBody == "")
				{
					text3 = text3 + string.Format(Messages.ErrorEmpty, Labels.SendCmpNotifToMobMsgBody) + "<br/>";
					num++;
				}
				else if (!checkMultiLanguage(sendCmpNotifToMobViewModel.msgBody, list2))
				{
					text3 = text3 + string.Format(Messages.CheckFieldInLang, Labels.SendCmpNotifToMobMsgBody) + "<br>";
					num++;
				}
				if (num == 0)
				{
					string text4 = "";
					string text5 = "";
					string text6 = "";
					foreach (Languages lang in Enumerable.ToList<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get()))
					{
						text5 = "";
						text6 = "";
						text5 = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : "");
						text6 = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : "");
						text4 = text4 + "MsgSubj=" + text5 + "|@#@|MsgBody=" + text6 + "|@#@|LangId=" + lang.LanguageID + "|@#@||^#^|";
					}
					ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
					string text7 = "";
					text = "";
					List<CRMspSendCompanyNotifFromRptFilterData_Result> list3 = Enumerable.ToList<CRMspSendCompanyNotifFromRptFilterData_Result>((IEnumerable<CRMspSendCompanyNotifFromRptFilterData_Result>)_dbI.CRMspSendCompanyNotifFromRptFilterData(text4, userId, value, registerDatePersian, registerDay, registerTime, value4, value5, value3, value2, appType, lCID, result, objectParameter, centerId));
					string text8 = "";
					if (objectParameter.Value != null)
					{
						text8 = objectParameter.Value.ToString();
						if (!string.IsNullOrWhiteSpace(text8))
						{
							if (text8.IndexOf("NoSetting", StringComparison.Ordinal) >= 0)
							{
								text8 = Messages.errorInReadingSetting;
							}
						}
						else if (!string.IsNullOrWhiteSpace(text8))
						{
							text8 = Messages.msgErrorRunFunction;
						}
						else if (list3 != null && Enumerable.Any<CRMspSendCompanyNotifFromRptFilterData_Result>((IEnumerable<CRMspSendCompanyNotifFromRptFilterData_Result>)list3))
						{
							text = "error";
							text7 = GetFileSendCmpNotifToMob(list3);
						}
					}
					else if (list3 != null && Enumerable.Any<CRMspSendCompanyNotifFromRptFilterData_Result>((IEnumerable<CRMspSendCompanyNotifFromRptFilterData_Result>)list3))
					{
						text = "error";
						text7 = GetFileSendCmpNotifToMob(list3);
					}
					if (!string.IsNullOrWhiteSpace(text7))
					{
						PushNotif.NewIntMsgNotify();
						PushNotif.NewIntMsgNotifyToCompanyByTank();
						commonResultStatusViewModel = CommonResultStatusViewModel.Success;
						text2 = Messages.msgNotCompeleteSuccessAction;
						text2 = text2 + "<br><a href='" + text7 + "' class='link-excel-file'>" + Messages.msgLinkForDownloadFileWithError + "</a>";
					}
					else if (!string.IsNullOrWhiteSpace(text8))
					{
						text = "";
						text2 = text8;
						commonResultStatusViewModel = CommonResultStatusViewModel.Error;
					}
					else
					{
						PushNotif.NewIntMsgNotify();
						PushNotif.NewIntMsgNotifyToCompanyByTank();
						text2 = Messages.msgSuccessAction;
						commonResultStatusViewModel = CommonResultStatusViewModel.Success;
					}
				}
				else
				{
					text = "";
					text2 = text3;
					commonResultStatusViewModel = CommonResultStatusViewModel.Error;
				}
			}
			else
			{
				text = "";
				text2 = string.Format(Messages.ErrorEmpty, Labels.SendCmpNotifToMobMsgBody);
				commonResultStatusViewModel = CommonResultStatusViewModel.Error;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			text = "";
			data = new CommonResultViewModel<string>
			{
				Data = text,
				Message = Messages.msgErrorRunFunction,
				Status = CommonResultStatusViewModel.Error
			};
			return Json(data, JsonRequestBehavior.AllowGet);
		}
		data = new CommonResultViewModel<string>
		{
			Data = text,
			Message = text2,
			Status = commonResultStatusViewModel
		};
		JsonResult jsonResult = Json(data, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public string GetFileSendCmpNotifToMob(List<CRMspSendCompanyNotifFromRptFilterData_Result> res)
	{
		//IL_034b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0366: Unknown result type (might be due to invalid IL or missing references)
		string text = "";
		Guid.NewGuid().ToString();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			short.Parse(Financial.Get().Id.ToString());
			int userId = UserLogin.CurrentUser.UserId;
			if (res != null && Enumerable.Any<CRMspSendCompanyNotifFromRptFilterData_Result>((IEnumerable<CRMspSendCompanyNotifFromRptFilterData_Result>)res))
			{
				ExcelPackage excelPackage = new ExcelPackage();
				ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets.Add(Labels.SendCmpNotifToMobExcelPropertiesTitle);
				int num = 0;
				int num2 = 1;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.SendCmpNotifToMobListCompanyName;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.SendCmpNotifToMobListCompanyNumber;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.frmError;
				foreach (CRMspSendCompanyNotifFromRptFilterData_Result re in res)
				{
					num2++;
					num = 0;
					num++;
					excelWorksheet.Cells[num2, num].Value = re.CompanyName ?? "";
					num++;
					excelWorksheet.Cells[num2, num].Value = re.cmpNumber.ToString();
					string text2 = "";
					text2 = Messages.msgErrorSendCmpNotifToMobNotPerson;
					num++;
					excelWorksheet.Cells[num2, num].Value = text2;
				}
				string text3 = base.Server.MapPath(Configuration.HostTempFilesPath) + "\\ReportSendCmpNotifToMob\\" + UserLogin.CurrentUser.UserId;
				string text4 = "CRM-Ideal-" + DateTime.Now.ToString("dd-MM-yyyy-hh-mm-ss") + ".xls";
				string path = text3 + "\\" + text4;
				try
				{
					if (System.IO.Directory.Exists(text3))
					{
						DirectoryInfo directoryInfo = new DirectoryInfo(text3);
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
						if (System.IO.Directory.Exists(text3))
						{
							System.IO.Directory.Delete(text3);
						}
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
				}
				if (!System.IO.Directory.Exists(text3))
				{
					System.IO.Directory.CreateDirectory(text3);
					CRM.General.IO.Directory.SetFullControlForEveryOne(text3);
				}
				using (ExcelRange excelRange = excelWorksheet.Cells[1, 1, 1, num])
				{
					excelRange.Style.Font.Bold = true;
					excelRange.Style.Fill.PatternType = ExcelFillStyle.Solid;
					excelRange.Style.Fill.BackgroundColor.SetColor(Color.DarkBlue);
					excelRange.Style.Font.Color.SetColor(Color.White);
				}
				excelPackage.Workbook.Properties.Title = Labels.SendCmpNotifToMobExcelPropertiesTitle;
				excelPackage.Workbook.Properties.Company = Labels.SendCmpNotifToMobExcelPropertiesCompany;
				Stream stream = System.IO.File.Create(path);
				excelPackage.SaveAs(stream);
				stream.Close();
				if (System.IO.File.Exists(path))
				{
					text = Configuration.HostTempFilesPath + "/ReportSendCmpNotifToMob/" + userId + "/" + text4;
					text = text.Replace("~/", "/");
					text = (text.StartsWith("/") ? text : ("/" + text));
				}
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return text;
	}

	public bool checkMultiLanguage(string defaultValue, List<CommonMultiLanguageViewModel> list)
	{
		bool result = true;
		List<CRMspSelectUserLanguages_Result> list2 = CRMIdeal.Cache.User.Language.Get();
		bool isCurrentUserAllowCopyOtherLanguage = UserLogin.IsCurrentUserAllowCopyOtherLanguage;
		foreach (Languages itemLang in CRMIdeal.Cache.Setting.Language.Get())
		{
			CommonMultiLanguageViewModel commonMultiLanguageViewModel = Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == itemLang.LanguageID));
			if (commonMultiLanguageViewModel == null)
			{
				if (Enumerable.Any<CRMspSelectUserLanguages_Result>((IEnumerable<CRMspSelectUserLanguages_Result>)list2, (Func<CRMspSelectUserLanguages_Result, bool>)((CRMspSelectUserLanguages_Result c) => c.LanguageID == itemLang.LanguageID)))
				{
					if (isCurrentUserAllowCopyOtherLanguage)
					{
						list.Add(new CommonMultiLanguageViewModel
						{
							LanguageId = itemLang.LanguageID,
							Value = defaultValue
						});
					}
					else
					{
						result = false;
					}
				}
				else
				{
					list.Add(new CommonMultiLanguageViewModel
					{
						LanguageId = itemLang.LanguageID,
						Value = defaultValue
					});
				}
			}
			else
			{
				if (!string.IsNullOrEmpty(commonMultiLanguageViewModel.Value))
				{
					continue;
				}
				if (Enumerable.Any<CRMspSelectUserLanguages_Result>((IEnumerable<CRMspSelectUserLanguages_Result>)list2, (Func<CRMspSelectUserLanguages_Result, bool>)((CRMspSelectUserLanguages_Result c) => c.LanguageID == itemLang.LanguageID)))
				{
					if (isCurrentUserAllowCopyOtherLanguage)
					{
						commonMultiLanguageViewModel.Value = defaultValue;
					}
					else
					{
						result = false;
					}
				}
				else
				{
					commonMultiLanguageViewModel.Value = defaultValue;
				}
			}
		}
		return result;
	}

	[HttpPost]
	public JsonResult ActSendCmpNotifToMobFo(string parameters)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		string text = "";
		string text2 = "";
		CommonResultStatusViewModel commonResultStatusViewModel = CommonResultStatusViewModel.Success;
		CommonResultViewModel<string> data;
		try
		{
			if (!string.IsNullOrWhiteSpace(parameters))
			{
				SendCmpNotifToMobViewModel sendCmpNotifToMobViewModel = new JavaScriptSerializer().Deserialize<SendCmpNotifToMobViewModel>(parameters);
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
				if (result <= 0)
				{
					result = 1065;
				}
				int currLangID = Thread.CurrentThread.CurrentCulture.LCID;
				DateTime now = DateTime.Now;
				now.ToString("yyyyMMdd", new PersianCulture());
				short.Parse(now.ToString("MM", new PersianCulture()));
				_ = Configuration.AppType;
				short.Parse(Financial.Get().Id.ToString());
				int userId = UserLogin.CurrentUser.UserId;
				now.AddSeconds(-7.0);
				_ = Messages.FOTicketErjaShow;
				short.Parse(now.ToString("yyyy", new PersianCulture()));
				DateTimeClass.DefineDayeOfWeekStartWith7(now.DayOfWeek.ToString());
				now.ToString("HH:mm:ss");
				string text3 = "";
				int num = 0;
				if (!UserLogin.IsUserAccess("frmCompanyReport", "actSendCmpNotifToMob", UserLogin.CurrentUser))
				{
					text3 = text3 + Messages.ErrorNotAccess + "<br>";
					num++;
				}
				List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(sendCmpNotifToMobViewModel.msgSubject_Lang))
				{
					list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(sendCmpNotifToMobViewModel.msgSubject_Lang);
				}
				list.Add(new CommonMultiLanguageViewModel
				{
					Value = sendCmpNotifToMobViewModel.msgSubject,
					LanguageId = currLangID
				});
				List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(sendCmpNotifToMobViewModel.msgBody_Lang))
				{
					list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(sendCmpNotifToMobViewModel.msgBody_Lang);
				}
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = sendCmpNotifToMobViewModel.msgBody,
					LanguageId = currLangID
				});
				if (sendCmpNotifToMobViewModel.msgBody == null && sendCmpNotifToMobViewModel.msgBody == "")
				{
					text3 = text3 + string.Format(Messages.ErrorEmpty, Labels.SendCmpNotifToMobMsgBody) + "<br/>";
					num++;
				}
				else if (!checkMultiLanguage(sendCmpNotifToMobViewModel.msgBody, list2))
				{
					text3 = text3 + string.Format(Messages.CheckFieldInLang, Labels.SendCmpNotifToMobMsgBody) + "<br>";
					num++;
				}
				if (num == 0)
				{
					List<CRMspSelectCompanyToSendNotifFromRptFilterData_Result> list3 = Enumerable.ToList<CRMspSelectCompanyToSendNotifFromRptFilterData_Result>((IEnumerable<CRMspSelectCompanyToSendNotifFromRptFilterData_Result>)_dbI.CRMspSelectCompanyToSendNotifFromRptFilterData(userId, currLangID, result));
					if (list3 != null && Enumerable.Any<CRMspSelectCompanyToSendNotifFromRptFilterData_Result>((IEnumerable<CRMspSelectCompanyToSendNotifFromRptFilterData_Result>)list3))
					{
						string value = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : "");
						string value2 = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : "");
						foreach (CRMspSelectCompanyToSendNotifFromRptFilterData_Result item in list3)
						{
							_ = item;
							new Dictionary<string, string>
							{
								{ "NotificationTitle", value },
								{ "NotificationBody", value2 }
							};
						}
					}
					text = "";
					text2 = Messages.msgSuccessAction;
					commonResultStatusViewModel = CommonResultStatusViewModel.Success;
				}
				else
				{
					text = "";
					text2 = text3;
					commonResultStatusViewModel = CommonResultStatusViewModel.Error;
				}
			}
			else
			{
				text = "";
				text2 = string.Format(Messages.ErrorEmpty, Labels.SendCmpNotifToMobMsgBody);
				commonResultStatusViewModel = CommonResultStatusViewModel.Error;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			text = "";
			data = new CommonResultViewModel<string>
			{
				Data = text,
				Message = Messages.msgErrorRunFunction,
				Status = CommonResultStatusViewModel.Error
			};
			return Json(data, JsonRequestBehavior.AllowGet);
		}
		data = new CommonResultViewModel<string>
		{
			Data = text,
			Message = text2,
			Status = commonResultStatusViewModel
		};
		JsonResult jsonResult = Json(data, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbI.Dispose();
		_dbTbl.Dispose();
		_dbII.Dispose();
		base.Dispose(disposing);
	}
}
