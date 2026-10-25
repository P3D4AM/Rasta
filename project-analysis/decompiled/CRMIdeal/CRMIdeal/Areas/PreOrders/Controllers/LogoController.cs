using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CRM.General.Security;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Cache.User;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace CRMIdeal.Areas.PreOrders.Controllers;

public class LogoController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	public ActionResult Index(int position)
	{
		string text = "";
		string text2 = "";
		int num = 0;
		switch (position)
		{
		case 1:
			text = "frmMain";
			text2 = "actDefineLogo";
			num = 0;
			break;
		case 2:
			text = "frmPreOrderDataEntry";
			text2 = "actInsertLLPicture";
			num = 1;
			break;
		case 3:
			text = "frmPreOrderDataEntry";
			text2 = "actInsertLRPicture";
			num = 1;
			break;
		case 4:
			text = "frmPreOrderDefultSetting";
			text2 = "actInsertLLPicture";
			num = 1;
			break;
		case 5:
			text = "frmPreOrderDefultSetting";
			text2 = "actInsertLRPicture";
			num = 1;
			break;
		case 6:
			text = "frmOrderDataEntry";
			text2 = "actInsertLLPicture";
			num = 1;
			break;
		case 7:
			text = "frmOrderDataEntry";
			text2 = "actInsertLRPicture";
			num = 1;
			break;
		case 8:
			text = "frmOrderDefultSetting";
			text2 = "actInsertLLPicture";
			num = 1;
			break;
		case 9:
			text = "frmOrderDefultSetting";
			text2 = "actInsertLRPicture";
			num = 1;
			break;
		default:
			return RedirectToAction("Login", "Account", (object)new
			{
				area = "",
				d = DateTime.Now
			});
		}
		if (!UserLogin.IsUserAccess(text, text2, UserLogin.CurrentUser))
		{
			return RedirectToAction("Login", "Account", (object)new
			{
				area = "",
				d = DateTime.Now
			});
		}
		base.ViewBag.LayoutName = num;
		base.ViewBag.Position = position;
		WSLogoLanguageViewModel wSLogoLanguageViewModel = new WSLogoLanguageViewModel();
		wSLogoLanguageViewModel.UserId = position;
		wSLogoLanguageViewModel.FPId = num;
		return View(wSLogoLanguageViewModel);
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public ActionResult Index(WSLogoLanguageViewModel vm, HttpPostedFileBase LogoUrlUpload)
	{
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
		if (defLangID <= 0)
		{
			defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(vm.LogoDescription_Lang))
		{
			list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(vm.LogoDescription_Lang);
		}
		list.Add(new CommonMultiLanguageViewModel
		{
			Value = vm.LogoDescription,
			LanguageId = lCID
		});
		string text = "";
		if (vm.LogoDescription == null && vm.LogoDescription == "")
		{
			text = text + Messages.CheckTitle + "<br/>";
		}
		else if (!checkMultiLanguage(vm.LogoDescription, list))
		{
			text = text + Messages.CheckTitleLang + "<br>";
		}
		if (text != "")
		{
			base.ModelState.AddModelError("error", text);
			return View(vm);
		}
		int fPId = vm.FPId;
		int userId = vm.UserId;
		base.ViewBag.LayoutName = fPId;
		base.ViewBag.Position = userId;
		try
		{
			if (!UserLogin.IsUserAccess("frmDefineLogoDataEntry", "actPost", UserLogin.CurrentUser))
			{
				return RedirectToAction("Login", "Account", (object)new
				{
					area = "",
					d = DateTime.Now
				});
			}
			if (base.ModelState.IsValid)
			{
				if (LogoUrlUpload == null)
				{
					base.ModelState.AddModelError("error", Messages.frmErrorNotFileSelected);
					return View(vm);
				}
				string text2 = LogoUrlUpload.ContentType.ToLower();
				string text3 = Path.GetExtension(LogoUrlUpload.FileName);
				if (text3 != null)
				{
					text3 = text3.ToLower();
				}
				if ((text2 != "image/jpg" && text2 != "image/jpeg" && text2 != "image/pjpeg" && text2 != "image/gif" && text2 != "image/x-png" && text2 != "image/png") || (text3 != ".jpg" && text3 != ".png" && text3 != ".gif" && text3 != ".jpeg"))
				{
					base.ModelState.AddModelError("error", Messages.frmErrorNotImageFile);
					return View(vm);
				}
				if (LogoUrlUpload.ContentLength / 1024 > Configuration.MaxImageSizeForUploadKb)
				{
					base.ModelState.AddModelError("error", string.Format(Messages.frmErrorMaxImageSizeForUpload, Configuration.MaxImageSizeForUploadKb));
					return View(vm);
				}
				DateTime now = DateTime.Now;
				WSLogo wSLogo = new WSLogo
				{
					UserId = UserLogin.CurrentUser.UserId,
					RegisterDate = now,
					RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture()),
					Month1 = short.Parse(now.ToString("MM", new PersianCulture())),
					AppType = Configuration.AppType,
					FPId = Financial.Get().Id,
					GUId = Guid.NewGuid(),
					LanguageID = defLangID,
					FirstRegisterUserId = UserLogin.CurrentUser.UserId,
					FirstRegisterDate = now,
					FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture()),
					LogoDescription = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : "")
				};
				wSLogo.Logo = ImageManager.CompressHttpPostedFileBase(new ImageManager.ImageParam
				{
					HttpPostedFileBase_Var = LogoUrlUpload
				});
				_dbTbl.WSLogo.Add(wSLogo);
				_dbTbl.SaveChanges();
				foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != defLangID))))
				{
					WSLogo_Lang wSLogo_Lang = new WSLogo_Lang();
					wSLogo_Lang.LanguageID = lang.LanguageID;
					wSLogo_Lang.LogoID = wSLogo.LogoID;
					wSLogo_Lang.LogoDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
					_dbTbl.WSLogo_Lang.Add(wSLogo_Lang);
					_dbTbl.SaveChanges();
				}
				CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSLogo");
				base.ViewBag.Update = true;
				vm = new WSLogoLanguageViewModel
				{
					LogoDescription = ""
				};
			}
			else
			{
				base.ModelState.AddModelError("error", Messages.frmErrorMessage);
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
			base.ModelState.AddModelError("error", Messages.frmErrorMessage);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			base.ModelState.AddModelError("error", Messages.frmErrorMessage);
		}
		vm.UserId = userId;
		vm.FPId = fPId;
		return View(vm);
	}

	[AjaxOnly]
	public ActionResult Logo_Read([DataSourceRequest] DataSourceRequest request)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspSelectLogo_Result> list = new List<WSspSelectLogo_Result>();
		try
		{
			list = Enumerable.ToList<WSspSelectLogo_Result>((IEnumerable<WSspSelectLogo_Result>)_db.WSspSelectLogo(lCID, result));
			foreach (WSspSelectLogo_Result item in list)
			{
				if (string.IsNullOrEmpty(item.AppType))
				{
					item.AppType = Configuration.AppType;
				}
				item.AppType = Configuration.GetAppType(item.AppType);
				string text = item.FirstRegisterUser ?? "";
				string text2 = (item.FirstRegisterDate.HasValue ? item.FirstRegisterDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
				item.FirstRegisterDatePersian = Labels.frmFirstRegisterUser + ": " + text + " (" + text2 + ")";
				string text3 = item.EditUser ?? "";
				_ = item.RegisterDate;
				string text4 = item.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				item.RegisterDatePersian = Labels.frmRegisterUser + ": " + text3 + " (" + Labels.AppType + ":" + item.AppType + ")  (" + text4 + ")";
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(((IEnumerable)list).ToDataSourceResult(request));
	}

	[AjaxOnly]
	public JsonResult DeleteLogo(int id)
	{
		List<WSspSelectLogo_Result> list = new List<WSspSelectLogo_Result>();
		try
		{
			if (_dbTbl.WSLogo.Find(id) != null)
			{
				try
				{
					mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)Enumerable.ToList<mct_Result>((IEnumerable<mct_Result>)_db.WSspDeleteWSLogo(id)));
					if (mct_Result != null)
					{
						_ = mct_Result.Result;
						_ = 0;
					}
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSLogo");
					int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
					if (result <= 0)
					{
						result = 1065;
					}
					int lCID = Thread.CurrentThread.CurrentCulture.LCID;
					list = Enumerable.ToList<WSspSelectLogo_Result>((IEnumerable<WSspSelectLogo_Result>)_db.WSspSelectLogo(lCID, result));
					foreach (WSspSelectLogo_Result item in list)
					{
						if (string.IsNullOrEmpty(item.AppType))
						{
							item.AppType = Configuration.AppType;
						}
						item.AppType = Configuration.GetAppType(item.AppType);
						string text = item.FirstRegisterUser ?? "";
						string text2 = (item.FirstRegisterDate.HasValue ? item.FirstRegisterDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
						item.FirstRegisterDatePersian = Labels.frmFirstRegisterUser + ": " + text + " (" + text2 + ")";
						string text3 = item.EditUser ?? "";
						_ = item.RegisterDate;
						string text4 = item.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
						item.RegisterDatePersian = Labels.frmRegisterUser + ": " + text3 + " (" + Labels.AppType + ":" + item.AppType + ")  (" + text4 + ")";
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
			}
		}
		catch (Exception e3)
		{
			ErrorSignal.FromCurrentContext().Raise(e3);
		}
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public bool checkMultiLanguage(string defaultValue, List<CommonMultiLanguageViewModel> list)
	{
		bool result = true;
		List<CRMspSelectUserLanguages_Result> list2 = CRMIdeal.Cache.User.Language.Get();
		bool isCurrentUserAllowCopyOtherLanguage = UserLogin.IsCurrentUserAllowCopyOtherLanguage;
		foreach (Languages itemLang in CRMIdeal.Cache.Setting.Language.Get())
		{
			CommonMultiLanguageViewModel commonMultiLanguageViewModel = Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == itemLang.LanguageID));
			if (commonMultiLanguageViewModel == null)
			{
				if (Enumerable.Any<CRMspSelectUserLanguages_Result>((IEnumerable<CRMspSelectUserLanguages_Result>)list2, (Func<CRMspSelectUserLanguages_Result, bool>)((CRMspSelectUserLanguages_Result c) => c.LanguageID == itemLang.LanguageID)))
				{
					if (isCurrentUserAllowCopyOtherLanguage)
					{
						list.Add(new CommonMultiLanguageViewModel
						{
							LanguageId = itemLang.LanguageID,
							Value = defaultValue
						});
					}
					else
					{
						result = false;
					}
				}
				else
				{
					list.Add(new CommonMultiLanguageViewModel
					{
						LanguageId = itemLang.LanguageID,
						Value = defaultValue
					});
				}
			}
			else
			{
				if (!string.IsNullOrEmpty(commonMultiLanguageViewModel.Value))
				{
					continue;
				}
				if (Enumerable.Any<CRMspSelectUserLanguages_Result>((IEnumerable<CRMspSelectUserLanguages_Result>)list2, (Func<CRMspSelectUserLanguages_Result, bool>)((CRMspSelectUserLanguages_Result c) => c.LanguageID == itemLang.LanguageID)))
				{
					if (isCurrentUserAllowCopyOtherLanguage)
					{
						commonMultiLanguageViewModel.Value = defaultValue;
					}
					else
					{
						result = false;
					}
				}
				else
				{
					commonMultiLanguageViewModel.Value = defaultValue;
				}
			}
		}
		return result;
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		base.Dispose(disposing);
	}
}
