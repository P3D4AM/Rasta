using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CRM.General.IO;
using CRM.General.IO.FTP;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.Setting.Controllers;

public class MobHRMSettingController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass5_0
	{
		public CrmMobHRMSettingLanguageViewModel model;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__5;

		internal bool _003CEditMobHRMSetting_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CEditMobHRMSetting_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CEditMobHRMSetting_003Eb__5(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass5_1
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass5_0 CS_0024_003C_003E8__locals1;

		internal bool _003CEditMobHRMSetting_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditMobHRMSetting_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditMobHRMSetting_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditMobHRMSetting_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	private CRMSpEntities db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	public ActionResult Index()
	{
		return View();
	}

	public JsonResult GetMobHRMSetting()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		CrmMobHRMSettingLanguageViewModel crmMobHRMSettingLanguageViewModel = new CrmMobHRMSettingLanguageViewModel();
		try
		{
			List<CrmsysSetting_Lang> list = Enumerable.ToList<CrmsysSetting_Lang>((IEnumerable<CrmsysSetting_Lang>)_dbTbl.CrmsysSetting_Lang);
			CrmsysSetting crmsysSetting = Queryable.FirstOrDefault<CrmsysSetting>((IQueryable<CrmsysSetting>)_dbTbl.CrmsysSetting);
			if (crmsysSetting != null)
			{
				crmMobHRMSettingLanguageViewModel = new CrmMobHRMSettingLanguageViewModel
				{
					SysSettingId = crmsysSetting.ID,
					CoLogoMobHRMAppPath = crmsysSetting.CoLogoMobHRMAppPath
				};
				if (!string.IsNullOrEmpty(crmMobHRMSettingLanguageViewModel.CoLogoMobHRMAppPath))
				{
					string coLogoMobHRMAppPath = crmMobHRMSettingLanguageViewModel.CoLogoMobHRMAppPath;
					crmMobHRMSettingLanguageViewModel.CoLogoMobHRMAppPath = crmMobHRMSettingLanguageViewModel.CoLogoMobHRMAppPath.Replace(Configuration.MainDirectoryPath, "/");
					crmMobHRMSettingLanguageViewModel.CoLogoMobHRMAppPath = Configuration.HostTempFilesPath + crmMobHRMSettingLanguageViewModel.CoLogoMobHRMAppPath;
					if (!System.IO.File.Exists(base.Server.MapPath(crmMobHRMSettingLanguageViewModel.CoLogoMobHRMAppPath)) && DownlaodFileFromFTP(coLogoMobHRMAppPath, crmMobHRMSettingLanguageViewModel.CoLogoMobHRMAppPath))
					{
						crmMobHRMSettingLanguageViewModel.CoLogoMobHRMAppPath = "";
					}
				}
				List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmsysSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmsysSetting_Lang>)list, (Func<CrmsysSetting_Lang, CommonMultiLanguageViewModel>)((CrmsysSetting_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.CoNameMobHRMApp,
					LanguageId = item.LanguageID
				})));
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = crmsysSetting.CoNameMobHRMApp,
					LanguageId = result
				});
				crmMobHRMSettingLanguageViewModel.CoNameMobHRMApp = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : "");
				crmMobHRMSettingLanguageViewModel.CoNameMobHRMApp_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID))));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(crmMobHRMSettingLanguageViewModel, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public ActionResult EditMobHRMSetting()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		CrmMobHRMSettingLanguageViewModel crmMobHRMSettingLanguageViewModel = new CrmMobHRMSettingLanguageViewModel();
		try
		{
			List<CrmsysSetting_Lang> list = Enumerable.ToList<CrmsysSetting_Lang>((IEnumerable<CrmsysSetting_Lang>)_dbTbl.CrmsysSetting_Lang);
			CrmsysSetting crmsysSetting = Queryable.FirstOrDefault<CrmsysSetting>((IQueryable<CrmsysSetting>)_dbTbl.CrmsysSetting);
			if (crmsysSetting != null)
			{
				crmMobHRMSettingLanguageViewModel = new CrmMobHRMSettingLanguageViewModel
				{
					SysSettingId = crmsysSetting.ID,
					CoLogoMobHRMAppPath = crmsysSetting.CoLogoMobHRMAppPath
				};
				if (!string.IsNullOrEmpty(crmMobHRMSettingLanguageViewModel.CoLogoMobHRMAppPath))
				{
					string coLogoMobHRMAppPath = crmMobHRMSettingLanguageViewModel.CoLogoMobHRMAppPath;
					crmMobHRMSettingLanguageViewModel.CoLogoMobHRMAppPath = crmMobHRMSettingLanguageViewModel.CoLogoMobHRMAppPath.Replace(Configuration.MainDirectoryPath, "/");
					crmMobHRMSettingLanguageViewModel.CoLogoMobHRMAppPath = Configuration.HostTempFilesPath + crmMobHRMSettingLanguageViewModel.CoLogoMobHRMAppPath;
					if (!System.IO.File.Exists(base.Server.MapPath(crmMobHRMSettingLanguageViewModel.CoLogoMobHRMAppPath)) && DownlaodFileFromFTP(coLogoMobHRMAppPath, crmMobHRMSettingLanguageViewModel.CoLogoMobHRMAppPath))
					{
						crmMobHRMSettingLanguageViewModel.CoLogoMobHRMAppPath = "";
					}
				}
				List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmsysSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmsysSetting_Lang>)list, (Func<CrmsysSetting_Lang, CommonMultiLanguageViewModel>)((CrmsysSetting_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.CoNameMobHRMApp,
					LanguageId = item.LanguageID
				})));
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = crmsysSetting.CoNameMobHRMApp,
					LanguageId = result
				});
				crmMobHRMSettingLanguageViewModel.CoNameMobHRMApp = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : "");
				crmMobHRMSettingLanguageViewModel.CoNameMobHRMApp_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID))));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return View(crmMobHRMSettingLanguageViewModel);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmMobHRMSetting", ActionName = "actEdit")]
	[ValidateAntiForgeryToken]
	public ActionResult EditMobHRMSetting(CrmMobHRMSettingLanguageViewModel model, HttpPostedFileBase urlUpload)
	{
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass5_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass5_0();
		CS_0024_003C_003E8__locals0.model = model;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		int num = 0;
		try
		{
			List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.CoNameMobHRMApp_Lang))
			{
				list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.CoNameMobHRMApp_Lang);
			}
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.model.CoNameMobHRMApp,
				LanguageId = lCID
			});
			string text2 = "";
			CrmsysSetting crmsysSetting = Queryable.FirstOrDefault<CrmsysSetting>((IQueryable<CrmsysSetting>)_dbTbl.CrmsysSetting);
			if (crmsysSetting != null)
			{
				text2 = crmsysSetting.CoLogoMobHRMAppPath;
			}
			DateTime now;
			int userId;
			short value;
			short value2;
			string appType;
			if (base.ModelState.IsValid)
			{
				int customWidth = 150;
				int customHeight = 150;
				string text3 = "Logo/";
				if (num == 0)
				{
					now = DateTime.Now;
					userId = UserLogin.CurrentUser.UserId;
					now.ToString("yyyyMMdd", new PersianCulture());
					value = short.Parse(Financial.Get().Id.ToString());
					value2 = short.Parse(now.ToString("MM", new PersianCulture()));
					appType = Configuration.AppType;
					int num2 = 500;
					if (urlUpload == null)
					{
						goto IL_0610;
					}
					string text4 = urlUpload.ContentType.ToLower();
					string text5 = Path.GetExtension(urlUpload.FileName).ToLower();
					if ((text4 != "image/jpg" && text4 != "image/jpeg" && text4 != "image/pjpeg" && text4 != "image/gif" && text4 != "image/x-png" && text4 != "image/png") || (text5 != ".jpg" && text5 != ".png" && text5 != ".gif" && text5 != ".jpeg"))
					{
						text = Messages.frmErrorNotImageFile;
						base.ViewBag.Error = text;
						base.ModelState.AddModelError("error", text);
						return View(CS_0024_003C_003E8__locals0.model);
					}
					if (urlUpload.ContentLength / 1024 > num2)
					{
						text = string.Format(Messages.frmErrorMaxImageSizeForUpload, num2);
						base.ViewBag.Error = text;
						base.ModelState.AddModelError("error", text);
						return View(CS_0024_003C_003E8__locals0.model);
					}
					FacadeFTP facadeFTP = new FacadeFTP(Configuration.FacadeFtp);
					string pathFtp = Configuration.PathFtp;
					string userNameFtp = Configuration.UserNameFtp;
					string passwordFtp = Configuration.PasswordFtp;
					bool usePassiveFtp = Configuration.UsePassiveFtp;
					string fileName = Path.GetFileName(urlUpload.FileName);
					string text6 = Configuration.MainDirectoryPath + Configuration.SysSettingDirectoryPath;
					string text7 = text6 + (text6.EndsWith("/") ? "" : "/");
					bool flag = facadeFTP.ExistsDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, Configuration.MainDirectoryPath, Configuration.SysSettingDirectoryPath, usePassiveFtp);
					if (!flag)
					{
						flag = facadeFTP.CreateDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, Configuration.MainDirectoryPath, Configuration.SysSettingDirectoryPath, usePassiveFtp);
					}
					bool flag2 = facadeFTP.ExistsDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, text7, text3, usePassiveFtp);
					if (!flag2)
					{
						flag2 = facadeFTP.CreateDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, text7, text3, usePassiveFtp);
					}
					if (!(flag && flag2))
					{
						goto IL_0610;
					}
					text7 += text3;
					string text8 = text7;
					text8 = text8.Replace(Configuration.MainDirectoryPath, "/");
					text8 = Configuration.HostTempFilesPath + text8;
					text8 = base.Server.MapPath(text8);
					if (!System.IO.Directory.Exists(text8))
					{
						System.IO.Directory.CreateDirectory(text8);
						CRM.General.IO.Directory.SetFullControlForEveryOne(text8);
					}
					if (System.IO.Directory.Exists(text8))
					{
						string text9 = text8 + "Initial-" + fileName;
						text8 += fileName;
						if (System.IO.File.Exists(text8))
						{
							System.IO.File.Delete(text8);
						}
						urlUpload.SaveAs(text9);
						if (System.IO.File.Exists(text9))
						{
							ImageManager.CompressFile(new ImageManager.ImageParam
							{
								FilePath = text9,
								DestPath = text8,
								CustomHeight = customHeight,
								CustomWidth = customWidth
							});
							ImageManager.DeleteFile(new ImageManager.ImageParam
							{
								FilePath = text9
							});
						}
					}
					if (!System.IO.File.Exists(text8))
					{
						goto IL_0610;
					}
					text7 += fileName;
					if (facadeFTP.UploadFtpFormTable(pathFtp, userNameFtp, passwordFtp, text7, text8, usePassiveFtp))
					{
						CS_0024_003C_003E8__locals0.model.CoLogoMobHRMAppPath = text7;
						goto IL_0610;
					}
					CS_0024_003C_003E8__locals0.model.CoLogoMobHRMAppPath = null;
					Exception e = new Exception(Messages.msgErrorUploadingFileInFtp + "  -  hostname: " + pathFtp + " ,username: " + userNameFtp + " ,destination: " + text7);
					ErrorSignal.FromCurrentContext().Raise(e);
					base.ModelState.AddModelError("error", Messages.frmErrorInSendingFile);
					base.ViewBag.Error = Messages.frmErrorInSendingFile;
				}
			}
			else
			{
				text = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
			}
			goto end_IL_005e;
			IL_0610:
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.CoLogoMobHRMAppPath) && CS_0024_003C_003E8__locals0.model.CoLogoMobHRMAppPath.IndexOf(Configuration.HostTempFilesPath, StringComparison.Ordinal) >= 0)
			{
				CS_0024_003C_003E8__locals0.model.CoLogoMobHRMAppPath = CS_0024_003C_003E8__locals0.model.CoLogoMobHRMAppPath.Replace(Configuration.HostTempFilesPath + "/", "");
				CS_0024_003C_003E8__locals0.model.CoLogoMobHRMAppPath = Configuration.MainDirectoryPath + CS_0024_003C_003E8__locals0.model.CoLogoMobHRMAppPath;
			}
			if (!string.IsNullOrWhiteSpace(text2) && (text2 ?? "").ToLower() != (CS_0024_003C_003E8__locals0.model.CoLogoMobHRMAppPath ?? "").ToLower())
			{
				DeleteOldFileFromFtp(text2);
			}
			DbSet<CrmsysSetting> crmsysSetting2 = _dbTbl.CrmsysSetting;
			ParameterExpression val = Expression.Parameter(typeof(CrmsysSetting), "m");
			CrmsysSetting crmsysSetting3 = Queryable.FirstOrDefault<CrmsysSetting>((IQueryable<CrmsysSetting>)crmsysSetting2, Expression.Lambda<Func<CrmsysSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass5_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (crmsysSetting3 != null)
			{
				crmsysSetting3.CoNameMobHRMApp = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				crmsysSetting3.CoLogoMobHRMAppPath = CS_0024_003C_003E8__locals0.model.CoLogoMobHRMAppPath;
				crmsysSetting3.UserId = userId;
				crmsysSetting3.RegisterDate = now;
				crmsysSetting3.Year1 = value;
				crmsysSetting3.Month1 = value2;
				crmsysSetting3.AppType = appType;
				_dbTbl.Entry(crmsysSetting3).State = EntityState.Modified;
				_dbTbl.SaveChanges();
				using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						_003C_003Ec__DisplayClass5_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass5_1();
						CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals0;
						CS_0024_003C_003E8__locals1.lang = enumerator.Current;
						DbSet<CrmsysSetting_Lang> crmsysSetting_Lang = _dbTbl.CrmsysSetting_Lang;
						val = Expression.Parameter(typeof(CrmsysSetting_Lang), "c");
						CrmsysSetting_Lang crmsysSetting_Lang2 = Queryable.FirstOrDefault<CrmsysSetting_Lang>((IQueryable<CrmsysSetting_Lang>)crmsysSetting_Lang, Expression.Lambda<Func<CrmsysSetting_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass5_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass5_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
						if (crmsysSetting_Lang2 != null)
						{
							crmsysSetting_Lang2.CoNameMobHRMApp = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							_dbTbl.Entry(crmsysSetting_Lang2).State = EntityState.Modified;
							_dbTbl.SaveChanges();
							continue;
						}
						crmsysSetting_Lang2 = new CrmsysSetting_Lang
						{
							CoNameMobHRMApp = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null)
						};
						_dbTbl.CrmsysSetting_Lang.Add(crmsysSetting_Lang2);
						_dbTbl.SaveChanges();
					}
				}
				CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmsysSetting");
			}
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.CoLogoMobHRMAppPath))
			{
				CS_0024_003C_003E8__locals0.model.CoLogoMobHRMAppPath = CS_0024_003C_003E8__locals0.model.CoLogoMobHRMAppPath.Replace(Configuration.MainDirectoryPath, "/");
				CS_0024_003C_003E8__locals0.model.CoLogoMobHRMAppPath = Configuration.HostTempFilesPath + CS_0024_003C_003E8__locals0.model.CoLogoMobHRMAppPath;
			}
			base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
			end_IL_005e:;
		}
		catch (DbEntityValidationException e2)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e2);
			text = Messages.frmErrorMessage;
		}
		catch (Exception e3)
		{
			ErrorSignal.FromCurrentContext().Raise(e3);
			text = Messages.frmErrorMessage;
		}
		base.ViewBag.Error = text;
		return View(CS_0024_003C_003E8__locals0.model);
	}

	public static bool DownlaodFileFromFTP(string sourceFile, string filePath)
	{
		bool result = false;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			FilesManager filesManager = new FilesManager();
			FacadeFTP facadeFTP = new FacadeFTP(Configuration.FacadeFtp);
			string pathFtp = Configuration.PathFtp;
			string userNameFtp = Configuration.UserNameFtp;
			string passwordFtp = Configuration.PasswordFtp;
			bool usePassiveFtp = Configuration.UsePassiveFtp;
			if (!string.IsNullOrEmpty(sourceFile) && !string.IsNullOrEmpty(filePath))
			{
				string text = "";
				if (!string.IsNullOrEmpty(sourceFile))
				{
					string source = sourceFile.ToLower().Replace(Configuration.PathFtp.ToLower(), "");
					bool flag = false;
					string text2 = filePath;
					if (!string.IsNullOrEmpty(text2))
					{
						string[] array = text2.Split(new char[1] { '/' });
						text2 = "";
						if (Enumerable.Any<string>((IEnumerable<string>)array))
						{
							for (int i = 0; i < array.Length - 1; i++)
							{
								if (!string.IsNullOrEmpty(array[i]) && array[i].IndexOf(".", StringComparison.Ordinal) <= 0)
								{
									text2 = text2 + array[i] + "/";
								}
							}
						}
						flag = filesManager.CreateDirectory(text2);
					}
					if (flag)
					{
						bool flag2 = true;
						text = HttpContext.Current.Server.MapPath(filePath);
						if (!System.IO.File.Exists(text))
						{
							flag2 = facadeFTP.Download(pathFtp, userNameFtp, passwordFtp, text, source, overwrite: true, usePassiveFtp);
						}
						result = flag2;
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public void DeleteOldFileFromFtp(string filePath)
	{
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			new FilesManager();
			string pathFtp = Configuration.PathFtp;
			string userNameFtp = Configuration.UserNameFtp;
			string passwordFtp = Configuration.PasswordFtp;
			bool usePassiveFtp = Configuration.UsePassiveFtp;
			bool flag = !string.IsNullOrEmpty(pathFtp) && !string.IsNullOrEmpty(userNameFtp) && !string.IsNullOrEmpty(passwordFtp);
			string pathFtpFo = Configuration.PathFtpFo;
			string userNameFtpFo = Configuration.UserNameFtpFo;
			string passwordFtpFo = Configuration.PasswordFtpFo;
			bool usePassiveFtpFo = Configuration.UsePassiveFtpFo;
			bool flag2 = !string.IsNullOrEmpty(pathFtpFo) && !string.IsNullOrEmpty(userNameFtpFo) && !string.IsNullOrEmpty(passwordFtpFo);
			string text = "";
			string[] array = filePath.Split(new char[1] { '/' });
			if (array != null && array.Length != 0)
			{
				text = array[^1];
			}
			if (string.IsNullOrWhiteSpace(filePath) || string.IsNullOrWhiteSpace(text))
			{
				return;
			}
			if (flag)
			{
				FacadeFTP facadeFTP = new FacadeFTP(Configuration.FacadeFtp);
				string destination = filePath.ToLower();
				facadeFTP.Delete(pathFtp, userNameFtp, passwordFtp, text, destination, usePassiveFtp);
				string text2 = filePath.ToLower().Replace(pathFtp.ToLower(), "");
				text2 = text2.Replace(Configuration.MainDirectoryPath.ToLower(), "/");
				text2 = Configuration.HostTempFilesPath + text2;
				text2 = base.Server.MapPath(text2);
				if (System.IO.File.Exists(text2))
				{
					System.IO.File.Delete(text2);
				}
			}
			if (flag2)
			{
				FacadeFTP facadeFTP2 = new FacadeFTP(Configuration.FacadeFtpFo);
				string text3 = filePath.ToLower().Replace(pathFtp.ToLower(), "");
				text3 = string.Concat(str1: text3.Replace(Configuration.MainDirectoryPath.ToLower(), "/"), str0: Configuration.HostTempFilesPath);
				text3 = text3.Replace("~", "").ToLower();
				facadeFTP2.Delete(pathFtpFo, userNameFtpFo, passwordFtpFo, text, text3, usePassiveFtpFo);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
	}
}
