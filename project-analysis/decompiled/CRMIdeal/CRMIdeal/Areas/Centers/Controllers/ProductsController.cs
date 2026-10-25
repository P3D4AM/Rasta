using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.GSD.Globalization;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.Centers.Controllers;

public class ProductsController : Controller
{
	private CRMSpEntities _db = new CRMSpEntities();

	private CRMSpIIEntities _dbII = new CRMSpIIEntities();

	[LoginAuthorize]
	public ActionResult Index()
	{
		return View();
	}

	[LoginAuthorize]
	public ActionResult LinkProductByCenter()
	{
		return View();
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetPrdFirstGroup()
	{
		List<nTreeItemViewModel> list = new List<nTreeItemViewModel>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<WSspSelectProductFirstGroup_Result> list2 = Enumerable.ToList<WSspSelectProductFirstGroup_Result>((IEnumerable<WSspSelectProductFirstGroup_Result>)_db.WSspSelectProductFirstGroup(lCID, result));
			if (list2 != null)
			{
				list.AddRange(Enumerable.Select<WSspSelectProductFirstGroup_Result, nTreeItemViewModel>((IEnumerable<WSspSelectProductFirstGroup_Result>)list2, (Func<WSspSelectProductFirstGroup_Result, nTreeItemViewModel>)((WSspSelectProductFirstGroup_Result x) => new nTreeItemViewModel
				{
					KeyId = x.PrdFirstGroupID.ToString(),
					KeyName = x.FGName,
					ParentId = "0"
				})));
				List<WSspSelectWSProductSecondGroup_Result> list3 = Enumerable.ToList<WSspSelectWSProductSecondGroup_Result>((IEnumerable<WSspSelectWSProductSecondGroup_Result>)_db.WSspSelectWSProductSecondGroup(fGId: 0, languageID: lCID, defaultLanguageID: result));
				if (list3 != null)
				{
					list.AddRange(Enumerable.Select<WSspSelectWSProductSecondGroup_Result, nTreeItemViewModel>((IEnumerable<WSspSelectWSProductSecondGroup_Result>)list3, (Func<WSspSelectWSProductSecondGroup_Result, nTreeItemViewModel>)((WSspSelectWSProductSecondGroup_Result x) => new nTreeItemViewModel
					{
						KeyId = x.PrdSecondGroupID.ToString(),
						KeyName = x.SGName,
						ParentId = x.FirstGroupId.ToString(),
						ChildsCnt = 0
					})));
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	[LoginAuthorize]
	public string InsertCenterProductMulti(string prdGroups = "", string cIds = "", bool? isActive = null, bool? shpShowAfterLogin = null)
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
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			int userId = UserLogin.CurrentUser.UserId;
			int value2 = int.Parse(Financial.Get().Id.ToString());
			short.Parse(Financial.Get().Id.ToString());
			short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			ObjectParameter objectParameter = new ObjectParameter("Result", 0);
			_dbII.WSspInsertCenterProductMulti(prdGroups, cIds, isActive, shpShowAfterLogin, userId, value, registerDatePersian, value2, value3, appType, lCID, objectParameter);
			if (objectParameter != null && objectParameter.Value.ToString() != "1")
			{
				result = Messages.msgErrorOperationFailed;
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
			result = Messages.msgErrorOperationFailed;
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public string DeleteCenterProductMulti(string prdGroups = "", string cIds = "")
	{
		string result = "";
		try
		{
			ObjectParameter objectParameter = new ObjectParameter("Result", 0);
			_dbII.WSspDeleteCenterProductMulti(prdGroups, cIds, objectParameter);
			if (objectParameter != null && objectParameter.Value.ToString() != "1")
			{
				result = Messages.msgErrorOperationFailed;
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
			result = Messages.msgErrorOperationFailed;
		}
		return result;
	}
}
