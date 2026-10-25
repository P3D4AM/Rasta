using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.Entity;
using System.Data.Objects;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Web.Mvc;
using CRM.General.IO;
using CRM.Models;
using CRM.OtherWebServices.LinkNoAvaranCapillary;
using CRM.Resources;
using CRMIdeal.Areas.Setting.Controllers;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using CRMIdeal.LinkPayvast;
using Elmah;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using NR.Shygun.WS.ClientSDK;
using NR.Shygun.WS.FilterDomains;
using Newtonsoft.Json;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace CRMIdeal.Areas.OtherSystems.Controllers;

public class WarehouseController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMLinkSpEntities _dbLink = new CRMLinkSpEntities();

	private readonly CRMSpIEntities _db_I = new CRMSpIEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	public string WrhsSyncTypeId = "WrhsSyncTypeId";

	public string shygunIIWrhsSyncTypeId = "WrhsSyncTypeId";

	public string ShomaranWrhsSyncTypeId = "WrhsSyncTypeId";

	public string LinkAccWrhsSyncTypeId = "WrhsSyncTypeId";

	public lstLkWareHouseInfoViewModel CrmWhList()
	{
		lstLkWareHouseInfoViewModel lstLkWareHouseInfoViewModel = new lstLkWareHouseInfoViewModel();
		try
		{
			_ = UserLogin.CurrentUser.UserId;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			List<WSspSelectActiveWareHouse_Result> list = CRMIdeal.Classes.Helper.Warehouse.SelectActiveWareHouse();
			if (list != null && Enumerable.Any<WSspSelectActiveWareHouse_Result>((IEnumerable<WSspSelectActiveWareHouse_Result>)list))
			{
				list = Enumerable.ToList<WSspSelectActiveWareHouse_Result>((IEnumerable<WSspSelectActiveWareHouse_Result>)Enumerable.OrderByDescending<WSspSelectActiveWareHouse_Result, string>((IEnumerable<WSspSelectActiveWareHouse_Result>)list, (Func<WSspSelectActiveWareHouse_Result, string>)((WSspSelectActiveWareHouse_Result x) => x.WrhsLinkAccWhCode)));
			}
			if (list != null && list.Count > 0)
			{
				List<LkWareHouseInfoViewModel> list2 = new List<LkWareHouseInfoViewModel>();
				List<SelectListItem> list3 = new List<SelectListItem>();
				foreach (WSspSelectActiveWareHouse_Result item in list)
				{
					list2.Add(new LkWareHouseInfoViewModel
					{
						WareHouseID = item.WareHouseID,
						WrhsName = item.WrhsName,
						WrhsCode = item.WrhsCode,
						WrhsAddress = item.WrhsAddress,
						WrhsPreTel = item.WrhsPreTel,
						WrhsTel = item.WrhsTel,
						WrhsTelSecond = item.WrhsTelSecond,
						WrhsTelThird = item.WrhsTelThird,
						WrhsFax = item.WrhsFax,
						WrhsFaxSecond = item.WrhsFaxSecond,
						WrhsArea = item.WrhsArea,
						WrhsPerson = item.WrhsPerson,
						WrhsDescription = item.WrhsDescription,
						WrhsDeActive = item.WrhsDeActive.GetValueOrDefault(),
						OrderView = item.OrderView.GetValueOrDefault(),
						WrhsLinkAccWhId = item.WrhsLinkAccWhId.GetValueOrDefault(),
						WrhsLinkAccWhCode = (item.WrhsLinkAccWhCode ?? ""),
						WrhsLinkAccWhIdStr = (item.WrhsLinkAccWhIdStr ?? "")
					});
					list3.Add(new SelectListItem
					{
						Value = item.WareHouseID.ToString(),
						Text = item.WrhsName,
						Selected = false
					});
				}
				lstLkWareHouseInfoViewModel.lst = list2;
				lstLkWareHouseInfoViewModel.lstSelectListItem = list3;
			}
			lstLkWareHouseInfoViewModel.isDone = true;
			lstLkWareHouseInfoViewModel.Message = "";
		}
		catch (Exception ex)
		{
			lstLkWareHouseInfoViewModel.isDone = false;
			lstLkWareHouseInfoViewModel.Message = "Error: " + ex.Message;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		base.ViewBag.CrmWhListJs = JsonConvert.SerializeObject(lstLkWareHouseInfoViewModel.lst);
		base.ViewBag.CrmWhSelectListJs = JsonConvert.SerializeObject(lstLkWareHouseInfoViewModel.lstSelectListItem);
		base.ViewBag.CrmWhList = lstLkWareHouseInfoViewModel;
		return lstLkWareHouseInfoViewModel;
	}

	public ActionResult ShygunExportWarehouse()
	{
		return View();
	}

	public ActionResult ShygunImportWarehouse()
	{
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmDefineWareHouse", ActionName = "actLinkedWhWithAcc")]
	public ActionResult ShygunSyncWarehouse()
	{
		CrmWhList();
		ShygunWhList();
		CRMIdeal.Classes.Helper.OtherSystems.ShygunSettingViewModel shygunSetting = CRMIdeal.Classes.Helper.OtherSystems.GetShygunSetting();
		base.ViewBag.SyncTypeId = shygunSetting.WrhsSyncTypeId;
		return View();
	}

	[HttpPost]
	public string ShygunSyncWarehouse(string jsData)
	{
		string text = "";
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		DateTime now = DateTime.Now;
		DateTime dateTime = now;
		string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
		_ = Financial.Get().Id;
		short.Parse(Financial.Get().Id.ToString());
		short num = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
		string appType = Configuration.AppType;
		int userId = UserLogin.CurrentUser.UserId;
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			if (!string.IsNullOrWhiteSpace(jsData) && string.IsNullOrWhiteSpace(text))
			{
				List<CommonWithIdStrViewModel> list2 = JsonConvert.DeserializeObject<List<CommonWithIdStrViewModel>>(jsData);
				if (list2 != null && list2.Count > 0)
				{
					List<SelectListItem> list3 = new List<SelectListItem>();
					foreach (CommonWithIdStrViewModel i in list2)
					{
						if (Enumerable.ToList<SelectListItem>(Enumerable.Where<SelectListItem>((IEnumerable<SelectListItem>)list3, (Func<SelectListItem, bool>)((SelectListItem x) => x.Value == i.Extra))).Count <= 0)
						{
							List<CommonWithIdStrViewModel> list4 = Enumerable.ToList<CommonWithIdStrViewModel>(Enumerable.Where<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list2, (Func<CommonWithIdStrViewModel, bool>)((CommonWithIdStrViewModel x) => x.Extra == i.Extra && !string.IsNullOrWhiteSpace(x.Id))));
							if (list4 == null || list4.Count <= 0)
							{
								list3.Add(new SelectListItem
								{
									Value = i.Extra,
									Text = ""
								});
							}
							else
							{
								list3.Add(new SelectListItem
								{
									Value = i.Extra,
									Text = JsonConvert.SerializeObject(list4)
								});
							}
						}
					}
					foreach (SelectListItem item in list3)
					{
						ObjectParameter objectParameter = new ObjectParameter("ErrorMessage", "");
						_dbLink.CRMspLkWSInsertUpdateWhLinkAccWarehouses(int.Parse(item.Value), item.Text, userId, num, dateTime, registerDatePersian, appType, objectParameter);
						new List<SelectListItem>();
						if (!string.IsNullOrWhiteSpace(item.Text))
						{
							List<CommonWithIdStrViewModel> list5 = JsonConvert.DeserializeObject<List<CommonWithIdStrViewModel>>(item.Text);
							if (list5 != null && Enumerable.Count<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list5) == 1)
							{
								int result2 = 0;
								int.TryParse(Enumerable.FirstOrDefault<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list5).Extra, out result2);
								WsWareHouse wsWareHouse = _dbTbl.WsWareHouse.Find(result2);
								if (wsWareHouse != null)
								{
									wsWareHouse.WrhsLinkAccWhIdStr = Enumerable.FirstOrDefault<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list5).Id;
									wsWareHouse.WrhsLinkAccWhCode = Enumerable.FirstOrDefault<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list5).Code;
									wsWareHouse.WrhsLinkAccWhName = Enumerable.FirstOrDefault<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list5).Name;
									wsWareHouse.AppType = appType;
									wsWareHouse.UserId = userId;
									wsWareHouse.Month1 = num;
									wsWareHouse.RegisterDate = dateTime;
									wsWareHouse.RegisterDatePersian = registerDatePersian;
									_dbTbl.Entry(wsWareHouse).State = EntityState.Modified;
									_dbTbl.Configuration.ValidateOnSaveEnabled = false;
									_dbTbl.SaveChanges();
									_dbTbl.Configuration.ValidateOnSaveEnabled = true;
								}
							}
						}
						if (objectParameter.Value != null)
						{
							if (!string.IsNullOrEmpty(objectParameter.Value.ToString()))
							{
								text = text + objectParameter.Value.ToString() + "|";
								continue;
							}
							list.Add(new SelectListItem
							{
								Value = item.Value,
								Text = item.Text
							});
						}
						else
						{
							list.Add(new SelectListItem
							{
								Value = item.Value,
								Text = item.Text
							});
						}
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return text + "|**|" + JsonConvert.SerializeObject(list);
	}

	public lstLkWareHouseInfoViewModel ShygunWhList(string fNumber = "", string tNumber = "")
	{
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		lstLkWareHouseInfoViewModel lstLkWareHouseInfoViewModel = new lstLkWareHouseInfoViewModel();
		bool flag = true;
		int num = 0;
		int rowCount = 100;
		try
		{
			List<LkWareHouseInfoViewModel> list = new List<LkWareHouseInfoViewModel>();
			List<WSspSelectWareHouseWithAccLinkField_Result> list2 = Enumerable.ToList<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)_dbLink.WSspSelectWareHouseWithAccLinkField(withWrhsLinkAccWhCode: false, withWrhsLinkAccWhId: false, withWrhsLinkAccWhIdStr: true, withWrhsLinkAccWareHouses: false, languageID: 0, defaultLanguageID: 0));
			while (flag)
			{
				CRMIdeal.Classes.Helper.OtherSystems.ShygunSettingViewModel shygunSetting = CRMIdeal.Classes.Helper.OtherSystems.GetShygunSetting();
				DomainStock domainStock = new DomainStock();
				domainStock.STNumber.From = fNumber;
				domainStock.STNumber.To = tNumber;
				string JsonResult;
				DataTable dataTableObject = new WebServiceGetStock(shygunSetting.IP, shygunSetting.conf, domainStock, num, rowCount).GetDataTableObject(out JsonResult);
				if (dataTableObject != null && ((InternalDataCollectionBase)dataTableObject.Rows).Count > 0)
				{
					List<SelectListItem> list3 = new List<SelectListItem>();
					foreach (DataRow item in (InternalDataCollectionBase)dataTableObject.Rows)
					{
						DataRow val = item;
						LkWareHouseInfoViewModel vm = new LkWareHouseInfoViewModel();
						vm.WrhsName = val[1].ToString();
						vm.WrhsLinkAccWhCode = val[0].ToString();
						vm.WrhsLinkAccWhIdStr = val[3].ToString();
						vm.WrhsLinkAccWhName = val[1].ToString();
						if (list2 != null)
						{
							WSspSelectWareHouseWithAccLinkField_Result wSspSelectWareHouseWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)list2, (Func<WSspSelectWareHouseWithAccLinkField_Result, bool>)((WSspSelectWareHouseWithAccLinkField_Result x) => x.WrhsLinkAccWhIdStr == vm.WrhsLinkAccWhIdStr));
							if (wSspSelectWareHouseWithAccLinkField_Result != null && wSspSelectWareHouseWithAccLinkField_Result.WareHouseID > 0)
							{
								vm.WareHouseID = wSspSelectWareHouseWithAccLinkField_Result.WareHouseID;
							}
						}
						list.Add(vm);
						list3.Add(new SelectListItem
						{
							Value = vm.WrhsLinkAccWhCode,
							Text = vm.WrhsName,
							Selected = false
						});
					}
					lstLkWareHouseInfoViewModel.lst = list;
					lstLkWareHouseInfoViewModel.lstSelectListItem = list3;
				}
				else
				{
					flag = false;
				}
				num += ((num > 0) ? 100 : 101);
			}
			lstLkWareHouseInfoViewModel.isDone = true;
			lstLkWareHouseInfoViewModel.Message = "";
		}
		catch (Exception ex)
		{
			lstLkWareHouseInfoViewModel.isDone = false;
			lstLkWareHouseInfoViewModel.Message = "Error: " + ex.Message;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		base.ViewBag.LinkAccWhListJs = JsonConvert.SerializeObject(lstLkWareHouseInfoViewModel.lst);
		base.ViewBag.LinkAccWhSelectListJs = JsonConvert.SerializeObject(lstLkWareHouseInfoViewModel.lstSelectListItem);
		base.ViewBag.LinkAccWhList = lstLkWareHouseInfoViewModel;
		return lstLkWareHouseInfoViewModel;
	}

	[DynamicAuthorize(ControllerName = "frmManageWarehousesLinkAcc", ActionName = "actCanChangeLinkType")]
	[HttpPost]
	public string ShygunSyncWarehouseType(int syncType = 1)
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
			DateTime now = DateTime.Now;
			DateTime registerDate = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			_ = Financial.Get().Id;
			short.Parse(Financial.Get().Id.ToString());
			short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
			DbSet<CrmLinkAccShygunSetting> crmLinkAccShygunSetting = _dbTbl.CrmLinkAccShygunSetting;
			ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccShygunSetting), "x");
			CrmLinkAccShygunSetting crmLinkAccShygunSetting2 = Queryable.FirstOrDefault<CrmLinkAccShygunSetting>((IQueryable<CrmLinkAccShygunSetting>)crmLinkAccShygunSetting, Expression.Lambda<Func<CrmLinkAccShygunSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)this, typeof(WarehouseController)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (crmLinkAccShygunSetting2 != null)
			{
				if (crmLinkAccShygunSetting2.LinkAccShygunSettingId > 0)
				{
					crmLinkAccShygunSetting2.PartValue = syncType.ToString();
					crmLinkAccShygunSetting2.RegisterDate = registerDate;
					crmLinkAccShygunSetting2.RegisterDatePersian = registerDatePersian;
					crmLinkAccShygunSetting2.UserId = userId;
					_dbTbl.Entry(crmLinkAccShygunSetting2).State = EntityState.Modified;
					_dbTbl.SaveChanges();
				}
				else
				{
					result = string.Format(Messages.msgNotSetLinkAccSettingWhRelation, Labels.Shygun);
				}
			}
			else
			{
				result = Messages.msgUpdateCrmDatabase;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[DynamicAuthorize(ControllerName = "frmDefineWareHouse", ActionName = "actManageWarehousesLinkAcc")]
	public ActionResult ShygunManageWarehouseLinkAcc()
	{
		CrmWhList();
		ShygunWhList();
		CRMIdeal.Classes.Helper.OtherSystems.ShygunSettingViewModel shygunSetting = CRMIdeal.Classes.Helper.OtherSystems.GetShygunSetting();
		base.ViewBag.SyncTypeId = shygunSetting.WrhsSyncTypeId;
		return View();
	}

	public List<LkWareHouseInfoViewModel> GetShygunWhList(string fNumber = "", string tNumber = "")
	{
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Expected O, but got Unknown
		List<LkWareHouseInfoViewModel> list = new List<LkWareHouseInfoViewModel>();
		bool flag = true;
		int num = 0;
		int rowCount = 100;
		try
		{
			List<WSspSelectWareHouseWithAccLinkField_Result> list2 = Enumerable.ToList<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)_dbLink.WSspSelectWareHouseWithAccLinkField(withWrhsLinkAccWhCode: false, withWrhsLinkAccWhId: false, withWrhsLinkAccWhIdStr: true, withWrhsLinkAccWareHouses: false, languageID: 0, defaultLanguageID: 0));
			while (flag)
			{
				CRMIdeal.Classes.Helper.OtherSystems.ShygunSettingViewModel shygunSetting = CRMIdeal.Classes.Helper.OtherSystems.GetShygunSetting();
				DomainStock domainStock = new DomainStock();
				domainStock.STNumber.From = fNumber;
				domainStock.STNumber.To = tNumber;
				string JsonResult;
				DataTable dataTableObject = new WebServiceGetStock(shygunSetting.IP, shygunSetting.conf, domainStock, num, rowCount).GetDataTableObject(out JsonResult);
				if (dataTableObject != null && ((InternalDataCollectionBase)dataTableObject.Rows).Count > 0)
				{
					foreach (DataRow item in (InternalDataCollectionBase)dataTableObject.Rows)
					{
						DataRow val = item;
						LkWareHouseInfoViewModel vm = new LkWareHouseInfoViewModel();
						vm.WrhsName = val[1].ToString();
						vm.WrhsLinkAccWhCode = val[0].ToString();
						vm.WrhsLinkAccWhIdStr = val[3].ToString();
						vm.WrhsLinkAccWhName = val[1].ToString();
						vm.Selected = true;
						if (list2 != null)
						{
							WSspSelectWareHouseWithAccLinkField_Result wSspSelectWareHouseWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)list2, (Func<WSspSelectWareHouseWithAccLinkField_Result, bool>)((WSspSelectWareHouseWithAccLinkField_Result x) => x.WrhsLinkAccWhIdStr == vm.WrhsLinkAccWhIdStr));
							if (wSspSelectWareHouseWithAccLinkField_Result != null && wSspSelectWareHouseWithAccLinkField_Result.WareHouseID > 0)
							{
								vm.WareHouseID = wSspSelectWareHouseWithAccLinkField_Result.WareHouseID;
								vm.Selected = false;
							}
						}
						list.Add(vm);
					}
				}
				else
				{
					flag = false;
				}
				num += ((num > 0) ? 100 : 101);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	public JsonResult GetShygunWhListJs(string fNumber = "", string tNumber = "")
	{
		JsonResult jsonResult = Json(GetShygunWhList(fNumber, tNumber), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public ActionResult ShygunWhImport_Read([DataSourceRequest] DataSourceRequest request)
	{
		return Json(((IEnumerable)GetShygunWhList()).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[HttpPost]
	public string GetShygunLinkedWhsList()
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
			List<WSspSelectWareHouseWithAccLinkField_Result> list = Enumerable.ToList<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)_dbLink.WSspSelectWareHouseWithAccLinkField(false, false, false, true, lCID, result2));
			if (list != null && list.Count > 0)
			{
				result = JsonConvert.SerializeObject(list);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[DynamicAuthorize(ControllerName = "frmManageWarehousesLinkAcc", ActionName = "actImportWhInfo")]
	public string ShygunImportWhInfo(string records = "")
	{
		string text = "";
		try
		{
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			int id = Financial.Get().Id;
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			if (!string.IsNullOrWhiteSpace(records))
			{
				Enumerable.ToList<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)_dbLink.WSspSelectWareHouseWithAccLinkField(withWrhsLinkAccWhCode: false, withWrhsLinkAccWhId: false, withWrhsLinkAccWhIdStr: true, withWrhsLinkAccWareHouses: false, languageID: 0, defaultLanguageID: 0));
				CRMIdeal.Classes.Helper.OtherSystems.GetShygunSetting();
				List<LkWareHouseInfoViewModel> list = JsonConvert.DeserializeObject<List<LkWareHouseInfoViewModel>>(records);
				int result2 = 0;
				string text2 = Configuration.MaxCountWarehouse.ToString();
				if (text2 != null)
				{
					int.TryParse(text2, out result2);
				}
				if (result2 == 0)
				{
					result2 = 1;
				}
				int valueOrDefault = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)_dbII.WSspReturnActiveWareHouseCount()).GetValueOrDefault();
				if (valueOrDefault >= result2)
				{
					text = Messages.msgErrorInDefinitionIllegalwarehouse1 + " " + result2 + " " + Messages.msgErrorInDefinitionIllegalwarehouse2;
				}
				if (list != null && list.Count > 0)
				{
					list = Enumerable.ToList<LkWareHouseInfoViewModel>(Enumerable.Where<LkWareHouseInfoViewModel>((IEnumerable<LkWareHouseInfoViewModel>)list, (Func<LkWareHouseInfoViewModel, bool>)((LkWareHouseInfoViewModel x) => x.Selected)));
					if (result2 - valueOrDefault <= list.Count)
					{
						text = Messages.msgErrorInDefinitionIllegalwarehouse1 + " " + result2 + " " + Messages.msgErrorInDefinitionIllegalwarehouse2;
					}
				}
				if (string.IsNullOrWhiteSpace(text))
				{
					string json = JsonConvert.SerializeObject(list);
					ObjectParameter objectParameter = new ObjectParameter("ErrorMessage", "");
					_dbLink.CRMspLkWSInsertUpdateWareHouse(json, userId, value2, id, value, registerDatePersian, appType, result, objectParameter, centerId);
					if (!string.IsNullOrWhiteSpace(objectParameter.Value.ToString()))
					{
						text += objectParameter.Value.ToString();
					}
				}
				CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WsWareHouse");
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return text;
	}

	[HttpPost]
	public string ShygunIISyncWarehouse(string jsData)
	{
		string text = "";
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		DateTime now = DateTime.Now;
		DateTime dateTime = now;
		string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
		_ = Financial.Get().Id;
		short.Parse(Financial.Get().Id.ToString());
		short num = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
		string appType = Configuration.AppType;
		int userId = UserLogin.CurrentUser.UserId;
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			if (!string.IsNullOrWhiteSpace(jsData) && string.IsNullOrWhiteSpace(text))
			{
				List<CommonWithIdStrViewModel> list2 = JsonConvert.DeserializeObject<List<CommonWithIdStrViewModel>>(jsData);
				if (list2 != null && list2.Count > 0)
				{
					List<SelectListItem> list3 = new List<SelectListItem>();
					foreach (CommonWithIdStrViewModel i in list2)
					{
						if (Enumerable.ToList<SelectListItem>(Enumerable.Where<SelectListItem>((IEnumerable<SelectListItem>)list3, (Func<SelectListItem, bool>)((SelectListItem x) => x.Value == i.Extra))).Count <= 0)
						{
							List<CommonWithIdStrViewModel> list4 = Enumerable.ToList<CommonWithIdStrViewModel>(Enumerable.Where<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list2, (Func<CommonWithIdStrViewModel, bool>)((CommonWithIdStrViewModel x) => x.Extra == i.Extra && !string.IsNullOrWhiteSpace(x.Id))));
							if (list4 == null || list4.Count <= 0)
							{
								list3.Add(new SelectListItem
								{
									Value = i.Extra,
									Text = ""
								});
							}
							else
							{
								list3.Add(new SelectListItem
								{
									Value = i.Extra,
									Text = JsonConvert.SerializeObject(list4)
								});
							}
						}
					}
					foreach (SelectListItem item in list3)
					{
						ObjectParameter objectParameter = new ObjectParameter("ErrorMessage", "");
						_dbLink.CRMspLkWSInsertUpdateWhLinkAccWarehouses(int.Parse(item.Value), item.Text, userId, num, dateTime, registerDatePersian, appType, objectParameter);
						new List<SelectListItem>();
						if (!string.IsNullOrWhiteSpace(item.Text))
						{
							List<CommonWithIdStrViewModel> list5 = JsonConvert.DeserializeObject<List<CommonWithIdStrViewModel>>(item.Text);
							if (list5 != null && Enumerable.Count<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list5) == 1)
							{
								int result2 = 0;
								int.TryParse(Enumerable.FirstOrDefault<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list5).Extra, out result2);
								WsWareHouse wsWareHouse = _dbTbl.WsWareHouse.Find(result2);
								if (wsWareHouse != null)
								{
									wsWareHouse.WrhsLinkAccWhIdStr = Enumerable.FirstOrDefault<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list5).Id;
									wsWareHouse.WrhsLinkAccWhCode = Enumerable.FirstOrDefault<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list5).Code;
									wsWareHouse.WrhsLinkAccWhName = Enumerable.FirstOrDefault<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list5).Name;
									wsWareHouse.AppType = appType;
									wsWareHouse.UserId = userId;
									wsWareHouse.Month1 = num;
									wsWareHouse.RegisterDate = dateTime;
									wsWareHouse.RegisterDatePersian = registerDatePersian;
									_dbTbl.Entry(wsWareHouse).State = EntityState.Modified;
									_dbTbl.Configuration.ValidateOnSaveEnabled = false;
									_dbTbl.SaveChanges();
									_dbTbl.Configuration.ValidateOnSaveEnabled = true;
								}
							}
						}
						if (objectParameter.Value != null)
						{
							if (!string.IsNullOrEmpty(objectParameter.Value.ToString()))
							{
								text = text + objectParameter.Value.ToString() + "|";
								continue;
							}
							list.Add(new SelectListItem
							{
								Value = item.Value,
								Text = item.Text
							});
						}
						else
						{
							list.Add(new SelectListItem
							{
								Value = item.Value,
								Text = item.Text
							});
						}
					}
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WsWareHouse");
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return text + "|**|" + JsonConvert.SerializeObject(list);
	}

	public lstLkWareHouseInfoViewModel ShygunIIWhList(string fNumber = "", string tNumber = "")
	{
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		lstLkWareHouseInfoViewModel lstLkWareHouseInfoViewModel = new lstLkWareHouseInfoViewModel();
		bool flag = true;
		int num = 0;
		int rowCount = 100;
		try
		{
			List<LkWareHouseInfoViewModel> list = new List<LkWareHouseInfoViewModel>();
			List<WSspSelectWareHouseWithAccLinkField_Result> list2 = Enumerable.ToList<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)_dbLink.WSspSelectWareHouseWithAccLinkField(withWrhsLinkAccWhCode: false, withWrhsLinkAccWhId: false, withWrhsLinkAccWhIdStr: true, withWrhsLinkAccWareHouses: false, languageID: 0, defaultLanguageID: 0));
			while (flag)
			{
				CRMIdeal.Classes.Helper.OtherSystems.ShygunIISettingViewModel shygunIISetting = CRMIdeal.Classes.Helper.OtherSystems.GetShygunIISetting();
				DomainStock domainStock = new DomainStock();
				domainStock.STNumber.From = fNumber;
				domainStock.STNumber.To = tNumber;
				string JsonResult;
				DataTable dataTableObject = new WebServiceGetStock(shygunIISetting.IP, shygunIISetting.conf, domainStock, num, rowCount).GetDataTableObject(out JsonResult);
				if (dataTableObject != null && ((InternalDataCollectionBase)dataTableObject.Rows).Count > 0)
				{
					List<SelectListItem> list3 = new List<SelectListItem>();
					foreach (DataRow item in (InternalDataCollectionBase)dataTableObject.Rows)
					{
						DataRow val = item;
						LkWareHouseInfoViewModel vm = new LkWareHouseInfoViewModel();
						vm.WrhsName = val[1].ToString();
						vm.WrhsLinkAccWhCode = val[0].ToString();
						vm.WrhsLinkAccWhIdStr = val[3].ToString();
						vm.WrhsLinkAccWhName = val[1].ToString();
						if (list2 != null)
						{
							WSspSelectWareHouseWithAccLinkField_Result wSspSelectWareHouseWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)list2, (Func<WSspSelectWareHouseWithAccLinkField_Result, bool>)((WSspSelectWareHouseWithAccLinkField_Result x) => x.WrhsLinkAccWhIdStr == vm.WrhsLinkAccWhIdStr));
							if (wSspSelectWareHouseWithAccLinkField_Result != null && wSspSelectWareHouseWithAccLinkField_Result.WareHouseID > 0)
							{
								vm.WareHouseID = wSspSelectWareHouseWithAccLinkField_Result.WareHouseID;
							}
						}
						list.Add(vm);
						list3.Add(new SelectListItem
						{
							Value = vm.WrhsLinkAccWhCode,
							Text = vm.WrhsName,
							Selected = false
						});
					}
					lstLkWareHouseInfoViewModel.lst = list;
					lstLkWareHouseInfoViewModel.lstSelectListItem = list3;
				}
				else
				{
					flag = false;
				}
				num += ((num > 0) ? 100 : 101);
			}
			lstLkWareHouseInfoViewModel.isDone = true;
			lstLkWareHouseInfoViewModel.Message = "";
		}
		catch (Exception ex)
		{
			lstLkWareHouseInfoViewModel.isDone = false;
			lstLkWareHouseInfoViewModel.Message = "Error: " + ex.Message;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		base.ViewBag.LinkAccWhListJs = JsonConvert.SerializeObject(lstLkWareHouseInfoViewModel.lst);
		base.ViewBag.LinkAccWhSelectListJs = JsonConvert.SerializeObject(lstLkWareHouseInfoViewModel.lstSelectListItem);
		base.ViewBag.LinkAccWhList = lstLkWareHouseInfoViewModel;
		return lstLkWareHouseInfoViewModel;
	}

	[DynamicAuthorize(ControllerName = "frmManageWarehousesLinkAcc", ActionName = "actCanChangeLinkType")]
	[HttpPost]
	public string ShygunIISyncWarehouseType(int syncType = 1)
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
			DateTime now = DateTime.Now;
			DateTime registerDate = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			_ = Financial.Get().Id;
			short.Parse(Financial.Get().Id.ToString());
			short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
			DbSet<CrmLinkAccShygunIISetting> crmLinkAccShygunIISetting = _dbTbl.CrmLinkAccShygunIISetting;
			ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccShygunIISetting), "x");
			CrmLinkAccShygunIISetting crmLinkAccShygunIISetting2 = Queryable.FirstOrDefault<CrmLinkAccShygunIISetting>((IQueryable<CrmLinkAccShygunIISetting>)crmLinkAccShygunIISetting, Expression.Lambda<Func<CrmLinkAccShygunIISetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)this, typeof(WarehouseController)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (crmLinkAccShygunIISetting2 != null)
			{
				if (crmLinkAccShygunIISetting2.LinkAccShygunIISettingId > 0)
				{
					crmLinkAccShygunIISetting2.PartValue = syncType.ToString();
					crmLinkAccShygunIISetting2.RegisterDate = registerDate;
					crmLinkAccShygunIISetting2.RegisterDatePersian = registerDatePersian;
					crmLinkAccShygunIISetting2.UserId = userId;
					_dbTbl.Entry(crmLinkAccShygunIISetting2).State = EntityState.Modified;
					_dbTbl.SaveChanges();
				}
				else
				{
					result = string.Format(Messages.msgNotSetLinkAccSettingWhRelation, Labels.ShygunII);
				}
			}
			else
			{
				result = Messages.msgUpdateCrmDatabase;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[DynamicAuthorize(ControllerName = "frmDefineWareHouse", ActionName = "actManageWarehousesLinkAcc")]
	public ActionResult ShygunIIManageWarehouseLinkAcc()
	{
		CrmWhList();
		ShygunIIWhList();
		CRMIdeal.Classes.Helper.OtherSystems.ShygunIISettingViewModel shygunIISetting = CRMIdeal.Classes.Helper.OtherSystems.GetShygunIISetting();
		base.ViewBag.SyncTypeId = shygunIISetting.WrhsSyncTypeId;
		return View();
	}

	public List<LkWareHouseInfoViewModel> GetShygunIIWhList(string fNumber = "", string tNumber = "")
	{
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Expected O, but got Unknown
		List<LkWareHouseInfoViewModel> list = new List<LkWareHouseInfoViewModel>();
		bool flag = true;
		int num = 0;
		int rowCount = 100;
		try
		{
			List<WSspSelectWareHouseWithAccLinkField_Result> list2 = Enumerable.ToList<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)_dbLink.WSspSelectWareHouseWithAccLinkField(withWrhsLinkAccWhCode: false, withWrhsLinkAccWhId: false, withWrhsLinkAccWhIdStr: true, withWrhsLinkAccWareHouses: false, languageID: 0, defaultLanguageID: 0));
			while (flag)
			{
				CRMIdeal.Classes.Helper.OtherSystems.ShygunIISettingViewModel shygunIISetting = CRMIdeal.Classes.Helper.OtherSystems.GetShygunIISetting();
				DomainStock domainStock = new DomainStock();
				domainStock.STNumber.From = fNumber;
				domainStock.STNumber.To = tNumber;
				string JsonResult;
				DataTable dataTableObject = new WebServiceGetStock(shygunIISetting.IP, shygunIISetting.conf, domainStock, num, rowCount).GetDataTableObject(out JsonResult);
				if (dataTableObject != null && ((InternalDataCollectionBase)dataTableObject.Rows).Count > 0)
				{
					foreach (DataRow item in (InternalDataCollectionBase)dataTableObject.Rows)
					{
						DataRow val = item;
						LkWareHouseInfoViewModel vm = new LkWareHouseInfoViewModel();
						vm.WrhsName = val[1].ToString();
						vm.WrhsLinkAccWhCode = val[0].ToString();
						vm.WrhsLinkAccWhIdStr = val[3].ToString();
						vm.WrhsLinkAccWhName = val[1].ToString();
						vm.Selected = true;
						if (list2 != null)
						{
							WSspSelectWareHouseWithAccLinkField_Result wSspSelectWareHouseWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)list2, (Func<WSspSelectWareHouseWithAccLinkField_Result, bool>)((WSspSelectWareHouseWithAccLinkField_Result x) => x.WrhsLinkAccWhIdStr == vm.WrhsLinkAccWhIdStr));
							if (wSspSelectWareHouseWithAccLinkField_Result != null && wSspSelectWareHouseWithAccLinkField_Result.WareHouseID > 0)
							{
								vm.WareHouseID = wSspSelectWareHouseWithAccLinkField_Result.WareHouseID;
								vm.Selected = false;
							}
						}
						list.Add(vm);
					}
				}
				else
				{
					flag = false;
				}
				num += ((num > 0) ? 100 : 101);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	public JsonResult GetShygunIIWhListJs(string fNumber = "", string tNumber = "")
	{
		JsonResult jsonResult = Json(GetShygunIIWhList(fNumber, tNumber), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public ActionResult ShygunIIWhImport_Read([DataSourceRequest] DataSourceRequest request)
	{
		JsonResult jsonResult = Json(((IEnumerable)GetShygunIIWhList()).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[HttpPost]
	public string GetShygunIILinkedWhsList()
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
			List<WSspSelectWareHouseWithAccLinkField_Result> list = Enumerable.ToList<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)_dbLink.WSspSelectWareHouseWithAccLinkField(false, false, false, true, lCID, result2));
			if (list != null && list.Count > 0)
			{
				result = JsonConvert.SerializeObject(list);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[DynamicAuthorize(ControllerName = "frmManageWarehousesLinkAcc", ActionName = "actImportWhInfo")]
	public string ShygunIIImportWhInfo(string records = "")
	{
		string text = "";
		try
		{
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			int id = Financial.Get().Id;
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			if (!string.IsNullOrWhiteSpace(records))
			{
				Enumerable.ToList<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)_dbLink.WSspSelectWareHouseWithAccLinkField(withWrhsLinkAccWhCode: false, withWrhsLinkAccWhId: false, withWrhsLinkAccWhIdStr: true, withWrhsLinkAccWareHouses: false, languageID: 0, defaultLanguageID: 0));
				CRMIdeal.Classes.Helper.OtherSystems.GetShygunIISetting();
				List<LkWareHouseInfoViewModel> list = JsonConvert.DeserializeObject<List<LkWareHouseInfoViewModel>>(records);
				int result2 = 0;
				string text2 = Configuration.MaxCountWarehouse.ToString();
				if (text2 != null)
				{
					int.TryParse(text2, out result2);
				}
				if (result2 == 0)
				{
					result2 = 1;
				}
				int valueOrDefault = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)_dbII.WSspReturnActiveWareHouseCount()).GetValueOrDefault();
				if (valueOrDefault >= result2)
				{
					text = Messages.msgErrorInDefinitionIllegalwarehouse1 + " " + result2 + " " + Messages.msgErrorInDefinitionIllegalwarehouse2;
				}
				if (list != null && list.Count > 0)
				{
					list = Enumerable.ToList<LkWareHouseInfoViewModel>(Enumerable.Where<LkWareHouseInfoViewModel>((IEnumerable<LkWareHouseInfoViewModel>)list, (Func<LkWareHouseInfoViewModel, bool>)((LkWareHouseInfoViewModel x) => x.Selected)));
					if (result2 - valueOrDefault <= list.Count)
					{
						text = Messages.msgErrorInDefinitionIllegalwarehouse1 + " " + result2 + " " + Messages.msgErrorInDefinitionIllegalwarehouse2;
					}
				}
				if (string.IsNullOrWhiteSpace(text))
				{
					string json = JsonConvert.SerializeObject(list);
					ObjectParameter objectParameter = new ObjectParameter("ErrorMessage", "");
					_dbLink.CRMspLkWSInsertUpdateWareHouse(json, userId, value2, id, value, registerDatePersian, appType, result, objectParameter, centerId);
					if (!string.IsNullOrWhiteSpace(objectParameter.Value.ToString()))
					{
						text += objectParameter.Value.ToString();
					}
				}
			}
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WsWareHouse");
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return text;
	}

	[DynamicAuthorize(ControllerName = "frmDefineWareHouse", ActionName = "actLinkWarehouseWithAcc")]
	public ActionResult SepLinkedWarehouse()
	{
		base.ViewBag.LinkAccSettingDBList = CRMIdeal.Classes.Helper.OtherSystems.GetLinkAccSettingDB(1);
		return View();
	}

	[HttpPost]
	public JsonResult ActSepLinkedWarehouse(string syncField, int mode, int linkAccSettingDBId)
	{
		string text = "";
		string text2 = "";
		CommonResultStatusViewModel commonResultStatusViewModel = CommonResultStatusViewModel.Success;
		CommonResultViewModel<string> data;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			new List<LinkedCompanyWithAccViewModel>();
			DateTime now = DateTime.Now;
			now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			short.Parse(Financial.Get().Id.ToString());
			_ = UserLogin.CurrentUser.UserId;
			string text3 = "";
			int num = 0;
			if (!UserLogin.IsUserAccess("frmDefineWareHouse", "actLinkWarehouseWithAcc", UserLogin.CurrentUser))
			{
				text3 = text3 + Messages.ErrorNotAccess + "<br>";
				num++;
			}
			if (string.IsNullOrWhiteSpace(syncField))
			{
				text3 = text3 + string.Format(Messages.msgErrorIsNotSelectedItem, Labels.OtherSystemsLinkedField) + "<br>";
				num++;
			}
			if (num == 0)
			{
				string text4 = "";
				text = "";
				List<CRMspLkSepWSLinkedWareHouse_Result> list = new List<CRMspLkSepWSLinkedWareHouse_Result>();
				list = Enumerable.ToList<CRMspLkSepWSLinkedWareHouse_Result>((IEnumerable<CRMspLkSepWSLinkedWareHouse_Result>)_dbLink.CRMspLkSepWSLinkedWareHouse(syncField, mode, lCID, result, linkAccSettingDBId));
				if (list != null && Enumerable.Any<CRMspLkSepWSLinkedWareHouse_Result>((IEnumerable<CRMspLkSepWSLinkedWareHouse_Result>)list) && list != null && Enumerable.Any<CRMspLkSepWSLinkedWareHouse_Result>((IEnumerable<CRMspLkSepWSLinkedWareHouse_Result>)list))
				{
					text = "error";
					text4 = GetFileSepLinkedWarehouse(list);
				}
				if (!string.IsNullOrWhiteSpace(text4))
				{
					text2 = Messages.msgNotCompeleteSuccessAction;
					text2 = text2 + "<br><a href='" + text4 + "' class='link-excel-file' target='_blank'>" + Messages.msgLinkForDownloadFileWithError + "</a>";
				}
				else
				{
					text2 = Messages.msgSuccessAction;
				}
				commonResultStatusViewModel = CommonResultStatusViewModel.Success;
			}
			else
			{
				text = "";
				text2 = text3;
				commonResultStatusViewModel = CommonResultStatusViewModel.Error;
			}
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WsWareHouse");
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			text = "";
			data = new CommonResultViewModel<string>
			{
				Data = text,
				Message = Messages.msgErrorRunFunction + "<br>" + ex.Message,
				Status = CommonResultStatusViewModel.Error
			};
			return Json(data, JsonRequestBehavior.AllowGet);
		}
		data = new CommonResultViewModel<string>
		{
			Data = text,
			Message = text2,
			Status = commonResultStatusViewModel
		};
		JsonResult jsonResult = Json(data, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public string GetFileSepLinkedWarehouse(List<CRMspLkSepWSLinkedWareHouse_Result> res)
	{
		//IL_048f: Unknown result type (might be due to invalid IL or missing references)
		//IL_04aa: Unknown result type (might be due to invalid IL or missing references)
		string text = "";
		Guid.NewGuid().ToString();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			short.Parse(Financial.Get().Id.ToString());
			int userId = UserLogin.CurrentUser.UserId;
			if (res != null && Enumerable.Any<CRMspLkSepWSLinkedWareHouse_Result>((IEnumerable<CRMspLkSepWSLinkedWareHouse_Result>)res))
			{
				ExcelPackage excelPackage = new ExcelPackage();
				ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets.Add(Labels.OtherSystemsExcelPropertiesTitle);
				int num = 0;
				int num2 = 1;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsLinkedListWrhsName;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsListWrhsCode;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsListWrhsLinkAccWhCode + " (" + Labels.Sepidar + ")";
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsListLinkAccName;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsListLinkDesc;
				foreach (CRMspLkSepWSLinkedWareHouse_Result re in res)
				{
					num2++;
					num = 0;
					num++;
					excelWorksheet.Cells[num2, num].Value = re.WrhsName ?? "";
					num++;
					excelWorksheet.Cells[num2, num].Value = re.WrhsCode.ToString();
					num++;
					excelWorksheet.Cells[num2, num].Value = re.WrhsLinkAccWhCode ?? "";
					num++;
					string value = "";
					if (re.Type.HasValue)
					{
						if (re.Type.GetValueOrDefault() == 1)
						{
							value = Labels.Sepidar;
						}
						else if (re.Type.GetValueOrDefault() == 2)
						{
							value = "CRM";
						}
					}
					excelWorksheet.Cells[num2, num].Value = value;
					string value2 = "";
					int result2 = 0;
					int.TryParse(re.ErrorType.ToString(), out result2);
					switch (result2)
					{
					case 0:
						value2 = Messages.msgErrorWrhsNotInCRM;
						break;
					case -1:
						value2 = string.Format(Messages.msgErrorDupWrhsLinkAccCode, Labels.Sepidar);
						break;
					case -2:
						value2 = Messages.msgErrorDupWrhsCode;
						break;
					case -3:
						value2 = string.Format(Messages.msgErrorWrhsNotInLinkAcc, Labels.Sepidar);
						break;
					}
					num++;
					excelWorksheet.Cells[num2, num].Value = value2;
				}
				string text2 = base.Server.MapPath(Configuration.HostTempFilesPath) + "\\ReportLinkAccLinked\\" + UserLogin.CurrentUser.UserId;
				string text3 = "CRM-Ideal-" + DateTime.Now.ToString("dd-MM-yyyy-hh-mm-ss") + ".xls";
				string path = text2 + "\\" + text3;
				try
				{
					DirectoryInfo directoryInfo = new DirectoryInfo(text2);
					FileInfo[] files = directoryInfo.GetFiles();
					for (int i = 0; i < files.Length; i++)
					{
						files[i].Delete();
					}
					DirectoryInfo[] directories = directoryInfo.GetDirectories();
					for (int i = 0; i < directories.Length; i++)
					{
						directories[i].Delete(recursive: true);
					}
					if (System.IO.Directory.Exists(text2))
					{
						System.IO.Directory.Delete(text2);
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
				}
				if (!System.IO.Directory.Exists(text2))
				{
					System.IO.Directory.CreateDirectory(text2);
					CRM.General.IO.Directory.SetFullControlForEveryOne(text2);
				}
				using (ExcelRange excelRange = excelWorksheet.Cells[1, 1, 1, num])
				{
					excelRange.Style.Font.Bold = true;
					excelRange.Style.Fill.PatternType = ExcelFillStyle.Solid;
					excelRange.Style.Fill.BackgroundColor.SetColor(Color.DarkBlue);
					excelRange.Style.Font.Color.SetColor(Color.White);
				}
				excelPackage.Workbook.Properties.Title = Labels.OtherSystemsExcelPropertiesTitle;
				excelPackage.Workbook.Properties.Company = Labels.OtherSystemsExcelPropertiesCompany;
				Stream stream = System.IO.File.Create(path);
				excelPackage.SaveAs(stream);
				stream.Close();
				if (System.IO.File.Exists(path))
				{
					text = Configuration.HostTempFilesPath + "/ReportLinkAccLinked/" + userId + "/" + text3;
					text = text.Replace("~/", "/");
					text = (text.StartsWith("/") ? text : ("/" + text));
				}
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return text;
	}

	[DynamicAuthorize(ControllerName = "frmDefineWareHouse", ActionName = "actManageWarehousesLinkAcc")]
	public ActionResult ShomaranManageWarehouseLinkAcc()
	{
		CrmWhList();
		ShomaranWhList();
		CRMIdeal.Classes.Helper.OtherSystems.ShomaranSettingViewModel shomaranSetting = CRMIdeal.Classes.Helper.OtherSystems.GetShomaranSetting();
		base.ViewBag.SyncTypeId = shomaranSetting.WrhsSyncTypeId;
		return View();
	}

	public lstLkWareHouseInfoViewModel ShomaranWhList()
	{
		lstLkWareHouseInfoViewModel lstLkWareHouseInfoViewModel = new lstLkWareHouseInfoViewModel();
		lstLkWareHouseInfoViewModel.lst = new List<LkWareHouseInfoViewModel>();
		lstLkWareHouseInfoViewModel.lstSelectListItem = new List<SelectListItem>();
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			_ = UserLogin.CurrentUser.UserId;
			DateTime now = DateTime.Now;
			now.ToString("yyyy/MM/dd HH:mm:ss");
			DateTimeClass.DefineDayeOfWeekFa(now.DayOfWeek.ToString());
			List<CRMspLkShomaranSelectWareHouse_Result> list = Enumerable.ToList<CRMspLkShomaranSelectWareHouse_Result>((IEnumerable<CRMspLkShomaranSelectWareHouse_Result>)_dbLink.CRMspLkShomaranSelectWareHouse(lCID, result));
			if (list != null && Enumerable.Any<CRMspLkShomaranSelectWareHouse_Result>((IEnumerable<CRMspLkShomaranSelectWareHouse_Result>)list))
			{
				new List<SelectListItem>();
				foreach (CRMspLkShomaranSelectWareHouse_Result item in list)
				{
					LkWareHouseInfoViewModel lkWareHouseInfoViewModel = new LkWareHouseInfoViewModel();
					lkWareHouseInfoViewModel.WrhsName = item.INVNAME ?? "";
					lkWareHouseInfoViewModel.WrhsLinkAccWhCode = item.INVCODE ?? "";
					lkWareHouseInfoViewModel.WrhsLinkAccWhIdStr = item.INVCODE ?? "";
					lkWareHouseInfoViewModel.WrhsLinkAccWhName = item.INVNAME ?? "";
					lkWareHouseInfoViewModel.WareHouseID = item.WareHouseId.GetValueOrDefault();
					lstLkWareHouseInfoViewModel.lst.Add(lkWareHouseInfoViewModel);
					lstLkWareHouseInfoViewModel.lstSelectListItem.Add(new SelectListItem
					{
						Value = lkWareHouseInfoViewModel.WrhsLinkAccWhCode,
						Text = lkWareHouseInfoViewModel.WrhsName,
						Selected = false
					});
				}
			}
			lstLkWareHouseInfoViewModel.isDone = true;
			lstLkWareHouseInfoViewModel.Message = "";
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			lstLkWareHouseInfoViewModel.isDone = false;
			lstLkWareHouseInfoViewModel.Message = "Error: " + ex.Message;
		}
		base.ViewBag.LinkAccWhListJs = JsonConvert.SerializeObject(lstLkWareHouseInfoViewModel.lst);
		base.ViewBag.LinkAccWhSelectListJs = JsonConvert.SerializeObject(lstLkWareHouseInfoViewModel.lstSelectListItem);
		base.ViewBag.LinkAccWhList = lstLkWareHouseInfoViewModel;
		return lstLkWareHouseInfoViewModel;
	}

	[HttpPost]
	public string ShomaranSyncWarehouse(string jsData)
	{
		string text = "";
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		DateTime now = DateTime.Now;
		DateTime dateTime = now;
		string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
		_ = Financial.Get().Id;
		short.Parse(Financial.Get().Id.ToString());
		short num = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
		string appType = Configuration.AppType;
		int userId = UserLogin.CurrentUser.UserId;
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			if (!string.IsNullOrWhiteSpace(jsData) && string.IsNullOrWhiteSpace(text))
			{
				List<CommonWithIdStrViewModel> list2 = JsonConvert.DeserializeObject<List<CommonWithIdStrViewModel>>(jsData);
				if (list2 != null && list2.Count > 0)
				{
					List<SelectListItem> list3 = new List<SelectListItem>();
					foreach (CommonWithIdStrViewModel i in list2)
					{
						if (Enumerable.ToList<SelectListItem>(Enumerable.Where<SelectListItem>((IEnumerable<SelectListItem>)list3, (Func<SelectListItem, bool>)((SelectListItem x) => x.Value == i.Extra))).Count <= 0)
						{
							List<CommonWithIdStrViewModel> list4 = Enumerable.ToList<CommonWithIdStrViewModel>(Enumerable.Where<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list2, (Func<CommonWithIdStrViewModel, bool>)((CommonWithIdStrViewModel x) => x.Extra == i.Extra && !string.IsNullOrWhiteSpace(x.Id))));
							if (list4 == null || list4.Count <= 0)
							{
								list3.Add(new SelectListItem
								{
									Value = i.Extra,
									Text = ""
								});
							}
							else
							{
								list3.Add(new SelectListItem
								{
									Value = i.Extra,
									Text = JsonConvert.SerializeObject(list4)
								});
							}
						}
					}
					foreach (SelectListItem item in list3)
					{
						ObjectParameter objectParameter = new ObjectParameter("ErrorMessage", "");
						_dbLink.CRMspLkWSInsertUpdateWhLinkAccWarehouses(int.Parse(item.Value), item.Text, userId, num, dateTime, registerDatePersian, appType, objectParameter);
						new List<SelectListItem>();
						if (!string.IsNullOrWhiteSpace(item.Text))
						{
							List<CommonWithIdStrViewModel> list5 = JsonConvert.DeserializeObject<List<CommonWithIdStrViewModel>>(item.Text);
							if (list5 != null && Enumerable.Count<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list5) == 1)
							{
								int result2 = 0;
								int.TryParse(Enumerable.FirstOrDefault<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list5).Extra, out result2);
								WsWareHouse wsWareHouse = _dbTbl.WsWareHouse.Find(result2);
								if (wsWareHouse != null)
								{
									wsWareHouse.WrhsLinkAccWhIdStr = Enumerable.FirstOrDefault<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list5).Id;
									wsWareHouse.WrhsLinkAccWhCode = Enumerable.FirstOrDefault<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list5).Code;
									wsWareHouse.WrhsLinkAccWhName = Enumerable.FirstOrDefault<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list5).Name;
									wsWareHouse.AppType = appType;
									wsWareHouse.UserId = userId;
									wsWareHouse.Month1 = num;
									wsWareHouse.RegisterDate = dateTime;
									wsWareHouse.RegisterDatePersian = registerDatePersian;
									_dbTbl.Entry(wsWareHouse).State = EntityState.Modified;
									_dbTbl.Configuration.ValidateOnSaveEnabled = false;
									_dbTbl.SaveChanges();
									_dbTbl.Configuration.ValidateOnSaveEnabled = true;
								}
							}
						}
						if (objectParameter.Value != null)
						{
							if (!string.IsNullOrEmpty(objectParameter.Value.ToString()))
							{
								text = text + objectParameter.Value.ToString() + "|";
								continue;
							}
							list.Add(new SelectListItem
							{
								Value = item.Value,
								Text = item.Text
							});
						}
						else
						{
							list.Add(new SelectListItem
							{
								Value = item.Value,
								Text = item.Text
							});
						}
					}
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WsWareHouse");
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return text + "|**|" + JsonConvert.SerializeObject(list);
	}

	[DynamicAuthorize(ControllerName = "frmManageWarehousesLinkAcc", ActionName = "actCanChangeLinkType")]
	[HttpPost]
	public string ShomaranSyncWarehouseType(int syncType = 1)
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
			DateTime now = DateTime.Now;
			DateTime registerDate = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			_ = Financial.Get().Id;
			short.Parse(Financial.Get().Id.ToString());
			short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
			DbSet<CrmLinkAccShomaranSetting> crmLinkAccShomaranSetting = _dbTbl.CrmLinkAccShomaranSetting;
			ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccShomaranSetting), "x");
			CrmLinkAccShomaranSetting crmLinkAccShomaranSetting2 = Queryable.FirstOrDefault<CrmLinkAccShomaranSetting>((IQueryable<CrmLinkAccShomaranSetting>)crmLinkAccShomaranSetting, Expression.Lambda<Func<CrmLinkAccShomaranSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)this, typeof(WarehouseController)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (crmLinkAccShomaranSetting2 != null)
			{
				if (crmLinkAccShomaranSetting2.LinkAccShomaranSettingId > 0)
				{
					crmLinkAccShomaranSetting2.PartValue = syncType.ToString();
					crmLinkAccShomaranSetting2.RegisterDate = registerDate;
					crmLinkAccShomaranSetting2.RegisterDatePersian = registerDatePersian;
					crmLinkAccShomaranSetting2.UserId = userId;
					_dbTbl.Entry(crmLinkAccShomaranSetting2).State = EntityState.Modified;
					_dbTbl.SaveChanges();
				}
				else
				{
					result = string.Format(Messages.msgNotSetLinkAccSettingWhRelation, Labels.Shomaran);
				}
			}
			else
			{
				result = Messages.msgUpdateCrmDatabase;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public List<LkWareHouseInfoViewModel> GetShomaranWhList()
	{
		List<LkWareHouseInfoViewModel> list = new List<LkWareHouseInfoViewModel>();
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			CRMIdeal.Classes.Helper.OtherSystems.GetShomaranSetting();
			List<CRMspLkShomaranSelectWareHouse_Result> list2 = Enumerable.ToList<CRMspLkShomaranSelectWareHouse_Result>((IEnumerable<CRMspLkShomaranSelectWareHouse_Result>)_dbLink.CRMspLkShomaranSelectWareHouse(lCID, result));
			if (list2 != null && Enumerable.Any<CRMspLkShomaranSelectWareHouse_Result>((IEnumerable<CRMspLkShomaranSelectWareHouse_Result>)list2))
			{
				foreach (CRMspLkShomaranSelectWareHouse_Result item in list2)
				{
					LkWareHouseInfoViewModel lkWareHouseInfoViewModel = new LkWareHouseInfoViewModel();
					lkWareHouseInfoViewModel.WrhsName = item.INVNAME ?? "";
					lkWareHouseInfoViewModel.WrhsLinkAccWhCode = item.INVCODE ?? "";
					lkWareHouseInfoViewModel.WrhsLinkAccWhIdStr = item.INVCODE ?? "";
					lkWareHouseInfoViewModel.WrhsLinkAccWhName = item.INVNAME ?? "";
					if (item.WareHouseId.GetValueOrDefault() == 0)
					{
						lkWareHouseInfoViewModel.Selected = true;
					}
					else
					{
						lkWareHouseInfoViewModel.WareHouseID = item.WareHouseId.GetValueOrDefault();
						lkWareHouseInfoViewModel.Selected = false;
					}
					list.Add(lkWareHouseInfoViewModel);
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	public JsonResult GetShomaranWhListJs()
	{
		JsonResult jsonResult = Json(GetShomaranWhList(), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public ActionResult ShomaranWhImport_Read([DataSourceRequest] DataSourceRequest request)
	{
		List<LkWareHouseInfoViewModel> list = GetShomaranWhList();
		if (list != null)
		{
			if (Enumerable.Any<LkWareHouseInfoViewModel>((IEnumerable<LkWareHouseInfoViewModel>)list))
			{
				foreach (LkWareHouseInfoViewModel item in list)
				{
					if (!string.IsNullOrWhiteSpace(item.WrhsLinkAccWhCode) && string.IsNullOrWhiteSpace(item.WrhsCode))
					{
						item.WrhsCode = item.WrhsLinkAccWhCode;
					}
				}
			}
		}
		else
		{
			list = new List<LkWareHouseInfoViewModel>();
		}
		JsonResult jsonResult = Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[HttpPost]
	public string GetShomaranLinkedWhsList()
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
			List<WSspSelectWareHouseWithAccLinkField_Result> list = Enumerable.ToList<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)_dbLink.WSspSelectWareHouseWithAccLinkField(false, false, false, true, lCID, result2));
			if (list != null && list.Count > 0)
			{
				result = JsonConvert.SerializeObject(list);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[DynamicAuthorize(ControllerName = "frmManageWarehousesLinkAcc", ActionName = "actImportWhInfo")]
	public string ShomaranImportWhInfo(string records = "")
	{
		string text = "";
		try
		{
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			int id = Financial.Get().Id;
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			if (!string.IsNullOrWhiteSpace(records))
			{
				Enumerable.ToList<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)_dbLink.WSspSelectWareHouseWithAccLinkField(withWrhsLinkAccWhCode: false, withWrhsLinkAccWhId: false, withWrhsLinkAccWhIdStr: true, withWrhsLinkAccWareHouses: false, languageID: 0, defaultLanguageID: 0));
				CRMIdeal.Classes.Helper.OtherSystems.GetShomaranSetting();
				List<LkWareHouseInfoViewModel> list = JsonConvert.DeserializeObject<List<LkWareHouseInfoViewModel>>(records);
				int result2 = 0;
				string text2 = Configuration.MaxCountWarehouse.ToString();
				if (text2 != null)
				{
					int.TryParse(text2, out result2);
				}
				if (result2 == 0)
				{
					result2 = 1;
				}
				int valueOrDefault = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)_dbII.WSspReturnActiveWareHouseCount()).GetValueOrDefault();
				if (valueOrDefault >= result2)
				{
					text = Messages.msgErrorInDefinitionIllegalwarehouse1 + " " + result2 + " " + Messages.msgErrorInDefinitionIllegalwarehouse2;
				}
				if (list != null && list.Count > 0)
				{
					list = Enumerable.ToList<LkWareHouseInfoViewModel>(Enumerable.Where<LkWareHouseInfoViewModel>((IEnumerable<LkWareHouseInfoViewModel>)list, (Func<LkWareHouseInfoViewModel, bool>)((LkWareHouseInfoViewModel x) => x.Selected)));
					if (result2 - valueOrDefault < list.Count)
					{
						text = Messages.msgErrorInDefinitionIllegalwarehouse1 + " " + result2 + " " + Messages.msgErrorInDefinitionIllegalwarehouse2;
					}
				}
				if (string.IsNullOrWhiteSpace(text))
				{
					string json = JsonConvert.SerializeObject(list);
					ObjectParameter objectParameter = new ObjectParameter("ErrorMessage", "");
					_dbLink.CRMspLkWSInsertUpdateWareHouse(json, userId, value2, id, value, registerDatePersian, appType, result, objectParameter, centerId);
					if (!string.IsNullOrWhiteSpace(objectParameter.Value.ToString()))
					{
						text += objectParameter.Value.ToString();
					}
				}
			}
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WsWareHouse");
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return text;
	}

	public List<WSspSelectWareHouseWithAccLinkField_Result> SelectWareHouseWithAccLinkField(bool withWrhsLinkAccWhId = false, bool withWrhsLinkAccWhIdStr = false, bool withWrhsLinkAccWhCode = false, bool withWrhsLinkAccWareHouses = false)
	{
		List<WSspSelectWareHouseWithAccLinkField_Result> result = new List<WSspSelectWareHouseWithAccLinkField_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<WSspSelectWareHouseWithAccLinkField_Result> list = Enumerable.ToList<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)_dbLink.WSspSelectWareHouseWithAccLinkField(withWrhsLinkAccWhId, withWrhsLinkAccWhIdStr: withWrhsLinkAccWhIdStr, withWrhsLinkAccWhCode: withWrhsLinkAccWhCode, withWrhsLinkAccWareHouses: withWrhsLinkAccWareHouses, languageID: lCID, defaultLanguageID: result2));
			if (list != null)
			{
				result = list;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[DynamicAuthorize(ControllerName = "frmDefineWareHouse", ActionName = "actLinkWarehouseWithAcc")]
	public ActionResult ImportWarehouse()
	{
		return View();
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmDefineWareHouse", ActionName = "actLinkWarehouseWithAcc")]
	public string WarehouseImport(string js = "", string linkAccName = "", bool canUpdate = false)
	{
		string result = "";
		try
		{
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			int id = Financial.Get().Id;
			short result2 = 0;
			short.TryParse(id.ToString(), out result2);
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result3);
			if (result3 <= 0)
			{
				result3 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (!string.IsNullOrWhiteSpace(js))
			{
				ObjectParameter errorMessage = new ObjectParameter("ErrorMessage", "");
				_dbLink.CRMspLkImportWareHouse(js, linkAccName, canUpdate, id, result2, value2, userId, value, registerDatePersian, appType, lCID, result3, errorMessage);
			}
			else
			{
				result = Messages.msgErrorNotSelectedItem;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result = ex.Message;
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetPayvastWhList(int isLinkedType = 1)
	{
		string result = "";
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		if (result2 <= 0)
		{
			result2 = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		LkWareHouseViewModel lkWareHouseViewModel = new LkWareHouseViewModel();
		lkWareHouseViewModel.List = new List<LkWareHouseInfoViewModel>();
		try
		{
			AccountingServiceSoapClient accountingServiceSoapClient = new AccountingServiceSoapClient();
			PayvastSettingViewModel payvastSetting = CRMIdeal.Classes.Helper.OtherSystems.GetPayvastSetting();
			List<StockRoom> list = Enumerable.ToList<StockRoom>((IEnumerable<StockRoom>)accountingServiceSoapClient.GetStockRoomsInfo(payvastSetting.PayvastUsername, payvastSetting.PayvastPassword, -1, CRMIdeal.Classes.Helper.OtherSystems.GetPayvastFPId(DateTime.Now)));
			List<WSspSelectWareHouseWithAccLinkField_Result> LinkedWhs = SelectWareHouseWithAccLinkField(withWrhsLinkAccWhId: true);
			switch (isLinkedType)
			{
			case 1:
				list = Enumerable.ToList<StockRoom>(Enumerable.Where<StockRoom>((IEnumerable<StockRoom>)list, (Func<StockRoom, bool>)((StockRoom x) => Enumerable.FirstOrDefault<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)LinkedWhs, (Func<WSspSelectWareHouseWithAccLinkField_Result, bool>)((WSspSelectWareHouseWithAccLinkField_Result f) => f.WrhsLinkAccWhId == x.Id)) == null)));
				break;
			case 2:
				list = Enumerable.ToList<StockRoom>(Enumerable.Where<StockRoom>((IEnumerable<StockRoom>)list, (Func<StockRoom, bool>)((StockRoom x) => Enumerable.FirstOrDefault<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)LinkedWhs, (Func<WSspSelectWareHouseWithAccLinkField_Result, bool>)((WSspSelectWareHouseWithAccLinkField_Result f) => f.WrhsLinkAccWhId == x.Id)) != null)));
				break;
			}
			foreach (StockRoom item in list)
			{
				if (item.Id != 0 && !string.IsNullOrWhiteSpace(item.Name))
				{
					LkWareHouseInfoViewModel vm = new LkWareHouseInfoViewModel();
					vm.WrhsName = item.Name;
					vm.WrhsDescription = item.Description;
					vm.WrhsLinkAccWhId = item.Id;
					vm.WrhsLinkAccWhIdStr = item.Id.ToString();
					vm.WrhsLinkAccWhCode = item.Code.ToString();
					vm.GUId = Guid.NewGuid();
					WSspSelectWareHouseWithAccLinkField_Result wSspSelectWareHouseWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)LinkedWhs, (Func<WSspSelectWareHouseWithAccLinkField_Result, bool>)((WSspSelectWareHouseWithAccLinkField_Result x) => x.WrhsLinkAccWhId == vm.WrhsLinkAccWhId));
					vm.Selected = wSspSelectWareHouseWithAccLinkField_Result == null;
					vm.WareHouseID = wSspSelectWareHouseWithAccLinkField_Result?.WareHouseID ?? 0;
					lkWareHouseViewModel.List.Add(vm);
				}
			}
			result = JsonConvert.SerializeObject(lkWareHouseViewModel);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public string Arpa_GetToken()
	{
		string text = "";
		try
		{
			CRMIdeal.Classes.Helper.OtherSystems.ArpaSettingViewModel arpaSetting = CRMIdeal.Classes.Helper.OtherSystems.GetArpaSetting();
			if (arpaSetting != null)
			{
				string text2 = arpaSetting.ArpaServerAddress ?? "";
				string text3 = arpaSetting.ArpaUserName ?? "";
				string text4 = arpaSetting.ArpaPassword ?? "";
				if (!string.IsNullOrWhiteSpace(text2) && !text2.EndsWith("serv/"))
				{
					text2 += "serv/";
				}
				if (!string.IsNullOrWhiteSpace(text2) && !string.IsNullOrWhiteSpace(text3) && !string.IsNullOrWhiteSpace(text4))
				{
					HttpClient httpClient = new HttpClient();
					string text5 = string.Format(text2 + "token/GetServiceToken?username={0}&password={1}", text3, text4);
					httpClient.BaseAddress = new Uri(text5);
					httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
					HttpContent content = new StringContent("", Encoding.UTF8, "application/json");
					HttpResponseMessage result = httpClient.PostAsync(text5, content).Result;
					if (result.IsSuccessStatusCode)
					{
						string result2 = result.Content.ReadAsStringAsync().Result;
						if (!string.IsNullOrWhiteSpace(result2))
						{
							text = result2 ?? "";
							if (!string.IsNullOrWhiteSpace(text))
							{
								text = "Bearer " + text;
							}
						}
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			text = "";
		}
		return text;
	}

	public ArpaWarehouseInfoViewModelObjects GetArpaWareHouseList()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		ArpaWarehouseInfoViewModelObjects arpaWarehouseInfoViewModelObjects = new ArpaWarehouseInfoViewModelObjects();
		arpaWarehouseInfoViewModelObjects.lst = new List<LkWareHouseInfoViewModel>();
		arpaWarehouseInfoViewModelObjects.FilteredLst = new List<LkWareHouseInfoViewModel>();
		List<LkWareHouseInfoViewModel> list = new List<LkWareHouseInfoViewModel>();
		try
		{
			string value = Arpa_GetToken();
			if (!string.IsNullOrWhiteSpace(value))
			{
				CRMIdeal.Classes.Helper.OtherSystems.ArpaSettingViewModel arpaSetting = CRMIdeal.Classes.Helper.OtherSystems.GetArpaSetting();
				if (arpaSetting != null)
				{
					string text = arpaSetting.ArpaServerAddress ?? "";
					string defUserGroupId = arpaSetting.DefUserGroupId;
					if (!string.IsNullOrWhiteSpace(text) && !text.EndsWith("serv/"))
					{
						text += "serv/";
					}
					if (!string.IsNullOrWhiteSpace(text))
					{
						string text2 = "";
						if (!string.IsNullOrWhiteSpace(defUserGroupId))
						{
							text2 = text2 + "?UserGroupID=" + defUserGroupId;
						}
						HttpClient httpClient = new HttpClient();
						string text3 = text + "api/GetStockAreas" + text2;
						httpClient.BaseAddress = new Uri(text3);
						httpClient.DefaultRequestHeaders.Add("Authorization", value);
						httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
						HttpContent content = new StringContent("", Encoding.UTF8, "application/json");
						HttpResponseMessage result2 = httpClient.PostAsync(text3, content).Result;
						if (result2.IsSuccessStatusCode)
						{
							string value2 = result2.Content.ReadAsStringAsync().Result;
							if (!string.IsNullOrWhiteSpace(value2))
							{
								value2 = value2.ClearHiddenCharacters();
							}
							ArpaWarehouseResponseViewModel arpaWarehouseResponseViewModel = JsonConvert.DeserializeObject<ArpaWarehouseResponseViewModel>(value2);
							if (arpaWarehouseResponseViewModel != null && arpaWarehouseResponseViewModel.data != null && Enumerable.Any<ArpaWarehouseInfoViewModel>((IEnumerable<ArpaWarehouseInfoViewModel>)arpaWarehouseResponseViewModel.data))
							{
								List<WSspSelectWareHouseWithAccLinkField_Result> list2 = Enumerable.ToList<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)_dbLink.WSspSelectWareHouseWithAccLinkField(false, false, false, true, lCID, result));
								int num = 1;
								foreach (ArpaWarehouseInfoViewModel item in arpaWarehouseResponseViewModel.data)
								{
									LkWareHouseInfoViewModel lkWareHouseInfoViewModel = new LkWareHouseInfoViewModel();
									lkWareHouseInfoViewModel.WrhsName = item.StockAreaName;
									lkWareHouseInfoViewModel.WrhsLinkAccWhCode = item.StockAreaCode;
									lkWareHouseInfoViewModel.WrhsLinkAccWhIdStr = item.StockAreaID;
									lkWareHouseInfoViewModel.RowNumber = num;
									WSspSelectWareHouseWithAccLinkField_Result wSspSelectWareHouseWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)list2, (Func<WSspSelectWareHouseWithAccLinkField_Result, bool>)((WSspSelectWareHouseWithAccLinkField_Result x) => x.WrhsLinkAccWhIdStr == item.StockAreaID));
									if (wSspSelectWareHouseWithAccLinkField_Result != null && !string.IsNullOrWhiteSpace(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWhIdStr))
									{
										lkWareHouseInfoViewModel.WareHouseID = wSspSelectWareHouseWithAccLinkField_Result.WareHouseID;
										lkWareHouseInfoViewModel.Selected = false;
									}
									else
									{
										lkWareHouseInfoViewModel.WareHouseID = 0;
										lkWareHouseInfoViewModel.Selected = true;
									}
									list.Add(lkWareHouseInfoViewModel);
									num++;
								}
							}
						}
					}
				}
			}
			arpaWarehouseInfoViewModelObjects.lst = list;
			arpaWarehouseInfoViewModelObjects.FilteredLst = list;
			arpaWarehouseInfoViewModelObjects.Json = Json(list, JsonRequestBehavior.AllowGet);
			arpaWarehouseInfoViewModelObjects.SerializedJson = JsonConvert.SerializeObject(list);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return arpaWarehouseInfoViewModelObjects;
	}

	public lstLkWareHouseInfoViewModel ArpaWhList()
	{
		lstLkWareHouseInfoViewModel lstLkWareHouseInfoViewModel = new lstLkWareHouseInfoViewModel();
		lstLkWareHouseInfoViewModel.lst = new List<LkWareHouseInfoViewModel>();
		lstLkWareHouseInfoViewModel.lstSelectListItem = new List<SelectListItem>();
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			_ = UserLogin.CurrentUser.UserId;
			DateTime now = DateTime.Now;
			now.ToString("yyyy/MM/dd HH:mm:ss");
			DateTimeClass.DefineDayeOfWeekFa(now.DayOfWeek.ToString());
			ArpaWarehouseInfoViewModelObjects arpaWareHouseList = GetArpaWareHouseList();
			if (arpaWareHouseList != null)
			{
				List<LkWareHouseInfoViewModel> lst = arpaWareHouseList.lst;
				if (lst != null && Enumerable.Any<LkWareHouseInfoViewModel>((IEnumerable<LkWareHouseInfoViewModel>)lst))
				{
					new List<SelectListItem>();
					foreach (LkWareHouseInfoViewModel item in lst)
					{
						LkWareHouseInfoViewModel lkWareHouseInfoViewModel = new LkWareHouseInfoViewModel();
						lkWareHouseInfoViewModel.WrhsName = item.WrhsName ?? "";
						lkWareHouseInfoViewModel.WrhsLinkAccWhCode = item.WrhsLinkAccWhCode ?? "";
						lkWareHouseInfoViewModel.WrhsLinkAccWhIdStr = item.WrhsLinkAccWhIdStr ?? "";
						lkWareHouseInfoViewModel.WrhsLinkAccWhName = item.WrhsName ?? "";
						lkWareHouseInfoViewModel.WareHouseID = item.WareHouseID;
						lstLkWareHouseInfoViewModel.lst.Add(lkWareHouseInfoViewModel);
						lstLkWareHouseInfoViewModel.lstSelectListItem.Add(new SelectListItem
						{
							Value = lkWareHouseInfoViewModel.WrhsLinkAccWhCode,
							Text = lkWareHouseInfoViewModel.WrhsName,
							Selected = false
						});
					}
				}
			}
			lstLkWareHouseInfoViewModel.isDone = true;
			lstLkWareHouseInfoViewModel.Message = "";
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			lstLkWareHouseInfoViewModel.isDone = false;
			lstLkWareHouseInfoViewModel.Message = "Error: " + ex.Message;
		}
		base.ViewBag.LinkAccWhListJs = JsonConvert.SerializeObject(lstLkWareHouseInfoViewModel.lst);
		base.ViewBag.LinkAccWhSelectListJs = JsonConvert.SerializeObject(lstLkWareHouseInfoViewModel.lstSelectListItem);
		base.ViewBag.LinkAccWhList = lstLkWareHouseInfoViewModel;
		return lstLkWareHouseInfoViewModel;
	}

	public WarehouseInfoViewModelObjects GetHamrahanWareHouseList()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		WarehouseInfoViewModelObjects warehouseInfoViewModelObjects = new WarehouseInfoViewModelObjects();
		warehouseInfoViewModelObjects.lst = new List<LkWareHouseInfoViewModel>();
		warehouseInfoViewModelObjects.FilteredLst = new List<LkWareHouseInfoViewModel>();
		List<LkWareHouseInfoViewModel> list = new List<LkWareHouseInfoViewModel>();
		try
		{
			string value = new LinkAccHamrahanSettingController().Hamrahan_GetToken();
			if (!string.IsNullOrWhiteSpace(value))
			{
				CRMIdeal.Classes.Helper.OtherSystems.HamrahanSettingViewModel hamrahanSetting = CRMIdeal.Classes.Helper.OtherSystems.GetHamrahanSetting();
				if (hamrahanSetting != null)
				{
					string text = hamrahanSetting.HamrahanApiAddress ?? "";
					string text2 = hamrahanSetting.HamrahanApiVersion ?? "";
					string text3 = hamrahanSetting.HamrahanCompanyId ?? "";
					if (!string.IsNullOrWhiteSpace(text) && !string.IsNullOrWhiteSpace(text2) && !string.IsNullOrWhiteSpace(text3))
					{
						if (!text.EndsWith("/"))
						{
							text += "/";
						}
						if (!text.EndsWith("api/"))
						{
							text += "api/";
						}
						text = text + "v" + text2 + "/";
						HttpClient httpClient = new HttpClient();
						string text4 = text + "DefineCellar/company/" + text3;
						httpClient.BaseAddress = new Uri(text4);
						httpClient.DefaultRequestHeaders.Add("Authorization", value);
						httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
						new StringContent("", Encoding.UTF8, "application/json");
						HttpResponseMessage result2 = httpClient.GetAsync(text4).Result;
						if (result2.IsSuccessStatusCode)
						{
							string value2 = result2.Content.ReadAsStringAsync().Result;
							if (!string.IsNullOrWhiteSpace(value2))
							{
								value2 = value2.ClearHiddenCharacters();
							}
							if (!string.IsNullOrWhiteSpace(value2))
							{
								List<HamrahanWarehouseInfoViewModel> list2 = JsonConvert.DeserializeObject<List<HamrahanWarehouseInfoViewModel>>(value2);
								if (list2 != null && Enumerable.Any<HamrahanWarehouseInfoViewModel>((IEnumerable<HamrahanWarehouseInfoViewModel>)list2))
								{
									List<WSspSelectWareHouseWithAccLinkField_Result> list3 = Enumerable.ToList<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)_dbLink.WSspSelectWareHouseWithAccLinkField(false, false, false, true, lCID, result));
									int num = 1;
									foreach (HamrahanWarehouseInfoViewModel item in list2)
									{
										LkWareHouseInfoViewModel vm = new LkWareHouseInfoViewModel();
										vm.WrhsName = item.nameCellar;
										vm.WrhsLinkAccWhCode = item.codeCellar;
										vm.WrhsLinkAccWhIdStr = item.recNo.GetValueOrDefault().ToString();
										vm.RowNumber = num;
										WSspSelectWareHouseWithAccLinkField_Result wSspSelectWareHouseWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)list3, (Func<WSspSelectWareHouseWithAccLinkField_Result, bool>)((WSspSelectWareHouseWithAccLinkField_Result x) => x.WrhsLinkAccWhIdStr == vm.WrhsLinkAccWhIdStr));
										if (wSspSelectWareHouseWithAccLinkField_Result != null && !string.IsNullOrWhiteSpace(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWhIdStr))
										{
											vm.WareHouseID = wSspSelectWareHouseWithAccLinkField_Result.WareHouseID;
											vm.Selected = false;
										}
										else
										{
											vm.WareHouseID = 0;
											vm.Selected = true;
										}
										list.Add(vm);
										num++;
									}
								}
							}
						}
					}
				}
			}
			warehouseInfoViewModelObjects.lst = list;
			warehouseInfoViewModelObjects.FilteredLst = list;
			warehouseInfoViewModelObjects.Json = Json(list, JsonRequestBehavior.AllowGet);
			warehouseInfoViewModelObjects.SerializedJson = JsonConvert.SerializeObject(list);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return warehouseInfoViewModelObjects;
	}

	public lstLkWareHouseInfoViewModel HamrahanWhList()
	{
		lstLkWareHouseInfoViewModel lstLkWareHouseInfoViewModel = new lstLkWareHouseInfoViewModel();
		lstLkWareHouseInfoViewModel.lst = new List<LkWareHouseInfoViewModel>();
		lstLkWareHouseInfoViewModel.lstSelectListItem = new List<SelectListItem>();
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			_ = UserLogin.CurrentUser.UserId;
			DateTime now = DateTime.Now;
			now.ToString("yyyy/MM/dd HH:mm:ss");
			DateTimeClass.DefineDayeOfWeekFa(now.DayOfWeek.ToString());
			WarehouseInfoViewModelObjects hamrahanWareHouseList = GetHamrahanWareHouseList();
			if (hamrahanWareHouseList != null)
			{
				List<LkWareHouseInfoViewModel> lst = hamrahanWareHouseList.lst;
				if (lst != null && Enumerable.Any<LkWareHouseInfoViewModel>((IEnumerable<LkWareHouseInfoViewModel>)lst))
				{
					new List<SelectListItem>();
					foreach (LkWareHouseInfoViewModel item in lst)
					{
						LkWareHouseInfoViewModel lkWareHouseInfoViewModel = new LkWareHouseInfoViewModel();
						lkWareHouseInfoViewModel.WrhsName = item.WrhsName ?? "";
						lkWareHouseInfoViewModel.WrhsLinkAccWhCode = item.WrhsLinkAccWhCode ?? "";
						lkWareHouseInfoViewModel.WrhsLinkAccWhIdStr = item.WrhsLinkAccWhIdStr ?? "";
						lkWareHouseInfoViewModel.WrhsLinkAccWhName = item.WrhsName ?? "";
						lkWareHouseInfoViewModel.WareHouseID = item.WareHouseID;
						lstLkWareHouseInfoViewModel.lst.Add(lkWareHouseInfoViewModel);
						lstLkWareHouseInfoViewModel.lstSelectListItem.Add(new SelectListItem
						{
							Value = lkWareHouseInfoViewModel.WrhsLinkAccWhCode,
							Text = lkWareHouseInfoViewModel.WrhsName,
							Selected = false
						});
					}
				}
			}
			lstLkWareHouseInfoViewModel.isDone = true;
			lstLkWareHouseInfoViewModel.Message = "";
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			lstLkWareHouseInfoViewModel.isDone = false;
			lstLkWareHouseInfoViewModel.Message = "Error: " + ex.Message;
		}
		base.ViewBag.LinkAccWhListJs = JsonConvert.SerializeObject(lstLkWareHouseInfoViewModel.lst);
		base.ViewBag.LinkAccWhSelectListJs = JsonConvert.SerializeObject(lstLkWareHouseInfoViewModel.lstSelectListItem);
		base.ViewBag.LinkAccWhList = lstLkWareHouseInfoViewModel;
		return lstLkWareHouseInfoViewModel;
	}

	public WarehouseInfoViewModelObjects GetNoAvaranCapillaryWareHouseList()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		WarehouseInfoViewModelObjects warehouseInfoViewModelObjects = new WarehouseInfoViewModelObjects();
		warehouseInfoViewModelObjects.lst = new List<LkWareHouseInfoViewModel>();
		warehouseInfoViewModelObjects.FilteredLst = new List<LkWareHouseInfoViewModel>();
		List<LkWareHouseInfoViewModel> list = new List<LkWareHouseInfoViewModel>();
		try
		{
			CRMIdeal.Classes.Helper.OtherSystems.NoAvaranCapillarySettingViewModel noAvaranCapillarySetting = CRMIdeal.Classes.Helper.OtherSystems.GetNoAvaranCapillarySetting();
			if (noAvaranCapillarySetting != null && !string.IsNullOrWhiteSpace(noAvaranCapillarySetting.ApiUserId ?? ""))
			{
				string value = new CommercialSoapClient().ReadFromStore();
				if (!string.IsNullOrWhiteSpace(value))
				{
					value = value.ClearHiddenCharacters();
				}
				if (!string.IsNullOrWhiteSpace(value))
				{
					List<NoAvaranCapillaryWarehouseInfoViewModel> list2 = JsonConvert.DeserializeObject<List<NoAvaranCapillaryWarehouseInfoViewModel>>(value);
					if (list2 != null && Enumerable.Any<NoAvaranCapillaryWarehouseInfoViewModel>((IEnumerable<NoAvaranCapillaryWarehouseInfoViewModel>)list2))
					{
						List<WSspSelectWareHouseWithAccLinkField_Result> list3 = Enumerable.ToList<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)_dbLink.WSspSelectWareHouseWithAccLinkField(false, false, false, true, lCID, result));
						int num = 1;
						foreach (NoAvaranCapillaryWarehouseInfoViewModel item in list2)
						{
							LkWareHouseInfoViewModel vm = new LkWareHouseInfoViewModel();
							vm.WrhsName = item.Name;
							vm.WrhsLinkAccWhCode = item.Code.GetValueOrDefault().ToString();
							vm.WrhsLinkAccWhIdStr = item.id.GetValueOrDefault().ToString();
							vm.RowNumber = num;
							WSspSelectWareHouseWithAccLinkField_Result wSspSelectWareHouseWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)list3, (Func<WSspSelectWareHouseWithAccLinkField_Result, bool>)((WSspSelectWareHouseWithAccLinkField_Result x) => x.WrhsLinkAccWhIdStr == vm.WrhsLinkAccWhIdStr));
							if (wSspSelectWareHouseWithAccLinkField_Result != null && !string.IsNullOrWhiteSpace(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWhIdStr))
							{
								vm.WareHouseID = wSspSelectWareHouseWithAccLinkField_Result.WareHouseID;
								vm.Selected = false;
							}
							else
							{
								vm.WareHouseID = 0;
								vm.Selected = true;
							}
							list.Add(vm);
							num++;
						}
					}
				}
			}
			warehouseInfoViewModelObjects.lst = list;
			warehouseInfoViewModelObjects.FilteredLst = list;
			warehouseInfoViewModelObjects.Json = Json(list, JsonRequestBehavior.AllowGet);
			warehouseInfoViewModelObjects.SerializedJson = JsonConvert.SerializeObject(list);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return warehouseInfoViewModelObjects;
	}

	public lstLkWareHouseInfoViewModel NoAvaranCapillaryWhList()
	{
		lstLkWareHouseInfoViewModel lstLkWareHouseInfoViewModel = new lstLkWareHouseInfoViewModel();
		lstLkWareHouseInfoViewModel.lst = new List<LkWareHouseInfoViewModel>();
		lstLkWareHouseInfoViewModel.lstSelectListItem = new List<SelectListItem>();
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			_ = UserLogin.CurrentUser.UserId;
			DateTime now = DateTime.Now;
			now.ToString("yyyy/MM/dd HH:mm:ss");
			DateTimeClass.DefineDayeOfWeekFa(now.DayOfWeek.ToString());
			WarehouseInfoViewModelObjects noAvaranCapillaryWareHouseList = GetNoAvaranCapillaryWareHouseList();
			if (noAvaranCapillaryWareHouseList != null)
			{
				List<LkWareHouseInfoViewModel> lst = noAvaranCapillaryWareHouseList.lst;
				if (lst != null && Enumerable.Any<LkWareHouseInfoViewModel>((IEnumerable<LkWareHouseInfoViewModel>)lst))
				{
					new List<SelectListItem>();
					foreach (LkWareHouseInfoViewModel item in lst)
					{
						LkWareHouseInfoViewModel lkWareHouseInfoViewModel = new LkWareHouseInfoViewModel();
						lkWareHouseInfoViewModel.WrhsName = item.WrhsName ?? "";
						lkWareHouseInfoViewModel.WrhsLinkAccWhCode = item.WrhsLinkAccWhCode ?? "";
						lkWareHouseInfoViewModel.WrhsLinkAccWhIdStr = item.WrhsLinkAccWhIdStr ?? "";
						lkWareHouseInfoViewModel.WrhsLinkAccWhName = item.WrhsName ?? "";
						lkWareHouseInfoViewModel.WareHouseID = item.WareHouseID;
						lstLkWareHouseInfoViewModel.lst.Add(lkWareHouseInfoViewModel);
						lstLkWareHouseInfoViewModel.lstSelectListItem.Add(new SelectListItem
						{
							Value = lkWareHouseInfoViewModel.WrhsLinkAccWhCode,
							Text = lkWareHouseInfoViewModel.WrhsName,
							Selected = false
						});
					}
				}
			}
			lstLkWareHouseInfoViewModel.isDone = true;
			lstLkWareHouseInfoViewModel.Message = "";
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			lstLkWareHouseInfoViewModel.isDone = false;
			lstLkWareHouseInfoViewModel.Message = "Error: " + ex.Message;
		}
		base.ViewBag.LinkAccWhListJs = JsonConvert.SerializeObject(lstLkWareHouseInfoViewModel.lst);
		base.ViewBag.LinkAccWhSelectListJs = JsonConvert.SerializeObject(lstLkWareHouseInfoViewModel.lstSelectListItem);
		base.ViewBag.LinkAccWhList = lstLkWareHouseInfoViewModel;
		return lstLkWareHouseInfoViewModel;
	}

	public WarehouseInfoViewModelObjects GetRahkaranRetailWareHouseList(string cookieVal)
	{
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Expected O, but got Unknown
		//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Invalid comparison between Unknown and I4
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		WarehouseInfoViewModelObjects warehouseInfoViewModelObjects = new WarehouseInfoViewModelObjects();
		warehouseInfoViewModelObjects.lst = new List<LkWareHouseInfoViewModel>();
		warehouseInfoViewModelObjects.FilteredLst = new List<LkWareHouseInfoViewModel>();
		List<LkWareHouseInfoViewModel> list = new List<LkWareHouseInfoViewModel>();
		try
		{
			if (!string.IsNullOrWhiteSpace(cookieVal))
			{
				string text = new LinkAccRahkaranRetailSettingController().Rahkaran_GetCooKie(cookieVal);
				if (!string.IsNullOrWhiteSpace(text))
				{
					CRMIdeal.Classes.Helper.OtherSystems.RahkaranRetailSettingViewModel rahkaranRetailSetting = CRMIdeal.Classes.Helper.OtherSystems.GetRahkaranRetailSetting();
					if (rahkaranRetailSetting != null)
					{
						string text2 = rahkaranRetailSetting.ApiAddress ?? "";
						if (!string.IsNullOrWhiteSpace(text2) && !text2.EndsWith("/"))
						{
							text2 += "/";
						}
						if (!string.IsNullOrWhiteSpace(text2) && !string.IsNullOrWhiteSpace(text))
						{
							string text3 = text2 + "Services/Retail/ESales.svc/shops?withStores=true";
							string value = "";
							HttpWebRequest val = (HttpWebRequest)WebRequest.Create(text3);
							((NameValueCollection)((WebRequest)val).Headers).Add("Cookie", text);
							((WebRequest)val).ContentType = "application/json; charset=utf-8";
							((WebRequest)val).Method = "GET";
							val.Accept = "application/json";
							object value2 = ((object)val).GetType().GetProperty("CurrentMethod", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(val);
							value2.GetType().GetField("ContentBodyNotAllowed", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(value2, false);
							using (StreamWriter streamWriter = new StreamWriter(((WebRequest)val).GetRequestStream()))
							{
								streamWriter.Write(value);
							}
							HttpWebResponse val2 = (HttpWebResponse)((WebRequest)val).GetResponse();
							StreamReader streamReader = new StreamReader(((WebResponse)val2).GetResponseStream());
							if ((int)val2.StatusCode == 200)
							{
								string value3 = streamReader.ReadToEnd();
								if (!string.IsNullOrWhiteSpace(value3))
								{
									value3 = value3.ClearHiddenCharacters();
								}
								if (!string.IsNullOrWhiteSpace(value3))
								{
									RahkaranRetailShopResponseViewModel rahkaranRetailShopResponseViewModel = JsonConvert.DeserializeObject<RahkaranRetailShopResponseViewModel>(value3);
									if (rahkaranRetailShopResponseViewModel != null && rahkaranRetailShopResponseViewModel.result != null && Enumerable.Any<RahkaranRetailShopInfoViewModel>((IEnumerable<RahkaranRetailShopInfoViewModel>)rahkaranRetailShopResponseViewModel.result))
									{
										List<RahkaranRetailStoresInfoViewModel> list2 = new List<RahkaranRetailStoresInfoViewModel>();
										foreach (RahkaranRetailShopInfoViewModel item in rahkaranRetailShopResponseViewModel.result)
										{
											if (item.stores == null || !Enumerable.Any<RahkaranRetailStoresInfoViewModel>((IEnumerable<RahkaranRetailStoresInfoViewModel>)item.stores))
											{
												continue;
											}
											foreach (RahkaranRetailStoresInfoViewModel store in item.stores)
											{
												bool flag = true;
												if (list2 != null && Enumerable.Any<RahkaranRetailStoresInfoViewModel>((IEnumerable<RahkaranRetailStoresInfoViewModel>)list2))
												{
													RahkaranRetailStoresInfoViewModel rahkaranRetailStoresInfoViewModel = Enumerable.FirstOrDefault<RahkaranRetailStoresInfoViewModel>((IEnumerable<RahkaranRetailStoresInfoViewModel>)list2, (Func<RahkaranRetailStoresInfoViewModel, bool>)((RahkaranRetailStoresInfoViewModel m) => m.id == store.id));
													if (rahkaranRetailStoresInfoViewModel != null && rahkaranRetailStoresInfoViewModel.id.GetValueOrDefault() != 0L)
													{
														flag = false;
													}
												}
												if (flag)
												{
													list2.Add(store);
												}
											}
										}
										if (list2 != null && Enumerable.Any<RahkaranRetailStoresInfoViewModel>((IEnumerable<RahkaranRetailStoresInfoViewModel>)list2))
										{
											List<WSspSelectWareHouseWithAccLinkField_Result> list3 = Enumerable.ToList<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)_dbLink.WSspSelectWareHouseWithAccLinkField(false, false, false, true, lCID, result));
											int num = 1;
											foreach (RahkaranRetailStoresInfoViewModel item2 in list2)
											{
												LkWareHouseInfoViewModel vm = new LkWareHouseInfoViewModel();
												vm.WrhsName = item2.name;
												vm.WrhsLinkAccWhCode = item2.id.GetValueOrDefault().ToString();
												vm.WrhsLinkAccWhIdStr = item2.id.GetValueOrDefault().ToString();
												vm.RowNumber = num;
												WSspSelectWareHouseWithAccLinkField_Result wSspSelectWareHouseWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)list3, (Func<WSspSelectWareHouseWithAccLinkField_Result, bool>)((WSspSelectWareHouseWithAccLinkField_Result x) => x.WrhsLinkAccWhIdStr == vm.WrhsLinkAccWhIdStr));
												if (wSspSelectWareHouseWithAccLinkField_Result != null && !string.IsNullOrWhiteSpace(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWhIdStr))
												{
													vm.WareHouseID = wSspSelectWareHouseWithAccLinkField_Result.WareHouseID;
													vm.Selected = false;
												}
												else
												{
													vm.WareHouseID = 0;
													vm.Selected = true;
												}
												list.Add(vm);
												num++;
											}
										}
									}
								}
							}
						}
					}
				}
			}
			warehouseInfoViewModelObjects.lst = list;
			warehouseInfoViewModelObjects.FilteredLst = list;
			warehouseInfoViewModelObjects.Json = Json(list, JsonRequestBehavior.AllowGet);
			warehouseInfoViewModelObjects.SerializedJson = JsonConvert.SerializeObject(list);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return warehouseInfoViewModelObjects;
	}

	public lstLkWareHouseInfoViewModel RahkaranRetailWhList(string cookieVal)
	{
		lstLkWareHouseInfoViewModel lstLkWareHouseInfoViewModel = new lstLkWareHouseInfoViewModel();
		lstLkWareHouseInfoViewModel.lst = new List<LkWareHouseInfoViewModel>();
		lstLkWareHouseInfoViewModel.lstSelectListItem = new List<SelectListItem>();
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			_ = UserLogin.CurrentUser.UserId;
			DateTime now = DateTime.Now;
			now.ToString("yyyy/MM/dd HH:mm:ss");
			DateTimeClass.DefineDayeOfWeekFa(now.DayOfWeek.ToString());
			WarehouseInfoViewModelObjects rahkaranRetailWareHouseList = GetRahkaranRetailWareHouseList(cookieVal);
			if (rahkaranRetailWareHouseList != null)
			{
				List<LkWareHouseInfoViewModel> lst = rahkaranRetailWareHouseList.lst;
				if (lst != null && Enumerable.Any<LkWareHouseInfoViewModel>((IEnumerable<LkWareHouseInfoViewModel>)lst))
				{
					new List<SelectListItem>();
					foreach (LkWareHouseInfoViewModel item in lst)
					{
						LkWareHouseInfoViewModel lkWareHouseInfoViewModel = new LkWareHouseInfoViewModel();
						lkWareHouseInfoViewModel.WrhsName = item.WrhsName ?? "";
						lkWareHouseInfoViewModel.WrhsLinkAccWhCode = item.WrhsLinkAccWhCode ?? "";
						lkWareHouseInfoViewModel.WrhsLinkAccWhIdStr = item.WrhsLinkAccWhIdStr ?? "";
						lkWareHouseInfoViewModel.WrhsLinkAccWhName = item.WrhsName ?? "";
						lkWareHouseInfoViewModel.WareHouseID = item.WareHouseID;
						lstLkWareHouseInfoViewModel.lst.Add(lkWareHouseInfoViewModel);
						lstLkWareHouseInfoViewModel.lstSelectListItem.Add(new SelectListItem
						{
							Value = lkWareHouseInfoViewModel.WrhsLinkAccWhCode,
							Text = lkWareHouseInfoViewModel.WrhsName,
							Selected = false
						});
					}
				}
			}
			lstLkWareHouseInfoViewModel.isDone = true;
			lstLkWareHouseInfoViewModel.Message = "";
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			lstLkWareHouseInfoViewModel.isDone = false;
			lstLkWareHouseInfoViewModel.Message = "Error: " + ex.Message;
		}
		base.ViewBag.LinkAccWhListJs = JsonConvert.SerializeObject(lstLkWareHouseInfoViewModel.lst);
		base.ViewBag.LinkAccWhSelectListJs = JsonConvert.SerializeObject(lstLkWareHouseInfoViewModel.lstSelectListItem);
		base.ViewBag.LinkAccWhList = lstLkWareHouseInfoViewModel;
		return lstLkWareHouseInfoViewModel;
	}

	public WarehouseInfoViewModelObjects GetNilramWareHouseList()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		WarehouseInfoViewModelObjects warehouseInfoViewModelObjects = new WarehouseInfoViewModelObjects();
		warehouseInfoViewModelObjects.lst = new List<LkWareHouseInfoViewModel>();
		warehouseInfoViewModelObjects.FilteredLst = new List<LkWareHouseInfoViewModel>();
		List<LkWareHouseInfoViewModel> list = new List<LkWareHouseInfoViewModel>();
		try
		{
			CRMIdeal.Classes.Helper.OtherSystems.NilramSettingViewModel nilramSetting = CRMIdeal.Classes.Helper.OtherSystems.GetNilramSetting();
			if (nilramSetting != null)
			{
				string text = nilramSetting.ApiAddress ?? "";
				string value = nilramSetting.ApiToken ?? "";
				if (!string.IsNullOrWhiteSpace(text) && !string.IsNullOrWhiteSpace(value))
				{
					if (!text.EndsWith("/"))
					{
						text += "/";
					}
					HttpClient httpClient = new HttpClient();
					string text2 = text + "MSTK_STOCK";
					httpClient.BaseAddress = new Uri(text2);
					httpClient.DefaultRequestHeaders.Add("Access-Token", value);
					httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
					new StringContent("", Encoding.UTF8, "application/json");
					HttpResponseMessage result2 = httpClient.GetAsync(text2).Result;
					if (result2.IsSuccessStatusCode)
					{
						string value2 = result2.Content.ReadAsStringAsync().Result;
						if (!string.IsNullOrWhiteSpace(value2))
						{
							value2 = value2.ClearHiddenCharacters();
						}
						if (!string.IsNullOrWhiteSpace(value2))
						{
							List<NilramWarehouseInfoViewModel> list2 = JsonConvert.DeserializeObject<List<NilramWarehouseInfoViewModel>>(value2);
							if (list2 != null && Enumerable.Any<NilramWarehouseInfoViewModel>((IEnumerable<NilramWarehouseInfoViewModel>)list2))
							{
								List<WSspSelectWareHouseWithAccLinkField_Result> list3 = Enumerable.ToList<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)_dbLink.WSspSelectWareHouseWithAccLinkField(false, false, false, true, lCID, result));
								int num = 1;
								foreach (NilramWarehouseInfoViewModel item in list2)
								{
									LkWareHouseInfoViewModel vm = new LkWareHouseInfoViewModel();
									vm.WrhsName = item.t_stk_name;
									vm.WrhsLinkAccWhCode = item.t_stk_no;
									vm.WrhsLinkAccWhIdStr = item.id_stock.GetValueOrDefault().ToString();
									vm.RowNumber = num;
									WSspSelectWareHouseWithAccLinkField_Result wSspSelectWareHouseWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)list3, (Func<WSspSelectWareHouseWithAccLinkField_Result, bool>)((WSspSelectWareHouseWithAccLinkField_Result x) => x.WrhsLinkAccWhIdStr == vm.WrhsLinkAccWhIdStr));
									if (wSspSelectWareHouseWithAccLinkField_Result != null && !string.IsNullOrWhiteSpace(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWhIdStr))
									{
										vm.WareHouseID = wSspSelectWareHouseWithAccLinkField_Result.WareHouseID;
										vm.Selected = false;
									}
									else
									{
										vm.WareHouseID = 0;
										vm.Selected = true;
									}
									list.Add(vm);
									num++;
								}
							}
						}
					}
				}
			}
			warehouseInfoViewModelObjects.lst = list;
			warehouseInfoViewModelObjects.FilteredLst = list;
			warehouseInfoViewModelObjects.Json = Json(list, JsonRequestBehavior.AllowGet);
			warehouseInfoViewModelObjects.SerializedJson = JsonConvert.SerializeObject(list);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return warehouseInfoViewModelObjects;
	}

	public lstLkWareHouseInfoViewModel NilramWhList()
	{
		lstLkWareHouseInfoViewModel lstLkWareHouseInfoViewModel = new lstLkWareHouseInfoViewModel();
		lstLkWareHouseInfoViewModel.lst = new List<LkWareHouseInfoViewModel>();
		lstLkWareHouseInfoViewModel.lstSelectListItem = new List<SelectListItem>();
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			_ = UserLogin.CurrentUser.UserId;
			DateTime now = DateTime.Now;
			now.ToString("yyyy/MM/dd HH:mm:ss");
			DateTimeClass.DefineDayeOfWeekFa(now.DayOfWeek.ToString());
			WarehouseInfoViewModelObjects nilramWareHouseList = GetNilramWareHouseList();
			if (nilramWareHouseList != null)
			{
				List<LkWareHouseInfoViewModel> lst = nilramWareHouseList.lst;
				if (lst != null && Enumerable.Any<LkWareHouseInfoViewModel>((IEnumerable<LkWareHouseInfoViewModel>)lst))
				{
					new List<SelectListItem>();
					foreach (LkWareHouseInfoViewModel item in lst)
					{
						LkWareHouseInfoViewModel lkWareHouseInfoViewModel = new LkWareHouseInfoViewModel();
						lkWareHouseInfoViewModel.WrhsName = item.WrhsName ?? "";
						lkWareHouseInfoViewModel.WrhsLinkAccWhCode = item.WrhsLinkAccWhCode ?? "";
						lkWareHouseInfoViewModel.WrhsLinkAccWhIdStr = item.WrhsLinkAccWhIdStr ?? "";
						lkWareHouseInfoViewModel.WrhsLinkAccWhName = item.WrhsName ?? "";
						lkWareHouseInfoViewModel.WareHouseID = item.WareHouseID;
						lstLkWareHouseInfoViewModel.lst.Add(lkWareHouseInfoViewModel);
						lstLkWareHouseInfoViewModel.lstSelectListItem.Add(new SelectListItem
						{
							Value = lkWareHouseInfoViewModel.WrhsLinkAccWhCode,
							Text = lkWareHouseInfoViewModel.WrhsName,
							Selected = false
						});
					}
				}
			}
			lstLkWareHouseInfoViewModel.isDone = true;
			lstLkWareHouseInfoViewModel.Message = "";
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			lstLkWareHouseInfoViewModel.isDone = false;
			lstLkWareHouseInfoViewModel.Message = "Error: " + ex.Message;
		}
		base.ViewBag.LinkAccWhListJs = JsonConvert.SerializeObject(lstLkWareHouseInfoViewModel.lst);
		base.ViewBag.LinkAccWhSelectListJs = JsonConvert.SerializeObject(lstLkWareHouseInfoViewModel.lstSelectListItem);
		base.ViewBag.LinkAccWhList = lstLkWareHouseInfoViewModel;
		return lstLkWareHouseInfoViewModel;
	}

	public WarehouseInfoViewModelObjects GetRahkaranInternalSalesWareHouseList()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		WarehouseInfoViewModelObjects warehouseInfoViewModelObjects = new WarehouseInfoViewModelObjects();
		warehouseInfoViewModelObjects.lst = new List<LkWareHouseInfoViewModel>();
		warehouseInfoViewModelObjects.FilteredLst = new List<LkWareHouseInfoViewModel>();
		List<LkWareHouseInfoViewModel> list = new List<LkWareHouseInfoViewModel>();
		try
		{
			string value = new CRMIdeal.Classes.Helper.OtherSystems.RahkaranInternalSalesProvider().GetStoresList();
			if (!string.IsNullOrWhiteSpace(value))
			{
				value = value.ClearHiddenCharacters();
			}
			if (!string.IsNullOrWhiteSpace(value))
			{
				List<RahkaranInternalSalesStoresResponseViewModel> list2 = JsonConvert.DeserializeObject<List<RahkaranInternalSalesStoresResponseViewModel>>(value);
				if (list2 != null && Enumerable.Any<RahkaranInternalSalesStoresResponseViewModel>((IEnumerable<RahkaranInternalSalesStoresResponseViewModel>)list2))
				{
					List<WSspSelectWareHouseWithAccLinkField_Result> list3 = Enumerable.ToList<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)_dbLink.WSspSelectWareHouseWithAccLinkField(false, false, false, true, lCID, result));
					int num = 1;
					foreach (RahkaranInternalSalesStoresResponseViewModel item in list2)
					{
						LkWareHouseInfoViewModel vm = new LkWareHouseInfoViewModel();
						vm.WrhsName = item.Name;
						vm.WrhsLinkAccWhCode = item.Code;
						vm.WrhsLinkAccWhIdStr = item.ID.GetValueOrDefault().ToString();
						vm.RowNumber = num;
						WSspSelectWareHouseWithAccLinkField_Result wSspSelectWareHouseWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)list3, (Func<WSspSelectWareHouseWithAccLinkField_Result, bool>)((WSspSelectWareHouseWithAccLinkField_Result x) => x.WrhsLinkAccWhIdStr == vm.WrhsLinkAccWhIdStr));
						if (wSspSelectWareHouseWithAccLinkField_Result != null && !string.IsNullOrWhiteSpace(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWhIdStr))
						{
							vm.WareHouseID = wSspSelectWareHouseWithAccLinkField_Result.WareHouseID;
							vm.Selected = false;
						}
						else
						{
							vm.WareHouseID = 0;
							vm.Selected = true;
						}
						list.Add(vm);
						num++;
					}
				}
			}
			warehouseInfoViewModelObjects.lst = list;
			warehouseInfoViewModelObjects.FilteredLst = list;
			warehouseInfoViewModelObjects.Json = Json(list, JsonRequestBehavior.AllowGet);
			warehouseInfoViewModelObjects.SerializedJson = JsonConvert.SerializeObject(list);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return warehouseInfoViewModelObjects;
	}

	public lstLkWareHouseInfoViewModel RahkaranInternalSalesWhList()
	{
		lstLkWareHouseInfoViewModel lstLkWareHouseInfoViewModel = new lstLkWareHouseInfoViewModel();
		lstLkWareHouseInfoViewModel.lst = new List<LkWareHouseInfoViewModel>();
		lstLkWareHouseInfoViewModel.lstSelectListItem = new List<SelectListItem>();
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			_ = UserLogin.CurrentUser.UserId;
			DateTime now = DateTime.Now;
			now.ToString("yyyy/MM/dd HH:mm:ss");
			DateTimeClass.DefineDayeOfWeekFa(now.DayOfWeek.ToString());
			WarehouseInfoViewModelObjects rahkaranInternalSalesWareHouseList = GetRahkaranInternalSalesWareHouseList();
			if (rahkaranInternalSalesWareHouseList != null)
			{
				List<LkWareHouseInfoViewModel> lst = rahkaranInternalSalesWareHouseList.lst;
				if (lst != null && Enumerable.Any<LkWareHouseInfoViewModel>((IEnumerable<LkWareHouseInfoViewModel>)lst))
				{
					new List<SelectListItem>();
					foreach (LkWareHouseInfoViewModel item in lst)
					{
						LkWareHouseInfoViewModel lkWareHouseInfoViewModel = new LkWareHouseInfoViewModel();
						lkWareHouseInfoViewModel.WrhsName = item.WrhsName ?? "";
						lkWareHouseInfoViewModel.WrhsLinkAccWhCode = item.WrhsLinkAccWhCode ?? "";
						lkWareHouseInfoViewModel.WrhsLinkAccWhIdStr = item.WrhsLinkAccWhIdStr ?? "";
						lkWareHouseInfoViewModel.WrhsLinkAccWhName = item.WrhsName ?? "";
						lkWareHouseInfoViewModel.WareHouseID = item.WareHouseID;
						lstLkWareHouseInfoViewModel.lst.Add(lkWareHouseInfoViewModel);
						lstLkWareHouseInfoViewModel.lstSelectListItem.Add(new SelectListItem
						{
							Value = lkWareHouseInfoViewModel.WrhsLinkAccWhCode,
							Text = lkWareHouseInfoViewModel.WrhsName,
							Selected = false
						});
					}
				}
			}
			lstLkWareHouseInfoViewModel.isDone = true;
			lstLkWareHouseInfoViewModel.Message = "";
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			lstLkWareHouseInfoViewModel.isDone = false;
			lstLkWareHouseInfoViewModel.Message = "Error: " + ex.Message;
		}
		base.ViewBag.LinkAccWhListJs = JsonConvert.SerializeObject(lstLkWareHouseInfoViewModel.lst);
		base.ViewBag.LinkAccWhSelectListJs = JsonConvert.SerializeObject(lstLkWareHouseInfoViewModel.lstSelectListItem);
		base.ViewBag.LinkAccWhList = lstLkWareHouseInfoViewModel;
		return lstLkWareHouseInfoViewModel;
	}

	public WarehouseInfoViewModelObjects GetRayvarzWareHouseList()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		WarehouseInfoViewModelObjects warehouseInfoViewModelObjects = new WarehouseInfoViewModelObjects();
		warehouseInfoViewModelObjects.lst = new List<LkWareHouseInfoViewModel>();
		warehouseInfoViewModelObjects.FilteredLst = new List<LkWareHouseInfoViewModel>();
		List<LkWareHouseInfoViewModel> list = new List<LkWareHouseInfoViewModel>();
		try
		{
			List<RayvarzWarehouseResponseViewModel> allWarehouseList = new CRMIdeal.Classes.Helper.OtherSystems.RayvarzProvider().GetAllWarehouseList();
			if (allWarehouseList != null && Enumerable.Any<RayvarzWarehouseResponseViewModel>((IEnumerable<RayvarzWarehouseResponseViewModel>)allWarehouseList))
			{
				List<WSspSelectWareHouseWithAccLinkField_Result> list2 = Enumerable.ToList<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)_dbLink.WSspSelectWareHouseWithAccLinkField(false, false, false, true, lCID, result));
				int num = 1;
				foreach (RayvarzWarehouseResponseViewModel item in allWarehouseList)
				{
					LkWareHouseInfoViewModel vm = new LkWareHouseInfoViewModel();
					vm.WrhsName = item.name;
					vm.WrhsLinkAccWhIdStr = item.warehouseId ?? "";
					vm.WrhsLinkAccWhCode = vm.WrhsLinkAccWhIdStr;
					vm.RowNumber = num;
					WSspSelectWareHouseWithAccLinkField_Result wSspSelectWareHouseWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)list2, (Func<WSspSelectWareHouseWithAccLinkField_Result, bool>)((WSspSelectWareHouseWithAccLinkField_Result x) => x.WrhsLinkAccWhIdStr == vm.WrhsLinkAccWhIdStr));
					if (wSspSelectWareHouseWithAccLinkField_Result != null && !string.IsNullOrWhiteSpace(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWhIdStr))
					{
						vm.WareHouseID = wSspSelectWareHouseWithAccLinkField_Result.WareHouseID;
						vm.Selected = false;
					}
					else
					{
						vm.WareHouseID = 0;
						vm.Selected = true;
					}
					list.Add(vm);
					num++;
				}
			}
			warehouseInfoViewModelObjects.lst = list;
			warehouseInfoViewModelObjects.FilteredLst = list;
			warehouseInfoViewModelObjects.Json = Json(list, JsonRequestBehavior.AllowGet);
			warehouseInfoViewModelObjects.SerializedJson = JsonConvert.SerializeObject(list);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return warehouseInfoViewModelObjects;
	}

	public lstLkWareHouseInfoViewModel RayvarzWhList()
	{
		lstLkWareHouseInfoViewModel lstLkWareHouseInfoViewModel = new lstLkWareHouseInfoViewModel();
		lstLkWareHouseInfoViewModel.lst = new List<LkWareHouseInfoViewModel>();
		lstLkWareHouseInfoViewModel.lstSelectListItem = new List<SelectListItem>();
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			_ = UserLogin.CurrentUser.UserId;
			DateTime now = DateTime.Now;
			now.ToString("yyyy/MM/dd HH:mm:ss");
			DateTimeClass.DefineDayeOfWeekFa(now.DayOfWeek.ToString());
			WarehouseInfoViewModelObjects rayvarzWareHouseList = GetRayvarzWareHouseList();
			if (rayvarzWareHouseList != null)
			{
				List<LkWareHouseInfoViewModel> lst = rayvarzWareHouseList.lst;
				if (lst != null && Enumerable.Any<LkWareHouseInfoViewModel>((IEnumerable<LkWareHouseInfoViewModel>)lst))
				{
					new List<SelectListItem>();
					foreach (LkWareHouseInfoViewModel item in lst)
					{
						LkWareHouseInfoViewModel lkWareHouseInfoViewModel = new LkWareHouseInfoViewModel();
						lkWareHouseInfoViewModel.WrhsName = item.WrhsName ?? "";
						lkWareHouseInfoViewModel.WrhsLinkAccWhCode = item.WrhsLinkAccWhCode ?? "";
						lkWareHouseInfoViewModel.WrhsLinkAccWhIdStr = item.WrhsLinkAccWhIdStr ?? "";
						lkWareHouseInfoViewModel.WrhsLinkAccWhName = item.WrhsName ?? "";
						lkWareHouseInfoViewModel.WareHouseID = item.WareHouseID;
						lstLkWareHouseInfoViewModel.lst.Add(lkWareHouseInfoViewModel);
						lstLkWareHouseInfoViewModel.lstSelectListItem.Add(new SelectListItem
						{
							Value = lkWareHouseInfoViewModel.WrhsLinkAccWhCode,
							Text = lkWareHouseInfoViewModel.WrhsName,
							Selected = false
						});
					}
				}
			}
			lstLkWareHouseInfoViewModel.isDone = true;
			lstLkWareHouseInfoViewModel.Message = "";
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			lstLkWareHouseInfoViewModel.isDone = false;
			lstLkWareHouseInfoViewModel.Message = "Error: " + ex.Message;
		}
		base.ViewBag.LinkAccWhListJs = JsonConvert.SerializeObject(lstLkWareHouseInfoViewModel.lst);
		base.ViewBag.LinkAccWhSelectListJs = JsonConvert.SerializeObject(lstLkWareHouseInfoViewModel.lstSelectListItem);
		base.ViewBag.LinkAccWhList = lstLkWareHouseInfoViewModel;
		return lstLkWareHouseInfoViewModel;
	}

	public WarehouseInfoViewModelObjects GetArianSystemWareHouseList()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		WarehouseInfoViewModelObjects warehouseInfoViewModelObjects = new WarehouseInfoViewModelObjects();
		warehouseInfoViewModelObjects.lst = new List<LkWareHouseInfoViewModel>();
		warehouseInfoViewModelObjects.FilteredLst = new List<LkWareHouseInfoViewModel>();
		List<LkWareHouseInfoViewModel> list = new List<LkWareHouseInfoViewModel>();
		try
		{
			List<ArianSystemWarehouseResponseViewModel> warehouseList = new CRMIdeal.Classes.Helper.OtherSystems.ArianSystemProvider().GetWarehouseList();
			if (warehouseList != null && Enumerable.Any<ArianSystemWarehouseResponseViewModel>((IEnumerable<ArianSystemWarehouseResponseViewModel>)warehouseList))
			{
				List<WSspSelectWareHouseWithAccLinkField_Result> list2 = Enumerable.ToList<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)_dbLink.WSspSelectWareHouseWithAccLinkField(false, false, false, true, lCID, result));
				int num = 1;
				foreach (ArianSystemWarehouseResponseViewModel item in warehouseList)
				{
					LkWareHouseInfoViewModel vm = new LkWareHouseInfoViewModel();
					vm.WrhsName = item.StockDesc;
					vm.WrhsLinkAccWhIdStr = item.StockID.GetValueOrDefault().ToString();
					vm.WrhsLinkAccWhCode = item.StockCode ?? vm.WrhsLinkAccWhIdStr;
					vm.RowNumber = num;
					WSspSelectWareHouseWithAccLinkField_Result wSspSelectWareHouseWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)list2, (Func<WSspSelectWareHouseWithAccLinkField_Result, bool>)((WSspSelectWareHouseWithAccLinkField_Result x) => x.WrhsLinkAccWhIdStr == vm.WrhsLinkAccWhIdStr));
					if (wSspSelectWareHouseWithAccLinkField_Result != null && !string.IsNullOrWhiteSpace(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWhIdStr))
					{
						vm.WareHouseID = wSspSelectWareHouseWithAccLinkField_Result.WareHouseID;
						vm.Selected = false;
					}
					else
					{
						vm.WareHouseID = 0;
						vm.Selected = true;
					}
					list.Add(vm);
					num++;
				}
			}
			warehouseInfoViewModelObjects.lst = list;
			warehouseInfoViewModelObjects.FilteredLst = list;
			warehouseInfoViewModelObjects.Json = Json(list, JsonRequestBehavior.AllowGet);
			warehouseInfoViewModelObjects.SerializedJson = JsonConvert.SerializeObject(list);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return warehouseInfoViewModelObjects;
	}

	public lstLkWareHouseInfoViewModel ArianSystemWhList()
	{
		lstLkWareHouseInfoViewModel lstLkWareHouseInfoViewModel = new lstLkWareHouseInfoViewModel();
		lstLkWareHouseInfoViewModel.lst = new List<LkWareHouseInfoViewModel>();
		lstLkWareHouseInfoViewModel.lstSelectListItem = new List<SelectListItem>();
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			_ = UserLogin.CurrentUser.UserId;
			DateTime now = DateTime.Now;
			now.ToString("yyyy/MM/dd HH:mm:ss");
			DateTimeClass.DefineDayeOfWeekFa(now.DayOfWeek.ToString());
			WarehouseInfoViewModelObjects arianSystemWareHouseList = GetArianSystemWareHouseList();
			if (arianSystemWareHouseList != null)
			{
				List<LkWareHouseInfoViewModel> lst = arianSystemWareHouseList.lst;
				if (lst != null && Enumerable.Any<LkWareHouseInfoViewModel>((IEnumerable<LkWareHouseInfoViewModel>)lst))
				{
					new List<SelectListItem>();
					foreach (LkWareHouseInfoViewModel item in lst)
					{
						LkWareHouseInfoViewModel lkWareHouseInfoViewModel = new LkWareHouseInfoViewModel();
						lkWareHouseInfoViewModel.WrhsName = item.WrhsName ?? "";
						lkWareHouseInfoViewModel.WrhsLinkAccWhCode = item.WrhsLinkAccWhCode ?? "";
						lkWareHouseInfoViewModel.WrhsLinkAccWhIdStr = item.WrhsLinkAccWhIdStr ?? "";
						lkWareHouseInfoViewModel.WrhsLinkAccWhName = item.WrhsName ?? "";
						lkWareHouseInfoViewModel.WareHouseID = item.WareHouseID;
						lstLkWareHouseInfoViewModel.lst.Add(lkWareHouseInfoViewModel);
						lstLkWareHouseInfoViewModel.lstSelectListItem.Add(new SelectListItem
						{
							Value = lkWareHouseInfoViewModel.WrhsLinkAccWhCode,
							Text = lkWareHouseInfoViewModel.WrhsName,
							Selected = false
						});
					}
				}
			}
			lstLkWareHouseInfoViewModel.isDone = true;
			lstLkWareHouseInfoViewModel.Message = "";
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			lstLkWareHouseInfoViewModel.isDone = false;
			lstLkWareHouseInfoViewModel.Message = "Error: " + ex.Message;
		}
		base.ViewBag.LinkAccWhListJs = JsonConvert.SerializeObject(lstLkWareHouseInfoViewModel.lst);
		base.ViewBag.LinkAccWhSelectListJs = JsonConvert.SerializeObject(lstLkWareHouseInfoViewModel.lstSelectListItem);
		base.ViewBag.LinkAccWhList = lstLkWareHouseInfoViewModel;
		return lstLkWareHouseInfoViewModel;
	}

	public WarehouseInfoViewModelObjects GetShygunDetailedAPIWareHouseList()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		WarehouseInfoViewModelObjects warehouseInfoViewModelObjects = new WarehouseInfoViewModelObjects();
		warehouseInfoViewModelObjects.lst = new List<LkWareHouseInfoViewModel>();
		warehouseInfoViewModelObjects.FilteredLst = new List<LkWareHouseInfoViewModel>();
		List<LkWareHouseInfoViewModel> list = new List<LkWareHouseInfoViewModel>();
		try
		{
			List<ShygunDetailedAPIWarehouseInfoViewModel> warehouseList = new CRMIdeal.Classes.Helper.OtherSystems.ShygunDetailedAPIProvider().GetWarehouseList();
			if (warehouseList != null && Enumerable.Any<ShygunDetailedAPIWarehouseInfoViewModel>((IEnumerable<ShygunDetailedAPIWarehouseInfoViewModel>)warehouseList))
			{
				List<WSspSelectWareHouseWithAccLinkField_Result> list2 = Enumerable.ToList<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)_dbLink.WSspSelectWareHouseWithAccLinkField(false, false, false, true, lCID, result));
				int num = 1;
				foreach (ShygunDetailedAPIWarehouseInfoViewModel item in warehouseList)
				{
					LkWareHouseInfoViewModel vm = new LkWareHouseInfoViewModel();
					vm.WrhsName = item.StockName ?? "";
					vm.WrhsLinkAccWhIdStr = item.GuId ?? "";
					vm.WrhsLinkAccWhCode = item.StockNumber;
					if (string.IsNullOrWhiteSpace(vm.WrhsLinkAccWhCode))
					{
						vm.WrhsLinkAccWhCode = vm.WrhsLinkAccWhIdStr;
					}
					vm.RowNumber = num;
					WSspSelectWareHouseWithAccLinkField_Result wSspSelectWareHouseWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)list2, (Func<WSspSelectWareHouseWithAccLinkField_Result, bool>)((WSspSelectWareHouseWithAccLinkField_Result x) => x.WrhsLinkAccWhIdStr == vm.WrhsLinkAccWhIdStr));
					if (wSspSelectWareHouseWithAccLinkField_Result != null && !string.IsNullOrWhiteSpace(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWhIdStr))
					{
						vm.WareHouseID = wSspSelectWareHouseWithAccLinkField_Result.WareHouseID;
						vm.Selected = false;
					}
					else
					{
						vm.WareHouseID = 0;
						vm.Selected = true;
					}
					list.Add(vm);
					num++;
				}
			}
			warehouseInfoViewModelObjects.lst = list;
			warehouseInfoViewModelObjects.FilteredLst = list;
			warehouseInfoViewModelObjects.Json = Json(list, JsonRequestBehavior.AllowGet);
			warehouseInfoViewModelObjects.SerializedJson = JsonConvert.SerializeObject(list);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return warehouseInfoViewModelObjects;
	}

	public lstLkWareHouseInfoViewModel ShygunDetailedAPIWhList()
	{
		lstLkWareHouseInfoViewModel lstLkWareHouseInfoViewModel = new lstLkWareHouseInfoViewModel();
		lstLkWareHouseInfoViewModel.lst = new List<LkWareHouseInfoViewModel>();
		lstLkWareHouseInfoViewModel.lstSelectListItem = new List<SelectListItem>();
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			_ = UserLogin.CurrentUser.UserId;
			DateTime now = DateTime.Now;
			now.ToString("yyyy/MM/dd HH:mm:ss");
			DateTimeClass.DefineDayeOfWeekFa(now.DayOfWeek.ToString());
			WarehouseInfoViewModelObjects shygunDetailedAPIWareHouseList = GetShygunDetailedAPIWareHouseList();
			if (shygunDetailedAPIWareHouseList != null)
			{
				List<LkWareHouseInfoViewModel> lst = shygunDetailedAPIWareHouseList.lst;
				if (lst != null && Enumerable.Any<LkWareHouseInfoViewModel>((IEnumerable<LkWareHouseInfoViewModel>)lst))
				{
					new List<SelectListItem>();
					foreach (LkWareHouseInfoViewModel item in lst)
					{
						LkWareHouseInfoViewModel lkWareHouseInfoViewModel = new LkWareHouseInfoViewModel();
						lkWareHouseInfoViewModel.WrhsName = item.WrhsName ?? "";
						lkWareHouseInfoViewModel.WrhsLinkAccWhCode = item.WrhsLinkAccWhCode ?? "";
						lkWareHouseInfoViewModel.WrhsLinkAccWhIdStr = item.WrhsLinkAccWhIdStr ?? "";
						lkWareHouseInfoViewModel.WrhsLinkAccWhName = item.WrhsName ?? "";
						lkWareHouseInfoViewModel.WareHouseID = item.WareHouseID;
						lstLkWareHouseInfoViewModel.lst.Add(lkWareHouseInfoViewModel);
						lstLkWareHouseInfoViewModel.lstSelectListItem.Add(new SelectListItem
						{
							Value = lkWareHouseInfoViewModel.WrhsLinkAccWhCode,
							Text = lkWareHouseInfoViewModel.WrhsName,
							Selected = false
						});
					}
				}
			}
			lstLkWareHouseInfoViewModel.isDone = true;
			lstLkWareHouseInfoViewModel.Message = "";
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			lstLkWareHouseInfoViewModel.isDone = false;
			lstLkWareHouseInfoViewModel.Message = "Error: " + ex.Message;
		}
		base.ViewBag.LinkAccWhListJs = JsonConvert.SerializeObject(lstLkWareHouseInfoViewModel.lst);
		base.ViewBag.LinkAccWhSelectListJs = JsonConvert.SerializeObject(lstLkWareHouseInfoViewModel.lstSelectListItem);
		base.ViewBag.LinkAccWhList = lstLkWareHouseInfoViewModel;
		return lstLkWareHouseInfoViewModel;
	}

	[DynamicAuthorize(ControllerName = "frmDefineWareHouse", ActionName = "actManageWarehousesLinkAcc")]
	public ActionResult ManageWarehouseLinkAcc(int linkAccSystemId, string cookieVal = "")
	{
		CrmWhList();
		int result = 0;
		switch (linkAccSystemId)
		{
		case 12:
			int.TryParse(CRMIdeal.Classes.Helper.OtherSystems.GetArpaSetting().WrhsSyncTypeId.ToString(), out result);
			ArpaWhList();
			break;
		case 17:
			int.TryParse(CRMIdeal.Classes.Helper.OtherSystems.GetHamrahanSetting().WrhsSyncTypeId.ToString(), out result);
			HamrahanWhList();
			break;
		case 18:
			int.TryParse(CRMIdeal.Classes.Helper.OtherSystems.GetNoAvaranCapillarySetting().WrhsSyncTypeId.ToString(), out result);
			NoAvaranCapillaryWhList();
			break;
		case 19:
			int.TryParse(CRMIdeal.Classes.Helper.OtherSystems.GetRahkaranRetailSetting().WrhsSyncTypeId.ToString(), out result);
			RahkaranRetailWhList(cookieVal);
			break;
		case 20:
			int.TryParse(CRMIdeal.Classes.Helper.OtherSystems.GetNilramSetting().WrhsSyncTypeId.ToString(), out result);
			NilramWhList();
			break;
		case 22:
			int.TryParse(new CRMIdeal.Classes.Helper.OtherSystems.RahkaranInternalSalesProvider().WrhsSyncTypeId.ToString(), out result);
			RahkaranInternalSalesWhList();
			break;
		case 23:
			int.TryParse(new CRMIdeal.Classes.Helper.OtherSystems.RayvarzProvider().WrhsSyncTypeId.ToString(), out result);
			RayvarzWhList();
			break;
		case 25:
			int.TryParse(new CRMIdeal.Classes.Helper.OtherSystems.ArianSystemProvider().WrhsSyncTypeId.ToString(), out result);
			ArianSystemWhList();
			break;
		case 26:
			int.TryParse(new CRMIdeal.Classes.Helper.OtherSystems.ShygunDetailedAPIProvider().WrhsSyncTypeId.ToString(), out result);
			ShygunDetailedAPIWhList();
			break;
		}
		base.ViewBag.SyncTypeId = result;
		base.ViewBag.LinkAccSystemId = linkAccSystemId;
		return View();
	}

	public JsonResult GetManageWhListJs(string cookieVal = "")
	{
		int result = 0;
		CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
		if (cRMspSelectCrmsysSetting_Result != null)
		{
			int.TryParse(cRMspSelectCrmsysSetting_Result.LinkAccSystemId.ToString(), out result);
		}
		CRMIdeal.Classes.Helper.Setting.GetLinkAccSystemTitle();
		List<LkWareHouseInfoViewModel> list = new List<LkWareHouseInfoViewModel>();
		switch (result)
		{
		case 12:
		{
			ArpaWarehouseInfoViewModelObjects arpaWareHouseList = GetArpaWareHouseList();
			if (arpaWareHouseList != null && arpaWareHouseList.lst != null && Enumerable.Any<LkWareHouseInfoViewModel>((IEnumerable<LkWareHouseInfoViewModel>)arpaWareHouseList.lst))
			{
				list = arpaWareHouseList.lst;
			}
			break;
		}
		case 17:
		{
			WarehouseInfoViewModelObjects hamrahanWareHouseList = GetHamrahanWareHouseList();
			if (hamrahanWareHouseList != null && hamrahanWareHouseList.lst != null && Enumerable.Any<LkWareHouseInfoViewModel>((IEnumerable<LkWareHouseInfoViewModel>)hamrahanWareHouseList.lst))
			{
				list = hamrahanWareHouseList.lst;
			}
			break;
		}
		case 18:
		{
			WarehouseInfoViewModelObjects noAvaranCapillaryWareHouseList = GetNoAvaranCapillaryWareHouseList();
			if (noAvaranCapillaryWareHouseList != null && noAvaranCapillaryWareHouseList.lst != null && Enumerable.Any<LkWareHouseInfoViewModel>((IEnumerable<LkWareHouseInfoViewModel>)noAvaranCapillaryWareHouseList.lst))
			{
				list = noAvaranCapillaryWareHouseList.lst;
			}
			break;
		}
		case 19:
		{
			WarehouseInfoViewModelObjects rahkaranRetailWareHouseList = GetRahkaranRetailWareHouseList(cookieVal);
			if (rahkaranRetailWareHouseList != null && rahkaranRetailWareHouseList.lst != null && Enumerable.Any<LkWareHouseInfoViewModel>((IEnumerable<LkWareHouseInfoViewModel>)rahkaranRetailWareHouseList.lst))
			{
				list = rahkaranRetailWareHouseList.lst;
			}
			break;
		}
		case 20:
		{
			WarehouseInfoViewModelObjects nilramWareHouseList = GetNilramWareHouseList();
			if (nilramWareHouseList != null && nilramWareHouseList.lst != null && Enumerable.Any<LkWareHouseInfoViewModel>((IEnumerable<LkWareHouseInfoViewModel>)nilramWareHouseList.lst))
			{
				list = nilramWareHouseList.lst;
			}
			break;
		}
		case 22:
		{
			WarehouseInfoViewModelObjects rahkaranInternalSalesWareHouseList = GetRahkaranInternalSalesWareHouseList();
			if (rahkaranInternalSalesWareHouseList != null && rahkaranInternalSalesWareHouseList.lst != null && Enumerable.Any<LkWareHouseInfoViewModel>((IEnumerable<LkWareHouseInfoViewModel>)rahkaranInternalSalesWareHouseList.lst))
			{
				list = rahkaranInternalSalesWareHouseList.lst;
			}
			break;
		}
		case 23:
		{
			WarehouseInfoViewModelObjects rayvarzWareHouseList = GetRayvarzWareHouseList();
			if (rayvarzWareHouseList != null && rayvarzWareHouseList.lst != null && Enumerable.Any<LkWareHouseInfoViewModel>((IEnumerable<LkWareHouseInfoViewModel>)rayvarzWareHouseList.lst))
			{
				list = rayvarzWareHouseList.lst;
			}
			break;
		}
		case 25:
		{
			WarehouseInfoViewModelObjects arianSystemWareHouseList = GetArianSystemWareHouseList();
			if (arianSystemWareHouseList != null && arianSystemWareHouseList.lst != null && Enumerable.Any<LkWareHouseInfoViewModel>((IEnumerable<LkWareHouseInfoViewModel>)arianSystemWareHouseList.lst))
			{
				list = arianSystemWareHouseList.lst;
			}
			break;
		}
		case 26:
		{
			WarehouseInfoViewModelObjects shygunDetailedAPIWareHouseList = GetShygunDetailedAPIWareHouseList();
			if (shygunDetailedAPIWareHouseList != null && shygunDetailedAPIWareHouseList.lst != null && Enumerable.Any<LkWareHouseInfoViewModel>((IEnumerable<LkWareHouseInfoViewModel>)shygunDetailedAPIWareHouseList.lst))
			{
				list = shygunDetailedAPIWareHouseList.lst;
			}
			break;
		}
		}
		if (list == null)
		{
			list = new List<LkWareHouseInfoViewModel>();
		}
		JsonResult jsonResult = Json(list, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public ActionResult ManageWhImport_Read([DataSourceRequest] DataSourceRequest request, string cookieVal = "")
	{
		int result = 0;
		CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
		if (cRMspSelectCrmsysSetting_Result != null)
		{
			int.TryParse(cRMspSelectCrmsysSetting_Result.LinkAccSystemId.ToString(), out result);
		}
		CRMIdeal.Classes.Helper.Setting.GetLinkAccSystemTitle();
		List<LkWareHouseInfoViewModel> list = new List<LkWareHouseInfoViewModel>();
		switch (result)
		{
		case 12:
		{
			ArpaWarehouseInfoViewModelObjects arpaWareHouseList = GetArpaWareHouseList();
			if (arpaWareHouseList != null && arpaWareHouseList.lst != null && Enumerable.Any<LkWareHouseInfoViewModel>((IEnumerable<LkWareHouseInfoViewModel>)arpaWareHouseList.lst))
			{
				list = arpaWareHouseList.lst;
			}
			break;
		}
		case 17:
		{
			WarehouseInfoViewModelObjects hamrahanWareHouseList = GetHamrahanWareHouseList();
			if (hamrahanWareHouseList != null && hamrahanWareHouseList.lst != null && Enumerable.Any<LkWareHouseInfoViewModel>((IEnumerable<LkWareHouseInfoViewModel>)hamrahanWareHouseList.lst))
			{
				list = hamrahanWareHouseList.lst;
			}
			break;
		}
		case 18:
		{
			WarehouseInfoViewModelObjects noAvaranCapillaryWareHouseList = GetNoAvaranCapillaryWareHouseList();
			if (noAvaranCapillaryWareHouseList != null && noAvaranCapillaryWareHouseList.lst != null && Enumerable.Any<LkWareHouseInfoViewModel>((IEnumerable<LkWareHouseInfoViewModel>)noAvaranCapillaryWareHouseList.lst))
			{
				list = noAvaranCapillaryWareHouseList.lst;
			}
			break;
		}
		case 19:
		{
			WarehouseInfoViewModelObjects rahkaranRetailWareHouseList = GetRahkaranRetailWareHouseList(cookieVal);
			if (rahkaranRetailWareHouseList != null && rahkaranRetailWareHouseList.lst != null && Enumerable.Any<LkWareHouseInfoViewModel>((IEnumerable<LkWareHouseInfoViewModel>)rahkaranRetailWareHouseList.lst))
			{
				list = rahkaranRetailWareHouseList.lst;
			}
			break;
		}
		case 20:
		{
			WarehouseInfoViewModelObjects nilramWareHouseList = GetNilramWareHouseList();
			if (nilramWareHouseList != null && nilramWareHouseList.lst != null && Enumerable.Any<LkWareHouseInfoViewModel>((IEnumerable<LkWareHouseInfoViewModel>)nilramWareHouseList.lst))
			{
				list = nilramWareHouseList.lst;
			}
			break;
		}
		case 22:
		{
			WarehouseInfoViewModelObjects rahkaranInternalSalesWareHouseList = GetRahkaranInternalSalesWareHouseList();
			if (rahkaranInternalSalesWareHouseList != null && rahkaranInternalSalesWareHouseList.lst != null && Enumerable.Any<LkWareHouseInfoViewModel>((IEnumerable<LkWareHouseInfoViewModel>)rahkaranInternalSalesWareHouseList.lst))
			{
				list = rahkaranInternalSalesWareHouseList.lst;
			}
			break;
		}
		case 23:
		{
			WarehouseInfoViewModelObjects rayvarzWareHouseList = GetRayvarzWareHouseList();
			if (rayvarzWareHouseList != null && rayvarzWareHouseList.lst != null && Enumerable.Any<LkWareHouseInfoViewModel>((IEnumerable<LkWareHouseInfoViewModel>)rayvarzWareHouseList.lst))
			{
				list = rayvarzWareHouseList.lst;
			}
			break;
		}
		case 25:
		{
			WarehouseInfoViewModelObjects arianSystemWareHouseList = GetArianSystemWareHouseList();
			if (arianSystemWareHouseList != null && arianSystemWareHouseList.lst != null && Enumerable.Any<LkWareHouseInfoViewModel>((IEnumerable<LkWareHouseInfoViewModel>)arianSystemWareHouseList.lst))
			{
				list = arianSystemWareHouseList.lst;
			}
			break;
		}
		case 26:
		{
			WarehouseInfoViewModelObjects shygunDetailedAPIWareHouseList = GetShygunDetailedAPIWareHouseList();
			if (shygunDetailedAPIWareHouseList != null && shygunDetailedAPIWareHouseList.lst != null && Enumerable.Any<LkWareHouseInfoViewModel>((IEnumerable<LkWareHouseInfoViewModel>)shygunDetailedAPIWareHouseList.lst))
			{
				list = shygunDetailedAPIWareHouseList.lst;
			}
			break;
		}
		}
		if (list != null)
		{
			if (Enumerable.Any<LkWareHouseInfoViewModel>((IEnumerable<LkWareHouseInfoViewModel>)list))
			{
				foreach (LkWareHouseInfoViewModel item in list)
				{
					if (!string.IsNullOrWhiteSpace(item.WrhsLinkAccWhCode) && string.IsNullOrWhiteSpace(item.WrhsCode))
					{
						item.WrhsCode = item.WrhsLinkAccWhCode;
					}
				}
			}
		}
		else
		{
			list = new List<LkWareHouseInfoViewModel>();
		}
		JsonResult jsonResult = Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[DynamicAuthorize(ControllerName = "frmManageWarehousesLinkAcc", ActionName = "actImportWhInfo")]
	public string ManageImportWhInfo(string records = "")
	{
		string text = "";
		try
		{
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			int id = Financial.Get().Id;
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			int result2 = 0;
			CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
			if (cRMspSelectCrmsysSetting_Result != null)
			{
				int.TryParse(cRMspSelectCrmsysSetting_Result.LinkAccSystemId.ToString(), out result2);
			}
			CRMIdeal.Classes.Helper.Setting.GetLinkAccSystemTitle();
			if (!string.IsNullOrWhiteSpace(records))
			{
				Enumerable.ToList<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)_dbLink.WSspSelectWareHouseWithAccLinkField(withWrhsLinkAccWhCode: false, withWrhsLinkAccWhId: false, withWrhsLinkAccWhIdStr: true, withWrhsLinkAccWareHouses: false, languageID: 0, defaultLanguageID: 0));
				List<LkWareHouseInfoViewModel> list = JsonConvert.DeserializeObject<List<LkWareHouseInfoViewModel>>(records);
				int result3 = 0;
				string text2 = Configuration.MaxCountWarehouse.ToString();
				if (text2 != null)
				{
					int.TryParse(text2, out result3);
				}
				if (result3 == 0)
				{
					result3 = 1;
				}
				int valueOrDefault = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)_dbII.WSspReturnActiveWareHouseCount()).GetValueOrDefault();
				if (valueOrDefault >= result3)
				{
					text = Messages.msgErrorInDefinitionIllegalwarehouse1 + " " + result3 + " " + Messages.msgErrorInDefinitionIllegalwarehouse2;
				}
				if (list != null && list.Count > 0)
				{
					list = Enumerable.ToList<LkWareHouseInfoViewModel>(Enumerable.Where<LkWareHouseInfoViewModel>((IEnumerable<LkWareHouseInfoViewModel>)list, (Func<LkWareHouseInfoViewModel, bool>)((LkWareHouseInfoViewModel x) => x.Selected)));
					if (result3 - valueOrDefault < list.Count)
					{
						text = Messages.msgErrorInDefinitionIllegalwarehouse1 + " " + result3 + " " + Messages.msgErrorInDefinitionIllegalwarehouse2;
					}
				}
				if (string.IsNullOrWhiteSpace(text))
				{
					string json = JsonConvert.SerializeObject(list);
					ObjectParameter objectParameter = new ObjectParameter("ErrorMessage", "");
					_dbLink.CRMspLkWSInsertUpdateWareHouse(json, userId, value2, id, value, registerDatePersian, appType, result, objectParameter, centerId);
					if (!string.IsNullOrWhiteSpace(objectParameter.Value.ToString()))
					{
						text += objectParameter.Value.ToString();
					}
				}
			}
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WsWareHouse");
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return text;
	}

	[HttpPost]
	public string ManageSyncWarehouse(string jsData)
	{
		string text = "";
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		DateTime now = DateTime.Now;
		DateTime dateTime = now;
		string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
		_ = Financial.Get().Id;
		short.Parse(Financial.Get().Id.ToString());
		short num = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
		string appType = Configuration.AppType;
		int userId = UserLogin.CurrentUser.UserId;
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			if (!string.IsNullOrWhiteSpace(jsData) && string.IsNullOrWhiteSpace(text))
			{
				List<CommonWithIdStrViewModel> list2 = JsonConvert.DeserializeObject<List<CommonWithIdStrViewModel>>(jsData);
				if (list2 != null && list2.Count > 0)
				{
					List<SelectListItem> list3 = new List<SelectListItem>();
					foreach (CommonWithIdStrViewModel i in list2)
					{
						if (Enumerable.ToList<SelectListItem>(Enumerable.Where<SelectListItem>((IEnumerable<SelectListItem>)list3, (Func<SelectListItem, bool>)((SelectListItem x) => x.Value == i.Extra))).Count <= 0)
						{
							List<CommonWithIdStrViewModel> list4 = Enumerable.ToList<CommonWithIdStrViewModel>(Enumerable.Where<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list2, (Func<CommonWithIdStrViewModel, bool>)((CommonWithIdStrViewModel x) => x.Extra == i.Extra && !string.IsNullOrWhiteSpace(x.Id))));
							if (list4 == null || list4.Count <= 0)
							{
								list3.Add(new SelectListItem
								{
									Value = i.Extra,
									Text = ""
								});
							}
							else
							{
								list3.Add(new SelectListItem
								{
									Value = i.Extra,
									Text = JsonConvert.SerializeObject(list4)
								});
							}
						}
					}
					foreach (SelectListItem item in list3)
					{
						ObjectParameter objectParameter = new ObjectParameter("ErrorMessage", "");
						_dbLink.CRMspLkWSInsertUpdateWhLinkAccWarehouses(int.Parse(item.Value), item.Text, userId, num, dateTime, registerDatePersian, appType, objectParameter);
						new List<SelectListItem>();
						if (!string.IsNullOrWhiteSpace(item.Text))
						{
							List<CommonWithIdStrViewModel> list5 = JsonConvert.DeserializeObject<List<CommonWithIdStrViewModel>>(item.Text);
							if (list5 != null && Enumerable.Count<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list5) == 1)
							{
								int result2 = 0;
								int.TryParse(Enumerable.FirstOrDefault<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list5).Extra, out result2);
								WsWareHouse wsWareHouse = _dbTbl.WsWareHouse.Find(result2);
								if (wsWareHouse != null)
								{
									wsWareHouse.WrhsLinkAccWhIdStr = Enumerable.FirstOrDefault<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list5).Id;
									wsWareHouse.WrhsLinkAccWhCode = Enumerable.FirstOrDefault<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list5).Code;
									wsWareHouse.WrhsLinkAccWhName = Enumerable.FirstOrDefault<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list5).Name;
									wsWareHouse.AppType = appType;
									wsWareHouse.UserId = userId;
									wsWareHouse.Month1 = num;
									wsWareHouse.RegisterDate = dateTime;
									wsWareHouse.RegisterDatePersian = registerDatePersian;
									_dbTbl.Entry(wsWareHouse).State = EntityState.Modified;
									_dbTbl.Configuration.ValidateOnSaveEnabled = false;
									_dbTbl.SaveChanges();
									_dbTbl.Configuration.ValidateOnSaveEnabled = true;
								}
							}
						}
						if (objectParameter.Value != null)
						{
							if (!string.IsNullOrEmpty(objectParameter.Value.ToString()))
							{
								text = text + objectParameter.Value.ToString() + "|";
								continue;
							}
							list.Add(new SelectListItem
							{
								Value = item.Value,
								Text = item.Text
							});
						}
						else
						{
							list.Add(new SelectListItem
							{
								Value = item.Value,
								Text = item.Text
							});
						}
					}
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WsWareHouse");
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return text + "|**|" + JsonConvert.SerializeObject(list);
	}

	[DynamicAuthorize(ControllerName = "frmManageWarehousesLinkAcc", ActionName = "actCanChangeLinkType")]
	[HttpPost]
	public string ManageSyncWarehouseType(int syncType = 1)
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
			DateTime now = DateTime.Now;
			DateTime registerDate = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			_ = Financial.Get().Id;
			short.Parse(Financial.Get().Id.ToString());
			short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
			int result3 = 0;
			string text = "";
			CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
			if (cRMspSelectCrmsysSetting_Result != null)
			{
				int.TryParse(cRMspSelectCrmsysSetting_Result.LinkAccSystemId.ToString(), out result3);
			}
			text = CRMIdeal.Classes.Helper.Setting.GetLinkAccSystemTitle();
			switch (result3)
			{
			case 12:
			{
				DbSet<CrmLinkAccArpaSetting> crmLinkAccArpaSetting = _dbTbl.CrmLinkAccArpaSetting;
				ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccArpaSetting), "x");
				CrmLinkAccArpaSetting crmLinkAccArpaSetting2 = Queryable.FirstOrDefault<CrmLinkAccArpaSetting>((IQueryable<CrmLinkAccArpaSetting>)crmLinkAccArpaSetting, Expression.Lambda<Func<CrmLinkAccArpaSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)this, typeof(WarehouseController)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				if (crmLinkAccArpaSetting2 != null)
				{
					if (crmLinkAccArpaSetting2.LinkAccArpaSettingId > 0)
					{
						crmLinkAccArpaSetting2.PartValue = syncType.ToString();
						crmLinkAccArpaSetting2.RegisterDate = registerDate;
						crmLinkAccArpaSetting2.RegisterDatePersian = registerDatePersian;
						crmLinkAccArpaSetting2.UserId = userId;
						_dbTbl.Entry(crmLinkAccArpaSetting2).State = EntityState.Modified;
						_dbTbl.SaveChanges();
					}
					else
					{
						result = string.Format(Messages.msgNotSetLinkAccSettingWhRelation, text);
					}
				}
				else
				{
					result = Messages.msgUpdateCrmDatabase;
				}
				break;
			}
			case 17:
			{
				DbSet<CrmLinkAccHamrahanSetting> crmLinkAccHamrahanSetting = _dbTbl.CrmLinkAccHamrahanSetting;
				ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccHamrahanSetting), "x");
				CrmLinkAccHamrahanSetting crmLinkAccHamrahanSetting2 = Queryable.FirstOrDefault<CrmLinkAccHamrahanSetting>((IQueryable<CrmLinkAccHamrahanSetting>)crmLinkAccHamrahanSetting, Expression.Lambda<Func<CrmLinkAccHamrahanSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)this, typeof(WarehouseController)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				if (crmLinkAccHamrahanSetting2 != null)
				{
					if (crmLinkAccHamrahanSetting2.LinkAccHamrahanSettingId > 0)
					{
						crmLinkAccHamrahanSetting2.PartValue = syncType.ToString();
						crmLinkAccHamrahanSetting2.RegisterDate = registerDate;
						crmLinkAccHamrahanSetting2.RegisterDatePersian = registerDatePersian;
						crmLinkAccHamrahanSetting2.UserId = userId;
						_dbTbl.Entry(crmLinkAccHamrahanSetting2).State = EntityState.Modified;
						_dbTbl.SaveChanges();
					}
					else
					{
						result = string.Format(Messages.msgNotSetLinkAccSettingWhRelation, text);
					}
				}
				else
				{
					result = Messages.msgUpdateCrmDatabase;
				}
				break;
			}
			case 18:
			{
				CRMIdeal.Classes.Helper.OtherSystems.NoAvaranCapillarySettingViewModel noAvaranCapillarySetting = CRMIdeal.Classes.Helper.OtherSystems.GetNoAvaranCapillarySetting();
				if (noAvaranCapillarySetting != null)
				{
					int wrhsSyncTypeLinkAccSettingId4 = noAvaranCapillarySetting.WrhsSyncTypeLinkAccSettingId;
					if (wrhsSyncTypeLinkAccSettingId4 != 0)
					{
						CRMIdeal.Classes.Helper.OtherSystems.UpdateLinkAccSettingPartValue(wrhsSyncTypeLinkAccSettingId4, syncType.ToString());
					}
					else
					{
						result = string.Format(Messages.msgNotSetLinkAccSettingWhRelation, text);
					}
				}
				else
				{
					result = Messages.msgUpdateCrmDatabase;
				}
				break;
			}
			case 19:
			{
				CRMIdeal.Classes.Helper.OtherSystems.RahkaranRetailSettingViewModel rahkaranRetailSetting = CRMIdeal.Classes.Helper.OtherSystems.GetRahkaranRetailSetting();
				if (rahkaranRetailSetting != null)
				{
					int wrhsSyncTypeLinkAccSettingId7 = rahkaranRetailSetting.WrhsSyncTypeLinkAccSettingId;
					if (wrhsSyncTypeLinkAccSettingId7 != 0)
					{
						CRMIdeal.Classes.Helper.OtherSystems.UpdateLinkAccSettingPartValue(wrhsSyncTypeLinkAccSettingId7, syncType.ToString());
					}
					else
					{
						result = string.Format(Messages.msgNotSetLinkAccSettingWhRelation, text);
					}
				}
				else
				{
					result = Messages.msgUpdateCrmDatabase;
				}
				break;
			}
			case 20:
			{
				CRMIdeal.Classes.Helper.OtherSystems.NilramSettingViewModel nilramSetting = CRMIdeal.Classes.Helper.OtherSystems.GetNilramSetting();
				if (nilramSetting != null)
				{
					int wrhsSyncTypeLinkAccSettingId5 = nilramSetting.WrhsSyncTypeLinkAccSettingId;
					if (wrhsSyncTypeLinkAccSettingId5 != 0)
					{
						CRMIdeal.Classes.Helper.OtherSystems.UpdateLinkAccSettingPartValue(wrhsSyncTypeLinkAccSettingId5, syncType.ToString());
					}
					else
					{
						result = string.Format(Messages.msgNotSetLinkAccSettingWhRelation, text);
					}
				}
				else
				{
					result = Messages.msgUpdateCrmDatabase;
				}
				break;
			}
			case 22:
			{
				int wrhsSyncTypeLinkAccSettingId2 = new CRMIdeal.Classes.Helper.OtherSystems.RahkaranInternalSalesProvider().WrhsSyncTypeLinkAccSettingId;
				if (wrhsSyncTypeLinkAccSettingId2 != 0)
				{
					CRMIdeal.Classes.Helper.OtherSystems.UpdateLinkAccSettingPartValue(wrhsSyncTypeLinkAccSettingId2, syncType.ToString());
				}
				else
				{
					result = string.Format(Messages.msgNotSetLinkAccSettingWhRelation, text);
				}
				break;
			}
			case 23:
			{
				int wrhsSyncTypeLinkAccSettingId6 = new CRMIdeal.Classes.Helper.OtherSystems.RayvarzProvider().WrhsSyncTypeLinkAccSettingId;
				if (wrhsSyncTypeLinkAccSettingId6 != 0)
				{
					CRMIdeal.Classes.Helper.OtherSystems.UpdateLinkAccSettingPartValue(wrhsSyncTypeLinkAccSettingId6, syncType.ToString());
				}
				else
				{
					result = string.Format(Messages.msgNotSetLinkAccSettingWhRelation, text);
				}
				break;
			}
			case 25:
			{
				int wrhsSyncTypeLinkAccSettingId3 = new CRMIdeal.Classes.Helper.OtherSystems.ArianSystemProvider().WrhsSyncTypeLinkAccSettingId;
				if (wrhsSyncTypeLinkAccSettingId3 != 0)
				{
					CRMIdeal.Classes.Helper.OtherSystems.UpdateLinkAccSettingPartValue(wrhsSyncTypeLinkAccSettingId3, syncType.ToString());
				}
				else
				{
					result = string.Format(Messages.msgNotSetLinkAccSettingWhRelation, text);
				}
				break;
			}
			case 26:
			{
				int wrhsSyncTypeLinkAccSettingId = new CRMIdeal.Classes.Helper.OtherSystems.ShygunDetailedAPIProvider().WrhsSyncTypeLinkAccSettingId;
				if (wrhsSyncTypeLinkAccSettingId != 0)
				{
					CRMIdeal.Classes.Helper.OtherSystems.UpdateLinkAccSettingPartValue(wrhsSyncTypeLinkAccSettingId, syncType.ToString());
				}
				else
				{
					result = string.Format(Messages.msgNotSetLinkAccSettingWhRelation, text);
				}
				break;
			}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[HttpPost]
	public string GetManageLinkedWhsList()
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
			List<WSspSelectWareHouseWithAccLinkField_Result> list = Enumerable.ToList<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)_dbLink.WSspSelectWareHouseWithAccLinkField(false, false, false, true, lCID, result2));
			if (list != null && list.Count > 0)
			{
				result = JsonConvert.SerializeObject(list);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbLink.Dispose();
		_db_I.Dispose();
		_dbII.Dispose();
		base.Dispose(disposing);
	}
}
