using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Objects;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using CRM.General.Security;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Areas.Products.Controllers;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.Orders.Controllers;

public class IssueQuickController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private readonly CRMLinkSpEntities _dbLink = new CRMLinkSpEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	private readonly CRMSpIIIEntities _dbIII = new CRMSpIIIEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actordSaleOrderIssueQuick")]
	public ActionResult Index(int mode = 0)
	{
		base.ViewBag.CompanyDefSetting = SelectCompanyQuickRegisterDefSetting();
		base.ViewBag.OrderDefSetting = SelectOrderDefaultSetting();
		base.ViewBag.FavPrdsListJs = SelectUserFavproductsByUserIdIssueQuickOrderJs();
		base.ViewBag.CompanyTitleSelectListItem = SelectCompanyTitleSelectListItem();
		base.ViewBag.PersonTitleSelectListItem = SelectPersonTitleSelectListItem();
		base.ViewBag.OrderIssueGroupsJs = SelectOrderIssueQuickGroupsJs();
		base.ViewBag.WarehouseSelectListItem = GetWarehouseList_Json();
		if (mode == 1 && !UserLogin.IsUserAccess("frmOrderIssueQuick", "actordIssueQuickSetting", UserLogin.CurrentUser))
		{
			mode = 0;
		}
		base.ViewBag.PaymentTypes = SelectOrderPaymentTypesJs();
		base.ViewBag.Mode = mode;
		return View();
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmOrderIssueQuick", ActionName = "actSaleOrderIssue")]
	public string IssueCompleteOrder(int? cmpSettingId = null, int cmpId = 0, int prsId = 0, int prjId = 0, int? cmpTitleId = null, string cmpName = "", string cmpNameLng = "", string cmpFName = "", string cmpFNameLng = "", string prsMobile = "", int? prsTitleId = null, int? ordSettingId = null, string ordIJs = "", int payTypeId = 0, bool insertOrdPay = false, string insertOrdPayJson = "", int discountCodeId = 0, int referUserId = 0, string prsAddress = "", string prsNationalCode = "")
	{
		WSspIssueCompleteOrder_Result wSspIssueCompleteOrder_Result = new WSspIssueCompleteOrder_Result();
		List<CommonErrorViewModel> list = new List<CommonErrorViewModel>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
			if (defLangID <= 0)
			{
				defLangID = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			if (referUserId == 0)
			{
				referUserId = currentUser.UserId;
			}
			if (!VersionBuyer.Order)
			{
				DbSet<WSOrder> wSOrder = _dbTbl.WSOrder;
				ParameterExpression val = Expression.Parameter(typeof(WSOrder), "c");
				if (Queryable.Any<WSOrder>((IQueryable<WSOrder>)wSOrder, Expression.Lambda<Func<WSOrder, bool>>((Expression)(object)Expression.GreaterThan((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)10, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val })))
				{
					list.Add(new CommonErrorViewModel
					{
						ErrorMessage = Messages.VersionBuy
					});
				}
			}
			List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
			foreach (Languages item in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != defLangID))))
			{
				if (string.IsNullOrWhiteSpace(cmpFNameLng))
				{
					list2.Add(new CommonMultiLanguageViewModel
					{
						Value = cmpFName,
						LanguageId = item.LanguageID
					});
				}
			}
			List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
			foreach (Languages item2 in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != defLangID))))
			{
				if (string.IsNullOrWhiteSpace(cmpNameLng))
				{
					list3.Add(new CommonMultiLanguageViewModel
					{
						Value = cmpName,
						LanguageId = item2.LanguageID
					});
				}
			}
			if (string.IsNullOrWhiteSpace(cmpName))
			{
				list.Add(new CommonErrorViewModel
				{
					ErrorMessage = Messages.msgErrorEnterCmpName
				});
			}
			int mobNumLen = CRMIdeal.Classes.Helper.Setting.GetMobNumLen();
			bool mobNumLenNoCheck = CRMIdeal.Classes.Helper.Setting.GetMobNumLenNoCheck();
			if (prsMobile.Length != mobNumLen && !mobNumLenNoCheck)
			{
				string text = Public.CheckMobileFormat(prsMobile);
				if (!string.IsNullOrWhiteSpace(text))
				{
					list.Add(new CommonErrorViewModel
					{
						ErrorMessage = text
					});
				}
			}
			string formName = "frmOrderItemDataEntry";
			int result = 0;
			int result2 = 0;
			int result3 = 0;
			if (ordSettingId.GetValueOrDefault() != 0)
			{
				WSspSelectOrderDefaultSettingById_Result wSspSelectOrderDefaultSettingById_Result = Enumerable.FirstOrDefault<WSspSelectOrderDefaultSettingById_Result>((IEnumerable<WSspSelectOrderDefaultSettingById_Result>)_dbIII.WSspSelectOrderDefaultSettingById(ordSettingId, lCID, defLangID));
				if (wSspSelectOrderDefaultSettingById_Result != null)
				{
					int.TryParse(wSspSelectOrderDefaultSettingById_Result.DefWHId.ToString(), out result);
					int.TryParse(wSspSelectOrderDefaultSettingById_Result.OrderOprID.ToString(), out result3);
					if (result3 != 0)
					{
						WSspSelectOrderOprById_Result wSspSelectOrderOprById_Result = Enumerable.FirstOrDefault<WSspSelectOrderOprById_Result>((IEnumerable<WSspSelectOrderOprById_Result>)_dbI.WSspSelectOrderOprById(result3, lCID, defLangID));
						if (wSspSelectOrderOprById_Result != null)
						{
							int.TryParse(wSspSelectOrderOprById_Result.OprType.ToString(), out result2);
						}
					}
				}
			}
			bool flag = false;
			if (UserLogin.IsUserAccess(formName, "actCanNotSelectWithNoStockInOrd", currentUser) || UserLogin.IsUserAccess(formName, "actCanNotSelectWithNoReserveStockInOrd", currentUser) || UserLogin.IsUserAccess(formName, "actCanNotSelectWithNoSoldStockInOrd", currentUser))
			{
				flag = true;
			}
			if (!string.IsNullOrWhiteSpace(ordIJs) && result2 != 2 && flag)
			{
				List<WSIssueOrderItemsCompleteViewModel> list4 = JsonConvert.DeserializeObject<List<WSIssueOrderItemsCompleteViewModel>>(ordIJs);
				if (list4 != null && Enumerable.Any<WSIssueOrderItemsCompleteViewModel>((IEnumerable<WSIssueOrderItemsCompleteViewModel>)list4))
				{
					SearchController searchController = new SearchController();
					foreach (WSIssueOrderItemsCompleteViewModel item3 in list4)
					{
						int result4 = 0;
						int.TryParse(item3.ordIPrdId.ToString(), out result4);
						int? num = null;
						if (!string.IsNullOrWhiteSpace(item3.ordIPrdPriceGroupID))
						{
							num = int.Parse(item3.ordIPrdPriceGroupID);
							if (num == 0)
							{
								num = null;
							}
						}
						double result5 = 0.0;
						double.TryParse(item3.ordIQuantity.ToString(), out result5);
						double? num2 = null;
						if (!string.IsNullOrWhiteSpace(item3.ordIFCR))
						{
							num2 = double.Parse(item3.ordIFCR);
							if (num2 == 0.0)
							{
								num2 = null;
							}
						}
						double? num3 = null;
						if (!string.IsNullOrWhiteSpace(item3.ordIFCRI))
						{
							num3 = double.Parse(item3.ordIFCRI);
							if (num3 == 0.0)
							{
								num3 = null;
							}
						}
						string tracing = "";
						int result6 = 1;
						string text2 = "";
						WSspSelectProductsWithId_Result wSspSelectProductsWithId_Result = Enumerable.FirstOrDefault<WSspSelectProductsWithId_Result>((IEnumerable<WSspSelectProductsWithId_Result>)_db.WSspSelectProductsWithId(result4, lCID, defLangID));
						if (wSspSelectProductsWithId_Result != null)
						{
							int.TryParse(wSspSelectProductsWithId_Result.PrdKind.ToString(), out result6);
							text2 = wSspSelectProductsWithId_Result.PrdName ?? "";
						}
						int result7 = 0;
						int.TryParse(item3.ordIWHId.ToString(), out result7);
						if (result7 == 0)
						{
							result7 = result;
						}
						if (result7 == 0)
						{
							list.Add(new CommonErrorViewModel
							{
								ErrorMessage = "برای محصول " + text2 + "انباری تعریف نشده است."
							});
						}
						if (result6 == 2)
						{
							continue;
						}
						ReturnPrdQuantityViewModel returnPrdQuantityViewModel = searchController.ReturnPrdQuantityResult(result4, 0, result7, num2.GetValueOrDefault(), num3.GetValueOrDefault(), tracing, cmpId, num.GetValueOrDefault(), "ord", "", "", "SaleOrder");
						if (returnPrdQuantityViewModel != null)
						{
							double num4 = result5;
							double result8 = 0.0;
							if (returnPrdQuantityViewModel.PrdQuantity != null)
							{
								double.TryParse(returnPrdQuantityViewModel.PrdQuantity.TracingRemainCount.ToString(), out result8);
							}
							double result9 = 0.0;
							double.TryParse(returnPrdQuantityViewModel.QtyRemain.ToString(), out result9);
							double result10 = 0.0;
							double.TryParse(returnPrdQuantityViewModel.RemainSoldOrdPrdQuantity.ToString(), out result10);
							if (UserLogin.IsUserAccess(formName, "actCanNotSelectWithNoStockInOrd", currentUser) && (result8 <= 0.0 || result8 < num4))
							{
								list.Add(new CommonErrorViewModel
								{
									ErrorMessage = Messages.ProductLackOfStock + ": " + text2
								});
							}
							if (UserLogin.IsUserAccess(formName, "actCanNotSelectWithNoReserveStockInOrd", currentUser) && result9 < num4)
							{
								list.Add(new CommonErrorViewModel
								{
									ErrorMessage = Messages.ProductLackOfReserveStock + ": " + text2
								});
							}
							if (UserLogin.IsUserAccess(formName, "actCanNotSelectWithNoSoldStockInOrd", currentUser) && result10 < num4)
							{
								list.Add(new CommonErrorViewModel
								{
									ErrorMessage = Messages.msgErrorProductLackOfSoldStock + ": " + text2
								});
							}
						}
					}
				}
			}
			if (!string.IsNullOrWhiteSpace(insertOrdPayJson))
			{
				PcPos.StartPaymentResult startPaymentResult = JsonConvert.DeserializeObject<PcPos.StartPaymentResult>(insertOrdPayJson);
				insertOrdPayJson = JsonConvert.SerializeObject(new List<WSIssueOrderPaymentsCompleteViewModel>
				{
					new WSIssueOrderPaymentsCompleteViewModel
					{
						ImportDate = startPaymentResult.CreateOn.ToString("yyyyMMdd", new PersianCulture()),
						ordpayTypeId = payTypeId,
						ordpayAmount = decimal.Parse(startPaymentResult.Amount.Replace(",", "")),
						ordpayDocNumber = startPaymentResult.TraceNumber,
						ordpayDocDate = startPaymentResult.CreateOn.ToString("yyyyMMdd", new PersianCulture()),
						ordpayDescription = Labels.PaymentTRN + " : " + startPaymentResult.RRN,
						ImportDateTime = startPaymentResult.CreateOn.ToString("yyyy-MM-dd HH:mm:ss", new CultureInfo("en-US")),
						ordpayDocDateTime = startPaymentResult.CreateOn.ToString("yyyy-MM-dd HH:mm:ss", new CultureInfo("en-US")),
						ordpayDocAmount = decimal.Parse(startPaymentResult.Amount.Replace(",", "")),
						ordpayAmountTemp = decimal.Parse(startPaymentResult.Amount.Replace(",", "")),
						ordpayCardNumber = startPaymentResult.CardMaskNumber
					}
				});
			}
			if (list.Count <= 0)
			{
				CRMSpIEntities dbI = _dbI;
				int? companyId = cmpId;
				int? cmpTitleId2 = cmpTitleId;
				string companyName_Lang = JsonConvert.SerializeObject(list3);
				int? companyPersonId = prsId;
				int? prsTitleId2 = prsTitleId;
				WSspIssueCompleteOrder_Result wSspIssueCompleteOrder_Result2 = Enumerable.FirstOrDefault<WSspIssueCompleteOrder_Result>((IEnumerable<WSspIssueCompleteOrder_Result>)dbI.WSspIssueCompleteOrder(cmpSettingId, companyId, companyPersonId, prjId, cmpTitleId2, cmpName, companyName_Lang, prsMobile, prsTitleId2, ordSettingId, ordIJs, currentUser.UserId, short.Parse(Financial.Get().Id.ToString()), short.Parse(now.ToString("MM", new PersianCulture())), Financial.Get().Id, now, now.ToString("yyyyMMdd", new PersianCulture()), Configuration.AppType, lCID, defLangID, Messages.CheckcmpNameDuplicate, Messages.CheckDuplicatePrsMobile, Messages.CheckDuplicatePrjPostFix, Messages.CheckDuplicatePrjDesc, cmpFName, JsonConvert.SerializeObject(list2), insertOrdPay, insertOrdPayJson, payTypeId, discountCodeId, centerId, XorCipher.PreparePublicKeyForSql(), referUserId, prsAddress, prsNationalCode, Messages.CheckDuplicatePrsNationalCode, Messages.CheckRequiredNationalCode));
				if (wSspIssueCompleteOrder_Result2 != null)
				{
					wSspIssueCompleteOrder_Result = wSspIssueCompleteOrder_Result2;
					if (!string.IsNullOrWhiteSpace(wSspIssueCompleteOrder_Result2.ErrorJson))
					{
						list = JsonConvert.DeserializeObject<List<CommonErrorViewModel>>(wSspIssueCompleteOrder_Result2.ErrorJson);
					}
					string text3 = Order.VerifyOrderComplete(wSspIssueCompleteOrder_Result.OrderId.GetValueOrDefault(), "frmOrderIssueQuick", actVerifyOrder_Value: true, actVerifyOrder_Passed: false, UserLogin.IsUserAccess("frmOrderIssueQuick", "actordIssueDraftAfterIssueQOrd", currentUser), UserLogin.IsUserAccess("frmOrderIssueQuick", "actordIssueDraftAfterIssueQOrd", currentUser), "actordIssueDraftAfterIssueQOrd");
					if (!string.IsNullOrWhiteSpace(text3))
					{
						string[] array = text3.Split(new char[1] { '|' });
						int result11 = 0;
						int.TryParse(array[0], out result11);
						if (result11 != 1)
						{
							list.Add(new CommonErrorViewModel
							{
								ErrorMessage = text3
							});
						}
					}
					list.Add(new CommonErrorViewModel
					{
						ErrorMessage = "[StartDate]" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
					});
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
			list.Add(new CommonErrorViewModel
			{
				ErrorMessage = ex.Message
			});
		}
		wSspIssueCompleteOrder_Result.ErrorJson = JsonConvert.SerializeObject(list);
		return JsonConvert.SerializeObject(wSspIssueCompleteOrder_Result);
	}

	[HttpPost]
	[LoginAuthorize]
	public List<WSspSelectUserFavproductsByUserIdIssueQuickOrder_Result> SelectUserFavproductsByUserIdIssueQuickOrder()
	{
		List<WSspSelectUserFavproductsByUserIdIssueQuickOrder_Result> result = new List<WSspSelectUserFavproductsByUserIdIssueQuickOrder_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int userId = UserLogin.CurrentUser.UserId;
			List<WSspSelectUserFavproductsByUserIdIssueQuickOrder_Result> list = Enumerable.ToList<WSspSelectUserFavproductsByUserIdIssueQuickOrder_Result>((IEnumerable<WSspSelectUserFavproductsByUserIdIssueQuickOrder_Result>)_dbI.WSspSelectUserFavproductsByUserIdIssueQuickOrder(userId, lCID, result2));
			if (list != null)
			{
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
	[LoginAuthorize]
	public string SelectUserFavproductsByUserIdIssueQuickOrderJs()
	{
		return JsonConvert.SerializeObject(SelectUserFavproductsByUserIdIssueQuickOrder());
	}

	[HttpPost]
	[LoginAuthorize]
	public List<WSspSelectUserFavproductItemsIssueQuickOrder_Result> SelectUserFavproductItemsIssueQuickOrder(int favId = 0)
	{
		List<WSspSelectUserFavproductItemsIssueQuickOrder_Result> result = new List<WSspSelectUserFavproductItemsIssueQuickOrder_Result>();
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
			if (favId != 0)
			{
				List<WSspSelectUserFavproductItemsIssueQuickOrder_Result> list = Enumerable.ToList<WSspSelectUserFavproductItemsIssueQuickOrder_Result>((IEnumerable<WSspSelectUserFavproductItemsIssueQuickOrder_Result>)_dbI.WSspSelectUserFavproductItemsIssueQuickOrder(favId, lCID, result2, result3, UserLogin.CurrentUser.UserId));
				if (list != null)
				{
					result = list;
				}
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
	public string SelectUserFavproductItemsIssueQuickOrderJs(int favId = 0)
	{
		return JsonConvert.SerializeObject(SelectUserFavproductItemsIssueQuickOrder(favId));
	}

	[HttpPost]
	[LoginAuthorize]
	public List<CRMspSelectCompanyQuickRegisterDefSettingUserAccess_Result> SelectCompanyQuickRegisterDefSetting()
	{
		List<CRMspSelectCompanyQuickRegisterDefSettingUserAccess_Result> result = new List<CRMspSelectCompanyQuickRegisterDefSettingUserAccess_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int userId = UserLogin.CurrentUser.UserId;
			List<CRMspSelectCompanyQuickRegisterDefSettingUserAccess_Result> list = Enumerable.ToList<CRMspSelectCompanyQuickRegisterDefSettingUserAccess_Result>((IEnumerable<CRMspSelectCompanyQuickRegisterDefSettingUserAccess_Result>)_dbIII.CRMspSelectCompanyQuickRegisterDefSettingUserAccess((short)3, userId, lCID, result2));
			int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)_dbIII.CRMspSelectCompanyQuickRegisterDefSettingIsDefUserAccess((short)3, userId, lCID, result2));
			if (list != null)
			{
				result = list;
			}
			base.ViewBag.DefCompanySettingId = num;
			if (list != null)
			{
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
	[LoginAuthorize]
	public string SelectCompanyQuickRegisterDefSettingJs()
	{
		return JsonConvert.SerializeObject(SelectCompanyQuickRegisterDefSetting());
	}

	[HttpPost]
	[LoginAuthorize]
	public List<WSspSelectOrderDefaultSettingUserAccess_Result> SelectOrderDefaultSetting()
	{
		List<WSspSelectOrderDefaultSettingUserAccess_Result> result = new List<WSspSelectOrderDefaultSettingUserAccess_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int userId = UserLogin.CurrentUser.UserId;
			List<WSspSelectOrderDefaultSettingUserAccess_Result> list = Enumerable.ToList<WSspSelectOrderDefaultSettingUserAccess_Result>((IEnumerable<WSspSelectOrderDefaultSettingUserAccess_Result>)_dbIII.WSspSelectOrderDefaultSettingUserAccess((short)2, userId, lCID, result2));
			int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)_dbIII.WSspSelectOrderDefaultSettingIsDefUserAccess((short)2, userId, lCID, result2));
			if (list != null)
			{
				result = list;
			}
			base.ViewBag.DefOrderSettingId = num;
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public List<SelectListItem> SelectOrderDefaultSettingSelectListItem()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			List<WSspSelectOrderDefaultSettingUserAccess_Result> list2 = SelectOrderDefaultSetting();
			if (list2 != null)
			{
				list.AddRange(Enumerable.Select<WSspSelectOrderDefaultSettingUserAccess_Result, SelectListItem>((IEnumerable<WSspSelectOrderDefaultSettingUserAccess_Result>)list2, (Func<WSspSelectOrderDefaultSettingUserAccess_Result, SelectListItem>)((WSspSelectOrderDefaultSettingUserAccess_Result x) => new SelectListItem
				{
					Text = x.SettingTitle,
					Value = x.OrderSettingID.ToString(),
					Selected = x.IsDefIssueQuickOrder.GetValueOrDefault()
				})));
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return list;
	}

	[HttpPost]
	public List<WSspSelectOrderPaymentTypes_Result> SelectOrderPaymentTypes()
	{
		List<WSspSelectOrderPaymentTypes_Result> result = new List<WSspSelectOrderPaymentTypes_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int value = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserId : 0);
			List<WSspSelectOrderPaymentTypes_Result> list = Enumerable.ToList<WSspSelectOrderPaymentTypes_Result>((IEnumerable<WSspSelectOrderPaymentTypes_Result>)_db.WSspSelectOrderPaymentTypes(lCID, result2, value));
			if (list != null)
			{
				foreach (WSspSelectOrderPaymentTypes_Result item in list)
				{
					item.ordPayTypePosPassword = ((!string.IsNullOrEmpty(item.ordPayTypePosPassword)) ? XorCipher.DecryptByPrivateKey(item.ordPayTypePosPassword) : null);
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
	public string SelectOrderPaymentTypesJs()
	{
		return JsonConvert.SerializeObject(SelectOrderPaymentTypes());
	}

	[HttpPost]
	public async Task<string> GetPcPosToken(int payTypeId = 0)
	{
		return JsonConvert.SerializeObject(await PcPos.GetToken(payTypeId));
	}

	[HttpPost]
	public async Task<string> GetPcPosIdentifier(string token = "", int payTypeId = 0)
	{
		return JsonConvert.SerializeObject(await PcPos.GetIdentifier(token, payTypeId));
	}

	[HttpPost]
	public async Task<string> PcPosSendPaymentRequest(string token = "", string identifier = "", string objId = "", int payTypeId = 0, string itemsJs = "", string selectedPrdJs = "", string totalPrice = "")
	{
		return JsonConvert.SerializeObject(await PcPos.SendPaymentRequest(token, identifier, objId, payTypeId, itemsJs, selectedPrdJs, totalPrice));
	}

	[HttpPost]
	[LoginAuthorize]
	public List<CRMspSelectCompanyTitle_Result> SelectCompanyTitle()
	{
		List<CRMspSelectCompanyTitle_Result> result = new List<CRMspSelectCompanyTitle_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectCompanyTitle_Result> list = Enumerable.ToList<CRMspSelectCompanyTitle_Result>((IEnumerable<CRMspSelectCompanyTitle_Result>)_db.CRMspSelectCompanyTitle(lCID, result2));
			if (list != null)
			{
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
	[LoginAuthorize]
	public List<SelectListItem> SelectCompanyTitleSelectListItem()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			List<CRMspSelectCompanyTitle_Result> list2 = SelectCompanyTitle();
			if (list2 != null)
			{
				list.AddRange(Enumerable.Select<CRMspSelectCompanyTitle_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyTitle_Result>)list2, (Func<CRMspSelectCompanyTitle_Result, SelectListItem>)((CRMspSelectCompanyTitle_Result x) => new SelectListItem
				{
					Text = x.CompanyTitle,
					Value = x.CompanyTitleID.ToString()
				})));
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return list;
	}

	[HttpPost]
	[LoginAuthorize]
	public List<CRMspSelectPersonTitle_Result> SelectPersonTitle()
	{
		List<CRMspSelectPersonTitle_Result> result = new List<CRMspSelectPersonTitle_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectPersonTitle_Result> list = Enumerable.ToList<CRMspSelectPersonTitle_Result>((IEnumerable<CRMspSelectPersonTitle_Result>)_db.CRMspSelectPersonTitle(lCID, result2));
			if (list != null)
			{
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
	[LoginAuthorize]
	public List<SelectListItem> SelectPersonTitleSelectListItem()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			List<CRMspSelectPersonTitle_Result> list2 = SelectPersonTitle();
			if (list2 != null)
			{
				list.AddRange(Enumerable.Select<CRMspSelectPersonTitle_Result, SelectListItem>((IEnumerable<CRMspSelectPersonTitle_Result>)list2, (Func<CRMspSelectPersonTitle_Result, SelectListItem>)((CRMspSelectPersonTitle_Result x) => new SelectListItem
				{
					Text = x.PersonTitle,
					Value = x.PersonTitleID.ToString()
				})));
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return list;
	}

	[HttpPost]
	[LoginAuthorize]
	public List<CRMspMainSearchWebSmart_Result> SearchWithPhone(string val = "")
	{
		return CRMIdeal.Classes.Helper.Company.MainSearchWebSmart(val, UserLogin.CurrentUser.UserId, 1, "9,20");
	}

	[HttpPost]
	[LoginAuthorize]
	public string SearchWithPhoneJs(string val = "")
	{
		return JsonConvert.SerializeObject(SearchWithPhone(val));
	}

	[HttpPost]
	[LoginAuthorize]
	public List<CRMspMainSearchWebSmart_Result> SearchWithNationalCode(string val = "")
	{
		return CRMIdeal.Classes.Helper.Company.MainSearchWebSmart(val, UserLogin.CurrentUser.UserId, 1, "12,22");
	}

	[HttpPost]
	[LoginAuthorize]
	public string SearchWithNationalCodeJs(string val = "")
	{
		return JsonConvert.SerializeObject(SearchWithNationalCode(val));
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmOrderIssueQuick", ActionName = "actSearchProducts")]
	public List<WSspSearchProductsWeb_Result> SearchProducts(string val = "", int? prdId = 0, string barcode = "")
	{
		List<WSspSearchProductsWeb_Result> result = new List<WSspSearchProductsWeb_Result>();
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
			if (!string.IsNullOrWhiteSpace(val) || prdId > 0 || !string.IsNullOrWhiteSpace(barcode))
			{
				List<WSspSearchProductsWeb_Result> list = Enumerable.ToList<WSspSearchProductsWeb_Result>((IEnumerable<WSspSearchProductsWeb_Result>)_dbI.WSspSearchProductsWeb(0, 0, barcode, val, prdId, 2, lCID, result2, 0, 0, null, null, result3, UserLogin.CurrentUser.UserId));
				if (list != null)
				{
					result = list;
				}
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
	public string SearchProductsJs(string val = "", int? prdId = 0, string barcode = "")
	{
		return JsonConvert.SerializeObject(SearchProducts(val, prdId, barcode));
	}

	[HttpPost]
	[LoginAuthorize]
	public List<CRMspSelectOrderIssueQuickGroups_Result> SelectOrderIssueQuickGroups()
	{
		List<CRMspSelectOrderIssueQuickGroups_Result> list = new List<CRMspSelectOrderIssueQuickGroups_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			_ = UserLogin.CurrentUser.UserId;
			List<CRMspSelectOrderIssueQuickGroups_Result> list2 = Enumerable.ToList<CRMspSelectOrderIssueQuickGroups_Result>((IEnumerable<CRMspSelectOrderIssueQuickGroups_Result>)_dbI.CRMspSelectOrderIssueQuickGroups(lCID, result));
			if (list2 != null)
			{
				list = list2;
				foreach (CRMspSelectOrderIssueQuickGroups_Result item in list)
				{
					item.GroupItemsJs = SelectOrderIssueQuickGroupItemsJs(item.IssueQuickGroupID);
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return list;
	}

	[HttpPost]
	[LoginAuthorize]
	public string SelectOrderIssueQuickGroupsJs()
	{
		return JsonConvert.SerializeObject(SelectOrderIssueQuickGroups());
	}

	[HttpPost]
	[LoginAuthorize]
	public string IssueQuickGroupIE(int issueQuickGroupId = 0, string groupTitle = "", string groupTitleJs = null, bool? isDefault = null, int boxRowsCount = 3, int boxColsCount = 3, int boxHeight = 75, int boxWidth = 130, string boxColor = null, string boxTextColor = null, string colorCode = null, string textColorCode = null, string description = null, string descriptionJs = null, int? orderView = null)
	{
		string text = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			int userId = UserLogin.CurrentUser.UserId;
			short value = short.Parse(Financial.Get().Id.ToString());
			short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
			_ = Financial.Get().Id;
			DateTime value3 = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			string appType = Configuration.AppType;
			if (string.IsNullOrWhiteSpace(groupTitle))
			{
				if (text != "")
				{
					text += "\n";
				}
				text += Messages.msgEmptyOrdIssueQuickTitle;
			}
			if (!(text != ""))
			{
				if (issueQuickGroupId != 0)
				{
					_dbI.CRMspUpdateOrderIssueQuickGroup(issueQuickGroupId, groupTitle, groupTitleJs, isDefault, boxRowsCount, boxColsCount, colorCode, textColorCode, description, descriptionJs, orderView, userId, value3, registerDatePersian, lCID, result);
					text = issueQuickGroupId.ToString();
				}
				else
				{
					ObjectParameter objectParameter = new ObjectParameter("InsertedId", 0);
					_dbI.CRMspInsertOrderIssueQuickGroup(groupTitle, groupTitleJs, isDefault, boxRowsCount, boxColsCount, colorCode, textColorCode, description, descriptionJs, boxHeight, boxWidth, boxColor, boxTextColor, orderView, userId, value3, registerDatePersian, value, value2, appType, lCID, result, objectParameter);
					if (objectParameter != null)
					{
						int result2 = 0;
						int.TryParse(objectParameter.Value.ToString(), out result2);
						if (result2 > 0)
						{
							text = result2.ToString();
						}
					}
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
			if (text != "")
			{
				text += "\n";
			}
			text += ex.Message;
		}
		return text;
	}

	[HttpPost]
	[LoginAuthorize]
	public string DeleteIssueQuickGroup(int id = 0, bool withItems = false)
	{
		string result = "";
		try
		{
			ObjectResult<int?> objectResult = _dbI.CRMspDeleteOrderIssueQuickGroup(id, withItems);
			int result2 = 0;
			int.TryParse(objectResult.ToString(), out result2);
			if (result2 != 1 && result2 == 0)
			{
				result = Messages.msgErrorOperationFailed;
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
			result = ex.Message;
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public List<CRMspSelectOrderIssueQuickGroupItems_Result> SelectOrderIssueQuickGroupItems(int groupId = 0)
	{
		List<CRMspSelectOrderIssueQuickGroupItems_Result> list = new List<CRMspSelectOrderIssueQuickGroupItems_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			_ = UserLogin.CurrentUser.UserId;
			List<CRMspSelectOrderIssueQuickGroupItems_Result> list2 = Enumerable.ToList<CRMspSelectOrderIssueQuickGroupItems_Result>((IEnumerable<CRMspSelectOrderIssueQuickGroupItems_Result>)_dbI.CRMspSelectOrderIssueQuickGroupItems(groupId, lCID, result));
			if (list2 != null)
			{
				list = list2;
				foreach (CRMspSelectOrderIssueQuickGroupItems_Result item in list)
				{
					item.PrdJs = SearchProductsJs("", item.PrdId);
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return list;
	}

	[HttpPost]
	[LoginAuthorize]
	public string SelectOrderIssueQuickGroupItemsJs(int groupId = 0)
	{
		return JsonConvert.SerializeObject(SelectOrderIssueQuickGroupItems(groupId));
	}

	[HttpPost]
	[LoginAuthorize]
	public CRMspSelectOrderIssueQuickGroupItemWithId_Result SelectOrderIssueQuickGroupItemWithId(int id = 0)
	{
		CRMspSelectOrderIssueQuickGroupItemWithId_Result cRMspSelectOrderIssueQuickGroupItemWithId_Result = new CRMspSelectOrderIssueQuickGroupItemWithId_Result();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			CRMspSelectOrderIssueQuickGroupItemWithId_Result cRMspSelectOrderIssueQuickGroupItemWithId_Result2 = Enumerable.FirstOrDefault<CRMspSelectOrderIssueQuickGroupItemWithId_Result>((IEnumerable<CRMspSelectOrderIssueQuickGroupItemWithId_Result>)_dbI.CRMspSelectOrderIssueQuickGroupItemWithId(id, lCID, result));
			if (cRMspSelectOrderIssueQuickGroupItemWithId_Result2 != null)
			{
				cRMspSelectOrderIssueQuickGroupItemWithId_Result = cRMspSelectOrderIssueQuickGroupItemWithId_Result2;
				if (cRMspSelectOrderIssueQuickGroupItemWithId_Result.PrdId > 0)
				{
					cRMspSelectOrderIssueQuickGroupItemWithId_Result.Prd = SearchProductsJs("", cRMspSelectOrderIssueQuickGroupItemWithId_Result.PrdId);
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return cRMspSelectOrderIssueQuickGroupItemWithId_Result;
	}

	[HttpPost]
	[LoginAuthorize]
	public string SelectOrderIssueQuickGroupItemWithIdJs(int id = 0)
	{
		return JsonConvert.SerializeObject(SelectOrderIssueQuickGroupItemWithId(id));
	}

	[HttpPost]
	[LoginAuthorize]
	public string InsertOrderIssueQuickGroupItems(int issueQuickGroupId = 0, string js = "")
	{
		string text = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			int userId = UserLogin.CurrentUser.UserId;
			short value = short.Parse(Financial.Get().Id.ToString());
			short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
			_ = Financial.Get().Id;
			DateTime value3 = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			string appType = Configuration.AppType;
			if (!string.IsNullOrWhiteSpace(js))
			{
				ObjectResult<int?> objectResult = _dbI.CRMspInsertOrderIssueQuickGroupItems(issueQuickGroupId, js, userId, value3, registerDatePersian, value, value2, appType, lCID);
				if (objectResult != null)
				{
					int result2 = 0;
					int.TryParse(Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)objectResult).Value.ToString(), out result2);
					if (result2 != 1 && result2 == 0)
					{
						if (text != "")
						{
							text += "\n";
						}
						text += Messages.msgErrorOperationFailed;
					}
				}
			}
			else
			{
				if (text != "")
				{
					text += "\n";
				}
				text += Messages.msgErrorItemNoValue;
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
			if (text != "")
			{
				text += "\n";
			}
			text += ex.Message;
		}
		return text;
	}

	[HttpPost]
	[LoginAuthorize]
	public string InsertUpdateOrderIssueQuickGroupItem(int issueQuickGroupItemId, int issueQuickGroupId, int? prdId = null, string boxTitle = null, string boxTitleJs = null, int? boxHeight = null, int? boxWidth = null, int? boxRow = null, int? boxCol = null, string boxColor = null, string boxTextColor = null, bool? inActive = null, int? orderView = null)
	{
		List<SelectListItem> list = new List<SelectListItem>();
		string text = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			int userId = UserLogin.CurrentUser.UserId;
			short value = short.Parse(Financial.Get().Id.ToString());
			short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
			_ = Financial.Get().Id;
			DateTime value3 = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			string appType = Configuration.AppType;
			ObjectResult<int?> objectResult = _dbI.CRMspInsertUpdateOrderIssueQuickGroupItem(issueQuickGroupItemId, issueQuickGroupId, prdId, boxTitle, boxTitleJs, boxHeight, boxWidth, boxRow, boxCol, boxColor, boxTextColor, inActive, orderView, userId, value3, registerDatePersian, value, value2, appType, lCID, result);
			if (objectResult != null)
			{
				int.TryParse(Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)objectResult).Value.ToString(), out issueQuickGroupItemId);
				if (issueQuickGroupItemId <= 0)
				{
					if (text != "")
					{
						text += "\n";
					}
					text += Messages.msgErrorOperationFailed;
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
			if (text != "")
			{
				text += "\n";
			}
			text = text + "Exception: " + ex.Message;
		}
		if (text != "")
		{
			list.Add(new SelectListItem
			{
				Text = "Error",
				Value = text
			});
		}
		return JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	[LoginAuthorize]
	public string DeleteIssueQuickGroupItem(int id = 0)
	{
		string result = "";
		try
		{
			ObjectResult<int?> objectResult = _dbI.CRMspDeleteOrderIssueQuickGroupItem(id);
			int result2 = 0;
			int.TryParse(objectResult.ToString(), out result2);
			if (result2 != 1 && result2 == 0)
			{
				result = Messages.msgErrorOperationFailed;
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
			result = "Exception: " + ex.Message;
		}
		return result;
	}

	[HttpPost]
	public WSspSelectDiscountCodeByDisCode_Result SelectDiscountCodeByDisCode(string disCode = "")
	{
		WSspSelectDiscountCodeByDisCode_Result result = new WSspSelectDiscountCodeByDisCode_Result();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (!string.IsNullOrWhiteSpace(disCode))
			{
				WSspSelectDiscountCodeByDisCode_Result wSspSelectDiscountCodeByDisCode_Result = Enumerable.FirstOrDefault<WSspSelectDiscountCodeByDisCode_Result>((IEnumerable<WSspSelectDiscountCodeByDisCode_Result>)_dbI.WSspSelectDiscountCodeByDisCode(disCode, lCID, result2));
				if (wSspSelectDiscountCodeByDisCode_Result != null)
				{
					result = wSspSelectDiscountCodeByDisCode_Result;
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	[HttpPost]
	public string SelectDiscountCodeByDisCodeJs(string disCode = "")
	{
		return JsonConvert.SerializeObject(SelectDiscountCodeByDisCode(disCode));
	}

	[HttpPost]
	public string SelectDiscountCodeByDisCodeIJs(int cmpId = 0, string prdIds = "", string disCode = "")
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
		List<SelectListItem> list = new List<SelectListItem>();
		WSspSelectDiscountCodeByDisCode_Result disc = SelectDiscountCodeByDisCode(disCode);
		if (disc.DiscountCodeId != 0)
		{
			list.Add(new SelectListItem
			{
				Text = "data",
				Value = JsonConvert.SerializeObject(disc)
			});
			_ = disc.DisExpDate;
			if (disc.DisExpDate <= DateTime.Now)
			{
				list.Add(new SelectListItem
				{
					Text = "msg",
					Value = Messages.msgErrorDisCodeExpired
				});
			}
			List<WSspSelectDiscountCodeHistory_Result> list2 = Enumerable.ToList<WSspSelectDiscountCodeHistory_Result>((IEnumerable<WSspSelectDiscountCodeHistory_Result>)_dbII.WSspSelectDiscountCodeHistory(disc.DiscountCodeId, lCID, result, 0, int.MaxValue));
			if (disc.DisCmpId.GetValueOrDefault() != 0)
			{
				if (disc.DisCmpId != cmpId)
				{
					list.Add(new SelectListItem
					{
						Text = "msg",
						Value = string.Format(Messages.msgErrorDisCodeUsableForCmp, disc.DisCmpName)
					});
				}
				else if (list2 != null && list2.Count >= disc.DisUseCnt)
				{
					list.Add(new SelectListItem
					{
						Text = "msg",
						Value = Messages.msgErrorDisCodeUsedBefore
					});
				}
			}
			else if (list2 != null && Enumerable.ToList<WSspSelectDiscountCodeHistory_Result>(Enumerable.Where<WSspSelectDiscountCodeHistory_Result>((IEnumerable<WSspSelectDiscountCodeHistory_Result>)list2, (Func<WSspSelectDiscountCodeHistory_Result, bool>)((WSspSelectDiscountCodeHistory_Result x) => x.DisCmpId == cmpId))).Count > 0)
			{
				list.Add(new SelectListItem
				{
					Text = "msg",
					Value = Messages.msgErrorDisCodeUsedBefore
				});
			}
			if (disc.DisUseCnt != 0 && disc.UsedCount.GetValueOrDefault() != 0 && disc.DisUseCnt <= disc.UsedCount.GetValueOrDefault())
			{
				list.Add(new SelectListItem
				{
					Text = "msg",
					Value = Messages.msgErrorDisCodeUsedBefore
				});
			}
			if (disc.ScoreRate.GetValueOrDefault() != 0.0)
			{
				double result3 = 0.0;
				CRMspReturnSumCompanyScores_Result cRMspReturnSumCompanyScores_Result = Enumerable.FirstOrDefault<CRMspReturnSumCompanyScores_Result>((IEnumerable<CRMspReturnSumCompanyScores_Result>)_dbI.CRMspReturnSumCompanyScores(cmpId, result2));
				if (cRMspReturnSumCompanyScores_Result != null)
				{
					double.TryParse(cRMspReturnSumCompanyScores_Result.SumUsableScores.ToString(), out result3);
				}
				if (disc.ScoreRate > result3)
				{
					list.Add(new SelectListItem
					{
						Text = "msg",
						Value = string.Format(Messages.msgErrorDisCodeNoScoreMin, disc.ScoreRate)
					});
				}
			}
			if (!string.IsNullOrWhiteSpace(prdIds) && disc.DisPrdId.GetValueOrDefault() != 0 && Enumerable.FirstOrDefault<string>((IEnumerable<string>)Enumerable.ToList<string>(Enumerable.Where<string>((IEnumerable<string>)prdIds.Split(new char[1] { ',' }), (Func<string, bool>)((string x) => !string.IsNullOrWhiteSpace(x)))), (Func<string, bool>)((string x) => int.Parse(x) == disc.DisPrdId)) == null)
			{
				list.Add(new SelectListItem
				{
					Text = "msg",
					Value = string.Format(Messages.msgErrorDisCodeItemNoPrd, disc.DisPrdName, "Order".OrderLabels())
				});
			}
		}
		else
		{
			list.Add(new SelectListItem
			{
				Text = "msg",
				Value = Messages.msgErrorDisCodeIncorrect
			});
		}
		return JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetLinkedProductsJs(int prdId = 0)
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
			if (prdId != 0)
			{
				List<CommonWithIdStrViewModel> list = new List<CommonWithIdStrViewModel>();
				WSspSearchProductsWeb_Result wSspSearchProductsWeb_Result = Enumerable.FirstOrDefault<WSspSearchProductsWeb_Result>((IEnumerable<WSspSearchProductsWeb_Result>)SearchProducts("", prdId));
				if (wSspSearchProductsWeb_Result != null)
				{
					list.Add(new CommonWithIdStrViewModel
					{
						Id = wSspSearchProductsWeb_Result.ProductID.ToString(),
						Code = wSspSearchProductsWeb_Result.PrdCode,
						Name = wSspSearchProductsWeb_Result.PName,
						Extra = JsonConvert.SerializeObject(wSspSearchProductsWeb_Result)
					});
				}
				List<WSspSelectLinkedProducts_Result> list2 = Enumerable.ToList<WSspSelectLinkedProducts_Result>((IEnumerable<WSspSelectLinkedProducts_Result>)_db.WSspSelectLinkedProducts(prdId, lCID, result2));
				if (list2 != null)
				{
					foreach (WSspSelectLinkedProducts_Result item in list2)
					{
						WSspSearchProductsWeb_Result wSspSearchProductsWeb_Result2 = Enumerable.FirstOrDefault<WSspSearchProductsWeb_Result>((IEnumerable<WSspSearchProductsWeb_Result>)SearchProducts("", item.ProductIdForLoad));
						if (wSspSearchProductsWeb_Result2 != null)
						{
							list.Add(new CommonWithIdStrViewModel
							{
								Id = wSspSearchProductsWeb_Result2.ProductID.ToString(),
								Code = wSspSearchProductsWeb_Result2.PrdCode,
								Name = wSspSearchProductsWeb_Result2.PName,
								Extra = JsonConvert.SerializeObject(wSspSearchProductsWeb_Result2),
								Selected = item.LinkedPrdIsSelect.GetValueOrDefault()
							});
						}
					}
					result = JsonConvert.SerializeObject(list);
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	public List<SelectListItem> GetOrdReferUserList()
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
			int result2 = 0;
			int value = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
				value = UserLogin.CurrentUser.UserId;
			}
			List<CRMspSelectUserForLinkedTypeIsActive_Result> list2 = Enumerable.ToList<CRMspSelectUserForLinkedTypeIsActive_Result>((IEnumerable<CRMspSelectUserForLinkedTypeIsActive_Result>)_dbI.CRMspSelectUserForLinkedTypeIsActive(value, 7, lCID, result, result2));
			if (list2 != null && Enumerable.Any<CRMspSelectUserForLinkedTypeIsActive_Result>((IEnumerable<CRMspSelectUserForLinkedTypeIsActive_Result>)list2))
			{
				list.AddRange(Enumerable.Select<CRMspSelectUserForLinkedTypeIsActive_Result, SelectListItem>((IEnumerable<CRMspSelectUserForLinkedTypeIsActive_Result>)list2, (Func<CRMspSelectUserForLinkedTypeIsActive_Result, SelectListItem>)((CRMspSelectUserForLinkedTypeIsActive_Result item) => new SelectListItem
				{
					Text = item.UserName,
					Value = item.LinkedUserId.ToString(),
					Selected = false
				})));
			}
			if (list == null)
			{
				list = new List<SelectListItem>();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	public string GetOrdReferUser_Json()
	{
		return JsonConvert.SerializeObject(GetOrdReferUserList());
	}

	public List<SelectListItem> GetWarehouseList()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
				_ = UserLogin.CurrentUser.UserId;
			}
			List<WSspSelectActiveWareHouse_Result> list2 = CRMIdeal.Classes.Helper.Warehouse.SelectActiveWareHouse();
			list.AddRange(Enumerable.Select<WSspSelectActiveWareHouse_Result, SelectListItem>((IEnumerable<WSspSelectActiveWareHouse_Result>)list2, (Func<WSspSelectActiveWareHouse_Result, SelectListItem>)((WSspSelectActiveWareHouse_Result item) => new SelectListItem
			{
				Text = item.WrhsName + ((!string.IsNullOrWhiteSpace(item.WrhsCode)) ? (" (" + item.WrhsCode + ")") : ""),
				Value = item.WareHouseID.ToString(),
				Selected = false
			})));
			if (list == null)
			{
				list = new List<SelectListItem>();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	public string GetWarehouseList_Json()
	{
		return JsonConvert.SerializeObject(GetWarehouseList());
	}

	[AjaxOnly]
	public JsonResult CalcAndUpdateDiscountPolicy(int orderSettingId, string orderItemJson, int cmpId = 0)
	{
		_ = UserLogin.CurrentUser;
		string data = "";
		string text = "";
		CommonResultStatusViewModel status = CommonResultStatusViewModel.Success;
		CommonResultViewModel<string> data2;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (orderSettingId == 0)
			{
				data2 = new CommonResultViewModel<string>
				{
					Data = data,
					Message = Messages.msgErrorOrdIssueQuickOrderDefSettingIsEmpty,
					Status = CommonResultStatusViewModel.Error
				};
				JsonResult jsonResult = Json(data2, JsonRequestBehavior.AllowGet);
				jsonResult.MaxJsonLength = int.MaxValue;
				return jsonResult;
			}
			if (!string.IsNullOrWhiteSpace(orderItemJson) && orderItemJson != "[]")
			{
				DateTime now = DateTime.Now;
				DateTime value = now;
				now.ToString("yyyyMMdd", new PersianCulture());
				short.Parse(now.ToString("MM", new PersianCulture()));
				_ = Configuration.AppType;
				_ = Financial.Get().Id;
				_ = UserLogin.CurrentUser.UserId;
				int result2 = 0;
				if (UserLogin.CurrentUser != null)
				{
					int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
				}
				ObjectParameter objectParameter = new ObjectParameter("Result", typeof(int));
				List<WSspCalcAndUpdateDiscountPolicyInIssueCompleteOrdItem_Result> list = Enumerable.ToList<WSspCalcAndUpdateDiscountPolicyInIssueCompleteOrdItem_Result>((IEnumerable<WSspCalcAndUpdateDiscountPolicyInIssueCompleteOrdItem_Result>)_dbII.WSspCalcAndUpdateDiscountPolicyInIssueCompleteOrdItem(orderSettingId, orderItemJson, cmpId, value, result2, lCID, result, objectParameter));
				int result3 = 0;
				if (objectParameter != null && objectParameter.Value != null)
				{
					int.TryParse(objectParameter.Value.ToString(), out result3);
				}
				switch (result3)
				{
				case 1:
					if (list != null && Enumerable.Any<WSspCalcAndUpdateDiscountPolicyInIssueCompleteOrdItem_Result>((IEnumerable<WSspCalcAndUpdateDiscountPolicyInIssueCompleteOrdItem_Result>)list))
					{
						data = JsonConvert.SerializeObject(Enumerable.ToList<WSspCalcAndUpdateDiscountPolicyInIssueCompleteOrdItem_Result>((IEnumerable<WSspCalcAndUpdateDiscountPolicyInIssueCompleteOrdItem_Result>)list));
					}
					status = CommonResultStatusViewModel.Success;
					text = "1";
					break;
				case 2:
					text = string.Format(Messages.msgErrorNotFindDiscoutPolicyOnItem, "lblOrd".OrderLabels());
					break;
				case 3:
					text = Messages.ErrorNotFound;
					break;
				default:
					text = string.Format(Messages.msgErrorCalcAndUpdateDiscountPolicyOnItem, "lblOrd".OrderLabels());
					break;
				}
			}
			else
			{
				text = Messages.ErrorNotFound;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			text = Messages.msgErrorRunFunction;
			status = CommonResultStatusViewModel.Error;
			data = "";
		}
		data2 = new CommonResultViewModel<string>
		{
			Data = data,
			Message = text,
			Status = status
		};
		JsonResult jsonResult2 = Json(data2, JsonRequestBehavior.AllowGet);
		jsonResult2.MaxJsonLength = int.MaxValue;
		return jsonResult2;
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		_dbLink.Dispose();
		_dbI.Dispose();
		_dbII.Dispose();
		_dbIII.Dispose();
		base.Dispose(disposing);
	}
}
