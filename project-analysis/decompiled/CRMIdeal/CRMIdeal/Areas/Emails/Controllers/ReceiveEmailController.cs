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
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using CRMIdeal.Hubs;
using Elmah;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using MimeKit;

namespace CRMIdeal.Areas.Emails.Controllers;

public class ReceiveEmailController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actemReceiveEmail")]
	public ActionResult Index()
	{
		base.ViewBag.IsBuying = VersionBuyer.Emails;
		GetEmailUsersInfo();
		return View();
	}

	[AjaxOnly]
	public JsonResult GetEmailUsersInfo()
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
			List<EmailspSelectActiveEmailUsersInfoByUserId_Result> list2 = Enumerable.ToList<EmailspSelectActiveEmailUsersInfoByUserId_Result>((IEnumerable<EmailspSelectActiveEmailUsersInfoByUserId_Result>)_db.EmailspSelectActiveEmailUsersInfoByUserId(UserLogin.CurrentUser.UserId));
			SelectListItem item2 = new SelectListItem
			{
				Text = Labels.All,
				Value = "-1",
				Selected = true
			};
			list.Add(item2);
			list.AddRange(Enumerable.Select<EmailspSelectActiveEmailUsersInfoByUserId_Result, SelectListItem>((IEnumerable<EmailspSelectActiveEmailUsersInfoByUserId_Result>)list2, (Func<EmailspSelectActiveEmailUsersInfoByUserId_Result, SelectListItem>)((EmailspSelectActiveEmailUsersInfoByUserId_Result item) => new SelectListItem
			{
				Text = item.euNikeEmail,
				Value = item.EmailUsersInfoId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.EmailUsersInfoList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public ActionResult _PartialEmailReceiveFoldersTree(int emailUsersInfoId)
	{
		List<EmailspSelectEmailReceiveFoldersTree_Result> list = new List<EmailspSelectEmailReceiveFoldersTree_Result>();
		list = GetEmailReceiveFoldersTree(emailUsersInfoId);
		return PartialView(list);
	}

	public List<EmailspSelectEmailReceiveFoldersTree_Result> GetEmailReceiveFoldersTree(int emailUsersInfoId)
	{
		List<EmailspSelectEmailReceiveFoldersTree_Result> result = new List<EmailspSelectEmailReceiveFoldersTree_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			int userId = UserLogin.CurrentUser.UserId;
			string allEmailText = "All";
			result = Enumerable.ToList<EmailspSelectEmailReceiveFoldersTree_Result>((IEnumerable<EmailspSelectEmailReceiveFoldersTree_Result>)_db.EmailspSelectEmailReceiveFoldersTree(emailUsersInfoId, userId, allEmailText));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[DynamicAuthorize(ControllerName = "frmReceiveEmail", ActionName = "actGetEmailFromServer")]
	public ActionResult GetEmailsFromServer()
	{
		GetEmailUsersInfo();
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmReceiveEmail", ActionName = "actGetEmailFromServer")]
	public ActionResult ReceiveEmailsFromServer(int emailUsersInfoId, string fromDate, string toDate)
	{
		base.ViewBag.EmailUsersInfoId = emailUsersInfoId;
		base.ViewBag.FromDate = fromDate;
		base.ViewBag.ToDate = toDate;
		base.ViewBag.IsBuying = VersionBuyer.Emails;
		return View();
	}

	[AjaxOnly]
	public JsonResult ReceiveAllEmailsFromServer(int emailUsersInfoId, string fromDate, string toDate, bool useInJob = false, bool noSetDateToQry = false)
	{
		bool flag = false;
		string message = "";
		CommonResultStatusViewModel status = CommonResultStatusViewModel.Success;
		int num = -3;
		if (UserLogin.CurrentUser != null)
		{
			num = UserLogin.CurrentUser.UserId;
		}
		CommonResultViewModel<bool> data;
		if (useInJob && !VersionBuyer.Emails)
		{
			data = new CommonResultViewModel<bool>
			{
				Data = false,
				Message = "No Module",
				Status = status
			};
			return Json(data, JsonRequestBehavior.AllowGet);
		}
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime fromDate2 = DateTime.Now;
			DateTime toDate2 = DateTime.Now;
			if (!string.IsNullOrEmpty(fromDate))
			{
				fromDate = fromDate.Replace("/", "").Replace("-", "").Replace("\\", "")
					.Replace(" ", "")
					.Replace("_", "");
				fromDate2 = lCID switch
				{
					1065 => DateTime.Parse(PersianDate.GetFormatetdDate(fromDate) + " 00:00:00"), 
					1025 => DateTime.Parse(PersianDate.GetFormatetdDate(fromDate) + " 00:00:00", new CultureInfo("ar-SA"), DateTimeStyles.None), 
					_ => DateTime.Parse(PersianDate.GetFormatetdDate(fromDate) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None), 
				};
			}
			if (!string.IsNullOrEmpty(toDate))
			{
				toDate = toDate.Replace("/", "").Replace("-", "").Replace("\\", "")
					.Replace(" ", "")
					.Replace("_", "");
				toDate2 = lCID switch
				{
					1065 => DateTime.Parse(PersianDate.GetFormatetdDate(toDate) + " 23:59:59"), 
					1025 => DateTime.Parse(PersianDate.GetFormatetdDate(toDate) + " 23:59:59", new CultureInfo("ar-SA"), DateTimeStyles.None), 
					_ => DateTime.Parse(PersianDate.GetFormatetdDate(toDate) + " 23:59:59", new CultureInfo("en-US"), DateTimeStyles.None), 
				};
			}
			if (emailUsersInfoId == -1)
			{
				List<EmailspSelectActiveEmailUsersInfoByUserId_Result> list = Enumerable.ToList<EmailspSelectActiveEmailUsersInfoByUserId_Result>((IEnumerable<EmailspSelectActiveEmailUsersInfoByUserId_Result>)_db.EmailspSelectActiveEmailUsersInfoByUserId(num));
				if (Enumerable.Any<EmailspSelectActiveEmailUsersInfoByUserId_Result>((IEnumerable<EmailspSelectActiveEmailUsersInfoByUserId_Result>)list))
				{
					foreach (EmailspSelectActiveEmailUsersInfoByUserId_Result item in list)
					{
						if (Email.ReceiveAllEmailForAccount(item.EmailUsersInfoId, null, fromDate2, toDate2, ref message, useInJob, noSetDateToQry))
						{
							ProgressHub.SendMessage("<br/><br/><br/>" + string.Format(Messages.msgCompleteRecEmails, item.euNikeEmail) + "<br/>=============================================================<br/>=============================================================<br/>=============================================================", 0, num);
							message = "";
						}
						else
						{
							ProgressHub.SendMessage(message, 0, num);
						}
					}
				}
				if (!string.IsNullOrEmpty(message))
				{
					flag = false;
					status = CommonResultStatusViewModel.Fail;
					ProgressHub.SendMessage(message, 0, num);
				}
				else
				{
					message = Messages.msgSuccessAction;
					flag = true;
					status = CommonResultStatusViewModel.Success;
				}
			}
			else if (emailUsersInfoId > 0)
			{
				EmailspSelectEmailUsersInfoById_Result emailspSelectEmailUsersInfoById_Result = Enumerable.FirstOrDefault<EmailspSelectEmailUsersInfoById_Result>((IEnumerable<EmailspSelectEmailUsersInfoById_Result>)_db.EmailspSelectEmailUsersInfoById(emailUsersInfoId));
				if (emailspSelectEmailUsersInfoById_Result != null)
				{
					if (Email.ReceiveAllEmailForAccount(emailspSelectEmailUsersInfoById_Result.EmailUsersInfoId, emailspSelectEmailUsersInfoById_Result, fromDate2, toDate2, ref message, useInJob, noSetDateToQry))
					{
						ProgressHub.SendMessage("<br/><br/><br/>" + string.Format(Messages.msgCompleteRecEmails, emailspSelectEmailUsersInfoById_Result.euNikeEmail) + "<br/>=============================================================<br/>=============================================================<br/>=============================================================", 0, num);
						message = "";
					}
					else
					{
						ProgressHub.SendMessage(message, 0, num);
					}
					if (!string.IsNullOrEmpty(message))
					{
						flag = false;
						status = CommonResultStatusViewModel.Fail;
						ProgressHub.SendMessage(message, 0, num);
					}
					else
					{
						message = Messages.msgSuccessAction;
						flag = true;
						status = CommonResultStatusViewModel.Success;
					}
				}
				else
				{
					message = string.Format(Messages.msgErrorIsNotFound, Labels.ReceiveEmailUserEmail);
					flag = false;
					status = CommonResultStatusViewModel.Error;
					ProgressHub.SendMessage(message, 0, num);
				}
			}
			else
			{
				message = string.Format(Messages.msgErrorIsNotFound, Labels.ReceiveEmailUserEmail);
				flag = false;
				status = CommonResultStatusViewModel.Error;
				ProgressHub.SendMessage(message, 0, num);
			}
		}
		catch (Exception ex)
		{
			Logs.LogError(ex, "");
			message = ex.Message;
			flag = false;
			status = CommonResultStatusViewModel.Error;
			ProgressHub.SendMessage(message, 0, num);
		}
		data = new CommonResultViewModel<bool>
		{
			Data = flag,
			Message = message,
			Status = status
		};
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult EmailReceive(int currId, int countNumber, int emailUsersInfoId, int emailReceiveFolderId, string folderName)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<EmailspSelectEmailReceive_Result> list = new List<EmailspSelectEmailReceive_Result>();
		try
		{
			if (emailUsersInfoId > 0 || emailReceiveFolderId > 0 || !string.IsNullOrEmpty(folderName))
			{
				list = Enumerable.ToList<EmailspSelectEmailReceive_Result>((IEnumerable<EmailspSelectEmailReceive_Result>)_db.EmailspSelectEmailReceive(currId, countNumber, emailUsersInfoId, emailReceiveFolderId, folderName, UserLogin.CurrentUser.UserId, lCID, result, 0, 1000000, 0));
				foreach (EmailspSelectEmailReceive_Result item in list)
				{
					item.EmailDatePersian = (item.EmailDate.HasValue ? item.EmailDate.Value.ToString("yyyy-MM-dd HH:mm:ss") : "");
					item.ReceiveDatePersian = (item.ReceiveDate.HasValue ? item.ReceiveDate.Value.ToString("yyyy-MM-dd HH:mm:ss") : "");
					item.ReadDatePersian = (item.ReadDate.HasValue ? item.ReadDate.Value.ToString("yyyy-MM-dd HH:mm:ss") : "");
					_ = item.FirstRegisterDate;
					item.FirstRegisterDatePersian = item.FirstRegisterDate.ToString("yyyy-MM-dd HH:mm:ss");
					_ = item.RegisterDate;
					item.RegisterDatePersian = item.RegisterDate.ToString("yyyy-MM-dd HH:mm:ss");
					item.CompanyName += ((!string.IsNullOrWhiteSpace(item.PersonName)) ? (" (" + item.PersonName + ")") : "");
				}
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
	public ActionResult EmailReceive_Read([DataSourceRequest] DataSourceRequest request, int emailUsersInfoId, int emailReceiveFolderId, string folderName)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<EmailspSelectEmailReceive_Result> enumerable = new List<EmailspSelectEmailReceive_Result>();
		try
		{
			if (emailUsersInfoId <= 0 && emailReceiveFolderId <= 0)
			{
				string.IsNullOrEmpty(folderName);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(((IEnumerable)enumerable).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public ActionResult ShowEmailInfo(int emailReceiveId = 0, int mode = 1)
	{
		//IL_046e: Unknown result type (might be due to invalid IL or missing references)
		//IL_048a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0491: Expected O, but got Unknown
		CurrentEmailReceiveViewModel currentEmailReceiveViewModel = new CurrentEmailReceiveViewModel();
		currentEmailReceiveViewModel.EmailInfo = new EmailspSelectEmailReceiveAndSendById_Result();
		currentEmailReceiveViewModel.Attachments = new List<EmailspSelectEmailReceiveAttachments_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			EmailspSelectEmailReceiveAndSendById_Result emailspSelectEmailReceiveAndSendById_Result = Enumerable.FirstOrDefault<EmailspSelectEmailReceiveAndSendById_Result>((IEnumerable<EmailspSelectEmailReceiveAndSendById_Result>)_dbII.EmailspSelectEmailReceiveAndSendById(mode, emailReceiveId, lCID, result));
			if (emailspSelectEmailReceiveAndSendById_Result != null)
			{
				emailspSelectEmailReceiveAndSendById_Result.EmailDatePersian = (emailspSelectEmailReceiveAndSendById_Result.EmailDate.HasValue ? emailspSelectEmailReceiveAndSendById_Result.EmailDate.Value.ToString("yyyy-MM-dd HH:mm:ss") : "");
				emailspSelectEmailReceiveAndSendById_Result.ReceiveDatePersian = (emailspSelectEmailReceiveAndSendById_Result.ReceiveDate.HasValue ? emailspSelectEmailReceiveAndSendById_Result.ReceiveDate.Value.ToString("yyyy-MM-dd HH:mm:ss") : "");
				emailspSelectEmailReceiveAndSendById_Result.ReadDatePersian = (emailspSelectEmailReceiveAndSendById_Result.ReadDate.HasValue ? emailspSelectEmailReceiveAndSendById_Result.ReadDate.Value.ToString("yyyy-MM-dd HH:mm:ss") : "");
				_ = emailspSelectEmailReceiveAndSendById_Result.FirstRegisterDate;
				emailspSelectEmailReceiveAndSendById_Result.FirstRegisterDatePersian = emailspSelectEmailReceiveAndSendById_Result.FirstRegisterDate.ToString("yyyy-MM-dd HH:mm:ss");
				_ = emailspSelectEmailReceiveAndSendById_Result.RegisterDate;
				emailspSelectEmailReceiveAndSendById_Result.RegisterDatePersian = emailspSelectEmailReceiveAndSendById_Result.RegisterDate.ToString("yyyy-MM-dd HH:mm:ss");
				emailspSelectEmailReceiveAndSendById_Result.CompanyName += ((!string.IsNullOrWhiteSpace(emailspSelectEmailReceiveAndSendById_Result.PersonName)) ? (" (" + emailspSelectEmailReceiveAndSendById_Result.PersonName + ")") : "");
				switch (mode)
				{
				case 1:
				{
					currentEmailReceiveViewModel.Attachments = Enumerable.ToList<EmailspSelectEmailReceiveAttachments_Result>((IEnumerable<EmailspSelectEmailReceiveAttachments_Result>)_db.EmailspSelectEmailReceiveAttachments(0, emailspSelectEmailReceiveAndSendById_Result.EmailReceiveId, lCID, result));
					DateTime now = DateTime.Now;
					string readDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					_db.EmailspUpdateEmailReceiveIsRead(emailspSelectEmailReceiveAndSendById_Result.EmailReceiveId, true, now, readDatePersian);
					break;
				}
				case 2:
				{
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
						text2 = text2 + "/" + emailspSelectEmailReceiveAndSendById_Result.EmailSendHeaderId;
						text3 = text3 + "/" + emailspSelectEmailReceiveAndSendById_Result.EmailSendHeaderId;
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
					string text4 = (emailspSelectEmailReceiveAndSendById_Result.HtmlBody ?? "").Replace(cmpPattern, emailspSelectEmailReceiveAndSendById_Result.CompanyName ?? "").Replace(cmpPrsPattern, emailspSelectEmailReceiveAndSendById_Result.PersonName ?? "").Replace(cmpPrsJobPattern, "") + "<p style='display:none;'>" + DateTime.Now.ToString("R") + "</p>";
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
					emailspSelectEmailReceiveAndSendById_Result.HtmlBody = text4;
					List<EmailspSelectSendedAttachment_Result> list = Enumerable.ToList<EmailspSelectSendedAttachment_Result>((IEnumerable<EmailspSelectSendedAttachment_Result>)_dbII.EmailspSelectSendedAttachment(emailspSelectEmailReceiveAndSendById_Result.EmailSendHeaderId, 0));
					if (list == null || !Enumerable.Any<EmailspSelectSendedAttachment_Result>((IEnumerable<EmailspSelectSendedAttachment_Result>)list))
					{
						break;
					}
					foreach (EmailspSelectSendedAttachment_Result item3 in list)
					{
						string[] array = item3.FileName.Split(new char[1] { '.' });
						string fileType = "";
						if (array != null)
						{
							fileType = array[^1];
						}
						EmailspSelectEmailReceiveAttachments_Result item = new EmailspSelectEmailReceiveAttachments_Result
						{
							EmailReceiveAttachmentId = item3.EmailSendAttachmentId,
							EmailReceiveId = item3.EmailSendHeaderId,
							ContentId = item3.ReceiveContentId,
							FileName = item3.FileName,
							SaveFilePath = item3.FilePath,
							FileType = fileType,
							CompanyId = emailspSelectEmailReceiveAndSendById_Result.CompanyId,
							CompanyName = emailspSelectEmailReceiveAndSendById_Result.CompanyName,
							CompanyPersonId = emailspSelectEmailReceiveAndSendById_Result.CompanyPersonId,
							PersonName = emailspSelectEmailReceiveAndSendById_Result.PersonName,
							ProjectId = emailspSelectEmailReceiveAndSendById_Result.ProjectId,
							Project = emailspSelectEmailReceiveAndSendById_Result.Project,
							FirstRegisterUserId = item3.FirstRegisterUserId.GetValueOrDefault(),
							FirstRegisterUser = "",
							FirstRegisterDate = (item3.FirstRegisterDate ?? emailspSelectEmailReceiveAndSendById_Result.FirstRegisterDate),
							FirstRegisterDatePersian = item3.FirstRegisterDatePersian,
							UserId = item3.FirstRegisterUserId.GetValueOrDefault(),
							EditUser = "",
							Year1 = 0,
							Month1 = 0,
							RegisterDate = (item3.FirstRegisterDate ?? emailspSelectEmailReceiveAndSendById_Result.FirstRegisterDate),
							RegisterDatePersian = item3.FirstRegisterDatePersian,
							GUId = item3.GUId,
							AppType = item3.AppType,
							LanguageID = item3.LanguageID.GetValueOrDefault(result)
						};
						currentEmailReceiveViewModel.Attachments.Add(item);
					}
					break;
				}
				}
			}
			currentEmailReceiveViewModel.EmailInfo = emailspSelectEmailReceiveAndSendById_Result;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return View(currentEmailReceiveViewModel);
	}

	[AjaxOnly]
	public ActionResult _PartialEmailReceiveInfo(int emailReceiveId, int mode = 1)
	{
		//IL_046e: Unknown result type (might be due to invalid IL or missing references)
		//IL_048a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0491: Expected O, but got Unknown
		CurrentEmailReceiveViewModel currentEmailReceiveViewModel = new CurrentEmailReceiveViewModel();
		currentEmailReceiveViewModel.EmailInfo = new EmailspSelectEmailReceiveAndSendById_Result();
		currentEmailReceiveViewModel.Attachments = new List<EmailspSelectEmailReceiveAttachments_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			EmailspSelectEmailReceiveAndSendById_Result emailspSelectEmailReceiveAndSendById_Result = Enumerable.FirstOrDefault<EmailspSelectEmailReceiveAndSendById_Result>((IEnumerable<EmailspSelectEmailReceiveAndSendById_Result>)_dbII.EmailspSelectEmailReceiveAndSendById(mode, emailReceiveId, lCID, result));
			if (emailspSelectEmailReceiveAndSendById_Result != null)
			{
				emailspSelectEmailReceiveAndSendById_Result.EmailDatePersian = (emailspSelectEmailReceiveAndSendById_Result.EmailDate.HasValue ? emailspSelectEmailReceiveAndSendById_Result.EmailDate.Value.ToString("yyyy-MM-dd HH:mm:ss") : "");
				emailspSelectEmailReceiveAndSendById_Result.ReceiveDatePersian = (emailspSelectEmailReceiveAndSendById_Result.ReceiveDate.HasValue ? emailspSelectEmailReceiveAndSendById_Result.ReceiveDate.Value.ToString("yyyy-MM-dd HH:mm:ss") : "");
				emailspSelectEmailReceiveAndSendById_Result.ReadDatePersian = (emailspSelectEmailReceiveAndSendById_Result.ReadDate.HasValue ? emailspSelectEmailReceiveAndSendById_Result.ReadDate.Value.ToString("yyyy-MM-dd HH:mm:ss") : "");
				_ = emailspSelectEmailReceiveAndSendById_Result.FirstRegisterDate;
				emailspSelectEmailReceiveAndSendById_Result.FirstRegisterDatePersian = emailspSelectEmailReceiveAndSendById_Result.FirstRegisterDate.ToString("yyyy-MM-dd HH:mm:ss");
				_ = emailspSelectEmailReceiveAndSendById_Result.RegisterDate;
				emailspSelectEmailReceiveAndSendById_Result.RegisterDatePersian = emailspSelectEmailReceiveAndSendById_Result.RegisterDate.ToString("yyyy-MM-dd HH:mm:ss");
				emailspSelectEmailReceiveAndSendById_Result.CompanyName += ((!string.IsNullOrWhiteSpace(emailspSelectEmailReceiveAndSendById_Result.PersonName)) ? (" (" + emailspSelectEmailReceiveAndSendById_Result.PersonName + ")") : "");
				switch (mode)
				{
				case 1:
				{
					currentEmailReceiveViewModel.Attachments = Enumerable.ToList<EmailspSelectEmailReceiveAttachments_Result>((IEnumerable<EmailspSelectEmailReceiveAttachments_Result>)_db.EmailspSelectEmailReceiveAttachments(0, emailspSelectEmailReceiveAndSendById_Result.EmailReceiveId, lCID, result));
					DateTime now = DateTime.Now;
					string readDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					_db.EmailspUpdateEmailReceiveIsRead(emailspSelectEmailReceiveAndSendById_Result.EmailReceiveId, true, now, readDatePersian);
					break;
				}
				case 2:
				{
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
						text2 = text2 + "/" + emailspSelectEmailReceiveAndSendById_Result.EmailSendHeaderId;
						text3 = text3 + "/" + emailspSelectEmailReceiveAndSendById_Result.EmailSendHeaderId;
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
					string text4 = (emailspSelectEmailReceiveAndSendById_Result.HtmlBody ?? "").Replace(cmpPattern, emailspSelectEmailReceiveAndSendById_Result.CompanyName ?? "").Replace(cmpPrsPattern, emailspSelectEmailReceiveAndSendById_Result.PersonName ?? "").Replace(cmpPrsJobPattern, "") + "<p style='display:none;'>" + DateTime.Now.ToString("R") + "</p>";
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
					emailspSelectEmailReceiveAndSendById_Result.HtmlBody = text4;
					List<EmailspSelectSendedAttachment_Result> list = Enumerable.ToList<EmailspSelectSendedAttachment_Result>((IEnumerable<EmailspSelectSendedAttachment_Result>)_dbII.EmailspSelectSendedAttachment(emailspSelectEmailReceiveAndSendById_Result.EmailSendHeaderId, 0));
					if (list == null || !Enumerable.Any<EmailspSelectSendedAttachment_Result>((IEnumerable<EmailspSelectSendedAttachment_Result>)list))
					{
						break;
					}
					foreach (EmailspSelectSendedAttachment_Result item3 in list)
					{
						string[] array = item3.FileName.Split(new char[1] { '.' });
						string fileType = "";
						if (array != null)
						{
							fileType = array[^1];
						}
						EmailspSelectEmailReceiveAttachments_Result item = new EmailspSelectEmailReceiveAttachments_Result
						{
							EmailReceiveAttachmentId = item3.EmailSendAttachmentId,
							EmailReceiveId = item3.EmailSendHeaderId,
							ContentId = item3.ReceiveContentId,
							FileName = item3.FileName,
							SaveFilePath = item3.FilePath,
							FileType = fileType,
							CompanyId = emailspSelectEmailReceiveAndSendById_Result.CompanyId,
							CompanyName = emailspSelectEmailReceiveAndSendById_Result.CompanyName,
							CompanyPersonId = emailspSelectEmailReceiveAndSendById_Result.CompanyPersonId,
							PersonName = emailspSelectEmailReceiveAndSendById_Result.PersonName,
							ProjectId = emailspSelectEmailReceiveAndSendById_Result.ProjectId,
							Project = emailspSelectEmailReceiveAndSendById_Result.Project,
							FirstRegisterUserId = item3.FirstRegisterUserId.GetValueOrDefault(),
							FirstRegisterUser = "",
							FirstRegisterDate = (item3.FirstRegisterDate ?? emailspSelectEmailReceiveAndSendById_Result.FirstRegisterDate),
							FirstRegisterDatePersian = item3.FirstRegisterDatePersian,
							UserId = item3.FirstRegisterUserId.GetValueOrDefault(),
							EditUser = "",
							Year1 = 0,
							Month1 = 0,
							RegisterDate = (item3.FirstRegisterDate ?? emailspSelectEmailReceiveAndSendById_Result.FirstRegisterDate),
							RegisterDatePersian = item3.FirstRegisterDatePersian,
							GUId = item3.GUId,
							AppType = item3.AppType,
							LanguageID = item3.LanguageID.GetValueOrDefault(result)
						};
						currentEmailReceiveViewModel.Attachments.Add(item);
					}
					break;
				}
				}
			}
			currentEmailReceiveViewModel.EmailInfo = emailspSelectEmailReceiveAndSendById_Result;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return PartialView(currentEmailReceiveViewModel);
	}

	[DynamicAuthorize(ControllerName = "frmReceiveEmail", ActionName = "actOpenFile")]
	[AjaxOnly]
	public string GetFilePath(int fileId, int mode = 1)
	{
		string text = "";
		if (fileId > 0)
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			try
			{
				string pathFtp = Configuration.PathFtp;
				string userNameFtp = Configuration.UserNameFtp;
				string passwordFtp = Configuration.PasswordFtp;
				bool usePassiveFtp = Configuration.UsePassiveFtp;
				switch (mode)
				{
				case 1:
				{
					EmailspSelectEmailReceiveAttachments_Result emailspSelectEmailReceiveAttachments_Result = Enumerable.FirstOrDefault<EmailspSelectEmailReceiveAttachments_Result>((IEnumerable<EmailspSelectEmailReceiveAttachments_Result>)_db.EmailspSelectEmailReceiveAttachments(fileId, 0, lCID, result));
					if (emailspSelectEmailReceiveAttachments_Result == null)
					{
						break;
					}
					string text6 = emailspSelectEmailReceiveAttachments_Result.SaveFilePath.ToLower().Replace(Configuration.PathFtp.ToLower(), "");
					if (!(text6 != ""))
					{
						break;
					}
					FilesManager filesManager = new FilesManager();
					string text7 = filesManager.SetNameDirectory(UserLogin.CurrentUser.UserId);
					emailspSelectEmailReceiveAttachments_Result.FileName = ((!string.IsNullOrEmpty(emailspSelectEmailReceiveAttachments_Result.FileName)) ? emailspSelectEmailReceiveAttachments_Result.FileName : (DateTime.Now.ToString("yyyyMMdd-HHmmss") + "." + emailspSelectEmailReceiveAttachments_Result.FileType));
					if (filesManager.CreateDirectory(text7))
					{
						text = HttpContext.Current.Server.MapPath(text7 + "/" + emailspSelectEmailReceiveAttachments_Result.FileName);
						if (!new FacadeFTP(Configuration.FacadeFtp).Download(pathFtp, userNameFtp, passwordFtp, text, text6, overwrite: true, usePassiveFtp))
						{
							text = "";
							string path = HttpContext.Current.Server.MapPath(text7);
							if (System.IO.Directory.Exists(path))
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
								if (System.IO.Directory.Exists(path))
								{
									System.IO.Directory.Delete(path);
								}
							}
						}
					}
					if (!string.IsNullOrWhiteSpace(text))
					{
						text = HttpUtility.UrlEncode(text);
					}
					break;
				}
				case 2:
				{
					EmailspSelectSendedAttachment_Result emailspSelectSendedAttachment_Result = Enumerable.FirstOrDefault<EmailspSelectSendedAttachment_Result>((IEnumerable<EmailspSelectSendedAttachment_Result>)_dbII.EmailspSelectSendedAttachment(0, fileId));
					if (emailspSelectSendedAttachment_Result == null)
					{
						break;
					}
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
					break;
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

	[DynamicAuthorize(ControllerName = "frmReceiveEmail", ActionName = "actGotoUnread")]
	[AjaxOnly]
	public string SetIsRead(int emailReceiveId, bool isRead)
	{
		string result = "";
		try
		{
			if (emailReceiveId > 0)
			{
				DateTime now = DateTime.Now;
				string readDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				_db.EmailspUpdateEmailReceiveIsRead(emailReceiveId, isRead, now, readDatePersian);
			}
			else
			{
				result = Messages.msgNotFound;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[DynamicAuthorize(ControllerName = "frmReceiveEmail", ActionName = "actAddEmailToCompany")]
	public ActionResult AddEmailToCompany(int emailReceiveId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		string text2 = "";
		string text3 = "";
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		try
		{
			EmailspSelectEmailReceiveById_Result emailspSelectEmailReceiveById_Result = Enumerable.FirstOrDefault<EmailspSelectEmailReceiveById_Result>((IEnumerable<EmailspSelectEmailReceiveById_Result>)_db.EmailspSelectEmailReceiveById(emailReceiveId, lCID, result));
			if (emailspSelectEmailReceiveById_Result != null)
			{
				num = emailspSelectEmailReceiveById_Result.CompanyId.GetValueOrDefault();
				text = emailspSelectEmailReceiveById_Result.CompanyName ?? "";
				num2 = emailspSelectEmailReceiveById_Result.CompanyPersonId.GetValueOrDefault();
				text2 = emailspSelectEmailReceiveById_Result.PersonName ?? "";
				num3 = emailspSelectEmailReceiveById_Result.ProjectId.GetValueOrDefault();
				text3 = emailspSelectEmailReceiveById_Result.Project;
				emailReceiveId = emailspSelectEmailReceiveById_Result.EmailReceiveId;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.CmpName = text;
		base.ViewBag.PrsName = text2;
		base.ViewBag.PrjTitle = text3;
		base.ViewBag.CmpId = num;
		base.ViewBag.PrsId = num2;
		base.ViewBag.PrjId = num3;
		base.ViewBag.EmailReceiveId = emailReceiveId;
		return View();
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmReceiveEmail", ActionName = "actAddEmailToCompany")]
	public JsonResult ActAddEmailToCompany(int emailReceiveId, int cmpId, int prsId, int prjId)
	{
		CommonReturnResultViewModel commonReturnResultViewModel = new CommonReturnResultViewModel();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			if (emailReceiveId > 0)
			{
				int? num = null;
				int? num2 = null;
				int? num3 = null;
				num3 = ((cmpId > 0) ? new int?(cmpId) : null);
				num2 = ((prsId > 0) ? new int?(prsId) : null);
				num = ((prjId > 0) ? new int?(prjId) : null);
				DateTime now = DateTime.Now;
				DateTime value = now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				short value3 = short.Parse(Financial.Get().Id.ToString());
				int userId = UserLogin.CurrentUser.UserId;
				_db.EmailspUpdateEmailReceiveCmpPrsPrj(emailReceiveId, num3, num2, num, userId, value, registerDatePersian, value3, value2, appType);
				commonReturnResultViewModel.Message = Messages.msgSuccessAction;
				commonReturnResultViewModel.IsDone = true;
			}
			else
			{
				commonReturnResultViewModel.Message = Messages.msgNotFound;
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
	public JsonResult GetCompany(string value = "")
	{
		List<CRMspMainSearchWeb_Result> data = new List<CRMspMainSearchWeb_Result>();
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
			data = Enumerable.ToList<CRMspMainSearchWeb_Result>((IEnumerable<CRMspMainSearchWeb_Result>)_dbI.CRMspMainSearchWeb(value, UserLogin.CurrentUser.UserId, 1, lCID, result, ",1000,1,2,3,8,9,11,12,14,17,20,21,22,", result2));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetCompanyPerson(int cmpId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectCompanyPersons_Result> list = new List<CRMspSelectCompanyPersons_Result>();
		try
		{
			List<CRMspSelectCompanyPersons_Result> list2 = CRMIdeal.Classes.Helper.Company.SelectCompanyPersons(cmpId);
			list.Add(new CRMspSelectCompanyPersons_Result
			{
				CompanyPersonID = -1,
				PersonName = Labels.SelectedListDefValue
			});
			list.AddRange(Enumerable.Select<CRMspSelectCompanyPersons_Result, CRMspSelectCompanyPersons_Result>((IEnumerable<CRMspSelectCompanyPersons_Result>)list2, (Func<CRMspSelectCompanyPersons_Result, CRMspSelectCompanyPersons_Result>)((CRMspSelectCompanyPersons_Result item) => new CRMspSelectCompanyPersons_Result
			{
				CompanyPersonID = item.CompanyPersonID,
				PersonName = item.PersonTitleName + ((!string.IsNullOrEmpty(item.prsEmail) || !string.IsNullOrEmpty(item.prsEmailII)) ? ("(" + ((!string.IsNullOrEmpty(item.prsEmail)) ? item.prsEmail : "") + ((!string.IsNullOrEmpty(item.prsEmailII)) ? (((!string.IsNullOrEmpty(item.prsEmail)) ? " - " : "") + item.prsEmailII) : "") + ")") : "")
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetProject(int cmpId)
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
			List<CRMspSelectCrmProjectBycmpAndUser_Result> list2 = Enumerable.ToList<CRMspSelectCrmProjectBycmpAndUser_Result>((IEnumerable<CRMspSelectCrmProjectBycmpAndUser_Result>)_db.CRMspSelectCrmProjectBycmpAndUser(cmpId, UserLogin.CurrentUser.UserId, lCID, result, result2));
			list.Add(new SelectListItem
			{
				Text = Labels.SelectedListDefValue,
				Value = "-1",
				Selected = true
			});
			list.AddRange(Enumerable.Select<CRMspSelectCrmProjectBycmpAndUser_Result, SelectListItem>((IEnumerable<CRMspSelectCrmProjectBycmpAndUser_Result>)list2, (Func<CRMspSelectCrmProjectBycmpAndUser_Result, SelectListItem>)((CRMspSelectCrmProjectBycmpAndUser_Result item) => new SelectListItem
			{
				Text = item.prjTitle,
				Value = item.ProjectID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.ProjectList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmReceiveEmail", ActionName = "actDelete")]
	public string DeleteEmail(int emailReceiveId)
	{
		string message = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			EmailspSelectEmailReceiveById_Result emailspSelectEmailReceiveById_Result = Enumerable.FirstOrDefault<EmailspSelectEmailReceiveById_Result>((IEnumerable<EmailspSelectEmailReceiveById_Result>)_db.EmailspSelectEmailReceiveById(emailReceiveId, lCID, result));
			if (emailspSelectEmailReceiveById_Result != null)
			{
				try
				{
					List<EmailspSelectEmailReceiveAttachments_Result> list = Enumerable.ToList<EmailspSelectEmailReceiveAttachments_Result>((IEnumerable<EmailspSelectEmailReceiveAttachments_Result>)_db.EmailspSelectEmailReceiveAttachments(0, emailspSelectEmailReceiveById_Result.EmailReceiveId, lCID, result));
					bool flag = false;
					if (list != null && Enumerable.Any<EmailspSelectEmailReceiveAttachments_Result>((IEnumerable<EmailspSelectEmailReceiveAttachments_Result>)list))
					{
						foreach (EmailspSelectEmailReceiveAttachments_Result item in list)
						{
							try
							{
								if (item != null)
								{
									string text = item.SaveFilePath.ToLower().Replace(Configuration.PathFtp.ToLower(), "");
									FacadeFTP facadeFTP = new FacadeFTP(Configuration.FacadeFtp);
									string text2 = text;
									string text3 = "";
									if (!string.IsNullOrEmpty(text2))
									{
										string text4 = text2;
										text4 = text4.Replace("//", "/").Replace("/", "/").Replace("\\", "/");
										for (int num = text4.IndexOf("." + item.FileType, StringComparison.Ordinal); num >= 0; num--)
										{
											if (text2 != "/")
											{
												text3 += text4[num];
											}
										}
										text3 = text3 + "." + item.FileType;
									}
									if (facadeFTP.Delete(Configuration.PathFtp, Configuration.UserNameFtp, Configuration.PasswordFtp, text3, text2, Configuration.UsePassiveFtp))
									{
										_db.EmailspDeleteEmailReceiveAttachments(item.EmailReceiveAttachmentId);
									}
								}
								flag = true;
							}
							catch (Exception ex)
							{
								ErrorSignal.FromCurrentContext().Raise(ex);
								message = ex.Message;
								flag = false;
							}
						}
					}
					else
					{
						flag = true;
					}
					EmailspSelectEmailUsersInfoById_Result emailspSelectEmailUsersInfoById_Result = Enumerable.FirstOrDefault<EmailspSelectEmailUsersInfoById_Result>((IEnumerable<EmailspSelectEmailUsersInfoById_Result>)_db.EmailspSelectEmailUsersInfoById(emailspSelectEmailReceiveById_Result.ToUserEmailUserInfoId));
					if (!emailspSelectEmailUsersInfoById_Result.euDeleteSrvrAfterDelDb.GetValueOrDefault() || Email.DeleteEmailForAccount(emailspSelectEmailUsersInfoById_Result, emailspSelectEmailReceiveById_Result.MessageId, emailspSelectEmailReceiveById_Result.FolderName, ref message))
					{
						try
						{
							_db.EmailspDeleteEmailReceive(emailspSelectEmailReceiveById_Result.EmailReceiveId);
						}
						catch (DbEntityValidationException e)
						{
							ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
							message = Messages.RedundancyMessage;
						}
					}
				}
				catch (DbEntityValidationException e2)
				{
					ErrorSignal.FromCurrentContext().Raise((Exception)(object)e2);
					message = Messages.RedundancyMessage;
				}
				catch (Exception ex2)
				{
					ErrorSignal.FromCurrentContext().Raise(ex2);
					message = Messages.msgErrorCommunicateWithServer + "<br><p style=text-align:left;>" + ex2.Message + "</p>";
				}
			}
			else
			{
				message = Messages.ErrorNotFound;
			}
		}
		catch (Exception e3)
		{
			ErrorSignal.FromCurrentContext().Raise(e3);
			message = Messages.frmErrorMessage;
		}
		return message;
	}

	public void ReceiveSingleEmailSync(int emailUsersInfoId, int euUserId, int currLangId)
	{
		try
		{
			if (!VersionBuyer.Emails)
			{
				return;
			}
			if (currLangId == 0)
			{
				currLangId = 1065;
			}
			DateTime now = DateTime.Now;
			string text = now.ToString("yyyyMMdd");
			DateTime dateTime = now;
			string text2 = "";
			CRMspSelectUsersById_Result cRMspSelectUsersById_Result = Enumerable.FirstOrDefault<CRMspSelectUsersById_Result>((IEnumerable<CRMspSelectUsersById_Result>)_db.CRMspSelectUsersById(euUserId, currLangId, currLangId, 0));
			if (cRMspSelectUsersById_Result != null)
			{
				dateTime = cRMspSelectUsersById_Result.LastCheckEmailDate.GetValueOrDefault(now);
				if (cRMspSelectUsersById_Result.LastCheckEmailDate.HasValue)
				{
					text2 = dateTime.ToString("yyyyMMdd");
				}
			}
			bool noSetDateToQry = false;
			if (string.IsNullOrWhiteSpace(text2) || string.IsNullOrWhiteSpace(text))
			{
				noSetDateToQry = true;
			}
			ReceiveAllEmailsFromServer(emailUsersInfoId, text2, text, useInJob: false, noSetDateToQry);
		}
		catch (Exception ex)
		{
			Logs.LogError(ex, "");
		}
	}

	public long GetReceiveEmailCount(int emailUsersInfoId, string fromDate, string toDate, bool useInJob = false)
	{
		long num = 0L;
		if (UserLogin.CurrentUser != null)
		{
			_ = UserLogin.CurrentUser.UserId;
		}
		string message = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime fromDate2 = DateTime.Now;
			DateTime toDate2 = DateTime.Now;
			if (!string.IsNullOrEmpty(fromDate))
			{
				fromDate = fromDate.Replace("/", "").Replace("-", "").Replace("\\", "")
					.Replace(" ", "")
					.Replace("_", "");
				fromDate2 = lCID switch
				{
					1065 => DateTime.Parse(PersianDate.GetFormatetdDate(fromDate) + " 00:00:00"), 
					1025 => DateTime.Parse(PersianDate.GetFormatetdDate(fromDate) + " 00:00:00", new CultureInfo("ar-SA"), DateTimeStyles.None), 
					_ => DateTime.Parse(PersianDate.GetFormatetdDate(fromDate) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None), 
				};
			}
			if (!string.IsNullOrEmpty(toDate))
			{
				toDate = toDate.Replace("/", "").Replace("-", "").Replace("\\", "")
					.Replace(" ", "")
					.Replace("_", "");
				toDate2 = lCID switch
				{
					1065 => DateTime.Parse(PersianDate.GetFormatetdDate(toDate) + " 23:59:59"), 
					1025 => DateTime.Parse(PersianDate.GetFormatetdDate(toDate) + " 23:59:59", new CultureInfo("ar-SA"), DateTimeStyles.None), 
					_ => DateTime.Parse(PersianDate.GetFormatetdDate(toDate) + " 23:59:59", new CultureInfo("en-US"), DateTimeStyles.None), 
				};
			}
			bool noSetDateToQry = false;
			if (string.IsNullOrWhiteSpace(fromDate) || string.IsNullOrWhiteSpace(toDate))
			{
				noSetDateToQry = true;
			}
			if (emailUsersInfoId > 0)
			{
				EmailspSelectEmailUsersInfoById_Result emailspSelectEmailUsersInfoById_Result = Enumerable.FirstOrDefault<EmailspSelectEmailUsersInfoById_Result>((IEnumerable<EmailspSelectEmailUsersInfoById_Result>)_db.EmailspSelectEmailUsersInfoById(emailUsersInfoId));
				if (emailspSelectEmailUsersInfoById_Result != null)
				{
					long num2 = Email.ReceiveCountAllEmailForAccount(emailspSelectEmailUsersInfoById_Result.EmailUsersInfoId, emailspSelectEmailUsersInfoById_Result, fromDate2, toDate2, ref message, useInJob, noSetDateToQry);
					num += num2;
				}
			}
		}
		catch (Exception ex)
		{
			Logs.LogError(ex, "");
		}
		return num;
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbI.Dispose();
		_dbII.Dispose();
		base.Dispose(disposing);
	}
}
