using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
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
using MimeKit;
using NReco.PdfGenerator;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.Emails.Controllers;

public class HomeController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actemSendEmail")]
	public ActionResult Index(int? id = null, string emails = "", string sbj = "", string file = "", string textBody = "", int cmpId = 0, bool hasPass = false, int euFromUserId = 0, int emailReceiveId = 0, string modeInEuRec = "", int euUserDefaultSettingId = 0, string positionName = "", int emailSystemPartId = 0, long emailObjectId = 0L, int receiveMode = 0)
	{
		//IL_1283: Unknown result type (might be due to invalid IL or missing references)
		//IL_129f: Unknown result type (might be due to invalid IL or missing references)
		//IL_12a6: Expected O, but got Unknown
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		base.ViewBag.CmpPattern = (base.ViewBag.CmpPrsJobPattern = (base.ViewBag.CmpPrsPattern = ""));
		EmailSetting emailSetting = Queryable.FirstOrDefault<EmailSetting>((IQueryable<EmailSetting>)_dbTbl.EmailSetting);
		int settingId = 0;
		if (emailSetting != null)
		{
			base.ViewBag.CmpPattern = emailSetting.CmpPattern;
			base.ViewBag.CmpPrsPattern = emailSetting.CmpPrsPattern;
			base.ViewBag.CmpPrsJobPattern = emailSetting.CmpPrsJobPattern;
			settingId = emailSetting.EmailSettingId;
		}
		base.ViewBag.From = LoadComboFrom();
		base.ViewBag.EuFromUserId = euFromUserId;
		base.ViewBag.EuUserDefaultSettingId = euUserDefaultSettingId;
		EmailSendViewModel emailSendViewModel = new EmailSendViewModel();
		emailSendViewModel.SendingDate = DateTime.Now;
		emailSendViewModel.SettingId = settingId;
		emailSendViewModel.PositionName = positionName;
		emailSendViewModel.EmailSystemPartId = emailSystemPartId;
		emailSendViewModel.EmailObjectId = emailObjectId;
		base.ViewBag.StyleDisplay = "none";
		string type = "normal";
		string reciveEmails = "";
		if (id.HasValue && id > 0)
		{
			type = "tank";
			base.ViewBag.StyleDisplay = "";
		}
		else if (emails.Trim() != "")
		{
			type = "email";
			reciveEmails = emails.Trim();
		}
		emailSendViewModel.Type = type;
		emailSendViewModel.ReciveEmails = reciveEmails;
		base.ViewBag.Signature = new List<EmailUserDefaultSetting>();
		DbSet<EmailUserDefaultSetting> emailUserDefaultSetting = _dbTbl.EmailUserDefaultSetting;
		ParameterExpression val = Expression.Parameter(typeof(EmailUserDefaultSetting), "c");
		List<EmailUserDefaultSetting> list = Enumerable.ToList<EmailUserDefaultSetting>((IEnumerable<EmailUserDefaultSetting>)Queryable.Where<EmailUserDefaultSetting>((IQueryable<EmailUserDefaultSetting>)emailUserDefaultSetting, Expression.Lambda<Func<EmailUserDefaultSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Property((Expression)null, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
		base.ViewBag.Signature = list;
		if (sbj.Trim() != "")
		{
			emailSendViewModel.Subject = sbj;
		}
		bool flag = false;
		if (emailReceiveId > 0)
		{
			string pathFtp = Configuration.PathFtp;
			string userNameFtp = Configuration.UserNameFtp;
			string passwordFtp = Configuration.PasswordFtp;
			bool usePassiveFtp = Configuration.UsePassiveFtp;
			EmailspSelectEmailReceiveAndSendById_Result emailspSelectEmailReceiveAndSendById_Result = Enumerable.FirstOrDefault<EmailspSelectEmailReceiveAndSendById_Result>((IEnumerable<EmailspSelectEmailReceiveAndSendById_Result>)_dbII.EmailspSelectEmailReceiveAndSendById(receiveMode, emailReceiveId, lCID, result));
			if (emailspSelectEmailReceiveAndSendById_Result != null)
			{
				emailSendViewModel.PersonId = emailspSelectEmailReceiveAndSendById_Result.CompanyPersonId;
				emailSendViewModel.ProjectId = emailspSelectEmailReceiveAndSendById_Result.ProjectId;
				cmpId = emailspSelectEmailReceiveAndSendById_Result.CompanyId.GetValueOrDefault();
				emailSendViewModel.CompanyId = cmpId;
				base.ViewBag.EuFromUserId = emailspSelectEmailReceiveAndSendById_Result.ToUserEmailUserInfoId;
				emailSendViewModel.From = emailspSelectEmailReceiveAndSendById_Result.ToUserEmailUserInfoId;
				string text = "";
				string text2 = "";
				string text3 = "";
				if (!string.IsNullOrEmpty(emailspSelectEmailReceiveAndSendById_Result.ToUserEmail))
				{
					text3 = emailspSelectEmailReceiveAndSendById_Result.ToUserEmail;
					if (text3.IndexOf("(", StringComparison.Ordinal) >= 0)
					{
						text3 = text3.Substring(0, text3.IndexOf("(", StringComparison.Ordinal));
					}
					text3 = " <" + text3 + "> ";
				}
				if (!string.IsNullOrEmpty(emailspSelectEmailReceiveAndSendById_Result.FromUserEmail))
				{
					text = emailspSelectEmailReceiveAndSendById_Result.FromUserEmail;
					if (text.IndexOf("(", StringComparison.Ordinal) >= 0)
					{
						text = text.Substring(0, text.IndexOf("(", StringComparison.Ordinal));
					}
					text2 = emailspSelectEmailReceiveAndSendById_Result.FromUserEmail;
					text2 = text2.Replace('(', '<').Replace(')', '>');
				}
				type = "email";
				emailSendViewModel.Type = type;
				emailSendViewModel.ReciveEmails = text;
				string text4 = "";
				if (!string.IsNullOrEmpty(emailspSelectEmailReceiveAndSendById_Result.Subject))
				{
					emailspSelectEmailReceiveAndSendById_Result.Subject = emailspSelectEmailReceiveAndSendById_Result.Subject.Replace((!string.IsNullOrEmpty(modeInEuRec)) ? (modeInEuRec + ": ") : "", "");
					text4 = emailspSelectEmailReceiveAndSendById_Result.Subject;
				}
				emailSendViewModel.Subject = ((!string.IsNullOrEmpty(modeInEuRec)) ? (modeInEuRec + ": ") : "") + emailspSelectEmailReceiveAndSendById_Result.Subject;
				string text5 = "";
				if (modeInEuRec == "Re")
				{
					emailspSelectEmailReceiveAndSendById_Result.EmailDatePersian = (emailspSelectEmailReceiveAndSendById_Result.EmailDate.HasValue ? emailspSelectEmailReceiveAndSendById_Result.EmailDate.Value.ToString("ddd, MMM dd, yyyy", new CultureInfo("en-US")) : "") + " at " + (emailspSelectEmailReceiveAndSendById_Result.EmailDate.HasValue ? emailspSelectEmailReceiveAndSendById_Result.EmailDate.Value.ToString("hh:mm tt", new CultureInfo("en-US")) : "");
					text5 = "On " + emailspSelectEmailReceiveAndSendById_Result.EmailDatePersian + " " + text2 + " wrote:<br/>";
				}
				else if (modeInEuRec == "Fwd")
				{
					emailspSelectEmailReceiveAndSendById_Result.EmailDatePersian = (emailspSelectEmailReceiveAndSendById_Result.EmailDate.HasValue ? emailspSelectEmailReceiveAndSendById_Result.EmailDate.Value.ToString("ddd, MMM dd, yyyy", new CultureInfo("en-US")) : "") + " at " + (emailspSelectEmailReceiveAndSendById_Result.EmailDate.HasValue ? emailspSelectEmailReceiveAndSendById_Result.EmailDate.Value.ToString("hh:mm tt", new CultureInfo("en-US")) : "");
					text5 = "<br/> ---------- Forwarded message --------- <br/>From: " + text2 + "<br/>Date: " + emailspSelectEmailReceiveAndSendById_Result.EmailDatePersian + "<br/>Subject: " + text4 + "<br/>To: " + text3 + " <br/><br/><br/><br/>";
					type = "";
					emailSendViewModel.Type = type;
					emailSendViewModel.ReciveEmails = "";
					emailSendViewModel.PersonId = null;
					emailSendViewModel.ProjectId = null;
					cmpId = 0;
					emailSendViewModel.CompanyId = cmpId;
					switch (receiveMode)
					{
					case 1:
					{
						List<EmailspSelectEmailReceiveAttachments_Result> list3 = Enumerable.ToList<EmailspSelectEmailReceiveAttachments_Result>((IEnumerable<EmailspSelectEmailReceiveAttachments_Result>)_db.EmailspSelectEmailReceiveAttachments(0, emailspSelectEmailReceiveAndSendById_Result.EmailReceiveId, lCID, result));
						if (!Enumerable.Any<EmailspSelectEmailReceiveAttachments_Result>((IEnumerable<EmailspSelectEmailReceiveAttachments_Result>)list3))
						{
							break;
						}
						flag = true;
						string text12 = "";
						emailSendViewModel.EmailReceiveAttachsPath = "";
						foreach (EmailspSelectEmailReceiveAttachments_Result item in list3)
						{
							string text13 = item.SaveFilePath.ToLower().Replace(Configuration.PathFtp.ToLower(), "");
							string text14 = "";
							if (!(text13 != ""))
							{
								continue;
							}
							new FilesManager();
							string text15 = base.Server.MapPath(Configuration.HostTempFilesPath) + "\\Emails\\Files\\EmailRec\\" + emailspSelectEmailReceiveAndSendById_Result.EmailReceiveId;
							if (!System.IO.Directory.Exists(text15))
							{
								System.IO.Directory.CreateDirectory(text15);
								CRM.General.IO.Directory.SetFullControlForEveryOne(text15);
							}
							item.FileName = ((!string.IsNullOrEmpty(item.FileName)) ? item.FileName : (DateTime.Now.ToString("yyyyMMdd-HHmmss") + "." + item.FileType));
							if (System.IO.Directory.Exists(text15))
							{
								text14 = text15 + "\\" + item.FileName;
								if (new FacadeFTP(Configuration.FacadeFtp).Download(pathFtp, userNameFtp, passwordFtp, text14, text13, overwrite: true, usePassiveFtp))
								{
									text12 = text12 + item.FileName + "|";
									emailSendViewModel.EmailReceiveAttachsPath = emailSendViewModel.EmailReceiveAttachsPath + text14 + "|";
								}
							}
						}
						base.ViewBag.EmailReceiveAttachs = text12;
						break;
					}
					case 2:
					{
						List<EmailspSelectSendedAttachment_Result> list2 = Enumerable.ToList<EmailspSelectSendedAttachment_Result>((IEnumerable<EmailspSelectSendedAttachment_Result>)_dbII.EmailspSelectSendedAttachment(emailspSelectEmailReceiveAndSendById_Result.EmailSendHeaderId, 0));
						if (!Enumerable.Any<EmailspSelectSendedAttachment_Result>((IEnumerable<EmailspSelectSendedAttachment_Result>)list2))
						{
							break;
						}
						flag = true;
						string text6 = "";
						emailSendViewModel.EmailReceiveAttachsPath = "";
						EmailspSelectEmailSetting_Result emailspSelectEmailSetting_Result = Enumerable.FirstOrDefault<EmailspSelectEmailSetting_Result>((IEnumerable<EmailspSelectEmailSetting_Result>)_db.EmailspSelectEmailSetting("", ""));
						string oldValue = ((emailspSelectEmailSetting_Result.EmailsAttachFilePath == null) ? "" : (emailspSelectEmailSetting_Result.EmailsAttachFilePath + (emailspSelectEmailSetting_Result.EmailsAttachFilePath.EndsWith("\\") ? "" : "\\")));
						if (emailspSelectEmailSetting_Result.EmailsPDFBodyFilePathFtp != null)
						{
							_ = emailspSelectEmailSetting_Result.EmailsPDFBodyFilePathFtp + (emailspSelectEmailSetting_Result.EmailsPDFBodyFilePathFtp.EndsWith("/") ? "" : "/");
						}
						string text7 = ((emailspSelectEmailSetting_Result.EmailsAttachShareFilePathFtp == null) ? "" : (emailspSelectEmailSetting_Result.EmailsAttachShareFilePathFtp + (emailspSelectEmailSetting_Result.EmailsAttachShareFilePathFtp.EndsWith("/") ? "" : "/")));
						foreach (EmailspSelectSendedAttachment_Result item2 in list2)
						{
							string text8 = HostingEnvironment.MapPath(Configuration.HostTempFilesPath + "/Emails/SendFile");
							if (!System.IO.Directory.Exists(text8))
							{
								System.IO.Directory.CreateDirectory(text8);
								CRM.General.IO.Directory.SetFullControlForEveryOne(text8);
							}
							else
							{
								text8 = text8 + "/" + item2.EmailSendHeaderId;
								if (!System.IO.Directory.Exists(text8))
								{
									System.IO.Directory.CreateDirectory(text8);
									CRM.General.IO.Directory.SetFullControlForEveryOne(text8);
								}
							}
							FacadeFTP facadeFTP = new FacadeFTP(Configuration.FacadeFtp);
							string filePath = item2.FilePath;
							if (!string.IsNullOrWhiteSpace(filePath))
							{
								string[] array = item2.FileName.Split(new char[1] { '.' });
								string text9 = item2.FileName;
								string text10 = "";
								if (array != null)
								{
									text10 = array[^1];
									text9 = text9.Replace("." + text10, "");
								}
								item2.FileName = text9 + "-" + DateTime.Now.ToString("yyyyMMdd-HHmmss") + "." + text10;
								filePath = filePath.Replace(oldValue, "");
								string text11 = text8 + "/" + item2.FileName;
								string source = text7 + filePath;
								if (!System.IO.File.Exists(text11) && facadeFTP.Download(pathFtp, userNameFtp, passwordFtp, text11, source, overwrite: true, usePassiveFtp))
								{
									text6 = text6 + item2.FileName + "|";
									emailSendViewModel.EmailReceiveAttachsPath = emailSendViewModel.EmailReceiveAttachsPath + text11 + "|";
								}
							}
						}
						base.ViewBag.EmailReceiveAttachs = text6;
						break;
					}
					}
				}
				if (receiveMode == 2)
				{
					EmailspSelectEmailSetting_Result emailspSelectEmailSetting_Result2 = Enumerable.FirstOrDefault<EmailspSelectEmailSetting_Result>((IEnumerable<EmailspSelectEmailSetting_Result>)_db.EmailspSelectEmailSetting("", ""));
					string oldValue2 = ((emailspSelectEmailSetting_Result2.EmailsAttachFilePath == null) ? "" : (emailspSelectEmailSetting_Result2.EmailsAttachFilePath + (emailspSelectEmailSetting_Result2.EmailsAttachFilePath.EndsWith("\\") ? "" : "\\")));
					if (emailspSelectEmailSetting_Result2.EmailsPDFBodyFilePathFtp != null)
					{
						_ = emailspSelectEmailSetting_Result2.EmailsPDFBodyFilePathFtp + (emailspSelectEmailSetting_Result2.EmailsPDFBodyFilePathFtp.EndsWith("/") ? "" : "/");
					}
					string text16 = ((emailspSelectEmailSetting_Result2.EmailsAttachShareFilePathFtp == null) ? "" : (emailspSelectEmailSetting_Result2.EmailsAttachShareFilePathFtp + (emailspSelectEmailSetting_Result2.EmailsAttachShareFilePathFtp.EndsWith("/") ? "" : "/")));
					string text17 = HostingEnvironment.MapPath(Configuration.HostTempFilesPath + "/Emails/SendFile");
					string text18 = Configuration.HostTempFilesPath + "/Emails/SendFile";
					text18 = text18.Replace("~", "");
					if (!System.IO.Directory.Exists(text17))
					{
						System.IO.Directory.CreateDirectory(text17);
						CRM.General.IO.Directory.SetFullControlForEveryOne(text17);
					}
					else
					{
						text17 = text17 + "/" + emailspSelectEmailReceiveAndSendById_Result.EmailSendHeaderId;
						text18 = text18 + "/" + emailspSelectEmailReceiveAndSendById_Result.EmailSendHeaderId;
						if (!System.IO.Directory.Exists(text17))
						{
							System.IO.Directory.CreateDirectory(text17);
							CRM.General.IO.Directory.SetFullControlForEveryOne(text17);
						}
					}
					FacadeFTP facadeFTP2 = new FacadeFTP(Configuration.FacadeFtp);
					string cmpPattern = emailspSelectEmailSetting_Result2.CmpPattern;
					string cmpPrsPattern = emailspSelectEmailSetting_Result2.CmpPrsPattern;
					string cmpPrsJobPattern = emailspSelectEmailSetting_Result2.CmpPrsJobPattern;
					Dictionary<string, string> dictionary = new Dictionary<string, string>();
					string text19 = (emailspSelectEmailReceiveAndSendById_Result.HtmlBody ?? "").Replace(cmpPattern, emailspSelectEmailReceiveAndSendById_Result.CompanyName ?? "").Replace(cmpPrsPattern, emailspSelectEmailReceiveAndSendById_Result.PersonName ?? "").Replace(cmpPrsJobPattern, "") + "<p style='display:none;'>" + DateTime.Now.ToString("R") + "</p>";
					foreach (Match item3 in new Regex("[a-z]:\\\\(?:[^\\\\:]+\\\\)*((?:[^:\\\\]+)\\.\\w+)", (RegexOptions)1).Matches(text19))
					{
						Match val2 = item3;
						string text20 = System.Guid.NewGuid().ToString();
						text19 = text19.Replace(((Capture)val2).Value, "cid:" + text20);
						dictionary.Add(text20, ((Capture)val2).Value);
					}
					new BodyBuilder();
					emailspSelectEmailReceiveAndSendById_Result.HtmlBody = text19;
					if (dictionary != null)
					{
						foreach (string key in dictionary.Keys)
						{
							string text21 = dictionary[key];
							string value = "";
							string newValue = "";
							if (!string.IsNullOrWhiteSpace(text21))
							{
								text21 = text21.Replace(oldValue2, "");
								string text22 = text17 + "/" + text21;
								string source2 = text16 + text21;
								newValue = text18 + "/" + text21;
								if (!System.IO.File.Exists(text22))
								{
									if (facadeFTP2.Download(pathFtp, userNameFtp, passwordFtp, text22, source2, overwrite: true, usePassiveFtp))
									{
										value = text22;
									}
								}
								else
								{
									value = text22;
								}
							}
							if (!string.IsNullOrWhiteSpace(value))
							{
								text19 = text19.Replace("cid:" + key, newValue);
							}
						}
					}
					emailspSelectEmailReceiveAndSendById_Result.HtmlBody = text19;
				}
				emailSendViewModel.Body = "<br/><br/>" + text5 + emailspSelectEmailReceiveAndSendById_Result.HtmlBody;
				textBody = emailSendViewModel.Body;
			}
		}
		string text23 = "";
		string text24 = "";
		string text25 = "";
		if (file != "")
		{
			string text26 = "";
			string[] array2 = file.Split(new char[1] { '|' });
			string text27 = "";
			if (array2.Length == 2)
			{
				text27 = array2[1];
			}
			int result2 = 0;
			int.TryParse(array2[0], out result2);
			if (result2 > 0)
			{
				text26 = text27 switch
				{
					"pord" => "Pro_" + UserLogin.CurrentUser.UserId + "_" + result2, 
					"ord" => "Ord_" + UserLogin.CurrentUser.UserId + "_" + result2, 
					"SendLetter" => "SendLetter_" + UserLogin.CurrentUser.UserId + "_" + result2, 
					_ => "", 
				};
			}
			if (text26 != "")
			{
				text23 = text26 + ".pdf";
				if (System.IO.File.Exists(string.Concat(base.Server.MapPath(Configuration.HostTempFilesPath) + "\\Emails\\Files", "\\", text23)))
				{
					flag = true;
					text25 = Configuration.HostTempFilesPath + "/Emails/Files/" + text23;
					text25 = text25.Replace("~/", "/");
					text25 = (text25.StartsWith("/") ? text25 : ("/" + text25));
				}
			}
		}
		base.ViewBag.HaveFile = flag;
		base.ViewBag.PdfFileName = text23;
		base.ViewBag.ImgFileName = text24;
		base.ViewBag.PdfFilePath = text25;
		emailSendViewModel.CompanyId = cmpId;
		emailSendViewModel.HavePassword = hasPass;
		emailSendViewModel.Body = textBody.Replace("|", "<br>");
		base.ViewBag.IsBuying = VersionBuyer.Emails;
		return View(emailSendViewModel);
	}

	[ValidateAntiForgeryToken]
	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actemSendEmail")]
	public ActionResult Index(EmailSendViewModel model, HttpPostedFileBase[] files)
	{
		//IL_07d2: Unknown result type (might be due to invalid IL or missing references)
		string[] array = new string[5] { "", "", "", "", "" };
		base.ViewBag.From = LoadComboFrom();
		base.ViewBag.StyleDisplay = "none";
		base.ViewBag.Signature = new List<EmailUserDefaultSetting>();
		DbSet<EmailUserDefaultSetting> emailUserDefaultSetting = _dbTbl.EmailUserDefaultSetting;
		ParameterExpression val = Expression.Parameter(typeof(EmailUserDefaultSetting), "c");
		List<EmailUserDefaultSetting> list = Enumerable.ToList<EmailUserDefaultSetting>((IEnumerable<EmailUserDefaultSetting>)Queryable.Where<EmailUserDefaultSetting>((IQueryable<EmailUserDefaultSetting>)emailUserDefaultSetting, Expression.Lambda<Func<EmailUserDefaultSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Property((Expression)null, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
		base.ViewBag.Signature = list;
		if (model.Type == "tank")
		{
			base.ViewBag.StyleDisplay = "";
		}
		if (!VersionBuyer.Emails)
		{
			string text = model.ToEmails;
			if (model.ToEmails.EndsWith("|"))
			{
				text = text.Substring(0, text.Length - 1);
			}
			string[] array2 = text.Split(new char[1] { '|' });
			DbSet<EmailSendDetail> emailSendDetail = _dbTbl.EmailSendDetail;
			val = Expression.Parameter(typeof(EmailSendDetail), "c");
			if (Queryable.Any<EmailSendDetail>((IQueryable<EmailSendDetail>)emailSendDetail, Expression.Lambda<Func<EmailSendDetail, bool>>((Expression)(object)Expression.GreaterThan((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)10, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val })))
			{
				base.ModelState.AddModelError("error", Messages.VersionBuy);
				return View(model);
			}
			DbSet<EmailSendDetail> emailSendDetail2 = _dbTbl.EmailSendDetail;
			val = Expression.Parameter(typeof(EmailSendDetail), "c");
			EmailSendDetail emailSendDetail3 = Queryable.LastOrDefault<EmailSendDetail>((IQueryable<EmailSendDetail>)(object)Queryable.OrderBy<EmailSendDetail, int>((IQueryable<EmailSendDetail>)emailSendDetail2, Expression.Lambda<Func<EmailSendDetail, int>>((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
			if (emailSendDetail3 != null)
			{
				int emailSendDetailId = emailSendDetail3.EmailSendDetailId;
				if (array2.Length - emailSendDetailId > 10)
				{
					base.ModelState.AddModelError("error", Messages.VersionBuy);
					return View(model);
				}
			}
		}
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			if (base.ModelState.IsValid)
			{
				int result2 = 0;
				long result3 = 0L;
				List<EmailspSelectEmailUserTempTankWithUserId_Result> list2 = new List<EmailspSelectEmailUserTempTankWithUserId_Result>();
				if (model != null)
				{
					int.TryParse(model.EmailSystemPartId.ToString(), out result2);
					long.TryParse(model.EmailObjectId.ToString(), out result3);
				}
				if (result2 != 0 && result3 != 0L)
				{
					list2 = Enumerable.ToList<EmailspSelectEmailUserTempTankWithUserId_Result>((IEnumerable<EmailspSelectEmailUserTempTankWithUserId_Result>)_dbI.EmailspSelectEmailUserTempTankWithUserId(UserLogin.CurrentUser.UserId, result2, result3));
				}
				if (model.HavePassword.HasValue && model.CompanyId.HasValue && model.HavePassword.Value && !string.IsNullOrWhiteSpace(model.Body))
				{
					CRMspSelectCompanyById_Result companyById = CRMIdeal.Classes.Helper.Company.GetCompanyById(model.CompanyId.GetValueOrDefault());
					if (companyById != null && !string.IsNullOrWhiteSpace(companyById.cmpPassword))
					{
						string newValue = XorCipher.DecryptByPublicKey(companyById.cmpPassword);
						model.Body = model.Body.Replace("[******]", newValue);
					}
				}
				EmailSetting emailSetting = _dbTbl.EmailSetting.Find(model.SettingId);
				if (emailSetting != null)
				{
					EmailSendHeader emailSendHeader = new EmailSendHeader
					{
						Body = "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" /> <div dir=\"rtl\">" + model.Body + "</div>",
						RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture()),
						RegisterDate = now,
						UserId = UserLogin.CurrentUser.UserId,
						EndDatePersian = null,
						EndDateTime = null,
						PriorityId = model.Priority,
						StartDatePersian = model.SendingDate.ToString("yyyyMMdd", new PersianCulture()),
						StartDateTime = model.SendingDate,
						Subject = model.Subject,
						EmailUsersInfoId = model.From,
						EmailSettingId = model.SettingId,
						AppType = Configuration.AppType,
						GUId = System.Guid.NewGuid(),
						LanguageID = result,
						FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture()),
						FirstRegisterDate = now,
						FirstRegisterUserId = UserLogin.CurrentUser.UserId
					};
					try
					{
						_dbTbl.EmailSendHeader.Add(emailSendHeader);
						_dbTbl.SaveChanges();
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
						base.ModelState.AddModelError("error", Messages.EmailSendingErrorInSaveHeader);
						return View(model);
					}
					if (emailSendHeader.EmailSendHeaderId > 0)
					{
						string text2 = ((emailSetting.EmailsAttachFilePath == null) ? "" : (emailSetting.EmailsAttachFilePath + (emailSetting.EmailsAttachFilePath.EndsWith("\\") ? "" : "\\")));
						string text3 = ((emailSetting.EmailsPDFBodyFilePathFtp == null) ? "" : (emailSetting.EmailsPDFBodyFilePathFtp + (emailSetting.EmailsPDFBodyFilePathFtp.EndsWith("/") ? "" : "/")));
						if (emailSetting.EmailsAttachShareFilePathFtp != null)
						{
							_ = emailSetting.EmailsAttachShareFilePathFtp + (emailSetting.EmailsAttachShareFilePathFtp.EndsWith("/") ? "" : "/");
						}
						List<string> list3 = new List<string>();
						foreach (Match item in Regex.Matches(emailSendHeader.Body, "<img.+?src=[\"'](.+?)[\"'].+?>", (RegexOptions)3))
						{
							string value = ((Capture)item.Groups[1]).Value;
							if (!list3.Contains(value))
							{
								list3.Add(value);
							}
						}
						if (model.IsNeedPdf)
						{
							string text4 = model.Body;
							foreach (string item2 in list3)
							{
								string newValue2 = base.Server.MapPath(item2);
								text4 = text4.Replace(item2, newValue2);
							}
							string text5 = emailSendHeader.EmailSendHeaderId + ".pdf";
							byte[] buffer = new HtmlToPdfConverter().GeneratePdf("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" /> <div dir=\"rtl\">" + text4 + "</div>");
							FTPclient fTPclient = new FTPclient(Configuration.PathFtp, Configuration.UserNameFtp, Configuration.PasswordFtp, Configuration.UsePassiveFtp);
							Stream sourceStream = new MemoryStream(buffer);
							if (!fTPclient.Upload(sourceStream, text3 + text5))
							{
								base.ModelState.AddModelError("error", Messages.EmailSendingErrorInSavePdf);
								try
								{
									_dbTbl.EmailSendHeader.Remove(emailSendHeader);
									_dbTbl.SaveChanges();
								}
								catch (DbEntityValidationException e2)
								{
									ErrorSignal.FromCurrentContext().Raise((Exception)(object)e2);
								}
								catch (Exception e3)
								{
									ErrorSignal.FromCurrentContext().Raise(e3);
								}
								return View(model);
							}
						}
						if (list3.Count > 0)
						{
							try
							{
								string text6 = emailSendHeader.Body;
								foreach (string item3 in list3)
								{
									string text7 = item3.Replace("%2F", "/").Replace("%20", " ");
									if (text7.IndexOf("http://", StringComparison.Ordinal) >= 0 || text7.IndexOf("https://", StringComparison.Ordinal) >= 0)
									{
										continue;
									}
									string text8 = base.Server.MapPath(text7);
									string[] array3 = text8.Split(new char[1] { '.' });
									RandomText randomText = new RandomText();
									string text9 = emailSendHeader.EmailSendHeaderId + "-" + randomText.CreateRandomCode(5, WithNumber: true, false).Replace(" ", "").Trim() + "-" + DateTime.Now.ToString("yyyyMMdd") + "-" + DateTime.Now.ToString("HHmmss") + "." + array3[^1];
									string newValue3 = text2 + text9;
									if (!new FTPclient(Configuration.PathFtp, Configuration.UserNameFtp, Configuration.PasswordFtp, Configuration.UsePassiveFtp).Upload(text8, emailSetting.EmailsAttachShareFilePathFtp + text9))
									{
										base.ModelState.AddModelError("error", Messages.EmailSendingErrorInSaveImage);
										try
										{
											_dbTbl.EmailSendHeader.Remove(emailSendHeader);
											_dbTbl.SaveChanges();
										}
										catch (DbEntityValidationException e4)
										{
											ErrorSignal.FromCurrentContext().Raise((Exception)(object)e4);
										}
										catch (Exception e5)
										{
											ErrorSignal.FromCurrentContext().Raise(e5);
										}
										return View(model);
									}
									text6 = text6.Replace(item3, newValue3);
								}
								emailSendHeader.Body = text6;
								emailSendHeader.StartDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
								emailSendHeader.StartDateTime = now;
								emailSendHeader.AppType = Configuration.AppType;
								_dbTbl.Entry(emailSendHeader).State = EntityState.Modified;
								_dbTbl.SaveChanges();
							}
							catch (Exception e6)
							{
								ErrorSignal.FromCurrentContext().Raise(e6);
								base.ModelState.AddModelError("error", Messages.EmailSendingErrorInSaveImage);
								try
								{
									_dbTbl.EmailSendHeader.Remove(emailSendHeader);
									_dbTbl.SaveChanges();
								}
								catch (DbEntityValidationException e7)
								{
									ErrorSignal.FromCurrentContext().Raise((Exception)(object)e7);
								}
								catch (Exception e8)
								{
									ErrorSignal.FromCurrentContext().Raise(e8);
								}
								return View(model);
							}
						}
						EmailspSelectEmailUserTempTankWithUserId_Result emailspSelectEmailUserTempTankWithUserId_Result = new EmailspSelectEmailUserTempTankWithUserId_Result();
						if (list2 != null && Enumerable.Any<EmailspSelectEmailUserTempTankWithUserId_Result>((IEnumerable<EmailspSelectEmailUserTempTankWithUserId_Result>)list2))
						{
							emailspSelectEmailUserTempTankWithUserId_Result = Enumerable.FirstOrDefault<EmailspSelectEmailUserTempTankWithUserId_Result>((IEnumerable<EmailspSelectEmailUserTempTankWithUserId_Result>)list2);
							if (emailspSelectEmailUserTempTankWithUserId_Result == null)
							{
								emailspSelectEmailUserTempTankWithUserId_Result = new EmailspSelectEmailUserTempTankWithUserId_Result();
							}
						}
						string[] array4;
						if (emailspSelectEmailUserTempTankWithUserId_Result != null)
						{
							int num = 0;
							if (!string.IsNullOrEmpty(emailspSelectEmailUserTempTankWithUserId_Result.FilePath))
							{
								array[num] = emailspSelectEmailUserTempTankWithUserId_Result.FilePath.Trim();
								num++;
							}
							if (!string.IsNullOrEmpty(emailspSelectEmailUserTempTankWithUserId_Result.FilePathII))
							{
								array[num] = emailspSelectEmailUserTempTankWithUserId_Result.FilePathII.Trim();
								num++;
							}
							if (!string.IsNullOrEmpty(emailspSelectEmailUserTempTankWithUserId_Result.FilePathIII))
							{
								array[num] = emailspSelectEmailUserTempTankWithUserId_Result.FilePathIII.Trim();
								num++;
							}
							if (!string.IsNullOrEmpty(emailspSelectEmailUserTempTankWithUserId_Result.FilePathIV))
							{
								array[num] = emailspSelectEmailUserTempTankWithUserId_Result.FilePathIV.Trim();
								num++;
							}
							if (!string.IsNullOrEmpty(emailspSelectEmailUserTempTankWithUserId_Result.FilePathV))
							{
								array[num] = emailspSelectEmailUserTempTankWithUserId_Result.FilePathV.Trim();
							}
							array4 = array;
							foreach (string text10 in array4)
							{
								if (!(text10.Trim() != ""))
								{
									continue;
								}
								try
								{
									string text11 = new FileInfo(text10).Extension.Replace(".", "");
									RandomText randomText2 = new RandomText();
									string text12 = emailSendHeader.EmailSendHeaderId + "-" + randomText2.CreateRandomCode(5, WithNumber: true, false).Replace(" ", "").Trim() + "-" + DateTime.Now.ToString("yyyyMMdd") + "-" + DateTime.Now.ToString("HHmmss") + "." + text11.Replace(".", "");
									string filePath = text2 + text12;
									FTPclient fTPclient2 = new FTPclient(Configuration.PathFtp, Configuration.UserNameFtp, Configuration.PasswordFtp, Configuration.UsePassiveFtp);
									FileStream fileStream = new FileStream(text10, FileMode.Open);
									if (!fTPclient2.Upload(fileStream, emailSetting.EmailsAttachShareFilePathFtp + text12))
									{
										base.ModelState.AddModelError("error", Messages.EmailSendingErrorInFindingTank);
										try
										{
											_dbTbl.EmailSendHeader.Remove(emailSendHeader);
											_dbTbl.SaveChanges();
										}
										catch (DbEntityValidationException e9)
										{
											ErrorSignal.FromCurrentContext().Raise((Exception)(object)e9);
										}
										catch (Exception e10)
										{
											ErrorSignal.FromCurrentContext().Raise(e10);
										}
										return View(model);
									}
									EmailSendAttachment entity = new EmailSendAttachment
									{
										EmailSendHeaderId = emailSendHeader.EmailSendHeaderId,
										FileName = text12,
										FilePath = filePath,
										RegisterDate = now,
										RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture()),
										AppType = Configuration.AppType,
										GUId = System.Guid.NewGuid(),
										FirstRegisterDate = now,
										FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture()),
										FirstRegisterUserId = UserLogin.CurrentUser.UserId,
										LanguageID = result
									};
									_dbTbl.EmailSendAttachment.Add(entity);
									_dbTbl.SaveChanges();
									fileStream.Dispose();
								}
								catch (Exception e11)
								{
									ErrorSignal.FromCurrentContext().Raise(e11);
									base.ModelState.AddModelError("error", Messages.EmailSendingErrorInFindingTank);
									try
									{
										_dbTbl.EmailSendHeader.Remove(emailSendHeader);
										_dbTbl.SaveChanges();
									}
									catch (DbEntityValidationException e12)
									{
										ErrorSignal.FromCurrentContext().Raise((Exception)(object)e12);
									}
									catch (Exception e13)
									{
										ErrorSignal.FromCurrentContext().Raise(e13);
									}
									return View(model);
								}
							}
						}
						if (!string.IsNullOrEmpty(model.EmailReceiveAttachsPath))
						{
							string[] array5 = model.EmailReceiveAttachsPath.Split(new char[1] { '|' });
							if (array5 != null)
							{
								array4 = array5;
								foreach (string text13 in array4)
								{
									if (string.IsNullOrEmpty(text13) || !(text13.Trim() != ""))
									{
										continue;
									}
									try
									{
										string text14 = new FileInfo(text13).Extension.Replace(".", "");
										RandomText randomText3 = new RandomText();
										string text15 = emailSendHeader.EmailSendHeaderId + "-" + randomText3.CreateRandomCode(5, WithNumber: true, false).Replace(" ", "").Trim() + "-" + DateTime.Now.ToString("yyyyMMdd") + "-" + DateTime.Now.ToString("HHmmss") + "." + text14.Replace(".", "");
										string filePath2 = text2 + text15;
										FTPclient fTPclient3 = new FTPclient(Configuration.PathFtp, Configuration.UserNameFtp, Configuration.PasswordFtp, Configuration.UsePassiveFtp);
										FileStream fileStream2 = new FileStream(text13, FileMode.Open);
										if (!fTPclient3.Upload(fileStream2, emailSetting.EmailsAttachShareFilePathFtp + text15))
										{
											base.ModelState.AddModelError("error", Messages.EmailSendingErrorInFindingTank);
											try
											{
												_dbTbl.EmailSendHeader.Remove(emailSendHeader);
												_dbTbl.SaveChanges();
											}
											catch (DbEntityValidationException e14)
											{
												ErrorSignal.FromCurrentContext().Raise((Exception)(object)e14);
											}
											catch (Exception e15)
											{
												ErrorSignal.FromCurrentContext().Raise(e15);
											}
											return View(model);
										}
										EmailSendAttachment entity2 = new EmailSendAttachment
										{
											EmailSendHeaderId = emailSendHeader.EmailSendHeaderId,
											FileName = text15,
											FilePath = filePath2,
											RegisterDate = now,
											RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture()),
											AppType = Configuration.AppType,
											GUId = System.Guid.NewGuid(),
											FirstRegisterDate = now,
											FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture()),
											FirstRegisterUserId = UserLogin.CurrentUser.UserId,
											LanguageID = result
										};
										_dbTbl.EmailSendAttachment.Add(entity2);
										_dbTbl.SaveChanges();
										fileStream2.Dispose();
									}
									catch (Exception e16)
									{
										ErrorSignal.FromCurrentContext().Raise(e16);
										base.ModelState.AddModelError("error", Messages.EmailSendingErrorInFindingTank);
										try
										{
											_dbTbl.EmailSendHeader.Remove(emailSendHeader);
											_dbTbl.SaveChanges();
										}
										catch (DbEntityValidationException e17)
										{
											ErrorSignal.FromCurrentContext().Raise((Exception)(object)e17);
										}
										catch (Exception e18)
										{
											ErrorSignal.FromCurrentContext().Raise(e18);
										}
										return View(model);
									}
								}
							}
						}
						if (files != null)
						{
							foreach (HttpPostedFileBase val2 in files)
							{
								try
								{
									val2.ContentType.ToLower();
									string text16 = Path.GetExtension(val2.FileName).ToLower();
									RandomText randomText4 = new RandomText();
									string text17 = emailSendHeader.EmailSendHeaderId + "-" + randomText4.CreateRandomCode(5, WithNumber: true, false).Replace(" ", "").Trim() + "-" + DateTime.Now.ToString("yyyyMMdd") + "-" + DateTime.Now.ToString("HHmmss") + "." + text16.Replace(".", "");
									string filePath3 = text2 + text17;
									if (!new FTPclient(Configuration.PathFtp, Configuration.UserNameFtp, Configuration.PasswordFtp, Configuration.UsePassiveFtp).Upload(val2.InputStream, emailSetting.EmailsAttachShareFilePathFtp + text17))
									{
										base.ModelState.AddModelError("error", Messages.EmailSendingErrorInFindingTank);
										try
										{
											_dbTbl.EmailSendHeader.Remove(emailSendHeader);
											_dbTbl.SaveChanges();
										}
										catch (DbEntityValidationException e19)
										{
											ErrorSignal.FromCurrentContext().Raise((Exception)(object)e19);
										}
										catch (Exception e20)
										{
											ErrorSignal.FromCurrentContext().Raise(e20);
										}
										return View(model);
									}
									EmailSendAttachment entity3 = new EmailSendAttachment
									{
										EmailSendHeaderId = emailSendHeader.EmailSendHeaderId,
										FileName = text17,
										FilePath = filePath3,
										RegisterDate = now,
										RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture()),
										AppType = Configuration.AppType,
										GUId = System.Guid.NewGuid(),
										FirstRegisterDate = now,
										FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture()),
										FirstRegisterUserId = UserLogin.CurrentUser.UserId,
										LanguageID = result
									};
									_dbTbl.EmailSendAttachment.Add(entity3);
									_dbTbl.SaveChanges();
								}
								catch (Exception e21)
								{
									ErrorSignal.FromCurrentContext().Raise(e21);
									base.ModelState.AddModelError("error", Messages.EmailSendingErrorInFindingTank);
									try
									{
										_dbTbl.EmailSendHeader.Remove(emailSendHeader);
										_dbTbl.SaveChanges();
									}
									catch (DbEntityValidationException e22)
									{
										ErrorSignal.FromCurrentContext().Raise((Exception)(object)e22);
									}
									catch (Exception e23)
									{
										ErrorSignal.FromCurrentContext().Raise(e23);
									}
									return View(model);
								}
							}
						}
						string[] array6 = model.ToEmails.Split(new char[1] { '|' });
						DateTime now2 = DateTime.Now;
						DateTime value2 = now2;
						string text18 = now2.ToString("yyyyMMdd", new PersianCulture());
						short.Parse(now2.ToString("MM", new PersianCulture()));
						string appType = Configuration.AppType;
						short.Parse(Financial.Get().Id.ToString());
						int userId = UserLogin.CurrentUser.UserId;
						int result4 = 0;
						if (array6 != null && Enumerable.Any<string>((IEnumerable<string>)array6))
						{
							int.TryParse(array6[0], out result4);
						}
						if (result4 <= 0)
						{
							List<EmailSendJsonViewModel> list4 = new List<EmailSendJsonViewModel>();
							if (array6 != null && Enumerable.Any<string>((IEnumerable<string>)array6))
							{
								array4 = array6;
								for (int i = 0; i < array4.Length; i++)
								{
									string text19 = array4[i].Trim();
									if (string.IsNullOrWhiteSpace(text19))
									{
										continue;
									}
									if (Regex.IsMatch(text19, "\\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\\Z", (RegexOptions)1))
									{
										EmailSendJsonViewModel emailSendJsonViewModel = new EmailSendJsonViewModel
										{
											EmailAddress = text19,
											EmailCmpId = null,
											EmailCmpPrjId = null,
											EmailCmpPrsId = null
										};
										if (model.CompanyId.HasValue && model.CompanyId > 0)
										{
											emailSendJsonViewModel.EmailCmpId = model.CompanyId;
										}
										if (model.ProjectId.HasValue && model.ProjectId > 0)
										{
											emailSendJsonViewModel.EmailCmpPrjId = model.ProjectId;
										}
										if (model.PersonId.HasValue && model.PersonId > 0)
										{
											emailSendJsonViewModel.EmailCmpPrsId = model.PersonId;
										}
										list4.Add(emailSendJsonViewModel);
										continue;
									}
									base.ModelState.AddModelError("error", Messages.EmailFormatError);
									try
									{
										_dbTbl.EmailSendHeader.Remove(emailSendHeader);
										_dbTbl.SaveChanges();
									}
									catch (DbEntityValidationException e24)
									{
										ErrorSignal.FromCurrentContext().Raise((Exception)(object)e24);
									}
									catch (Exception e25)
									{
										ErrorSignal.FromCurrentContext().Raise(e25);
									}
									return View(model);
								}
								if (list4 != null && Enumerable.Any<EmailSendJsonViewModel>((IEnumerable<EmailSendJsonViewModel>)list4))
								{
									string emailAddress = JsonConvert.SerializeObject(Enumerable.ToList<EmailSendJsonViewModel>((IEnumerable<EmailSendJsonViewModel>)list4));
									try
									{
										_dbI.EmailspInsertEmailSendDetailWeb(emailSendHeader.EmailSendHeaderId, emailAddress, model.CompanyId, model.PersonId, model.ProjectId, "", "", "", value2, text18, null, null, 0, userId, value2, text18, appType, result, false, "", (result2 != 0) ? new int?(result2) : null, (result3 != 0L) ? new long?(result3) : null, null, null);
									}
									catch (Exception e26)
									{
										ErrorSignal.FromCurrentContext().Raise(e26);
										base.ModelState.AddModelError("error", Messages.EmailSendingErrorInSaveDetails);
										try
										{
											_dbTbl.EmailSendHeader.Remove(emailSendHeader);
											_dbTbl.SaveChanges();
										}
										catch (DbEntityValidationException e27)
										{
											ErrorSignal.FromCurrentContext().Raise((Exception)(object)e27);
										}
										catch (Exception e28)
										{
											ErrorSignal.FromCurrentContext().Raise(e28);
										}
										return View(model);
									}
								}
							}
						}
						else
						{
							try
							{
								_dbI.EmailspInsertEmailSendDetailWeb(emailSendHeader.EmailSendHeaderId, "", model.CompanyId, model.PersonId, model.ProjectId, "", "", "", value2, text18, null, null, 0, userId, value2, text18, appType, result, true, model.ToEmails, (result2 != 0) ? new int?(result2) : null, (result3 != 0L) ? new long?(result3) : null, null, null);
							}
							catch (Exception e29)
							{
								ErrorSignal.FromCurrentContext().Raise(e29);
								base.ModelState.AddModelError("error", Messages.EmailSendingErrorInSaveDetails);
								try
								{
									_dbTbl.EmailSendHeader.Remove(emailSendHeader);
									_dbTbl.SaveChanges();
								}
								catch (DbEntityValidationException e30)
								{
									ErrorSignal.FromCurrentContext().Raise((Exception)(object)e30);
								}
								catch (Exception e31)
								{
									ErrorSignal.FromCurrentContext().Raise(e31);
								}
								return View(model);
							}
						}
						int settingId = model.SettingId;
						model = new EmailSendViewModel();
						model.SendingDate = DateTime.Now;
						model.SettingId = settingId;
						model.Type = "normal";
						base.ModelState.AddModelError("success", Messages.EmailSendingSuccessfully);
						base.ViewBag.StyleDisplay = "none";
						array4 = array;
						foreach (string text20 in array4)
						{
							if (text20.Trim() != "")
							{
								try
								{
									System.IO.File.Delete(text20);
								}
								catch (Exception e32)
								{
									ErrorSignal.FromCurrentContext().Raise(e32);
								}
							}
						}
						model.EmailReceiveAttachsPath = "";
					}
				}
				else
				{
					base.ModelState.AddModelError("error", Messages.EmailSendingErrorInFindSetting);
				}
			}
		}
		catch (Exception e33)
		{
			ErrorSignal.FromCurrentContext().Raise(e33);
			base.ModelState.AddModelError("error", Messages.EmailSendingErrorInSending);
		}
		return View(model);
	}

	[AjaxOnly]
	public JsonResult LoadEmailUserTempTank(int userId, int emailSystemPartId = 0, long emailObjectId = 0L)
	{
		List<EmailTempTankSampleViewModel> data = new List<EmailTempTankSampleViewModel>();
		try
		{
			List<EmailspSelectEmailUserTempTankWithUserId_Result> list = Enumerable.ToList<EmailspSelectEmailUserTempTankWithUserId_Result>((IEnumerable<EmailspSelectEmailUserTempTankWithUserId_Result>)_dbI.EmailspSelectEmailUserTempTankWithUserId(userId, emailSystemPartId, emailObjectId));
			if (list != null && Enumerable.Any<EmailspSelectEmailUserTempTankWithUserId_Result>((IEnumerable<EmailspSelectEmailUserTempTankWithUserId_Result>)list))
			{
				data = Enumerable.ToList<EmailTempTankSampleViewModel>(Enumerable.Select<EmailspSelectEmailUserTempTankWithUserId_Result, EmailTempTankSampleViewModel>(Enumerable.Where<EmailspSelectEmailUserTempTankWithUserId_Result>((IEnumerable<EmailspSelectEmailUserTempTankWithUserId_Result>)list, (Func<EmailspSelectEmailUserTempTankWithUserId_Result, bool>)((EmailspSelectEmailUserTempTankWithUserId_Result item) => Regex.IsMatch(item.EmailAddress, "\\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\\Z", (RegexOptions)1))), (Func<EmailspSelectEmailUserTempTankWithUserId_Result, EmailTempTankSampleViewModel>)((EmailspSelectEmailUserTempTankWithUserId_Result item) => new EmailTempTankSampleViewModel
				{
					EmailAddress = item.EmailAddress.Replace("&#160;", "").Trim(),
					EmailUserTempTankId = item.EmailUserTempTankId,
					EmailCmpPrsName = item.EmailCmpPrsName
				})));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	private List<SelectListItem> LoadComboFrom()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			List<EmailspSelectActiveEmailUsersInfoByUserId_Result> list2 = Enumerable.ToList<EmailspSelectActiveEmailUsersInfoByUserId_Result>((IEnumerable<EmailspSelectActiveEmailUsersInfoByUserId_Result>)_db.EmailspSelectActiveEmailUsersInfoByUserId(UserLogin.CurrentUser.UserId));
			bool selected = true;
			if (list2.Count > 1)
			{
				list.Add(new SelectListItem
				{
					Text = Labels.DropDownListSelectText,
					Value = "",
					Selected = true
				});
				selected = false;
			}
			list.AddRange(Enumerable.Select<EmailspSelectActiveEmailUsersInfoByUserId_Result, SelectListItem>((IEnumerable<EmailspSelectActiveEmailUsersInfoByUserId_Result>)list2, (Func<EmailspSelectActiveEmailUsersInfoByUserId_Result, SelectListItem>)((EmailspSelectActiveEmailUsersInfoByUserId_Result info) => new SelectListItem
			{
				Text = info.euNikeName + "  [ " + info.euNikeEmail + " ]",
				Value = info.EmailUsersInfoId.ToString(),
				Selected = selected
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	[DynamicAuthorize(ControllerName = "frmCompanyReport", ActionName = "actGetEmail")]
	public ActionResult EmailLoadAndCheck()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int result2 = 0;
		int result3 = 0;
		int result4 = 0;
		try
		{
			DateTime now = DateTime.Now;
			int num = 180;
			long num2 = long.Parse(now.ToString("yyyyMMddHHmmss", new CultureInfo("en-US")));
			base.ViewBag.EmailSystemPartId = num;
			base.ViewBag.EmailObjectId = num2;
			DateTime now2 = DateTime.Now;
			DateTime value = now2;
			string registerDatePersian = now2.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(now2.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			short.Parse(Financial.Get().Id.ToString());
			int userId = UserLogin.CurrentUser.UserId;
			_dbII.CRMspFillTempEmailsFromCmpFilterWeb(userId, num, num2, appType, lCID, result);
			_dbII.EmailspInsertEmailUserTempTankBycmpFilterWeb(userId, num, num2, value, registerDatePersian, appType, result);
			CRMspReturnTotalCountUserTempEmailInMode_Result cRMspReturnTotalCountUserTempEmailInMode_Result = Enumerable.FirstOrDefault<CRMspReturnTotalCountUserTempEmailInMode_Result>((IEnumerable<CRMspReturnTotalCountUserTempEmailInMode_Result>)_dbII.CRMspReturnTotalCountUserTempEmailInMode(userId, num, num2));
			if (cRMspReturnTotalCountUserTempEmailInMode_Result != null)
			{
				int.TryParse(cRMspReturnTotalCountUserTempEmailInMode_Result.EmailTotalCount.ToString(), out result2);
				int.TryParse(cRMspReturnTotalCountUserTempEmailInMode_Result.EmailCorrectTotalCount.ToString(), out result3);
				int.TryParse(cRMspReturnTotalCountUserTempEmailInMode_Result.EmailNotCorrectTotalCount.ToString(), out result4);
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
		base.ViewBag.filterAll = result2;
		base.ViewBag.filterCorrect = result3;
		base.ViewBag.filterNotCrrect = result4;
		return View();
	}

	[AjaxOnly]
	public ActionResult _PartialEmailLoadAndCheck(int mode, int emailSystemPartId = 0, long emailObjectId = 0L)
	{
		base.ViewBag.mode = mode;
		base.ViewBag.EmailSystemPartId = emailSystemPartId;
		base.ViewBag.EmailObjectId = emailObjectId;
		return PartialView();
	}

	public ActionResult GetEmail_Read([DataSourceRequest] DataSourceRequest request, int mode, int emailSystemPartId = 0, long emailObjectId = 0L)
	{
		List<EmailSelectUserTempViewModel> list = new List<EmailSelectUserTempViewModel>();
		try
		{
			List<CRMspSelectUserTempEmailInModeWeb_Result> list2 = Enumerable.ToList<CRMspSelectUserTempEmailInModeWeb_Result>((IEnumerable<CRMspSelectUserTempEmailInModeWeb_Result>)_dbII.CRMspSelectUserTempEmailInModeWeb(UserLogin.CurrentUser.UserId, mode, emailSystemPartId, emailObjectId));
			if (list2 != null && Enumerable.Any<CRMspSelectUserTempEmailInModeWeb_Result>((IEnumerable<CRMspSelectUserTempEmailInModeWeb_Result>)list2))
			{
				list = Enumerable.ToList<EmailSelectUserTempViewModel>(Enumerable.Select<CRMspSelectUserTempEmailInModeWeb_Result, EmailSelectUserTempViewModel>((IEnumerable<CRMspSelectUserTempEmailInModeWeb_Result>)list2, (Func<CRMspSelectUserTempEmailInModeWeb_Result, EmailSelectUserTempViewModel>)((CRMspSelectUserTempEmailInModeWeb_Result item) => new EmailSelectUserTempViewModel
				{
					ID = item.ID,
					Selector = item.Selector,
					CompanyName = item.CompanyName,
					PersonName = item.PersonName,
					CompanyId = item.CompanyId,
					CompanyPersonId = item.CompanyPersonId,
					EmailAddress = item.Email
				})));
			}
			if (list == null)
			{
				list = new List<EmailSelectUserTempViewModel>();
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
	public JsonResult GetAllEmail(int mode, int emailSystemPartId = 0, long emailObjectId = 0L)
	{
		try
		{
			List<string> data = Enumerable.ToList<string>(Enumerable.Select<CRMspSelectUserTempEmailInModeWeb_Result, string>((IEnumerable<CRMspSelectUserTempEmailInModeWeb_Result>)Enumerable.ToList<CRMspSelectUserTempEmailInModeWeb_Result>(Enumerable.Where<CRMspSelectUserTempEmailInModeWeb_Result>((IEnumerable<CRMspSelectUserTempEmailInModeWeb_Result>)_dbII.CRMspSelectUserTempEmailInModeWeb(UserLogin.CurrentUser.UserId, mode, emailSystemPartId, emailObjectId), (Func<CRMspSelectUserTempEmailInModeWeb_Result, bool>)((CRMspSelectUserTempEmailInModeWeb_Result c) => c.Selector))), (Func<CRMspSelectUserTempEmailInModeWeb_Result, string>)((CRMspSelectUserTempEmailInModeWeb_Result item) => item.Email)));
			JsonResult jsonResult = Json(data, JsonRequestBehavior.AllowGet);
			jsonResult.MaxJsonLength = int.MaxValue;
			return jsonResult;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return null;
		}
	}

	[AjaxOnly]
	public string InsertEmailUserTempTank(int mode, int emailSystemPartId = 0, long emailObjectId = 0L)
	{
		string result = "1";
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		if (result2 <= 0)
		{
			result2 = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			int userId = UserLogin.CurrentUser.UserId;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			short.Parse(Financial.Get().Id.ToString());
			Enumerable.ToList<CRMspSelectUserTempEmailForGenerateWeb_Result>((IEnumerable<CRMspSelectUserTempEmailForGenerateWeb_Result>)_dbII.CRMspSelectUserTempEmailForGenerateWeb(userId, mode, emailSystemPartId, emailObjectId));
			_dbII.EmailspInsertEmailUserTempTankBycmpFilterWeb(userId, emailSystemPartId, emailObjectId, value, registerDatePersian, appType, result2);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = Messages.frmErrorMessage;
		}
		return result;
	}

	[AjaxOnly]
	public string SelOrDeSelMobNum(int lstId, bool selectItem)
	{
		string result = "0";
		try
		{
			if (lstId != 0)
			{
				CrmTempEmails crmTempEmails = _dbTbl.CrmTempEmails.Find(lstId);
				if (crmTempEmails != null)
				{
					crmTempEmails.Selector = selectItem;
					crmTempEmails.AppType = Configuration.AppType;
					_dbTbl.Entry(crmTempEmails).State = EntityState.Modified;
					_dbTbl.SaveChanges();
				}
				result = ((!selectItem) ? "-1" : "1");
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public ActionResult SignatureManager()
	{
		DbSet<EmailUserDefaultSetting> emailUserDefaultSetting = _dbTbl.EmailUserDefaultSetting;
		ParameterExpression val = Expression.Parameter(typeof(EmailUserDefaultSetting), "c");
		List<EmailUserDefaultSetting> list = Enumerable.ToList<EmailUserDefaultSetting>((IEnumerable<EmailUserDefaultSetting>)Queryable.Where<EmailUserDefaultSetting>((IQueryable<EmailUserDefaultSetting>)emailUserDefaultSetting, Expression.Lambda<Func<EmailUserDefaultSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Property((Expression)null, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
		if (list.Count <= 0)
		{
			list = new List<EmailUserDefaultSetting>();
		}
		base.ViewBag.AllUserSignature = list;
		base.ViewBag.SignatureCode = CodeDecode.Codding(_db.Database.Connection.ConnectionString);
		return View();
	}

	[AjaxOnly]
	public string GetSignature(int id)
	{
		EmailUserDefaultSetting emailUserDefaultSetting = _dbTbl.EmailUserDefaultSetting.Find(id);
		if (emailUserDefaultSetting == null)
		{
			return "";
		}
		return "<br />" + emailUserDefaultSetting.eudBody + "<br />";
	}

	[AjaxOnly]
	[HttpPost]
	public JsonResult AddSignature(SignatureManagerViewNodel data)
	{
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			if (!string.IsNullOrEmpty(data.Title) && !string.IsNullOrEmpty(data.Body))
			{
				EmailUserDefaultSetting emailUserDefaultSetting = new EmailUserDefaultSetting();
				int userId2 = (emailUserDefaultSetting.FirstRegisterUserId = UserLogin.CurrentUser.UserId);
				emailUserDefaultSetting.UserId = userId2;
				emailUserDefaultSetting.eudTitle = data.Title;
				string firstRegisterDatePersian = (emailUserDefaultSetting.RegisterDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture()));
				emailUserDefaultSetting.FirstRegisterDatePersian = firstRegisterDatePersian;
				emailUserDefaultSetting.RegisterDate = now;
				emailUserDefaultSetting.FirstRegisterDate = now;
				emailUserDefaultSetting.eudBody = data.Body;
				emailUserDefaultSetting.AppType = Configuration.AppType;
				emailUserDefaultSetting.GUId = System.Guid.NewGuid();
				emailUserDefaultSetting.LanguageID = result;
				_dbTbl.EmailUserDefaultSetting.Add(emailUserDefaultSetting);
				_dbTbl.SaveChanges();
				return Json(emailUserDefaultSetting, JsonRequestBehavior.AllowGet);
			}
			return null;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return null;
		}
	}

	[AjaxOnly]
	public JsonResult DeleteSignature(int id)
	{
		string data = "";
		EmailUserDefaultSetting emailUserDefaultSetting = _dbTbl.EmailUserDefaultSetting.Find(id);
		if (emailUserDefaultSetting != null)
		{
			try
			{
				_dbTbl.EmailUserDefaultSetting.Remove(emailUserDefaultSetting);
				_dbTbl.SaveChanges();
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
				data = Messages.frmErrorMessage;
			}
		}
		else
		{
			data = Messages.msgErrorSampleSignatureNotFound;
		}
		return Json(data, JsonRequestBehavior.AllowGet);
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
