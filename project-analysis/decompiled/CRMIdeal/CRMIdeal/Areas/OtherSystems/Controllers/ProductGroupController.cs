using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CRM.General.Security;
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
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using NR.Shygun.WS.ClientSDK;
using NR.Shygun.WS.FilterDomains;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.OtherSystems.Controllers;

public class ProductGroupController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMLinkSpEntities _dbLink = new CRMLinkSpEntities();

	private readonly CRMSpIEntities _db_I = new CRMSpIEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	public string prdGroupSyncTypeId = "PrdGroupSyncTypeId";

	[JsonIgnore]
	private string JsonRender;

	public string PrdGroupSyncTypeId = "PrdGroupSyncTypeId";

	public string shygunIIPrdGroupSyncTypeId = "PrdGroupSyncTypeId";

	public string LinkAccPrdGroupSyncTypeId = "PrdGroupSyncTypeId";

	[AjaxOnly]
	public JsonResult GetProductSecondGroup()
	{
		LkProductSecondGroupListViewModel lkProductSecondGroupListViewModel = new LkProductSecondGroupListViewModel();
		lkProductSecondGroupListViewModel.lst = new List<LkProductSecondGroupInfoViewModel>();
		lkProductSecondGroupListViewModel.lstSelectListItem = new List<SelectListItem>();
		try
		{
			_ = UserLogin.CurrentUser.UserId;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspLkWSSelectProductSecondGroup_Result> list = Enumerable.ToList<CRMspLkWSSelectProductSecondGroup_Result>((IEnumerable<CRMspLkWSSelectProductSecondGroup_Result>)_dbLink.CRMspLkWSSelectProductSecondGroup(0, lCID, result));
			if (list != null && Enumerable.Any<CRMspLkWSSelectProductSecondGroup_Result>((IEnumerable<CRMspLkWSSelectProductSecondGroup_Result>)list))
			{
				List<LkProductSecondGroupInfoViewModel> list2 = new List<LkProductSecondGroupInfoViewModel>();
				List<SelectListItem> list3 = new List<SelectListItem>();
				foreach (CRMspLkWSSelectProductSecondGroup_Result item in list)
				{
					list2.Add(new LkProductSecondGroupInfoViewModel
					{
						PrdSecondGroupID = item.PrdSecondGroupID,
						FirstGroupId = item.FirstGroupId,
						SGCode = item.SGCode,
						SGName = item.FulName,
						SGLinkAccGroupId = item.SGLinkAccGroupId,
						SGLinkAccGroupCode = item.SGLinkAccGroupCode,
						SGLinkAccGroupIdStr = item.SGLinkAccGroupIdStr,
						SGLinkAccGroupName = item.SGLinkAccGroupName
					});
					list3.Add(new SelectListItem
					{
						Value = item.PrdSecondGroupID.ToString(),
						Text = item.FulName,
						Selected = false
					});
				}
				lkProductSecondGroupListViewModel.lst = list2;
				lkProductSecondGroupListViewModel.lstSelectListItem = list3;
			}
			lkProductSecondGroupListViewModel.isDone = true;
			lkProductSecondGroupListViewModel.Message = "";
		}
		catch (Exception ex)
		{
			lkProductSecondGroupListViewModel.isDone = false;
			lkProductSecondGroupListViewModel.Message = "Error: " + ex.Message;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		base.ViewBag.ProductSecondGroupList = lkProductSecondGroupListViewModel;
		JsonResult jsonResult = Json(lkProductSecondGroupListViewModel.lst, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public List<WSspSelectProductsFirstGroupWithAccLinkField_Result> SelectProductsFirstGroupWithAccLinkField(bool withLinkAccGroupId = false, bool withLinkAccGroupCode = false, bool withLinkAccGroupIdStr = false)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspSelectProductsFirstGroupWithAccLinkField_Result> result2 = new List<WSspSelectProductsFirstGroupWithAccLinkField_Result>();
		try
		{
			result2 = Enumerable.ToList<WSspSelectProductsFirstGroupWithAccLinkField_Result>((IEnumerable<WSspSelectProductsFirstGroupWithAccLinkField_Result>)_dbLink.WSspSelectProductsFirstGroupWithAccLinkField(withLinkAccGroupId: withLinkAccGroupId, withLinkAccGroupCode: withLinkAccGroupCode, withLinkAccGroupIdStr: withLinkAccGroupIdStr, languageID: lCID, defaultLanguageID: result));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result2;
	}

	public List<WSspSelectProductsSecondGroupWithAccLinkField_Result> SelectProductsSecondGroupWithAccLinkField(bool withLinkAccGroupId = false, bool withLinkAccGroupCode = false, bool withLinkAccGroupIdStr = false, bool withLinkAccGroups = false)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspSelectProductsSecondGroupWithAccLinkField_Result> result2 = new List<WSspSelectProductsSecondGroupWithAccLinkField_Result>();
		try
		{
			result2 = Enumerable.ToList<WSspSelectProductsSecondGroupWithAccLinkField_Result>((IEnumerable<WSspSelectProductsSecondGroupWithAccLinkField_Result>)_dbLink.WSspSelectProductsSecondGroupWithAccLinkField(withLinkAccGroupId: withLinkAccGroupId, withLinkAccGroupCode: withLinkAccGroupCode, withLinkAccGroupIdStr: withLinkAccGroupIdStr, withLinkAccGroups: withLinkAccGroups, languageID: lCID, defaultLanguageID: result));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result2;
	}

	[DynamicAuthorize(ControllerName = "frmProductGroup", ActionName = "actLinkedSGWithAcc")]
	public ActionResult ShygunSyncProductGroup()
	{
		GetShygunProductGroup();
		GetProductSecondGroup();
		CRMIdeal.Classes.Helper.OtherSystems.ShygunSettingViewModel shygunSetting = CRMIdeal.Classes.Helper.OtherSystems.GetShygunSetting();
		base.ViewBag.SyncTypeId = shygunSetting.PrdGroupSyncTypeId;
		return View();
	}

	[AjaxOnly]
	public JsonResult GetShygunProductGroup()
	{
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_0188: Expected O, but got Unknown
		LkProductSecondGroupListViewModel lkProductSecondGroupListViewModel = new LkProductSecondGroupListViewModel();
		lkProductSecondGroupListViewModel.lst = new List<LkProductSecondGroupInfoViewModel>();
		lkProductSecondGroupListViewModel.lstSelectListItem = new List<SelectListItem>();
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<LkProductSecondGroupInfoViewModel> list = new List<LkProductSecondGroupInfoViewModel>();
		List<SelectListItem> list2 = new List<SelectListItem>();
		bool flag = true;
		int num = 0;
		int rowCount = 100;
		try
		{
			List<WSspSelectProductsSecondGroupWithAccLinkField_Result> list3 = Enumerable.ToList<WSspSelectProductsSecondGroupWithAccLinkField_Result>((IEnumerable<WSspSelectProductsSecondGroupWithAccLinkField_Result>)_dbLink.WSspSelectProductsSecondGroupWithAccLinkField(false, false, true, false, 0, 0));
			flag = true;
			while (flag)
			{
				CRMIdeal.Classes.Helper.OtherSystems.ShygunSettingViewModel shygunSetting = CRMIdeal.Classes.Helper.OtherSystems.GetShygunSetting();
				DomainItemGroup domainItemGroup = new DomainItemGroup();
				domainItemGroup.GroupNumber.From = string.Empty;
				domainItemGroup.GroupNumber.To = string.Empty;
				domainItemGroup.Sort.From = string.Empty;
				DataTable dataTableObject = new WebServiceGetItemGroup(shygunSetting.IP, shygunSetting.conf, domainItemGroup, num, rowCount).GetDataTableObject(out JsonRender);
				if (dataTableObject != null && ((InternalDataCollectionBase)dataTableObject.Rows).Count > 0)
				{
					DataTable val = DataTableExtensions.CopyToDataTable<DataRow>((IEnumerable<DataRow>)dataTableObject.Select("isnull(IsMainGroup, 0) = 0"));
					if (val != null && ((InternalDataCollectionBase)val.Rows).Count > 0)
					{
						foreach (DataRow item in (InternalDataCollectionBase)val.Rows)
						{
							DataRow val2 = item;
							LkProductSecondGroupInfoViewModel vm = new LkProductSecondGroupInfoViewModel();
							vm.SGName = val2["GroupName"].ToString();
							vm.SGName = val2["ParentGroupName"].ToString() + " - " + val2["GroupName"].ToString();
							vm.SGLinkAccGroupIdStr = val2["GroupGuId"].ToString();
							vm.SGLinkAccGroupCode = val2["GroupNumber"].ToString();
							if (list3 != null)
							{
								WSspSelectProductsSecondGroupWithAccLinkField_Result wSspSelectProductsSecondGroupWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectProductsSecondGroupWithAccLinkField_Result>((IEnumerable<WSspSelectProductsSecondGroupWithAccLinkField_Result>)list3, (Func<WSspSelectProductsSecondGroupWithAccLinkField_Result, bool>)((WSspSelectProductsSecondGroupWithAccLinkField_Result x) => x.SGLinkAccGroupIdStr == vm.SGLinkAccGroupIdStr));
								if (wSspSelectProductsSecondGroupWithAccLinkField_Result != null && wSspSelectProductsSecondGroupWithAccLinkField_Result.PrdSecondGroupID != 0)
								{
									vm.PrdSecondGroupID = wSspSelectProductsSecondGroupWithAccLinkField_Result.PrdSecondGroupID;
								}
							}
							list.Add(vm);
							list2.Add(new SelectListItem
							{
								Value = vm.SGLinkAccGroupIdStr,
								Text = vm.SGName,
								Selected = false
							});
						}
					}
				}
				else
				{
					flag = false;
				}
				num += ((num > 0) ? 100 : 101);
			}
			lkProductSecondGroupListViewModel.lst = list;
			lkProductSecondGroupListViewModel.lstSelectListItem = list2;
			lkProductSecondGroupListViewModel.isDone = true;
			lkProductSecondGroupListViewModel.Message = "";
		}
		catch (Exception ex)
		{
			lkProductSecondGroupListViewModel.isDone = false;
			lkProductSecondGroupListViewModel.Message = "Error: " + ex.Message;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		base.ViewBag.LinkAccProductSecondGroupList = lkProductSecondGroupListViewModel;
		base.ViewBag.LinkAccProductSecondGroupListlst = lkProductSecondGroupListViewModel.lst;
		JsonResult jsonResult = Json(lkProductSecondGroupListViewModel.lst, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[DynamicAuthorize(ControllerName = "frmManagePrdGroupsLinkAcc", ActionName = "actImportFGShowInfo")]
	public List<LkProductFirstGroupInfoViewModel> GetShygunProductFGroup()
	{
		//IL_0164: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected O, but got Unknown
		List<LkProductFirstGroupInfoViewModel> list = new List<LkProductFirstGroupInfoViewModel>();
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		bool flag = true;
		int num = 0;
		int rowCount = 100;
		int num2 = 1;
		try
		{
			List<WSspSelectProductsFirstGroupWithAccLinkField_Result> list2 = SelectProductsFirstGroupWithAccLinkField(withLinkAccGroupId: false, withLinkAccGroupCode: false, withLinkAccGroupIdStr: true);
			while (flag)
			{
				CRMIdeal.Classes.Helper.OtherSystems.ShygunSettingViewModel shygunSetting = CRMIdeal.Classes.Helper.OtherSystems.GetShygunSetting();
				DomainItemGroup domainItemGroup = new DomainItemGroup();
				domainItemGroup.GroupNumber.From = string.Empty;
				domainItemGroup.GroupNumber.To = string.Empty;
				domainItemGroup.Sort.From = string.Empty;
				DataTable dataTableObject = new WebServiceGetItemGroup(shygunSetting.IP, shygunSetting.conf, domainItemGroup, num, rowCount).GetDataTableObject(out JsonRender);
				if (dataTableObject != null && ((InternalDataCollectionBase)dataTableObject.Rows).Count > 0)
				{
					List<DataRow> list3 = Enumerable.ToList<DataRow>((IEnumerable<DataRow>)dataTableObject.Select("isnull(IsMainGroup, 0) = 1"));
					if (list3 != null && Enumerable.Any<DataRow>((IEnumerable<DataRow>)list3) && Enumerable.Count<DataRow>((IEnumerable<DataRow>)list3) > 0)
					{
						DataTable val = DataTableExtensions.CopyToDataTable<DataRow>((IEnumerable<DataRow>)dataTableObject.Select("isnull(IsMainGroup, 0) = 1"));
						if (val != null && ((InternalDataCollectionBase)val.Rows).Count > 0)
						{
							foreach (DataRow item in (InternalDataCollectionBase)val.Rows)
							{
								DataRow val2 = item;
								if (!string.IsNullOrWhiteSpace(val2["GroupGuId"].ToString()))
								{
									val2["GroupGuId"].ToString();
								}
								if (!string.IsNullOrWhiteSpace(val2["GroupName"].ToString()))
								{
									val2["GroupName"].ToString();
								}
								LkProductFirstGroupInfoViewModel vm = new LkProductFirstGroupInfoViewModel();
								vm.FGName = val2["GroupName"].ToString();
								vm.FGLinkAccGroupIdStr = val2["GroupGuId"].ToString();
								vm.FGLinkAccGroupCode = val2["GroupNumber"].ToString();
								vm.Selected = true;
								if (list2 != null)
								{
									WSspSelectProductsFirstGroupWithAccLinkField_Result wSspSelectProductsFirstGroupWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectProductsFirstGroupWithAccLinkField_Result>((IEnumerable<WSspSelectProductsFirstGroupWithAccLinkField_Result>)list2, (Func<WSspSelectProductsFirstGroupWithAccLinkField_Result, bool>)((WSspSelectProductsFirstGroupWithAccLinkField_Result x) => x.FGLinkAccGroupIdStr == vm.FGLinkAccGroupIdStr));
									if (wSspSelectProductsFirstGroupWithAccLinkField_Result != null && wSspSelectProductsFirstGroupWithAccLinkField_Result.PrdFirstGroupID != 0)
									{
										vm.PrdFirstGroupID = wSspSelectProductsFirstGroupWithAccLinkField_Result.PrdFirstGroupID;
										vm.Selected = false;
									}
								}
								vm.RowNumber = num2++;
								list.Add(vm);
							}
						}
						else
						{
							flag = false;
						}
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

	[DynamicAuthorize(ControllerName = "frmManagePrdGroupsLinkAcc", ActionName = "actImportFGShowInfo")]
	public JsonResult GetShygunProductFGroupJs()
	{
		JsonResult jsonResult = Json(GetShygunProductFGroup(), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[DynamicAuthorize(ControllerName = "frmManagePrdGroupsLinkAcc", ActionName = "actImportSGShowInfo")]
	public List<LkProductSecondGroupInfoViewModel> GetShygunProductSGroup()
	{
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_0152: Expected O, but got Unknown
		List<LkProductSecondGroupInfoViewModel> list = new List<LkProductSecondGroupInfoViewModel>();
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		bool flag = true;
		int num = 0;
		int rowCount = 100;
		int num2 = 1;
		try
		{
			List<WSspSelectProductsFirstGroupWithAccLinkField_Result> list2 = SelectProductsFirstGroupWithAccLinkField(withLinkAccGroupId: false, withLinkAccGroupCode: false, withLinkAccGroupIdStr: true);
			List<WSspSelectProductsSecondGroupWithAccLinkField_Result> list3 = SelectProductsSecondGroupWithAccLinkField(withLinkAccGroupId: false, withLinkAccGroupCode: false, withLinkAccGroupIdStr: true);
			flag = true;
			while (flag)
			{
				CRMIdeal.Classes.Helper.OtherSystems.ShygunSettingViewModel shygunSetting = CRMIdeal.Classes.Helper.OtherSystems.GetShygunSetting();
				DomainItemGroup domainItemGroup = new DomainItemGroup();
				domainItemGroup.GroupNumber.From = string.Empty;
				domainItemGroup.GroupNumber.To = string.Empty;
				domainItemGroup.Sort.From = string.Empty;
				DataTable dataTableObject = new WebServiceGetItemGroup(shygunSetting.IP, shygunSetting.conf, domainItemGroup, num, rowCount).GetDataTableObject(out JsonRender);
				if (dataTableObject != null && ((InternalDataCollectionBase)dataTableObject.Rows).Count > 0)
				{
					DataTable val = DataTableExtensions.CopyToDataTable<DataRow>((IEnumerable<DataRow>)dataTableObject.Select("isnull(IsMainGroup, 0) = 0"));
					if (val != null && ((InternalDataCollectionBase)val.Rows).Count > 0)
					{
						foreach (DataRow item in (InternalDataCollectionBase)val.Rows)
						{
							DataRow rowChild = item;
							LkProductSecondGroupInfoViewModel vm = new LkProductSecondGroupInfoViewModel();
							vm.FGName = rowChild["ParentGroupName"].ToString() ?? "";
							vm.SGName = rowChild["GroupName"].ToString() ?? "";
							vm.SGLinkAccGroupIdStr = rowChild["GroupGuId"].ToString();
							vm.SGLinkAccGroupCode = rowChild["GroupNumber"].ToString();
							vm.Selected = true;
							if (list2 != null)
							{
								WSspSelectProductsFirstGroupWithAccLinkField_Result wSspSelectProductsFirstGroupWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectProductsFirstGroupWithAccLinkField_Result>((IEnumerable<WSspSelectProductsFirstGroupWithAccLinkField_Result>)list2, (Func<WSspSelectProductsFirstGroupWithAccLinkField_Result, bool>)((WSspSelectProductsFirstGroupWithAccLinkField_Result x) => x.FGLinkAccGroupIdStr == rowChild["ParentGroupGuId"].ToString()));
								if (wSspSelectProductsFirstGroupWithAccLinkField_Result != null && wSspSelectProductsFirstGroupWithAccLinkField_Result.PrdFirstGroupID != 0)
								{
									vm.FirstGroupId = wSspSelectProductsFirstGroupWithAccLinkField_Result.PrdFirstGroupID;
								}
							}
							if (list3 != null)
							{
								WSspSelectProductsSecondGroupWithAccLinkField_Result wSspSelectProductsSecondGroupWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectProductsSecondGroupWithAccLinkField_Result>((IEnumerable<WSspSelectProductsSecondGroupWithAccLinkField_Result>)list3, (Func<WSspSelectProductsSecondGroupWithAccLinkField_Result, bool>)((WSspSelectProductsSecondGroupWithAccLinkField_Result x) => x.SGLinkAccGroupIdStr == vm.SGLinkAccGroupIdStr));
								if (wSspSelectProductsSecondGroupWithAccLinkField_Result != null && wSspSelectProductsSecondGroupWithAccLinkField_Result.PrdSecondGroupID != 0)
								{
									vm.PrdSecondGroupID = wSspSelectProductsSecondGroupWithAccLinkField_Result.PrdSecondGroupID;
									vm.Selected = false;
								}
							}
							vm.RowNumber = num2++;
							list.Add(vm);
						}
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

	[DynamicAuthorize(ControllerName = "frmManagePrdGroupsLinkAcc", ActionName = "actImportSGShowInfo")]
	public JsonResult GetShygunProductSGroupJs()
	{
		JsonResult jsonResult = Json(GetShygunProductSGroup(), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[HttpPost]
	public string GetShygunLinkedPrdGroupsList()
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
			List<WSspSelectProductsSecondGroupWithAccLinkField_Result> list = Enumerable.ToList<WSspSelectProductsSecondGroupWithAccLinkField_Result>((IEnumerable<WSspSelectProductsSecondGroupWithAccLinkField_Result>)_dbLink.WSspSelectProductsSecondGroupWithAccLinkField(false, false, false, true, lCID, result2));
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

	[HttpPost]
	public string ShygunSyncProductGroupIE(string jsData, int syncType = 1)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		DateTime now = DateTime.Now;
		DateTime dateTime = now;
		string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
		short num = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
		string appType = Configuration.AppType;
		int userId = UserLogin.CurrentUser.UserId;
		string text = "";
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			DbSet<CrmLinkAccShygunSetting> crmLinkAccShygunSetting = _dbTbl.CrmLinkAccShygunSetting;
			ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccShygunSetting), "x");
			CrmLinkAccShygunSetting crmLinkAccShygunSetting2 = Queryable.FirstOrDefault<CrmLinkAccShygunSetting>((IQueryable<CrmLinkAccShygunSetting>)crmLinkAccShygunSetting, Expression.Lambda<Func<CrmLinkAccShygunSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)this, typeof(ProductGroupController)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (crmLinkAccShygunSetting2 != null)
			{
				if (crmLinkAccShygunSetting2.LinkAccShygunSettingId > 0)
				{
					crmLinkAccShygunSetting2.PartValue = syncType.ToString();
					crmLinkAccShygunSetting2.RegisterDate = dateTime;
					crmLinkAccShygunSetting2.RegisterDatePersian = registerDatePersian;
					crmLinkAccShygunSetting2.UserId = userId;
					_dbTbl.Entry(crmLinkAccShygunSetting2).State = EntityState.Modified;
					_dbTbl.SaveChanges();
				}
				else
				{
					text = string.Format(Messages.msgNotSetLinkAccSettingWhRelation, Labels.Shygun);
				}
			}
			else
			{
				text = Messages.msgUpdateCrmDatabase;
			}
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
						_dbLink.CRMspLkWSInsertUpdateProductSGLinkAccGroups(int.Parse(item.Value), item.Text, userId, num, dateTime, registerDatePersian, appType, objectParameter);
						new List<SelectListItem>();
						if (!string.IsNullOrWhiteSpace(item.Text))
						{
							List<CommonWithIdStrViewModel> list5 = JsonConvert.DeserializeObject<List<CommonWithIdStrViewModel>>(item.Text);
							if (list5 != null && Enumerable.Count<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list5) == 1)
							{
								int result2 = 0;
								int.TryParse(Enumerable.FirstOrDefault<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list5).Extra, out result2);
								WSProductSecondGroup wSProductSecondGroup = _dbTbl.WSProductSecondGroup.Find(result2);
								if (wSProductSecondGroup != null)
								{
									wSProductSecondGroup.SGLinkAccGroupIdStr = Enumerable.FirstOrDefault<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list5).Id;
									wSProductSecondGroup.SGLinkAccGroupCode = Enumerable.FirstOrDefault<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list5).Code;
									wSProductSecondGroup.SGLinkAccGroupName = Enumerable.FirstOrDefault<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list5).Name;
									wSProductSecondGroup.AppType = appType;
									wSProductSecondGroup.UserId = userId;
									wSProductSecondGroup.Month1 = num;
									wSProductSecondGroup.RegisterDate = dateTime;
									wSProductSecondGroup.RegisterDatePersian = registerDatePersian;
									_dbTbl.Entry(wSProductSecondGroup).State = EntityState.Modified;
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
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductFirstGroup");
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductSecondGroup");
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			text = text + "Error: " + ex.Message;
		}
		return text + "|**|" + JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	public string ShygunSyncProductGroupTypeIE(int syncType = 1)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		DateTime now = DateTime.Now;
		DateTime registerDate = now;
		string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
		short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
		_ = Configuration.AppType;
		int userId = UserLogin.CurrentUser.UserId;
		string text = "";
		List<SelectListItem> value = new List<SelectListItem>();
		try
		{
			DbSet<CrmLinkAccShygunSetting> crmLinkAccShygunSetting = _dbTbl.CrmLinkAccShygunSetting;
			ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccShygunSetting), "x");
			CrmLinkAccShygunSetting crmLinkAccShygunSetting2 = Queryable.FirstOrDefault<CrmLinkAccShygunSetting>((IQueryable<CrmLinkAccShygunSetting>)crmLinkAccShygunSetting, Expression.Lambda<Func<CrmLinkAccShygunSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)this, typeof(ProductGroupController)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
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
					text = string.Format(Messages.msgNotSetLinkAccSettingWhRelation, Labels.Shygun);
				}
			}
			else
			{
				text = Messages.msgUpdateCrmDatabase;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			text = text + "Error: " + ex.Message;
		}
		return text + "|**|" + JsonConvert.SerializeObject(value);
	}

	[DynamicAuthorize(ControllerName = "frmProductGroup", ActionName = "actManagePrdGroupsLinkAcc")]
	public ActionResult ShygunManagePrdGroupLinkAcc()
	{
		GetShygunProductGroup();
		GetProductSecondGroup();
		CRMIdeal.Classes.Helper.OtherSystems.ShygunSettingViewModel shygunSetting = CRMIdeal.Classes.Helper.OtherSystems.GetShygunSetting();
		base.ViewBag.SGSyncTypeId = shygunSetting.PrdGroupSyncTypeId;
		return View();
	}

	public ActionResult ShygunPrdFGImport_Read([DataSourceRequest] DataSourceRequest request)
	{
		return Json(((IEnumerable)GetShygunProductFGroup()).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[DynamicAuthorize(ControllerName = "frmManagePrdGroupsLinkAcc", ActionName = "actImportFGInfo")]
	[HttpPost]
	public string ImportShygunProductFirstGroup(string records = "")
	{
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		string result = Messages.msgErrorRunFunction;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			SelectProductsFirstGroupWithAccLinkField(withLinkAccGroupId: false, withLinkAccGroupCode: false, withLinkAccGroupIdStr: true);
			if (!string.IsNullOrWhiteSpace(records))
			{
				List<LkProductFirstGroupInfoViewModel> list = new List<LkProductFirstGroupInfoViewModel>();
				List<LkProductFirstGroupInfoViewModel> list2 = new List<LkProductFirstGroupInfoViewModel>();
				list2 = new JavaScriptSerializer().Deserialize<List<LkProductFirstGroupInfoViewModel>>(records);
				if (list2.Count > 0)
				{
					list2 = Enumerable.ToList<LkProductFirstGroupInfoViewModel>(Enumerable.Where<LkProductFirstGroupInfoViewModel>((IEnumerable<LkProductFirstGroupInfoViewModel>)list2, (Func<LkProductFirstGroupInfoViewModel, bool>)((LkProductFirstGroupInfoViewModel x) => x.Selected)));
				}
				List<LkProductFirstGroupInfoViewModel> shygunProductFGroup = GetShygunProductFGroup();
				foreach (LkProductFirstGroupInfoViewModel itm in list2)
				{
					LkProductFirstGroupInfoViewModel lkProductFirstGroupInfoViewModel = Enumerable.FirstOrDefault<LkProductFirstGroupInfoViewModel>((IEnumerable<LkProductFirstGroupInfoViewModel>)shygunProductFGroup, (Func<LkProductFirstGroupInfoViewModel, bool>)((LkProductFirstGroupInfoViewModel x) => x.FGLinkAccGroupIdStr == itm.FGLinkAccGroupIdStr));
					if (lkProductFirstGroupInfoViewModel != null)
					{
						list.Add(lkProductFirstGroupInfoViewModel);
					}
				}
				if (list != null && list.Count > 0)
				{
					int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result3);
					if (result3 <= 0)
					{
						result3 = 1065;
					}
					_ = Thread.CurrentThread.CurrentCulture.LCID;
					DateTime now = DateTime.Now;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					int id = Financial.Get().Id;
					short value2 = short.Parse(Financial.Get().Id.ToString());
					short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					string appType = Configuration.AppType;
					int userId = UserLogin.CurrentUser.UserId;
					string json = JsonConvert.SerializeObject(list);
					ObjectParameter objectParameter = new ObjectParameter("ErrorMessage", "");
					_dbLink.CRMspLkWSInsertUpdateProductsFirstGroup(json, userId, value3, value2, id, value, registerDatePersian, appType, result3, objectParameter);
					result = ((objectParameter == null || string.IsNullOrWhiteSpace(objectParameter.Value.ToString())) ? "" : objectParameter.Value.ToString());
				}
			}
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductFirstGroup");
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductSecondGroup");
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result = Labels.Error + ": " + ex.Message;
		}
		return result;
	}

	public ActionResult ShygunPrdSGImport_Read([DataSourceRequest] DataSourceRequest request)
	{
		return Json(((IEnumerable)GetShygunProductSGroup()).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[DynamicAuthorize(ControllerName = "frmManagePrdGroupsLinkAcc", ActionName = "actImportSGInfo")]
	[HttpPost]
	public string ImportShygunProductSecondGroup(string records = "")
	{
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		string result = Messages.msgErrorRunFunction;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			if (!string.IsNullOrWhiteSpace(records))
			{
				List<LkProductSecondGroupInfoViewModel> list = new List<LkProductSecondGroupInfoViewModel>();
				List<LkProductSecondGroupInfoViewModel> list2 = new List<LkProductSecondGroupInfoViewModel>();
				list2 = new JavaScriptSerializer().Deserialize<List<LkProductSecondGroupInfoViewModel>>(records);
				if (list2.Count > 0)
				{
					list2 = Enumerable.ToList<LkProductSecondGroupInfoViewModel>(Enumerable.Where<LkProductSecondGroupInfoViewModel>((IEnumerable<LkProductSecondGroupInfoViewModel>)list2, (Func<LkProductSecondGroupInfoViewModel, bool>)((LkProductSecondGroupInfoViewModel x) => x.Selected)));
				}
				List<LkProductSecondGroupInfoViewModel> shygunProductSGroup = GetShygunProductSGroup();
				foreach (LkProductSecondGroupInfoViewModel itm in list2)
				{
					LkProductSecondGroupInfoViewModel lkProductSecondGroupInfoViewModel = Enumerable.FirstOrDefault<LkProductSecondGroupInfoViewModel>((IEnumerable<LkProductSecondGroupInfoViewModel>)shygunProductSGroup, (Func<LkProductSecondGroupInfoViewModel, bool>)((LkProductSecondGroupInfoViewModel x) => x.SGLinkAccGroupIdStr == itm.SGLinkAccGroupIdStr));
					if (lkProductSecondGroupInfoViewModel != null)
					{
						list.Add(lkProductSecondGroupInfoViewModel);
					}
				}
				if (list != null && list.Count > 0)
				{
					int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result3);
					if (result3 <= 0)
					{
						result3 = 1065;
					}
					_ = Thread.CurrentThread.CurrentCulture.LCID;
					DateTime now = DateTime.Now;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					int id = Financial.Get().Id;
					short value2 = short.Parse(Financial.Get().Id.ToString());
					short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					string appType = Configuration.AppType;
					int userId = UserLogin.CurrentUser.UserId;
					string json = JsonConvert.SerializeObject(list);
					ObjectParameter objectParameter = new ObjectParameter("ErrorMessage", "");
					_dbLink.CRMspLkWSInsertUpdateProductsSecondGroup(json, userId, value3, value2, id, value, registerDatePersian, appType, result3, objectParameter);
					result = ((objectParameter == null || string.IsNullOrWhiteSpace(objectParameter.Value.ToString())) ? "" : objectParameter.Value.ToString());
				}
			}
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductFirstGroup");
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductSecondGroup");
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result = Labels.Error + ": " + ex.Message;
		}
		return result;
	}

	[DynamicAuthorize(ControllerName = "frmProductGroup", ActionName = "actLinkedSGWithAcc")]
	public ActionResult ShygunIISyncProductGroup()
	{
		GetShygunIIProductGroup();
		GetProductSecondGroup();
		CRMIdeal.Classes.Helper.OtherSystems.ShygunIISettingViewModel shygunIISetting = CRMIdeal.Classes.Helper.OtherSystems.GetShygunIISetting();
		base.ViewBag.SyncTypeId = shygunIISetting.PrdGroupSyncTypeId;
		return View();
	}

	[AjaxOnly]
	public JsonResult GetShygunIIProductGroup()
	{
		//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b8: Expected O, but got Unknown
		//IL_02af: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b6: Expected O, but got Unknown
		LkProductSecondGroupListViewModel lkProductSecondGroupListViewModel = new LkProductSecondGroupListViewModel();
		lkProductSecondGroupListViewModel.lst = new List<LkProductSecondGroupInfoViewModel>();
		lkProductSecondGroupListViewModel.lstSelectListItem = new List<SelectListItem>();
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<LkProductSecondGroupInfoViewModel> list = new List<LkProductSecondGroupInfoViewModel>();
		List<SelectListItem> list2 = new List<SelectListItem>();
		bool flag = true;
		int num = 0;
		int rowCount = 100;
		try
		{
			while (flag)
			{
				List<WSspSelectProductsSecondGroupWithAccLinkField_Result> list3 = Enumerable.ToList<WSspSelectProductsSecondGroupWithAccLinkField_Result>((IEnumerable<WSspSelectProductsSecondGroupWithAccLinkField_Result>)_dbLink.WSspSelectProductsSecondGroupWithAccLinkField(false, false, true, false, 0, 0));
				CRMIdeal.Classes.Helper.OtherSystems.ShygunIISettingViewModel shygunIISetting = CRMIdeal.Classes.Helper.OtherSystems.GetShygunIISetting();
				DomainItemGroup domainItemGroup = new DomainItemGroup();
				domainItemGroup.GroupNumber.From = string.Empty;
				domainItemGroup.GroupNumber.To = string.Empty;
				domainItemGroup.Sort.From = string.Empty;
				DataTable dataTableObject = new WebServiceGetItemGroup(shygunIISetting.IP, shygunIISetting.conf, domainItemGroup, num, rowCount).GetDataTableObject(out JsonRender);
				if (dataTableObject != null && ((InternalDataCollectionBase)dataTableObject.Rows).Count > 0)
				{
					List<DataRow> list4 = Enumerable.ToList<DataRow>((IEnumerable<DataRow>)dataTableObject.Select("isnull(IsMainGroup, 0) = 1"));
					if (list4 != null && Enumerable.Any<DataRow>((IEnumerable<DataRow>)list4) && Enumerable.Count<DataRow>((IEnumerable<DataRow>)list4) > 0)
					{
						DataTable val = DataTableExtensions.CopyToDataTable<DataRow>((IEnumerable<DataRow>)dataTableObject.Select("isnull(IsMainGroup, 0) = 1"));
						if (val != null && ((InternalDataCollectionBase)val.Rows).Count > 0)
						{
							foreach (DataRow item in (InternalDataCollectionBase)val.Rows)
							{
								DataRow val2 = item;
								string text = "";
								text = (string.IsNullOrWhiteSpace(val2["GroupGuId"].ToString()) ? "" : val2["GroupGuId"].ToString());
								if (!string.IsNullOrWhiteSpace(val2["GroupName"].ToString()))
								{
									val2["GroupName"].ToString();
								}
								if (string.IsNullOrWhiteSpace(text))
								{
									continue;
								}
								List<DataRow> list5 = Enumerable.ToList<DataRow>((IEnumerable<DataRow>)dataTableObject.Select("[ParentGroupGuId] = '" + val2["GroupGuId"].ToString() + "'"));
								if (list5 == null || list5.Count <= 0)
								{
									continue;
								}
								foreach (DataRow item2 in (InternalDataCollectionBase)DataTableExtensions.CopyToDataTable<DataRow>((IEnumerable<DataRow>)dataTableObject.Select("[ParentGroupGuId] = '" + val2["GroupGuId"].ToString() + "'")).Rows)
								{
									DataRow val3 = item2;
									LkProductSecondGroupInfoViewModel vm = new LkProductSecondGroupInfoViewModel();
									vm.SGName = val3["GroupName"].ToString();
									vm.SGName = val3["ParentGroupName"].ToString() + " - " + val3["GroupName"].ToString();
									vm.SGLinkAccGroupIdStr = val3["GroupGuId"].ToString();
									vm.SGLinkAccGroupCode = val3["GroupNumber"].ToString();
									if (list3 != null)
									{
										WSspSelectProductsSecondGroupWithAccLinkField_Result wSspSelectProductsSecondGroupWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectProductsSecondGroupWithAccLinkField_Result>((IEnumerable<WSspSelectProductsSecondGroupWithAccLinkField_Result>)list3, (Func<WSspSelectProductsSecondGroupWithAccLinkField_Result, bool>)((WSspSelectProductsSecondGroupWithAccLinkField_Result x) => x.SGLinkAccGroupIdStr == vm.SGLinkAccGroupIdStr));
										if (wSspSelectProductsSecondGroupWithAccLinkField_Result != null && wSspSelectProductsSecondGroupWithAccLinkField_Result.PrdSecondGroupID != 0)
										{
											vm.PrdSecondGroupID = wSspSelectProductsSecondGroupWithAccLinkField_Result.PrdSecondGroupID;
										}
									}
									list.Add(vm);
									list2.Add(new SelectListItem
									{
										Value = vm.SGLinkAccGroupIdStr,
										Text = vm.SGName,
										Selected = false
									});
								}
							}
						}
						else
						{
							flag = false;
						}
					}
					lkProductSecondGroupListViewModel.lst = list;
					lkProductSecondGroupListViewModel.lstSelectListItem = list2;
				}
				else
				{
					flag = false;
				}
				num += ((num > 0) ? 100 : 101);
			}
			lkProductSecondGroupListViewModel.isDone = true;
			lkProductSecondGroupListViewModel.Message = "";
		}
		catch (Exception ex)
		{
			lkProductSecondGroupListViewModel.isDone = false;
			lkProductSecondGroupListViewModel.Message = "Error: " + ex.Message;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		base.ViewBag.LinkAccProductSecondGroupList = lkProductSecondGroupListViewModel;
		base.ViewBag.LinkAccProductSecondGroupListlst = lkProductSecondGroupListViewModel.lst;
		JsonResult jsonResult = Json(lkProductSecondGroupListViewModel.lst, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[DynamicAuthorize(ControllerName = "frmManagePrdGroupsLinkAcc", ActionName = "actImportFGShowInfo")]
	public List<LkProductFirstGroupInfoViewModel> GetShygunIIProductFGroup()
	{
		//IL_0164: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected O, but got Unknown
		List<LkProductFirstGroupInfoViewModel> list = new List<LkProductFirstGroupInfoViewModel>();
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		bool flag = true;
		int num = 0;
		int rowCount = 100;
		int num2 = 1;
		try
		{
			List<WSspSelectProductsFirstGroupWithAccLinkField_Result> list2 = SelectProductsFirstGroupWithAccLinkField(withLinkAccGroupId: false, withLinkAccGroupCode: false, withLinkAccGroupIdStr: true);
			while (flag)
			{
				CRMIdeal.Classes.Helper.OtherSystems.ShygunIISettingViewModel shygunIISetting = CRMIdeal.Classes.Helper.OtherSystems.GetShygunIISetting();
				DomainItemGroup domainItemGroup = new DomainItemGroup();
				domainItemGroup.GroupNumber.From = string.Empty;
				domainItemGroup.GroupNumber.To = string.Empty;
				domainItemGroup.Sort.From = string.Empty;
				DataTable dataTableObject = new WebServiceGetItemGroup(shygunIISetting.IP, shygunIISetting.conf, domainItemGroup, num, rowCount).GetDataTableObject(out JsonRender);
				if (dataTableObject != null && ((InternalDataCollectionBase)dataTableObject.Rows).Count > 0)
				{
					List<DataRow> list3 = Enumerable.ToList<DataRow>((IEnumerable<DataRow>)dataTableObject.Select("isnull(IsMainGroup, 0) = 1"));
					if (list3 != null && Enumerable.Any<DataRow>((IEnumerable<DataRow>)list3) && Enumerable.Count<DataRow>((IEnumerable<DataRow>)list3) > 0)
					{
						DataTable val = DataTableExtensions.CopyToDataTable<DataRow>((IEnumerable<DataRow>)dataTableObject.Select("isnull(IsMainGroup, 0) = 1"));
						if (val != null && ((InternalDataCollectionBase)val.Rows).Count > 0)
						{
							foreach (DataRow item in (InternalDataCollectionBase)val.Rows)
							{
								DataRow val2 = item;
								if (!string.IsNullOrWhiteSpace(val2["GroupGuId"].ToString()))
								{
									val2["GroupGuId"].ToString();
								}
								if (!string.IsNullOrWhiteSpace(val2["GroupName"].ToString()))
								{
									val2["GroupName"].ToString();
								}
								LkProductFirstGroupInfoViewModel vm = new LkProductFirstGroupInfoViewModel();
								vm.FGName = val2["GroupName"].ToString();
								vm.FGLinkAccGroupIdStr = val2["GroupGuId"].ToString();
								vm.FGLinkAccGroupCode = val2["GroupNumber"].ToString();
								vm.Selected = true;
								if (list2 != null)
								{
									WSspSelectProductsFirstGroupWithAccLinkField_Result wSspSelectProductsFirstGroupWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectProductsFirstGroupWithAccLinkField_Result>((IEnumerable<WSspSelectProductsFirstGroupWithAccLinkField_Result>)list2, (Func<WSspSelectProductsFirstGroupWithAccLinkField_Result, bool>)((WSspSelectProductsFirstGroupWithAccLinkField_Result x) => x.FGLinkAccGroupIdStr == vm.FGLinkAccGroupIdStr));
									if (wSspSelectProductsFirstGroupWithAccLinkField_Result != null && wSspSelectProductsFirstGroupWithAccLinkField_Result.PrdFirstGroupID != 0)
									{
										vm.PrdFirstGroupID = wSspSelectProductsFirstGroupWithAccLinkField_Result.PrdFirstGroupID;
										vm.Selected = false;
									}
								}
								vm.RowNumber = num2++;
								list.Add(vm);
							}
						}
						else
						{
							flag = false;
						}
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

	[DynamicAuthorize(ControllerName = "frmManagePrdGroupsLinkAcc", ActionName = "actImportFGShowInfo")]
	public JsonResult GetShygunIIProductFGroupJs()
	{
		JsonResult jsonResult = Json(GetShygunIIProductFGroup(), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[DynamicAuthorize(ControllerName = "frmManagePrdGroupsLinkAcc", ActionName = "actImportSGShowInfo")]
	public List<LkProductSecondGroupInfoViewModel> GetShygunIIProductSGroup()
	{
		//IL_0179: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Expected O, but got Unknown
		//IL_0298: Unknown result type (might be due to invalid IL or missing references)
		//IL_029f: Expected O, but got Unknown
		List<LkProductSecondGroupInfoViewModel> list = new List<LkProductSecondGroupInfoViewModel>();
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		bool flag = true;
		int num = 0;
		int rowCount = 100;
		int num2 = 1;
		try
		{
			List<WSspSelectProductsFirstGroupWithAccLinkField_Result> list2 = SelectProductsFirstGroupWithAccLinkField(withLinkAccGroupId: false, withLinkAccGroupCode: false, withLinkAccGroupIdStr: true);
			List<WSspSelectProductsSecondGroupWithAccLinkField_Result> list3 = SelectProductsSecondGroupWithAccLinkField(withLinkAccGroupId: false, withLinkAccGroupCode: false, withLinkAccGroupIdStr: true);
			while (flag)
			{
				CRMIdeal.Classes.Helper.OtherSystems.ShygunIISettingViewModel shygunIISetting = CRMIdeal.Classes.Helper.OtherSystems.GetShygunIISetting();
				DomainItemGroup domainItemGroup = new DomainItemGroup();
				domainItemGroup.GroupNumber.From = string.Empty;
				domainItemGroup.GroupNumber.To = string.Empty;
				domainItemGroup.Sort.From = string.Empty;
				DataTable dataTableObject = new WebServiceGetItemGroup(shygunIISetting.IP, shygunIISetting.conf, domainItemGroup, num, rowCount).GetDataTableObject(out JsonRender);
				if (dataTableObject != null && ((InternalDataCollectionBase)dataTableObject.Rows).Count > 0)
				{
					List<DataRow> list4 = Enumerable.ToList<DataRow>((IEnumerable<DataRow>)dataTableObject.Select("isnull(IsMainGroup, 0) = 1"));
					if (list4 != null && Enumerable.Any<DataRow>((IEnumerable<DataRow>)list4) && Enumerable.Count<DataRow>((IEnumerable<DataRow>)list4) > 0)
					{
						DataTable val = DataTableExtensions.CopyToDataTable<DataRow>((IEnumerable<DataRow>)dataTableObject.Select("isnull(IsMainGroup, 0) = 1"));
						if (val != null && ((InternalDataCollectionBase)val.Rows).Count > 0)
						{
							foreach (DataRow item in (InternalDataCollectionBase)val.Rows)
							{
								DataRow row = item;
								string text = "";
								text = (string.IsNullOrWhiteSpace(row["GroupGuId"].ToString()) ? "" : row["GroupGuId"].ToString());
								if (!string.IsNullOrWhiteSpace(row["GroupName"].ToString()))
								{
									row["GroupName"].ToString();
								}
								if (string.IsNullOrWhiteSpace(text))
								{
									continue;
								}
								List<DataRow> list5 = Enumerable.ToList<DataRow>((IEnumerable<DataRow>)dataTableObject.Select("[ParentGroupGuId] = '" + row["GroupGuId"].ToString() + "'"));
								if (list5 == null || list5.Count <= 0)
								{
									continue;
								}
								foreach (DataRow item2 in (InternalDataCollectionBase)DataTableExtensions.CopyToDataTable<DataRow>((IEnumerable<DataRow>)dataTableObject.Select("[ParentGroupGuId] = '" + row["GroupGuId"].ToString() + "'")).Rows)
								{
									DataRow val2 = item2;
									LkProductSecondGroupInfoViewModel vm = new LkProductSecondGroupInfoViewModel();
									vm.FGName = val2["ParentGroupName"].ToString() ?? "";
									vm.SGName = val2["GroupName"].ToString() ?? "";
									vm.SGLinkAccGroupIdStr = val2["GroupGuId"].ToString();
									vm.SGLinkAccGroupCode = val2["GroupNumber"].ToString();
									vm.Selected = true;
									if (list2 != null)
									{
										WSspSelectProductsFirstGroupWithAccLinkField_Result wSspSelectProductsFirstGroupWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectProductsFirstGroupWithAccLinkField_Result>((IEnumerable<WSspSelectProductsFirstGroupWithAccLinkField_Result>)list2, (Func<WSspSelectProductsFirstGroupWithAccLinkField_Result, bool>)((WSspSelectProductsFirstGroupWithAccLinkField_Result x) => x.FGLinkAccGroupIdStr == row["GroupGuId"].ToString()));
										if (wSspSelectProductsFirstGroupWithAccLinkField_Result != null && wSspSelectProductsFirstGroupWithAccLinkField_Result.PrdFirstGroupID != 0)
										{
											vm.FirstGroupId = wSspSelectProductsFirstGroupWithAccLinkField_Result.PrdFirstGroupID;
										}
									}
									if (list3 != null)
									{
										WSspSelectProductsSecondGroupWithAccLinkField_Result wSspSelectProductsSecondGroupWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectProductsSecondGroupWithAccLinkField_Result>((IEnumerable<WSspSelectProductsSecondGroupWithAccLinkField_Result>)list3, (Func<WSspSelectProductsSecondGroupWithAccLinkField_Result, bool>)((WSspSelectProductsSecondGroupWithAccLinkField_Result x) => x.SGLinkAccGroupIdStr == vm.SGLinkAccGroupIdStr));
										if (wSspSelectProductsSecondGroupWithAccLinkField_Result != null && wSspSelectProductsSecondGroupWithAccLinkField_Result.PrdSecondGroupID != 0)
										{
											vm.PrdSecondGroupID = wSspSelectProductsSecondGroupWithAccLinkField_Result.PrdSecondGroupID;
											vm.Selected = false;
										}
									}
									vm.RowNumber = num2++;
									list.Add(vm);
								}
							}
						}
						else
						{
							flag = false;
						}
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

	[DynamicAuthorize(ControllerName = "frmManagePrdGroupsLinkAcc", ActionName = "actImportSGShowInfo")]
	public JsonResult GetShygunIIProductSGroupJs()
	{
		JsonResult jsonResult = Json(GetShygunIIProductSGroup(), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[HttpPost]
	public string GetShygunIILinkedPrdGroupsList()
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
			List<WSspSelectProductsSecondGroupWithAccLinkField_Result> list = Enumerable.ToList<WSspSelectProductsSecondGroupWithAccLinkField_Result>((IEnumerable<WSspSelectProductsSecondGroupWithAccLinkField_Result>)_dbLink.WSspSelectProductsSecondGroupWithAccLinkField(false, false, false, true, lCID, result2));
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

	[HttpPost]
	public string ShygunIISyncProductGroupIE(string jsData, int syncType = 1)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		DateTime now = DateTime.Now;
		DateTime dateTime = now;
		string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
		short num = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
		string appType = Configuration.AppType;
		int userId = UserLogin.CurrentUser.UserId;
		string text = "";
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			DbSet<CrmLinkAccShygunIISetting> crmLinkAccShygunIISetting = _dbTbl.CrmLinkAccShygunIISetting;
			ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccShygunIISetting), "x");
			CrmLinkAccShygunIISetting crmLinkAccShygunIISetting2 = Queryable.FirstOrDefault<CrmLinkAccShygunIISetting>((IQueryable<CrmLinkAccShygunIISetting>)crmLinkAccShygunIISetting, Expression.Lambda<Func<CrmLinkAccShygunIISetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)this, typeof(ProductGroupController)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (crmLinkAccShygunIISetting2 != null)
			{
				if (crmLinkAccShygunIISetting2.LinkAccShygunIISettingId > 0)
				{
					crmLinkAccShygunIISetting2.PartValue = syncType.ToString();
					crmLinkAccShygunIISetting2.RegisterDate = dateTime;
					crmLinkAccShygunIISetting2.RegisterDatePersian = registerDatePersian;
					crmLinkAccShygunIISetting2.UserId = userId;
					_dbTbl.Entry(crmLinkAccShygunIISetting2).State = EntityState.Modified;
					_dbTbl.SaveChanges();
				}
				else
				{
					text = string.Format(Messages.msgNotSetLinkAccSettingWhRelation, Labels.ShygunII);
				}
			}
			else
			{
				text = Messages.msgUpdateCrmDatabase;
			}
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
						_dbLink.CRMspLkWSInsertUpdateProductSGLinkAccGroups(int.Parse(item.Value), item.Text, userId, num, dateTime, registerDatePersian, appType, objectParameter);
						new List<SelectListItem>();
						if (!string.IsNullOrWhiteSpace(item.Text))
						{
							List<CommonWithIdStrViewModel> list5 = JsonConvert.DeserializeObject<List<CommonWithIdStrViewModel>>(item.Text);
							if (list5 != null && Enumerable.Count<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list5) == 1)
							{
								int result2 = 0;
								int.TryParse(Enumerable.FirstOrDefault<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list5).Extra, out result2);
								WSProductSecondGroup wSProductSecondGroup = _dbTbl.WSProductSecondGroup.Find(result2);
								if (wSProductSecondGroup != null)
								{
									wSProductSecondGroup.SGLinkAccGroupIdStr = Enumerable.FirstOrDefault<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list5).Id;
									wSProductSecondGroup.SGLinkAccGroupCode = Enumerable.FirstOrDefault<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list5).Code;
									wSProductSecondGroup.SGLinkAccGroupName = Enumerable.FirstOrDefault<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list5).Name;
									wSProductSecondGroup.AppType = appType;
									wSProductSecondGroup.UserId = userId;
									wSProductSecondGroup.Month1 = num;
									wSProductSecondGroup.RegisterDate = dateTime;
									wSProductSecondGroup.RegisterDatePersian = registerDatePersian;
									_dbTbl.Entry(wSProductSecondGroup).State = EntityState.Modified;
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
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			text = text + "Error: " + ex.Message;
		}
		return text + "|**|" + JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	public string ShygunIISyncProductGroupTypeIE(int syncType = 1)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		DateTime now = DateTime.Now;
		DateTime registerDate = now;
		string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
		short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
		_ = Configuration.AppType;
		int userId = UserLogin.CurrentUser.UserId;
		string text = "";
		List<SelectListItem> value = new List<SelectListItem>();
		try
		{
			DbSet<CrmLinkAccShygunIISetting> crmLinkAccShygunIISetting = _dbTbl.CrmLinkAccShygunIISetting;
			ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccShygunIISetting), "x");
			CrmLinkAccShygunIISetting crmLinkAccShygunIISetting2 = Queryable.FirstOrDefault<CrmLinkAccShygunIISetting>((IQueryable<CrmLinkAccShygunIISetting>)crmLinkAccShygunIISetting, Expression.Lambda<Func<CrmLinkAccShygunIISetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)this, typeof(ProductGroupController)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
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
					text = string.Format(Messages.msgNotSetLinkAccSettingWhRelation, Labels.ShygunII);
				}
			}
			else
			{
				text = Messages.msgUpdateCrmDatabase;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			text = text + "Error: " + ex.Message;
		}
		return text + "|**|" + JsonConvert.SerializeObject(value);
	}

	[DynamicAuthorize(ControllerName = "frmProductGroup", ActionName = "actManagePrdGroupsLinkAcc")]
	public ActionResult ShygunIIManagePrdGroupLinkAcc()
	{
		GetShygunIIProductGroup();
		GetProductSecondGroup();
		CRMIdeal.Classes.Helper.OtherSystems.ShygunIISettingViewModel shygunIISetting = CRMIdeal.Classes.Helper.OtherSystems.GetShygunIISetting();
		base.ViewBag.SGSyncTypeId = shygunIISetting.PrdGroupSyncTypeId;
		return View();
	}

	public ActionResult ShygunIIPrdFGImport_Read([DataSourceRequest] DataSourceRequest request)
	{
		return Json(((IEnumerable)GetShygunIIProductFGroup()).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[DynamicAuthorize(ControllerName = "frmManagePrdGroupsLinkAcc", ActionName = "actImportFGInfo")]
	[HttpPost]
	public string ImportShygunIIProductFirstGroup(string records = "")
	{
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		string result = Messages.msgErrorRunFunction;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			SelectProductsFirstGroupWithAccLinkField(withLinkAccGroupId: false, withLinkAccGroupCode: false, withLinkAccGroupIdStr: true);
			if (!string.IsNullOrWhiteSpace(records))
			{
				List<LkProductFirstGroupInfoViewModel> list = new List<LkProductFirstGroupInfoViewModel>();
				List<LkProductFirstGroupInfoViewModel> list2 = new List<LkProductFirstGroupInfoViewModel>();
				list2 = new JavaScriptSerializer().Deserialize<List<LkProductFirstGroupInfoViewModel>>(records);
				if (list2.Count > 0)
				{
					list2 = Enumerable.ToList<LkProductFirstGroupInfoViewModel>(Enumerable.Where<LkProductFirstGroupInfoViewModel>((IEnumerable<LkProductFirstGroupInfoViewModel>)list2, (Func<LkProductFirstGroupInfoViewModel, bool>)((LkProductFirstGroupInfoViewModel x) => x.Selected)));
				}
				List<LkProductFirstGroupInfoViewModel> shygunIIProductFGroup = GetShygunIIProductFGroup();
				foreach (LkProductFirstGroupInfoViewModel itm in list2)
				{
					LkProductFirstGroupInfoViewModel lkProductFirstGroupInfoViewModel = Enumerable.FirstOrDefault<LkProductFirstGroupInfoViewModel>((IEnumerable<LkProductFirstGroupInfoViewModel>)shygunIIProductFGroup, (Func<LkProductFirstGroupInfoViewModel, bool>)((LkProductFirstGroupInfoViewModel x) => x.FGLinkAccGroupIdStr == itm.FGLinkAccGroupIdStr));
					if (lkProductFirstGroupInfoViewModel != null)
					{
						list.Add(lkProductFirstGroupInfoViewModel);
					}
				}
				if (list != null && list.Count > 0)
				{
					int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result3);
					if (result3 <= 0)
					{
						result3 = 1065;
					}
					_ = Thread.CurrentThread.CurrentCulture.LCID;
					DateTime now = DateTime.Now;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					int id = Financial.Get().Id;
					short value2 = short.Parse(Financial.Get().Id.ToString());
					short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					string appType = Configuration.AppType;
					int userId = UserLogin.CurrentUser.UserId;
					string json = JsonConvert.SerializeObject(list);
					ObjectParameter objectParameter = new ObjectParameter("ErrorMessage", "");
					_dbLink.CRMspLkWSInsertUpdateProductsFirstGroup(json, userId, value3, value2, id, value, registerDatePersian, appType, result3, objectParameter);
					result = ((objectParameter == null || string.IsNullOrWhiteSpace(objectParameter.Value.ToString())) ? "" : objectParameter.Value.ToString());
				}
			}
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductFirstGroup");
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductSecondGroup");
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result = Labels.Error + ": " + ex.Message;
		}
		return result;
	}

	public ActionResult ShygunIIPrdSGImport_Read([DataSourceRequest] DataSourceRequest request)
	{
		return Json(((IEnumerable)GetShygunProductSGroup()).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[DynamicAuthorize(ControllerName = "frmManagePrdGroupsLinkAcc", ActionName = "actImportSGInfo")]
	[HttpPost]
	public string ImportShygunIIProductSecondGroup(string records = "")
	{
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		string result = Messages.msgErrorRunFunction;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			if (!string.IsNullOrWhiteSpace(records))
			{
				List<LkProductSecondGroupInfoViewModel> list = new List<LkProductSecondGroupInfoViewModel>();
				List<LkProductSecondGroupInfoViewModel> list2 = new List<LkProductSecondGroupInfoViewModel>();
				list2 = new JavaScriptSerializer().Deserialize<List<LkProductSecondGroupInfoViewModel>>(records);
				if (list2.Count > 0)
				{
					list2 = Enumerable.ToList<LkProductSecondGroupInfoViewModel>(Enumerable.Where<LkProductSecondGroupInfoViewModel>((IEnumerable<LkProductSecondGroupInfoViewModel>)list2, (Func<LkProductSecondGroupInfoViewModel, bool>)((LkProductSecondGroupInfoViewModel x) => x.Selected)));
				}
				List<LkProductSecondGroupInfoViewModel> shygunIIProductSGroup = GetShygunIIProductSGroup();
				foreach (LkProductSecondGroupInfoViewModel itm in list2)
				{
					LkProductSecondGroupInfoViewModel lkProductSecondGroupInfoViewModel = Enumerable.FirstOrDefault<LkProductSecondGroupInfoViewModel>((IEnumerable<LkProductSecondGroupInfoViewModel>)shygunIIProductSGroup, (Func<LkProductSecondGroupInfoViewModel, bool>)((LkProductSecondGroupInfoViewModel x) => x.SGLinkAccGroupIdStr == itm.SGLinkAccGroupIdStr));
					if (lkProductSecondGroupInfoViewModel != null)
					{
						list.Add(lkProductSecondGroupInfoViewModel);
					}
				}
				if (list != null && list.Count > 0)
				{
					int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result3);
					if (result3 <= 0)
					{
						result3 = 1065;
					}
					_ = Thread.CurrentThread.CurrentCulture.LCID;
					DateTime now = DateTime.Now;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					int id = Financial.Get().Id;
					short value2 = short.Parse(Financial.Get().Id.ToString());
					short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					string appType = Configuration.AppType;
					int userId = UserLogin.CurrentUser.UserId;
					string json = JsonConvert.SerializeObject(list);
					ObjectParameter objectParameter = new ObjectParameter("ErrorMessage", "");
					_dbLink.CRMspLkWSInsertUpdateProductsSecondGroup(json, userId, value3, value2, id, value, registerDatePersian, appType, result3, objectParameter);
					result = ((objectParameter == null || string.IsNullOrWhiteSpace(objectParameter.Value.ToString())) ? "" : objectParameter.Value.ToString());
				}
			}
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductFirstGroup");
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductSecondGroup");
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result = Labels.Error + ": " + ex.Message;
		}
		return result;
	}

	public LkProductSecondGroupInfoViewModelObjects GetHamrahanProductGroupList()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		LkProductSecondGroupInfoViewModelObjects lkProductSecondGroupInfoViewModelObjects = new LkProductSecondGroupInfoViewModelObjects();
		List<LkProductSecondGroupInfoViewModel> list = new List<LkProductSecondGroupInfoViewModel>();
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
						string text4 = text + "DefineGroupObject/company/" + text3;
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
								List<HamrahanProducGrouptInfoViewModel> list2 = JsonConvert.DeserializeObject<List<HamrahanProducGrouptInfoViewModel>>(value2);
								if (list2 != null && Enumerable.Any<HamrahanProducGrouptInfoViewModel>((IEnumerable<HamrahanProducGrouptInfoViewModel>)list2))
								{
									List<WSspSelectProductsSecondGroupWithAccLinkField_Result> list3 = Enumerable.ToList<WSspSelectProductsSecondGroupWithAccLinkField_Result>((IEnumerable<WSspSelectProductsSecondGroupWithAccLinkField_Result>)_dbLink.WSspSelectProductsSecondGroupWithAccLinkField(false, false, true, false, 0, 0));
									int num = 1;
									foreach (HamrahanProducGrouptInfoViewModel item in list2)
									{
										LkProductSecondGroupInfoViewModel lkProductSecondGroupInfoViewModel = new LkProductSecondGroupInfoViewModel();
										lkProductSecondGroupInfoViewModel.SGLinkAccGroupIdStr = item.recNo.GetValueOrDefault().ToString();
										lkProductSecondGroupInfoViewModel.SGLinkAccGroupCode = item.codeGroup;
										lkProductSecondGroupInfoViewModel.SGName = item.nameGroup;
										lkProductSecondGroupInfoViewModel.RowNumber = num;
										WSspSelectProductsSecondGroupWithAccLinkField_Result wSspSelectProductsSecondGroupWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectProductsSecondGroupWithAccLinkField_Result>((IEnumerable<WSspSelectProductsSecondGroupWithAccLinkField_Result>)list3, (Func<WSspSelectProductsSecondGroupWithAccLinkField_Result, bool>)((WSspSelectProductsSecondGroupWithAccLinkField_Result x) => x.SGLinkAccGroupIdStr == item.recNo.GetValueOrDefault().ToString()));
										if (wSspSelectProductsSecondGroupWithAccLinkField_Result != null && !string.IsNullOrWhiteSpace(wSspSelectProductsSecondGroupWithAccLinkField_Result.SGLinkAccGroupIdStr))
										{
											lkProductSecondGroupInfoViewModel.PrdSecondGroupID = wSspSelectProductsSecondGroupWithAccLinkField_Result.PrdSecondGroupID;
										}
										else
										{
											lkProductSecondGroupInfoViewModel.PrdSecondGroupID = 0;
										}
										list.Add(lkProductSecondGroupInfoViewModel);
										num++;
									}
								}
							}
						}
					}
				}
			}
			lkProductSecondGroupInfoViewModelObjects.lst = list;
			lkProductSecondGroupInfoViewModelObjects.FilteredLst = list;
			lkProductSecondGroupInfoViewModelObjects.Json = Json(list, JsonRequestBehavior.AllowGet);
			lkProductSecondGroupInfoViewModelObjects.SerializedJson = JsonConvert.SerializeObject(list);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return lkProductSecondGroupInfoViewModelObjects;
	}

	public LkProductSecondGroupInfoViewModelObjects GetNoAvaranCapillaryProductGroupList()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		LkProductSecondGroupInfoViewModelObjects lkProductSecondGroupInfoViewModelObjects = new LkProductSecondGroupInfoViewModelObjects();
		List<LkProductSecondGroupInfoViewModel> list = new List<LkProductSecondGroupInfoViewModel>();
		try
		{
			CRMIdeal.Classes.Helper.OtherSystems.NoAvaranCapillarySettingViewModel noAvaranCapillarySetting = CRMIdeal.Classes.Helper.OtherSystems.GetNoAvaranCapillarySetting();
			if (noAvaranCapillarySetting != null)
			{
				string text = noAvaranCapillarySetting.ApiUserId ?? "";
				if (!string.IsNullOrWhiteSpace(text))
				{
					string value = new CommercialSoapClient().ReadFromGorooh(text);
					if (!string.IsNullOrWhiteSpace(value))
					{
						value = value.ClearHiddenCharacters();
					}
					if (!string.IsNullOrWhiteSpace(value))
					{
						List<NoAvaranCapillaryProductGroupInfoViewModel> list2 = JsonConvert.DeserializeObject<List<NoAvaranCapillaryProductGroupInfoViewModel>>(value);
						if (list2 != null && Enumerable.Any<NoAvaranCapillaryProductGroupInfoViewModel>((IEnumerable<NoAvaranCapillaryProductGroupInfoViewModel>)list2))
						{
							List<WSspSelectProductsSecondGroupWithAccLinkField_Result> list3 = Enumerable.ToList<WSspSelectProductsSecondGroupWithAccLinkField_Result>((IEnumerable<WSspSelectProductsSecondGroupWithAccLinkField_Result>)_dbLink.WSspSelectProductsSecondGroupWithAccLinkField(false, false, true, false, 0, 0));
							int num = 1;
							foreach (NoAvaranCapillaryProductGroupInfoViewModel item in list2)
							{
								LkProductSecondGroupInfoViewModel vmPrdGroup = new LkProductSecondGroupInfoViewModel();
								vmPrdGroup.SGLinkAccGroupIdStr = item.GroupID.GetValueOrDefault().ToString();
								vmPrdGroup.SGName = item.GroupName;
								vmPrdGroup.RowNumber = num;
								WSspSelectProductsSecondGroupWithAccLinkField_Result wSspSelectProductsSecondGroupWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectProductsSecondGroupWithAccLinkField_Result>((IEnumerable<WSspSelectProductsSecondGroupWithAccLinkField_Result>)list3, (Func<WSspSelectProductsSecondGroupWithAccLinkField_Result, bool>)((WSspSelectProductsSecondGroupWithAccLinkField_Result x) => x.SGLinkAccGroupIdStr == vmPrdGroup.SGLinkAccGroupIdStr));
								if (wSspSelectProductsSecondGroupWithAccLinkField_Result != null && !string.IsNullOrWhiteSpace(wSspSelectProductsSecondGroupWithAccLinkField_Result.SGLinkAccGroupIdStr))
								{
									vmPrdGroup.PrdSecondGroupID = wSspSelectProductsSecondGroupWithAccLinkField_Result.PrdSecondGroupID;
								}
								else
								{
									vmPrdGroup.PrdSecondGroupID = 0;
								}
								list.Add(vmPrdGroup);
								num++;
							}
						}
					}
				}
			}
			lkProductSecondGroupInfoViewModelObjects.lst = list;
			lkProductSecondGroupInfoViewModelObjects.FilteredLst = list;
			lkProductSecondGroupInfoViewModelObjects.Json = Json(list, JsonRequestBehavior.AllowGet);
			lkProductSecondGroupInfoViewModelObjects.SerializedJson = JsonConvert.SerializeObject(list);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return lkProductSecondGroupInfoViewModelObjects;
	}

	public LkProductGroupInfoViewModelObjects GetShygunDetailedAPIProductGroupList(bool isMainGroup)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		LkProductGroupInfoViewModelObjects lkProductGroupInfoViewModelObjects = new LkProductGroupInfoViewModelObjects();
		lkProductGroupInfoViewModelObjects.lst = new List<LkProductGroupInfoViewModel>();
		lkProductGroupInfoViewModelObjects.FilteredLst = new List<LkProductGroupInfoViewModel>();
		List<LkProductGroupInfoViewModel> list = new List<LkProductGroupInfoViewModel>();
		try
		{
			List<ShygunDetailedAPIItemGroupInfoViewModel> list2 = new CRMIdeal.Classes.Helper.OtherSystems.ShygunDetailedAPIProvider().GetItemGroupList();
			if (list2 != null && Enumerable.Any<ShygunDetailedAPIItemGroupInfoViewModel>((IEnumerable<ShygunDetailedAPIItemGroupInfoViewModel>)list2))
			{
				list2 = Enumerable.ToList<ShygunDetailedAPIItemGroupInfoViewModel>(Enumerable.Where<ShygunDetailedAPIItemGroupInfoViewModel>((IEnumerable<ShygunDetailedAPIItemGroupInfoViewModel>)list2, (Func<ShygunDetailedAPIItemGroupInfoViewModel, bool>)((ShygunDetailedAPIItemGroupInfoViewModel m) => m.IsMainGroup.GetValueOrDefault() == isMainGroup)));
			}
			if (list2 != null && Enumerable.Any<ShygunDetailedAPIItemGroupInfoViewModel>((IEnumerable<ShygunDetailedAPIItemGroupInfoViewModel>)list2))
			{
				List<WSspSelectProductsFirstGroupWithAccLinkField_Result> list3 = new List<WSspSelectProductsFirstGroupWithAccLinkField_Result>();
				List<WSspSelectProductsSecondGroupWithAccLinkField_Result> list4 = new List<WSspSelectProductsSecondGroupWithAccLinkField_Result>();
				if (isMainGroup)
				{
					list3 = Enumerable.ToList<WSspSelectProductsFirstGroupWithAccLinkField_Result>((IEnumerable<WSspSelectProductsFirstGroupWithAccLinkField_Result>)_dbLink.WSspSelectProductsFirstGroupWithAccLinkField(false, false, true, lCID, result));
				}
				else
				{
					list4 = Enumerable.ToList<WSspSelectProductsSecondGroupWithAccLinkField_Result>((IEnumerable<WSspSelectProductsSecondGroupWithAccLinkField_Result>)_dbLink.WSspSelectProductsSecondGroupWithAccLinkField(false, false, true, false, lCID, result));
				}
				int num = 1;
				foreach (ShygunDetailedAPIItemGroupInfoViewModel item in list2)
				{
					LkProductGroupInfoViewModel vm = new LkProductGroupInfoViewModel();
					vm.GroupName = item.GroupName ?? "";
					vm.LinkAccGroupIdStr = item.GroupGuid;
					vm.LinkAccGroupCode = item.GroupNumber;
					vm.ParentGroupName = item.ParentGroupName ?? "";
					vm.ParentLinkAccGroupIdStr = item.ParentGroupGuId ?? "";
					vm.ParentLinkAccGroupCode = item.ParentGroupNumber;
					vm.GroupName = ((!string.IsNullOrWhiteSpace(vm.ParentGroupName)) ? (vm.ParentGroupName + " - ") : "") + vm.GroupName;
					if (isMainGroup)
					{
						if (list3 != null)
						{
							WSspSelectProductsFirstGroupWithAccLinkField_Result wSspSelectProductsFirstGroupWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectProductsFirstGroupWithAccLinkField_Result>((IEnumerable<WSspSelectProductsFirstGroupWithAccLinkField_Result>)list3, (Func<WSspSelectProductsFirstGroupWithAccLinkField_Result, bool>)((WSspSelectProductsFirstGroupWithAccLinkField_Result x) => x.FGLinkAccGroupIdStr == vm.LinkAccGroupIdStr));
							if (wSspSelectProductsFirstGroupWithAccLinkField_Result != null && wSspSelectProductsFirstGroupWithAccLinkField_Result.PrdFirstGroupID != 0)
							{
								vm.PrdGroupID = wSspSelectProductsFirstGroupWithAccLinkField_Result.PrdFirstGroupID;
							}
						}
					}
					else if (list4 != null)
					{
						WSspSelectProductsSecondGroupWithAccLinkField_Result wSspSelectProductsSecondGroupWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectProductsSecondGroupWithAccLinkField_Result>((IEnumerable<WSspSelectProductsSecondGroupWithAccLinkField_Result>)list4, (Func<WSspSelectProductsSecondGroupWithAccLinkField_Result, bool>)((WSspSelectProductsSecondGroupWithAccLinkField_Result x) => x.SGLinkAccGroupIdStr == vm.LinkAccGroupIdStr));
						if (wSspSelectProductsSecondGroupWithAccLinkField_Result != null && wSspSelectProductsSecondGroupWithAccLinkField_Result.PrdSecondGroupID != 0)
						{
							vm.PrdGroupID = wSspSelectProductsSecondGroupWithAccLinkField_Result.PrdSecondGroupID;
						}
					}
					list.Add(vm);
					num++;
				}
			}
			lkProductGroupInfoViewModelObjects.lst = list;
			lkProductGroupInfoViewModelObjects.FilteredLst = list;
			lkProductGroupInfoViewModelObjects.Json = Json(list, JsonRequestBehavior.AllowGet);
			lkProductGroupInfoViewModelObjects.SerializedJson = JsonConvert.SerializeObject(list);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return lkProductGroupInfoViewModelObjects;
	}

	public lstLkProductGroupInfoViewModel ShygunDetailedAPIProductGroupList(bool isMainGroup)
	{
		lstLkProductGroupInfoViewModel lstLkProductGroupInfoViewModel = new lstLkProductGroupInfoViewModel();
		lstLkProductGroupInfoViewModel.lst = new List<LkProductGroupInfoViewModel>();
		lstLkProductGroupInfoViewModel.lstSelectListItem = new List<SelectListItem>();
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
			LkProductGroupInfoViewModelObjects shygunDetailedAPIProductGroupList = GetShygunDetailedAPIProductGroupList(isMainGroup);
			if (shygunDetailedAPIProductGroupList != null)
			{
				List<LkProductGroupInfoViewModel> lst = shygunDetailedAPIProductGroupList.lst;
				if (lst != null && Enumerable.Any<LkProductGroupInfoViewModel>((IEnumerable<LkProductGroupInfoViewModel>)lst))
				{
					new List<SelectListItem>();
					foreach (LkProductGroupInfoViewModel item in lst)
					{
						lstLkProductGroupInfoViewModel.lst.Add(item);
						lstLkProductGroupInfoViewModel.lstSelectListItem.Add(new SelectListItem
						{
							Value = item.LinkAccGroupIdStr,
							Text = item.GroupName,
							Selected = false
						});
					}
				}
			}
			lstLkProductGroupInfoViewModel.isDone = true;
			lstLkProductGroupInfoViewModel.Message = "";
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			lstLkProductGroupInfoViewModel.isDone = false;
			lstLkProductGroupInfoViewModel.Message = "Error: " + ex.Message;
		}
		if (!isMainGroup)
		{
			base.ViewBag.LinkAccSGListJs = JsonConvert.SerializeObject(lstLkProductGroupInfoViewModel.lst);
			base.ViewBag.LinkAccSGSelectListJs = JsonConvert.SerializeObject(lstLkProductGroupInfoViewModel.lstSelectListItem);
			base.ViewBag.LinkAccSGList = lstLkProductGroupInfoViewModel;
		}
		else
		{
			base.ViewBag.LinkAccFGListJs = JsonConvert.SerializeObject(lstLkProductGroupInfoViewModel.lst);
			base.ViewBag.LinkAccFGSelectListJs = JsonConvert.SerializeObject(lstLkProductGroupInfoViewModel.lstSelectListItem);
			base.ViewBag.LinkAccFGList = lstLkProductGroupInfoViewModel;
		}
		return lstLkProductGroupInfoViewModel;
	}

	[DynamicAuthorize(ControllerName = "frmProductGroup", ActionName = "actManagePrdGroupsLinkAcc")]
	public ActionResult ManagePrdGroupLinkAcc(int linkAccSystemId)
	{
		GetProductGroup(isMainGroup: true);
		GetProductGroup(isMainGroup: false);
		int result = 0;
		if (linkAccSystemId == 26)
		{
			int.TryParse(new CRMIdeal.Classes.Helper.OtherSystems.ShygunDetailedAPIProvider().PrdGroupSyncTypeId.ToString(), out result);
			ShygunDetailedAPIProductGroupList(isMainGroup: true);
			ShygunDetailedAPIProductGroupList(isMainGroup: false);
		}
		base.ViewBag.PrdGroupSyncTypeId = result;
		base.ViewBag.LinkAccSystemId = linkAccSystemId;
		return View();
	}

	public JsonResult GetManagePrdGroupListJs(bool isMainGroup)
	{
		int result = 0;
		CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
		if (cRMspSelectCrmsysSetting_Result != null)
		{
			int.TryParse(cRMspSelectCrmsysSetting_Result.LinkAccSystemId.ToString(), out result);
		}
		CRMIdeal.Classes.Helper.Setting.GetLinkAccSystemTitle();
		List<LkProductGroupInfoViewModel> list = new List<LkProductGroupInfoViewModel>();
		if (result == 26)
		{
			LkProductGroupInfoViewModelObjects shygunDetailedAPIProductGroupList = GetShygunDetailedAPIProductGroupList(isMainGroup);
			if (shygunDetailedAPIProductGroupList != null && shygunDetailedAPIProductGroupList.lst != null && Enumerable.Any<LkProductGroupInfoViewModel>((IEnumerable<LkProductGroupInfoViewModel>)shygunDetailedAPIProductGroupList.lst))
			{
				list = shygunDetailedAPIProductGroupList.lst;
			}
		}
		if (list == null)
		{
			list = new List<LkProductGroupInfoViewModel>();
		}
		JsonResult jsonResult = Json(list, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public ActionResult ManageProductGroupImport_Read([DataSourceRequest] DataSourceRequest request, bool isMainGroup)
	{
		int result = 0;
		CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
		if (cRMspSelectCrmsysSetting_Result != null)
		{
			int.TryParse(cRMspSelectCrmsysSetting_Result.LinkAccSystemId.ToString(), out result);
		}
		CRMIdeal.Classes.Helper.Setting.GetLinkAccSystemTitle();
		List<LkProductGroupInfoViewModel> list = new List<LkProductGroupInfoViewModel>();
		if (result == 26)
		{
			LkProductGroupInfoViewModelObjects shygunDetailedAPIProductGroupList = GetShygunDetailedAPIProductGroupList(isMainGroup);
			if (shygunDetailedAPIProductGroupList != null && shygunDetailedAPIProductGroupList.lst != null && Enumerable.Any<LkProductGroupInfoViewModel>((IEnumerable<LkProductGroupInfoViewModel>)shygunDetailedAPIProductGroupList.lst))
			{
				list = shygunDetailedAPIProductGroupList.lst;
			}
		}
		if (list != null)
		{
			if (Enumerable.Any<LkProductGroupInfoViewModel>((IEnumerable<LkProductGroupInfoViewModel>)list))
			{
				foreach (LkProductGroupInfoViewModel item in list)
				{
					if (!string.IsNullOrWhiteSpace(item.LinkAccGroupCode) && string.IsNullOrWhiteSpace(item.GroupCode))
					{
						item.GroupCode = item.LinkAccGroupCode;
					}
				}
			}
		}
		else
		{
			list = new List<LkProductGroupInfoViewModel>();
		}
		JsonResult jsonResult = Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[DynamicAuthorize(ControllerName = "frmManagePrdGroupsLinkAcc", ActionName = "actImportFGShowInfo,actImportSGShowInfo")]
	public string ManageImportProductGroupInfo(string records = "", bool isMainGroup = false)
	{
		string result = "";
		try
		{
			if (UserLogin.CurrentUser != null)
			{
				_ = UserLogin.CurrentUser.UserLastCId;
			}
			DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
			_ = Financial.Get().Id;
			short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			_ = UserLogin.CurrentUser.UserId;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			int result3 = 0;
			CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
			if (cRMspSelectCrmsysSetting_Result != null)
			{
				int.TryParse(cRMspSelectCrmsysSetting_Result.LinkAccSystemId.ToString(), out result3);
			}
			CRMIdeal.Classes.Helper.Setting.GetLinkAccSystemTitle();
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[DynamicAuthorize(ControllerName = "frmManagePrdGroupsLinkAcc", ActionName = "actImportFGInfo")]
	[HttpPost]
	public string ManageImportProductFirstGroup(string records = "")
	{
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		string result = Messages.msgErrorRunFunction;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			SelectProductsFirstGroupWithAccLinkField(withLinkAccGroupId: false, withLinkAccGroupCode: false, withLinkAccGroupIdStr: true);
			if (!string.IsNullOrWhiteSpace(records))
			{
				List<LkProductFirstGroupInfoViewModel> list = new List<LkProductFirstGroupInfoViewModel>();
				List<LkProductFirstGroupInfoViewModel> list2 = new List<LkProductFirstGroupInfoViewModel>();
				list2 = new JavaScriptSerializer().Deserialize<List<LkProductFirstGroupInfoViewModel>>(records);
				if (list2 != null && Enumerable.Any<LkProductFirstGroupInfoViewModel>((IEnumerable<LkProductFirstGroupInfoViewModel>)list2))
				{
					list = Enumerable.ToList<LkProductFirstGroupInfoViewModel>(Enumerable.Where<LkProductFirstGroupInfoViewModel>((IEnumerable<LkProductFirstGroupInfoViewModel>)list2, (Func<LkProductFirstGroupInfoViewModel, bool>)((LkProductFirstGroupInfoViewModel x) => x.Selected)));
				}
				if (list != null && Enumerable.Any<LkProductFirstGroupInfoViewModel>((IEnumerable<LkProductFirstGroupInfoViewModel>)list) && list.Count > 0)
				{
					DateTime now = DateTime.Now;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					int id = Financial.Get().Id;
					short value2 = short.Parse(Financial.Get().Id.ToString());
					short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					string appType = Configuration.AppType;
					int userId = UserLogin.CurrentUser.UserId;
					string json = JsonConvert.SerializeObject(list);
					ObjectParameter objectParameter = new ObjectParameter("ErrorMessage", "");
					_dbLink.CRMspLkWSInsertUpdateProductsFirstGroup(json, userId, value3, value2, id, value, registerDatePersian, appType, result2, objectParameter);
					result = ((objectParameter == null || string.IsNullOrWhiteSpace(objectParameter.Value.ToString())) ? "" : objectParameter.Value.ToString());
				}
			}
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductFirstGroup");
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductSecondGroup");
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result = Labels.Error + ": " + ex.Message;
		}
		return result;
	}

	[DynamicAuthorize(ControllerName = "frmManagePrdGroupsLinkAcc", ActionName = "actImportSGInfo")]
	[HttpPost]
	public string ManageImportProductSecondGroup(string records = "")
	{
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		string result = Messages.msgErrorRunFunction;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			if (!string.IsNullOrWhiteSpace(records))
			{
				List<LkProductSecondGroupInfoViewModel> list = new List<LkProductSecondGroupInfoViewModel>();
				List<LkProductSecondGroupInfoViewModel> list2 = new List<LkProductSecondGroupInfoViewModel>();
				list2 = new JavaScriptSerializer().Deserialize<List<LkProductSecondGroupInfoViewModel>>(records);
				if (list2 != null && Enumerable.Any<LkProductSecondGroupInfoViewModel>((IEnumerable<LkProductSecondGroupInfoViewModel>)list2) && list2.Count > 0)
				{
					list = Enumerable.ToList<LkProductSecondGroupInfoViewModel>(Enumerable.Where<LkProductSecondGroupInfoViewModel>((IEnumerable<LkProductSecondGroupInfoViewModel>)list2, (Func<LkProductSecondGroupInfoViewModel, bool>)((LkProductSecondGroupInfoViewModel x) => x.Selected)));
				}
				if (list != null && Enumerable.Any<LkProductSecondGroupInfoViewModel>((IEnumerable<LkProductSecondGroupInfoViewModel>)list) && list.Count > 0)
				{
					DateTime now = DateTime.Now;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					int id = Financial.Get().Id;
					short value2 = short.Parse(Financial.Get().Id.ToString());
					short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					string appType = Configuration.AppType;
					int userId = UserLogin.CurrentUser.UserId;
					string json = JsonConvert.SerializeObject(list);
					ObjectParameter objectParameter = new ObjectParameter("ErrorMessage", "");
					_dbLink.CRMspLkWSInsertUpdateProductsSecondGroup(json, userId, value3, value2, id, value, registerDatePersian, appType, result2, objectParameter);
					result = ((objectParameter == null || string.IsNullOrWhiteSpace(objectParameter.Value.ToString())) ? "" : objectParameter.Value.ToString());
				}
			}
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductFirstGroup");
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductSecondGroup");
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result = Labels.Error + ": " + ex.Message;
		}
		return result;
	}

	[HttpPost]
	public string ManageSyncPrdGroup(string jsData, bool isMainGroup, int syncType = 1)
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
					if (isMainGroup)
					{
						foreach (SelectListItem item in list3)
						{
							ObjectParameter objectParameter = new ObjectParameter("ErrorMessage", "");
							new List<SelectListItem>();
							if (!string.IsNullOrWhiteSpace(item.Text))
							{
								List<CommonWithIdStrViewModel> list5 = JsonConvert.DeserializeObject<List<CommonWithIdStrViewModel>>(item.Text);
								if (list5 != null && Enumerable.Count<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list5) == 1)
								{
									int result2 = 0;
									int.TryParse(Enumerable.FirstOrDefault<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list5).Extra, out result2);
									WSProductFirstGroup wSProductFirstGroup = _dbTbl.WSProductFirstGroup.Find(result2);
									if (wSProductFirstGroup != null)
									{
										wSProductFirstGroup.FGLinkAccGroupIdStr = Enumerable.FirstOrDefault<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list5).Id;
										wSProductFirstGroup.FGLinkAccGroupCode = Enumerable.FirstOrDefault<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list5).Code;
										wSProductFirstGroup.FGLinkAccGroupName = Enumerable.FirstOrDefault<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list5).Name;
										wSProductFirstGroup.AppType = appType;
										wSProductFirstGroup.UserId = userId;
										wSProductFirstGroup.Month1 = num;
										wSProductFirstGroup.RegisterDate = dateTime;
										wSProductFirstGroup.RegisterDatePersian = registerDatePersian;
										_dbTbl.Entry(wSProductFirstGroup).State = EntityState.Modified;
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
					else
					{
						foreach (SelectListItem item2 in list3)
						{
							ObjectParameter objectParameter2 = new ObjectParameter("ErrorMessage", "");
							_dbLink.CRMspLkWSInsertUpdateProductSGLinkAccGroups(int.Parse(item2.Value), item2.Text, userId, num, dateTime, registerDatePersian, appType, objectParameter2);
							new List<SelectListItem>();
							if (!string.IsNullOrWhiteSpace(item2.Text))
							{
								List<CommonWithIdStrViewModel> list6 = JsonConvert.DeserializeObject<List<CommonWithIdStrViewModel>>(item2.Text);
								if (list6 != null && Enumerable.Count<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list6) == 1)
								{
									int result3 = 0;
									int.TryParse(Enumerable.FirstOrDefault<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list6).Extra, out result3);
									WSProductSecondGroup wSProductSecondGroup = _dbTbl.WSProductSecondGroup.Find(result3);
									if (wSProductSecondGroup != null)
									{
										wSProductSecondGroup.SGLinkAccGroupIdStr = Enumerable.FirstOrDefault<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list6).Id;
										wSProductSecondGroup.SGLinkAccGroupCode = Enumerable.FirstOrDefault<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list6).Code;
										wSProductSecondGroup.SGLinkAccGroupName = Enumerable.FirstOrDefault<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list6).Name;
										wSProductSecondGroup.AppType = appType;
										wSProductSecondGroup.UserId = userId;
										wSProductSecondGroup.Month1 = num;
										wSProductSecondGroup.RegisterDate = dateTime;
										wSProductSecondGroup.RegisterDatePersian = registerDatePersian;
										_dbTbl.Entry(wSProductSecondGroup).State = EntityState.Modified;
										_dbTbl.Configuration.ValidateOnSaveEnabled = false;
										_dbTbl.SaveChanges();
										_dbTbl.Configuration.ValidateOnSaveEnabled = true;
									}
								}
							}
							if (objectParameter2.Value != null)
							{
								if (!string.IsNullOrEmpty(objectParameter2.Value.ToString()))
								{
									text = text + objectParameter2.Value.ToString() + "|";
									continue;
								}
								list.Add(new SelectListItem
								{
									Value = item2.Value,
									Text = item2.Text
								});
							}
							else
							{
								list.Add(new SelectListItem
								{
									Value = item2.Value,
									Text = item2.Text
								});
							}
						}
					}
				}
			}
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductFirstGroup");
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductSecondGroup");
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return text + "|**|" + JsonConvert.SerializeObject(list);
	}

	[DynamicAuthorize(ControllerName = "frmManagePrdGroupsLinkAcc", ActionName = "actCanChangeLinkType")]
	[HttpPost]
	public string ManageSyncPrdGroupType(int syncType = 1)
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
			DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
			_ = Financial.Get().Id;
			short.Parse(Financial.Get().Id.ToString());
			short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			_ = UserLogin.CurrentUser.UserId;
			int result3 = 0;
			string text = "";
			CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
			if (cRMspSelectCrmsysSetting_Result != null)
			{
				int.TryParse(cRMspSelectCrmsysSetting_Result.LinkAccSystemId.ToString(), out result3);
			}
			text = CRMIdeal.Classes.Helper.Setting.GetLinkAccSystemTitle();
			if (result3 == 26)
			{
				int prdGroupSyncTypeLinkAccSettingId = new CRMIdeal.Classes.Helper.OtherSystems.ShygunDetailedAPIProvider().PrdGroupSyncTypeLinkAccSettingId;
				if (prdGroupSyncTypeLinkAccSettingId != 0)
				{
					CRMIdeal.Classes.Helper.OtherSystems.UpdateLinkAccSettingPartValue(prdGroupSyncTypeLinkAccSettingId, syncType.ToString());
				}
				else
				{
					result = string.Format(Messages.msgNotSetLinkAccSettingPrdGroupRelation, text);
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public lstLkProductGroupInfoViewModel GetProductGroup(bool isMainGroup)
	{
		lstLkProductGroupInfoViewModel lstLkProductGroupInfoViewModel = new lstLkProductGroupInfoViewModel();
		lstLkProductGroupInfoViewModel.lst = new List<LkProductGroupInfoViewModel>();
		lstLkProductGroupInfoViewModel.lstSelectListItem = new List<SelectListItem>();
		try
		{
			_ = UserLogin.CurrentUser.UserId;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (isMainGroup)
			{
				List<WSspSelectProductsFirstGroupWithAccLinkField_Result> list = Enumerable.ToList<WSspSelectProductsFirstGroupWithAccLinkField_Result>((IEnumerable<WSspSelectProductsFirstGroupWithAccLinkField_Result>)_dbLink.WSspSelectProductsFirstGroupWithAccLinkField(false, false, false, lCID, result));
				if (list != null && Enumerable.Any<WSspSelectProductsFirstGroupWithAccLinkField_Result>((IEnumerable<WSspSelectProductsFirstGroupWithAccLinkField_Result>)list))
				{
					List<LkProductGroupInfoViewModel> list2 = new List<LkProductGroupInfoViewModel>();
					List<SelectListItem> list3 = new List<SelectListItem>();
					foreach (WSspSelectProductsFirstGroupWithAccLinkField_Result item in list)
					{
						list2.Add(new LkProductGroupInfoViewModel
						{
							PrdGroupID = item.PrdFirstGroupID,
							ParentGroupId = 0,
							GroupCode = item.FGCode,
							GroupName = item.FGName,
							LinkAccGroupCode = item.FGLinkAccGroupCode,
							LinkAccGroupIdStr = item.FGLinkAccGroupIdStr,
							LinkAccGroupName = item.FGLinkAccGroupName,
							ParentGroupName = ""
						});
						list3.Add(new SelectListItem
						{
							Value = item.PrdFirstGroupID.ToString(),
							Text = item.FGName,
							Selected = false
						});
					}
					lstLkProductGroupInfoViewModel.lst = list2;
					lstLkProductGroupInfoViewModel.lstSelectListItem = list3;
				}
			}
			else
			{
				List<CRMspLkWSSelectProductSecondGroup_Result> list4 = Enumerable.ToList<CRMspLkWSSelectProductSecondGroup_Result>((IEnumerable<CRMspLkWSSelectProductSecondGroup_Result>)_dbLink.CRMspLkWSSelectProductSecondGroup(0, lCID, result));
				if (list4 != null && Enumerable.Any<CRMspLkWSSelectProductSecondGroup_Result>((IEnumerable<CRMspLkWSSelectProductSecondGroup_Result>)list4))
				{
					List<LkProductGroupInfoViewModel> list5 = new List<LkProductGroupInfoViewModel>();
					List<SelectListItem> list6 = new List<SelectListItem>();
					foreach (CRMspLkWSSelectProductSecondGroup_Result item2 in list4)
					{
						list5.Add(new LkProductGroupInfoViewModel
						{
							PrdGroupID = item2.PrdSecondGroupID,
							ParentGroupId = item2.FirstGroupId,
							GroupCode = item2.SGCode,
							GroupName = item2.FulName,
							LinkAccGroupCode = item2.SGLinkAccGroupCode,
							LinkAccGroupIdStr = item2.SGLinkAccGroupIdStr,
							LinkAccGroupName = item2.SGLinkAccGroupName,
							ParentGroupName = item2.FGName
						});
						list6.Add(new SelectListItem
						{
							Value = item2.PrdSecondGroupID.ToString(),
							Text = item2.FulName,
							Selected = false
						});
					}
					lstLkProductGroupInfoViewModel.lst = list5;
					lstLkProductGroupInfoViewModel.lstSelectListItem = list6;
				}
			}
			lstLkProductGroupInfoViewModel.isDone = true;
			lstLkProductGroupInfoViewModel.Message = "";
		}
		catch (Exception ex)
		{
			lstLkProductGroupInfoViewModel.isDone = false;
			lstLkProductGroupInfoViewModel.Message = "Error: " + ex.Message;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		if (!isMainGroup)
		{
			base.ViewBag.CrmSGListJs = JsonConvert.SerializeObject(lstLkProductGroupInfoViewModel.lst);
			base.ViewBag.CrmSGSelectListJs = JsonConvert.SerializeObject(lstLkProductGroupInfoViewModel.lstSelectListItem);
			base.ViewBag.CrmSGList = lstLkProductGroupInfoViewModel;
		}
		else
		{
			base.ViewBag.CrmFGListJs = JsonConvert.SerializeObject(lstLkProductGroupInfoViewModel.lst);
			base.ViewBag.CrmFGSelectListJs = JsonConvert.SerializeObject(lstLkProductGroupInfoViewModel.lstSelectListItem);
			base.ViewBag.CrmFGList = lstLkProductGroupInfoViewModel;
		}
		return lstLkProductGroupInfoViewModel;
	}

	public string GetLinkedPrdGroupsList(bool isMainGroup)
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
			if (isMainGroup)
			{
				List<WSspSelectProductsFirstGroupWithAccLinkField_Result> list = Enumerable.ToList<WSspSelectProductsFirstGroupWithAccLinkField_Result>((IEnumerable<WSspSelectProductsFirstGroupWithAccLinkField_Result>)_dbLink.WSspSelectProductsFirstGroupWithAccLinkField(false, false, false, lCID, result2));
				if (list != null && Enumerable.Any<WSspSelectProductsFirstGroupWithAccLinkField_Result>((IEnumerable<WSspSelectProductsFirstGroupWithAccLinkField_Result>)list) && list.Count > 0)
				{
					result = JsonConvert.SerializeObject(list);
				}
			}
			else
			{
				List<WSspSelectProductsSecondGroupWithAccLinkField_Result> list2 = Enumerable.ToList<WSspSelectProductsSecondGroupWithAccLinkField_Result>((IEnumerable<WSspSelectProductsSecondGroupWithAccLinkField_Result>)_dbLink.WSspSelectProductsSecondGroupWithAccLinkField(false, false, false, true, lCID, result2));
				if (list2 != null && Enumerable.Any<WSspSelectProductsSecondGroupWithAccLinkField_Result>((IEnumerable<WSspSelectProductsSecondGroupWithAccLinkField_Result>)list2) && list2.Count > 0)
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

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbLink.Dispose();
		_db_I.Dispose();
		base.Dispose(disposing);
	}
}
