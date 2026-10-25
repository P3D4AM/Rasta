using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CRM.Models;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace CRMIdeal.Areas.Setting.Controllers;

public class PendingOperationsController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIEntities _db_I = new CRMSpIEntities();

	private readonly CRMSpIIEntities _db_II = new CRMSpIIEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	[LoginAuthorize]
	public ActionResult Index()
	{
		return View();
	}

	[LoginAuthorize]
	public ActionResult PendingOperations_Read([DataSourceRequest] DataSourceRequest request, int systemPartId = 0)
	{
		JsonResult jsonResult = Json(((IEnumerable)SelectSysPendingOperations()).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[LoginAuthorize]
	public List<CRMspSelectSysPendingOperations_Result> SelectSysPendingOperations()
	{
		List<CRMspSelectSysPendingOperations_Result> list = new List<CRMspSelectSysPendingOperations_Result>();
		try
		{
			List<CRMspSelectSysPendingOperations_Result> list2 = Enumerable.ToList<CRMspSelectSysPendingOperations_Result>((IEnumerable<CRMspSelectSysPendingOperations_Result>)_db_II.CRMspSelectSysPendingOperations());
			if (list2 != null)
			{
				list = list2;
			}
			foreach (CRMspSelectSysPendingOperations_Result item in list)
			{
				item.poOperateDatePersian = item.poOperateDate?.ToString("yyyy/MM/dd HH:mm");
				item.poResultDatePersian = item.poResultDate?.ToString("yyyy/MM/dd HH:mm");
				item.poStartDatePersian = item.poStartDate?.ToString("yyyy/MM/dd HH:mm");
				item.poFinishDatePersian = item.poFinishDate?.ToString("yyyy/MM/dd HH:mm");
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return list;
	}
}
