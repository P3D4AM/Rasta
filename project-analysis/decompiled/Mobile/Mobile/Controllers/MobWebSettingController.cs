using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using CRM.General.IO;
using CRM.General.IO.FTP;
using CRM.General.Security;
using CRM.Resources;
using Elmah;
using GSD.Globalization;
using Mobile.Cache;
using Mobile.Cache.Setting;
using Mobile.Classes;
using Mobile.Models;

namespace Mobile.Controllers;

public class MobWebSettingController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass2_0
	{
		public int id;
	}

	private CRMEntities _db = new CRMEntities();

	[LoginAuthorize]
	public ActionResult Index()
	{
		List<MobspSelectCrmWebSetting_Result> list = new List<MobspSelectCrmWebSetting_Result>();
		try
		{
			list = WebSetting.Get();
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.ListSetting = list;
		return View(new WebSettingViewModel());
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public ActionResult Index(WebSettingViewModel model)
	{
		List<MobspSelectCrmWebSetting_Result> list = new List<MobspSelectCrmWebSetting_Result>();
		try
		{
			list = WebSetting.Get();
			if (base.ModelState.IsValid)
			{
				string[] array = model.AllSettings.Split(new char[1] { '|' });
				foreach (string text in array)
				{
					if (text != "")
					{
						string[] array2 = text.Split(new char[1] { '^' });
						if (array2.Length != 2)
						{
							base.ViewBag.Error = Messages.MobMsgErrorLackInfo;
							return View(model);
						}
						_003C_003Ec__DisplayClass2_0 _003C_003Ec__DisplayClass2_ = new _003C_003Ec__DisplayClass2_0();
						int.TryParse(array2[0], out _003C_003Ec__DisplayClass2_.id);
						DbSet<CrmWebSetting> crmWebSetting = _db.CrmWebSetting;
						ParameterExpression val = Expression.Parameter(typeof(CrmWebSetting), "m");
						CrmWebSetting crmWebSetting2 = Queryable.FirstOrDefault<CrmWebSetting>((IQueryable<CrmWebSetting>)crmWebSetting, Expression.Lambda<Func<CrmWebSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass2_, typeof(_003C_003Ec__DisplayClass2_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
						if (crmWebSetting2 == null)
						{
							base.ViewBag.Error = Messages.MobMsgErrorInFindSettingField;
							return View(model);
						}
						if (crmWebSetting2.IsRequired && array2[1].Trim() == "")
						{
							base.ViewBag.Error = string.Format(Messages.MobMsgErrorFieldEmpty, crmWebSetting2.KeyFa);
							return View(model);
						}
						crmWebSetting2.Value = (crmWebSetting2.IsDecoded ? CodeDecode.Codding(array2[1]) : array2[1]);
						crmWebSetting2.UserId = MobUserLogin.CurrentUser.UserId;
						DateTime dateTime = (crmWebSetting2.RegisterDate = DateTime.Now);
						crmWebSetting2.RegisterDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
						crmWebSetting2.Year1 = short.Parse(Financial.Get().Id.ToString());
						crmWebSetting2.Month1 = short.Parse(dateTime.ToString("MM", new PersianCulture()));
						crmWebSetting2.AppType = Configuration.AppType;
						_db.Entry(crmWebSetting2).State = EntityState.Modified;
						_db.SaveChanges();
					}
				}
				if (!Manager.UpdateAllSettingCach())
				{
					base.ViewBag.Error = Messages.MobMsgErrorInCacheUpdate;
					return View(model);
				}
				WebSetting.Update();
				base.ViewBag.Successfull = Messages.MobMsgEditInfoSuccess;
				list = WebSetting.Get();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			base.ViewBag.Error = Messages.frmErrorMessage;
		}
		base.ViewBag.ListSetting = list;
		return View(model);
	}

	[LoginAuthorize]
	public ActionResult TestFtp()
	{
		return View();
	}

	[ValidateAntiForgeryToken]
	public ActionResult ActAttachFile(HttpPostedFileBase attachFileUrlUpload)
	{
		string text = "";
		bool flag = false;
		try
		{
			if (attachFileUrlUpload != null)
			{
				attachFileUrlUpload.ContentType.ToLower();
				Path.GetExtension(attachFileUrlUpload.FileName).ToLower();
				string text2 = Configuration.HostTempFilesPath + "/Test";
				string text3 = base.Server.MapPath(text2);
				if (!System.IO.Directory.Exists(text3))
				{
					System.IO.Directory.CreateDirectory(text3);
					CRM.General.IO.Directory.SetFullControlForEveryOne(text3);
				}
				string text4 = base.Server.MapPath(text2 + "/");
				if (!System.IO.Directory.Exists(text4))
				{
					System.IO.Directory.CreateDirectory(text4);
					CRM.General.IO.Directory.SetFullControlForEveryOne(text4);
				}
				string pathFtp = Configuration.PathFtp;
				string userNameFtp = Configuration.UserNameFtp;
				string passwordFtp = Configuration.PasswordFtp;
				bool usePassiveFtp = Configuration.UsePassiveFtp;
				string text5 = Path.GetFileName(attachFileUrlUpload.FileName);
				if (text5 != null)
				{
					string text6 = Path.Combine(text4, text5);
					if (System.IO.File.Exists(text6))
					{
						text5 = DateTime.Now.ToString("yyyyMMdd-HHmmss") + "-" + text5;
						text6 = Path.Combine(text4, text5);
					}
					attachFileUrlUpload.SaveAs(text6);
					if (System.IO.File.Exists(text6))
					{
						FacadeFTP facadeFTP = new FacadeFTP(Configuration.FacadeFtp);
						string mainDirectoryPath = Configuration.MainDirectoryPath;
						string text7 = "Test";
						bool flag2 = facadeFTP.ExistsDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, mainDirectoryPath, text7, Configuration.UsePassiveFtp);
						if (!flag2)
						{
							flag2 = facadeFTP.CreateDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, mainDirectoryPath, text7, usePassiveFtp);
						}
						if (flag2)
						{
							string text8 = "";
							string text9 = "";
							mainDirectoryPath = mainDirectoryPath + text7 + "/";
							string[] array = text5.Split(new char[1] { '.' });
							text8 = text7 + "-" + DateTime.Now.ToString("yyyyMMdd-HHmmss") + "." + array[^1];
							mainDirectoryPath += text8;
							text9 = text6;
							if (text9 != "")
							{
								flag = facadeFTP.UploadFtpFormTable(pathFtp, userNameFtp, passwordFtp, mainDirectoryPath, text9, usePassiveFtp);
							}
							text = (flag ? "yes" : "no");
						}
						else
						{
							text += Messages.MobMsgErrorFtpInfoIncorrect;
							flag = false;
						}
					}
					else
					{
						text += Messages.MobMsgErrorNotCreateFileInServer;
						flag = false;
					}
				}
				else
				{
					text += Messages.MobMsgErrorFileNotSelected;
					flag = false;
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			text += Messages.MobMsgErrorInSendingFile;
			flag = false;
		}
		var data = new
		{
			Success = flag.ToString(),
			Message = text
		};
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[ValidateAntiForgeryToken]
	public ActionResult ActAttachFileRecording(HttpPostedFileBase attachFileRecordingUrlUpload)
	{
		string text = "";
		bool flag = false;
		try
		{
			string pathFtpRecording = Configuration.PathFtpRecording;
			string userNameFtpRecording = Configuration.UserNameFtpRecording;
			string passwordFtpRecording = Configuration.PasswordFtpRecording;
			bool usePassiveFtpRecording = Configuration.UsePassiveFtpRecording;
			if (!string.IsNullOrEmpty(pathFtpRecording))
			{
				if (attachFileRecordingUrlUpload != null)
				{
					attachFileRecordingUrlUpload.ContentType.ToLower();
					Path.GetExtension(attachFileRecordingUrlUpload.FileName).ToLower();
					string text2 = Configuration.HostTempFilesPath + "/Test";
					string text3 = base.Server.MapPath(text2);
					if (!System.IO.Directory.Exists(text3))
					{
						System.IO.Directory.CreateDirectory(text3);
						CRM.General.IO.Directory.SetFullControlForEveryOne(text3);
					}
					string text4 = base.Server.MapPath(text2 + "/");
					if (!System.IO.Directory.Exists(text4))
					{
						System.IO.Directory.CreateDirectory(text4);
						CRM.General.IO.Directory.SetFullControlForEveryOne(text4);
					}
					string text5 = Path.GetFileName(attachFileRecordingUrlUpload.FileName);
					if (text5 != null)
					{
						string text6 = Path.Combine(text4, text5);
						if (System.IO.File.Exists(text6))
						{
							text5 = DateTime.Now.ToString("yyyyMMdd-HHmmss") + "-" + text5;
							text6 = Path.Combine(text4, text5);
						}
						attachFileRecordingUrlUpload.SaveAs(text6);
						if (System.IO.File.Exists(text6))
						{
							FacadeFTP facadeFTP = new FacadeFTP(Configuration.FacadeFtpRecording);
							string text7 = "/";
							string text8 = "Test";
							bool flag2 = facadeFTP.ExistsDirectoryInFtp(pathFtpRecording, userNameFtpRecording, passwordFtpRecording, text7, text8, usePassiveFtpRecording);
							if (!flag2)
							{
								flag2 = facadeFTP.CreateDirectoryInFtp(pathFtpRecording, userNameFtpRecording, passwordFtpRecording, text7, text8, usePassiveFtpRecording);
							}
							if (flag2)
							{
								string text9 = "";
								string text10 = "";
								text7 = text7 + text8 + "/";
								string[] array = text5.Split(new char[1] { '.' });
								text9 = text8 + "-" + DateTime.Now.ToString("yyyyMMdd-HHmmss") + "." + array[^1];
								text7 += text9;
								text10 = text6;
								if (text10 != "")
								{
									flag = facadeFTP.UploadFtpFormTable(pathFtpRecording, userNameFtpRecording, passwordFtpRecording, text7, text10, usePassiveFtpRecording);
								}
								text = (flag ? "yes" : "no");
							}
							else
							{
								text += Messages.MobMsgErrorFtpInfoIncorrect;
								flag = false;
							}
						}
						else
						{
							text += Messages.MobMsgErrorNotCreateFileInServer;
							flag = false;
						}
					}
					else
					{
						text += Messages.MobMsgErrorFileNotSelected;
						flag = false;
					}
				}
			}
			else
			{
				text += Messages.MobMsgErrorFtpRecordingNotDefined;
				flag = false;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			text += Messages.MobMsgErrorInSendingFile;
			flag = false;
		}
		var data = new
		{
			Success = flag.ToString(),
			Message = text
		};
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		base.Dispose(disposing);
	}
}
