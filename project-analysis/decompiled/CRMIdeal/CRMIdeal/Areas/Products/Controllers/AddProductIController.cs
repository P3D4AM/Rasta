using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CRM.General.Calendar;
using CRM.General.Security;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Areas.OtherSystems.Controllers;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Kendo.Mvc.UI;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.Products.Controllers;

public class AddProductIController : Controller
{
	private CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private CRMSpIEntities _dbI = new CRMSpIEntities();

	private CRMSpIIEntities _dbII = new CRMSpIIEntities();

	private CRMLinkSpEntities _dbLink = new CRMLinkSpEntities();

	private CRMSpIIIEntities _dbIII = new CRMSpIIIEntities();

	public ActionResult Index(string parentPage = "ord", bool isEdit = false, string masterForm = "SaleOrder", int masterId = 0, int detailId = 0, int taxInDoc = 0, string prdKind = "2")
	{
		SelectProductUnits();
		SelectWarehouse();
		SelectProductPriceGroup();
		SelectProductCostGroup();
		SelectProductColor();
		SelectLinkAccSettingDB();
		CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
		int num = 0;
		if (cRMspSelectCrmsysSetting_Result != null)
		{
			num = cRMspSelectCrmsysSetting_Result.LinkAccSystemId.GetValueOrDefault();
		}
		base.ViewBag.ParentPage = parentPage;
		base.ViewBag.ModeInsertEdit = (isEdit ? "Edit" : "Insert");
		base.ViewBag.DetailId = detailId;
		base.ViewBag.MasterId = masterId;
		base.ViewBag.MasterForm = masterForm;
		base.ViewBag.HaveTaxInDoc = taxInDoc;
		base.ViewBag.Mode = prdKind;
		int num2 = 0;
		if (masterForm == "SaleOrder")
		{
			num2 = Order.OrderItemsDoneTimeSum(masterId, detailId);
		}
		base.ViewBag.OrderItemsDoneTimeSum = num2;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		string text2 = "";
		switch (masterForm)
		{
		case "preOrder":
		case "PreOrder":
			text = "frmPreOrder";
			text2 = "actAddProductMulti";
			if (num == 4)
			{
				WSspSelectPreOrderItems_Result wSspSelectPreOrderItems_Result = Enumerable.FirstOrDefault<WSspSelectPreOrderItems_Result>((IEnumerable<WSspSelectPreOrderItems_Result>)Enumerable.OrderByDescending<WSspSelectPreOrderItems_Result, int>((IEnumerable<WSspSelectPreOrderItems_Result>)_db.WSspSelectPreOrderItems(masterId, lCID, result), (Func<WSspSelectPreOrderItems_Result, int>)((WSspSelectPreOrderItems_Result m) => m.PreOrderItemID)));
				base.ViewBag.DefLinkAccSettingDBId = wSspSelectPreOrderItems_Result?.pordILinkAccSettingDBId.GetValueOrDefault() ?? 0;
			}
			break;
		case "SaleOrder":
			text = "frmOrder";
			text2 = "actAddProductMulti";
			if (num == 4)
			{
				WSspSelectOrderItems_Result wSspSelectOrderItems_Result = Enumerable.FirstOrDefault<WSspSelectOrderItems_Result>((IEnumerable<WSspSelectOrderItems_Result>)Enumerable.OrderByDescending<WSspSelectOrderItems_Result, int>((IEnumerable<WSspSelectOrderItems_Result>)_db.WSspSelectOrderItems(masterId, lCID, result), (Func<WSspSelectOrderItems_Result, int>)((WSspSelectOrderItems_Result m) => m.OrderId)));
				base.ViewBag.DefLinkAccSettingDBId = wSspSelectOrderItems_Result?.ordILinkAccSettingDBId.GetValueOrDefault() ?? 0;
			}
			break;
		default:
			return RedirectToAction("Login", "Account", (object)new
			{
				area = "",
				d = DateTime.Now
			});
		}
		if (!UserLogin.IsUserAccess(text, text2, UserLogin.CurrentUser))
		{
			return RedirectToAction("Login", "Account", (object)new
			{
				area = "",
				d = DateTime.Now
			});
		}
		string text3 = "frmAddProduct";
		text3 = masterForm.ToLower() switch
		{
			"preorder" => "frmPreOrderItemDataEntry", 
			"saleorder" => "frmOrderItemDataEntry", 
			"buyorder" => "frmBuyOrderItemDataEntry", 
			"stocksupply" => "frmStockSupplyItemDataEntry", 
			_ => "frmAddProduct", 
		};
		base.ViewBag.ItemFormName = text3;
		switch (num)
		{
		case 8:
		{
			CRMIdeal.Classes.Helper.OtherSystems.ShygunSettingViewModel shygunSetting = CRMIdeal.Classes.Helper.OtherSystems.GetShygunSetting();
			if (shygunSetting != null)
			{
				base.ViewBag.LinkAccWrhsSyncTypeId = shygunSetting.WrhsSyncTypeId;
			}
			break;
		}
		case 9:
		{
			CRMIdeal.Classes.Helper.OtherSystems.ShygunIISettingViewModel shygunIISetting = CRMIdeal.Classes.Helper.OtherSystems.GetShygunIISetting();
			if (shygunIISetting != null)
			{
				base.ViewBag.LinkAccWrhsSyncTypeId = shygunIISetting.WrhsSyncTypeId;
			}
			break;
		}
		case 11:
		{
			CRMIdeal.Classes.Helper.OtherSystems.ShomaranSettingViewModel shomaranSetting = CRMIdeal.Classes.Helper.OtherSystems.GetShomaranSetting();
			if (shomaranSetting != null)
			{
				base.ViewBag.LinkAccWrhsSyncTypeId = shomaranSetting.WrhsSyncTypeId;
			}
			break;
		}
		case 12:
		{
			CRMIdeal.Classes.Helper.OtherSystems.ArpaSettingViewModel arpaSetting = CRMIdeal.Classes.Helper.OtherSystems.GetArpaSetting();
			if (arpaSetting != null)
			{
				base.ViewBag.LinkAccWrhsSyncTypeId = arpaSetting.WrhsSyncTypeId;
			}
			break;
		}
		case 17:
		{
			CRMIdeal.Classes.Helper.OtherSystems.HamrahanSettingViewModel hamrahanSetting = CRMIdeal.Classes.Helper.OtherSystems.GetHamrahanSetting();
			if (hamrahanSetting != null)
			{
				base.ViewBag.LinkAccWrhsSyncTypeId = hamrahanSetting.WrhsSyncTypeId;
			}
			break;
		}
		case 18:
		{
			CRMIdeal.Classes.Helper.OtherSystems.NoAvaranCapillarySettingViewModel noAvaranCapillarySetting = CRMIdeal.Classes.Helper.OtherSystems.GetNoAvaranCapillarySetting();
			if (noAvaranCapillarySetting != null)
			{
				base.ViewBag.LinkAccWrhsSyncTypeId = noAvaranCapillarySetting.WrhsSyncTypeId;
			}
			break;
		}
		case 19:
		{
			CRMIdeal.Classes.Helper.OtherSystems.RahkaranRetailSettingViewModel rahkaranRetailSetting = CRMIdeal.Classes.Helper.OtherSystems.GetRahkaranRetailSetting();
			if (rahkaranRetailSetting != null)
			{
				base.ViewBag.LinkAccWrhsSyncTypeId = rahkaranRetailSetting.WrhsSyncTypeId;
			}
			break;
		}
		case 20:
		{
			CRMIdeal.Classes.Helper.OtherSystems.NilramSettingViewModel nilramSetting = CRMIdeal.Classes.Helper.OtherSystems.GetNilramSetting();
			if (nilramSetting != null)
			{
				base.ViewBag.LinkAccWrhsSyncTypeId = nilramSetting.WrhsSyncTypeId;
			}
			break;
		}
		case 22:
		{
			CRMIdeal.Classes.Helper.OtherSystems.RahkaranInternalSalesProvider rahkaranInternalSalesProvider = new CRMIdeal.Classes.Helper.OtherSystems.RahkaranInternalSalesProvider(isUpdateList: false, isLogin: false);
			base.ViewBag.LinkAccWrhsSyncTypeId = rahkaranInternalSalesProvider.WrhsSyncTypeId;
			break;
		}
		case 23:
		{
			CRMIdeal.Classes.Helper.OtherSystems.RayvarzProvider rayvarzProvider = new CRMIdeal.Classes.Helper.OtherSystems.RayvarzProvider(isUpdateList: false, isLogin: false);
			base.ViewBag.LinkAccWrhsSyncTypeId = rayvarzProvider.WrhsSyncTypeId;
			break;
		}
		case 25:
		{
			CRMIdeal.Classes.Helper.OtherSystems.ArianSystemProvider arianSystemProvider = new CRMIdeal.Classes.Helper.OtherSystems.ArianSystemProvider(isUpdateList: false, isLogin: false);
			base.ViewBag.LinkAccWrhsSyncTypeId = arianSystemProvider.WrhsSyncTypeId;
			break;
		}
		}
		return View();
	}

