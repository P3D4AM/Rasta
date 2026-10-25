using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Objects;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CRM.General.Calendar;
using CRM.General.IO;
using CRM.General.IO.FTP;
using CRM.General.Security;
using CRM.General.Utilities;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Newtonsoft.Json;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace CRMIdeal.Areas.CompanyReport.Controllers;

public class SendSurveyController : Controller
{
	private CRMSpEntities _db = new CRMSpEntities();

	private CRMSpIEntities _dbI = new CRMSpIEntities();

	private CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private CRMSpIIEntities _dbII = new CRMSpIIEntities();

	[DynamicAuthorize(ControllerName = "frmCompanyReport", ActionName = "actSendSurvey")]
	public ActionResult Index()
	{
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		GetSurveys(10);
		GetSurveySendSetting();
		string text = MakeSurveyLink("0|0|0|0|0|0|0").ToString();
		List<SelectListItem> list = new JavaScriptSerializer().Deserialize<List<SelectListItem>>(text);
		string arg = Labels.SurveyHistorySendSmsDefText + "\n" + list[1].Value;
		base.ViewBag.FirstBodyTemp = string.Format(Labels.SendSurveySampleSmsBody, arg);
		return View(new SurveyHistoryViewModel
		{
			SelectedMode = 0
		});
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public ActionResult Index(SurveyHistoryViewModel vm)
	{
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e9e: Unknown result type (might be due to invalid IL or missing references)
		//IL_08cb: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int userId = UserLogin.CurrentUser.UserId;
		short value = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
		short value2 = short.Parse(Financial.Get().Id.ToString());
		DateTime now = DateTime.Now;
		string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
		string appType = Configuration.AppType;
		GetSurveys(10);
		GetSurveySendSetting();
		string text = MakeSurveyLink("0|0|0|0|0|0|0").ToString();
		List<SelectListItem> list = new JavaScriptSerializer().Deserialize<List<SelectListItem>>(text);
		string arg = Labels.SurveyHistorySendSmsDefText + "\n" + list[1].Value;
		base.ViewBag.FirstBodyTemp = string.Format(Labels.SendSurveySampleSmsBody, arg);
		try
		{
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
			if (vm.surhSystemPartId <= 0 || vm.surhSurveyId <= 0 || !(vm.surhDefSendSettingId > 0))
			{
				base.ViewBag.Error = Messages.msgErrorDefSettingNotMake;
				return View(vm);
			}
			if (!VersionBuyer.Survey)
			{
				DbSet<CrmSurveyHistory> crmSurveyHistory = _dbTbl.CrmSurveyHistory;
				ParameterExpression val = Expression.Parameter(typeof(CrmSurveyHistory), "c");
				if (Queryable.Any<CrmSurveyHistory>((IQueryable<CrmSurveyHistory>)crmSurveyHistory, Expression.Lambda<Func<CrmSurveyHistory, bool>>((Expression)(object)Expression.GreaterThan((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)3, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val })))
				{
					base.ViewBag.Error = "BV|" + string.Format(Messages.ImportExcelBuyModuleWithCount, "3");
					return View(vm);
				}
			}
			if (vm.surhSurveyId <= 0 && vm.surhDefSendSettingId <= 0 && vm.surhSystemPartId <= 0)
			{
				base.ViewBag.Error = Messages.msgErrorDefSettingNotMake;
				return View(vm);
			}
			DateTime dateTime = default(DateTime);
			string text2 = "";
			try
			{
				if (!string.IsNullOrEmpty(vm.surhSendDatePersian))
				{
					text2 = PersianDate.GetFormatetdDate(vm.surhSendDatePersian.Replace("/", ""));
					switch (lCID)
					{
					case 1065:
						dateTime = DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
						vm.surhSendDatePersian = dateTime.ToString("yyyyMMdd");
						break;
					case 1025:
						dateTime = DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
						vm.surhSendDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					default:
						dateTime = DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
						vm.surhSendDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					}
					vm.surhSendDate = dateTime;
				}
				else
				{
					vm.surhSendDate = null;
					vm.surhSendDatePersian = null;
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
				base.ViewBag.Error = Messages.WrongDateTime;
				return View(vm);
			}
			if (vm.surhSendDatePersian != null)
			{
				vm.surhSendDatePersian = vm.surhSendDatePersian.Replace("/", "").Replace("-", "").Replace("_", "")
					.Replace(".", "")
					.Replace(",", "")
					.Replace("\\", "");
			}
			DateTime dateTime2 = default(DateTime);
			string text3 = "";
			try
			{
				if (!string.IsNullOrEmpty(vm.surhReplyExpireDatePersian))
				{
					text3 = PersianDate.GetFormatetdDate(vm.surhReplyExpireDatePersian.Replace("/", ""));
					switch (lCID)
					{
					case 1065:
						dateTime2 = DateTime.Parse(text3 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
						vm.surhReplyExpireDatePersian = dateTime2.ToString("yyyyMMdd");
						break;
					case 1025:
						dateTime2 = DateTime.Parse(text3 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
						vm.surhReplyExpireDatePersian = dateTime2.ToString("yyyyMMdd", new PersianCulture());
						break;
					default:
						dateTime2 = DateTime.Parse(text3 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
						vm.surhReplyExpireDatePersian = dateTime2.ToString("yyyyMMdd", new PersianCulture());
						break;
					}
					vm.surhReplyExpireDate = dateTime2;
				}
				else
				{
					vm.surhReplyExpireDate = null;
					vm.surhReplyExpireDatePersian = null;
				}
			}
			catch (Exception e2)
			{
				ErrorSignal.FromCurrentContext().Raise(e2);
				base.ViewBag.Error = Messages.WrongDateTime;
				return View(vm);
			}
			if (vm.surhReplyExpireDatePersian != null)
			{
				vm.surhReplyExpireDatePersian = vm.surhReplyExpireDatePersian.Replace("/", "").Replace("-", "").Replace("_", "")
					.Replace(".", "")
					.Replace(",", "")
					.Replace("\\", "");
			}
			bool result2 = false;
			bool result3 = false;
			bool result4 = false;
			CRMspSelectSurveySendSettingWithId_Result cRMspSelectSurveySendSettingWithId_Result = Enumerable.FirstOrDefault<CRMspSelectSurveySendSettingWithId_Result>((IEnumerable<CRMspSelectSurveySendSettingWithId_Result>)_db.CRMspSelectSurveySendSettingWithId(vm.surhDefSendSettingId, lCID, result));
			if (cRMspSelectSurveySendSettingWithId_Result != null)
			{
				bool.TryParse(cRMspSelectSurveySendSettingWithId_Result.surssSmsSendByWeb.ToString(), out result2);
				bool.TryParse(cRMspSelectSurveySendSettingWithId_Result.surssSmsSendByGSM.ToString(), out result3);
				bool.TryParse(cRMspSelectSurveySendSettingWithId_Result.surssSendByEmail.ToString(), out result4);
			}
			string text4 = "";
			if (!string.IsNullOrWhiteSpace(vm.surhSendEmailBody) && result4)
			{
				text4 = ((!Thread.CurrentThread.CurrentCulture.TextInfo.IsRightToLeft) ? ("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" /> <div dir=\"ltr\">" + vm.surhSendEmailBody + "</div>") : ("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" /> <div dir=\"rtl\">" + vm.surhSendEmailBody + "</div>"));
				List<string> list2 = new List<string>();
				foreach (Match item in Regex.Matches(text4, "<img.+?src=[\"'](.+?)[\"'].+?>", (RegexOptions)3))
				{
					string value3 = ((Capture)item.Groups[1]).Value;
					if (!list2.Contains(value3))
					{
						list2.Add(value3);
					}
				}
				if (list2.Count > 0)
				{
					EmailSetting emailSetting = EmailSettings.Get();
					string text5 = ((emailSetting.EmailsAttachFilePath == null) ? "" : (emailSetting.EmailsAttachFilePath + (emailSetting.EmailsAttachFilePath.EndsWith("\\") ? "" : "\\")));
					try
					{
						string text6 = text4;
						foreach (string item2 in list2)
						{
							string text7 = item2.Replace("%2F", "/").Replace("%20", " ");
							string text8 = base.Server.MapPath(text7);
							string[] array = text8.Split(new char[1] { '.' });
							RandomText randomText = new RandomText();
							string text9 = DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + randomText.CreateRandomCode(5, WithNumber: true, false).Replace(" ", "").Trim() + "-" + DateTime.Now.ToString("yyyyMMdd") + "-" + DateTime.Now.ToString("HHmmss") + "." + array[^1];
							string newValue = text5 + text9;
							new FTPclient(Configuration.PathFtp, Configuration.UserNameFtp, Configuration.PasswordFtp, Configuration.UsePassiveFtp).Upload(text8, emailSetting.EmailsAttachShareFilePathFtp + text9);
							text6 = text6.Replace(item2, newValue);
						}
						text4 = text6;
					}
					catch (Exception e3)
					{
						ErrorSignal.FromCurrentContext().Raise(e3);
					}
				}
			}
			try
			{
				List<CRMspInsertSurveyHistoryFromCmpRep_Result> list3 = Enumerable.ToList<CRMspInsertSurveyHistoryFromCmpRep_Result>((IEnumerable<CRMspInsertSurveyHistoryFromCmpRep_Result>)_dbI.CRMspInsertSurveyHistoryFromCmpRep(vm.surhSurveyId, vm.surhDefSendSettingId, vm.surhSystemPartId, vm.surhReplyExpireDate, vm.surhReplyExpireDatePersian, vm.surhSendDate, vm.surhSendDatePersian, value2, value, now, registerDatePersian, appType, userId, lCID, result, vm.SelectedMode.GetValueOrDefault(), centerId));
				if (list3 != null && list3.Count > 0)
				{
					string text10 = JsonConvert.SerializeObject(Enumerable.ToList<CRMspInsertSurveyHistoryFromCmpRep_Result>(Enumerable.Where<CRMspInsertSurveyHistoryFromCmpRep_Result>((IEnumerable<CRMspInsertSurveyHistoryFromCmpRep_Result>)list3, (Func<CRMspInsertSurveyHistoryFromCmpRep_Result, bool>)((CRMspInsertSurveyHistoryFromCmpRep_Result x) => x.TypeError.GetValueOrDefault() < 0 || x.EmailTypeError.GetValueOrDefault() < 0))));
					base.ViewBag.SurveyHistorysErrorRecords = text10;
					base.ViewBag.SurveyHistorysErrorRecordsDownloadLink = DownloadExcelErrorRecords(text10, vm.SelectedMode.GetValueOrDefault());
				}
				if (list3 != null && Enumerable.Any<CRMspInsertSurveyHistoryFromCmpRep_Result>((IEnumerable<CRMspInsertSurveyHistoryFromCmpRep_Result>)list3))
				{
					List<CRMspInsertSurveyHistoryFromCmpRep_Result> list4 = Enumerable.ToList<CRMspInsertSurveyHistoryFromCmpRep_Result>(Enumerable.Where<CRMspInsertSurveyHistoryFromCmpRep_Result>((IEnumerable<CRMspInsertSurveyHistoryFromCmpRep_Result>)list3, (Func<CRMspInsertSurveyHistoryFromCmpRep_Result, bool>)((CRMspInsertSurveyHistoryFromCmpRep_Result x) => (x.TypeError.GetValueOrDefault() == 0 || x.EmailTypeError.GetValueOrDefault() == 0) && x.SurveyHistoryId.GetValueOrDefault() != 0)));
					string text11 = SysSeting.Get().FOUrl?.ToString() ?? "";
					if (!string.IsNullOrWhiteSpace(text11) && !text11.StartsWith("http"))
					{
						text11 = "http://" + text11;
					}
					text11 = text11.TrimEnd(new char[1] { '/' });
					if (list4 != null && list4 != null && Enumerable.Any<CRMspInsertSurveyHistoryFromCmpRep_Result>((IEnumerable<CRMspInsertSurveyHistoryFromCmpRep_Result>)list4))
					{
						DateTime now2 = DateTime.Now;
						DateTime value4 = now2;
						string text12 = now2.ToString("yyyyMMdd", new PersianCulture());
						short value5 = short.Parse(now2.ToString("MM", new PersianCulture()));
						string appType2 = Configuration.AppType;
						short value6 = short.Parse(now2.ToString("yyyy", new PersianCulture()));
						int userId2 = UserLogin.CurrentUser.UserId;
						if (!vm.surhSendDate.HasValue)
						{
							vm.surhSendDate = value4;
							vm.surhSendDatePersian = text12;
						}
						foreach (CRMspInsertSurveyHistoryFromCmpRep_Result item3 in list4)
						{
							string text13 = MakeSurveyLink(vm.surhSystemPartId + "|" + item3.CompanyId.GetValueOrDefault() + "|" + item3.CompanyId.GetValueOrDefault() + "|0|" + item3.SurveyHistoryId.GetValueOrDefault() + "|" + vm.surhSurveyId + "|0").ToString();
							if (!string.IsNullOrWhiteSpace(text13))
							{
								List<SelectListItem> list5 = new JavaScriptSerializer().Deserialize<List<SelectListItem>>(text13);
								if (list5 != null && list5.Count > 1)
								{
									Uri uri = new Uri(list5[1].Value);
									string text14 = uri.Scheme + "://" + uri.Authority;
									ObjectParameter objectParameter = new ObjectParameter("ShortKey", typeof(string));
									_dbII.CRMspInsertShortLink(list5[1].Value, 160, vm.surhSurveyId, null, null, null, null, vm.surhReplyExpireDate, null, userId, now, registerDatePersian, appType2, lCID, text14, objectParameter);
									string text15 = objectParameter.Value?.ToString();
									item3.LinkSurvey = text14 + "/s/" + text15 + " ";
								}
							}
						}
						if ((result2 || result3) && !string.IsNullOrWhiteSpace(vm.surhSendSmsBody))
						{
							int result5 = 0;
							List<CRMspInsertSurveyHistoryFromCmpRep_Result> list6 = Enumerable.ToList<CRMspInsertSurveyHistoryFromCmpRep_Result>(Enumerable.Where<CRMspInsertSurveyHistoryFromCmpRep_Result>((IEnumerable<CRMspInsertSurveyHistoryFromCmpRep_Result>)list4, (Func<CRMspInsertSurveyHistoryFromCmpRep_Result, bool>)((CRMspInsertSurveyHistoryFromCmpRep_Result x) => x.TypeError.GetValueOrDefault() == 0 && !string.IsNullOrWhiteSpace(x.cmpMainPersonMobile))));
							if (list6 != null && Enumerable.Any<CRMspInsertSurveyHistoryFromCmpRep_Result>((IEnumerable<CRMspInsertSurveyHistoryFromCmpRep_Result>)list6))
							{
								string listJson = JsonConvert.SerializeObject(Enumerable.ToList<CRMspInsertSurveyHistoryFromCmpRep_Result>((IEnumerable<CRMspInsertSurveyHistoryFromCmpRep_Result>)list6));
								mct_II_Result mct_II_Result = Enumerable.FirstOrDefault<mct_II_Result>((IEnumerable<mct_II_Result>)_dbII.CRMspInsertSmsSurveyHistoryByCmpRep(vm.surhDefSendSettingId, listJson, vm.surhSendSmsBody, vm.surhSendDate, vm.surhSendDatePersian, userId2, value6, value5, value4, text12, appType2, lCID, result, centerId));
								if (mct_II_Result != null)
								{
									int.TryParse(mct_II_Result.Result.ToString(), out result5);
									if (result5 != 1)
									{
										base.ViewBag.Error = string.Format(Messages.msgErrorInSaveItem, Labels.lblSms);
									}
								}
							}
						}
						if (result4 && !string.IsNullOrWhiteSpace(text4))
						{
							int result6 = 0;
							List<CRMspInsertSurveyHistoryFromCmpRep_Result> list7 = Enumerable.ToList<CRMspInsertSurveyHistoryFromCmpRep_Result>(Enumerable.Where<CRMspInsertSurveyHistoryFromCmpRep_Result>((IEnumerable<CRMspInsertSurveyHistoryFromCmpRep_Result>)list4, (Func<CRMspInsertSurveyHistoryFromCmpRep_Result, bool>)((CRMspInsertSurveyHistoryFromCmpRep_Result x) => x.EmailTypeError.GetValueOrDefault() == 0 && !string.IsNullOrWhiteSpace(x.cmpMainPersonEmail))));
							if (list7 != null && Enumerable.Any<CRMspInsertSurveyHistoryFromCmpRep_Result>((IEnumerable<CRMspInsertSurveyHistoryFromCmpRep_Result>)list7))
							{
								string listJson2 = JsonConvert.SerializeObject(Enumerable.ToList<CRMspInsertSurveyHistoryFromCmpRep_Result>((IEnumerable<CRMspInsertSurveyHistoryFromCmpRep_Result>)list7));
								mct_II_Result mct_II_Result2 = Enumerable.FirstOrDefault<mct_II_Result>((IEnumerable<mct_II_Result>)_dbII.CRMspInsertEmailSurveyHistoryByCmpRep(vm.surhDefSendSettingId, listJson2, text4, vm.surhSendEmailSubject, vm.surhSendDate, vm.surhSendDatePersian, userId2, value4, text12, appType2, lCID, result, centerId));
								if (mct_II_Result2 != null)
								{
									int.TryParse(mct_II_Result2.Result.ToString(), out result6);
									if (result6 != 1)
									{
										base.ViewBag.Error = string.Format(Messages.msgErrorInSaveItem, Labels.lblEmail);
									}
								}
							}
						}
					}
				}
				base.ViewBag.Successfull = Messages.msgSuccessAction;
			}
			catch (Exception ex)
			{
				ErrorSignal.FromCurrentContext().Raise(ex);
				base.ViewBag.Error = ex.Message;
				return View(vm);
			}
		}
		catch (Exception ex2)
		{
			ErrorSignal.FromCurrentContext().Raise(ex2);
			base.ViewBag.Error = ex2.Message;
			return View(vm);
		}
		return View(vm);
	}

	public string DownloadExcelErrorRecords(string json, int mode = 0)
	{
		//IL_0518: Unknown result type (might be due to invalid IL or missing references)
		//IL_0533: Unknown result type (might be due to invalid IL or missing references)
		string text = "";
		System.Guid.NewGuid().ToString();
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
			List<CRMspInsertSurveyHistoryFromCmpRep_Result> list = new List<CRMspInsertSurveyHistoryFromCmpRep_Result>();
			if (!string.IsNullOrWhiteSpace(json))
			{
				list = JsonConvert.DeserializeObject<List<CRMspInsertSurveyHistoryFromCmpRep_Result>>(json);
			}
			if (list != null && list.Count > 0)
			{
				ExcelPackage excelPackage = new ExcelPackage();
				ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets.Add(Labels.SendSurveyCRMIdeal);
				int num = 0;
				int num2 = 1;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.SendSurveyListCompanyName;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.SendSurveyListCompanyNumber;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.frmError + " (" + Labels.lblSms + ")";
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.frmError + " (" + Labels.lblEmail + ")";
				foreach (CRMspInsertSurveyHistoryFromCmpRep_Result item in list)
				{
					num2++;
					num = 0;
					num++;
					excelWorksheet.Cells[num2, num].Value = item.CompanyName ?? "";
					num++;
					excelWorksheet.Cells[num2, num].Value = item.cmpNumber.ToString();
					string value = "";
					int result2 = 0;
					int.TryParse(item.TypeError.ToString(), out result2);
					switch (mode)
					{
					case 1:
						switch (result2)
						{
						case -2:
							value = Messages.msgErrorEmptyCmpMobileNumber;
							break;
						case -3:
							value = Messages.msgErrorCmpMobileFormat;
							break;
						}
						break;
					case 2:
						switch (result2)
						{
						case -1:
							value = Messages.msgErrorEmptyPerson;
							break;
						case -2:
							value = Messages.msgErrorEmptyPersonMobileNumber;
							break;
						case -3:
							value = Messages.msgErrorPersonMobileFormat;
							break;
						}
						break;
					default:
						switch (result2)
						{
						case -1:
							value = Messages.msgErrorEmptyMainPerson;
							break;
						case -2:
							value = Messages.msgErrorEmptyMainPersonMobileNumber;
							break;
						case -3:
							value = Messages.msgErrorMainPersonMobileFormat;
							break;
						}
						break;
					}
					num++;
					excelWorksheet.Cells[num2, num].Value = value;
					string value2 = "";
					int result3 = 0;
					int.TryParse(item.EmailTypeError.ToString(), out result3);
					switch (mode)
					{
					case 1:
						switch (result3)
						{
						case -2:
							value2 = Messages.msgErrorEmptyCmpEmail;
							break;
						case -3:
							value2 = Messages.msgErrorCmpEmailFormat;
							break;
						}
						break;
					case 2:
						switch (result3)
						{
						case -1:
							value2 = Messages.msgErrorEmptyPerson;
							break;
						case -2:
							value2 = Messages.msgErrorPersonEmail;
							break;
						case -3:
							value2 = Messages.msgErrorPersonEmailFormat;
							break;
						}
						break;
					default:
						switch (result3)
						{
						case -1:
							value2 = Messages.msgErrorEmptyMainPerson;
							break;
						case -2:
							value2 = Messages.msgErrorEmptyMainPersonEmail;
							break;
						case -3:
							value2 = Messages.msgErrorMainPersonEmailFormat;
							break;
						}
						break;
					}
					num++;
					excelWorksheet.Cells[num2, num].Value = value2;
				}
				string text2 = base.Server.MapPath(Configuration.HostTempFilesPath) + "\\ReportSendSurveyHistorys\\" + UserLogin.CurrentUser.UserId;
				string text3 = "CRM-Ideal-" + DateTime.Now.ToString("dd-MM-yyyy-hh-mm-ss") + ".xls";
				string path = text2 + "\\" + text3;
				try
				{
					DirectoryInfo directoryInfo = new DirectoryInfo(text2);
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
					if (System.IO.Directory.Exists(text2))
					{
						System.IO.Directory.Delete(text2);
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
				}
				if (!System.IO.Directory.Exists(text2))
				{
					System.IO.Directory.CreateDirectory(text2);
					CRM.General.IO.Directory.SetFullControlForEveryOne(text2);
				}
				using (ExcelRange excelRange = excelWorksheet.Cells[1, 1, 1, num])
				{
					excelRange.Style.Font.Bold = true;
					excelRange.Style.Fill.PatternType = ExcelFillStyle.Solid;
					excelRange.Style.Fill.BackgroundColor.SetColor(Color.DarkBlue);
					excelRange.Style.Font.Color.SetColor(Color.White);
				}
				excelPackage.Workbook.Properties.Title = Labels.SendSurveyCRMIdeal;
				excelPackage.Workbook.Properties.Company = Labels.SendSurveyKaraAfzar;
				Stream stream = System.IO.File.Create(path);
				excelPackage.SaveAs(stream);
				stream.Close();
				if (System.IO.File.Exists(path))
				{
					text = Configuration.HostTempFilesPath + "/ReportSendSurveyHistorys/" + userId + "/" + text3;
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

	public string MakeSurveyLink(string token = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		if (!string.IsNullOrWhiteSpace(token))
		{
			int result2 = 0;
			int.TryParse(token.Split(new char[1] { '|' })[5], out result2);
			Uri url = base.HttpContext.Request.Url;
			string text = url.Scheme + "://" + url.Authority;
			string text2 = "";
			text = text + "/Survey/Home/SurveyAnswerValues?token=" + Code(token);
			list.Add(new SelectListItem
			{
				Text = Labels.InternalLink,
				Value = text,
				Selected = false
			});
			CRMspSelectSurveyWithId_Result cRMspSelectSurveyWithId_Result = Enumerable.FirstOrDefault<CRMspSelectSurveyWithId_Result>((IEnumerable<CRMspSelectSurveyWithId_Result>)_db.CRMspSelectSurveyWithId(result2, lCID, result));
			if (cRMspSelectSurveyWithId_Result != null)
			{
				CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<CRMspSelectCrmsysSetting_Result>((IEnumerable<CRMspSelectCrmsysSetting_Result>)_db.CRMspSelectCrmsysSetting(lCID, result));
				if (cRMspSelectSurveyWithId_Result.surReplyAfterLogin.GetValueOrDefault())
				{
					if (cRMspSelectCrmsysSetting_Result != null && !string.IsNullOrWhiteSpace(cRMspSelectCrmsysSetting_Result.FOUrl))
					{
						text2 = cRMspSelectCrmsysSetting_Result.FOUrl.Trim();
						if (!text2.Contains("http"))
						{
							text2 = url.Scheme + "://" + text2;
						}
						if (text2.EndsWith("/"))
						{
							text2 = text2.Substring(0, text2.Length - 1);
						}
						text2 = text2 + "/Survey/Home/Index?token=" + Code(token);
					}
					else
					{
						text2 = text;
					}
				}
				else if (cRMspSelectCrmsysSetting_Result != null && !string.IsNullOrWhiteSpace(cRMspSelectCrmsysSetting_Result.CrmIPStatic))
				{
					text2 = cRMspSelectCrmsysSetting_Result.CrmIPStatic.Trim();
					if (!text2.Contains("http"))
					{
						text2 = url.Scheme + "://" + text2;
					}
					if (text2.EndsWith("/"))
					{
						text2 = text2.Substring(0, text2.Length - 1);
					}
					text2 = text2 + "/Survey/Register/Index?token=" + Code(token);
				}
				else
				{
					text2 = text;
				}
			}
			else
			{
				text2 = text;
			}
			list.Add(new SelectListItem
			{
				Text = Labels.ExternalLink + "(" + Labels.ExternalLinkDescForSendAllOutUsers + ")",
				Value = text2,
				Selected = false
			});
		}
		return JsonConvert.SerializeObject(list);
	}

	public string Code(string val = "")
	{
		string result = "";
		if (!string.IsNullOrWhiteSpace(val))
		{
			try
			{
				result = CodeDecode.CoddingUTF8(val);
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
			}
		}
		return result;
	}

	public string DeCode(string val = "")
	{
		string result = "";
		if (!string.IsNullOrWhiteSpace(val))
		{
			try
			{
				result = CodeDecode.DeCoddingUTF8(val);
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
			}
		}
		return result;
	}

	public List<SelectListItem> GetSystemParts(int currLangId = 1065, int defLangId = 1065)
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			List<CRMspSelectActiveSystemParts_Result> list2 = Enumerable.ToList<CRMspSelectActiveSystemParts_Result>(Enumerable.Where<CRMspSelectActiveSystemParts_Result>((IEnumerable<CRMspSelectActiveSystemParts_Result>)_dbI.CRMspSelectActiveSystemParts(currLangId, defLangId, "1,10,11,12,13,20,30,40,50,51,60,61,62,70,80,90,95"), (Func<CRMspSelectActiveSystemParts_Result, bool>)((CRMspSelectActiveSystemParts_Result m) => m.Type == "CRM")));
			if (list2 != null)
			{
				foreach (CRMspSelectActiveSystemParts_Result item in list2)
				{
					SelectListItem selectListItem = new SelectListItem();
					selectListItem.Text = item.PartTitle;
					selectListItem.Value = item.SystemPartId.ToString();
					selectListItem.Selected = false;
					list.Add(selectListItem);
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.SysPartsList = list;
		return list;
	}

	[AjaxOnly]
	public JsonResult GetSurveys(int systemPartId)
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			List<CRMspSelectSurvey_Result> list2 = Enumerable.ToList<CRMspSelectSurvey_Result>(Enumerable.Where<CRMspSelectSurvey_Result>((IEnumerable<CRMspSelectSurvey_Result>)_db.CRMspSelectSurvey(lCID, result, result2), (Func<CRMspSelectSurvey_Result, bool>)((CRMspSelectSurvey_Result m) => m.surSystemPartId == systemPartId && !m.surInactive.GetValueOrDefault())));
			list.AddRange(Enumerable.Select<CRMspSelectSurvey_Result, SelectListItem>((IEnumerable<CRMspSelectSurvey_Result>)list2, (Func<CRMspSelectSurvey_Result, SelectListItem>)((CRMspSelectSurvey_Result item) => new SelectListItem
			{
				Text = item.surTitle,
				Value = item.SurveyId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.SurveysList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public List<SelectListItem> GetSurveySendSetting()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectSurveySendSetting_Result> list2 = Enumerable.ToList<CRMspSelectSurveySendSetting_Result>((IEnumerable<CRMspSelectSurveySendSetting_Result>)_db.CRMspSelectSurveySendSetting(lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectSurveySendSetting_Result, SelectListItem>((IEnumerable<CRMspSelectSurveySendSetting_Result>)list2, (Func<CRMspSelectSurveySendSetting_Result, SelectListItem>)((CRMspSelectSurveySendSetting_Result item) => new SelectListItem
			{
				Text = item.surssTitle,
				Value = item.SurveySendSettingId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.SendSettingsList = list;
		return list;
	}

	public JsonResult GetSurveySendSettingJs()
	{
		return Json(GetSurveySendSetting(), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetSurveySendSettingInfo(int sendSettingId)
	{
		CRMspSelectSurveySendSettingWithId_Result cRMspSelectSurveySendSettingWithId_Result = new CRMspSelectSurveySendSettingWithId_Result();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			cRMspSelectSurveySendSettingWithId_Result = Enumerable.FirstOrDefault<CRMspSelectSurveySendSettingWithId_Result>((IEnumerable<CRMspSelectSurveySendSettingWithId_Result>)_db.CRMspSelectSurveySendSettingWithId(sendSettingId, lCID, result));
			if (cRMspSelectSurveySendSettingWithId_Result == null)
			{
				cRMspSelectSurveySendSettingWithId_Result = new CRMspSelectSurveySendSettingWithId_Result();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(cRMspSelectSurveySendSettingWithId_Result, JsonRequestBehavior.AllowGet);
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		_dbI.Dispose();
		_dbII.Dispose();
		base.Dispose(disposing);
	}
}
