using System;
using System.Collections;
using System.Collections.Generic;
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
using System.Web.Script.Serialization;
using CRM.General.IO;
using CRM.General.Security;
using CRM.Models;
using CRM.OtherWebServices.LinkNoAvanran_II;
using CRM.OtherWebServices.LinkNoAvaranCapillary;
using CRM.Resources;
using CRMIdeal.Areas.Setting.Controllers;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using CRMIdeal.Hubs;
using Elmah;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using NR.Shygun.WS.FilterDomains;
using Newtonsoft.Json;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace CRMIdeal.Areas.OtherSystems.Controllers;

public class UserController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private readonly CRMLinkSpEntities _dbLink = new CRMLinkSpEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	[JsonIgnore]
	private string JsonRender;

	[DynamicAuthorize(ControllerName = "frmDefineUsers", ActionName = "actManageUserLinkAcc")]
	public ActionResult ShygunIIManageUserLinkAcc()
	{
		GetRolls();
		return View();
	}

	public ShygunIIUserInfoViewModelObjects GetShygunIIUserList_Old(string fJobCode = "", string tJobCode = "", int fNum = 0, int tNum = 100)
	{
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_0841: Unknown result type (might be due to invalid IL or missing references)
		//IL_0846: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		ShygunIIUserInfoViewModelObjects shygunIIUserInfoViewModelObjects = new ShygunIIUserInfoViewModelObjects();
		shygunIIUserInfoViewModelObjects.lst = new List<ShygunIIUserInfoViewModel>();
		shygunIIUserInfoViewModelObjects.FilteredLst = new List<ShygunIIUserInfoViewModel>();
		List<ShygunIIUserInfoViewModel> list = new List<ShygunIIUserInfoViewModel>();
		try
		{
			CRMIdeal.Classes.Helper.OtherSystems.ShygunIISettingViewModel shygunIISetting = CRMIdeal.Classes.Helper.OtherSystems.GetShygunIISetting();
			DomainJob domainJob = new DomainJob();
			domainJob.JobCostingCode.From = fJobCode;
			domainJob.JobCostingCode.To = tJobCode;
			int num = ((fNum > 0) ? fNum : 0);
			int num2 = ((tNum >= 100) ? 100 : tNum);
			try
			{
				List<CRMspSelectUsersWithAccLinkField_Result> list2 = Enumerable.ToList<CRMspSelectUsersWithAccLinkField_Result>((IEnumerable<CRMspSelectUsersWithAccLinkField_Result>)_dbLink.CRMspSelectUsersWithAccLinkField(true, false, lCID, result));
				int num3 = 1;
				List<CrmLinkAccShygunIIAccountInfoViewModel> list3 = new List<CrmLinkAccShygunIIAccountInfoViewModel>();
				if (shygunIISetting != null)
				{
					if (!string.IsNullOrWhiteSpace(shygunIISetting.ShygunSaleMoinNumber))
					{
						if (shygunIISetting.ShygunSaleMoinNumber.IndexOf("[{") >= 0)
						{
							List<CrmLinkAccShygunIIAccountInfoViewModel> list4 = new JavaScriptSerializer().Deserialize<List<CrmLinkAccShygunIIAccountInfoViewModel>>(shygunIISetting.ShygunSaleMoinNumber);
							if (list4 != null && Enumerable.Any<CrmLinkAccShygunIIAccountInfoViewModel>((IEnumerable<CrmLinkAccShygunIIAccountInfoViewModel>)list4))
							{
								foreach (CrmLinkAccShygunIIAccountInfoViewModel item2 in list4)
								{
									if (!string.IsNullOrWhiteSpace(item2.GuId))
									{
										CrmLinkAccShygunIIAccountInfoViewModel item = new CrmLinkAccShygunIIAccountInfoViewModel
										{
											GuId = item2.GuId
										};
										list3.Add(item);
									}
								}
							}
						}
						if (list3 != null && Enumerable.Any<CrmLinkAccShygunIIAccountInfoViewModel>((IEnumerable<CrmLinkAccShygunIIAccountInfoViewModel>)list3))
						{
							list3 = Enumerable.ToList<CrmLinkAccShygunIIAccountInfoViewModel>(Enumerable.Distinct<CrmLinkAccShygunIIAccountInfoViewModel>((IEnumerable<CrmLinkAccShygunIIAccountInfoViewModel>)list3));
						}
					}
					else
					{
						Exception e = new Exception(Messages.errorInReadingSetting + " (" + string.Format(Messages.msgErrorIsNotEntered, shygunIISetting.ShygunSaleMoinNumberFieldTitle ?? ""));
						ErrorSignal.FromCurrentContext().Raise(e);
					}
				}
				else
				{
					Exception e2 = new Exception(Messages.errorInReadingSetting);
					ErrorSignal.FromCurrentContext().Raise(e2);
				}
				string text = shygunIISetting.IP;
				if (string.IsNullOrWhiteSpace(text))
				{
					Exception e3 = new Exception(Messages.errorInReadingSetting);
					ErrorSignal.FromCurrentContext().Raise(e3);
				}
				if (!text.EndsWith("/"))
				{
					text += "/";
				}
				HttpClient httpClient = new HttpClient();
				httpClient.Timeout = CRMIdeal.Classes.Helper.OtherSystems.RestApiTimeout();
				httpClient.BaseAddress = new Uri(text);
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				string text2 = "api/Job/Get";
				text2 = text2 + "?RowStart=" + num + "&RowCount=" + num2;
				HttpContent content = new StringContent(JsonConvert.SerializeObject(new CRMIdeal.Classes.Helper.OtherSystems.ShygunIIApiGetJobParamViewModel
				{
					Config = shygunIISetting.conf,
					Domain = domainJob,
					StartVersion = "0"
				}), Encoding.UTF8, "application/json");
				HttpResponseMessage httpResponseMessage = new HttpResponseMessage();
				httpResponseMessage = httpClient.PostAsync(text2, content).Result;
				if (httpResponseMessage.IsSuccessStatusCode)
				{
					CRMIdeal.Classes.Helper.OtherSystems.ShygunIIApiGetJobResultViewModel shygunIIApiGetJobResultViewModel = JsonConvert.DeserializeObject<CRMIdeal.Classes.Helper.OtherSystems.ShygunIIApiGetJobResultViewModel>(httpResponseMessage.Content.ReadAsStringAsync().Result);
					if (shygunIIApiGetJobResultViewModel != null && list3 != null && Enumerable.Any<CrmLinkAccShygunIIAccountInfoViewModel>((IEnumerable<CrmLinkAccShygunIIAccountInfoViewModel>)list3) && shygunIIApiGetJobResultViewModel.Result != null && Enumerable.Any<ShygunIICompanyInfoViewModel>((IEnumerable<ShygunIICompanyInfoViewModel>)shygunIIApiGetJobResultViewModel.Result))
					{
						foreach (ShygunIICompanyInfoViewModel item3 in shygunIIApiGetJobResultViewModel.Result)
						{
							ShygunIIUserInfoViewModel vm = new ShygunIIUserInfoViewModel();
							vm.JobNo = item3.JobNo ?? "";
							vm.JobName = item3.JobName ?? "";
							vm.JobDescription = item3.JobDescription ?? "";
							vm.LendCover = item3.LendCover;
							vm.DebtCover = item3.DebtCover;
							vm.DebtCoverDoc = item3.DebtCoverDoc;
							vm.CreditCoverDoc = item3.CreditCoverDoc;
							vm.RemainAccount = item3.RemainAccount;
							vm.Scode1Number = item3.Scode1Number ?? "";
							vm.Scode2Number = item3.Scode2Number ?? "";
							vm.JobScode1Number = item3.JobScode1Number ?? "";
							vm.JobScode2Number = item3.JobScode2Number ?? "";
							vm.JobCreate = item3.JobCreate;
							vm.JobCreateStr = (vm.JobCreate.HasValue ? vm.JobCreate.Value.ToString("yyyy/MM/dd") : "");
							vm.DiscountLevel = item3.DiscountLevel;
							vm.Telephone1 = item3.Telephone1 ?? "";
							vm.Telephone2 = item3.Telephone2 ?? "";
							vm.Fax = item3.Fax ?? "";
							vm.Email = item3.Email ?? "";
							vm.Web = item3.Web ?? "";
							vm.Address1 = item3.Address1 ?? "";
							vm.Address2 = item3.Address2 ?? "";
							vm.City = item3.City ?? "";
							vm.Province = item3.Province ?? "";
							vm.ZipCode = item3.ZipCode ?? "";
							vm.Country = item3.Country ?? "";
							vm.EconomicCode = item3.EconomicCode ?? "";
							vm.Tlx = item3.Tlx ?? "";
							vm.Title = item3.Title ?? "";
							vm.Mobile = item3.Mobile ?? "";
							vm.BankNumber1 = item3.BankNumber1 ?? "";
							vm.BankNumber2 = item3.BankNumber2 ?? "";
							vm.MelliCode = item3.MelliCode ?? "";
							vm.DefaultDiscountPer = item3.DefaultDiscountPer;
							vm.JobGroupNumber = item3.JobGroupNumber ?? "";
							vm.JobGroupName = item3.JobGroupName ?? "";
							vm.GuId = item3.GuId ?? "";
							vm.JobGroupGuId = item3.JobGroupGuId ?? "";
							if (Enumerable.FirstOrDefault<CrmLinkAccShygunIIAccountInfoViewModel>((IEnumerable<CrmLinkAccShygunIIAccountInfoViewModel>)list3, (Func<CrmLinkAccShygunIIAccountInfoViewModel, bool>)((CrmLinkAccShygunIIAccountInfoViewModel m) => m.GuId == vm.JobGroupGuId)) != null)
							{
								vm.RowNumber = num3;
								CRMspSelectUsersWithAccLinkField_Result cRMspSelectUsersWithAccLinkField_Result = Enumerable.FirstOrDefault<CRMspSelectUsersWithAccLinkField_Result>((IEnumerable<CRMspSelectUsersWithAccLinkField_Result>)list2, (Func<CRMspSelectUsersWithAccLinkField_Result, bool>)((CRMspSelectUsersWithAccLinkField_Result x) => x.LinkAccUserIdStr == vm.GuId));
								if (cRMspSelectUsersWithAccLinkField_Result != null && !string.IsNullOrWhiteSpace(cRMspSelectUsersWithAccLinkField_Result.LinkAccUserIdStr))
								{
									vm.UserId = cRMspSelectUsersWithAccLinkField_Result.UserId;
								}
								else
								{
									vm.UserId = 0;
								}
								list.Add(vm);
								num3++;
							}
						}
					}
				}
				else
				{
					HttpStatusCode statusCode = httpResponseMessage.StatusCode;
					Exception e4 = new Exception(((object)(HttpStatusCode)(ref statusCode)).ToString());
					ErrorSignal.FromCurrentContext().Raise(e4);
				}
				shygunIIUserInfoViewModelObjects.lst = list;
				shygunIIUserInfoViewModelObjects.FilteredLst = list;
				shygunIIUserInfoViewModelObjects.Json = Json(list, JsonRequestBehavior.AllowGet);
				shygunIIUserInfoViewModelObjects.SerializedJson = JsonConvert.SerializeObject(list);
			}
			catch (Exception e5)
			{
				ErrorSignal.FromCurrentContext().Raise(e5);
			}
		}
		catch (Exception e6)
		{
			ErrorSignal.FromCurrentContext().Raise(e6);
		}
		return shygunIIUserInfoViewModelObjects;
	}

	public ShygunIIUserInfoViewModelObjects GetShygunIIUserList(string fJobCode = "", string tJobCode = "", int fNum = 0, int tNum = 100, bool allUser = false)
	{
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_0873: Unknown result type (might be due to invalid IL or missing references)
		//IL_0878: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		ShygunIIUserInfoViewModelObjects shygunIIUserInfoViewModelObjects = new ShygunIIUserInfoViewModelObjects();
		shygunIIUserInfoViewModelObjects.lst = new List<ShygunIIUserInfoViewModel>();
		shygunIIUserInfoViewModelObjects.FilteredLst = new List<ShygunIIUserInfoViewModel>();
		List<ShygunIIUserInfoViewModel> list = new List<ShygunIIUserInfoViewModel>();
		try
		{
			CRMIdeal.Classes.Helper.OtherSystems.ShygunIISettingViewModel shygunIISetting = CRMIdeal.Classes.Helper.OtherSystems.GetShygunIISetting();
			DomainJob domainJob = new DomainJob();
			domainJob.JobCostingCode.From = fJobCode;
			domainJob.JobCostingCode.To = tJobCode;
			int num = ((fNum > 0) ? fNum : 0);
			int num2 = ((tNum >= 100) ? 100 : tNum);
			try
			{
				List<CRMspSelectUsersWithAccLinkField_Result> list2 = Enumerable.ToList<CRMspSelectUsersWithAccLinkField_Result>((IEnumerable<CRMspSelectUsersWithAccLinkField_Result>)_dbLink.CRMspSelectUsersWithAccLinkField(true, false, lCID, result));
				int num3 = 1;
				List<CrmLinkAccShygunIIAccountInfoViewModel> list3 = new List<CrmLinkAccShygunIIAccountInfoViewModel>();
				if (shygunIISetting != null)
				{
					if (!string.IsNullOrWhiteSpace(shygunIISetting.ShygunSaleMoinNumber))
					{
						if (shygunIISetting.ShygunSaleMoinNumber.IndexOf("[{") >= 0)
						{
							List<CrmLinkAccShygunIIAccountInfoViewModel> list4 = new JavaScriptSerializer().Deserialize<List<CrmLinkAccShygunIIAccountInfoViewModel>>(shygunIISetting.ShygunSaleMoinNumber);
							if (list4 != null && Enumerable.Any<CrmLinkAccShygunIIAccountInfoViewModel>((IEnumerable<CrmLinkAccShygunIIAccountInfoViewModel>)list4))
							{
								foreach (CrmLinkAccShygunIIAccountInfoViewModel item2 in list4)
								{
									if (!string.IsNullOrWhiteSpace(item2.GuId))
									{
										CrmLinkAccShygunIIAccountInfoViewModel item = new CrmLinkAccShygunIIAccountInfoViewModel
										{
											GuId = item2.GuId
										};
										list3.Add(item);
									}
								}
							}
						}
						if (list3 != null && Enumerable.Any<CrmLinkAccShygunIIAccountInfoViewModel>((IEnumerable<CrmLinkAccShygunIIAccountInfoViewModel>)list3))
						{
							list3 = Enumerable.ToList<CrmLinkAccShygunIIAccountInfoViewModel>(Enumerable.Distinct<CrmLinkAccShygunIIAccountInfoViewModel>((IEnumerable<CrmLinkAccShygunIIAccountInfoViewModel>)list3));
						}
					}
					else
					{
						Exception e = new Exception(Messages.errorInReadingSetting + " (" + string.Format(Messages.msgErrorIsNotEntered, shygunIISetting.ShygunSaleMoinNumberFieldTitle ?? ""));
						ErrorSignal.FromCurrentContext().Raise(e);
					}
				}
				else
				{
					Exception e2 = new Exception(Messages.errorInReadingSetting);
					ErrorSignal.FromCurrentContext().Raise(e2);
				}
				bool flag = true;
				int num4 = num;
				int num5 = num2;
				string text = shygunIISetting.IP;
				if (string.IsNullOrWhiteSpace(text))
				{
					Exception e3 = new Exception(Messages.errorInReadingSetting);
					ErrorSignal.FromCurrentContext().Raise(e3);
				}
				if (!text.EndsWith("/"))
				{
					text += "/";
				}
				while (flag)
				{
					HttpClient httpClient = new HttpClient();
					httpClient.Timeout = CRMIdeal.Classes.Helper.OtherSystems.RestApiTimeout();
					httpClient.BaseAddress = new Uri(text);
					httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
					string text2 = "api/Job/Get";
					text2 = text2 + "?RowStart=" + num4 + "&RowCount=" + num5;
					HttpContent content = new StringContent(JsonConvert.SerializeObject(new CRMIdeal.Classes.Helper.OtherSystems.ShygunIIApiGetJobParamViewModel
					{
						Config = shygunIISetting.conf,
						Domain = domainJob,
						StartVersion = "0"
					}), Encoding.UTF8, "application/json");
					HttpResponseMessage httpResponseMessage = new HttpResponseMessage();
					httpResponseMessage = httpClient.PostAsync(text2, content).Result;
					if (httpResponseMessage.IsSuccessStatusCode)
					{
						CRMIdeal.Classes.Helper.OtherSystems.ShygunIIApiGetJobResultViewModel shygunIIApiGetJobResultViewModel = JsonConvert.DeserializeObject<CRMIdeal.Classes.Helper.OtherSystems.ShygunIIApiGetJobResultViewModel>(httpResponseMessage.Content.ReadAsStringAsync().Result);
						if (shygunIIApiGetJobResultViewModel != null && list3 != null && Enumerable.Any<CrmLinkAccShygunIIAccountInfoViewModel>((IEnumerable<CrmLinkAccShygunIIAccountInfoViewModel>)list3))
						{
							if (shygunIIApiGetJobResultViewModel.Result != null && Enumerable.Any<ShygunIICompanyInfoViewModel>((IEnumerable<ShygunIICompanyInfoViewModel>)shygunIIApiGetJobResultViewModel.Result))
							{
								foreach (ShygunIICompanyInfoViewModel item3 in shygunIIApiGetJobResultViewModel.Result)
								{
									ShygunIIUserInfoViewModel vm = new ShygunIIUserInfoViewModel();
									vm.JobNo = item3.JobNo ?? "";
									vm.JobName = item3.JobName ?? "";
									vm.JobDescription = item3.JobDescription ?? "";
									vm.LendCover = item3.LendCover;
									vm.DebtCover = item3.DebtCover;
									vm.DebtCoverDoc = item3.DebtCoverDoc;
									vm.CreditCoverDoc = item3.CreditCoverDoc;
									vm.RemainAccount = item3.RemainAccount;
									vm.Scode1Number = item3.Scode1Number ?? "";
									vm.Scode2Number = item3.Scode2Number ?? "";
									vm.JobScode1Number = item3.JobScode1Number ?? "";
									vm.JobScode2Number = item3.JobScode2Number ?? "";
									vm.JobCreate = item3.JobCreate;
									vm.JobCreateStr = (vm.JobCreate.HasValue ? vm.JobCreate.Value.ToString("yyyy/MM/dd") : "");
									vm.DiscountLevel = item3.DiscountLevel;
									vm.Telephone1 = item3.Telephone1 ?? "";
									vm.Telephone2 = item3.Telephone2 ?? "";
									vm.Fax = item3.Fax ?? "";
									vm.Email = item3.Email ?? "";
									vm.Web = item3.Web ?? "";
									vm.Address1 = item3.Address1 ?? "";
									vm.Address2 = item3.Address2 ?? "";
									vm.City = item3.City ?? "";
									vm.Province = item3.Province ?? "";
									vm.ZipCode = item3.ZipCode ?? "";
									vm.Country = item3.Country ?? "";
									vm.EconomicCode = item3.EconomicCode ?? "";
									vm.Tlx = item3.Tlx ?? "";
									vm.Title = item3.Title ?? "";
									vm.Mobile = item3.Mobile ?? "";
									vm.BankNumber1 = item3.BankNumber1 ?? "";
									vm.BankNumber2 = item3.BankNumber2 ?? "";
									vm.MelliCode = item3.MelliCode ?? "";
									vm.DefaultDiscountPer = item3.DefaultDiscountPer;
									vm.JobGroupNumber = item3.JobGroupNumber ?? "";
									vm.JobGroupName = item3.JobGroupName ?? "";
									vm.GuId = item3.GuId ?? "";
									vm.JobGroupGuId = item3.JobGroupGuId ?? "";
									if (Enumerable.FirstOrDefault<CrmLinkAccShygunIIAccountInfoViewModel>((IEnumerable<CrmLinkAccShygunIIAccountInfoViewModel>)list3, (Func<CrmLinkAccShygunIIAccountInfoViewModel, bool>)((CrmLinkAccShygunIIAccountInfoViewModel m) => m.GuId == vm.JobGroupGuId)) != null)
									{
										vm.RowNumber = num3;
										CRMspSelectUsersWithAccLinkField_Result cRMspSelectUsersWithAccLinkField_Result = Enumerable.FirstOrDefault<CRMspSelectUsersWithAccLinkField_Result>((IEnumerable<CRMspSelectUsersWithAccLinkField_Result>)list2, (Func<CRMspSelectUsersWithAccLinkField_Result, bool>)((CRMspSelectUsersWithAccLinkField_Result x) => x.LinkAccUserIdStr == vm.GuId));
										if (cRMspSelectUsersWithAccLinkField_Result != null && !string.IsNullOrWhiteSpace(cRMspSelectUsersWithAccLinkField_Result.LinkAccUserIdStr))
										{
											vm.UserId = cRMspSelectUsersWithAccLinkField_Result.UserId;
										}
										else
										{
											vm.UserId = 0;
										}
										list.Add(vm);
										num3++;
									}
								}
								num4 += ((num4 > 0) ? 100 : 101);
								flag = true;
							}
							else
							{
								flag = false;
							}
						}
						else
						{
							flag = false;
						}
					}
					else
					{
						HttpStatusCode statusCode = httpResponseMessage.StatusCode;
						Exception e4 = new Exception(((object)(HttpStatusCode)(ref statusCode)).ToString());
						ErrorSignal.FromCurrentContext().Raise(e4);
						flag = false;
					}
				}
				shygunIIUserInfoViewModelObjects.lst = list;
				shygunIIUserInfoViewModelObjects.FilteredLst = list;
				shygunIIUserInfoViewModelObjects.Json = Json(list, JsonRequestBehavior.AllowGet);
				shygunIIUserInfoViewModelObjects.SerializedJson = JsonConvert.SerializeObject(list);
			}
			catch (Exception e5)
			{
				ErrorSignal.FromCurrentContext().Raise(e5);
			}
		}
		catch (Exception e6)
		{
			ErrorSignal.FromCurrentContext().Raise(e6);
		}
		return shygunIIUserInfoViewModelObjects;
	}

	[DynamicAuthorize(ControllerName = "frmManageUserLinkAcc", ActionName = "actImportShowInfo")]
	public ActionResult ShygunIIUser_Read([DataSourceRequest] DataSourceRequest request, string fJobCode = "", string tJobCode = "", int fNum = 0, int tNum = 100)
	{
		List<ShygunIIUserInfoViewModel> enumerable = new List<ShygunIIUserInfoViewModel>();
		ShygunIIUserInfoViewModelObjects shygunIIUserList = GetShygunIIUserList(fJobCode, tJobCode, fNum, tNum);
		if (shygunIIUserList != null)
		{
			enumerable = shygunIIUserList.lst;
		}
		JsonResult jsonResult = Json(((IEnumerable)enumerable).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[DynamicAuthorize(ControllerName = "frmManageUserLinkAcc", ActionName = "actImportInfo")]
	[AjaxOnly]
	public JsonResult ShygunIIImportInfo(string records, int rollId = 0, string fJobCode = "", string tJobCode = "", int fNum = 0, int tNum = 100)
	{
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int num = 0;
		string text = "";
		CommonResultStatusViewModel commonResultStatusViewModel = CommonResultStatusViewModel.Success;
		CommonResultViewModel<int> data;
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
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
			List<OtherSystemSelectedVIiewModel> list = new List<OtherSystemSelectedVIiewModel>();
			List<OtherSystemSelectedVIiewModel> list2 = new List<OtherSystemSelectedVIiewModel>();
			if (!string.IsNullOrWhiteSpace(records))
			{
				list = new JavaScriptSerializer().Deserialize<List<OtherSystemSelectedVIiewModel>>(records);
				if (Enumerable.Any<OtherSystemSelectedVIiewModel>((IEnumerable<OtherSystemSelectedVIiewModel>)list))
				{
					list2 = Enumerable.ToList<OtherSystemSelectedVIiewModel>(Enumerable.Where<OtherSystemSelectedVIiewModel>((IEnumerable<OtherSystemSelectedVIiewModel>)list, (Func<OtherSystemSelectedVIiewModel, bool>)((OtherSystemSelectedVIiewModel m) => m.Selected)));
				}
			}
			List<ShygunIIUserInfoViewModel> list3 = new List<ShygunIIUserInfoViewModel>();
			List<ShygunIIUserInfoViewModel> lst = GetShygunIIUserList(fJobCode, tJobCode, fNum, tNum).lst;
			if (lst != null)
			{
				List<CRMspSelectUsersWithAccLinkField_Result> list4 = Enumerable.ToList<CRMspSelectUsersWithAccLinkField_Result>((IEnumerable<CRMspSelectUsersWithAccLinkField_Result>)_dbLink.CRMspSelectUsersWithAccLinkField(true, false, lCID, result));
				foreach (OtherSystemSelectedVIiewModel SelectedRowitem in list2)
				{
					foreach (ShygunIIUserInfoViewModel item in Enumerable.ToList<ShygunIIUserInfoViewModel>(Enumerable.Where<ShygunIIUserInfoViewModel>((IEnumerable<ShygunIIUserInfoViewModel>)lst, (Func<ShygunIIUserInfoViewModel, bool>)((ShygunIIUserInfoViewModel w) => w.GuId == SelectedRowitem.Id))))
					{
						if (list4 != null && Enumerable.Any<CRMspSelectUsersWithAccLinkField_Result>((IEnumerable<CRMspSelectUsersWithAccLinkField_Result>)list4))
						{
							CRMspSelectUsersWithAccLinkField_Result cRMspSelectUsersWithAccLinkField_Result = Enumerable.FirstOrDefault<CRMspSelectUsersWithAccLinkField_Result>((IEnumerable<CRMspSelectUsersWithAccLinkField_Result>)list4, (Func<CRMspSelectUsersWithAccLinkField_Result, bool>)((CRMspSelectUsersWithAccLinkField_Result m) => m.LinkAccUserIdStr == item.GuId));
							if (cRMspSelectUsersWithAccLinkField_Result != null)
							{
								item.UserId = cRMspSelectUsersWithAccLinkField_Result.UserId;
							}
						}
						list3.Add(item);
					}
				}
			}
			else
			{
				string text2 = Messages.msgErrorRunFunction + " (get list from ShygunII) ";
				Exception e = new Exception(text2);
				ErrorSignal.FromCurrentContext().Raise(e);
				text = text2;
			}
			bool flag = true;
			if (list3 != null && Enumerable.Any<ShygunIIUserInfoViewModel>((IEnumerable<ShygunIIUserInfoViewModel>)list3))
			{
				int count = list3.Count;
				int num2 = 0;
				num2 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)_dbI.CRMspReturnActiveUsersCount()).GetValueOrDefault();
				num2 += count;
				int num3 = Configuration.MaxCountOfOnlineUser + Configuration.MaxCountOfOnlineUserDeActive;
				if (VersionBuyer.Enterprise)
				{
					_ = Configuration.MaxCountOfOnlineUser;
				}
				if (num3 <= num2)
				{
					text = Messages.msgErrorFinishingUserDefinitionCapacity;
					flag = false;
				}
			}
			if (flag)
			{
				if (list3 != null && Enumerable.Any<ShygunIIUserInfoViewModel>((IEnumerable<ShygunIIUserInfoViewModel>)list3))
				{
					text = "";
					string text3 = JsonConvert.SerializeObject(list3);
					ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
					_dbLink.CRMspLkShygunIIInsertUpdateUser(text3, rollId, userId, month1: value2, year1: result2, registerDate: value, registerDatePersian: registerDatePersian, languageId: result, appType: appType, errorMessage: objectParameter, centerId: centerId);
					if (objectParameter.Value != null)
					{
						if (!string.IsNullOrEmpty(objectParameter.Value.ToString()))
						{
							text = text + "<br>" + objectParameter.Value.ToString();
						}
						else
						{
							int count2 = 100;
							ProgressHub.SendMessage("ok", count2, userId);
						}
					}
					else
					{
						int count3 = 100;
						ProgressHub.SendMessage("ok", count3, userId);
					}
				}
				else
				{
					text = Messages.msgErrorRunFunction + " (" + Messages.ErrorNotFound + ")";
				}
			}
			if (!string.IsNullOrEmpty(text))
			{
				num = 0;
				commonResultStatusViewModel = CommonResultStatusViewModel.Fail;
				ProgressHub.SendMessage(text, 0, userId);
			}
			else
			{
				text = Messages.msgSuccessAction;
				num = 1;
				commonResultStatusViewModel = CommonResultStatusViewModel.Success;
			}
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("Users");
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			num = 0;
			data = new CommonResultViewModel<int>
			{
				Data = num,
				Message = Messages.msgErrorRunFunction,
				Status = CommonResultStatusViewModel.Error
			};
			return Json(data, JsonRequestBehavior.AllowGet);
		}
		data = new CommonResultViewModel<int>
		{
			Data = num,
			Message = text,
			Status = commonResultStatusViewModel
		};
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetShygunIIImportUserList(string records, string fJobCode = "", string tJobCode = "", int fNum = 0, int tNum = 100)
	{
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		List<OtherSystemSelectedVIiewModel> list = new List<OtherSystemSelectedVIiewModel>();
		try
		{
			foreach (ShygunIIUserInfoViewModel item2 in GetShygunIIUserList(fJobCode, tJobCode, fNum, tNum).lst)
			{
				string id = "";
				if (!string.IsNullOrWhiteSpace(item2.GuId))
				{
					id = item2.GuId ?? "0";
				}
				OtherSystemSelectedVIiewModel item = new OtherSystemSelectedVIiewModel
				{
					Row = item2.RowNumber,
					Id = id,
					Selected = (item2.UserId <= 0)
				};
				list.Add(item);
			}
			if (!string.IsNullOrWhiteSpace(records))
			{
				List<OtherSystemSelectedVIiewModel> list2 = new List<OtherSystemSelectedVIiewModel>();
				list2 = new JavaScriptSerializer().Deserialize<List<OtherSystemSelectedVIiewModel>>(records);
				if (Enumerable.Any<OtherSystemSelectedVIiewModel>((IEnumerable<OtherSystemSelectedVIiewModel>)list2))
				{
					foreach (OtherSystemSelectedVIiewModel item3 in list2)
					{
						foreach (OtherSystemSelectedVIiewModel item4 in list)
						{
							if (item4.Row == item3.Row)
							{
								item4.Selected = item3.Selected;
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
		JsonResult jsonResult = Json(list, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[DynamicAuthorize(ControllerName = "frmManageUserLinkAcc", ActionName = "actLinkUserWithAcc")]
	public ActionResult ShygunIILinkedUser()
	{
		return View();
	}

	[HttpPost]
	public JsonResult ActShygunIILinkedUser(string syncField, int mode, int fromRec = 0, int recCount = 100)
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
			List<LinkedUserWithAccViewModel> list = new List<LinkedUserWithAccViewModel>();
			DateTime now = DateTime.Now;
			now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			short.Parse(Financial.Get().Id.ToString());
			_ = UserLogin.CurrentUser.UserId;
			string text3 = "";
			int num = 0;
			if (!UserLogin.IsUserAccess("frmManageUserLinkAcc", "actLinkUserWithAcc", UserLogin.CurrentUser))
			{
				text3 = text3 + Messages.ErrorNotAccess + "<br>";
				num++;
			}
			if (string.IsNullOrWhiteSpace(syncField))
			{
				text3 = text3 + string.Format(Messages.msgErrorIsNotSelectedItem, Labels.OtherSystemsLinkedField) + "<br>";
				num++;
			}
			ShygunIIUserInfoViewModelObjects shygunIIUserList = GetShygunIIUserList(string.Empty, string.Empty, fromRec, recCount, allUser: true);
			if (shygunIIUserList != null && (shygunIIUserList.lst != null || Enumerable.Any<ShygunIIUserInfoViewModel>((IEnumerable<ShygunIIUserInfoViewModel>)shygunIIUserList.lst)))
			{
				foreach (ShygunIIUserInfoViewModel item3 in shygunIIUserList.lst)
				{
					LinkedUserWithAccViewModel item = new LinkedUserWithAccViewModel
					{
						LinkAccUserCode = item3.JobNo,
						LinkAccUserIdStr = item3.GuId,
						UserName = item3.JobName
					};
					list.Add(item);
				}
			}
			if (list == null || !Enumerable.Any<LinkedUserWithAccViewModel>((IEnumerable<LinkedUserWithAccViewModel>)list))
			{
				text3 = string.Format(Messages.msgErrorListUserInLinkAccIsEmpty, Labels.ShygunII) + "<br>";
				num++;
			}
			if (num == 0)
			{
				string text4 = "";
				text = "";
				List<CRMspLkShygunIILinkedUser_Result> list2 = new List<CRMspLkShygunIILinkedUser_Result>();
				int count = list.Count;
				int num2 = 1000;
				int num3 = count / num2;
				if (count % num2 != 0)
				{
					num3++;
				}
				for (int i = 0; i <= num3; i++)
				{
					List<LinkedUserWithAccViewModel> list3 = new List<LinkedUserWithAccViewModel>();
					for (int j = i * num2; j < i * num2 + num2 && j < count; j++)
					{
						LinkedUserWithAccViewModel item2 = new LinkedUserWithAccViewModel
						{
							LinkAccUserCode = list[j].LinkAccUserCode,
							LinkAccUserIdStr = list[j].LinkAccUserIdStr,
							UserName = list[j].UserName
						};
						list3.Add(item2);
					}
					if (Enumerable.Any<LinkedUserWithAccViewModel>((IEnumerable<LinkedUserWithAccViewModel>)list3))
					{
						string itemJson = JsonConvert.SerializeObject(Enumerable.ToList<LinkedUserWithAccViewModel>((IEnumerable<LinkedUserWithAccViewModel>)list3));
						List<CRMspLkShygunIILinkedUser_Result> list4 = Enumerable.ToList<CRMspLkShygunIILinkedUser_Result>((IEnumerable<CRMspLkShygunIILinkedUser_Result>)_dbLink.CRMspLkShygunIILinkedUser(itemJson, syncField, mode, lCID, result));
						if (list4 != null && Enumerable.Any<CRMspLkShygunIILinkedUser_Result>((IEnumerable<CRMspLkShygunIILinkedUser_Result>)list4))
						{
							list2.AddRange(list4);
						}
					}
				}
				if (list2 != null && Enumerable.Any<CRMspLkShygunIILinkedUser_Result>((IEnumerable<CRMspLkShygunIILinkedUser_Result>)list2))
				{
					list2 = Enumerable.ToList<CRMspLkShygunIILinkedUser_Result>(Enumerable.Distinct<CRMspLkShygunIILinkedUser_Result>(Enumerable.Where<CRMspLkShygunIILinkedUser_Result>((IEnumerable<CRMspLkShygunIILinkedUser_Result>)list2, (Func<CRMspLkShygunIILinkedUser_Result, bool>)((CRMspLkShygunIILinkedUser_Result m) => (m.LinkAccUserIdStr ?? "") == "" || m.Type == 1))));
					if (list2 != null && Enumerable.Any<CRMspLkShygunIILinkedUser_Result>((IEnumerable<CRMspLkShygunIILinkedUser_Result>)list2))
					{
						text = "error";
						text4 = GetFileShygunIILinkedUser(list2);
					}
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
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("Users");
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

	public string GetFileShygunIILinkedUser(List<CRMspLkShygunIILinkedUser_Result> res)
	{
		//IL_046d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0488: Unknown result type (might be due to invalid IL or missing references)
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
			if (res != null && Enumerable.Any<CRMspLkShygunIILinkedUser_Result>((IEnumerable<CRMspLkShygunIILinkedUser_Result>)res))
			{
				ExcelPackage excelPackage = new ExcelPackage();
				ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets.Add(Labels.OtherSystemsExcelPropertiesTitle);
				int num = 0;
				int num2 = 1;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsLinkedListUserName;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsListUserPersCode;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsListLinkAccUserCode + " (" + Labels.ShygunII + ")";
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsListLinkAccName;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsListLinkDesc;
				foreach (CRMspLkShygunIILinkedUser_Result re in res)
				{
					num2++;
					num = 0;
					num++;
					excelWorksheet.Cells[num2, num].Value = re.UserName ?? "";
					num++;
					excelWorksheet.Cells[num2, num].Value = re.PersCode ?? "";
					num++;
					excelWorksheet.Cells[num2, num].Value = re.LinkAccUserCode ?? "";
					num++;
					string value = "";
					_ = re.Type;
					if (re.Type == 1)
					{
						value = Labels.ShygunII;
					}
					else if (re.Type == 2)
					{
						value = "CRM";
					}
					excelWorksheet.Cells[num2, num].Value = value;
					string value2 = "";
					int result2 = 0;
					int.TryParse(re.ErrorType.ToString(), out result2);
					switch (result2)
					{
					case 0:
						value2 = Messages.msgErrorUserNotInCRM;
						break;
					case -1:
						value2 = Messages.msgErrorDupLinkAccUserCode;
						break;
					case -2:
						value2 = Messages.msgErrorDupUserPersCode;
						break;
					case -3:
						value2 = string.Format(Messages.msgErrorUserNotInLinkAcc, Labels.ShygunII);
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

	[AjaxOnly]
	public JsonResult GetRolls()
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
			List<CRMspSelectsysRolls_Result> list2 = Enumerable.ToList<CRMspSelectsysRolls_Result>((IEnumerable<CRMspSelectsysRolls_Result>)_db.CRMspSelectsysRolls(lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectsysRolls_Result, SelectListItem>((IEnumerable<CRMspSelectsysRolls_Result>)list2, (Func<CRMspSelectsysRolls_Result, SelectListItem>)((CRMspSelectsysRolls_Result item) => new SelectListItem
			{
				Text = item.RollName,
				Value = item.ID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.RollList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public LkUserInfoViewModelObjects GetTarazUserList(int type = 0)
	{
		//IL_07fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0802: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		LkUserInfoViewModelObjects lkUserInfoViewModelObjects = new LkUserInfoViewModelObjects();
		lkUserInfoViewModelObjects.lst = new List<LkUserInfoViewModel>();
		lkUserInfoViewModelObjects.FilteredLst = new List<LkUserInfoViewModel>();
		List<LkUserInfoViewModel> list = new List<LkUserInfoViewModel>();
		try
		{
			if (type == 0)
			{
				type = 1;
			}
			new List<TarazWarehousesViewModel>();
			List<CRMspSelectLinkAccTarazSetting_Result> list2 = Enumerable.ToList<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)_dbLink.CRMspSelectLinkAccTarazSetting(0, "Setting", lCID, result));
			if (list2 != null)
			{
				string text = "";
				CRMspSelectLinkAccTarazSetting_Result cRMspSelectLinkAccTarazSetting_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)list2, (Func<CRMspSelectLinkAccTarazSetting_Result, bool>)((CRMspSelectLinkAccTarazSetting_Result m) => m.LinkAccTarazSettingId == 1));
				if (cRMspSelectLinkAccTarazSetting_Result != null)
				{
					text = cRMspSelectLinkAccTarazSetting_Result.PartValue ?? "";
				}
				string text2 = "";
				string text3 = "";
				CRMspSelectLinkAccTarazSetting_Result cRMspSelectLinkAccTarazSetting_Result2 = Enumerable.FirstOrDefault<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)list2, (Func<CRMspSelectLinkAccTarazSetting_Result, bool>)((CRMspSelectLinkAccTarazSetting_Result m) => m.LinkAccTarazSettingId == 2));
				if (cRMspSelectLinkAccTarazSetting_Result2 != null)
				{
					text3 = cRMspSelectLinkAccTarazSetting_Result2.PartValue ?? "";
				}
				string text4 = "";
				CRMspSelectLinkAccTarazSetting_Result cRMspSelectLinkAccTarazSetting_Result3 = Enumerable.FirstOrDefault<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)list2, (Func<CRMspSelectLinkAccTarazSetting_Result, bool>)((CRMspSelectLinkAccTarazSetting_Result m) => m.LinkAccTarazSettingId == 3));
				if (cRMspSelectLinkAccTarazSetting_Result3 != null)
				{
					text4 = cRMspSelectLinkAccTarazSetting_Result3.PartValue ?? "";
				}
				CRMspSelectLinkAccTarazSetting_Result cRMspSelectLinkAccTarazSetting_Result4 = Enumerable.FirstOrDefault<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)list2, (Func<CRMspSelectLinkAccTarazSetting_Result, bool>)((CRMspSelectLinkAccTarazSetting_Result m) => m.LinkAccTarazSettingId == 6));
				if (cRMspSelectLinkAccTarazSetting_Result4 != null)
				{
					text2 = cRMspSelectLinkAccTarazSetting_Result4.PartValue ?? "";
				}
				if (!string.IsNullOrWhiteSpace(text) && !string.IsNullOrWhiteSpace(text3) && !string.IsNullOrWhiteSpace(text4))
				{
					if (!text.EndsWith("/"))
					{
						text += "/";
					}
					if (string.IsNullOrWhiteSpace(text2))
					{
						TarazGetAuthViewModel tarazGetAuthViewModel = new TarazGetAuthViewModel();
						tarazGetAuthViewModel.username = text3;
						tarazGetAuthViewModel.password = text4;
						string text5 = "tws/authenticate";
						HttpResponseMessage result2 = new HttpClient
						{
							Timeout = CRMIdeal.Classes.Helper.OtherSystems.RestApiTimeout(),
							BaseAddress = new Uri(text + text5),
							DefaultRequestHeaders = 
							{
								Accept = 
								{
									new MediaTypeWithQualityHeaderValue("application/json")
								}
							}
						}.PostAsync(content: new StringContent(JsonConvert.SerializeObject(tarazGetAuthViewModel), Encoding.UTF8, "application/json"), requestUri: text + text5).Result;
						if (result2.IsSuccessStatusCode)
						{
							TarazGetAuthResultViewModel tarazGetAuthResultViewModel = JsonConvert.DeserializeObject<TarazGetAuthResultViewModel>(result2.Content.ReadAsStringAsync().Result);
							if (!string.IsNullOrWhiteSpace(tarazGetAuthResultViewModel.token))
							{
								text2 = ((!string.IsNullOrEmpty(tarazGetAuthResultViewModel.type)) ? (tarazGetAuthResultViewModel.type + " ") : "Bearer ") + tarazGetAuthResultViewModel.token;
								DbSet<CrmLinkAccTarazSetting> crmLinkAccTarazSetting = _dbTbl.CrmLinkAccTarazSetting;
								ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccTarazSetting), "m");
								CrmLinkAccTarazSetting crmLinkAccTarazSetting2 = Queryable.FirstOrDefault<CrmLinkAccTarazSetting>((IQueryable<CrmLinkAccTarazSetting>)crmLinkAccTarazSetting, Expression.Lambda<Func<CrmLinkAccTarazSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)6, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
								if (crmLinkAccTarazSetting2 != null)
								{
									crmLinkAccTarazSetting2.PartValue = text2;
									_dbTbl.Entry(crmLinkAccTarazSetting2).State = EntityState.Modified;
									_dbTbl.Configuration.ValidateOnSaveEnabled = false;
									_dbTbl.SaveChanges();
									_dbTbl.Configuration.ValidateOnSaveEnabled = true;
								}
							}
						}
					}
					if (!string.IsNullOrWhiteSpace(text2))
					{
						HttpClient httpClient = new HttpClient();
						httpClient.Timeout = CRMIdeal.Classes.Helper.OtherSystems.RestApiTimeout();
						httpClient.BaseAddress = new Uri(text);
						httpClient.DefaultRequestHeaders.Add("Authorization", text2);
						httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
						string requestUri = "tws/sale/marketingmen";
						if (type == 2)
						{
							requestUri = "tws/sale/sellers";
						}
						HttpResponseMessage result3 = httpClient.GetAsync(requestUri).Result;
						if (result3.IsSuccessStatusCode)
						{
							string value = result3.Content.ReadAsStringAsync().Result;
							if (!string.IsNullOrWhiteSpace(value))
							{
								value = value.ClearHiddenCharacters();
							}
							if (!string.IsNullOrWhiteSpace(value))
							{
								switch (type)
								{
								case 1:
								{
									List<TarazMarketingMenViewModel> list5 = JsonConvert.DeserializeObject<List<TarazMarketingMenViewModel>>(value);
									if (list5 == null || !Enumerable.Any<TarazMarketingMenViewModel>((IEnumerable<TarazMarketingMenViewModel>)list5))
									{
										break;
									}
									if (Enumerable.Any<TarazMarketingMenViewModel>((IEnumerable<TarazMarketingMenViewModel>)list5))
									{
										list5 = Enumerable.ToList<TarazMarketingMenViewModel>(Enumerable.Where<TarazMarketingMenViewModel>((IEnumerable<TarazMarketingMenViewModel>)list5, (Func<TarazMarketingMenViewModel, bool>)((TarazMarketingMenViewModel m) => m.isActive.HasValue && m.isActive.GetValueOrDefault())));
									}
									if (list5 == null || !Enumerable.Any<TarazMarketingMenViewModel>((IEnumerable<TarazMarketingMenViewModel>)list5))
									{
										break;
									}
									List<CRMspSelectUsersWithAccLinkField_Result> list6 = Enumerable.ToList<CRMspSelectUsersWithAccLinkField_Result>((IEnumerable<CRMspSelectUsersWithAccLinkField_Result>)_dbLink.CRMspSelectUsersWithAccLinkField(true, false, lCID, result));
									int num2 = 1;
									foreach (TarazMarketingMenViewModel item in list5)
									{
										LkUserInfoViewModel vm = new LkUserInfoViewModel();
										vm.LName = item.customerName ?? "";
										vm.LinkAccUserIdStr = item.customerID.GetValueOrDefault().ToString();
										vm.PersCode = item.customerCode ?? "";
										vm.LinkAccUserCode = vm.PersCode;
										vm.RowNumber = num2;
										CRMspSelectUsersWithAccLinkField_Result cRMspSelectUsersWithAccLinkField_Result2 = Enumerable.FirstOrDefault<CRMspSelectUsersWithAccLinkField_Result>((IEnumerable<CRMspSelectUsersWithAccLinkField_Result>)list6, (Func<CRMspSelectUsersWithAccLinkField_Result, bool>)((CRMspSelectUsersWithAccLinkField_Result x) => x.LinkAccUserIdStr == vm.LinkAccUserIdStr));
										if (cRMspSelectUsersWithAccLinkField_Result2 != null && !string.IsNullOrWhiteSpace(cRMspSelectUsersWithAccLinkField_Result2.LinkAccUserIdStr))
										{
											vm.UserId = cRMspSelectUsersWithAccLinkField_Result2.UserId;
										}
										else
										{
											vm.UserId = 0;
										}
										list.Add(vm);
										num2++;
									}
									break;
								}
								case 2:
								{
									List<TarazSellerViewModel> list3 = JsonConvert.DeserializeObject<List<TarazSellerViewModel>>(value);
									if (list3 == null || !Enumerable.Any<TarazSellerViewModel>((IEnumerable<TarazSellerViewModel>)list3))
									{
										break;
									}
									if (Enumerable.Any<TarazSellerViewModel>((IEnumerable<TarazSellerViewModel>)list3))
									{
										list3 = Enumerable.ToList<TarazSellerViewModel>(Enumerable.Where<TarazSellerViewModel>((IEnumerable<TarazSellerViewModel>)list3, (Func<TarazSellerViewModel, bool>)((TarazSellerViewModel m) => m.isActive.HasValue && m.isActive.GetValueOrDefault())));
									}
									if (list3 == null || !Enumerable.Any<TarazSellerViewModel>((IEnumerable<TarazSellerViewModel>)list3))
									{
										break;
									}
									List<CRMspSelectUsersWithAccLinkField_Result> list4 = Enumerable.ToList<CRMspSelectUsersWithAccLinkField_Result>((IEnumerable<CRMspSelectUsersWithAccLinkField_Result>)_dbLink.CRMspSelectUsersWithAccLinkField(true, false, lCID, result));
									int num = 1;
									foreach (TarazSellerViewModel item2 in list3)
									{
										LkUserInfoViewModel vm2 = new LkUserInfoViewModel();
										vm2.LName = item2.customerName ?? "";
										vm2.LinkAccUserIdStr = item2.customerID.GetValueOrDefault().ToString();
										vm2.PersCode = item2.customerCode ?? "";
										vm2.LinkAccUserCode = vm2.PersCode;
										vm2.Description = item2.customerDesc;
										vm2.RowNumber = num;
										CRMspSelectUsersWithAccLinkField_Result cRMspSelectUsersWithAccLinkField_Result = Enumerable.FirstOrDefault<CRMspSelectUsersWithAccLinkField_Result>((IEnumerable<CRMspSelectUsersWithAccLinkField_Result>)list4, (Func<CRMspSelectUsersWithAccLinkField_Result, bool>)((CRMspSelectUsersWithAccLinkField_Result x) => x.LinkAccUserIdStr == vm2.LinkAccUserIdStr));
										if (cRMspSelectUsersWithAccLinkField_Result != null && !string.IsNullOrWhiteSpace(cRMspSelectUsersWithAccLinkField_Result.LinkAccUserIdStr))
										{
											vm2.UserId = cRMspSelectUsersWithAccLinkField_Result.UserId;
										}
										else
										{
											vm2.UserId = 0;
										}
										list.Add(vm2);
										num++;
									}
									break;
								}
								}
							}
						}
						else
						{
							HttpStatusCode statusCode = result3.StatusCode;
							if (((object)(HttpStatusCode)(ref statusCode)).ToString() == "Unauthorized")
							{
								DbSet<CrmLinkAccTarazSetting> crmLinkAccTarazSetting3 = _dbTbl.CrmLinkAccTarazSetting;
								ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccTarazSetting), "m");
								CrmLinkAccTarazSetting crmLinkAccTarazSetting4 = Queryable.FirstOrDefault<CrmLinkAccTarazSetting>((IQueryable<CrmLinkAccTarazSetting>)crmLinkAccTarazSetting3, Expression.Lambda<Func<CrmLinkAccTarazSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)6, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
								if (crmLinkAccTarazSetting4 != null)
								{
									crmLinkAccTarazSetting4.PartValue = "";
									_dbTbl.Entry(crmLinkAccTarazSetting4).State = EntityState.Modified;
									_dbTbl.Configuration.ValidateOnSaveEnabled = false;
									_dbTbl.SaveChanges();
									_dbTbl.Configuration.ValidateOnSaveEnabled = true;
								}
							}
							else
							{
								TarazExceptionViewModel tarazExceptionViewModel = JsonConvert.DeserializeObject<TarazExceptionViewModel>(result3.Content.ReadAsStringAsync().Result);
								if (tarazExceptionViewModel != null)
								{
									_ = tarazExceptionViewModel.status;
									if (tarazExceptionViewModel.status == 401)
									{
										DbSet<CrmLinkAccTarazSetting> crmLinkAccTarazSetting5 = _dbTbl.CrmLinkAccTarazSetting;
										ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccTarazSetting), "m");
										CrmLinkAccTarazSetting crmLinkAccTarazSetting6 = Queryable.FirstOrDefault<CrmLinkAccTarazSetting>((IQueryable<CrmLinkAccTarazSetting>)crmLinkAccTarazSetting5, Expression.Lambda<Func<CrmLinkAccTarazSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)6, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
										if (crmLinkAccTarazSetting6 != null)
										{
											crmLinkAccTarazSetting6.PartValue = "";
											_dbTbl.Entry(crmLinkAccTarazSetting6).State = EntityState.Modified;
											_dbTbl.Configuration.ValidateOnSaveEnabled = false;
											_dbTbl.SaveChanges();
											_dbTbl.Configuration.ValidateOnSaveEnabled = true;
										}
									}
								}
							}
						}
					}
				}
			}
			lkUserInfoViewModelObjects.lst = list;
			lkUserInfoViewModelObjects.FilteredLst = list;
			lkUserInfoViewModelObjects.Json = Json(list, JsonRequestBehavior.AllowGet);
			lkUserInfoViewModelObjects.SerializedJson = JsonConvert.SerializeObject(list);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return lkUserInfoViewModelObjects;
	}

	public LkUserInfoViewModelObjects GetNoAvIIUserList()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		LkUserInfoViewModelObjects lkUserInfoViewModelObjects = new LkUserInfoViewModelObjects();
		lkUserInfoViewModelObjects.lst = new List<LkUserInfoViewModel>();
		lkUserInfoViewModelObjects.FilteredLst = new List<LkUserInfoViewModel>();
		List<LkUserInfoViewModel> list = new List<LkUserInfoViewModel>();
		try
		{
			string text = "";
			CRMspSelectLinkAccNoAvIISetting_Result cRMspSelectLinkAccNoAvIISetting_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccNoAvIISetting_Result>((IEnumerable<CRMspSelectLinkAccNoAvIISetting_Result>)_dbLink.CRMspSelectLinkAccNoAvIISetting(2, "Setting", lCID, result));
			if (cRMspSelectLinkAccNoAvIISetting_Result != null)
			{
				text = cRMspSelectLinkAccNoAvIISetting_Result.PartValue ?? "";
				_ = cRMspSelectLinkAccNoAvIISetting_Result.PartDescription;
			}
			if (!string.IsNullOrWhiteSpace(text))
			{
				string value = new ServiceSoapClient().ReadFromBazaryaban(string.Empty, text);
				if (!string.IsNullOrWhiteSpace(value))
				{
					value = value.ClearHiddenCharacters();
				}
				if (!string.IsNullOrWhiteSpace(value))
				{
					List<NoAvaranIIUserInfoViewModel> list2 = JsonConvert.DeserializeObject<List<NoAvaranIIUserInfoViewModel>>(value);
					if (list2 != null && Enumerable.Any<NoAvaranIIUserInfoViewModel>((IEnumerable<NoAvaranIIUserInfoViewModel>)list2))
					{
						List<CRMspSelectUsersWithAccLinkField_Result> list3 = Enumerable.ToList<CRMspSelectUsersWithAccLinkField_Result>((IEnumerable<CRMspSelectUsersWithAccLinkField_Result>)_dbLink.CRMspSelectUsersWithAccLinkField(false, true, lCID, result));
						int num = 1;
						foreach (NoAvaranIIUserInfoViewModel item in list2)
						{
							LkUserInfoViewModel vm = new LkUserInfoViewModel();
							vm.LName = item.Dis ?? "";
							vm.LinkAccUserIdStr = item.Part.ToString();
							vm.PersCode = item.Part.ToString();
							vm.LinkAccUserCode = vm.PersCode;
							vm.RowNumber = num;
							CRMspSelectUsersWithAccLinkField_Result cRMspSelectUsersWithAccLinkField_Result = Enumerable.FirstOrDefault<CRMspSelectUsersWithAccLinkField_Result>((IEnumerable<CRMspSelectUsersWithAccLinkField_Result>)list3, (Func<CRMspSelectUsersWithAccLinkField_Result, bool>)((CRMspSelectUsersWithAccLinkField_Result x) => x.LinkAccUserCode == vm.LinkAccUserCode));
							if (cRMspSelectUsersWithAccLinkField_Result != null && !string.IsNullOrWhiteSpace(cRMspSelectUsersWithAccLinkField_Result.LinkAccUserIdStr))
							{
								vm.UserId = cRMspSelectUsersWithAccLinkField_Result.UserId;
							}
							else
							{
								vm.UserId = 0;
							}
							list.Add(vm);
							num++;
						}
					}
				}
			}
			lkUserInfoViewModelObjects.lst = list;
			lkUserInfoViewModelObjects.FilteredLst = list;
			lkUserInfoViewModelObjects.Json = Json(list, JsonRequestBehavior.AllowGet);
			lkUserInfoViewModelObjects.SerializedJson = JsonConvert.SerializeObject(list);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return lkUserInfoViewModelObjects;
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

	public ArpaUserInfoViewModelObjects GetArpaUserList()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		ArpaUserInfoViewModelObjects arpaUserInfoViewModelObjects = new ArpaUserInfoViewModelObjects();
		arpaUserInfoViewModelObjects.lst = new List<LkUserInfoViewModel>();
		arpaUserInfoViewModelObjects.FilteredLst = new List<LkUserInfoViewModel>();
		List<LkUserInfoViewModel> list = new List<LkUserInfoViewModel>();
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
						string text3 = text + "api/GetRepresentors" + text2;
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
							ArpaUserResponseViewModel arpaUserResponseViewModel = JsonConvert.DeserializeObject<ArpaUserResponseViewModel>(value2);
							if (arpaUserResponseViewModel != null && arpaUserResponseViewModel.data != null && Enumerable.Any<ArpaUserInfoViewModel>((IEnumerable<ArpaUserInfoViewModel>)arpaUserResponseViewModel.data))
							{
								List<CRMspSelectUsersWithAccLinkField_Result> list2 = Enumerable.ToList<CRMspSelectUsersWithAccLinkField_Result>((IEnumerable<CRMspSelectUsersWithAccLinkField_Result>)_dbLink.CRMspSelectUsersWithAccLinkField(true, false, lCID, result));
								int num = 1;
								foreach (ArpaUserInfoViewModel item in arpaUserResponseViewModel.data)
								{
									LkUserInfoViewModel lkUserInfoViewModel = new LkUserInfoViewModel();
									lkUserInfoViewModel.LName = item.RepresentorName;
									lkUserInfoViewModel.Address = item.Address;
									lkUserInfoViewModel.Tel = item.PhoneNo;
									lkUserInfoViewModel.NationalCode = item.FinCode;
									lkUserInfoViewModel.Mobile = item.Mobile;
									lkUserInfoViewModel.LinkAccUserIdStr = item.RepresentorID;
									lkUserInfoViewModel.PersCode = item.RepresentorCode;
									lkUserInfoViewModel.LinkAccUserCode = item.RepresentorCode;
									lkUserInfoViewModel.RowNumber = num;
									CRMspSelectUsersWithAccLinkField_Result cRMspSelectUsersWithAccLinkField_Result = Enumerable.FirstOrDefault<CRMspSelectUsersWithAccLinkField_Result>((IEnumerable<CRMspSelectUsersWithAccLinkField_Result>)list2, (Func<CRMspSelectUsersWithAccLinkField_Result, bool>)((CRMspSelectUsersWithAccLinkField_Result x) => x.LinkAccUserIdStr == item.RepresentorID));
									if (cRMspSelectUsersWithAccLinkField_Result != null && !string.IsNullOrWhiteSpace(cRMspSelectUsersWithAccLinkField_Result.LinkAccUserIdStr))
									{
										lkUserInfoViewModel.UserId = cRMspSelectUsersWithAccLinkField_Result.UserId;
									}
									else
									{
										lkUserInfoViewModel.UserId = 0;
									}
									list.Add(lkUserInfoViewModel);
									num++;
								}
							}
						}
					}
				}
			}
			arpaUserInfoViewModelObjects.lst = list;
			arpaUserInfoViewModelObjects.FilteredLst = list;
			arpaUserInfoViewModelObjects.Json = Json(list, JsonRequestBehavior.AllowGet);
			arpaUserInfoViewModelObjects.SerializedJson = JsonConvert.SerializeObject(list);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return arpaUserInfoViewModelObjects;
	}

	public LkUserInfoViewModelObjects GetHamrahanUserList()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		LkUserInfoViewModelObjects lkUserInfoViewModelObjects = new LkUserInfoViewModelObjects();
		lkUserInfoViewModelObjects.lst = new List<LkUserInfoViewModel>();
		lkUserInfoViewModelObjects.FilteredLst = new List<LkUserInfoViewModel>();
		List<LkUserInfoViewModel> list = new List<LkUserInfoViewModel>();
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
						string text4 = text + "DefineSeller/company/" + text3;
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
								List<HamrahanUserInfoViewModel> list2 = JsonConvert.DeserializeObject<List<HamrahanUserInfoViewModel>>(value2);
								if (list2 != null && Enumerable.Any<HamrahanUserInfoViewModel>((IEnumerable<HamrahanUserInfoViewModel>)list2))
								{
									List<CRMspSelectUsersWithAccLinkField_Result> list3 = Enumerable.ToList<CRMspSelectUsersWithAccLinkField_Result>((IEnumerable<CRMspSelectUsersWithAccLinkField_Result>)_dbLink.CRMspSelectUsersWithAccLinkField(true, false, lCID, result));
									int num = 1;
									foreach (HamrahanUserInfoViewModel item in list2)
									{
										LkUserInfoViewModel vm = new LkUserInfoViewModel();
										vm.LName = item.sellerName;
										vm.LinkAccUserIdStr = item.recNo.GetValueOrDefault().ToString();
										vm.PersCode = item.codeFormal;
										vm.LinkAccUserCode = item.codeFormal;
										HamrahanLinkAccDataViewModel value3 = new HamrahanLinkAccDataViewModel
										{
											refFormal = item.refFormal.GetValueOrDefault(),
											rnGroupFormal = item.rnGroupFormal.GetValueOrDefault()
										};
										vm.LinkAccData = "[" + JsonConvert.SerializeObject(value3) + "]";
										vm.RowNumber = num;
										CRMspSelectUsersWithAccLinkField_Result cRMspSelectUsersWithAccLinkField_Result = Enumerable.FirstOrDefault<CRMspSelectUsersWithAccLinkField_Result>((IEnumerable<CRMspSelectUsersWithAccLinkField_Result>)list3, (Func<CRMspSelectUsersWithAccLinkField_Result, bool>)((CRMspSelectUsersWithAccLinkField_Result x) => x.LinkAccUserIdStr == vm.LinkAccUserIdStr));
										if (cRMspSelectUsersWithAccLinkField_Result != null && !string.IsNullOrWhiteSpace(cRMspSelectUsersWithAccLinkField_Result.LinkAccUserIdStr))
										{
											vm.UserId = cRMspSelectUsersWithAccLinkField_Result.UserId;
										}
										else
										{
											vm.UserId = 0;
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
			lkUserInfoViewModelObjects.lst = list;
			lkUserInfoViewModelObjects.FilteredLst = list;
			lkUserInfoViewModelObjects.Json = Json(list, JsonRequestBehavior.AllowGet);
			lkUserInfoViewModelObjects.SerializedJson = JsonConvert.SerializeObject(list);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return lkUserInfoViewModelObjects;
	}

	public LkUserInfoViewModelObjects GetNoAvaranCapillaryUserList()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		LkUserInfoViewModelObjects lkUserInfoViewModelObjects = new LkUserInfoViewModelObjects();
		lkUserInfoViewModelObjects.lst = new List<LkUserInfoViewModel>();
		lkUserInfoViewModelObjects.FilteredLst = new List<LkUserInfoViewModel>();
		List<LkUserInfoViewModel> list = new List<LkUserInfoViewModel>();
		try
		{
			CRMIdeal.Classes.Helper.OtherSystems.NoAvaranCapillarySettingViewModel noAvaranCapillarySetting = CRMIdeal.Classes.Helper.OtherSystems.GetNoAvaranCapillarySetting();
			if (noAvaranCapillarySetting != null && !string.IsNullOrWhiteSpace(noAvaranCapillarySetting.ApiUserId ?? ""))
			{
				string value = new CommercialSoapClient().GetSalesmanList();
				if (!string.IsNullOrWhiteSpace(value))
				{
					value = value.ClearHiddenCharacters();
				}
				if (!string.IsNullOrWhiteSpace(value))
				{
					List<NoAvaranCapillaryUserInfoViewModel> list2 = JsonConvert.DeserializeObject<List<NoAvaranCapillaryUserInfoViewModel>>(value);
					if (list2 != null && Enumerable.Any<NoAvaranCapillaryUserInfoViewModel>((IEnumerable<NoAvaranCapillaryUserInfoViewModel>)list2))
					{
						List<CRMspSelectUsersWithAccLinkField_Result> list3 = Enumerable.ToList<CRMspSelectUsersWithAccLinkField_Result>((IEnumerable<CRMspSelectUsersWithAccLinkField_Result>)_dbLink.CRMspSelectUsersWithAccLinkField(true, false, lCID, result));
						int num = 1;
						foreach (NoAvaranCapillaryUserInfoViewModel item in list2)
						{
							LkUserInfoViewModel vm = new LkUserInfoViewModel();
							vm.FName = item.FirstName;
							vm.LName = item.LastName ?? "";
							if (string.IsNullOrWhiteSpace(vm.LName))
							{
								vm.LName = item.FirstName ?? "";
							}
							vm.LinkAccUserIdStr = item.id.GetValueOrDefault().ToString();
							vm.PersCode = item.Code1 ?? "";
							vm.LinkAccUserCode = vm.PersCode;
							vm.Address = item.Address;
							vm.Tel = item.Tel;
							vm.Mobile = item.Mobile;
							vm.NationalCode = item.CodeMeli;
							vm.RowNumber = num;
							CRMspSelectUsersWithAccLinkField_Result cRMspSelectUsersWithAccLinkField_Result = Enumerable.FirstOrDefault<CRMspSelectUsersWithAccLinkField_Result>((IEnumerable<CRMspSelectUsersWithAccLinkField_Result>)list3, (Func<CRMspSelectUsersWithAccLinkField_Result, bool>)((CRMspSelectUsersWithAccLinkField_Result x) => x.LinkAccUserIdStr == vm.LinkAccUserIdStr));
							if (cRMspSelectUsersWithAccLinkField_Result != null && !string.IsNullOrWhiteSpace(cRMspSelectUsersWithAccLinkField_Result.LinkAccUserIdStr))
							{
								vm.UserId = cRMspSelectUsersWithAccLinkField_Result.UserId;
							}
							else
							{
								vm.UserId = 0;
							}
							list.Add(vm);
							num++;
						}
					}
				}
			}
			lkUserInfoViewModelObjects.lst = list;
			lkUserInfoViewModelObjects.FilteredLst = list;
			lkUserInfoViewModelObjects.Json = Json(list, JsonRequestBehavior.AllowGet);
			lkUserInfoViewModelObjects.SerializedJson = JsonConvert.SerializeObject(list);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return lkUserInfoViewModelObjects;
	}

	public LkUserInfoViewModelObjects GetRahkaranInternalSalesUserList()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		LkUserInfoViewModelObjects lkUserInfoViewModelObjects = new LkUserInfoViewModelObjects();
		lkUserInfoViewModelObjects.lst = new List<LkUserInfoViewModel>();
		lkUserInfoViewModelObjects.FilteredLst = new List<LkUserInfoViewModel>();
		List<LkUserInfoViewModel> list = new List<LkUserInfoViewModel>();
		try
		{
			string value = new CRMIdeal.Classes.Helper.OtherSystems.RahkaranInternalSalesProvider().GetBrokers();
			if (!string.IsNullOrWhiteSpace(value))
			{
				value = value.ClearHiddenCharacters();
			}
			if (!string.IsNullOrWhiteSpace(value))
			{
				List<RahkaranInternalSalesBrokersResponseViewModel> list2 = JsonConvert.DeserializeObject<List<RahkaranInternalSalesBrokersResponseViewModel>>(value);
				if (list2 != null && Enumerable.Any<RahkaranInternalSalesBrokersResponseViewModel>((IEnumerable<RahkaranInternalSalesBrokersResponseViewModel>)list2))
				{
					List<CRMspSelectUsersWithAccLinkField_Result> list3 = Enumerable.ToList<CRMspSelectUsersWithAccLinkField_Result>((IEnumerable<CRMspSelectUsersWithAccLinkField_Result>)_dbLink.CRMspSelectUsersWithAccLinkField(true, false, lCID, result));
					int num = 1;
					foreach (RahkaranInternalSalesBrokersResponseViewModel item in list2)
					{
						LkUserInfoViewModel vm = new LkUserInfoViewModel();
						vm.FName = item.firstName;
						vm.LName = item.lastName ?? "";
						if (string.IsNullOrWhiteSpace(vm.LName))
						{
							vm.LName = item.firstName ?? "";
						}
						vm.LinkAccUserIdStr = item.id;
						vm.PersCode = item.code ?? "";
						vm.LinkAccUserCode = vm.PersCode;
						vm.RowNumber = num;
						CRMspSelectUsersWithAccLinkField_Result cRMspSelectUsersWithAccLinkField_Result = Enumerable.FirstOrDefault<CRMspSelectUsersWithAccLinkField_Result>((IEnumerable<CRMspSelectUsersWithAccLinkField_Result>)list3, (Func<CRMspSelectUsersWithAccLinkField_Result, bool>)((CRMspSelectUsersWithAccLinkField_Result x) => x.LinkAccUserIdStr == vm.LinkAccUserIdStr));
						if (cRMspSelectUsersWithAccLinkField_Result != null && !string.IsNullOrWhiteSpace(cRMspSelectUsersWithAccLinkField_Result.LinkAccUserIdStr))
						{
							vm.UserId = cRMspSelectUsersWithAccLinkField_Result.UserId;
						}
						else
						{
							vm.UserId = 0;
						}
						list.Add(vm);
						num++;
					}
				}
			}
			lkUserInfoViewModelObjects.lst = list;
			lkUserInfoViewModelObjects.FilteredLst = list;
			lkUserInfoViewModelObjects.Json = Json(list, JsonRequestBehavior.AllowGet);
			lkUserInfoViewModelObjects.SerializedJson = JsonConvert.SerializeObject(list);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return lkUserInfoViewModelObjects;
	}

	public LkUserInfoViewModelObjects GetArianSystemUserList()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		LkUserInfoViewModelObjects lkUserInfoViewModelObjects = new LkUserInfoViewModelObjects();
		lkUserInfoViewModelObjects.lst = new List<LkUserInfoViewModel>();
		lkUserInfoViewModelObjects.FilteredLst = new List<LkUserInfoViewModel>();
		List<LkUserInfoViewModel> list = new List<LkUserInfoViewModel>();
		try
		{
			List<ArianSystemUserResponseViewModel> sellerVisitors = new CRMIdeal.Classes.Helper.OtherSystems.ArianSystemProvider().GetSellerVisitors();
			if (sellerVisitors != null && Enumerable.Any<ArianSystemUserResponseViewModel>((IEnumerable<ArianSystemUserResponseViewModel>)sellerVisitors))
			{
				List<CRMspSelectUsersWithAccLinkField_Result> list2 = Enumerable.ToList<CRMspSelectUsersWithAccLinkField_Result>((IEnumerable<CRMspSelectUsersWithAccLinkField_Result>)_dbLink.CRMspSelectUsersWithAccLinkField(true, false, lCID, result));
				int num = 1;
				foreach (ArianSystemUserResponseViewModel item in sellerVisitors)
				{
					LkUserInfoViewModel vm = new LkUserInfoViewModel();
					vm.LName = item.SellerVisitorDesc ?? "";
					vm.LinkAccUserIdStr = item.SellerVisitorID.GetValueOrDefault().ToString();
					vm.PersCode = item.PersonCode ?? "";
					vm.LinkAccUserCode = vm.PersCode;
					vm.RowNumber = num;
					CRMspSelectUsersWithAccLinkField_Result cRMspSelectUsersWithAccLinkField_Result = Enumerable.FirstOrDefault<CRMspSelectUsersWithAccLinkField_Result>((IEnumerable<CRMspSelectUsersWithAccLinkField_Result>)list2, (Func<CRMspSelectUsersWithAccLinkField_Result, bool>)((CRMspSelectUsersWithAccLinkField_Result x) => x.LinkAccUserIdStr == vm.LinkAccUserIdStr));
					if (cRMspSelectUsersWithAccLinkField_Result != null && !string.IsNullOrWhiteSpace(cRMspSelectUsersWithAccLinkField_Result.LinkAccUserIdStr))
					{
						vm.UserId = cRMspSelectUsersWithAccLinkField_Result.UserId;
					}
					else
					{
						vm.UserId = 0;
					}
					list.Add(vm);
					num++;
				}
			}
			lkUserInfoViewModelObjects.lst = list;
			lkUserInfoViewModelObjects.FilteredLst = list;
			lkUserInfoViewModelObjects.Json = Json(list, JsonRequestBehavior.AllowGet);
			lkUserInfoViewModelObjects.SerializedJson = JsonConvert.SerializeObject(list);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return lkUserInfoViewModelObjects;
	}

	[DynamicAuthorize(ControllerName = "frmDefineUsers", ActionName = "actManageUserLinkAcc")]
	public ActionResult ManageUserLinkAcc(int linkAccSystemId)
	{
		GetRolls();
		base.ViewBag.LinkAccSystemId = linkAccSystemId;
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmManageUserLinkAcc", ActionName = "actImportShowInfo")]
	public ActionResult ManageImportUser_Read([DataSourceRequest] DataSourceRequest request, int linkAccSystemId, int type = 0)
	{
		List<LkUserInfoViewModel> list = new List<LkUserInfoViewModel>();
		switch (linkAccSystemId)
		{
		case 3:
		{
			LkUserInfoViewModelObjects tarazUserList = GetTarazUserList(type);
			if (tarazUserList != null)
			{
				list = tarazUserList.lst;
			}
			break;
		}
		case 5:
		{
			LkUserInfoViewModelObjects noAvIIUserList = GetNoAvIIUserList();
			if (noAvIIUserList != null)
			{
				list = noAvIIUserList.lst;
			}
			break;
		}
		case 12:
		{
			ArpaUserInfoViewModelObjects arpaUserList = GetArpaUserList();
			if (arpaUserList != null)
			{
				list = arpaUserList.lst;
			}
			break;
		}
		case 17:
		{
			LkUserInfoViewModelObjects hamrahanUserList = GetHamrahanUserList();
			if (hamrahanUserList != null)
			{
				list = hamrahanUserList.lst;
			}
			break;
		}
		case 18:
		{
			LkUserInfoViewModelObjects noAvaranCapillaryUserList = GetNoAvaranCapillaryUserList();
			if (noAvaranCapillaryUserList != null)
			{
				list = noAvaranCapillaryUserList.lst;
			}
			break;
		}
		case 22:
		{
			LkUserInfoViewModelObjects rahkaranInternalSalesUserList = GetRahkaranInternalSalesUserList();
			if (rahkaranInternalSalesUserList != null)
			{
				list = rahkaranInternalSalesUserList.lst;
			}
			break;
		}
		case 25:
		{
			LkUserInfoViewModelObjects arianSystemUserList = GetArianSystemUserList();
			if (arianSystemUserList != null)
			{
				list = arianSystemUserList.lst;
			}
			break;
		}
		}
		if (list != null && Enumerable.Any<LkUserInfoViewModel>((IEnumerable<LkUserInfoViewModel>)list))
		{
			foreach (LkUserInfoViewModel item in list)
			{
				item.LName = ((!string.IsNullOrWhiteSpace(item.FName)) ? (item.FName + " ") : "") + ((!string.IsNullOrWhiteSpace(item.LName)) ? (item.LName ?? "") : "");
			}
		}
		if (list == null)
		{
			list = new List<LkUserInfoViewModel>();
		}
		JsonResult jsonResult = Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult GetManageImportUserList(string records, int linkAccSystemId, int type = 0)
	{
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		List<OtherSystemSelectedVIiewModel> list = new List<OtherSystemSelectedVIiewModel>();
		try
		{
			List<LkUserInfoViewModel> list2 = new List<LkUserInfoViewModel>();
			switch (linkAccSystemId)
			{
			case 3:
			{
				LkUserInfoViewModelObjects tarazUserList = GetTarazUserList(type);
				if (tarazUserList != null)
				{
					list2 = tarazUserList.lst;
				}
				break;
			}
			case 5:
			{
				LkUserInfoViewModelObjects noAvIIUserList = GetNoAvIIUserList();
				if (noAvIIUserList != null)
				{
					list2 = noAvIIUserList.lst;
				}
				break;
			}
			case 12:
			{
				ArpaUserInfoViewModelObjects arpaUserList = GetArpaUserList();
				if (arpaUserList != null)
				{
					list2 = arpaUserList.lst;
				}
				break;
			}
			case 17:
			{
				LkUserInfoViewModelObjects hamrahanUserList = GetHamrahanUserList();
				if (hamrahanUserList != null)
				{
					list2 = hamrahanUserList.lst;
				}
				break;
			}
			case 18:
			{
				LkUserInfoViewModelObjects noAvaranCapillaryUserList = GetNoAvaranCapillaryUserList();
				if (noAvaranCapillaryUserList != null)
				{
					list2 = noAvaranCapillaryUserList.lst;
				}
				break;
			}
			case 22:
			{
				LkUserInfoViewModelObjects rahkaranInternalSalesUserList = GetRahkaranInternalSalesUserList();
				if (rahkaranInternalSalesUserList != null)
				{
					list2 = rahkaranInternalSalesUserList.lst;
				}
				break;
			}
			case 25:
			{
				LkUserInfoViewModelObjects arianSystemUserList = GetArianSystemUserList();
				if (arianSystemUserList != null)
				{
					list2 = arianSystemUserList.lst;
				}
				break;
			}
			}
			if (list2 != null && Enumerable.Any<LkUserInfoViewModel>((IEnumerable<LkUserInfoViewModel>)list2))
			{
				foreach (LkUserInfoViewModel item2 in list2)
				{
					OtherSystemSelectedVIiewModel item = new OtherSystemSelectedVIiewModel
					{
						Row = item2.RowNumber,
						Id = (item2.LinkAccUserIdStr ?? "0"),
						Selected = (item2.UserId <= 0)
					};
					list.Add(item);
				}
			}
			if (list != null)
			{
				if (!string.IsNullOrWhiteSpace(records))
				{
					List<OtherSystemSelectedVIiewModel> list3 = new List<OtherSystemSelectedVIiewModel>();
					list3 = new JavaScriptSerializer().Deserialize<List<OtherSystemSelectedVIiewModel>>(records);
					if (Enumerable.Any<OtherSystemSelectedVIiewModel>((IEnumerable<OtherSystemSelectedVIiewModel>)list3))
					{
						foreach (OtherSystemSelectedVIiewModel item3 in list3)
						{
							foreach (OtherSystemSelectedVIiewModel item4 in list)
							{
								if (item4.Row == item3.Row)
								{
									item4.Selected = item3.Selected;
								}
							}
						}
					}
				}
			}
			else
			{
				list = new List<OtherSystemSelectedVIiewModel>();
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

	[DynamicAuthorize(ControllerName = "frmManageUserLinkAcc", ActionName = "actImportInfo")]
	[AjaxOnly]
	public JsonResult ManageUserImportInfo(string records, int linkAccSystemId, int rollId = 0, int type = 0)
	{
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		int num = 0;
		string text = "";
		CommonResultStatusViewModel commonResultStatusViewModel = CommonResultStatusViewModel.Success;
		CommonResultViewModel<int> data;
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
			short result2 = 0;
			short.TryParse(id.ToString(), out result2);
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
			List<OtherSystemSelectedVIiewModel> list = new List<OtherSystemSelectedVIiewModel>();
			List<OtherSystemSelectedVIiewModel> list2 = new List<OtherSystemSelectedVIiewModel>();
			if (!string.IsNullOrWhiteSpace(records))
			{
				list = new JavaScriptSerializer().Deserialize<List<OtherSystemSelectedVIiewModel>>(records);
				if (Enumerable.Any<OtherSystemSelectedVIiewModel>((IEnumerable<OtherSystemSelectedVIiewModel>)list))
				{
					list2 = Enumerable.ToList<OtherSystemSelectedVIiewModel>(Enumerable.Where<OtherSystemSelectedVIiewModel>((IEnumerable<OtherSystemSelectedVIiewModel>)list, (Func<OtherSystemSelectedVIiewModel, bool>)((OtherSystemSelectedVIiewModel m) => m.Selected)));
				}
			}
			List<LkUserInfoViewModel> list3 = new List<LkUserInfoViewModel>();
			switch (linkAccSystemId)
			{
			case 3:
			{
				LkUserInfoViewModelObjects tarazUserList = GetTarazUserList(type);
				if (tarazUserList != null)
				{
					List<LkUserInfoViewModel> lst3 = tarazUserList.lst;
					if (lst3 != null)
					{
						if (Enumerable.Any<LkUserInfoViewModel>((IEnumerable<LkUserInfoViewModel>)lst3))
						{
							if (list2 == null)
							{
								break;
							}
							foreach (OtherSystemSelectedVIiewModel item5 in list2)
							{
								LkUserInfoViewModel lkUserInfoViewModel3 = Enumerable.FirstOrDefault<LkUserInfoViewModel>((IEnumerable<LkUserInfoViewModel>)lst3, (Func<LkUserInfoViewModel, bool>)((LkUserInfoViewModel x) => x.LinkAccUserIdStr == item5.Id));
								if (lkUserInfoViewModel3 != null)
								{
									list3.Add(lkUserInfoViewModel3);
								}
							}
						}
						else
						{
							string text8 = Messages.msgErrorRunFunction + " (get list from Taraz) ";
							Exception e7 = new Exception(text8);
							ErrorSignal.FromCurrentContext().Raise(e7);
							text = text8;
						}
					}
					else
					{
						string text9 = Messages.msgErrorRunFunction + " (get list from Taraz) ";
						Exception e8 = new Exception(text9);
						ErrorSignal.FromCurrentContext().Raise(e8);
						text = text9;
					}
				}
				else
				{
					string text10 = Messages.msgErrorRunFunction + " (get list from Taraz) ";
					Exception e9 = new Exception(text10);
					ErrorSignal.FromCurrentContext().Raise(e9);
					text = text10;
				}
				break;
			}
			case 5:
			{
				LkUserInfoViewModelObjects noAvIIUserList = GetNoAvIIUserList();
				if (noAvIIUserList != null)
				{
					List<LkUserInfoViewModel> lst5 = noAvIIUserList.lst;
					if (lst5 != null)
					{
						if (Enumerable.Any<LkUserInfoViewModel>((IEnumerable<LkUserInfoViewModel>)lst5))
						{
							if (list2 == null)
							{
								break;
							}
							foreach (OtherSystemSelectedVIiewModel item3 in list2)
							{
								LkUserInfoViewModel lkUserInfoViewModel5 = Enumerable.FirstOrDefault<LkUserInfoViewModel>((IEnumerable<LkUserInfoViewModel>)lst5, (Func<LkUserInfoViewModel, bool>)((LkUserInfoViewModel x) => x.LinkAccUserIdStr == item3.Id));
								if (lkUserInfoViewModel5 != null)
								{
									list3.Add(lkUserInfoViewModel5);
								}
							}
						}
						else
						{
							string text14 = Messages.msgErrorRunFunction + " (get list from NoAvaran) ";
							Exception e13 = new Exception(text14);
							ErrorSignal.FromCurrentContext().Raise(e13);
							text = text14;
						}
					}
					else
					{
						string text15 = Messages.msgErrorRunFunction + " (get list from NoAvaran) ";
						Exception e14 = new Exception(text15);
						ErrorSignal.FromCurrentContext().Raise(e14);
						text = text15;
					}
				}
				else
				{
					string text16 = Messages.msgErrorRunFunction + " (get list from NoAvaran) ";
					Exception e15 = new Exception(text16);
					ErrorSignal.FromCurrentContext().Raise(e15);
					text = text16;
				}
				break;
			}
			case 12:
			{
				ArpaUserInfoViewModelObjects arpaUserList = GetArpaUserList();
				if (arpaUserList != null)
				{
					List<LkUserInfoViewModel> lst6 = arpaUserList.lst;
					if (lst6 != null)
					{
						if (Enumerable.Any<LkUserInfoViewModel>((IEnumerable<LkUserInfoViewModel>)lst6))
						{
							if (list2 == null)
							{
								break;
							}
							foreach (OtherSystemSelectedVIiewModel item2 in list2)
							{
								LkUserInfoViewModel lkUserInfoViewModel6 = Enumerable.FirstOrDefault<LkUserInfoViewModel>((IEnumerable<LkUserInfoViewModel>)lst6, (Func<LkUserInfoViewModel, bool>)((LkUserInfoViewModel x) => x.LinkAccUserIdStr == item2.Id));
								if (lkUserInfoViewModel6 != null)
								{
									list3.Add(lkUserInfoViewModel6);
								}
							}
						}
						else
						{
							string text17 = Messages.msgErrorRunFunction + " (get list from Apra) ";
							Exception e16 = new Exception(text17);
							ErrorSignal.FromCurrentContext().Raise(e16);
							text = text17;
						}
					}
					else
					{
						string text18 = Messages.msgErrorRunFunction + " (get list from Apra) ";
						Exception e17 = new Exception(text18);
						ErrorSignal.FromCurrentContext().Raise(e17);
						text = text18;
					}
				}
				else
				{
					string text19 = Messages.msgErrorRunFunction + " (get list from Apra) ";
					Exception e18 = new Exception(text19);
					ErrorSignal.FromCurrentContext().Raise(e18);
					text = text19;
				}
				break;
			}
			case 17:
			{
				LkUserInfoViewModelObjects hamrahanUserList = GetHamrahanUserList();
				if (hamrahanUserList != null)
				{
					List<LkUserInfoViewModel> lst4 = hamrahanUserList.lst;
					if (lst4 != null)
					{
						if (Enumerable.Any<LkUserInfoViewModel>((IEnumerable<LkUserInfoViewModel>)lst4))
						{
							if (list2 == null)
							{
								break;
							}
							foreach (OtherSystemSelectedVIiewModel item4 in list2)
							{
								LkUserInfoViewModel lkUserInfoViewModel4 = Enumerable.FirstOrDefault<LkUserInfoViewModel>((IEnumerable<LkUserInfoViewModel>)lst4, (Func<LkUserInfoViewModel, bool>)((LkUserInfoViewModel x) => x.LinkAccUserIdStr == item4.Id));
								if (lkUserInfoViewModel4 != null)
								{
									list3.Add(lkUserInfoViewModel4);
								}
							}
						}
						else
						{
							string text11 = Messages.msgErrorRunFunction + " (get list from Hamrahan) ";
							Exception e10 = new Exception(text11);
							ErrorSignal.FromCurrentContext().Raise(e10);
							text = text11;
						}
					}
					else
					{
						string text12 = Messages.msgErrorRunFunction + " (get list from Hamrahan) ";
						Exception e11 = new Exception(text12);
						ErrorSignal.FromCurrentContext().Raise(e11);
						text = text12;
					}
				}
				else
				{
					string text13 = Messages.msgErrorRunFunction + " (get list from Hamrahan) ";
					Exception e12 = new Exception(text13);
					ErrorSignal.FromCurrentContext().Raise(e12);
					text = text13;
				}
				break;
			}
			case 18:
			{
				LkUserInfoViewModelObjects noAvaranCapillaryUserList = GetNoAvaranCapillaryUserList();
				if (noAvaranCapillaryUserList != null)
				{
					List<LkUserInfoViewModel> lst7 = noAvaranCapillaryUserList.lst;
					if (lst7 != null)
					{
						if (Enumerable.Any<LkUserInfoViewModel>((IEnumerable<LkUserInfoViewModel>)lst7))
						{
							if (list2 == null)
							{
								break;
							}
							foreach (OtherSystemSelectedVIiewModel item in list2)
							{
								LkUserInfoViewModel lkUserInfoViewModel7 = Enumerable.FirstOrDefault<LkUserInfoViewModel>((IEnumerable<LkUserInfoViewModel>)lst7, (Func<LkUserInfoViewModel, bool>)((LkUserInfoViewModel x) => x.LinkAccUserIdStr == item.Id));
								if (lkUserInfoViewModel7 != null)
								{
									list3.Add(lkUserInfoViewModel7);
								}
							}
						}
						else
						{
							string text20 = Messages.msgErrorRunFunction + " (get list from NoAvaran) ";
							Exception e19 = new Exception(text20);
							ErrorSignal.FromCurrentContext().Raise(e19);
							text = text20;
						}
					}
					else
					{
						string text21 = Messages.msgErrorRunFunction + " (get list from NoAvaran) ";
						Exception e20 = new Exception(text21);
						ErrorSignal.FromCurrentContext().Raise(e20);
						text = text21;
					}
				}
				else
				{
					string text22 = Messages.msgErrorRunFunction + " (get list from NoAvaran) ";
					Exception e21 = new Exception(text22);
					ErrorSignal.FromCurrentContext().Raise(e21);
					text = text22;
				}
				break;
			}
			case 22:
			{
				LkUserInfoViewModelObjects rahkaranInternalSalesUserList = GetRahkaranInternalSalesUserList();
				if (rahkaranInternalSalesUserList != null)
				{
					List<LkUserInfoViewModel> lst2 = rahkaranInternalSalesUserList.lst;
					if (lst2 != null)
					{
						if (Enumerable.Any<LkUserInfoViewModel>((IEnumerable<LkUserInfoViewModel>)lst2))
						{
							if (list2 == null)
							{
								break;
							}
							foreach (OtherSystemSelectedVIiewModel item6 in list2)
							{
								LkUserInfoViewModel lkUserInfoViewModel2 = Enumerable.FirstOrDefault<LkUserInfoViewModel>((IEnumerable<LkUserInfoViewModel>)lst2, (Func<LkUserInfoViewModel, bool>)((LkUserInfoViewModel x) => x.LinkAccUserIdStr == item6.Id));
								if (lkUserInfoViewModel2 != null)
								{
									list3.Add(lkUserInfoViewModel2);
								}
							}
						}
						else
						{
							string text5 = Messages.msgErrorRunFunction + " (get list from Rahkaran) ";
							Exception e4 = new Exception(text5);
							ErrorSignal.FromCurrentContext().Raise(e4);
							text = text5;
						}
					}
					else
					{
						string text6 = Messages.msgErrorRunFunction + " (get list from Rahkaran) ";
						Exception e5 = new Exception(text6);
						ErrorSignal.FromCurrentContext().Raise(e5);
						text = text6;
					}
				}
				else
				{
					string text7 = Messages.msgErrorRunFunction + " (get list from Rahkaran) ";
					Exception e6 = new Exception(text7);
					ErrorSignal.FromCurrentContext().Raise(e6);
					text = text7;
				}
				break;
			}
			case 25:
			{
				LkUserInfoViewModelObjects arianSystemUserList = GetArianSystemUserList();
				if (arianSystemUserList != null)
				{
					List<LkUserInfoViewModel> lst = arianSystemUserList.lst;
					if (lst != null)
					{
						if (Enumerable.Any<LkUserInfoViewModel>((IEnumerable<LkUserInfoViewModel>)lst))
						{
							if (list2 == null)
							{
								break;
							}
							foreach (OtherSystemSelectedVIiewModel item7 in list2)
							{
								LkUserInfoViewModel lkUserInfoViewModel = Enumerable.FirstOrDefault<LkUserInfoViewModel>((IEnumerable<LkUserInfoViewModel>)lst, (Func<LkUserInfoViewModel, bool>)((LkUserInfoViewModel x) => x.LinkAccUserIdStr == item7.Id));
								if (lkUserInfoViewModel != null)
								{
									list3.Add(lkUserInfoViewModel);
								}
							}
						}
						else
						{
							string text2 = Messages.msgErrorRunFunction + " (get list from ArianSystem) ";
							Exception e = new Exception(text2);
							ErrorSignal.FromCurrentContext().Raise(e);
							text = text2;
						}
					}
					else
					{
						string text3 = Messages.msgErrorRunFunction + " (get list from ArianSystem) ";
						Exception e2 = new Exception(text3);
						ErrorSignal.FromCurrentContext().Raise(e2);
						text = text3;
					}
				}
				else
				{
					string text4 = Messages.msgErrorRunFunction + " (get list from ArianSystem) ";
					Exception e3 = new Exception(text4);
					ErrorSignal.FromCurrentContext().Raise(e3);
					text = text4;
				}
				break;
			}
			}
			bool flag = true;
			if (list3 != null && Enumerable.Any<LkUserInfoViewModel>((IEnumerable<LkUserInfoViewModel>)list3))
			{
				int count = list3.Count;
				int num2 = 0;
				num2 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)_dbI.CRMspReturnActiveUsersCount()).GetValueOrDefault();
				num2 += count;
				int num3 = Configuration.MaxCountOfOnlineUser + Configuration.MaxCountOfOnlineUserDeActive;
				if (VersionBuyer.Enterprise)
				{
					_ = Configuration.MaxCountOfOnlineUser;
				}
				if (num3 <= num2)
				{
					text = Messages.msgErrorFinishingUserDefinitionCapacity;
					flag = false;
				}
			}
			if (flag)
			{
				if (list3 != null && Enumerable.Any<LkUserInfoViewModel>((IEnumerable<LkUserInfoViewModel>)list3))
				{
					text = "";
					string userJson = JsonConvert.SerializeObject(list3);
					ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
					CRMLinkSpEntities dbLink = _dbLink;
					int? crmRollId = rollId;
					int? userId2 = userId;
					short? month = value2;
					int? fPId = id;
					short? year = result2;
					DateTime? registerDate = value;
					string appType2 = appType;
					dbLink.CRMspLkInsertUpdateUserByJson(userJson, crmRollId, userId2, fPId, year, month, registerDate, registerDatePersian, result, appType2, objectParameter, centerId);
					if (objectParameter.Value != null)
					{
						if (!string.IsNullOrEmpty(objectParameter.Value.ToString()))
						{
							text = text + "<br>" + objectParameter.Value.ToString();
						}
						else
						{
							int count2 = 100;
							ProgressHub.SendMessage("ok", count2, userId);
						}
					}
					else
					{
						int count3 = 100;
						ProgressHub.SendMessage("ok", count3, userId);
					}
				}
				else
				{
					text = Messages.msgErrorRunFunction + " (" + Messages.ErrorNotFound + ")";
				}
			}
			if (!string.IsNullOrEmpty(text))
			{
				num = 0;
				commonResultStatusViewModel = CommonResultStatusViewModel.Fail;
				ProgressHub.SendMessage(text, 0, userId);
			}
			else
			{
				text = Messages.msgSuccessAction;
				num = 1;
				commonResultStatusViewModel = CommonResultStatusViewModel.Success;
			}
		}
		catch (Exception e22)
		{
			ErrorSignal.FromCurrentContext().Raise(e22);
			num = 0;
			data = new CommonResultViewModel<int>
			{
				Data = num,
				Message = Messages.msgErrorRunFunction,
				Status = CommonResultStatusViewModel.Error
			};
			return Json(data, JsonRequestBehavior.AllowGet);
		}
		data = new CommonResultViewModel<int>
		{
			Data = num,
			Message = text,
			Status = commonResultStatusViewModel
		};
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[DynamicAuthorize(ControllerName = "frmManageUserLinkAcc", ActionName = "actLinkUserWithAcc")]
	public ActionResult LinkedUserLinkAcc(int linkAccSystemId)
	{
		base.ViewBag.LinkAccSystemId = linkAccSystemId;
		return View();
	}

	[HttpPost]
	public JsonResult ActLinkedUserAcc(string syncField, int mode, int type = 0)
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
			List<LinkedUserWithAccViewModel> list = new List<LinkedUserWithAccViewModel>();
			DateTime now = DateTime.Now;
			now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			short.Parse(Financial.Get().Id.ToString());
			_ = UserLogin.CurrentUser.UserId;
			string text3 = "";
			int num = 0;
			if (!UserLogin.IsUserAccess("frmManageUserLinkAcc", "actLinkUserWithAcc", UserLogin.CurrentUser))
			{
				text3 = text3 + Messages.ErrorNotAccess + "<br>";
				num++;
			}
			if (string.IsNullOrWhiteSpace(syncField))
			{
				text3 = text3 + string.Format(Messages.msgErrorIsNotSelectedItem, Labels.OtherSystemsLinkedField) + "<br>";
				num++;
			}
			int result2 = 0;
			string text4 = "";
			CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
			if (cRMspSelectCrmsysSetting_Result != null)
			{
				int.TryParse(cRMspSelectCrmsysSetting_Result.LinkAccSystemId.ToString(), out result2);
			}
			text4 = CRMIdeal.Classes.Helper.Setting.GetLinkAccSystemTitle();
			List<LkUserInfoViewModel> list2 = new List<LkUserInfoViewModel>();
			switch (result2)
			{
			case 3:
			{
				LkUserInfoViewModelObjects tarazUserList = GetTarazUserList(type);
				if (tarazUserList != null)
				{
					list2 = tarazUserList.lst;
				}
				break;
			}
			case 5:
			{
				LkUserInfoViewModelObjects noAvIIUserList = GetNoAvIIUserList();
				if (noAvIIUserList != null)
				{
					list2 = noAvIIUserList.lst;
				}
				break;
			}
			case 12:
			{
				ArpaUserInfoViewModelObjects arpaUserList = GetArpaUserList();
				if (arpaUserList != null)
				{
					list2 = arpaUserList.lst;
				}
				break;
			}
			case 17:
			{
				LkUserInfoViewModelObjects hamrahanUserList = GetHamrahanUserList();
				if (hamrahanUserList != null)
				{
					list2 = hamrahanUserList.lst;
				}
				break;
			}
			case 18:
			{
				LkUserInfoViewModelObjects noAvaranCapillaryUserList = GetNoAvaranCapillaryUserList();
				if (noAvaranCapillaryUserList != null)
				{
					list2 = noAvaranCapillaryUserList.lst;
				}
				break;
			}
			case 22:
			{
				LkUserInfoViewModelObjects rahkaranInternalSalesUserList = GetRahkaranInternalSalesUserList();
				if (rahkaranInternalSalesUserList != null)
				{
					list2 = rahkaranInternalSalesUserList.lst;
				}
				break;
			}
			case 25:
			{
				LkUserInfoViewModelObjects arianSystemUserList = GetArianSystemUserList();
				if (arianSystemUserList != null)
				{
					list2 = arianSystemUserList.lst;
				}
				break;
			}
			}
			if (list2 != null && Enumerable.Any<LkUserInfoViewModel>((IEnumerable<LkUserInfoViewModel>)list2))
			{
				foreach (LkUserInfoViewModel item3 in list2)
				{
					LinkedUserWithAccViewModel item = new LinkedUserWithAccViewModel
					{
						LinkAccUserIdStr = item3.LinkAccUserIdStr,
						LinkAccUserCode = item3.LinkAccUserCode,
						UserName = ((!string.IsNullOrWhiteSpace(item3.FName)) ? (item3.FName + " ") : "") + ((!string.IsNullOrWhiteSpace(item3.LName)) ? (item3.LName ?? "") : ""),
						LinkAccData = item3.LinkAccData
					};
					list.Add(item);
				}
			}
			if (list == null || !Enumerable.Any<LinkedUserWithAccViewModel>((IEnumerable<LinkedUserWithAccViewModel>)list))
			{
				text3 = string.Format(Messages.msgErrorListUserInLinkAccIsEmpty, text4) + "<br>";
				num++;
			}
			if (num == 0)
			{
				string text5 = "";
				text = "";
				List<CRMspLkLinkedUser_Result> list3 = new List<CRMspLkLinkedUser_Result>();
				int count = list.Count;
				int num2 = 1000;
				int num3 = count / num2;
				if (count % num2 != 0)
				{
					num3++;
				}
				for (int i = 0; i <= num3; i++)
				{
					List<LinkedUserWithAccViewModel> list4 = new List<LinkedUserWithAccViewModel>();
					for (int j = i * num2; j < i * num2 + num2 && j < count; j++)
					{
						LinkedUserWithAccViewModel item2 = new LinkedUserWithAccViewModel
						{
							LinkAccUserIdStr = list[j].LinkAccUserIdStr,
							LinkAccUserCode = list[j].LinkAccUserCode,
							UserName = list[j].UserName,
							LinkAccData = list[j].LinkAccData
						};
						list4.Add(item2);
					}
					if (Enumerable.Any<LinkedUserWithAccViewModel>((IEnumerable<LinkedUserWithAccViewModel>)list4))
					{
						string itemJson = JsonConvert.SerializeObject(Enumerable.ToList<LinkedUserWithAccViewModel>((IEnumerable<LinkedUserWithAccViewModel>)list4));
						List<CRMspLkLinkedUser_Result> list5 = Enumerable.ToList<CRMspLkLinkedUser_Result>((IEnumerable<CRMspLkLinkedUser_Result>)_dbLink.CRMspLkLinkedUser(result2, itemJson, syncField, mode, lCID, result));
						if (list5 != null && Enumerable.Any<CRMspLkLinkedUser_Result>((IEnumerable<CRMspLkLinkedUser_Result>)list5))
						{
							list3.AddRange(list5);
						}
					}
				}
				if (list3 != null && Enumerable.Any<CRMspLkLinkedUser_Result>((IEnumerable<CRMspLkLinkedUser_Result>)list3))
				{
					list3 = Enumerable.ToList<CRMspLkLinkedUser_Result>(Enumerable.Distinct<CRMspLkLinkedUser_Result>(Enumerable.Where<CRMspLkLinkedUser_Result>((IEnumerable<CRMspLkLinkedUser_Result>)list3, (Func<CRMspLkLinkedUser_Result, bool>)((CRMspLkLinkedUser_Result m) => (m.LinkAccUserIdStr ?? "") == "" || m.Type.GetValueOrDefault() == 1))));
					if (list3 != null && Enumerable.Any<CRMspLkLinkedUser_Result>((IEnumerable<CRMspLkLinkedUser_Result>)list3))
					{
						text = "error";
						text5 = GetFileLinkedUserAcc(list3);
					}
				}
				if (!string.IsNullOrWhiteSpace(text5))
				{
					text2 = Messages.msgNotCompeleteSuccessAction;
					text2 = text2 + "<br><a href='" + text5 + "' class='link-excel-file' target='_blank'>" + Messages.msgLinkForDownloadFileWithError + "</a>";
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

	public string GetFileLinkedUserAcc(List<CRMspLkLinkedUser_Result> res)
	{
		//IL_04bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d6: Unknown result type (might be due to invalid IL or missing references)
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
			int result2 = 0;
			string text2 = "";
			CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
			if (cRMspSelectCrmsysSetting_Result != null)
			{
				int.TryParse(cRMspSelectCrmsysSetting_Result.LinkAccSystemId.ToString(), out result2);
			}
			text2 = CRMIdeal.Classes.Helper.Setting.GetLinkAccSystemTitle();
			if (res != null && Enumerable.Any<CRMspLkLinkedUser_Result>((IEnumerable<CRMspLkLinkedUser_Result>)res))
			{
				ExcelPackage excelPackage = new ExcelPackage();
				ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets.Add(Labels.OtherSystemsExcelPropertiesTitle);
				int num = 0;
				int num2 = 1;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsLinkedListUserName;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsListUserPersCode;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsListLinkAccUserCode + " (" + text2 + ")";
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsListLinkAccName;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsListLinkDesc;
				foreach (CRMspLkLinkedUser_Result re in res)
				{
					num2++;
					num = 0;
					num++;
					excelWorksheet.Cells[num2, num].Value = re.UserName ?? "";
					num++;
					excelWorksheet.Cells[num2, num].Value = re.PersCode ?? "";
					num++;
					excelWorksheet.Cells[num2, num].Value = re.LinkAccUserCode ?? "";
					num++;
					string value = "";
					if (re.Type.HasValue)
					{
						if (re.Type.GetValueOrDefault() == 1)
						{
							value = text2;
						}
						else if (re.Type.GetValueOrDefault() == 2)
						{
							value = "CRM";
						}
					}
					excelWorksheet.Cells[num2, num].Value = value;
					string value2 = "";
					int result3 = 0;
					int.TryParse(re.ErrorType.ToString(), out result3);
					switch (result3)
					{
					case 0:
						value2 = Messages.msgErrorUserNotInCRM;
						break;
					case -1:
						value2 = Messages.msgErrorDupLinkAccUserCode;
						break;
					case -2:
						value2 = Messages.msgErrorDupUserPersCode;
						break;
					case -3:
						value2 = string.Format(Messages.msgErrorUserNotInLinkAcc, text2);
						break;
					}
					num++;
					excelWorksheet.Cells[num2, num].Value = value2;
				}
				string text3 = base.Server.MapPath(Configuration.HostTempFilesPath) + "\\ReportLinkAccLinked\\" + UserLogin.CurrentUser.UserId;
				string text4 = "CRM-Ideal-" + DateTime.Now.ToString("dd-MM-yyyy-hh-mm-ss") + ".xls";
				string path = text3 + "\\" + text4;
				try
				{
					DirectoryInfo directoryInfo = new DirectoryInfo(text3);
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
					if (System.IO.Directory.Exists(text3))
					{
						System.IO.Directory.Delete(text3);
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
				}
				if (!System.IO.Directory.Exists(text3))
				{
					System.IO.Directory.CreateDirectory(text3);
					CRM.General.IO.Directory.SetFullControlForEveryOne(text3);
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
					text = Configuration.HostTempFilesPath + "/ReportLinkAccLinked/" + userId + "/" + text4;
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

	public string SetLinkAccCookie(string cookieVal)
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
			int result3 = 0;
			string text = "";
			CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
			if (cRMspSelectCrmsysSetting_Result != null)
			{
				int.TryParse(cRMspSelectCrmsysSetting_Result.LinkAccSystemId.ToString(), out result3);
			}
			text = CRMIdeal.Classes.Helper.Setting.GetLinkAccSystemTitle();
			if (!string.IsNullOrWhiteSpace(cookieVal) && VersionBuyer.LinkAcc && result3 == 19 && string.IsNullOrWhiteSpace(new LinkAccRahkaranRetailSettingController().Rahkaran_GetCooKie(cookieVal)))
			{
				result = string.Format(Messages.msgErrorGetLinkAccCookie, text);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = Messages.msgErrorRunFunction;
		}
		return result;
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		_dbLink.Dispose();
		_dbI.Dispose();
		base.Dispose(disposing);
	}
}
