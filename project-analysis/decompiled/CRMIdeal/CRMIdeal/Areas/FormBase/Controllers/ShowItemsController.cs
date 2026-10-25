using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using CRM.General.Calendar;
using CRM.General.Security;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Helper;
using Elmah;

namespace CRMIdeal.Areas.FormBase.Controllers;

public class ShowItemsController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	public ActionResult Index(string type, string param, string extra = "")
	{
		base.ViewBag.Parameters = param;
		base.ViewBag.Type = type;
		base.ViewBag.Extra = extra;
		return View();
	}

	[AjaxOnly]
	public JsonResult ListUserForReferToMultilUser(string parameters, string extra = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int result2 = 0;
		int result3 = 0;
		List<CommonMultiSelectorViewModel> data = new List<CommonMultiSelectorViewModel>();
		try
		{
			if (parameters != "")
			{
				string[] array = parameters.Split(new char[1] { '|' });
				if (array.Length > 1)
				{
					int.TryParse(array[0], out result2);
					int.TryParse(array[1], out result3);
				}
			}
			int result4 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result4);
			}
			int value = 7;
			string[] arrSelected = extra.Split(new char[1] { '|' });
			data = Enumerable.ToList<CommonMultiSelectorViewModel>(Enumerable.Select(Enumerable.Select(Enumerable.Select((IEnumerable<CRMspSelectUserForCnvsReferToMultilUser_Result>)Enumerable.ToList<CRMspSelectUserForCnvsReferToMultilUser_Result>((IEnumerable<CRMspSelectUserForCnvsReferToMultilUser_Result>)_db.CRMspSelectUserForCnvsReferToMultilUser(UserLogin.CurrentUser.UserId, value, result2, result3, lCID, result, result4)), (CRMspSelectUserForCnvsReferToMultilUser_Result item) => new
			{
				item = item,
				sel = Array.Exists(arrSelected, (string element) => element == item.LinkedUserId.ToString())
			}), _003C_003Eh__TransparentIdentifier0 => new
			{
				_003C_003Eh__TransparentIdentifier0 = _003C_003Eh__TransparentIdentifier0,
				text = ((_003C_003Eh__TransparentIdentifier0.item.cmpAccess == -100) ? $" ({Messages.CnvsComboReferUserCmpNotAccess})" : "")
			}), _003C_003Eh__TransparentIdentifier1 => new CommonMultiSelectorViewModel
			{
				Id = int.Parse(_003C_003Eh__TransparentIdentifier1._003C_003Eh__TransparentIdentifier0.item.LinkedUserId.ToString()),
				Name = _003C_003Eh__TransparentIdentifier1._003C_003Eh__TransparentIdentifier0.item.UserName + _003C_003Eh__TransparentIdentifier1.text,
				Selected = _003C_003Eh__TransparentIdentifier1._003C_003Eh__TransparentIdentifier0.sel
			}));
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult ListUserForShpDefReferToMultilUser(string parameters, string extra = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int result2 = 0;
		int result3 = 0;
		List<CommonMultiSelectorViewModel> list = new List<CommonMultiSelectorViewModel>();
		try
		{
			if (parameters != "")
			{
				string[] array = parameters.Split(new char[1] { '|' });
				if (array.Length > 1)
				{
					int.TryParse(array[0], out result2);
					int.TryParse(array[1], out result3);
				}
			}
			int result4 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result4);
			}
			int value = 7;
			string[] arrSelected = extra.Split(new char[1] { '|' });
			List<CRMspSelectUserForCnvsReferToMultilUser_Result> list2 = Enumerable.ToList<CRMspSelectUserForCnvsReferToMultilUser_Result>((IEnumerable<CRMspSelectUserForCnvsReferToMultilUser_Result>)_db.CRMspSelectUserForCnvsReferToMultilUser(UserLogin.CurrentUser.UserId, value, result2, result3, lCID, result, result4));
			bool flag = true;
			if (list2 != null && Enumerable.Any<CRMspSelectUserForCnvsReferToMultilUser_Result>((IEnumerable<CRMspSelectUserForCnvsReferToMultilUser_Result>)list2))
			{
				CRMspSelectUserForCnvsReferToMultilUser_Result cRMspSelectUserForCnvsReferToMultilUser_Result = Enumerable.FirstOrDefault<CRMspSelectUserForCnvsReferToMultilUser_Result>((IEnumerable<CRMspSelectUserForCnvsReferToMultilUser_Result>)list2, (Func<CRMspSelectUserForCnvsReferToMultilUser_Result, bool>)((CRMspSelectUserForCnvsReferToMultilUser_Result m) => m.LinkedUserId.GetValueOrDefault() == -109));
				if (cRMspSelectUserForCnvsReferToMultilUser_Result != null && cRMspSelectUserForCnvsReferToMultilUser_Result.LinkedUserId.GetValueOrDefault() == -109)
				{
					flag = false;
				}
			}
			if (flag)
			{
				List<CRMspSelectUsersByIds_Result> list3 = CRMIdeal.Classes.Helper.User.SelectUsersByIds("-109");
				if (list3 != null)
				{
					list.AddRange(Enumerable.Select<CRMspSelectUsersByIds_Result, CommonMultiSelectorViewModel>((IEnumerable<CRMspSelectUsersByIds_Result>)Enumerable.ToList<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list3), (Func<CRMspSelectUsersByIds_Result, CommonMultiSelectorViewModel>)((CRMspSelectUsersByIds_Result i) => new CommonMultiSelectorViewModel
					{
						Name = (i.FullName ?? ""),
						Id = i.UserId,
						Selected = false
					})));
				}
			}
			list.AddRange(Enumerable.ToList<CommonMultiSelectorViewModel>(Enumerable.Select(Enumerable.Select(Enumerable.Select((IEnumerable<CRMspSelectUserForCnvsReferToMultilUser_Result>)list2, (CRMspSelectUserForCnvsReferToMultilUser_Result item) => new
			{
				item = item,
				sel = Array.Exists(arrSelected, (string element) => element == item.LinkedUserId.ToString())
			}), _003C_003Eh__TransparentIdentifier0 => new
			{
				_003C_003Eh__TransparentIdentifier0 = _003C_003Eh__TransparentIdentifier0,
				text = ((_003C_003Eh__TransparentIdentifier0.item.cmpAccess == -100) ? $" ({Messages.CnvsComboReferUserCmpNotAccess})" : "")
			}), _003C_003Eh__TransparentIdentifier1 => new CommonMultiSelectorViewModel
			{
				Id = int.Parse(_003C_003Eh__TransparentIdentifier1._003C_003Eh__TransparentIdentifier0.item.LinkedUserId.ToString()),
				Name = _003C_003Eh__TransparentIdentifier1._003C_003Eh__TransparentIdentifier0.item.UserName,
				Selected = _003C_003Eh__TransparentIdentifier1._003C_003Eh__TransparentIdentifier0.sel
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
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult ListOrderIndicatorOrderStatus(string parameters, string extra = "")
	{
		List<CommonMultiSelectorViewModel> data = new List<CommonMultiSelectorViewModel>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			string[] arrSelected = extra.Split(new char[1] { '|' });
			data = Enumerable.ToList<CommonMultiSelectorViewModel>(Enumerable.Select(Enumerable.Select((IEnumerable<WSspSelectOrderStatus_Result>)Enumerable.ToList<WSspSelectOrderStatus_Result>((IEnumerable<WSspSelectOrderStatus_Result>)_db.WSspSelectOrderStatus(lCID, result)), (WSspSelectOrderStatus_Result item) => new
			{
				item = item,
				sel = Array.Exists(arrSelected, (string element) => element == item.OrderStatusId.ToString())
			}), _003C_003Eh__TransparentIdentifier0 => new CommonMultiSelectorViewModel
			{
				Id = int.Parse(_003C_003Eh__TransparentIdentifier0.item.OrderStatusId.ToString()),
				Name = _003C_003Eh__TransparentIdentifier0.item.OrderStatus,
				Selected = _003C_003Eh__TransparentIdentifier0.sel
			}));
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult ListOrderIndicatorOrderOpr(string parameters, string extra = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<CommonMultiSelectorViewModel> data = new List<CommonMultiSelectorViewModel>();
		try
		{
			string[] arrSelected = extra.Split(new char[1] { '|' });
			List<WSspSelectOrderOpr_Result> list = Order.SelectOrderOpr();
			if (list != null)
			{
				data = Enumerable.ToList<CommonMultiSelectorViewModel>(Enumerable.Select(Enumerable.Select((IEnumerable<WSspSelectOrderOpr_Result>)list, (WSspSelectOrderOpr_Result item) => new
				{
					item = item,
					sel = Array.Exists(arrSelected, (string element) => element == item.OrderOprID.ToString())
				}), _003C_003Eh__TransparentIdentifier0 => new CommonMultiSelectorViewModel
				{
					Id = int.Parse(_003C_003Eh__TransparentIdentifier0.item.OrderOprID.ToString()),
					Name = _003C_003Eh__TransparentIdentifier0.item.Name,
					Selected = _003C_003Eh__TransparentIdentifier0.sel
				}));
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult ListHourlySaleOrderOpr(string parameters, string extra = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<CommonMultiSelectorViewModel> data = new List<CommonMultiSelectorViewModel>();
		try
		{
			string[] arrSelected = extra.Split(new char[1] { '|' });
			List<WSspSelectOrderOpr_Result> list = Order.SelectOrderOpr();
			if (list != null)
			{
				data = Enumerable.ToList<CommonMultiSelectorViewModel>(Enumerable.Select(Enumerable.Select((IEnumerable<WSspSelectOrderOpr_Result>)list, (WSspSelectOrderOpr_Result item) => new
				{
					item = item,
					sel = Array.Exists(arrSelected, (string element) => element == item.OrderOprID.ToString())
				}), _003C_003Eh__TransparentIdentifier0 => new CommonMultiSelectorViewModel
				{
					Id = int.Parse(_003C_003Eh__TransparentIdentifier0.item.OrderOprID.ToString()),
					Name = _003C_003Eh__TransparentIdentifier0.item.Name,
					Selected = _003C_003Eh__TransparentIdentifier0.sel
				}));
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult ListPreOrderIndicatorPreOrderOpr(string parameters, string extra = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CommonMultiSelectorViewModel> data = new List<CommonMultiSelectorViewModel>();
		try
		{
			string[] arrSelected = extra.Split(new char[1] { '|' });
			data = Enumerable.ToList<CommonMultiSelectorViewModel>(Enumerable.Select(Enumerable.Select((IEnumerable<WSspSelectPreOrderOpr_Result>)Enumerable.ToList<WSspSelectPreOrderOpr_Result>((IEnumerable<WSspSelectPreOrderOpr_Result>)_db.WSspSelectPreOrderOpr(lCID, result)), (WSspSelectPreOrderOpr_Result item) => new
			{
				item = item,
				sel = Array.Exists(arrSelected, (string element) => element == item.PreOrderOprID.ToString())
			}), _003C_003Eh__TransparentIdentifier0 => new CommonMultiSelectorViewModel
			{
				Id = int.Parse(_003C_003Eh__TransparentIdentifier0.item.PreOrderOprID.ToString()),
				Name = _003C_003Eh__TransparentIdentifier0.item.PreOrderOpr,
				Selected = _003C_003Eh__TransparentIdentifier0.sel
			}));
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult ListOrderIndicatorOrderPrd(string parameters, string extra = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CommonMultiSelectorViewModel> data = new List<CommonMultiSelectorViewModel>();
		try
		{
			string[] arrSelected = extra.Split(new char[1] { '|' });
			int value = 0;
			int value2 = 0;
			if (parameters != "")
			{
				string[] array = parameters.Split(new char[1] { '|' });
				value = ((array[0] != null && array[0] != "") ? int.Parse(array[0]) : 0);
				value2 = ((array[1] != null && array[1] != "") ? int.Parse(array[1]) : 0);
			}
			data = Enumerable.ToList<CommonMultiSelectorViewModel>(Enumerable.Select(Enumerable.Select((IEnumerable<WSspSearchProducts_Result>)Enumerable.ToList<WSspSearchProducts_Result>((IEnumerable<WSspSearchProducts_Result>)_db.WSspSearchProducts(value, value2, "", "", 0, 2, lCID, result, 0, -1, 0, 0, "", null)), (WSspSearchProducts_Result item) => new
			{
				item = item,
				sel = Array.Exists(arrSelected, (string element) => element == item.PrdId.ToString())
			}), _003C_003Eh__TransparentIdentifier0 => new CommonMultiSelectorViewModel
			{
				Id = int.Parse(_003C_003Eh__TransparentIdentifier0.item.PrdId.ToString()),
				Name = _003C_003Eh__TransparentIdentifier0.item.PName + ((_003C_003Eh__TransparentIdentifier0.item.GName != null && _003C_003Eh__TransparentIdentifier0.item.GName != "") ? $" ({_003C_003Eh__TransparentIdentifier0.item.GName})" : ""),
				Selected = _003C_003Eh__TransparentIdentifier0.sel
			}));
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult ListPreOrderIndicatorPreOrderPrd(string parameters, string extra = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CommonMultiSelectorViewModel> data = new List<CommonMultiSelectorViewModel>();
		try
		{
			string[] arrSelected = extra.Split(new char[1] { '|' });
			int value = 0;
			int value2 = 0;
			if (parameters != "")
			{
				string[] array = parameters.Split(new char[1] { '|' });
				value = ((array[0] != null && array[0] != "") ? int.Parse(array[0]) : 0);
				value2 = ((array[1] != null && array[1] != "") ? int.Parse(array[1]) : 0);
			}
			data = Enumerable.ToList<CommonMultiSelectorViewModel>(Enumerable.Select(Enumerable.Select((IEnumerable<WSspSearchProducts_Result>)Enumerable.ToList<WSspSearchProducts_Result>((IEnumerable<WSspSearchProducts_Result>)_db.WSspSearchProducts(value, value2, "", "", 0, 2, lCID, result, 0, -1, 0, 0, "", null)), (WSspSearchProducts_Result item) => new
			{
				item = item,
				sel = Array.Exists(arrSelected, (string element) => element == item.PrdId.ToString())
			}), _003C_003Eh__TransparentIdentifier0 => new CommonMultiSelectorViewModel
			{
				Id = int.Parse(_003C_003Eh__TransparentIdentifier0.item.PrdId.ToString()),
				Name = _003C_003Eh__TransparentIdentifier0.item.PName + ((_003C_003Eh__TransparentIdentifier0.item.GName != null && _003C_003Eh__TransparentIdentifier0.item.GName != "") ? $" ({_003C_003Eh__TransparentIdentifier0.item.GName})" : ""),
				Selected = _003C_003Eh__TransparentIdentifier0.sel
			}));
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult ListOrderPaymentIndicatorOrdPayType(string parameters, string extra = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CommonMultiSelectorViewModel> data = new List<CommonMultiSelectorViewModel>();
		try
		{
			int value = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserId : 0);
			string[] arrSelected = extra.Split(new char[1] { '|' });
			data = Enumerable.ToList<CommonMultiSelectorViewModel>(Enumerable.Select(Enumerable.Select((IEnumerable<WSspSelectOrderPaymentTypes_Result>)Enumerable.ToList<WSspSelectOrderPaymentTypes_Result>((IEnumerable<WSspSelectOrderPaymentTypes_Result>)_db.WSspSelectOrderPaymentTypes(lCID, result, value)), (WSspSelectOrderPaymentTypes_Result item) => new
			{
				item = item,
				sel = Array.Exists(arrSelected, (string element) => element == item.OrderPaymentTypeId.ToString())
			}), _003C_003Eh__TransparentIdentifier0 => new CommonMultiSelectorViewModel
			{
				Id = int.Parse(_003C_003Eh__TransparentIdentifier0.item.OrderPaymentTypeId.ToString()),
				Name = _003C_003Eh__TransparentIdentifier0.item.ordpayType,
				Selected = _003C_003Eh__TransparentIdentifier0.sel
			}));
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult ListBuyOrderPaymentIndicatorBordPayType(string parameters, string extra = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CommonMultiSelectorViewModel> data = new List<CommonMultiSelectorViewModel>();
		try
		{
			string[] arrSelected = extra.Split(new char[1] { '|' });
			data = Enumerable.ToList<CommonMultiSelectorViewModel>(Enumerable.Select(Enumerable.Select((IEnumerable<WSspSelectBuyOrderPaymentTypes_Result>)Enumerable.ToList<WSspSelectBuyOrderPaymentTypes_Result>((IEnumerable<WSspSelectBuyOrderPaymentTypes_Result>)_db.WSspSelectBuyOrderPaymentTypes(lCID, result)), (WSspSelectBuyOrderPaymentTypes_Result item) => new
			{
				item = item,
				sel = Array.Exists(arrSelected, (string element) => element == item.BuyOrderPaymentTypeId.ToString())
			}), _003C_003Eh__TransparentIdentifier0 => new CommonMultiSelectorViewModel
			{
				Id = int.Parse(_003C_003Eh__TransparentIdentifier0.item.BuyOrderPaymentTypeId.ToString()),
				Name = _003C_003Eh__TransparentIdentifier0.item.bordpayType,
				Selected = _003C_003Eh__TransparentIdentifier0.sel
			}));
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult ListBuyOrderIndicatorBuyOrderStatus(string parameters, string extra = "")
	{
		List<CommonMultiSelectorViewModel> data = new List<CommonMultiSelectorViewModel>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			string[] arrSelected = extra.Split(new char[1] { '|' });
			data = Enumerable.ToList<CommonMultiSelectorViewModel>(Enumerable.Select(Enumerable.Select((IEnumerable<WSspSelectBuyOrderStatus_Result>)Enumerable.ToList<WSspSelectBuyOrderStatus_Result>((IEnumerable<WSspSelectBuyOrderStatus_Result>)_db.WSspSelectBuyOrderStatus(lCID, result)), (WSspSelectBuyOrderStatus_Result item) => new
			{
				item = item,
				sel = Array.Exists(arrSelected, (string element) => element == item.BuyOrderStatusId.ToString())
			}), _003C_003Eh__TransparentIdentifier0 => new CommonMultiSelectorViewModel
			{
				Id = int.Parse(_003C_003Eh__TransparentIdentifier0.item.BuyOrderStatusId.ToString()),
				Name = _003C_003Eh__TransparentIdentifier0.item.BuyOrderStatus,
				Selected = _003C_003Eh__TransparentIdentifier0.sel
			}));
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult ListBuyOrderIndicatorBuyOrderOpr(string parameters, string extra = "")
	{
		List<CommonMultiSelectorViewModel> data = new List<CommonMultiSelectorViewModel>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			string[] arrSelected = extra.Split(new char[1] { '|' });
			List<WSspSelectBuyOrderOpr_Result> list = BuyOrder.SelectBuyOrderOpr();
			if (list != null)
			{
				data = Enumerable.ToList<CommonMultiSelectorViewModel>(Enumerable.Select(Enumerable.Select((IEnumerable<WSspSelectBuyOrderOpr_Result>)list, (WSspSelectBuyOrderOpr_Result item) => new
				{
					item = item,
					sel = Array.Exists(arrSelected, (string element) => element == item.BuyOrderOprID.ToString())
				}), _003C_003Eh__TransparentIdentifier0 => new CommonMultiSelectorViewModel
				{
					Id = int.Parse(_003C_003Eh__TransparentIdentifier0.item.BuyOrderOprID.ToString()),
					Name = _003C_003Eh__TransparentIdentifier0.item.Name,
					Selected = _003C_003Eh__TransparentIdentifier0.sel
				}));
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult ListBuyOrderIndicatorBuyOrderPrd(string parameters, string extra = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CommonMultiSelectorViewModel> data = new List<CommonMultiSelectorViewModel>();
		try
		{
			string[] arrSelected = extra.Split(new char[1] { '|' });
			int value = 0;
			int value2 = 0;
			if (parameters != "")
			{
				string[] array = parameters.Split(new char[1] { '|' });
				value = ((array[0] != null && array[0] != "") ? int.Parse(array[0]) : 0);
				value2 = ((array[1] != null && array[1] != "") ? int.Parse(array[1]) : 0);
			}
			data = Enumerable.ToList<CommonMultiSelectorViewModel>(Enumerable.Select(Enumerable.Select((IEnumerable<WSspSearchProducts_Result>)Enumerable.ToList<WSspSearchProducts_Result>((IEnumerable<WSspSearchProducts_Result>)_db.WSspSearchProducts(value, value2, "", "", 0, 1, lCID, result, 0, -1, null, null, "", null)), (WSspSearchProducts_Result item) => new
			{
				item = item,
				sel = Array.Exists(arrSelected, (string element) => element == item.PrdId.ToString())
			}), _003C_003Eh__TransparentIdentifier0 => new CommonMultiSelectorViewModel
			{
				Id = int.Parse(_003C_003Eh__TransparentIdentifier0.item.PrdId.ToString()),
				Name = _003C_003Eh__TransparentIdentifier0.item.PName + ((_003C_003Eh__TransparentIdentifier0.item.GName != null && _003C_003Eh__TransparentIdentifier0.item.GName != "") ? $" ({_003C_003Eh__TransparentIdentifier0.item.GName})" : ""),
				Selected = _003C_003Eh__TransparentIdentifier0.sel
			}));
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult ListPreOrderIndicatorPordStatus(string parameters, string extra = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CommonMultiSelectorViewModel> data = new List<CommonMultiSelectorViewModel>();
		try
		{
			string[] arrSelected = extra.Split(new char[1] { '|' });
			data = Enumerable.ToList<CommonMultiSelectorViewModel>(Enumerable.Select(Enumerable.Select((IEnumerable<WSspSelectPreOrderStatus_Result>)Enumerable.ToList<WSspSelectPreOrderStatus_Result>((IEnumerable<WSspSelectPreOrderStatus_Result>)_db.WSspSelectPreOrderStatus(lCID, result)), (WSspSelectPreOrderStatus_Result item) => new
			{
				item = item,
				sel = Array.Exists(arrSelected, (string element) => element == item.PreOrderStatusId.ToString())
			}), _003C_003Eh__TransparentIdentifier0 => new CommonMultiSelectorViewModel
			{
				Id = int.Parse(_003C_003Eh__TransparentIdentifier0.item.PreOrderStatusId.ToString()),
				Name = _003C_003Eh__TransparentIdentifier0.item.PreOrderStatus,
				Selected = _003C_003Eh__TransparentIdentifier0.sel
			}));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult ListPreOrderIndicatorPordFirstRegisterUser(string parameters, string extra = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CommonMultiSelectorViewModel> data = new List<CommonMultiSelectorViewModel>();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			string[] arrSelected = extra.Split(new char[1] { '|' });
			data = Enumerable.ToList<CommonMultiSelectorViewModel>(Enumerable.Select(Enumerable.Select((IEnumerable<WSspSelectPreOrderReferUsers_Result>)Enumerable.ToList<WSspSelectPreOrderReferUsers_Result>((IEnumerable<WSspSelectPreOrderReferUsers_Result>)_db.WSspSelectPreOrderReferUsers(UserLogin.CurrentUser.UserId, lCID, result, result2)), (WSspSelectPreOrderReferUsers_Result item) => new
			{
				item = item,
				sel = Array.Exists(arrSelected, (string element) => element == item.UserId.ToString())
			}), _003C_003Eh__TransparentIdentifier0 => new CommonMultiSelectorViewModel
			{
				Id = int.Parse(_003C_003Eh__TransparentIdentifier0.item.UserId.ToString()),
				Name = _003C_003Eh__TransparentIdentifier0.item.UserName,
				Selected = _003C_003Eh__TransparentIdentifier0.sel
			}));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult ListPreOrderIndicatorPordReferUser(string parameters, string extra = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CommonMultiSelectorViewModel> data = new List<CommonMultiSelectorViewModel>();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			string[] arrSelected = extra.Split(new char[1] { '|' });
			data = Enumerable.ToList<CommonMultiSelectorViewModel>(Enumerable.Select(Enumerable.Select((IEnumerable<WSspSelectPreOrderReferUsers_Result>)Enumerable.ToList<WSspSelectPreOrderReferUsers_Result>((IEnumerable<WSspSelectPreOrderReferUsers_Result>)_db.WSspSelectPreOrderReferUsers(UserLogin.CurrentUser.UserId, lCID, result, result2)), (WSspSelectPreOrderReferUsers_Result item) => new
			{
				item = item,
				sel = Array.Exists(arrSelected, (string element) => element == item.UserId.ToString())
			}), _003C_003Eh__TransparentIdentifier0 => new CommonMultiSelectorViewModel
			{
				Id = int.Parse(_003C_003Eh__TransparentIdentifier0.item.UserId.ToString()),
				Name = _003C_003Eh__TransparentIdentifier0.item.UserName,
				Selected = _003C_003Eh__TransparentIdentifier0.sel
			}));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult ListPreOrderIndicatorPordSeller(string parameters, string extra = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CommonMultiSelectorViewModel> data = new List<CommonMultiSelectorViewModel>();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			string[] arrSelected = extra.Split(new char[1] { '|' });
			data = Enumerable.ToList<CommonMultiSelectorViewModel>(Enumerable.Select(Enumerable.Select((IEnumerable<CRMspSelectActiveUsers_Result>)Enumerable.ToList<CRMspSelectActiveUsers_Result>((IEnumerable<CRMspSelectActiveUsers_Result>)_db.CRMspSelectActiveUsers(lCID, result, result2)), (CRMspSelectActiveUsers_Result item) => new
			{
				item = item,
				sel = Array.Exists(arrSelected, (string element) => element == item.UserId.ToString())
			}), _003C_003Eh__TransparentIdentifier0 => new CommonMultiSelectorViewModel
			{
				Id = int.Parse(_003C_003Eh__TransparentIdentifier0.item.UserId.ToString()),
				Name = _003C_003Eh__TransparentIdentifier0.item.Name,
				Selected = _003C_003Eh__TransparentIdentifier0.sel
			}));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult ListOrdIndicatorFirstRegisterUser(string parameters, string extra = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CommonMultiSelectorViewModel> data = new List<CommonMultiSelectorViewModel>();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			string[] arrSelected = extra.Split(new char[1] { '|' });
			data = Enumerable.ToList<CommonMultiSelectorViewModel>(Enumerable.Select(Enumerable.Select((IEnumerable<WSspSelectOrderReferUsers_Result>)Enumerable.ToList<WSspSelectOrderReferUsers_Result>((IEnumerable<WSspSelectOrderReferUsers_Result>)_db.WSspSelectOrderReferUsers(UserLogin.CurrentUser.UserId, lCID, result, result2)), (WSspSelectOrderReferUsers_Result item) => new
			{
				item = item,
				sel = Array.Exists(arrSelected, (string element) => element == item.UserId.ToString())
			}), _003C_003Eh__TransparentIdentifier0 => new CommonMultiSelectorViewModel
			{
				Id = int.Parse(_003C_003Eh__TransparentIdentifier0.item.UserId.ToString()),
				Name = _003C_003Eh__TransparentIdentifier0.item.UserName,
				Selected = _003C_003Eh__TransparentIdentifier0.sel
			}));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult ListOrdIndicatorReferUser(string parameters, string extra = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CommonMultiSelectorViewModel> data = new List<CommonMultiSelectorViewModel>();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			string[] arrSelected = extra.Split(new char[1] { '|' });
			data = Enumerable.ToList<CommonMultiSelectorViewModel>(Enumerable.Select(Enumerable.Select((IEnumerable<WSspSelectOrderReferUsers_Result>)Enumerable.ToList<WSspSelectOrderReferUsers_Result>((IEnumerable<WSspSelectOrderReferUsers_Result>)_db.WSspSelectOrderReferUsers(UserLogin.CurrentUser.UserId, lCID, result, result2)), (WSspSelectOrderReferUsers_Result item) => new
			{
				item = item,
				sel = Array.Exists(arrSelected, (string element) => element == item.UserId.ToString())
			}), _003C_003Eh__TransparentIdentifier0 => new CommonMultiSelectorViewModel
			{
				Id = int.Parse(_003C_003Eh__TransparentIdentifier0.item.UserId.ToString()),
				Name = _003C_003Eh__TransparentIdentifier0.item.UserName,
				Selected = _003C_003Eh__TransparentIdentifier0.sel
			}));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult ListHourlySaleReferUser(string parameters, string extra = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CommonMultiSelectorViewModel> data = new List<CommonMultiSelectorViewModel>();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			string[] arrSelected = extra.Split(new char[1] { '|' });
			data = Enumerable.ToList<CommonMultiSelectorViewModel>(Enumerable.Select(Enumerable.Select((IEnumerable<WSspSelectOrderReferUsers_Result>)Enumerable.ToList<WSspSelectOrderReferUsers_Result>((IEnumerable<WSspSelectOrderReferUsers_Result>)_db.WSspSelectOrderReferUsers(UserLogin.CurrentUser.UserId, lCID, result, result2)), (WSspSelectOrderReferUsers_Result item) => new
			{
				item = item,
				sel = Array.Exists(arrSelected, (string element) => element == item.UserId.ToString())
			}), _003C_003Eh__TransparentIdentifier0 => new CommonMultiSelectorViewModel
			{
				Id = int.Parse(_003C_003Eh__TransparentIdentifier0.item.UserId.ToString()),
				Name = _003C_003Eh__TransparentIdentifier0.item.UserName,
				Selected = _003C_003Eh__TransparentIdentifier0.sel
			}));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult ListOrdIndicatorSeller(string parameters, string extra = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CommonMultiSelectorViewModel> data = new List<CommonMultiSelectorViewModel>();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			string[] arrSelected = extra.Split(new char[1] { '|' });
			data = Enumerable.ToList<CommonMultiSelectorViewModel>(Enumerable.Select(Enumerable.Select((IEnumerable<CRMspSelectActiveUsers_Result>)Enumerable.ToList<CRMspSelectActiveUsers_Result>((IEnumerable<CRMspSelectActiveUsers_Result>)_db.CRMspSelectActiveUsers(lCID, result, result2)), (CRMspSelectActiveUsers_Result item) => new
			{
				item = item,
				sel = Array.Exists(arrSelected, (string element) => element == item.UserId.ToString())
			}), _003C_003Eh__TransparentIdentifier0 => new CommonMultiSelectorViewModel
			{
				Id = int.Parse(_003C_003Eh__TransparentIdentifier0.item.UserId.ToString()),
				Name = _003C_003Eh__TransparentIdentifier0.item.Name,
				Selected = _003C_003Eh__TransparentIdentifier0.sel
			}));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult ListBordIndicatorFirstRegisterUser(string parameters, string extra = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int result2 = 0;
		if (UserLogin.CurrentUser != null)
		{
			int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
		}
		List<CommonMultiSelectorViewModel> data = new List<CommonMultiSelectorViewModel>();
		try
		{
			string[] arrSelected = extra.Split(new char[1] { '|' });
			data = Enumerable.ToList<CommonMultiSelectorViewModel>(Enumerable.Select(Enumerable.Select((IEnumerable<WSspSelectBuyOrderRegUsers_Result>)Enumerable.ToList<WSspSelectBuyOrderRegUsers_Result>((IEnumerable<WSspSelectBuyOrderRegUsers_Result>)_db.WSspSelectBuyOrderRegUsers(UserLogin.CurrentUser.UserId, lCID, result, result2)), (WSspSelectBuyOrderRegUsers_Result item) => new
			{
				item = item,
				sel = Array.Exists(arrSelected, (string element) => element == item.UserId.ToString())
			}), _003C_003Eh__TransparentIdentifier0 => new CommonMultiSelectorViewModel
			{
				Id = int.Parse(_003C_003Eh__TransparentIdentifier0.item.UserId.ToString()),
				Name = _003C_003Eh__TransparentIdentifier0.item.UserName,
				Selected = _003C_003Eh__TransparentIdentifier0.sel
			}));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult ListBordIndicatorReferUser(string parameters, string extra = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CommonMultiSelectorViewModel> data = new List<CommonMultiSelectorViewModel>();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			string[] arrSelected = extra.Split(new char[1] { '|' });
			data = Enumerable.ToList<CommonMultiSelectorViewModel>(Enumerable.Select(Enumerable.Select((IEnumerable<WSspSelectBuyOrderReferUsers_Result>)Enumerable.ToList<WSspSelectBuyOrderReferUsers_Result>((IEnumerable<WSspSelectBuyOrderReferUsers_Result>)_db.WSspSelectBuyOrderReferUsers(UserLogin.CurrentUser.UserId, lCID, result, result2)), (WSspSelectBuyOrderReferUsers_Result item) => new
			{
				item = item,
				sel = Array.Exists(arrSelected, (string element) => element == item.UserId.ToString())
			}), _003C_003Eh__TransparentIdentifier0 => new CommonMultiSelectorViewModel
			{
				Id = int.Parse(_003C_003Eh__TransparentIdentifier0.item.UserId.ToString()),
				Name = _003C_003Eh__TransparentIdentifier0.item.UserName,
				Selected = _003C_003Eh__TransparentIdentifier0.sel
			}));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult ListIndicatorWarehouse(string parameters, string extra = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<CommonMultiSelectorViewModel> data = new List<CommonMultiSelectorViewModel>();
		try
		{
			string[] arrSelected = extra.Split(new char[1] { '|' });
			_ = UserLogin.CurrentUser.UserId;
			List<WSspSelectActiveWareHouse_Result> list = CRMIdeal.Classes.Helper.Warehouse.SelectActiveWareHouse();
			if (list != null && Enumerable.Any<WSspSelectActiveWareHouse_Result>((IEnumerable<WSspSelectActiveWareHouse_Result>)list))
			{
				data = Enumerable.ToList<CommonMultiSelectorViewModel>(Enumerable.Select(Enumerable.Select((IEnumerable<WSspSelectActiveWareHouse_Result>)list, (WSspSelectActiveWareHouse_Result item) => new
				{
					item = item,
					sel = Array.Exists(arrSelected, (string element) => element == item.WareHouseID.ToString())
				}), _003C_003Eh__TransparentIdentifier0 => new CommonMultiSelectorViewModel
				{
					Id = int.Parse(_003C_003Eh__TransparentIdentifier0.item.WareHouseID.ToString()),
					Name = _003C_003Eh__TransparentIdentifier0.item.WrhsName,
					Selected = _003C_003Eh__TransparentIdentifier0.sel
				}));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult ListUsersForDyForm(string parameters, string extra = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CommonMultiSelectorViewModel> data = new List<CommonMultiSelectorViewModel>();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			string[] arrSelected = extra.Split(new char[1] { '|' });
			data = Enumerable.ToList<CommonMultiSelectorViewModel>(Enumerable.Select(Enumerable.Select((IEnumerable<CRMspSelectActiveUsers_Result>)Enumerable.ToList<CRMspSelectActiveUsers_Result>((IEnumerable<CRMspSelectActiveUsers_Result>)_db.CRMspSelectActiveUsers(lCID, result, result2)), (CRMspSelectActiveUsers_Result item) => new
			{
				item = item,
				sel = Array.Exists(arrSelected, (string element) => element == item.UserId.ToString())
			}), _003C_003Eh__TransparentIdentifier0 => new CommonMultiSelectorViewModel
			{
				Id = int.Parse(_003C_003Eh__TransparentIdentifier0.item.UserId.ToString()),
				Name = _003C_003Eh__TransparentIdentifier0.item.Name,
				Selected = _003C_003Eh__TransparentIdentifier0.sel
			}));
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult ListForDyFormCrmShowLoc(string parameters, string extra = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CommonMultiSelectorViewModel> list = new List<CommonMultiSelectorViewModel>();
		try
		{
			List<string> splitedData = new List<string>();
			if (!string.IsNullOrWhiteSpace(extra))
			{
				splitedData = Enumerable.ToList<string>((IEnumerable<string>)extra.Split(new char[1] { '|' }));
			}
			List<CRMspSelectActiveSystemParts_Result> list2 = Enumerable.ToList<CRMspSelectActiveSystemParts_Result>(Enumerable.Where<CRMspSelectActiveSystemParts_Result>((IEnumerable<CRMspSelectActiveSystemParts_Result>)_dbI.CRMspSelectActiveSystemParts(lCID, result, "1,10,11,12,13,20,30,40,50,51,60,61,62,70,100,105,110,111,112,120,130,45"), (Func<CRMspSelectActiveSystemParts_Result, bool>)((CRMspSelectActiveSystemParts_Result m) => m.Type == "CRM")));
			list.AddRange(Enumerable.Select<CRMspSelectActiveSystemParts_Result, CommonMultiSelectorViewModel>((IEnumerable<CRMspSelectActiveSystemParts_Result>)list2, (Func<CRMspSelectActiveSystemParts_Result, CommonMultiSelectorViewModel>)((CRMspSelectActiveSystemParts_Result x) => new CommonMultiSelectorViewModel
			{
				Id = x.SystemPartId,
				Name = x.PartTitle,
				Selected = (splitedData.IndexOf(x.SystemPartId.ToString()) >= 0)
			})));
			list2 = Enumerable.ToList<CRMspSelectActiveSystemParts_Result>(Enumerable.Where<CRMspSelectActiveSystemParts_Result>((IEnumerable<CRMspSelectActiveSystemParts_Result>)_dbI.CRMspSelectActiveSystemParts(lCID, result, "1,10,11,12,13,20,30,40,50,51,60,61,62,70,100,105,110,111,112,120,130,45"), (Func<CRMspSelectActiveSystemParts_Result, bool>)((CRMspSelectActiveSystemParts_Result m) => m.Type == "FO" && m.SystemPartId == 105)));
			list.AddRange(Enumerable.Select<CRMspSelectActiveSystemParts_Result, CommonMultiSelectorViewModel>((IEnumerable<CRMspSelectActiveSystemParts_Result>)list2, (Func<CRMspSelectActiveSystemParts_Result, CommonMultiSelectorViewModel>)((CRMspSelectActiveSystemParts_Result x) => new CommonMultiSelectorViewModel
			{
				Id = x.SystemPartId,
				Name = x.PartTitle,
				Selected = (splitedData.IndexOf(x.SystemPartId.ToString()) >= 0)
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
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult ListForDyFormFOShowLoc(string parameters, string extra = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CommonMultiSelectorViewModel> list = new List<CommonMultiSelectorViewModel>();
		try
		{
			List<string> splitedData = new List<string>();
			if (!string.IsNullOrWhiteSpace(extra))
			{
				splitedData = Enumerable.ToList<string>((IEnumerable<string>)extra.Split(new char[1] { '|' }));
			}
			List<CRMspSelectActiveSystemParts_Result> list2 = Enumerable.ToList<CRMspSelectActiveSystemParts_Result>(Enumerable.Where<CRMspSelectActiveSystemParts_Result>((IEnumerable<CRMspSelectActiveSystemParts_Result>)_dbI.CRMspSelectActiveSystemParts(lCID, result, "1,10,11,12,13,20,30,40,50,51,60,61,62,70,100,105,110,111,112,120,130,45"), (Func<CRMspSelectActiveSystemParts_Result, bool>)((CRMspSelectActiveSystemParts_Result m) => m.Type == "FO")));
			list.AddRange(Enumerable.Select<CRMspSelectActiveSystemParts_Result, CommonMultiSelectorViewModel>((IEnumerable<CRMspSelectActiveSystemParts_Result>)list2, (Func<CRMspSelectActiveSystemParts_Result, CommonMultiSelectorViewModel>)((CRMspSelectActiveSystemParts_Result x) => new CommonMultiSelectorViewModel
			{
				Id = x.SystemPartId,
				Name = x.PartTitle,
				Selected = ((splitedData != null && splitedData.IndexOf(x.SystemPartId.ToString()) >= 0) ? true : false)
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
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult ListCategorysForSurveyAnswer(string parameters, string extra = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CommonMultiSelectorViewModel> list = new List<CommonMultiSelectorViewModel>();
		try
		{
			int result2 = 0;
			int.TryParse(parameters, out result2);
			string[] array = extra.Split(new char[1] { '|' });
			List<CRMspSelectSurveyAnswerCategory_Result> list2 = Enumerable.ToList<CRMspSelectSurveyAnswerCategory_Result>((IEnumerable<CRMspSelectSurveyAnswerCategory_Result>)_db.CRMspSelectSurveyAnswerCategory(result2, lCID, result));
			if (list2 != null)
			{
				foreach (CRMspSelectSurveyAnswerCategory_Result item in list2)
				{
					CommonMultiSelectorViewModel item2 = new CommonMultiSelectorViewModel
					{
						Id = item.SurveyAnswerCategoryId,
						Name = item.SurveyAnswerCategoryTitle,
						Selected = Array.Exists(array, (string element) => element == item.SurveyAnswerCategoryId.ToString())
					};
					list.Add(item2);
				}
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult ListCallHistories(string parameters, string extra = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		DateTime value = DateTime.Now;
		DateTime value2 = DateTime.Now;
		int result2 = 0;
		int result3 = 0;
		List<CommonMultiSelectorViewModel> data = new List<CommonMultiSelectorViewModel>();
		try
		{
			if (parameters != "")
			{
				string[] array = parameters.Split(new char[1] { '|' });
				if (array.Length > 1)
				{
					text = array[0];
					int.TryParse(array[1], out result3);
					int.TryParse(array[2], out result2);
				}
			}
			if (!string.IsNullOrWhiteSpace(text))
			{
				switch (lCID)
				{
				case 1065:
					value = DateTime.Parse(PersianDate.GetFormatetdDate(text) + " 00:00:00");
					value2 = DateTime.Parse(PersianDate.GetFormatetdDate(text) + " 23:59:59");
					break;
				case 1025:
					value = DateTime.Parse(PersianDate.GetFormatetdDate(text) + " 00:00:00", new CultureInfo("ar-SA"), DateTimeStyles.None);
					value2 = DateTime.Parse(PersianDate.GetFormatetdDate(text) + " 23:59:59", new CultureInfo("ar-SA"), DateTimeStyles.None);
					break;
				default:
					value = DateTime.Parse(PersianDate.GetFormatetdDate(text) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None);
					value2 = DateTime.Parse(PersianDate.GetFormatetdDate(text) + " 23:59:59", new CultureInfo("en-US"), DateTimeStyles.None);
					break;
				}
			}
			string[] arrSelected = extra.Split(new char[1] { '|' });
			int result4 = 0;
			int value3 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result4);
				value3 = UserLogin.CurrentUser.UserId;
			}
			List<CRMspSelectCallHistoryWithoutCnvsByCmpId_Result> list = Enumerable.ToList<CRMspSelectCallHistoryWithoutCnvsByCmpId_Result>((IEnumerable<CRMspSelectCallHistoryWithoutCnvsByCmpId_Result>)_db.CRMspSelectCallHistoryWithoutCnvsByCmpId(value, value2, result3, lCID, result, value3, result4));
			List<CRMspSelectConversationCallHistory_Result> list2 = Enumerable.ToList<CRMspSelectConversationCallHistory_Result>((IEnumerable<CRMspSelectConversationCallHistory_Result>)_db.CRMspSelectConversationCallHistory(result2, lCID, result));
			string cnvsIncommingCall = Labels.CnvsIncommingCall;
			string cnvsOutGoingCall = Labels.CnvsOutGoingCall;
			if (list2 != null && Enumerable.Any<CRMspSelectConversationCallHistory_Result>((IEnumerable<CRMspSelectConversationCallHistory_Result>)list2))
			{
				foreach (CRMspSelectConversationCallHistory_Result item3 in list2)
				{
					CRMspSelectCallHistoryWithoutCnvsByCmpId_Result item2 = new CRMspSelectCallHistoryWithoutCnvsByCmpId_Result
					{
						CallHistoryID = item3.CallHistoryID,
						CallTypeId = item3.CallTypeId,
						CallType = item3.CallType,
						PhoneNumber = item3.PhoneNumber,
						CompanyID = item3.CompanyID,
						CallDate = item3.CallDate,
						LineNumber = item3.LineNumber,
						CompanyPersonId = item3.CompanyPersonId,
						Duration = item3.Duration,
						CallDateTime = item3.CallDateTime,
						ConversationID = item3.ConversationID
					};
					list.Add(item2);
				}
			}
			foreach (CRMspSelectCallHistoryWithoutCnvsByCmpId_Result item4 in list)
			{
				_ = item4.CallTypeId;
				if (item4.CallTypeId == 1)
				{
					item4.CallType = cnvsOutGoingCall;
				}
				else if (item4.CallTypeId == 2)
				{
					item4.CallType = cnvsIncommingCall;
				}
			}
			data = Enumerable.ToList<CommonMultiSelectorViewModel>(Enumerable.Select(Enumerable.Select((IEnumerable<CRMspSelectCallHistoryWithoutCnvsByCmpId_Result>)list, (CRMspSelectCallHistoryWithoutCnvsByCmpId_Result item) => new
			{
				item = item,
				sel = Array.Exists(arrSelected, (string element) => element == item.CallHistoryID.ToString())
			}), _003C_003Eh__TransparentIdentifier0 => new CommonMultiSelectorViewModel
			{
				Id = int.Parse(_003C_003Eh__TransparentIdentifier0.item.CallHistoryID.ToString()),
				Name = _003C_003Eh__TransparentIdentifier0.item.CallType + " - " + ((!string.IsNullOrWhiteSpace(_003C_003Eh__TransparentIdentifier0.item.PhoneNumber)) ? (" (" + _003C_003Eh__TransparentIdentifier0.item.PhoneNumber + ")") : "") + " - " + ((!string.IsNullOrWhiteSpace(_003C_003Eh__TransparentIdentifier0.item.Duration)) ? (" (" + _003C_003Eh__TransparentIdentifier0.item.Duration + ")") : "") + " - " + (_003C_003Eh__TransparentIdentifier0.item.CallDateTime.HasValue ? _003C_003Eh__TransparentIdentifier0.item.CallDateTime.Value.ToString("yyyy/MM/dd hh:mm:dd") : ""),
				Selected = _003C_003Eh__TransparentIdentifier0.sel
			}));
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		JsonResult jsonResult = Json(data, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult ListUserForCmpImportExcelCmpReferMultiUser(string parameters = "", string extra = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CommonMultiSelectorViewModel> data = new List<CommonMultiSelectorViewModel>();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			string[] arrSelected = extra.Split(new char[1] { '|' });
			data = Enumerable.ToList<CommonMultiSelectorViewModel>(Enumerable.Select(Enumerable.Select((IEnumerable<CRMspSelectCompanyReferUsers_Result>)Enumerable.ToList<CRMspSelectCompanyReferUsers_Result>((IEnumerable<CRMspSelectCompanyReferUsers_Result>)_db.CRMspSelectCompanyReferUsers(UserLogin.CurrentUser.UserId, lCID, result, result2)), (CRMspSelectCompanyReferUsers_Result item) => new
			{
				item = item,
				sel = Array.Exists(arrSelected, (string element) => element == item.UserId.ToString())
			}), _003C_003Eh__TransparentIdentifier0 => new CommonMultiSelectorViewModel
			{
				Id = int.Parse(_003C_003Eh__TransparentIdentifier0.item.UserId.ToString()),
				Name = _003C_003Eh__TransparentIdentifier0.item.USER,
				Selected = _003C_003Eh__TransparentIdentifier0.sel
			}));
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult ListCmrUserForLinkedUsers(string parameters, string extra = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int crmUserId = 0;
		List<CommonMultiSelectorViewModel> data = new List<CommonMultiSelectorViewModel>();
		try
		{
			if (parameters != "")
			{
				string[] array = parameters.Split(new char[1] { '|' });
				if (array.Length > 1)
				{
					int.TryParse(array[0], out crmUserId);
				}
			}
			string[] arrSelected = extra.Split(new char[1] { '|' });
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			List<CRMspSelectActiveUsers_Result> list = Enumerable.ToList<CRMspSelectActiveUsers_Result>(Enumerable.Where<CRMspSelectActiveUsers_Result>((IEnumerable<CRMspSelectActiveUsers_Result>)_db.CRMspSelectActiveUsers(lCID, result, result2), (Func<CRMspSelectActiveUsers_Result, bool>)((CRMspSelectActiveUsers_Result m) => m.UserId != crmUserId)));
			List<CRMspSelectUsersByIds_Result> list2 = CRMIdeal.Classes.Helper.User.SelectUsersByIds("-20");
			if (list2 != null)
			{
				if (list == null)
				{
					list = new List<CRMspSelectActiveUsers_Result>();
				}
				list.AddRange(Enumerable.Select<CRMspSelectUsersByIds_Result, CRMspSelectActiveUsers_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)Enumerable.ToList<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list2), (Func<CRMspSelectUsersByIds_Result, CRMspSelectActiveUsers_Result>)((CRMspSelectUsersByIds_Result i) => new CRMspSelectActiveUsers_Result
				{
					Name = ((!string.IsNullOrWhiteSpace(i.LName)) ? i.LName : "") + " " + ((!string.IsNullOrWhiteSpace(i.FName)) ? i.FName : ""),
					UserId = i.UserId
				})));
			}
			data = Enumerable.ToList<CommonMultiSelectorViewModel>(Enumerable.Select(Enumerable.Select((IEnumerable<CRMspSelectActiveUsers_Result>)list, (CRMspSelectActiveUsers_Result item) => new
			{
				item = item,
				sel = Array.Exists(arrSelected, (string element) => element == item.UserId.ToString())
			}), _003C_003Eh__TransparentIdentifier0 => new CommonMultiSelectorViewModel
			{
				Id = int.Parse(_003C_003Eh__TransparentIdentifier0.item.UserId.ToString()),
				Name = _003C_003Eh__TransparentIdentifier0.item.Name,
				Selected = _003C_003Eh__TransparentIdentifier0.sel
			}));
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult ListOrderIndicatorOrderSaleCenter(string parameters, string extra = "")
	{
		List<CommonMultiSelectorViewModel> data = new List<CommonMultiSelectorViewModel>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			string[] arrSelected = extra.Split(new char[1] { '|' });
			data = Enumerable.ToList<CommonMultiSelectorViewModel>(Enumerable.Select(Enumerable.Select((IEnumerable<WSspSelectSaleCenters_Result>)Enumerable.ToList<WSspSelectSaleCenters_Result>((IEnumerable<WSspSelectSaleCenters_Result>)_db.WSspSelectSaleCenters(lCID, result)), (WSspSelectSaleCenters_Result item) => new
			{
				item = item,
				sel = Array.Exists(arrSelected, (string element) => element == item.SaleCenterId.ToString())
			}), _003C_003Eh__TransparentIdentifier0 => new CommonMultiSelectorViewModel
			{
				Id = int.Parse(_003C_003Eh__TransparentIdentifier0.item.SaleCenterId.ToString()),
				Name = _003C_003Eh__TransparentIdentifier0.item.SaleCenterName,
				Selected = _003C_003Eh__TransparentIdentifier0.sel
			}));
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult ListPreOrderIndicatorPreOrderSaleCenter(string parameters, string extra = "")
	{
		List<CommonMultiSelectorViewModel> data = new List<CommonMultiSelectorViewModel>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			string[] arrSelected = extra.Split(new char[1] { '|' });
			data = Enumerable.ToList<CommonMultiSelectorViewModel>(Enumerable.Select(Enumerable.Select((IEnumerable<WSspSelectSaleCenters_Result>)Enumerable.ToList<WSspSelectSaleCenters_Result>((IEnumerable<WSspSelectSaleCenters_Result>)_db.WSspSelectSaleCenters(lCID, result)), (WSspSelectSaleCenters_Result item) => new
			{
				item = item,
				sel = Array.Exists(arrSelected, (string element) => element == item.SaleCenterId.ToString())
			}), _003C_003Eh__TransparentIdentifier0 => new CommonMultiSelectorViewModel
			{
				Id = int.Parse(_003C_003Eh__TransparentIdentifier0.item.SaleCenterId.ToString()),
				Name = _003C_003Eh__TransparentIdentifier0.item.SaleCenterName,
				Selected = _003C_003Eh__TransparentIdentifier0.sel
			}));
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult ListBordIndicatorSuppUser(string parameters, string extra = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CommonMultiSelectorViewModel> data = new List<CommonMultiSelectorViewModel>();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			string[] arrSelected = extra.Split(new char[1] { '|' });
			data = Enumerable.ToList<CommonMultiSelectorViewModel>(Enumerable.Select(Enumerable.Select((IEnumerable<CRMspSelectActiveUsers_Result>)Enumerable.ToList<CRMspSelectActiveUsers_Result>((IEnumerable<CRMspSelectActiveUsers_Result>)_db.CRMspSelectActiveUsers(lCID, result, result2)), (CRMspSelectActiveUsers_Result item) => new
			{
				item = item,
				sel = Array.Exists(arrSelected, (string element) => element == item.UserId.ToString())
			}), _003C_003Eh__TransparentIdentifier0 => new CommonMultiSelectorViewModel
			{
				Id = int.Parse(_003C_003Eh__TransparentIdentifier0.item.UserId.ToString()),
				Name = (_003C_003Eh__TransparentIdentifier0.item.Name ?? "").Trim(),
				Selected = _003C_003Eh__TransparentIdentifier0.sel
			}));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult LisrUserForSysSettingTimeAttendanceRecTemp(string parameters, string extra = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CommonMultiSelectorViewModel> data = new List<CommonMultiSelectorViewModel>();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			string[] arrSelected = extra.Split(new char[1] { '|' });
			data = Enumerable.ToList<CommonMultiSelectorViewModel>(Enumerable.Select(Enumerable.Select((IEnumerable<CRMspSelectActiveUsers_Result>)Enumerable.ToList<CRMspSelectActiveUsers_Result>((IEnumerable<CRMspSelectActiveUsers_Result>)_db.CRMspSelectActiveUsers(lCID, result, result2)), (CRMspSelectActiveUsers_Result item) => new
			{
				item = item,
				sel = Array.Exists(arrSelected, (string element) => element == item.UserId.ToString())
			}), _003C_003Eh__TransparentIdentifier0 => new CommonMultiSelectorViewModel
			{
				Id = int.Parse(_003C_003Eh__TransparentIdentifier0.item.UserId.ToString()),
				Name = _003C_003Eh__TransparentIdentifier0.item.Name,
				Selected = _003C_003Eh__TransparentIdentifier0.sel
			}));
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbI.Dispose();
		base.Dispose(disposing);
	}
}