	[HttpPost]
	[LoginAuthorize]
	public string AddProductItem(string records, bool InsertWithDups, int cmpId, int buyOrder, int preOrderId, int orderId)
	{
		//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1660: Unknown result type (might be due to invalid IL or missing references)
		//IL_176a: Unknown result type (might be due to invalid IL or missing references)
		List<CommonSelectListItemViewModel> list = new List<CommonSelectListItemViewModel>();
		try
		{
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string text = now.ToString("yyyyMMdd", new PersianCulture());
			int userId = UserLogin.CurrentUser.UserId;
			short.Parse(Financial.Get().Id.ToString());
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int id = Financial.Get().Id;
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
			if (string.IsNullOrWhiteSpace(records))
			{
				list.Add(new CommonSelectListItemViewModel
				{
					Text = string.Format(Messages.msgErrorListEmpty, Labels.AddProductIPrds),
					Value = "0"
				});
			}
			else
			{
				bool result2 = false;
				bool result3 = false;
				CRMspSelectFoSetting_Result foSetting = CRMIdeal.Classes.Helper.Setting.GetFoSetting();
				if (foSetting != null)
				{
					bool.TryParse(foSetting.ShpUniqueSaleCenterParentInOrd.ToString(), out result2);
					bool.TryParse(foSetting.ShpPrdDoneTimeScheduleActive.ToString(), out result3);
				}
				CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
				bool flag = false;
				int num = 0;
				if (cRMspSelectCrmsysSetting_Result != null)
				{
					flag = ((cRMspSelectCrmsysSetting_Result.InvStockFromLink.HasValue && cRMspSelectCrmsysSetting_Result.InvStockFromLink.GetValueOrDefault()) ? true : false);
					num = cRMspSelectCrmsysSetting_Result.LinkAccSystemId.GetValueOrDefault();
				}
				List<AddProductViewModel> list2 = new List<AddProductViewModel>();
				try
				{
					list2 = new JavaScriptSerializer().Deserialize<List<AddProductViewModel>>(records);
					list2 = Enumerable.ToList<AddProductViewModel>(Enumerable.Where<AddProductViewModel>((IEnumerable<AddProductViewModel>)list2, (Func<AddProductViewModel, bool>)((AddProductViewModel x) => x.ProductId > 0)));
				}
				catch (Exception ex)
				{
					ErrorSignal.FromCurrentContext().Raise(ex);
					list.Add(new CommonSelectListItemViewModel
					{
						Text = Messages.msgErrorJsonDeserialize + " / " + ex.Message,
						Value = "0"
					});
				}
				if (list2 != null && Enumerable.Any<AddProductViewModel>((IEnumerable<AddProductViewModel>)list2))
				{
					string linkAccSystemTitle = CRMIdeal.Classes.Helper.Setting.GetLinkAccSystemTitle();
					if (Enumerable.FirstOrDefault<AddProductViewModel>((IEnumerable<AddProductViewModel>)list2).MasterForm == "pord" || Enumerable.FirstOrDefault<AddProductViewModel>((IEnumerable<AddProductViewModel>)list2).MasterForm == "PreOrderHavePrdMustExist" || Enumerable.FirstOrDefault<AddProductViewModel>((IEnumerable<AddProductViewModel>)list2).MasterForm == "PreOrder")
					{
						if (PreOrder.IsSentToLinkAccByAction(preOrderId))
						{
							list.Add(new CommonSelectListItemViewModel
							{
								Text = string.Format(Messages.msgErrorUnableChangeInSentToLinkAcc, linkAccSystemTitle),
								Value = "0"
							});
						}
					}
					else if ((Enumerable.FirstOrDefault<AddProductViewModel>((IEnumerable<AddProductViewModel>)list2).MasterForm == "ord" || Enumerable.FirstOrDefault<AddProductViewModel>((IEnumerable<AddProductViewModel>)list2).MasterForm == "SaleOrder") && Order.IsSentToLinkAccByAction(orderId))
					{
						list.Add(new CommonSelectListItemViewModel
						{
							Text = string.Format(Messages.msgErrorUnableChangeInSentToLinkAcc, linkAccSystemTitle),
							Value = "0"
						});
					}
				}
				string text2 = "";
				if (list2 != null && Enumerable.Any<AddProductViewModel>((IEnumerable<AddProductViewModel>)list2))
				{
					AddProductViewModel addProductViewModel = Enumerable.FirstOrDefault<AddProductViewModel>((IEnumerable<AddProductViewModel>)list2);
					if (addProductViewModel != null)
					{
						text2 = (addProductViewModel.MasterForm ?? "").ToLower();
					}
					if (flag && num > 0)
					{
						foreach (AddProductViewModel item in list2)
						{
							double result4 = 0.0;
							new ProductController();
							string text3 = "";
							text3 = CRMIdeal.Classes.Helper.OtherSystems.GetPrdQuantity(userId, item.ProductId, item.WHId.GetValueOrDefault(), item.LinkAccWHIdStr ?? "", item.Tracing ?? "", cmpId, "", item.LinkAccSettingDBId.GetValueOrDefault());
							if (!string.IsNullOrEmpty(text3))
							{
								if (text3 == Labels.frmError)
								{
									text3 = "0";
								}
								if (text3 != Labels.frmError)
								{
									double.TryParse(text3, out result4);
								}
							}
							item.PrdSHPLinkAccStock = result4;
						}
					}
					if ((text2 == "preorder" || text2 == "pord") && UserLogin.IsUserAccess("frmPreOrder", "actCanNotVerifyNoStockFromShop", UserLogin.CurrentUser))
					{
						foreach (AddProductViewModel item2 in list2)
						{
							if (!string.IsNullOrWhiteSpace(item2.Tracing))
							{
								ObjectParameter resultJson = new ObjectParameter("ResultJson", "");
								WSspCheckDuplicatePreOrderItemTracingFromShop_Result wSspCheckDuplicatePreOrderItemTracingFromShop_Result = Enumerable.FirstOrDefault<WSspCheckDuplicatePreOrderItemTracingFromShop_Result>((IEnumerable<WSspCheckDuplicatePreOrderItemTracingFromShop_Result>)_dbII.WSspCheckDuplicatePreOrderItemTracingFromShop(0, item2.ProductId, item2.WHId, item2.Tracing, item2.PrdSHPLinkAccStock.GetValueOrDefault(), centerId, lCID, result, false, resultJson));
								if (wSspCheckDuplicatePreOrderItemTracingFromShop_Result != null && wSspCheckDuplicatePreOrderItemTracingFromShop_Result.PreOrderItemID > 0)
								{
									string text4 = (wSspCheckDuplicatePreOrderItemTracingFromShop_Result.pordDateTime.HasValue ? wSspCheckDuplicatePreOrderItemTracingFromShop_Result.pordDateTime.Value.ToString("yyyy/MM/dd") : "");
									list.Add(new CommonSelectListItemViewModel
									{
										Text = string.Format(Messages.msgErrorNotSaveDupTracingByFoShop, Labels.lblPOrd, wSspCheckDuplicatePreOrderItemTracingFromShop_Result.pordNumber.GetValueOrDefault().ToString(), text4, item2.Tracing ?? ""),
										Value = "0"
									});
								}
							}
						}
					}
				}
				List<AddProductViewModel> list3 = new List<AddProductViewModel>();
				if (list2 != null && list.Count <= 0 && orderId != 0 && result3)
				{
					WSspSelectOrderById_Result ord = Enumerable.FirstOrDefault<WSspSelectOrderById_Result>((IEnumerable<WSspSelectOrderById_Result>)_db.WSspSelectOrderById(orderId, lCID, result));
					if (ord != null && ord.ordSaleCenterId.GetValueOrDefault() != 0 && Enumerable.ToList<AddProductViewModel>(Enumerable.Where<AddProductViewModel>((IEnumerable<AddProductViewModel>)list2, (Func<AddProductViewModel, bool>)((AddProductViewModel x) => x.ParentSaleCenterId.GetValueOrDefault() != 0 && x.ParentSaleCenterId != ord.ordSaleCenterId))).Count != 0)
					{
						list.Add(new CommonSelectListItemViewModel
						{
							Text = "msgErrorNotSaveOrdItemByDifferentOrdSaleCenter".OrderMessages(),
							Value = "0"
						});
					}
				}
				int defLinkAccSettingDBId = 0;
				if (num == 4)
				{
					switch (text2)
					{
					case "preOrder":
					case "PreOrder":
						defLinkAccSettingDBId = Enumerable.FirstOrDefault<WSspSelectPreOrderItems_Result>((IEnumerable<WSspSelectPreOrderItems_Result>)Enumerable.OrderByDescending<WSspSelectPreOrderItems_Result, int>((IEnumerable<WSspSelectPreOrderItems_Result>)_db.WSspSelectPreOrderItems(preOrderId, lCID, result), (Func<WSspSelectPreOrderItems_Result, int>)((WSspSelectPreOrderItems_Result m) => m.PreOrderItemID)))?.pordILinkAccSettingDBId.GetValueOrDefault() ?? 0;
						break;
					case "SaleOrder":
						defLinkAccSettingDBId = Enumerable.FirstOrDefault<WSspSelectOrderItems_Result>((IEnumerable<WSspSelectOrderItems_Result>)Enumerable.OrderByDescending<WSspSelectOrderItems_Result, int>((IEnumerable<WSspSelectOrderItems_Result>)_db.WSspSelectOrderItems(orderId, lCID, result), (Func<WSspSelectOrderItems_Result, int>)((WSspSelectOrderItems_Result m) => m.OrderId)))?.ordILinkAccSettingDBId.GetValueOrDefault() ?? 0;
						break;
					}
					if (defLinkAccSettingDBId > 0)
					{
						if (!Enumerable.All<AddProductViewModel>((IEnumerable<AddProductViewModel>)list2, (Func<AddProductViewModel, bool>)((AddProductViewModel c) => c.LinkAccSettingDBId == defLinkAccSettingDBId)))
						{
							list.Add(new CommonSelectListItemViewModel
							{
								Text = Messages.HolooConflictLinkAccSettingDB,
								Value = "0"
							});
						}
					}
					else if (Enumerable.Count<int?>(Enumerable.Distinct<int?>(Enumerable.Select<AddProductViewModel, int?>((IEnumerable<AddProductViewModel>)list2, (Func<AddProductViewModel, int?>)((AddProductViewModel c) => c.LinkAccSettingDBId)))) != 1)
					{
						list.Add(new CommonSelectListItemViewModel
						{
							Text = Messages.HolooConflictLinkAccSettingDB,
							Value = "0"
						});
					}
				}
				if (list2 != null && list.Count <= 0)
				{
					foreach (AddProductViewModel item3 in list2)
					{
						DateTime dateTime = default(DateTime);
						string text5 = "";
						try
						{
							if (!string.IsNullOrEmpty(item3.DeliveryDatePersian))
							{
								text5 = PersianDate.GetFormatetdDate(item3.DeliveryDatePersian.Replace("/", ""));
								string text6 = ((!string.IsNullOrWhiteSpace(item3.DeliveryTime)) ? item3.DeliveryTime : "00:00:00");
								switch (lCID)
								{
								case 1065:
									dateTime = DateTime.Parse(text5 + " " + text6, new PersianCulture());
									item3.DeliveryDatePersian = dateTime.ToString("yyyyMMdd");
									break;
								case 1025:
									dateTime = DateTime.Parse(text5 + " " + text6, new CultureInfo("ar-SA"));
									item3.DeliveryDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
									break;
								default:
									dateTime = DateTime.Parse(text5 + " " + text6, new CultureInfo("en-US"));
									item3.DeliveryDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
									break;
								}
								item3.DeliveryDate = dateTime;
								item3.DeliveryDay = DateTimeClass.DefineDayeOfWeekStartWith7(dateTime.DayOfWeek.ToString());
							}
							else
							{
								item3.DeliveryDate = null;
								item3.DeliveryDatePersian = null;
								item3.DeliveryDay = null;
							}
						}
						catch (Exception ex2)
						{
							ErrorSignal.FromCurrentContext().Raise(ex2);
							base.ViewBag.Error = Messages.WrongDateTime;
							list.Add(new CommonSelectListItemViewModel
							{
								Text = Messages.WrongDateTime + ". " + ex2.Message,
								Value = "0"
							});
						}
						if (item3.DeliveryDatePersian != null)
						{
							item3.DeliveryDatePersian = item3.DeliveryDatePersian.Replace("/", "").Replace("-", "").Replace("_", "")
								.Replace(".", "")
								.Replace(",", "")
								.Replace("\\", "");
						}
						try
						{
							if (!string.IsNullOrEmpty(item3.DeliveryEndDatePersian))
							{
								text5 = PersianDate.GetFormatetdDate(item3.DeliveryEndDatePersian.Replace("/", ""));
								string text7 = ((!string.IsNullOrWhiteSpace(item3.DeliveryEndTime)) ? item3.DeliveryEndTime : "00:00:00");
								switch (lCID)
								{
								case 1065:
									dateTime = DateTime.Parse(text5 + " " + text7, new PersianCulture());
									item3.DeliveryEndDatePersian = dateTime.ToString("yyyyMMdd");
									break;
								case 1025:
									dateTime = DateTime.Parse(text5 + " " + text7, new CultureInfo("ar-SA"));
									item3.DeliveryEndDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
									break;
								default:
									dateTime = DateTime.Parse(text5 + " " + text7, new CultureInfo("en-US"));
									item3.DeliveryEndDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
									break;
								}
								item3.DeliveryEndDate = dateTime;
								item3.DeliveryEndDay = DateTimeClass.DefineDayeOfWeekStartWith7(dateTime.DayOfWeek.ToString());
							}
							else
							{
								item3.DeliveryEndDate = null;
								item3.DeliveryEndDatePersian = null;
								item3.DeliveryEndDay = null;
							}
						}
						catch (Exception ex3)
						{
							ErrorSignal.FromCurrentContext().Raise(ex3);
							base.ViewBag.Error = Messages.WrongDateTime;
							list.Add(new CommonSelectListItemViewModel
							{
								Text = Messages.WrongDateTime + ". " + ex3.Message,
								Value = "0"
							});
						}
						if (item3.DeliveryEndDatePersian != null)
						{
							item3.DeliveryEndDatePersian = item3.DeliveryEndDatePersian.Replace("/", "").Replace("-", "").Replace("_", "")
								.Replace(".", "")
								.Replace(",", "")
								.Replace("\\", "");
						}
						try
						{
							if (!string.IsNullOrEmpty(item3.ValidityExpireDatePersian))
							{
								text5 = PersianDate.GetFormatetdDate(item3.ValidityExpireDatePersian.Replace("/", ""));
								string text8 = ((!string.IsNullOrWhiteSpace(item3.ValidityExpireTime)) ? item3.ValidityExpireTime : DateTime.Now.ToString("hh:mm:ss"));
								switch (lCID)
								{
								case 1065:
									dateTime = DateTime.Parse(text5 + " " + text8, new PersianCulture());
									item3.ValidityExpireDatePersian = dateTime.ToString("yyyyMMdd");
									break;
								case 1025:
									dateTime = DateTime.Parse(text5 + " " + text8, new CultureInfo("ar-SA"));
									item3.ValidityExpireDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
									break;
								default:
									dateTime = DateTime.Parse(text5 + " " + text8, new CultureInfo("en-US"));
									item3.ValidityExpireDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
									break;
								}
								item3.ValidityExpireDate = dateTime;
							}
							else
							{
								item3.ValidityExpireDate = null;
								item3.ValidityExpireDatePersian = null;
							}
						}
						catch (Exception ex4)
						{
							ErrorSignal.FromCurrentContext().Raise(ex4);
							base.ViewBag.Error = Messages.WrongDateTime;
							list.Add(new CommonSelectListItemViewModel
							{
								Text = Messages.WrongDateTime + ". " + ex4.Message,
								Value = "0"
							});
						}
						if (item3.ValidityExpireDatePersian != null)
						{
							item3.ValidityExpireDatePersian = item3.ValidityExpireDatePersian.Replace("/", "").Replace("-", "").Replace("_", "")
								.Replace(".", "")
								.Replace(",", "")
								.Replace("\\", "");
						}
						if (orderId != 0 && item3.SaleCenterId.GetValueOrDefault() != 0 && result3)
						{
							ObjectParameter objectParameter = new ObjectParameter("Result", typeof(int));
							_dbII.WSspCheckOrderItemSaleCenterUnique(orderId, item3.SaleCenterId, objectParameter);
							if (objectParameter != null && objectParameter.Value != null)
							{
								int result5 = 0;
								int.TryParse(objectParameter.Value.ToString(), out result5);
								if (result5 == 0)
								{
									list.Add(new CommonSelectListItemViewModel
									{
										Text = item3.ProductName + " : " + "msgErrorNotSaveOrdItemByDifferentOrdSaleCenter".OrderMessages(),
										Value = "0"
									});
								}
							}
						}
						int cmpId2 = 0;
						int num2 = 0;
						int result6 = 1;
						string crmOrdType = "pord";
						string masterFormName = "";
						string formName = "";
						WSspSelectProductsWithId_Result wSspSelectProductsWithId_Result = Enumerable.FirstOrDefault<WSspSelectProductsWithId_Result>((IEnumerable<WSspSelectProductsWithId_Result>)_db.WSspSelectProductsWithId(item3.ProductId, lCID, result));
						if (wSspSelectProductsWithId_Result != null)
						{
							int.TryParse(wSspSelectProductsWithId_Result.PrdKind.ToString(), out result6);
						}
						switch (text2)
						{
						case "preorder":
						case "pord":
						case "saleorder":
						case "ord":
						{
							bool flag2 = false;
							switch (text2)
							{
							case "preorder":
							case "pord":
							{
								formName = "frmPreOrderItemDataEntry";
								masterFormName = "preOrder";
								WSspSelectPreOrderWithId_Result wSspSelectPreOrderWithId_Result = Enumerable.FirstOrDefault<WSspSelectPreOrderWithId_Result>((IEnumerable<WSspSelectPreOrderWithId_Result>)_db.WSspSelectPreOrderWithId(preOrderId, lCID, result));
								if (wSspSelectPreOrderWithId_Result != null)
								{
									cmpId2 = wSspSelectPreOrderWithId_Result.pordCompanyId.GetValueOrDefault();
								}
								if (UserLogin.IsUserAccess(formName, "actCanNotSelectWithNoStockInPord", currentUser) || UserLogin.IsUserAccess(formName, "actCanNotSelectWithNoReserveStockInPord", currentUser) || UserLogin.IsUserAccess(formName, "actCanNotSelectWithNoSoldStockInPord", currentUser))
								{
									flag2 = true;
								}
								break;
							}
							case "saleorder":
							case "ord":
							{
								formName = "frmOrderItemDataEntry";
								masterFormName = "SaleOrder";
								crmOrdType = "ord";
								WSspSelectOrderById_Result wSspSelectOrderById_Result = Enumerable.FirstOrDefault<WSspSelectOrderById_Result>((IEnumerable<WSspSelectOrderById_Result>)_db.WSspSelectOrderById(preOrderId, lCID, result));
								if (wSspSelectOrderById_Result != null)
								{
									cmpId2 = wSspSelectOrderById_Result.ordCompanyId;
									num2 = wSspSelectOrderById_Result.OrderOprType.GetValueOrDefault();
								}
								if (UserLogin.IsUserAccess(formName, "actCanNotSelectWithNoStockInOrd", currentUser) || UserLogin.IsUserAccess(formName, "actCanNotSelectWithNoReserveStockInOrd", currentUser) || UserLogin.IsUserAccess(formName, "actCanNotSelectWithNoSoldStockInOrd", currentUser))
								{
									flag2 = true;
								}
								break;
							}
							}
							if (!flag || num == 0 || !flag2 || result6 == 2 || num2 == 2)
							{
								break;
							}
							ReturnPrdQuantityViewModel returnPrdQuantityViewModel = new SearchController().ReturnPrdQuantityResult(item3.ProductId, preOrderId, item3.WHId.GetValueOrDefault(), item3.FCR.GetValueOrDefault(), item3.FCRI.GetValueOrDefault(), item3.Tracing ?? "", cmpId2, item3.PrdPriceGroupId.GetValueOrDefault(), crmOrdType, item3.LinkAccWHIdStr ?? "", item3.DescriptionI ?? "", masterFormName, item3.LinkAccSettingDBId.GetValueOrDefault());
							if (returnPrdQuantityViewModel != null)
							{
								double quantity = item3.Quantity;
								double result7 = 0.0;
								if (returnPrdQuantityViewModel.PrdQuantity != null)
								{
									double.TryParse(returnPrdQuantityViewModel.PrdQuantity.TracingRemainCount.ToString(), out result7);
								}
								double result8 = 0.0;
								double.TryParse(returnPrdQuantityViewModel.QtyRemain.ToString(), out result8);
								double result9 = 0.0;
								double.TryParse(returnPrdQuantityViewModel.RemainSoldOrdPrdQuantity.ToString(), out result9);
								if ((((text2 == "preorder" || text2 == "pord") && UserLogin.IsUserAccess(formName, "actCanNotSelectWithNoStockInPord", currentUser)) || ((text2 == "saleorder" || text2 == "ord") && UserLogin.IsUserAccess(formName, "actCanNotSelectWithNoStockInOrd", currentUser))) && (result7 <= 0.0 || result7 < quantity))
								{
									list.Add(new CommonSelectListItemViewModel
									{
										Text = Messages.ProductLackOfStock,
										Value = "-90"
									});
								}
								if ((((text2 == "preorder" || text2 == "pord") && UserLogin.IsUserAccess(formName, "actCanNotSelectWithNoReserveStockInPord", currentUser)) || ((text2 == "saleorder" || text2 == "ord") && UserLogin.IsUserAccess(formName, "actCanNotSelectWithNoReserveStockInOrd", currentUser))) && result8 < quantity)
								{
									list.Add(new CommonSelectListItemViewModel
									{
										Text = Messages.ProductLackOfReserveStock,
										Value = "-100"
									});
								}
								if ((((text2 == "preorder" || text2 == "pord") && UserLogin.IsUserAccess(formName, "actCanNotSelectWithNoSoldStockInPord", currentUser)) || ((text2 == "saleorder" || text2 == "ord") && UserLogin.IsUserAccess(formName, "actCanNotSelectWithNoSoldStockInOrd", currentUser))) && result9 < quantity)
								{
									list.Add(new CommonSelectListItemViewModel
									{
										Text = Messages.msgErrorProductLackOfSoldStock,
										Value = "-200"
									});
								}
							}
							break;
						}
						}
						list3.Add(item3);
					}
				}
				if (list.Count <= 0)
				{
					if (Enumerable.FirstOrDefault<AddProductViewModel>((IEnumerable<AddProductViewModel>)list2).MasterForm == "ord" || Enumerable.FirstOrDefault<AddProductViewModel>((IEnumerable<AddProductViewModel>)list2).MasterForm == "SaleOrder")
					{
						ObjectParameter objectParameter2 = new ObjectParameter("resultMessages", "");
						_dbI.WSspInsertOrderItemsMulti(cmpId, preOrderId, orderId, JsonConvert.SerializeObject(list3), userId, id, value2, value, text, appType, lCID, result, userId, value, text, objectParameter2, centerId);
						if (objectParameter2 != null && !string.IsNullOrWhiteSpace(objectParameter2.Value.ToString()))
						{
							List<CommonSelectListItemViewModel> collection = new JavaScriptSerializer().Deserialize<List<CommonSelectListItemViewModel>>(objectParameter2.Value.ToString());
							list.AddRange(collection);
						}
					}
					else if ((Enumerable.FirstOrDefault<AddProductViewModel>((IEnumerable<AddProductViewModel>)list2).MasterForm == "pord" || Enumerable.FirstOrDefault<AddProductViewModel>((IEnumerable<AddProductViewModel>)list2).MasterForm == "PreOrderHavePrdMustExist" || Enumerable.FirstOrDefault<AddProductViewModel>((IEnumerable<AddProductViewModel>)list2).MasterForm == "PreOrder") && list.Count <= 0)
					{
						ObjectParameter objectParameter3 = new ObjectParameter("resultMessages", "");
						_dbI.WSspInsertPreOrderItemsMulti(cmpId, preOrderId, JsonConvert.SerializeObject(list3), userId, id, value2, value, text, appType, lCID, result, userId, value, text, objectParameter3, centerId);
						if (objectParameter3 != null && !string.IsNullOrWhiteSpace(objectParameter3.Value.ToString()))
						{
							List<CommonSelectListItemViewModel> list4 = new JavaScriptSerializer().Deserialize<List<CommonSelectListItemViewModel>>(objectParameter3.Value.ToString());
							if (list4 != null && Enumerable.Any<CommonSelectListItemViewModel>((IEnumerable<CommonSelectListItemViewModel>)list4))
							{
								foreach (CommonSelectListItemViewModel item4 in list4)
								{
									int result10 = 0;
									int.TryParse(item4.Value.ToString(), out result10);
									if (result10 != -190)
									{
										continue;
									}
									string text9 = item4.Text ?? "";
									if (string.IsNullOrWhiteSpace(text9))
									{
										continue;
									}
									string[] array = text9.Split(new char[1] { '|' });
									if (array != null && array.Length >= 4)
									{
										string text10 = array[0];
										string text11 = array[1];
										string text12 = array[2];
										string text13 = array[3];
										text10 = (text10 ?? "").Replace("Duplicate tracing. @PordId=", "").Trim();
										text11 = (text11 ?? "").Replace("@pordNum=", "").Trim();
										text12 = (text12 ?? "").Replace("@pordDate=", "");
										text13 = (text13 ?? "").Replace("@trac=", "");
										int result11 = 0;
										long result12 = 0L;
										DateTime result13 = DateTime.Now;
										int.TryParse(text10, out result11);
										long.TryParse(text11, out result12);
										DateTime.TryParse(text12, out result13);
										if (result11 != 0)
										{
											DateTime dateTime2 = result13;
											string text14 = dateTime2.ToString("yyyy/MM/dd");
											item4.Text = string.Format(Messages.msgErrorNotSaveDupTracingByFoShop, Labels.lblPOrd, result12.ToString(), text14, text13 ?? "");
										}
									}
								}
							}
							list.AddRange(list4);
						}
					}
				}
			}
		}
		catch (Exception ex5)
		{
			ErrorSignal.FromCurrentContext().Raise(ex5);
			list.Add(new CommonSelectListItemViewModel
			{
				Text = ex5.Message,
				Value = "0"
			});
		}
		return JsonConvert.SerializeObject(list);
	}

