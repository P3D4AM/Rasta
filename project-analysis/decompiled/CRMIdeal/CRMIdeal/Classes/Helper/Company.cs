using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.Objects;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CRM.General.Calendar;
using CRM.General.Security;
using CRM.General.Utilities;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Areas.OtherSystems.Controllers;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes.Common;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Newtonsoft.Json;
using dotless.Core.Utils;

namespace CRMIdeal.Classes.Helper;

public class Company
{
	private static object _lock = new object();

	public static CRMspCheckDuplicateCompanyViewModel CheckDuplicateCompany(int type, int cmpId, string val, int titleId, int cityId, int? userId)
	{
		CRMspCheckDuplicateCompanyViewModel result = null;
		string lblLackOfShow = Labels.lblLackOfShow;
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
		lock (_lock)
		{
			CRMSpEntities cRMSpEntities = new CRMSpEntities();
			try
			{
				List<CRMspCheckDuplicateCompany_Result> list = Enumerable.ToList<CRMspCheckDuplicateCompany_Result>((IEnumerable<CRMspCheckDuplicateCompany_Result>)cRMSpEntities.CRMspCheckDuplicateCompany(type, cmpId, val, titleId, cityId, userId, lblLackOfShow, lCID, result2, result3));
				if (list.Count > 0)
				{
					result = new CRMspCheckDuplicateCompanyViewModel
					{
						CompanyID = list[0].CompanyID,
						cmpId = list[0].cmpId,
						cmpName = list[0].cmpName,
						Title = list[0].Title,
						CompanyWithTitle = list[0].CompanyWithTitle,
						cmpTel = list[0].cmpTel,
						cmpTelII = list[0].cmpTelII,
						cmpFax = list[0].cmpFax,
						Country = list[0].Country,
						Provice = list[0].Provice,
						City = list[0].City,
						cmpAddress = list[0].cmpAddress,
						prsName = list[0].prsName,
						prsTel = list[0].prsTel,
						prsTelII = list[0].prsTelII,
						prsFax = list[0].prsFax,
						prsMobile = list[0].prsMobile,
						prsEmail = list[0].prsEmail,
						prsEmailII = list[0].prsEmailII,
						cmpNumber = list[0].cmpNumber
					};
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
			}
			finally
			{
				cRMSpEntities.Dispose();
			}
		}
		return result;
	}

	public static int CreateCompanyNumber()
	{
		int result = 0;
		lock (_lock)
		{
			CRMSpEntities cRMSpEntities = new CRMSpEntities();
			try
			{
				int num = Enumerable.FirstOrDefault<int>(cRMSpEntities.Database.SqlQuery<int>("Select dbo.CrmfnReturnCompanyNumber()", Array.Empty<object>()));
				result = ((num > 0) ? num : 0);
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
			}
			finally
			{
				cRMSpEntities.Dispose();
			}
		}
		return result;
	}

	public static string CheckDuplicateCompanyNumber(int cmpId, int? cmpNum)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		string result2 = "";
		try
		{
			string sql = $"Select * from CRMfnCheckDuplicateCompanyNumber_Lang({cmpNum}, {cmpId}, {lCID}, {result})";
			result2 = Enumerable.Aggregate<CheckDuplicateCompanyNumberViewModel, string>((IEnumerable<CheckDuplicateCompanyNumberViewModel>)Enumerable.ToList<CheckDuplicateCompanyNumberViewModel>(cRMSpEntities.Database.SqlQuery<CheckDuplicateCompanyNumberViewModel>(sql, Array.Empty<object>())), "", (Func<string, CheckDuplicateCompanyNumberViewModel, string>)((string current, CheckDuplicateCompanyNumberViewModel item) => current + item.CompanyName + " "));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result2 = "-1";
		}
		finally
		{
			cRMSpEntities.Dispose();
		}
		return result2;
	}

	public static string GetCompanyName(int cmpId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		string result2 = "";
		try
		{
			CRMspSelectCompanyById_Result companyById = GetCompanyById(cmpId);
			if (companyById != null)
			{
				result2 = companyById.cmpName;
			}
			cRMSpEntities.Dispose();
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			cRMSpEntities.Dispose();
		}
		return result2;
	}

