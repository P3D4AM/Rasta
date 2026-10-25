using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using CRM.Models;
using CRMIdeal.Cache.Setting;
using Elmah;

namespace CRMIdeal.Classes.Helper;

public class PrintFormat
{
	public static string GetPrintFormatTitle(int printFormatId, int currLangId, int defLangId)
	{
		CRMSpIIEntities cRMSpIIEntities = new CRMSpIIEntities();
		string result = "";
		try
		{
			CRMspSelectPrintFormatById_Result cRMspSelectPrintFormatById_Result = Enumerable.FirstOrDefault<CRMspSelectPrintFormatById_Result>((IEnumerable<CRMspSelectPrintFormatById_Result>)cRMSpIIEntities.CRMspSelectPrintFormatById(printFormatId, currLangId, defLangId));
			if (cRMspSelectPrintFormatById_Result != null)
			{
				result = cRMspSelectPrintFormatById_Result.Title ?? "";
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

	public static List<CRMspSelectPrintFormatByTypeId_Result> GetPrintFortants(int userLastCId = 0, int formatTypeId = 0, int sysPartId = 0, int sysPartObjId = 0)
	{
		List<CRMspSelectPrintFormatByTypeId_Result> list = new List<CRMspSelectPrintFormatByTypeId_Result>();
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
			list = Enumerable.ToList<CRMspSelectPrintFormatByTypeId_Result>((IEnumerable<CRMspSelectPrintFormatByTypeId_Result>)cRMSpEntities.CRMspSelectPrintFormatByTypeId(formatTypeId, lCID, result, userLastCId, sysPartId, sysPartObjId));
			if (list == null)
			{
				list = new List<CRMspSelectPrintFormatByTypeId_Result>();
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

	public static List<SelectListItem> GetPrintFortantList(int userLastCId = 0, int formatTypeId = 0, int sysPartId = 0, int sysPartObjId = 0)
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
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			if (UserLogin.CurrentUser != null && userLastCId == 0)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out userLastCId);
			}
			List<CRMspSelectPrintFormatByTypeId_Result> printFortants = GetPrintFortants(userLastCId, formatTypeId, sysPartId, sysPartObjId);
			if (printFortants != null)
			{
				list.AddRange(Enumerable.Select<CRMspSelectPrintFormatByTypeId_Result, SelectListItem>((IEnumerable<CRMspSelectPrintFormatByTypeId_Result>)printFortants, (Func<CRMspSelectPrintFormatByTypeId_Result, SelectListItem>)((CRMspSelectPrintFormatByTypeId_Result x) => new SelectListItem
				{
					Text = (x.Title ?? ""),
					Value = x.PrintFormatID.ToString(),
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

	public static List<spSelectPrintFormat_Result> GetspPrintFortants(int userLastCId = 0, int formatTypeId = 0, int sysPartId = 0, int sysPartObjId = 0)
	{
		List<spSelectPrintFormat_Result> list = new List<spSelectPrintFormat_Result>();
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
			list = Enumerable.ToList<spSelectPrintFormat_Result>((IEnumerable<spSelectPrintFormat_Result>)cRMSpEntities.spSelectPrintFormat(formatTypeId, lCID, result, userLastCId, sysPartId, sysPartObjId));
			if (list == null)
			{
				list = new List<spSelectPrintFormat_Result>();
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

	public static List<SelectListItem> GetspPrintFortantList(int userLastCId = 0, int formatTypeId = 0, int sysPartId = 0, int sysPartObjId = 0)
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
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			if (UserLogin.CurrentUser != null && userLastCId == 0)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out userLastCId);
			}
			List<spSelectPrintFormat_Result> list2 = GetspPrintFortants(userLastCId, formatTypeId, sysPartId, sysPartObjId);
			if (list2 != null)
			{
				list.AddRange(Enumerable.Select<spSelectPrintFormat_Result, SelectListItem>((IEnumerable<spSelectPrintFormat_Result>)list2, (Func<spSelectPrintFormat_Result, SelectListItem>)((spSelectPrintFormat_Result x) => new SelectListItem
				{
					Text = (x.Title ?? ""),
					Value = x.PrintFormatID.ToString(),
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

	public static CRMspSelectPrintFormatById_Result GetPrintFormatById(int printFormatId, int currLangId, int defLangId)
	{
		CRMSpIIEntities cRMSpIIEntities = new CRMSpIIEntities();
		CRMspSelectPrintFormatById_Result result = new CRMspSelectPrintFormatById_Result();
		try
		{
			if (defLangId == 0)
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out defLangId);
			}
			if (defLangId <= 0)
			{
				defLangId = 1065;
			}
			if (currLangId == 0)
			{
				currLangId = Thread.CurrentThread.CurrentCulture.LCID;
			}
			result = Enumerable.FirstOrDefault<CRMspSelectPrintFormatById_Result>((IEnumerable<CRMspSelectPrintFormatById_Result>)cRMSpIIEntities.CRMspSelectPrintFormatById(printFormatId, currLangId, defLangId));
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

	public static int GetPrintFormatCId(int printFormatId = 0, string fileName = "", int currLangId = 0, int defLangId = 0)
	{
		CRMSpIIEntities cRMSpIIEntities = new CRMSpIIEntities();
		int result = 0;
		try
		{
			if (defLangId == 0)
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out defLangId);
			}
			if (defLangId <= 0)
			{
				defLangId = 1065;
			}
			if (currLangId == 0)
			{
				currLangId = Thread.CurrentThread.CurrentCulture.LCID;
			}
			if (printFormatId != 0)
			{
				CRMspSelectPrintFormatById_Result cRMspSelectPrintFormatById_Result = Enumerable.FirstOrDefault<CRMspSelectPrintFormatById_Result>((IEnumerable<CRMspSelectPrintFormatById_Result>)cRMSpIIEntities.CRMspSelectPrintFormatById(printFormatId, currLangId, defLangId));
				if (cRMspSelectPrintFormatById_Result != null)
				{
					result = cRMspSelectPrintFormatById_Result.CId.GetValueOrDefault();
				}
			}
			else if (!string.IsNullOrWhiteSpace(fileName))
			{
				if (!fileName.ToLower().EndsWith(".mrt"))
				{
					fileName += ".mrt";
				}
				CRMspSelectPrintFormatByFileNameWeb_Result cRMspSelectPrintFormatByFileNameWeb_Result = Enumerable.FirstOrDefault<CRMspSelectPrintFormatByFileNameWeb_Result>((IEnumerable<CRMspSelectPrintFormatByFileNameWeb_Result>)cRMSpIIEntities.CRMspSelectPrintFormatByFileNameWeb(fileName, currLangId, defLangId));
				if (cRMspSelectPrintFormatByFileNameWeb_Result != null)
				{
					result = cRMspSelectPrintFormatByFileNameWeb_Result.CId.GetValueOrDefault();
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
}
