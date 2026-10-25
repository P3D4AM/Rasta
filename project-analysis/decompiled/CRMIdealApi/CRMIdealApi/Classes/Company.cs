using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CRM.General.Utilities;
using CRMIdealApi.ApiModels;
using CRMIdealApi.Classes.Common;
using CRMIdealApi.Resources;
using Elmah;

namespace CRMIdealApi.Classes;

public class Company
{
	public static string GetCompanyName(int comanyId, int cmpNumber, string cmpCode, int defLangId, int currLangId)
	{
		CRMEntities cRMEntities = new CRMEntities();
		string result = "";
		try
		{
			ApispSelectCompanyWithIdNumberCode_Result apispSelectCompanyWithIdNumberCode_Result = Enumerable.FirstOrDefault<ApispSelectCompanyWithIdNumberCode_Result>((IEnumerable<ApispSelectCompanyWithIdNumberCode_Result>)cRMEntities.ApispSelectCompanyWithIdNumberCode(comanyId, cmpNumber, cmpCode, currLangId, defLangId));
			if (apispSelectCompanyWithIdNumberCode_Result != null)
			{
				result = ((!string.IsNullOrEmpty(apispSelectCompanyWithIdNumberCode_Result.CompanyName)) ? apispSelectCompanyWithIdNumberCode_Result.CompanyName : "");
			}
			cRMEntities.Dispose();
		}
		catch (Exception)
		{
			cRMEntities.Dispose();
		}
		finally
		{
			cRMEntities.Dispose();
		}
		return result;
	}

	public static string GetPersonName(int prsId, int defLangId, int currLangId)
	{
		CRMEntities cRMEntities = new CRMEntities();
		string result = "";
		try
		{
			ApispSelectCompanyPersonWithId_Result apispSelectCompanyPersonWithId_Result = Enumerable.FirstOrDefault<ApispSelectCompanyPersonWithId_Result>((IEnumerable<ApispSelectCompanyPersonWithId_Result>)cRMEntities.ApispSelectCompanyPersonWithId(prsId, currLangId, defLangId));
			if (apispSelectCompanyPersonWithId_Result != null)
			{
				result = ((!string.IsNullOrEmpty(apispSelectCompanyPersonWithId_Result.Person)) ? apispSelectCompanyPersonWithId_Result.Person : "");
			}
			cRMEntities.Dispose();
		}
		catch (Exception)
		{
			cRMEntities.Dispose();
		}
		finally
		{
			cRMEntities.Dispose();
		}
		return result;
	}

	public static string GetProjectTitle(int prjId, int defLangId, int currLangId)
	{
		CRMEntities cRMEntities = new CRMEntities();
		string result = "";
		try
		{
			ApispSelectProjectWithId_Result apispSelectProjectWithId_Result = Enumerable.FirstOrDefault<ApispSelectProjectWithId_Result>((IEnumerable<ApispSelectProjectWithId_Result>)cRMEntities.ApispSelectProjectWithId(prjId, currLangId, defLangId));
			if (apispSelectProjectWithId_Result != null)
			{
				result = ((!string.IsNullOrEmpty(apispSelectProjectWithId_Result.ProjectTitle)) ? apispSelectProjectWithId_Result.ProjectTitle : "");
			}
			cRMEntities.Dispose();
		}
		catch (Exception)
		{
			cRMEntities.Dispose();
		}
		finally
		{
			cRMEntities.Dispose();
		}
		return result;
	}

