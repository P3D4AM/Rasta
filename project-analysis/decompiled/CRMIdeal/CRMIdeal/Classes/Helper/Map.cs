using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CRM.Models;
using CRMIdeal.Cache.Setting;
using Elmah;

namespace CRMIdeal.Classes.Helper;

public class Map
{
	public static string DefaultMapName = "Leaflet";

	public static string LeafletMapName = "Leaflet";

	public static string GMapMapName = "GMap";

	public static string GetDefMapName()
	{
		string result = DefaultMapName;
		try
		{
			List<CrmWebSetting> list = WebSetting.Get();
			if (list != null)
			{
				CrmWebSetting crmWebSetting = Enumerable.FirstOrDefault<CrmWebSetting>((IEnumerable<CrmWebSetting>)list, (Func<CrmWebSetting, bool>)((CrmWebSetting c) => c.Key.Equals("DefMapName")));
				if (crmWebSetting != null && !string.IsNullOrWhiteSpace(crmWebSetting.Value.Split(new char[1] { ':' })[0]))
				{
					result = crmWebSetting.Value.Split(new char[1] { ':' })[0];
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public static List<SelectListItem> GetMapStyles()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		if (GetDefMapName() == LeafletMapName)
		{
			list.Add(new SelectListItem
			{
				Text = $"/Content/Map/{GetDefMapName()}/src/Control.FullScreen.css"
			});
			list.Add(new SelectListItem
			{
				Text = string.Format("/Content/Map/{0}/{0}.css", GetDefMapName())
			});
		}
		return list;
	}

	public static List<SelectListItem> GetMapScripts()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		if (GetDefMapName() == LeafletMapName)
		{
			list.Add(new SelectListItem
			{
				Text = string.Format("/Scripts/Map/{0}/src/{0}.js", GetDefMapName())
			});
			list.Add(new SelectListItem
			{
				Text = $"/Scripts/Map/{GetDefMapName()}/src/Control.FullScreen.js"
			});
		}
		else if (GetDefMapName() == GMapMapName)
		{
			list.Add(new SelectListItem
			{
				Text = "https://maps.googleapis.com/maps/api/js?key=AIzaSyBt9IusW02lgozFd9eCCZ8p6cnoJLOUIro&libraries=visualization&libraries=places"
			});
		}
		list.Add(new SelectListItem
		{
			Text = string.Format("/Scripts/Map/{0}/js{0}.js", GetDefMapName())
		});
		return list;
	}
}
