using System;
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
using System.Web.Http;
using System.Web.Mail;
using CRM.General.IO;
using CRM.General.IO.FTP;
using CRM.General.Security;
using CRM.Resources;
using Elmah;
using GSD.Globalization;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using Mobile.Cache.Setting;
using Mobile.Classes;
using Mobile.Classes.Helper;
using Mobile.DataType;
using Mobile.Models;
using NReco.PdfGenerator;

namespace Mobile.Controllers;

public class EmailController : ApiController
{
	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static RemoteCertificateValidationCallback _003C_003E9__2_0;

		internal bool _003CSendEmail_003Eb__2_0(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
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

	public ServiceResult<string> ActSendEmailByOtp(string otpCode, string headerIds = "")
	{
		string data = "";
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		CRMEntities cRMEntities = null;
		try
		{
			cRMEntities = new CRMEntities();
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			string text = now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(now.ToString("MM", new PersianCulture()));
			string appType = Mobile.Classes.Configuration.AppType;
			short.Parse(Financial.Get().Id.ToString());
			if (UserLogin.CurrentUser != null)
			{
				_ = UserLogin.CurrentUser.UserId;
			}
			MobspSelectEmailSetting_Result mobspSelectEmailSetting_Result = Enumerable.FirstOrDefault<MobspSelectEmailSetting_Result>((IEnumerable<MobspSelectEmailSetting_Result>)cRMEntities.MobspSelectEmailSetting("", ""));
			if (mobspSelectEmailSetting_Result != null)
			{
				try
				{
					if (!string.IsNullOrWhiteSpace(headerIds))
					{
						headerIds = DeleteOldFiles(headerIds);
					}
					DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59");
					MobspSelectEmailReadySendByOTP_Result mobspSelectEmailReadySendByOTP_Result = Enumerable.FirstOrDefault<MobspSelectEmailReadySendByOTP_Result>((IEnumerable<MobspSelectEmailReadySendByOTP_Result>)cRMEntities.MobspSelectEmailReadySendByOTP(otpCode));
					MobspSelectEmailReadySend_Result mobspSelectEmailReadySend_Result = null;
					if (mobspSelectEmailReadySendByOTP_Result != null)
					{
						mobspSelectEmailReadySend_Result = new MobspSelectEmailReadySend_Result();
						mobspSelectEmailReadySend_Result.UserId = mobspSelectEmailReadySendByOTP_Result.UserId;
						mobspSelectEmailReadySend_Result.Header_Id = mobspSelectEmailReadySendByOTP_Result.Header_Id;
						mobspSelectEmailReadySend_Result.Header_Subject = mobspSelectEmailReadySendByOTP_Result.Header_Subject;
						mobspSelectEmailReadySend_Result.Header_Body = mobspSelectEmailReadySendByOTP_Result.Header_Body;
						mobspSelectEmailReadySend_Result.Header_PriorityId = mobspSelectEmailReadySendByOTP_Result.Header_PriorityId;
						mobspSelectEmailReadySend_Result.Setting_Id = mobspSelectEmailReadySendByOTP_Result.Setting_Id;
						mobspSelectEmailReadySend_Result.UsersInfo_Id = mobspSelectEmailReadySendByOTP_Result.UsersInfo_Id;
						mobspSelectEmailReadySend_Result.UsersInfo_euUserId = mobspSelectEmailReadySendByOTP_Result.UsersInfo_euUserId;
						mobspSelectEmailReadySend_Result.UsersInfo_euNikeName = mobspSelectEmailReadySendByOTP_Result.UsersInfo_euNikeName;
						mobspSelectEmailReadySend_Result.UsersInfo_euNikeEmail = mobspSelectEmailReadySendByOTP_Result.UsersInfo_euNikeEmail;
						mobspSelectEmailReadySend_Result.UsersInfo_euPOP3Server = mobspSelectEmailReadySendByOTP_Result.UsersInfo_euPOP3Server;
						mobspSelectEmailReadySend_Result.UsersInfo_euSMTPServer = mobspSelectEmailReadySendByOTP_Result.UsersInfo_euSMTPServer;
						mobspSelectEmailReadySend_Result.UsersInfo_euUserName = mobspSelectEmailReadySendByOTP_Result.UsersInfo_euUserName;
						mobspSelectEmailReadySend_Result.UsersInfo_euPassword = ((!string.IsNullOrEmpty(mobspSelectEmailReadySendByOTP_Result.UsersInfo_euPassword)) ? XorCipher.DecryptByPrivateKey(mobspSelectEmailReadySendByOTP_Result.UsersInfo_euPassword) : string.Empty);
						mobspSelectEmailReadySend_Result.UsersInfo_euIsActive = mobspSelectEmailReadySendByOTP_Result.UsersInfo_euIsActive;
						mobspSelectEmailReadySend_Result.Detail_Id = mobspSelectEmailReadySendByOTP_Result.Detail_Id;
						mobspSelectEmailReadySend_Result.Detail_EmailAddress = mobspSelectEmailReadySendByOTP_Result.Detail_EmailAddress;
						mobspSelectEmailReadySend_Result.Detail_EmailCmpId = mobspSelectEmailReadySendByOTP_Result.Detail_EmailCmpId;
						mobspSelectEmailReadySend_Result.Detail_EmailCmpPrsId = mobspSelectEmailReadySendByOTP_Result.Detail_EmailCmpPrsId;
						mobspSelectEmailReadySend_Result.Detail_EmailCmpPrjId = mobspSelectEmailReadySendByOTP_Result.Detail_EmailCmpPrjId;
						mobspSelectEmailReadySend_Result.Detail_EmailCmpName = mobspSelectEmailReadySendByOTP_Result.Detail_EmailCmpName;
						mobspSelectEmailReadySend_Result.Detail_EmailCmpPrsName = mobspSelectEmailReadySendByOTP_Result.Detail_EmailCmpPrsName;
						mobspSelectEmailReadySend_Result.Detail_EmailPrsJob = mobspSelectEmailReadySendByOTP_Result.Detail_EmailPrsJob;
						mobspSelectEmailReadySend_Result.Detail_StatusId = mobspSelectEmailReadySendByOTP_Result.Detail_StatusId;
						mobspSelectEmailReadySend_Result.Detail_AppType = mobspSelectEmailReadySendByOTP_Result.Detail_AppType;
						mobspSelectEmailReadySend_Result.Detail_TryCount = mobspSelectEmailReadySendByOTP_Result.Detail_TryCount;
						mobspSelectEmailReadySend_Result.UsersInfo_euSMTPUseDefCredentials = mobspSelectEmailReadySendByOTP_Result.UsersInfo_euSMTPUseDefCredentials;
						mobspSelectEmailReadySend_Result.UsersInfo_euSMTPUseSsl = mobspSelectEmailReadySendByOTP_Result.UsersInfo_euSMTPUseSsl;
						mobspSelectEmailReadySend_Result.UsersInfo_euSMTPPort = mobspSelectEmailReadySendByOTP_Result.UsersInfo_euSMTPPort;
						string oTP = mobspSelectEmailReadySendByOTP_Result.OTP;
						oTP = oTP ?? "";
						string text2 = mobspSelectEmailReadySend_Result.Header_Body ?? "";
						string text3 = mobspSelectEmailReadySend_Result.Header_Subject ?? "";
						if (!string.IsNullOrWhiteSpace(text2))
						{
							text2 = text2.Replace("[#کد تاييد OTP#]", oTP);
							mobspSelectEmailReadySend_Result.Header_Body = text2;
						}
						if (!string.IsNullOrWhiteSpace(text3))
						{
							text3 = text3.Replace("[#کد تاييد OTP#]", oTP);
							mobspSelectEmailReadySend_Result.Header_Subject = text3;
						}
					}
					if (mobspSelectEmailReadySend_Result != null)
					{
						lock (mobspSelectEmailReadySend_Result)
						{
							if (mobspSelectEmailSetting_Result.EmailBulkingIsActive.HasValue && mobspSelectEmailSetting_Result.EmailBulkingIsActive.GetValueOrDefault())
							{
								string text4 = ((!string.IsNullOrWhiteSpace(mobspSelectEmailSetting_Result.EmailBulkingDailyStarTime)) ? mobspSelectEmailSetting_Result.EmailBulkingDailyStarTime : "00:00:00");
								string text5 = ((!string.IsNullOrWhiteSpace(mobspSelectEmailSetting_Result.EmailBulkingDailyEndTime)) ? mobspSelectEmailSetting_Result.EmailBulkingDailyEndTime : "23:59:59");
								DateTime startTime = DateTime.Parse(now.ToString("yyyy/MM/dd") + " " + text4);
								DateTime endTime = DateTime.Parse(now.ToString("yyyy/MM/dd") + " " + text5);
								if (IsBetween(DateTime.Now, startTime, endTime))
								{
									if (SendEmail(mobspSelectEmailReadySend_Result, mobspSelectEmailSetting_Result))
									{
										MobspSelectEmailSendDetail_Result mobspSelectEmailSendDetail_Result = Enumerable.FirstOrDefault<MobspSelectEmailSendDetail_Result>((IEnumerable<MobspSelectEmailSendDetail_Result>)cRMEntities.MobspSelectEmailSendDetail("EmailSendDetailId=" + mobspSelectEmailReadySend_Result.Detail_Id, ""));
										if (mobspSelectEmailSendDetail_Result != null)
										{
											now = DateTime.Now;
											mobspSelectEmailSendDetail_Result.SendedDateTime = now;
											mobspSelectEmailSendDetail_Result.SendedDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
											mobspSelectEmailSendDetail_Result.StatusId = 1;
											if (!mobspSelectEmailSendDetail_Result.TryCount.HasValue)
											{
												mobspSelectEmailSendDetail_Result.TryCount = 0;
											}
											if (cRMEntities.MobspUpdateEmailSendDetail(mobspSelectEmailSendDetail_Result.EmailSendDetailId, mobspSelectEmailSendDetail_Result.EmailSendHeaderId, mobspSelectEmailSendDetail_Result.EmailAddress, mobspSelectEmailSendDetail_Result.EmailCmpId, mobspSelectEmailSendDetail_Result.EmailCmpPrsId, mobspSelectEmailSendDetail_Result.EmailCmpPrjId, mobspSelectEmailSendDetail_Result.SendDateTime, mobspSelectEmailSendDetail_Result.SendDatePersian, mobspSelectEmailSendDetail_Result.SendedDateTime, mobspSelectEmailSendDetail_Result.SendedDatePersian, mobspSelectEmailSendDetail_Result.StatusId, now, now.ToString("yyyyMMdd", new PersianCulture()), mobspSelectEmailSendDetail_Result.EmailCmpPrsName, mobspSelectEmailSendDetail_Result.EmailCmpName, mobspSelectEmailSendDetail_Result.EmailPrsJob, appType, mobspSelectEmailSendDetail_Result.TryCount) <= 0)
											{
												data = "-2";
												message = string.Format(Messages.msgErrInUpdateEmailDetails, mobspSelectEmailReadySend_Result.Detail_EmailAddress);
												status = ServiceResultStatus.Fail;
											}
											else
											{
												if (Enumerable.ToList<MobspSelectEmailSendDetail_Result>((IEnumerable<MobspSelectEmailSendDetail_Result>)cRMEntities.MobspSelectEmailSendDetail("EmailSendHeaderId=" + mobspSelectEmailReadySend_Result.Header_Id + " AND StatusId=0", "")).Count > 0)
												{
													goto IL_06d8;
												}
												MobspSelectEmailSendHeader_Result mobspSelectEmailSendHeader_Result = Enumerable.FirstOrDefault<MobspSelectEmailSendHeader_Result>((IEnumerable<MobspSelectEmailSendHeader_Result>)cRMEntities.MobspSelectEmailSendHeader("EmailSendHeaderId=" + mobspSelectEmailReadySend_Result.Header_Id, ""));
												if (mobspSelectEmailSendHeader_Result == null)
												{
													goto IL_06d8;
												}
												now = DateTime.Now;
												mobspSelectEmailSendHeader_Result.EndDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
												mobspSelectEmailSendHeader_Result.EndDateTime = now;
												if (cRMEntities.MobspUpdateEmailSendHeader(mobspSelectEmailSendHeader_Result.EmailSendHeaderId, mobspSelectEmailSendHeader_Result.UserId, mobspSelectEmailSendHeader_Result.Subject, mobspSelectEmailSendHeader_Result.Body, mobspSelectEmailSendHeader_Result.StartDateTime, mobspSelectEmailSendHeader_Result.StartDatePersian, mobspSelectEmailSendHeader_Result.EndDateTime, mobspSelectEmailSendHeader_Result.EndDatePersian, mobspSelectEmailSendHeader_Result.PriorityId, mobspSelectEmailSendHeader_Result.RegisterDate, mobspSelectEmailSendHeader_Result.RegisterDatePersian, mobspSelectEmailSendHeader_Result.EmailUsersInfoId, mobspSelectEmailSendHeader_Result.EmailSettingId, appType) > 0)
												{
													headerIds = headerIds + mobspSelectEmailReadySend_Result.Header_Id + ",";
													goto IL_06d8;
												}
												data = "-2";
												message = string.Format(Messages.msgErrInUpdateEmailDetails, mobspSelectEmailReadySend_Result.Detail_EmailAddress);
												status = ServiceResultStatus.Fail;
											}
										}
									}
									else
									{
										int result2 = 0;
										if (mobspSelectEmailReadySend_Result.Detail_TryCount.HasValue)
										{
											int.TryParse(mobspSelectEmailReadySend_Result.Detail_TryCount.ToString(), out result2);
										}
										if (result2 < 0)
										{
											result2 = 0;
										}
										if (result2 < 2)
										{
											result2++;
											mobspSelectEmailReadySend_Result.Detail_TryCount = result2;
											MobspSelectEmailSendDetail_Result mobspSelectEmailSendDetail_Result2 = Enumerable.FirstOrDefault<MobspSelectEmailSendDetail_Result>((IEnumerable<MobspSelectEmailSendDetail_Result>)cRMEntities.MobspSelectEmailSendDetail("EmailSendDetailId=" + mobspSelectEmailReadySend_Result.Detail_Id, ""));
											if (mobspSelectEmailSendDetail_Result2 != null)
											{
												mobspSelectEmailSendDetail_Result2.TryCount = result2;
												if (cRMEntities.MobspUpdateEmailSendDetail(mobspSelectEmailSendDetail_Result2.EmailSendDetailId, mobspSelectEmailSendDetail_Result2.EmailSendHeaderId, mobspSelectEmailSendDetail_Result2.EmailAddress, mobspSelectEmailSendDetail_Result2.EmailCmpId, mobspSelectEmailSendDetail_Result2.EmailCmpPrsId, mobspSelectEmailSendDetail_Result2.EmailCmpPrjId, mobspSelectEmailSendDetail_Result2.SendDateTime, mobspSelectEmailSendDetail_Result2.SendDatePersian, mobspSelectEmailSendDetail_Result2.SendedDateTime, mobspSelectEmailSendDetail_Result2.SendedDatePersian, mobspSelectEmailSendDetail_Result2.StatusId, now, text, mobspSelectEmailSendDetail_Result2.EmailCmpPrsName, mobspSelectEmailSendDetail_Result2.EmailCmpName, mobspSelectEmailSendDetail_Result2.EmailPrsJob, appType, mobspSelectEmailSendDetail_Result2.TryCount) <= 0)
												{
													data = "-2";
													message = string.Format(Messages.msgErrInUpdateEmailDetails, mobspSelectEmailReadySend_Result.Detail_EmailAddress);
													status = ServiceResultStatus.Fail;
												}
												else
												{
													data = "-1";
													message = string.Format(Messages.msgErrInUpdateEmailDetails, mobspSelectEmailReadySend_Result.Detail_EmailAddress);
													status = ServiceResultStatus.Fail;
												}
											}
										}
										else
										{
											MobspSelectEmailSendDetail_Result mobspSelectEmailSendDetail_Result3 = Enumerable.FirstOrDefault<MobspSelectEmailSendDetail_Result>((IEnumerable<MobspSelectEmailSendDetail_Result>)cRMEntities.MobspSelectEmailSendDetail("EmailSendDetailId=" + mobspSelectEmailReadySend_Result.Detail_Id, ""));
											if (mobspSelectEmailSendDetail_Result3 == null)
											{
												goto IL_0ac9;
											}
											mobspSelectEmailSendDetail_Result3.SendedDateTime = now;
											mobspSelectEmailSendDetail_Result3.SendedDatePersian = text;
											mobspSelectEmailSendDetail_Result3.StatusId = -2;
											mobspSelectEmailSendDetail_Result3.TryCount = 3;
											if (cRMEntities.MobspUpdateEmailSendDetail(mobspSelectEmailSendDetail_Result3.EmailSendDetailId, mobspSelectEmailSendDetail_Result3.EmailSendHeaderId, mobspSelectEmailSendDetail_Result3.EmailAddress, mobspSelectEmailSendDetail_Result3.EmailCmpId, mobspSelectEmailSendDetail_Result3.EmailCmpPrsId, mobspSelectEmailSendDetail_Result3.EmailCmpPrjId, mobspSelectEmailSendDetail_Result3.SendDateTime, mobspSelectEmailSendDetail_Result3.SendDatePersian, mobspSelectEmailSendDetail_Result3.SendedDateTime, mobspSelectEmailSendDetail_Result3.SendedDatePersian, mobspSelectEmailSendDetail_Result3.StatusId, now, text, mobspSelectEmailSendDetail_Result3.EmailCmpPrsName, mobspSelectEmailSendDetail_Result3.EmailCmpName, mobspSelectEmailSendDetail_Result3.EmailPrsJob, appType, mobspSelectEmailSendDetail_Result3.TryCount) <= 0)
											{
												data = "-2";
												message = string.Format(Messages.msgErrInUpdateEmailDetails, mobspSelectEmailReadySend_Result.Detail_EmailAddress);
												status = ServiceResultStatus.Fail;
											}
											else
											{
												if (Enumerable.ToList<MobspSelectEmailSendDetail_Result>((IEnumerable<MobspSelectEmailSendDetail_Result>)cRMEntities.MobspSelectEmailSendDetail("EmailSendHeaderId=" + mobspSelectEmailReadySend_Result.Header_Id + " AND StatusId=0", "")).Count > 0)
												{
													goto IL_0ac9;
												}
												MobspSelectEmailSendHeader_Result mobspSelectEmailSendHeader_Result2 = Enumerable.FirstOrDefault<MobspSelectEmailSendHeader_Result>((IEnumerable<MobspSelectEmailSendHeader_Result>)cRMEntities.MobspSelectEmailSendHeader("EmailSendHeaderId=" + mobspSelectEmailReadySend_Result.Header_Id, ""));
												if (mobspSelectEmailSendHeader_Result2 == null)
												{
													goto IL_0ac9;
												}
												now = DateTime.Now;
												mobspSelectEmailSendHeader_Result2.EndDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
												mobspSelectEmailSendHeader_Result2.EndDateTime = now;
												if (cRMEntities.MobspUpdateEmailSendHeader(mobspSelectEmailSendHeader_Result2.EmailSendHeaderId, mobspSelectEmailSendHeader_Result2.UserId, mobspSelectEmailSendHeader_Result2.Subject, mobspSelectEmailSendHeader_Result2.Body, mobspSelectEmailSendHeader_Result2.StartDateTime, mobspSelectEmailSendHeader_Result2.StartDatePersian, mobspSelectEmailSendHeader_Result2.EndDateTime, mobspSelectEmailSendHeader_Result2.EndDatePersian, mobspSelectEmailSendHeader_Result2.PriorityId, mobspSelectEmailSendHeader_Result2.RegisterDate, mobspSelectEmailSendHeader_Result2.RegisterDatePersian, mobspSelectEmailSendHeader_Result2.EmailUsersInfoId, mobspSelectEmailSendHeader_Result2.EmailSettingId, appType) > 0)
												{
													headerIds = headerIds + mobspSelectEmailReadySend_Result.Header_Id + ",";
													goto IL_0ac9;
												}
												data = "-2";
												message = string.Format(Messages.msgErrInUpdateEmailDetails, mobspSelectEmailReadySend_Result.Detail_EmailAddress);
												status = ServiceResultStatus.Fail;
											}
										}
									}
								}
								else
								{
									data = "0";
									message = string.Format(Messages.msgStartTimeToSendEmail, text4, text5);
									status = ServiceResultStatus.Success;
								}
							}
							else
							{
								data = "0";
								message = Messages.msgErrEmailBulkingIsNotActive;
								status = ServiceResultStatus.Success;
							}
							goto end_IL_0363;
							IL_0ac9:
							data = headerIds;
							message = string.Format(Messages.msgErrEmailRemoveFromQueue, mobspSelectEmailReadySend_Result.Detail_EmailAddress);
							status = ServiceResultStatus.Fail;
							goto end_IL_0363;
							IL_06d8:
							data = headerIds;
							message = string.Format(Messages.msgSendEmailBySuccess, mobspSelectEmailReadySend_Result.Detail_EmailAddress);
							status = ServiceResultStatus.Success;
							end_IL_0363:;
						}
					}
					else
					{
						data = "0";
						message = Messages.msgErrorTankIsEmpty;
						status = ServiceResultStatus.Error;
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
					data = "0";
					message = Messages.msgErrorRunFunction;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				data = "0";
				message = Messages.msgErrorInReadingEmailSetting;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			data = "0";
			message = Messages.msgErrorRunFunction;
			status = ServiceResultStatus.Error;
		}
		return new ServiceResult<string>
		{
			Data = data,
			Message = message,
			Status = status
		};
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

	private bool SendEmail(MobspSelectEmailReadySend_Result item, MobspSelectEmailSetting_Result _setting)
	{
		//IL_01b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d5: Expected O, but got Unknown
		//IL_0237: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f1: Expected O, but got Unknown
		//IL_08ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0909: Expected O, but got Unknown
		MailAddress mailAddress = null;
		CRMEntities cRMEntities = null;
		try
		{
			cRMEntities = new CRMEntities();
			string oldValue = ((_setting.EmailsAttachFilePath == null) ? "" : (_setting.EmailsAttachFilePath + (_setting.EmailsAttachFilePath.EndsWith("\\") ? "" : "\\")));
			if (_setting.EmailsPDFBodyFilePathFtp != null)
			{
				_ = _setting.EmailsPDFBodyFilePathFtp + (_setting.EmailsPDFBodyFilePathFtp.EndsWith("/") ? "" : "/");
			}
			string text = ((_setting.EmailsAttachShareFilePathFtp == null) ? "" : (_setting.EmailsAttachShareFilePathFtp + (_setting.EmailsAttachShareFilePathFtp.EndsWith("/") ? "" : "/")));
			string text2 = HostingEnvironment.MapPath(Mobile.Classes.Configuration.HostTempFilesPath + "/Emails/SendFile");
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
			FacadeFTP facadeFTP = new FacadeFTP(Mobile.Classes.Configuration.FacadeFtp);
			string pathFtp = Mobile.Classes.Configuration.PathFtp;
			string userNameFtp = Mobile.Classes.Configuration.UserNameFtp;
			string passwordFtp = Mobile.Classes.Configuration.PasswordFtp;
			bool usePassiveFtp = Mobile.Classes.Configuration.UsePassiveFtp;
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
			foreach (MobspSelectEmailSendAttachment_Result item3 in Enumerable.ToList<MobspSelectEmailSendAttachment_Result>((IEnumerable<MobspSelectEmailSendAttachment_Result>)cRMEntities.MobspSelectEmailSendAttachment("EmailSendHeaderId=" + item.Header_Id, "")))
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
				smtpClient.Timeout = 60000;
				object obj = _003C_003Ec._003C_003E9__2_0;
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
					_003C_003Ec._003C_003E9__2_0 = val2;
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
				mailAddress = new MailAddress(item.Detail_EmailAddress, (item.Detail_EmailCmpPrsName != "") ? item.Detail_EmailCmpPrsName : item.Detail_EmailAddress);
				mailMessage.Bcc.Add(mailAddress);
				mimeMessage.Bcc.Add(new MailboxAddress((item.Detail_EmailCmpPrsName != "") ? item.Detail_EmailCmpPrsName : item.Detail_EmailAddress, item.Detail_EmailAddress));
				mimeMessage.From.Add(new MailboxAddress(item.UsersInfo_euNikeName, item.UsersInfo_euNikeEmail));
				mimeMessage.To.Add(new MailboxAddress(item.Detail_EmailAddress));
				string subject = item.Header_Subject.Replace(cmpPattern, item.Detail_EmailCmpName).Replace(cmpPrsPattern, item.Detail_EmailCmpPrsName).Replace(cmpPrsJobPattern, item.Detail_EmailPrsJob);
				mimeMessage.Subject = subject;
				mimeMessage.Priority = MessagePriority.Urgent;
				bodyBuilder.HtmlBody = text3;
				mimeMessage.Body = bodyBuilder.ToMessageBody();
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
						string path = HostingEnvironment.MapPath(Mobile.Classes.Configuration.HostTempFilesPath + "/Emails/SendFile/" + result);
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

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<int> InsertEmail(InsertEmailViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		int data = 0;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int num = ((result > 0) ? result : result2);
		baseInfo.SetCulture(num);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					cRMSpEntities = new CRMSpEntities();
					DateTime now = DateTime.Now;
					DateTime value = now;
					string text = now.ToString("yyyyMMdd", new PersianCulture());
					int userId = token2.userId;
					string appType = Mobile.Classes.Configuration.AppType;
					decimal? num2 = Enumerable.FirstOrDefault<decimal?>((IEnumerable<decimal?>)cRMSpEntities.MobspInsertEmailSendHeader(userId, model.EmailSubject, model.EmailBody, model.EmailStartDateTime, model.EmailStartDatePersian, null, null, model.EmailPriorityId, value, text, model.EmailUsersInfoId, model.EmailSettingId, appType, num));
					if (num2.GetValueOrDefault() > 0m)
					{
						int num3 = int.Parse(num2.ToString());
						if (model.IsNeedPdf.GetValueOrDefault())
						{
							try
							{
								MobspSelectEmailSetting_Result mobspSelectEmailSetting_Result = Enumerable.FirstOrDefault<MobspSelectEmailSetting_Result>((IEnumerable<MobspSelectEmailSetting_Result>)cRMEntities.MobspSelectEmailSetting("", ""));
								if (mobspSelectEmailSetting_Result == null)
								{
									return new ServiceResult<int>
									{
										Message = Messages.MobMsgEmailSettingNotFound,
										Data = 0,
										Status = ServiceResultStatus.Error
									};
								}
								string obj = ((mobspSelectEmailSetting_Result.EmailsPDFBodyFilePathFtp == null) ? "" : (mobspSelectEmailSetting_Result.EmailsPDFBodyFilePathFtp + (mobspSelectEmailSetting_Result.EmailsPDFBodyFilePathFtp.EndsWith("/") ? "" : "/")));
								_ = Mobile.Classes.Configuration.FacadeFtp;
								string pathFtp = Mobile.Classes.Configuration.PathFtp;
								string userNameFtp = Mobile.Classes.Configuration.UserNameFtp;
								string passwordFtp = Mobile.Classes.Configuration.PasswordFtp;
								bool usePassiveFtp = Mobile.Classes.Configuration.UsePassiveFtp;
								string text2 = num3 + ".pdf";
								string targetFilename = obj + text2;
								Stream sourceStream = new MemoryStream(new HtmlToPdfConverter().GeneratePdf("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" /> <div dir=\"rtl\">" + model.EmailBody + "</div>"));
								if (!new FTPclient(pathFtp, userNameFtp, passwordFtp, usePassiveFtp).Upload(sourceStream, targetFilename))
								{
									return new ServiceResult<int>
									{
										Message = Messages.EmailSendingErrorInSavePdf,
										Data = 0,
										Status = ServiceResultStatus.Error
									};
								}
							}
							catch (Exception e)
							{
								ErrorSignal.FromCurrentContext().Raise(e);
								return new ServiceResult<int>
								{
									Message = Messages.EmailSendingErrorInSavePdf,
									Data = 0,
									Status = ServiceResultStatus.Error
								};
							}
						}
						cRMSpEntities.MobspInsertEmailSendDetail(num3, model.EmailAddress, model.EmailCmpId, model.EmailCmpPrsId, model.EmailCmpPrjId, model.EmailCmpPrsName, model.EmailCmpName, model.EmailPrsJob, value, text, null, null, 0, userId, value, text, appType, num, false, null);
						data = num3;
						message = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
					}
					else
					{
						message = Messages.MobMsgErrorDoneOperation;
						status = ServiceResultStatus.Error;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = 0;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = 0;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e2)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = 0;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		finally
		{
			cRMEntities?.Dispose();
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<int>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<int> GetEmailCnt()
	{
		int num = 1065;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		CRMSpEntities cRMSpEntities = null;
		int data = 0;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((num > 0) ? num : result);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					cRMSpEntities = new CRMSpEntities();
					data = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMSpEntities.MobspReturnEmailCnt()).GetValueOrDefault();
					message = Messages.MobMsgSuccessAction;
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = 0;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = 0;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = 0;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<int>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}
}
