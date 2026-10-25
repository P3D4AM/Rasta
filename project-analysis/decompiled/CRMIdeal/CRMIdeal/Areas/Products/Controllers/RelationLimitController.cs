using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using CRM.General.Security;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace CRMIdeal.Areas.Products.Controllers;

public class RelationLimitController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actPrdRelationLimit")]
	public ActionResult Index()
	{
		GetProductRelationType();
		return View();
	}

	public List<TreeViewItemModel> GetPrdGroupNodeTree(List<WSspSelectProductGroupTree_Result> lstPrdGroup, int? gId)
	{
		List<TreeViewItemModel> list = new List<TreeViewItemModel>();
		try
		{
			List<WSspSelectProductGroupTree_Result> list2 = Enumerable.ToList<WSspSelectProductGroupTree_Result>(Enumerable.Where<WSspSelectProductGroupTree_Result>((IEnumerable<WSspSelectProductGroupTree_Result>)lstPrdGroup, (Func<WSspSelectProductGroupTree_Result, bool>)((WSspSelectProductGroupTree_Result m) => m.ParentId == gId)));
			if (Enumerable.Any<WSspSelectProductGroupTree_Result>((IEnumerable<WSspSelectProductGroupTree_Result>)list2))
			{
				foreach (WSspSelectProductGroupTree_Result item in list2)
				{
					TreeViewItemModel treeViewItemModel = new TreeViewItemModel();
					treeViewItemModel.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", item.SId.ToString()));
					treeViewItemModel.Id = item.SId.ToString();
					treeViewItemModel.Text = item.KEYName;
					treeViewItemModel.ImageUrl = "";
					treeViewItemModel.Items = null;
					list.Add(treeViewItemModel);
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	public List<TreeViewItemModel> GetPrdGroupTree()
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
			List<WSspSelectProductGroupTree_Result> list2 = Enumerable.ToList<WSspSelectProductGroupTree_Result>((IEnumerable<WSspSelectProductGroupTree_Result>)_db.WSspSelectProductGroupTree(lCID, result));
			if (Enumerable.Any<WSspSelectProductGroupTree_Result>((IEnumerable<WSspSelectProductGroupTree_Result>)list2))
			{
				List<WSspSelectProductGroupTree_Result> list3 = Enumerable.ToList<WSspSelectProductGroupTree_Result>(Enumerable.Where<WSspSelectProductGroupTree_Result>((IEnumerable<WSspSelectProductGroupTree_Result>)list2, (Func<WSspSelectProductGroupTree_Result, bool>)((WSspSelectProductGroupTree_Result m) => m.ParentId == 0)));
				if (Enumerable.Any<WSspSelectProductGroupTree_Result>((IEnumerable<WSspSelectProductGroupTree_Result>)list3))
				{
					foreach (WSspSelectProductGroupTree_Result item in list3)
					{
						TreeViewItemModel treeViewItemModel = new TreeViewItemModel();
						treeViewItemModel.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", item.SId.ToString()));
						treeViewItemModel.Id = item.SId.ToString();
						treeViewItemModel.Text = item.KEYName;
						treeViewItemModel.ImageUrl = "";
						List<TreeViewItemModel> prdGroupNodeTree = GetPrdGroupNodeTree(list2, item.FId);
						treeViewItemModel.Items = new List<TreeViewItemModel>(prdGroupNodeTree);
						list.Add(treeViewItemModel);
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

	[AjaxOnly]
	public ActionResult _PartialProductGroupTree()
	{
		try
		{
			List<TreeViewItemModel> prdGroupTree = GetPrdGroupTree();
			base.ViewBag.PrdGroupTree = prdGroupTree;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return PartialView();
	}

	[AjaxOnly]
	public JsonResult GetProductRelationType()
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
			List<WSspSelectProductRelationType_Result> list2 = Enumerable.ToList<WSspSelectProductRelationType_Result>((IEnumerable<WSspSelectProductRelationType_Result>)_db.WSspSelectProductRelationType(lCID, result));
			list.AddRange(Enumerable.Select<WSspSelectProductRelationType_Result, SelectListItem>((IEnumerable<WSspSelectProductRelationType_Result>)list2, (Func<WSspSelectProductRelationType_Result, SelectListItem>)((WSspSelectProductRelationType_Result item) => new SelectListItem
			{
				Text = item.RelationTypeName,
				Value = item.ProductRelationTypeId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.ProductRelationTypeList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetCompanyGroup()
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
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			List<CRMspSelectCompanyGroup_Result> list2 = Enumerable.ToList<CRMspSelectCompanyGroup_Result>((IEnumerable<CRMspSelectCompanyGroup_Result>)_db.CRMspSelectCompanyGroup(UserLogin.CurrentUser.UserId, lCID, result, result2));
			list.AddRange(Enumerable.Select<CRMspSelectCompanyGroup_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyGroup_Result>)list2, (Func<CRMspSelectCompanyGroup_Result, SelectListItem>)((CRMspSelectCompanyGroup_Result item) => new SelectListItem
			{
				Text = item.GroupName,
				Value = item.CompanyGroupID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetCompanyGroupII()
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
			List<CRMspSelectCompanyGroupsII_Result> list2 = Enumerable.ToList<CRMspSelectCompanyGroupsII_Result>((IEnumerable<CRMspSelectCompanyGroupsII_Result>)_db.CRMspSelectCompanyGroupsII(lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectCompanyGroupsII_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyGroupsII_Result>)list2, (Func<CRMspSelectCompanyGroupsII_Result, SelectListItem>)((CRMspSelectCompanyGroupsII_Result item) => new SelectListItem
			{
				Text = item.GroupIIName,
				Value = item.CompanyGroupIIID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetCompanyGroupIII()
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
			List<CRMspSelectCompanyGroupsIII_Result> list2 = Enumerable.ToList<CRMspSelectCompanyGroupsIII_Result>((IEnumerable<CRMspSelectCompanyGroupsIII_Result>)_db.CRMspSelectCompanyGroupsIII(lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectCompanyGroupsIII_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyGroupsIII_Result>)list2, (Func<CRMspSelectCompanyGroupsIII_Result, SelectListItem>)((CRMspSelectCompanyGroupsIII_Result item) => new SelectListItem
			{
				Text = item.GroupIIIName,
				Value = item.CompanyGroupIIIID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetCompanyGroupIV()
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
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			List<CRMspSelectCompanyGroupsIV_Result> list2 = Enumerable.ToList<CRMspSelectCompanyGroupsIV_Result>((IEnumerable<CRMspSelectCompanyGroupsIV_Result>)_db.CRMspSelectCompanyGroupsIV(UserLogin.CurrentUser.UserId, lCID, result, result2));
			list.AddRange(Enumerable.Select<CRMspSelectCompanyGroupsIV_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyGroupsIV_Result>)list2, (Func<CRMspSelectCompanyGroupsIV_Result, SelectListItem>)((CRMspSelectCompanyGroupsIV_Result item) => new SelectListItem
			{
				Text = item.GroupIVName,
				Value = item.CompanyGroupIVID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetCompanyType()
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
			List<CRMspSelectCompanyType_Result> list2 = Enumerable.ToList<CRMspSelectCompanyType_Result>((IEnumerable<CRMspSelectCompanyType_Result>)_db.CRMspSelectCompanyType(lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectCompanyType_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyType_Result>)list2, (Func<CRMspSelectCompanyType_Result, SelectListItem>)((CRMspSelectCompanyType_Result item) => new SelectListItem
			{
				Text = item.CompanyTypeName,
				Value = item.CompanyTypeID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetProjectGroup()
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
			List<CRMspSelectProjectGroups_Result> list2 = Enumerable.ToList<CRMspSelectProjectGroups_Result>((IEnumerable<CRMspSelectProjectGroups_Result>)_db.CRMspSelectProjectGroups(lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectProjectGroups_Result, SelectListItem>((IEnumerable<CRMspSelectProjectGroups_Result>)list2, (Func<CRMspSelectProjectGroups_Result, SelectListItem>)((CRMspSelectProjectGroups_Result item) => new SelectListItem
			{
				Text = item.ProjectGroup,
				Value = item.ProjectGroupID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult SearchCompany(string value = "")
	{
		List<CRMspMainSearchWeb_Result> data = new List<CRMspMainSearchWeb_Result>();
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
			data = Enumerable.ToList<CRMspMainSearchWeb_Result>((IEnumerable<CRMspMainSearchWeb_Result>)_dbI.CRMspMainSearchWeb(value, UserLogin.CurrentUser.UserId, 4, lCID, result, "", result2));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	public List<TreeViewItemModel> GetProjectCategoryNodeTree(List<CRMspSelectProjectCategoryTree_Result> lstCategory, int? currCatId)
	{
		List<TreeViewItemModel> list = new List<TreeViewItemModel>();
		try
		{
			List<CRMspSelectProjectCategoryTree_Result> list2 = Enumerable.ToList<CRMspSelectProjectCategoryTree_Result>(Enumerable.Where<CRMspSelectProjectCategoryTree_Result>((IEnumerable<CRMspSelectProjectCategoryTree_Result>)lstCategory, (Func<CRMspSelectProjectCategoryTree_Result, bool>)((CRMspSelectProjectCategoryTree_Result m) => m.ParentId == currCatId)));
			if (Enumerable.Any<CRMspSelectProjectCategoryTree_Result>((IEnumerable<CRMspSelectProjectCategoryTree_Result>)list2))
			{
				foreach (CRMspSelectProjectCategoryTree_Result item in list2)
				{
					TreeViewItemModel treeViewItemModel = new TreeViewItemModel();
					treeViewItemModel.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", item.ProjectCategoryId.ToString()));
					treeViewItemModel.HtmlAttributes.Add(new KeyValuePair<string, string>("categoryFullName", item.CategoryFullName.ToString()));
					treeViewItemModel.Id = item.ProjectCategoryId.ToString();
					treeViewItemModel.Text = item.CategoryName;
					treeViewItemModel.ImageUrl = "";
					List<TreeViewItemModel> projectCategoryNodeTree = GetProjectCategoryNodeTree(lstCategory, item.ProjectCategoryId);
					treeViewItemModel.Items = new List<TreeViewItemModel>(projectCategoryNodeTree);
					list.Add(treeViewItemModel);
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	public List<TreeViewItemModel> GetProjectCategoryTree(int currCatId = -1)
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
			List<CRMspSelectProjectCategoryTree_Result> list2 = Enumerable.ToList<CRMspSelectProjectCategoryTree_Result>((IEnumerable<CRMspSelectProjectCategoryTree_Result>)_db.CRMspSelectProjectCategoryTree(currCatId, lCID, result));
			if (Enumerable.Any<CRMspSelectProjectCategoryTree_Result>((IEnumerable<CRMspSelectProjectCategoryTree_Result>)list2))
			{
				List<CRMspSelectProjectCategoryTree_Result> list3 = Enumerable.ToList<CRMspSelectProjectCategoryTree_Result>(Enumerable.Where<CRMspSelectProjectCategoryTree_Result>((IEnumerable<CRMspSelectProjectCategoryTree_Result>)list2, (Func<CRMspSelectProjectCategoryTree_Result, bool>)((CRMspSelectProjectCategoryTree_Result m) => m.ParentId == 0)));
				if (Enumerable.Any<CRMspSelectProjectCategoryTree_Result>((IEnumerable<CRMspSelectProjectCategoryTree_Result>)list3))
				{
					foreach (CRMspSelectProjectCategoryTree_Result item in list3)
					{
						TreeViewItemModel treeViewItemModel = new TreeViewItemModel();
						treeViewItemModel.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", item.ProjectCategoryId.ToString()));
						treeViewItemModel.HtmlAttributes.Add(new KeyValuePair<string, string>("categoryFullName", item.CategoryFullName.ToString()));
						treeViewItemModel.Id = item.ProjectCategoryId.ToString();
						treeViewItemModel.Text = item.CategoryName;
						treeViewItemModel.ImageUrl = "";
						List<TreeViewItemModel> projectCategoryNodeTree = GetProjectCategoryNodeTree(list2, item.ProjectCategoryId);
						treeViewItemModel.Items = new List<TreeViewItemModel>(projectCategoryNodeTree);
						list.Add(treeViewItemModel);
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

	[AjaxOnly]
	public ActionResult _PartialProjectCategoryTree(int currCatId = -1)
	{
		try
		{
			List<TreeViewItemModel> projectCategoryTree = GetProjectCategoryTree(currCatId);
			base.ViewBag.PrjCategoryTree = projectCategoryTree;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return PartialView();
	}

	[AjaxOnly]
	public ActionResult ProductNoRelationLimitForType_Read([DataSourceRequest] DataSourceRequest request, int prdRelationTypeId, int objectId, int prdGroupId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspSelectProductNoRelationLimitForType_Result> enumerable = new List<WSspSelectProductNoRelationLimitForType_Result>();
		try
		{
			string activeText = "(" + Labels.Active + ")";
			string inActiveText = "(" + Labels.Passive + ")";
			enumerable = Enumerable.ToList<WSspSelectProductNoRelationLimitForType_Result>((IEnumerable<WSspSelectProductNoRelationLimitForType_Result>)_db.WSspSelectProductNoRelationLimitForType(prdRelationTypeId, objectId, prdGroupId, activeText, inActiveText, lCID, result));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(((IEnumerable)enumerable).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public ActionResult ProductRelationLimitForType_Read([DataSourceRequest] DataSourceRequest request, int prdRelationTypeId, int objectId, int prdGroupId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspSelectProductRelationLimitForType_Result> enumerable = new List<WSspSelectProductRelationLimitForType_Result>();
		try
		{
			string activeText = "(" + Labels.Active + ")";
			string inActiveText = "(" + Labels.Passive + ")";
			enumerable = Enumerable.ToList<WSspSelectProductRelationLimitForType_Result>((IEnumerable<WSspSelectProductRelationLimitForType_Result>)_db.WSspSelectProductRelationLimitForType(prdRelationTypeId, objectId, prdGroupId, activeText, inActiveText, lCID, result));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(((IEnumerable)enumerable).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public string ActAssign(int prdRelationTypeId, int objectId, int prdId)
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
			if (!UserLogin.IsUserAccess("frmProductRelationLimit", "actAssign", UserLogin.CurrentUser))
			{
				return Messages.ErrorNotAccess;
			}
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int value3 = int.Parse(Financial.Get().Id.ToString());
			int userId = UserLogin.CurrentUser.UserId;
			_db.WSspInsertProductRelationLimitByType(prdRelationTypeId, objectId, prdId, userId, value3, value2, value, registerDatePersian, appType, result2);
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductRelationLimit");
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result = Messages.msgErrorRunFunction + "<br>" + ex.Message;
		}
		return result;
	}

	[AjaxOnly]
	public string ActRemove(int prdRelationTypeId, int objectId, int prdId)
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
			if (!UserLogin.IsUserAccess("frmProductRelationLimit", "actRemove", UserLogin.CurrentUser))
			{
				return Messages.ErrorNotAccess;
			}
			_db.WSspDeleteProductRelationLimitByPrdIdAndType(prdRelationTypeId, objectId, prdId);
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductRelationLimit");
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result = Messages.msgErrorRunFunction + "<br>" + ex.Message;
		}
		return result;
	}

	[AjaxOnly]
	public string ActAssignAll(int prdRelationTypeId, int objectId, int prdGroupId)
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
			if (!UserLogin.IsUserAccess("frmProductRelationLimit", "actAssignAll", UserLogin.CurrentUser))
			{
				return Messages.ErrorNotAccess;
			}
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int value3 = int.Parse(Financial.Get().Id.ToString());
			int userId = UserLogin.CurrentUser.UserId;
			_db.WSspInsertProductRelationLimitAllByType(prdRelationTypeId, objectId, prdGroupId, userId, value3, value2, value, registerDatePersian, appType, result2);
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductRelationLimit");
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result = Messages.msgErrorRunFunction + "<br>" + ex.Message;
		}
		return result;
	}

	[AjaxOnly]
	public string ActRemoveAll(int prdRelationTypeId, int objectId, int prdGroupId)
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
			if (!UserLogin.IsUserAccess("frmProductRelationLimit", "actRemoveAll", UserLogin.CurrentUser))
			{
				return Messages.ErrorNotAccess;
			}
			_db.WSspDeleteProductRelationLimitAllByType(prdRelationTypeId, objectId, prdGroupId);
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductRelationLimit");
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result = Messages.msgErrorRunFunction + "<br>" + ex.Message;
		}
		return result;
	}

	[AjaxOnly]
	public string ActAssignPrdSelected(int prdRelationTypeId, int objectId, string prdIds)
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
			if (!UserLogin.IsUserAccess("frmProductRelationLimit", "actAssignPrdSelected", UserLogin.CurrentUser))
			{
				return Messages.ErrorNotAccess;
			}
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int value3 = int.Parse(Financial.Get().Id.ToString());
			int userId = UserLogin.CurrentUser.UserId;
			_db.WSspInsertProductRelationLimitByPrdIdsAndType(prdRelationTypeId, objectId, prdIds, userId, value3, value2, value, registerDatePersian, appType, result2);
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductRelationLimit");
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result = Messages.msgErrorRunFunction + "<br>" + ex.Message;
		}
		return result;
	}

	[AjaxOnly]
	public string ActRemovePrdSelected(int prdRelationTypeId, int objectId, string prdIds)
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
			if (!UserLogin.IsUserAccess("frmProductRelationLimit", "actRemovePrdSelected", UserLogin.CurrentUser))
			{
				return Messages.ErrorNotAccess;
			}
			_db.WSspDeleteProductRelationLimitByPrdIdsAndType(prdRelationTypeId, objectId, prdIds);
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductRelationLimit");
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result = Messages.msgErrorRunFunction + "<br>" + ex.Message;
		}
		return result;
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		base.Dispose(disposing);
	}
}
