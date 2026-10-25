using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Cache.User;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.Products.Controllers;

public class SpecificationController : Controller
{
	private CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private CRMSpEntities _db = new CRMSpEntities();

	private CRMSpIIEntities _dbII = new CRMSpIIEntities();

	[DynamicAuthorize(ControllerName = "frmProducts", ActionName = "actSavePrdSpecification")]
	public ActionResult Index(int prdId)
	{
		base.ViewBag.PrdId = prdId;
		base.ViewBag.GroupsList = GetProductSpecificationFieldGroups_SelectListItem();
		base.ViewBag.lstFGroups = GetPrdFirstGroup();
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmDefineBaseInfoI", ActionName = "actInsert,actEdit")]
	public ActionResult InsertEdit(int id = 0)
	{
		return View();
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmDefineBaseInfoIDataEntry", ActionName = "actPost")]
	public string InsertEdit(string jsonValue = "", int? prdId = null, int? specificationId = null)
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
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			int userId = UserLogin.CurrentUser.UserId;
			short.Parse(Financial.Get().Id.ToString());
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int id = Financial.Get().Id;
			int num = 0;
			if (num == 0)
			{
				num = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserLastCId.GetValueOrDefault() : 0);
			}
			if (!Product.HaveSpecModule())
			{
				return Messages.VersionBuyModule;
			}
			ObjectParameter objectParameter = new ObjectParameter("ResultId", 0);
			_dbII.WSspInsertUpdateProductSpecificationValue(jsonValue, prdId, specificationId, userId, value2, id, value, registerDatePersian, appType, lCID, num, objectParameter);
			if (objectParameter != null && !string.IsNullOrWhiteSpace(objectParameter.Value.ToString()))
			{
				result = objectParameter.Value.ToString();
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
	public List<WSspSelectProductSpecificationValues_Result> GetProductSpecificationValues(int? prdId = 0)
	{
		List<WSspSelectProductSpecificationValues_Result> result = new List<WSspSelectProductSpecificationValues_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<WSspSelectProductSpecificationValues_Result> list = Enumerable.ToList<WSspSelectProductSpecificationValues_Result>((IEnumerable<WSspSelectProductSpecificationValues_Result>)_dbII.WSspSelectProductSpecificationValues(prdId, lCID, result2));
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
	public string GetProductSpecificationValues_Json(int? prdId = 0)
	{
		return JsonConvert.SerializeObject(GetProductSpecificationValues(prdId));
	}

	[HttpPost]
	[LoginAuthorize]
	public List<SelectListItem> GetPrdFirstGroup()
	{
		List<SelectListItem> result = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<WSspSelectProductFirstGroup_Result> list = Enumerable.ToList<WSspSelectProductFirstGroup_Result>((IEnumerable<WSspSelectProductFirstGroup_Result>)_db.WSspSelectProductFirstGroup(lCID, result2));
			if (list != null)
			{
				result = Enumerable.ToList<SelectListItem>(Enumerable.Select<WSspSelectProductFirstGroup_Result, SelectListItem>((IEnumerable<WSspSelectProductFirstGroup_Result>)list, (Func<WSspSelectProductFirstGroup_Result, SelectListItem>)((WSspSelectProductFirstGroup_Result x) => new SelectListItem
				{
					Text = x.FGName,
					Value = x.PrdFirstGroupID.ToString()
				})));
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
	public string GetPrdSecondGroup(int fGID = 0)
	{
		List<SelectListItem> value = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<WSspSelectProductSecondGroup_Result> list = Enumerable.ToList<WSspSelectProductSecondGroup_Result>((IEnumerable<WSspSelectProductSecondGroup_Result>)_db.WSspSelectProductSecondGroup(fGID, lCID, result));
			if (list != null)
			{
				value = Enumerable.ToList<SelectListItem>(Enumerable.Select<WSspSelectProductSecondGroup_Result, SelectListItem>((IEnumerable<WSspSelectProductSecondGroup_Result>)list, (Func<WSspSelectProductSecondGroup_Result, SelectListItem>)((WSspSelectProductSecondGroup_Result x) => new SelectListItem
				{
					Text = x.SGName,
					Value = x.PrdSecondGroupID.ToString()
				})));
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return JsonConvert.SerializeObject(value);
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actPrdDefineSpecificationGroups")]
	public ActionResult Groups()
	{
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmDefineBaseInfoI", ActionName = "actInsert,actEdit")]
	public ActionResult GroupInsertEdit(int id = 0)
	{
		WSspSelectProductSpecificationFieldGroupWithId_Result productSpecificationFieldGroupWithId = GetProductSpecificationFieldGroupWithId(id);
		if (productSpecificationFieldGroupWithId != null)
		{
			List<WSspSelectProductSpecificationFieldGroups_Result> productSpecificationFieldGroups = GetProductSpecificationFieldGroups();
			if (productSpecificationFieldGroupWithId.OrderView.GetValueOrDefault() == 0)
			{
				productSpecificationFieldGroupWithId.OrderView = ((productSpecificationFieldGroups == null || productSpecificationFieldGroups.Count <= 0) ? new int?(10) : (Enumerable.Max<WSspSelectProductSpecificationFieldGroups_Result>((IEnumerable<WSspSelectProductSpecificationFieldGroups_Result>)productSpecificationFieldGroups, (Func<WSspSelectProductSpecificationFieldGroups_Result, int?>)((WSspSelectProductSpecificationFieldGroups_Result x) => x.OrderView)) + 10));
			}
		}
		return View(productSpecificationFieldGroupWithId);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmDefineBaseInfoIDataEntry", ActionName = "actPost")]
	public string GroupInsertEdit(int id = 0, string title = "", string title_Lang = "", bool? inActive = null, int? orderView = null, int? cId = null)
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
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			int userId = UserLogin.CurrentUser.UserId;
			short.Parse(Financial.Get().Id.ToString());
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int id2 = Financial.Get().Id;
			if (cId.GetValueOrDefault() == 0)
			{
				cId = ((UserLogin.CurrentUser == null) ? null : (UserLogin.CurrentUser.UserLastCId ?? null));
			}
			List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrWhiteSpace(title_Lang))
			{
				list = JsonConvert.DeserializeObject<List<CommonMultiLanguageViewModel>>(title_Lang);
			}
			list.Add(new CommonMultiLanguageViewModel
			{
				LanguageId = lCID,
				Value = title
			});
			if (!checkMultiLanguage(title, list))
			{
				text = string.Format(Messages.CheckFieldInLang, Labels.Title) + "<br>";
			}
			if (text == "")
			{
				if (id != 0)
				{
					_dbII.WSspUpdateProductSpecificationFieldGroups(id, title, title_Lang, inActive, orderView, userId, DateTime.Now, DateTime.Now.ToString("yyyyMMdd", new PersianCulture()), id2, value2, appType, lCID, result, cId);
				}
				else
				{
					if (!Product.HaveSpecModule())
					{
						return Messages.VersionBuy;
					}
					ObjectParameter insertedId = new ObjectParameter("InsertedId", 0);
					_dbII.WSspInsertProductSpecificationFieldGroups(title, title_Lang, inActive, orderView, userId, value, registerDatePersian, id2, value2, appType, lCID, result, cId, insertedId);
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
			text = "Error: " + ex.Message;
		}
		return text;
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmDefineBaseInfoI", ActionName = "actDelete")]
	public string DeleteGroup(int id = 0)
	{
		string text = "";
		try
		{
			if (id == 0)
			{
				text += Messages.mnuErrorPleaseSelectARow;
			}
			if (text == "")
			{
				_dbII.WSspDeleteProductSpecificationFieldGroups(id);
			}
		}
		catch (Exception ex)
		{
			text = "Error: " + ex.Message;
		}
		return text;
	}

	[HttpPost]
	[LoginAuthorize]
	public List<WSspSelectProductSpecificationFieldGroups_Result> GetProductSpecificationFieldGroups(int cId = 0)
	{
		List<WSspSelectProductSpecificationFieldGroups_Result> result = new List<WSspSelectProductSpecificationFieldGroups_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (cId == 0)
			{
				cId = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserLastCId.GetValueOrDefault() : 0);
			}
			List<WSspSelectProductSpecificationFieldGroups_Result> list = Enumerable.ToList<WSspSelectProductSpecificationFieldGroups_Result>((IEnumerable<WSspSelectProductSpecificationFieldGroups_Result>)_dbII.WSspSelectProductSpecificationFieldGroups(cId, lCID, result2));
			if (list != null)
			{
				foreach (WSspSelectProductSpecificationFieldGroups_Result item in list)
				{
					item.FirstRegisterDatePersian = item.FirstRegisterDate?.ToString("yyyy/MM/dd HH:mm");
					item.RegisterDatePersian = item.RegisterDate?.ToString("yyyy/MM/dd HH:mm");
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
	[LoginAuthorize]
	public List<SelectListItem> GetProductSpecificationFieldGroups_SelectListItem(int selectedId = 0, int cId = 0)
	{
		return Enumerable.ToList<SelectListItem>(Enumerable.Select<WSspSelectProductSpecificationFieldGroups_Result, SelectListItem>((IEnumerable<WSspSelectProductSpecificationFieldGroups_Result>)GetProductSpecificationFieldGroups(cId), (Func<WSspSelectProductSpecificationFieldGroups_Result, SelectListItem>)((WSspSelectProductSpecificationFieldGroups_Result x) => new SelectListItem
		{
			Text = x.FieldGroupTitle,
			Value = x.SpecificationFieldGroupID.ToString(),
			Selected = (x.SpecificationFieldGroupID == selectedId)
		})));
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetProductSpecificationFieldGroups_Json(int cId = 0)
	{
		return JsonConvert.SerializeObject(GetProductSpecificationFieldGroups(cId));
	}

	[HttpPost]
	[LoginAuthorize]
	public WSspSelectProductSpecificationFieldGroupWithId_Result GetProductSpecificationFieldGroupWithId(int id = 0)
	{
		WSspSelectProductSpecificationFieldGroupWithId_Result result = new WSspSelectProductSpecificationFieldGroupWithId_Result();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			WSspSelectProductSpecificationFieldGroupWithId_Result wSspSelectProductSpecificationFieldGroupWithId_Result = Enumerable.FirstOrDefault<WSspSelectProductSpecificationFieldGroupWithId_Result>((IEnumerable<WSspSelectProductSpecificationFieldGroupWithId_Result>)_dbII.WSspSelectProductSpecificationFieldGroupWithId(id, lCID, result2));
			if (wSspSelectProductSpecificationFieldGroupWithId_Result != null)
			{
				wSspSelectProductSpecificationFieldGroupWithId_Result.FirstRegisterDatePersian = wSspSelectProductSpecificationFieldGroupWithId_Result.FirstRegisterDate?.ToString("yyyy/MM/dd HH:mm");
				wSspSelectProductSpecificationFieldGroupWithId_Result.RegisterDatePersian = wSspSelectProductSpecificationFieldGroupWithId_Result.RegisterDate?.ToString("yyyy/MM/dd HH:mm");
				result = wSspSelectProductSpecificationFieldGroupWithId_Result;
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actPrdDefineSpecificationFields")]
	public ActionResult Fields()
	{
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmDefineBaseInfoI", ActionName = "actInsert,actEdit")]
	public ActionResult FieldInsertEdit(int id = 0)
	{
		WSspSelectProductSpecificationFieldWithId_Result productSpecificationFieldWithId = GetProductSpecificationFieldWithId(id);
		if (productSpecificationFieldWithId != null)
		{
			List<WSspSelectProductSpecificationFields_Result> productSpecificationFields = GetProductSpecificationFields();
			if (productSpecificationFieldWithId.OrderView.GetValueOrDefault() == 0)
			{
				productSpecificationFieldWithId.OrderView = ((productSpecificationFields == null || productSpecificationFields.Count <= 0) ? new int?(10) : (Enumerable.Max<WSspSelectProductSpecificationFields_Result>((IEnumerable<WSspSelectProductSpecificationFields_Result>)productSpecificationFields, (Func<WSspSelectProductSpecificationFields_Result, int?>)((WSspSelectProductSpecificationFields_Result x) => x.OrderView)) + 10));
			}
		}
		base.ViewBag.GroupsList = GetProductSpecificationFieldGroups_SelectListItem(productSpecificationFieldWithId.specGroupId.GetValueOrDefault());
		base.ViewBag.TypesList = GetProductSpecificationFieldType_SelectListItem(productSpecificationFieldWithId.specGroupId.GetValueOrDefault());
		return View(productSpecificationFieldWithId);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmDefineBaseInfoIDataEntry", ActionName = "actPost")]
	public string FieldInsertEdit(int id = 0, int groupId = 0, int typeId = 0, string title = "", string title_Lang = null, string sHPTitle = null, string sHPTitle_Lang = null, long? minValue = null, long? maxValue = null, long? strLength = null, string multiItemValues = null, string multiItemValues_Lang = null, bool? inActive = null, int? orderView = null, int? cId = null, bool? specSHPInActive = null, bool? specSHPFilterInActive = null)
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
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			int userId = UserLogin.CurrentUser.UserId;
			short.Parse(Financial.Get().Id.ToString());
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int id2 = Financial.Get().Id;
			if (cId.GetValueOrDefault() == 0)
			{
				cId = ((UserLogin.CurrentUser == null) ? null : (UserLogin.CurrentUser.UserLastCId ?? null));
			}
			List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrWhiteSpace(title_Lang))
			{
				list = JsonConvert.DeserializeObject<List<CommonMultiLanguageViewModel>>(title_Lang);
			}
			list.Add(new CommonMultiLanguageViewModel
			{
				LanguageId = lCID,
				Value = title
			});
			if (!checkMultiLanguage(title, list))
			{
				text = string.Format(Messages.CheckFieldInLang, Labels.Title) + "<br>";
			}
			List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrWhiteSpace(sHPTitle_Lang))
			{
				list2 = JsonConvert.DeserializeObject<List<CommonMultiLanguageViewModel>>(sHPTitle_Lang);
			}
			list2.Add(new CommonMultiLanguageViewModel
			{
				LanguageId = lCID,
				Value = sHPTitle
			});
			if (!checkMultiLanguage(sHPTitle, list2))
			{
				text = string.Format(Messages.CheckFieldInLang, Labels.Title) + "<br>";
			}
			List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrWhiteSpace(multiItemValues_Lang))
			{
				list3 = JsonConvert.DeserializeObject<List<CommonMultiLanguageViewModel>>(multiItemValues_Lang);
			}
			list3.Add(new CommonMultiLanguageViewModel
			{
				LanguageId = lCID,
				Value = multiItemValues
			});
			if (text == "")
			{
				if (id != 0)
				{
					_dbII.WSspUpdateProductSpecificationField(id, groupId, typeId, title, title_Lang, sHPTitle, sHPTitle_Lang, minValue, maxValue, strLength, multiItemValues, multiItemValues_Lang, inActive, orderView, userId, value, registerDatePersian, id2, value2, appType, lCID, result, cId, specSHPInActive, specSHPFilterInActive);
				}
				else
				{
					if (!Product.HaveSpecModule())
					{
						return Messages.VersionBuy;
					}
					ObjectParameter insertedId = new ObjectParameter("InsertedId", 0);
					_dbII.WSspInsertProductSpecificationField(groupId, typeId, title, title_Lang, sHPTitle, sHPTitle_Lang, minValue, maxValue, strLength, multiItemValues, multiItemValues_Lang, inActive, orderView, userId, value, registerDatePersian, id2, value2, appType, lCID, result, cId, insertedId, specSHPInActive, specSHPFilterInActive);
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return text;
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmDefineBaseInfoI", ActionName = "actDelete")]
	public string DeleteField(int id = 0)
	{
		string text = "";
		try
		{
			if (id == 0)
			{
				text += Messages.mnuErrorPleaseSelectARow;
			}
			if (text == "")
			{
				_dbII.WSspDeleteProductSpecificationField(id);
			}
		}
		catch (Exception ex)
		{
			text = "Error: " + ex.Message;
		}
		return text;
	}

	[HttpPost]
	[LoginAuthorize]
	public WSspSelectProductSpecificationFieldWithId_Result GetProductSpecificationFieldWithId(int fieldId = 0)
	{
		WSspSelectProductSpecificationFieldWithId_Result result = new WSspSelectProductSpecificationFieldWithId_Result();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			WSspSelectProductSpecificationFieldWithId_Result wSspSelectProductSpecificationFieldWithId_Result = Enumerable.FirstOrDefault<WSspSelectProductSpecificationFieldWithId_Result>((IEnumerable<WSspSelectProductSpecificationFieldWithId_Result>)_dbII.WSspSelectProductSpecificationFieldWithId(fieldId, lCID, result2));
			if (wSspSelectProductSpecificationFieldWithId_Result != null)
			{
				wSspSelectProductSpecificationFieldWithId_Result.FirstRegisterDatePersian = wSspSelectProductSpecificationFieldWithId_Result.FirstRegisterDate?.ToString("yyyy/MM/dd HH:mm");
				wSspSelectProductSpecificationFieldWithId_Result.RegisterDatePersian = wSspSelectProductSpecificationFieldWithId_Result.RegisterDate?.ToString("yyyy/MM/dd HH:mm");
				result = wSspSelectProductSpecificationFieldWithId_Result;
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	public ActionResult SpecFields_Read([DataSourceRequest] DataSourceRequest request, int? cId = null)
	{
		JsonResult jsonResult = Json(((IEnumerable)GetProductSpecificationFields(cId)).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[HttpPost]
	[LoginAuthorize]
	public List<WSspSelectProductSpecificationFields_Result> GetProductSpecificationFields(int? cId = null)
	{
		List<WSspSelectProductSpecificationFields_Result> result = new List<WSspSelectProductSpecificationFields_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (cId == 0)
			{
				cId = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserLastCId.GetValueOrDefault() : 0);
			}
			List<WSspSelectProductSpecificationFields_Result> list = Enumerable.ToList<WSspSelectProductSpecificationFields_Result>((IEnumerable<WSspSelectProductSpecificationFields_Result>)_dbII.WSspSelectProductSpecificationFields(cId, lCID, result2));
			if (list != null)
			{
				foreach (WSspSelectProductSpecificationFields_Result item in list)
				{
					item.FirstRegisterDatePersian = item.FirstRegisterDate?.ToString("yyyy/MM/dd HH:mm");
					item.RegisterDatePersian = item.RegisterDate?.ToString("yyyy/MM/dd HH:mm");
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
	[LoginAuthorize]
	public string GetProductSpecificationFields_Json(int? cId = null)
	{
		return JsonConvert.SerializeObject(GetProductSpecificationFields(cId));
	}

	[HttpPost]
	[LoginAuthorize]
	public List<SelectListItem> GetProductSpecificationFields_SelectListItem(int? cId = null, int selectedId = 0)
	{
		return Enumerable.ToList<SelectListItem>(Enumerable.Select<WSspSelectProductSpecificationFields_Result, SelectListItem>((IEnumerable<WSspSelectProductSpecificationFields_Result>)GetProductSpecificationFields(cId), (Func<WSspSelectProductSpecificationFields_Result, SelectListItem>)((WSspSelectProductSpecificationFields_Result x) => new SelectListItem
		{
			Text = x.specTitle,
			Value = x.SpecificationFieldID.ToString(),
			Selected = (x.SpecificationFieldID == selectedId)
		})));
	}

	[HttpPost]
	[LoginAuthorize]
	public List<WSspSelectProductSpecificationFieldsByGroupId_Result> GetProductSpecificationFieldsByGroupId(int? groupId = null)
	{
		List<WSspSelectProductSpecificationFieldsByGroupId_Result> result = new List<WSspSelectProductSpecificationFieldsByGroupId_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int num = 0;
			if (num == 0)
			{
				num = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserLastCId.GetValueOrDefault() : 0);
			}
			List<WSspSelectProductSpecificationFieldsByGroupId_Result> list = Enumerable.ToList<WSspSelectProductSpecificationFieldsByGroupId_Result>((IEnumerable<WSspSelectProductSpecificationFieldsByGroupId_Result>)_dbII.WSspSelectProductSpecificationFieldsByGroupId(num, groupId, lCID, result2));
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
	public string GetProductSpecificationFieldsByGroupId_Json(int? groupId = null)
	{
		return JsonConvert.SerializeObject(GetProductSpecificationFieldsByGroupId(groupId));
	}

	[HttpPost]
	[LoginAuthorize]
	public List<WSspSelectProductSpecificationFieldTypes_Result> GetProductSpecificationFieldTypes()
	{
		List<WSspSelectProductSpecificationFieldTypes_Result> result = new List<WSspSelectProductSpecificationFieldTypes_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<WSspSelectProductSpecificationFieldTypes_Result> list = Enumerable.ToList<WSspSelectProductSpecificationFieldTypes_Result>((IEnumerable<WSspSelectProductSpecificationFieldTypes_Result>)_dbII.WSspSelectProductSpecificationFieldTypes(lCID, result2));
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
	public List<SelectListItem> GetProductSpecificationFieldType_SelectListItem(int selectedId = 0)
	{
		return Enumerable.ToList<SelectListItem>(Enumerable.Select<WSspSelectProductSpecificationFieldTypes_Result, SelectListItem>((IEnumerable<WSspSelectProductSpecificationFieldTypes_Result>)GetProductSpecificationFieldTypes(), (Func<WSspSelectProductSpecificationFieldTypes_Result, SelectListItem>)((WSspSelectProductSpecificationFieldTypes_Result x) => new SelectListItem
		{
			Text = x.TypeName,
			Value = x.SpecificationFieldTypeID.ToString(),
			Selected = (x.SpecificationFieldTypeID == selectedId)
		})));
	}

	[HttpPost]
	[LoginAuthorize]
	public string InsertProductSpecificationMulti(string fgId = "", string sgId = "", string fieldsJs = "")
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
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			int userId = UserLogin.CurrentUser.UserId;
			short value2 = short.Parse(Financial.Get().Id.ToString());
			short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int id = Financial.Get().Id;
			int? cId = ((UserLogin.CurrentUser == null) ? null : (UserLogin.CurrentUser.UserLastCId ?? null));
			return JsonConvert.SerializeObject(Enumerable.FirstOrDefault<WSspInsertProductSpecificationMulti_Result>((IEnumerable<WSspInsertProductSpecificationMulti_Result>)_dbII.WSspInsertProductSpecificationMulti(fgId, sgId, null, fieldsJs, false, id, userId, value2, value3, value, registerDatePersian, appType, lCID, result, cId)));
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
			return "er";
		}
	}

	[HttpPost]
	[LoginAuthorize]
	public string DeleteProductSpecificationInMode(int mode = 0, int? prdId = null)
	{
		string result = "";
		try
		{
			ObjectParameter objectParameter = new ObjectParameter("Result", 0);
			_dbII.WSspDeleteProductSpecificationInMode(mode, prdId, objectParameter);
			if (objectParameter == null || !(objectParameter.Value.ToString() == "1"))
			{
				result = Messages.msgErrorOperationFailed;
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	public bool checkMultiLanguage(string defaultValue, List<CommonMultiLanguageViewModel> list)
	{
		bool result = true;
		List<CRMspSelectUserLanguages_Result> list2 = CRMIdeal.Cache.User.Language.Get();
		bool isCurrentUserAllowCopyOtherLanguage = UserLogin.IsCurrentUserAllowCopyOtherLanguage;
		foreach (Languages itemLang in CRMIdeal.Cache.Setting.Language.Get())
		{
			CommonMultiLanguageViewModel commonMultiLanguageViewModel = Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == itemLang.LanguageID));
			if (commonMultiLanguageViewModel == null)
			{
				if (Enumerable.Any<CRMspSelectUserLanguages_Result>((IEnumerable<CRMspSelectUserLanguages_Result>)list2, (Func<CRMspSelectUserLanguages_Result, bool>)((CRMspSelectUserLanguages_Result c) => c.LanguageID == itemLang.LanguageID)))
				{
					if (isCurrentUserAllowCopyOtherLanguage)
					{
						list.Add(new CommonMultiLanguageViewModel
						{
							LanguageId = itemLang.LanguageID,
							Value = defaultValue
						});
					}
					else
					{
						result = false;
					}
				}
				else
				{
					list.Add(new CommonMultiLanguageViewModel
					{
						LanguageId = itemLang.LanguageID,
						Value = defaultValue
					});
				}
			}
			else
			{
				if (!string.IsNullOrEmpty(commonMultiLanguageViewModel.Value))
				{
					continue;
				}
				if (Enumerable.Any<CRMspSelectUserLanguages_Result>((IEnumerable<CRMspSelectUserLanguages_Result>)list2, (Func<CRMspSelectUserLanguages_Result, bool>)((CRMspSelectUserLanguages_Result c) => c.LanguageID == itemLang.LanguageID)))
				{
					if (isCurrentUserAllowCopyOtherLanguage)
					{
						commonMultiLanguageViewModel.Value = defaultValue;
					}
					else
					{
						result = false;
					}
				}
				else
				{
					commonMultiLanguageViewModel.Value = defaultValue;
				}
			}
		}
		return result;
	}

	public ActionResult ChooseForFilter(string hdnFieldName = "", string rfrshBtnName = "")
	{
		base.ViewBag.HiddenFieldName = hdnFieldName;
		base.ViewBag.RefreshButtonName = rfrshBtnName;
		return View();
	}

	[HttpPost]
	public string GetAllSpecifications()
	{
		List<WSspSelectProductSpecificationFields_Result> list = new List<WSspSelectProductSpecificationFields_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int num = 0;
			if (num == 0)
			{
				num = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserLastCId.GetValueOrDefault() : 0);
			}
			List<WSspSelectProductSpecificationFields_Result> list2 = Enumerable.ToList<WSspSelectProductSpecificationFields_Result>((IEnumerable<WSspSelectProductSpecificationFields_Result>)_dbII.WSspSelectProductSpecificationFields(num, lCID, result));
			if (list2 != null)
			{
				list.AddRange(list2);
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return JsonConvert.SerializeObject(list);
	}

	protected override void Dispose(bool disposing)
	{
		_dbII.Dispose();
		base.Dispose(disposing);
	}
}
