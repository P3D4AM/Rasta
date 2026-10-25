using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Net.Security;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.Hosting;
using System.Web.Mail;
using System.Web.Mvc;
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
using Elmah;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace CRMIdeal.Areas.Emails.Controllers;

public class SendTankController : Controller
{
	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static RemoteCertificateValidationCallback _003C_003E9__10_0;

		internal bool _003CSendEmail_003Eb__10_0(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_0009: Invalid comparison between Unknown and I4
			if ((int)sslPolicyErrors == 0)
			{
				return true;
			}
			if ((int)sslPolicyErrors == 4)
			{
				X509ChainStatus[] chainStatus = chain.ChainStatus;
				for (int i = 0; i < chainStatus.Length; i++)
				{
					X509ChainStatus x509ChainStatus = chainStatus[i];
					if (x509ChainStatus.Status != X509ChainStatusFlags.RevocationStatusUnknown && x509ChainStatus.Status != X509ChainStatusFlags.OfflineRevocation)
					{
						return false;
					}
				}
				return true;
			}
			return false;
		}
	}

	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMSpIIIEntities _dbIII = new CRMSpIIIEntities();

	private EmailspSelectEmailReadySend_Result _email;

	private EmailspSelectEmailSetting_Result _setting;

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actemEmailShowSendTank")]
	public ActionResult Index()
	{
		int result = 0;
		try
		{
			_setting = Enumerable.FirstOrDefault<EmailspSelectEmailSetting_Result>((IEnumerable<EmailspSelectEmailSetting_Result>)_db.EmailspSelectEmailSetting("", ""));
			if (_setting == null)
			{
				base.ViewBag.Error = Messages.msgErrorInReadingEmailSetting;
			}
			else
			{
				int.TryParse(_setting.EmailBulkingDelayTime.ToString(), out result);
				if (result < 3)
				{
					result = 3;
				}
				result *= 1000;
				if (!_setting.EmailBulkingIsActive.HasValue || !_setting.EmailBulkingIsActive.GetValueOrDefault())
				{
					base.ViewBag.Error = Messages.msgErrEmailBulkingIsNotActive;
				}
				else
				{
					DateTime now = DateTime.Now;
					string text = ((!string.IsNullOrWhiteSpace(_setting.EmailBulkingDailyStarTime)) ? _setting.EmailBulkingDailyStarTime : "00:00:00");
					string text2 = ((!string.IsNullOrWhiteSpace(_setting.EmailBulkingDailyEndTime)) ? _setting.EmailBulkingDailyEndTime : "23:59:59");
					DateTime startTime = DateTime.Parse(now.ToString("yyyy/MM/dd") + " " + text);
					DateTime endTime = DateTime.Parse(now.ToString("yyyy/MM/dd") + " " + text2);
					if (!IsBetween(DateTime.Now, startTime, endTime))
					{
						base.ViewBag.Error = string.Format(Messages.msgStartTimeToSendEmail, text, text2);
					}
				}
			}
			string text3 = "";
			string path = base.Server.MapPath(Configuration.HostTempFilesPath + "/Emails/SendFile");
			if (System.IO.Directory.Exists(path))
			{
				DirectoryInfo[] directories = new DirectoryInfo(path).GetDirectories();
				foreach (DirectoryInfo directoryInfo in directories)
				{
					text3 = text3 + directoryInfo.Name + ",";
				}
			}
			base.ViewBag.OldFolder = text3;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.IsBuying = VersionBuyer.Emails;
		base.ViewBag.Delay = result;
		return View();
	}

	[AjaxOnly]
	public ActionResult SendTank_Read([DataSourceRequest] DataSourceRequest request)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<EmailspSelectEmailTankReadySend_Result> list = new List<EmailspSelectEmailTankReadySend_Result>();
		try
		{
			DateTime value = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59");
			int result2 = 0;
			int value2 = 0;
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			if (currentUser != null)
			{
				int.TryParse(currentUser.UserLastCId.ToString(), out result2);
				value2 = currentUser.UserId;
			}
			list = Enumerable.ToList<EmailspSelectEmailTankReadySend_Result>((IEnumerable<EmailspSelectEmailTankReadySend_Result>)_dbIII.EmailspSelectEmailTankReadySend(value2, value, result2));
			if (list != null && Enumerable.Any<EmailspSelectEmailTankReadySend_Result>((IEnumerable<EmailspSelectEmailTankReadySend_Result>)list))
			{
				foreach (EmailspSelectEmailTankReadySend_Result item in list)
				{
					_ = item.Header_PriorityId;
					item.Detail_AppType = ((item.Header_PriorityId == 0) ? Labels.EmailNormalPriority : ((item.Header_PriorityId == 1) ? Labels.EmailHighPriority : ""));
					item.UsersInfo_euNikeEmail = item.UsersInfo_euNikeName + ((!string.IsNullOrWhiteSpace(item.UsersInfo_euNikeEmail)) ? ("  [ " + item.UsersInfo_euNikeEmail + " ]") : "");
					item.Detail_EmailCmpName += ((!string.IsNullOrWhiteSpace(item.Detail_EmailCmpPrsName)) ? (" (" + item.Detail_EmailCmpPrsName + ")") : "");
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	[ValidateInput(false)]
	public JsonResult ActSendEmail(string headerIds = "", EmailspSelectEmailReadySend_Result emailInfo = null)
	{
		string data = "";
		string message = "";
		CommonResultStatusViewModel status = CommonResultStatusViewModel.Success;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			string text = now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			short.Parse(Financial.Get().Id.ToString());
			if (UserLogin.CurrentUser != null)
			{
				_ = UserLogin.CurrentUser.UserId;
			}
			_setting = Enumerable.FirstOrDefault<EmailspSelectEmailSetting_Result>((IEnumerable<EmailspSelectEmailSetting_Result>)_db.EmailspSelectEmailSetting("", ""));
			if (_setting != null)
			{
				try
				{
					if (!string.IsNullOrWhiteSpace(headerIds))
					{
						headerIds = DeleteOldFiles(headerIds);
					}
					DateTime value = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59");
					_email = new EmailspSelectEmailReadySend_Result();
					if (emailInfo != null && emailInfo != null && emailInfo.Header_Id != 0)
					{
						_email = emailInfo;
					}
					else
					{
						_email = Enumerable.FirstOrDefault<EmailspSelectEmailReadySend_Result>((IEnumerable<EmailspSelectEmailReadySend_Result>)_db.EmailspSelectEmailReadySend(value));
					}
					if (_email != null)
					{
						string usersInfo_euPassword = _email.UsersInfo_euPassword;
						usersInfo_euPassword = ((!string.IsNullOrEmpty(usersInfo_euPassword)) ? XorCipher.DecryptByPrivateKey(usersInfo_euPassword) : string.Empty);
						_email.UsersInfo_euPassword = usersInfo_euPassword;
						lock (_email)
						{
							if (_setting.EmailBulkingIsActive.HasValue && _setting.EmailBulkingIsActive.GetValueOrDefault())
							{
								string text2 = ((!string.IsNullOrWhiteSpace(_setting.EmailBulkingDailyStarTime)) ? _setting.EmailBulkingDailyStarTime : "00:00:00");
								string text3 = ((!string.IsNullOrWhiteSpace(_setting.EmailBulkingDailyEndTime)) ? _setting.EmailBulkingDailyEndTime : "23:59:59");
								DateTime startTime = DateTime.Parse(now.ToString("yyyy/MM/dd") + " " + text2);
								DateTime endTime = DateTime.Parse(now.ToString("yyyy/MM/dd") + " " + text3);
								if (IsBetween(DateTime.Now, startTime, endTime))
								{
									if (SendEmail(_email))
									{
										EmailspSelectEmailSendDetail_Result emailspSelectEmailSendDetail_Result = Enumerable.FirstOrDefault<EmailspSelectEmailSendDetail_Result>((IEnumerable<EmailspSelectEmailSendDetail_Result>)_db.EmailspSelectEmailSendDetail("EmailSendDetailId=" + _email.Detail_Id, ""));
										if (emailspSelectEmailSendDetail_Result != null)
										{
											now = DateTime.Now;
											emailspSelectEmailSendDetail_Result.SendedDateTime = now;
											emailspSelectEmailSendDetail_Result.SendedDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
											emailspSelectEmailSendDetail_Result.StatusId = 1;
											if (!emailspSelectEmailSendDetail_Result.TryCount.HasValue)
											{
												emailspSelectEmailSendDetail_Result.TryCount = 0;
											}
											if (_db.EmailspUpdateEmailSendDetail(emailspSelectEmailSendDetail_Result.EmailSendDetailId, emailspSelectEmailSendDetail_Result.EmailSendHeaderId, emailspSelectEmailSendDetail_Result.EmailAddress, emailspSelectEmailSendDetail_Result.EmailCmpId, emailspSelectEmailSendDetail_Result.EmailCmpPrsId, emailspSelectEmailSendDetail_Result.EmailCmpPrjId, emailspSelectEmailSendDetail_Result.SendDateTime, emailspSelectEmailSendDetail_Result.SendDatePersian, emailspSelectEmailSendDetail_Result.SendedDateTime, emailspSelectEmailSendDetail_Result.SendedDatePersian, emailspSelectEmailSendDetail_Result.StatusId, now, now.ToString("yyyyMMdd", new PersianCulture()), emailspSelectEmailSendDetail_Result.EmailCmpPrsName, emailspSelectEmailSendDetail_Result.EmailCmpName, emailspSelectEmailSendDetail_Result.EmailPrsJob, appType, emailspSelectEmailSendDetail_Result.TryCount) <= 0)
											{
												data = "-2";
												message = string.Format(Messages.msgErrInUpdateEmailDetails, _email.Detail_EmailAddress);
												status = CommonResultStatusViewModel.Fail;
											}
											else
											{
												if (Enumerable.ToList<EmailspSelectEmailSendDetail_Result>((IEnumerable<EmailspSelectEmailSendDetail_Result>)_db.EmailspSelectEmailSendDetail("EmailSendHeaderId=" + _email.Header_Id + " AND StatusId=0", "")).Count > 0)
												{
													goto IL_0556;
												}
												EmailspSelectEmailSendHeader_Result emailspSelectEmailSendHeader_Result = Enumerable.FirstOrDefault<EmailspSelectEmailSendHeader_Result>((IEnumerable<EmailspSelectEmailSendHeader_Result>)_db.EmailspSelectEmailSendHeader("EmailSendHeaderId=" + _email.Header_Id, ""));
												if (emailspSelectEmailSendHeader_Result == null)
												{
													goto IL_0556;
												}
												now = DateTime.Now;
												emailspSelectEmailSendHeader_Result.EndDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
												emailspSelectEmailSendHeader_Result.EndDateTime = now;
												if (_db.EmailspUpdateEmailSendHeader(emailspSelectEmailSendHeader_Result.EmailSendHeaderId, emailspSelectEmailSendHeader_Result.UserId, emailspSelectEmailSendHeader_Result.Subject, emailspSelectEmailSendHeader_Result.Body, emailspSelectEmailSendHeader_Result.StartDateTime, emailspSelectEmailSendHeader_Result.StartDatePersian, emailspSelectEmailSendHeader_Result.EndDateTime, emailspSelectEmailSendHeader_Result.EndDatePersian, emailspSelectEmailSendHeader_Result.PriorityId, emailspSelectEmailSendHeader_Result.RegisterDate, emailspSelectEmailSendHeader_Result.RegisterDatePersian, emailspSelectEmailSendHeader_Result.EmailUsersInfoId, emailspSelectEmailSendHeader_Result.EmailSettingId, appType) > 0)
												{
													headerIds = headerIds + _email.Header_Id + ",";
													goto IL_0556;
												}
												data = "-2";
												message = string.Format(Messages.msgErrInUpdateEmailDetails, _email.Detail_EmailAddress);
												status = CommonResultStatusViewModel.Fail;
											}
										}
									}
									else
									{
										int result2 = 0;
										if (_email.Detail_TryCount.HasValue)
										{
											int.TryParse(_email.Detail_TryCount.ToString(), out result2);
										}
										if (result2 < 0)
										{
											result2 = 0;
										}
										if (result2 < 2)
										{
											result2++;
											_email.Detail_TryCount = result2;
											EmailspSelectEmailSendDetail_Result emailspSelectEmailSendDetail_Result2 = Enumerable.FirstOrDefault<EmailspSelectEmailSendDetail_Result>((IEnumerable<EmailspSelectEmailSendDetail_Result>)_db.EmailspSelectEmailSendDetail("EmailSendDetailId=" + _email.Detail_Id, ""));
											if (emailspSelectEmailSendDetail_Result2 != null)
											{
												emailspSelectEmailSendDetail_Result2.TryCount = result2;
												if (_db.EmailspUpdateEmailSendDetail(emailspSelectEmailSendDetail_Result2.EmailSendDetailId, emailspSelectEmailSendDetail_Result2.EmailSendHeaderId, emailspSelectEmailSendDetail_Result2.EmailAddress, emailspSelectEmailSendDetail_Result2.EmailCmpId, emailspSelectEmailSendDetail_Result2.EmailCmpPrsId, emailspSelectEmailSendDetail_Result2.EmailCmpPrjId, emailspSelectEmailSendDetail_Result2.SendDateTime, emailspSelectEmailSendDetail_Result2.SendDatePersian, emailspSelectEmailSendDetail_Result2.SendedDateTime, emailspSelectEmailSendDetail_Result2.SendedDatePersian, emailspSelectEmailSendDetail_Result2.StatusId, now, text, emailspSelectEmailSendDetail_Result2.EmailCmpPrsName, emailspSelectEmailSendDetail_Result2.EmailCmpName, emailspSelectEmailSendDetail_Result2.EmailPrsJob, appType, emailspSelectEmailSendDetail_Result2.TryCount) <= 0)
												{
													data = "-2";
													message = string.Format(Messages.msgErrInUpdateEmailDetails, _email.Detail_EmailAddress);
													status = CommonResultStatusViewModel.Fail;
												}
												else
												{
													data = "-1";
													message = string.Format(Messages.msgErrInUpdateEmailDetails, _email.Detail_EmailAddress);
													status = CommonResultStatusViewModel.Fail;
												}
											}
										}
										else
										{
											EmailspSelectEmailSendDetail_Result emailspSelectEmailSendDetail_Result3 = Enumerable.FirstOrDefault<EmailspSelectEmailSendDetail_Result>((IEnumerable<EmailspSelectEmailSendDetail_Result>)_db.EmailspSelectEmailSendDetail("EmailSendDetailId=" + _email.Detail_Id, ""));
											if (emailspSelectEmailSendDetail_Result3 == null)
											{
												goto IL_099e;
											}
											emailspSelectEmailSendDetail_Result3.SendedDateTime = now;
											emailspSelectEmailSendDetail_Result3.SendedDatePersian = text;
											emailspSelectEmailSendDetail_Result3.StatusId = -2;
											emailspSelectEmailSendDetail_Result3.TryCount = 3;
											if (_db.EmailspUpdateEmailSendDetail(emailspSelectEmailSendDetail_Result3.EmailSendDetailId, emailspSelectEmailSendDetail_Result3.EmailSendHeaderId, emailspSelectEmailSendDetail_Result3.EmailAddress, emailspSelectEmailSendDetail_Result3.EmailCmpId, emailspSelectEmailSendDetail_Result3.EmailCmpPrsId, emailspSelectEmailSendDetail_Result3.EmailCmpPrjId, emailspSelectEmailSendDetail_Result3.SendDateTime, emailspSelectEmailSendDetail_Result3.SendDatePersian, emailspSelectEmailSendDetail_Result3.SendedDateTime, emailspSelectEmailSendDetail_Result3.SendedDatePersian, emailspSelectEmailSendDetail_Result3.StatusId, now, text, emailspSelectEmailSendDetail_Result3.EmailCmpPrsName, emailspSelectEmailSendDetail_Result3.EmailCmpName, emailspSelectEmailSendDetail_Result3.EmailPrsJob, appType, emailspSelectEmailSendDetail_Result3.TryCount) <= 0)
											{
												data = "-2";
												message = string.Format(Messages.msgErrInUpdateEmailDetails, _email.Detail_EmailAddress);
												status = CommonResultStatusViewModel.Fail;
											}
											else
											{
												if (Enumerable.ToList<EmailspSelectEmailSendDetail_Result>((IEnumerable<EmailspSelectEmailSendDetail_Result>)_db.EmailspSelectEmailSendDetail("EmailSendHeaderId=" + _email.Header_Id + " AND StatusId=0", "")).Count > 0)
												{
													goto IL_099e;
												}
												EmailspSelectEmailSendHeader_Result emailspSelectEmailSendHeader_Result2 = Enumerable.FirstOrDefault<EmailspSelectEmailSendHeader_Result>((IEnumerable<EmailspSelectEmailSendHeader_Result>)_db.EmailspSelectEmailSendHeader("EmailSendHeaderId=" + _email.Header_Id, ""));
												if (emailspSelectEmailSendHeader_Result2 == null)
												{
													goto IL_099e;
												}
												now = DateTime.Now;
												emailspSelectEmailSendHeader_Result2.EndDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
												emailspSelectEmailSendHeader_Result2.EndDateTime = now;
												if (_db.EmailspUpdateEmailSendHeader(emailspSelectEmailSendHeader_Result2.EmailSendHeaderId, emailspSelectEmailSendHeader_Result2.UserId, emailspSelectEmailSendHeader_Result2.Subject, emailspSelectEmailSendHeader_Result2.Body, emailspSelectEmailSendHeader_Result2.StartDateTime, emailspSelectEmailSendHeader_Result2.StartDatePersian, emailspSelectEmailSendHeader_Result2.EndDateTime, emailspSelectEmailSendHeader_Result2.EndDatePersian, emailspSelectEmailSendHeader_Result2.PriorityId, emailspSelectEmailSendHeader_Result2.RegisterDate, emailspSelectEmailSendHeader_Result2.RegisterDatePersian, emailspSelectEmailSendHeader_Result2.EmailUsersInfoId, emailspSelectEmailSendHeader_Result2.EmailSettingId, appType) > 0)
												{
													headerIds = headerIds + _email.Header_Id + ",";
													goto IL_099e;
												}
												data = "-2";
												message = string.Format(Messages.msgErrInUpdateEmailDetails, _email.Detail_EmailAddress);
												status = CommonResultStatusViewModel.Fail;
											}
										}
									}
								}
								else
								{
									data = "0";
									message = string.Format(Messages.msgStartTimeToSendEmail, text2, text3);
									status = CommonResultStatusViewModel.Success;
								}
							}
							else
							{
								data = "0";
								message = Messages.msgErrEmailBulkingIsNotActive;
								status = CommonResultStatusViewModel.Success;
							}
							goto end_IL_0196;
							IL_099e:
							data = headerIds;
							message = string.Format(Messages.msgErrEmailRemoveFromQueue, _email.Detail_EmailAddress);
							status = CommonResultStatusViewModel.Fail;
							goto end_IL_0196;
							IL_0556:
							data = headerIds;
							message = string.Format(Messages.msgSendEmailBySuccess, _email.Detail_EmailAddress);
							status = CommonResultStatusViewModel.Success;
							end_IL_0196:;
						}
					}
					else
					{
						data = "0";
						message = Messages.msgErrorTankIsEmpty;
						status = CommonResultStatusViewModel.Error;
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
					data = "0";
					message = Messages.msgErrorRunFunction;
					status = CommonResultStatusViewModel.Error;
				}
			}
			else
			{
				data = "0";
				message = Messages.msgErrorInReadingEmailSetting;
				status = CommonResultStatusViewModel.Error;
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			data = "0";
			message = Messages.msgErrorRunFunction;
			status = CommonResultStatusViewModel.Error;
		}
		CommonResultViewModel<string> data2 = new CommonResultViewModel<string>
		{
			Data = data,
			Message = message,
			Status = status
		};
		return Json(data2, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	[ValidateInput(false)]
	public JsonResult ActSendEmailByOtp(string otpCode, string headerIds = "")
	{
		string data = "";
		string message = "";
		CommonResultStatusViewModel status = CommonResultStatusViewModel.Success;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			string text = now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			short.Parse(Financial.Get().Id.ToString());
			if (UserLogin.CurrentUser != null)
			{
				_ = UserLogin.CurrentUser.UserId;
			}
			_setting = Enumerable.FirstOrDefault<EmailspSelectEmailSetting_Result>((IEnumerable<EmailspSelectEmailSetting_Result>)_db.EmailspSelectEmailSetting("", ""));
			if (_setting != null)
			{
				try
				{
					if (!string.IsNullOrWhiteSpace(headerIds))
					{
						headerIds = DeleteOldFiles(headerIds);
					}
					DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59");
					EmailspSelectEmailReadySendByOTP_Result emailspSelectEmailReadySendByOTP_Result = Enumerable.FirstOrDefault<EmailspSelectEmailReadySendByOTP_Result>((IEnumerable<EmailspSelectEmailReadySendByOTP_Result>)_dbI.EmailspSelectEmailReadySendByOTP(otpCode));
					if (emailspSelectEmailReadySendByOTP_Result != null)
					{
						_email = new EmailspSelectEmailReadySend_Result();
						_email.UserId = emailspSelectEmailReadySendByOTP_Result.UserId;
						_email.Header_Id = emailspSelectEmailReadySendByOTP_Result.Header_Id;
						_email.Header_Subject = emailspSelectEmailReadySendByOTP_Result.Header_Subject;
						_email.Header_Body = emailspSelectEmailReadySendByOTP_Result.Header_Body;
						_email.Header_PriorityId = emailspSelectEmailReadySendByOTP_Result.Header_PriorityId;
						_email.Setting_Id = emailspSelectEmailReadySendByOTP_Result.Setting_Id;
						_email.UsersInfo_Id = emailspSelectEmailReadySendByOTP_Result.UsersInfo_Id;
						_email.UsersInfo_euUserId = emailspSelectEmailReadySendByOTP_Result.UsersInfo_euUserId;
						_email.UsersInfo_euNikeName = emailspSelectEmailReadySendByOTP_Result.UsersInfo_euNikeName;
						_email.UsersInfo_euNikeEmail = emailspSelectEmailReadySendByOTP_Result.UsersInfo_euNikeEmail;
						_email.UsersInfo_euPOP3Server = emailspSelectEmailReadySendByOTP_Result.UsersInfo_euPOP3Server;
						_email.UsersInfo_euSMTPServer = emailspSelectEmailReadySendByOTP_Result.UsersInfo_euSMTPServer;
						_email.UsersInfo_euUserName = emailspSelectEmailReadySendByOTP_Result.UsersInfo_euUserName;
						_email.UsersInfo_euPassword = ((!string.IsNullOrEmpty(emailspSelectEmailReadySendByOTP_Result.UsersInfo_euPassword)) ? XorCipher.DecryptByPrivateKey(emailspSelectEmailReadySendByOTP_Result.UsersInfo_euPassword) : string.Empty);
						_email.UsersInfo_euIsActive = emailspSelectEmailReadySendByOTP_Result.UsersInfo_euIsActive;
						_email.Detail_Id = emailspSelectEmailReadySendByOTP_Result.Detail_Id;
						_email.Detail_EmailAddress = emailspSelectEmailReadySendByOTP_Result.Detail_EmailAddress;
						_email.Detail_EmailCmpId = emailspSelectEmailReadySendByOTP_Result.Detail_EmailCmpId;
						_email.Detail_EmailCmpPrsId = emailspSelectEmailReadySendByOTP_Result.Detail_EmailCmpPrsId;
						_email.Detail_EmailCmpPrjId = emailspSelectEmailReadySendByOTP_Result.Detail_EmailCmpPrjId;
						_email.Detail_EmailCmpName = emailspSelectEmailReadySendByOTP_Result.Detail_EmailCmpName;
						_email.Detail_EmailCmpPrsName = emailspSelectEmailReadySendByOTP_Result.Detail_EmailCmpPrsName;
						_email.Detail_EmailPrsJob = emailspSelectEmailReadySendByOTP_Result.Detail_EmailPrsJob;
						_email.Detail_StatusId = emailspSelectEmailReadySendByOTP_Result.Detail_StatusId;
						_email.Detail_AppType = emailspSelectEmailReadySendByOTP_Result.Detail_AppType;
						_email.Detail_TryCount = emailspSelectEmailReadySendByOTP_Result.Detail_TryCount;
						_email.UsersInfo_euSMTPUseDefCredentials = emailspSelectEmailReadySendByOTP_Result.UsersInfo_euSMTPUseDefCredentials;
						_email.UsersInfo_euSMTPUseSsl = emailspSelectEmailReadySendByOTP_Result.UsersInfo_euSMTPUseSsl;
						_email.UsersInfo_euSMTPPort = emailspSelectEmailReadySendByOTP_Result.UsersInfo_euSMTPPort;
						string oTP = emailspSelectEmailReadySendByOTP_Result.OTP;
						oTP = oTP ?? "";
						string text2 = _email.Header_Body ?? "";
						string text3 = _email.Header_Subject ?? "";
						if (!string.IsNullOrWhiteSpace(text2))
						{
							text2 = text2.Replace("[#کد تاييد OTP#]", oTP);
							_email.Header_Body = text2;
						}
						if (!string.IsNullOrWhiteSpace(text3))
						{
							text3 = text3.Replace("[#کد تاييد OTP#]", oTP);
							_email.Header_Subject = text3;
						}
					}
					if (_email != null)
					{
						lock (_email)
						{
							if (_setting.EmailBulkingIsActive.HasValue && _setting.EmailBulkingIsActive.GetValueOrDefault())
							{
								string text4 = ((!string.IsNullOrWhiteSpace(_setting.EmailBulkingDailyStarTime)) ? _setting.EmailBulkingDailyStarTime : "00:00:00");
								string text5 = ((!string.IsNullOrWhiteSpace(_setting.EmailBulkingDailyEndTime)) ? _setting.EmailBulkingDailyEndTime : "23:59:59");
								DateTime startTime = DateTime.Parse(now.ToString("yyyy/MM/dd") + " " + text4);
								DateTime endTime = DateTime.Parse(now.ToString("yyyy/MM/dd") + " " + text5);
								_email.UsersInfo_euPassword = ((!string.IsNullOrEmpty(emailspSelectEmailReadySendByOTP_Result.UsersInfo_euPassword)) ? XorCipher.DecryptByPrivateKey(emailspSelectEmailReadySendByOTP_Result.UsersInfo_euPassword) : string.Empty);
								if (IsBetween(DateTime.Now, startTime, endTime))
								{
									if (SendEmail(_email))
									{
										EmailspSelectEmailSendDetail_Result emailspSelectEmailSendDetail_Result = Enumerable.FirstOrDefault<EmailspSelectEmailSendDetail_Result>((IEnumerable<EmailspSelectEmailSendDetail_Result>)_db.EmailspSelectEmailSendDetail("EmailSendDetailId=" + _email.Detail_Id, ""));
										if (emailspSelectEmailSendDetail_Result != null)
										{
											now = DateTime.Now;
											emailspSelectEmailSendDetail_Result.SendedDateTime = now;
											emailspSelectEmailSendDetail_Result.SendedDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
											emailspSelectEmailSendDetail_Result.StatusId = 1;
											if (!emailspSelectEmailSendDetail_Result.TryCount.HasValue)
											{
												emailspSelectEmailSendDetail_Result.TryCount = 0;
											}
											if (_db.EmailspUpdateEmailSendDetail(emailspSelectEmailSendDetail_Result.EmailSendDetailId, emailspSelectEmailSendDetail_Result.EmailSendHeaderId, emailspSelectEmailSendDetail_Result.EmailAddress, emailspSelectEmailSendDetail_Result.EmailCmpId, emailspSelectEmailSendDetail_Result.EmailCmpPrsId, emailspSelectEmailSendDetail_Result.EmailCmpPrjId, emailspSelectEmailSendDetail_Result.SendDateTime, emailspSelectEmailSendDetail_Result.SendDatePersian, emailspSelectEmailSendDetail_Result.SendedDateTime, emailspSelectEmailSendDetail_Result.SendedDatePersian, emailspSelectEmailSendDetail_Result.StatusId, now, now.ToString("yyyyMMdd", new PersianCulture()), emailspSelectEmailSendDetail_Result.EmailCmpPrsName, emailspSelectEmailSendDetail_Result.EmailCmpName, emailspSelectEmailSendDetail_Result.EmailPrsJob, appType, emailspSelectEmailSendDetail_Result.TryCount) <= 0)
											{
												data = "-2";
												message = string.Format(Messages.msgErrInUpdateEmailDetails, _email.Detail_EmailAddress);
												status = CommonResultStatusViewModel.Fail;
											}
											else
											{
												if (Enumerable.ToList<EmailspSelectEmailSendDetail_Result>((IEnumerable<EmailspSelectEmailSendDetail_Result>)_db.EmailspSelectEmailSendDetail("EmailSendHeaderId=" + _email.Header_Id + " AND StatusId=0", "")).Count > 0)
												{
													goto IL_07e6;
												}
												EmailspSelectEmailSendHeader_Result emailspSelectEmailSendHeader_Result = Enumerable.FirstOrDefault<EmailspSelectEmailSendHeader_Result>((IEnumerable<EmailspSelectEmailSendHeader_Result>)_db.EmailspSelectEmailSendHeader("EmailSendHeaderId=" + _email.Header_Id, ""));
												if (emailspSelectEmailSendHeader_Result == null)
												{
													goto IL_07e6;
												}
												now = DateTime.Now;
												emailspSelectEmailSendHeader_Result.EndDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
												emailspSelectEmailSendHeader_Result.EndDateTime = now;
												if (_db.EmailspUpdateEmailSendHeader(emailspSelectEmailSendHeader_Result.EmailSendHeaderId, emailspSelectEmailSendHeader_Result.UserId, emailspSelectEmailSendHeader_Result.Subject, emailspSelectEmailSendHeader_Result.Body, emailspSelectEmailSendHeader_Result.StartDateTime, emailspSelectEmailSendHeader_Result.StartDatePersian, emailspSelectEmailSendHeader_Result.EndDateTime, emailspSelectEmailSendHeader_Result.EndDatePersian, emailspSelectEmailSendHeader_Result.PriorityId, emailspSelectEmailSendHeader_Result.RegisterDate, emailspSelectEmailSendHeader_Result.RegisterDatePersian, emailspSelectEmailSendHeader_Result.EmailUsersInfoId, emailspSelectEmailSendHeader_Result.EmailSettingId, appType) > 0)
												{
													headerIds = headerIds + _email.Header_Id + ",";
													goto IL_07e6;
												}
												data = "-2";
												message = string.Format(Messages.msgErrInUpdateEmailDetails, _email.Detail_EmailAddress);
												status = CommonResultStatusViewModel.Fail;
											}
										}
									}
									else
									{
										int result2 = 0;
										if (_email.Detail_TryCount.HasValue)
										{
											int.TryParse(_email.Detail_TryCount.ToString(), out result2);
										}
										if (result2 < 0)
										{
											result2 = 0;
										}
										if (result2 < 2)
										{
											result2++;
											_email.Detail_TryCount = result2;
											EmailspSelectEmailSendDetail_Result emailspSelectEmailSendDetail_Result2 = Enumerable.FirstOrDefault<EmailspSelectEmailSendDetail_Result>((IEnumerable<EmailspSelectEmailSendDetail_Result>)_db.EmailspSelectEmailSendDetail("EmailSendDetailId=" + _email.Detail_Id, ""));
											if (emailspSelectEmailSendDetail_Result2 != null)
											{
												emailspSelectEmailSendDetail_Result2.TryCount = result2;
												if (_db.EmailspUpdateEmailSendDetail(emailspSelectEmailSendDetail_Result2.EmailSendDetailId, emailspSelectEmailSendDetail_Result2.EmailSendHeaderId, emailspSelectEmailSendDetail_Result2.EmailAddress, emailspSelectEmailSendDetail_Result2.EmailCmpId, emailspSelectEmailSendDetail_Result2.EmailCmpPrsId, emailspSelectEmailSendDetail_Result2.EmailCmpPrjId, emailspSelectEmailSendDetail_Result2.SendDateTime, emailspSelectEmailSendDetail_Result2.SendDatePersian, emailspSelectEmailSendDetail_Result2.SendedDateTime, emailspSelectEmailSendDetail_Result2.SendedDatePersian, emailspSelectEmailSendDetail_Result2.StatusId, now, text, emailspSelectEmailSendDetail_Result2.EmailCmpPrsName, emailspSelectEmailSendDetail_Result2.EmailCmpName, emailspSelectEmailSendDetail_Result2.EmailPrsJob, appType, emailspSelectEmailSendDetail_Result2.TryCount) <= 0)
												{
													data = "-2";
													message = string.Format(Messages.msgErrInUpdateEmailDetails, _email.Detail_EmailAddress);
													status = CommonResultStatusViewModel.Fail;
												}
												else
												{
													data = "-1";
													message = string.Format(Messages.msgErrInUpdateEmailDetails, _email.Detail_EmailAddress);
													status = CommonResultStatusViewModel.Fail;
												}
											}
										}
										else
										{
											EmailspSelectEmailSendDetail_Result emailspSelectEmailSendDetail_Result3 = Enumerable.FirstOrDefault<EmailspSelectEmailSendDetail_Result>((IEnumerable<EmailspSelectEmailSendDetail_Result>)_db.EmailspSelectEmailSendDetail("EmailSendDetailId=" + _email.Detail_Id, ""));
											if (emailspSelectEmailSendDetail_Result3 == null)
											{
												goto IL_0c2e;
											}
											emailspSelectEmailSendDetail_Result3.SendedDateTime = now;
											emailspSelectEmailSendDetail_Result3.SendedDatePersian = text;
											emailspSelectEmailSendDetail_Result3.StatusId = -2;
											emailspSelectEmailSendDetail_Result3.TryCount = 3;
											if (_db.EmailspUpdateEmailSendDetail(emailspSelectEmailSendDetail_Result3.EmailSendDetailId, emailspSelectEmailSendDetail_Result3.EmailSendHeaderId, emailspSelectEmailSendDetail_Result3.EmailAddress, emailspSelectEmailSendDetail_Result3.EmailCmpId, emailspSelectEmailSendDetail_Result3.EmailCmpPrsId, emailspSelectEmailSendDetail_Result3.EmailCmpPrjId, emailspSelectEmailSendDetail_Result3.SendDateTime, emailspSelectEmailSendDetail_Result3.SendDatePersian, emailspSelectEmailSendDetail_Result3.SendedDateTime, emailspSelectEmailSendDetail_Result3.SendedDatePersian, emailspSelectEmailSendDetail_Result3.StatusId, now, text, emailspSelectEmailSendDetail_Result3.EmailCmpPrsName, emailspSelectEmailSendDetail_Result3.EmailCmpName, emailspSelectEmailSendDetail_Result3.EmailPrsJob, appType, emailspSelectEmailSendDetail_Result3.TryCount) <= 0)
											{
												data = "-2";
												message = string.Format(Messages.msgErrInUpdateEmailDetails, _email.Detail_EmailAddress);
												status = CommonResultStatusViewModel.Fail;
											}
											else
											{
												if (Enumerable.ToList<EmailspSelectEmailSendDetail_Result>((IEnumerable<EmailspSelectEmailSendDetail_Result>)_db.EmailspSelectEmailSendDetail("EmailSendHeaderId=" + _email.Header_Id + " AND StatusId=0", "")).Count > 0)
												{
													goto IL_0c2e;
												}
												EmailspSelectEmailSendHeader_Result emailspSelectEmailSendHeader_Result2 = Enumerable.FirstOrDefault<EmailspSelectEmailSendHeader_Result>((IEnumerable<EmailspSelectEmailSendHeader_Result>)_db.EmailspSelectEmailSendHeader("EmailSendHeaderId=" + _email.Header_Id, ""));
												if (emailspSelectEmailSendHeader_Result2 == null)
												{
													goto IL_0c2e;
												}
												now = DateTime.Now;
												emailspSelectEmailSendHeader_Result2.EndDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
												emailspSelectEmailSendHeader_Result2.EndDateTime = now;
												if (_db.EmailspUpdateEmailSendHeader(emailspSelectEmailSendHeader_Result2.EmailSendHeaderId, emailspSelectEmailSendHeader_Result2.UserId, emailspSelectEmailSendHeader_Result2.Subject, emailspSelectEmailSendHeader_Result2.Body, emailspSelectEmailSendHeader_Result2.StartDateTime, emailspSelectEmailSendHeader_Result2.StartDatePersian, emailspSelectEmailSendHeader_Result2.EndDateTime, emailspSelectEmailSendHeader_Result2.EndDatePersian, emailspSelectEmailSendHeader_Result2.PriorityId, emailspSelectEmailSendHeader_Result2.RegisterDate, emailspSelectEmailSendHeader_Result2.RegisterDatePersian, emailspSelectEmailSendHeader_Result2.EmailUsersInfoId, emailspSelectEmailSendHeader_Result2.EmailSettingId, appType) > 0)
												{
													headerIds = headerIds + _email.Header_Id + ",";
													goto IL_0c2e;
												}
												data = "-2";
												message = string.Format(Messages.msgErrInUpdateEmailDetails, _email.Detail_EmailAddress);
												status = CommonResultStatusViewModel.Fail;
											}
										}
									}
								}
								else
								{
									data = "0";
									message = string.Format(Messages.msgStartTimeToSendEmail, text4, text5);
									status = CommonResultStatusViewModel.Success;
								}
							}
							else
							{
								data = "0";
								message = Messages.msgErrEmailBulkingIsNotActive;
								status = CommonResultStatusViewModel.Success;
							}
							goto end_IL_03fa;
							IL_07e6:
							data = headerIds;
							message = string.Format(Messages.msgSendEmailBySuccess, _email.Detail_EmailAddress);
							status = CommonResultStatusViewModel.Success;
							goto end_IL_03fa;
							IL_0c2e:
							data = headerIds;
							message = string.Format(Messages.msgErrEmailRemoveFromQueue, _email.Detail_EmailAddress);
							status = CommonResultStatusViewModel.Fail;
							end_IL_03fa:;
						}
					}
					else
					{
						data = "0";
						message = Messages.msgErrorTankIsEmpty;
						status = CommonResultStatusViewModel.Error;
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
					data = "0";
					message = Messages.msgErrorRunFunction;
					status = CommonResultStatusViewModel.Error;
				}
			}
			else
			{
				data = "0";
				message = Messages.msgErrorInReadingEmailSetting;
				status = CommonResultStatusViewModel.Error;
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			data = "0";
			message = Messages.msgErrorRunFunction;
			status = CommonResultStatusViewModel.Error;
		}
		CommonResultViewModel<string> data2 = new CommonResultViewModel<string>
		{
			Data = data,
			Message = message,
			Status = status
		};
		return Json(data2, JsonRequestBehavior.AllowGet);
	}

	public bool IsBetween(DateTime time, DateTime startTime, DateTime endTime)
	{
		if (time.TimeOfDay == startTime.TimeOfDay)
		{
			return true;
		}
		if (time.TimeOfDay == endTime.TimeOfDay)
		{
			return true;
		}
		if (startTime.TimeOfDay <= endTime.TimeOfDay)
		{
			if (time.TimeOfDay >= startTime.TimeOfDay)
			{
				return time.TimeOfDay <= endTime.TimeOfDay;
			}
			return false;
		}
		if (time.TimeOfDay >= endTime.TimeOfDay)
		{
			return !(time.TimeOfDay <= startTime.TimeOfDay);
		}
		return true;
	}

	private bool SendEmail(EmailspSelectEmailReadySend_Result item)
	{
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0201: Unknown result type (might be due to invalid IL or missing references)
		//IL_0208: Expected O, but got Unknown
		//IL_026a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0411: Unknown result type (might be due to invalid IL or missing references)
		//IL_0416: Unknown result type (might be due to invalid IL or missing references)
		//IL_041c: Expected O, but got Unknown
		//IL_091b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0925: Expected O, but got Unknown
		MailAddress mailAddress = null;
		try
		{
			string oldValue = ((_setting.EmailsAttachFilePath == null) ? "" : (_setting.EmailsAttachFilePath + (_setting.EmailsAttachFilePath.EndsWith("\\") ? "" : "\\")));
			if (_setting.EmailsPDFBodyFilePathFtp != null)
			{
				_ = _setting.EmailsPDFBodyFilePathFtp + (_setting.EmailsPDFBodyFilePathFtp.EndsWith("/") ? "" : "/");
			}
			string text = ((_setting.EmailsAttachShareFilePathFtp == null) ? "" : (_setting.EmailsAttachShareFilePathFtp + (_setting.EmailsAttachShareFilePathFtp.EndsWith("/") ? "" : "/")));
			string text2 = HostingEnvironment.MapPath(Configuration.HostTempFilesPath + "/Emails/SendFile");
			if (!System.IO.Directory.Exists(text2))
			{
				System.IO.Directory.CreateDirectory(text2);
				CRM.General.IO.Directory.SetFullControlForEveryOne(text2);
			}
			else
			{
				text2 = text2 + "/" + item.Header_Id;
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
			string cmpPattern = _setting.CmpPattern;
			string cmpPrsPattern = _setting.CmpPrsPattern;
			string cmpPrsJobPattern = _setting.CmpPrsJobPattern;
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			string text3 = item.Header_Body.Replace(cmpPattern, item.Detail_EmailCmpName).Replace(cmpPrsPattern, item.Detail_EmailCmpPrsName).Replace(cmpPrsJobPattern, item.Detail_EmailPrsJob) + "<p style='display:none;'>" + DateTime.Now.ToString("R") + "</p>";
			foreach (Match item2 in new Regex("[a-z]:\\\\(?:[^\\\\:]+\\\\)*((?:[^:\\\\]+)\\.\\w+)", (RegexOptions)1).Matches(text3))
			{
				Match val = item2;
				string text4 = Guid.NewGuid().ToString();
				text3 = text3.Replace(((Capture)val).Value, "cid:" + text4);
				dictionary.Add(text4, ((Capture)val).Value);
			}
			new MailMessage();
			MailMessage mailMessage = new MailMessage();
			BodyBuilder bodyBuilder = new BodyBuilder();
			foreach (EmailspSelectEmailSendAttachment_Result item3 in Enumerable.ToList<EmailspSelectEmailSendAttachment_Result>((IEnumerable<EmailspSelectEmailSendAttachment_Result>)_db.EmailspSelectEmailSendAttachment("EmailSendHeaderId=" + item.Header_Id, "")))
			{
				string text5 = item3.FilePath;
				if (!string.IsNullOrWhiteSpace(text5))
				{
					text5 = text5.Replace(oldValue, "");
					string text6 = text2 + "/" + text5;
					string source = text + text5;
					text5 = (System.IO.File.Exists(text6) ? text6 : ((!facadeFTP.Download(pathFtp, userNameFtp, passwordFtp, text6, source, overwrite: true, usePassiveFtp)) ? "" : text6));
				}
				if (!string.IsNullOrWhiteSpace(text5) && System.IO.File.Exists(text5))
				{
					Attachment attachment = new Attachment(text5);
					System.Net.Mime.ContentDisposition? contentDisposition = attachment.ContentDisposition;
					contentDisposition.CreationDate = System.IO.File.GetCreationTime(attachment.Name);
					contentDisposition.ModificationDate = System.IO.File.GetLastWriteTime(text5);
					contentDisposition.ReadDate = System.IO.File.GetLastAccessTime(text5);
					contentDisposition.FileName = Path.GetFileName(text5);
					contentDisposition.Size = new FileInfo(text5).Length;
					contentDisposition.DispositionType = "attachment";
					bodyBuilder.Attachments.Add(text5);
					mailMessage.Attachments.Add(attachment);
				}
			}
			if (item.UsersInfo_euSMTPUseSsl.GetValueOrDefault())
			{
				using MailKit.Net.Smtp.SmtpClient smtpClient = new MailKit.Net.Smtp.SmtpClient();
				object obj = _003C_003Ec._003C_003E9__10_0;
				if (obj == null)
				{
					RemoteCertificateValidationCallback val2 = delegate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
					{
						//IL_0000: Unknown result type (might be due to invalid IL or missing references)
						//IL_0006: Unknown result type (might be due to invalid IL or missing references)
						//IL_0009: Invalid comparison between Unknown and I4
						if ((int)sslPolicyErrors == 0)
						{
							return true;
						}
						if ((int)sslPolicyErrors == 4)
						{
							X509ChainStatus[] chainStatus = chain.ChainStatus;
							for (int i = 0; i < chainStatus.Length; i++)
							{
								X509ChainStatus x509ChainStatus = chainStatus[i];
								if (x509ChainStatus.Status != X509ChainStatusFlags.RevocationStatusUnknown && x509ChainStatus.Status != X509ChainStatusFlags.OfflineRevocation)
								{
									return false;
								}
							}
							return true;
						}
						return false;
					};
					_003C_003Ec._003C_003E9__10_0 = val2;
					obj = (object)val2;
				}
				smtpClient.ServerCertificateValidationCallback = (RemoteCertificateValidationCallback)obj;
				if (item.UsersInfo_euSMTPPort.GetValueOrDefault(465) == 587)
				{
					smtpClient.Connect(item.UsersInfo_euSMTPServer, item.UsersInfo_euSMTPPort.GetValueOrDefault(465), SecureSocketOptions.StartTls);
				}
				else
				{
					smtpClient.Connect(item.UsersInfo_euSMTPServer, item.UsersInfo_euSMTPPort.GetValueOrDefault(465), SecureSocketOptions.SslOnConnect);
				}
				smtpClient.Authenticate(item.UsersInfo_euUserName, item.UsersInfo_euPassword);
				MimeMessage mimeMessage = new MimeMessage();
				mimeMessage.Bcc.Add(new MailboxAddress((item.Detail_EmailCmpPrsName != "") ? item.Detail_EmailCmpPrsName : item.Detail_EmailAddress, item.Detail_EmailAddress));
				mimeMessage.From.Add(new MailboxAddress(item.UsersInfo_euNikeName, item.UsersInfo_euNikeEmail));
				mimeMessage.To.Add(new MailboxAddress((item.Detail_EmailCmpPrsName != "") ? item.Detail_EmailCmpPrsName : item.Detail_EmailAddress, item.Detail_EmailAddress));
				string subject = item.Header_Subject.Replace(cmpPattern, item.Detail_EmailCmpName).Replace(cmpPrsPattern, item.Detail_EmailCmpPrsName).Replace(cmpPrsJobPattern, item.Detail_EmailPrsJob);
				mimeMessage.Subject = subject;
				mimeMessage.Priority = MessagePriority.Urgent;
				bodyBuilder.HtmlBody = text3;
				foreach (string key in dictionary.Keys)
				{
					string text7 = dictionary[key];
					string text8 = "";
					if (!string.IsNullOrWhiteSpace(text7))
					{
						text7 = text7.Replace(oldValue, "");
						string text9 = text2 + "/" + text7;
						string source2 = text + text7;
						if (!System.IO.File.Exists(text9))
						{
							if (facadeFTP.Download(pathFtp, userNameFtp, passwordFtp, text9, source2, overwrite: true, usePassiveFtp))
							{
								text8 = text9;
							}
						}
						else
						{
							text8 = text9;
						}
					}
					if (!string.IsNullOrWhiteSpace(text8))
					{
						string mimeMapping = MimeMapping.GetMimeMapping(text8);
						LinkedResource linkedResource = new LinkedResource(text8, mimeMapping);
						linkedResource.ContentId = key;
						linkedResource.ContentType.MediaType = mimeMapping;
						linkedResource.TransferEncoding = TransferEncoding.Base64;
						linkedResource.ContentType.Name = Path.GetFileName(text8);
						linkedResource.ContentLink = new Uri("cid:" + key);
					}
				}
				mimeMessage.Body = bodyBuilder.ToMessageBody();
				smtpClient.Timeout = 60000;
				smtpClient.Send(mimeMessage);
				smtpClient.Dispose();
			}
			else
			{
				mailAddress = new MailAddress(item.Detail_EmailAddress, (item.Detail_EmailCmpPrsName != "") ? item.Detail_EmailCmpPrsName : item.Detail_EmailAddress);
				mailMessage.Bcc.Add(mailAddress);
				mailMessage.From = new MailAddress(item.UsersInfo_euNikeEmail, item.UsersInfo_euNikeName);
				string subject2 = item.Header_Subject.Replace(cmpPattern, item.Detail_EmailCmpName).Replace(cmpPrsPattern, item.Detail_EmailCmpPrsName).Replace(cmpPrsJobPattern, item.Detail_EmailPrsJob);
				mailMessage.Subject = subject2;
				mailMessage.DeliveryNotificationOptions = DeliveryNotificationOptions.Never;
				mailMessage.Priority = MailPriority.High;
				mailMessage.IsBodyHtml = true;
				mailMessage.BodyEncoding = Encoding.UTF8;
				mailMessage.SubjectEncoding = Encoding.UTF8;
				AlternateView alternateView = AlternateView.CreateAlternateViewFromString(text3, (Encoding)null, "text/html");
				foreach (string key2 in dictionary.Keys)
				{
					string text10 = dictionary[key2];
					string text11 = "";
					if (!string.IsNullOrWhiteSpace(text10))
					{
						text10 = text10.Replace(oldValue, "");
						string text12 = text2 + "/" + text10;
						string source3 = text + text10;
						if (!System.IO.File.Exists(text12))
						{
							if (facadeFTP.Download(pathFtp, userNameFtp, passwordFtp, text12, source3, overwrite: true, usePassiveFtp))
							{
								text11 = text12;
							}
						}
						else
						{
							text11 = text12;
						}
					}
					if (!string.IsNullOrWhiteSpace(text11))
					{
						string mimeMapping2 = MimeMapping.GetMimeMapping(text11);
						LinkedResource linkedResource2 = new LinkedResource(text11, mimeMapping2);
						linkedResource2.ContentId = key2;
						linkedResource2.ContentType.MediaType = mimeMapping2;
						linkedResource2.TransferEncoding = TransferEncoding.Base64;
						linkedResource2.ContentType.Name = Path.GetFileName(text11);
						linkedResource2.ContentLink = new Uri("cid:" + key2);
						alternateView.LinkedResources.Add(linkedResource2);
					}
				}
				mailMessage.AlternateViews.Add(alternateView);
				System.Net.Mail.SmtpClient smtpClient2 = new System.Net.Mail.SmtpClient();
				smtpClient2.DeliveryMethod = SmtpDeliveryMethod.Network;
				smtpClient2.Host = item.UsersInfo_euSMTPServer;
				smtpClient2.EnableSsl = item.UsersInfo_euSMTPUseSsl.GetValueOrDefault();
				smtpClient2.UseDefaultCredentials = item.UsersInfo_euSMTPUseDefCredentials.GetValueOrDefault();
				smtpClient2.Credentials = (ICredentialsByHost?)new NetworkCredential(item.UsersInfo_euUserName, item.UsersInfo_euPassword);
				smtpClient2.Port = item.UsersInfo_euSMTPPort.GetValueOrDefault(25);
				smtpClient2.ServicePoint.MaxIdleTime = 1;
				smtpClient2.Timeout = 60000;
				smtpClient2.Send(mailMessage);
			}
			return true;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return false;
		}
	}

	public string DeleteOldFiles(string headerIds)
	{
		string text = ((string.IsNullOrWhiteSpace(headerIds) || headerIds == ",") ? "" : ((headerIds.StartsWith(",") ? "" : ",") + headerIds));
		text += (text.EndsWith(",") ? "" : ",");
		try
		{
			if (!string.IsNullOrWhiteSpace(headerIds) && headerIds != ",")
			{
				string[] array = headerIds.Split(new char[1] { ',' });
				if (Enumerable.Any<string>((IEnumerable<string>)array))
				{
					string[] array2 = array;
					foreach (string text2 in array2)
					{
						string s = ((!string.IsNullOrWhiteSpace(text2)) ? text2 : "-1");
						int result = 0;
						int.TryParse(s, out result);
						if (result <= 0)
						{
							continue;
						}
						string path = HostingEnvironment.MapPath(Configuration.HostTempFilesPath + "/Emails/SendFile/" + result);
						if (System.IO.Directory.Exists(path))
						{
							DirectoryInfo directoryInfo = new DirectoryInfo(path);
							FileInfo[] files = directoryInfo.GetFiles();
							for (int j = 0; j < files.Length; j++)
							{
								files[j].Delete();
							}
							DirectoryInfo[] directories = directoryInfo.GetDirectories();
							for (int j = 0; j < directories.Length; j++)
							{
								directories[j].Delete(recursive: true);
							}
							if (System.IO.Directory.Exists(path))
							{
								System.IO.Directory.Delete(path);
							}
						}
						text = text.Replace("," + result.ToString().ToString() + ",", ",");
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

	public void SendSingleEmailSync(EmailspSelectEmailReadySend_Result emailInfo)
	{
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		try
		{
			int result = 0;
			EmailspSelectEmailSetting_Result emailspSelectEmailSetting_Result = Enumerable.FirstOrDefault<EmailspSelectEmailSetting_Result>((IEnumerable<EmailspSelectEmailSetting_Result>)cRMSpEntities.EmailspSelectEmailSetting("", ""));
			if (emailspSelectEmailSetting_Result != null && VersionBuyer.Emails)
			{
				int.TryParse(emailspSelectEmailSetting_Result.EmailBulkingDelayTime.ToString(), out result);
				if (result < 3)
				{
					result = 3;
				}
				result *= 1000;
				ActSendEmail("", emailInfo);
			}
		}
		catch (Exception ex)
		{
			Logs.LogError(ex, "");
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbI.Dispose();
		_dbIII.Dispose();
		base.Dispose(disposing);
	}
}
