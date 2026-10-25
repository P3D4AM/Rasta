using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using System.Web.Script.Serialization;
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

public class ProvinceController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMLinkSpEntities _dbLink = new CRMLinkSpEntities();

	private readonly CRMSpIEntities _db_I = new CRMSpIEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	[LoginAuthorize]
	public ActionResult ManageProvinceLinkAcc(int linkAccSystemId, int position = 0)
	{
		string text = "";
		string text2 = "";
		switch (position)
		{
		case 0:
			text = "frmDefineProvince";
			text2 = "actManageProvinceLinkAcc";
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

	public ActionResult _PartialLoadManageProvinceLinkAcc(int linkAccSystemId, int linkAccSettingDBId)
	{
		GetCrmProvinceList(linkAccSystemId, linkAccSettingDBId);
		if (linkAccSystemId == 1)
		{
			SepidarProvinceList(linkAccSettingDBId);
		}
		else
		{
			OtherLinkAccProvinceList(linkAccSystemId);
		}
		base.ViewBag.LinkAccSystemId = linkAccSystemId;
		return PartialView();
	}

	[HttpPost]
	public string ManageSyncProvince(string jsData, int linkAccSettingDBId)
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
						_dbLink.CRMspLkUpdateProvinceLinkAccByJson(itemJson, userId, value3, value2, value, registerDatePersian, appType, objectParameter, linkAccSettingDBId);
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
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("Province");
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
	public JsonResult ActLinkedProvinceAcc(int linkAccSystemId, int linkAccSettingDBId)
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
			if (!UserLogin.IsUserAccess("frmManageProvinceLinkAcc", "actLinkWithAcc", UserLogin.CurrentUser))
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
			if ((linkAccSystemId != 1) ? OtherLinkedProvinceAcc(linkAccSystemId) : SepidarLinkedProvinceAcc(linkAccSettingDBId))
			{
				text = "";
				commonResultStatusViewModel = CommonResultStatusViewModel.Success;
				text2 = Messages.msgSuccessAction;
				CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("Province");
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
	public string GetManageLinkedProvinceList(int linkAccSystemId, int linkAccSettingDBId)
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
			List<CRMspSelectProvinceWithAccLinkField_Result> list = Enumerable.ToList<CRMspSelectProvinceWithAccLinkField_Result>((IEnumerable<CRMspSelectProvinceWithAccLinkField_Result>)_dbLink.CRMspSelectProvinceWithAccLinkField(true, lCID, result2, true));
			if (linkAccSystemId == 1 && list != null && Enumerable.Any<CRMspSelectProvinceWithAccLinkField_Result>((IEnumerable<CRMspSelectProvinceWithAccLinkField_Result>)list))
			{
				foreach (CRMspSelectProvinceWithAccLinkField_Result item in list)
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
							item.LinkAccProvinceIdStr = linkAccDataViewModel.Id ?? "";
							item.LinkAccData = "";
						}
					}
				}
				list = Enumerable.ToList<CRMspSelectProvinceWithAccLinkField_Result>(Enumerable.Where<CRMspSelectProvinceWithAccLinkField_Result>((IEnumerable<CRMspSelectProvinceWithAccLinkField_Result>)list, (Func<CRMspSelectProvinceWithAccLinkField_Result, bool>)((CRMspSelectProvinceWithAccLinkField_Result m) => (m.LinkAccProvinceIdStr ?? "") != "")));
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

	public LkListProvinceInfoViewModel GetCrmProvinceList(int linkAccSystemId, int linkAccSettingDBId)
	{
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		LkListProvinceInfoViewModel lkListProvinceInfoViewModel = new LkListProvinceInfoViewModel();
		try
		{
			_ = UserLogin.CurrentUser.UserId;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectProvince_Result> list = Enumerable.ToList<CRMspSelectProvince_Result>((IEnumerable<CRMspSelectProvince_Result>)_db.CRMspSelectProvince(lCID, result));
			if (linkAccSystemId == 1 && list != null && Enumerable.Any<CRMspSelectProvince_Result>((IEnumerable<CRMspSelectProvince_Result>)list))
			{
				foreach (CRMspSelectProvince_Result item in list)
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
							item.LinkAccProvinceIdStr = linkAccDataViewModel.Id ?? "";
							item.LinkAccData = "";
						}
					}
				}
			}
			if (list != null && list.Count > 0)
			{
				List<LkProvinceInfoViewModel> list3 = new List<LkProvinceInfoViewModel>();
				List<SelectListItem> list4 = new List<SelectListItem>();
				foreach (CRMspSelectProvince_Result item2 in list)
				{
					list3.Add(new LkProvinceInfoViewModel
					{
						ProvinceID = item2.ProvinceID,
						Province = item2.Province,
						ProvinceCode = item2.ProvinceCode,
						Description = item2.Description,
						LinkAccProvinceIdStr = item2.LinkAccProvinceIdStr,
						CountryId = item2.CountryID,
						CountryName = item2.CountryName
					});
					list4.Add(new SelectListItem
					{
						Value = item2.ProvinceID.ToString(),
						Text = ((!string.IsNullOrWhiteSpace(item2.CountryName)) ? item2.CountryName : "") + ((!string.IsNullOrWhiteSpace(item2.CountryName) && !string.IsNullOrWhiteSpace(item2.Province)) ? " - " : "") + ((!string.IsNullOrWhiteSpace(item2.Province)) ? item2.Province : ""),
						Selected = false
					});
				}
				lkListProvinceInfoViewModel.Lst = list3;
				lkListProvinceInfoViewModel.LstSelectListItem = list4;
			}
			lkListProvinceInfoViewModel.IsDone = true;
			lkListProvinceInfoViewModel.Message = "";
		}
		catch (Exception ex)
		{
			lkListProvinceInfoViewModel.IsDone = false;
			lkListProvinceInfoViewModel.Message = "Error: " + ex.Message;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		base.ViewBag.CrmProvinceListJs = JsonConvert.SerializeObject(lkListProvinceInfoViewModel.Lst);
		base.ViewBag.CrmProvinceSelectListJs = JsonConvert.SerializeObject(lkListProvinceInfoViewModel.LstSelectListItem);
		base.ViewBag.CrmProvinceList = lkListProvinceInfoViewModel;
		return lkListProvinceInfoViewModel;
	}

	public LkListProvinceInfoViewModel OtherLinkAccProvinceList(int linkAccSystemId)
	{
		LkListProvinceInfoViewModel lkListProvinceInfoViewModel = new LkListProvinceInfoViewModel();
		lkListProvinceInfoViewModel.Lst = new List<LkProvinceInfoViewModel>();
		lkListProvinceInfoViewModel.LstSelectListItem = new List<SelectListItem>();
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
			LkProvinceInfoViewModelObjects lkProvinceInfoViewModelObjects = new LkProvinceInfoViewModelObjects();
			switch (linkAccSystemId)
			{
			case 18:
				lkProvinceInfoViewModelObjects = GetNoAvaranCapillaryProvinceList();
				break;
			case 20:
				lkProvinceInfoViewModelObjects = GetNilramProvinceList();
				break;
			case 21:
				lkProvinceInfoViewModelObjects = GetHamyarProvinceList();
				break;
			case 22:
				lkProvinceInfoViewModelObjects = GetRahkaranInternalSalesProvinceList();
				break;
			case 25:
				lkProvinceInfoViewModelObjects = GetArianSystemProvinceList();
				break;
			}
			if (lkProvinceInfoViewModelObjects != null)
			{
				List<LkProvinceInfoViewModel> lst = lkProvinceInfoViewModelObjects.lst;
				if (lst != null && Enumerable.Any<LkProvinceInfoViewModel>((IEnumerable<LkProvinceInfoViewModel>)lst))
				{
					new List<SelectListItem>();
					foreach (LkProvinceInfoViewModel item in lst)
					{
						LkProvinceInfoViewModel lkProvinceInfoViewModel = new LkProvinceInfoViewModel();
						lkProvinceInfoViewModel.Province = item.Province ?? "";
						lkProvinceInfoViewModel.LinkAccProvinceIdStr = item.LinkAccProvinceIdStr ?? "";
						lkProvinceInfoViewModel.Province = item.Province ?? "";
						lkProvinceInfoViewModel.ProvinceID = item.ProvinceID;
						lkProvinceInfoViewModel.CountryId = item.CountryId;
						lkProvinceInfoViewModel.CountryName = item.CountryName;
						lkListProvinceInfoViewModel.Lst.Add(lkProvinceInfoViewModel);
						lkListProvinceInfoViewModel.LstSelectListItem.Add(new SelectListItem
						{
							Value = lkProvinceInfoViewModel.LinkAccProvinceIdStr,
							Text = ((!string.IsNullOrWhiteSpace(lkProvinceInfoViewModel.CountryName)) ? lkProvinceInfoViewModel.CountryName : "") + ((!string.IsNullOrWhiteSpace(lkProvinceInfoViewModel.CountryName) && !string.IsNullOrWhiteSpace(lkProvinceInfoViewModel.Province)) ? " - " : "") + ((!string.IsNullOrWhiteSpace(lkProvinceInfoViewModel.Province)) ? lkProvinceInfoViewModel.Province : ""),
							Selected = false
						});
					}
				}
			}
			lkListProvinceInfoViewModel.IsDone = true;
			lkListProvinceInfoViewModel.Message = "";
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			lkListProvinceInfoViewModel.IsDone = false;
			lkListProvinceInfoViewModel.Message = "Error: " + ex.Message;
		}
		base.ViewBag.LinkAccProvinceListJs = JsonConvert.SerializeObject(lkListProvinceInfoViewModel.Lst);
		base.ViewBag.LinkAccProvinceSelectListJs = JsonConvert.SerializeObject(lkListProvinceInfoViewModel.LstSelectListItem);
		base.ViewBag.LinkAccProvinceList = lkListProvinceInfoViewModel;
		return lkListProvinceInfoViewModel;
	}

	public bool OtherLinkedProvinceAcc(int linkAccSystemId)
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
			LkListProvinceInfoViewModel lkListProvinceInfoViewModel = OtherLinkAccProvinceList(linkAccSystemId);
			if (lkListProvinceInfoViewModel != null && lkListProvinceInfoViewModel.Lst != null && Enumerable.Any<LkProvinceInfoViewModel>((IEnumerable<LkProvinceInfoViewModel>)lkListProvinceInfoViewModel.Lst))
			{
				text = JsonConvert.SerializeObject(Enumerable.ToList<LkProvinceInfoViewModel>((IEnumerable<LkProvinceInfoViewModel>)lkListProvinceInfoViewModel.Lst));
			}
			if (!string.IsNullOrWhiteSpace(text))
			{
				mct_Link_Result mct_Link_Result = Enumerable.FirstOrDefault<mct_Link_Result>((IEnumerable<mct_Link_Result>)_dbLink.CRMspLkLinkedProvince(linkAccSystemId, text, userId, value2, value3, value, registerDatePersian, appType));
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

	public LkProvinceInfoViewModelObjects GetSepidarProvinceList(int linkAccSettingDBId)
	{
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		LkProvinceInfoViewModelObjects lkProvinceInfoViewModelObjects = new LkProvinceInfoViewModelObjects();
		lkProvinceInfoViewModelObjects.lst = new List<LkProvinceInfoViewModel>();
		lkProvinceInfoViewModelObjects.FilteredLst = new List<LkProvinceInfoViewModel>();
		List<LkProvinceInfoViewModel> list = new List<LkProvinceInfoViewModel>();
		try
		{
			List<CRMspLkSepSelectLocation_Result> list2 = Enumerable.ToList<CRMspLkSepSelectLocation_Result>((IEnumerable<CRMspLkSepSelectLocation_Result>)_dbLink.CRMspLkSepSelectLocation("2", linkAccSettingDBId, lCID, result));
			if (list2 != null && Enumerable.Any<CRMspLkSepSelectLocation_Result>((IEnumerable<CRMspLkSepSelectLocation_Result>)list2))
			{
				List<CRMspSelectProvinceWithAccLinkField_Result> list3 = Enumerable.ToList<CRMspSelectProvinceWithAccLinkField_Result>((IEnumerable<CRMspSelectProvinceWithAccLinkField_Result>)_dbLink.CRMspSelectProvinceWithAccLinkField(true, lCID, result, true));
				int result2 = 0;
				CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
				if (cRMspSelectCrmsysSetting_Result != null)
				{
					int.TryParse(cRMspSelectCrmsysSetting_Result.LinkAccSystemId.ToString(), out result2);
				}
				if (result2 == 1 && list3 != null && Enumerable.Any<CRMspSelectProvinceWithAccLinkField_Result>((IEnumerable<CRMspSelectProvinceWithAccLinkField_Result>)list3))
				{
					foreach (CRMspSelectProvinceWithAccLinkField_Result item2 in list3)
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
								item2.LinkAccProvinceIdStr = linkAccDataViewModel.Id ?? "";
								item2.LinkAccData = "";
							}
						}
					}
				}
				int num = 1;
				foreach (CRMspLkSepSelectLocation_Result item in list2)
				{
					LkProvinceInfoViewModel lkProvinceInfoViewModel = new LkProvinceInfoViewModel();
					lkProvinceInfoViewModel.Province = item.Title;
					lkProvinceInfoViewModel.ProvinceCode = item.Code;
					lkProvinceInfoViewModel.LinkAccProvinceIdStr = item.LocationId.ToString();
					lkProvinceInfoViewModel.CountryId = item.Parent.GetValueOrDefault();
					lkProvinceInfoViewModel.CountryName = item.ParentName;
					lkProvinceInfoViewModel.RowNumber = num;
					CRMspSelectProvinceWithAccLinkField_Result cRMspSelectProvinceWithAccLinkField_Result = Enumerable.FirstOrDefault<CRMspSelectProvinceWithAccLinkField_Result>((IEnumerable<CRMspSelectProvinceWithAccLinkField_Result>)list3, (Func<CRMspSelectProvinceWithAccLinkField_Result, bool>)((CRMspSelectProvinceWithAccLinkField_Result x) => x.LinkAccProvinceIdStr == item.LocationId.ToString()));
					if (cRMspSelectProvinceWithAccLinkField_Result != null && !string.IsNullOrWhiteSpace(cRMspSelectProvinceWithAccLinkField_Result.LinkAccProvinceIdStr))
					{
						lkProvinceInfoViewModel.ProvinceID = cRMspSelectProvinceWithAccLinkField_Result.ProvinceID;
						lkProvinceInfoViewModel.Selected = false;
					}
					else
					{
						lkProvinceInfoViewModel.ProvinceID = 0;
						lkProvinceInfoViewModel.Selected = true;
					}
					list.Add(lkProvinceInfoViewModel);
					num++;
				}
			}
			lkProvinceInfoViewModelObjects.lst = list;
			lkProvinceInfoViewModelObjects.FilteredLst = list;
			lkProvinceInfoViewModelObjects.Json = Json(list, JsonRequestBehavior.AllowGet);
			lkProvinceInfoViewModelObjects.SerializedJson = JsonConvert.SerializeObject(list);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return lkProvinceInfoViewModelObjects;
	}

	public LkListProvinceInfoViewModel SepidarProvinceList(int linkAccSettingDBId)
	{
		LkListProvinceInfoViewModel lkListProvinceInfoViewModel = new LkListProvinceInfoViewModel();
		lkListProvinceInfoViewModel.Lst = new List<LkProvinceInfoViewModel>();
		lkListProvinceInfoViewModel.LstSelectListItem = new List<SelectListItem>();
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
			LkProvinceInfoViewModelObjects sepidarProvinceList = GetSepidarProvinceList(linkAccSettingDBId);
			if (sepidarProvinceList != null)
			{
				List<LkProvinceInfoViewModel> lst = sepidarProvinceList.lst;
				if (lst != null && Enumerable.Any<LkProvinceInfoViewModel>((IEnumerable<LkProvinceInfoViewModel>)lst))
				{
					new List<SelectListItem>();
					foreach (LkProvinceInfoViewModel item in lst)
					{
						LkProvinceInfoViewModel lkProvinceInfoViewModel = new LkProvinceInfoViewModel();
						lkProvinceInfoViewModel.Province = item.Province ?? "";
						lkProvinceInfoViewModel.LinkAccProvinceIdStr = item.LinkAccProvinceIdStr ?? "";
						lkProvinceInfoViewModel.Province = item.Province ?? "";
						lkProvinceInfoViewModel.ProvinceID = item.ProvinceID;
						lkProvinceInfoViewModel.CountryId = item.CountryId;
						lkProvinceInfoViewModel.CountryName = item.CountryName;
						lkListProvinceInfoViewModel.Lst.Add(lkProvinceInfoViewModel);
						lkListProvinceInfoViewModel.LstSelectListItem.Add(new SelectListItem
						{
							Value = lkProvinceInfoViewModel.LinkAccProvinceIdStr,
							Text = ((!string.IsNullOrWhiteSpace(lkProvinceInfoViewModel.CountryName)) ? lkProvinceInfoViewModel.CountryName : "") + ((!string.IsNullOrWhiteSpace(lkProvinceInfoViewModel.CountryName) && !string.IsNullOrWhiteSpace(lkProvinceInfoViewModel.Province)) ? " - " : "") + ((!string.IsNullOrWhiteSpace(lkProvinceInfoViewModel.Province)) ? lkProvinceInfoViewModel.Province : ""),
							Selected = false
						});
					}
				}
			}
			lkListProvinceInfoViewModel.IsDone = true;
			lkListProvinceInfoViewModel.Message = "";
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			lkListProvinceInfoViewModel.IsDone = false;
			lkListProvinceInfoViewModel.Message = "Error: " + ex.Message;
		}
		base.ViewBag.LinkAccProvinceListJs = JsonConvert.SerializeObject(lkListProvinceInfoViewModel.Lst);
		base.ViewBag.LinkAccProvinceSelectListJs = JsonConvert.SerializeObject(lkListProvinceInfoViewModel.LstSelectListItem);
		base.ViewBag.LinkAccProvinceList = lkListProvinceInfoViewModel;
		return lkListProvinceInfoViewModel;
	}

	public bool SepidarLinkedProvinceAcc(int linkAccSettingDBId)
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
			mct_Link_Result mct_Link_Result = Enumerable.FirstOrDefault<mct_Link_Result>((IEnumerable<mct_Link_Result>)_dbLink.CRMspLkSepLinkedProvince(userId, value2, value3, value, registerDatePersian, appType, linkAccSettingDBId));
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

	public LkProvinceInfoViewModelObjects GetNoAvaranCapillaryProvinceList()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		LkProvinceInfoViewModelObjects lkProvinceInfoViewModelObjects = new LkProvinceInfoViewModelObjects();
		lkProvinceInfoViewModelObjects.lst = new List<LkProvinceInfoViewModel>();
		lkProvinceInfoViewModelObjects.FilteredLst = new List<LkProvinceInfoViewModel>();
		List<LkProvinceInfoViewModel> list = new List<LkProvinceInfoViewModel>();
		try
		{
			CRMIdeal.Classes.Helper.OtherSystems.NoAvaranCapillarySettingViewModel noAvaranCapillarySetting = CRMIdeal.Classes.Helper.OtherSystems.GetNoAvaranCapillarySetting();
			if (noAvaranCapillarySetting != null)
			{
				string text = noAvaranCapillarySetting.ApiUserId ?? "";
				if (!string.IsNullOrWhiteSpace(text))
				{
					List<CRMspSelectProvinceWithAccLinkField_Result> list2 = Enumerable.ToList<CRMspSelectProvinceWithAccLinkField_Result>((IEnumerable<CRMspSelectProvinceWithAccLinkField_Result>)_dbLink.CRMspSelectProvinceWithAccLinkField(true, lCID, result, false));
					List<SelectListItem> noAvaranCapillaryCountryList = GetNoAvaranCapillaryCountryList();
					string value = new CommercialSoapClient().ReadFromProvince("", text);
					if (!string.IsNullOrWhiteSpace(value))
					{
						value = value.ClearHiddenCharacters();
					}
					if (!string.IsNullOrWhiteSpace(value))
					{
						List<NoAvaranCapillaryProvinceInfoViewModel> list3 = JsonConvert.DeserializeObject<List<NoAvaranCapillaryProvinceInfoViewModel>>(value);
						if (list3 != null && Enumerable.Any<NoAvaranCapillaryProvinceInfoViewModel>((IEnumerable<NoAvaranCapillaryProvinceInfoViewModel>)list3))
						{
							int num = 1;
							foreach (NoAvaranCapillaryProvinceInfoViewModel item in list3)
							{
								LkProvinceInfoViewModel vm = new LkProvinceInfoViewModel();
								vm.Province = item.Name ?? "";
								vm.ProvinceCode = item.Code;
								vm.LinkAccProvinceIdStr = item.id.GetValueOrDefault().ToString();
								vm.CountryId = int.Parse(item.idCountry.GetValueOrDefault().ToString());
								if (noAvaranCapillaryCountryList != null && vm.CountryId != 0 && Enumerable.Any<SelectListItem>((IEnumerable<SelectListItem>)noAvaranCapillaryCountryList))
								{
									SelectListItem selectListItem = Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)noAvaranCapillaryCountryList, (Func<SelectListItem, bool>)((SelectListItem m) => m.Value == vm.CountryId.ToString()));
									if (selectListItem != null)
									{
										vm.CountryName = selectListItem.Text ?? "";
									}
								}
								vm.RowNumber = num;
								if (list2 != null && Enumerable.Any<CRMspSelectProvinceWithAccLinkField_Result>((IEnumerable<CRMspSelectProvinceWithAccLinkField_Result>)list2))
								{
									CRMspSelectProvinceWithAccLinkField_Result cRMspSelectProvinceWithAccLinkField_Result = Enumerable.FirstOrDefault<CRMspSelectProvinceWithAccLinkField_Result>((IEnumerable<CRMspSelectProvinceWithAccLinkField_Result>)list2, (Func<CRMspSelectProvinceWithAccLinkField_Result, bool>)((CRMspSelectProvinceWithAccLinkField_Result x) => x.LinkAccProvinceIdStr == vm.LinkAccProvinceIdStr));
									if (cRMspSelectProvinceWithAccLinkField_Result != null && !string.IsNullOrWhiteSpace(cRMspSelectProvinceWithAccLinkField_Result.LinkAccProvinceIdStr))
									{
										vm.ProvinceID = cRMspSelectProvinceWithAccLinkField_Result.ProvinceID;
										vm.Selected = false;
									}
									else
									{
										vm.ProvinceID = 0;
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
			lkProvinceInfoViewModelObjects.lst = list;
			lkProvinceInfoViewModelObjects.FilteredLst = list;
			lkProvinceInfoViewModelObjects.Json = Json(list, JsonRequestBehavior.AllowGet);
			lkProvinceInfoViewModelObjects.SerializedJson = JsonConvert.SerializeObject(list);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return lkProvinceInfoViewModelObjects;
	}

	public List<SelectListItem> GetNoAvaranCapillaryCountryList()
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
					string value = new CommercialSoapClient().ReadFromContry("", text);
					if (!string.IsNullOrWhiteSpace(value))
					{
						value = value.ClearHiddenCharacters();
					}
					if (!string.IsNullOrWhiteSpace(value))
					{
						List<NoAvaranCapillaryCountryInfoViewModel> list2 = JsonConvert.DeserializeObject<List<NoAvaranCapillaryCountryInfoViewModel>>(value);
						if (list2 != null && Enumerable.Any<NoAvaranCapillaryCountryInfoViewModel>((IEnumerable<NoAvaranCapillaryCountryInfoViewModel>)list2))
						{
							foreach (NoAvaranCapillaryCountryInfoViewModel item in list2)
							{
								item.id = item.id;
								item.Name = item.Name.TrimEnd(new char[1] { ' ' });
							}
							list.AddRange(Enumerable.Select<NoAvaranCapillaryCountryInfoViewModel, SelectListItem>((IEnumerable<NoAvaranCapillaryCountryInfoViewModel>)list2, (Func<NoAvaranCapillaryCountryInfoViewModel, SelectListItem>)((NoAvaranCapillaryCountryInfoViewModel item) => new SelectListItem
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

	public LkProvinceInfoViewModelObjects GetNilramProvinceList()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		LkProvinceInfoViewModelObjects lkProvinceInfoViewModelObjects = new LkProvinceInfoViewModelObjects();
		lkProvinceInfoViewModelObjects.lst = new List<LkProvinceInfoViewModel>();
		lkProvinceInfoViewModelObjects.FilteredLst = new List<LkProvinceInfoViewModel>();
		List<LkProvinceInfoViewModel> list = new List<LkProvinceInfoViewModel>();
		try
		{
			List<NilramCountryInfoViewModel> nilramCountryProvinceCityList = new CountryController().GetNilramCountryProvinceCityList();
			if (nilramCountryProvinceCityList != null && Enumerable.Any<NilramCountryInfoViewModel>((IEnumerable<NilramCountryInfoViewModel>)nilramCountryProvinceCityList))
			{
				List<CRMspSelectProvinceWithAccLinkField_Result> list2 = Enumerable.ToList<CRMspSelectProvinceWithAccLinkField_Result>((IEnumerable<CRMspSelectProvinceWithAccLinkField_Result>)_dbLink.CRMspSelectProvinceWithAccLinkField(true, lCID, result, false));
				int num = 1;
				foreach (NilramCountryInfoViewModel item in nilramCountryProvinceCityList)
				{
					bool flag = true;
					if (list != null && Enumerable.Any<LkProvinceInfoViewModel>((IEnumerable<LkProvinceInfoViewModel>)list))
					{
						LkProvinceInfoViewModel lkProvinceInfoViewModel = Enumerable.FirstOrDefault<LkProvinceInfoViewModel>((IEnumerable<LkProvinceInfoViewModel>)list, (Func<LkProvinceInfoViewModel, bool>)((LkProvinceInfoViewModel m) => m.LinkAccProvinceIdStr == item.CITY_CD.GetValueOrDefault().ToString()));
						if (lkProvinceInfoViewModel != null && !string.IsNullOrWhiteSpace(lkProvinceInfoViewModel.LinkAccProvinceIdStr))
						{
							flag = false;
						}
					}
					if (!flag)
					{
						continue;
					}
					LkProvinceInfoViewModel vm = new LkProvinceInfoViewModel();
					vm.Province = item.CITY_DSC ?? "";
					vm.LinkAccProvinceIdStr = item.CITY_CD.GetValueOrDefault().ToString();
					vm.CountryId = int.Parse(item.ID.GetValueOrDefault().ToString());
					vm.CountryName = item.NAME ?? "";
					vm.RowNumber = num;
					if (list2 != null && Enumerable.Any<CRMspSelectProvinceWithAccLinkField_Result>((IEnumerable<CRMspSelectProvinceWithAccLinkField_Result>)list2))
					{
						CRMspSelectProvinceWithAccLinkField_Result cRMspSelectProvinceWithAccLinkField_Result = Enumerable.FirstOrDefault<CRMspSelectProvinceWithAccLinkField_Result>((IEnumerable<CRMspSelectProvinceWithAccLinkField_Result>)list2, (Func<CRMspSelectProvinceWithAccLinkField_Result, bool>)((CRMspSelectProvinceWithAccLinkField_Result x) => x.LinkAccProvinceIdStr == vm.LinkAccProvinceIdStr));
						if (cRMspSelectProvinceWithAccLinkField_Result != null && !string.IsNullOrWhiteSpace(cRMspSelectProvinceWithAccLinkField_Result.LinkAccProvinceIdStr))
						{
							vm.ProvinceID = cRMspSelectProvinceWithAccLinkField_Result.ProvinceID;
							vm.Selected = false;
						}
						else
						{
							vm.ProvinceID = 0;
							vm.Selected = true;
						}
					}
					list.Add(vm);
					num++;
				}
			}
			lkProvinceInfoViewModelObjects.lst = list;
			lkProvinceInfoViewModelObjects.FilteredLst = list;
			lkProvinceInfoViewModelObjects.Json = Json(list, JsonRequestBehavior.AllowGet);
			lkProvinceInfoViewModelObjects.SerializedJson = JsonConvert.SerializeObject(list);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return lkProvinceInfoViewModelObjects;
	}

	public LkProvinceInfoViewModelObjects GetHamyarProvinceList()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		CRMIdeal.Classes.Helper.OtherSystems.HamyarProvider hamyarProvider = new CRMIdeal.Classes.Helper.OtherSystems.HamyarProvider(false);
		LkProvinceInfoViewModelObjects lkProvinceInfoViewModelObjects = new LkProvinceInfoViewModelObjects();
		lkProvinceInfoViewModelObjects.lst = new List<LkProvinceInfoViewModel>();
		lkProvinceInfoViewModelObjects.lst = hamyarProvider.GetProvinces(readAllDbCountries: true);
		return lkProvinceInfoViewModelObjects;
	}

	public LkProvinceInfoViewModelObjects GetRahkaranInternalSalesProvinceList()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		LkProvinceInfoViewModelObjects lkProvinceInfoViewModelObjects = new LkProvinceInfoViewModelObjects();
		lkProvinceInfoViewModelObjects.lst = new List<LkProvinceInfoViewModel>();
		lkProvinceInfoViewModelObjects.FilteredLst = new List<LkProvinceInfoViewModel>();
		List<LkProvinceInfoViewModel> list = new List<LkProvinceInfoViewModel>();
		try
		{
			CRMIdeal.Classes.Helper.OtherSystems.RahkaranInternalSalesProvider rahkaranInternalSalesProvider = new CRMIdeal.Classes.Helper.OtherSystems.RahkaranInternalSalesProvider();
			List<RahkaranInternalSalesRegionalDivisionResponseViewModel> regionalDivisionList = rahkaranInternalSalesProvider.GetRegionalDivisionList(1, 0L);
			List<RahkaranInternalSalesRegionalDivisionResponseViewModel> regionalDivisionList2 = rahkaranInternalSalesProvider.GetRegionalDivisionList(2, 0L);
			if (regionalDivisionList2 != null && Enumerable.Any<RahkaranInternalSalesRegionalDivisionResponseViewModel>((IEnumerable<RahkaranInternalSalesRegionalDivisionResponseViewModel>)regionalDivisionList2))
			{
				List<CRMspSelectProvinceWithAccLinkField_Result> list2 = Enumerable.ToList<CRMspSelectProvinceWithAccLinkField_Result>((IEnumerable<CRMspSelectProvinceWithAccLinkField_Result>)_dbLink.CRMspSelectProvinceWithAccLinkField(true, lCID, result, false));
				int num = 1;
				foreach (RahkaranInternalSalesRegionalDivisionResponseViewModel item in regionalDivisionList2)
				{
					bool flag = true;
					if (list != null && Enumerable.Any<LkProvinceInfoViewModel>((IEnumerable<LkProvinceInfoViewModel>)list))
					{
						LkProvinceInfoViewModel lkProvinceInfoViewModel = Enumerable.FirstOrDefault<LkProvinceInfoViewModel>((IEnumerable<LkProvinceInfoViewModel>)list, (Func<LkProvinceInfoViewModel, bool>)((LkProvinceInfoViewModel m) => m.LinkAccProvinceIdStr == item.RegionalDivisionID.GetValueOrDefault().ToString()));
						if (lkProvinceInfoViewModel != null && !string.IsNullOrWhiteSpace(lkProvinceInfoViewModel.LinkAccProvinceIdStr))
						{
							flag = false;
						}
					}
					if (!flag)
					{
						continue;
					}
					LkProvinceInfoViewModel vm = new LkProvinceInfoViewModel();
					vm.Province = item.Name ?? "";
					vm.LinkAccProvinceIdStr = item.RegionalDivisionID.GetValueOrDefault().ToString();
					vm.CountryId = int.Parse(item.ParentID.GetValueOrDefault().ToString());
					if (vm.CountryId != 0 && regionalDivisionList != null && Enumerable.Any<RahkaranInternalSalesRegionalDivisionResponseViewModel>((IEnumerable<RahkaranInternalSalesRegionalDivisionResponseViewModel>)regionalDivisionList))
					{
						RahkaranInternalSalesRegionalDivisionResponseViewModel rahkaranInternalSalesRegionalDivisionResponseViewModel = Enumerable.FirstOrDefault<RahkaranInternalSalesRegionalDivisionResponseViewModel>((IEnumerable<RahkaranInternalSalesRegionalDivisionResponseViewModel>)regionalDivisionList, (Func<RahkaranInternalSalesRegionalDivisionResponseViewModel, bool>)((RahkaranInternalSalesRegionalDivisionResponseViewModel m) => m.RegionalDivisionID.GetValueOrDefault() == vm.CountryId));
						if (rahkaranInternalSalesRegionalDivisionResponseViewModel != null)
						{
							vm.CountryName = rahkaranInternalSalesRegionalDivisionResponseViewModel.Name ?? "";
						}
					}
					vm.RowNumber = num;
					if (list2 != null && Enumerable.Any<CRMspSelectProvinceWithAccLinkField_Result>((IEnumerable<CRMspSelectProvinceWithAccLinkField_Result>)list2))
					{
						CRMspSelectProvinceWithAccLinkField_Result cRMspSelectProvinceWithAccLinkField_Result = Enumerable.FirstOrDefault<CRMspSelectProvinceWithAccLinkField_Result>((IEnumerable<CRMspSelectProvinceWithAccLinkField_Result>)list2, (Func<CRMspSelectProvinceWithAccLinkField_Result, bool>)((CRMspSelectProvinceWithAccLinkField_Result x) => x.LinkAccProvinceIdStr == vm.LinkAccProvinceIdStr));
						if (cRMspSelectProvinceWithAccLinkField_Result != null && !string.IsNullOrWhiteSpace(cRMspSelectProvinceWithAccLinkField_Result.LinkAccProvinceIdStr))
						{
							vm.ProvinceID = cRMspSelectProvinceWithAccLinkField_Result.ProvinceID;
							vm.Selected = false;
						}
						else
						{
							vm.ProvinceID = 0;
							vm.Selected = true;
						}
					}
					list.Add(vm);
					num++;
				}
			}
			lkProvinceInfoViewModelObjects.lst = list;
			lkProvinceInfoViewModelObjects.FilteredLst = list;
			lkProvinceInfoViewModelObjects.Json = Json(list, JsonRequestBehavior.AllowGet);
			lkProvinceInfoViewModelObjects.SerializedJson = JsonConvert.SerializeObject(list);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return lkProvinceInfoViewModelObjects;
	}

	public LkProvinceInfoViewModelObjects GetArianSystemProvinceList()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		LkProvinceInfoViewModelObjects lkProvinceInfoViewModelObjects = new LkProvinceInfoViewModelObjects();
		lkProvinceInfoViewModelObjects.lst = new List<LkProvinceInfoViewModel>();
		lkProvinceInfoViewModelObjects.FilteredLst = new List<LkProvinceInfoViewModel>();
		List<LkProvinceInfoViewModel> list = new List<LkProvinceInfoViewModel>();
		try
		{
			CRMIdeal.Classes.Helper.OtherSystems.ArianSystemProvider arianSystemProvider = new CRMIdeal.Classes.Helper.OtherSystems.ArianSystemProvider();
			List<ArianSystemLocationListResponseViewModel> locationList = arianSystemProvider.GetLocationList(0L);
			List<ArianSystemLocationListResponseViewModel> list2 = new List<ArianSystemLocationListResponseViewModel>();
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
							list2.AddRange(locationList2);
						}
					}
				}
			}
			if (list2 != null && Enumerable.Any<ArianSystemLocationListResponseViewModel>((IEnumerable<ArianSystemLocationListResponseViewModel>)list2))
			{
				List<CRMspSelectProvinceWithAccLinkField_Result> list3 = Enumerable.ToList<CRMspSelectProvinceWithAccLinkField_Result>((IEnumerable<CRMspSelectProvinceWithAccLinkField_Result>)_dbLink.CRMspSelectProvinceWithAccLinkField(true, lCID, result, false));
				int num = 1;
				foreach (ArianSystemLocationListResponseViewModel item in list2)
				{
					bool flag = true;
					if (list != null && Enumerable.Any<LkProvinceInfoViewModel>((IEnumerable<LkProvinceInfoViewModel>)list))
					{
						LkProvinceInfoViewModel lkProvinceInfoViewModel = Enumerable.FirstOrDefault<LkProvinceInfoViewModel>((IEnumerable<LkProvinceInfoViewModel>)list, (Func<LkProvinceInfoViewModel, bool>)((LkProvinceInfoViewModel m) => m.LinkAccProvinceIdStr == item.LocationID.GetValueOrDefault().ToString()));
						if (lkProvinceInfoViewModel != null && !string.IsNullOrWhiteSpace(lkProvinceInfoViewModel.LinkAccProvinceIdStr))
						{
							flag = false;
						}
					}
					if (!flag)
					{
						continue;
					}
					LkProvinceInfoViewModel vm = new LkProvinceInfoViewModel();
					vm.Province = item.LocationDesc ?? "";
					vm.LinkAccProvinceIdStr = item.LocationID.GetValueOrDefault().ToString();
					vm.CountryId = int.Parse(item.FatherLocationID.GetValueOrDefault().ToString());
					vm.CountryName = item.FatherName ?? "";
					vm.ProvinceCode = item.LocationCode ?? "";
					vm.RowNumber = num;
					if (list3 != null && Enumerable.Any<CRMspSelectProvinceWithAccLinkField_Result>((IEnumerable<CRMspSelectProvinceWithAccLinkField_Result>)list3))
					{
						CRMspSelectProvinceWithAccLinkField_Result cRMspSelectProvinceWithAccLinkField_Result = Enumerable.FirstOrDefault<CRMspSelectProvinceWithAccLinkField_Result>((IEnumerable<CRMspSelectProvinceWithAccLinkField_Result>)list3, (Func<CRMspSelectProvinceWithAccLinkField_Result, bool>)((CRMspSelectProvinceWithAccLinkField_Result x) => x.LinkAccProvinceIdStr == vm.LinkAccProvinceIdStr));
						if (cRMspSelectProvinceWithAccLinkField_Result != null && !string.IsNullOrWhiteSpace(cRMspSelectProvinceWithAccLinkField_Result.LinkAccProvinceIdStr))
						{
							vm.ProvinceID = cRMspSelectProvinceWithAccLinkField_Result.ProvinceID;
							vm.Selected = false;
						}
						else
						{
							vm.ProvinceID = 0;
							vm.Selected = true;
						}
					}
					list.Add(vm);
					num++;
				}
			}
			lkProvinceInfoViewModelObjects.lst = list;
			lkProvinceInfoViewModelObjects.FilteredLst = list;
			lkProvinceInfoViewModelObjects.Json = Json(list, JsonRequestBehavior.AllowGet);
			lkProvinceInfoViewModelObjects.SerializedJson = JsonConvert.SerializeObject(list);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return lkProvinceInfoViewModelObjects;
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbLink.Dispose();
		_db_I.Dispose();
		base.Dispose(disposing);
	}
}
