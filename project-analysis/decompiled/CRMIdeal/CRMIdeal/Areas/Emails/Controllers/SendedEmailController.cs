using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using CRM.General.Calendar;
using CRM.General.IO;
using CRM.General.IO.FTP;
using CRM.General.Security;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using MimeKit;

namespace CRMIdeal.Areas.Emails.Controllers;

public class SendedEmailController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actemSendedEmails")]
	public ActionResult Index()
	{
		GetEmailUser();
		GetEmailStatus();
		return View();
	}

	[AjaxOnly]
	public JsonResult GetEmailUser()
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
			List<CRMspSelectUserForLinkedType_Result> list2 = Enumerable.ToList<CRMspSelectUserForLinkedType_Result>((IEnumerable<CRMspSelectUserForLinkedType_Result>)_db.CRMspSelectUserForLinkedType(UserLogin.CurrentUser.UserId, 34, lCID, result, result2));
			list.AddRange(Enumerable.Select<CRMspSelectUserForLinkedType_Result, SelectListItem>((IEnumerable<CRMspSelectUserForLinkedType_Result>)list2, (Func<CRMspSelectUserForLinkedType_Result, SelectListItem>)((CRMspSelectUserForLinkedType_Result item) => new SelectListItem
			{
				Text = item.UserName,
				Value = item.LinkedUserId.ToString(),
				Selected = false
			})));
			if (Enumerable.Any<SelectListItem>((IEnumerable<SelectListItem>)list))
			{
				list[0].Selected = true;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.EmailUserList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetEmailStatus()
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
			list = GetEmailStatusList();
			if (Enumerable.Any<SelectListItem>((IEnumerable<SelectListItem>)list))
			{
				list[0].Selected = true;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.EmailStatusList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public List<SelectListItem> GetEmailStatusList()
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
			list.Add(new SelectListItem
			{
				Text = Labels.All,
				Value = "-100",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.SendedEmailStatusInQueue,
				Value = "0",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.SendedEmailStatusSent,
				Value = "1",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.SendedEmailStatusNotSent,
				Value = "-2",
				Selected = false
			});
			if (Enumerable.Any<SelectListItem>((IEnumerable<SelectListItem>)list))
			{
				list[0].Selected = true;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	public List<EmailspSelectSendedDetail_Result> ListEmailSended(int emailSenderId, int emailStatus, string fromDate, string toDate)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<EmailspSelectSendedDetail_Result> list = new List<EmailspSelectSendedDetail_Result>();
		try
		{
			if (!UserLogin.IsUserAccess("frmSendedEmails", "actConfirm"))
			{
				return list;
			}
			if (!string.IsNullOrWhiteSpace(fromDate) && !string.IsNullOrWhiteSpace(toDate))
			{
				toDate = toDate.Replace("/", "").Replace("-", "").Replace("\\", "")
					.Replace(" ", "")
					.Replace("_", "");
				fromDate = fromDate.Replace("/", "").Replace("-", "").Replace("\\", "")
					.Replace(" ", "")
					.Replace("_", "");
				DateTime value = DateTime.Now;
				DateTime value2 = DateTime.Now;
				if (!string.IsNullOrEmpty(fromDate))
				{
					value = DateTime.Parse(PersianDate.GetFormatetdDate(fromDate.Replace("/", "")) + " 00:00:00", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrEmpty(toDate))
				{
					value2 = DateTime.Parse(PersianDate.GetFormatetdDate(toDate.Replace("/", "")) + " 23:59:59", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				list = Enumerable.ToList<EmailspSelectSendedDetail_Result>((IEnumerable<EmailspSelectSendedDetail_Result>)_dbII.EmailspSelectSendedDetail(emailSenderId, statusId: emailStatus, fDateTime: value, tDateTime: value2, languageID: lCID, defaultLanguageID: result, searchedValue: null));
				List<SelectListItem> emailStatusList = GetEmailStatusList();
				if (list == null)
				{
					list = new List<EmailspSelectSendedDetail_Result>();
				}
				else if (Enumerable.Any<EmailspSelectSendedDetail_Result>((IEnumerable<EmailspSelectSendedDetail_Result>)list))
				{
					foreach (EmailspSelectSendedDetail_Result item in list)
					{
						EmailspSelectSendedDetail_Result emailspSelectSendedDetail_Result = item;
						_ = item.SendDateTime;
						emailspSelectSendedDetail_Result.SendDatePersian = item.SendDateTime.ToString("yyyy/MM/dd HH:mm:ss");
						item.SendedDatePersian = (item.SendedDateTime.HasValue ? item.SendedDateTime.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
						item.CompanyName += ((!string.IsNullOrWhiteSpace(item.PersonName)) ? (" (" + item.PersonName + ")") : "");
						if (emailStatusList != null)
						{
							SelectListItem selectListItem = Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)emailStatusList, (Func<SelectListItem, bool>)((SelectListItem m) => m.Value == item.StatusId.ToString()));
							if (selectListItem != null)
							{
								item.StatusTitle = selectListItem.Text ?? "";
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
		return list;
	}

	[AjaxOnly]
	public ActionResult EmailSended_Read([DataSourceRequest] DataSourceRequest request, int emailSenderId, int emailStatus, string fromDate, string toDate)
	{
		JsonResult jsonResult = Json(((IEnumerable)ListEmailSended(emailSenderId, emailStatus, fromDate, toDate)).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public ActionResult GetListEmailSended(int emailSenderId, int emailStatus, string fromDate, string toDate)
	{
		JsonResult jsonResult = Json(ListEmailSended(emailSenderId, emailStatus, fromDate, toDate), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmSendedEmails", ActionName = "actDeleteEmail")]
	public string ActDeleteEmail(int headerId, int detailId)
	{
		string text = "";
		try
		{
			if (headerId > 0 && detailId > 0)
			{
				try
				{
					mct_II_Result mct_II_Result = Enumerable.FirstOrDefault<mct_II_Result>((IEnumerable<mct_II_Result>)_dbII.EmailspDeleteSendedFull(headerId, detailId));
					int result = 0;
					if (mct_II_Result != null)
					{
						int.TryParse(mct_II_Result.Result.ToString(), out result);
					}
					if (result == 1)
					{
						return "1";
					}
					return Messages.RedundancyMessage;
				}
				catch (DbEntityValidationException e)
				{
					ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
					return Messages.msgErrorRunFunction;
				}
				catch (Exception ex)
				{
					ErrorSignal.FromCurrentContext().Raise(ex);
					return Messages.msgErrorCommunicateWithServer + "<br><p style=text-align:left;>" + ex.Message + "</p>";
				}
			}
			return Messages.ErrorNotFound;
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			return Messages.frmErrorMessage;
		}
	}

	public ActionResult ShowEmailDetails(int detailId)
	{
		//IL_0466: Unknown result type (might be due to invalid IL or missing references)
		//IL_0482: Unknown result type (might be due to invalid IL or missing references)
		//IL_0489: Expected O, but got Unknown
		CurrentEmailSendedViewModel currentEmailSendedViewModel = new CurrentEmailSendedViewModel();
		currentEmailSendedViewModel.EmailInfo = new EmailspSelectSendedDetailById_Result();
		currentEmailSendedViewModel.Attachments = new List<EmailspSelectSendedAttachment_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			EmailspSelectSendedDetailById_Result item = Enumerable.FirstOrDefault<EmailspSelectSendedDetailById_Result>((IEnumerable<EmailspSelectSendedDetailById_Result>)_dbII.EmailspSelectSendedDetailById(detailId, lCID, result));
			if (item != null)
			{
				EmailspSelectSendedDetailById_Result emailspSelectSendedDetailById_Result = item;
				_ = item.StartDateTime;
				emailspSelectSendedDetailById_Result.StartDatePersian = item.StartDateTime.ToString("yyyy-MM-dd HH:mm:ss");
				item.EndDatePersian = (item.EndDateTime.HasValue ? item.EndDateTime.Value.ToString("yyyy-MM-dd HH:mm:ss") : "");
				EmailspSelectSendedDetailById_Result emailspSelectSendedDetailById_Result2 = item;
				_ = item.SendDateTime;
				emailspSelectSendedDetailById_Result2.SendDatePersian = item.SendDateTime.ToString("yyyy-MM-dd HH:mm:ss");
				item.SendedDatePersian = (item.SendedDateTime.HasValue ? item.SendedDateTime.Value.ToString("yyyy-MM-dd HH:mm:ss") : "");
				item.CompanyName += ((!string.IsNullOrWhiteSpace(item.PersonName)) ? (" (" + item.PersonName + ")") : "");
				List<SelectListItem> emailStatusList = GetEmailStatusList();
				if (emailStatusList != null)
				{
					SelectListItem selectListItem = Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)emailStatusList, (Func<SelectListItem, bool>)((SelectListItem m) => m.Value == item.StatusId.ToString()));
					if (selectListItem != null)
					{
						item.StatusTitle = selectListItem.Text ?? "";
					}
				}
				EmailspSelectEmailSetting_Result emailspSelectEmailSetting_Result = Enumerable.FirstOrDefault<EmailspSelectEmailSetting_Result>((IEnumerable<EmailspSelectEmailSetting_Result>)_db.EmailspSelectEmailSetting("", ""));
				string oldValue = ((emailspSelectEmailSetting_Result.EmailsAttachFilePath == null) ? "" : (emailspSelectEmailSetting_Result.EmailsAttachFilePath + (emailspSelectEmailSetting_Result.EmailsAttachFilePath.EndsWith("\\") ? "" : "\\")));
				if (emailspSelectEmailSetting_Result.EmailsPDFBodyFilePathFtp != null)
				{
					_ = emailspSelectEmailSetting_Result.EmailsPDFBodyFilePathFtp + (emailspSelectEmailSetting_Result.EmailsPDFBodyFilePathFtp.EndsWith("/") ? "" : "/");
				}
				string text = ((emailspSelectEmailSetting_Result.EmailsAttachShareFilePathFtp == null) ? "" : (emailspSelectEmailSetting_Result.EmailsAttachShareFilePathFtp + (emailspSelectEmailSetting_Result.EmailsAttachShareFilePathFtp.EndsWith("/") ? "" : "/")));
				string text2 = HostingEnvironment.MapPath(Configuration.HostTempFilesPath + "/Emails/SendFile");
				string text3 = Configuration.HostTempFilesPath + "/Emails/SendFile";
				text3 = text3.Replace("~", "");
				if (!System.IO.Directory.Exists(text2))
				{
					System.IO.Directory.CreateDirectory(text2);
					CRM.General.IO.Directory.SetFullControlForEveryOne(text2);
				}
				else
				{
					text2 = text2 + "/" + item.EmailSendHeaderId;
					text3 = text3 + "/" + item.EmailSendHeaderId;
					if (!System.IO.Directory.Exists(text2))
					{
						System.IO.Directory.CreateDirectory(text2);
						CRM.General.IO.Directory.SetFullControlForEveryOne(text2);
					}
				}
				FacadeFTP facadeFTP = new FacadeFTP(Configuration.FacadeFtp);
				string pathFtp = Configuration.PathFtp;
				string userNameFtp = Configuration.UserNameFtp;
				string passwordFtp = Configuration.PasswordFtp;
				bool usePassiveFtp = Configuration.UsePassiveFtp;
				string cmpPattern = emailspSelectEmailSetting_Result.CmpPattern;
				string cmpPrsPattern = emailspSelectEmailSetting_Result.CmpPrsPattern;
				string cmpPrsJobPattern = emailspSelectEmailSetting_Result.CmpPrsJobPattern;
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				string text4 = (item.Body ?? "").Replace(cmpPattern, item.EmailCmpName ?? "").Replace(cmpPrsPattern, item.EmailCmpPrsName ?? "").Replace(cmpPrsJobPattern, item.EmailPrsJob ?? "") + "<p style='display:none;'>" + DateTime.Now.ToString("R") + "</p>";
				foreach (Match item2 in new Regex("[a-z]:\\\\(?:[^\\\\:]+\\\\)*((?:[^:\\\\]+)\\.\\w+)", (RegexOptions)1).Matches(text4))
				{
					Match val = item2;
					string text5 = Guid.NewGuid().ToString();
					text4 = text4.Replace(((Capture)val).Value, "cid:" + text5);
					dictionary.Add(text5, ((Capture)val).Value);
				}
				new BodyBuilder().HtmlBody = text4;
				if (dictionary != null)
				{
					foreach (string key in dictionary.Keys)
					{
						string text6 = dictionary[key];
						string value = "";
						string newValue = "";
						if (!string.IsNullOrWhiteSpace(text6))
						{
							text6 = text6.Replace(oldValue, "");
							string text7 = text2 + "/" + text6;
							string source = text + text6;
							newValue = text3 + "/" + text6;
							if (!System.IO.File.Exists(text7))
							{
								if (facadeFTP.Download(pathFtp, userNameFtp, passwordFtp, text7, source, overwrite: true, usePassiveFtp))
								{
									value = text7;
								}
							}
							else
							{
								value = text7;
							}
						}
						if (!string.IsNullOrWhiteSpace(value))
						{
							text4 = text4.Replace("cid:" + key, newValue);
						}
					}
				}
				item.Body = text4;
				currentEmailSendedViewModel.Attachments = Enumerable.ToList<EmailspSelectSendedAttachment_Result>((IEnumerable<EmailspSelectSendedAttachment_Result>)_dbII.EmailspSelectSendedAttachment(item.EmailSendHeaderId, 0));
			}
			currentEmailSendedViewModel.EmailInfo = item;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return View(currentEmailSendedViewModel);
	}

	[DynamicAuthorize(ControllerName = "frmReceiveEmail", ActionName = "actOpenFile")]
	[AjaxOnly]
	public string GetFilePath(int fileId)
	{
		string text = "";
		if (fileId > 0)
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			try
			{
				EmailspSelectSendedAttachment_Result emailspSelectSendedAttachment_Result = Enumerable.FirstOrDefault<EmailspSelectSendedAttachment_Result>((IEnumerable<EmailspSelectSendedAttachment_Result>)_dbII.EmailspSelectSendedAttachment(0, fileId));
				if (emailspSelectSendedAttachment_Result != null)
				{
					EmailspSelectEmailSetting_Result emailspSelectEmailSetting_Result = Enumerable.FirstOrDefault<EmailspSelectEmailSetting_Result>((IEnumerable<EmailspSelectEmailSetting_Result>)_db.EmailspSelectEmailSetting("", ""));
					string oldValue = ((emailspSelectEmailSetting_Result.EmailsAttachFilePath == null) ? "" : (emailspSelectEmailSetting_Result.EmailsAttachFilePath + (emailspSelectEmailSetting_Result.EmailsAttachFilePath.EndsWith("\\") ? "" : "\\")));
					if (emailspSelectEmailSetting_Result.EmailsPDFBodyFilePathFtp != null)
					{
						_ = emailspSelectEmailSetting_Result.EmailsPDFBodyFilePathFtp + (emailspSelectEmailSetting_Result.EmailsPDFBodyFilePathFtp.EndsWith("/") ? "" : "/");
					}
					string text2 = ((emailspSelectEmailSetting_Result.EmailsAttachShareFilePathFtp == null) ? "" : (emailspSelectEmailSetting_Result.EmailsAttachShareFilePathFtp + (emailspSelectEmailSetting_Result.EmailsAttachShareFilePathFtp.EndsWith("/") ? "" : "/")));
					string text3 = HostingEnvironment.MapPath(Configuration.HostTempFilesPath + "/Emails/SendFile");
					if (!System.IO.Directory.Exists(text3))
					{
						System.IO.Directory.CreateDirectory(text3);
						CRM.General.IO.Directory.SetFullControlForEveryOne(text3);
					}
					else
					{
						text3 = text3 + "/" + emailspSelectSendedAttachment_Result.EmailSendHeaderId;
						if (!System.IO.Directory.Exists(text3))
						{
							System.IO.Directory.CreateDirectory(text3);
							CRM.General.IO.Directory.SetFullControlForEveryOne(text3);
						}
					}
					FacadeFTP facadeFTP = new FacadeFTP(Configuration.FacadeFtp);
					string pathFtp = Configuration.PathFtp;
					string userNameFtp = Configuration.UserNameFtp;
					string passwordFtp = Configuration.PasswordFtp;
					bool usePassiveFtp = Configuration.UsePassiveFtp;
					string text4 = emailspSelectSendedAttachment_Result.FilePath;
					if (!string.IsNullOrWhiteSpace(text4))
					{
						text4 = text4.Replace(oldValue, "");
						string text5 = text3 + "/" + text4;
						string source = text2 + text4;
						text4 = (System.IO.File.Exists(text5) ? text5 : ((!facadeFTP.Download(pathFtp, userNameFtp, passwordFtp, text5, source, overwrite: true, usePassiveFtp)) ? "" : text5));
					}
					if (!string.IsNullOrWhiteSpace(text4) && System.IO.File.Exists(text4))
					{
						text = text4;
					}
					if (!string.IsNullOrWhiteSpace(text))
					{
						text = HttpUtility.UrlEncode(text);
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

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbI.Dispose();
		_dbII.Dispose();
		base.Dispose(disposing);
	}
}
