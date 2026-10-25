using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CRM.Models;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.Component.Controllers;

public class SearchProductController : Controller
{
	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	[HttpPost]
	[LoginAuthorize]
	public string SearchProductsWeb(int fgId = 0, int sgId = 0, string barcode = "", string val = "", int prdId = 0, int showMode = 0, int prdKind = 0, int prdInActive = 0, int? cmpId = null, int? prjId = null)
	{
		string result = "";
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			List<WSspSearchProductsWeb_Result> list = Enumerable.ToList<WSspSearchProductsWeb_Result>((IEnumerable<WSspSearchProductsWeb_Result>)_dbI.WSspSearchProductsWeb(fgId, sgId, barcode, val, prdId, showMode, 0, 0, prdKind, prdInActive, cmpId, prjId, result2, UserLogin.CurrentUser.UserId));
			if (list != null)
			{
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
