using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CRM.General.Security;
using CRM.Models;
using CRM.OtherWebServices.LinkNoAvaranCapillary;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.OtherSystems.Controllers;

public class CityController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMLinkSpEntities _dbLink = new CRMLinkSpEntities();

	private readonly CRMSpIEntities _db_I = new CRMSpIEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	[LoginAuthorize]
	public ActionResult ManageCityLinkAcc(int linkAccSystemId, int position = 0)
	{
		string text = "";
		string text2 = "";
		switch (position)
		{
		case 0:
			text = "frmDefineCity";
			text2 = "actManageCityLinkAcc";
			break;
		case 1:
			text = "frmsysSetting";
			text2 = "actEdit";
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
		if (linkAccSystemId == 1)
		{
			base.ViewBag.LinkAccSettingDBList = CRMIdeal.Classes.Helper.OtherSystems.GetLinkAccSettingDB(1);
		}
		base.ViewBag.LinkAccSystemId = linkAccSystemId;
		return View();
	}

	public ActionResult _PartialManageCityLinkAccCombo(int linkAccSystemId, int provinceId, int linkAccProvinceId, int linkAccSettingDBId)
	{
		GetCrmCityList(provinceId, linkAccSystemId, linkAccSettingDBId);
		if (linkAccSystemId == 1)
		{
			SepidarCityList(linkAccProvinceId, linkAccSettingDBId);
		}
		else
		{
			OtherLinkAccCityList(linkAccProvinceId, linkAccSystemId);
		}
		base.ViewBag.LinkAccSystemId = linkAccSystemId;
		return PartialView();
	}

	public ActionResult _PartialManageCityLinkAcc(int linkAccSystemId, int provinceId, int linkAccProvinceId, int linkAccSettingDBId)
	{
		GetCrmCityList(provinceId, linkAccSystemId, linkAccSettingDBId);
		if (linkAccSystemId == 1)
		{
			SepidarCityList(linkAccProvinceId, linkAccSettingDBId);
		}
		else
		{
			OtherLinkAccCityList(linkAccProvinceId, linkAccSystemId);
		}
		base.ViewBag.LinkAccSystemId = linkAccSystemId;
		return PartialView();
	}

	public ActionResult _PartialLoadManageCityLinkAcc(int linkAccSystemId, int linkAccSettingDBId)
	{
		GetCrmProvinceList(linkAccSystemId, linkAccSettingDBId);
		if (linkAccSystemId == 1)
		{
			GetSepidarProvinceList(linkAccSettingDBId);
		}
		else
		{
			GetOtherLinkAccProvinceList(linkAccSystemId);
		}
		base.ViewBag.LinkAccSystemId = linkAccSystemId;
		return PartialView();
	}

	[AjaxOnly]
	public JsonResult GetCrmProvinceList(int linkAccSystemId, int linkAccSettingDBId)
	{
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectProvince_Result> list2 = Enumerable.ToList<CRMspSelectProvince_Result>((IEnumerable<CRMspSelectProvince_Result>)_db.CRMspSelectProvince(lCID, result));
			if (linkAccSystemId == 1 && list2 != null && Enumerable.Any<CRMspSelectProvince_Result>((IEnumerable<CRMspSelectProvince_Result>)list2))
			{
				foreach (CRMspSelectProvince_Result item in list2)
				{
					if (string.IsNullOrWhiteSpace(item.LinkAccData))
					{
						continue;
					}
					List<LinkAccDataViewModel> list3 = new JavaScriptSerializer().Deserialize<List<LinkAccDataViewModel>>(item.LinkAccData);
					if (list3 != null && Enumerable.Any<LinkAccDataViewModel>((IEnumerable<LinkAccDataViewModel>)list3))
					{
						LinkAccDataViewModel linkAccDataViewModel = Enumerable.FirstOrDefault<LinkAccDataViewModel>((IEnumerable<LinkAccDataViewModel>)list3, (Func<LinkAccDataViewModel, bool>)((LinkAccDataViewModel m) => m.DBId.GetValueOrDefault() == linkAccSettingDBId));
						if (linkAccDataViewModel != null)
						{
							item.LinkAccProvinceIdStr = linkAccDataViewModel.Id ?? "";
							item.LinkAccData = "";
						}
					}
				}
			}
			if (list2 != null)
			{
				list.AddRange(Enumerable.Select<CRMspSelectProvince_Result, SelectListItem>((IEnumerable<CRMspSelectProvince_Result>)list2, (Func<CRMspSelectProvince_Result, SelectListItem>)((CRMspSelectProvince_Result item) => new SelectListItem
				{
					Value = item.ProvinceID.ToString(),
					Text = ((!string.IsNullOrWhiteSpace(item.CountryName)) ? item.CountryName : "") + ((!string.IsNullOrWhiteSpace(item.CountryName) && !string.IsNullOrWhiteSpace(item.Province)) ? " - " : "") + ((!string.IsNullOrWhiteSpace(item.Province)) ? item.Province : ""),
					Selected = false
				})));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.CrmProvinceList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetSepidarProvinceList(int linkAccSettingDBId)
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
			List<CRMspLkSepSelectLocation_Result> list2 = Enumerable.ToList<CRMspLkSepSelectLocation_Result>((IEnumerable<CRMspLkSepSelectLocation_Result>)_dbLink.CRMspLkSepSelectLocation("2", linkAccSettingDBId, lCID, result));
			if (list2 != null)
			{
				list.AddRange(Enumerable.Select<CRMspLkSepSelectLocation_Result, SelectListItem>((IEnumerable<CRMspLkSepSelectLocation_Result>)list2, (Func<CRMspLkSepSelectLocation_Result, SelectListItem>)((CRMspLkSepSelectLocation_Result item) => new SelectListItem
				{
					Value = item.LocationId.ToString(),
					Text = ((!string.IsNullOrWhiteSpace(item.ParentName)) ? item.ParentName : "") + ((!string.IsNullOrWhiteSpace(item.ParentName) && !string.IsNullOrWhiteSpace(item.Title)) ? " - " : "") + ((!string.IsNullOrWhiteSpace(item.Title)) ? item.Title : ""),
					Selected = false
				})));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.LinkAccProvinceList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetOtherLinkAccProvinceList(int linkAccSystemId)
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
			LkListProvinceInfoViewModel lkListProvinceInfoViewModel = new ProvinceController().OtherLinkAccProvinceList(linkAccSystemId);
			if (lkListProvinceInfoViewModel != null && lkListProvinceInfoViewModel.Lst != null && Enumerable.Any<LkProvinceInfoViewModel>((IEnumerable<LkProvinceInfoViewModel>)lkListProvinceInfoViewModel.Lst))
			{
				list.AddRange(Enumerable.Select<LkProvinceInfoViewModel, SelectListItem>((IEnumerable<LkProvinceInfoViewModel>)lkListProvinceInfoViewModel.Lst, (Func<LkProvinceInfoViewModel, SelectListItem>)((LkProvinceInfoViewModel item) => new SelectListItem
				{
					Value = item.LinkAccProvinceIdStr,
					Text = ((!string.IsNullOrWhiteSpace(item.CountryName)) ? item.CountryName : "") + ((!string.IsNullOrWhiteSpace(item.CountryName) && !string.IsNullOrWhiteSpace(item.Province)) ? " - " : "") + ((!string.IsNullOrWhiteSpace(item.Province)) ? item.Province : ""),
					Selected = false
				})));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.LinkAccProvinceList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[HttpPost]
	public string ManageSyncCity(string jsData, int linkAccSettingDBId)
	{
		string text = "";
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		DateTime now = DateTime.Now;
		DateTime value = now;
		string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
		_ = Financial.Get().Id;
		short value2 = short.Parse(Financial.Get().Id.ToString());
		short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
		string appType = Configuration.AppType;
		int userId = UserLogin.CurrentUser.UserId;
		List<SelectListItem> value4 = new List<SelectListItem>();
		try
		{
			if (!string.IsNullOrWhiteSpace(jsData) && string.IsNullOrWhiteSpace(text))
			{
				List<CommonWithIdStrViewModel> list = JsonConvert.DeserializeObject<List<CommonWithIdStrViewModel>>(jsData);
				if (list != null && list.Count > 0)
				{
					List<SelectListItem> list2 = new List<SelectListItem>();
					List<SelectListItem> list3 = new List<SelectListItem>();
					foreach (CommonWithIdStrViewModel i in list)
					{
						if (Enumerable.ToList<SelectListItem>(Enumerable.Where<SelectListItem>((IEnumerable<SelectListItem>)list2, (Func<SelectListItem, bool>)((SelectListItem x) => x.Value == i.Extra))).Count <= 0)
						{
							List<CommonWithIdStrViewModel> list4 = Enumerable.ToList<CommonWithIdStrViewModel>(Enumerable.Where<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list, (Func<CommonWithIdStrViewModel, bool>)((CommonWithIdStrViewModel x) => x.Extra == i.Extra && !string.IsNullOrWhiteSpace(x.Id))));
							if (list4 == null || list4.Count <= 0)
							{
								list2.Add(new SelectListItem
								{
									Value = i.Extra,
									Text = ""
								});
								list3.Add(new SelectListItem
								{
									Value = i.Extra,
									Text = ""
								});
							}
							else
							{
								list2.Add(new SelectListItem
								{
									Value = i.Extra,
									Text = JsonConvert.SerializeObject(list4)
								});
								list3.Add(new SelectListItem
								{
									Value = i.Extra,
									Text = i.Id
								});
							}
						}
					}
					if (list2 != null && list3 != null && Enumerable.Any<SelectListItem>((IEnumerable<SelectListItem>)list2) && Enumerable.Any<SelectListItem>((IEnumerable<SelectListItem>)list3))
					{
						string itemJson = JsonConvert.SerializeObject(Enumerable.ToList<SelectListItem>((IEnumerable<SelectListItem>)list3));
						ObjectParameter objectParameter = new ObjectParameter("ErrorMessage", "");
						_dbLink.CRMspLkUpdateCityLinkAccByJson(itemJson, userId, value3, value2, value, registerDatePersian, appType, objectParameter, linkAccSettingDBId);
						if (objectParameter.Value != null)
						{
							if (!string.IsNullOrEmpty(objectParameter.Value.ToString()))
							{
								text = text + objectParameter.Value.ToString() + "|";
							}
							else
							{
								value4 = list2;
							}
						}
						else
						{
							value4 = list2;
						}
					}
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("City");
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return text + "|**|" + JsonConvert.SerializeObject(value4);
	}

	[HttpPost]
	public JsonResult ActLinkedCityAcc(int linkAccSystemId, int linkAccSettingDBId)
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
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			new List<LinkedCompanyWithAccViewModel>();
			DateTime now = DateTime.Now;
			now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			short.Parse(Financial.Get().Id.ToString());
			_ = UserLogin.CurrentUser.UserId;
			string text3 = "";
			int num = 0;
			if (!UserLogin.IsUserAccess("frmManageCityLinkAcc", "actLinkWithAcc", UserLogin.CurrentUser))
			{
				text3 = text3 + Messages.ErrorNotAccess + "<br>";
				num++;
			}
			CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
			if (cRMspSelectCrmsysSetting_Result != null)
			{
				int.TryParse(cRMspSelectCrmsysSetting_Result.LinkAccSystemId.ToString(), out linkAccSystemId);
			}
			CRMIdeal.Classes.Helper.Setting.GetLinkAccSystemTitle();
			bool flag = false;
			if ((linkAccSystemId != 1) ? OtherLinkedCityAcc(linkAccSystemId) : SepidarLinkedCityAcc(linkAccSettingDBId))
			{
				text = "";
				commonResultStatusViewModel = CommonResultStatusViewModel.Success;
				text2 = Messages.msgSuccessAction;
				CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("City");
			}
			else
			{
				text = "";
				text2 = Messages.msgErrorRunFunction;
				commonResultStatusViewModel = CommonResultStatusViewModel.Error;
			}
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

	[HttpPost]
	public string GetManageLinkedCityList(int provinceId, int linkAccSystemId, int linkAccSettingDBId)
	{
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectCityWithAccLinkField_Result> list = Enumerable.ToList<CRMspSelectCityWithAccLinkField_Result>(Enumerable.Where<CRMspSelectCityWithAccLinkField_Result>((IEnumerable<CRMspSelectCityWithAccLinkField_Result>)_dbLink.CRMspSelectCityWithAccLinkField(true, lCID, result2, true), (Func<CRMspSelectCityWithAccLinkField_Result, bool>)((CRMspSelectCityWithAccLinkField_Result m) => m.ProvinceId == provinceId)));
			if (linkAccSystemId == 1 && list != null && Enumerable.Any<CRMspSelectCityWithAccLinkField_Result>((IEnumerable<CRMspSelectCityWithAccLinkField_Result>)list))
			{
				foreach (CRMspSelectCityWithAccLinkField_Result item in list)
				{
					if (string.IsNullOrWhiteSpace(item.LinkAccData))
					{
						continue;
					}
					List<LinkAccDataViewModel> list2 = new JavaScriptSerializer().Deserialize<List<LinkAccDataViewModel>>(item.LinkAccData);
					if (list2 != null && Enumerable.Any<LinkAccDataViewModel>((IEnumerable<LinkAccDataViewModel>)list2))
					{
						LinkAccDataViewModel linkAccDataViewModel = Enumerable.FirstOrDefault<LinkAccDataViewModel>((IEnumerable<LinkAccDataViewModel>)list2, (Func<LinkAccDataViewModel, bool>)((LinkAccDataViewModel m) => m.DBId.GetValueOrDefault() == linkAccSettingDBId));
						if (linkAccDataViewModel != null)
						{
							item.LinkAccCityIdStr = linkAccDataViewModel.Id ?? "";
							item.LinkAccData = "";
						}
					}
				}
				list = Enumerable.ToList<CRMspSelectCityWithAccLinkField_Result>(Enumerable.Where<CRMspSelectCityWithAccLinkField_Result>((IEnumerable<CRMspSelectCityWithAccLinkField_Result>)list, (Func<CRMspSelectCityWithAccLinkField_Result, bool>)((CRMspSelectCityWithAccLinkField_Result m) => (m.LinkAccCityIdStr ?? "") != "")));
			}
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

	public LkListCityInfoViewModel GetCrmCityList(int provinceId, int linkAccSystemId, int linkAccSettingDBId)
	{
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		LkListCityInfoViewModel lkListCityInfoViewModel = new LkListCityInfoViewModel();
		try
		{
			_ = UserLogin.CurrentUser.UserId;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectCity_Result> list = Enumerable.ToList<CRMspSelectCity_Result>(Enumerable.Where<CRMspSelectCity_Result>((IEnumerable<CRMspSelectCity_Result>)_db.CRMspSelectCity(lCID, result), (Func<CRMspSelectCity_Result, bool>)((CRMspSelectCity_Result m) => m.ProvinceId == provinceId)));
			if (linkAccSystemId == 1 && list != null && Enumerable.Any<CRMspSelectCity_Result>((IEnumerable<CRMspSelectCity_Result>)list))
			{
				foreach (CRMspSelectCity_Result item in list)
				{
					if (string.IsNullOrWhiteSpace(item.LinkAccData))
					{
						continue;
					}
					List<LinkAccDataViewModel> list2 = new JavaScriptSerializer().Deserialize<List<LinkAccDataViewModel>>(item.LinkAccData);
					if (list2 != null && Enumerable.Any<LinkAccDataViewModel>((IEnumerable<LinkAccDataViewModel>)list2))
					{
						LinkAccDataViewModel linkAccDataViewModel = Enumerable.FirstOrDefault<LinkAccDataViewModel>((IEnumerable<LinkAccDataViewModel>)list2, (Func<LinkAccDataViewModel, bool>)((LinkAccDataViewModel m) => m.DBId.GetValueOrDefault() == linkAccSettingDBId));
						if (linkAccDataViewModel != null)
						{
							item.LinkAccCityIdStr = linkAccDataViewModel.Id ?? "";
							item.LinkAccData = "";
						}
					}
				}
			}
			if (list != null && list.Count > 0)
			{
				List<LkCityInfoViewModel> list3 = new List<LkCityInfoViewModel>();
				List<SelectListItem> list4 = new List<SelectListItem>();
				foreach (CRMspSelectCity_Result item2 in list)
				{
					list3.Add(new LkCityInfoViewModel
					{
						CityID = item2.CityID,
						City = item2.City,
						CityCode = item2.CityCode,
						Description = item2.Description,
						LinkAccCityIdStr = item2.LinkAccCityIdStr,
						ProvinceId = item2.ProvinceId,
						ProvinceName = item2.ProvinceName
					});
					list4.Add(new SelectListItem
					{
						Value = item2.CityID.ToString(),
						Text = ((!string.IsNullOrWhiteSpace(item2.ProvinceName)) ? item2.ProvinceName : "") + ((!string.IsNullOrWhiteSpace(item2.ProvinceName) && !string.IsNullOrWhiteSpace(item2.City)) ? " - " : "") + ((!string.IsNullOrWhiteSpace(item2.City)) ? item2.City : ""),
						Selected = false
					});
				}
				lkListCityInfoViewModel.Lst = list3;
				lkListCityInfoViewModel.LstSelectListItem = list4;
			}
			lkListCityInfoViewModel.IsDone = true;
			lkListCityInfoViewModel.Message = "";
		}
		catch (Exception ex)
		{
			lkListCityInfoViewModel.IsDone = false;
			lkListCityInfoViewModel.Message = "Error: " + ex.Message;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		base.ViewBag.CrmCityListJs = JsonConvert.SerializeObject(lkListCityInfoViewModel.Lst);
		base.ViewBag.CrmCitySelectListJs = JsonConvert.SerializeObject(lkListCityInfoViewModel.LstSelectListItem);
		base.ViewBag.CrmCityList = lkListCityInfoViewModel;
		return lkListCityInfoViewModel;
	}

	public LkListCityInfoViewModel OtherLinkAccCityList(int provinceId, int linkAccSystemId)
	{
		LkListCityInfoViewModel lkListCityInfoViewModel = new LkListCityInfoViewModel();
		lkListCityInfoViewModel.Lst = new List<LkCityInfoViewModel>();
		lkListCityInfoViewModel.LstSelectListItem = new List<SelectListItem>();
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
			LkCityInfoViewModelObjects lkCityInfoViewModelObjects = new LkCityInfoViewModelObjects();
			switch (linkAccSystemId)
			{
			case 18:
				lkCityInfoViewModelObjects = GetNoAvaranCapillaryCityList(provinceId);
				break;
			case 20:
				lkCityInfoViewModelObjects = GetNilramCityList(provinceId);
				break;
			case 21:
				lkCityInfoViewModelObjects = GetHamyarCityList(provinceId.ToString());
				break;
			case 22:
				lkCityInfoViewModelObjects = GetRahkaranInternalSalesCityList(provinceId);
				break;
			case 25:
				lkCityInfoViewModelObjects = GetArianSystemCityList(provinceId);
				break;
			}
			if (lkCityInfoViewModelObjects != null)
			{
				List<LkCityInfoViewModel> lst = lkCityInfoViewModelObjects.lst;
				if (lst != null && Enumerable.Any<LkCityInfoViewModel>((IEnumerable<LkCityInfoViewModel>)lst))
				{
					new List<SelectListItem>();
					foreach (LkCityInfoViewModel item in lst)
					{
						LkCityInfoViewModel lkCityInfoViewModel = new LkCityInfoViewModel();
						lkCityInfoViewModel.City = item.City ?? "";
						lkCityInfoViewModel.LinkAccCityIdStr = item.LinkAccCityIdStr ?? "";
						lkCityInfoViewModel.City = item.City ?? "";
						lkCityInfoViewModel.CityID = item.CityID;
						lkCityInfoViewModel.ProvinceId = item.ProvinceId;
						lkCityInfoViewModel.ProvinceName = item.ProvinceName;
						lkListCityInfoViewModel.Lst.Add(lkCityInfoViewModel);
						lkListCityInfoViewModel.LstSelectListItem.Add(new SelectListItem
						{
							Value = lkCityInfoViewModel.LinkAccCityIdStr,
							Text = ((!string.IsNullOrWhiteSpace(lkCityInfoViewModel.ProvinceName)) ? lkCityInfoViewModel.ProvinceName : "") + ((!string.IsNullOrWhiteSpace(lkCityInfoViewModel.ProvinceName) && !string.IsNullOrWhiteSpace(lkCityInfoViewModel.City)) ? " - " : "") + ((!string.IsNullOrWhiteSpace(lkCityInfoViewModel.City)) ? lkCityInfoViewModel.City : ""),
							Selected = false
						});
					}
				}
			}
			lkListCityInfoViewModel.IsDone = true;
			lkListCityInfoViewModel.Message = "";
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			lkListCityInfoViewModel.IsDone = false;
			lkListCityInfoViewModel.Message = "Error: " + ex.Message;
		}
		base.ViewBag.LinkAccCityListJs = JsonConvert.SerializeObject(lkListCityInfoViewModel.Lst);
		base.ViewBag.LinkAccCitySelectListJs = JsonConvert.SerializeObject(lkListCityInfoViewModel.LstSelectListItem);
		base.ViewBag.LinkAccCityList = lkListCityInfoViewModel;
		return lkListCityInfoViewModel;
	}

	public bool OtherLinkedCityAcc(int linkAccSystemId)
	{
		bool result = false;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			short value3 = short.Parse(Financial.Get().Id.ToString());
			int userId = UserLogin.CurrentUser.UserId;
			string text = "";
			LkListCityInfoViewModel lkListCityInfoViewModel = OtherLinkAccCityList(0, linkAccSystemId);
			if (lkListCityInfoViewModel != null && lkListCityInfoViewModel.Lst != null && Enumerable.Any<LkCityInfoViewModel>((IEnumerable<LkCityInfoViewModel>)lkListCityInfoViewModel.Lst))
			{
				text = JsonConvert.SerializeObject(Enumerable.ToList<LkCityInfoViewModel>((IEnumerable<LkCityInfoViewModel>)lkListCityInfoViewModel.Lst));
			}
			if (!string.IsNullOrWhiteSpace(text))
			{
				mct_Link_Result mct_Link_Result = Enumerable.FirstOrDefault<mct_Link_Result>((IEnumerable<mct_Link_Result>)_dbLink.CRMspLkLinkedCity(linkAccSystemId, text, userId, value2, value3, value, registerDatePersian, appType));
				if (mct_Link_Result != null)
				{
					int result3 = 0;
					int.TryParse(mct_Link_Result.Result.ToString(), out result3);
					if (result3 > 0)
					{
						result = true;
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public LkCityInfoViewModelObjects GetSepidarCityList(int provinceId, int linkAccSettingDBId)
	{
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		LkCityInfoViewModelObjects lkCityInfoViewModelObjects = new LkCityInfoViewModelObjects();
		lkCityInfoViewModelObjects.lst = new List<LkCityInfoViewModel>();
		lkCityInfoViewModelObjects.FilteredLst = new List<LkCityInfoViewModel>();
		List<LkCityInfoViewModel> list = new List<LkCityInfoViewModel>();
		try
		{
			List<CRMspLkSepSelectLocation_Result> list2 = Enumerable.ToList<CRMspLkSepSelectLocation_Result>(Enumerable.Where<CRMspLkSepSelectLocation_Result>((IEnumerable<CRMspLkSepSelectLocation_Result>)_dbLink.CRMspLkSepSelectLocation("3", linkAccSettingDBId, lCID, result), (Func<CRMspLkSepSelectLocation_Result, bool>)((CRMspLkSepSelectLocation_Result m) => m.Parent.GetValueOrDefault() == provinceId)));
			if (list2 != null && Enumerable.Any<CRMspLkSepSelectLocation_Result>((IEnumerable<CRMspLkSepSelectLocation_Result>)list2))
			{
				List<CRMspSelectCityWithAccLinkField_Result> list3 = Enumerable.ToList<CRMspSelectCityWithAccLinkField_Result>((IEnumerable<CRMspSelectCityWithAccLinkField_Result>)_dbLink.CRMspSelectCityWithAccLinkField(true, lCID, result, true));
				int result2 = 0;
				CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
				if (cRMspSelectCrmsysSetting_Result != null)
				{
					int.TryParse(cRMspSelectCrmsysSetting_Result.LinkAccSystemId.ToString(), out result2);
				}
				if (result2 == 1 && list3 != null && Enumerable.Any<CRMspSelectCityWithAccLinkField_Result>((IEnumerable<CRMspSelectCityWithAccLinkField_Result>)list3))
				{
					foreach (CRMspSelectCityWithAccLinkField_Result item2 in list3)
					{
						if (string.IsNullOrWhiteSpace(item2.LinkAccData))
						{
							continue;
						}
						List<LinkAccDataViewModel> list4 = new JavaScriptSerializer().Deserialize<List<LinkAccDataViewModel>>(item2.LinkAccData);
						if (list4 != null && Enumerable.Any<LinkAccDataViewModel>((IEnumerable<LinkAccDataViewModel>)list4))
						{
							LinkAccDataViewModel linkAccDataViewModel = Enumerable.FirstOrDefault<LinkAccDataViewModel>((IEnumerable<LinkAccDataViewModel>)list4, (Func<LinkAccDataViewModel, bool>)((LinkAccDataViewModel m) => m.DBId.GetValueOrDefault() == linkAccSettingDBId));
							if (linkAccDataViewModel != null)
							{
								item2.LinkAccCityIdStr = linkAccDataViewModel.Id ?? "";
								item2.LinkAccData = "";
							}
						}
					}
				}
				int num = 1;
				foreach (CRMspLkSepSelectLocation_Result item in list2)
				{
					LkCityInfoViewModel lkCityInfoViewModel = new LkCityInfoViewModel();
					lkCityInfoViewModel.City = item.Title;
					lkCityInfoViewModel.CityCode = item.Code;
					lkCityInfoViewModel.LinkAccCityIdStr = item.LocationId.ToString();
					lkCityInfoViewModel.ProvinceId = item.Parent.GetValueOrDefault();
					lkCityInfoViewModel.ProvinceName = item.ParentName;
					lkCityInfoViewModel.RowNumber = num;
					CRMspSelectCityWithAccLinkField_Result cRMspSelectCityWithAccLinkField_Result = Enumerable.FirstOrDefault<CRMspSelectCityWithAccLinkField_Result>((IEnumerable<CRMspSelectCityWithAccLinkField_Result>)list3, (Func<CRMspSelectCityWithAccLinkField_Result, bool>)((CRMspSelectCityWithAccLinkField_Result x) => x.LinkAccCityIdStr == item.LocationId.ToString()));
					if (cRMspSelectCityWithAccLinkField_Result != null && !string.IsNullOrWhiteSpace(cRMspSelectCityWithAccLinkField_Result.LinkAccCityIdStr))
					{
						lkCityInfoViewModel.CityID = cRMspSelectCityWithAccLinkField_Result.CityID;
						lkCityInfoViewModel.Selected = false;
					}
					else
					{
						lkCityInfoViewModel.CityID = 0;
						lkCityInfoViewModel.Selected = true;
					}
					list.Add(lkCityInfoViewModel);
					num++;
				}
			}
			lkCityInfoViewModelObjects.lst = list;
			lkCityInfoViewModelObjects.FilteredLst = list;
			lkCityInfoViewModelObjects.Json = Json(list, JsonRequestBehavior.AllowGet);
			lkCityInfoViewModelObjects.SerializedJson = JsonConvert.SerializeObject(list);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return lkCityInfoViewModelObjects;
	}

	public LkListCityInfoViewModel SepidarCityList(int provinceId, int linkAccSettingDBId)
	{
		LkListCityInfoViewModel lkListCityInfoViewModel = new LkListCityInfoViewModel();
		lkListCityInfoViewModel.Lst = new List<LkCityInfoViewModel>();
		lkListCityInfoViewModel.LstSelectListItem = new List<SelectListItem>();
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
			LkCityInfoViewModelObjects sepidarCityList = GetSepidarCityList(provinceId, linkAccSettingDBId);
			if (sepidarCityList != null)
			{
				List<LkCityInfoViewModel> lst = sepidarCityList.lst;
				if (lst != null && Enumerable.Any<LkCityInfoViewModel>((IEnumerable<LkCityInfoViewModel>)lst))
				{
					new List<SelectListItem>();
					foreach (LkCityInfoViewModel item in lst)
					{
						LkCityInfoViewModel lkCityInfoViewModel = new LkCityInfoViewModel();
						lkCityInfoViewModel.City = item.City ?? "";
						lkCityInfoViewModel.LinkAccCityIdStr = item.LinkAccCityIdStr ?? "";
						lkCityInfoViewModel.City = item.City ?? "";
						lkCityInfoViewModel.CityID = item.CityID;
						lkCityInfoViewModel.ProvinceId = item.ProvinceId;
						lkCityInfoViewModel.ProvinceName = item.ProvinceName;
						lkListCityInfoViewModel.Lst.Add(lkCityInfoViewModel);
						lkListCityInfoViewModel.LstSelectListItem.Add(new SelectListItem
						{
							Value = lkCityInfoViewModel.LinkAccCityIdStr,
							Text = ((!string.IsNullOrWhiteSpace(lkCityInfoViewModel.ProvinceName)) ? lkCityInfoViewModel.ProvinceName : "") + ((!string.IsNullOrWhiteSpace(lkCityInfoViewModel.ProvinceName) && !string.IsNullOrWhiteSpace(lkCityInfoViewModel.City)) ? " - " : "") + ((!string.IsNullOrWhiteSpace(lkCityInfoViewModel.City)) ? lkCityInfoViewModel.City : ""),
							Selected = false
						});
					}
				}
			}
			lkListCityInfoViewModel.IsDone = true;
			lkListCityInfoViewModel.Message = "";
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			lkListCityInfoViewModel.IsDone = false;
			lkListCityInfoViewModel.Message = "Error: " + ex.Message;
		}
		base.ViewBag.LinkAccCityListJs = JsonConvert.SerializeObject(lkListCityInfoViewModel.Lst);
		base.ViewBag.LinkAccCitySelectListJs = JsonConvert.SerializeObject(lkListCityInfoViewModel.LstSelectListItem);
		base.ViewBag.LinkAccCityList = lkListCityInfoViewModel;
		return lkListCityInfoViewModel;
	}

	public bool SepidarLinkedCityAcc(int linkAccSettingDBId)
	{
		bool result = false;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			short value3 = short.Parse(Financial.Get().Id.ToString());
			int userId = UserLogin.CurrentUser.UserId;
			mct_Link_Result mct_Link_Result = Enumerable.FirstOrDefault<mct_Link_Result>((IEnumerable<mct_Link_Result>)_dbLink.CRMspLkSepLinkedCity(userId, value2, value3, value, registerDatePersian, appType, linkAccSettingDBId));
			if (mct_Link_Result != null)
			{
				int result3 = 0;
				int.TryParse(mct_Link_Result.Result.ToString(), out result3);
				if (result3 > 0)
				{
					result = true;
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public LkCityInfoViewModelObjects GetNoAvaranCapillaryCityList(int provinceId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		LkCityInfoViewModelObjects lkCityInfoViewModelObjects = new LkCityInfoViewModelObjects();
		lkCityInfoViewModelObjects.lst = new List<LkCityInfoViewModel>();
		lkCityInfoViewModelObjects.FilteredLst = new List<LkCityInfoViewModel>();
		List<LkCityInfoViewModel> list = new List<LkCityInfoViewModel>();
		try
		{
			CRMIdeal.Classes.Helper.OtherSystems.NoAvaranCapillarySettingViewModel noAvaranCapillarySetting = CRMIdeal.Classes.Helper.OtherSystems.GetNoAvaranCapillarySetting();
			if (noAvaranCapillarySetting != null)
			{
				string text = noAvaranCapillarySetting.ApiUserId ?? "";
				if (!string.IsNullOrWhiteSpace(text))
				{
					List<CRMspSelectCityWithAccLinkField_Result> list2 = Enumerable.ToList<CRMspSelectCityWithAccLinkField_Result>((IEnumerable<CRMspSelectCityWithAccLinkField_Result>)_dbLink.CRMspSelectCityWithAccLinkField(true, lCID, result, false));
					List<SelectListItem> noAvaranCapillaryProvinceList = GetNoAvaranCapillaryProvinceList();
					string value = new CommercialSoapClient().ReadFromCity("", text, (provinceId == 0) ? "" : provinceId.ToString());
					if (!string.IsNullOrWhiteSpace(value))
					{
						value = value.ClearHiddenCharacters();
					}
					if (!string.IsNullOrWhiteSpace(value))
					{
						List<NoAvaranCapillaryCityInfoViewModel> list3 = JsonConvert.DeserializeObject<List<NoAvaranCapillaryCityInfoViewModel>>(value);
						if (list3 != null && Enumerable.Any<NoAvaranCapillaryCityInfoViewModel>((IEnumerable<NoAvaranCapillaryCityInfoViewModel>)list3))
						{
							int num = 1;
							foreach (NoAvaranCapillaryCityInfoViewModel item in list3)
							{
								LkCityInfoViewModel vm = new LkCityInfoViewModel();
								vm.City = item.Name ?? "";
								vm.CityCode = item.Code;
								vm.LinkAccCityIdStr = item.id.GetValueOrDefault().ToString();
								vm.ProvinceId = int.Parse(item.idProvince.GetValueOrDefault().ToString());
								if (noAvaranCapillaryProvinceList != null && vm.ProvinceId != 0 && Enumerable.Any<SelectListItem>((IEnumerable<SelectListItem>)noAvaranCapillaryProvinceList))
								{
									SelectListItem selectListItem = Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)noAvaranCapillaryProvinceList, (Func<SelectListItem, bool>)((SelectListItem m) => m.Value == vm.ProvinceId.ToString()));
									if (selectListItem != null)
									{
										vm.ProvinceName = selectListItem.Text ?? "";
									}
								}
								vm.RowNumber = num;
								if (list2 != null && Enumerable.Any<CRMspSelectCityWithAccLinkField_Result>((IEnumerable<CRMspSelectCityWithAccLinkField_Result>)list2))
								{
									CRMspSelectCityWithAccLinkField_Result cRMspSelectCityWithAccLinkField_Result = Enumerable.FirstOrDefault<CRMspSelectCityWithAccLinkField_Result>((IEnumerable<CRMspSelectCityWithAccLinkField_Result>)list2, (Func<CRMspSelectCityWithAccLinkField_Result, bool>)((CRMspSelectCityWithAccLinkField_Result x) => x.LinkAccCityIdStr == vm.LinkAccCityIdStr));
									if (cRMspSelectCityWithAccLinkField_Result != null && !string.IsNullOrWhiteSpace(cRMspSelectCityWithAccLinkField_Result.LinkAccCityIdStr))
									{
										vm.CityID = cRMspSelectCityWithAccLinkField_Result.CityID;
										vm.Selected = false;
									}
									else
									{
										vm.CityID = 0;
										vm.Selected = true;
									}
								}
								list.Add(vm);
								num++;
							}
						}
					}
				}
			}
			lkCityInfoViewModelObjects.lst = list;
			lkCityInfoViewModelObjects.FilteredLst = list;
			lkCityInfoViewModelObjects.Json = Json(list, JsonRequestBehavior.AllowGet);
			lkCityInfoViewModelObjects.SerializedJson = JsonConvert.SerializeObject(list);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return lkCityInfoViewModelObjects;
	}

	public List<SelectListItem> GetNoAvaranCapillaryProvinceList()
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
			CRMIdeal.Classes.Helper.OtherSystems.NoAvaranCapillarySettingViewModel noAvaranCapillarySetting = CRMIdeal.Classes.Helper.OtherSystems.GetNoAvaranCapillarySetting();
			if (noAvaranCapillarySetting != null)
			{
				string text = noAvaranCapillarySetting.ApiUserId ?? "";
				if (!string.IsNullOrWhiteSpace(text))
				{
					string value = new CommercialSoapClient().ReadFromProvince("", text);
					if (!string.IsNullOrWhiteSpace(value))
					{
						value = value.ClearHiddenCharacters();
					}
					if (!string.IsNullOrWhiteSpace(value))
					{
						List<NoAvaranCapillaryProvinceInfoViewModel> list2 = JsonConvert.DeserializeObject<List<NoAvaranCapillaryProvinceInfoViewModel>>(value);
						if (list2 != null && Enumerable.Any<NoAvaranCapillaryProvinceInfoViewModel>((IEnumerable<NoAvaranCapillaryProvinceInfoViewModel>)list2))
						{
							foreach (NoAvaranCapillaryProvinceInfoViewModel item in list2)
							{
								item.id = item.id;
								item.Name = item.Name.TrimEnd(new char[1] { ' ' });
							}
							list.AddRange(Enumerable.Select<NoAvaranCapillaryProvinceInfoViewModel, SelectListItem>((IEnumerable<NoAvaranCapillaryProvinceInfoViewModel>)list2, (Func<NoAvaranCapillaryProvinceInfoViewModel, SelectListItem>)((NoAvaranCapillaryProvinceInfoViewModel item) => new SelectListItem
							{
								Text = (item.Name ?? ""),
								Value = item.id.GetValueOrDefault().ToString(),
								Selected = false
							})));
						}
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	public LkCityInfoViewModelObjects GetNilramCityList(int provinceId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		LkCityInfoViewModelObjects lkCityInfoViewModelObjects = new LkCityInfoViewModelObjects();
		lkCityInfoViewModelObjects.lst = new List<LkCityInfoViewModel>();
		lkCityInfoViewModelObjects.FilteredLst = new List<LkCityInfoViewModel>();
		List<LkCityInfoViewModel> list = new List<LkCityInfoViewModel>();
		try
		{
			List<NilramCountryInfoViewModel> list2 = new CountryController().GetNilramCountryProvinceCityList();
			if (list2 != null && Enumerable.Any<NilramCountryInfoViewModel>((IEnumerable<NilramCountryInfoViewModel>)list2))
			{
				if (provinceId != 0)
				{
					list2 = Enumerable.ToList<NilramCountryInfoViewModel>(Enumerable.Where<NilramCountryInfoViewModel>((IEnumerable<NilramCountryInfoViewModel>)list2, (Func<NilramCountryInfoViewModel, bool>)((NilramCountryInfoViewModel m) => m.CITY_CD.GetValueOrDefault() == provinceId)));
				}
				if (list2 != null && Enumerable.Any<NilramCountryInfoViewModel>((IEnumerable<NilramCountryInfoViewModel>)list2))
				{
					List<CRMspSelectCityWithAccLinkField_Result> list3 = Enumerable.ToList<CRMspSelectCityWithAccLinkField_Result>((IEnumerable<CRMspSelectCityWithAccLinkField_Result>)_dbLink.CRMspSelectCityWithAccLinkField(true, lCID, result, false));
					int num = 1;
					foreach (NilramCountryInfoViewModel item in list2)
					{
						bool flag = true;
						if (list != null && Enumerable.Any<LkCityInfoViewModel>((IEnumerable<LkCityInfoViewModel>)list))
						{
							LkCityInfoViewModel lkCityInfoViewModel = Enumerable.FirstOrDefault<LkCityInfoViewModel>((IEnumerable<LkCityInfoViewModel>)list, (Func<LkCityInfoViewModel, bool>)((LkCityInfoViewModel m) => m.LinkAccCityIdStr == item.CITY_CD2.GetValueOrDefault().ToString() && m.ProvinceId == item.CITY_CD.GetValueOrDefault()));
							if (lkCityInfoViewModel != null && !string.IsNullOrWhiteSpace(lkCityInfoViewModel.LinkAccCityIdStr))
							{
								flag = false;
							}
						}
						if (!flag)
						{
							continue;
						}
						LkCityInfoViewModel vm = new LkCityInfoViewModel();
						vm.City = item.CITY2_DSC ?? "";
						vm.LinkAccCityIdStr = item.CITY_CD2.GetValueOrDefault().ToString();
						vm.ProvinceId = int.Parse(item.CITY_CD.GetValueOrDefault().ToString());
						vm.ProvinceName = item.CITY_DSC ?? "";
						vm.RowNumber = num;
						if (list3 != null && Enumerable.Any<CRMspSelectCityWithAccLinkField_Result>((IEnumerable<CRMspSelectCityWithAccLinkField_Result>)list3))
						{
							CRMspSelectCityWithAccLinkField_Result cRMspSelectCityWithAccLinkField_Result = Enumerable.FirstOrDefault<CRMspSelectCityWithAccLinkField_Result>((IEnumerable<CRMspSelectCityWithAccLinkField_Result>)list3, (Func<CRMspSelectCityWithAccLinkField_Result, bool>)((CRMspSelectCityWithAccLinkField_Result x) => x.LinkAccCityIdStr == vm.LinkAccCityIdStr));
							if (cRMspSelectCityWithAccLinkField_Result != null && !string.IsNullOrWhiteSpace(cRMspSelectCityWithAccLinkField_Result.LinkAccCityIdStr))
							{
								vm.CityID = cRMspSelectCityWithAccLinkField_Result.CityID;
								vm.Selected = false;
							}
							else
							{
								vm.CityID = 0;
								vm.Selected = true;
							}
						}
						list.Add(vm);
						num++;
					}
				}
			}
			lkCityInfoViewModelObjects.lst = list;
			lkCityInfoViewModelObjects.FilteredLst = list;
			lkCityInfoViewModelObjects.Json = Json(list, JsonRequestBehavior.AllowGet);
			lkCityInfoViewModelObjects.SerializedJson = JsonConvert.SerializeObject(list);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return lkCityInfoViewModelObjects;
	}

	public List<SelectListItem> GetNilramProvinceList()
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
			LkProvinceInfoViewModelObjects nilramProvinceList = new ProvinceController().GetNilramProvinceList();
			if (nilramProvinceList != null)
			{
				List<LkProvinceInfoViewModel> lst = nilramProvinceList.lst;
				if (lst != null && Enumerable.Any<LkProvinceInfoViewModel>((IEnumerable<LkProvinceInfoViewModel>)lst))
				{
					list.AddRange(Enumerable.Select<LkProvinceInfoViewModel, SelectListItem>((IEnumerable<LkProvinceInfoViewModel>)lst, (Func<LkProvinceInfoViewModel, SelectListItem>)((LkProvinceInfoViewModel item) => new SelectListItem
					{
						Text = (item.Province ?? "").TrimEnd(new char[1] { ' ' }),
						Value = (item.LinkAccProvinceIdStr ?? ""),
						Selected = false
					})));
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	public LkCityInfoViewModelObjects GetHamyarCityList(string provinceCode)
	{
		LkCityInfoViewModelObjects lkCityInfoViewModelObjects = new LkCityInfoViewModelObjects();
		lkCityInfoViewModelObjects.lst = new List<LkCityInfoViewModel>();
		lkCityInfoViewModelObjects.FilteredLst = new List<LkCityInfoViewModel>();
		if (provinceCode == "0" || provinceCode == "")
		{
			lkCityInfoViewModelObjects.lst.AddRange(new CRMIdeal.Classes.Helper.OtherSystems.HamyarProvider(false).GetCities(readAllDbProvinces: true));
		}
		else
		{
			lkCityInfoViewModelObjects.lst.AddRange(new CRMIdeal.Classes.Helper.OtherSystems.HamyarProvider(false).GetCities(provinceCode, secRead: false, 1L));
		}
		return lkCityInfoViewModelObjects;
	}

	public LkCityInfoViewModelObjects GetRahkaranInternalSalesCityList(int provinceId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		LkCityInfoViewModelObjects lkCityInfoViewModelObjects = new LkCityInfoViewModelObjects();
		lkCityInfoViewModelObjects.lst = new List<LkCityInfoViewModel>();
		lkCityInfoViewModelObjects.FilteredLst = new List<LkCityInfoViewModel>();
		List<LkCityInfoViewModel> list = new List<LkCityInfoViewModel>();
		try
		{
			CRMIdeal.Classes.Helper.OtherSystems.RahkaranInternalSalesProvider rahkaranInternalSalesProvider = new CRMIdeal.Classes.Helper.OtherSystems.RahkaranInternalSalesProvider();
			int num = 4;
			List<RahkaranInternalSalesRegionalDivisionResponseViewModel> list2 = rahkaranInternalSalesProvider.GetRegionalDivisionList(num, provinceId);
			if (list2 == null)
			{
				num = 3;
				list2 = rahkaranInternalSalesProvider.GetRegionalDivisionList(num, provinceId);
			}
			else if (list2 != null && !Enumerable.Any<RahkaranInternalSalesRegionalDivisionResponseViewModel>((IEnumerable<RahkaranInternalSalesRegionalDivisionResponseViewModel>)list2))
			{
				num = 3;
				list2 = rahkaranInternalSalesProvider.GetRegionalDivisionList(num, provinceId);
			}
			if (list2 != null && Enumerable.Any<RahkaranInternalSalesRegionalDivisionResponseViewModel>((IEnumerable<RahkaranInternalSalesRegionalDivisionResponseViewModel>)list2) && num == 4)
			{
				List<RahkaranInternalSalesRegionalDivisionResponseViewModel> list3 = new List<RahkaranInternalSalesRegionalDivisionResponseViewModel>();
				foreach (RahkaranInternalSalesRegionalDivisionResponseViewModel item2 in list2)
				{
					if (item2.RegionalDivisionID.GetValueOrDefault() == 0L)
					{
						continue;
					}
					List<RahkaranInternalSalesRegionalDivisionResponseViewModel> regionalDivisionList = rahkaranInternalSalesProvider.GetRegionalDivisionList(3, item2.RegionalDivisionID.GetValueOrDefault());
					if (regionalDivisionList == null || !Enumerable.Any<RahkaranInternalSalesRegionalDivisionResponseViewModel>((IEnumerable<RahkaranInternalSalesRegionalDivisionResponseViewModel>)regionalDivisionList))
					{
						continue;
					}
					foreach (RahkaranInternalSalesRegionalDivisionResponseViewModel item3 in regionalDivisionList)
					{
						item3.ParentID = provinceId;
						list3.Add(item3);
					}
				}
				if (list3 != null && Enumerable.Any<RahkaranInternalSalesRegionalDivisionResponseViewModel>((IEnumerable<RahkaranInternalSalesRegionalDivisionResponseViewModel>)list3))
				{
					list2 = new List<RahkaranInternalSalesRegionalDivisionResponseViewModel>();
					list2.AddRange(list3);
				}
			}
			if (list2 != null && Enumerable.Any<RahkaranInternalSalesRegionalDivisionResponseViewModel>((IEnumerable<RahkaranInternalSalesRegionalDivisionResponseViewModel>)list2) && list2 != null && Enumerable.Any<RahkaranInternalSalesRegionalDivisionResponseViewModel>((IEnumerable<RahkaranInternalSalesRegionalDivisionResponseViewModel>)list2))
			{
				List<CRMspSelectCityWithAccLinkField_Result> list4 = Enumerable.ToList<CRMspSelectCityWithAccLinkField_Result>((IEnumerable<CRMspSelectCityWithAccLinkField_Result>)_dbLink.CRMspSelectCityWithAccLinkField(true, lCID, result, false));
				List<RahkaranInternalSalesRegionalDivisionResponseViewModel> regionalDivisionList2 = rahkaranInternalSalesProvider.GetRegionalDivisionList(2, 0L);
				int num2 = 1;
				foreach (RahkaranInternalSalesRegionalDivisionResponseViewModel item in list2)
				{
					bool flag = true;
					if (list != null && Enumerable.Any<LkCityInfoViewModel>((IEnumerable<LkCityInfoViewModel>)list))
					{
						LkCityInfoViewModel lkCityInfoViewModel = Enumerable.FirstOrDefault<LkCityInfoViewModel>((IEnumerable<LkCityInfoViewModel>)list, (Func<LkCityInfoViewModel, bool>)((LkCityInfoViewModel m) => m.LinkAccCityIdStr == item.RegionalDivisionID.GetValueOrDefault().ToString() && m.ProvinceId == item.ParentID.GetValueOrDefault()));
						if (lkCityInfoViewModel != null && !string.IsNullOrWhiteSpace(lkCityInfoViewModel.LinkAccCityIdStr))
						{
							flag = false;
						}
					}
					if (!flag)
					{
						continue;
					}
					LkCityInfoViewModel vm = new LkCityInfoViewModel();
					vm.City = item.Name ?? "";
					vm.LinkAccCityIdStr = item.RegionalDivisionID.GetValueOrDefault().ToString();
					vm.ProvinceId = int.Parse(item.ParentID.GetValueOrDefault().ToString());
					if (vm.ProvinceId != 0 && regionalDivisionList2 != null && Enumerable.Any<RahkaranInternalSalesRegionalDivisionResponseViewModel>((IEnumerable<RahkaranInternalSalesRegionalDivisionResponseViewModel>)regionalDivisionList2))
					{
						RahkaranInternalSalesRegionalDivisionResponseViewModel rahkaranInternalSalesRegionalDivisionResponseViewModel = Enumerable.FirstOrDefault<RahkaranInternalSalesRegionalDivisionResponseViewModel>((IEnumerable<RahkaranInternalSalesRegionalDivisionResponseViewModel>)regionalDivisionList2, (Func<RahkaranInternalSalesRegionalDivisionResponseViewModel, bool>)((RahkaranInternalSalesRegionalDivisionResponseViewModel m) => m.RegionalDivisionID.GetValueOrDefault() == vm.ProvinceId));
						if (rahkaranInternalSalesRegionalDivisionResponseViewModel != null)
						{
							vm.ProvinceName = rahkaranInternalSalesRegionalDivisionResponseViewModel.Name ?? "";
						}
					}
					vm.RowNumber = num2;
					if (list4 != null && Enumerable.Any<CRMspSelectCityWithAccLinkField_Result>((IEnumerable<CRMspSelectCityWithAccLinkField_Result>)list4))
					{
						CRMspSelectCityWithAccLinkField_Result cRMspSelectCityWithAccLinkField_Result = Enumerable.FirstOrDefault<CRMspSelectCityWithAccLinkField_Result>((IEnumerable<CRMspSelectCityWithAccLinkField_Result>)list4, (Func<CRMspSelectCityWithAccLinkField_Result, bool>)((CRMspSelectCityWithAccLinkField_Result x) => x.LinkAccCityIdStr == vm.LinkAccCityIdStr));
						if (cRMspSelectCityWithAccLinkField_Result != null && !string.IsNullOrWhiteSpace(cRMspSelectCityWithAccLinkField_Result.LinkAccCityIdStr))
						{
							vm.CityID = cRMspSelectCityWithAccLinkField_Result.CityID;
							vm.Selected = false;
						}
						else
						{
							vm.CityID = 0;
							vm.Selected = true;
						}
					}
					list.Add(vm);
					num2++;
				}
			}
			lkCityInfoViewModelObjects.lst = list;
			lkCityInfoViewModelObjects.FilteredLst = list;
			lkCityInfoViewModelObjects.Json = Json(list, JsonRequestBehavior.AllowGet);
			lkCityInfoViewModelObjects.SerializedJson = JsonConvert.SerializeObject(list);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return lkCityInfoViewModelObjects;
	}

	public LkCityInfoViewModelObjects GetArianSystemCityList(int provinceId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		LkCityInfoViewModelObjects lkCityInfoViewModelObjects = new LkCityInfoViewModelObjects();
		lkCityInfoViewModelObjects.lst = new List<LkCityInfoViewModel>();
		lkCityInfoViewModelObjects.FilteredLst = new List<LkCityInfoViewModel>();
		List<LkCityInfoViewModel> list = new List<LkCityInfoViewModel>();
		try
		{
			CRMIdeal.Classes.Helper.OtherSystems.ArianSystemProvider arianSystemProvider = new CRMIdeal.Classes.Helper.OtherSystems.ArianSystemProvider();
			List<ArianSystemLocationListResponseViewModel> list2 = new List<ArianSystemLocationListResponseViewModel>();
			if (provinceId != 0)
			{
				list2 = arianSystemProvider.GetLocationList(provinceId);
			}
			else
			{
				List<ArianSystemLocationListResponseViewModel> locationList = arianSystemProvider.GetLocationList(0L);
				List<ArianSystemLocationListResponseViewModel> list3 = new List<ArianSystemLocationListResponseViewModel>();
				if (locationList != null && Enumerable.Any<ArianSystemLocationListResponseViewModel>((IEnumerable<ArianSystemLocationListResponseViewModel>)locationList))
				{
					foreach (ArianSystemLocationListResponseViewModel item2 in locationList)
					{
						int result2 = 0;
						int.TryParse(item2.LocationID.ToString(), out result2);
						if (result2 != 0)
						{
							List<ArianSystemLocationListResponseViewModel> locationList2 = arianSystemProvider.GetLocationList(result2);
							if (locationList2 != null && Enumerable.Any<ArianSystemLocationListResponseViewModel>((IEnumerable<ArianSystemLocationListResponseViewModel>)locationList2))
							{
								list3.AddRange(locationList2);
							}
						}
					}
				}
				if (list3 != null && Enumerable.Any<ArianSystemLocationListResponseViewModel>((IEnumerable<ArianSystemLocationListResponseViewModel>)list3))
				{
					foreach (ArianSystemLocationListResponseViewModel item3 in list3)
					{
						int result3 = 0;
						int.TryParse(item3.LocationID.ToString(), out result3);
						if (result3 != 0)
						{
							List<ArianSystemLocationListResponseViewModel> locationList3 = arianSystemProvider.GetLocationList(result3);
							if (locationList3 != null && Enumerable.Any<ArianSystemLocationListResponseViewModel>((IEnumerable<ArianSystemLocationListResponseViewModel>)locationList3))
							{
								list2.AddRange(locationList3);
							}
						}
					}
				}
			}
			if (list2 != null && Enumerable.Any<ArianSystemLocationListResponseViewModel>((IEnumerable<ArianSystemLocationListResponseViewModel>)list2) && list2 != null && Enumerable.Any<ArianSystemLocationListResponseViewModel>((IEnumerable<ArianSystemLocationListResponseViewModel>)list2))
			{
				List<CRMspSelectCityWithAccLinkField_Result> list4 = Enumerable.ToList<CRMspSelectCityWithAccLinkField_Result>((IEnumerable<CRMspSelectCityWithAccLinkField_Result>)_dbLink.CRMspSelectCityWithAccLinkField(true, lCID, result, false));
				int num = 1;
				foreach (ArianSystemLocationListResponseViewModel item in list2)
				{
					bool flag = true;
					if (list != null && Enumerable.Any<LkCityInfoViewModel>((IEnumerable<LkCityInfoViewModel>)list))
					{
						LkCityInfoViewModel lkCityInfoViewModel = Enumerable.FirstOrDefault<LkCityInfoViewModel>((IEnumerable<LkCityInfoViewModel>)list, (Func<LkCityInfoViewModel, bool>)((LkCityInfoViewModel m) => m.LinkAccCityIdStr == item.LocationID.GetValueOrDefault().ToString() && m.ProvinceId == item.FatherLocationID.GetValueOrDefault()));
						if (lkCityInfoViewModel != null && !string.IsNullOrWhiteSpace(lkCityInfoViewModel.LinkAccCityIdStr))
						{
							flag = false;
						}
					}
					if (!flag)
					{
						continue;
					}
					LkCityInfoViewModel vm = new LkCityInfoViewModel();
					vm.City = item.LocationDesc ?? "";
					vm.LinkAccCityIdStr = item.LocationID.GetValueOrDefault().ToString();
					vm.ProvinceId = int.Parse(item.FatherLocationID.GetValueOrDefault().ToString());
					vm.ProvinceName = item.FatherName ?? "";
					vm.CityCode = item.LocationCode ?? "";
					vm.RowNumber = num;
					if (list4 != null && Enumerable.Any<CRMspSelectCityWithAccLinkField_Result>((IEnumerable<CRMspSelectCityWithAccLinkField_Result>)list4))
					{
						CRMspSelectCityWithAccLinkField_Result cRMspSelectCityWithAccLinkField_Result = Enumerable.FirstOrDefault<CRMspSelectCityWithAccLinkField_Result>((IEnumerable<CRMspSelectCityWithAccLinkField_Result>)list4, (Func<CRMspSelectCityWithAccLinkField_Result, bool>)((CRMspSelectCityWithAccLinkField_Result x) => x.LinkAccCityIdStr == vm.LinkAccCityIdStr));
						if (cRMspSelectCityWithAccLinkField_Result != null && !string.IsNullOrWhiteSpace(cRMspSelectCityWithAccLinkField_Result.LinkAccCityIdStr))
						{
							vm.CityID = cRMspSelectCityWithAccLinkField_Result.CityID;
							vm.Selected = false;
						}
						else
						{
							vm.CityID = 0;
							vm.Selected = true;
						}
					}
					list.Add(vm);
					num++;
				}
			}
			lkCityInfoViewModelObjects.lst = list;
			lkCityInfoViewModelObjects.FilteredLst = list;
			lkCityInfoViewModelObjects.Json = Json(list, JsonRequestBehavior.AllowGet);
			lkCityInfoViewModelObjects.SerializedJson = JsonConvert.SerializeObject(list);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return lkCityInfoViewModelObjects;
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbLink.Dispose();
		_db_I.Dispose();
		base.Dispose(disposing);
	}
}
