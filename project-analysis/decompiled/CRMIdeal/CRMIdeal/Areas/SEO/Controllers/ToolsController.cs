using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using CRM.Models;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.SEO.Controllers;

public class ToolsController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIEntities _db_I = new CRMSpIEntities();

	private readonly CRMSpIIEntities _db_II = new CRMSpIIEntities();

	[LoginAuthorize]
	public ActionResult Index(CRMIdeal.Classes.Helper.SEO.Modes mode, string ids = "")
	{
		SeoLanguageViewModel seoLanguageViewModel = new SeoLanguageViewModel();
		string objNames = "";
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		switch (mode)
		{
		case CRMIdeal.Classes.Helper.SEO.Modes.PrdFromFG:
			objNames = string.Join(",", Enumerable.Select<WSspSelectProductFirstGroupWithIds_Result, string>(Enumerable.Where<WSspSelectProductFirstGroupWithIds_Result>((IEnumerable<WSspSelectProductFirstGroupWithIds_Result>)Enumerable.ToList<WSspSelectProductFirstGroupWithIds_Result>((IEnumerable<WSspSelectProductFirstGroupWithIds_Result>)_db_II.WSspSelectProductFirstGroupWithIds(ids, ",", lCID, result)), (Func<WSspSelectProductFirstGroupWithIds_Result, bool>)((WSspSelectProductFirstGroupWithIds_Result x) => !string.IsNullOrWhiteSpace(x.FGName))), (Func<WSspSelectProductFirstGroupWithIds_Result, string>)((WSspSelectProductFirstGroupWithIds_Result x) => x.FGName)));
			break;
		case CRMIdeal.Classes.Helper.SEO.Modes.PrdFromSG:
			objNames = string.Join(",", Enumerable.Select<WSspSelectProductSecondGroupWithIds_Result, string>(Enumerable.Where<WSspSelectProductSecondGroupWithIds_Result>((IEnumerable<WSspSelectProductSecondGroupWithIds_Result>)Enumerable.ToList<WSspSelectProductSecondGroupWithIds_Result>((IEnumerable<WSspSelectProductSecondGroupWithIds_Result>)_db_I.WSspSelectProductSecondGroupWithIds(ids, ",", lCID, result)), (Func<WSspSelectProductSecondGroupWithIds_Result, bool>)((WSspSelectProductSecondGroupWithIds_Result x) => !string.IsNullOrWhiteSpace(x.SGName))), (Func<WSspSelectProductSecondGroupWithIds_Result, string>)((WSspSelectProductSecondGroupWithIds_Result x) => x.SGName)));
			break;
		case CRMIdeal.Classes.Helper.SEO.Modes.PrdSGFromFG:
			objNames = string.Join(",", Enumerable.Select<WSspSelectProductFirstGroupWithIds_Result, string>(Enumerable.Where<WSspSelectProductFirstGroupWithIds_Result>((IEnumerable<WSspSelectProductFirstGroupWithIds_Result>)Enumerable.ToList<WSspSelectProductFirstGroupWithIds_Result>((IEnumerable<WSspSelectProductFirstGroupWithIds_Result>)_db_II.WSspSelectProductFirstGroupWithIds(ids, ",", lCID, result)), (Func<WSspSelectProductFirstGroupWithIds_Result, bool>)((WSspSelectProductFirstGroupWithIds_Result x) => !string.IsNullOrWhiteSpace(x.FGName))), (Func<WSspSelectProductFirstGroupWithIds_Result, string>)((WSspSelectProductFirstGroupWithIds_Result x) => x.FGName)));
			break;
		default:
			mode = CRMIdeal.Classes.Helper.SEO.Modes.None;
			break;
		case CRMIdeal.Classes.Helper.SEO.Modes.Prd:
		case CRMIdeal.Classes.Helper.SEO.Modes.PrdFG:
		case CRMIdeal.Classes.Helper.SEO.Modes.PrdSG:
			break;
		}
		seoLanguageViewModel.Mode = (int)mode;
		seoLanguageViewModel.ObjIds = ids;
		seoLanguageViewModel.ObjNames = objNames;
		return View(seoLanguageViewModel);
	}

	[HttpPost]
	[LoginAuthorize]
	public string SearchObject(CRMIdeal.Classes.Helper.SEO.Modes mode, List<SelectListItem> p = null)
	{
		List<SelectListItem> value = new List<SelectListItem>();
		try
		{
			_ = 1000;
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return JsonConvert.SerializeObject(value);
	}

	[HttpPost]
	[LoginAuthorize]
	public string InsertEdit(SeoLanguageViewModel vm)
	{
		string result = "";
		List<string> list = new List<string>();
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		if (result2 <= 0)
		{
			result2 = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		if (vm.Mode == 1000)
		{
			result = JsonConvert.SerializeObject(UpdateProducts(vm));
		}
		else if (vm.Mode == 1005)
		{
			result = JsonConvert.SerializeObject(UpdateProductsFromFG(vm));
		}
		else if (vm.Mode == 1010)
		{
			result = JsonConvert.SerializeObject(UpdateProductsFromSG(vm));
		}
		else if (vm.Mode == 2000)
		{
			result = JsonConvert.SerializeObject(UpdateProductFirstGroup(vm));
		}
		else if (vm.Mode == 3000)
		{
			result = JsonConvert.SerializeObject(UpdateProductSecondGroup(vm));
		}
		else if (vm.Mode == 3005)
		{
			string[] array = vm.ObjIds?.Split(new char[1] { ',' });
			foreach (string text in array)
			{
				if (!string.IsNullOrWhiteSpace(text))
				{
					list.AddRange(Enumerable.Select<WSspSelectProductSecondGroup_Result, string>((IEnumerable<WSspSelectProductSecondGroup_Result>)Enumerable.ToList<WSspSelectProductSecondGroup_Result>((IEnumerable<WSspSelectProductSecondGroup_Result>)_db.WSspSelectProductSecondGroup(int.Parse(text), lCID, result2)), (Func<WSspSelectProductSecondGroup_Result, string>)((WSspSelectProductSecondGroup_Result x) => x.PrdSecondGroupID.ToString())));
				}
			}
			vm.ObjIds = string.Join(",", list);
			if (!string.IsNullOrWhiteSpace(vm.ObjIds))
			{
				result = JsonConvert.SerializeObject(UpdateProductSecondGroup(vm));
			}
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public AdvanceResultItemViewModel UpdateProducts(SeoLanguageViewModel vm)
	{
		AdvanceResultItemViewModel advanceResultItemViewModel = new AdvanceResultItemViewModel();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			int userId = UserLogin.CurrentUser.UserId;
			short value2 = short.Parse(Financial.Get().Id.ToString());
			short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			_db_II.CRMspUpdateProductShpSeo(vm.ObjIds, vm.SeoIsActive_Enabled, vm.SeoIsActive, vm.SeoTitle_Enabled, vm.SeoTitleMode, vm.SeoTitle, vm.SeoTitle_Lang, vm.SeoDescription_Enabled, vm.SeoDescription, vm.SeoDescription_Lang, vm.SeoHttpEquiv_Enabled, vm.SeoHttpEquiv, vm.SeoExpires_Enabled, vm.SeoExpires, vm.SeoGoogleNotranslate_Enabled, vm.SeoGoogleNotranslate, vm.SeoDistribution_Enabled, vm.SeoDistribution, vm.SeoRobots_Enabled, vm.SeoRobots, vm.SeoRating_Enabled, vm.SeoRating, vm.SeoAuthor_Enabled, vm.SeoAuthor, vm.SeoAuthor_Lang, vm.SeoIsUseSocialNetwork_Enabled, vm.SeoIsUseSocialNetwork, vm.SeoMobileOptimized_Enabled, vm.SeoMobileOptimized, vm.SeoCopyright_Enabled, vm.SeoCopyright, vm.SeoCopyright_Lang, vm.SeoUseDefault_Enabled, vm.SeoUseDefault, vm.SeoKeywords_Enabled, vm.SeoKeywords, vm.SeoKeywords_Lang, vm.SeoFAQ_Enabled, vm.SeoFAQ, vm.SeoFAQ_Lang, userId, value2, value3, value, registerDatePersian, appType, lCID, result);
			advanceResultItemViewModel.Status = CommonResultStatusViewModel.Success;
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
			advanceResultItemViewModel.Status = CommonResultStatusViewModel.Error;
			advanceResultItemViewModel.Errors.Add(ex.Message);
		}
		return advanceResultItemViewModel;
	}

	[HttpPost]
	[LoginAuthorize]
	public AdvanceResultItemViewModel UpdateProductsFromFG(SeoLanguageViewModel vm)
	{
		AdvanceResultItemViewModel advanceResultItemViewModel = new AdvanceResultItemViewModel();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			int userId = UserLogin.CurrentUser.UserId;
			short value2 = short.Parse(Financial.Get().Id.ToString());
			short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			_db_II.CRMspUpdateProductShpSeoFromFG(vm.ObjIds, vm.SeoIsActive_Enabled, vm.SeoIsActive, vm.SeoTitle_Enabled, vm.SeoTitleMode, vm.SeoTitle, vm.SeoTitle_Lang, vm.SeoDescription_Enabled, vm.SeoDescription, vm.SeoDescription_Lang, vm.SeoHttpEquiv_Enabled, vm.SeoHttpEquiv, vm.SeoExpires_Enabled, vm.SeoExpires, vm.SeoGoogleNotranslate_Enabled, vm.SeoGoogleNotranslate, vm.SeoDistribution_Enabled, vm.SeoDistribution, vm.SeoRobots_Enabled, vm.SeoRobots, vm.SeoRating_Enabled, vm.SeoRating, vm.SeoAuthor_Enabled, vm.SeoAuthor, vm.SeoAuthor_Lang, vm.SeoIsUseSocialNetwork_Enabled, vm.SeoIsUseSocialNetwork, vm.SeoMobileOptimized_Enabled, vm.SeoMobileOptimized, vm.SeoCopyright_Enabled, vm.SeoCopyright, vm.SeoCopyright_Lang, vm.SeoUseDefault_Enabled, vm.SeoUseDefault, vm.SeoKeywords_Enabled, vm.SeoKeywords, vm.SeoKeywords_Lang, vm.SeoFAQ_Enabled, vm.SeoFAQ, vm.SeoFAQ_Lang, userId, value2, value3, value, registerDatePersian, appType, lCID, result);
			advanceResultItemViewModel.Status = CommonResultStatusViewModel.Success;
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
			advanceResultItemViewModel.Status = CommonResultStatusViewModel.Error;
			advanceResultItemViewModel.Errors.Add(ex.Message);
		}
		return advanceResultItemViewModel;
	}

	[HttpPost]
	[LoginAuthorize]
	public AdvanceResultItemViewModel UpdateProductsFromSG(SeoLanguageViewModel vm)
	{
		AdvanceResultItemViewModel advanceResultItemViewModel = new AdvanceResultItemViewModel();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			int userId = UserLogin.CurrentUser.UserId;
			short value2 = short.Parse(Financial.Get().Id.ToString());
			short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			_db_II.CRMspUpdateProductShpSeoFromSG(vm.ObjIds, vm.SeoIsActive_Enabled, vm.SeoIsActive, vm.SeoTitle_Enabled, vm.SeoTitleMode, vm.SeoTitle, vm.SeoTitle_Lang, vm.SeoDescription_Enabled, vm.SeoDescription, vm.SeoDescription_Lang, vm.SeoHttpEquiv_Enabled, vm.SeoHttpEquiv, vm.SeoExpires_Enabled, vm.SeoExpires, vm.SeoGoogleNotranslate_Enabled, vm.SeoGoogleNotranslate, vm.SeoDistribution_Enabled, vm.SeoDistribution, vm.SeoRobots_Enabled, vm.SeoRobots, vm.SeoRating_Enabled, vm.SeoRating, vm.SeoAuthor_Enabled, vm.SeoAuthor, vm.SeoAuthor_Lang, vm.SeoIsUseSocialNetwork_Enabled, vm.SeoIsUseSocialNetwork, vm.SeoMobileOptimized_Enabled, vm.SeoMobileOptimized, vm.SeoCopyright_Enabled, vm.SeoCopyright, vm.SeoCopyright_Lang, vm.SeoUseDefault_Enabled, vm.SeoUseDefault, vm.SeoKeywords_Enabled, vm.SeoKeywords, vm.SeoKeywords_Lang, vm.SeoFAQ_Enabled, vm.SeoFAQ, vm.SeoFAQ_Lang, userId, value2, value3, value, registerDatePersian, appType, lCID, result);
			advanceResultItemViewModel.Status = CommonResultStatusViewModel.Success;
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
			advanceResultItemViewModel.Status = CommonResultStatusViewModel.Error;
			advanceResultItemViewModel.Errors.Add(ex.Message);
		}
		return advanceResultItemViewModel;
	}

	[HttpPost]
	[LoginAuthorize]
	public AdvanceResultItemViewModel UpdateProductFirstGroup(SeoLanguageViewModel vm)
	{
		AdvanceResultItemViewModel advanceResultItemViewModel = new AdvanceResultItemViewModel();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			int userId = UserLogin.CurrentUser.UserId;
			short value2 = short.Parse(Financial.Get().Id.ToString());
			short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			_db_II.CRMspUpdateProductFirstGroupShpSeo(vm.ObjIds, vm.SeoIsActive_Enabled, vm.SeoIsActive, vm.SeoTitle_Enabled, vm.SeoTitleMode, vm.SeoTitle, vm.SeoTitle_Lang, vm.SeoDescription_Enabled, vm.SeoDescription, vm.SeoDescription_Lang, vm.SeoHttpEquiv_Enabled, vm.SeoHttpEquiv, vm.SeoExpires_Enabled, vm.SeoExpires, vm.SeoGoogleNotranslate_Enabled, vm.SeoGoogleNotranslate, vm.SeoDistribution_Enabled, vm.SeoDistribution, vm.SeoRobots_Enabled, vm.SeoRobots, vm.SeoRating_Enabled, vm.SeoRating, vm.SeoAuthor_Enabled, vm.SeoAuthor, vm.SeoAuthor_Lang, vm.SeoIsUseSocialNetwork_Enabled, vm.SeoIsUseSocialNetwork, vm.SeoMobileOptimized_Enabled, vm.SeoMobileOptimized, vm.SeoCopyright_Enabled, vm.SeoCopyright, vm.SeoCopyright_Lang, vm.SeoUseDefault_Enabled, vm.SeoUseDefault, vm.SeoKeywords_Enabled, vm.SeoKeywords, vm.SeoKeywords_Lang, vm.SeoFAQ_Enabled, vm.SeoFAQ, vm.SeoFAQ_Lang, userId, value2, value3, value, registerDatePersian, appType, lCID, result);
			advanceResultItemViewModel.Status = CommonResultStatusViewModel.Success;
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
			advanceResultItemViewModel.Status = CommonResultStatusViewModel.Error;
			advanceResultItemViewModel.Errors.Add(ex.Message);
		}
		return advanceResultItemViewModel;
	}

	[HttpPost]
	[LoginAuthorize]
	public AdvanceResultItemViewModel UpdateProductSecondGroup(SeoLanguageViewModel vm)
	{
		AdvanceResultItemViewModel advanceResultItemViewModel = new AdvanceResultItemViewModel();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			int userId = UserLogin.CurrentUser.UserId;
			short value2 = short.Parse(Financial.Get().Id.ToString());
			short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			_db_II.CRMspUpdateProductSecondGroupShpSeo(vm.ObjIds, vm.SeoIsActive_Enabled, vm.SeoIsActive, vm.SeoTitle_Enabled, vm.SeoTitleMode, vm.SeoTitle, vm.SeoTitle_Lang, vm.SeoDescription_Enabled, vm.SeoDescription, vm.SeoDescription_Lang, vm.SeoHttpEquiv_Enabled, vm.SeoHttpEquiv, vm.SeoExpires_Enabled, vm.SeoExpires, vm.SeoGoogleNotranslate_Enabled, vm.SeoGoogleNotranslate, vm.SeoDistribution_Enabled, vm.SeoDistribution, vm.SeoRobots_Enabled, vm.SeoRobots, vm.SeoRating_Enabled, vm.SeoRating, vm.SeoAuthor_Enabled, vm.SeoAuthor, vm.SeoAuthor_Lang, vm.SeoIsUseSocialNetwork_Enabled, vm.SeoIsUseSocialNetwork, vm.SeoMobileOptimized_Enabled, vm.SeoMobileOptimized, vm.SeoCopyright_Enabled, vm.SeoCopyright, vm.SeoCopyright_Lang, vm.SeoUseDefault_Enabled, vm.SeoUseDefault, vm.SeoKeywords_Enabled, vm.SeoKeywords, vm.SeoKeywords_Lang, vm.SeoFAQ_Enabled, vm.SeoFAQ, vm.SeoFAQ_Lang, userId, value2, value3, value, registerDatePersian, appType, lCID, result);
			advanceResultItemViewModel.Status = CommonResultStatusViewModel.Success;
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
			advanceResultItemViewModel.Status = CommonResultStatusViewModel.Error;
			advanceResultItemViewModel.Errors.Add(ex.Message);
		}
		return advanceResultItemViewModel;
	}
}
