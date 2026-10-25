using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using CRM.Models;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using Elmah;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.FormBase.Controllers;

public class SelectItemsController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	public ActionResult Index(int position = 0, int itemtypeId = 0, int selectedType = 1, bool disabledItem = false, string selectedIds = "", string formName = "")
	{
		base.ViewBag.Position = position;
		base.ViewBag.ItemtypeId = itemtypeId;
		base.ViewBag.SelectedType = selectedType;
		base.ViewBag.DisabledItem = disabledItem;
		base.ViewBag.FormName = formName;
		base.ViewBag.selectedIds = selectedIds;
		return View();
	}

	public ActionResult ProductAndGroup(int position = 0, int itemtypeId = 0, int selectedType = 1, bool disabledItem = false, string selectedIds = "", string formName = "", int maxLevel = 2)
	{
		base.ViewBag.Position = position;
		base.ViewBag.ItemtypeId = itemtypeId;
		base.ViewBag.SelectedType = selectedType;
		base.ViewBag.DisabledItem = disabledItem;
		base.ViewBag.FormName = formName;
		base.ViewBag.selectedIds = selectedIds;
		base.ViewBag.MaxLevel = maxLevel;
		return View();
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetListItems(int itemtypeId = 0)
	{
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			List<SelectListItem> list = new List<SelectListItem>();
			switch (itemtypeId)
			{
			case 1:
				list = GetCmpGroupList();
				break;
			case 2:
				list = GetCmpSubGroupList();
				break;
			case 3:
				list = GetCmpGroupIIList();
				break;
			case 4:
				list = GetCmpGroupIIIList();
				break;
			case 5:
				list = GetCmpGroupIVList();
				break;
			case 6:
				list = GetCmpTypeList();
				break;
			case 7:
				list = GetCmpPresentationList();
				break;
			}
			if (list != null && Enumerable.Any<SelectListItem>((IEnumerable<SelectListItem>)list))
			{
				result = JsonConvert.SerializeObject(Enumerable.ToList<nComboBoxListItem>(Enumerable.Select<SelectListItem, nComboBoxListItem>((IEnumerable<SelectListItem>)list, (Func<SelectListItem, nComboBoxListItem>)((SelectListItem item) => new nComboBoxListItem
				{
					Text = item.Text,
					Value = item.Value
				}))));
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	public List<SelectListItem> GetCmpGroupList()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> result2 = new List<SelectListItem>();
		try
		{
			int result3 = 0;
			int value = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result3);
				value = UserLogin.CurrentUser.UserId;
			}
			result2 = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectCompanyGroup_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyGroup_Result>)Enumerable.ToList<CRMspSelectCompanyGroup_Result>((IEnumerable<CRMspSelectCompanyGroup_Result>)_db.CRMspSelectCompanyGroup(value, lCID, result, result3)), (Func<CRMspSelectCompanyGroup_Result, SelectListItem>)((CRMspSelectCompanyGroup_Result item) => new SelectListItem
			{
				Text = item.GroupName,
				Value = item.CompanyGroupID.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result2;
	}

	public List<SelectListItem> GetCmpSubGroupList()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> result2 = new List<SelectListItem>();
		try
		{
			int result3 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result3);
			}
			result2 = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspDySelectCompanySubGroup_Result, SelectListItem>((IEnumerable<CRMspDySelectCompanySubGroup_Result>)Enumerable.ToList<CRMspDySelectCompanySubGroup_Result>((IEnumerable<CRMspDySelectCompanySubGroup_Result>)_dbII.CRMspDySelectCompanySubGroup(UserLogin.CurrentUser.UserId, 0, result3, lCID, result)), (Func<CRMspDySelectCompanySubGroup_Result, SelectListItem>)((CRMspDySelectCompanySubGroup_Result item) => new SelectListItem
			{
				Text = ((!string.IsNullOrWhiteSpace(item.GroupName)) ? item.GroupName : "") + ((!string.IsNullOrWhiteSpace(item.GroupName) && !string.IsNullOrWhiteSpace(item.SubGroupName)) ? " - " : "") + ((!string.IsNullOrWhiteSpace(item.SubGroupName)) ? item.SubGroupName : ""),
				Value = item.CompanySubGroupID.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result2;
	}

	public List<SelectListItem> GetCmpGroupIIList()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> result2 = new List<SelectListItem>();
		try
		{
			result2 = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectCompanyGroupsII_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyGroupsII_Result>)Enumerable.ToList<CRMspSelectCompanyGroupsII_Result>((IEnumerable<CRMspSelectCompanyGroupsII_Result>)_db.CRMspSelectCompanyGroupsII(lCID, result)), (Func<CRMspSelectCompanyGroupsII_Result, SelectListItem>)((CRMspSelectCompanyGroupsII_Result item) => new SelectListItem
			{
				Text = item.GroupIIName,
				Value = item.CompanyGroupIIID.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result2;
	}

	public List<SelectListItem> GetCmpGroupIIIList()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> result2 = new List<SelectListItem>();
		try
		{
			result2 = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectCompanyGroupsIII_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyGroupsIII_Result>)Enumerable.ToList<CRMspSelectCompanyGroupsIII_Result>((IEnumerable<CRMspSelectCompanyGroupsIII_Result>)_db.CRMspSelectCompanyGroupsIII(lCID, result)), (Func<CRMspSelectCompanyGroupsIII_Result, SelectListItem>)((CRMspSelectCompanyGroupsIII_Result item) => new SelectListItem
			{
				Text = item.GroupIIIName,
				Value = item.CompanyGroupIIIID.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result2;
	}

	public List<SelectListItem> GetCmpGroupIVList()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> result2 = new List<SelectListItem>();
		try
		{
			int result3 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result3);
			}
			result2 = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectCompanyGroupsIV_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyGroupsIV_Result>)Enumerable.ToList<CRMspSelectCompanyGroupsIV_Result>((IEnumerable<CRMspSelectCompanyGroupsIV_Result>)_db.CRMspSelectCompanyGroupsIV(UserLogin.CurrentUser.UserId, lCID, result, result3)), (Func<CRMspSelectCompanyGroupsIV_Result, SelectListItem>)((CRMspSelectCompanyGroupsIV_Result item) => new SelectListItem
			{
				Text = item.GroupIVName,
				Value = item.CompanyGroupIVID.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result2;
	}

	public List<SelectListItem> GetCmpTypeList()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> result2 = new List<SelectListItem>();
		try
		{
			result2 = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectCompanyType_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyType_Result>)Enumerable.ToList<CRMspSelectCompanyType_Result>((IEnumerable<CRMspSelectCompanyType_Result>)_db.CRMspSelectCompanyType(lCID, result)), (Func<CRMspSelectCompanyType_Result, SelectListItem>)((CRMspSelectCompanyType_Result item) => new SelectListItem
			{
				Text = item.CompanyTypeName,
				Value = item.CompanyTypeID.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result2;
	}

	public List<SelectListItem> GetCmpPresentationList()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> result2 = new List<SelectListItem>();
		try
		{
			result2 = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectCompanyPresentation_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyPresentation_Result>)Enumerable.ToList<CRMspSelectCompanyPresentation_Result>((IEnumerable<CRMspSelectCompanyPresentation_Result>)_db.CRMspSelectCompanyPresentation(lCID, result)), (Func<CRMspSelectCompanyPresentation_Result, SelectListItem>)((CRMspSelectCompanyPresentation_Result item) => new SelectListItem
			{
				Text = item.Presentation,
				Value = item.CompanyPresentationID.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result2;
	}

	public JsonResult LoadProductTree(int? mode, int? prdKind, int? prdInActive, int? cmpId, int? prjId, int? level, int maxLevel, int? parentId, int? productId, int pageNumber = 1, int pageSize = 20, string textSearch = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspProductsTreeByLevel_Result> data = new List<WSspProductsTreeByLevel_Result>();
		try
		{
			if (productId.HasValue && productId != 0)
			{
				textSearch = "";
			}
			textSearch = textSearch.Trim();
			parentId = ((parentId.HasValue && parentId.GetValueOrDefault() == -1) ? new int?(0) : parentId);
			data = Enumerable.ToList<WSspProductsTreeByLevel_Result>((IEnumerable<WSspProductsTreeByLevel_Result>)_dbII.WSspProductsTreeByLevel(mode, lCID, result, prdKind, prdInActive, cmpId, prjId, level, textSearch, maxLevel, parentId, productId, pageSize, pageNumber));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(data, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbI.Dispose();
		_dbII.Dispose();
		base.Dispose(disposing);
	}
}