	public static string CreateCmpPassword(string password)
	{
		string result = "";
		try
		{
			string text = DateTime.Now.ToString("fffss");
			Random random = new Random();
			string text2 = random.Next(1000, 9999).ToString();
			result = text + password + text2;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public static string CheckDuplicateCompanyCode(int cmpId, string cmpCode, int defLangId, int currLangId, string defLangCollation)
	{
		CRMEntities cRMEntities = new CRMEntities();
		string result = "";
		try
		{
			ApispCheckDuplicateCompanyCode_Result apispCheckDuplicateCompanyCode_Result = Enumerable.FirstOrDefault<ApispCheckDuplicateCompanyCode_Result>((IEnumerable<ApispCheckDuplicateCompanyCode_Result>)cRMEntities.ApispCheckDuplicateCompanyCode(cmpCode, cmpId, currLangId, defLangId));
			if (apispCheckDuplicateCompanyCode_Result != null)
			{
				result = string.Format(MyResource.GetResourceString("ErrorCmpCodeDuplicate", defLangCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), apispCheckDuplicateCompanyCode_Result.CompanyName ?? "");
			}
			cRMEntities.Dispose();
		}
		catch (Exception)
		{
			cRMEntities.Dispose();
		}
		finally
		{
			cRMEntities.Dispose();
		}
		return result;
	}

	public static string CantSaveDupTel(string tel, int mode, int currentId, int defLangId, int currLangId, string defLangCollation)
	{
		CRMEntities cRMEntities = new CRMEntities();
		string result = "";
		try
		{
			ApispCheckDuplicateTel_Result apispCheckDuplicateTel_Result = Enumerable.FirstOrDefault<ApispCheckDuplicateTel_Result>((IEnumerable<ApispCheckDuplicateTel_Result>)cRMEntities.ApispCheckDuplicateTel(tel, mode, currentId, currLangId, defLangId));
			if (apispCheckDuplicateTel_Result != null)
			{
				result = string.Format(MyResource.GetResourceString("ErrorDuplicateTel", defLangCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), apispCheckDuplicateTel_Result.cmpNumber.ToString(), apispCheckDuplicateTel_Result.CompanyName ?? "");
			}
			cRMEntities.Dispose();
		}
		catch (Exception)
		{
			cRMEntities.Dispose();
		}
		finally
		{
			cRMEntities.Dispose();
		}
		return result;
	}

	public static string CantSaveDupFax(string tel, int mode, int currentId, int defLangId, int currLangId, string defLangCollation)
	{
		CRMEntities cRMEntities = new CRMEntities();
		string result = "";
		try
		{
			ApispCheckDuplicateTel_Result apispCheckDuplicateTel_Result = Enumerable.FirstOrDefault<ApispCheckDuplicateTel_Result>((IEnumerable<ApispCheckDuplicateTel_Result>)cRMEntities.ApispCheckDuplicateTel(tel, mode, currentId, currLangId, defLangId));
			if (apispCheckDuplicateTel_Result != null)
			{
				result = string.Format(MyResource.GetResourceString("ErrorDuplicateFax", defLangCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), apispCheckDuplicateTel_Result.cmpNumber.ToString(), apispCheckDuplicateTel_Result.CompanyName ?? "");
			}
			cRMEntities.Dispose();
		}
		catch (Exception)
		{
			cRMEntities.Dispose();
		}
		finally
		{
			cRMEntities.Dispose();
		}
		return result;
	}

	public static string CantSaveDupZipCode(string zipCode, int mode, int currentId, int defLangId, int currLangId, string defLangCollation)
	{
		CRMEntities cRMEntities = new CRMEntities();
		string result = "";
		try
		{
			ApispCheckDuplicateZipCode_Result apispCheckDuplicateZipCode_Result = Enumerable.FirstOrDefault<ApispCheckDuplicateZipCode_Result>((IEnumerable<ApispCheckDuplicateZipCode_Result>)cRMEntities.ApispCheckDuplicateZipCode(zipCode, mode, currentId, currLangId, defLangId));
			if (apispCheckDuplicateZipCode_Result != null)
			{
				result = string.Format(MyResource.GetResourceString("ErrorDuplicateZipCode", defLangCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), apispCheckDuplicateZipCode_Result.cmpNumber.ToString(), apispCheckDuplicateZipCode_Result.CompanyName ?? "");
			}
			cRMEntities.Dispose();
		}
		catch (Exception)
		{
			cRMEntities.Dispose();
		}
		finally
		{
			cRMEntities.Dispose();
		}
		return result;
	}

	public static string CantSaveDupCmpNationalCode(string cmpNCode, int currentId, int defLangId, int currLangId, string defLangCollation)
	{
		CRMEntities cRMEntities = new CRMEntities();
		string result = "";
		try
		{
			ApispCheckDuplicateCmpNationalCode_Result apispCheckDuplicateCmpNationalCode_Result = Enumerable.FirstOrDefault<ApispCheckDuplicateCmpNationalCode_Result>((IEnumerable<ApispCheckDuplicateCmpNationalCode_Result>)cRMEntities.ApispCheckDuplicateCmpNationalCode(cmpNCode, currentId, currLangId, defLangId));
			if (apispCheckDuplicateCmpNationalCode_Result != null)
			{
				result = string.Format(MyResource.GetResourceString("ErrorDuplicateCmpNationalCode", defLangCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), apispCheckDuplicateCmpNationalCode_Result.cmpNumber.ToString(), apispCheckDuplicateCmpNationalCode_Result.CompanyName ?? "");
			}
			cRMEntities.Dispose();
		}
		catch (Exception)
		{
			cRMEntities.Dispose();
		}
		finally
		{
			cRMEntities.Dispose();
		}
		return result;
	}

	public static string CantSaveDupCmpEconomicCode(string cmpEcoCode, int currentId, int defLangId, int currLangId, string defLangCollation)
	{
		CRMEntities cRMEntities = new CRMEntities();
		string result = "";
		try
		{
			ApispCheckDuplicateCmpEconomicCode_Result apispCheckDuplicateCmpEconomicCode_Result = Enumerable.FirstOrDefault<ApispCheckDuplicateCmpEconomicCode_Result>((IEnumerable<ApispCheckDuplicateCmpEconomicCode_Result>)cRMEntities.ApispCheckDuplicateCmpEconomicCode(cmpEcoCode, currentId, currLangId, defLangId));
			if (apispCheckDuplicateCmpEconomicCode_Result != null)
			{
				result = string.Format(MyResource.GetResourceString("ErrorDuplicateCmpEconomicCode", defLangCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), apispCheckDuplicateCmpEconomicCode_Result.cmpNumber.ToString(), apispCheckDuplicateCmpEconomicCode_Result.CompanyName ?? "");
			}
			cRMEntities.Dispose();
		}
		catch (Exception)
		{
			cRMEntities.Dispose();
		}
		finally
		{
			cRMEntities.Dispose();
		}
		return result;
	}

	public static string CantSaveDupCmpEmail(string cmpEmail, int currentId, int defLangId, int currLangId, string defLangCollation)
	{
		CRMEntities cRMEntities = new CRMEntities();
		string result = "";
		try
		{
			ApispCheckDuplicateCmpEmail_Result apispCheckDuplicateCmpEmail_Result = Enumerable.FirstOrDefault<ApispCheckDuplicateCmpEmail_Result>((IEnumerable<ApispCheckDuplicateCmpEmail_Result>)cRMEntities.ApispCheckDuplicateCmpEmail(cmpEmail, currentId, currLangId, defLangId));
			if (apispCheckDuplicateCmpEmail_Result != null)
			{
				result = string.Format(MyResource.GetResourceString("ErrorDuplicateCmpEmail", defLangCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), apispCheckDuplicateCmpEmail_Result.cmpNumber.ToString(), apispCheckDuplicateCmpEmail_Result.CompanyName ?? "");
			}
			cRMEntities.Dispose();
		}
		catch (Exception)
		{
			cRMEntities.Dispose();
		}
		finally
		{
			cRMEntities.Dispose();
		}
		return result;
	}

	public static string CantSaveDupCmpMobile(string cmpMobile, int currentId, int defLangId, int currLangId, string defLangCollation)
	{
		CRMEntities cRMEntities = new CRMEntities();
		string result = "";
		try
		{
			ApispCheckDuplicateCmpMobile_Result apispCheckDuplicateCmpMobile_Result = Enumerable.FirstOrDefault<ApispCheckDuplicateCmpMobile_Result>((IEnumerable<ApispCheckDuplicateCmpMobile_Result>)cRMEntities.ApispCheckDuplicateCmpMobile(cmpMobile, currentId, currLangId, defLangId));
			if (apispCheckDuplicateCmpMobile_Result != null)
			{
				result = string.Format(MyResource.GetResourceString("ErrorDuplicateCmpMobile", defLangCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), apispCheckDuplicateCmpMobile_Result.cmpNumber.ToString(), apispCheckDuplicateCmpMobile_Result.CompanyName ?? "");
			}
			cRMEntities.Dispose();
		}
		catch (Exception)
		{
			cRMEntities.Dispose();
		}
		finally
		{
			cRMEntities.Dispose();
		}
		return result;
	}

	public static string CantSaveDupPrsNationalCode(string prsNCode, int currentId, int defLangId, int currLangId, string defLangCollation)
	{
		CRMEntities cRMEntities = new CRMEntities();
		string result = "";
		try
		{
			ApispCheckDuplicatePrsNationalCode_Result apispCheckDuplicatePrsNationalCode_Result = Enumerable.FirstOrDefault<ApispCheckDuplicatePrsNationalCode_Result>((IEnumerable<ApispCheckDuplicatePrsNationalCode_Result>)cRMEntities.ApispCheckDuplicatePrsNationalCode(prsNCode, currentId, currLangId, defLangId));
			if (apispCheckDuplicatePrsNationalCode_Result != null)
			{
				result = string.Format(MyResource.GetResourceString("ErrorDuplicatePrsNationalCode", defLangCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), apispCheckDuplicatePrsNationalCode_Result.cmpNumber.ToString(), apispCheckDuplicatePrsNationalCode_Result.CompanyName ?? "");
			}
			cRMEntities.Dispose();
		}
		catch (Exception)
		{
			cRMEntities.Dispose();
		}
		finally
		{
			cRMEntities.Dispose();
		}
		return result;
	}

	public static string CantSaveDupPrjPostFix(string prjPostFix, int currentId, int defLangId, int currLangId, string defLangCollation)
	{
		CRMEntities cRMEntities = new CRMEntities();
		string result = "";
		try
		{
			ApispCheckDuplicatePrjPostFix_Result apispCheckDuplicatePrjPostFix_Result = Enumerable.FirstOrDefault<ApispCheckDuplicatePrjPostFix_Result>((IEnumerable<ApispCheckDuplicatePrjPostFix_Result>)cRMEntities.ApispCheckDuplicatePrjPostFix(prjPostFix, currentId, currLangId, defLangId));
			if (apispCheckDuplicatePrjPostFix_Result != null)
			{
				result = string.Format(MyResource.GetResourceString("ErrorDuplicatePrjPostFix", defLangCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), apispCheckDuplicatePrjPostFix_Result.CompanyNumber.ToString(), apispCheckDuplicatePrjPostFix_Result.CompanyName ?? "");
			}
			cRMEntities.Dispose();
		}
		catch (Exception)
		{
			cRMEntities.Dispose();
		}
		finally
		{
			cRMEntities.Dispose();
		}
		return result;
	}

	public static string CantSaveDupPrjDesc(string prjDesc, int currentId, int defLangId, int currLangId, string defLangCollation)
	{
		CRMEntities cRMEntities = new CRMEntities();
		string result = "";
		try
		{
			ApispCheckDuplicatePrjDesc_Result apispCheckDuplicatePrjDesc_Result = Enumerable.FirstOrDefault<ApispCheckDuplicatePrjDesc_Result>((IEnumerable<ApispCheckDuplicatePrjDesc_Result>)cRMEntities.ApispCheckDuplicatePrjDesc(prjDesc, currentId, currLangId, defLangId));
			if (apispCheckDuplicatePrjDesc_Result != null)
			{
				result = string.Format(MyResource.GetResourceString("ErrorDuplicatePrjDesc", defLangCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), apispCheckDuplicatePrjDesc_Result.CompanyNumber.ToString(), apispCheckDuplicatePrjDesc_Result.CompanyName ?? "");
			}
			cRMEntities.Dispose();
		}
		catch (Exception)
		{
			cRMEntities.Dispose();
		}
		finally
		{
			cRMEntities.Dispose();
		}
		return result;
	}

	public static string CantSaveDupPrjNumR(int? companyId, long? prjNumR, string prjTitle, int currentId, int defLangId, int currLangId, string defLangCollation)
	{
		CRMEntities cRMEntities = new CRMEntities();
		string result = "";
		try
		{
			ApispCheckDuplicatePrjNumR_Result apispCheckDuplicatePrjNumR_Result = Enumerable.FirstOrDefault<ApispCheckDuplicatePrjNumR_Result>((IEnumerable<ApispCheckDuplicatePrjNumR_Result>)cRMEntities.ApispCheckDuplicatePrjNumR(companyId, prjNumR, currentId, prjTitle, currLangId, defLangId));
			if (apispCheckDuplicatePrjNumR_Result != null)
			{
				result = string.Format(MyResource.GetResourceString("ErrorDuplicatePrjNumR", defLangCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), apispCheckDuplicatePrjNumR_Result.CompanyNumber.ToString(), apispCheckDuplicatePrjNumR_Result.CompanyName ?? "");
			}
			cRMEntities.Dispose();
		}
		catch (Exception)
		{
			cRMEntities.Dispose();
		}
		finally
		{
			cRMEntities.Dispose();
		}
		return result;
	}

	public static string CantSaveDupPrjNumRef(string prjNumRef, int currentId, int defLangId, int currLangId, string defLangCollation)
	{
		CRMEntities cRMEntities = new CRMEntities();
		string result = "";
		try
		{
			ApispCheckDuplicatePrjNumRef_Result apispCheckDuplicatePrjNumRef_Result = Enumerable.FirstOrDefault<ApispCheckDuplicatePrjNumRef_Result>((IEnumerable<ApispCheckDuplicatePrjNumRef_Result>)cRMEntities.ApispCheckDuplicatePrjNumRef(prjNumRef, currentId, currLangId, defLangId));
			if (apispCheckDuplicatePrjNumRef_Result != null)
			{
				result = string.Format(MyResource.GetResourceString("ErrorDuplicatePrjNumRef", defLangCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), apispCheckDuplicatePrjNumRef_Result.CompanyNumber.ToString(), apispCheckDuplicatePrjNumRef_Result.CompanyName ?? "");
			}
			cRMEntities.Dispose();
		}
		catch (Exception)
		{
			cRMEntities.Dispose();
		}
		finally
		{
			cRMEntities.Dispose();
		}
		return result;
	}

	public static List<ApispSelectCompanyGroupsIII_Result> GetCompanyGroupsIII(int? currLangId = 1065, int? defLangId = 1065)
	{
		List<ApispSelectCompanyGroupsIII_Result> result = new List<ApispSelectCompanyGroupsIII_Result>();
		CRMEntities cRMEntities = new CRMEntities();
		try
		{
			List<ApispSelectCompanyGroupsIII_Result> list = Enumerable.ToList<ApispSelectCompanyGroupsIII_Result>((IEnumerable<ApispSelectCompanyGroupsIII_Result>)cRMEntities.ApispSelectCompanyGroupsIII(currLangId, defLangId));
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
			cRMEntities?.Dispose();
		}
		return result;
	}
}