	public static string GetCompanyName(int cmpId, int defLangID, int currLangID)
	{
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		string result = "";
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			CRMspSelectCompanyById_Result cRMspSelectCompanyById_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyById_Result>((IEnumerable<CRMspSelectCompanyById_Result>)cRMSpEntities.CRMspSelectCompanyById(cmpId, currLangID, defLangID, result2));
			if (cRMspSelectCompanyById_Result != null)
			{
				result = cRMspSelectCompanyById_Result.CompanyName ?? "";
			}
			cRMSpEntities.Dispose();
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			cRMSpEntities.Dispose();
		}
		return result;
	}

	public static string GetCompanyNameWithTitle(int cmpId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		string result2 = "";
		try
		{
			CRMspSelectCompanyById_Result companyById = GetCompanyById(cmpId);
			if (companyById != null)
			{
				result2 = companyById.CompanyName ?? "";
			}
			cRMSpEntities.Dispose();
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			cRMSpEntities.Dispose();
		}
		return result2;
	}

	public static string GetCompanyAppType(int cmpId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		string result2 = "";
		try
		{
			CRMspSelectCompanyById_Result companyById = GetCompanyById(cmpId);
			if (companyById != null)
			{
				result2 = Configuration.GetAppType(companyById.AppType);
			}
			cRMSpEntities.Dispose();
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			cRMSpEntities.Dispose();
		}
		return result2;
	}

	public static string GetCmpPersonName(int? prsId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		if (!prsId.HasValue || prsId == 0)
		{
			return "";
		}
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		string result2 = "";
		try
		{
			CRMspSelectCompanyPersonsByID_Result cRMspSelectCompanyPersonsByID_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyPersonsByID_Result>((IEnumerable<CRMspSelectCompanyPersonsByID_Result>)Enumerable.ToList<CRMspSelectCompanyPersonsByID_Result>((IEnumerable<CRMspSelectCompanyPersonsByID_Result>)cRMSpEntities.CRMspSelectCompanyPersonsByID(prsId, lCID, result)));
			if (cRMspSelectCompanyPersonsByID_Result != null)
			{
				result2 = cRMspSelectCompanyPersonsByID_Result.prsFName + " " + cRMspSelectCompanyPersonsByID_Result.prsLName;
			}
			cRMSpEntities.Dispose();
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			cRMSpEntities.Dispose();
		}
		return result2;
	}

	public static string GetCmpPersonName(int defLangID, int currLangID, int? prsId)
	{
		if (!prsId.HasValue || prsId == 0)
		{
			return "";
		}
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		string result = "";
		try
		{
			CRMspSelectCompanyPersonsByID_Result cRMspSelectCompanyPersonsByID_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyPersonsByID_Result>((IEnumerable<CRMspSelectCompanyPersonsByID_Result>)Enumerable.ToList<CRMspSelectCompanyPersonsByID_Result>((IEnumerable<CRMspSelectCompanyPersonsByID_Result>)cRMSpEntities.CRMspSelectCompanyPersonsByID(prsId, currLangID, defLangID)));
			if (cRMspSelectCompanyPersonsByID_Result != null)
			{
				result = cRMspSelectCompanyPersonsByID_Result.PersonName ?? "";
			}
			cRMSpEntities.Dispose();
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			cRMSpEntities.Dispose();
		}
		return result;
	}

	public static string GetCmpPersonFullName(int? prsId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		if (!prsId.HasValue || prsId == 0)
		{
			return "";
		}
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		string result2 = "";
		try
		{
			CRMspSelectCompanyPersonsByID_Result cRMspSelectCompanyPersonsByID_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyPersonsByID_Result>((IEnumerable<CRMspSelectCompanyPersonsByID_Result>)cRMSpEntities.CRMspSelectCompanyPersonsByID(prsId, lCID, result));
			if (cRMspSelectCompanyPersonsByID_Result != null)
			{
				result2 = cRMspSelectCompanyPersonsByID_Result.PersonName ?? "";
			}
			cRMSpEntities.Dispose();
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			cRMSpEntities.Dispose();
		}
		return result2;
	}

	public static string GetCmpPersonNameWithTitle(int? prsId)
	{
		if (!prsId.HasValue || prsId == 0)
		{
			return "";
		}
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			CRMspSelectCompanyPersonsByID_Result cRMspSelectCompanyPersonsByID_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyPersonsByID_Result>((IEnumerable<CRMspSelectCompanyPersonsByID_Result>)cRMSpEntities.CRMspSelectCompanyPersonsByID(prsId, lCID, result2));
			if (cRMspSelectCompanyPersonsByID_Result != null)
			{
				result = cRMspSelectCompanyPersonsByID_Result.PersonName ?? "";
			}
			cRMSpEntities.Dispose();
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			cRMSpEntities.Dispose();
		}
		return result;
	}

	public static string GetCmpProjectTitle(int? prjId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		if (!prjId.HasValue || prjId == 0)
		{
			return "";
		}
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		string result2 = "";
		try
		{
			CRMspSelectCrmProjectsById_Result cRMspSelectCrmProjectsById_Result = Enumerable.FirstOrDefault<CRMspSelectCrmProjectsById_Result>((IEnumerable<CRMspSelectCrmProjectsById_Result>)cRMSpEntities.CRMspSelectCrmProjectsById(prjId, lCID, result));
			if (cRMspSelectCrmProjectsById_Result != null)
			{
				result2 = cRMspSelectCrmProjectsById_Result.prjTitle + ((!string.IsNullOrEmpty(cRMspSelectCrmProjectsById_Result.prjPostFix)) ? (" " + cRMspSelectCrmProjectsById_Result.prjPostFix) : "");
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities.Dispose();
		}
		return result2;
	}

	public static string GetCmpProjectTitle(int defLangID, int currLangID, int? prjId)
	{
		if (!prjId.HasValue || prjId == 0)
		{
			return "";
		}
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		string result = "";
		try
		{
			CRMspSelectCrmProjectsById_Result cRMspSelectCrmProjectsById_Result = Enumerable.FirstOrDefault<CRMspSelectCrmProjectsById_Result>((IEnumerable<CRMspSelectCrmProjectsById_Result>)cRMSpEntities.CRMspSelectCrmProjectsById(prjId, currLangID, defLangID));
			if (cRMspSelectCrmProjectsById_Result != null)
			{
				result = cRMspSelectCrmProjectsById_Result.ProjectTitle ?? "";
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities.Dispose();
		}
		return result;
	}

	public static bool IsFieldEmpty(string formName, string fieldName)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		try
		{
			List<CRMspSelectsysDBObjectsNotNull_Result> list = Enumerable.ToList<CRMspSelectsysDBObjectsNotNull_Result>((IEnumerable<CRMspSelectsysDBObjectsNotNull_Result>)cRMSpEntities.CRMspSelectsysDBObjectsNotNull(formName, lCID, result));
			bool result2 = false;
			if (list != null)
			{
				CRMspSelectsysDBObjectsNotNull_Result cRMspSelectsysDBObjectsNotNull_Result = Enumerable.FirstOrDefault<CRMspSelectsysDBObjectsNotNull_Result>((IEnumerable<CRMspSelectsysDBObjectsNotNull_Result>)list, (Func<CRMspSelectsysDBObjectsNotNull_Result, bool>)((CRMspSelectsysDBObjectsNotNull_Result c) => c.FieldName == fieldName));
				result2 = cRMspSelectsysDBObjectsNotNull_Result != null && cRMspSelectsysDBObjectsNotNull_Result.NotNull.HasValue && cRMspSelectsysDBObjectsNotNull_Result.NotNull != false;
			}
			cRMSpEntities.Dispose();
			return result2;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			cRMSpEntities.Dispose();
		}
		return false;
	}

	public static string ChkBeforeSubmitCompany(CrmCompany company, ref int countError)
	{
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		CRMTabelEntities cRMTabelEntities = new CRMTabelEntities();
		string text = "";
		try
		{
			DbSet<CrmsysDBObjects> crmsysDBObjects = cRMTabelEntities.CrmsysDBObjects;
			ParameterExpression val = Expression.Parameter(typeof(CrmsysDBObjects), "m");
			using (List<CrmsysDBObjects>.Enumerator enumerator = Enumerable.ToList<CrmsysDBObjects>((IEnumerable<CrmsysDBObjects>)Queryable.Where<CrmsysDBObjects>((IQueryable<CrmsysDBObjects>)crmsysDBObjects, Expression.Lambda<Func<CrmsysDBObjects, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)"CrmCompany", typeof(string))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Convert((Expression)(object)Expression.Constant((object)true, typeof(bool)), typeof(bool?)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }))).GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					switch (enumerator.Current.FieldName)
					{
					case "cmpName":
						if (company.cmpName == null)
						{
							text = text + Messages.CheckcmpName + "<br>";
							countError++;
						}
						break;
					case "cmpTitleId":
						if (!company.cmpTitleId.HasValue)
						{
							text = text + Messages.CheckcmpTitleId + "<br>";
							countError++;
						}
						break;
					case "cmpActivityType":
						if (company.cmpActivityType == null)
						{
							text = text + Messages.CheckcmpActivityType + "<br>";
							countError++;
						}
						break;
					case "cmpPresentationId":
						if (!company.cmpPresentationId.HasValue)
						{
							text = text + Messages.CheckcmpPresentationId + "<br>";
							countError++;
						}
						break;
					case "cmpTypeId":
						if (!company.cmpTypeId.HasValue)
						{
							text = text + Messages.CheckcmpTypeId + "<br>";
							countError++;
						}
						break;
					case "cmpGroupId":
						if (!company.cmpGroupId.HasValue)
						{
							text = text + Messages.CheckcmpGroupId + "<br>";
							countError++;
						}
						break;
					case "cmpSubGroupId":
						if (!company.cmpSubGroupId.HasValue)
						{
							text = text + Messages.CheckcmpSubGroupId + "<br>";
							countError++;
						}
						break;
					case "cmpGroupIdII":
						if (!company.cmpGroupIdII.HasValue)
						{
							text = text + Messages.CheckcmpGroupIdII + "<br>";
							countError++;
						}
						break;
					case "cmpGroupIdIII":
						if (!company.cmpGroupIdIII.HasValue)
						{
							text = text + Messages.CheckcmpGroupIdIII + "<br>";
							countError++;
						}
						break;
					case "cmpGroupIdIV":
						if (!company.cmpGroupIdIV.HasValue)
						{
							text = text + Messages.CheckcmpGroupIdIV + "<br>";
							countError++;
						}
						break;
					case "cmpPreTel":
						if (company.cmpPreTel == null)
						{
							text = text + Messages.CheckcmpPreTel + "<br>";
							countError++;
						}
						break;
					case "cmpTel":
						if (company.cmpTel == null)
						{
							text = text + Messages.CheckcmpTel + "<br>";
							countError++;
						}
						break;
					case "cmpTelUpTo":
						if (company.cmpTelUpTo == null)
						{
							text = text + Messages.CheckcmpTelUpTo + "<br>";
							countError++;
						}
						break;
					case "cmpTelDesc":
						if (company.cmpTelDesc == null)
						{
							text = text + Messages.CheckcmpTelDesc + "<br>";
							countError++;
						}
						break;
					case "cmpPreTelII":
						if (company.cmpPreTelII == null)
						{
							text = text + Messages.CheckcmpPreTelII + "<br>";
							countError++;
						}
						break;
					case "cmpTelII":
						if (company.cmpTelII == null)
						{
							text = text + Messages.CheckcmpTelII + "<br>";
							countError++;
						}
						break;
					case "cmpTelUpToII":
						if (company.cmpTelUpToII == null)
						{
							text = text + Messages.CheckcmpTelUpToII + "<br>";
							countError++;
						}
						break;
					case "cmpTelIIDesc":
						if (company.cmpTelIIDesc == null)
						{
							text = text + Messages.CheckcmpTelIIDesc + "<br>";
							countError++;
						}
						break;
					case "cmpFax":
						if (company.cmpFax == null)
						{
							text = text + Messages.CheckcmpFax + "<br>";
							countError++;
						}
						break;
					case "cmpFaxDesc":
						if (company.cmpFaxDesc == null)
						{
							text = text + Messages.CheckcmpFaxDesc + "<br>";
							countError++;
						}
						break;
					case "cmpCountryId":
						if (!company.cmpCountryId.HasValue)
						{
							text = text + Messages.CheckcmpCountryId + "<br>";
							countError++;
						}
						break;
					case "cmpProvinceId":
						if (!company.cmpProvinceId.HasValue)
						{
							text = text + Messages.CheckcmpProvinceId + "<br>";
							countError++;
						}
						break;
					case "cmpCityId":
						if (!company.cmpCityId.HasValue)
						{
							text = text + Messages.CheckcmpCityId + "<br>";
							countError++;
						}
						break;
					case "cmpAddress":
						if (company.cmpAddress == null)
						{
							text = text + Messages.CheckcmpAddress + "<br>";
							countError++;
						}
						break;
					case "cmpAddressDesc":
						if (company.cmpAddressDesc == null)
						{
							text = text + Messages.CheckcmpAddressDesc + "<br>";
							countError++;
						}
						break;
					case "cmpZipCode":
						if (company.cmpZipCode == null)
						{
							text = text + Messages.CheckcmpZipCode + "<br>";
							countError++;
						}
						break;
					case "cmpPostBox":
						if (company.cmpPostBox == null)
						{
							text = text + Messages.CheckcmpPostBox + "<br>";
							countError++;
						}
						break;
					case "cmpSpecialPoint":
						if (company.cmpSpecialPoint == null)
						{
							text = text + Messages.CheckcmpSpecialPoint + "<br>";
							countError++;
						}
						break;
					case "cmpDescription":
						if (company.cmpDescription == null)
						{
							text = text + Messages.CheckcmpDescription + "<br>";
							countError++;
						}
						break;
					}
				}
			}
			if (string.IsNullOrEmpty(company.cmpName))
			{
				text = text + Messages.CheckcmpName + "<br>";
				countError++;
			}
			if (!company.cmpCountryId.HasValue || company.cmpCountryId == 0)
			{
				text = text + Messages.CheckcmpCountryId + "<br>";
				countError++;
			}
			if (!company.cmpProvinceId.HasValue || company.cmpProvinceId == 0)
			{
				text = text + Messages.CheckcmpProvinceId + "<br>";
				countError++;
			}
			if (!company.cmpCityId.HasValue || company.cmpCityId == 0)
			{
				text = text + Messages.CheckcmpCityId + "<br>";
				countError++;
			}
			if (string.IsNullOrEmpty(company.cmpName))
			{
				text = text + Messages.CheckcmpName + "<br>";
			}
			else if (company.cmpName != Labels.lblPerson && company.cmpName != "شخص")
			{
				int titleId = (company.cmpTitleId.HasValue ? int.Parse(company.cmpTitleId.ToString()) : 0);
				int cityId = (company.cmpCityId.HasValue ? int.Parse(company.cmpCityId.ToString()) : 0);
				CRMspCheckDuplicateCompanyViewModel cRMspCheckDuplicateCompanyViewModel = CheckDuplicateCompany(1, company.CompanyID, company.cmpName, titleId, cityId, company.UserId);
				if (cRMspCheckDuplicateCompanyViewModel != null)
				{
					countError++;
					text += string.Format(Messages.CheckcmpNameDuplicate, cRMspCheckDuplicateCompanyViewModel.cmpName, cRMspCheckDuplicateCompanyViewModel.Title, cRMspCheckDuplicateCompanyViewModel.City, cRMspCheckDuplicateCompanyViewModel.cmpNumber);
				}
			}
			if (company.cmpPreTel != null && company.cmpPreTel.Length > 1 && company.cmpPreTel.Substring(0, 2) == "09")
			{
				countError++;
				text += Messages.CheckcmpPreTelMobile;
			}
			if (company.cmpPreTelII != null && company.cmpPreTelII.Length > 1 && company.cmpPreTelII.Substring(0, 2) == "09")
			{
				countError++;
				text += Messages.CheckcmpPreTelIIMobile;
			}
			if (!string.IsNullOrEmpty(company.cmpTel))
			{
				bool flag = true;
				for (int i = 0; i < company.cmpTel.Length; i++)
				{
					if (!char.IsDigit(company.cmpTel[i]))
					{
						flag = false;
					}
				}
				if (!flag)
				{
					countError++;
					text = text + Messages.CheckNrmbercmpTel + "<br>";
				}
			}
			if (!string.IsNullOrEmpty(company.cmpPreTel))
			{
				bool flag2 = true;
				for (int j = 0; j < company.cmpPreTel.Length; j++)
				{
					if (!char.IsDigit(company.cmpPreTel[j]))
					{
						flag2 = false;
					}
				}
				if (!flag2)
				{
					countError++;
					text = text + Messages.CheckNrmbercmpPreTel + "<br>";
				}
			}
			if (!string.IsNullOrEmpty(company.cmpTelUpTo))
			{
				bool flag3 = true;
				for (int k = 0; k < company.cmpTelUpTo.Length; k++)
				{
					if (!char.IsDigit(company.cmpTelUpTo[k]))
					{
						flag3 = false;
					}
				}
				if (!flag3)
				{
					countError++;
					text = text + Messages.CheckNrmbercmpTelUpTo + "<br>";
				}
			}
			if (!string.IsNullOrEmpty(company.cmpTelII))
			{
				bool flag4 = true;
				for (int l = 0; l < company.cmpTelII.Length; l++)
				{
					if (!char.IsDigit(company.cmpTelII[l]))
					{
						flag4 = false;
					}
				}
				if (!flag4)
				{
					countError++;
					text = text + Messages.CheckNrmbercmpTelII + "<br>";
				}
			}
			if (!string.IsNullOrEmpty(company.cmpPreTelII))
			{
				bool flag5 = true;
				for (int m = 0; m < company.cmpPreTelII.Length; m++)
				{
					if (!char.IsDigit(company.cmpPreTelII[m]))
					{
						flag5 = false;
					}
				}
				if (!flag5)
				{
					countError++;
					text = text + Messages.CheckNrmbercmpPreTelII + "<br>";
				}
			}
			if (!string.IsNullOrEmpty(company.cmpTelUpToII))
			{
				bool flag6 = true;
				for (int n = 0; n < company.cmpTelUpToII.Length; n++)
				{
					if (!char.IsDigit(company.cmpTelUpToII[n]))
					{
						flag6 = false;
					}
				}
				if (!flag6)
				{
					countError++;
					text = text + Messages.CheckNrmbercmpTelUpToII + "<br>";
				}
			}
			if (!string.IsNullOrEmpty(company.cmpFax))
			{
				bool flag7 = true;
				for (int num = 0; num < company.cmpFax.Length; num++)
				{
					if (!char.IsDigit(company.cmpFax[num]))
					{
						flag7 = false;
					}
				}
				if (!flag7)
				{
					countError++;
					text = text + Messages.CheckNrmbercmpFax + "<br>";
				}
			}
			if (company.cmpNumber.HasValue)
			{
				string text2 = company.cmpNumber.ToString();
				if (!string.IsNullOrEmpty(text2))
				{
					bool flag8 = true;
					for (int num2 = 0; num2 < text2.Length; num2++)
					{
						if (!char.IsDigit(text2[num2]))
						{
							flag8 = false;
						}
					}
					if (!flag8)
					{
						countError++;
						text = text + Messages.CheckNrmbercmpNum + "<br>";
					}
				}
			}
			if (UserLogin.IsUserAccess("frmCompanyI", "actCanChangecmpNumber", UserLogin.CurrentUser))
			{
				if (company.cmpNumber.HasValue)
				{
					string text3 = CheckDuplicateCompanyNumber(company.CompanyID, company.cmpNumber);
					if ((text3 != null) & (text3 != ""))
					{
						countError++;
						text += string.Format(Messages.CheckcmpNumberDuplicate, text3);
					}
				}
				else
				{
					company.cmpNumber = CreateCompanyNumber();
				}
			}
			else if (!company.cmpNumber.HasValue)
			{
				company.cmpNumber = CreateCompanyNumber();
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
			text = Messages.frmErrorMessage;
			countError++;
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			text = Messages.frmErrorMessage;
			countError++;
		}
		finally
		{
			cRMSpEntities.Dispose();
			cRMTabelEntities.Dispose();
		}
		return text;
	}

	public static string GetUserName(int userID, int defLangID, int currLangID)
	{
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		string result = "";
		try
		{
			CRMspSelectUsersById_Result cRMspSelectUsersById_Result = User.SelectUsersById(userID, -1, currLangID, defLangID);
			if (cRMspSelectUsersById_Result != null)
			{
				result = cRMspSelectUsersById_Result.FullName ?? "";
			}
			cRMSpEntities.Dispose();
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			cRMSpEntities.Dispose();
		}
		return result;
	}

	public static string CreateCmpPassword(string password)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		string result2 = "";
		try
		{
			string text = DateTime.Now.ToString("fffss");
			string text2 = new Random().Next(1000, 9999).ToString();
			result2 = text + password + text2;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result2;
	}

	public static string CheckDuplicateCompanyCode(int cmpId, string cmpCode)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		string result2 = "";
		try
		{
			if (!string.IsNullOrEmpty(cmpCode) && UserLogin.IsUserAccess("frmCompanyI", "actCmpCodeNotDup", UserLogin.CurrentUser))
			{
				string sql = $"Select * from CRMfnCheckDuplicateCompanyCode('{cmpCode}', {cmpId}, {lCID}, {result})";
				result2 = Enumerable.Aggregate<CheckDuplicateCompanyCodeViewModel, string>((IEnumerable<CheckDuplicateCompanyCodeViewModel>)Enumerable.ToList<CheckDuplicateCompanyCodeViewModel>(cRMSpEntities.Database.SqlQuery<CheckDuplicateCompanyCodeViewModel>(sql, Array.Empty<object>())), "", (Func<string, CheckDuplicateCompanyCodeViewModel, string>)((string current, CheckDuplicateCompanyCodeViewModel item) => current + item.CompanyName + " "));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result2 = "-1";
		}
		finally
		{
			cRMSpEntities.Dispose();
		}
		return result2;
	}

	public static string CheckMobileFormat(string val = "")
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		string result = "";
		try
		{
			if (string.IsNullOrWhiteSpace(val))
			{
				return result;
			}
			val = val.Trim();
			new Regex("");
			if (new Regex("^(0|0098|\\+98)9(0[1-5]|[1 3]\\d|2[0-2]|98)\\d{7}$").IsMatch(val))
			{
				return val;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public static string CheckPhoneFormat(string val = "")
	{
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		string result = val;
		try
		{
			if (string.IsNullOrWhiteSpace(val))
			{
				return "";
			}
			if (!string.IsNullOrWhiteSpace(CheckMobileFormat(val)))
			{
				return "";
			}
			val = val.Trim();
			new Regex("");
			if (new Regex("^(0|0098|\\+98)[0-9]{2,}[0-9]{7,}$").IsMatch(val))
			{
				return result;
			}
			if (new Regex("^0[1-8]{2,}[0-9]{8,}$").IsMatch(val))
			{
				return result;
			}
			if (val.Substring(0, 2) == "09" || val.Substring(0, 2) == "+989" || val.Substring(0, 2) == "00989")
			{
				result = "";
			}
			if (!new Regex("^\\d+$").IsMatch(val))
			{
				result = "";
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public static string[] GetPhoneParts(string val = "")
	{
		string[] array = new string[3] { "", "", "" };
		try
		{
			val = CheckPhoneFormat(val);
			if (!string.IsNullOrWhiteSpace(val))
			{
				if (val.Length <= 8)
				{
					array[0] = "";
					array[1] = val;
					array[2] = "";
				}
				else if (val.Length == 11)
				{
					array[0] = val.Substring(0, 3);
					array[1] = val.Substring(4, val.Length - 4);
					array[2] = "";
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return array;
	}

	public static string CheckPrjIsFinishedByPrjPrdHNotDone(int prjId, bool isTicket = false)
	{
		string result = "";
		CRMSpIEntities cRMSpIEntities = new CRMSpIEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (prjId != 0 && UserLogin.IsUserAccess("frmDefineProjects", "actCanNotPrjIsFinishedByPrjPrdHNotDone", UserLogin.CurrentUser))
			{
				CRMspSelectProjectProductHistoryNotDone_Result cRMspSelectProjectProductHistoryNotDone_Result = Enumerable.FirstOrDefault<CRMspSelectProjectProductHistoryNotDone_Result>((IEnumerable<CRMspSelectProjectProductHistoryNotDone_Result>)cRMSpIEntities.CRMspSelectProjectProductHistoryNotDone(prjId, lCID, result2));
				if (cRMspSelectProjectProductHistoryNotDone_Result != null)
				{
					string text = cRMspSelectProjectProductHistoryNotDone_Result.PrjPrdHProduct ?? "";
					if (!string.IsNullOrWhiteSpace(text))
					{
						text = "'" + text + "'";
					}
					result = ((!isTicket) ? string.Format(Messages.msgErrorPrjNotFinishedWithPrjPrdHistoryNotDone, text) : string.Format(Messages.msgErrorTicketNotClosedWithPrjPrdHistoryNotDone, text));
				}
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
		}
		finally
		{
			cRMSpIEntities.Dispose();
		}
		return result;
	}

	public static string CheckCnvsRemindOkByPrjPrdHNotDone(int prjId)
	{
		string result = "";
		CRMSpIEntities cRMSpIEntities = new CRMSpIEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (prjId != 0 && UserLogin.IsUserAccess("frmDefineConversation", "actCanNotCnvsRemindOkByPrjPrdHNotDone", UserLogin.CurrentUser))
			{
				CRMspSelectProjectProductHistoryNotDone_Result cRMspSelectProjectProductHistoryNotDone_Result = Enumerable.FirstOrDefault<CRMspSelectProjectProductHistoryNotDone_Result>((IEnumerable<CRMspSelectProjectProductHistoryNotDone_Result>)cRMSpIEntities.CRMspSelectProjectProductHistoryNotDone(prjId, lCID, result2));
				if (cRMspSelectProjectProductHistoryNotDone_Result != null)
				{
					string text = cRMspSelectProjectProductHistoryNotDone_Result.PrjPrdHProduct ?? "";
					if (!string.IsNullOrWhiteSpace(text))
					{
						text = "'" + text + "'";
					}
					result = string.Format(Messages.msgErrorCnvsRemindOkWithPrjPrdHistoryNotDone, text);
				}
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
		}
		finally
		{
			cRMSpIEntities.Dispose();
		}
		return result;
	}

	public static bool InsertCompanyChangeHistory(int cmpId, int mode, CrmCompanyChangeHistoryFieldViewModel oldCmpInfo, CrmCompanyChangeHistoryFieldViewModel newCmpInfo)
	{
		bool result = false;
		CRMSpIEntities cRMSpIEntities = new CRMSpIEntities();
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		CRMTabelEntities cRMTabelEntities = new CRMTabelEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
			if (defLangID <= 0)
			{
				defLangID = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			string appType = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
			string text = "";
			string text2 = "";
			string text3 = "";
			string text4 = "";
			string text5 = "";
			List<CrmCompanyChangeHistoryLangViewModel> list = new List<CrmCompanyChangeHistoryLangViewModel>();
			if (oldCmpInfo.cmpGroupId != newCmpInfo.cmpGroupId)
			{
				text = "cmpGroupId";
				text2 = ((!oldCmpInfo.cmpGroupId.HasValue) ? "" : oldCmpInfo.cmpGroupId.ToString());
				text3 = ((!newCmpInfo.cmpGroupId.HasValue) ? "" : newCmpInfo.cmpGroupId.ToString());
				list = new List<CrmCompanyChangeHistoryLangViewModel>();
				List<CommonMultiAndIdLanguageViewModel> list2 = new List<CommonMultiAndIdLanguageViewModel>();
				List<CrmCompanyGroups> list3 = Enumerable.ToList<CrmCompanyGroups>((IEnumerable<CrmCompanyGroups>)cRMTabelEntities.CrmCompanyGroups);
				List<CrmCompanyGroups_Lang> list4 = Enumerable.ToList<CrmCompanyGroups_Lang>((IEnumerable<CrmCompanyGroups_Lang>)cRMTabelEntities.CrmCompanyGroups_Lang);
				if (list3 != null && Enumerable.Any<CrmCompanyGroups>((IEnumerable<CrmCompanyGroups>)list3))
				{
					foreach (CrmCompanyGroups item23 in list3)
					{
						CommonMultiAndIdLanguageViewModel item = new CommonMultiAndIdLanguageViewModel
						{
							LanguageId = item23.LanguageID.GetValueOrDefault(),
							Value = item23.GroupName,
							Id = item23.CompanyGroupID
						};
						list2.Add(item);
					}
				}
				if (list4 != null && Enumerable.Any<CrmCompanyGroups_Lang>((IEnumerable<CrmCompanyGroups_Lang>)list4))
				{
					foreach (CrmCompanyGroups_Lang item24 in list4)
					{
						CommonMultiAndIdLanguageViewModel item2 = new CommonMultiAndIdLanguageViewModel
						{
							LanguageId = item24.LanguageID,
							Value = item24.GroupName,
							Id = item24.CompanyGroupID
						};
						list2.Add(item2);
					}
				}
				foreach (Languages lang9 in Enumerable.ToList<Languages>((IEnumerable<Languages>)Language.Get()))
				{
					CrmCompanyChangeHistoryLangViewModel crmCompanyChangeHistoryLangViewModel = new CrmCompanyChangeHistoryLangViewModel();
					crmCompanyChangeHistoryLangViewModel.LanguageID = lang9.LanguageID;
					crmCompanyChangeHistoryLangViewModel.OldValue = text2;
					crmCompanyChangeHistoryLangViewModel.NewValue = text3;
					string text6 = "";
					CRMspSelectUsersById_Result cRMspSelectUsersById_Result = User.SelectUsersById(userId, -1, lang9.LanguageID, defLangID);
					if (cRMspSelectUsersById_Result != null)
					{
						text6 = cRMspSelectUsersById_Result.FullName ?? "";
					}
					if (mode == 1)
					{
						crmCompanyChangeHistoryLangViewModel.Desc = string.Format(MyResource.GetResourceString("cmpChangeHistoryDescRegisterByUser", lang9.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), text6);
					}
					else
					{
						string arg = "";
						string arg2 = "";
						if (list2 != null && Enumerable.Any<CommonMultiAndIdLanguageViewModel>((IEnumerable<CommonMultiAndIdLanguageViewModel>)list2))
						{
							if (!oldCmpInfo.cmpGroupId.HasValue)
							{
								arg = MyResource.GetResourceString("LblNoValue", lang9.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
							}
							else
							{
								CommonMultiAndIdLanguageViewModel commonMultiAndIdLanguageViewModel = Enumerable.FirstOrDefault<CommonMultiAndIdLanguageViewModel>((IEnumerable<CommonMultiAndIdLanguageViewModel>)list2, (Func<CommonMultiAndIdLanguageViewModel, bool>)((CommonMultiAndIdLanguageViewModel m) => m.Id == oldCmpInfo.cmpGroupId && m.LanguageId == lang9.LanguageID));
								if (commonMultiAndIdLanguageViewModel != null)
								{
									arg = commonMultiAndIdLanguageViewModel.Value ?? "";
								}
							}
							if (!newCmpInfo.cmpGroupId.HasValue)
							{
								arg2 = MyResource.GetResourceString("LblNoValue", lang9.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
							}
							else
							{
								CommonMultiAndIdLanguageViewModel commonMultiAndIdLanguageViewModel2 = Enumerable.FirstOrDefault<CommonMultiAndIdLanguageViewModel>((IEnumerable<CommonMultiAndIdLanguageViewModel>)list2, (Func<CommonMultiAndIdLanguageViewModel, bool>)((CommonMultiAndIdLanguageViewModel m) => m.Id == newCmpInfo.cmpGroupId && m.LanguageId == lang9.LanguageID));
								if (commonMultiAndIdLanguageViewModel2 != null)
								{
									arg2 = commonMultiAndIdLanguageViewModel2.Value ?? "";
								}
							}
							crmCompanyChangeHistoryLangViewModel.Desc = string.Format(MyResource.GetResourceString("cmpChangeHistoryDescChangeGroup", lang9.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), arg, arg2, text6);
						}
					}
					list.Add(crmCompanyChangeHistoryLangViewModel);
				}
				text4 = "";
				text5 = "";
				if (list != null && Enumerable.Any<CrmCompanyChangeHistoryLangViewModel>((IEnumerable<CrmCompanyChangeHistoryLangViewModel>)list))
				{
					text4 = (Enumerable.Any<CrmCompanyChangeHistoryLangViewModel>((IEnumerable<CrmCompanyChangeHistoryLangViewModel>)list, (Func<CrmCompanyChangeHistoryLangViewModel, bool>)((CrmCompanyChangeHistoryLangViewModel c) => c.LanguageID == defLangID)) ? Enumerable.FirstOrDefault<CrmCompanyChangeHistoryLangViewModel>((IEnumerable<CrmCompanyChangeHistoryLangViewModel>)list, (Func<CrmCompanyChangeHistoryLangViewModel, bool>)((CrmCompanyChangeHistoryLangViewModel c) => c.LanguageID == defLangID)).Desc : "");
					text5 = JsonConvert.SerializeObject(Enumerable.ToList<CrmCompanyChangeHistoryLangViewModel>(Enumerable.Where<CrmCompanyChangeHistoryLangViewModel>((IEnumerable<CrmCompanyChangeHistoryLangViewModel>)list, (Func<CrmCompanyChangeHistoryLangViewModel, bool>)((CrmCompanyChangeHistoryLangViewModel c) => c.LanguageID != defLangID))));
				}
				ObjectParameter insertedId = new ObjectParameter("insertedId", 0);
				cRMSpIEntities.CRMspInsertCompanyChangeHistory(cmpId, text, text2, text3, text4, text5, userId, now, registerDatePersian, appType, defLangID, insertedId);
			}
			if (oldCmpInfo.cmpSubGroupId != newCmpInfo.cmpSubGroupId)
			{
				text = "cmpSubGroupId";
				text2 = ((!oldCmpInfo.cmpSubGroupId.HasValue) ? "" : oldCmpInfo.cmpSubGroupId.ToString());
				text3 = ((!newCmpInfo.cmpSubGroupId.HasValue) ? "" : newCmpInfo.cmpSubGroupId.ToString());
				list = new List<CrmCompanyChangeHistoryLangViewModel>();
				List<CommonMultiAndIdLanguageViewModel> list5 = new List<CommonMultiAndIdLanguageViewModel>();
				List<CrmCompanySubGroups> list6 = Enumerable.ToList<CrmCompanySubGroups>((IEnumerable<CrmCompanySubGroups>)cRMTabelEntities.CrmCompanySubGroups);
				List<CrmCompanySubGroups_Lang> list7 = Enumerable.ToList<CrmCompanySubGroups_Lang>((IEnumerable<CrmCompanySubGroups_Lang>)cRMTabelEntities.CrmCompanySubGroups_Lang);
				if (list6 != null && Enumerable.Any<CrmCompanySubGroups>((IEnumerable<CrmCompanySubGroups>)list6))
				{
					foreach (CrmCompanySubGroups item25 in list6)
					{
						CommonMultiAndIdLanguageViewModel item3 = new CommonMultiAndIdLanguageViewModel
						{
							LanguageId = item25.LanguageID.GetValueOrDefault(),
							Value = item25.SubGroupName,
							Id = item25.CompanySubGroupID
						};
						list5.Add(item3);
					}
				}
				if (list7 != null && Enumerable.Any<CrmCompanySubGroups_Lang>((IEnumerable<CrmCompanySubGroups_Lang>)list7))
				{
					foreach (CrmCompanySubGroups_Lang item26 in list7)
					{
						CommonMultiAndIdLanguageViewModel item4 = new CommonMultiAndIdLanguageViewModel
						{
							LanguageId = item26.LanguageID,
							Value = item26.SubGroupName,
							Id = item26.CompanySubGroupID
						};
						list5.Add(item4);
					}
				}
				foreach (Languages lang8 in Enumerable.ToList<Languages>((IEnumerable<Languages>)Language.Get()))
				{
					CrmCompanyChangeHistoryLangViewModel crmCompanyChangeHistoryLangViewModel2 = new CrmCompanyChangeHistoryLangViewModel();
					crmCompanyChangeHistoryLangViewModel2.LanguageID = lang8.LanguageID;
					crmCompanyChangeHistoryLangViewModel2.OldValue = text2;
					crmCompanyChangeHistoryLangViewModel2.NewValue = text3;
					string text7 = "";
					CRMspSelectUsersById_Result cRMspSelectUsersById_Result2 = User.SelectUsersById(userId, -1, lang8.LanguageID, defLangID);
					if (cRMspSelectUsersById_Result2 != null)
					{
						text7 = cRMspSelectUsersById_Result2.FullName ?? "";
					}
					if (mode == 1)
					{
						crmCompanyChangeHistoryLangViewModel2.Desc = string.Format(MyResource.GetResourceString("cmpChangeHistoryDescRegisterByUser", lang8.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), text7);
					}
					else
					{
						string arg3 = "";
						string arg4 = "";
						if (list5 != null && Enumerable.Any<CommonMultiAndIdLanguageViewModel>((IEnumerable<CommonMultiAndIdLanguageViewModel>)list5))
						{
							if (!oldCmpInfo.cmpSubGroupId.HasValue)
							{
								arg3 = MyResource.GetResourceString("LblNoValue", lang8.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
							}
							else
							{
								CommonMultiAndIdLanguageViewModel commonMultiAndIdLanguageViewModel3 = Enumerable.FirstOrDefault<CommonMultiAndIdLanguageViewModel>((IEnumerable<CommonMultiAndIdLanguageViewModel>)list5, (Func<CommonMultiAndIdLanguageViewModel, bool>)((CommonMultiAndIdLanguageViewModel m) => m.Id == oldCmpInfo.cmpSubGroupId && m.LanguageId == lang8.LanguageID));
								if (commonMultiAndIdLanguageViewModel3 != null)
								{
									arg3 = commonMultiAndIdLanguageViewModel3.Value ?? "";
								}
							}
							if (!newCmpInfo.cmpSubGroupId.HasValue)
							{
								arg4 = MyResource.GetResourceString("LblNoValue", lang8.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
							}
							else
							{
								CommonMultiAndIdLanguageViewModel commonMultiAndIdLanguageViewModel4 = Enumerable.FirstOrDefault<CommonMultiAndIdLanguageViewModel>((IEnumerable<CommonMultiAndIdLanguageViewModel>)list5, (Func<CommonMultiAndIdLanguageViewModel, bool>)((CommonMultiAndIdLanguageViewModel m) => m.Id == newCmpInfo.cmpSubGroupId && m.LanguageId == lang8.LanguageID));
								if (commonMultiAndIdLanguageViewModel4 != null)
								{
									arg4 = commonMultiAndIdLanguageViewModel4.Value ?? "";
								}
							}
							crmCompanyChangeHistoryLangViewModel2.Desc = string.Format(MyResource.GetResourceString("cmpChangeHistoryDescChangeSubGroup", lang8.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), arg3, arg4, text7);
						}
					}
					list.Add(crmCompanyChangeHistoryLangViewModel2);
				}
				text4 = "";
				text5 = "";
				if (list != null && Enumerable.Any<CrmCompanyChangeHistoryLangViewModel>((IEnumerable<CrmCompanyChangeHistoryLangViewModel>)list))
				{
					text4 = (Enumerable.Any<CrmCompanyChangeHistoryLangViewModel>((IEnumerable<CrmCompanyChangeHistoryLangViewModel>)list, (Func<CrmCompanyChangeHistoryLangViewModel, bool>)((CrmCompanyChangeHistoryLangViewModel c) => c.LanguageID == defLangID)) ? Enumerable.FirstOrDefault<CrmCompanyChangeHistoryLangViewModel>((IEnumerable<CrmCompanyChangeHistoryLangViewModel>)list, (Func<CrmCompanyChangeHistoryLangViewModel, bool>)((CrmCompanyChangeHistoryLangViewModel c) => c.LanguageID == defLangID)).Desc : "");
					text5 = JsonConvert.SerializeObject(Enumerable.ToList<CrmCompanyChangeHistoryLangViewModel>(Enumerable.Where<CrmCompanyChangeHistoryLangViewModel>((IEnumerable<CrmCompanyChangeHistoryLangViewModel>)list, (Func<CrmCompanyChangeHistoryLangViewModel, bool>)((CrmCompanyChangeHistoryLangViewModel c) => c.LanguageID != defLangID))));
				}
				ObjectParameter insertedId2 = new ObjectParameter("insertedId", 0);
				cRMSpIEntities.CRMspInsertCompanyChangeHistory(cmpId, text, text2, text3, text4, text5, userId, now, registerDatePersian, appType, defLangID, insertedId2);
			}
			if (oldCmpInfo.cmpGroupIdII != newCmpInfo.cmpGroupIdII)
			{
				text = "cmpGroupIdII";
				text2 = ((!oldCmpInfo.cmpGroupIdII.HasValue) ? "" : oldCmpInfo.cmpGroupIdII.ToString());
				text3 = ((!newCmpInfo.cmpGroupIdII.HasValue) ? "" : newCmpInfo.cmpGroupIdII.ToString());
				list = new List<CrmCompanyChangeHistoryLangViewModel>();
				List<CommonMultiAndIdLanguageViewModel> list8 = new List<CommonMultiAndIdLanguageViewModel>();
				List<CrmCompanyGroupsII> list9 = Enumerable.ToList<CrmCompanyGroupsII>((IEnumerable<CrmCompanyGroupsII>)cRMTabelEntities.CrmCompanyGroupsII);
				List<CrmCompanyGroupsII_Lang> list10 = Enumerable.ToList<CrmCompanyGroupsII_Lang>((IEnumerable<CrmCompanyGroupsII_Lang>)cRMTabelEntities.CrmCompanyGroupsII_Lang);
				if (list9 != null && Enumerable.Any<CrmCompanyGroupsII>((IEnumerable<CrmCompanyGroupsII>)list9))
				{
					foreach (CrmCompanyGroupsII item27 in list9)
					{
						CommonMultiAndIdLanguageViewModel item5 = new CommonMultiAndIdLanguageViewModel
						{
							LanguageId = item27.LanguageID.GetValueOrDefault(),
							Value = item27.GroupIIName,
							Id = item27.CompanyGroupIIID
						};
						list8.Add(item5);
					}
				}
				if (list10 != null && Enumerable.Any<CrmCompanyGroupsII_Lang>((IEnumerable<CrmCompanyGroupsII_Lang>)list10))
				{
					foreach (CrmCompanyGroupsII_Lang item28 in list10)
					{
						CommonMultiAndIdLanguageViewModel item6 = new CommonMultiAndIdLanguageViewModel
						{
							LanguageId = item28.LanguageID,
							Value = item28.GroupIIName,
							Id = item28.CompanyGroupIIID
						};
						list8.Add(item6);
					}
				}
				foreach (Languages lang7 in Enumerable.ToList<Languages>((IEnumerable<Languages>)Language.Get()))
				{
					CrmCompanyChangeHistoryLangViewModel crmCompanyChangeHistoryLangViewModel3 = new CrmCompanyChangeHistoryLangViewModel();
					crmCompanyChangeHistoryLangViewModel3.LanguageID = lang7.LanguageID;
					crmCompanyChangeHistoryLangViewModel3.OldValue = text2;
					crmCompanyChangeHistoryLangViewModel3.NewValue = text3;
					string text8 = "";
					CRMspSelectUsersById_Result cRMspSelectUsersById_Result3 = User.SelectUsersById(userId, -1, lang7.LanguageID, defLangID);
					if (cRMspSelectUsersById_Result3 != null)
					{
						text8 = cRMspSelectUsersById_Result3.FullName ?? "";
					}
					if (mode == 1)
					{
						crmCompanyChangeHistoryLangViewModel3.Desc = string.Format(MyResource.GetResourceString("cmpChangeHistoryDescRegisterByUser", lang7.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), text8);
					}
					else
					{
						string arg5 = "";
						string arg6 = "";
						if (list8 != null && Enumerable.Any<CommonMultiAndIdLanguageViewModel>((IEnumerable<CommonMultiAndIdLanguageViewModel>)list8))
						{
							if (!oldCmpInfo.cmpGroupIdII.HasValue)
							{
								arg5 = MyResource.GetResourceString("LblNoValue", lang7.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
							}
							else
							{
								CommonMultiAndIdLanguageViewModel commonMultiAndIdLanguageViewModel5 = Enumerable.FirstOrDefault<CommonMultiAndIdLanguageViewModel>((IEnumerable<CommonMultiAndIdLanguageViewModel>)list8, (Func<CommonMultiAndIdLanguageViewModel, bool>)((CommonMultiAndIdLanguageViewModel m) => m.Id == oldCmpInfo.cmpGroupIdII && m.LanguageId == lang7.LanguageID));
								if (commonMultiAndIdLanguageViewModel5 != null)
								{
									arg5 = commonMultiAndIdLanguageViewModel5.Value ?? "";
								}
							}
							if (!newCmpInfo.cmpGroupIdII.HasValue)
							{
								arg6 = MyResource.GetResourceString("LblNoValue", lang7.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
							}
							else
							{
								CommonMultiAndIdLanguageViewModel commonMultiAndIdLanguageViewModel6 = Enumerable.FirstOrDefault<CommonMultiAndIdLanguageViewModel>((IEnumerable<CommonMultiAndIdLanguageViewModel>)list8, (Func<CommonMultiAndIdLanguageViewModel, bool>)((CommonMultiAndIdLanguageViewModel m) => m.Id == newCmpInfo.cmpGroupIdII && m.LanguageId == lang7.LanguageID));
								if (commonMultiAndIdLanguageViewModel6 != null)
								{
									arg6 = commonMultiAndIdLanguageViewModel6.Value ?? "";
								}
							}
							crmCompanyChangeHistoryLangViewModel3.Desc = string.Format(MyResource.GetResourceString("cmpChangeHistoryDescChangeGroupII", lang7.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), arg5, arg6, text8);
						}
					}
					list.Add(crmCompanyChangeHistoryLangViewModel3);
				}
				text4 = "";
				text5 = "";
				if (list != null && Enumerable.Any<CrmCompanyChangeHistoryLangViewModel>((IEnumerable<CrmCompanyChangeHistoryLangViewModel>)list))
				{
					text4 = (Enumerable.Any<CrmCompanyChangeHistoryLangViewModel>((IEnumerable<CrmCompanyChangeHistoryLangViewModel>)list, (Func<CrmCompanyChangeHistoryLangViewModel, bool>)((CrmCompanyChangeHistoryLangViewModel c) => c.LanguageID == defLangID)) ? Enumerable.FirstOrDefault<CrmCompanyChangeHistoryLangViewModel>((IEnumerable<CrmCompanyChangeHistoryLangViewModel>)list, (Func<CrmCompanyChangeHistoryLangViewModel, bool>)((CrmCompanyChangeHistoryLangViewModel c) => c.LanguageID == defLangID)).Desc : "");
					text5 = JsonConvert.SerializeObject(Enumerable.ToList<CrmCompanyChangeHistoryLangViewModel>(Enumerable.Where<CrmCompanyChangeHistoryLangViewModel>((IEnumerable<CrmCompanyChangeHistoryLangViewModel>)list, (Func<CrmCompanyChangeHistoryLangViewModel, bool>)((CrmCompanyChangeHistoryLangViewModel c) => c.LanguageID != defLangID))));
				}
				ObjectParameter insertedId3 = new ObjectParameter("insertedId", 0);
				cRMSpIEntities.CRMspInsertCompanyChangeHistory(cmpId, text, text2, text3, text4, text5, userId, now, registerDatePersian, appType, defLangID, insertedId3);
			}
			if (oldCmpInfo.cmpGroupIdIII != newCmpInfo.cmpGroupIdIII)
			{
				text = "cmpGroupIdIII";
				text2 = ((!oldCmpInfo.cmpGroupIdIII.HasValue) ? "" : oldCmpInfo.cmpGroupIdIII.ToString());
				text3 = ((!newCmpInfo.cmpGroupIdIII.HasValue) ? "" : newCmpInfo.cmpGroupIdIII.ToString());
				list = new List<CrmCompanyChangeHistoryLangViewModel>();
				List<CommonMultiAndIdLanguageViewModel> list11 = new List<CommonMultiAndIdLanguageViewModel>();
				List<CrmCompanyGroupsIII> list12 = Enumerable.ToList<CrmCompanyGroupsIII>((IEnumerable<CrmCompanyGroupsIII>)cRMTabelEntities.CrmCompanyGroupsIII);
				List<CrmCompanyGroupsIII_Lang> list13 = Enumerable.ToList<CrmCompanyGroupsIII_Lang>((IEnumerable<CrmCompanyGroupsIII_Lang>)cRMTabelEntities.CrmCompanyGroupsIII_Lang);
				if (list12 != null && Enumerable.Any<CrmCompanyGroupsIII>((IEnumerable<CrmCompanyGroupsIII>)list12))
				{
					foreach (CrmCompanyGroupsIII item29 in list12)
					{
						CommonMultiAndIdLanguageViewModel item7 = new CommonMultiAndIdLanguageViewModel
						{
							LanguageId = item29.LanguageID.GetValueOrDefault(),
							Value = item29.GroupIIIName,
							Id = item29.CompanyGroupIIIID
						};
						list11.Add(item7);
					}
				}
				if (list13 != null && Enumerable.Any<CrmCompanyGroupsIII_Lang>((IEnumerable<CrmCompanyGroupsIII_Lang>)list13))
				{
					foreach (CrmCompanyGroupsIII_Lang item30 in list13)
					{
						CommonMultiAndIdLanguageViewModel item8 = new CommonMultiAndIdLanguageViewModel
						{
							LanguageId = item30.LanguageID,
							Value = item30.GroupIIIName,
							Id = item30.CompanyGroupIIIID
						};
						list11.Add(item8);
					}
				}
				foreach (Languages lang6 in Enumerable.ToList<Languages>((IEnumerable<Languages>)Language.Get()))
				{
					CrmCompanyChangeHistoryLangViewModel crmCompanyChangeHistoryLangViewModel4 = new CrmCompanyChangeHistoryLangViewModel();
					crmCompanyChangeHistoryLangViewModel4.LanguageID = lang6.LanguageID;
					crmCompanyChangeHistoryLangViewModel4.OldValue = text2;
					crmCompanyChangeHistoryLangViewModel4.NewValue = text3;
					string text9 = "";
					CRMspSelectUsersById_Result cRMspSelectUsersById_Result4 = User.SelectUsersById(userId, -1, lang6.LanguageID, defLangID);
					if (cRMspSelectUsersById_Result4 != null)
					{
						text9 = cRMspSelectUsersById_Result4.FullName ?? "";
					}
					if (mode == 1)
					{
						crmCompanyChangeHistoryLangViewModel4.Desc = string.Format(MyResource.GetResourceString("cmpChangeHistoryDescRegisterByUser", lang6.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), text9);
					}
					else
					{
						string arg7 = "";
						string arg8 = "";
						if (list11 != null && Enumerable.Any<CommonMultiAndIdLanguageViewModel>((IEnumerable<CommonMultiAndIdLanguageViewModel>)list11))
						{
							if (!oldCmpInfo.cmpGroupIdIII.HasValue)
							{
								arg7 = MyResource.GetResourceString("LblNoValue", lang6.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
							}
							else
							{
								CommonMultiAndIdLanguageViewModel commonMultiAndIdLanguageViewModel7 = Enumerable.FirstOrDefault<CommonMultiAndIdLanguageViewModel>((IEnumerable<CommonMultiAndIdLanguageViewModel>)list11, (Func<CommonMultiAndIdLanguageViewModel, bool>)((CommonMultiAndIdLanguageViewModel m) => m.Id == oldCmpInfo.cmpGroupIdIII && m.LanguageId == lang6.LanguageID));
								if (commonMultiAndIdLanguageViewModel7 != null)
								{
									arg7 = commonMultiAndIdLanguageViewModel7.Value ?? "";
								}
							}
							if (!newCmpInfo.cmpGroupIdIII.HasValue)
							{
								arg8 = MyResource.GetResourceString("LblNoValue", lang6.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
							}
							else
							{
								CommonMultiAndIdLanguageViewModel commonMultiAndIdLanguageViewModel8 = Enumerable.FirstOrDefault<CommonMultiAndIdLanguageViewModel>((IEnumerable<CommonMultiAndIdLanguageViewModel>)list11, (Func<CommonMultiAndIdLanguageViewModel, bool>)((CommonMultiAndIdLanguageViewModel m) => m.Id == newCmpInfo.cmpGroupIdIII && m.LanguageId == lang6.LanguageID));
								if (commonMultiAndIdLanguageViewModel8 != null)
								{
									arg8 = commonMultiAndIdLanguageViewModel8.Value ?? "";
								}
							}
							crmCompanyChangeHistoryLangViewModel4.Desc = string.Format(MyResource.GetResourceString("cmpChangeHistoryDescChangeGroupIII", lang6.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), arg7, arg8, text9);
						}
					}
					list.Add(crmCompanyChangeHistoryLangViewModel4);
				}
				text4 = "";
				text5 = "";
				if (list != null && Enumerable.Any<CrmCompanyChangeHistoryLangViewModel>((IEnumerable<CrmCompanyChangeHistoryLangViewModel>)list))
				{
					text4 = (Enumerable.Any<CrmCompanyChangeHistoryLangViewModel>((IEnumerable<CrmCompanyChangeHistoryLangViewModel>)list, (Func<CrmCompanyChangeHistoryLangViewModel, bool>)((CrmCompanyChangeHistoryLangViewModel c) => c.LanguageID == defLangID)) ? Enumerable.FirstOrDefault<CrmCompanyChangeHistoryLangViewModel>((IEnumerable<CrmCompanyChangeHistoryLangViewModel>)list, (Func<CrmCompanyChangeHistoryLangViewModel, bool>)((CrmCompanyChangeHistoryLangViewModel c) => c.LanguageID == defLangID)).Desc : "");
					text5 = JsonConvert.SerializeObject(Enumerable.ToList<CrmCompanyChangeHistoryLangViewModel>(Enumerable.Where<CrmCompanyChangeHistoryLangViewModel>((IEnumerable<CrmCompanyChangeHistoryLangViewModel>)list, (Func<CrmCompanyChangeHistoryLangViewModel, bool>)((CrmCompanyChangeHistoryLangViewModel c) => c.LanguageID != defLangID))));
				}
				ObjectParameter insertedId4 = new ObjectParameter("insertedId", 0);
				cRMSpIEntities.CRMspInsertCompanyChangeHistory(cmpId, text, text2, text3, text4, text5, userId, now, registerDatePersian, appType, defLangID, insertedId4);
			}
			if (oldCmpInfo.cmpGroupIdIV != newCmpInfo.cmpGroupIdIV)
			{
				text = "cmpGroupIdIV";
				text2 = ((!oldCmpInfo.cmpGroupIdIV.HasValue) ? "" : oldCmpInfo.cmpGroupIdIV.ToString());
				text3 = ((!newCmpInfo.cmpGroupIdIV.HasValue) ? "" : newCmpInfo.cmpGroupIdIV.ToString());
				list = new List<CrmCompanyChangeHistoryLangViewModel>();
				List<CommonMultiAndIdLanguageViewModel> list14 = new List<CommonMultiAndIdLanguageViewModel>();
				List<CrmCompanyGroupsIV> list15 = Enumerable.ToList<CrmCompanyGroupsIV>((IEnumerable<CrmCompanyGroupsIV>)cRMTabelEntities.CrmCompanyGroupsIV);
				List<CrmCompanyGroupsIV_Lang> list16 = Enumerable.ToList<CrmCompanyGroupsIV_Lang>((IEnumerable<CrmCompanyGroupsIV_Lang>)cRMTabelEntities.CrmCompanyGroupsIV_Lang);
				if (list15 != null && Enumerable.Any<CrmCompanyGroupsIV>((IEnumerable<CrmCompanyGroupsIV>)list15))
				{
					foreach (CrmCompanyGroupsIV item31 in list15)
					{
						CommonMultiAndIdLanguageViewModel item9 = new CommonMultiAndIdLanguageViewModel
						{
							LanguageId = item31.LanguageID.GetValueOrDefault(),
							Value = item31.GroupIVName,
							Id = item31.CompanyGroupIVID
						};
						list14.Add(item9);
					}
				}
				if (list16 != null && Enumerable.Any<CrmCompanyGroupsIV_Lang>((IEnumerable<CrmCompanyGroupsIV_Lang>)list16))
				{
					foreach (CrmCompanyGroupsIV_Lang item32 in list16)
					{
						CommonMultiAndIdLanguageViewModel item10 = new CommonMultiAndIdLanguageViewModel
						{
							LanguageId = item32.LanguageID,
							Value = item32.GroupIVName,
							Id = item32.CompanyGroupIVID
						};
						list14.Add(item10);
					}
				}
				foreach (Languages lang5 in Enumerable.ToList<Languages>((IEnumerable<Languages>)Language.Get()))
				{
					CrmCompanyChangeHistoryLangViewModel crmCompanyChangeHistoryLangViewModel5 = new CrmCompanyChangeHistoryLangViewModel();
					crmCompanyChangeHistoryLangViewModel5.LanguageID = lang5.LanguageID;
					crmCompanyChangeHistoryLangViewModel5.OldValue = text2;
					crmCompanyChangeHistoryLangViewModel5.NewValue = text3;
					string text10 = "";
					CRMspSelectUsersById_Result cRMspSelectUsersById_Result5 = User.SelectUsersById(userId, -1, lang5.LanguageID, defLangID);
					if (cRMspSelectUsersById_Result5 != null)
					{
						text10 = cRMspSelectUsersById_Result5.FullName ?? "";
					}
					if (mode == 1)
					{
						crmCompanyChangeHistoryLangViewModel5.Desc = string.Format(MyResource.GetResourceString("cmpChangeHistoryDescRegisterByUser", lang5.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), text10);
					}
					else
					{
						string arg9 = "";
						string arg10 = "";
						if (list14 != null && Enumerable.Any<CommonMultiAndIdLanguageViewModel>((IEnumerable<CommonMultiAndIdLanguageViewModel>)list14))
						{
							if (!oldCmpInfo.cmpGroupIdIV.HasValue)
							{
								arg9 = MyResource.GetResourceString("LblNoValue", lang5.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
							}
							else
							{
								CommonMultiAndIdLanguageViewModel commonMultiAndIdLanguageViewModel9 = Enumerable.FirstOrDefault<CommonMultiAndIdLanguageViewModel>((IEnumerable<CommonMultiAndIdLanguageViewModel>)list14, (Func<CommonMultiAndIdLanguageViewModel, bool>)((CommonMultiAndIdLanguageViewModel m) => m.Id == oldCmpInfo.cmpGroupIdIV && m.LanguageId == lang5.LanguageID));
								if (commonMultiAndIdLanguageViewModel9 != null)
								{
									arg9 = commonMultiAndIdLanguageViewModel9.Value ?? "";
								}
							}
							if (!newCmpInfo.cmpGroupIdIV.HasValue)
							{
								arg10 = MyResource.GetResourceString("LblNoValue", lang5.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
							}
							else
							{
								CommonMultiAndIdLanguageViewModel commonMultiAndIdLanguageViewModel10 = Enumerable.FirstOrDefault<CommonMultiAndIdLanguageViewModel>((IEnumerable<CommonMultiAndIdLanguageViewModel>)list14, (Func<CommonMultiAndIdLanguageViewModel, bool>)((CommonMultiAndIdLanguageViewModel m) => m.Id == newCmpInfo.cmpGroupIdIV && m.LanguageId == lang5.LanguageID));
								if (commonMultiAndIdLanguageViewModel10 != null)
								{
									arg10 = commonMultiAndIdLanguageViewModel10.Value ?? "";
								}
							}
							crmCompanyChangeHistoryLangViewModel5.Desc = string.Format(MyResource.GetResourceString("cmpChangeHistoryDescChangeGroupIV", lang5.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), arg9, arg10, text10);
						}
					}
					list.Add(crmCompanyChangeHistoryLangViewModel5);
				}
				text4 = "";
				text5 = "";
				if (list != null && Enumerable.Any<CrmCompanyChangeHistoryLangViewModel>((IEnumerable<CrmCompanyChangeHistoryLangViewModel>)list))
				{
					text4 = (Enumerable.Any<CrmCompanyChangeHistoryLangViewModel>((IEnumerable<CrmCompanyChangeHistoryLangViewModel>)list, (Func<CrmCompanyChangeHistoryLangViewModel, bool>)((CrmCompanyChangeHistoryLangViewModel c) => c.LanguageID == defLangID)) ? Enumerable.FirstOrDefault<CrmCompanyChangeHistoryLangViewModel>((IEnumerable<CrmCompanyChangeHistoryLangViewModel>)list, (Func<CrmCompanyChangeHistoryLangViewModel, bool>)((CrmCompanyChangeHistoryLangViewModel c) => c.LanguageID == defLangID)).Desc : "");
					text5 = JsonConvert.SerializeObject(Enumerable.ToList<CrmCompanyChangeHistoryLangViewModel>(Enumerable.Where<CrmCompanyChangeHistoryLangViewModel>((IEnumerable<CrmCompanyChangeHistoryLangViewModel>)list, (Func<CrmCompanyChangeHistoryLangViewModel, bool>)((CrmCompanyChangeHistoryLangViewModel c) => c.LanguageID != defLangID))));
				}
				ObjectParameter insertedId5 = new ObjectParameter("insertedId", 0);
				cRMSpIEntities.CRMspInsertCompanyChangeHistory(cmpId, text, text2, text3, text4, text5, userId, now, registerDatePersian, appType, defLangID, insertedId5);
			}
			if (oldCmpInfo.cmpTypeId != newCmpInfo.cmpTypeId)
			{
				text = "cmpTypeId";
				text2 = ((!oldCmpInfo.cmpTypeId.HasValue) ? "" : oldCmpInfo.cmpTypeId.ToString());
				text3 = ((!newCmpInfo.cmpTypeId.HasValue) ? "" : newCmpInfo.cmpTypeId.ToString());
				list = new List<CrmCompanyChangeHistoryLangViewModel>();
				List<CommonMultiAndIdLanguageViewModel> list17 = new List<CommonMultiAndIdLanguageViewModel>();
				List<CrmCompanyType> list18 = Enumerable.ToList<CrmCompanyType>((IEnumerable<CrmCompanyType>)cRMTabelEntities.CrmCompanyType);
				List<CrmCompanyType_Lang> list19 = Enumerable.ToList<CrmCompanyType_Lang>((IEnumerable<CrmCompanyType_Lang>)cRMTabelEntities.CrmCompanyType_Lang);
				if (list18 != null && Enumerable.Any<CrmCompanyType>((IEnumerable<CrmCompanyType>)list18))
				{
					foreach (CrmCompanyType item33 in list18)
					{
						CommonMultiAndIdLanguageViewModel item11 = new CommonMultiAndIdLanguageViewModel
						{
							LanguageId = item33.LanguageID.GetValueOrDefault(),
							Value = item33.CompanyTypeName,
							Id = item33.CompanyTypeID
						};
						list17.Add(item11);
					}
				}
				if (list19 != null && Enumerable.Any<CrmCompanyType_Lang>((IEnumerable<CrmCompanyType_Lang>)list19))
				{
					foreach (CrmCompanyType_Lang item34 in list19)
					{
						CommonMultiAndIdLanguageViewModel item12 = new CommonMultiAndIdLanguageViewModel
						{
							LanguageId = item34.LanguageID,
							Value = item34.CompanyTypeName,
							Id = item34.CompanyTypeID
						};
						list17.Add(item12);
					}
				}
				foreach (Languages lang4 in Enumerable.ToList<Languages>((IEnumerable<Languages>)Language.Get()))
				{
					CrmCompanyChangeHistoryLangViewModel crmCompanyChangeHistoryLangViewModel6 = new CrmCompanyChangeHistoryLangViewModel();
					crmCompanyChangeHistoryLangViewModel6.LanguageID = lang4.LanguageID;
					crmCompanyChangeHistoryLangViewModel6.OldValue = text2;
					crmCompanyChangeHistoryLangViewModel6.NewValue = text3;
					string text11 = "";
					CRMspSelectUsersById_Result cRMspSelectUsersById_Result6 = User.SelectUsersById(userId, -1, lang4.LanguageID, defLangID);
					if (cRMspSelectUsersById_Result6 != null)
					{
						text11 = cRMspSelectUsersById_Result6.FullName ?? "";
					}
					if (mode == 1)
					{
						crmCompanyChangeHistoryLangViewModel6.Desc = string.Format(MyResource.GetResourceString("cmpChangeHistoryDescRegisterByUser", lang4.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), text11);
					}
					else
					{
						string arg11 = "";
						string arg12 = "";
						if (list17 != null && Enumerable.Any<CommonMultiAndIdLanguageViewModel>((IEnumerable<CommonMultiAndIdLanguageViewModel>)list17))
						{
							if (!oldCmpInfo.cmpTypeId.HasValue)
							{
								arg11 = MyResource.GetResourceString("LblNoValue", lang4.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
							}
							else
							{
								CommonMultiAndIdLanguageViewModel commonMultiAndIdLanguageViewModel11 = Enumerable.FirstOrDefault<CommonMultiAndIdLanguageViewModel>((IEnumerable<CommonMultiAndIdLanguageViewModel>)list17, (Func<CommonMultiAndIdLanguageViewModel, bool>)((CommonMultiAndIdLanguageViewModel m) => m.Id == oldCmpInfo.cmpTypeId && m.LanguageId == lang4.LanguageID));
								if (commonMultiAndIdLanguageViewModel11 != null)
								{
									arg11 = commonMultiAndIdLanguageViewModel11.Value ?? "";
								}
							}
							if (!newCmpInfo.cmpTypeId.HasValue)
							{
								arg12 = MyResource.GetResourceString("LblNoValue", lang4.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
							}
							else
							{
								CommonMultiAndIdLanguageViewModel commonMultiAndIdLanguageViewModel12 = Enumerable.FirstOrDefault<CommonMultiAndIdLanguageViewModel>((IEnumerable<CommonMultiAndIdLanguageViewModel>)list17, (Func<CommonMultiAndIdLanguageViewModel, bool>)((CommonMultiAndIdLanguageViewModel m) => m.Id == newCmpInfo.cmpTypeId && m.LanguageId == lang4.LanguageID));
								if (commonMultiAndIdLanguageViewModel12 != null)
								{
									arg12 = commonMultiAndIdLanguageViewModel12.Value ?? "";
								}
							}
							crmCompanyChangeHistoryLangViewModel6.Desc = string.Format(MyResource.GetResourceString("cmpChangeHistoryDescChangeType", lang4.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), arg11, arg12, text11);
						}
					}
					list.Add(crmCompanyChangeHistoryLangViewModel6);
				}
				text4 = "";
				text5 = "";
				if (list != null && Enumerable.Any<CrmCompanyChangeHistoryLangViewModel>((IEnumerable<CrmCompanyChangeHistoryLangViewModel>)list))
				{
					text4 = (Enumerable.Any<CrmCompanyChangeHistoryLangViewModel>((IEnumerable<CrmCompanyChangeHistoryLangViewModel>)list, (Func<CrmCompanyChangeHistoryLangViewModel, bool>)((CrmCompanyChangeHistoryLangViewModel c) => c.LanguageID == defLangID)) ? Enumerable.FirstOrDefault<CrmCompanyChangeHistoryLangViewModel>((IEnumerable<CrmCompanyChangeHistoryLangViewModel>)list, (Func<CrmCompanyChangeHistoryLangViewModel, bool>)((CrmCompanyChangeHistoryLangViewModel c) => c.LanguageID == defLangID)).Desc : "");
					text5 = JsonConvert.SerializeObject(Enumerable.ToList<CrmCompanyChangeHistoryLangViewModel>(Enumerable.Where<CrmCompanyChangeHistoryLangViewModel>((IEnumerable<CrmCompanyChangeHistoryLangViewModel>)list, (Func<CrmCompanyChangeHistoryLangViewModel, bool>)((CrmCompanyChangeHistoryLangViewModel c) => c.LanguageID != defLangID))));
				}
				ObjectParameter insertedId6 = new ObjectParameter("insertedId", 0);
				cRMSpIEntities.CRMspInsertCompanyChangeHistory(cmpId, text, text2, text3, text4, text5, userId, now, registerDatePersian, appType, defLangID, insertedId6);
			}
			if (oldCmpInfo.cmpPresentationId != newCmpInfo.cmpPresentationId)
			{
				text = "cmpPresentationId";
				text2 = ((!oldCmpInfo.cmpPresentationId.HasValue) ? "" : oldCmpInfo.cmpPresentationId.ToString());
				text3 = ((!newCmpInfo.cmpPresentationId.HasValue) ? "" : newCmpInfo.cmpPresentationId.ToString());
				list = new List<CrmCompanyChangeHistoryLangViewModel>();
				List<CommonMultiAndIdLanguageViewModel> list20 = new List<CommonMultiAndIdLanguageViewModel>();
				List<CrmCompanyPresentation> list21 = Enumerable.ToList<CrmCompanyPresentation>((IEnumerable<CrmCompanyPresentation>)cRMTabelEntities.CrmCompanyPresentation);
				List<CrmCompanyPresentation_Lang> list22 = Enumerable.ToList<CrmCompanyPresentation_Lang>((IEnumerable<CrmCompanyPresentation_Lang>)cRMTabelEntities.CrmCompanyPresentation_Lang);
				if (list21 != null && Enumerable.Any<CrmCompanyPresentation>((IEnumerable<CrmCompanyPresentation>)list21))
				{
					foreach (CrmCompanyPresentation item35 in list21)
					{
						CommonMultiAndIdLanguageViewModel item13 = new CommonMultiAndIdLanguageViewModel
						{
							LanguageId = item35.LanguageID.GetValueOrDefault(),
							Value = item35.Presentation,
							Id = item35.CompanyPresentationID
						};
						list20.Add(item13);
					}
				}
				if (list22 != null && Enumerable.Any<CrmCompanyPresentation_Lang>((IEnumerable<CrmCompanyPresentation_Lang>)list22))
				{
					foreach (CrmCompanyPresentation_Lang item36 in list22)
					{
						CommonMultiAndIdLanguageViewModel item14 = new CommonMultiAndIdLanguageViewModel
						{
							LanguageId = item36.LanguageID,
							Value = item36.Presentation,
							Id = item36.CompanyPresentationID
						};
						list20.Add(item14);
					}
				}
				foreach (Languages lang3 in Enumerable.ToList<Languages>((IEnumerable<Languages>)Language.Get()))
				{
					CrmCompanyChangeHistoryLangViewModel crmCompanyChangeHistoryLangViewModel7 = new CrmCompanyChangeHistoryLangViewModel();
					crmCompanyChangeHistoryLangViewModel7.LanguageID = lang3.LanguageID;
					crmCompanyChangeHistoryLangViewModel7.OldValue = text2;
					crmCompanyChangeHistoryLangViewModel7.NewValue = text3;
					string text12 = "";
					CRMspSelectUsersById_Result cRMspSelectUsersById_Result7 = User.SelectUsersById(userId, -1, lang3.LanguageID, defLangID);
					if (cRMspSelectUsersById_Result7 != null)
					{
						text12 = cRMspSelectUsersById_Result7.FullName ?? "";
					}
					if (mode == 1)
					{
						crmCompanyChangeHistoryLangViewModel7.Desc = string.Format(MyResource.GetResourceString("cmpChangeHistoryDescRegisterByUser", lang3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), text12);
					}
					else
					{
						string arg13 = "";
						string arg14 = "";
						if (list20 != null && Enumerable.Any<CommonMultiAndIdLanguageViewModel>((IEnumerable<CommonMultiAndIdLanguageViewModel>)list20))
						{
							if (!oldCmpInfo.cmpPresentationId.HasValue)
							{
								arg13 = MyResource.GetResourceString("LblNoValue", lang3.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
							}
							else
							{
								CommonMultiAndIdLanguageViewModel commonMultiAndIdLanguageViewModel13 = Enumerable.FirstOrDefault<CommonMultiAndIdLanguageViewModel>((IEnumerable<CommonMultiAndIdLanguageViewModel>)list20, (Func<CommonMultiAndIdLanguageViewModel, bool>)((CommonMultiAndIdLanguageViewModel m) => m.Id == oldCmpInfo.cmpPresentationId && m.LanguageId == lang3.LanguageID));
								if (commonMultiAndIdLanguageViewModel13 != null)
								{
									arg13 = commonMultiAndIdLanguageViewModel13.Value ?? "";
								}
							}
							if (!newCmpInfo.cmpPresentationId.HasValue)
							{
								arg14 = MyResource.GetResourceString("LblNoValue", lang3.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
							}
							else
							{
								CommonMultiAndIdLanguageViewModel commonMultiAndIdLanguageViewModel14 = Enumerable.FirstOrDefault<CommonMultiAndIdLanguageViewModel>((IEnumerable<CommonMultiAndIdLanguageViewModel>)list20, (Func<CommonMultiAndIdLanguageViewModel, bool>)((CommonMultiAndIdLanguageViewModel m) => m.Id == newCmpInfo.cmpPresentationId && m.LanguageId == lang3.LanguageID));
								if (commonMultiAndIdLanguageViewModel14 != null)
								{
									arg14 = commonMultiAndIdLanguageViewModel14.Value ?? "";
								}
							}
							crmCompanyChangeHistoryLangViewModel7.Desc = string.Format(MyResource.GetResourceString("cmpChangeHistoryDescChangePresentation", lang3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), arg13, arg14, text12);
						}
					}
					list.Add(crmCompanyChangeHistoryLangViewModel7);
				}
				text4 = "";
				text5 = "";
				if (list != null && Enumerable.Any<CrmCompanyChangeHistoryLangViewModel>((IEnumerable<CrmCompanyChangeHistoryLangViewModel>)list))
				{
					text4 = (Enumerable.Any<CrmCompanyChangeHistoryLangViewModel>((IEnumerable<CrmCompanyChangeHistoryLangViewModel>)list, (Func<CrmCompanyChangeHistoryLangViewModel, bool>)((CrmCompanyChangeHistoryLangViewModel c) => c.LanguageID == defLangID)) ? Enumerable.FirstOrDefault<CrmCompanyChangeHistoryLangViewModel>((IEnumerable<CrmCompanyChangeHistoryLangViewModel>)list, (Func<CrmCompanyChangeHistoryLangViewModel, bool>)((CrmCompanyChangeHistoryLangViewModel c) => c.LanguageID == defLangID)).Desc : "");
					text5 = JsonConvert.SerializeObject(Enumerable.ToList<CrmCompanyChangeHistoryLangViewModel>(Enumerable.Where<CrmCompanyChangeHistoryLangViewModel>((IEnumerable<CrmCompanyChangeHistoryLangViewModel>)list, (Func<CrmCompanyChangeHistoryLangViewModel, bool>)((CrmCompanyChangeHistoryLangViewModel c) => c.LanguageID != defLangID))));
				}
				ObjectParameter insertedId7 = new ObjectParameter("insertedId", 0);
				cRMSpIEntities.CRMspInsertCompanyChangeHistory(cmpId, text, text2, text3, text4, text5, userId, now, registerDatePersian, appType, defLangID, insertedId7);
			}
			if (oldCmpInfo.cmpReferUserId != newCmpInfo.cmpReferUserId)
			{
				text = "cmpReferUserId";
				text2 = ((oldCmpInfo.cmpReferUserId == 0) ? "" : oldCmpInfo.cmpReferUserId.ToString());
				text3 = ((newCmpInfo.cmpReferUserId == 0) ? "" : newCmpInfo.cmpReferUserId.ToString());
				list = new List<CrmCompanyChangeHistoryLangViewModel>();
				foreach (Languages item37 in Enumerable.ToList<Languages>((IEnumerable<Languages>)Language.Get()))
				{
					CrmCompanyChangeHistoryLangViewModel crmCompanyChangeHistoryLangViewModel8 = new CrmCompanyChangeHistoryLangViewModel();
					crmCompanyChangeHistoryLangViewModel8.LanguageID = item37.LanguageID;
					crmCompanyChangeHistoryLangViewModel8.OldValue = text2;
					crmCompanyChangeHistoryLangViewModel8.NewValue = text3;
					string text13 = "";
					CRMspSelectUsersById_Result cRMspSelectUsersById_Result8 = User.SelectUsersById(userId, -1, item37.LanguageID, defLangID);
					if (cRMspSelectUsersById_Result8 != null)
					{
						text13 = cRMspSelectUsersById_Result8.FullName ?? "";
					}
					if (mode == 1)
					{
						crmCompanyChangeHistoryLangViewModel8.Desc = string.Format(MyResource.GetResourceString("cmpChangeHistoryDescRegisterByUser", item37.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), text13);
					}
					else
					{
						string arg15 = "";
						string arg16 = "";
						_ = oldCmpInfo.cmpReferUserId;
						CRMspSelectUsersById_Result cRMspSelectUsersById_Result9 = User.SelectUsersById(oldCmpInfo.cmpReferUserId, -1, item37.LanguageID, defLangID);
						if (cRMspSelectUsersById_Result9 != null)
						{
							arg15 = cRMspSelectUsersById_Result9.FullName ?? "";
						}
						_ = newCmpInfo.cmpReferUserId;
						CRMspSelectUsersById_Result cRMspSelectUsersById_Result10 = User.SelectUsersById(newCmpInfo.cmpReferUserId, -1, item37.LanguageID, defLangID);
						if (cRMspSelectUsersById_Result10 != null)
						{
							arg16 = cRMspSelectUsersById_Result10.FullName ?? "";
						}
						crmCompanyChangeHistoryLangViewModel8.Desc = string.Format(MyResource.GetResourceString("cmpChangeHistoryDescChangeReferUser", item37.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), arg15, arg16, text13);
					}
					list.Add(crmCompanyChangeHistoryLangViewModel8);
				}
				text4 = "";
				text5 = "";
				if (list != null && Enumerable.Any<CrmCompanyChangeHistoryLangViewModel>((IEnumerable<CrmCompanyChangeHistoryLangViewModel>)list))
				{
					text4 = (Enumerable.Any<CrmCompanyChangeHistoryLangViewModel>((IEnumerable<CrmCompanyChangeHistoryLangViewModel>)list, (Func<CrmCompanyChangeHistoryLangViewModel, bool>)((CrmCompanyChangeHistoryLangViewModel c) => c.LanguageID == defLangID)) ? Enumerable.FirstOrDefault<CrmCompanyChangeHistoryLangViewModel>((IEnumerable<CrmCompanyChangeHistoryLangViewModel>)list, (Func<CrmCompanyChangeHistoryLangViewModel, bool>)((CrmCompanyChangeHistoryLangViewModel c) => c.LanguageID == defLangID)).Desc : "");
					text5 = JsonConvert.SerializeObject(Enumerable.ToList<CrmCompanyChangeHistoryLangViewModel>(Enumerable.Where<CrmCompanyChangeHistoryLangViewModel>((IEnumerable<CrmCompanyChangeHistoryLangViewModel>)list, (Func<CrmCompanyChangeHistoryLangViewModel, bool>)((CrmCompanyChangeHistoryLangViewModel c) => c.LanguageID != defLangID))));
				}
				ObjectParameter insertedId8 = new ObjectParameter("insertedId", 0);
				cRMSpIEntities.CRMspInsertCompanyChangeHistory(cmpId, text, text2, text3, text4, text5, userId, now, registerDatePersian, appType, defLangID, insertedId8);
			}
			if (oldCmpInfo.cmpSuppUserId != newCmpInfo.cmpSuppUserId)
			{
				text = "cmpSuppUserId";
				text2 = ((!oldCmpInfo.cmpSuppUserId.HasValue) ? "" : oldCmpInfo.cmpSuppUserId.ToString());
				text3 = ((!newCmpInfo.cmpSuppUserId.HasValue) ? "" : newCmpInfo.cmpSuppUserId.ToString());
				list = new List<CrmCompanyChangeHistoryLangViewModel>();
				foreach (Languages item38 in Enumerable.ToList<Languages>((IEnumerable<Languages>)Language.Get()))
				{
					CrmCompanyChangeHistoryLangViewModel crmCompanyChangeHistoryLangViewModel9 = new CrmCompanyChangeHistoryLangViewModel();
					crmCompanyChangeHistoryLangViewModel9.LanguageID = item38.LanguageID;
					crmCompanyChangeHistoryLangViewModel9.OldValue = text2;
					crmCompanyChangeHistoryLangViewModel9.NewValue = text3;
					string text14 = "";
					CRMspSelectUsersById_Result cRMspSelectUsersById_Result11 = User.SelectUsersById(userId, -1, item38.LanguageID, defLangID);
					if (cRMspSelectUsersById_Result11 != null)
					{
						text14 = cRMspSelectUsersById_Result11.FullName ?? "";
					}
					if (mode == 1)
					{
						crmCompanyChangeHistoryLangViewModel9.Desc = string.Format(MyResource.GetResourceString("cmpChangeHistoryDescRegisterByUser", item38.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), text14);
					}
					else
					{
						string arg17 = "";
						string arg18 = "";
						if (!oldCmpInfo.cmpSuppUserId.HasValue)
						{
							arg17 = MyResource.GetResourceString("LblNoValue", item38.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
						}
						else
						{
							CRMspSelectUsersById_Result cRMspSelectUsersById_Result12 = User.SelectUsersById(oldCmpInfo.cmpSuppUserId.GetValueOrDefault(), -1, item38.LanguageID, defLangID);
							if (cRMspSelectUsersById_Result12 != null)
							{
								arg17 = cRMspSelectUsersById_Result12.FullName ?? "";
							}
						}
						if (!newCmpInfo.cmpSuppUserId.HasValue)
						{
							arg18 = MyResource.GetResourceString("LblNoValue", item38.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
						}
						else
						{
							CRMspSelectUsersById_Result cRMspSelectUsersById_Result13 = User.SelectUsersById(newCmpInfo.cmpSuppUserId.GetValueOrDefault(), -1, item38.LanguageID, defLangID);
							if (cRMspSelectUsersById_Result13 != null)
							{
								arg18 = cRMspSelectUsersById_Result13.FullName ?? "";
							}
						}
						crmCompanyChangeHistoryLangViewModel9.Desc = string.Format(MyResource.GetResourceString("cmpChangeHistoryDescChangeSuppUser", item38.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), arg17, arg18, text14);
					}
					list.Add(crmCompanyChangeHistoryLangViewModel9);
				}
				text4 = "";
				text5 = "";
				if (list != null && Enumerable.Any<CrmCompanyChangeHistoryLangViewModel>((IEnumerable<CrmCompanyChangeHistoryLangViewModel>)list))
				{
					text4 = (Enumerable.Any<CrmCompanyChangeHistoryLangViewModel>((IEnumerable<CrmCompanyChangeHistoryLangViewModel>)list, (Func<CrmCompanyChangeHistoryLangViewModel, bool>)((CrmCompanyChangeHistoryLangViewModel c) => c.LanguageID == defLangID)) ? Enumerable.FirstOrDefault<CrmCompanyChangeHistoryLangViewModel>((IEnumerable<CrmCompanyChangeHistoryLangViewModel>)list, (Func<CrmCompanyChangeHistoryLangViewModel, bool>)((CrmCompanyChangeHistoryLangViewModel c) => c.LanguageID == defLangID)).Desc : "");
					text5 = JsonConvert.SerializeObject(Enumerable.ToList<CrmCompanyChangeHistoryLangViewModel>(Enumerable.Where<CrmCompanyChangeHistoryLangViewModel>((IEnumerable<CrmCompanyChangeHistoryLangViewModel>)list, (Func<CrmCompanyChangeHistoryLangViewModel, bool>)((CrmCompanyChangeHistoryLangViewModel c) => c.LanguageID != defLangID))));
				}
				ObjectParameter insertedId9 = new ObjectParameter("insertedId", 0);
				cRMSpIEntities.CRMspInsertCompanyChangeHistory(cmpId, text, text2, text3, text4, text5, userId, now, registerDatePersian, appType, defLangID, insertedId9);
			}
			List<CommonMultiSelectorViewModel> list23 = new List<CommonMultiSelectorViewModel>();
			List<CommonMultiSelectorViewModel> list24 = new List<CommonMultiSelectorViewModel>();
			if (!string.IsNullOrWhiteSpace(oldCmpInfo.cmpCampaignIds))
			{
				if (oldCmpInfo.cmpCampaignIds.EndsWith(","))
				{
					oldCmpInfo.cmpCampaignIds = oldCmpInfo.cmpCampaignIds.TrimEnd(new char[1] { ',' });
				}
				if (oldCmpInfo.cmpCampaignIds.StartsWith(","))
				{
					oldCmpInfo.cmpCampaignIds = oldCmpInfo.cmpCampaignIds.TrimStart(new char[1] { ',' });
				}
				if (!string.IsNullOrWhiteSpace(oldCmpInfo.cmpCampaignIds))
				{
					string[] array = oldCmpInfo.cmpCampaignIds.Split(new char[1] { ',' });
					if (array != null && array.Length != 0)
					{
						for (int i = 0; i < array.Length; i++)
						{
							int result2 = 0;
							int.TryParse(array[i], out result2);
							if (result2 != 0)
							{
								CommonMultiSelectorViewModel item15 = new CommonMultiSelectorViewModel
								{
									Id = result2
								};
								list23.Add(item15);
							}
						}
					}
					if (list23 != null && Enumerable.Any<CommonMultiSelectorViewModel>((IEnumerable<CommonMultiSelectorViewModel>)list23))
					{
						list23 = Enumerable.ToList<CommonMultiSelectorViewModel>((IEnumerable<CommonMultiSelectorViewModel>)Enumerable.OrderBy<CommonMultiSelectorViewModel, int>((IEnumerable<CommonMultiSelectorViewModel>)list23, (Func<CommonMultiSelectorViewModel, int>)((CommonMultiSelectorViewModel m) => m.Id)));
						string text15 = "";
						foreach (CommonMultiSelectorViewModel item39 in list23)
						{
							text15 = text15 + item39.Id + ",";
						}
						oldCmpInfo.cmpCampaignIds = text15;
						if (oldCmpInfo.cmpCampaignIds.EndsWith(","))
						{
							oldCmpInfo.cmpCampaignIds = oldCmpInfo.cmpCampaignIds.TrimEnd(new char[1] { ',' });
						}
						if (oldCmpInfo.cmpCampaignIds.StartsWith(","))
						{
							oldCmpInfo.cmpCampaignIds = oldCmpInfo.cmpCampaignIds.TrimStart(new char[1] { ',' });
						}
					}
				}
			}
			if (!string.IsNullOrWhiteSpace(newCmpInfo.cmpCampaignIds))
			{
				if (newCmpInfo.cmpCampaignIds.EndsWith(","))
				{
					newCmpInfo.cmpCampaignIds = newCmpInfo.cmpCampaignIds.TrimEnd(new char[1] { ',' });
				}
				if (newCmpInfo.cmpCampaignIds.StartsWith(","))
				{
					newCmpInfo.cmpCampaignIds = newCmpInfo.cmpCampaignIds.TrimStart(new char[1] { ',' });
				}
				if (!string.IsNullOrWhiteSpace(newCmpInfo.cmpCampaignIds))
				{
					string[] array2 = newCmpInfo.cmpCampaignIds.Split(new char[1] { ',' });
					if (array2 != null && array2.Length != 0)
					{
						for (int j = 0; j < array2.Length; j++)
						{
							int result3 = 0;
							int.TryParse(array2[j], out result3);
							if (result3 != 0)
							{
								CommonMultiSelectorViewModel item16 = new CommonMultiSelectorViewModel
								{
									Id = result3
								};
								list24.Add(item16);
							}
						}
					}
					if (list24 != null && Enumerable.Any<CommonMultiSelectorViewModel>((IEnumerable<CommonMultiSelectorViewModel>)list24))
					{
						list24 = Enumerable.ToList<CommonMultiSelectorViewModel>((IEnumerable<CommonMultiSelectorViewModel>)Enumerable.OrderBy<CommonMultiSelectorViewModel, int>((IEnumerable<CommonMultiSelectorViewModel>)list24, (Func<CommonMultiSelectorViewModel, int>)((CommonMultiSelectorViewModel m) => m.Id)));
						string text16 = "";
						foreach (CommonMultiSelectorViewModel item40 in list24)
						{
							text16 = text16 + item40.Id + ",";
						}
						newCmpInfo.cmpCampaignIds = text16;
						if (newCmpInfo.cmpCampaignIds.EndsWith(","))
						{
							newCmpInfo.cmpCampaignIds = newCmpInfo.cmpCampaignIds.TrimEnd(new char[1] { ',' });
						}
						if (newCmpInfo.cmpCampaignIds.StartsWith(","))
						{
							newCmpInfo.cmpCampaignIds = newCmpInfo.cmpCampaignIds.TrimStart(new char[1] { ',' });
						}
					}
				}
			}
			if (oldCmpInfo.cmpCampaignIds != newCmpInfo.cmpCampaignIds)
			{
				text = "cmpCampaignIds";
				text2 = (string.IsNullOrWhiteSpace(oldCmpInfo.cmpCampaignIds) ? "" : oldCmpInfo.cmpCampaignIds);
				text3 = (string.IsNullOrWhiteSpace(newCmpInfo.cmpCampaignIds) ? "" : newCmpInfo.cmpCampaignIds);
				list = new List<CrmCompanyChangeHistoryLangViewModel>();
				List<CommonMultiAndIdLanguageViewModel> list25 = new List<CommonMultiAndIdLanguageViewModel>();
				List<CrmCompanyCampaign> list26 = Enumerable.ToList<CrmCompanyCampaign>((IEnumerable<CrmCompanyCampaign>)cRMTabelEntities.CrmCompanyCampaign);
				List<CrmCompanyCampaign_Lang> list27 = Enumerable.ToList<CrmCompanyCampaign_Lang>((IEnumerable<CrmCompanyCampaign_Lang>)cRMTabelEntities.CrmCompanyCampaign_Lang);
				if (list26 != null && Enumerable.Any<CrmCompanyCampaign>((IEnumerable<CrmCompanyCampaign>)list26))
				{
					foreach (CrmCompanyCampaign item41 in list26)
					{
						CommonMultiAndIdLanguageViewModel item17 = new CommonMultiAndIdLanguageViewModel
						{
							LanguageId = item41.LanguageID,
							Value = item41.CampaignName,
							Id = item41.CompanyCampaignId
						};
						list25.Add(item17);
					}
				}
				if (list27 != null && Enumerable.Any<CrmCompanyCampaign_Lang>((IEnumerable<CrmCompanyCampaign_Lang>)list27))
				{
					foreach (CrmCompanyCampaign_Lang item42 in list27)
					{
						CommonMultiAndIdLanguageViewModel item18 = new CommonMultiAndIdLanguageViewModel
						{
							LanguageId = item42.LanguageID,
							Value = item42.CampaignName,
							Id = item42.CompanyCampaignId
						};
						list25.Add(item18);
					}
				}
				foreach (Languages lang2 in Enumerable.ToList<Languages>((IEnumerable<Languages>)Language.Get()))
				{
					CrmCompanyChangeHistoryLangViewModel crmCompanyChangeHistoryLangViewModel10 = new CrmCompanyChangeHistoryLangViewModel();
					crmCompanyChangeHistoryLangViewModel10.LanguageID = lang2.LanguageID;
					crmCompanyChangeHistoryLangViewModel10.OldValue = text2;
					crmCompanyChangeHistoryLangViewModel10.NewValue = text3;
					string text17 = "";
					CRMspSelectUsersById_Result cRMspSelectUsersById_Result14 = User.SelectUsersById(userId, -1, lang2.LanguageID, defLangID);
					if (cRMspSelectUsersById_Result14 != null)
					{
						text17 = cRMspSelectUsersById_Result14.FullName ?? "";
					}
					if (mode == 1)
					{
						crmCompanyChangeHistoryLangViewModel10.Desc = string.Format(MyResource.GetResourceString("cmpChangeHistoryDescRegisterByUser", lang2.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), text17);
					}
					else
					{
						string text18 = "";
						string text19 = "";
						if (list25 != null && Enumerable.Any<CommonMultiAndIdLanguageViewModel>((IEnumerable<CommonMultiAndIdLanguageViewModel>)list25))
						{
							if (string.IsNullOrWhiteSpace(oldCmpInfo.cmpCampaignIds))
							{
								text18 = MyResource.GetResourceString("LblNoValue", lang2.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
							}
							else if (list23 != null && Enumerable.Any<CommonMultiSelectorViewModel>((IEnumerable<CommonMultiSelectorViewModel>)list23))
							{
								foreach (CommonMultiSelectorViewModel itemId4 in list23)
								{
									if (itemId4.Id != 0)
									{
										CommonMultiAndIdLanguageViewModel commonMultiAndIdLanguageViewModel15 = Enumerable.FirstOrDefault<CommonMultiAndIdLanguageViewModel>((IEnumerable<CommonMultiAndIdLanguageViewModel>)list25, (Func<CommonMultiAndIdLanguageViewModel, bool>)((CommonMultiAndIdLanguageViewModel m) => m.Id == itemId4.Id && m.LanguageId == lang2.LanguageID));
										if (commonMultiAndIdLanguageViewModel15 != null)
										{
											text18 = text18 + commonMultiAndIdLanguageViewModel15.Value + ",";
										}
									}
								}
								if (!string.IsNullOrWhiteSpace(text18))
								{
									if (text18.StartsWith(","))
									{
										text18 = text18.TrimStart(new char[1] { ',' });
									}
									if (text18.EndsWith(","))
									{
										text18 = text18.TrimEnd(new char[1] { ',' });
									}
								}
							}
							string.IsNullOrWhiteSpace(newCmpInfo.cmpCampaignIds);
							if (list24 != null && Enumerable.Any<CommonMultiSelectorViewModel>((IEnumerable<CommonMultiSelectorViewModel>)list24))
							{
								foreach (CommonMultiSelectorViewModel itemId3 in list24)
								{
									if (itemId3.Id != 0)
									{
										CommonMultiAndIdLanguageViewModel commonMultiAndIdLanguageViewModel16 = Enumerable.FirstOrDefault<CommonMultiAndIdLanguageViewModel>((IEnumerable<CommonMultiAndIdLanguageViewModel>)list25, (Func<CommonMultiAndIdLanguageViewModel, bool>)((CommonMultiAndIdLanguageViewModel m) => m.Id == itemId3.Id && m.LanguageId == lang2.LanguageID));
										if (commonMultiAndIdLanguageViewModel16 != null)
										{
											text19 = text19 + commonMultiAndIdLanguageViewModel16.Value + ",";
										}
									}
								}
								if (!string.IsNullOrWhiteSpace(text19))
								{
									if (text19.StartsWith(","))
									{
										text19 = text19.TrimStart(new char[1] { ',' });
									}
									if (text19.EndsWith(","))
									{
										text19 = text19.TrimEnd(new char[1] { ',' });
									}
								}
							}
							crmCompanyChangeHistoryLangViewModel10.Desc = string.Format(MyResource.GetResourceString("cmpChangeHistoryDescChangeCampaign", lang2.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), text18, text19, text17);
						}
					}
					list.Add(crmCompanyChangeHistoryLangViewModel10);
				}
				text4 = "";
				text5 = "";
				if (list != null && Enumerable.Any<CrmCompanyChangeHistoryLangViewModel>((IEnumerable<CrmCompanyChangeHistoryLangViewModel>)list))
				{
					text4 = (Enumerable.Any<CrmCompanyChangeHistoryLangViewModel>((IEnumerable<CrmCompanyChangeHistoryLangViewModel>)list, (Func<CrmCompanyChangeHistoryLangViewModel, bool>)((CrmCompanyChangeHistoryLangViewModel c) => c.LanguageID == defLangID)) ? Enumerable.FirstOrDefault<CrmCompanyChangeHistoryLangViewModel>((IEnumerable<CrmCompanyChangeHistoryLangViewModel>)list, (Func<CrmCompanyChangeHistoryLangViewModel, bool>)((CrmCompanyChangeHistoryLangViewModel c) => c.LanguageID == defLangID)).Desc : "");
					text5 = JsonConvert.SerializeObject(Enumerable.ToList<CrmCompanyChangeHistoryLangViewModel>(Enumerable.Where<CrmCompanyChangeHistoryLangViewModel>((IEnumerable<CrmCompanyChangeHistoryLangViewModel>)list, (Func<CrmCompanyChangeHistoryLangViewModel, bool>)((CrmCompanyChangeHistoryLangViewModel c) => c.LanguageID != defLangID))));
				}
				ObjectParameter insertedId10 = new ObjectParameter("insertedId", 0);
				cRMSpIEntities.CRMspInsertCompanyChangeHistory(cmpId, text, text2, text3, text4, text5, userId, now, registerDatePersian, appType, defLangID, insertedId10);
			}
			List<CommonMultiSelectorViewModel> list28 = new List<CommonMultiSelectorViewModel>();
			List<CommonMultiSelectorViewModel> list29 = new List<CommonMultiSelectorViewModel>();
			if (!string.IsNullOrWhiteSpace(oldCmpInfo.cmpGroupsMultiIds))
			{
				if (oldCmpInfo.cmpGroupsMultiIds.EndsWith(","))
				{
					oldCmpInfo.cmpGroupsMultiIds = oldCmpInfo.cmpGroupsMultiIds.TrimEnd(new char[1] { ',' });
				}
				if (oldCmpInfo.cmpGroupsMultiIds.StartsWith(","))
				{
					oldCmpInfo.cmpGroupsMultiIds = oldCmpInfo.cmpGroupsMultiIds.TrimStart(new char[1] { ',' });
				}
				if (!string.IsNullOrWhiteSpace(oldCmpInfo.cmpGroupsMultiIds))
				{
					string[] array3 = oldCmpInfo.cmpGroupsMultiIds.Split(new char[1] { ',' });
					if (array3 != null && array3.Length != 0)
					{
						for (int k = 0; k < array3.Length; k++)
						{
							int result4 = 0;
							int.TryParse(array3[k], out result4);
							if (result4 != 0)
							{
								CommonMultiSelectorViewModel item19 = new CommonMultiSelectorViewModel
								{
									Id = result4
								};
								list28.Add(item19);
							}
						}
					}
					if (list28 != null && Enumerable.Any<CommonMultiSelectorViewModel>((IEnumerable<CommonMultiSelectorViewModel>)list28))
					{
						list28 = Enumerable.ToList<CommonMultiSelectorViewModel>((IEnumerable<CommonMultiSelectorViewModel>)Enumerable.OrderBy<CommonMultiSelectorViewModel, int>((IEnumerable<CommonMultiSelectorViewModel>)list28, (Func<CommonMultiSelectorViewModel, int>)((CommonMultiSelectorViewModel m) => m.Id)));
						string text20 = "";
						foreach (CommonMultiSelectorViewModel item43 in list28)
						{
							text20 = text20 + item43.Id + ",";
						}
						oldCmpInfo.cmpGroupsMultiIds = text20;
						if (oldCmpInfo.cmpGroupsMultiIds.EndsWith(","))
						{
							oldCmpInfo.cmpGroupsMultiIds = oldCmpInfo.cmpGroupsMultiIds.TrimEnd(new char[1] { ',' });
						}
						if (oldCmpInfo.cmpGroupsMultiIds.StartsWith(","))
						{
							oldCmpInfo.cmpGroupsMultiIds = oldCmpInfo.cmpGroupsMultiIds.TrimStart(new char[1] { ',' });
						}
					}
				}
			}
			if (!string.IsNullOrWhiteSpace(newCmpInfo.cmpGroupsMultiIds))
			{
				if (newCmpInfo.cmpGroupsMultiIds.EndsWith(","))
				{
					newCmpInfo.cmpGroupsMultiIds = newCmpInfo.cmpGroupsMultiIds.TrimEnd(new char[1] { ',' });
				}
				if (newCmpInfo.cmpGroupsMultiIds.StartsWith(","))
				{
					newCmpInfo.cmpGroupsMultiIds = newCmpInfo.cmpGroupsMultiIds.TrimStart(new char[1] { ',' });
				}
				if (!string.IsNullOrWhiteSpace(newCmpInfo.cmpGroupsMultiIds))
				{
					string[] array4 = newCmpInfo.cmpGroupsMultiIds.Split(new char[1] { ',' });
					if (array4 != null && array4.Length != 0)
					{
						for (int l = 0; l < array4.Length; l++)
						{
							int result5 = 0;
							int.TryParse(array4[l], out result5);
							if (result5 != 0)
							{
								CommonMultiSelectorViewModel item20 = new CommonMultiSelectorViewModel
								{
									Id = result5
								};
								list29.Add(item20);
							}
						}
					}
					if (list29 != null && Enumerable.Any<CommonMultiSelectorViewModel>((IEnumerable<CommonMultiSelectorViewModel>)list29))
					{
						list29 = Enumerable.ToList<CommonMultiSelectorViewModel>((IEnumerable<CommonMultiSelectorViewModel>)Enumerable.OrderBy<CommonMultiSelectorViewModel, int>((IEnumerable<CommonMultiSelectorViewModel>)list29, (Func<CommonMultiSelectorViewModel, int>)((CommonMultiSelectorViewModel m) => m.Id)));
						string text21 = "";
						foreach (CommonMultiSelectorViewModel item44 in list29)
						{
							text21 = text21 + item44.Id + ",";
						}
						newCmpInfo.cmpGroupsMultiIds = text21;
						if (newCmpInfo.cmpGroupsMultiIds.EndsWith(","))
						{
							newCmpInfo.cmpGroupsMultiIds = newCmpInfo.cmpGroupsMultiIds.TrimEnd(new char[1] { ',' });
						}
						if (newCmpInfo.cmpGroupsMultiIds.StartsWith(","))
						{
							newCmpInfo.cmpGroupsMultiIds = newCmpInfo.cmpGroupsMultiIds.TrimStart(new char[1] { ',' });
						}
					}
				}
			}
			if (oldCmpInfo.cmpGroupsMultiIds != newCmpInfo.cmpGroupsMultiIds)
			{
				text = "cmpGroupsMultiIds";
				text2 = (string.IsNullOrWhiteSpace(oldCmpInfo.cmpGroupsMultiIds) ? "" : oldCmpInfo.cmpGroupsMultiIds);
				text3 = (string.IsNullOrWhiteSpace(newCmpInfo.cmpGroupsMultiIds) ? "" : newCmpInfo.cmpGroupsMultiIds);
				list = new List<CrmCompanyChangeHistoryLangViewModel>();
				List<CommonMultiAndIdLanguageViewModel> list30 = new List<CommonMultiAndIdLanguageViewModel>();
				List<CrmCompanyGroupsMulti> list31 = Enumerable.ToList<CrmCompanyGroupsMulti>((IEnumerable<CrmCompanyGroupsMulti>)cRMTabelEntities.CrmCompanyGroupsMulti);
				List<CrmCompanyGroupsMulti_Lang> list32 = Enumerable.ToList<CrmCompanyGroupsMulti_Lang>((IEnumerable<CrmCompanyGroupsMulti_Lang>)cRMTabelEntities.CrmCompanyGroupsMulti_Lang);
				if (list31 != null && Enumerable.Any<CrmCompanyGroupsMulti>((IEnumerable<CrmCompanyGroupsMulti>)list31))
				{
					foreach (CrmCompanyGroupsMulti item45 in list31)
					{
						CommonMultiAndIdLanguageViewModel item21 = new CommonMultiAndIdLanguageViewModel
						{
							LanguageId = item45.LanguageID.GetValueOrDefault(),
							Value = item45.CompanyGroupsMultiName,
							Id = item45.CompanyGroupsMultiID
						};
						list30.Add(item21);
					}
				}
				if (list32 != null && Enumerable.Any<CrmCompanyGroupsMulti_Lang>((IEnumerable<CrmCompanyGroupsMulti_Lang>)list32))
				{
					foreach (CrmCompanyGroupsMulti_Lang item46 in list32)
					{
						CommonMultiAndIdLanguageViewModel item22 = new CommonMultiAndIdLanguageViewModel
						{
							LanguageId = item46.LanguageID,
							Value = item46.CompanyGroupsMultiName,
							Id = item46.CompanyGroupsMultiID
						};
						list30.Add(item22);
					}
				}
				foreach (Languages lang in Enumerable.ToList<Languages>((IEnumerable<Languages>)Language.Get()))
				{
					CrmCompanyChangeHistoryLangViewModel crmCompanyChangeHistoryLangViewModel11 = new CrmCompanyChangeHistoryLangViewModel();
					crmCompanyChangeHistoryLangViewModel11.LanguageID = lang.LanguageID;
					crmCompanyChangeHistoryLangViewModel11.OldValue = text2;
					crmCompanyChangeHistoryLangViewModel11.NewValue = text3;
					string text22 = "";
					CRMspSelectUsersById_Result cRMspSelectUsersById_Result15 = User.SelectUsersById(userId, -1, lang.LanguageID, defLangID);
					if (cRMspSelectUsersById_Result15 != null)
					{
						text22 = cRMspSelectUsersById_Result15.FullName ?? "";
					}
					if (mode == 1)
					{
						crmCompanyChangeHistoryLangViewModel11.Desc = string.Format(MyResource.GetResourceString("cmpChangeHistoryDescRegisterByUser", lang.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), text22);
					}
					else
					{
						string text23 = "";
						string text24 = "";
						if (list30 != null && Enumerable.Any<CommonMultiAndIdLanguageViewModel>((IEnumerable<CommonMultiAndIdLanguageViewModel>)list30))
						{
							if (string.IsNullOrWhiteSpace(oldCmpInfo.cmpGroupsMultiIds))
							{
								text23 = MyResource.GetResourceString("LblNoValue", lang.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
							}
							else if (list28 != null && Enumerable.Any<CommonMultiSelectorViewModel>((IEnumerable<CommonMultiSelectorViewModel>)list28))
							{
								foreach (CommonMultiSelectorViewModel itemId2 in list28)
								{
									if (itemId2.Id != 0)
									{
										CommonMultiAndIdLanguageViewModel commonMultiAndIdLanguageViewModel17 = Enumerable.FirstOrDefault<CommonMultiAndIdLanguageViewModel>((IEnumerable<CommonMultiAndIdLanguageViewModel>)list30, (Func<CommonMultiAndIdLanguageViewModel, bool>)((CommonMultiAndIdLanguageViewModel m) => m.Id == itemId2.Id && m.LanguageId == lang.LanguageID));
										if (commonMultiAndIdLanguageViewModel17 != null)
										{
											text23 = text23 + commonMultiAndIdLanguageViewModel17.Value + ",";
										}
									}
								}
								if (!string.IsNullOrWhiteSpace(text23))
								{
									if (text23.StartsWith(","))
									{
										text23 = text23.TrimStart(new char[1] { ',' });
									}
									if (text23.EndsWith(","))
									{
										text23 = text23.TrimEnd(new char[1] { ',' });
									}
								}
							}
							if (string.IsNullOrWhiteSpace(newCmpInfo.cmpGroupsMultiIds))
							{
								text24 = MyResource.GetResourceString("LblNoValue", lang.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
							}
							else if (list29 != null && Enumerable.Any<CommonMultiSelectorViewModel>((IEnumerable<CommonMultiSelectorViewModel>)list29))
							{
								foreach (CommonMultiSelectorViewModel itemId in list29)
								{
									if (itemId.Id != 0)
									{
										CommonMultiAndIdLanguageViewModel commonMultiAndIdLanguageViewModel18 = Enumerable.FirstOrDefault<CommonMultiAndIdLanguageViewModel>((IEnumerable<CommonMultiAndIdLanguageViewModel>)list30, (Func<CommonMultiAndIdLanguageViewModel, bool>)((CommonMultiAndIdLanguageViewModel m) => m.Id == itemId.Id && m.LanguageId == lang.LanguageID));
										if (commonMultiAndIdLanguageViewModel18 != null)
										{
											text24 = text24 + commonMultiAndIdLanguageViewModel18.Value + ",";
										}
									}
								}
								if (!string.IsNullOrWhiteSpace(text24))
								{
									if (text24.StartsWith(","))
									{
										text24 = text24.TrimStart(new char[1] { ',' });
									}
									if (text24.EndsWith(","))
									{
										text24 = text24.TrimEnd(new char[1] { ',' });
									}
								}
							}
							crmCompanyChangeHistoryLangViewModel11.Desc = string.Format(MyResource.GetResourceString("cmpChangeHistoryDescChangeGroupsMulti", lang.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), text23, text24, text22);
						}
					}
					list.Add(crmCompanyChangeHistoryLangViewModel11);
				}
				text4 = "";
				text5 = "";
				if (list != null && Enumerable.Any<CrmCompanyChangeHistoryLangViewModel>((IEnumerable<CrmCompanyChangeHistoryLangViewModel>)list))
				{
					text4 = (Enumerable.Any<CrmCompanyChangeHistoryLangViewModel>((IEnumerable<CrmCompanyChangeHistoryLangViewModel>)list, (Func<CrmCompanyChangeHistoryLangViewModel, bool>)((CrmCompanyChangeHistoryLangViewModel c) => c.LanguageID == defLangID)) ? Enumerable.FirstOrDefault<CrmCompanyChangeHistoryLangViewModel>((IEnumerable<CrmCompanyChangeHistoryLangViewModel>)list, (Func<CrmCompanyChangeHistoryLangViewModel, bool>)((CrmCompanyChangeHistoryLangViewModel c) => c.LanguageID == defLangID)).Desc : "");
					text5 = JsonConvert.SerializeObject(Enumerable.ToList<CrmCompanyChangeHistoryLangViewModel>(Enumerable.Where<CrmCompanyChangeHistoryLangViewModel>((IEnumerable<CrmCompanyChangeHistoryLangViewModel>)list, (Func<CrmCompanyChangeHistoryLangViewModel, bool>)((CrmCompanyChangeHistoryLangViewModel c) => c.LanguageID != defLangID))));
				}
				ObjectParameter insertedId11 = new ObjectParameter("insertedId", 0);
				cRMSpIEntities.CRMspInsertCompanyChangeHistory(cmpId, text, text2, text3, text4, text5, userId, now, registerDatePersian, appType, defLangID, insertedId11);
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
		}
		finally
		{
			cRMSpIEntities.Dispose();
			cRMSpEntities.Dispose();
			cRMTabelEntities.Dispose();
		}
		return result;
	}

	public static List<CRMspMainSearchWebSmart_Result> MainSearchWebSmart(string val = "", int userId = 0, int searchType = 1, string searchConditionMode = "")
	{
		List<CRMspMainSearchWebSmart_Result> result = new List<CRMspMainSearchWebSmart_Result>();
		CRMSpIEntities cRMSpIEntities = new CRMSpIEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (userId == 0)
			{
				userId = UserLogin.CurrentUser.UserId;
			}
			int result3 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result3);
			}
			if (!string.IsNullOrWhiteSpace(val))
			{
				List<CRMspMainSearchWebSmart_Result> list = Enumerable.ToList<CRMspMainSearchWebSmart_Result>((IEnumerable<CRMspMainSearchWebSmart_Result>)cRMSpIEntities.CRMspMainSearchWebSmart(val, userId, searchType, lCID, result2, searchConditionMode, result3));
				if (list != null)
				{
					if (Enumerable.Any<CRMspMainSearchWebSmart_Result>((IEnumerable<CRMspMainSearchWebSmart_Result>)list))
					{
						foreach (CRMspMainSearchWebSmart_Result item in list)
						{
							item.cmpCode = OtherSystems.GetLinkAccCodeWithComa(1, item.cmpCode);
						}
					}
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
			cRMSpIEntities.Dispose();
		}
		return result;
	}

	public static bool CheckHaveOrderOprExceptTspCmp(int cmpId)
	{
		CRMSpIIEntities cRMSpIIEntities = new CRMSpIIEntities();
		bool result = false;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (cmpId != 0)
			{
				List<WSspCheckHaveOrderOprExceptTspCmp_Result> list = Enumerable.ToList<WSspCheckHaveOrderOprExceptTspCmp_Result>((IEnumerable<WSspCheckHaveOrderOprExceptTspCmp_Result>)cRMSpIIEntities.WSspCheckHaveOrderOprExceptTspCmp(cmpId, lCID, result2));
				if (list != null && Enumerable.Any<WSspCheckHaveOrderOprExceptTspCmp_Result>((IEnumerable<WSspCheckHaveOrderOprExceptTspCmp_Result>)list))
				{
					result = true;
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpIIEntities.Dispose();
		}
		return result;
	}

	public static decimal GetCompanyAllPayRemain(int cmpId = 0, int linkAccSettingDBId = 0)
	{
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		decimal result = default(decimal);
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			int result3 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result3);
			}
			_ = DateTime.Now;
			bool result4 = false;
			int num = 0;
			CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
			if (cRMspSelectCrmsysSetting_Result != null)
			{
				bool.TryParse(cRMspSelectCrmsysSetting_Result.CmpAccFromLink.ToString(), out result4);
				num = cRMspSelectCrmsysSetting_Result.LinkAccSystemId.GetValueOrDefault();
			}
			if (result4 && num != 0)
			{
				CompanyController companyController = new CompanyController();
				decimal remainAccount = default(decimal);
				if (num == 1 || num == 3 || num == 4 || num == 8 || num == 9 || num == 12 || num == 15 || num == 17 || num == 18 || num == 20 || num == 22 || num == 23 || num == 26)
				{
					decimal linkAccDebitBalance = default(decimal);
					decimal linkAccCreditBalance = default(decimal);
					companyController.LinkAccCmpAccountingDetail(num, cmpId, ref remainAccount, ref linkAccDebitBalance, ref linkAccCreditBalance, linkAccSettingDBId);
					result = remainAccount;
					return result;
				}
				CRMspReturnCmpAccountingSummary_Result cRMspReturnCmpAccountingSummary_Result = Enumerable.FirstOrDefault<CRMspReturnCmpAccountingSummary_Result>((IEnumerable<CRMspReturnCmpAccountingSummary_Result>)cRMSpEntities.CRMspReturnCmpAccountingSummary(cmpId, result3));
				if (cRMspReturnCmpAccountingSummary_Result != null)
				{
					decimal.TryParse(cRMspReturnCmpAccountingSummary_Result.AllPayRemain.ToString(), out result);
				}
			}
			else
			{
				CRMspReturnCmpAccountingSummary_Result cRMspReturnCmpAccountingSummary_Result2 = Enumerable.FirstOrDefault<CRMspReturnCmpAccountingSummary_Result>((IEnumerable<CRMspReturnCmpAccountingSummary_Result>)cRMSpEntities.CRMspReturnCmpAccountingSummary(cmpId, result3));
				if (cRMspReturnCmpAccountingSummary_Result2 != null)
				{
					decimal.TryParse(cRMspReturnCmpAccountingSummary_Result2.AllPayRemain.ToString(), out result);
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return result;
	}

	public static bool CreateCompanyPersonUsernameAndPassword(int prsId)
	{
		bool result = false;
		CRMSpIIEntities cRMSpIIEntities = new CRMSpIIEntities();
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
			short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			short value3 = short.Parse(Financial.Get().Id.ToString());
			int userId = UserLogin.CurrentUser.UserId;
			string encryptionKey = XorCipher.PreparePublicKeyForSql();
			mct_II_Result mct_II_Result = Enumerable.FirstOrDefault<mct_II_Result>((IEnumerable<mct_II_Result>)cRMSpIIEntities.CRMspCreateCompanyPersonUsernameAndPassword(prsId, userId, value2, value3, value, registerDatePersian, appType, centerId, encryptionKey));
			if (mct_II_Result != null)
			{
				int result2 = 0;
				int.TryParse(mct_II_Result.Result.ToString(), out result2);
				result = result2 > 0;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpIIEntities?.Dispose();
		}
		return result;
	}

	public static List<CRMspSelectCompanyPersons_Result> SelectCompanyPersons(int cmpId, int userId = 0, bool? prsWorkingOut = null)
	{
		List<CRMspSelectCompanyPersons_Result> list = new List<CRMspSelectCompanyPersons_Result>();
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
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
				if (userId == 0)
				{
					int.TryParse(UserLogin.CurrentUser.UserId.ToString(), out userId);
				}
			}
			list = Enumerable.ToList<CRMspSelectCompanyPersons_Result>((IEnumerable<CRMspSelectCompanyPersons_Result>)cRMSpEntities.CRMspSelectCompanyPersons(cmpId, userId, lCID, result, result2, prsWorkingOut));
			if (list == null)
			{
				list = new List<CRMspSelectCompanyPersons_Result>();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return list;
	}

	public static List<CRMspSelectCompanyPersonsWithPaging_Result> SelectCompanyPersonsWithPaging(int cmpId, int userId = 0, bool? prsWorkingOut = null, int pageSize = 50, int lastRowNumber = 0, string searchedValue = "")
	{
		List<CRMspSelectCompanyPersonsWithPaging_Result> list = new List<CRMspSelectCompanyPersonsWithPaging_Result>();
		CRMSpIIEntities cRMSpIIEntities = new CRMSpIIEntities();
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
				if (userId == 0)
				{
					int.TryParse(UserLogin.CurrentUser.UserId.ToString(), out userId);
				}
			}
			list = Enumerable.ToList<CRMspSelectCompanyPersonsWithPaging_Result>((IEnumerable<CRMspSelectCompanyPersonsWithPaging_Result>)cRMSpIIEntities.CRMspSelectCompanyPersonsWithPaging(cmpId, userId, lCID, result, result2, prsWorkingOut, pageSize, lastRowNumber, searchedValue));
			if (list == null)
			{
				list = new List<CRMspSelectCompanyPersonsWithPaging_Result>();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpIIEntities?.Dispose();
		}
		return list;
	}

	public static CRMspSelectCompanyPersonsByID_Result SelectCompanyPersonsById(int prsId = 0)
	{
		CRMspSelectCompanyPersonsByID_Result cRMspSelectCompanyPersonsByID_Result = new CRMspSelectCompanyPersonsByID_Result();
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
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
			cRMspSelectCompanyPersonsByID_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyPersonsByID_Result>((IEnumerable<CRMspSelectCompanyPersonsByID_Result>)cRMSpEntities.CRMspSelectCompanyPersonsByID(prsId, lCID, result));
			if (cRMspSelectCompanyPersonsByID_Result == null)
			{
				cRMspSelectCompanyPersonsByID_Result = new CRMspSelectCompanyPersonsByID_Result();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return cRMspSelectCompanyPersonsByID_Result;
	}

	public static List<CRMspSelectCompanyPersonsByIds_Result> SelectCompanyPersonsByIds(int cmpId = 0, string prsIds = "", string sep = ",", bool? prsWorkingOut = null)
	{
		List<CRMspSelectCompanyPersonsByIds_Result> result = null;
		CRMSpIIEntities cRMSpIIEntities = new CRMSpIIEntities();
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
			result = Enumerable.ToList<CRMspSelectCompanyPersonsByIds_Result>((IEnumerable<CRMspSelectCompanyPersonsByIds_Result>)cRMSpIIEntities.CRMspSelectCompanyPersonsByIds(cmpId, prsIds, sep, lCID, result2, prsWorkingOut));
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		finally
		{
			cRMSpIIEntities?.Dispose();
		}
		return result;
	}

	public static List<CRMspSelectCompanyProjects_Result> SelectCompanyProjects(int cmpId, int isFinished, int? prjIsTicket = null, int userId = 0)
	{
		List<CRMspSelectCompanyProjects_Result> list = new List<CRMspSelectCompanyProjects_Result>();
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
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
				if (userId == 0)
				{
					int.TryParse(UserLogin.CurrentUser.UserId.ToString(), out userId);
				}
			}
			list = Enumerable.ToList<CRMspSelectCompanyProjects_Result>((IEnumerable<CRMspSelectCompanyProjects_Result>)cRMSpEntities.CRMspSelectCompanyProjects(cmpId, isFinished, userId, lCID, result, prjIsTicket, result2));
			if (list == null)
			{
				list = new List<CRMspSelectCompanyProjects_Result>();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return list;
	}

	public static CRMspSelectCompanyProjectsCount_Result SelectCompanyProjectsCount(int cmpId, int userId = 0)
	{
		CRMspSelectCompanyProjectsCount_Result cRMspSelectCompanyProjectsCount_Result = new CRMspSelectCompanyProjectsCount_Result();
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
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
				if (userId == 0)
				{
					int.TryParse(UserLogin.CurrentUser.UserId.ToString(), out userId);
				}
			}
			cRMspSelectCompanyProjectsCount_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyProjectsCount_Result>((IEnumerable<CRMspSelectCompanyProjectsCount_Result>)cRMSpEntities.CRMspSelectCompanyProjectsCount(cmpId, userId, result2));
			if (cRMspSelectCompanyProjectsCount_Result == null)
			{
				cRMspSelectCompanyProjectsCount_Result = new CRMspSelectCompanyProjectsCount_Result();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return cRMspSelectCompanyProjectsCount_Result;
	}

	public static LinkAccDataViewModel GetCmpCenterInfo(int cmpId, int cId)
	{
		LinkAccDataViewModel result = null;
		try
		{
			CRMspSelectCompanyById_Result cmpWithId = GetCmpWithId(cmpId);
			if (cmpWithId != null && !string.IsNullOrWhiteSpace(cmpWithId.cmpLinkAccData))
			{
				List<LinkAccDataViewModel> list = JsonConvert.DeserializeObject<List<LinkAccDataViewModel>>(cmpWithId.cmpLinkAccData);
				if (list != null)
				{
					result = Enumerable.FirstOrDefault<LinkAccDataViewModel>((IEnumerable<LinkAccDataViewModel>)list, (Func<LinkAccDataViewModel, bool>)((LinkAccDataViewModel x) => x.CId == cId));
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	public static CRMspSelectCompanyById_Result GetCmpWithId(int? cmpId = null)
	{
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		CRMspSelectCompanyById_Result result = null;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			result = GetCompanyById(cmpId.GetValueOrDefault());
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

	public static int? GetPrjCId(int prjId)
	{
		int? result = null;
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			CRMspSelectCrmProjectsById_Result cRMspSelectCrmProjectsById_Result = Enumerable.FirstOrDefault<CRMspSelectCrmProjectsById_Result>((IEnumerable<CRMspSelectCrmProjectsById_Result>)cRMSpEntities.CRMspSelectCrmProjectsById(prjId, lCID, result2));
			if (cRMspSelectCrmProjectsById_Result != null)
			{
				result = cRMspSelectCrmProjectsById_Result.prjCId;
				return result;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return result;
	}

	public static string GetFoInfoJsonByName(string foInfo, string cIds)
	{
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		string result = "";
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
			string[] array = new string[1];
			if (!string.IsNullOrWhiteSpace(cIds))
			{
				array = cIds.Split(new char[1] { ',' });
			}
			if (array == null || array.Length == 0)
			{
				array = new string[1] { result3.ToString() };
			}
			List<CommonFoInfoByNameViewModel> list = new List<CommonFoInfoByNameViewModel>();
			if (!string.IsNullOrWhiteSpace(foInfo))
			{
				list = new JavaScriptSerializer().Deserialize<List<CommonFoInfoByNameViewModel>>(foInfo);
			}
			if (list != null && array != null)
			{
				if (Enumerable.Any<CommonFoInfoByNameViewModel>((IEnumerable<CommonFoInfoByNameViewModel>)list))
				{
					for (int i = 0; i < array.Length; i++)
					{
						int cI = 0;
						int.TryParse(array[i], out cI);
						if (cI == 0)
						{
							continue;
						}
						bool flag = false;
						CommonFoInfoByNameViewModel commonFoInfoByNameViewModel = Enumerable.FirstOrDefault<CommonFoInfoByNameViewModel>((IEnumerable<CommonFoInfoByNameViewModel>)list, (Func<CommonFoInfoByNameViewModel, bool>)((CommonFoInfoByNameViewModel m) => m.CId == cI.ToString()));
						if (commonFoInfoByNameViewModel != null)
						{
							int result4 = 0;
							int.TryParse(commonFoInfoByNameViewModel.CId, out result4);
							if (result4 != 0)
							{
								flag = true;
							}
						}
						if (!flag)
						{
							list.Add(new CommonFoInfoByNameViewModel
							{
								CId = cI.ToString(),
								FOAct = "0",
								FOActDt = "",
								FOActUId = "0",
								FOExpDt = "",
								FOExpUId = "0",
								ShpAct = "0",
								ShpActDt = "",
								ShpActUId = "0",
								ShpExpDt = "",
								ShpExpUId = "0",
								ReferUId = "0",
								SuppUId = "0"
							});
						}
					}
				}
				else
				{
					for (int j = 0; j < array.Length; j++)
					{
						int result5 = 0;
						int.TryParse(array[j], out result5);
						if (result5 != 0)
						{
							list.Add(new CommonFoInfoByNameViewModel
							{
								CId = result5.ToString(),
								FOAct = "0",
								FOActDt = "",
								FOActUId = "0",
								FOExpDt = "",
								FOExpUId = "0",
								ShpAct = "0",
								ShpActDt = "",
								ShpActUId = "0",
								ShpExpDt = "",
								ShpExpUId = "0",
								ReferUId = "0",
								SuppUId = "0"
							});
						}
					}
				}
			}
			if (list != null && Enumerable.Any<CommonFoInfoByNameViewModel>((IEnumerable<CommonFoInfoByNameViewModel>)list))
			{
				List<CRMspSelectCenters_Result> list2 = Center.Get();
				string text = "";
				List<string> list3 = new List<string>();
				list3.AddRange(Enumerable.Select<CommonFoInfoByNameViewModel, string>(Enumerable.Where<CommonFoInfoByNameViewModel>((IEnumerable<CommonFoInfoByNameViewModel>)list, (Func<CommonFoInfoByNameViewModel, bool>)((CommonFoInfoByNameViewModel x) => !string.IsNullOrWhiteSpace(x.FOActUId) && x.FOActUId != "0")), (Func<CommonFoInfoByNameViewModel, string>)((CommonFoInfoByNameViewModel x) => x.FOActUId)));
				list3.AddRange(Enumerable.Select<CommonFoInfoByNameViewModel, string>(Enumerable.Where<CommonFoInfoByNameViewModel>((IEnumerable<CommonFoInfoByNameViewModel>)list, (Func<CommonFoInfoByNameViewModel, bool>)((CommonFoInfoByNameViewModel x) => !string.IsNullOrWhiteSpace(x.FOExpUId) && x.FOExpUId != "0")), (Func<CommonFoInfoByNameViewModel, string>)((CommonFoInfoByNameViewModel x) => x.FOExpUId)));
				list3.AddRange(Enumerable.Select<CommonFoInfoByNameViewModel, string>(Enumerable.Where<CommonFoInfoByNameViewModel>((IEnumerable<CommonFoInfoByNameViewModel>)list, (Func<CommonFoInfoByNameViewModel, bool>)((CommonFoInfoByNameViewModel x) => !string.IsNullOrWhiteSpace(x.ReferUId) && x.ReferUId != "0")), (Func<CommonFoInfoByNameViewModel, string>)((CommonFoInfoByNameViewModel x) => x.ReferUId)));
				list3.AddRange(Enumerable.Select<CommonFoInfoByNameViewModel, string>(Enumerable.Where<CommonFoInfoByNameViewModel>((IEnumerable<CommonFoInfoByNameViewModel>)list, (Func<CommonFoInfoByNameViewModel, bool>)((CommonFoInfoByNameViewModel x) => !string.IsNullOrWhiteSpace(x.ShpActUId) && x.ShpActUId != "0")), (Func<CommonFoInfoByNameViewModel, string>)((CommonFoInfoByNameViewModel x) => x.ShpActUId)));
				list3.AddRange(Enumerable.Select<CommonFoInfoByNameViewModel, string>(Enumerable.Where<CommonFoInfoByNameViewModel>((IEnumerable<CommonFoInfoByNameViewModel>)list, (Func<CommonFoInfoByNameViewModel, bool>)((CommonFoInfoByNameViewModel x) => !string.IsNullOrWhiteSpace(x.ShpExpUId) && x.ShpExpUId != "0")), (Func<CommonFoInfoByNameViewModel, string>)((CommonFoInfoByNameViewModel x) => x.ShpExpUId)));
				list3.AddRange(Enumerable.Select<CommonFoInfoByNameViewModel, string>(Enumerable.Where<CommonFoInfoByNameViewModel>((IEnumerable<CommonFoInfoByNameViewModel>)list, (Func<CommonFoInfoByNameViewModel, bool>)((CommonFoInfoByNameViewModel x) => !string.IsNullOrWhiteSpace(x.SuppUId) && x.SuppUId != "0")), (Func<CommonFoInfoByNameViewModel, string>)((CommonFoInfoByNameViewModel x) => x.SuppUId)));
				text = list3.JoinStrings(",");
				List<CRMspSelectUsersByIds_Result> list4 = Enumerable.ToList<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)new CRMSpIEntities().CRMspSelectUsersByIds(text, ",", lCID, result2, result3));
				foreach (CommonFoInfoByNameViewModel item in list)
				{
					int cId = 0;
					int.TryParse(item.CId, out cId);
					if (list2 != null && list2.Count > 0)
					{
						CRMspSelectCenters_Result cRMspSelectCenters_Result = Enumerable.FirstOrDefault<CRMspSelectCenters_Result>((IEnumerable<CRMspSelectCenters_Result>)list2, (Func<CRMspSelectCenters_Result, bool>)((CRMspSelectCenters_Result x) => x.CenterID == cId));
						if (cRMspSelectCenters_Result != null)
						{
							item.CenterName = cRMspSelectCenters_Result.CenterName;
						}
					}
					if (!string.IsNullOrWhiteSpace(item.FOActDt))
					{
						item.FOActDtStr = DateTime.Parse(item.FOActDt, new CultureInfo("en-US")).ToString("yyyy/MM/dd", new CultureInfo(lCID));
					}
					int fOActUId = 0;
					int.TryParse(item.FOActUId, out fOActUId);
					if (fOActUId != 0)
					{
						item.FOActUName = ((list4 == null) ? null : Enumerable.FirstOrDefault<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list4, (Func<CRMspSelectUsersByIds_Result, bool>)((CRMspSelectUsersByIds_Result x) => x.UserId == fOActUId))?.FullName) ?? "";
					}
					if (!string.IsNullOrWhiteSpace(item.FOExpDt))
					{
						item.FOExpDtStr = DateTime.Parse(item.FOExpDt, new CultureInfo("en-US")).ToString("yyyy/MM/dd", new CultureInfo(lCID));
					}
					int fOExpUId = 0;
					int.TryParse(item.FOExpUId, out fOExpUId);
					if (fOExpUId != 0)
					{
						item.FOExpUName = ((list4 == null) ? null : Enumerable.FirstOrDefault<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list4, (Func<CRMspSelectUsersByIds_Result, bool>)((CRMspSelectUsersByIds_Result x) => x.UserId == fOExpUId))?.FullName) ?? "";
					}
					if (!string.IsNullOrWhiteSpace(item.ShpActDt))
					{
						item.ShpActDtStr = DateTime.Parse(item.ShpActDt, new CultureInfo("en-US")).ToString("yyyy/MM/dd", new CultureInfo(lCID));
					}
					int shpActUId = 0;
					int.TryParse(item.ShpActUId, out shpActUId);
					if (shpActUId != 0)
					{
						item.ShpActUName = ((list4 == null) ? null : Enumerable.FirstOrDefault<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list4, (Func<CRMspSelectUsersByIds_Result, bool>)((CRMspSelectUsersByIds_Result x) => x.UserId == shpActUId))?.FullName) ?? "";
					}
					if (!string.IsNullOrWhiteSpace(item.ShpExpDt))
					{
						item.ShpExpDtStr = DateTime.Parse(item.ShpExpDt, new CultureInfo("en-US")).ToString("yyyy/MM/dd", new CultureInfo(lCID));
					}
					int shpExpUId = 0;
					int.TryParse(item.ShpExpUId, out shpExpUId);
					if (shpExpUId != 0)
					{
						item.ShpExpUName = ((list4 == null) ? null : Enumerable.FirstOrDefault<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list4, (Func<CRMspSelectUsersByIds_Result, bool>)((CRMspSelectUsersByIds_Result x) => x.UserId == shpExpUId))?.FullName) ?? "";
					}
					int referUId = 0;
					int.TryParse(item.ReferUId, out referUId);
					if (referUId != 0)
					{
						item.ReferUName = ((list4 == null) ? null : Enumerable.FirstOrDefault<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list4, (Func<CRMspSelectUsersByIds_Result, bool>)((CRMspSelectUsersByIds_Result x) => x.UserId == referUId))?.FullName) ?? "";
					}
					int suppUId = 0;
					int.TryParse(item.SuppUId, out suppUId);
					if (suppUId != 0)
					{
						item.SuppUName = ((list4 == null) ? null : Enumerable.FirstOrDefault<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list4, (Func<CRMspSelectUsersByIds_Result, bool>)((CRMspSelectUsersByIds_Result x) => x.UserId == suppUId))?.FullName) ?? "";
					}
				}
				result = JsonConvert.SerializeObject(Enumerable.ToList<CommonFoInfoByNameViewModel>((IEnumerable<CommonFoInfoByNameViewModel>)list));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public static string GetFoInfoJson(string foInfo, string oldFoInfo, string cIds, ref bool haveEroroFoCnt, int userId = 0, int userLastCId = 0, bool isCmp = false, int referUId = 0, int suppUId = 0, int? defaultReferUId = null)
	{
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		string result = "";
		CRMSpIIEntities cRMSpIIEntities = new CRMSpIIEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			string text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", new CultureInfo("en-US"));
			bool flag = false;
			if (UserLogin.CurrentUser != null)
			{
				if (userLastCId == 0)
				{
					int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out userLastCId);
				}
				if (userId == 0)
				{
					userId = UserLogin.CurrentUser.UserId;
				}
			}
			List<CommonFoInfoViewModel> list = new List<CommonFoInfoViewModel>();
			List<CommonFoInfoViewModel> list2 = new List<CommonFoInfoViewModel>();
			if (!string.IsNullOrWhiteSpace(oldFoInfo))
			{
				list2 = new JavaScriptSerializer().Deserialize<List<CommonFoInfoViewModel>>(oldFoInfo);
				if (list2 != null && Enumerable.Any<CommonFoInfoViewModel>((IEnumerable<CommonFoInfoViewModel>)list2) && Enumerable.FirstOrDefault<CommonFoInfoViewModel>((IEnumerable<CommonFoInfoViewModel>)list2, (Func<CommonFoInfoViewModel, bool>)((CommonFoInfoViewModel m) => (m.FOAct ?? "0") == "1")) != null)
				{
					flag = true;
				}
			}
			string[] array = new string[1];
			if (!string.IsNullOrWhiteSpace(cIds))
			{
				array = cIds.Split(new char[1] { ',' });
			}
			if (array == null || array.Length == 0)
			{
				array = new string[1] { userLastCId.ToString() };
			}
			List<CommonFoInfoByNameViewModel> list3 = new List<CommonFoInfoByNameViewModel>();
			if (!string.IsNullOrWhiteSpace(foInfo))
			{
				list3 = new JavaScriptSerializer().Deserialize<List<CommonFoInfoByNameViewModel>>(foInfo);
			}
			if (list3 != null && array != null)
			{
				if (Enumerable.Any<CommonFoInfoByNameViewModel>((IEnumerable<CommonFoInfoByNameViewModel>)list3))
				{
					for (int i = 0; i < array.Length; i++)
					{
						int cI = 0;
						int.TryParse(array[i], out cI);
						if (cI == 0)
						{
							continue;
						}
						bool flag2 = false;
						CommonFoInfoByNameViewModel commonFoInfoByNameViewModel = Enumerable.FirstOrDefault<CommonFoInfoByNameViewModel>((IEnumerable<CommonFoInfoByNameViewModel>)list3, (Func<CommonFoInfoByNameViewModel, bool>)((CommonFoInfoByNameViewModel m) => m.CId == cI.ToString()));
						if (commonFoInfoByNameViewModel != null)
						{
							int result3 = 0;
							int.TryParse(commonFoInfoByNameViewModel.CId, out result3);
							if (result3 != 0)
							{
								flag2 = true;
							}
						}
						if (!flag2)
						{
							list3.Add(new CommonFoInfoByNameViewModel
							{
								CId = cI.ToString(),
								FOAct = "0",
								FOActDt = "",
								FOActUId = "0",
								FOExpDt = "",
								FOExpUId = "0",
								ShpAct = "0",
								ShpActDt = "",
								ShpActUId = "0",
								ShpExpDt = "",
								ShpExpUId = "0",
								ReferUId = ((defaultReferUId.GetValueOrDefault() != 0) ? defaultReferUId.ToString() : "0"),
								SuppUId = "0"
							});
						}
					}
				}
				else
				{
					for (int j = 0; j < array.Length; j++)
					{
						int result4 = 0;
						int.TryParse(array[j], out result4);
						if (result4 != 0)
						{
							list3.Add(new CommonFoInfoByNameViewModel
							{
								CId = result4.ToString(),
								FOAct = "0",
								FOActDt = "",
								FOActUId = "0",
								FOExpDt = "",
								FOExpUId = "0",
								ShpAct = "0",
								ShpActDt = "",
								ShpActUId = "0",
								ShpExpDt = "",
								ShpExpUId = "0",
								ReferUId = ((defaultReferUId.GetValueOrDefault() != 0) ? defaultReferUId.ToString() : "0"),
								SuppUId = "0"
							});
						}
					}
				}
			}
			if (list3 != null && Enumerable.Any<CommonFoInfoByNameViewModel>((IEnumerable<CommonFoInfoByNameViewModel>)list3))
			{
				foreach (CommonFoInfoByNameViewModel item in list3)
				{
					int cId = 0;
					int.TryParse(item.CId, out cId);
					if (cId == 0)
					{
						continue;
					}
					bool flag3 = false;
					int result5 = 0;
					int.TryParse(item.FOAct, out result5);
					if (result5 == 1)
					{
						flag3 = true;
					}
					bool flag4 = false;
					int result6 = 0;
					int.TryParse(item.ShpAct, out result6);
					if (result6 == 1)
					{
						flag4 = true;
					}
					DateTime dateTime = default(DateTime);
					string text2 = "";
					try
					{
						if (!string.IsNullOrWhiteSpace(item.FOActDtStr))
						{
							text2 = PersianDate.GetFormatetdDate(item.FOActDtStr.Replace("/", ""));
							item.FOActDt = (lCID switch
							{
								1065 => DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture()), 
								1025 => DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA")), 
								_ => DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US")), 
							}).ToString("yyyy-MM-dd HH:mm:ss", new CultureInfo("en-US"));
						}
						else
						{
							item.FOActDt = "";
						}
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
					}
					dateTime = default(DateTime);
					text2 = "";
					try
					{
						if (!string.IsNullOrWhiteSpace(item.ShpActDtStr))
						{
							text2 = PersianDate.GetFormatetdDate(item.ShpActDtStr.Replace("/", ""));
							item.ShpActDt = (lCID switch
							{
								1065 => DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture()), 
								1025 => DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA")), 
								_ => DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US")), 
							}).ToString("yyyy-MM-dd HH:mm:ss", new CultureInfo("en-US"));
						}
						else
						{
							item.ShpActDt = "";
						}
					}
					catch (Exception e2)
					{
						ErrorSignal.FromCurrentContext().Raise(e2);
					}
					dateTime = default(DateTime);
					text2 = "";
					try
					{
						if (!string.IsNullOrWhiteSpace(item.FOExpDtStr))
						{
							text2 = PersianDate.GetFormatetdDate(item.FOExpDtStr.Replace("/", ""));
							item.FOExpDt = (lCID switch
							{
								1065 => DateTime.Parse(text2 + " 00:00:00", new PersianCulture()), 
								1025 => DateTime.Parse(text2 + " 00:00:00", new CultureInfo("ar-SA")), 
								_ => DateTime.Parse(text2 + " 00:00:00", new CultureInfo("en-US")), 
							}).ToString("yyyy-MM-dd HH:mm:ss", new CultureInfo("en-US"));
						}
						else
						{
							item.FOExpDt = "";
						}
					}
					catch (Exception e3)
					{
						ErrorSignal.FromCurrentContext().Raise(e3);
					}
					dateTime = default(DateTime);
					text2 = "";
					try
					{
						if (!string.IsNullOrWhiteSpace(item.ShpExpDtStr))
						{
							text2 = PersianDate.GetFormatetdDate(item.ShpExpDtStr.Replace("/", ""));
							item.ShpExpDt = (lCID switch
							{
								1065 => DateTime.Parse(text2 + " 00:00:00", new PersianCulture()), 
								1025 => DateTime.Parse(text2 + " 00:00:00", new CultureInfo("ar-SA")), 
								_ => DateTime.Parse(text2 + " 00:00:00", new CultureInfo("en-US")), 
							}).ToString("yyyy-MM-dd HH:mm:ss", new CultureInfo("en-US"));
						}
						else
						{
							item.ShpExpDt = "";
						}
					}
					catch (Exception e4)
					{
						ErrorSignal.FromCurrentContext().Raise(e4);
					}
					item.ReferUId = (string.IsNullOrWhiteSpace(item.ReferUId) ? "0" : item.ReferUId);
					item.SuppUId = (string.IsNullOrWhiteSpace(item.SuppUId) ? "0" : item.SuppUId);
					if (cId.ToString() == userLastCId.ToString() && referUId != 0)
					{
						item.ReferUId = referUId.ToString();
						if (suppUId != 0)
						{
							item.SuppUId = suppUId.ToString();
						}
						else
						{
							item.SuppUId = "0";
						}
					}
					CommonFoInfoViewModel commonFoInfoViewModel = new CommonFoInfoViewModel();
					if (list2 != null && Enumerable.Any<CommonFoInfoViewModel>((IEnumerable<CommonFoInfoViewModel>)list2))
					{
						commonFoInfoViewModel = Enumerable.FirstOrDefault<CommonFoInfoViewModel>((IEnumerable<CommonFoInfoViewModel>)list2, (Func<CommonFoInfoViewModel, bool>)((CommonFoInfoViewModel m) => m.CId == cId.ToString()));
					}
					if (commonFoInfoViewModel == null)
					{
						commonFoInfoViewModel = new CommonFoInfoViewModel
						{
							CId = cId.ToString(),
							ReferUId = referUId.ToString(),
							SuppUId = suppUId.ToString()
						};
					}
					if (commonFoInfoViewModel != null)
					{
						bool flag5 = false;
						int result7 = 0;
						int.TryParse(commonFoInfoViewModel.FOAct, out result7);
						if (result7 == 1)
						{
							flag5 = true;
						}
						if (!flag3)
						{
							item.FOAct = "0";
							item.FOActDt = "";
							item.FOActUId = "0";
						}
						else if (!flag5 && flag3 && !flag)
						{
							int maxFOCount = Configuration.MaxFOCount;
							if (Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMSpIIEntities.CRMspReturnCmpFOIsActiveCnt()).GetValueOrDefault() + 1 > maxFOCount && isCmp)
							{
								haveEroroFoCnt = true;
							}
							else
							{
								item.FOAct = (flag3 ? "1" : "0");
							}
						}
						else if (flag5 == flag3)
						{
							item.FOAct = (flag3 ? "1" : "0");
							item.FOActUId = commonFoInfoViewModel.FOActUId;
						}
						else
						{
							item.FOAct = (flag3 ? "1" : "0");
						}
						if (flag3 && string.IsNullOrWhiteSpace(item.FOActDt))
						{
							item.FOActDt = text;
						}
						if (flag3 && (string.IsNullOrWhiteSpace(item.FOActUId) || item.FOActUId == "0"))
						{
							item.FOActUId = userId.ToString();
						}
						bool flag6 = false;
						int result8 = 0;
						int.TryParse(commonFoInfoViewModel.ShpAct, out result8);
						if (result8 == 1)
						{
							flag6 = true;
						}
						if (!flag4)
						{
							item.ShpAct = "0";
							item.ShpActDt = "";
							item.ShpActUId = "0";
						}
						else
						{
							item.ShpAct = (flag4 ? "1" : "0");
							if (flag6 == flag4)
							{
								item.ShpActUId = commonFoInfoViewModel.ShpActUId;
							}
						}
						if (flag4 && string.IsNullOrWhiteSpace(item.ShpActDt))
						{
							item.ShpActDt = text;
						}
						if (flag4 && (string.IsNullOrWhiteSpace(item.ShpActUId) || item.ShpActUId == "0"))
						{
							item.ShpActUId = userId.ToString();
						}
						long result9 = 0L;
						long result10 = 0L;
						if (!string.IsNullOrWhiteSpace(commonFoInfoViewModel.FOExpDt))
						{
							long.TryParse(DateTime.Parse(commonFoInfoViewModel.FOExpDt).ToString("yyyyMMdd", new CultureInfo("en-US")), out result9);
						}
						if (!string.IsNullOrWhiteSpace(item.FOExpDt))
						{
							long.TryParse(DateTime.Parse(item.FOExpDt).ToString("yyyyMMdd", new CultureInfo("en-US")), out result10);
						}
						if (result9 != result10)
						{
							item.FOExpUId = userId.ToString();
						}
						else
						{
							item.FOExpUId = commonFoInfoViewModel.FOExpUId;
						}
						if (result10 == 0L)
						{
							item.FOExpUId = "0";
						}
						long result11 = 0L;
						long result12 = 0L;
						if (!string.IsNullOrWhiteSpace(commonFoInfoViewModel.ShpExpDt))
						{
							long.TryParse(DateTime.Parse(commonFoInfoViewModel.ShpExpDt).ToString("yyyyMMdd", new CultureInfo("en-US")), out result11);
						}
						if (!string.IsNullOrWhiteSpace(item.ShpExpDt))
						{
							long.TryParse(DateTime.Parse(item.ShpExpDt).ToString("yyyyMMdd", new CultureInfo("en-US")), out result12);
						}
						if (result11 != result12)
						{
							item.ShpExpUId = userId.ToString();
						}
						else
						{
							item.ShpExpUId = commonFoInfoViewModel.ShpExpUId;
						}
						if (result12 == 0L)
						{
							item.ShpExpUId = "0";
						}
					}
					CommonFoInfoViewModel commonFoInfoViewModel2 = new CommonFoInfoViewModel
					{
						CId = cId.ToString(),
						FOAct = (item.FOAct ?? "0"),
						FOActDt = (item.FOActDt ?? ""),
						FOActUId = (item.FOActUId ?? "0"),
						ShpAct = (item.ShpAct ?? "0"),
						ShpActDt = (item.ShpActDt ?? ""),
						ShpActUId = (item.ShpActUId ?? "0"),
						FOExpDt = (item.FOExpDt ?? ""),
						FOExpUId = (item.FOExpUId ?? "0"),
						ShpExpDt = (item.ShpExpDt ?? ""),
						ShpExpUId = (item.ShpExpUId ?? "0"),
						ReferUId = (item.ReferUId ?? "0"),
						SuppUId = (item.SuppUId ?? "0")
					};
					if ((string.IsNullOrWhiteSpace(commonFoInfoViewModel2.ReferUId) || commonFoInfoViewModel2.ReferUId == "0") && defaultReferUId.GetValueOrDefault() != 0)
					{
						commonFoInfoViewModel2.ReferUId = defaultReferUId.ToString();
					}
					list.Add(commonFoInfoViewModel2);
				}
			}
			if (list != null && Enumerable.Any<CommonFoInfoViewModel>((IEnumerable<CommonFoInfoViewModel>)list))
			{
				result = JsonConvert.SerializeObject(Enumerable.ToList<CommonFoInfoViewModel>((IEnumerable<CommonFoInfoViewModel>)list));
			}
		}
		catch (Exception e5)
		{
			ErrorSignal.FromCurrentContext().Raise(e5);
		}
		finally
		{
			cRMSpIIEntities?.Dispose();
		}
		return result;
	}

	public static string GetCmpCIds(int cmpId)
	{
		string result = "";
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			CRMspSelectCompanyById_Result companyById = GetCompanyById(cmpId);
			if (companyById != null)
			{
				result = companyById.cmpCIds ?? "";
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return result;
	}

	public static int GetCountCmpCIds(int cmpId)
	{
		int num = 0;
		try
		{
			string cmpCIds = GetCmpCIds(cmpId);
			if (!string.IsNullOrWhiteSpace(cmpCIds))
			{
				string[] array = cmpCIds.Split(new char[1] { ',' });
				if (array != null && array.Length != 0)
				{
					string[] array2 = array;
					foreach (string text in array2)
					{
						if (!string.IsNullOrWhiteSpace(text))
						{
							int result = 0;
							int.TryParse(text, out result);
							if (result != 0)
							{
								num++;
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
		return num;
	}

	public static string GetPrsCIds(int prsId)
	{
		string result = "";
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			CRMspSelectCompanyPersonsByID_Result cRMspSelectCompanyPersonsByID_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyPersonsByID_Result>((IEnumerable<CRMspSelectCompanyPersonsByID_Result>)cRMSpEntities.CRMspSelectCompanyPersonsByID(prsId, lCID, result2));
			if (cRMspSelectCompanyPersonsByID_Result != null)
			{
				result = cRMspSelectCompanyPersonsByID_Result.prsCIds ?? "";
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return result;
	}

	public static int GetCountPrsCIds(int prsId)
	{
		int num = 0;
		try
		{
			string prsCIds = GetPrsCIds(prsId);
			if (!string.IsNullOrWhiteSpace(prsCIds))
			{
				string[] array = prsCIds.Split(new char[1] { ',' });
				if (array != null && array.Length != 0)
				{
					string[] array2 = array;
					foreach (string text in array2)
					{
						if (!string.IsNullOrWhiteSpace(text))
						{
							int result = 0;
							int.TryParse(text, out result);
							if (result != 0)
							{
								num++;
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
		return num;
	}

	public static string GetCmpFoInfoJsonByCmpId(int cmpId)
	{
		string result = "";
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			CRMspSelectCompanyById_Result companyById = GetCompanyById(cmpId);
			if (companyById != null)
			{
				string cIds = companyById.cmpCIds ?? "";
				result = GetFoInfoJsonByName(companyById.cmpFOInfo ?? "", cIds);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return result;
	}

	public static string GetPrsFoInfoJsonByCmpId(int prsId)
	{
		string result = "";
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			CRMspSelectCompanyPersonsByID_Result cRMspSelectCompanyPersonsByID_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyPersonsByID_Result>((IEnumerable<CRMspSelectCompanyPersonsByID_Result>)cRMSpEntities.CRMspSelectCompanyPersonsByID(prsId, lCID, result2));
			if (cRMspSelectCompanyPersonsByID_Result != null)
			{
				string cIds = cRMspSelectCompanyPersonsByID_Result.prsCIds ?? "";
				result = GetFoInfoJsonByName(cRMspSelectCompanyPersonsByID_Result.prsFOInfo ?? "", cIds);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return result;
	}

	public static bool CheckCanDeleteCmpInCurrentCenter(int cmpId)
	{
		bool result = true;
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			string cmpCIds = GetCmpCIds(cmpId);
			if (!string.IsNullOrWhiteSpace(cmpCIds))
			{
				string[] array = cmpCIds.Split(new char[1] { ',' });
				if (array != null)
				{
					if (array.Length > 1)
					{
						for (int i = 0; i < array.Length; i++)
						{
							int result3 = 0;
							int.TryParse(array[i], out result3);
							if (result3 != 0 && result2 != 0 && result3 != result2)
							{
								result = false;
							}
						}
					}
					else
					{
						int result4 = 0;
						int.TryParse(array[0], out result4);
						if (result4 != 0 && result2 != 0 && result4 != result2)
						{
							result = false;
						}
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return result;
	}

	public static bool CheckCanDeletePrsInCurrentCenter(int prsId)
	{
		bool result = true;
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			string prsCIds = GetPrsCIds(prsId);
			if (!string.IsNullOrWhiteSpace(prsCIds))
			{
				string[] array = prsCIds.Split(new char[1] { ',' });
				if (array != null)
				{
					if (array.Length > 1)
					{
						for (int i = 0; i < array.Length; i++)
						{
							int result3 = 0;
							int.TryParse(array[i], out result3);
							if (result3 != 0 && result2 != 0 && result3 != result2)
							{
								result = false;
							}
						}
					}
					else
					{
						int result4 = 0;
						int.TryParse(array[0], out result4);
						if (result4 != 0 && result2 != 0 && result4 != result2)
						{
							result = false;
						}
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return result;
	}

	public static bool SendCmpToLinkAccByShpIsActive(int cmpId, ref string errorMsg)
	{
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		bool flag = true;
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			int result2 = 0;
			CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
			if (cRMspSelectCrmsysSetting_Result != null)
			{
				int.TryParse(cRMspSelectCrmsysSetting_Result.LinkAccSystemId.ToString(), out result2);
			}
			if (result2 != 21)
			{
				flag = true;
				return flag;
			}
			CRMspSelectCompanyById_Result companyById = GetCompanyById(cmpId);
			if (companyById != null)
			{
				List<CommonFoInfoByNameViewModel> list = new List<CommonFoInfoByNameViewModel>();
				string foInfoJsonByName = GetFoInfoJsonByName(companyById.cmpFOInfo ?? "", companyById.cmpCIds ?? "");
				if (!string.IsNullOrWhiteSpace(foInfoJsonByName))
				{
					list = new JavaScriptSerializer().Deserialize<List<CommonFoInfoByNameViewModel>>(foInfoJsonByName);
					if (list != null && Enumerable.Any<CommonFoInfoByNameViewModel>((IEnumerable<CommonFoInfoByNameViewModel>)list))
					{
						foreach (CommonFoInfoByNameViewModel item in list)
						{
							int result3 = 0;
							int.TryParse(item.CId, out result3);
							int result4 = 0;
							int.TryParse(item.ShpAct, out result4);
							if (result3 != 0 && result4 == 1 && flag)
							{
								string errorMsg2 = "";
								flag = OtherSystems.SendCmpToLinkAccByShpIsActive(cmpId, result3, ref errorMsg2);
								errorMsg += errorMsg2;
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
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return flag;
	}

	public static void GetCmpReferAndSuppUserInCenter(int cmpId, ref int referUserId, ref int suppUserId, int userLastCId = 0)
	{
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			if (UserLogin.CurrentUser != null && userLastCId == 0)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out userLastCId);
			}
			CRMspSelectCompanyById_Result companyById = GetCompanyById(cmpId);
			if (companyById == null)
			{
				return;
			}
			List<CommonFoInfoByNameViewModel> list = new List<CommonFoInfoByNameViewModel>();
			string foInfoJsonByName = GetFoInfoJsonByName(companyById.cmpFOInfo ?? "", companyById.cmpCIds ?? "");
			if (string.IsNullOrWhiteSpace(foInfoJsonByName))
			{
				return;
			}
			list = new JavaScriptSerializer().Deserialize<List<CommonFoInfoByNameViewModel>>(foInfoJsonByName);
			if (list == null || !Enumerable.Any<CommonFoInfoByNameViewModel>((IEnumerable<CommonFoInfoByNameViewModel>)list))
			{
				return;
			}
			foreach (CommonFoInfoByNameViewModel item in list)
			{
				int result2 = 0;
				int.TryParse(item.CId, out result2);
				if (result2 != 0 && result2 == userLastCId)
				{
					int.TryParse(item.ReferUId, out referUserId);
					int.TryParse(item.SuppUId, out suppUserId);
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
	}

	public static List<SelectListItem> GetCmpSuppUserList(int userLastCId = 0)
	{
		List<SelectListItem> list = new List<SelectListItem>();
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (UserLogin.CurrentUser != null && userLastCId == 0)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out userLastCId);
			}
			List<CRMspSelectActiveUsers_Result> list2 = Enumerable.ToList<CRMspSelectActiveUsers_Result>((IEnumerable<CRMspSelectActiveUsers_Result>)cRMSpEntities.CRMspSelectActiveUsers(lCID, result, userLastCId));
			if (list2 != null)
			{
				list.AddRange(Enumerable.Select<CRMspSelectActiveUsers_Result, SelectListItem>((IEnumerable<CRMspSelectActiveUsers_Result>)list2, (Func<CRMspSelectActiveUsers_Result, SelectListItem>)((CRMspSelectActiveUsers_Result x) => new SelectListItem
				{
					Text = (x.Name ?? ""),
					Value = x.UserId.ToString(),
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
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return list;
	}

	public static List<SelectListItem> GetCmpReferUserList(int userLastCId = 0)
	{
		List<SelectListItem> list = new List<SelectListItem>();
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (UserLogin.CurrentUser != null && userLastCId == 0)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out userLastCId);
			}
			List<CRMspSelectCompanyReferUsers_Result> list2 = Enumerable.ToList<CRMspSelectCompanyReferUsers_Result>((IEnumerable<CRMspSelectCompanyReferUsers_Result>)cRMSpEntities.CRMspSelectCompanyReferUsers(UserLogin.CurrentUser.UserId, lCID, result, userLastCId));
			if (list2 != null)
			{
				list.AddRange(Enumerable.Select<CRMspSelectCompanyReferUsers_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyReferUsers_Result>)list2, (Func<CRMspSelectCompanyReferUsers_Result, SelectListItem>)((CRMspSelectCompanyReferUsers_Result x) => new SelectListItem
				{
					Text = (x.USER ?? ""),
					Value = x.UserId.ToString(),
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
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return list;
	}

	public static List<CRMspSelectCompanyGroupsIII_Result> GetCompanyGroupsIII()
	{
		List<CRMspSelectCompanyGroupsIII_Result> result = new List<CRMspSelectCompanyGroupsIII_Result>();
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectCompanyGroupsIII_Result> list = Enumerable.ToList<CRMspSelectCompanyGroupsIII_Result>((IEnumerable<CRMspSelectCompanyGroupsIII_Result>)cRMSpEntities.CRMspSelectCompanyGroupsIII(lCID, result2));
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

	public static CRMspSelectCompanyById_Result GetCompanyById(int cmpId, int cId = 0)
	{
		CRMspSelectCompanyById_Result result = new CRMspSelectCompanyById_Result();
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
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
			if (cId != 0)
			{
				result3 = cId;
			}
			result = Enumerable.FirstOrDefault<CRMspSelectCompanyById_Result>((IEnumerable<CRMspSelectCompanyById_Result>)cRMSpEntities.CRMspSelectCompanyById(cmpId, lCID, result2, result3));
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

	public static decimal ReturnCompanyMoneyBagRemain(int cmpId, ref string moneyBagByFormat, int cId = 0)
	{
		decimal num = default(decimal);
		CRMSpIEntities cRMSpIEntities = new CRMSpIEntities();
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
			}
			if (cId != 0)
			{
				result2 = cId;
			}
			if (cmpId != 0)
			{
				num = Enumerable.FirstOrDefault<decimal?>((IEnumerable<decimal?>)cRMSpIEntities.CRMspReturnCompanyMoneyBagRemain(cmpId, result2)).GetValueOrDefault();
				if (num != 0m)
				{
					moneyBagByFormat = $"{num:N2}";
					moneyBagByFormat = moneyBagByFormat.Replace(".00", "");
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		finally
		{
			cRMSpIEntities?.Dispose();
		}
		return num;
	}
}
