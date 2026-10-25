using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Validation;
using System.Data.Objects;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CRM.General.IO;
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
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace CRMIdeal.Areas.Company.Controllers;

public class GenerateAutoUPController : Controller
{
	private CRMSpEntities _db = new CRMSpEntities();

	private CRMSpIEntities _dbI = new CRMSpIEntities();

	private CRMSpIIEntities _dbII = new CRMSpIIEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	[DynamicAuthorize(ControllerName = "frmCompanyReport", ActionName = "actManageCmpUP")]
	public ActionResult Index()
	{
		GetEmailList();
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int? centerId = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserLastCId : null);
		int result2 = -1;
		int result3 = -1;
		int result4 = -1;
		int result5 = -1;
		try
		{
			List<CRMspSelectFoSettingRegister_Result> list = Enumerable.ToList<CRMspSelectFoSettingRegister_Result>((IEnumerable<CRMspSelectFoSettingRegister_Result>)_dbII.CRMspSelectFoSettingRegister(centerId, lCID, result));
			if (list != null)
			{
				CRMspSelectFoSettingRegister_Result cRMspSelectFoSettingRegister_Result = Enumerable.FirstOrDefault<CRMspSelectFoSettingRegister_Result>((IEnumerable<CRMspSelectFoSettingRegister_Result>)list, (Func<CRMspSelectFoSettingRegister_Result, bool>)((CRMspSelectFoSettingRegister_Result f) => f.CmpKind == 1));
				CRMspSelectFoSettingRegister_Result cRMspSelectFoSettingRegister_Result2 = Enumerable.FirstOrDefault<CRMspSelectFoSettingRegister_Result>((IEnumerable<CRMspSelectFoSettingRegister_Result>)list, (Func<CRMspSelectFoSettingRegister_Result, bool>)((CRMspSelectFoSettingRegister_Result f) => f.CmpKind == 0));
				if (cRMspSelectFoSettingRegister_Result != null)
				{
					if (cRMspSelectFoSettingRegister_Result.CmpDefUsernameType.HasValue)
					{
						int.TryParse(cRMspSelectFoSettingRegister_Result.CmpDefUsernameType.ToString(), out result2);
					}
					else
					{
						result2 = -1;
					}
					if (cRMspSelectFoSettingRegister_Result.CmpDefPasswordType.HasValue)
					{
						int.TryParse(cRMspSelectFoSettingRegister_Result.CmpDefPasswordType.ToString(), out result3);
					}
					else
					{
						result3 = -1;
					}
				}
				if (cRMspSelectFoSettingRegister_Result2 != null)
				{
					if (cRMspSelectFoSettingRegister_Result2.CmpDefUsernameType.HasValue)
					{
						int.TryParse(cRMspSelectFoSettingRegister_Result2.CmpDefUsernameType.ToString(), out result4);
					}
					else
					{
						result4 = -1;
					}
					if (cRMspSelectFoSettingRegister_Result2.CmpDefPasswordType.HasValue)
					{
						int.TryParse(cRMspSelectFoSettingRegister_Result2.CmpDefPasswordType.ToString(), out result5);
					}
					else
					{
						result5 = -1;
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.PrsDefRealUsernameType = result2;
		base.ViewBag.PrsDefRealPasswordType = result3;
		base.ViewBag.PrsDefLegalUsernameType = result4;
		base.ViewBag.PrsDefLegalPasswordType = result5;
		if (centerId.HasValue)
		{
			base.ViewBag.referUserList = CRMIdeal.Classes.Helper.Company.GetCmpReferUserList(centerId.Value);
			base.ViewBag.suppUserList = CRMIdeal.Classes.Helper.Company.GetCmpSuppUserList(centerId.Value);
		}
		return View();
	}

	[AjaxOnly]
	public JsonResult GetEmailList()
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
			list = Enumerable.ToList<SelectListItem>(Enumerable.Select<EmailspSelectEmailUsersInfoByUser_Result, SelectListItem>((IEnumerable<EmailspSelectEmailUsersInfoByUser_Result>)Enumerable.ToList<EmailspSelectEmailUsersInfoByUser_Result>((IEnumerable<EmailspSelectEmailUsersInfoByUser_Result>)_db.EmailspSelectEmailUsersInfoByUser(UserLogin.CurrentUser.UserId)), (Func<EmailspSelectEmailUsersInfoByUser_Result, SelectListItem>)((EmailspSelectEmailUsersInfoByUser_Result item) => new SelectListItem
			{
				Text = item.euNikeName + "  [ " + item.euNikeEmail + " ]",
				Value = item.EmailUsersInfoId.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.Emailslist = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public List<CRMspSelectCompanyEmailsAndMobilesFromRptFilterData_Result> GetList(int type, int mode)
	{
		List<CRMspSelectCompanyEmailsAndMobilesFromRptFilterData_Result> result = new List<CRMspSelectCompanyEmailsAndMobilesFromRptFilterData_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int userId = UserLogin.CurrentUser.UserId;
			result = Enumerable.ToList<CRMspSelectCompanyEmailsAndMobilesFromRptFilterData_Result>((IEnumerable<CRMspSelectCompanyEmailsAndMobilesFromRptFilterData_Result>)_db.CRMspSelectCompanyEmailsAndMobilesFromRptFilterData(userId, type, mode, lCID, result2));
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return result;
	}

	public ActionResult List_Read([DataSourceRequest] DataSourceRequest request, int type, int mode)
	{
		List<CRMspSelectCompanyEmailsAndMobilesFromRptFilterData_Result> enumerable = new List<CRMspSelectCompanyEmailsAndMobilesFromRptFilterData_Result>();
		try
		{
			enumerable = GetList(type, mode);
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		JsonResult jsonResult = Json(((IEnumerable)enumerable).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult GetCmpList(int type, int mode)
	{
		List<GenerateAutoCmpMobileEmailViewModel> list = new List<GenerateAutoCmpMobileEmailViewModel>();
		try
		{
			List<CRMspSelectCompanyEmailsAndMobilesFromRptFilterData_Result> list2 = GetList(type, mode);
			int num = 1;
			foreach (CRMspSelectCompanyEmailsAndMobilesFromRptFilterData_Result item2 in list2)
			{
				GenerateAutoCmpMobileEmailViewModel item = new GenerateAutoCmpMobileEmailViewModel
				{
					Row = num,
					CmpId = item2.CompanyID,
					Email = (item2.Email ?? ""),
					Mobile = (item2.Mobile ?? ""),
					Selected = true
				};
				list.Add(item);
				num++;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(list, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	[ValidateInput(false)]
	public JsonResult ActSend(string companies, int type, int setNewUsername, int setNewPassword, int? emailUserInfoId, string subject, string emailBody, string smsBody)
	{
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bae: Unknown result type (might be due to invalid IL or missing references)
		//IL_0852: Unknown result type (might be due to invalid IL or missing references)
		//IL_060f: Unknown result type (might be due to invalid IL or missing references)
		string data = "";
		string message = "";
		CommonResultStatusViewModel status = CommonResultStatusViewModel.Success;
		CommonResultViewModel<string> data2;
		try
		{
			int result = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result);
			}
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			short.Parse(Financial.Get().Id.ToString());
			int userId = UserLogin.CurrentUser.UserId;
			if (UserLogin.CurrentUser != null)
			{
				_ = UserLogin.CurrentUser.UserLastCId;
			}
			List<GenerateAutoCmpMobileEmailViewModel> list = new List<GenerateAutoCmpMobileEmailViewModel>();
			list = new JavaScriptSerializer().Deserialize<List<GenerateAutoCmpMobileEmailViewModel>>(companies);
			string text = "";
			if (Enumerable.Any<GenerateAutoCmpMobileEmailViewModel>((IEnumerable<GenerateAutoCmpMobileEmailViewModel>)list))
			{
				foreach (GenerateAutoCmpMobileEmailViewModel item in list)
				{
					if (item.Selected)
					{
						text = text + item.CmpId + ",";
					}
				}
			}
			string text2 = "";
			int num = 0;
			if (!Enumerable.Any<GenerateAutoCmpMobileEmailViewModel>((IEnumerable<GenerateAutoCmpMobileEmailViewModel>)list))
			{
				text2 = text2 + Messages.msgErrorNotSelectedItem + "<br>";
				num++;
			}
			if (string.IsNullOrWhiteSpace(text))
			{
				text2 = text2 + Messages.msgErrorNotSelectedItem + "<br>";
				num++;
			}
			switch (type)
			{
			case 1:
				if (UserLogin.IsUserAccess("frmGenerateAutoCmpUP", "actSendEmailToTank", UserLogin.CurrentUser))
				{
					if (!emailUserInfoId.HasValue)
					{
						text2 = text2 + string.Format(Messages.msgErrorIsNotEntered, Labels.GenerateAutoCmpUPEmailFrom) + "<br>";
						num++;
					}
					if (string.IsNullOrWhiteSpace(subject))
					{
						text2 = text2 + string.Format(Messages.msgErrorIsNotEntered, Labels.GenerateAutoCmpUPSubject) + "<br>";
						num++;
					}
					if (string.IsNullOrWhiteSpace(emailBody))
					{
						text2 = text2 + string.Format(Messages.msgErrorIsNotEntered, Labels.GenerateAutoCmpUPBody) + "<br>";
						num++;
					}
					break;
				}
				data = "";
				message = Messages.ErrorNotAccess;
				status = CommonResultStatusViewModel.Error;
				goto end_IL_000e;
			case 2:
				if (UserLogin.IsUserAccess("frmGenerateAutoCmpUP", "actGoToSendSMS", UserLogin.CurrentUser))
				{
					if (string.IsNullOrWhiteSpace(smsBody))
					{
						text2 = text2 + string.Format(Messages.msgErrorIsNotEntered, Labels.GenerateAutoCmpUPBody) + "<br>";
						num++;
					}
					break;
				}
				data = "";
				message = Messages.ErrorNotAccess;
				status = CommonResultStatusViewModel.Error;
				goto end_IL_000e;
			}
			if (num > 0)
			{
				data = "";
				message = text2;
				status = CommonResultStatusViewModel.Error;
			}
			else
			{
				List<object> list2 = new List<object>();
				string objectJson2;
				string encryptionKey2;
				mct_I_Result mct_I_Result;
				switch (type)
				{
				case 1:
				{
					string text8 = ((SysSeting.Get().FOUrl != null) ? SysSeting.Get().FOUrl.ToString() : "");
					text8 = text8 ?? "";
					if (!string.IsNullOrWhiteSpace(text8) && !text8.StartsWith("http"))
					{
						text8 = "http://" + text8;
					}
					now.AddHours(24.0);
					if (string.IsNullOrWhiteSpace(text8) || !Enumerable.Any<GenerateAutoCmpMobileEmailViewModel>((IEnumerable<GenerateAutoCmpMobileEmailViewModel>)list))
					{
						break;
					}
					foreach (GenerateAutoCmpMobileEmailViewModel item2 in Enumerable.Where<GenerateAutoCmpMobileEmailViewModel>((IEnumerable<GenerateAutoCmpMobileEmailViewModel>)list, (Func<GenerateAutoCmpMobileEmailViewModel, bool>)((GenerateAutoCmpMobileEmailViewModel p) => p.Selected)))
					{
						string text9 = CodeDecode.Codding(now.AddHours(24.0).ToString("yyyy/MM/dd HH:mm:ss"), Configuration.ForgotPassword);
						string text10 = CodeDecode.Codding(item2.CmpId.ToString(), Configuration.ForgotPassword);
						string text11 = CodeDecode.Codding(item2.Email.ToString(), Configuration.ForgotPassword);
						string getString2 = "dt=[" + text9 + "]id=[" + text10 + "]email=[" + text11 + "]";
						getString2 = CodeDecode.Codding(getString2, Configuration.ForgotPassword);
						text8 = (text8.EndsWith("/") ? text8.TrimEnd(new char[1] { '/' }) : text8);
						string absoluteUri2 = HttpContext.Current.Request.Url.AbsoluteUri;
						absoluteUri2 = text8 + "/Users/Home/ResetPassword?qs=" + getString2;
						Uri uri2 = new Uri(absoluteUri2);
						string domain2 = uri2.Scheme + "://" + uri2.Authority;
						ObjectParameter objectParameter2 = new ObjectParameter("ShortKey", typeof(string));
						_dbII.CRMspInsertShortLink(absoluteUri2, 10, item2.CmpId, null, null, null, null, DateTime.Now.AddDays(1.0), null, userId, value, registerDatePersian, appType, lCID, domain2, objectParameter2);
						string text12 = objectParameter2.Value?.ToString();
						list2.Add(new
						{
							CmpId = item2.CmpId,
							Link = text8 + "/s/" + text12 + " "
						});
					}
					if (!string.IsNullOrWhiteSpace(emailBody))
					{
						emailBody = ((!Thread.CurrentThread.CurrentCulture.TextInfo.IsRightToLeft) ? ("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" /> <div dir=\"ltr\">" + emailBody + "</div>") : ("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" /> <div dir=\"rtl\">" + emailBody + "</div>"));
						List<string> list3 = new List<string>();
						foreach (Match item3 in Regex.Matches(emailBody, "<img.+?src=[\"'](.+?)[\"'].+?>", (RegexOptions)3))
						{
							string value2 = ((Capture)item3.Groups[1]).Value;
							if (!list3.Contains(value2))
							{
								list3.Add(value2);
							}
						}
						if (list3.Count > 0)
						{
							EmailSetting emailSetting = EmailSettings.Get();
							string text13 = ((emailSetting.EmailsAttachFilePath == null) ? "" : (emailSetting.EmailsAttachFilePath + (emailSetting.EmailsAttachFilePath.EndsWith("\\") ? "" : "\\")));
							try
							{
								string text14 = emailBody;
								foreach (string item4 in list3)
								{
									string text15 = item4.Replace("%2F", "/").Replace("%20", " ");
									string text16 = base.Server.MapPath(text15);
									string[] array = text16.Split(new char[1] { '.' });
									RandomText randomText = new RandomText();
									string text17 = DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + randomText.CreateRandomCode(5, WithNumber: true, false).Replace(" ", "").Trim() + "-" + DateTime.Now.ToString("yyyyMMdd") + "-" + DateTime.Now.ToString("HHmmss") + "." + array[^1];
									string newValue = text13 + text17;
									if (!new FTPclient(Configuration.PathFtp, Configuration.UserNameFtp, Configuration.PasswordFtp, Configuration.UsePassiveFtp).Upload(text16, emailSetting.EmailsAttachShareFilePathFtp + text17))
									{
										data = "";
										message = Messages.EmailSendingErrorInSaveImage;
										status = CommonResultStatusViewModel.Error;
										goto end_IL_02dd;
									}
									text14 = text14.Replace(item4, newValue);
								}
								emailBody = text14;
								goto IL_0852;
							}
							catch (Exception e)
							{
								ErrorSignal.FromCurrentContext().Raise(e);
								data = "";
								message = Messages.EmailSendingErrorInSaveImage;
								status = CommonResultStatusViewModel.Error;
							}
							break;
						}
					}
					goto IL_0852;
				}
				case 2:
					{
						string text3 = ((SysSeting.Get().FOUrl != null) ? SysSeting.Get().FOUrl.ToString() : "");
						text3 = text3 ?? "";
						if (!string.IsNullOrWhiteSpace(text3) && !text3.StartsWith("http"))
						{
							text3 = "http://" + text3;
						}
						if (string.IsNullOrWhiteSpace(text3) || !Enumerable.Any<GenerateAutoCmpMobileEmailViewModel>((IEnumerable<GenerateAutoCmpMobileEmailViewModel>)list))
						{
							break;
						}
						foreach (GenerateAutoCmpMobileEmailViewModel item5 in Enumerable.Where<GenerateAutoCmpMobileEmailViewModel>((IEnumerable<GenerateAutoCmpMobileEmailViewModel>)list, (Func<GenerateAutoCmpMobileEmailViewModel, bool>)((GenerateAutoCmpMobileEmailViewModel x) => x.Selected)))
						{
							string text4 = CodeDecode.Codding(now.AddHours(24.0).ToString("yyyy/MM/dd HH:mm:ss"), Configuration.ForgotPassword);
							string text5 = CodeDecode.Codding(item5.CmpId.ToString(), Configuration.ForgotPassword);
							string text6 = CodeDecode.Codding(item5.Email.ToString(), Configuration.ForgotPassword);
							string getString = "dt=[" + text4 + "]id=[" + text5 + "]email=[" + text6 + "]";
							getString = CodeDecode.Codding(getString, Configuration.ForgotPassword);
							text3 = (text3.EndsWith("/") ? text3.TrimEnd(new char[1] { '/' }) : text3);
							string absoluteUri = HttpContext.Current.Request.Url.AbsoluteUri;
							absoluteUri = text3 + "/Users/Home/ResetPassword?qs=" + getString;
							ObjectParameter objectParameter = new ObjectParameter("ShortKey", typeof(string));
							Uri uri = new Uri(absoluteUri);
							string domain = uri.Scheme + "://" + uri.Authority;
							_dbII.CRMspInsertShortLink(absoluteUri, 10, item5.CmpId, null, null, null, null, DateTime.Now.AddDays(1.0), null, userId, value, registerDatePersian, appType, lCID, domain, objectParameter);
							string text7 = objectParameter.Value?.ToString();
							list2.Add(new
							{
								CmpId = item5.CmpId,
								Link = text3 + "/s/" + text7 + " "
							});
						}
						string objectJson = new JavaScriptSerializer().Serialize((object)list2);
						string encryptionKey = XorCipher.PreparePublicKeyForSql();
						CRMspInsertSmsTempMobileNumbersFromGenerateAutoUP_Result cRMspInsertSmsTempMobileNumbersFromGenerateAutoUP_Result = Enumerable.FirstOrDefault<CRMspInsertSmsTempMobileNumbersFromGenerateAutoUP_Result>((IEnumerable<CRMspInsertSmsTempMobileNumbersFromGenerateAutoUP_Result>)_dbI.CRMspInsertSmsTempMobileNumbersFromGenerateAutoUP(smsBody, userId, value, registerDatePersian, appType, lCID, result2, objectJson, encryptionKey));
						if (cRMspInsertSmsTempMobileNumbersFromGenerateAutoUP_Result != null)
						{
							data = cRMspInsertSmsTempMobileNumbersFromGenerateAutoUP_Result.Numbers + "|" + cRMspInsertSmsTempMobileNumbersFromGenerateAutoUP_Result.Companies + "|" + cRMspInsertSmsTempMobileNumbersFromGenerateAutoUP_Result.CompanyPersons + "|" + ((!cRMspInsertSmsTempMobileNumbersFromGenerateAutoUP_Result.AllBodyCount.HasValue) ? new int?(0) : cRMspInsertSmsTempMobileNumbersFromGenerateAutoUP_Result.AllBodyCount) + "|" + ((!cRMspInsertSmsTempMobileNumbersFromGenerateAutoUP_Result.AllBodyCost.HasValue) ? new decimal?(default(decimal)) : cRMspInsertSmsTempMobileNumbersFromGenerateAutoUP_Result.AllBodyCost) + "|" + cRMspInsertSmsTempMobileNumbersFromGenerateAutoUP_Result.SMSBody + "|" + ((!cRMspInsertSmsTempMobileNumbersFromGenerateAutoUP_Result.NumberCount.HasValue) ? new int?(0) : cRMspInsertSmsTempMobileNumbersFromGenerateAutoUP_Result.NumberCount) + "|";
							message = Messages.msgSuccessAction;
							status = CommonResultStatusViewModel.Success;
						}
						else
						{
							data = "";
							message = Messages.msgErrorRunFunction;
							status = CommonResultStatusViewModel.Error;
						}
						break;
					}
					IL_0852:
					objectJson2 = new JavaScriptSerializer().Serialize((object)list2);
					encryptionKey2 = XorCipher.PreparePublicKeyForSql();
					mct_I_Result = Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)_dbI.CRMspInsertEmailFromGenerateAutoUP(emailBody, subject, emailUserInfoId, userId, value, registerDatePersian, appType, lCID, result2, (result != 0) ? new int?(result) : null, objectJson2, encryptionKey2));
					if (mct_I_Result != null)
					{
						_ = mct_I_Result.Result;
						if (mct_I_Result.Result > 0)
						{
							data = "1";
							message = Messages.EmailSendingSuccessfully;
							status = CommonResultStatusViewModel.Success;
						}
						else
						{
							data = "";
							message = Messages.msgErrorRunFunction;
							status = CommonResultStatusViewModel.Error;
						}
					}
					break;
					end_IL_02dd:
					break;
				}
			}
			end_IL_000e:;
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			data = "";
			data2 = new CommonResultViewModel<string>
			{
				Data = data,
				Message = Messages.msgErrorRunFunction,
				Status = CommonResultStatusViewModel.Error
			};
			return Json(data2, JsonRequestBehavior.AllowGet);
		}
		data2 = new CommonResultViewModel<string>
		{
			Data = data,
			Message = message,
			Status = status
		};
		return Json(data2, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	[ValidateInput(false)]
	public JsonResult ActCreateCmpUP(string companies, int realMode, int legalMode, int pswdRealMode, int pswdLegalMode, int setNewUsername, int setNewPassword)
	{
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		string data = "";
		string message = "";
		CommonResultStatusViewModel status = CommonResultStatusViewModel.Success;
		CommonResultViewModel<string> data2;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			short.Parse(Financial.Get().Id.ToString());
			int userId = UserLogin.CurrentUser.UserId;
			int? centerId = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserLastCId : null);
			List<GenerateAutoCmpMobileEmailViewModel> list = new List<GenerateAutoCmpMobileEmailViewModel>();
			list = new JavaScriptSerializer().Deserialize<List<GenerateAutoCmpMobileEmailViewModel>>(companies);
			string text = "";
			if (Enumerable.Any<GenerateAutoCmpMobileEmailViewModel>((IEnumerable<GenerateAutoCmpMobileEmailViewModel>)list))
			{
				foreach (GenerateAutoCmpMobileEmailViewModel item in list)
				{
					if (item.Selected)
					{
						text = text + item.CmpId + ",";
					}
				}
			}
			string text2 = "";
			int num = 0;
			if (!UserLogin.IsUserAccess("frmGenerateAutoCmpUP", "actCreateCmpUP", UserLogin.CurrentUser))
			{
				text2 = text2 + Messages.ErrorNotAccess + "<br>";
				num++;
			}
			if (!Enumerable.Any<GenerateAutoCmpMobileEmailViewModel>((IEnumerable<GenerateAutoCmpMobileEmailViewModel>)list))
			{
				text2 = text2 + Messages.msgErrorNotSelectedItem + "<br>";
				num++;
			}
			if (string.IsNullOrWhiteSpace(text))
			{
				text2 = text2 + Messages.msgErrorNotSelectedItem + "<br>";
				num++;
			}
			if (num == 0)
			{
				string encryptionKey = XorCipher.PreparePublicKeyForSql();
				mct_I_Result mct_I_Result = Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)_dbI.CRMspUpdateCompanyFromGenerateAutoUP(text, realMode, legalMode, pswdRealMode, pswdLegalMode, setNewUsername, setNewPassword, userId, value, registerDatePersian, appType, lCID, result, encryptionKey));
				if (mct_I_Result != null)
				{
					_ = mct_I_Result.Result;
					if (mct_I_Result.Result > 0)
					{
						int num2 = -1;
						int num3 = -1;
						int num4 = -1;
						int num5 = -1;
						try
						{
							List<CRMspSelectFoSettingRegister_Result> list2 = Enumerable.ToList<CRMspSelectFoSettingRegister_Result>((IEnumerable<CRMspSelectFoSettingRegister_Result>)_dbII.CRMspSelectFoSettingRegister(centerId, lCID, result));
							if (list2 != null && setNewUsername != 0 && setNewPassword != 0)
							{
								CRMspSelectFoSettingRegister_Result cRMspSelectFoSettingRegister_Result = Enumerable.FirstOrDefault<CRMspSelectFoSettingRegister_Result>((IEnumerable<CRMspSelectFoSettingRegister_Result>)list2, (Func<CRMspSelectFoSettingRegister_Result, bool>)((CRMspSelectFoSettingRegister_Result f) => f.CmpKind == 1));
								CRMspSelectFoSettingRegister_Result cRMspSelectFoSettingRegister_Result2 = Enumerable.FirstOrDefault<CRMspSelectFoSettingRegister_Result>((IEnumerable<CRMspSelectFoSettingRegister_Result>)list2, (Func<CRMspSelectFoSettingRegister_Result, bool>)((CRMspSelectFoSettingRegister_Result f) => f.CmpKind == 0));
								bool flag = false;
								if (cRMspSelectFoSettingRegister_Result != null)
								{
									if (!cRMspSelectFoSettingRegister_Result.CmpDefUsernameType.HasValue)
									{
										cRMspSelectFoSettingRegister_Result.CmpDefUsernameType = realMode;
									}
									if (!cRMspSelectFoSettingRegister_Result.CmpDefPasswordType.HasValue)
									{
										cRMspSelectFoSettingRegister_Result.CmpDefPasswordType = pswdRealMode;
									}
									if (!cRMspSelectFoSettingRegister_Result.CmpDefUsernameType.HasValue || !cRMspSelectFoSettingRegister_Result.CmpDefPasswordType.HasValue)
									{
										_dbTbl.Entry(cRMspSelectFoSettingRegister_Result).State = EntityState.Modified;
										flag = true;
									}
								}
								if (cRMspSelectFoSettingRegister_Result2 != null)
								{
									if (!cRMspSelectFoSettingRegister_Result2.CmpDefUsernameType.HasValue)
									{
										cRMspSelectFoSettingRegister_Result2.CmpDefUsernameType = legalMode;
									}
									if (!cRMspSelectFoSettingRegister_Result2.CmpDefPasswordType.HasValue)
									{
										cRMspSelectFoSettingRegister_Result2.CmpDefPasswordType = pswdLegalMode;
									}
									if (!cRMspSelectFoSettingRegister_Result2.CmpDefUsernameType.HasValue || !cRMspSelectFoSettingRegister_Result2.CmpDefPasswordType.HasValue)
									{
										_dbTbl.Entry(cRMspSelectFoSettingRegister_Result2).State = EntityState.Modified;
										flag = true;
									}
								}
								if (flag)
								{
									_dbTbl.SaveChanges();
								}
								data = "11";
							}
						}
						catch (Exception e)
						{
							ErrorSignal.FromCurrentContext().Raise(e);
						}
						base.ViewBag.PrsDefRealUsernameType = num2;
						base.ViewBag.PrsDefRealPasswordType = num3;
						base.ViewBag.PrsDefLegalUsernameType = num4;
						base.ViewBag.PrsDefLegalPasswordType = num5;
						message = Messages.msgSuccessAction;
						status = CommonResultStatusViewModel.Success;
					}
					else
					{
						data = "";
						message = Messages.msgErrorRunFunction;
						status = CommonResultStatusViewModel.Error;
					}
				}
			}
			else
			{
				data = "";
				message = text2;
				status = CommonResultStatusViewModel.Error;
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			data = "";
			data2 = new CommonResultViewModel<string>
			{
				Data = data,
				Message = Messages.msgErrorRunFunction,
				Status = CommonResultStatusViewModel.Error
			};
			return Json(data2, JsonRequestBehavior.AllowGet);
		}
		data2 = new CommonResultViewModel<string>
		{
			Data = data,
			Message = message,
			Status = status
		};
		return Json(data2, JsonRequestBehavior.AllowGet);
	}

	[HttpPost]
	public JsonResult TransferMobAndEmailFromMainPrsToCmpRep()
	{
		string text = "";
		string text2 = "";
		CommonResultStatusViewModel commonResultStatusViewModel = CommonResultStatusViewModel.Success;
		CommonResultViewModel<string> data;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			short.Parse(Financial.Get().Id.ToString());
			int userId = UserLogin.CurrentUser.UserId;
			string text3 = "";
			int num = 0;
			if (!UserLogin.IsUserAccess("frmGenerateAutoCmpUP", "actTransferMobAndEmailFromMainPrsToCmp", UserLogin.CurrentUser))
			{
				text3 = text3 + Messages.ErrorNotAccess + "<br>";
				num++;
			}
			if (num == 0)
			{
				string text4 = "";
				text = "";
				List<CRMspTransferMobAndEmailFromMainPrsToCmpRep_Result> list = Enumerable.ToList<CRMspTransferMobAndEmailFromMainPrsToCmpRep_Result>((IEnumerable<CRMspTransferMobAndEmailFromMainPrsToCmpRep_Result>)_dbI.CRMspTransferMobAndEmailFromMainPrsToCmpRep(userId, lCID, result));
				if (list != null && Enumerable.Any<CRMspTransferMobAndEmailFromMainPrsToCmpRep_Result>((IEnumerable<CRMspTransferMobAndEmailFromMainPrsToCmpRep_Result>)list))
				{
					text = "error";
					text4 = GetFileTransferMobAndEmailFromMainPrsToCmpRep(list);
				}
				if (!string.IsNullOrWhiteSpace(text4))
				{
					text2 = Messages.msgNotCompeleteSuccessAction;
					text2 = text2 + "<br><a href='" + text4 + "' class='link-excel-file'>" + Messages.msgLinkForDownloadFileWithError + "</a>";
				}
				else
				{
					text2 = Messages.msgSuccessAction;
				}
				commonResultStatusViewModel = CommonResultStatusViewModel.Success;
			}
			else
			{
				text = "";
				text2 = text3;
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

	public string GetFileTransferMobAndEmailFromMainPrsToCmpRep(List<CRMspTransferMobAndEmailFromMainPrsToCmpRep_Result> res)
	{
		//IL_0399: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b4: Unknown result type (might be due to invalid IL or missing references)
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
			if (res != null && Enumerable.Any<CRMspTransferMobAndEmailFromMainPrsToCmpRep_Result>((IEnumerable<CRMspTransferMobAndEmailFromMainPrsToCmpRep_Result>)res))
			{
				ExcelPackage excelPackage = new ExcelPackage();
				ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets.Add(Labels.GenerateAutoCmpUPExcelPropertiesTitle);
				int num = 0;
				int num2 = 1;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.GenerateAutoCmpUPListCompanyName;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.GenerateAutoCmpUPListCompanyNumber;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.frmError;
				foreach (CRMspTransferMobAndEmailFromMainPrsToCmpRep_Result re in res)
				{
					num2++;
					num = 0;
					num++;
					excelWorksheet.Cells[num2, num].Value = re.CompanyName ?? "";
					num++;
					excelWorksheet.Cells[num2, num].Value = re.cmpNumber.ToString();
					string value = "";
					int result2 = 0;
					int.TryParse(re.TypeError.ToString(), out result2);
					switch (result2)
					{
					case 1:
						value = Messages.msgErrorNotDefineCmpMainPersonInTrasferMobAndEmail;
						break;
					case 2:
						value = Messages.msgErrorCmpMainPersonNotMobOrEmailInTrasferMobAndEmail;
						break;
					case 3:
						value = Messages.msgErrorDupCmpMainPersonMobInTrasferMobAndEmail;
						break;
					case 4:
						value = Messages.msgErrorDupCmpMainPersonEmailInTrasferMobAndEmail;
						break;
					}
					num++;
					excelWorksheet.Cells[num2, num].Value = value;
				}
				string text2 = base.Server.MapPath(Configuration.HostTempFilesPath) + "\\ReportGenerateAutoUP\\" + UserLogin.CurrentUser.UserId;
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
				excelPackage.Workbook.Properties.Title = Labels.GenerateAutoCmpUPExcelPropertiesTitle;
				excelPackage.Workbook.Properties.Company = Labels.GenerateAutoCmpUPExcelPropertiesCompany;
				Stream stream = System.IO.File.Create(path);
				excelPackage.SaveAs(stream);
				stream.Close();
				if (System.IO.File.Exists(path))
				{
					text = Configuration.HostTempFilesPath + "/ReportGenerateAutoUP/" + userId + "/" + text3;
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

	[DynamicAuthorize(ControllerName = "frmCompanyReport", ActionName = "actManagePrsUP")]
	public ActionResult CompanyPersons()
	{
		GetEmailList();
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int? centerId = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserLastCId : null);
		int result2 = -1;
		int result3 = -1;
		int result4 = -1;
		int result5 = -1;
		try
		{
			List<CRMspSelectFoSettingRegister_Result> list = Enumerable.ToList<CRMspSelectFoSettingRegister_Result>((IEnumerable<CRMspSelectFoSettingRegister_Result>)_dbII.CRMspSelectFoSettingRegister(centerId, lCID, result));
			if (list != null)
			{
				CRMspSelectFoSettingRegister_Result cRMspSelectFoSettingRegister_Result = Enumerable.FirstOrDefault<CRMspSelectFoSettingRegister_Result>((IEnumerable<CRMspSelectFoSettingRegister_Result>)list, (Func<CRMspSelectFoSettingRegister_Result, bool>)((CRMspSelectFoSettingRegister_Result f) => f.CmpKind == 1));
				CRMspSelectFoSettingRegister_Result cRMspSelectFoSettingRegister_Result2 = Enumerable.FirstOrDefault<CRMspSelectFoSettingRegister_Result>((IEnumerable<CRMspSelectFoSettingRegister_Result>)list, (Func<CRMspSelectFoSettingRegister_Result, bool>)((CRMspSelectFoSettingRegister_Result f) => f.CmpKind == 0));
				if (cRMspSelectFoSettingRegister_Result != null)
				{
					if (cRMspSelectFoSettingRegister_Result.CmpDefUsernameType.HasValue)
					{
						int.TryParse(cRMspSelectFoSettingRegister_Result.CmpDefUsernameType.ToString(), out result2);
					}
					else
					{
						result2 = -1;
					}
					if (cRMspSelectFoSettingRegister_Result.CmpDefPasswordType.HasValue)
					{
						int.TryParse(cRMspSelectFoSettingRegister_Result.CmpDefPasswordType.ToString(), out result3);
					}
					else
					{
						result3 = -1;
					}
				}
				if (cRMspSelectFoSettingRegister_Result2 != null)
				{
					if (cRMspSelectFoSettingRegister_Result2.CmpDefUsernameType.HasValue)
					{
						int.TryParse(cRMspSelectFoSettingRegister_Result2.CmpDefUsernameType.ToString(), out result4);
					}
					else
					{
						result4 = -1;
					}
					if (cRMspSelectFoSettingRegister_Result2.CmpDefPasswordType.HasValue)
					{
						int.TryParse(cRMspSelectFoSettingRegister_Result2.CmpDefPasswordType.ToString(), out result5);
					}
					else
					{
						result5 = -1;
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.PrsDefRealUsernameType = result2;
		base.ViewBag.PrsDefRealPasswordType = result3;
		base.ViewBag.PrsDefLegalUsernameType = result4;
		base.ViewBag.PrsDefLegalPasswordType = result5;
		return View();
	}

	[AjaxOnly]
	[ValidateInput(false)]
	public JsonResult ActCreateCmpPersonUP(string persons, int realMode, int legalMode, int pswdRealMode, int pswdLegalMode, int setNewUsername, int setNewPassword)
	{
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		string data = "";
		string message = "";
		CommonResultStatusViewModel status = CommonResultStatusViewModel.Success;
		CommonResultViewModel<string> data2;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			short.Parse(Financial.Get().Id.ToString());
			int userId = UserLogin.CurrentUser.UserId;
			int? centerId = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserLastCId : null);
			List<GenerateAutoPrsMobileEmailViewModel> list = new List<GenerateAutoPrsMobileEmailViewModel>();
			list = new JavaScriptSerializer().Deserialize<List<GenerateAutoPrsMobileEmailViewModel>>(persons);
			string text = "";
			if (Enumerable.Any<GenerateAutoPrsMobileEmailViewModel>((IEnumerable<GenerateAutoPrsMobileEmailViewModel>)list))
			{
				foreach (GenerateAutoPrsMobileEmailViewModel item in list)
				{
					if (item.Selected)
					{
						text = text + item.PrsId + ",";
					}
				}
			}
			string text2 = "";
			int num = 0;
			if (!UserLogin.IsUserAccess("frmGenerateAutoPrsUP", "actCreatePrsUP", UserLogin.CurrentUser))
			{
				text2 = text2 + Messages.ErrorNotAccess + "<br>";
				num++;
			}
			if (!Enumerable.Any<GenerateAutoPrsMobileEmailViewModel>((IEnumerable<GenerateAutoPrsMobileEmailViewModel>)list))
			{
				text2 = text2 + Messages.msgErrorNotSelectedItem + "<br>";
				num++;
			}
			if (string.IsNullOrWhiteSpace(text))
			{
				text2 = text2 + Messages.msgErrorNotSelectedItem + "<br>";
				num++;
			}
			if (num == 0)
			{
				string encryptionKey = XorCipher.PreparePublicKeyForSql();
				mct_II_Result mct_II_Result = Enumerable.FirstOrDefault<mct_II_Result>((IEnumerable<mct_II_Result>)_dbII.CRMspUpdateCmpPersonFromGenerateAutoUP(text, realMode, legalMode, pswdRealMode, pswdLegalMode, setNewUsername, setNewPassword, userId, value, registerDatePersian, appType, lCID, result, encryptionKey));
				if (mct_II_Result != null)
				{
					_ = mct_II_Result.Result;
					if (mct_II_Result.Result > 0)
					{
						List<CRMspSelectFoSettingRegister_Result> list2 = Enumerable.ToList<CRMspSelectFoSettingRegister_Result>((IEnumerable<CRMspSelectFoSettingRegister_Result>)_dbII.CRMspSelectFoSettingRegister(centerId, lCID, result));
						if (list2 != null && setNewUsername != 0 && setNewPassword != 0)
						{
							CRMspSelectFoSettingRegister_Result cRMspSelectFoSettingRegister_Result = Enumerable.FirstOrDefault<CRMspSelectFoSettingRegister_Result>((IEnumerable<CRMspSelectFoSettingRegister_Result>)list2, (Func<CRMspSelectFoSettingRegister_Result, bool>)((CRMspSelectFoSettingRegister_Result f) => f.CmpKind == 1));
							CRMspSelectFoSettingRegister_Result cRMspSelectFoSettingRegister_Result2 = Enumerable.FirstOrDefault<CRMspSelectFoSettingRegister_Result>((IEnumerable<CRMspSelectFoSettingRegister_Result>)list2, (Func<CRMspSelectFoSettingRegister_Result, bool>)((CRMspSelectFoSettingRegister_Result f) => f.CmpKind == 0));
							bool flag = false;
							if (cRMspSelectFoSettingRegister_Result != null)
							{
								if (!cRMspSelectFoSettingRegister_Result.CmpDefUsernameType.HasValue)
								{
									cRMspSelectFoSettingRegister_Result.CmpDefUsernameType = realMode;
								}
								if (!cRMspSelectFoSettingRegister_Result.CmpDefPasswordType.HasValue)
								{
									cRMspSelectFoSettingRegister_Result.CmpDefPasswordType = pswdRealMode;
								}
								if (!cRMspSelectFoSettingRegister_Result.CmpDefUsernameType.HasValue || !cRMspSelectFoSettingRegister_Result.CmpDefPasswordType.HasValue)
								{
									_dbTbl.Entry(cRMspSelectFoSettingRegister_Result).State = EntityState.Modified;
									flag = true;
								}
							}
							if (cRMspSelectFoSettingRegister_Result2 != null)
							{
								if (!cRMspSelectFoSettingRegister_Result2.CmpDefUsernameType.HasValue)
								{
									cRMspSelectFoSettingRegister_Result2.CmpDefUsernameType = legalMode;
								}
								if (!cRMspSelectFoSettingRegister_Result2.CmpDefPasswordType.HasValue)
								{
									cRMspSelectFoSettingRegister_Result2.CmpDefPasswordType = pswdLegalMode;
								}
								if (!cRMspSelectFoSettingRegister_Result2.CmpDefUsernameType.HasValue || !cRMspSelectFoSettingRegister_Result2.CmpDefPasswordType.HasValue)
								{
									_dbTbl.Entry(cRMspSelectFoSettingRegister_Result2).State = EntityState.Modified;
									flag = true;
								}
							}
							if (flag)
							{
								_dbTbl.SaveChanges();
							}
							data = "11";
						}
						message = Messages.msgSuccessAction;
						status = CommonResultStatusViewModel.Success;
					}
					else
					{
						data = "";
						message = Messages.msgErrorRunFunction;
						status = CommonResultStatusViewModel.Error;
					}
				}
			}
			else
			{
				data = "";
				message = text2;
				status = CommonResultStatusViewModel.Error;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			data = "";
			data2 = new CommonResultViewModel<string>
			{
				Data = data,
				Message = Messages.msgErrorRunFunction,
				Status = CommonResultStatusViewModel.Error
			};
			return Json(data2, JsonRequestBehavior.AllowGet);
		}
		data2 = new CommonResultViewModel<string>
		{
			Data = data,
			Message = message,
			Status = status
		};
		return Json(data2, JsonRequestBehavior.AllowGet);
	}

	public List<CRMspSelectCmpPersonEmailsAndMobilesFromRptFilterData_Result> GetPersonsList(int type, int mode)
	{
		List<CRMspSelectCmpPersonEmailsAndMobilesFromRptFilterData_Result> result = new List<CRMspSelectCmpPersonEmailsAndMobilesFromRptFilterData_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int userId = UserLogin.CurrentUser.UserId;
			result = Enumerable.ToList<CRMspSelectCmpPersonEmailsAndMobilesFromRptFilterData_Result>((IEnumerable<CRMspSelectCmpPersonEmailsAndMobilesFromRptFilterData_Result>)_dbII.CRMspSelectCmpPersonEmailsAndMobilesFromRptFilterData(userId, type, mode, lCID, result2));
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return result;
	}

	public ActionResult PersonsList_Read([DataSourceRequest] DataSourceRequest request, int type, int mode)
	{
		List<CRMspSelectCmpPersonEmailsAndMobilesFromRptFilterData_Result> enumerable = new List<CRMspSelectCmpPersonEmailsAndMobilesFromRptFilterData_Result>();
		try
		{
			enumerable = GetPersonsList(type, mode);
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		JsonResult jsonResult = Json(((IEnumerable)enumerable).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult GetPrsList(int type, int mode)
	{
		List<GenerateAutoPrsMobileEmailViewModel> list = new List<GenerateAutoPrsMobileEmailViewModel>();
		try
		{
			List<CRMspSelectCmpPersonEmailsAndMobilesFromRptFilterData_Result> personsList = GetPersonsList(type, mode);
			int num = 1;
			foreach (CRMspSelectCmpPersonEmailsAndMobilesFromRptFilterData_Result item2 in personsList)
			{
				GenerateAutoPrsMobileEmailViewModel item = new GenerateAutoPrsMobileEmailViewModel
				{
					Row = num,
					PrsId = item2.CompanyPersonID,
					Email = (item2.Email ?? ""),
					Mobile = (item2.Mobile ?? ""),
					Selected = true
				};
				list.Add(item);
				num++;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(list, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	[ValidateInput(false)]
	public JsonResult ActSendCmpPerson(string persons, int type, int setNewUsername, int setNewPassword, int? emailUserInfoId, string subject, string emailBody, string smsBody)
	{
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ba5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0859: Unknown result type (might be due to invalid IL or missing references)
		//IL_0616: Unknown result type (might be due to invalid IL or missing references)
		string data = "";
		string message = "";
		CommonResultStatusViewModel status = CommonResultStatusViewModel.Success;
		CommonResultViewModel<string> data2;
		try
		{
			int result = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result);
			}
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			short.Parse(Financial.Get().Id.ToString());
			int userId = UserLogin.CurrentUser.UserId;
			List<GenerateAutoPrsMobileEmailViewModel> list = new List<GenerateAutoPrsMobileEmailViewModel>();
			list = new JavaScriptSerializer().Deserialize<List<GenerateAutoPrsMobileEmailViewModel>>(persons);
			string text = "";
			if (Enumerable.Any<GenerateAutoPrsMobileEmailViewModel>((IEnumerable<GenerateAutoPrsMobileEmailViewModel>)list))
			{
				foreach (GenerateAutoPrsMobileEmailViewModel item in list)
				{
					if (item.Selected)
					{
						text = text + item.PrsId + ",";
					}
				}
			}
			string text2 = "";
			int num = 0;
			if (!Enumerable.Any<GenerateAutoPrsMobileEmailViewModel>((IEnumerable<GenerateAutoPrsMobileEmailViewModel>)list))
			{
				text2 = text2 + Messages.msgErrorNotSelectedItem + "<br>";
				num++;
			}
			if (string.IsNullOrWhiteSpace(text))
			{
				text2 = text2 + Messages.msgErrorNotSelectedItem + "<br>";
				num++;
			}
			switch (type)
			{
			case 1:
				if (UserLogin.IsUserAccess("frmGenerateAutoPrsUP", "actSendEmailToTank", UserLogin.CurrentUser))
				{
					if (!emailUserInfoId.HasValue)
					{
						text2 = text2 + string.Format(Messages.msgErrorIsNotEntered, Labels.GenerateAutoCmpUPEmailFrom) + "<br>";
						num++;
					}
					if (string.IsNullOrWhiteSpace(subject))
					{
						text2 = text2 + string.Format(Messages.msgErrorIsNotEntered, Labels.GenerateAutoCmpUPSubject) + "<br>";
						num++;
					}
					if (string.IsNullOrWhiteSpace(emailBody))
					{
						text2 = text2 + string.Format(Messages.msgErrorIsNotEntered, Labels.GenerateAutoCmpUPBody) + "<br>";
						num++;
					}
					break;
				}
				data = "";
				message = Messages.ErrorNotAccess;
				status = CommonResultStatusViewModel.Error;
				goto end_IL_000e;
			case 2:
				if (UserLogin.IsUserAccess("frmGenerateAutoPrsUP", "actGoToSendSMS", UserLogin.CurrentUser))
				{
					if (string.IsNullOrWhiteSpace(smsBody))
					{
						text2 = text2 + string.Format(Messages.msgErrorIsNotEntered, Labels.GenerateAutoCmpUPBody) + "<br>";
						num++;
					}
					break;
				}
				data = "";
				message = Messages.ErrorNotAccess;
				status = CommonResultStatusViewModel.Error;
				goto end_IL_000e;
			}
			if (num > 0)
			{
				data = "";
				message = text2;
				status = CommonResultStatusViewModel.Error;
			}
			else
			{
				List<object> list2 = new List<object>();
				string text9;
				string encryptionKey2;
				CRMSpIIEntities dbII2;
				string objectJson;
				mct_II_Result mct_II_Result;
				switch (type)
				{
				case 1:
				{
					string text10 = SysSeting.Get().FOUrl?.ToString() ?? "";
					if (!string.IsNullOrWhiteSpace(text10) && !text10.StartsWith("http"))
					{
						text10 = "http://" + text10;
					}
					text10 = text10.TrimEnd(new char[1] { '/' });
					now.AddHours(24.0);
					if (!string.IsNullOrWhiteSpace(text10) && list != null && Enumerable.Any<GenerateAutoPrsMobileEmailViewModel>((IEnumerable<GenerateAutoPrsMobileEmailViewModel>)list))
					{
						foreach (GenerateAutoPrsMobileEmailViewModel item2 in Enumerable.Where<GenerateAutoPrsMobileEmailViewModel>((IEnumerable<GenerateAutoPrsMobileEmailViewModel>)list, (Func<GenerateAutoPrsMobileEmailViewModel, bool>)((GenerateAutoPrsMobileEmailViewModel p) => p.Selected)))
						{
							string text11 = CodeDecode.Codding(now.AddHours(24.0).ToString("yyyy/MM/dd HH:mm:ss"), Configuration.ForgotPassword);
							string text12 = CodeDecode.Codding(item2.PrsId.ToString(), Configuration.ForgotPassword);
							string text13 = CodeDecode.Codding(item2.Email.ToString(), Configuration.ForgotPassword);
							string getString2 = "dt=[" + text11 + "]id=[" + text12 + "]email=[" + text13 + "]pid=[" + text12 + "]";
							getString2 = CodeDecode.Codding(getString2, Configuration.ForgotPassword);
							text10 = (text10.EndsWith("/") ? text10.TrimEnd(new char[1] { '/' }) : text10);
							string absoluteUri2 = HttpContext.Current.Request.Url.AbsoluteUri;
							absoluteUri2 = text10 + "/Users/Home/ResetPassword?qs=" + getString2;
							ObjectParameter objectParameter2 = new ObjectParameter("ShortKey", typeof(string));
							Uri uri2 = new Uri(absoluteUri2);
							string domain2 = uri2.Scheme + "://" + uri2.Authority;
							_dbII.CRMspInsertShortLink(absoluteUri2, 11, item2.PrsId, null, null, null, null, DateTime.Now.AddDays(1.0), null, userId, value, registerDatePersian, appType, lCID, domain2, objectParameter2);
							string text14 = objectParameter2.Value?.ToString();
							list2.Add(new
							{
								PrsId = item2.PrsId,
								Link = text10 + "/s/" + text14 + " "
							});
						}
					}
					if (!string.IsNullOrWhiteSpace(emailBody))
					{
						emailBody = ((!Thread.CurrentThread.CurrentCulture.TextInfo.IsRightToLeft) ? ("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" /> <div dir=\"ltr\">" + emailBody + "</div>") : ("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" /> <div dir=\"rtl\">" + emailBody + "</div>"));
						List<string> list3 = new List<string>();
						foreach (Match item3 in Regex.Matches(emailBody, "<img.+?src=[\"'](.+?)[\"'].+?>", (RegexOptions)3))
						{
							string value2 = ((Capture)item3.Groups[1]).Value;
							if (!list3.Contains(value2))
							{
								list3.Add(value2);
							}
						}
						if (list3.Count > 0)
						{
							EmailSetting emailSetting = EmailSettings.Get();
							string text15 = ((emailSetting.EmailsAttachFilePath == null) ? "" : (emailSetting.EmailsAttachFilePath + (emailSetting.EmailsAttachFilePath.EndsWith("\\") ? "" : "\\")));
							try
							{
								string text16 = emailBody;
								foreach (string item4 in list3)
								{
									string text17 = item4.Replace("%2F", "/").Replace("%20", " ");
									string text18 = base.Server.MapPath(text17);
									string[] array = text18.Split(new char[1] { '.' });
									RandomText randomText = new RandomText();
									string text19 = DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + randomText.CreateRandomCode(5, WithNumber: true, false).Replace(" ", "").Trim() + "-" + DateTime.Now.ToString("yyyyMMdd") + "-" + DateTime.Now.ToString("HHmmss") + "." + array[^1];
									string newValue = text15 + text19;
									if (!new FTPclient(Configuration.PathFtp, Configuration.UserNameFtp, Configuration.PasswordFtp, Configuration.UsePassiveFtp).Upload(text18, emailSetting.EmailsAttachShareFilePathFtp + text19))
									{
										data = "";
										message = Messages.EmailSendingErrorInSaveImage;
										status = CommonResultStatusViewModel.Error;
										goto end_IL_02cb;
									}
									text16 = text16.Replace(item4, newValue);
								}
								emailBody = text16;
								goto IL_0859;
							}
							catch (Exception e)
							{
								ErrorSignal.FromCurrentContext().Raise(e);
								data = "";
								message = Messages.EmailSendingErrorInSaveImage;
								status = CommonResultStatusViewModel.Error;
							}
							break;
						}
					}
					goto IL_0859;
				}
				case 2:
					{
						string text3 = SysSeting.Get().FOUrl?.ToString() ?? "";
						if (!string.IsNullOrWhiteSpace(text3) && !text3.StartsWith("http"))
						{
							text3 = "http://" + text3;
						}
						text3 = text3.TrimEnd(new char[1] { '/' });
						if (!string.IsNullOrWhiteSpace(text3) && Enumerable.Any<GenerateAutoPrsMobileEmailViewModel>((IEnumerable<GenerateAutoPrsMobileEmailViewModel>)list))
						{
							foreach (GenerateAutoPrsMobileEmailViewModel item5 in Enumerable.Where<GenerateAutoPrsMobileEmailViewModel>((IEnumerable<GenerateAutoPrsMobileEmailViewModel>)list, (Func<GenerateAutoPrsMobileEmailViewModel, bool>)((GenerateAutoPrsMobileEmailViewModel x) => x.Selected)))
							{
								string text4 = CodeDecode.Codding(now.AddHours(24.0).ToString("yyyy/MM/dd HH:mm:ss"), Configuration.ForgotPassword);
								string text5 = CodeDecode.Codding(item5.PrsId.ToString(), Configuration.ForgotPassword);
								string text6 = CodeDecode.Codding(item5.Email.ToString(), Configuration.ForgotPassword);
								string getString = "dt=[" + text4 + "]id=[" + text5 + "]email=[" + text6 + "]pid=[" + text5 + "]";
								getString = CodeDecode.Codding(getString, Configuration.ForgotPassword);
								string absoluteUri = HttpContext.Current.Request.Url.AbsoluteUri;
								absoluteUri = text3 + "/Users/Home/ResetPassword?qs=" + getString;
								Uri uri = new Uri(absoluteUri);
								string domain = uri.Scheme + "://" + uri.Authority;
								ObjectParameter objectParameter = new ObjectParameter("ShortKey", typeof(string));
								_dbII.CRMspInsertShortLink(absoluteUri, 11, item5.PrsId, null, null, null, null, DateTime.Now.AddDays(1.0), null, userId, value, registerDatePersian, appType, lCID, domain, objectParameter);
								string text7 = objectParameter.Value?.ToString();
								list2.Add(new
								{
									PrsId = item5.PrsId,
									Link = text3 + "/s/" + text7 + " "
								});
							}
						}
						string text8 = new JavaScriptSerializer().Serialize((object)list2);
						string encryptionKey = XorCipher.PreparePublicKeyForSql();
						CRMSpIIEntities dbII = _dbII;
						objectJson = text8;
						CRMspInsertSmsTempMobileNumbersFromGenerateAutoUPForCmpPerson_Result cRMspInsertSmsTempMobileNumbersFromGenerateAutoUPForCmpPerson_Result = Enumerable.FirstOrDefault<CRMspInsertSmsTempMobileNumbersFromGenerateAutoUPForCmpPerson_Result>((IEnumerable<CRMspInsertSmsTempMobileNumbersFromGenerateAutoUPForCmpPerson_Result>)dbII.CRMspInsertSmsTempMobileNumbersFromGenerateAutoUPForCmpPerson(smsBody, userId, value, registerDatePersian, appType, lCID, result2, objectJson, encryptionKey));
						if (cRMspInsertSmsTempMobileNumbersFromGenerateAutoUPForCmpPerson_Result != null)
						{
							data = cRMspInsertSmsTempMobileNumbersFromGenerateAutoUPForCmpPerson_Result.Numbers + "|" + cRMspInsertSmsTempMobileNumbersFromGenerateAutoUPForCmpPerson_Result.Companies + "|" + cRMspInsertSmsTempMobileNumbersFromGenerateAutoUPForCmpPerson_Result.CompanyPersons + "|" + ((!cRMspInsertSmsTempMobileNumbersFromGenerateAutoUPForCmpPerson_Result.AllBodyCount.HasValue) ? new int?(0) : cRMspInsertSmsTempMobileNumbersFromGenerateAutoUPForCmpPerson_Result.AllBodyCount) + "|" + ((!cRMspInsertSmsTempMobileNumbersFromGenerateAutoUPForCmpPerson_Result.AllBodyCost.HasValue) ? new decimal?(default(decimal)) : cRMspInsertSmsTempMobileNumbersFromGenerateAutoUPForCmpPerson_Result.AllBodyCost) + "|" + cRMspInsertSmsTempMobileNumbersFromGenerateAutoUPForCmpPerson_Result.SMSBody + "|" + ((!cRMspInsertSmsTempMobileNumbersFromGenerateAutoUPForCmpPerson_Result.NumberCount.HasValue) ? new int?(0) : cRMspInsertSmsTempMobileNumbersFromGenerateAutoUPForCmpPerson_Result.NumberCount) + "|";
							message = Messages.msgSuccessAction;
							status = CommonResultStatusViewModel.Success;
						}
						else
						{
							data = "";
							message = Messages.msgErrorRunFunction;
							status = CommonResultStatusViewModel.Error;
						}
						break;
					}
					IL_0859:
					text9 = new JavaScriptSerializer().Serialize((object)list2);
					encryptionKey2 = XorCipher.PreparePublicKeyForSql();
					dbII2 = _dbII;
					objectJson = text9;
					mct_II_Result = Enumerable.FirstOrDefault<mct_II_Result>((IEnumerable<mct_II_Result>)dbII2.CRMspInsertEmailFromGenerateAutoUPForCmpPerson(emailBody, subject, emailUserInfoId, objectJson, userId, value, registerDatePersian, appType, lCID, result2, (result != 0) ? new int?(result) : null, encryptionKey2));
					if (mct_II_Result != null)
					{
						_ = mct_II_Result.Result;
						if (mct_II_Result.Result > 0)
						{
							data = "1";
							message = Messages.EmailSendingSuccessfully;
							status = CommonResultStatusViewModel.Success;
						}
						else
						{
							data = "";
							message = Messages.msgErrorRunFunction;
							status = CommonResultStatusViewModel.Error;
						}
					}
					break;
					end_IL_02cb:
					break;
				}
			}
			end_IL_000e:;
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			data = "";
			data2 = new CommonResultViewModel<string>
			{
				Data = data,
				Message = Messages.msgErrorRunFunction,
				Status = CommonResultStatusViewModel.Error
			};
			return Json(data2, JsonRequestBehavior.AllowGet);
		}
		data2 = new CommonResultViewModel<string>
		{
			Data = data,
			Message = message,
			Status = status
		};
		return Json(data2, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	[ValidateInput(false)]
	public JsonResult ActUpdateCompanyFOInfo(string companies, int referUserId, int suppUserId, bool fOAct, bool shpAct, bool shpDeAct, bool fODeAct, string shpActDt, string shpExpDt, string fOActDt, string fOExpDt)
	{
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_0226: Unknown result type (might be due to invalid IL or missing references)
		CommonResultStatusViewModel commonResultStatusViewModel = CommonResultStatusViewModel.Success;
		string data = "";
		string text = "";
		CommonResultViewModel<string> data2;
		try
		{
			if (!UserLogin.IsUserAccess("frmGenerateAutoCmpUP", "actCmpChangeFoInfo", UserLogin.CurrentUser))
			{
				data = "";
				text = Messages.ErrorNotAccess;
				commonResultStatusViewModel = CommonResultStatusViewModel.Error;
			}
			else if ((referUserId == 0 || referUserId == -1) && (suppUserId == 0 || suppUserId == -1) && !fOAct && !shpAct && !fODeAct && !shpDeAct)
			{
				data = "";
				text = Messages.msgErrorNotSelectedFilterToPerformAction;
				commonResultStatusViewModel = CommonResultStatusViewModel.Error;
			}
			else if (fOAct && fOActDt == null)
			{
				data = "";
				text = Messages.msgErrorNotSelectActivationDate;
				commonResultStatusViewModel = CommonResultStatusViewModel.Error;
			}
			else if (shpAct && shpActDt == null)
			{
				data = "";
				text = Messages.msgErrorNotSelectActivationDate;
				commonResultStatusViewModel = CommonResultStatusViewModel.Error;
			}
			else
			{
				switch (companies)
				{
				case null:
				case "":
				case "[]":
					data = "";
					text = Messages.msgErrorNotSelectedItem;
					commonResultStatusViewModel = CommonResultStatusViewModel.Error;
					break;
				default:
				{
					if (!fOAct)
					{
						fOActDt = null;
						fOExpDt = null;
					}
					if (!shpAct)
					{
						shpActDt = null;
						shpExpDt = null;
					}
					int result = 0;
					if (UserLogin.CurrentUser != null)
					{
						int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result);
					}
					int userId = UserLogin.CurrentUser.UserId;
					List<GenerateAutoCmpMobileEmailViewModel> list = new List<GenerateAutoCmpMobileEmailViewModel>();
					list = new JavaScriptSerializer().Deserialize<List<GenerateAutoCmpMobileEmailViewModel>>(companies);
					if (!Enumerable.Any<GenerateAutoCmpMobileEmailViewModel>((IEnumerable<GenerateAutoCmpMobileEmailViewModel>)list, (Func<GenerateAutoCmpMobileEmailViewModel, bool>)((GenerateAutoCmpMobileEmailViewModel cmp) => cmp.Selected)))
					{
						data = "";
						text = Messages.msgErrorNotSelectedItem;
						commonResultStatusViewModel = CommonResultStatusViewModel.Error;
						break;
					}
					string text2 = "";
					List<object> list2 = new List<object>();
					if (Enumerable.Any<GenerateAutoCmpMobileEmailViewModel>((IEnumerable<GenerateAutoCmpMobileEmailViewModel>)list))
					{
						foreach (GenerateAutoCmpMobileEmailViewModel item in Enumerable.Where<GenerateAutoCmpMobileEmailViewModel>((IEnumerable<GenerateAutoCmpMobileEmailViewModel>)list, (Func<GenerateAutoCmpMobileEmailViewModel, bool>)((GenerateAutoCmpMobileEmailViewModel cmp) => cmp.Selected)))
						{
							text2 = text2 + item.CmpId + ",";
							list2.Add(new { item.CmpId });
						}
					}
					DateTime? dateFromPersian = DateTimeClass.GetDateFromPersian(fOActDt);
					DateTime? dateFromPersian2 = DateTimeClass.GetDateFromPersian(fOExpDt);
					DateTime? dateFromPersian3 = DateTimeClass.GetDateFromPersian(shpActDt);
					DateTime? dateFromPersian4 = DateTimeClass.GetDateFromPersian(shpExpDt);
					string objectJson = new JavaScriptSerializer().Serialize((object)list2);
					int maxFOCount = Configuration.MaxFOCount;
					CRMspUpdateCompanyFoInfoFromRptFilterData_Result cRMspUpdateCompanyFoInfoFromRptFilterData_Result = Enumerable.FirstOrDefault<CRMspUpdateCompanyFoInfoFromRptFilterData_Result>((IEnumerable<CRMspUpdateCompanyFoInfoFromRptFilterData_Result>)_dbII.CRMspUpdateCompanyFoInfoFromRptFilterData(userId, result, objectJson, suppUserId, referUserId, shpAct, shpDeAct, dateFromPersian3, dateFromPersian4, fOAct, fODeAct, dateFromPersian, dateFromPersian2, maxFOCount));
					if (cRMspUpdateCompanyFoInfoFromRptFilterData_Result != null)
					{
						if (cRMspUpdateCompanyFoInfoFromRptFilterData_Result.Result == 1)
						{
							text = Messages.msgSuccessAction;
							commonResultStatusViewModel = CommonResultStatusViewModel.Success;
						}
						else if (cRMspUpdateCompanyFoInfoFromRptFilterData_Result.Result == -1)
						{
							text = string.Format(Messages.msgErrorUserLimitExceeded, cRMspUpdateCompanyFoInfoFromRptFilterData_Result.FOPendingActivationCount + cRMspUpdateCompanyFoInfoFromRptFilterData_Result.FOInfoNullCount + cRMspUpdateCompanyFoInfoFromRptFilterData_Result.FoActiveCount - maxFOCount, maxFOCount);
							commonResultStatusViewModel = CommonResultStatusViewModel.Error;
						}
						else
						{
							text = Messages.msgErrorRunFunction;
							commonResultStatusViewModel = CommonResultStatusViewModel.Error;
						}
					}
					else
					{
						text = Messages.msgErrorRunFunction;
						commonResultStatusViewModel = CommonResultStatusViewModel.Error;
					}
					break;
				}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			data = "";
			data2 = new CommonResultViewModel<string>
			{
				Data = data,
				Message = Messages.msgErrorRunFunction,
				Status = CommonResultStatusViewModel.Error
			};
			return Json(data2, JsonRequestBehavior.AllowGet);
		}
		data2 = new CommonResultViewModel<string>
		{
			Data = data,
			Message = text,
			Status = commonResultStatusViewModel
		};
		return Json(data2, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	[ValidateInput(false)]
	public JsonResult ActUpdateCmpPersonFOInfo(string persons, bool fOAct, bool shpAct, bool shpDeAct, bool fODeAct, string shpActDt, string shpExpDt, string fOActDt, string fOExpDt)
	{
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0222: Unknown result type (might be due to invalid IL or missing references)
		CommonResultStatusViewModel commonResultStatusViewModel = CommonResultStatusViewModel.Success;
		string data = "";
		string text = "";
		CommonResultViewModel<string> data2;
		try
		{
			if (!UserLogin.IsUserAccess("frmGenerateAutoPrsUP", "actPrsChangeFoInfo", UserLogin.CurrentUser))
			{
				data = "";
				text = Messages.ErrorNotAccess;
				commonResultStatusViewModel = CommonResultStatusViewModel.Error;
			}
			else if (!fOAct && !shpAct && !fODeAct && !shpDeAct)
			{
				data = "";
				text = Messages.msgErrorNotSelectedFilterToPerformAction;
				commonResultStatusViewModel = CommonResultStatusViewModel.Error;
			}
			else if (fOAct && fOActDt == null)
			{
				data = "";
				text = Messages.msgErrorNotSelectActivationDate;
				commonResultStatusViewModel = CommonResultStatusViewModel.Error;
			}
			else if (shpAct && shpActDt == null)
			{
				data = "";
				text = Messages.msgErrorNotSelectActivationDate;
				commonResultStatusViewModel = CommonResultStatusViewModel.Error;
			}
			else
			{
				switch (persons)
				{
				case null:
				case "":
				case "[]":
					data = "";
					text = Messages.msgErrorNotSelectedItem;
					commonResultStatusViewModel = CommonResultStatusViewModel.Error;
					break;
				default:
				{
					if (!fOAct)
					{
						fOActDt = null;
						fOExpDt = null;
					}
					if (!shpAct)
					{
						shpActDt = null;
						shpExpDt = null;
					}
					int result = 0;
					if (UserLogin.CurrentUser != null)
					{
						int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result);
					}
					int userId = UserLogin.CurrentUser.UserId;
					List<GenerateAutoPrsMobileEmailViewModel> list = new List<GenerateAutoPrsMobileEmailViewModel>();
					list = new JavaScriptSerializer().Deserialize<List<GenerateAutoPrsMobileEmailViewModel>>(persons);
					if (!Enumerable.Any<GenerateAutoPrsMobileEmailViewModel>((IEnumerable<GenerateAutoPrsMobileEmailViewModel>)list, (Func<GenerateAutoPrsMobileEmailViewModel, bool>)((GenerateAutoPrsMobileEmailViewModel prs) => prs.Selected)))
					{
						data = "";
						text = Messages.msgErrorNotSelectedItem;
						commonResultStatusViewModel = CommonResultStatusViewModel.Error;
						break;
					}
					string text2 = "";
					List<object> list2 = new List<object>();
					if (Enumerable.Any<GenerateAutoPrsMobileEmailViewModel>((IEnumerable<GenerateAutoPrsMobileEmailViewModel>)list))
					{
						foreach (GenerateAutoPrsMobileEmailViewModel item in Enumerable.Where<GenerateAutoPrsMobileEmailViewModel>((IEnumerable<GenerateAutoPrsMobileEmailViewModel>)list, (Func<GenerateAutoPrsMobileEmailViewModel, bool>)((GenerateAutoPrsMobileEmailViewModel cmp) => cmp.Selected)))
						{
							text2 = text2 + item.PrsId + ",";
							list2.Add(new { item.PrsId });
						}
					}
					_ = Thread.CurrentThread.CurrentCulture.LCID;
					DateTime? dateFromPersian = DateTimeClass.GetDateFromPersian(fOActDt);
					DateTime? dateFromPersian2 = DateTimeClass.GetDateFromPersian(fOExpDt);
					DateTime? dateFromPersian3 = DateTimeClass.GetDateFromPersian(shpActDt);
					DateTime? dateFromPersian4 = DateTimeClass.GetDateFromPersian(shpExpDt);
					string objectJson = new JavaScriptSerializer().Serialize((object)list2);
					_dbII.CRMspUpdateCmpPersonFoInfoFromRptFilterData(userId, result, objectJson, shpAct, shpDeAct, dateFromPersian3, dateFromPersian4, fOAct, fODeAct, dateFromPersian, dateFromPersian2);
					text = Messages.msgSuccessAction;
					commonResultStatusViewModel = CommonResultStatusViewModel.Success;
					break;
				}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			data = "";
			data2 = new CommonResultViewModel<string>
			{
				Data = data,
				Message = Messages.msgErrorRunFunction,
				Status = CommonResultStatusViewModel.Error
			};
			return Json(data2, JsonRequestBehavior.AllowGet);
		}
		data2 = new CommonResultViewModel<string>
		{
			Data = data,
			Message = text,
			Status = commonResultStatusViewModel
		};
		return Json(data2, JsonRequestBehavior.AllowGet);
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
