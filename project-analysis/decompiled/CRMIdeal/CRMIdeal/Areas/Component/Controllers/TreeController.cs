using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using CRM.Models;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes.Common;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.Component.Controllers;

public class TreeController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	[HttpPost]
	public List<WSspSelectSaleCenters_Result> SelectSaleCenters(int parentId)
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
				list = Enumerable.ToList<WSspSelectSaleCenters_Result>(Enumerable.Where<WSspSelectSaleCenters_Result>((IEnumerable<WSspSelectSaleCenters_Result>)list, (Func<WSspSelectSaleCenters_Result, bool>)((WSspSelectSaleCenters_Result x) => x.ParentId.GetValueOrDefault() == parentId)));
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
	public string GetSelectSaleCenters(int parentId)
	{
		return JsonConvert.SerializeObject(SelectSaleCenters(parentId));
	}
}