	public ActionResult LinkedProduct(int prdId = 0, int prdPriceGroupId = 0, int destCurrencyUnitId = 0, string selectedIds = "", string masterFormName = "")
	{
		string text = masterFormName.ToLower();
		string text2 = "frmAddProduct";
		base.ViewBag.ItemFormName = text switch
		{
			"preorder" => "frmPreOrderItemDataEntry", 
			"saleorder" => "frmOrderItemDataEntry", 
			"buyorder" => "frmBuyOrderItemDataEntry", 
			"stocksupply" => "frmStockSupplyItemDataEntry", 
			_ => "frmAddProduct", 
		};
		SelectLinkedProducts(prdId, prdPriceGroupId, destCurrencyUnitId, selectedIds);
		return View();
	}

	[HttpPost]
	[LoginAuthorize]
	public string CheckSingleItem(string sysPartName = "", int masterId = 0, int detailId = 0, int prdId = 0, bool isSingle = false)
	{
		string result = "";
		if (masterId > 0 && prdId > 0)
		{
			if (sysPartName == "Pord" || sysPartName == "pord" || sysPartName == "PreOrder" || sysPartName == "preOrder")
			{
				List<WSspCheckUsedPrdSingleItemInPreOrder_Result> list = Enumerable.ToList<WSspCheckUsedPrdSingleItemInPreOrder_Result>((IEnumerable<WSspCheckUsedPrdSingleItemInPreOrder_Result>)_dbI.WSspCheckUsedPrdSingleItemInPreOrder(masterId, detailId, prdId));
				if (list != null && Enumerable.Any<WSspCheckUsedPrdSingleItemInPreOrder_Result>((IEnumerable<WSspCheckUsedPrdSingleItemInPreOrder_Result>)list))
				{
					result = ((!isSingle) ? Messages.msgErrorNoRegisterPrdInPordWithSingleItem : Messages.msgErrorNoRegisterPrdSingleItemInPord);
				}
			}
			else if (sysPartName == "Ord" || sysPartName == "SaleOrder" || sysPartName == "Ord")
			{
				List<WSspCheckUsedPrdSingleItemInOrder_Result> list2 = Enumerable.ToList<WSspCheckUsedPrdSingleItemInOrder_Result>((IEnumerable<WSspCheckUsedPrdSingleItemInOrder_Result>)_dbI.WSspCheckUsedPrdSingleItemInOrder(masterId, detailId, prdId));
				if (list2 != null && Enumerable.Any<WSspCheckUsedPrdSingleItemInOrder_Result>((IEnumerable<WSspCheckUsedPrdSingleItemInOrder_Result>)list2))
				{
					result = ((!isSingle) ? Messages.msgErrorNoRegisterPrdInOrdWithSingleItem : Messages.msgErrorNoRegisterPrdSingleItemInOrd);
				}
			}
		}
		return result;
	}

