using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.Filter.Controllers;

public class ProductController : Controller
{
	private CRMSpEntities db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private CRMSpIEntities _dbI = new CRMSpIEntities();

	private CRMSpIIEntities _dbII = new CRMSpIIEntities();

	private static string textNone = Labels.None;

	private static string textHaveNot = Labels.HaveNot;

	private static string textItemSeperators = "-----------";

	[LoginAuthorize]
	public ActionResult _PartialOperateOnResult()
	{
		return PartialView();
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetPrdKinds(int? selectedId = 0)
	{
		return JsonConvert.SerializeObject(new List<nComboBoxListItem>
		{
			new nComboBoxListItem
			{
				Text = Labels.PrdKindProduct,
				Value = "1",
				Selected = (1 == selectedId.GetValueOrDefault())
			},
			new nComboBoxListItem
			{
				Text = Labels.PrdKindService,
				Value = "2",
				Selected = (2 == selectedId.GetValueOrDefault())
			}
		});
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetUsedProductSpecifications(int? reportId = 0)
	{
		return JsonConvert.SerializeObject(Product.FillUserReportFieldsByPrdSpecifications(null, true));
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetPrdFirstGroups(string selectedIds = null)
	{
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<string> selectedIdsList = new List<string>();
			if (!string.IsNullOrWhiteSpace(selectedIds))
			{
				List<string> list = selectedIdsList;
				string[] array = selectedIds.Split(new char[1] { ',' });
				object collection;
				if (array == null)
				{
					collection = null;
				}
				else
				{
					IEnumerable<string> enumerable = Enumerable.Where<string>((IEnumerable<string>)array, (Func<string, bool>)((string x) => !string.IsNullOrWhiteSpace(x)));
					collection = ((enumerable != null) ? Enumerable.ToList<string>(enumerable) : null);
				}
				list.AddRange((IEnumerable<string>)collection);
			}
			List<nComboBoxListItem> list2 = Enumerable.ToList<nComboBoxListItem>(Enumerable.Select<WSspSelectProductFirstGroup_Result, nComboBoxListItem>((IEnumerable<WSspSelectProductFirstGroup_Result>)Enumerable.ToList<WSspSelectProductFirstGroup_Result>((IEnumerable<WSspSelectProductFirstGroup_Result>)db.WSspSelectProductFirstGroup(lCID, result2)), (Func<WSspSelectProductFirstGroup_Result, nComboBoxListItem>)((WSspSelectProductFirstGroup_Result item) => new nComboBoxListItem
			{
				Text = (item.FGName ?? ""),
				Value = item.PrdFirstGroupID.ToString(),
				Selected = (Enumerable.FirstOrDefault<string>((IEnumerable<string>)selectedIdsList, (Func<string, bool>)((string x) => x == item.PrdFirstGroupID.ToString())) != null),
				IsSysDef = ((item.FGName == textHaveNot || item.FGName == textNone) ? true : false),
				IsSep = (item.FGName == textItemSeperators)
			})));
			if (list2 != null)
			{
				result = JsonConvert.SerializeObject(list2);
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
	public string GetPrdSecondGroups(string firstGroupIds = "", string selectedIds = null)
	{
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<string> selectedIdsList = new List<string>();
			if (!string.IsNullOrWhiteSpace(selectedIds))
			{
				List<string> list = selectedIdsList;
				string[] array = selectedIds.Split(new char[1] { ',' });
				object collection;
				if (array == null)
				{
					collection = null;
				}
				else
				{
					IEnumerable<string> enumerable = Enumerable.Where<string>((IEnumerable<string>)array, (Func<string, bool>)((string x) => !string.IsNullOrWhiteSpace(x)));
					collection = ((enumerable != null) ? Enumerable.ToList<string>(enumerable) : null);
				}
				list.AddRange((IEnumerable<string>)collection);
			}
			List<nComboBoxListItem> list2 = Enumerable.ToList<nComboBoxListItem>(Enumerable.Select<WSspSelectProductSecondGroupWithFGIds_Result, nComboBoxListItem>((IEnumerable<WSspSelectProductSecondGroupWithFGIds_Result>)Enumerable.ToList<WSspSelectProductSecondGroupWithFGIds_Result>((IEnumerable<WSspSelectProductSecondGroupWithFGIds_Result>)_dbII.WSspSelectProductSecondGroupWithFGIds(firstGroupIds, ",", lCID, result2)), (Func<WSspSelectProductSecondGroupWithFGIds_Result, nComboBoxListItem>)((WSspSelectProductSecondGroupWithFGIds_Result item) => new nComboBoxListItem
			{
				Text = (item.SGName ?? ""),
				Value = item.PrdSecondGroupID.ToString(),
				Selected = (Enumerable.FirstOrDefault<string>((IEnumerable<string>)selectedIdsList, (Func<string, bool>)((string x) => x == item.PrdSecondGroupID.ToString())) != null),
				IsSysDef = ((item.SGName == textHaveNot || item.SGName == textNone) ? true : false),
				IsSep = (item.SGName == textItemSeperators)
			})));
			if (list2 != null)
			{
				result = JsonConvert.SerializeObject(list2);
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
	public string GetProductFilterDataWeb(string selectedFieldsJs = "", string dbObjectNames = "")
	{
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int result3 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result3);
			}
			List<WSspRpt_ProductFilterDataWeb_Result> list = Enumerable.ToList<WSspRpt_ProductFilterDataWeb_Result>((IEnumerable<WSspRpt_ProductFilterDataWeb_Result>)_dbII.WSspRpt_ProductFilterDataWeb(selectedFieldsJs, dbObjectNames, UserLogin.CurrentUser.UserId, DateTime.Now.ToString("yyyyMMdd", new PersianCulture()), Configuration.AppType, lCID, result2, null, null, result3));
			if (list != null)
			{
				string prdKindProduct = Labels.PrdKindProduct;
				string prdKindService = Labels.PrdKindService;
				foreach (WSspRpt_ProductFilterDataWeb_Result item in list)
				{
					if (item.PrdKind.GetValueOrDefault() == 1)
					{
						item.PrdKindName = prdKindProduct;
					}
					else if (item.PrdKind.GetValueOrDefault() == 2)
					{
						item.PrdKindName = prdKindService;
					}
				}
				result = JsonConvert.SerializeObject(list);
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}
}
