using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using CRM.Models;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes.Common;
using Newtonsoft.Json;

namespace CRMIdeal.Classes.Helper;

public class MainSearch
{
	[LoginAuthorize]
	public static List<CRMspMainSearchWebSmart_Result> MainSearchWebSmart(string srchVal = "", int? srchType = null, string srchCols = "")
	{
		List<CRMspMainSearchWebSmart_Result> res = new List<CRMspMainSearchWebSmart_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int userId = UserLogin.CurrentUser.UserId;
			CRMSpIEntities cRMSpIEntities = new CRMSpIEntities();
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			try
			{
				List<CRMspMainSearchWebSmart_Result> list = Enumerable.ToList<CRMspMainSearchWebSmart_Result>((IEnumerable<CRMspMainSearchWebSmart_Result>)cRMSpIEntities.CRMspMainSearchWebSmart(srchVal, userId, srchType, lCID, result, srchCols, result2));
				if (list != null)
				{
					res.AddRange(list);
				}
				srchCols = ((!srchCols.Contains("1000") && !srchCols.Contains("1001") && !srchCols.Contains("1002")) ? (string.Join(",", Enumerable.ToList<string>(Enumerable.Where<string>((IEnumerable<string>)Enumerable.ToList<string>((IEnumerable<string>)srchCols.Split(new char[1] { ',' })), (Func<string, bool>)((string x) => x != "1003")))) + ",1000,1002") : (string.Join(",", Enumerable.ToList<string>(Enumerable.Where<string>((IEnumerable<string>)Enumerable.ToList<string>((IEnumerable<string>)srchCols.Split(new char[1] { ',' })), (Func<string, bool>)((string x) => x != "1000" && x != "1001" && x != "1002")))) + ",1003"));
				list = Enumerable.ToList<CRMspMainSearchWebSmart_Result>((IEnumerable<CRMspMainSearchWebSmart_Result>)cRMSpIEntities.CRMspMainSearchWebSmart(srchVal, userId, srchType, lCID, result, srchCols, result2));
				if (list != null)
				{
					res.AddRange(Enumerable.ToList<CRMspMainSearchWebSmart_Result>(Enumerable.Where<CRMspMainSearchWebSmart_Result>((IEnumerable<CRMspMainSearchWebSmart_Result>)list, (Func<CRMspMainSearchWebSmart_Result, bool>)((CRMspMainSearchWebSmart_Result x) => Enumerable.FirstOrDefault<CRMspMainSearchWebSmart_Result>((IEnumerable<CRMspMainSearchWebSmart_Result>)res, (Func<CRMspMainSearchWebSmart_Result, bool>)((CRMspMainSearchWebSmart_Result r) => r.CompanyID == x.CompanyID)) == null))));
				}
				foreach (CRMspMainSearchWebSmart_Result item in res)
				{
					if (!string.IsNullOrWhiteSpace(item.cmpEffectiveDatePersian))
					{
						item.cmpEffectiveDatePersian = item.cmpEffectiveDateTime?.ToString("yyyy/MM/dd");
					}
					if (!string.IsNullOrWhiteSpace(item.FirstRegisterDatePersian))
					{
						item.FirstRegisterDatePersian = item.FirstRegisterDate?.ToString("yyyy/MM/dd HH:mm:ss");
					}
					if (!string.IsNullOrWhiteSpace(item.RegisterDatePersian))
					{
						item.RegisterDatePersian = item.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
					}
					item.cmpCode = OtherSystems.GetLinkAccCodeWithComa(1, item.cmpCode);
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
		}
		catch (Exception ex2)
		{
			Public.InsExceptToElmah(ex2);
		}
		return res;
	}

	public static string MainSearchWebSmartJs(string srchVal = "", int? srchType = null, string srchCols = "")
	{
		return JsonConvert.SerializeObject(MainSearchWebSmart(srchVal, srchType, srchCols));
	}

	public static List<SelectListItem> MainSearchWebSmartWithDelay(string srchVal = "", int? srchType = null, string srchCols = "")
	{
		List<SelectListItem> list = new List<SelectListItem>();
		DateTime now = DateTime.Now;
		list.Add(new SelectListItem
		{
			Value = MainSearchWebSmartJs(srchVal, srchType, srchCols)
		});
		DateTime now2 = DateTime.Now;
		list.Add(new SelectListItem
		{
			Value = (now2 - now).ToString()
		});
		return list;
	}
}