	public ActionResult ProductTree(int mode, int prdKind, int prdInActive, int cmpId, int prjId, string masterFormName = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<TreeViewItemModel> list = new List<TreeViewItemModel>();
		try
		{
			List<WSspProductsTree_Result> list2 = Enumerable.ToList<WSspProductsTree_Result>((IEnumerable<WSspProductsTree_Result>)_db.WSspProductsTree(mode, lCID, result, prdKind, prdInActive, cmpId, prjId));
			foreach (WSspProductsTree_Result item in Enumerable.ToList<WSspProductsTree_Result>(Enumerable.Where<WSspProductsTree_Result>((IEnumerable<WSspProductsTree_Result>)list2, (Func<WSspProductsTree_Result, bool>)((WSspProductsTree_Result c) => c.ParentId == 0))))
			{
				TreeViewItemModel treeViewItemModel = new TreeViewItemModel();
				treeViewItemModel.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", item.FId + "|" + item.SId + "|" + item.PrdId));
				treeViewItemModel.Id = item.FId + "|" + item.SId + "|" + item.PrdId;
				treeViewItemModel.Text = item.KEYName;
				treeViewItemModel.ImageUrl = "";
				List<WSspProductsTree_Result> list3 = Enumerable.ToList<WSspProductsTree_Result>(Enumerable.Where<WSspProductsTree_Result>((IEnumerable<WSspProductsTree_Result>)list2, (Func<WSspProductsTree_Result, bool>)((WSspProductsTree_Result c) => c.ParentId == item.FId)));
				List<TreeViewItemModel> list4 = new List<TreeViewItemModel>();
				foreach (WSspProductsTree_Result itemIn in list3)
				{
					TreeViewItemModel treeViewItemModel2 = new TreeViewItemModel();
					treeViewItemModel2.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", itemIn.FId + "|" + itemIn.SId + "|" + itemIn.PrdId));
					treeViewItemModel2.Id = itemIn.FId + "|" + itemIn.SId + "|" + itemIn.PrdId;
					treeViewItemModel2.Text = itemIn.KEYName;
					treeViewItemModel2.ImageUrl = "";
					int.Parse("100" + itemIn.SId);
					List<WSspProductsTree_Result> list5 = Enumerable.ToList<WSspProductsTree_Result>(Enumerable.Where<WSspProductsTree_Result>((IEnumerable<WSspProductsTree_Result>)list2, (Func<WSspProductsTree_Result, bool>)((WSspProductsTree_Result c) => c.ParentId == itemIn.KeyId && c.FId == 0)));
					List<TreeViewItemModel> list6 = new List<TreeViewItemModel>();
					foreach (WSspProductsTree_Result item2 in list5)
					{
						TreeViewItemModel treeViewItemModel3 = new TreeViewItemModel();
						treeViewItemModel3.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", item2.FId + "|" + item2.SId + "|" + item2.PrdId));
						treeViewItemModel3.Id = item2.FId + "|" + item2.SId + "|" + item2.PrdId;
						treeViewItemModel3.Text = item2.KEYName;
						treeViewItemModel3.ImageUrl = "";
						treeViewItemModel3.Items = null;
						list6.Add(treeViewItemModel3);
					}
					treeViewItemModel2.Items = new List<TreeViewItemModel>(list6);
					list4.Add(treeViewItemModel2);
				}
				treeViewItemModel.Items = new List<TreeViewItemModel>(list4);
				list.Add(treeViewItemModel);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.PrdGroups = list;
		string text = masterFormName.ToLower();
		string text2 = "frmAddProduct";
		base.ViewBag.ItemFormName = text switch
		{
			"preorder" => "frmPreOrderItemDataEntry", 
			"saleorder" => "frmOrderItemDataEntry", 
			"buyorder" => "frmBuyOrderItemDataEntry", 
			"stocksupply" => "frmStockSupplyItemDataEntry", 
			_ => "frmAddProduct", 
		};
		return View();
	}

	public string CheckDuplicateProduct(string masterForm, int masterId, int prdId, int currentId)
	{
		string text = "0";
		try
		{
			switch (masterForm)
			{
			case "PreOrder":
			case "preOrder":
			{
				IQueryable<int?> val3 = _db.WSfnCheckDuplicatePreOrderProduct(masterId, prdId, currentId);
				return (val3 != null && Queryable.Any<int?>(val3)) ? "1" : "0";
			}
			case "UserPavProduct":
			{
				IQueryable<WSfnCheckDuplicateUserFavPrd_Result> val2 = _db.WSfnCheckDuplicateUserFavPrd(prdId, UserLogin.CurrentUser.UserId, masterId);
				return (val2 != null && Queryable.Any<WSfnCheckDuplicateUserFavPrd_Result>(val2)) ? "-1" : "0";
			}
			case "SaleOrder":
			{
				IQueryable<int?> val4 = _db.WSfnCheckDuplicateOrderProduct(masterId, prdId, currentId);
				return (val4 != null && Queryable.Any<int?>(val4)) ? "1" : "0";
			}
			case "BuyOrder":
			{
				IQueryable<int?> val = _db.WSfnCheckDuplicateBuyOrderProduct(masterId, prdId, currentId);
				return (val != null && Queryable.Any<int?>(val)) ? "1" : "0";
			}
			default:
				return "0";
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return "-1";
		}
	}

	[HttpPost]
	public JsonResult SelectProduct(string barcode = "", string text = "", int showMode = 2, int prdKind = 0, int companyId = 0, int projectId = 0, string masterFormName = "", int currentMasterId = 0)
	{
		List<WSspSearchProducts_Result> list = new List<WSspSearchProducts_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
			_ = UserLogin.CurrentUser.UserId;
			short.Parse(Financial.Get().Id.ToString());
			short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			if (!string.IsNullOrWhiteSpace(text))
			{
				list = Enumerable.ToList<WSspSearchProducts_Result>(Enumerable.Take<WSspSearchProducts_Result>((IEnumerable<WSspSearchProducts_Result>)_db.WSspSearchProducts(0, 0, text, text, 0, showMode, lCID, result, prdKind, 0, companyId, projectId, "", null), 800));
				CRMspSelectFoSetting_Result foSetting = CRMIdeal.Classes.Helper.Setting.GetFoSetting();
				bool result2 = false;
				if (foSetting != null)
				{
					bool.TryParse(foSetting.ShpPrdDeliveryScheduleActive.ToString(), out result2);
				}
				foreach (WSspSearchProducts_Result item in list)
				{
					if (item.PrdValidity.GetValueOrDefault())
					{
						switch (masterFormName)
						{
						case "SaleOrder":
						case "preOrder":
						case "PreOrder":
						{
							WSspReturnProductValidity_Result wSspReturnProductValidity_Result = Enumerable.FirstOrDefault<WSspReturnProductValidity_Result>((IEnumerable<WSspReturnProductValidity_Result>)_dbI.WSspReturnProductValidity(item.PrdId));
							if (wSspReturnProductValidity_Result == null)
							{
								break;
							}
							bool flag = false;
							int result3 = 0;
							int result4 = 0;
							int result5 = 0;
							if (wSspReturnProductValidity_Result.PrdValidityDay.HasValue)
							{
								int.TryParse(wSspReturnProductValidity_Result.PrdValidityDay.ToString(), out result3);
								flag = true;
							}
							if (!string.IsNullOrWhiteSpace(wSspReturnProductValidity_Result.PrdValidityTime))
							{
								string[] array = wSspReturnProductValidity_Result.PrdValidityTime.Split(new char[1] { ':' });
								if (array != null && Enumerable.Any<string>((IEnumerable<string>)array) && array.Length == 2)
								{
									int.TryParse(array[0] ?? "0", out result4);
									int.TryParse(array[1] ?? "0", out result5);
								}
								flag = true;
							}
							if (flag && currentMasterId > 0 && masterFormName == "SaleOrder")
							{
								WSspSelectOrderById_Result wSspSelectOrderById_Result = Enumerable.FirstOrDefault<WSspSelectOrderById_Result>((IEnumerable<WSspSelectOrderById_Result>)_db.WSspSelectOrderById(currentMasterId, lCID, result));
								if (wSspSelectOrderById_Result != null && wSspSelectOrderById_Result.ordDateTime.HasValue)
								{
									DateTime dateTime = default(DateTime);
									dateTime = wSspSelectOrderById_Result.ordDateTime.Value.AddDays(result3).AddHours(result4).AddMinutes(result5);
									item.PrdValidityExpireDate = dateTime.ToString("yyyy/MM/dd");
									item.PrdValidityExpireTime = dateTime.ToString("HH:mm");
								}
							}
							else if (flag && currentMasterId > 0 && (masterFormName == "preOrder" || masterFormName == "PreOrder"))
							{
								WSspSelectPreOrderWithId_Result wSspSelectPreOrderWithId_Result = Enumerable.FirstOrDefault<WSspSelectPreOrderWithId_Result>((IEnumerable<WSspSelectPreOrderWithId_Result>)_db.WSspSelectPreOrderWithId(currentMasterId, lCID, result));
								if (wSspSelectPreOrderWithId_Result != null && wSspSelectPreOrderWithId_Result.pordDateTime.HasValue)
								{
									DateTime dateTime2 = default(DateTime);
									dateTime2 = wSspSelectPreOrderWithId_Result.pordDateTime.Value.AddDays(result3).AddHours(result4).AddMinutes(result5);
									item.PrdValidityExpireDate = dateTime2.ToString("yyyy/MM/dd");
									item.PrdValidityExpireTime = dateTime2.ToString("HH:mm");
								}
							}
							break;
						}
						}
					}
					switch (masterFormName)
					{
					case "SaleOrder":
					case "preOrder":
					case "PreOrder":
						if (result2)
						{
							item.DeliveryScheduleTotalCount = DeliverySchedule.GetPrdDeliveryScheduleTotalCount(item.PrdId);
						}
						else
						{
							item.DeliveryScheduleTotalCount = 0;
						}
						break;
					}
					item.PrdLinkAccPrdCode = CRMIdeal.Classes.Helper.OtherSystems.GetLinkAccCodeWithComa(2, item.PrdLinkAccPrdCode);
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.ProductsList = list;
		JsonResult jsonResult = Json(list, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public JsonResult SelectWarehouse()
	{
		List<WSspSelectActiveWareHouse_Result> list = new List<WSspSelectActiveWareHouse_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
			_ = UserLogin.CurrentUser.UserId;
			short.Parse(Financial.Get().Id.ToString());
			short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			list = CRMIdeal.Classes.Helper.Warehouse.SelectActiveWareHouse();
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.WarehousesList = list;
		JsonResult jsonResult = Json(list, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public JsonResult SelectLinkAccSettingDB()
	{
		List<CRMspSelectLinkAccSettingDB_Result> list = new List<CRMspSelectLinkAccSettingDB_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
			_ = UserLogin.CurrentUser.UserId;
			short.Parse(Financial.Get().Id.ToString());
			short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			int value = 0;
			CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
			if (cRMspSelectCrmsysSetting_Result != null)
			{
				value = cRMspSelectCrmsysSetting_Result.LinkAccSystemId.GetValueOrDefault();
			}
			list = Enumerable.ToList<CRMspSelectLinkAccSettingDB_Result>((IEnumerable<CRMspSelectLinkAccSettingDB_Result>)_dbLink.CRMspSelectLinkAccSettingDB(value, 0, lCID, result));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.LinkAccSettingDBList = list;
		JsonResult jsonResult = Json(list, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public JsonResult GetOrderTracing(int whId, int prdId, string masterFormName, int currentItemId = 0)
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			int result2 = 0;
			if (currentUser != null)
			{
				int.TryParse(currentUser.UserLastCId.ToString(), out result2);
			}
			if (whId != 0 && prdId != 0)
			{
				if ((masterFormName ?? "").ToLower() == "preorder" && UserLogin.IsUserAccess("frmPreOrder", "actCanNotVerifyNoStockFromShop", currentUser))
				{
					List<WSspReturnProductTracingFromShop_Result> list2 = Enumerable.ToList<WSspReturnProductTracingFromShop_Result>((IEnumerable<WSspReturnProductTracingFromShop_Result>)_dbII.WSspReturnProductTracingFromShop(whId, prdId, 0, currentItemId, 0, 0, result2, lCID, result));
					if (list2 != null)
					{
						int num = 0;
						foreach (WSspReturnProductTracingFromShop_Result item in list2)
						{
							list.Add(new SelectListItem
							{
								Text = item.Tracing,
								Value = num++.ToString()
							});
						}
					}
				}
				else
				{
					List<WSspReturnProductTracing_Result> list3 = Enumerable.ToList<WSspReturnProductTracing_Result>((IEnumerable<WSspReturnProductTracing_Result>)_db.WSspReturnProductTracing(whId, prdId, result2));
					if (list3 != null)
					{
						int num2 = 0;
						foreach (WSspReturnProductTracing_Result item2 in list3)
						{
							list.Add(new SelectListItem
							{
								Text = item2.Tracing,
								Value = num2++.ToString()
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
		JsonResult jsonResult = Json(list, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public ReturnPrdQuantityViewModel SelectReturnPrdQuantity(int prdId = 0, int currId = 0, int whId = 0, double fcr = 0.0, double fcrI = 0.0, string tracing = "", int cmpId = 0, int prdPriceGroupId = 0, string crmOrdType = "ord", string linkAccWhId = "", string masterFormName = "", int linkAccSettingDBId = 0)
	{
		ReturnPrdQuantityViewModel returnPrdQuantityViewModel = new ReturnPrdQuantityViewModel();
		returnPrdQuantityViewModel.PrdQuantity = new WSspReturnPrdQuantity_Result();
		returnPrdQuantityViewModel.ValidpordQuantity = 0.0;
		returnPrdQuantityViewModel.QtyRemain = 0.0;
		returnPrdQuantityViewModel.ValidpordQuantityTotal = "0/0";
		returnPrdQuantityViewModel.SoldOrdPrdQuantity = 0.0;
		returnPrdQuantityViewModel.RemainSoldOrdPrdQuantity = 0.0;
		returnPrdQuantityViewModel.SoldOrdPrdQuantityTotal = "0/0";
		try
		{
			int result = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result);
			}
			tracing = ConvertCharacter.DecodeTracing(tracing);
			int value = 0;
			string text = masterFormName.ToLower();
			string text2 = "frmAddProduct";
			switch (text)
			{
			case "preorder":
				text2 = "frmPreOrderItemDataEntry";
				value = currId;
				break;
			case "saleorder":
				text2 = "frmOrderItemDataEntry";
				break;
			case "buyorder":
				text2 = "frmBuyOrderItemDataEntry";
				break;
			case "stocksupply":
				text2 = "frmStockSupplyItemDataEntry";
				break;
			default:
				text2 = "frmAddProduct";
				break;
			}
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int id = Financial.Get().Id;
			returnPrdQuantityViewModel.PrdQuantity = Enumerable.FirstOrDefault<WSspReturnPrdQuantity_Result>((IEnumerable<WSspReturnPrdQuantity_Result>)_db.WSspReturnPrdQuantity(prdId, id, whId, 0, lCID, result2, fcr, fcrI, (!string.IsNullOrWhiteSpace(tracing)) ? tracing.Trim() : "", result));
			if (returnPrdQuantityViewModel.PrdQuantity == null)
			{
				returnPrdQuantityViewModel.PrdQuantity = new WSspReturnPrdQuantity_Result();
			}
			WSspReturnValidPordPrdCount_Result wSspReturnValidPordPrdCount_Result = Enumerable.FirstOrDefault<WSspReturnValidPordPrdCount_Result>((IEnumerable<WSspReturnValidPordPrdCount_Result>)_db.WSspReturnValidPordPrdCount(prdId, value, DateTime.Now, fcr, fcrI, whId, (!string.IsNullOrWhiteSpace(tracing)) ? tracing.Trim() : ""));
			if (wSspReturnValidPordPrdCount_Result != null)
			{
				returnPrdQuantityViewModel.ValidpordQuantity = wSspReturnValidPordPrdCount_Result.ValidpordQuantity.GetValueOrDefault();
				returnPrdQuantityViewModel.ValidpordQuantityTotal = wSspReturnValidPordPrdCount_Result.ValidpordQuantity.GetValueOrDefault() + "/" + wSspReturnValidPordPrdCount_Result.ValidpordQuantityTotal.GetValueOrDefault();
			}
			if (returnPrdQuantityViewModel.PrdQuantity != null)
			{
				double valueOrDefault = returnPrdQuantityViewModel.PrdQuantity.TracingRemainCount.GetValueOrDefault();
				returnPrdQuantityViewModel.QtyRemain = valueOrDefault - returnPrdQuantityViewModel.ValidpordQuantity;
				if (!UserLogin.IsUserAccess(text2, "actShowPrdQuantityRemainCurrAndAll", UserLogin.CurrentUser))
				{
					string text3 = returnPrdQuantityViewModel.PrdQuantity.QuantityRemain.GetValueOrDefault().ToString();
					returnPrdQuantityViewModel.PrdQuantity.RemainCurrAndAll = text3 + "/" + text3;
				}
			}
			CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
			bool flag = false;
			int num = 0;
			if (cRMspSelectCrmsysSetting_Result != null)
			{
				flag = ((cRMspSelectCrmsysSetting_Result.InvStockFromLink.HasValue && cRMspSelectCrmsysSetting_Result.InvStockFromLink.GetValueOrDefault()) ? true : false);
				num = cRMspSelectCrmsysSetting_Result.LinkAccSystemId.GetValueOrDefault();
			}
			if (flag && num > 0 && returnPrdQuantityViewModel.PrdQuantity != null)
			{
				ProductController productController = new ProductController();
				string text4 = "";
				switch (num)
				{
				case 3:
				{
					decimal prdPrice = default(decimal);
					double prdQuantity = 0.0;
					productController.TarazGetPrdQuantityAndPrice(prdId, cmpId, whId, prdPriceGroupId, ref prdPrice, ref prdQuantity, crmOrdType, 0);
					text4 = prdQuantity.ToString();
					break;
				}
				case 4:
					text4 = productController.HolooGetPrdQuantity(prdId, linkAccSettingDBId);
					break;
				case 6:
					text4 = productController.KyanGetPrdQuantity(prdId, whId);
					break;
				case 7:
					text4 = productController.PayvastGetPrdQuantity(prdId, whId);
					break;
				case 11:
					text4 = productController.ShomaranGetPrdQuantity(prdId, whId, linkAccWhId, tracing);
					break;
				case 12:
					text4 = productController.LinkAccGetPrdQuantity(num, prdId, whId, linkAccWhId, tracing);
					break;
				default:
					text4 = productController.LinkAccGetPrdQuantity(num, prdId, whId, linkAccWhId, tracing, "", prdPriceGroupId);
					break;
				}
				double result3 = 0.0;
				if (!string.IsNullOrEmpty(text4) && text4 != Labels.frmError)
				{
					double.TryParse(text4, out result3);
				}
				returnPrdQuantityViewModel.PrdQuantity.TracingRemainCount = result3;
				returnPrdQuantityViewModel.QtyRemain = result3 - returnPrdQuantityViewModel.ValidpordQuantity;
			}
			double result4 = 0.0;
			double result5 = 0.0;
			int value2 = 0;
			WSspReturnSoldOrdPrdCount_Result wSspReturnSoldOrdPrdCount_Result = Enumerable.FirstOrDefault<WSspReturnSoldOrdPrdCount_Result>((IEnumerable<WSspReturnSoldOrdPrdCount_Result>)_dbIII.WSspReturnSoldOrdPrdCount(prdId, value2, fcr, fcrI, whId, tracing, result));
			if (wSspReturnSoldOrdPrdCount_Result != null)
			{
				double.TryParse(wSspReturnSoldOrdPrdCount_Result.RemainOrdQty.ToString(), out result4);
				double.TryParse(wSspReturnSoldOrdPrdCount_Result.RemainOrdQtyTotal.ToString(), out result5);
			}
			returnPrdQuantityViewModel.SoldOrdPrdQuantity = result4;
			returnPrdQuantityViewModel.SoldOrdPrdQuantityTotal = result4 + "/" + result5;
			double result6 = 0.0;
			if (returnPrdQuantityViewModel.PrdQuantity != null)
			{
				double.TryParse(returnPrdQuantityViewModel.PrdQuantity.TracingRemainCount.ToString(), out result6);
			}
			returnPrdQuantityViewModel.RemainSoldOrdPrdQuantity = result6 - result4;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return returnPrdQuantityViewModel;
	}

	[HttpPost]
	public JsonResult ReturnPrdQuantity(int prdId = 0, int currId = 0, int whId = 0, double fcr = 0.0, double fcrI = 0.0, string tracing = "", int cmpId = 0, int prdPriceGroupId = 0, string crmOrdType = "ord", string linkAccWhId = "", string masterFormName = "", int linkAccSettingDBId = 0)
	{
		tracing = ConvertCharacter.DecodeTracing(tracing);
		ReturnPrdQuantityViewModel data = SelectReturnPrdQuantity(prdId, 0, whId, fcr, fcrI, (!string.IsNullOrWhiteSpace(tracing)) ? tracing.Trim() : "", cmpId, prdPriceGroupId, crmOrdType, linkAccWhId, masterFormName, linkAccSettingDBId);
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	public List<WSspSelectProductPriceGroup_Result> SelectProductPriceGroup()
	{
		List<WSspSelectProductPriceGroup_Result> list = new List<WSspSelectProductPriceGroup_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			list = Enumerable.ToList<WSspSelectProductPriceGroup_Result>((IEnumerable<WSspSelectProductPriceGroup_Result>)_db.WSspSelectProductPriceGroup(lCID, result));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.ProductPriceGroup = list;
		return list;
	}

	public JsonResult SelectProductPriceGroupJs()
	{
		JsonResult jsonResult = Json(SelectProductPriceGroup(), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult ReturnProductCost(int prdId, int prdCostGroupId, int currUnitId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int? centerId = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserLastCId : null);
		WSspReturnProductCost_Result data = new WSspReturnProductCost_Result();
		try
		{
			data = Enumerable.FirstOrDefault<WSspReturnProductCost_Result>((IEnumerable<WSspReturnProductCost_Result>)_db.WSspReturnProductCost(prdId, prdCostGroupId, lCID, result, currUnitId, centerId)) ?? new WSspReturnProductCost_Result
			{
				Cost = 0m,
				CurrencyCost = default(decimal),
				CurrencyUnit = "",
				CurrencyUnitId = 0
			};
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	public WSspReturnProductPriceViewModel SelectReturnProductPrice(int prdId, int prdPriceGroupId, int currUnitId = 0, int cmpId = 0, int whId = 0, string crmOrdType = "ord", string linkedPrdIds = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int? centerId = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserLastCId : null);
		WSspReturnProductPriceViewModel wSspReturnProductPriceViewModel = new WSspReturnProductPriceViewModel();
		try
		{
			WSspReturnProductPrice_Result wSspReturnProductPrice_Result = Enumerable.FirstOrDefault<WSspReturnProductPrice_Result>((IEnumerable<WSspReturnProductPrice_Result>)_db.WSspReturnProductPrice(prdId, prdPriceGroupId, lCID, result, currUnitId, centerId)) ?? new WSspReturnProductPrice_Result
			{
				Price = 0m,
				CurrencyPrice = default(decimal),
				CurrencyUnit = "",
				CooperationPrice = default(decimal),
				CurrencyUnitId = 0,
				Discount = default(decimal),
				DiscountPrecent = default(decimal),
				DocNumber = null
			};
			if (wSspReturnProductPrice_Result != null)
			{
				wSspReturnProductPriceViewModel = new WSspReturnProductPriceViewModel
				{
					PrdId = wSspReturnProductPrice_Result.PrdId,
					DocDate = wSspReturnProductPrice_Result.DocDate,
					DocDateTime = wSspReturnProductPrice_Result.DocDateTime,
					DocNumber = wSspReturnProductPrice_Result.DocNumber,
					Price = wSspReturnProductPrice_Result.Price,
					CurrencyPrice = wSspReturnProductPrice_Result.CurrencyPrice,
					CurrencyUnitId = wSspReturnProductPrice_Result.CurrencyUnitId,
					CurrencyUnit = wSspReturnProductPrice_Result.CurrencyUnit,
					CurrencyUnitEn = wSspReturnProductPrice_Result.CurrencyUnitEn,
					CooperationPrice = wSspReturnProductPrice_Result.CooperationPrice,
					PricePercent = wSspReturnProductPrice_Result.PricePercent,
					DiscountPrecent = wSspReturnProductPrice_Result.DiscountPrecent,
					Discount = wSspReturnProductPrice_Result.Discount,
					OtherPrice = wSspReturnProductPrice_Result.OtherPrice,
					CurrencyRate = wSspReturnProductPrice_Result.CurrencyRate,
					IsDecimal = wSspReturnProductPrice_Result.IsDecimal,
					TaxIndex = wSspReturnProductPrice_Result.TaxIndex
				};
				wSspReturnProductPriceViewModel.SumLinkedProductPrice = Enumerable.FirstOrDefault<decimal?>((IEnumerable<decimal?>)_db.WSspReturnSumLinkedProductPrice(prdId, prdPriceGroupId, currUnitId, linkedPrdIds, centerId)) ?? new decimal?(default(decimal));
			}
			CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
			bool flag = false;
			int num = 0;
			if (cRMspSelectCrmsysSetting_Result != null)
			{
				flag = ((cRMspSelectCrmsysSetting_Result.PrdPriceFromLink.HasValue && cRMspSelectCrmsysSetting_Result.PrdPriceFromLink.GetValueOrDefault()) ? true : false);
				num = cRMspSelectCrmsysSetting_Result.LinkAccSystemId.GetValueOrDefault();
			}
			if (flag && num > 0 && wSspReturnProductPriceViewModel != null)
			{
				ProductController productController = new ProductController();
				string text = "";
				if (num == 3)
				{
					decimal prdPrice = default(decimal);
					double prdQuantity = 0.0;
					productController.TarazGetPrdQuantityAndPrice(prdId, cmpId, whId, prdPriceGroupId, ref prdPrice, ref prdQuantity, crmOrdType, 0);
					text = prdPrice.ToString();
				}
				decimal result2 = default(decimal);
				if (!string.IsNullOrEmpty(text))
				{
					decimal.TryParse(text, out result2);
					wSspReturnProductPriceViewModel.DocNumber = result2.ToString();
				}
				else
				{
					wSspReturnProductPriceViewModel.DocNumber = "0";
				}
			}
			else
			{
				wSspReturnProductPriceViewModel.DocNumber = null;
			}
			double result3 = -1.0;
			bool result4 = false;
			if (cRMspSelectCrmsysSetting_Result != null)
			{
				bool.TryParse(cRMspSelectCrmsysSetting_Result.FullDiscountPerWithRateInAdd.ToString(), out result4);
			}
			if (result4)
			{
				WSspReturnCmpGroupIIRateFromPrdGroup_Result wSspReturnCmpGroupIIRateFromPrdGroup_Result = Enumerable.FirstOrDefault<WSspReturnCmpGroupIIRateFromPrdGroup_Result>((IEnumerable<WSspReturnCmpGroupIIRateFromPrdGroup_Result>)_dbI.WSspReturnCmpGroupIIRateFromPrdGroup(cmpId, prdId));
				if (wSspReturnCmpGroupIIRateFromPrdGroup_Result != null)
				{
					if (wSspReturnCmpGroupIIRateFromPrdGroup_Result.Rate.HasValue || wSspReturnCmpGroupIIRateFromPrdGroup_Result.CmpGroupIIRate.HasValue)
					{
						double result5 = 0.0;
						double result6 = 0.0;
						double.TryParse(wSspReturnCmpGroupIIRateFromPrdGroup_Result.Rate.ToString(), out result5);
						double.TryParse(wSspReturnCmpGroupIIRateFromPrdGroup_Result.CmpGroupIIRate.ToString(), out result6);
						result3 = result5;
						if (result3 == 0.0 && !wSspReturnCmpGroupIIRateFromPrdGroup_Result.Rate.HasValue)
						{
							result3 = result6;
						}
					}
				}
				else
				{
					double? num2 = Enumerable.FirstOrDefault<double?>((IEnumerable<double?>)_db.WSspReturnPricePartRateFromCmpGroupII(cmpId));
					if (num2.HasValue)
					{
						double.TryParse(num2.ToString(), out result3);
					}
				}
			}
			wSspReturnProductPriceViewModel.CmpGroupIIRate = result3;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return wSspReturnProductPriceViewModel;
	}

	[AjaxOnly]
	public JsonResult ReturnProductPriceJs(int prdId, int prdPriceGroupId, int currUnitId = 0, int cmpId = 0, int whId = 0, string crmOrdType = "ord", string linkedPrdIds = "")
	{
		WSspReturnProductPriceViewModel data = SelectReturnProductPrice(prdId, prdPriceGroupId, currUnitId, cmpId, whId, crmOrdType, linkedPrdIds);
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	public decimal SelectReturnProductUserDiscount(int prdGroupId, int prdId)
	{
		decimal result = default(decimal);
		try
		{
			decimal? num = Enumerable.FirstOrDefault<decimal?>((IEnumerable<decimal?>)_db.WSspReturnProductUserDiscountValue(prdGroupId, prdId, UserLogin.CurrentUser.UserId));
			if (num.HasValue)
			{
				result = num.Value;
				return result;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[AjaxOnly]
	public JsonResult ReturnProductUserDiscount(int prdGroupId, int prdId)
	{
		return Json(SelectReturnProductUserDiscount(prdGroupId, prdId), JsonRequestBehavior.AllowGet);
	}

	public JsonResult GetDeliveryTerms()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspSelectDeliveryTerms_Result> list = new List<WSspSelectDeliveryTerms_Result>();
		try
		{
			list = Enumerable.ToList<WSspSelectDeliveryTerms_Result>((IEnumerable<WSspSelectDeliveryTerms_Result>)_db.WSspSelectDeliveryTerms(lCID, result));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.DeliveryTermsList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public List<WSspSelectWareHouseWithAccLinkField_Result> GetLinkAccWhList(bool fillAuto = true, bool withWrhsLinkAccWhCode = true, bool withWrhsLinkAccWhId = true, bool withWrhsLinkAccWhIdStr = true, bool withWrhsLinkAccWareHouses = false, bool removeDups = true)
	{
		List<WSspSelectWareHouseWithAccLinkField_Result> list = new List<WSspSelectWareHouseWithAccLinkField_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (VersionBuyer.LinkAcc)
			{
				CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
				if (fillAuto && cRMspSelectCrmsysSetting_Result != null)
				{
					int result2 = 0;
					int.TryParse(cRMspSelectCrmsysSetting_Result.LinkAccSystemId.ToString(), out result2);
					switch (result2)
					{
					case 8:
						withWrhsLinkAccWhCode = true;
						withWrhsLinkAccWhId = true;
						withWrhsLinkAccWhIdStr = false;
						break;
					case 9:
						withWrhsLinkAccWhCode = true;
						withWrhsLinkAccWhId = true;
						withWrhsLinkAccWhIdStr = false;
						break;
					case 11:
						withWrhsLinkAccWhCode = false;
						withWrhsLinkAccWhId = false;
						withWrhsLinkAccWhIdStr = false;
						withWrhsLinkAccWareHouses = true;
						break;
					case 12:
						withWrhsLinkAccWhCode = false;
						withWrhsLinkAccWhId = false;
						withWrhsLinkAccWhIdStr = false;
						withWrhsLinkAccWareHouses = true;
						break;
					case 17:
						withWrhsLinkAccWhCode = false;
						withWrhsLinkAccWhId = false;
						withWrhsLinkAccWhIdStr = false;
						withWrhsLinkAccWareHouses = true;
						break;
					case 18:
						withWrhsLinkAccWhCode = false;
						withWrhsLinkAccWhId = false;
						withWrhsLinkAccWhIdStr = false;
						withWrhsLinkAccWareHouses = true;
						break;
					case 19:
						withWrhsLinkAccWhCode = false;
						withWrhsLinkAccWhId = false;
						withWrhsLinkAccWhIdStr = false;
						withWrhsLinkAccWareHouses = true;
						break;
					case 20:
						withWrhsLinkAccWhCode = false;
						withWrhsLinkAccWhId = false;
						withWrhsLinkAccWhIdStr = false;
						withWrhsLinkAccWareHouses = true;
						break;
					case 22:
					case 23:
					case 25:
						withWrhsLinkAccWhCode = false;
						withWrhsLinkAccWhId = false;
						withWrhsLinkAccWhIdStr = false;
						withWrhsLinkAccWareHouses = true;
						break;
					default:
						withWrhsLinkAccWhCode = false;
						withWrhsLinkAccWhId = false;
						withWrhsLinkAccWhIdStr = false;
						break;
					case 1:
					case 2:
					case 3:
					case 4:
					case 5:
					case 6:
					case 7:
						break;
					}
				}
				CRMLinkSpEntities dbLink = _dbLink;
				bool? flag = withWrhsLinkAccWhCode;
				List<WSspSelectWareHouseWithAccLinkField_Result> list2 = Enumerable.ToList<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)dbLink.WSspSelectWareHouseWithAccLinkField(withWrhsLinkAccWhId, flag, withWrhsLinkAccWhIdStr, languageID: lCID, defaultLanguageID: result, withWrhsLinkAccWareHouses: withWrhsLinkAccWareHouses));
				if (list2 != null && list2.Count > 0)
				{
					if (removeDups)
					{
						foreach (WSspSelectWareHouseWithAccLinkField_Result i in list2)
						{
							if (Enumerable.FirstOrDefault<WSspSelectWareHouseWithAccLinkField_Result>(Enumerable.Where<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)list, (Func<WSspSelectWareHouseWithAccLinkField_Result, bool>)((WSspSelectWareHouseWithAccLinkField_Result x) => x.WrhsLinkAccWhId == i.WrhsLinkAccWhId && x.WrhsLinkAccWhCode == i.WrhsLinkAccWhCode && x.WrhsLinkAccWhIdStr == i.WrhsLinkAccWhIdStr))) == null)
							{
								list.Add(i);
							}
						}
					}
					else
					{
						list.AddRange(list2);
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.LinkAccWareHouseList = list;
		return list;
	}

	public JsonResult GetLinkAccWareHousesJs(int whId = 0)
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			if (VersionBuyer.LinkAcc)
			{
				CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
				WSspSelectWareHouseWithAccLinkField_Result wSspSelectWareHouseWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)GetLinkAccWhList(fillAuto: true, withWrhsLinkAccWhCode: false, withWrhsLinkAccWhId: false, withWrhsLinkAccWhIdStr: false, withWrhsLinkAccWareHouses: false, removeDups: false), (Func<WSspSelectWareHouseWithAccLinkField_Result, bool>)((WSspSelectWareHouseWithAccLinkField_Result x) => x.WareHouseID == whId));
				if (wSspSelectWareHouseWithAccLinkField_Result != null && cRMspSelectCrmsysSetting_Result != null)
				{
					int result = 0;
					int.TryParse(cRMspSelectCrmsysSetting_Result.LinkAccSystemId.ToString(), out result);
					string text = "";
					string value = "";
					text = wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWhName;
					switch (result)
					{
					case 8:
					{
						text = "";
						value = "";
						if (string.IsNullOrWhiteSpace(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses))
						{
							break;
						}
						List<CommonWithIdStrViewModel> list8 = JsonConvert.DeserializeObject<List<CommonWithIdStrViewModel>>(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses);
						if (list8 == null || list8.Count <= 0)
						{
							break;
						}
						foreach (CommonWithIdStrViewModel item in list8)
						{
							list.Add(new SelectListItem
							{
								Text = item.Name,
								Value = item.Code,
								Selected = false
							});
						}
						break;
					}
					case 9:
					{
						text = "";
						value = "";
						if (string.IsNullOrWhiteSpace(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses))
						{
							break;
						}
						List<CommonWithIdStrViewModel> list9 = JsonConvert.DeserializeObject<List<CommonWithIdStrViewModel>>(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses);
						if (list9 == null || list9.Count <= 0)
						{
							break;
						}
						foreach (CommonWithIdStrViewModel item2 in list9)
						{
							list.Add(new SelectListItem
							{
								Text = item2.Name,
								Value = item2.Code,
								Selected = false
							});
						}
						break;
					}
					case 11:
					{
						text = "";
						value = "";
						if (string.IsNullOrWhiteSpace(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses))
						{
							break;
						}
						List<CommonWithIdStrViewModel> list5 = JsonConvert.DeserializeObject<List<CommonWithIdStrViewModel>>(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses);
						if (list5 == null || list5.Count <= 0)
						{
							break;
						}
						foreach (CommonWithIdStrViewModel item3 in list5)
						{
							list.Add(new SelectListItem
							{
								Text = item3.Name,
								Value = item3.Code,
								Selected = false
							});
						}
						break;
					}
					case 12:
					{
						text = "";
						value = "";
						if (string.IsNullOrWhiteSpace(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses))
						{
							break;
						}
						List<CommonWithIdStrViewModel> list3 = JsonConvert.DeserializeObject<List<CommonWithIdStrViewModel>>(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses);
						if (list3 == null || list3.Count <= 0)
						{
							break;
						}
						foreach (CommonWithIdStrViewModel item4 in list3)
						{
							list.Add(new SelectListItem
							{
								Text = item4.Name,
								Value = item4.Id,
								Selected = false
							});
						}
						break;
					}
					case 17:
					{
						text = "";
						value = "";
						if (string.IsNullOrWhiteSpace(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses))
						{
							break;
						}
						List<CommonWithIdStrViewModel> list4 = JsonConvert.DeserializeObject<List<CommonWithIdStrViewModel>>(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses);
						if (list4 == null || list4.Count <= 0)
						{
							break;
						}
						foreach (CommonWithIdStrViewModel item5 in list4)
						{
							list.Add(new SelectListItem
							{
								Text = item5.Name,
								Value = item5.Id,
								Selected = false
							});
						}
						break;
					}
					case 18:
					{
						text = "";
						value = "";
						if (string.IsNullOrWhiteSpace(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses))
						{
							break;
						}
						List<CommonWithIdStrViewModel> list7 = JsonConvert.DeserializeObject<List<CommonWithIdStrViewModel>>(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses);
						if (list7 == null || list7.Count <= 0)
						{
							break;
						}
						foreach (CommonWithIdStrViewModel item6 in list7)
						{
							list.Add(new SelectListItem
							{
								Text = item6.Name,
								Value = item6.Id,
								Selected = false
							});
						}
						break;
					}
					case 19:
					{
						text = "";
						value = "";
						if (string.IsNullOrWhiteSpace(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses))
						{
							break;
						}
						List<CommonWithIdStrViewModel> list10 = JsonConvert.DeserializeObject<List<CommonWithIdStrViewModel>>(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses);
						if (list10 == null || list10.Count <= 0)
						{
							break;
						}
						foreach (CommonWithIdStrViewModel item7 in list10)
						{
							list.Add(new SelectListItem
							{
								Text = item7.Name,
								Value = item7.Id,
								Selected = false
							});
						}
						break;
					}
					case 20:
					{
						text = "";
						value = "";
						if (string.IsNullOrWhiteSpace(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses))
						{
							break;
						}
						List<CommonWithIdStrViewModel> list6 = JsonConvert.DeserializeObject<List<CommonWithIdStrViewModel>>(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses);
						if (list6 == null || list6.Count <= 0)
						{
							break;
						}
						foreach (CommonWithIdStrViewModel item8 in list6)
						{
							list.Add(new SelectListItem
							{
								Text = item8.Name,
								Value = item8.Id,
								Selected = false
							});
						}
						break;
					}
					case 22:
					case 23:
					case 25:
					{
						text = "";
						value = "";
						if (string.IsNullOrWhiteSpace(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses))
						{
							break;
						}
						List<CommonWithIdStrViewModel> list2 = JsonConvert.DeserializeObject<List<CommonWithIdStrViewModel>>(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses);
						if (list2 == null || list2.Count <= 0)
						{
							break;
						}
						foreach (CommonWithIdStrViewModel item9 in list2)
						{
							list.Add(new SelectListItem
							{
								Text = item9.Name,
								Value = item9.Id,
								Selected = false
							});
						}
						break;
					}
					default:
						text = "";
						value = "";
						break;
					case 1:
					case 2:
					case 3:
					case 4:
					case 5:
					case 6:
					case 7:
						break;
					}
					if (!string.IsNullOrWhiteSpace(text) && !string.IsNullOrWhiteSpace(value))
					{
						list.Add(new SelectListItem
						{
							Text = text,
							Value = value,
							Selected = false
						});
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.LinkAccWareHouseSelectList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public List<WSspSelectProductUnits_Result> SelectProductUnits()
	{
		List<WSspSelectProductUnits_Result> list = new List<WSspSelectProductUnits_Result>();
		string text = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<WSspSelectProductUnits_Result> list2 = Enumerable.ToList<WSspSelectProductUnits_Result>((IEnumerable<WSspSelectProductUnits_Result>)_db.WSspSelectProductUnits(lCID, result));
			if (list2 != null)
			{
				list = list2;
			}
			if (list2 != null && Enumerable.Any<WSspSelectProductUnits_Result>((IEnumerable<WSspSelectProductUnits_Result>)list2))
			{
				List<WSProductUnitsFormulaListViewModel> list3 = new List<WSProductUnitsFormulaListViewModel>();
				list3.AddRange(Enumerable.Select<WSspSelectProductUnits_Result, WSProductUnitsFormulaListViewModel>((IEnumerable<WSspSelectProductUnits_Result>)list2, (Func<WSspSelectProductUnits_Result, WSProductUnitsFormulaListViewModel>)((WSspSelectProductUnits_Result item) => new WSProductUnitsFormulaListViewModel
				{
					ProductUnitID = item.ProductUnitID,
					UnitIFormula = item.UnitIFormula,
					UnitIIFormula = item.UnitIIFormula
				})));
				text = "";
				if (list3 != null && Enumerable.Any<WSProductUnitsFormulaListViewModel>((IEnumerable<WSProductUnitsFormulaListViewModel>)list3))
				{
					text = JsonConvert.SerializeObject(Enumerable.ToList<WSProductUnitsFormulaListViewModel>((IEnumerable<WSProductUnitsFormulaListViewModel>)list3));
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.PrdUnitList = list;
		base.ViewBag.PrdUnitFormulaListJson = text;
		return list;
	}

	public List<SelectListItem> SelectProductUnitsOld()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<WSspSelectProductUnits_Result> list2 = Enumerable.ToList<WSspSelectProductUnits_Result>((IEnumerable<WSspSelectProductUnits_Result>)_db.WSspSelectProductUnits(lCID, result));
			list.AddRange(Enumerable.Select<WSspSelectProductUnits_Result, SelectListItem>((IEnumerable<WSspSelectProductUnits_Result>)list2, (Func<WSspSelectProductUnits_Result, SelectListItem>)((WSspSelectProductUnits_Result item) => new SelectListItem
			{
				Text = item.Unit,
				Value = item.ProductUnitID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.PrdUnitList = list;
		return list;
	}

	public List<SelectListItem> SelectProductColor()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<WSspSelectProductColor_Result> list2 = Enumerable.ToList<WSspSelectProductColor_Result>((IEnumerable<WSspSelectProductColor_Result>)_db.WSspSelectProductColor(lCID, result));
			list.AddRange(Enumerable.Select<WSspSelectProductColor_Result, SelectListItem>((IEnumerable<WSspSelectProductColor_Result>)list2, (Func<WSspSelectProductColor_Result, SelectListItem>)((WSspSelectProductColor_Result item) => new SelectListItem
			{
				Text = item.Color,
				Value = item.ProductColorID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.PrdColorList = list;
		return list;
	}

	public List<WSspSelectLinkedProductsWithPrice_Result> SelectLinkedProducts(int prdId = 0, int productPriceGroupId = 0, int destCurrencyUnitId = 0, string selectedIds = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspSelectLinkedProductsWithPrice_Result> list = new List<WSspSelectLinkedProductsWithPrice_Result>();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			list = Enumerable.ToList<WSspSelectLinkedProductsWithPrice_Result>((IEnumerable<WSspSelectLinkedProductsWithPrice_Result>)_dbI.WSspSelectLinkedProductsWithPrice(prdId, productPriceGroupId, destCurrencyUnitId, lCID, result, result2));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.LinkedProducts = list;
		base.ViewBag.LinkedProductsSelectedIds = selectedIds;
		return list;
	}

	public JsonResult SelectLinkedProductsJs(int prdId = 0, int productPriceGroupId = 0, int destCurrencyUnitId = 0, string selectedIds = "")
	{
		return Json(SelectLinkedProducts(prdId, productPriceGroupId, destCurrencyUnitId, selectedIds), JsonRequestBehavior.AllowGet);
	}

	[HttpPost]
	public JsonResult ReturnSelectedLinkedPrdDetailsJs(string masterForm = "", int masterId = 0, int companyId = 0, string crmOrdType = "ord", int prdId = 0, int parentPrdQuan = 1, int prdPriceGroupId = 0, int whId = 0, int destCurrencyUnitId = 0, string selectedIds = "", int prdKind = 0, int orderOprType = 0, string linkAccWhId = "", string masterFormName = "", int linkedItemRowNum = 0)
	{
		List<AddProductViewModel> list = new List<AddProductViewModel>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
			_ = UserLogin.CurrentUser.UserId;
			short.Parse(Financial.Get().Id.ToString());
			short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			_ = Financial.Get().Id;
			bool result2 = false;
			CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
			if (cRMspSelectCrmsysSetting_Result != null)
			{
				bool.TryParse(cRMspSelectCrmsysSetting_Result.FullDiscountPerWithRateInAdd.ToString(), out result2);
			}
			string text = "frmAddProduct";
			string text2 = masterFormName.ToLower();
			string text3 = "frmAddProduct";
			text = text2 switch
			{
				"preorder" => "frmPreOrderItemDataEntry", 
				"saleorder" => "frmOrderItemDataEntry", 
				"buyorder" => "frmBuyOrderItemDataEntry", 
				"stocksupply" => "frmStockSupplyItemDataEntry", 
				_ => "frmAddProduct", 
			};
			if (prdId > 0 && !string.IsNullOrWhiteSpace(selectedIds))
			{
				List<WSspSelectLinkedProductsWithPrice_Result> list2 = SelectLinkedProducts(prdId, prdPriceGroupId, destCurrencyUnitId, selectedIds);
				if (list2 != null)
				{
					string[] array = selectedIds.Split(new char[1] { ',' });
					foreach (string s in array)
					{
						int id = 0;
						int.TryParse(s, out id);
						if (id <= 0)
						{
							continue;
						}
						WSspSelectLinkedProductsWithPrice_Result wSspSelectLinkedProductsWithPrice_Result = Enumerable.FirstOrDefault<WSspSelectLinkedProductsWithPrice_Result>(Enumerable.Where<WSspSelectLinkedProductsWithPrice_Result>((IEnumerable<WSspSelectLinkedProductsWithPrice_Result>)list2, (Func<WSspSelectLinkedProductsWithPrice_Result, bool>)((WSspSelectLinkedProductsWithPrice_Result x) => x.LinkedProductId == id)));
						if (wSspSelectLinkedProductsWithPrice_Result == null)
						{
							continue;
						}
						WSspSelectProductsWithId_Result prd = Enumerable.FirstOrDefault<WSspSelectProductsWithId_Result>((IEnumerable<WSspSelectProductsWithId_Result>)_db.WSspSelectProductsWithId(wSspSelectLinkedProductsWithPrice_Result.ProductIdForLoad, lCID, result));
						if (prd == null)
						{
							continue;
						}
						WSspReturnProductPriceViewModel wSspReturnProductPriceViewModel = SelectReturnProductPrice(prd.ProductID, prdPriceGroupId, destCurrencyUnitId, companyId, whId, crmOrdType, wSspSelectLinkedProductsWithPrice_Result.LinkedProductId.ToString());
						WSspSelectProductUnits_Result wSspSelectProductUnits_Result = Enumerable.FirstOrDefault<WSspSelectProductUnits_Result>((IEnumerable<WSspSelectProductUnits_Result>)_db.WSspSelectProductUnits(lCID, result), (Func<WSspSelectProductUnits_Result, bool>)((WSspSelectProductUnits_Result x) => x.ProductUnitID == prd.PrdUnitId));
						string text4 = CheckDuplicateProduct(masterForm, masterId, prd.ProductID, 0);
						AddProductViewModel addProductViewModel = new AddProductViewModel
						{
							ErrorsList = new List<SelectListItem>()
						};
						if (text4 == "1")
						{
							addProductViewModel.ErrorsList.Add(new SelectListItem
							{
								Text = addProductViewModel.ProductName + ": " + Messages.msgErrorDupIProduct,
								Value = "dup"
							});
						}
						addProductViewModel.PrdUserDiscountPercent = SelectReturnProductUserDiscount(prd.PrdGroupID, prd.ProductID);
						addProductViewModel.MasterForm = masterForm;
						addProductViewModel.MasterId = masterId;
						addProductViewModel.ProductId = prd.ProductID;
						addProductViewModel.ProductName = prd.PrdName;
						addProductViewModel.OprType = orderOprType;
						addProductViewModel.prdKind = prd.PrdKind;
						addProductViewModel.PrdCanChangePrice = prd.PrdCanChangePrice.GetValueOrDefault();
						addProductViewModel.LinkedParentItemRowNum = linkedItemRowNum;
						addProductViewModel.LinkedParentPrdRowNum = prdId;
						addProductViewModel.PrdCode = prd.PrdCode ?? "";
						addProductViewModel.PrdAutoCalcPrice = prd.PrdAutoCalcPrice.GetValueOrDefault();
						addProductViewModel.PrdQtyCanDecimal = prd.PrdQtyCanDecimal.GetValueOrDefault();
						if (wSspSelectLinkedProductsWithPrice_Result.LinkedPrdAddQuantity.GetValueOrDefault())
						{
							double valueOrDefault = wSspSelectLinkedProductsWithPrice_Result.LinkedPrdQuantity.GetValueOrDefault(1.0);
							addProductViewModel.Quantity = valueOrDefault * (double)parentPrdQuan;
						}
						else
						{
							addProductViewModel.Quantity = wSspSelectLinkedProductsWithPrice_Result.LinkedPrdQuantity.GetValueOrDefault(1.0);
						}
						addProductViewModel.QuantityDesc = "";
						double result3 = 0.0;
						double.TryParse(prd.PrdUnitIRate.ToString(), out result3);
						if (result3 != 0.0)
						{
							addProductViewModel.PrdUnitIRateResult = 1.0 / result3 * addProductViewModel.Quantity;
							addProductViewModel.PrdUnitIdI = prd.PrdUnitIdI;
							addProductViewModel.PrdUnitIRateCalcAuto = prd.PrdUnitIRateCalcAuto;
							addProductViewModel.PrdUnitIRate = prd.PrdUnitIRate;
						}
						double result4 = 0.0;
						double.TryParse(prd.PrdUnitIIRate.ToString(), out result4);
						if (result4 != 0.0)
						{
							addProductViewModel.PrdUnitIIRateResult = 1.0 / result4 * addProductViewModel.Quantity;
							addProductViewModel.PrdUnitIdII = prd.PrdUnitIdII;
							addProductViewModel.PrdUnitIIRateCalcAuto = prd.PrdUnitIIRateCalcAuto;
							addProductViewModel.PrdUnitIIRate = prd.PrdUnitIIRate;
						}
						addProductViewModel.PrdWeight = prd.PrdWeight;
						double num = addProductViewModel.PrdWeight.GetValueOrDefault() * addProductViewModel.Quantity;
						if (num != 0.0)
						{
							addProductViewModel.ItemPrdWeight = num;
						}
						ReturnPrdQuantityViewModel returnPrdQuantityViewModel = SelectReturnPrdQuantity(prdId, 0, whId, wSspSelectProductUnits_Result?.FCR.GetValueOrDefault() ?? 0.0, wSspSelectProductUnits_Result?.FCRI.GetValueOrDefault() ?? 0.0, "", companyId, prdPriceGroupId, crmOrdType, linkAccWhId, masterFormName);
						if (crmOrdType == "ord" && UserLogin.IsUserAccess(text, "actCanNotSelectWithNoStockInOrd", UserLogin.CurrentUser))
						{
							if ((returnPrdQuantityViewModel.QtyRemain <= 0.0 || returnPrdQuantityViewModel.QtyRemain < addProductViewModel.Quantity) && prdKind != 2)
							{
								addProductViewModel.ErrorsList.Add(new SelectListItem
								{
									Text = addProductViewModel.ProductName + ": " + Messages.msgAddProductICountIsMoreThanRemain + "(" + returnPrdQuantityViewModel.QtyRemain + "<" + addProductViewModel.Quantity + ")",
									Value = ""
								});
							}
						}
						else if (crmOrdType == "pord" && UserLogin.IsUserAccess(text, "actCanNotSelectWithNoStockInPord", UserLogin.CurrentUser) && (returnPrdQuantityViewModel.QtyRemain <= 0.0 || returnPrdQuantityViewModel.QtyRemain < addProductViewModel.Quantity) && prdKind != 2)
						{
							addProductViewModel.ErrorsList.Add(new SelectListItem
							{
								Text = addProductViewModel.ProductName + ": " + Messages.msgAddProductICountIsMoreThanRemain + "(" + returnPrdQuantityViewModel.QtyRemain + "<" + addProductViewModel.Quantity + ")",
								Value = ""
							});
						}
						if (crmOrdType == "ord" && UserLogin.IsUserAccess(text, "actCanNotSelectWithNoReserveStockInOrd", UserLogin.CurrentUser))
						{
							if ((returnPrdQuantityViewModel.ValidpordQuantity <= 0.0 || returnPrdQuantityViewModel.ValidpordQuantity < addProductViewModel.Quantity) && prdKind != 2)
							{
								addProductViewModel.ErrorsList.Add(new SelectListItem
								{
									Text = addProductViewModel.ProductName + ": " + Messages.ProductLackOfReserveStock + "(" + returnPrdQuantityViewModel.ValidpordQuantity + "<" + addProductViewModel.Quantity + ")",
									Value = ""
								});
							}
						}
						else if (crmOrdType == "pord" && UserLogin.IsUserAccess(text, "actCanNotSelectWithNoReserveStockInPord", UserLogin.CurrentUser) && (returnPrdQuantityViewModel.ValidpordQuantity <= 0.0 || returnPrdQuantityViewModel.ValidpordQuantity < addProductViewModel.Quantity) && prdKind != 2)
						{
							addProductViewModel.ErrorsList.Add(new SelectListItem
							{
								Text = addProductViewModel.ProductName + ": " + Messages.ProductLackOfReserveStock + "(" + returnPrdQuantityViewModel.ValidpordQuantity + "<" + addProductViewModel.Quantity + ")",
								Value = ""
							});
						}
						addProductViewModel.Round = default(decimal);
						addProductViewModel.RoundPlus = default(decimal);
						if (wSspSelectLinkedProductsWithPrice_Result.LinkedPrdAddPrice.GetValueOrDefault())
						{
							addProductViewModel.Price = wSspReturnProductPriceViewModel.Price.GetValueOrDefault();
							addProductViewModel.PriceSum = default(decimal);
							addProductViewModel.TotalPrice = default(decimal);
						}
						else
						{
							addProductViewModel.Price = default(decimal);
							addProductViewModel.PriceSum = default(decimal);
							addProductViewModel.TotalPrice = default(decimal);
						}
						if (wSspSelectLinkedProductsWithPrice_Result.LinkedPrdAddDiscount.GetValueOrDefault())
						{
							addProductViewModel.DiscountPrecent = wSspReturnProductPriceViewModel.DiscountPrecent.GetValueOrDefault();
							addProductViewModel.Discount = wSspReturnProductPriceViewModel.Discount.GetValueOrDefault();
							addProductViewModel.DiscountSum = default(decimal);
							if (result2)
							{
								double result5 = -1.0;
								WSspReturnCmpGroupIIRateFromPrdGroup_Result wSspReturnCmpGroupIIRateFromPrdGroup_Result = Enumerable.FirstOrDefault<WSspReturnCmpGroupIIRateFromPrdGroup_Result>((IEnumerable<WSspReturnCmpGroupIIRateFromPrdGroup_Result>)_dbI.WSspReturnCmpGroupIIRateFromPrdGroup(companyId, prd.ProductID));
								if (wSspReturnCmpGroupIIRateFromPrdGroup_Result != null)
								{
									if (wSspReturnCmpGroupIIRateFromPrdGroup_Result.Rate.HasValue || wSspReturnCmpGroupIIRateFromPrdGroup_Result.CmpGroupIIRate.HasValue)
									{
										double result6 = 0.0;
										double result7 = 0.0;
										double.TryParse(wSspReturnCmpGroupIIRateFromPrdGroup_Result.Rate.ToString(), out result6);
										double.TryParse(wSspReturnCmpGroupIIRateFromPrdGroup_Result.CmpGroupIIRate.ToString(), out result7);
										result5 = result6;
										if (result5 == 0.0 && !wSspReturnCmpGroupIIRateFromPrdGroup_Result.Rate.HasValue)
										{
											result5 = result7;
										}
									}
								}
								else
								{
									double? num2 = Enumerable.FirstOrDefault<double?>((IEnumerable<double?>)_db.WSspReturnPricePartRateFromCmpGroupII(companyId));
									if (num2.HasValue)
									{
										double.TryParse(num2.ToString(), out result5);
									}
								}
								if (result5 != -1.0)
								{
									addProductViewModel.DiscountPrecent = (decimal)result5;
									addProductViewModel.Discount = default(decimal);
									addProductViewModel.DiscountSum = default(decimal);
								}
							}
						}
						else
						{
							addProductViewModel.DiscountPrecent = default(decimal);
							addProductViewModel.Discount = default(decimal);
							addProductViewModel.DiscountSum = default(decimal);
						}
						double num3 = double.Parse(addProductViewModel.Price.ToString());
						double quantity = addProductViewModel.Quantity;
						double num4 = wSspSelectProductUnits_Result?.FCR.GetValueOrDefault() ?? 1.0;
						if (num4 <= 0.0)
						{
							num4 = 1.0;
						}
						double num5 = wSspSelectProductUnits_Result?.FCRI.GetValueOrDefault() ?? 1.0;
						if (num5 <= 0.0)
						{
							num5 = 1.0;
						}
						double num6 = double.Parse(addProductViewModel.Round.ToString());
						double num7 = double.Parse(addProductViewModel.RoundPlus.ToString());
						double num8 = quantity * num4 * num5;
						double num9 = double.Parse(addProductViewModel.Discount.GetValueOrDefault().ToString());
						double num10 = num3 - num9 - num6 + num7;
						double num11 = double.Parse(addProductViewModel.Discount.ToString());
						double num12 = double.Parse(addProductViewModel.DiscountPrecent.ToString());
						double num13 = 0.0;
						num13 = ((!(num12 > 0.0)) ? (num11 * num8) : (num3 * num8 * num12 / 100.0));
						double num14 = num13;
						if (num14 > 0.0)
						{
							addProductViewModel.DiscountSum = decimal.Parse(num14.ToString());
						}
						else
						{
							addProductViewModel.DiscountSum = default(decimal);
						}
						addProductViewModel.PriceSum = decimal.Parse((num3 - num11 - num6 + num7).ToString());
						num14 = num10 * num8;
						if (num14 > 0.0)
						{
							addProductViewModel.TotalPrice = decimal.Parse(num14.ToString());
						}
						else
						{
							addProductViewModel.TotalPrice = default(decimal);
						}
						addProductViewModel.Description = prd.PrdDescription;
						addProductViewModel.FCR = num4;
						addProductViewModel.FCRI = num5;
						addProductViewModel.PrdUnitId = prd.PrdUnitId;
						addProductViewModel.PrdColorId = prd.PrdColorId;
						addProductViewModel.CurrencyUnitId = destCurrencyUnitId;
						addProductViewModel.WHId = whId;
						addProductViewModel.PrdPriceGroupId = prdPriceGroupId;
						addProductViewModel.SelectedNotInSum = wSspSelectLinkedProductsWithPrice_Result.LinkedPrdNotInSum.GetValueOrDefault();
						addProductViewModel.SelectedNotVisible = wSspSelectLinkedProductsWithPrice_Result.LinkedPrdNotVisible.GetValueOrDefault();
						list.Add(addProductViewModel);
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public WSspPrdSalePriceHistory_Result PrdSalePriceHistoryResult(int prdId, int mode)
	{
		WSspPrdSalePriceHistory_Result result = new WSspPrdSalePriceHistory_Result();
		try
		{
			result = Enumerable.FirstOrDefault<WSspPrdSalePriceHistory_Result>((IEnumerable<WSspPrdSalePriceHistory_Result>)_db.WSspPrdSalePriceHistory(prdId, mode)) ?? new WSspPrdSalePriceHistory_Result
			{
				LastPrice = default(decimal),
				LastPriceLastCmp = "",
				LastPriceLastCmpId = 0,
				minPrice = default(decimal),
				minPriceLastCmp = "",
				minPriceLastCmpId = 0,
				maxPrice = default(decimal),
				maxPriceLastCmp = "",
				maxPriceLastCmpId = 0,
				avePrice = default(decimal),
				avePriceLastCmp = "",
				avePriceLastCmpId = 0
			};
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[AjaxOnly]
	public JsonResult PrdSalePriceHistory(int prdId, int mode)
	{
		WSspPrdSalePriceHistory_Result data = new WSspPrdSalePriceHistory_Result();
		try
		{
			data = PrdSalePriceHistoryResult(prdId, mode);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	public List<WSspSelectProductCostGroup_Result> SelectProductCostGroup()
	{
		List<WSspSelectProductCostGroup_Result> list = new List<WSspSelectProductCostGroup_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			list = Enumerable.ToList<WSspSelectProductCostGroup_Result>((IEnumerable<WSspSelectProductCostGroup_Result>)_db.WSspSelectProductCostGroup(lCID, result));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.ProductCostGroup = list;
		return list;
	}

	[HttpPost]
	public string GetSaleCentersWithPrdIds(string ids = "")
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
			List<WSspSelectProductsWithIds_Result> list = Enumerable.ToList<WSspSelectProductsWithIds_Result>((IEnumerable<WSspSelectProductsWithIds_Result>)_dbI.WSspSelectProductsWithIds(ids, ",", lCID, result2));
			if (list != null)
			{
				string text = "";
				foreach (WSspSelectProductsWithIds_Result item in list)
				{
					if (!string.IsNullOrWhiteSpace(item.PrdSaleCenterIds))
					{
						if (text != "")
						{
							text += ",";
						}
						text += item.PrdSaleCenterIds;
					}
				}
				List<WSspSelectSaleCentersWithIds_Result> list2 = Enumerable.ToList<WSspSelectSaleCentersWithIds_Result>((IEnumerable<WSspSelectSaleCentersWithIds_Result>)_dbII.WSspSelectSaleCentersWithIds(text, lCID, result2));
				if (list2 != null)
				{
					result = JsonConvert.SerializeObject(list2);
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
	public string GetSaleCentersWithIds(string ids = "")
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
			List<WSspSelectSaleCentersWithIds_Result> list = Enumerable.ToList<WSspSelectSaleCentersWithIds_Result>((IEnumerable<WSspSelectSaleCentersWithIds_Result>)_dbII.WSspSelectSaleCentersWithIds(ids, lCID, result2));
			if (list != null)
			{
				foreach (WSspSelectSaleCentersWithIds_Result item in list)
				{
					item.FirstRegisterDatePersian = item.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm");
					item.RegisterDatePersian = item.RegisterDate.ToString("yyyy/MM/dd HH:mm");
				}
				result = JsonConvert.SerializeObject(list);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[HttpPost]
	public string GetOrderItemsSaleCenterDelivery(string dt = "", int orderId = 0)
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
			if (!string.IsNullOrWhiteSpace(dt))
			{
				dt = HttpUtility.UrlDecode(dt);
				DateTime dateTime = default(DateTime);
				string text = "";
				try
				{
					text = PersianDate.GetFormatetdDate(dt.Replace("/", ""));
					switch (lCID)
					{
					case 1065:
						dateTime = DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
						dt = dateTime.ToString("yyyyMMdd");
						break;
					case 1025:
						dateTime = DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
						dt = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					default:
						dateTime = DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
						dt = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
					base.ViewBag.Error = Messages.WrongDateTime;
					return "";
				}
				List<WSspSelectOrderItemsSaleCenterDelivery_Result> list = Enumerable.ToList<WSspSelectOrderItemsSaleCenterDelivery_Result>((IEnumerable<WSspSelectOrderItemsSaleCenterDelivery_Result>)_dbII.WSspSelectOrderItemsSaleCenterDelivery(dateTime, orderId, lCID, result2));
				if (list != null)
				{
					foreach (WSspSelectOrderItemsSaleCenterDelivery_Result item in list)
					{
						item.RegisterDatePersian = item.RegisterDate.ToString("yyyy/MM/dd");
						item.FirstRegisterDatePersian = item.FirstRegisterDate?.ToString("yyyy/MM/dd");
					}
					result = JsonConvert.SerializeObject(list);
				}
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return result;
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		_dbI.Dispose();
		_dbII.Dispose();
		_dbIII.Dispose();
		base.Dispose(disposing);
	}
}
