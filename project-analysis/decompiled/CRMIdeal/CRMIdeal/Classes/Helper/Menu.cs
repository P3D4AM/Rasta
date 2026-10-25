using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading;
using CRM.Models;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Cache.User;
using Elmah;
using Newtonsoft.Json;

namespace CRMIdeal.Classes.Helper;

public class Menu
{
	public List<CRMspSelectRollMenuItems_Result> GetRollMenu(int menuTypeId = 1)
	{
		CRMSpIEntities cRMSpIEntities = new CRMSpIEntities();
		List<CRMspSelectRollMenuItems_Result> list = new List<CRMspSelectRollMenuItems_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			list = Enumerable.ToList<CRMspSelectRollMenuItems_Result>((IEnumerable<CRMspSelectRollMenuItems_Result>)cRMSpIEntities.CRMspSelectRollMenuItems(Info.Get().RollId, menuTypeId, lCID, result));
			if (list.Count > 0)
			{
				string text = "";
				string link = "";
				text = ((SysSeting.Get().FOUrl != null) ? SysSeting.Get().FOUrl.ToString() : "");
				text = text ?? "";
				if (!string.IsNullOrWhiteSpace(text))
				{
					if (!text.StartsWith("http"))
					{
						text = "http://" + text;
					}
					if (!text.EndsWith("/"))
					{
						text += "/";
					}
					link = text + "Home/Index?crmMode=1";
					text += "Home/Index?crmMode=2";
				}
				if (Enumerable.FirstOrDefault<CRMspSelectRollMenuItems_Result>((IEnumerable<CRMspSelectRollMenuItems_Result>)list, (Func<CRMspSelectRollMenuItems_Result, bool>)((CRMspSelectRollMenuItems_Result x) => x.MenuItemName == "mnuGoToFoUrl")) != null)
				{
					Enumerable.FirstOrDefault<CRMspSelectRollMenuItems_Result>((IEnumerable<CRMspSelectRollMenuItems_Result>)list, (Func<CRMspSelectRollMenuItems_Result, bool>)((CRMspSelectRollMenuItems_Result x) => x.MenuItemName == "mnuGoToFoUrl")).Link = text;
				}
				if (Enumerable.FirstOrDefault<CRMspSelectRollMenuItems_Result>((IEnumerable<CRMspSelectRollMenuItems_Result>)list, (Func<CRMspSelectRollMenuItems_Result, bool>)((CRMspSelectRollMenuItems_Result x) => x.MenuItemName == "mnuGoToStoreUrl")) != null)
				{
					Enumerable.FirstOrDefault<CRMspSelectRollMenuItems_Result>((IEnumerable<CRMspSelectRollMenuItems_Result>)list, (Func<CRMspSelectRollMenuItems_Result, bool>)((CRMspSelectRollMenuItems_Result x) => x.MenuItemName == "mnuGoToStoreUrl")).Link = link;
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
		finally
		{
			cRMSpIEntities.Dispose();
		}
		return list;
	}

	public string GetRollSideMenuJs()
	{
		return JsonConvert.SerializeObject(GetRollMenu());
	}

	public string GetRollMegaMenuJs()
	{
		return JsonConvert.SerializeObject(GetRollMenu(2));
	}

	public List<CRMspSelectSysMenuItems_Result> GetSysMenu()
	{
		CRMSpIEntities cRMSpIEntities = new CRMSpIEntities();
		List<CRMspSelectSysMenuItems_Result> list = new List<CRMspSelectSysMenuItems_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			list = Enumerable.ToList<CRMspSelectSysMenuItems_Result>((IEnumerable<CRMspSelectSysMenuItems_Result>)cRMSpIEntities.CRMspSelectSysMenuItems(lCID, result));
			if (list.Count > 0)
			{
				string text = "";
				string link = "";
				text = ((SysSeting.Get().FOUrl != null) ? SysSeting.Get().FOUrl.ToString() : "");
				text = text ?? "";
				if (!string.IsNullOrWhiteSpace(text))
				{
					if (!text.StartsWith("http"))
					{
						text = "http://" + text;
					}
					if (!text.EndsWith("/"))
					{
						text += "/";
					}
					link = text + "Home/Index?crmMode=1";
					text += "Home/Index?crmMode=2";
				}
				Enumerable.FirstOrDefault<CRMspSelectSysMenuItems_Result>((IEnumerable<CRMspSelectSysMenuItems_Result>)list, (Func<CRMspSelectSysMenuItems_Result, bool>)((CRMspSelectSysMenuItems_Result x) => x.MenuItemName == "mnuGoToFoUrl")).Link = text;
				Enumerable.FirstOrDefault<CRMspSelectSysMenuItems_Result>((IEnumerable<CRMspSelectSysMenuItems_Result>)list, (Func<CRMspSelectSysMenuItems_Result, bool>)((CRMspSelectSysMenuItems_Result x) => x.MenuItemName == "mnuGoToStoreUrl")).Link = link;
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
		finally
		{
			cRMSpIEntities.Dispose();
		}
		return list;
	}

	public string GetSysMenuJs()
	{
		return JsonConvert.SerializeObject(GetSysMenu());
	}
}
