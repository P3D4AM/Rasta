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

namespace CRMIdeal.Areas.Products.Controllers;

public class UpdateProductMultiController : Controller
{
	private CRMSpEntities _db = new CRMSpEntities();

	private CRMSpIIIEntities _dbIII = new CRMSpIIIEntities();

	[DynamicAuthorize(ControllerName = "frmProducts", ActionName = "actUpdateProductMulti")]
	public ActionResult Index()
	{
		return View();
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetPrdGroups()
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
					KeyId = $"F{x.PrdFirstGroupID}",
					KeyName = x.FGName,
					ParentId = "0"
				})));
				List<WSspSelectWSProductSecondGroup_Result> list3 = Enumerable.ToList<WSspSelectWSProductSecondGroup_Result>((IEnumerable<WSspSelectWSProductSecondGroup_Result>)_db.WSspSelectWSProductSecondGroup(fGId: 0, languageID: lCID, defaultLanguageID: result));
				if (list3 != null)
				{
					list.AddRange(Enumerable.Select<WSspSelectWSProductSecondGroup_Result, nTreeItemViewModel>((IEnumerable<WSspSelectWSProductSecondGroup_Result>)list3, (Func<WSspSelectWSProductSecondGroup_Result, nTreeItemViewModel>)((WSspSelectWSProductSecondGroup_Result x) => new nTreeItemViewModel
					{
						KeyId = $"S{x.PrdSecondGroupID}",
						ParentId = $"F{x.FirstGroupId}",
						KeyName = x.SGName,
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
	public string actUpdateProductMulti(string prdGroupdJson, string fieldJsonStr)
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
			if (string.IsNullOrWhiteSpace(prdGroupdJson))
			{
				result = string.Format(Messages.msgErrorPleaseSelectA, Labels.Group);
			}
			else if (string.IsNullOrWhiteSpace(fieldJsonStr))
			{
				result = Messages.msgErrorNoFieldSelectedToUpdate;
			}
			else
			{
				List<Dictionary<string, string>>? list = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(prdGroupdJson);
				List<Dictionary<string, string>> list2 = new List<Dictionary<string, string>>();
				foreach (Dictionary<string, string> item in list)
				{
					string text = item["KeyId"];
					string text2 = item["ParentId"];
					string value4 = text;
					string value5 = text2;
					if (text.StartsWith("F") || text.StartsWith("S"))
					{
						value4 = text.Substring(1);
					}
					if (text2.StartsWith("F") || text2.StartsWith("S"))
					{
						value5 = text2.Substring(1);
					}
					list2.Add(new Dictionary<string, string>
					{
						["ParentId"] = value5,
						["KeyId"] = value4
					});
				}
				prdGroupdJson = JsonConvert.SerializeObject(list2);
				ObjectParameter objectParameter = new ObjectParameter("Result", 0);
				_dbIII.WSspUpdateProductMulti(prdGroupdJson, fieldJsonStr, userId, value, registerDatePersian, value2, value3, appType, lCID, objectParameter);
				int result3 = 0;
				if (objectParameter != null && !string.IsNullOrWhiteSpace(objectParameter.Value.ToString()))
				{
					int.TryParse(objectParameter.Value.ToString(), out result3);
				}
				if (result3 != 1)
				{
					result = Messages.msgErrorOperationFailed;
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
			result = Messages.msgErrorOperationFailed;
		}
		return result;
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbIII.Dispose();
		base.Dispose(disposing);
	}
}
