using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CRM.Models;
using CRM.OtherWebServices.LinkNoAvaranCapillary;
using CRM.Resources;
using CRMIdeal.Areas.Setting.Controllers;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.OtherSystems.Controllers;

public class CountryController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMLinkSpEntities _dbLink = new CRMLinkSpEntities();

	private readonly CRMSpIEntities _db_I = new CRMSpIEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	[LoginAuthorize]
	public ActionResult ManageCountryLinkAcc(int linkAccSystemId, int position = 0)
	{
		string text = "";
		string text2 = "";
		switch (position)
		{
		case 0:
			text = "frmDefineCountry";
			text2 = "actManageCountryLinkAcc";
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

	public ActionResult _PartialLoadManageCountryLinkAcc(int linkAccSystemId, int linkAccSettingDBId)
	{
		GetCrmCountryList(linkAccSystemId, linkAccSettingDBId);
		if (linkAccSystemId == 1)
		{
			SepidarCountryList(linkAccSettingDBId);
		}
		else
		{
			OtherLinkAccCountryList(linkAccSystemId);
		}
		base.ViewBag.LinkAccSystemId = linkAccSystemId;
		return PartialView();
	}

	[HttpPost]
	public string ManageSyncCountry(string jsData, int linkAccSettingDBId)
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
						_dbLink.CRMspLkUpdateCountryLinkAccByJson(itemJson, userId, value3, value2, value, registerDatePersian, appType, objectParameter, linkAccSettingDBId);
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
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("Country");
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
	public JsonResult ActLinkedCountryAcc(int linkAccSystemId, int linkAccSettingDBId)
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
			if (!UserLogin.IsUserAccess("frmManageCountryLinkAcc", "actLinkWithAcc", UserLogin.CurrentUser))
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
			if ((linkAccSystemId != 1) ? OtherLinkedCountryAcc(linkAccSystemId) : SepidarLinkedCountryAcc(linkAccSettingDBId))
			{
				text = "";
				commonResultStatusViewModel = CommonResultStatusViewModel.Success;
				text2 = Messages.msgSuccessAction;
				CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("Country");
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
	public string GetManageLinkedCountryList(int linkAccSystemId, int linkAccSettingDBId)
	{
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectCountryWithAccLinkField_Result> list = Enumerable.ToList<CRMspSelectCountryWithAccLinkField_Result>((IEnumerable<CRMspSelectCountryWithAccLinkField_Result>)_dbLink.CRMspSelectCountryWithAccLinkField(true, lCID, result2, true));
			if (linkAccSystemId == 1 && list != null && Enumerable.Any<CRMspSelectCountryWithAccLinkField_Result>((IEnumerable<CRMspSelectCountryWithAccLinkField_Result>)list))
			{
				foreach (CRMspSelectCountryWithAccLinkField_Result item in list)
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
							item.LinkAccCountryIdStr = linkAccDataViewModel.Id ?? "";
							item.LinkAccData = "";
						}
					}
				}
				list = Enumerable.ToList<CRMspSelectCountryWithAccLinkField_Result>(Enumerable.Where<CRMspSelectCountryWithAccLinkField_Result>((IEnumerable<CRMspSelectCountryWithAccLinkField_Result>)list, (Func<CRMspSelectCountryWithAccLinkField_Result, bool>)((CRMspSelectCountryWithAccLinkField_Result m) => (m.LinkAccCountryIdStr ?? "") != "")));
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

	public LkListCountryInfoViewModel GetCrmCountryList(int linkAccSystemId, int linkAccSettingDBId)
	{
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		LkListCountryInfoViewModel lkListCountryInfoViewModel = new LkListCountryInfoViewModel();
		try
		{
			_ = UserLogin.CurrentUser.UserId;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectCountry_Result> list = Enumerable.ToList<CRMspSelectCountry_Result>((IEnumerable<CRMspSelectCountry_Result>)_db.CRMspSelectCountry(lCID, result));
			if (linkAccSystemId == 1 && list != null && Enumerable.Any<CRMspSelectCountry_Result>((IEnumerable<CRMspSelectCountry_Result>)list))
			{
				foreach (CRMspSelectCountry_Result item in list)
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
							item.LinkAccCountryIdStr = linkAccDataViewModel.Id ?? "";
							item.LinkAccData = "";
						}
					}
				}
			}
			if (list != null && list.Count > 0)
			{
				List<LkCountryInfoViewModel> list3 = new List<LkCountryInfoViewModel>();
				List<SelectListItem> list4 = new List<SelectListItem>();
				foreach (CRMspSelectCountry_Result item2 in list)
				{
					list3.Add(new LkCountryInfoViewModel
					{
						CountryID = item2.CountryID,
						Country = item2.Country,
						CountryCode = item2.CountryCode,
						CountryDescription = item2.CountryDescription,
						LinkAccCountryIdStr = item2.LinkAccCountryIdStr
					});
					list4.Add(new SelectListItem
					{
						Value = item2.CountryID.ToString(),
						Text = item2.Country,
						Selected = false
					});
				}
				lkListCountryInfoViewModel.Lst = list3;
				lkListCountryInfoViewModel.LstSelectListItem = list4;
			}
			lkListCountryInfoViewModel.IsDone = true;
			lkListCountryInfoViewModel.Message = "";
		}
		catch (Exception ex)
		{
			lkListCountryInfoViewModel.IsDone = false;
			lkListCountryInfoViewModel.Message = "Error: " + ex.Message;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		base.ViewBag.CrmCountryListJs = JsonConvert.SerializeObject(lkListCountryInfoViewModel.Lst);
		base.ViewBag.CrmCountrySelectListJs = JsonConvert.SerializeObject(lkListCountryInfoViewModel.LstSelectListItem);
		base.ViewBag.CrmCountryList = lkListCountryInfoViewModel;
		return lkListCountryInfoViewModel;
	}

	public LkListCountryInfoViewModel OtherLinkAccCountryList(int linkAccSystemId)
	{
		LkListCountryInfoViewModel lkListCountryInfoViewModel = new LkListCountryInfoViewModel();
		lkListCountryInfoViewModel.Lst = new List<LkCountryInfoViewModel>();
		lkListCountryInfoViewModel.LstSelectListItem = new List<SelectListItem>();
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
			LkCountryInfoViewModelObjects lkCountryInfoViewModelObjects = new LkCountryInfoViewModelObjects();
			switch (linkAccSystemId)
			{
			case 18:
				lkCountryInfoViewModelObjects = GetNoAvaranCapillaryCountryList();
				break;
			case 20:
				lkCountryInfoViewModelObjects = GetNilramCountryList();
				break;
			case 21:
				lkCountryInfoViewModelObjects = GetHamyarCountryList();
				break;
			case 22:
				lkCountryInfoViewModelObjects = GetRahkaranInternalSalesCountryList();
				break;
			case 25:
				lkCountryInfoViewModelObjects = GetArianSystemCountryList();
				break;
			}
			if (lkCountryInfoViewModelObjects != null && lkCountryInfoViewModelObjects.lst != null)
			{
				List<LkCountryInfoViewModel> lst = lkCountryInfoViewModelObjects.lst;
				if (lst != null && Enumerable.Any<LkCountryInfoViewModel>((IEnumerable<LkCountryInfoViewModel>)lst))
				{
					new List<SelectListItem>();
					foreach (LkCountryInfoViewModel item in lst)
					{
						LkCountryInfoViewModel lkCountryInfoViewModel = new LkCountryInfoViewModel();
						lkCountryInfoViewModel.Country = item.Country ?? "";
						lkCountryInfoViewModel.LinkAccCountryIdStr = item.LinkAccCountryIdStr ?? "";
						lkCountryInfoViewModel.Country = item.Country ?? "";
						lkCountryInfoViewModel.CountryID = item.CountryID;
						lkCountryInfoViewModel.CountryCode = item.CountryCode;
						lkListCountryInfoViewModel.Lst.Add(lkCountryInfoViewModel);
						lkListCountryInfoViewModel.LstSelectListItem.Add(new SelectListItem
						{
							Value = lkCountryInfoViewModel.LinkAccCountryIdStr,
							Text = lkCountryInfoViewModel.Country,
							Selected = false
						});
					}
				}
			}
			lkListCountryInfoViewModel.IsDone = true;
			lkListCountryInfoViewModel.Message = "";
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			lkListCountryInfoViewModel.IsDone = false;
			lkListCountryInfoViewModel.Message = "Error: " + ex.Message;
		}
		base.ViewBag.LinkAccCountryListJs = JsonConvert.SerializeObject(lkListCountryInfoViewModel.Lst);
		base.ViewBag.LinkAccCountrySelectListJs = JsonConvert.SerializeObject(lkListCountryInfoViewModel.LstSelectListItem);
		base.ViewBag.LinkAccCountryList = lkListCountryInfoViewModel;
		return lkListCountryInfoViewModel;
	}

	public bool OtherLinkedCountryAcc(int linkAccSystemId)
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
			LkListCountryInfoViewModel lkListCountryInfoViewModel = OtherLinkAccCountryList(linkAccSystemId);
			if (lkListCountryInfoViewModel != null && lkListCountryInfoViewModel.Lst != null && Enumerable.Any<LkCountryInfoViewModel>((IEnumerable<LkCountryInfoViewModel>)lkListCountryInfoViewModel.Lst))
			{
				text = JsonConvert.SerializeObject(Enumerable.ToList<LkCountryInfoViewModel>((IEnumerable<LkCountryInfoViewModel>)lkListCountryInfoViewModel.Lst));
			}
			if (!string.IsNullOrWhiteSpace(text))
			{
				mct_Link_Result mct_Link_Result = Enumerable.FirstOrDefault<mct_Link_Result>((IEnumerable<mct_Link_Result>)_dbLink.CRMspLkLinkedCountry(linkAccSystemId, text, userId, value2, value3, value, registerDatePersian, appType));
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

	public LkCountryInfoViewModelObjects GetSepidarCountryList(int linkAccSettingDBId)
	{
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		LkCountryInfoViewModelObjects lkCountryInfoViewModelObjects = new LkCountryInfoViewModelObjects();
		lkCountryInfoViewModelObjects.lst = new List<LkCountryInfoViewModel>();
		lkCountryInfoViewModelObjects.FilteredLst = new List<LkCountryInfoViewModel>();
		List<LkCountryInfoViewModel> list = new List<LkCountryInfoViewModel>();
		try
		{
			List<CRMspLkSepSelectLocation_Result> list2 = Enumerable.ToList<CRMspLkSepSelectLocation_Result>((IEnumerable<CRMspLkSepSelectLocation_Result>)_dbLink.CRMspLkSepSelectLocation("1", linkAccSettingDBId, lCID, result));
			if (list2 != null && Enumerable.Any<CRMspLkSepSelectLocation_Result>((IEnumerable<CRMspLkSepSelectLocation_Result>)list2))
			{
				List<CRMspSelectCountryWithAccLinkField_Result> list3 = Enumerable.ToList<CRMspSelectCountryWithAccLinkField_Result>((IEnumerable<CRMspSelectCountryWithAccLinkField_Result>)_dbLink.CRMspSelectCountryWithAccLinkField(true, lCID, result, true));
				int result2 = 0;
				CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
				if (cRMspSelectCrmsysSetting_Result != null)
				{
					int.TryParse(cRMspSelectCrmsysSetting_Result.LinkAccSystemId.ToString(), out result2);
				}
				if (result2 == 1 && list3 != null && Enumerable.Any<CRMspSelectCountryWithAccLinkField_Result>((IEnumerable<CRMspSelectCountryWithAccLinkField_Result>)list3))
				{
					foreach (CRMspSelectCountryWithAccLinkField_Result item2 in list3)
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
								item2.LinkAccCountryIdStr = linkAccDataViewModel.Id ?? "";
								item2.LinkAccData = "";
							}
						}
					}
				}
				int num = 1;
				foreach (CRMspLkSepSelectLocation_Result item in list2)
				{
					LkCountryInfoViewModel lkCountryInfoViewModel = new LkCountryInfoViewModel();
					lkCountryInfoViewModel.Country = item.Title;
					lkCountryInfoViewModel.CountryCode = item.Code;
					lkCountryInfoViewModel.LinkAccCountryIdStr = item.LocationId.ToString();
					lkCountryInfoViewModel.RowNumber = num;
					CRMspSelectCountryWithAccLinkField_Result cRMspSelectCountryWithAccLinkField_Result = Enumerable.FirstOrDefault<CRMspSelectCountryWithAccLinkField_Result>((IEnumerable<CRMspSelectCountryWithAccLinkField_Result>)list3, (Func<CRMspSelectCountryWithAccLinkField_Result, bool>)((CRMspSelectCountryWithAccLinkField_Result x) => x.LinkAccCountryIdStr == item.LocationId.ToString()));
					if (cRMspSelectCountryWithAccLinkField_Result != null && !string.IsNullOrWhiteSpace(cRMspSelectCountryWithAccLinkField_Result.LinkAccCountryIdStr))
					{
						lkCountryInfoViewModel.CountryID = cRMspSelectCountryWithAccLinkField_Result.CountryID;
						lkCountryInfoViewModel.Selected = false;
					}
					else
					{
						lkCountryInfoViewModel.CountryID = 0;
						lkCountryInfoViewModel.Selected = true;
					}
					list.Add(lkCountryInfoViewModel);
					num++;
				}
			}
			lkCountryInfoViewModelObjects.lst = list;
			lkCountryInfoViewModelObjects.FilteredLst = list;
			lkCountryInfoViewModelObjects.Json = Json(list, JsonRequestBehavior.AllowGet);
			lkCountryInfoViewModelObjects.SerializedJson = JsonConvert.SerializeObject(list);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return lkCountryInfoViewModelObjects;
	}

	public LkListCountryInfoViewModel SepidarCountryList(int linkAccSettingDBId)
	{
		LkListCountryInfoViewModel lkListCountryInfoViewModel = new LkListCountryInfoViewModel();
		lkListCountryInfoViewModel.Lst = new List<LkCountryInfoViewModel>();
		lkListCountryInfoViewModel.LstSelectListItem = new List<SelectListItem>();
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
			LkCountryInfoViewModelObjects sepidarCountryList = GetSepidarCountryList(linkAccSettingDBId);
			if (sepidarCountryList != null)
			{
				List<LkCountryInfoViewModel> lst = sepidarCountryList.lst;
				if (lst != null && Enumerable.Any<LkCountryInfoViewModel>((IEnumerable<LkCountryInfoViewModel>)lst))
				{
					new List<SelectListItem>();
					foreach (LkCountryInfoViewModel item in lst)
					{
						LkCountryInfoViewModel lkCountryInfoViewModel = new LkCountryInfoViewModel();
						lkCountryInfoViewModel.Country = item.Country ?? "";
						lkCountryInfoViewModel.LinkAccCountryIdStr = item.LinkAccCountryIdStr ?? "";
						lkCountryInfoViewModel.Country = item.Country ?? "";
						lkCountryInfoViewModel.CountryID = item.CountryID;
						lkListCountryInfoViewModel.Lst.Add(lkCountryInfoViewModel);
						lkListCountryInfoViewModel.LstSelectListItem.Add(new SelectListItem
						{
							Value = lkCountryInfoViewModel.LinkAccCountryIdStr,
							Text = lkCountryInfoViewModel.Country,
							Selected = false
						});
					}
				}
			}
			lkListCountryInfoViewModel.IsDone = true;
			lkListCountryInfoViewModel.Message = "";
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			lkListCountryInfoViewModel.IsDone = false;
			lkListCountryInfoViewModel.Message = "Error: " + ex.Message;
		}
		base.ViewBag.LinkAccCountryListJs = JsonConvert.SerializeObject(lkListCountryInfoViewModel.Lst);
		base.ViewBag.LinkAccCountrySelectListJs = JsonConvert.SerializeObject(lkListCountryInfoViewModel.LstSelectListItem);
		base.ViewBag.LinkAccCountryList = lkListCountryInfoViewModel;
		return lkListCountryInfoViewModel;
	}

	public bool SepidarLinkedCountryAcc(int linkAccSettingDBId)
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
			mct_Link_Result mct_Link_Result = Enumerable.FirstOrDefault<mct_Link_Result>((IEnumerable<mct_Link_Result>)_dbLink.CRMspLkSepLinkedCountry(userId, value2, value3, value, registerDatePersian, appType, linkAccSettingDBId));
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

	public LkCountryInfoViewModelObjects GetNoAvaranCapillaryCountryList()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		LkCountryInfoViewModelObjects lkCountryInfoViewModelObjects = new LkCountryInfoViewModelObjects();
		lkCountryInfoViewModelObjects.lst = new List<LkCountryInfoViewModel>();
		lkCountryInfoViewModelObjects.FilteredLst = new List<LkCountryInfoViewModel>();
		List<LkCountryInfoViewModel> list = new List<LkCountryInfoViewModel>();
		try
		{
			CRMIdeal.Classes.Helper.OtherSystems.NoAvaranCapillarySettingViewModel noAvaranCapillarySetting = CRMIdeal.Classes.Helper.OtherSystems.GetNoAvaranCapillarySetting();
			if (noAvaranCapillarySetting != null)
			{
				string text = noAvaranCapillarySetting.ApiUserId ?? "";
				if (!string.IsNullOrWhiteSpace(text))
				{
					List<CRMspSelectCountryWithAccLinkField_Result> list2 = Enumerable.ToList<CRMspSelectCountryWithAccLinkField_Result>((IEnumerable<CRMspSelectCountryWithAccLinkField_Result>)_dbLink.CRMspSelectCountryWithAccLinkField(true, lCID, result, false));
					string value = new CommercialSoapClient().ReadFromContry("", text);
					if (!string.IsNullOrWhiteSpace(value))
					{
						value = value.ClearHiddenCharacters();
					}
					if (!string.IsNullOrWhiteSpace(value))
					{
						List<NoAvaranCapillaryCountryInfoViewModel> list3 = JsonConvert.DeserializeObject<List<NoAvaranCapillaryCountryInfoViewModel>>(value);
						if (list3 != null && Enumerable.Any<NoAvaranCapillaryCountryInfoViewModel>((IEnumerable<NoAvaranCapillaryCountryInfoViewModel>)list3))
						{
							int num = 1;
							foreach (NoAvaranCapillaryCountryInfoViewModel item in list3)
							{
								LkCountryInfoViewModel vm = new LkCountryInfoViewModel();
								vm.Country = item.Name ?? "";
								vm.CountryCode = item.Code;
								vm.LinkAccCountryIdStr = item.id.GetValueOrDefault().ToString();
								vm.RowNumber = num;
								if (list2 != null && Enumerable.Any<CRMspSelectCountryWithAccLinkField_Result>((IEnumerable<CRMspSelectCountryWithAccLinkField_Result>)list2))
								{
									CRMspSelectCountryWithAccLinkField_Result cRMspSelectCountryWithAccLinkField_Result = Enumerable.FirstOrDefault<CRMspSelectCountryWithAccLinkField_Result>((IEnumerable<CRMspSelectCountryWithAccLinkField_Result>)list2, (Func<CRMspSelectCountryWithAccLinkField_Result, bool>)((CRMspSelectCountryWithAccLinkField_Result x) => x.LinkAccCountryIdStr == vm.LinkAccCountryIdStr));
									if (cRMspSelectCountryWithAccLinkField_Result != null && !string.IsNullOrWhiteSpace(cRMspSelectCountryWithAccLinkField_Result.LinkAccCountryIdStr))
									{
										vm.CountryID = cRMspSelectCountryWithAccLinkField_Result.CountryID;
										vm.Selected = false;
									}
									else
									{
										vm.CountryID = 0;
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
			lkCountryInfoViewModelObjects.lst = list;
			lkCountryInfoViewModelObjects.FilteredLst = list;
			lkCountryInfoViewModelObjects.Json = Json(list, JsonRequestBehavior.AllowGet);
			lkCountryInfoViewModelObjects.SerializedJson = JsonConvert.SerializeObject(list);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return lkCountryInfoViewModelObjects;
	}

	public List<NilramCountryInfoViewModel> GetNilramCountryProvinceCityList()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<NilramCountryInfoViewModel> list = new List<NilramCountryInfoViewModel>();
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
					string text2 = text + "COUNTRY";
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
							List<NilramCountryInfoViewModel> list2 = JsonConvert.DeserializeObject<List<NilramCountryInfoViewModel>>(value2);
							if (list2 != null && Enumerable.Any<NilramCountryInfoViewModel>((IEnumerable<NilramCountryInfoViewModel>)list2))
							{
								list.AddRange(list2);
							}
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

	public LkCountryInfoViewModelObjects GetNilramCountryList()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		LkCountryInfoViewModelObjects lkCountryInfoViewModelObjects = new LkCountryInfoViewModelObjects();
		lkCountryInfoViewModelObjects.lst = new List<LkCountryInfoViewModel>();
		lkCountryInfoViewModelObjects.FilteredLst = new List<LkCountryInfoViewModel>();
		List<LkCountryInfoViewModel> list = new List<LkCountryInfoViewModel>();
		try
		{
			List<NilramCountryInfoViewModel> nilramCountryProvinceCityList = GetNilramCountryProvinceCityList();
			if (nilramCountryProvinceCityList != null && Enumerable.Any<NilramCountryInfoViewModel>((IEnumerable<NilramCountryInfoViewModel>)nilramCountryProvinceCityList))
			{
				List<CRMspSelectCountryWithAccLinkField_Result> list2 = Enumerable.ToList<CRMspSelectCountryWithAccLinkField_Result>((IEnumerable<CRMspSelectCountryWithAccLinkField_Result>)_dbLink.CRMspSelectCountryWithAccLinkField(true, lCID, result, false));
				int num = 1;
				foreach (NilramCountryInfoViewModel item in nilramCountryProvinceCityList)
				{
					bool flag = true;
					if (list != null && Enumerable.Any<LkCountryInfoViewModel>((IEnumerable<LkCountryInfoViewModel>)list))
					{
						LkCountryInfoViewModel lkCountryInfoViewModel = Enumerable.FirstOrDefault<LkCountryInfoViewModel>((IEnumerable<LkCountryInfoViewModel>)list, (Func<LkCountryInfoViewModel, bool>)((LkCountryInfoViewModel m) => m.LinkAccCountryIdStr == item.ID.GetValueOrDefault().ToString()));
						if (lkCountryInfoViewModel != null && !string.IsNullOrWhiteSpace(lkCountryInfoViewModel.LinkAccCountryIdStr))
						{
							flag = false;
						}
					}
					if (!flag)
					{
						continue;
					}
					LkCountryInfoViewModel vm = new LkCountryInfoViewModel();
					vm.Country = item.NAME ?? "";
					vm.LinkAccCountryIdStr = item.ID.GetValueOrDefault().ToString();
					vm.RowNumber = num;
					if (list2 != null && Enumerable.Any<CRMspSelectCountryWithAccLinkField_Result>((IEnumerable<CRMspSelectCountryWithAccLinkField_Result>)list2))
					{
						CRMspSelectCountryWithAccLinkField_Result cRMspSelectCountryWithAccLinkField_Result = Enumerable.FirstOrDefault<CRMspSelectCountryWithAccLinkField_Result>((IEnumerable<CRMspSelectCountryWithAccLinkField_Result>)list2, (Func<CRMspSelectCountryWithAccLinkField_Result, bool>)((CRMspSelectCountryWithAccLinkField_Result x) => x.LinkAccCountryIdStr == vm.LinkAccCountryIdStr));
						if (cRMspSelectCountryWithAccLinkField_Result != null && !string.IsNullOrWhiteSpace(cRMspSelectCountryWithAccLinkField_Result.LinkAccCountryIdStr))
						{
							vm.CountryID = cRMspSelectCountryWithAccLinkField_Result.CountryID;
							vm.Selected = false;
						}
						else
						{
							vm.CountryID = 0;
							vm.Selected = true;
						}
					}
					list.Add(vm);
					num++;
				}
			}
			lkCountryInfoViewModelObjects.lst = list;
			lkCountryInfoViewModelObjects.FilteredLst = list;
			lkCountryInfoViewModelObjects.Json = Json(list, JsonRequestBehavior.AllowGet);
			lkCountryInfoViewModelObjects.SerializedJson = JsonConvert.SerializeObject(list);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return lkCountryInfoViewModelObjects;
	}

	public LkCountryInfoViewModelObjects GetHamyarCountryList()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		LkCountryInfoViewModelObjects lkCountryInfoViewModelObjects = new LkCountryInfoViewModelObjects();
		lkCountryInfoViewModelObjects.lst = new List<LkCountryInfoViewModel>();
		lkCountryInfoViewModelObjects.FilteredLst = new List<LkCountryInfoViewModel>();
		List<LkCountryInfoViewModel> list = new List<LkCountryInfoViewModel>();
		try
		{
			CRMIdeal.Classes.Helper.OtherSystems.HamyarSettingViewModel hamyarSetting = CRMIdeal.Classes.Helper.OtherSystems.GetHamyarSetting();
			if (hamyarSetting != null)
			{
				string text = hamyarSetting.ApiAddress ?? "";
				string value = hamyarSetting.ApiKey ?? "";
				if (!string.IsNullOrWhiteSpace(text) && !string.IsNullOrWhiteSpace(value))
				{
					string token = new LinkAccHamyarSettingController().GetToken();
					if (!string.IsNullOrWhiteSpace(token))
					{
						if (!text.EndsWith("/"))
						{
							text += "/";
						}
						HttpClient httpClient = new HttpClient();
						string text2 = text + "getAllCountry";
						httpClient.BaseAddress = new Uri(text2);
						httpClient.DefaultRequestHeaders.Add("X-API-KEY", value);
						httpClient.DefaultRequestHeaders.Add("Authorization", token);
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
								HamyarAPIResponseViewModel<List<HamyarCountryInfoViewModel>> hamyarAPIResponseViewModel = JsonConvert.DeserializeObject<HamyarAPIResponseViewModel<List<HamyarCountryInfoViewModel>>>(value2);
								if (hamyarAPIResponseViewModel != null && hamyarAPIResponseViewModel.isSuccess.GetValueOrDefault() && hamyarAPIResponseViewModel.data != null && Enumerable.Any<HamyarCountryInfoViewModel>((IEnumerable<HamyarCountryInfoViewModel>)hamyarAPIResponseViewModel.data))
								{
									List<CRMspSelectCountryWithAccLinkField_Result> list2 = Enumerable.ToList<CRMspSelectCountryWithAccLinkField_Result>((IEnumerable<CRMspSelectCountryWithAccLinkField_Result>)_dbLink.CRMspSelectCountryWithAccLinkField(true, lCID, result, false));
									int num = 1;
									foreach (HamyarCountryInfoViewModel item in hamyarAPIResponseViewModel.data)
									{
										bool flag = true;
										if (list != null && Enumerable.Any<LkCountryInfoViewModel>((IEnumerable<LkCountryInfoViewModel>)list))
										{
											LkCountryInfoViewModel lkCountryInfoViewModel = Enumerable.FirstOrDefault<LkCountryInfoViewModel>((IEnumerable<LkCountryInfoViewModel>)list, (Func<LkCountryInfoViewModel, bool>)((LkCountryInfoViewModel m) => m.LinkAccCountryIdStr == item.code.GetValueOrDefault().ToString()));
											if (lkCountryInfoViewModel != null && !string.IsNullOrWhiteSpace(lkCountryInfoViewModel.LinkAccCountryIdStr))
											{
												flag = false;
											}
										}
										if (!flag)
										{
											continue;
										}
										LkCountryInfoViewModel vm = new LkCountryInfoViewModel();
										vm.Country = item.countyName ?? "";
										vm.LinkAccCountryIdStr = item.code.GetValueOrDefault().ToString();
										vm.RowNumber = num;
										if (list2 != null && Enumerable.Any<CRMspSelectCountryWithAccLinkField_Result>((IEnumerable<CRMspSelectCountryWithAccLinkField_Result>)list2))
										{
											CRMspSelectCountryWithAccLinkField_Result cRMspSelectCountryWithAccLinkField_Result = Enumerable.FirstOrDefault<CRMspSelectCountryWithAccLinkField_Result>((IEnumerable<CRMspSelectCountryWithAccLinkField_Result>)list2, (Func<CRMspSelectCountryWithAccLinkField_Result, bool>)((CRMspSelectCountryWithAccLinkField_Result x) => x.LinkAccCountryIdStr == vm.LinkAccCountryIdStr));
											if (cRMspSelectCountryWithAccLinkField_Result != null && !string.IsNullOrWhiteSpace(cRMspSelectCountryWithAccLinkField_Result.LinkAccCountryIdStr))
											{
												vm.CountryID = cRMspSelectCountryWithAccLinkField_Result.CountryID;
												vm.Selected = false;
											}
											else
											{
												vm.CountryID = 0;
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
				}
			}
			lkCountryInfoViewModelObjects.lst = list;
			lkCountryInfoViewModelObjects.FilteredLst = list;
			lkCountryInfoViewModelObjects.Json = Json(list, JsonRequestBehavior.AllowGet);
			lkCountryInfoViewModelObjects.SerializedJson = JsonConvert.SerializeObject(list);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return lkCountryInfoViewModelObjects;
	}

	public LkCountryInfoViewModelObjects GetRahkaranInternalSalesCountryList()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		LkCountryInfoViewModelObjects lkCountryInfoViewModelObjects = new LkCountryInfoViewModelObjects();
		lkCountryInfoViewModelObjects.lst = new List<LkCountryInfoViewModel>();
		lkCountryInfoViewModelObjects.FilteredLst = new List<LkCountryInfoViewModel>();
		List<LkCountryInfoViewModel> list = new List<LkCountryInfoViewModel>();
		try
		{
			List<RahkaranInternalSalesRegionalDivisionResponseViewModel> regionalDivisionList = new CRMIdeal.Classes.Helper.OtherSystems.RahkaranInternalSalesProvider().GetRegionalDivisionList(1, 0L);
			if (regionalDivisionList != null && Enumerable.Any<RahkaranInternalSalesRegionalDivisionResponseViewModel>((IEnumerable<RahkaranInternalSalesRegionalDivisionResponseViewModel>)regionalDivisionList))
			{
				List<CRMspSelectCountryWithAccLinkField_Result> list2 = Enumerable.ToList<CRMspSelectCountryWithAccLinkField_Result>((IEnumerable<CRMspSelectCountryWithAccLinkField_Result>)_dbLink.CRMspSelectCountryWithAccLinkField(true, lCID, result, false));
				int num = 1;
				foreach (RahkaranInternalSalesRegionalDivisionResponseViewModel item in regionalDivisionList)
				{
					bool flag = true;
					if (list != null && Enumerable.Any<LkCountryInfoViewModel>((IEnumerable<LkCountryInfoViewModel>)list))
					{
						LkCountryInfoViewModel lkCountryInfoViewModel = Enumerable.FirstOrDefault<LkCountryInfoViewModel>((IEnumerable<LkCountryInfoViewModel>)list, (Func<LkCountryInfoViewModel, bool>)((LkCountryInfoViewModel m) => m.LinkAccCountryIdStr == item.RegionalDivisionID.GetValueOrDefault().ToString()));
						if (lkCountryInfoViewModel != null && !string.IsNullOrWhiteSpace(lkCountryInfoViewModel.LinkAccCountryIdStr))
						{
							flag = false;
						}
					}
					if (!flag)
					{
						continue;
					}
					LkCountryInfoViewModel vm = new LkCountryInfoViewModel();
					vm.Country = item.Name ?? "";
					vm.LinkAccCountryIdStr = item.RegionalDivisionID.GetValueOrDefault().ToString();
					vm.RowNumber = num;
					if (list2 != null && Enumerable.Any<CRMspSelectCountryWithAccLinkField_Result>((IEnumerable<CRMspSelectCountryWithAccLinkField_Result>)list2))
					{
						CRMspSelectCountryWithAccLinkField_Result cRMspSelectCountryWithAccLinkField_Result = Enumerable.FirstOrDefault<CRMspSelectCountryWithAccLinkField_Result>((IEnumerable<CRMspSelectCountryWithAccLinkField_Result>)list2, (Func<CRMspSelectCountryWithAccLinkField_Result, bool>)((CRMspSelectCountryWithAccLinkField_Result x) => x.LinkAccCountryIdStr == vm.LinkAccCountryIdStr));
						if (cRMspSelectCountryWithAccLinkField_Result != null && !string.IsNullOrWhiteSpace(cRMspSelectCountryWithAccLinkField_Result.LinkAccCountryIdStr))
						{
							vm.CountryID = cRMspSelectCountryWithAccLinkField_Result.CountryID;
							vm.Selected = false;
						}
						else
						{
							vm.CountryID = 0;
							vm.Selected = true;
						}
					}
					list.Add(vm);
					num++;
				}
			}
			lkCountryInfoViewModelObjects.lst = list;
			lkCountryInfoViewModelObjects.FilteredLst = list;
			lkCountryInfoViewModelObjects.Json = Json(list, JsonRequestBehavior.AllowGet);
			lkCountryInfoViewModelObjects.SerializedJson = JsonConvert.SerializeObject(list);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return lkCountryInfoViewModelObjects;
	}

	public LkCountryInfoViewModelObjects GetArianSystemCountryList()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		LkCountryInfoViewModelObjects lkCountryInfoViewModelObjects = new LkCountryInfoViewModelObjects();
		lkCountryInfoViewModelObjects.lst = new List<LkCountryInfoViewModel>();
		lkCountryInfoViewModelObjects.FilteredLst = new List<LkCountryInfoViewModel>();
		List<LkCountryInfoViewModel> list = new List<LkCountryInfoViewModel>();
		try
		{
			List<ArianSystemLocationListResponseViewModel> locationList = new CRMIdeal.Classes.Helper.OtherSystems.ArianSystemProvider().GetLocationList(0L);
			if (locationList != null && Enumerable.Any<ArianSystemLocationListResponseViewModel>((IEnumerable<ArianSystemLocationListResponseViewModel>)locationList))
			{
				List<CRMspSelectCountryWithAccLinkField_Result> list2 = Enumerable.ToList<CRMspSelectCountryWithAccLinkField_Result>((IEnumerable<CRMspSelectCountryWithAccLinkField_Result>)_dbLink.CRMspSelectCountryWithAccLinkField(true, lCID, result, false));
				int num = 1;
				foreach (ArianSystemLocationListResponseViewModel item in locationList)
				{
					bool flag = true;
					if (list != null && Enumerable.Any<LkCountryInfoViewModel>((IEnumerable<LkCountryInfoViewModel>)list))
					{
						LkCountryInfoViewModel lkCountryInfoViewModel = Enumerable.FirstOrDefault<LkCountryInfoViewModel>((IEnumerable<LkCountryInfoViewModel>)list, (Func<LkCountryInfoViewModel, bool>)((LkCountryInfoViewModel m) => m.LinkAccCountryIdStr == item.LocationID.GetValueOrDefault().ToString()));
						if (lkCountryInfoViewModel != null && !string.IsNullOrWhiteSpace(lkCountryInfoViewModel.LinkAccCountryIdStr))
						{
							flag = false;
						}
					}
					if (!flag)
					{
						continue;
					}
					LkCountryInfoViewModel vm = new LkCountryInfoViewModel();
					vm.Country = item.LocationDesc ?? "";
					vm.LinkAccCountryIdStr = item.LocationID.GetValueOrDefault().ToString();
					vm.CountryCode = item.LocationCode ?? "";
					vm.RowNumber = num;
					if (list2 != null && Enumerable.Any<CRMspSelectCountryWithAccLinkField_Result>((IEnumerable<CRMspSelectCountryWithAccLinkField_Result>)list2))
					{
						CRMspSelectCountryWithAccLinkField_Result cRMspSelectCountryWithAccLinkField_Result = Enumerable.FirstOrDefault<CRMspSelectCountryWithAccLinkField_Result>((IEnumerable<CRMspSelectCountryWithAccLinkField_Result>)list2, (Func<CRMspSelectCountryWithAccLinkField_Result, bool>)((CRMspSelectCountryWithAccLinkField_Result x) => x.LinkAccCountryIdStr == vm.LinkAccCountryIdStr));
						if (cRMspSelectCountryWithAccLinkField_Result != null && !string.IsNullOrWhiteSpace(cRMspSelectCountryWithAccLinkField_Result.LinkAccCountryIdStr))
						{
							vm.CountryID = cRMspSelectCountryWithAccLinkField_Result.CountryID;
							vm.Selected = false;
						}
						else
						{
							vm.CountryID = 0;
							vm.Selected = true;
						}
					}
					list.Add(vm);
					num++;
				}
			}
			lkCountryInfoViewModelObjects.lst = list;
			lkCountryInfoViewModelObjects.FilteredLst = list;
			lkCountryInfoViewModelObjects.Json = Json(list, JsonRequestBehavior.AllowGet);
			lkCountryInfoViewModelObjects.SerializedJson = JsonConvert.SerializeObject(list);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return lkCountryInfoViewModelObjects;
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbLink.Dispose();
		_db_I.Dispose();
		base.Dispose(disposing);
	}
}
