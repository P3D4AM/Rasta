using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Threading;
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
using Newtonsoft.Json;

namespace CRMIdeal.Areas.FormBase.Controllers;

public class SaleCentersController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actDefineSaleCenter")]
	public ActionResult Index()
	{
		return View();
	}

	[LoginAuthorize]
	[DynamicAuthorize(ControllerName = "frmDefineBaseInfo", ActionName = "actInsert,actEdit")]
	public ActionResult InsertEdit(int id = 0)
	{
		return View(SelectSaleCenterWithId(id));
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmDefineBaseInfo", ActionName = "actInsert,actEdit")]
	public ActionResult InsertEdit(WSspSelectSaleCenterWithId_Result vm)
	{
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		string text = "";
		string text2 = "";
		int num = 0;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int currLangID = Thread.CurrentThread.CurrentCulture.LCID;
			int id = Financial.Get().Id;
			DateTime now = DateTime.Now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short value = short.Parse(now.ToString("MM", new PersianCulture()));
			int userId = UserLogin.CurrentUser.UserId;
			string appType = Configuration.AppType;
			if (vm.ReferUserId.GetValueOrDefault() == 0)
			{
				vm.ReferUserId = null;
			}
			if (vm.ParentId.GetValueOrDefault() > 0)
			{
				vm.SaleCenterTitle = null;
				vm.SaleCenterTitle = null;
			}
			if (string.IsNullOrWhiteSpace(vm.SaleCenterName))
			{
				text = text + string.Format(Messages.ErrorEmpty, Labels.cnvsStatusResultTitle) + "<br/>";
				num++;
			}
			else
			{
				List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(vm.SaleCenterName_Lang))
				{
					list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(vm.SaleCenterName_Lang);
				}
				list.Add(new CommonMultiLanguageViewModel
				{
					Value = vm.SaleCenterName,
					LanguageId = currLangID
				});
				if (!checkMultiLanguage(vm.SaleCenterName, list))
				{
					text = text + string.Format(Messages.CheckFieldInLang, Labels.cnvsStatusResultTitle) + "<br>";
					num++;
				}
				vm.SaleCenterName_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID))));
			}
			if (num == 0)
			{
				if (vm.SaleCenterId == 0)
				{
					ObjectParameter objectParameter = new ObjectParameter("InsertedId", 0);
					_dbII.WSspInsertSaleCenter(vm.SaleCenterName, vm.SaleCenterName_Lang, vm.ParentId, vm.StartTime, vm.EndTime, appType, id, value, userId, now, registerDatePersian, currLangID, result, objectParameter, vm.ReferUserId, vm.SaleCenterTitle, vm.SaleCenterTitle_Lang);
					if (objectParameter != null)
					{
						int result2 = 0;
						int.TryParse(objectParameter.Value.ToString(), out result2);
						switch (result2)
						{
						case 0:
							text = Messages.msgErrorOperationFailed;
							break;
						case -1:
							text = Messages.RedundancyMessage;
							break;
						default:
							text2 = Messages.msgOperationCompleted;
							break;
						}
					}
				}
				else
				{
					_dbII.WSspUpdateSaleCenter(vm.SaleCenterId, vm.SaleCenterName, vm.SaleCenterName_Lang, vm.ParentId, vm.StartTime, vm.EndTime, appType, id, value, userId, now, registerDatePersian, currLangID, result, vm.ReferUserId, vm.SaleCenterTitle, vm.SaleCenterTitle_Lang);
					text2 = Messages.msgOperationCompleted;
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
			text = "Error: " + ex.Message;
		}
		base.ViewBag.Error = text;
		base.ViewBag.Successfull = text2;
		base.ViewBag.SaleCentersJs = SelectSaleCentersJs();
		return View(vm);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmDefineBaseInfo", ActionName = "actDelete")]
	public string Delete(int id = 0)
	{
		string result = "";
		try
		{
			mct_II_Result mct_II_Result = Enumerable.FirstOrDefault<mct_II_Result>((IEnumerable<mct_II_Result>)_dbII.WSspDeleteSaleCenter(id));
			if (mct_II_Result != null)
			{
				if (mct_II_Result.Result == 0)
				{
					result = Messages.msgErrorOperationFailed;
				}
				else if (mct_II_Result.Result == -1)
				{
					result = Messages.RedundancyMessage;
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
			result = "Error: " + ex.Message;
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public List<WSspSelectSaleCenters_Result> SelectSaleCenters()
	{
		List<WSspSelectSaleCenters_Result> result = new List<WSspSelectSaleCenters_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<WSspSelectSaleCenters_Result> list = Enumerable.ToList<WSspSelectSaleCenters_Result>((IEnumerable<WSspSelectSaleCenters_Result>)_db.WSspSelectSaleCenters(lCID, result2));
			if (list != null)
			{
				foreach (WSspSelectSaleCenters_Result item in list)
				{
					item.FirstRegisterDatePersian = item.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm");
					item.RegisterDatePersian = item.RegisterDate.ToString("yyyy/MM/dd HH:mm");
				}
				result = list;
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public string SelectSaleCentersJs()
	{
		return JsonConvert.SerializeObject(SelectSaleCenters());
	}

	[AjaxOnly]
	public ActionResult SaleCenters_Read([DataSourceRequest] DataSourceRequest request)
	{
		return Json(((IEnumerable)SelectSaleCenters()).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[HttpPost]
	[LoginAuthorize]
	public WSspSelectSaleCenterWithId_Result SelectSaleCenterWithId(int id = 0)
	{
		WSspSelectSaleCenterWithId_Result result = new WSspSelectSaleCenterWithId_Result();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (id != 0)
			{
				WSspSelectSaleCenterWithId_Result wSspSelectSaleCenterWithId_Result = Enumerable.FirstOrDefault<WSspSelectSaleCenterWithId_Result>((IEnumerable<WSspSelectSaleCenterWithId_Result>)_dbII.WSspSelectSaleCenterWithId(id, lCID, result2));
				if (wSspSelectSaleCenterWithId_Result != null)
				{
					wSspSelectSaleCenterWithId_Result.FirstRegisterDatePersian = wSspSelectSaleCenterWithId_Result.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm");
					wSspSelectSaleCenterWithId_Result.RegisterDatePersian = wSspSelectSaleCenterWithId_Result.RegisterDate.ToString("yyyy/MM/dd HH:mm");
					result = wSspSelectSaleCenterWithId_Result;
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	public string GetSaleCenterReferUser()
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
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			List<CRMspSelectActiveUsers_Result> list2 = CRMIdeal.Classes.Helper.User.SelectActiveUsers(result2);
			if (list2 != null && Enumerable.Any<CRMspSelectActiveUsers_Result>((IEnumerable<CRMspSelectActiveUsers_Result>)list2))
			{
				list.AddRange(Enumerable.Select<CRMspSelectActiveUsers_Result, SelectListItem>((IEnumerable<CRMspSelectActiveUsers_Result>)list2, (Func<CRMspSelectActiveUsers_Result, SelectListItem>)((CRMspSelectActiveUsers_Result item) => new SelectListItem
				{
					Value = item.UserId.ToString(),
					Text = (item.Name ?? "")
				})));
			}
			if (list == null)
			{
				list = new List<SelectListItem>();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return JsonConvert.SerializeObject(list);
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
		_dbI.Dispose();
		base.Dispose(disposing);
	}
}
