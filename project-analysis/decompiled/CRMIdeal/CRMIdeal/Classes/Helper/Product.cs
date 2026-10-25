using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using CRM.Models;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes.Common;

namespace CRMIdeal.Classes.Helper;

public class Product
{
	public static List<CRMspRpt_SysDBObjects_UserReportFilter_Result> FillUserReportFieldsByPrdSpecifications(List<CRMspRpt_SysDBObjects_UserReportFilter_Result> model = null, bool? shouldAddToList = false)
	{
		CRMSpIIEntities cRMSpIIEntities = new CRMSpIIEntities();
		try
		{
			if (model == null)
			{
				model = new List<CRMspRpt_SysDBObjects_UserReportFilter_Result>();
			}
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
			List<WSspSelectProductSpecificationsUsedInPrds_Result> list = Enumerable.ToList<WSspSelectProductSpecificationsUsedInPrds_Result>((IEnumerable<WSspSelectProductSpecificationsUsedInPrds_Result>)cRMSpIIEntities.WSspSelectProductSpecificationsUsedInPrds(result2.ToString(), "", "", lCID, result));
			if (list != null)
			{
				if (shouldAddToList.GetValueOrDefault())
				{
					model.AddRange(Enumerable.Select<WSspSelectProductSpecificationsUsedInPrds_Result, CRMspRpt_SysDBObjects_UserReportFilter_Result>((IEnumerable<WSspSelectProductSpecificationsUsedInPrds_Result>)list, (Func<WSspSelectProductSpecificationsUsedInPrds_Result, CRMspRpt_SysDBObjects_UserReportFilter_Result>)((WSspSelectProductSpecificationsUsedInPrds_Result x) => new CRMspRpt_SysDBObjects_UserReportFilter_Result
					{
						FieldName = "spec-" + x.SpecificationFieldID
					})));
				}
				List<CRMspSelectSysDBObjectTypes_Result> list2 = Enumerable.ToList<CRMspSelectSysDBObjectTypes_Result>((IEnumerable<CRMspSelectSysDBObjectTypes_Result>)cRMSpIIEntities.CRMspSelectSysDBObjectTypes(lCID, result));
				foreach (CRMspRpt_SysDBObjects_UserReportFilter_Result r in model)
				{
					WSspSelectProductSpecificationsUsedInPrds_Result f = Enumerable.FirstOrDefault<WSspSelectProductSpecificationsUsedInPrds_Result>((IEnumerable<WSspSelectProductSpecificationsUsedInPrds_Result>)list, (Func<WSspSelectProductSpecificationsUsedInPrds_Result, bool>)((WSspSelectProductSpecificationsUsedInPrds_Result x) => "spec-" + x.SpecificationFieldID == r.FieldName));
					if (f != null)
					{
						r.DBObjectId = int.Parse("9999" + f.SpecificationFieldID);
						r.DBObjectName = "WSProductSpecifications";
						r.FieldName = "spec-" + f.SpecificationFieldID;
						r.FieldTitle = (string.IsNullOrWhiteSpace(f.specSHPTitle) ? f.specTitle : f.specSHPTitle);
						r.FieldElementTypeWeb = f.specTypeWeb;
						r.Items = f.specMultiItemValues;
						CRMspSelectSysDBObjectTypes_Result cRMspSelectSysDBObjectTypes_Result = Enumerable.FirstOrDefault<CRMspSelectSysDBObjectTypes_Result>((IEnumerable<CRMspSelectSysDBObjectTypes_Result>)list2, (Func<CRMspSelectSysDBObjectTypes_Result, bool>)((CRMspSelectSysDBObjectTypes_Result x) => x.DataTypeName == f.specTypeWeb));
						if (cRMspSelectSysDBObjectTypes_Result != null)
						{
							r.FieldDataTypeId = cRMspSelectSysDBObjectTypes_Result.FieldDataTypeID;
						}
						if (f.specTypeWeb == "numeric")
						{
							r.FieldFromTo = true;
							r.FieldElementTypeWeb = "number-float";
						}
						else if (f.specTypeWeb == "select")
						{
							r.FieldMulti = true;
						}
					}
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		finally
		{
			cRMSpIIEntities.Dispose();
		}
		return model;
	}

	public static List<CRMspRpt_SysDBObjects_UserReportFilterResultColumns_Result> FillUserReportFilterResultColumnsByPrdSpecifications(List<CRMspRpt_SysDBObjects_UserReportFilterResultColumns_Result> model = null, bool? shouldAddToList = false)
	{
		CRMSpIIEntities cRMSpIIEntities = new CRMSpIIEntities();
		try
		{
			if (model == null)
			{
				model = new List<CRMspRpt_SysDBObjects_UserReportFilterResultColumns_Result>();
			}
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
			List<WSspSelectProductSpecificationsUsedInPrds_Result> list = Enumerable.ToList<WSspSelectProductSpecificationsUsedInPrds_Result>((IEnumerable<WSspSelectProductSpecificationsUsedInPrds_Result>)cRMSpIIEntities.WSspSelectProductSpecificationsUsedInPrds(result2.ToString(), "", "", lCID, result));
			if (list != null)
			{
				if (shouldAddToList.GetValueOrDefault())
				{
					model.AddRange(Enumerable.Select<WSspSelectProductSpecificationsUsedInPrds_Result, CRMspRpt_SysDBObjects_UserReportFilterResultColumns_Result>((IEnumerable<WSspSelectProductSpecificationsUsedInPrds_Result>)list, (Func<WSspSelectProductSpecificationsUsedInPrds_Result, CRMspRpt_SysDBObjects_UserReportFilterResultColumns_Result>)((WSspSelectProductSpecificationsUsedInPrds_Result x) => new CRMspRpt_SysDBObjects_UserReportFilterResultColumns_Result
					{
						FieldName = "spec-" + x.SpecificationFieldID
					})));
				}
				List<CRMspSelectSysDBObjectTypes_Result> list2 = Enumerable.ToList<CRMspSelectSysDBObjectTypes_Result>((IEnumerable<CRMspSelectSysDBObjectTypes_Result>)cRMSpIIEntities.CRMspSelectSysDBObjectTypes(lCID, result));
				foreach (CRMspRpt_SysDBObjects_UserReportFilterResultColumns_Result r in model)
				{
					WSspSelectProductSpecificationsUsedInPrds_Result f = Enumerable.FirstOrDefault<WSspSelectProductSpecificationsUsedInPrds_Result>((IEnumerable<WSspSelectProductSpecificationsUsedInPrds_Result>)list, (Func<WSspSelectProductSpecificationsUsedInPrds_Result, bool>)((WSspSelectProductSpecificationsUsedInPrds_Result x) => "spec-" + x.SpecificationFieldID == r.FieldName));
					if (f != null)
					{
						r.DBObjectId = int.Parse("9999" + f.SpecificationFieldID);
						r.DBObjectName = "WSProductSpecifications";
						r.FieldName = "spec-" + f.SpecificationFieldID;
						r.FieldTitle = (string.IsNullOrWhiteSpace(f.specSHPTitle) ? f.specTitle : f.specSHPTitle);
						r.FieldElementTypeWeb = f.specTypeWeb;
						CRMspSelectSysDBObjectTypes_Result cRMspSelectSysDBObjectTypes_Result = Enumerable.FirstOrDefault<CRMspSelectSysDBObjectTypes_Result>((IEnumerable<CRMspSelectSysDBObjectTypes_Result>)list2, (Func<CRMspSelectSysDBObjectTypes_Result, bool>)((CRMspSelectSysDBObjectTypes_Result x) => x.DataTypeName == f.specTypeWeb));
						if (cRMspSelectSysDBObjectTypes_Result != null)
						{
							r.FieldDataTypeId = cRMspSelectSysDBObjectTypes_Result.FieldDataTypeID;
						}
						if (f.specTypeWeb == "numeric")
						{
							r.FieldFromTo = true;
							r.FieldElementTypeWeb = "number-float";
						}
						else if (f.specTypeWeb == "select")
						{
							r.FieldMulti = true;
						}
					}
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		finally
		{
			cRMSpIIEntities.Dispose();
		}
		return model;
	}

	public static bool HaveSpecModule()
	{
		return VersionBuyer.PrdSpec;
	}

	public static List<WSspSelectProductSpecificationValues_Result> SelectProductSpecificationValues(int prdId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		CRMSpIIEntities cRMSpIIEntities = new CRMSpIIEntities();
		List<WSspSelectProductSpecificationValues_Result> result2 = new List<WSspSelectProductSpecificationValues_Result>();
		try
		{
			List<WSspSelectProductSpecificationValues_Result> list = Enumerable.ToList<WSspSelectProductSpecificationValues_Result>((IEnumerable<WSspSelectProductSpecificationValues_Result>)cRMSpIIEntities.WSspSelectProductSpecificationValues(prdId, lCID, result));
			if (list != null)
			{
				result2 = list;
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		finally
		{
			cRMSpIIEntities?.Dispose();
		}
		return result2;
	}

	public static List<nTreeItemViewModel> GetPrdGroupsTree()
	{
		List<nTreeItemViewModel> list = new List<nTreeItemViewModel>();
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			List<WSspSelectProductSecondGroup_Result> sg = SelectSecondGroups(0, getAll: true);
			List<WSspSelectProductFirstGroup_Result> list2 = SelectFirstGroups();
			if (list2 != null && sg != null)
			{
				list.AddRange(Enumerable.Select<WSspSelectProductFirstGroup_Result, nTreeItemViewModel>((IEnumerable<WSspSelectProductFirstGroup_Result>)list2, (Func<WSspSelectProductFirstGroup_Result, nTreeItemViewModel>)((WSspSelectProductFirstGroup_Result x) => new nTreeItemViewModel
				{
					ParentId = "",
					KeyId = "fg-" + x.PrdFirstGroupID,
					KeyName = x.FGName,
					ChildsCnt = Enumerable.Count<WSspSelectProductSecondGroup_Result>(Enumerable.Where<WSspSelectProductSecondGroup_Result>((IEnumerable<WSspSelectProductSecondGroup_Result>)sg, (Func<WSspSelectProductSecondGroup_Result, bool>)((WSspSelectProductSecondGroup_Result s) => s.FirstGroupId == x.PrdFirstGroupID)))
				})));
				list.AddRange(Enumerable.Select<WSspSelectProductSecondGroup_Result, nTreeItemViewModel>((IEnumerable<WSspSelectProductSecondGroup_Result>)sg, (Func<WSspSelectProductSecondGroup_Result, nTreeItemViewModel>)((WSspSelectProductSecondGroup_Result x) => new nTreeItemViewModel
				{
					ParentId = "fg-" + x.FirstGroupId,
					KeyId = "sg-" + x.PrdSecondGroupID,
					KeyName = x.SGName,
					ChildsCnt = 0
				})));
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return list;
	}

	public static List<WSspSelectProductFirstGroup_Result> SelectFirstGroups()
	{
		List<WSspSelectProductFirstGroup_Result> result = new List<WSspSelectProductFirstGroup_Result>();
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<WSspSelectProductFirstGroup_Result> list = Enumerable.ToList<WSspSelectProductFirstGroup_Result>((IEnumerable<WSspSelectProductFirstGroup_Result>)cRMSpEntities.WSspSelectProductFirstGroup(lCID, result2));
			if (list != null)
			{
				result = list;
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return result;
	}

	public static string GetFirstGroupNames(string fgIds = "", string sep = ",")
	{
		string result = "";
		if (!string.IsNullOrWhiteSpace(fgIds))
		{
			List<WSspSelectProductFirstGroup_Result> list = SelectFirstGroups();
			string[] ids = fgIds.Split(new string[1] { sep }, StringSplitOptions.None);
			result = string.Join(sep, Enumerable.Select<WSspSelectProductFirstGroup_Result, string>(Enumerable.Where<WSspSelectProductFirstGroup_Result>((IEnumerable<WSspSelectProductFirstGroup_Result>)list, (Func<WSspSelectProductFirstGroup_Result, bool>)((WSspSelectProductFirstGroup_Result x) => Enumerable.Contains<int>(Enumerable.Select<string, int>((IEnumerable<string>)ids, (Func<string, int>)((string s) => int.Parse(s))), x.PrdFirstGroupID))), (Func<WSspSelectProductFirstGroup_Result, string>)((WSspSelectProductFirstGroup_Result x) => x.FGName)));
		}
		return result;
	}

	public static List<WSspSelectProductSecondGroup_Result> SelectSecondGroups(int fgId = 0, bool getAll = false)
	{
		List<WSspSelectProductSecondGroup_Result> result = new List<WSspSelectProductSecondGroup_Result>();
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (fgId != 0 || getAll)
			{
				List<WSspSelectProductSecondGroup_Result> list = Enumerable.ToList<WSspSelectProductSecondGroup_Result>((IEnumerable<WSspSelectProductSecondGroup_Result>)cRMSpEntities.WSspSelectProductSecondGroup(fgId, lCID, result2));
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
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return result;
	}

	public static string GetSecondGroupNames(string sgIds = "", string sep = ",")
	{
		string result = "";
		if (!string.IsNullOrWhiteSpace(sgIds))
		{
			List<WSspSelectProductSecondGroup_Result> list = SelectSecondGroups(0, getAll: true);
			string[] ids = sgIds.Split(new string[1] { sep }, StringSplitOptions.None);
			result = string.Join(sep, Enumerable.Select<WSspSelectProductSecondGroup_Result, string>(Enumerable.Where<WSspSelectProductSecondGroup_Result>((IEnumerable<WSspSelectProductSecondGroup_Result>)list, (Func<WSspSelectProductSecondGroup_Result, bool>)((WSspSelectProductSecondGroup_Result x) => Enumerable.Contains<int>(Enumerable.Select<string, int>((IEnumerable<string>)ids, (Func<string, int>)((string s) => int.Parse(s))), x.PrdSecondGroupID))), (Func<WSspSelectProductSecondGroup_Result, string>)((WSspSelectProductSecondGroup_Result x) => x.SGName)));
		}
		return result;
	}

	public static WSspSelectProductsWithId_Result SelectProductsWithId(int prdId, int defLangId = 0, int currLangId = 0)
	{
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		WSspSelectProductsWithId_Result wSspSelectProductsWithId_Result = new WSspSelectProductsWithId_Result();
		try
		{
			if (defLangId == 0)
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out defLangId);
				if (defLangId <= 0)
				{
					defLangId = 1065;
				}
			}
			if (currLangId == 0)
			{
				currLangId = Thread.CurrentThread.CurrentCulture.LCID;
			}
			wSspSelectProductsWithId_Result = Enumerable.FirstOrDefault<WSspSelectProductsWithId_Result>((IEnumerable<WSspSelectProductsWithId_Result>)cRMSpEntities.WSspSelectProductsWithId(prdId, currLangId, defLangId));
			if (wSspSelectProductsWithId_Result == null)
			{
				wSspSelectProductsWithId_Result = new WSspSelectProductsWithId_Result();
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		finally
		{
			cRMSpEntities.Dispose();
		}
		return wSspSelectProductsWithId_Result;
	}

	public static string GetProductNameAndCode(int prdId, string prdFormat = "", int defLangId = 0, int currLangId = 0)
	{
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		string text = "";
		try
		{
			if (defLangId == 0)
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out defLangId);
				if (defLangId <= 0)
				{
					defLangId = 1065;
				}
			}
			if (currLangId == 0)
			{
				currLangId = Thread.CurrentThread.CurrentCulture.LCID;
			}
			if (string.IsNullOrWhiteSpace(prdFormat))
			{
				prdFormat = "{0} ({1})";
			}
			WSspSelectProductsWithId_Result wSspSelectProductsWithId_Result = SelectProductsWithId(prdId, defLangId, currLangId);
			if (wSspSelectProductsWithId_Result != null)
			{
				string arg = wSspSelectProductsWithId_Result.PrdName ?? "";
				string arg2 = wSspSelectProductsWithId_Result.PrdCode ?? "";
				text = string.Format(prdFormat, arg, arg2);
				if (!string.IsNullOrWhiteSpace(text))
				{
					text = text.Replace("()", "").Replace("( )", "");
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		finally
		{
			cRMSpEntities.Dispose();
		}
		return text;
	}
}
