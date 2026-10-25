using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using CRM.General.Security;
using CRM.Models;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using Elmah;
using Kendo.Mvc.UI;

namespace CRMIdeal.Areas.FormBase.Controllers;

public class SelectCityController : Controller
{
	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	[AjaxOnly]
	public ActionResult _PartialCityTree(string value, int? cityId = 0, int position = 0)
	{
		try
		{
			List<TreeViewItemModel> companyCityTree = GetCompanyCityTree(value, cityId);
			base.ViewBag.cmpCityTree = companyCityTree;
			base.ViewBag.position = position;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return PartialView();
	}

	public List<TreeViewItemModel> GetCompanyCityTree(string value, int? cityId = 0)
	{
		List<TreeViewItemModel> list = new List<TreeViewItemModel>();
		try
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
			List<CRMspSelectUserAccessCompanyCityTree_Result> list2 = Enumerable.ToList<CRMspSelectUserAccessCompanyCityTree_Result>((IEnumerable<CRMspSelectUserAccessCompanyCityTree_Result>)_dbI.CRMspSelectUserAccessCompanyCityTree(UserLogin.CurrentUser.UserId, cityId, value, lCID, result, result2));
			int num = 1000;
			if (list2 != null && Enumerable.Any<CRMspSelectUserAccessCompanyCityTree_Result>((IEnumerable<CRMspSelectUserAccessCompanyCityTree_Result>)list2) && Enumerable.Count<CRMspSelectUserAccessCompanyCityTree_Result>((IEnumerable<CRMspSelectUserAccessCompanyCityTree_Result>)list2) > num)
			{
				list2 = Enumerable.ToList<CRMspSelectUserAccessCompanyCityTree_Result>(Enumerable.Take<CRMspSelectUserAccessCompanyCityTree_Result>((IEnumerable<CRMspSelectUserAccessCompanyCityTree_Result>)list2, num));
			}
			if (Enumerable.Any<CRMspSelectUserAccessCompanyCityTree_Result>((IEnumerable<CRMspSelectUserAccessCompanyCityTree_Result>)list2))
			{
				List<CRMspSelectUserAccessCompanyCityTree_Result> list3 = Enumerable.ToList<CRMspSelectUserAccessCompanyCityTree_Result>(Enumerable.Where<CRMspSelectUserAccessCompanyCityTree_Result>((IEnumerable<CRMspSelectUserAccessCompanyCityTree_Result>)list2, (Func<CRMspSelectUserAccessCompanyCityTree_Result, bool>)((CRMspSelectUserAccessCompanyCityTree_Result m) => m.Type == 1)));
				if (Enumerable.Any<CRMspSelectUserAccessCompanyCityTree_Result>((IEnumerable<CRMspSelectUserAccessCompanyCityTree_Result>)list3))
				{
					foreach (CRMspSelectUserAccessCompanyCityTree_Result item in list3)
					{
						string nodeId = item.CountryID + "|-1|-1";
						TreeViewItemModel treeViewItemModel = new TreeViewItemModel();
						if (list != null && Enumerable.Any<TreeViewItemModel>((IEnumerable<TreeViewItemModel>)list))
						{
							treeViewItemModel = Enumerable.FirstOrDefault<TreeViewItemModel>((IEnumerable<TreeViewItemModel>)list, (Func<TreeViewItemModel, bool>)((TreeViewItemModel m) => m.Id == nodeId));
						}
						string value2 = "";
						if (treeViewItemModel != null)
						{
							value2 = treeViewItemModel.Id ?? "";
						}
						if (string.IsNullOrWhiteSpace(value2))
						{
							TreeViewItemModel treeViewItemModel2 = new TreeViewItemModel();
							treeViewItemModel2.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", nodeId));
							treeViewItemModel2.HtmlAttributes.Add(new KeyValuePair<string, string>("CityFullName", item.Country.ToString()));
							treeViewItemModel2.Id = nodeId;
							treeViewItemModel2.Text = item.Country;
							treeViewItemModel2.ImageUrl = "";
							List<TreeViewItemModel> companyCityProvinceNodeTree = GetCompanyCityProvinceNodeTree(list2, item.CountryID);
							treeViewItemModel2.Items = new List<TreeViewItemModel>(companyCityProvinceNodeTree);
							list.Add(treeViewItemModel2);
						}
					}
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
		return list;
	}

	public List<TreeViewItemModel> GetCompanyCityProvinceNodeTree(List<CRMspSelectUserAccessCompanyCityTree_Result> lstCity, int? currCountryId)
	{
		List<TreeViewItemModel> list = new List<TreeViewItemModel>();
		try
		{
			List<CRMspSelectUserAccessCompanyCityTree_Result> list2 = Enumerable.ToList<CRMspSelectUserAccessCompanyCityTree_Result>(Enumerable.Where<CRMspSelectUserAccessCompanyCityTree_Result>((IEnumerable<CRMspSelectUserAccessCompanyCityTree_Result>)lstCity, (Func<CRMspSelectUserAccessCompanyCityTree_Result, bool>)((CRMspSelectUserAccessCompanyCityTree_Result m) => m.CountryID == currCountryId && m.Type == 2)));
			if (Enumerable.Any<CRMspSelectUserAccessCompanyCityTree_Result>((IEnumerable<CRMspSelectUserAccessCompanyCityTree_Result>)list2))
			{
				foreach (CRMspSelectUserAccessCompanyCityTree_Result item in list2)
				{
					string nodeId = item.CountryID + "|" + item.ProvinceID + "|-1";
					TreeViewItemModel treeViewItemModel = new TreeViewItemModel();
					if (list != null && Enumerable.Any<TreeViewItemModel>((IEnumerable<TreeViewItemModel>)list))
					{
						treeViewItemModel = Enumerable.FirstOrDefault<TreeViewItemModel>((IEnumerable<TreeViewItemModel>)list, (Func<TreeViewItemModel, bool>)((TreeViewItemModel m) => m.Id == nodeId));
					}
					string value = "";
					if (treeViewItemModel != null)
					{
						value = treeViewItemModel.Id ?? "";
					}
					if (string.IsNullOrWhiteSpace(value))
					{
						TreeViewItemModel treeViewItemModel2 = new TreeViewItemModel();
						treeViewItemModel2.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", nodeId));
						treeViewItemModel2.HtmlAttributes.Add(new KeyValuePair<string, string>("CityFullName", item.Country + " " + item.Province));
						treeViewItemModel2.Id = nodeId;
						treeViewItemModel2.Text = item.Province;
						treeViewItemModel2.ImageUrl = "";
						List<TreeViewItemModel> companyCityNodeTree = GetCompanyCityNodeTree(lstCity, item.ProvinceID);
						treeViewItemModel2.Items = new List<TreeViewItemModel>(companyCityNodeTree);
						list.Add(treeViewItemModel2);
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

	public List<TreeViewItemModel> GetCompanyCityNodeTree(List<CRMspSelectUserAccessCompanyCityTree_Result> lstCity, int? currProvinceId)
	{
		List<TreeViewItemModel> list = new List<TreeViewItemModel>();
		try
		{
			List<CRMspSelectUserAccessCompanyCityTree_Result> list2 = Enumerable.ToList<CRMspSelectUserAccessCompanyCityTree_Result>(Enumerable.Where<CRMspSelectUserAccessCompanyCityTree_Result>((IEnumerable<CRMspSelectUserAccessCompanyCityTree_Result>)lstCity, (Func<CRMspSelectUserAccessCompanyCityTree_Result, bool>)((CRMspSelectUserAccessCompanyCityTree_Result m) => m.ProvinceID == currProvinceId && m.Type == 3)));
			if (Enumerable.Any<CRMspSelectUserAccessCompanyCityTree_Result>((IEnumerable<CRMspSelectUserAccessCompanyCityTree_Result>)list2))
			{
				foreach (CRMspSelectUserAccessCompanyCityTree_Result item in list2)
				{
					string nodeId = item.CountryID + "|" + item.ProvinceID + "|" + item.CityID;
					string value = item.CPC ?? "";
					TreeViewItemModel treeViewItemModel = new TreeViewItemModel();
					if (list != null && Enumerable.Any<TreeViewItemModel>((IEnumerable<TreeViewItemModel>)list))
					{
						treeViewItemModel = Enumerable.FirstOrDefault<TreeViewItemModel>((IEnumerable<TreeViewItemModel>)list, (Func<TreeViewItemModel, bool>)((TreeViewItemModel m) => m.Id == nodeId));
					}
					string value2 = "";
					if (treeViewItemModel != null)
					{
						value2 = treeViewItemModel.Id ?? "";
					}
					if (string.IsNullOrWhiteSpace(value2))
					{
						TreeViewItemModel treeViewItemModel2 = new TreeViewItemModel();
						treeViewItemModel2.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", nodeId));
						treeViewItemModel2.HtmlAttributes.Add(new KeyValuePair<string, string>("CityFullName", value));
						treeViewItemModel2.Id = nodeId;
						treeViewItemModel2.Text = item.City;
						treeViewItemModel2.ImageUrl = "";
						treeViewItemModel2.Items = null;
						list.Add(treeViewItemModel2);
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
}
