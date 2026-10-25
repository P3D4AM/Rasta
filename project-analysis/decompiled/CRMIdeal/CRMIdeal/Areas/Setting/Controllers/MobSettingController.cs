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
using CRM.General.Security;
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

public class MobSettingController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass10_0
	{
		public int mobSettingId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass11_0
	{
		public CrmMobSettingIELanguageViewModel model;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass4_1
	{
		public CRMspSelectCrmsysSetting_Result coSettingfromCache;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass5_0
	{
		public int defLangID;

		public CrmMobSettingLanguageViewModel model;

		public Func<Languages, bool> _003C_003E9__4;

		internal bool _003CIndex_003Eb__2(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CIndex_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CIndex_003Eb__4(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass5_1
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass5_0 CS_0024_003C_003E8__locals1;

		internal bool _003CIndex_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CIndex_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CIndex_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CIndex_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	private CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private CRMSpIEntities _dbI = new CRMSpIEntities();

	private CRMSpIIEntities _dbII = new CRMSpIIEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actSetting")]
	public ActionResult Index()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		CrmMobSettingLanguageViewModel crmMobSettingLanguageViewModel = new CrmMobSettingLanguageViewModel();
		try
		{
			_003C_003Ec__DisplayClass4_1 _003C_003Ec__DisplayClass4_ = new _003C_003Ec__DisplayClass4_1();
			List<CrmsysSetting_Lang> list = Enumerable.ToList<CrmsysSetting_Lang>((IEnumerable<CrmsysSetting_Lang>)_dbTbl.CrmsysSetting_Lang);
			CrmsysSetting crmsysSetting = new CrmsysSetting();
			_003C_003Ec__DisplayClass4_.coSettingfromCache = SysSeting.Get();
			if (_003C_003Ec__DisplayClass4_.coSettingfromCache != null)
			{
				DbSet<CrmsysSetting> crmsysSetting2 = _dbTbl.CrmsysSetting;
				ParameterExpression val = Expression.Parameter(typeof(CrmsysSetting), "m");
				crmsysSetting = Queryable.FirstOrDefault<CrmsysSetting>((IQueryable<CrmsysSetting>)crmsysSetting2, Expression.Lambda<Func<CrmsysSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass4_, typeof(_003C_003Ec__DisplayClass4_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			}
			else
			{
				crmsysSetting = new CrmsysSetting
				{
					UserId = UserLogin.CurrentUser.UserId,
					Month1 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture())),
					Year1 = short.Parse(DateTime.Now.ToString("yyyy", new PersianCulture())),
					RegisterDate = DateTime.Now,
					ID = 0
				};
			}
			if (crmsysSetting == null)
			{
				crmsysSetting = new CrmsysSetting
				{
					UserId = UserLogin.CurrentUser.UserId,
					Month1 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture())),
					Year1 = short.Parse(DateTime.Now.ToString("yyyy", new PersianCulture())),
					RegisterDate = DateTime.Now,
					ID = 0
				};
			}
			crmMobSettingLanguageViewModel = new CrmMobSettingLanguageViewModel
			{
				ID = crmsysSetting.ID,
				MobAccessCmpDistance = crmsysSetting.MobAccessCmpDistance,
				CoLogoMobAppPath = crmsysSetting.CoLogoMobAppPath,
				MobCmpQuickRegDupReaction = crmsysSetting.MobCmpQuickRegDupReaction
			};
			if (!string.IsNullOrEmpty(crmMobSettingLanguageViewModel.CoLogoMobAppPath))
			{
				string coLogoMobAppPath = crmMobSettingLanguageViewModel.CoLogoMobAppPath;
				crmMobSettingLanguageViewModel.CoLogoMobAppPath = crmMobSettingLanguageViewModel.CoLogoMobAppPath.Replace(Configuration.MainDirectoryPath, "/");
				crmMobSettingLanguageViewModel.CoLogoMobAppPath = Configuration.HostTempFilesPath + crmMobSettingLanguageViewModel.CoLogoMobAppPath;
				if (!System.IO.File.Exists(base.Server.MapPath(crmMobSettingLanguageViewModel.CoLogoMobAppPath)) && DownlaodFileFromFTP(coLogoMobAppPath, crmMobSettingLanguageViewModel.CoLogoMobAppPath))
				{
					crmMobSettingLanguageViewModel.CoLogoMobAppPath = "";
				}
			}
			List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmsysSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmsysSetting_Lang>)list, (Func<CrmsysSetting_Lang, CommonMultiLanguageViewModel>)((CrmsysSetting_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.CoNameMobApp,
				LanguageId = item.LanguageID
			})));
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = crmsysSetting.CoNameMobApp,
				LanguageId = result
			});
			crmMobSettingLanguageViewModel.CoNameMobApp = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : "");
			crmMobSettingLanguageViewModel.CoNameMobApp_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID))));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.IsBuying = VersionBuyer.MobAccessCmpDistance;
		return View(crmMobSettingLanguageViewModel);
	}

	[ValidateAntiForgeryToken]
	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmsysSetting", ActionName = "actPost")]
	public ActionResult Index(CrmMobSettingLanguageViewModel model, HttpPostedFileBase urlUpload)
	{
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass5_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass5_0();
		CS_0024_003C_003E8__locals0.model = model;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		try
		{
			string text2 = "";
			double num = 0.0;
			CrmsysSetting crmsysSetting = Queryable.FirstOrDefault<CrmsysSetting>((IQueryable<CrmsysSetting>)_dbTbl.CrmsysSetting);
			if (crmsysSetting != null)
			{
				text2 = crmsysSetting.CoLogoMobAppPath;
				num = crmsysSetting.MobAccessCmpDistance.GetValueOrDefault();
			}
			if (!VersionBuyer.MobAccessCmpDistance && num != CS_0024_003C_003E8__locals0.model.MobAccessCmpDistance.GetValueOrDefault())
			{
				base.ViewBag.Error = "BV|" + Messages.VersionBuyWithoutCount;
				return View(CS_0024_003C_003E8__locals0.model);
			}
			List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.CoNameMobApp_Lang))
			{
				list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.CoNameMobApp_Lang);
			}
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.model.CoNameMobApp,
				LanguageId = lCID
			});
			DateTime now;
			int userId;
			short value;
			short value2;
			string appType;
			if (base.ModelState.IsValid)
			{
				if (CS_0024_003C_003E8__locals0.model.ID == 0)
				{
					text = Messages.errorInReadingSetting;
				}
				else
				{
					now = DateTime.Now;
					userId = UserLogin.CurrentUser.UserId;
					now.ToString("yyyyMMdd", new PersianCulture());
					value = short.Parse(Financial.Get().Id.ToString());
					value2 = short.Parse(now.ToString("MM", new PersianCulture()));
					appType = Configuration.AppType;
					int num2 = 500;
					int customWidth = 150;
					int customHeight = 150;
					string text3 = "Logo/";
					if (urlUpload == null)
					{
						goto IL_06db;
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
						goto IL_06db;
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
						goto IL_06db;
					}
					text7 += fileName;
					if (facadeFTP.UploadFtpFormTable(pathFtp, userNameFtp, passwordFtp, text7, text8, usePassiveFtp))
					{
						CS_0024_003C_003E8__locals0.model.CoLogoMobAppPath = text7;
						goto IL_06db;
					}
					CS_0024_003C_003E8__locals0.model.CoLogoMobAppPath = null;
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
			goto end_IL_005b;
			IL_06db:
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.CoLogoMobAppPath) && CS_0024_003C_003E8__locals0.model.CoLogoMobAppPath.IndexOf(Configuration.HostTempFilesPath, StringComparison.Ordinal) >= 0)
			{
				CS_0024_003C_003E8__locals0.model.CoLogoMobAppPath = CS_0024_003C_003E8__locals0.model.CoLogoMobAppPath.Replace(Configuration.HostTempFilesPath + "/", "");
				CS_0024_003C_003E8__locals0.model.CoLogoMobAppPath = Configuration.MainDirectoryPath + CS_0024_003C_003E8__locals0.model.CoLogoMobAppPath;
			}
			if (!string.IsNullOrWhiteSpace(text2) && (text2 ?? "").ToLower() != (CS_0024_003C_003E8__locals0.model.CoLogoMobAppPath ?? "").ToLower())
			{
				DeleteOldFileFromFtp(text2);
			}
			CrmsysSetting crmsysSetting2 = Queryable.FirstOrDefault<CrmsysSetting>((IQueryable<CrmsysSetting>)_dbTbl.CrmsysSetting);
			if (crmsysSetting2 != null)
			{
				crmsysSetting2.MobAccessCmpDistance = CS_0024_003C_003E8__locals0.model.MobAccessCmpDistance;
				crmsysSetting2.CoNameMobApp = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				crmsysSetting2.CoLogoMobAppPath = CS_0024_003C_003E8__locals0.model.CoLogoMobAppPath;
				crmsysSetting2.MobCmpQuickRegDupReaction = CS_0024_003C_003E8__locals0.model.MobCmpQuickRegDupReaction;
				crmsysSetting2.UserId = userId;
				crmsysSetting2.RegisterDate = now;
				crmsysSetting2.Year1 = value;
				crmsysSetting2.Month1 = value2;
				crmsysSetting2.AppType = appType;
				_dbTbl.Entry(crmsysSetting2).State = EntityState.Modified;
				_dbTbl.SaveChanges();
				using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						_003C_003Ec__DisplayClass5_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass5_1();
						CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals0;
						CS_0024_003C_003E8__locals1.lang = enumerator.Current;
						DbSet<CrmsysSetting_Lang> crmsysSetting_Lang = _dbTbl.CrmsysSetting_Lang;
						ParameterExpression val = Expression.Parameter(typeof(CrmsysSetting_Lang), "c");
						CrmsysSetting_Lang crmsysSetting_Lang2 = Queryable.FirstOrDefault<CrmsysSetting_Lang>((IQueryable<CrmsysSetting_Lang>)crmsysSetting_Lang, Expression.Lambda<Func<CrmsysSetting_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass5_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass5_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
						if (crmsysSetting_Lang2 != null)
						{
							crmsysSetting_Lang2.CoNameMobApp = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							_dbTbl.Entry(crmsysSetting_Lang2).State = EntityState.Modified;
							_dbTbl.SaveChanges();
							continue;
						}
						crmsysSetting_Lang2 = new CrmsysSetting_Lang
						{
							CoNameMobApp = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null)
						};
						_dbTbl.CrmsysSetting_Lang.Add(crmsysSetting_Lang2);
						_dbTbl.SaveChanges();
					}
				}
				if (SysSeting.Update())
				{
					base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
				}
				else
				{
					text = Messages.ErrorInCacheUpdate;
				}
				CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmsysSetting");
			}
			else
			{
				text = Messages.errorInReadingSetting;
			}
			end_IL_005b:;
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

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actSetting")]
	public ActionResult OtherMobSetting()
	{
		return View();
	}

	[AjaxOnly]
	public JsonResult GetMobSettingInfo()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		CRMspSelectMobSetting_Result cRMspSelectMobSetting_Result = new CRMspSelectMobSetting_Result();
		CRMspSelectFoSetting_Result cRMspSelectFoSetting_Result = new CRMspSelectFoSetting_Result();
		try
		{
			cRMspSelectFoSetting_Result = CRMIdeal.Classes.Helper.Setting.GetFoSetting();
			cRMspSelectMobSetting_Result = Enumerable.FirstOrDefault<CRMspSelectMobSetting_Result>((IEnumerable<CRMspSelectMobSetting_Result>)_dbII.CRMspSelectMobSetting(lCID, result));
			if (cRMspSelectMobSetting_Result == null)
			{
				cRMspSelectMobSetting_Result = new CRMspSelectMobSetting_Result();
			}
			else
			{
				CRMspSelectMobSetting_Result cRMspSelectMobSetting_Result2 = cRMspSelectMobSetting_Result;
				_ = cRMspSelectMobSetting_Result.FirstRegisterDate;
				cRMspSelectMobSetting_Result2.FirstRegisterDatePersian = cRMspSelectMobSetting_Result.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				CRMspSelectMobSetting_Result cRMspSelectMobSetting_Result3 = cRMspSelectMobSetting_Result;
				_ = cRMspSelectMobSetting_Result.RegisterDate;
				cRMspSelectMobSetting_Result3.RegisterDatePersian = cRMspSelectMobSetting_Result.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				if (string.IsNullOrEmpty(cRMspSelectMobSetting_Result.AppType))
				{
					cRMspSelectMobSetting_Result.AppType = Configuration.AppType;
				}
				cRMspSelectMobSetting_Result.AppType = Configuration.GetAppType(cRMspSelectMobSetting_Result.AppType);
				if (cRMspSelectFoSetting_Result != null)
				{
					cRMspSelectMobSetting_Result.PordWHId = cRMspSelectFoSetting_Result.ShpDefWHId;
					cRMspSelectMobSetting_Result.PordWHName = cRMspSelectFoSetting_Result.ShpDefWH;
				}
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
		JsonResult jsonResult = Json(cRMspSelectMobSetting_Result, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public ActionResult OtherMobSettingInsertEdit(int mobSettingId = 0)
	{
		_003C_003Ec__DisplayClass10_0 _003C_003Ec__DisplayClass10_ = new _003C_003Ec__DisplayClass10_0();
		_003C_003Ec__DisplayClass10_.mobSettingId = mobSettingId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		CrmMobSettingIELanguageViewModel model = new CrmMobSettingIELanguageViewModel();
		_ = DateTime.Now;
		try
		{
			CrmMobSetting crmMobSetting = new CrmMobSetting();
			CRMspSelectFoSetting_Result cRMspSelectFoSetting_Result = new CRMspSelectFoSetting_Result();
			if (_003C_003Ec__DisplayClass10_.mobSettingId > 0)
			{
				DbSet<CrmMobSetting> crmMobSetting2 = _dbTbl.CrmMobSetting;
				ParameterExpression val = Expression.Parameter(typeof(CrmMobSetting), "m");
				crmMobSetting = Queryable.FirstOrDefault<CrmMobSetting>((IQueryable<CrmMobSetting>)crmMobSetting2, Expression.Lambda<Func<CrmMobSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass10_, typeof(_003C_003Ec__DisplayClass10_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				cRMspSelectFoSetting_Result = CRMIdeal.Classes.Helper.Setting.GetFoSetting();
				int? pordWHId = null;
				if (crmMobSetting != null)
				{
					if (cRMspSelectFoSetting_Result != null)
					{
						pordWHId = cRMspSelectFoSetting_Result.ShpDefWHId;
					}
					model = new CrmMobSettingIELanguageViewModel
					{
						MobSettingId = crmMobSetting.MobSettingId,
						AppName = crmMobSetting.AppName,
						DefUserId = crmMobSetting.DefUserId,
						DefPrjTitle = crmMobSetting.DefPrjTitle,
						DefPrjCnvsStatusGroupId = crmMobSetting.DefPrjCnvsStatusGroupId,
						DefCnvsTopicId = crmMobSetting.DefCnvsTopicId,
						DefCnvsReferUserId = crmMobSetting.DefCnvsReferUserId,
						DefCnvsStatusId = crmMobSetting.DefCnvsStatusId,
						DefCnvsDesc = crmMobSetting.DefCnvsDesc,
						DefPrdPriceGroupId = crmMobSetting.DefPrdPriceGroupId,
						DefPordVerifierRequestId = crmMobSetting.DefPordVerifierRequestId,
						ShowTomanLabel = crmMobSetting.ShowTomanLabel.GetValueOrDefault(),
						ShowLastPrdPriceListDate = crmMobSetting.ShowLastPrdPriceListDate.GetValueOrDefault(),
						LoginUserId = crmMobSetting.LoginUserId,
						LoginPrjTitle = crmMobSetting.LoginPrjTitle,
						LoginPrjCnvsStatusGroupId = crmMobSetting.LoginPrjCnvsStatusGroupId,
						LoginCnvsTopicId = crmMobSetting.LoginCnvsTopicId,
						LoginCnvsReferUserId = crmMobSetting.LoginCnvsReferUserId,
						LoginCnvsDesc = crmMobSetting.LoginCnvsDesc,
						LoginCnvsStatusId = crmMobSetting.LoginCnvsStatusId,
						PordPrjTitle = crmMobSetting.PordPrjTitle,
						PordPrjCnvsStatusGroupId = crmMobSetting.PordPrjCnvsStatusGroupId,
						PordCnvsTopicId = crmMobSetting.PordCnvsTopicId,
						PordCnvsReferUserId = crmMobSetting.PordCnvsReferUserId,
						PordCnvsDesc = crmMobSetting.PordCnvsDesc,
						PordCnvsStatusId = crmMobSetting.PordCnvsStatusId,
						PordChangeCurrDesId = crmMobSetting.PordChangeCurrDesId,
						PordCreditDurationId = crmMobSetting.PordCreditDurationId,
						PordCurrencyUnitId = crmMobSetting.PordCurrencyUnitId,
						PordPrintFormatId = crmMobSetting.PordPrintFormatId,
						PordWHId = pordWHId,
						PordIssueOrdAfterOnLinePay = crmMobSetting.PordIssueOrdAfterOnLinePay.GetValueOrDefault(),
						PordSendSmsAfterVerify = crmMobSetting.PordSendSmsAfterVerify.GetValueOrDefault(),
						PordVerifierRequestMsg = crmMobSetting.PordVerifierRequestMsg,
						PordPayTypeId = crmMobSetting.PordPayTypeId,
						PordIssueOrdOprId = crmMobSetting.PordIssueOrdOprId,
						PordIssueOrdPrintFormId = crmMobSetting.PordIssueOrdPrintFormId,
						InstallPrjTitle = crmMobSetting.InstallPrjTitle,
						InstallPrjCnvsStatusGroupId = crmMobSetting.InstallPrjCnvsStatusGroupId,
						InstallCnvsDesc = crmMobSetting.InstallCnvsDesc,
						InstallCnvsReferUserId = crmMobSetting.InstallCnvsReferUserId,
						InstallCnvsTopicId = crmMobSetting.InstallCnvsTopicId,
						InstallCnvsStatusId = crmMobSetting.InstallCnvsStatusId,
						CmpNotifPrjTitle = crmMobSetting.CmpNotifPrjTitle,
						CmpNotifCnvsReferUserId = crmMobSetting.CmpNotifCnvsReferUserId,
						CmpNotifCnvsStatusId = crmMobSetting.CmpNotifCnvsStatusId,
						CmpNotifCnvsDesc = crmMobSetting.CmpNotifCnvsDesc,
						CmpNotifCnvsTopicId = crmMobSetting.CmpNotifCnvsTopicId,
						CmpNotifPrjCnvsStatusGroupId = crmMobSetting.CmpNotifPrjCnvsStatusGroupId,
						EdtReqCnvsReferUserId = crmMobSetting.EdtReqCnvsReferUserId,
						EdtReqCnvsTopicId = crmMobSetting.EdtReqCnvsTopicId,
						EdtReqCnvsStatusId = crmMobSetting.EdtReqCnvsStatusId,
						EdtReqPrjCnvsStatusGroupId = crmMobSetting.EdtReqPrjCnvsStatusGroupId,
						EdtReqPrjTitle = crmMobSetting.EdtReqPrjTitle,
						EditReqCnvsDesc = crmMobSetting.EditReqCnvsDesc,
						CallPrjTitle = crmMobSetting.CallPrjTitle,
						CallCnvsDesc = crmMobSetting.CallCnvsDesc,
						CallAfterSendMessage = crmMobSetting.CallAfterSendMessage,
						CallCnvsReferUserId = crmMobSetting.CallCnvsReferUserId,
						CallCnvsStatusId = crmMobSetting.CallCnvsStatusId,
						CallCnvsTopicId = crmMobSetting.CallCnvsTopicId,
						CallPrjCnvsStatusGroupId = crmMobSetting.CallPrjCnvsStatusGroupId,
						CheckCnvsDesc = crmMobSetting.CheckCnvsDesc,
						CheckCnvsReferUserId = crmMobSetting.CheckCnvsReferUserId,
						CheckCnvsStatusId = crmMobSetting.CheckCnvsStatusId,
						CheckCnvsTopicId = crmMobSetting.CheckCnvsTopicId,
						CheckPrjCnvsStatusGroupId = crmMobSetting.CheckPrjCnvsStatusGroupId,
						CheckPrjTitle = crmMobSetting.CheckPrjTitle
					};
				}
			}
			else
			{
				crmMobSetting.DefUserId = -20;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		GetStatusGroups();
		GetTopicList();
		GetCurrencyUnit();
		GetUsers();
		GetPordPrintFormat();
		GetPordCreditDuration();
		GetPrdPriceGroupList();
		GetWareHouse();
		GetOrderOprs();
		GetPordPayType();
		GetOrdPrintFormat();
		return View(model);
	}

	[ValidateAntiForgeryToken]
	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmsysSetting", ActionName = "actPost")]
	public ActionResult OtherMobSettingInsertEdit(CrmMobSettingIELanguageViewModel model)
	{
		_003C_003Ec__DisplayClass11_0 _003C_003Ec__DisplayClass11_ = new _003C_003Ec__DisplayClass11_0();
		_003C_003Ec__DisplayClass11_.model = model;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		int num = 0;
		GetStatusGroups();
		GetTopicList();
		GetCurrencyUnit();
		GetUsers();
		GetWareHouse();
		GetPrdPriceGroupList();
		GetPordPrintFormat();
		GetPordCreditDuration();
		GetOrderOprs();
		GetPordPayType();
		GetOrdPrintFormat();
		if (base.ModelState.IsValid)
		{
			if (string.IsNullOrWhiteSpace(_003C_003Ec__DisplayClass11_.model.AppName))
			{
				text = text + string.Format(Messages.ErrorEmpty, Labels.MobSettingAppName) + "<br/>";
				num++;
			}
			if (num == 0)
			{
				DateTime now = DateTime.Now;
				DateTime dateTime = now;
				string text2 = now.ToString("yyyyMMdd", new PersianCulture());
				short month = short.Parse(now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				_ = Financial.Get().Id;
				short year = short.Parse(Financial.Get().Id.ToString());
				int userId = UserLogin.CurrentUser.UserId;
				try
				{
					CrmMobSetting crmMobSetting = new CrmMobSetting();
					CRMspSelectFoSetting_Result cRMspSelectFoSetting_Result = new CRMspSelectFoSetting_Result();
					if (_003C_003Ec__DisplayClass11_.model.MobSettingId > 0)
					{
						DbSet<CrmMobSetting> crmMobSetting2 = _dbTbl.CrmMobSetting;
						ParameterExpression val = Expression.Parameter(typeof(CrmMobSetting), "m");
						crmMobSetting = Queryable.FirstOrDefault<CrmMobSetting>((IQueryable<CrmMobSetting>)crmMobSetting2, Expression.Lambda<Func<CrmMobSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass11_, typeof(_003C_003Ec__DisplayClass11_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
					}
					cRMspSelectFoSetting_Result = CRMIdeal.Classes.Helper.Setting.GetFoSetting();
					crmMobSetting.AppName = _003C_003Ec__DisplayClass11_.model.AppName;
					crmMobSetting.UserId = userId;
					crmMobSetting.RegisterDate = dateTime;
					crmMobSetting.RegisterDatePersian = text2;
					crmMobSetting.Month1 = month;
					crmMobSetting.Year1 = year;
					crmMobSetting.AppType = appType;
					crmMobSetting.DefUserId = _003C_003Ec__DisplayClass11_.model.DefUserId;
					crmMobSetting.DefPrjTitle = _003C_003Ec__DisplayClass11_.model.DefPrjTitle;
					crmMobSetting.DefPrjCnvsStatusGroupId = _003C_003Ec__DisplayClass11_.model.DefPrjCnvsStatusGroupId;
					crmMobSetting.DefCnvsTopicId = _003C_003Ec__DisplayClass11_.model.DefCnvsTopicId;
					crmMobSetting.DefCnvsReferUserId = _003C_003Ec__DisplayClass11_.model.DefCnvsReferUserId;
					crmMobSetting.DefCnvsStatusId = _003C_003Ec__DisplayClass11_.model.DefCnvsStatusId;
					crmMobSetting.DefCnvsDesc = _003C_003Ec__DisplayClass11_.model.DefCnvsDesc;
					crmMobSetting.DefPrdPriceGroupId = _003C_003Ec__DisplayClass11_.model.DefPrdPriceGroupId;
					crmMobSetting.DefPordVerifierRequestId = _003C_003Ec__DisplayClass11_.model.DefPordVerifierRequestId;
					crmMobSetting.ShowLastPrdPriceListDate = _003C_003Ec__DisplayClass11_.model.ShowLastPrdPriceListDate;
					crmMobSetting.ShowTomanLabel = _003C_003Ec__DisplayClass11_.model.ShowTomanLabel;
					crmMobSetting.LoginUserId = _003C_003Ec__DisplayClass11_.model.LoginUserId;
					crmMobSetting.LoginPrjTitle = _003C_003Ec__DisplayClass11_.model.LoginPrjTitle;
					crmMobSetting.LoginPrjCnvsStatusGroupId = _003C_003Ec__DisplayClass11_.model.LoginPrjCnvsStatusGroupId;
					crmMobSetting.LoginCnvsTopicId = _003C_003Ec__DisplayClass11_.model.LoginCnvsTopicId;
					crmMobSetting.LoginCnvsReferUserId = _003C_003Ec__DisplayClass11_.model.LoginCnvsReferUserId;
					crmMobSetting.LoginCnvsDesc = _003C_003Ec__DisplayClass11_.model.LoginCnvsDesc;
					crmMobSetting.LoginCnvsStatusId = _003C_003Ec__DisplayClass11_.model.LoginCnvsStatusId;
					crmMobSetting.PordPrjTitle = _003C_003Ec__DisplayClass11_.model.PordPrjTitle;
					crmMobSetting.PordPrjCnvsStatusGroupId = _003C_003Ec__DisplayClass11_.model.PordPrjCnvsStatusGroupId;
					crmMobSetting.PordCnvsTopicId = _003C_003Ec__DisplayClass11_.model.PordCnvsTopicId;
					crmMobSetting.PordCnvsReferUserId = _003C_003Ec__DisplayClass11_.model.PordCnvsReferUserId;
					crmMobSetting.PordCnvsDesc = _003C_003Ec__DisplayClass11_.model.PordCnvsDesc;
					crmMobSetting.PordCnvsStatusId = _003C_003Ec__DisplayClass11_.model.PordCnvsStatusId;
					crmMobSetting.PordChangeCurrDesId = _003C_003Ec__DisplayClass11_.model.PordChangeCurrDesId;
					crmMobSetting.PordCreditDurationId = _003C_003Ec__DisplayClass11_.model.PordCreditDurationId;
					crmMobSetting.PordCurrencyUnitId = _003C_003Ec__DisplayClass11_.model.PordCurrencyUnitId;
					crmMobSetting.PordPrintFormatId = _003C_003Ec__DisplayClass11_.model.PordPrintFormatId;
					if (cRMspSelectFoSetting_Result != null)
					{
						crmMobSetting.PordWHId = cRMspSelectFoSetting_Result.ShpDefWHId;
					}
					crmMobSetting.PordVerifierRequestMsg = _003C_003Ec__DisplayClass11_.model.PordVerifierRequestMsg;
					crmMobSetting.PordSendSmsAfterVerify = _003C_003Ec__DisplayClass11_.model.PordSendSmsAfterVerify;
					crmMobSetting.PordIssueOrdAfterOnLinePay = _003C_003Ec__DisplayClass11_.model.PordIssueOrdAfterOnLinePay;
					crmMobSetting.PordPayTypeId = _003C_003Ec__DisplayClass11_.model.PordPayTypeId;
					crmMobSetting.PordIssueOrdOprId = _003C_003Ec__DisplayClass11_.model.PordIssueOrdOprId;
					crmMobSetting.PordIssueOrdPrintFormId = _003C_003Ec__DisplayClass11_.model.PordIssueOrdPrintFormId;
					crmMobSetting.InstallPrjTitle = _003C_003Ec__DisplayClass11_.model.InstallPrjTitle;
					crmMobSetting.InstallPrjCnvsStatusGroupId = _003C_003Ec__DisplayClass11_.model.InstallPrjCnvsStatusGroupId;
					crmMobSetting.InstallCnvsDesc = _003C_003Ec__DisplayClass11_.model.InstallCnvsDesc;
					crmMobSetting.InstallCnvsReferUserId = _003C_003Ec__DisplayClass11_.model.InstallCnvsReferUserId;
					crmMobSetting.InstallCnvsTopicId = _003C_003Ec__DisplayClass11_.model.InstallCnvsTopicId;
					crmMobSetting.InstallCnvsStatusId = _003C_003Ec__DisplayClass11_.model.InstallCnvsStatusId;
					crmMobSetting.CmpNotifPrjTitle = _003C_003Ec__DisplayClass11_.model.CmpNotifPrjTitle;
					crmMobSetting.CmpNotifCnvsReferUserId = _003C_003Ec__DisplayClass11_.model.CmpNotifCnvsReferUserId;
					crmMobSetting.CmpNotifCnvsStatusId = _003C_003Ec__DisplayClass11_.model.CmpNotifCnvsStatusId;
					crmMobSetting.CmpNotifCnvsDesc = _003C_003Ec__DisplayClass11_.model.CmpNotifCnvsDesc;
					crmMobSetting.CmpNotifCnvsTopicId = _003C_003Ec__DisplayClass11_.model.CmpNotifCnvsTopicId;
					crmMobSetting.CmpNotifPrjCnvsStatusGroupId = _003C_003Ec__DisplayClass11_.model.CmpNotifPrjCnvsStatusGroupId;
					crmMobSetting.EdtReqCnvsReferUserId = _003C_003Ec__DisplayClass11_.model.EdtReqCnvsReferUserId;
					crmMobSetting.EdtReqCnvsTopicId = _003C_003Ec__DisplayClass11_.model.EdtReqCnvsTopicId;
					crmMobSetting.EdtReqCnvsStatusId = _003C_003Ec__DisplayClass11_.model.EdtReqCnvsStatusId;
					crmMobSetting.EdtReqPrjCnvsStatusGroupId = _003C_003Ec__DisplayClass11_.model.EdtReqPrjCnvsStatusGroupId;
					crmMobSetting.EdtReqPrjTitle = _003C_003Ec__DisplayClass11_.model.EdtReqPrjTitle;
					crmMobSetting.EditReqCnvsDesc = _003C_003Ec__DisplayClass11_.model.EditReqCnvsDesc;
					crmMobSetting.CallPrjTitle = _003C_003Ec__DisplayClass11_.model.CallPrjTitle;
					crmMobSetting.CallCnvsDesc = _003C_003Ec__DisplayClass11_.model.CallCnvsDesc;
					crmMobSetting.CallAfterSendMessage = _003C_003Ec__DisplayClass11_.model.CallAfterSendMessage;
					crmMobSetting.CallCnvsReferUserId = _003C_003Ec__DisplayClass11_.model.CallCnvsReferUserId;
					crmMobSetting.CallCnvsStatusId = _003C_003Ec__DisplayClass11_.model.CallCnvsStatusId;
					crmMobSetting.CallCnvsTopicId = _003C_003Ec__DisplayClass11_.model.CallCnvsTopicId;
					crmMobSetting.CallPrjCnvsStatusGroupId = _003C_003Ec__DisplayClass11_.model.CallPrjCnvsStatusGroupId;
					crmMobSetting.CheckCnvsDesc = _003C_003Ec__DisplayClass11_.model.CheckCnvsDesc;
					crmMobSetting.CheckCnvsReferUserId = _003C_003Ec__DisplayClass11_.model.CheckCnvsReferUserId;
					crmMobSetting.CheckCnvsStatusId = _003C_003Ec__DisplayClass11_.model.CheckCnvsStatusId;
					crmMobSetting.CheckCnvsTopicId = _003C_003Ec__DisplayClass11_.model.CheckCnvsTopicId;
					crmMobSetting.CheckPrjCnvsStatusGroupId = _003C_003Ec__DisplayClass11_.model.CheckPrjCnvsStatusGroupId;
					crmMobSetting.CheckPrjTitle = _003C_003Ec__DisplayClass11_.model.CheckPrjTitle;
					if (_003C_003Ec__DisplayClass11_.model.MobSettingId > 0)
					{
						_dbTbl.Entry(crmMobSetting).State = EntityState.Modified;
						_dbTbl.SaveChanges();
						CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmMobSetting");
						base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
					}
					else
					{
						crmMobSetting.LanguageID = result;
						crmMobSetting.FirstRegisterDate = dateTime;
						crmMobSetting.FirstRegisterDatePersian = text2;
						crmMobSetting.FirstRegisterUserId = userId;
						crmMobSetting.GUId = Guid.NewGuid();
						_dbTbl.CrmMobSetting.Add(crmMobSetting);
						_dbTbl.SaveChanges();
						CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmMobSetting");
						_003C_003Ec__DisplayClass11_.model.MobSettingId = crmMobSetting.MobSettingId;
						base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
					text = Messages.msgErrorRunFunction;
				}
			}
		}
		else
		{
			text = Messages.msgErrorOrdFillNotNullColumns;
		}
		if (text != "")
		{
			base.ViewBag.Error = text;
		}
		return View(_003C_003Ec__DisplayClass11_.model);
	}

	public JsonResult GetProjectTitles()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectProjectTitles_Result> list = new List<CRMspSelectProjectTitles_Result>();
		try
		{
			list = Enumerable.ToList<CRMspSelectProjectTitles_Result>((IEnumerable<CRMspSelectProjectTitles_Result>)_db.CRMspSelectProjectTitles(lCID, result));
			if (list == null)
			{
				list = new List<CRMspSelectProjectTitles_Result>();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public JsonResult GetStatusGroups()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		List<SelectListItem> list2 = new List<SelectListItem>();
		List<SelectListItem> list3 = new List<SelectListItem>();
		List<SelectListItem> list4 = new List<SelectListItem>();
		List<SelectListItem> list5 = new List<SelectListItem>();
		List<SelectListItem> list6 = new List<SelectListItem>();
		List<SelectListItem> list7 = new List<SelectListItem>();
		List<SelectListItem> list8 = new List<SelectListItem>();
		List<SelectListItem> list9 = new List<SelectListItem>();
		try
		{
			List<CRMspSelectConversationStatusGroups_Result> list10 = Enumerable.ToList<CRMspSelectConversationStatusGroups_Result>((IEnumerable<CRMspSelectConversationStatusGroups_Result>)_db.CRMspSelectConversationStatusGroups(lCID, result));
			list = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectConversationStatusGroups_Result, SelectListItem>((IEnumerable<CRMspSelectConversationStatusGroups_Result>)list10, (Func<CRMspSelectConversationStatusGroups_Result, SelectListItem>)((CRMspSelectConversationStatusGroups_Result item) => new SelectListItem
			{
				Text = item.ConversationStatusGroup,
				Value = item.ConversationStatusGroupID.ToString()
			})));
			list2 = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectConversationStatusGroups_Result, SelectListItem>((IEnumerable<CRMspSelectConversationStatusGroups_Result>)list10, (Func<CRMspSelectConversationStatusGroups_Result, SelectListItem>)((CRMspSelectConversationStatusGroups_Result item) => new SelectListItem
			{
				Text = item.ConversationStatusGroup,
				Value = item.ConversationStatusGroupID.ToString()
			})));
			list3 = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectConversationStatusGroups_Result, SelectListItem>((IEnumerable<CRMspSelectConversationStatusGroups_Result>)list10, (Func<CRMspSelectConversationStatusGroups_Result, SelectListItem>)((CRMspSelectConversationStatusGroups_Result item) => new SelectListItem
			{
				Text = item.ConversationStatusGroup,
				Value = item.ConversationStatusGroupID.ToString()
			})));
			list4 = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectConversationStatusGroups_Result, SelectListItem>((IEnumerable<CRMspSelectConversationStatusGroups_Result>)list10, (Func<CRMspSelectConversationStatusGroups_Result, SelectListItem>)((CRMspSelectConversationStatusGroups_Result item) => new SelectListItem
			{
				Text = item.ConversationStatusGroup,
				Value = item.ConversationStatusGroupID.ToString()
			})));
			list5 = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectConversationStatusGroups_Result, SelectListItem>((IEnumerable<CRMspSelectConversationStatusGroups_Result>)list10, (Func<CRMspSelectConversationStatusGroups_Result, SelectListItem>)((CRMspSelectConversationStatusGroups_Result item) => new SelectListItem
			{
				Text = item.ConversationStatusGroup,
				Value = item.ConversationStatusGroupID.ToString()
			})));
			list6 = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectConversationStatusGroups_Result, SelectListItem>((IEnumerable<CRMspSelectConversationStatusGroups_Result>)list10, (Func<CRMspSelectConversationStatusGroups_Result, SelectListItem>)((CRMspSelectConversationStatusGroups_Result item) => new SelectListItem
			{
				Text = item.ConversationStatusGroup,
				Value = item.ConversationStatusGroupID.ToString()
			})));
			list7 = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectConversationStatusGroups_Result, SelectListItem>((IEnumerable<CRMspSelectConversationStatusGroups_Result>)list10, (Func<CRMspSelectConversationStatusGroups_Result, SelectListItem>)((CRMspSelectConversationStatusGroups_Result item) => new SelectListItem
			{
				Text = item.ConversationStatusGroup,
				Value = item.ConversationStatusGroupID.ToString()
			})));
			list8 = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectConversationStatusGroups_Result, SelectListItem>((IEnumerable<CRMspSelectConversationStatusGroups_Result>)list10, (Func<CRMspSelectConversationStatusGroups_Result, SelectListItem>)((CRMspSelectConversationStatusGroups_Result item) => new SelectListItem
			{
				Text = item.ConversationStatusGroup,
				Value = item.ConversationStatusGroupID.ToString()
			})));
			list9 = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectConversationStatusGroups_Result, SelectListItem>((IEnumerable<CRMspSelectConversationStatusGroups_Result>)list10, (Func<CRMspSelectConversationStatusGroups_Result, SelectListItem>)((CRMspSelectConversationStatusGroups_Result item) => new SelectListItem
			{
				Text = item.ConversationStatusGroup,
				Value = item.ConversationStatusGroupID.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.StatusGroupslist = list;
		base.ViewBag.DefStatusGroups = list2;
		base.ViewBag.LoginStatusGroups = list3;
		base.ViewBag.PordStatusGroups = list4;
		base.ViewBag.NotifStatusGroups = list5;
		base.ViewBag.InstallStatusGroups = list6;
		base.ViewBag.CallStatusGroups = list7;
		base.ViewBag.EditStatusGroups = list8;
		base.ViewBag.CheckStatusGroups = list9;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public JsonResult ProjectTitleFull(string valPrjTitle = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			valPrjTitle = valPrjTitle ?? "";
			List<CRMspSelectCompanyProjectTitle_Result> list2 = Enumerable.ToList<CRMspSelectCompanyProjectTitle_Result>((IEnumerable<CRMspSelectCompanyProjectTitle_Result>)_db.CRMspSelectCompanyProjectTitle(valPrjTitle, UserLogin.CurrentUser.UserId, lCID, result, result2));
			if (list2 != null)
			{
				list.AddRange(Enumerable.Select<CRMspSelectCompanyProjectTitle_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyProjectTitle_Result>)list2, (Func<CRMspSelectCompanyProjectTitle_Result, SelectListItem>)((CRMspSelectCompanyProjectTitle_Result x) => new SelectListItem
				{
					Text = x.prjTitle,
					Value = x.prjTitle
				})));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.PrjTitleList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public JsonResult GetcnvsStatusList(int statusGroupId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			foreach (CRMspSelectConversationStatus_Result item in Enumerable.ToList<CRMspSelectConversationStatus_Result>((IEnumerable<CRMspSelectConversationStatus_Result>)_db.CRMspSelectConversationStatus(statusGroupId, lCID, result)))
			{
				if (item.StatusDesc == null)
				{
					item.StatusDesc = "";
				}
				list.Add(new SelectListItem
				{
					Text = ((!string.IsNullOrEmpty(item.Status)) ? item.Status : "") + (item.ProgressPercent.HasValue ? (" |" + Labels.cnvsPercentStatus + ": " + item.ProgressPercent) : "") + ((!string.IsNullOrEmpty(item.StatusDesc)) ? (" |" + Labels.cnvsDescStatus + ": " + item.StatusDesc) : ""),
					Value = item.ConversationStatusID.ToString()
				});
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.CnvsStatuslist = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public JsonResult GetTopicList()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		List<SelectListItem> list2 = new List<SelectListItem>();
		List<SelectListItem> list3 = new List<SelectListItem>();
		List<SelectListItem> list4 = new List<SelectListItem>();
		List<SelectListItem> list5 = new List<SelectListItem>();
		List<SelectListItem> list6 = new List<SelectListItem>();
		List<SelectListItem> list7 = new List<SelectListItem>();
		List<SelectListItem> list8 = new List<SelectListItem>();
		List<SelectListItem> list9 = new List<SelectListItem>();
		try
		{
			List<CRMspSelectConversationTopics_Result> list10 = Enumerable.ToList<CRMspSelectConversationTopics_Result>((IEnumerable<CRMspSelectConversationTopics_Result>)_db.CRMspSelectConversationTopics(lCID, result));
			list = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectConversationTopics_Result, SelectListItem>((IEnumerable<CRMspSelectConversationTopics_Result>)list10, (Func<CRMspSelectConversationTopics_Result, SelectListItem>)((CRMspSelectConversationTopics_Result item) => new SelectListItem
			{
				Text = item.Topic,
				Value = item.ConversationTopicsID.ToString()
			})));
			list2 = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectConversationTopics_Result, SelectListItem>((IEnumerable<CRMspSelectConversationTopics_Result>)list10, (Func<CRMspSelectConversationTopics_Result, SelectListItem>)((CRMspSelectConversationTopics_Result item) => new SelectListItem
			{
				Text = item.Topic,
				Value = item.ConversationTopicsID.ToString()
			})));
			list3 = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectConversationTopics_Result, SelectListItem>((IEnumerable<CRMspSelectConversationTopics_Result>)list10, (Func<CRMspSelectConversationTopics_Result, SelectListItem>)((CRMspSelectConversationTopics_Result item) => new SelectListItem
			{
				Text = item.Topic,
				Value = item.ConversationTopicsID.ToString()
			})));
			list4 = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectConversationTopics_Result, SelectListItem>((IEnumerable<CRMspSelectConversationTopics_Result>)list10, (Func<CRMspSelectConversationTopics_Result, SelectListItem>)((CRMspSelectConversationTopics_Result item) => new SelectListItem
			{
				Text = item.Topic,
				Value = item.ConversationTopicsID.ToString()
			})));
			list5 = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectConversationTopics_Result, SelectListItem>((IEnumerable<CRMspSelectConversationTopics_Result>)list10, (Func<CRMspSelectConversationTopics_Result, SelectListItem>)((CRMspSelectConversationTopics_Result item) => new SelectListItem
			{
				Text = item.Topic,
				Value = item.ConversationTopicsID.ToString()
			})));
			list6 = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectConversationTopics_Result, SelectListItem>((IEnumerable<CRMspSelectConversationTopics_Result>)list10, (Func<CRMspSelectConversationTopics_Result, SelectListItem>)((CRMspSelectConversationTopics_Result item) => new SelectListItem
			{
				Text = item.Topic,
				Value = item.ConversationTopicsID.ToString()
			})));
			list7 = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectConversationTopics_Result, SelectListItem>((IEnumerable<CRMspSelectConversationTopics_Result>)list10, (Func<CRMspSelectConversationTopics_Result, SelectListItem>)((CRMspSelectConversationTopics_Result item) => new SelectListItem
			{
				Text = item.Topic,
				Value = item.ConversationTopicsID.ToString()
			})));
			list8 = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectConversationTopics_Result, SelectListItem>((IEnumerable<CRMspSelectConversationTopics_Result>)list10, (Func<CRMspSelectConversationTopics_Result, SelectListItem>)((CRMspSelectConversationTopics_Result item) => new SelectListItem
			{
				Text = item.Topic,
				Value = item.ConversationTopicsID.ToString()
			})));
			list9 = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectConversationTopics_Result, SelectListItem>((IEnumerable<CRMspSelectConversationTopics_Result>)list10, (Func<CRMspSelectConversationTopics_Result, SelectListItem>)((CRMspSelectConversationTopics_Result item) => new SelectListItem
			{
				Text = item.Topic,
				Value = item.ConversationTopicsID.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.ConversationTopicslist = list;
		base.ViewBag.DefCnvcTopic = list2;
		base.ViewBag.LoginCnvcTopic = list3;
		base.ViewBag.PordCnvcTopic = list4;
		base.ViewBag.NotifCnvcTopic = list5;
		base.ViewBag.InstallCnvcTopic = list6;
		base.ViewBag.EditCnvcTopic = list7;
		base.ViewBag.CheckCnvcTopic = list8;
		base.ViewBag.CallCnvcTopic = list9;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public JsonResult GetWareHouse()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		CRMspSelectFoSetting_Result cRMspSelectFoSetting_Result = new CRMspSelectFoSetting_Result();
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			cRMspSelectFoSetting_Result = CRMIdeal.Classes.Helper.Setting.GetFoSetting();
			if (cRMspSelectFoSetting_Result != null)
			{
				list.Add(new SelectListItem
				{
					Text = cRMspSelectFoSetting_Result.ShpDefWH,
					Value = cRMspSelectFoSetting_Result.ShpDefWHId.ToString(),
					Selected = true
				});
			}
			if (Enumerable.Any<SelectListItem>((IEnumerable<SelectListItem>)list))
			{
				list[0].Selected = true;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.WareHouseList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public JsonResult GetCurrencyUnit()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		List<SelectListItem> list2 = new List<SelectListItem>();
		List<SelectListItem> list3 = new List<SelectListItem>();
		try
		{
			List<WSspSelectCurrencyUnits_Result> list4 = Enumerable.ToList<WSspSelectCurrencyUnits_Result>((IEnumerable<WSspSelectCurrencyUnits_Result>)_db.WSspSelectCurrencyUnits(lCID, result));
			list.AddRange(Enumerable.Select<WSspSelectCurrencyUnits_Result, SelectListItem>((IEnumerable<WSspSelectCurrencyUnits_Result>)list4, (Func<WSspSelectCurrencyUnits_Result, SelectListItem>)((WSspSelectCurrencyUnits_Result item) => new SelectListItem
			{
				Text = item.CurrencyUnit,
				Value = item.CurrencyUnitID.ToString(),
				Selected = false
			})));
			list3.AddRange(Enumerable.Select<WSspSelectCurrencyUnits_Result, SelectListItem>((IEnumerable<WSspSelectCurrencyUnits_Result>)list4, (Func<WSspSelectCurrencyUnits_Result, SelectListItem>)((WSspSelectCurrencyUnits_Result item) => new SelectListItem
			{
				Text = item.CurrencyUnit,
				Value = item.CurrencyUnitID.ToString(),
				Selected = false
			})));
			list2.AddRange(Enumerable.Select<WSspSelectCurrencyUnits_Result, SelectListItem>((IEnumerable<WSspSelectCurrencyUnits_Result>)list4, (Func<WSspSelectCurrencyUnits_Result, SelectListItem>)((WSspSelectCurrencyUnits_Result item) => new SelectListItem
			{
				Text = item.CurrencyUnit,
				Value = item.CurrencyUnitID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.CurrencyUnitList = list;
		base.ViewBag.CurrencyUnit = list3;
		base.ViewBag.ChangeCurrUnit = list2;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public JsonResult GetPrdPriceGroupList()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			List<WSspSelectProductPriceGroup_Result> list2 = Enumerable.ToList<WSspSelectProductPriceGroup_Result>((IEnumerable<WSspSelectProductPriceGroup_Result>)_db.WSspSelectProductPriceGroup(lCID, result));
			list.AddRange(Enumerable.Select<WSspSelectProductPriceGroup_Result, SelectListItem>((IEnumerable<WSspSelectProductPriceGroup_Result>)list2, (Func<WSspSelectProductPriceGroup_Result, SelectListItem>)((WSspSelectProductPriceGroup_Result item) => new SelectListItem
			{
				Text = item.ProductPriceGroupName,
				Value = item.ProductPriceGroupID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.PrdPriceGroupList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public JsonResult GetUsers()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		List<SelectListItem> list2 = new List<SelectListItem>();
		List<SelectListItem> list3 = new List<SelectListItem>();
		List<SelectListItem> list4 = new List<SelectListItem>();
		List<SelectListItem> list5 = new List<SelectListItem>();
		List<SelectListItem> list6 = new List<SelectListItem>();
		List<SelectListItem> list7 = new List<SelectListItem>();
		List<SelectListItem> list8 = new List<SelectListItem>();
		List<SelectListItem> list9 = new List<SelectListItem>();
		List<SelectListItem> list10 = new List<SelectListItem>();
		List<SelectListItem> list11 = new List<SelectListItem>();
		List<SelectListItem> list12 = new List<SelectListItem>();
		try
		{
			List<CRMspSelectUsersByIds_Result> list13 = CRMIdeal.Classes.Helper.User.SelectUsersByIds("-10,-20,-103,-102");
			if (list13 != null)
			{
				list13 = Enumerable.ToList<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)Enumerable.OrderByDescending<CRMspSelectUsersByIds_Result, int>((IEnumerable<CRMspSelectUsersByIds_Result>)list13, (Func<CRMspSelectUsersByIds_Result, int>)((CRMspSelectUsersByIds_Result m) => m.UserId)));
			}
			if (list13 != null)
			{
				list.AddRange(Enumerable.Select<CRMspSelectUsersByIds_Result, SelectListItem>((IEnumerable<CRMspSelectUsersByIds_Result>)Enumerable.ToList<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list13), (Func<CRMspSelectUsersByIds_Result, SelectListItem>)((CRMspSelectUsersByIds_Result i) => new SelectListItem
				{
					Text = (i.FullName ?? ""),
					Value = i.UserId.ToString(),
					Selected = false
				})));
				list2.AddRange(Enumerable.Select<CRMspSelectUsersByIds_Result, SelectListItem>((IEnumerable<CRMspSelectUsersByIds_Result>)Enumerable.ToList<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list13), (Func<CRMspSelectUsersByIds_Result, SelectListItem>)((CRMspSelectUsersByIds_Result i) => new SelectListItem
				{
					Text = (i.FullName ?? ""),
					Value = i.UserId.ToString(),
					Selected = false
				})));
				list3.AddRange(Enumerable.Select<CRMspSelectUsersByIds_Result, SelectListItem>((IEnumerable<CRMspSelectUsersByIds_Result>)Enumerable.ToList<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list13), (Func<CRMspSelectUsersByIds_Result, SelectListItem>)((CRMspSelectUsersByIds_Result i) => new SelectListItem
				{
					Text = (i.FullName ?? ""),
					Value = i.UserId.ToString(),
					Selected = false
				})));
				list4.AddRange(Enumerable.Select<CRMspSelectUsersByIds_Result, SelectListItem>((IEnumerable<CRMspSelectUsersByIds_Result>)Enumerable.ToList<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list13), (Func<CRMspSelectUsersByIds_Result, SelectListItem>)((CRMspSelectUsersByIds_Result i) => new SelectListItem
				{
					Text = (i.FullName ?? ""),
					Value = i.UserId.ToString(),
					Selected = false
				})));
				list5.AddRange(Enumerable.Select<CRMspSelectUsersByIds_Result, SelectListItem>((IEnumerable<CRMspSelectUsersByIds_Result>)Enumerable.ToList<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list13), (Func<CRMspSelectUsersByIds_Result, SelectListItem>)((CRMspSelectUsersByIds_Result i) => new SelectListItem
				{
					Text = (i.FullName ?? ""),
					Value = i.UserId.ToString(),
					Selected = false
				})));
				list6.AddRange(Enumerable.Select<CRMspSelectUsersByIds_Result, SelectListItem>((IEnumerable<CRMspSelectUsersByIds_Result>)Enumerable.ToList<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list13), (Func<CRMspSelectUsersByIds_Result, SelectListItem>)((CRMspSelectUsersByIds_Result i) => new SelectListItem
				{
					Text = (i.FullName ?? ""),
					Value = i.UserId.ToString(),
					Selected = false
				})));
				list7.AddRange(Enumerable.Select<CRMspSelectUsersByIds_Result, SelectListItem>((IEnumerable<CRMspSelectUsersByIds_Result>)Enumerable.ToList<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list13), (Func<CRMspSelectUsersByIds_Result, SelectListItem>)((CRMspSelectUsersByIds_Result i) => new SelectListItem
				{
					Text = (i.FullName ?? ""),
					Value = i.UserId.ToString(),
					Selected = false
				})));
				list8.AddRange(Enumerable.Select<CRMspSelectUsersByIds_Result, SelectListItem>((IEnumerable<CRMspSelectUsersByIds_Result>)Enumerable.ToList<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list13), (Func<CRMspSelectUsersByIds_Result, SelectListItem>)((CRMspSelectUsersByIds_Result i) => new SelectListItem
				{
					Text = (i.FullName ?? ""),
					Value = i.UserId.ToString(),
					Selected = false
				})));
				list9.AddRange(Enumerable.Select<CRMspSelectUsersByIds_Result, SelectListItem>((IEnumerable<CRMspSelectUsersByIds_Result>)Enumerable.ToList<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list13), (Func<CRMspSelectUsersByIds_Result, SelectListItem>)((CRMspSelectUsersByIds_Result i) => new SelectListItem
				{
					Text = (i.FullName ?? ""),
					Value = i.UserId.ToString(),
					Selected = false
				})));
				list10.AddRange(Enumerable.Select<CRMspSelectUsersByIds_Result, SelectListItem>((IEnumerable<CRMspSelectUsersByIds_Result>)Enumerable.ToList<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list13), (Func<CRMspSelectUsersByIds_Result, SelectListItem>)((CRMspSelectUsersByIds_Result i) => new SelectListItem
				{
					Text = (i.FullName ?? ""),
					Value = i.UserId.ToString(),
					Selected = false
				})));
				list11.AddRange(Enumerable.Select<CRMspSelectUsersByIds_Result, SelectListItem>((IEnumerable<CRMspSelectUsersByIds_Result>)Enumerable.ToList<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list13), (Func<CRMspSelectUsersByIds_Result, SelectListItem>)((CRMspSelectUsersByIds_Result i) => new SelectListItem
				{
					Text = (i.FullName ?? ""),
					Value = i.UserId.ToString(),
					Selected = false
				})));
				list12.AddRange(Enumerable.Select<CRMspSelectUsersByIds_Result, SelectListItem>((IEnumerable<CRMspSelectUsersByIds_Result>)Enumerable.ToList<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list13), (Func<CRMspSelectUsersByIds_Result, SelectListItem>)((CRMspSelectUsersByIds_Result i) => new SelectListItem
				{
					Text = (i.FullName ?? ""),
					Value = i.UserId.ToString(),
					Selected = false
				})));
			}
			List<CRMspSelectActiveUsers_Result> list14 = Enumerable.ToList<CRMspSelectActiveUsers_Result>((IEnumerable<CRMspSelectActiveUsers_Result>)_db.CRMspSelectActiveUsers(lCID, result, 0));
			list.AddRange(Enumerable.Select<CRMspSelectActiveUsers_Result, SelectListItem>((IEnumerable<CRMspSelectActiveUsers_Result>)list14, (Func<CRMspSelectActiveUsers_Result, SelectListItem>)((CRMspSelectActiveUsers_Result item) => new SelectListItem
			{
				Text = (item.Name ?? ""),
				Value = item.UserId.ToString(),
				Selected = false
			})));
			list2.AddRange(Enumerable.Select<CRMspSelectActiveUsers_Result, SelectListItem>((IEnumerable<CRMspSelectActiveUsers_Result>)list14, (Func<CRMspSelectActiveUsers_Result, SelectListItem>)((CRMspSelectActiveUsers_Result item) => new SelectListItem
			{
				Text = (item.Name ?? ""),
				Value = item.UserId.ToString(),
				Selected = false
			})));
			if (list2 != null && Enumerable.Any<SelectListItem>((IEnumerable<SelectListItem>)list2) && Enumerable.ToList<SelectListItem>(Enumerable.Where<SelectListItem>((IEnumerable<SelectListItem>)list2, (Func<SelectListItem, bool>)((SelectListItem m) => m.Value == "-20"))) != null)
			{
				list2 = Enumerable.ToList<SelectListItem>(Enumerable.Where<SelectListItem>((IEnumerable<SelectListItem>)list2, (Func<SelectListItem, bool>)((SelectListItem m) => m.Value == "-20")));
				if (list2 == null)
				{
					list2 = new List<SelectListItem>();
				}
			}
			list3.AddRange(Enumerable.Select<CRMspSelectActiveUsers_Result, SelectListItem>((IEnumerable<CRMspSelectActiveUsers_Result>)list14, (Func<CRMspSelectActiveUsers_Result, SelectListItem>)((CRMspSelectActiveUsers_Result item) => new SelectListItem
			{
				Text = (item.Name ?? ""),
				Value = item.UserId.ToString(),
				Selected = false
			})));
			list4.AddRange(Enumerable.Select<CRMspSelectActiveUsers_Result, SelectListItem>((IEnumerable<CRMspSelectActiveUsers_Result>)list14, (Func<CRMspSelectActiveUsers_Result, SelectListItem>)((CRMspSelectActiveUsers_Result item) => new SelectListItem
			{
				Text = (item.Name ?? ""),
				Value = item.UserId.ToString(),
				Selected = false
			})));
			list5.AddRange(Enumerable.Select<CRMspSelectActiveUsers_Result, SelectListItem>((IEnumerable<CRMspSelectActiveUsers_Result>)list14, (Func<CRMspSelectActiveUsers_Result, SelectListItem>)((CRMspSelectActiveUsers_Result item) => new SelectListItem
			{
				Text = (item.Name ?? ""),
				Value = item.UserId.ToString(),
				Selected = false
			})));
			list6.AddRange(Enumerable.Select<CRMspSelectActiveUsers_Result, SelectListItem>((IEnumerable<CRMspSelectActiveUsers_Result>)list14, (Func<CRMspSelectActiveUsers_Result, SelectListItem>)((CRMspSelectActiveUsers_Result item) => new SelectListItem
			{
				Text = (item.Name ?? ""),
				Value = item.UserId.ToString(),
				Selected = false
			})));
			list7.AddRange(Enumerable.Select<CRMspSelectActiveUsers_Result, SelectListItem>((IEnumerable<CRMspSelectActiveUsers_Result>)list14, (Func<CRMspSelectActiveUsers_Result, SelectListItem>)((CRMspSelectActiveUsers_Result item) => new SelectListItem
			{
				Text = (item.Name ?? ""),
				Value = item.UserId.ToString(),
				Selected = false
			})));
			list8.AddRange(Enumerable.Select<CRMspSelectActiveUsers_Result, SelectListItem>((IEnumerable<CRMspSelectActiveUsers_Result>)list14, (Func<CRMspSelectActiveUsers_Result, SelectListItem>)((CRMspSelectActiveUsers_Result item) => new SelectListItem
			{
				Text = (item.Name ?? ""),
				Value = item.UserId.ToString(),
				Selected = false
			})));
			list9.AddRange(Enumerable.Select<CRMspSelectActiveUsers_Result, SelectListItem>((IEnumerable<CRMspSelectActiveUsers_Result>)list14, (Func<CRMspSelectActiveUsers_Result, SelectListItem>)((CRMspSelectActiveUsers_Result item) => new SelectListItem
			{
				Text = (item.Name ?? ""),
				Value = item.UserId.ToString(),
				Selected = false
			})));
			list10.AddRange(Enumerable.Select<CRMspSelectActiveUsers_Result, SelectListItem>((IEnumerable<CRMspSelectActiveUsers_Result>)list14, (Func<CRMspSelectActiveUsers_Result, SelectListItem>)((CRMspSelectActiveUsers_Result item) => new SelectListItem
			{
				Text = (item.Name ?? ""),
				Value = item.UserId.ToString(),
				Selected = false
			})));
			list11.AddRange(Enumerable.Select<CRMspSelectActiveUsers_Result, SelectListItem>((IEnumerable<CRMspSelectActiveUsers_Result>)list14, (Func<CRMspSelectActiveUsers_Result, SelectListItem>)((CRMspSelectActiveUsers_Result item) => new SelectListItem
			{
				Text = (item.Name ?? ""),
				Value = item.UserId.ToString(),
				Selected = false
			})));
			list12.AddRange(Enumerable.Select<CRMspSelectActiveUsers_Result, SelectListItem>((IEnumerable<CRMspSelectActiveUsers_Result>)list14, (Func<CRMspSelectActiveUsers_Result, SelectListItem>)((CRMspSelectActiveUsers_Result item) => new SelectListItem
			{
				Text = (item.Name ?? ""),
				Value = item.UserId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.UsersList = list;
		base.ViewBag.DefUSer = list2;
		base.ViewBag.DefReferUSer = list3;
		base.ViewBag.LoginUser = list4;
		base.ViewBag.LoginReferUser = list5;
		base.ViewBag.PordReferUser = list6;
		base.ViewBag.PordReqUser = list7;
		base.ViewBag.NotifRefetUser = list8;
		base.ViewBag.InstallReferUser = list9;
		base.ViewBag.CheckReferUser = list10;
		base.ViewBag.EditReferUser = list11;
		base.ViewBag.CallReferUser = list12;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public JsonResult GetPordCreditDuration()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			list = Enumerable.ToList<SelectListItem>(Enumerable.Select<WSspSelectCreditDuration_Result, SelectListItem>((IEnumerable<WSspSelectCreditDuration_Result>)Enumerable.ToList<WSspSelectCreditDuration_Result>((IEnumerable<WSspSelectCreditDuration_Result>)_db.WSspSelectCreditDuration(lCID, result)), (Func<WSspSelectCreditDuration_Result, SelectListItem>)((WSspSelectCreditDuration_Result item) => new SelectListItem
			{
				Text = item.CreditDuration,
				Value = item.CreditDurationID.ToString()
			})));
			base.ViewBag.PordCreditDurationList = list;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public JsonResult GetPordPrintFormat()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			list = Enumerable.ToList<SelectListItem>(Enumerable.Select<spSelectPrintFormat_Result, SelectListItem>((IEnumerable<spSelectPrintFormat_Result>)CRMIdeal.Classes.Helper.PrintFormat.GetspPrintFortants(result2, 1), (Func<spSelectPrintFormat_Result, SelectListItem>)((spSelectPrintFormat_Result item) => new SelectListItem
			{
				Text = item.Title,
				Value = item.PrintFormatID.ToString()
			})));
			base.ViewBag.PordPrintFormatList = list;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public JsonResult GetOrdPrintFormat()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			list = Enumerable.ToList<SelectListItem>(Enumerable.Select<spSelectPrintFormat_Result, SelectListItem>((IEnumerable<spSelectPrintFormat_Result>)CRMIdeal.Classes.Helper.PrintFormat.GetspPrintFortants(result2, 2), (Func<spSelectPrintFormat_Result, SelectListItem>)((spSelectPrintFormat_Result item) => new SelectListItem
			{
				Text = item.Title,
				Value = item.PrintFormatID.ToString()
			})));
			base.ViewBag.PordIssueOrdPrintForm = list;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public JsonResult GetPordPayType()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int value = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserId : 0);
			list = Enumerable.ToList<SelectListItem>(Enumerable.Select<WSspSelectOrderPaymentTypes_Result, SelectListItem>((IEnumerable<WSspSelectOrderPaymentTypes_Result>)Enumerable.ToList<WSspSelectOrderPaymentTypes_Result>((IEnumerable<WSspSelectOrderPaymentTypes_Result>)_db.WSspSelectOrderPaymentTypes(lCID, result, value)), (Func<WSspSelectOrderPaymentTypes_Result, SelectListItem>)((WSspSelectOrderPaymentTypes_Result item) => new SelectListItem
			{
				Text = item.ordpayType,
				Value = item.OrderPaymentTypeId.ToString()
			})));
			base.ViewBag.PordPayType = list;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public JsonResult GetOrderOprs()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			List<WSspSelectOrderOpr_Result> list2 = Order.SelectOrderOpr();
			if (list2 != null)
			{
				list = Enumerable.ToList<SelectListItem>(Enumerable.Select<WSspSelectOrderOpr_Result, SelectListItem>((IEnumerable<WSspSelectOrderOpr_Result>)list2, (Func<WSspSelectOrderOpr_Result, SelectListItem>)((WSspSelectOrderOpr_Result item) => new SelectListItem
				{
					Text = item.Name,
					Value = item.OrderOprID.ToString()
				})));
			}
			base.ViewBag.PordIssueOrdOpr = list;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(list, JsonRequestBehavior.AllowGet);
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
