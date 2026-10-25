using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web.Mvc;
using CRM.General.Security;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Classes;
using Elmah;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace CRMIdeal.Areas.WareHouse.Controllers;

public class ChangeWareHouseController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actwhChangeWareHouse")]
	public ActionResult Index()
	{
		return View();
	}

	public ActionResult WareHouseList_Read([DataSourceRequest] DataSourceRequest request)
	{
		List<WareHouseViewModel> list = new List<WareHouseViewModel>();
		try
		{
			List<WsWareHouse> list2 = Enumerable.ToList<WsWareHouse>((IEnumerable<WsWareHouse>)_dbTbl.WsWareHouse);
			list.AddRange(Enumerable.Select<WsWareHouse, WareHouseViewModel>((IEnumerable<WsWareHouse>)list2, (Func<WsWareHouse, WareHouseViewModel>)((WsWareHouse item) => new WareHouseViewModel
			{
				UserId = item.UserId,
				AppType = item.AppType,
				FPId = item.FPId,
				IsFix = item.IsFix,
				GUId = item.GUId,
				Month1 = item.Month1,
				RegisterDate = item.RegisterDate,
				RegisterDatePersian = item.RegisterDatePersian,
				WareHouseID = item.WareHouseID,
				WrhsAddress = item.WrhsAddress,
				WrhsArea = item.WrhsArea,
				WrhsCode = item.WrhsCode,
				WrhsDescription = item.WrhsDescription,
				WrhsFax = item.WrhsFax,
				WrhsFaxSecond = item.WrhsFaxSecond,
				WrhsName = item.WrhsName,
				WrhsPerson = item.WrhsPerson,
				WrhsPreTel = item.WrhsPreTel,
				WrhsTel = item.WrhsTel,
				WrhsTelSecond = item.WrhsTelSecond,
				WrhsTelThird = item.WrhsTelThird
			})));
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actwhChangeWareHouse")]
	public string GetChangeWareHouse(int id)
	{
		string result = "";
		try
		{
			if (id > 0)
			{
				if (_dbTbl.WsWareHouse.Find(id) != null)
				{
					try
					{
						result = "1";
					}
					catch (DbEntityValidationException e)
					{
						ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
						result = Messages.RedundancyMessage;
					}
					catch (Exception ex)
					{
						ErrorSignal.FromCurrentContext().Raise(ex);
						result = Messages.msgErrorCommunicateWithServer + "<br><p style=text-align:left;>" + ex.Message + "</p>";
					}
				}
				else
				{
					result = Messages.ErrorNotFound;
				}
			}
		}
		catch (Exception ex2)
		{
			ErrorSignal.FromCurrentContext().Raise(ex2);
			result = Messages.frmErrorMessage + "<br/>" + ex2.Message;
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
