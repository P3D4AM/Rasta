using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CRM.General.Web;

public class SEO
{
	private SEOParamsViewModel Params = new SEOParamsViewModel();

	public const int Title_MaxLen = 55;

	public const int Desc_MaxLen = 155;

	public const int Author_MaxLen = 55;

	public const int Copyright_MaxLen = 120;

	public const int FAQ_Ques_MaxLen = 120;

	public const int FAQ_Ans_MaxLen = 600;

	public static string Title_KeyName => "title";

	public static string Description_KeyName => "description";

	public static string Author_KeyName => "author";

	public static string Copyright_KeyName => "copyright";

	public static string Robots_KeyName => "robots";

	public static string Robots_DefaultValue => Robots_Value_Index + "," + Robots_Value_Follow;

	public static string Robots_Value_Index => "index";

	public static string Robots_Value_NoIndex => "noindex";

	public static string Robots_Value_Follow => "follow";

	public static string Robots_Value_NoFollow => "nofollow";

	public static string Robots_Value_NoSnippet => "nosnippet";

	public static string Robots_Value_NoArchive => "noarchive";

	public static string Robots_Value_MaxSnippet => "max-snippet:-1";

	public static string Robots_Value_MaxImagePreview => "max-image-preview:large";

	public static string Robots_Value_MaxVideoPreview => "max-video-preview:-1";

	public static string Robots_Value_None => "none";

	public static string HttpEquiv_KeyName => "http-equiv";

	public static string HttpEquiv_DefaultValue => HttpEquiv_Value_Content_Type;

	public static string HttpEquiv_Value_Content_Type => "content-type";

	public static string HttpEquiv_Value_Default_Style => "default-style";

	public static string HttpEquiv_Value_Refresh => "refresh";

	public static string HttpEquiv_Value_x_ua_Compatible => "x-ua-compatible";

	private static string HttpEquiv_Content_Security_Policy => "content-security-policy";

	public static string Expires_KeyName => "expires";

	public static string Expires_DefaultValue => Expires_Value_0;

	public static string Expires_Value_Never => "never";

	public static string Expires_Value_0 => "0";

	public static string GoogleNotranslate_KeyName => "google";

	public static bool GoogleNotranslate_DefaultValue => false;

	public static string Distribution_KeyName => "distribution";

	public static string Distribution_DefaultValue => Distribution_Value_Global;

	public static string Distribution_Value_Global => "global";

	public static string Distribution_Value_Local => "local";

	public static string Rating_KeyName => "rating";

	public static string Rating_DefaultValue => Rating_Value_General;

	public static string Rating_Value_General => "general";

	public static string Rating_Value_Mature => "mature";

	public static string Rating_Value_Adult => "adult";

	public static string IsUseSocialNetwork_Twitter_KeyName => "twitter";

	public static string IsUseSocialNetwork_OG_KeyName => "og";

	public static string IsUseSocialNetwork_All_Keys => IsUseSocialNetwork_OG_KeyName + "," + IsUseSocialNetwork_Twitter_KeyName;

	public static bool IsUseSocialNetwork_DefaultValue => true;

	public static string MobileOptimized_KeyName => "MobileOptimized";

	public static string MobileOptimized_DefaultValue => MobileOptimized_Yes.Value;

	public static SelectListItem MobileOptimized_No => new SelectListItem
	{
		Text = "No",
		Value = "0"
	};

	public static SelectListItem MobileOptimized_Yes => new SelectListItem
	{
		Text = "Yes",
		Value = "1"
	};

	public static SelectListItem MobileOptimized_Responsive => new SelectListItem
	{
		Text = "Responsive",
		Value = "2"
	};

	public static string Keywords_KeyName => "keywords";

	public static string FAQ_KeyName => "faq";

	public SEO(SEOParamsViewModel p = null)
	{
		if (p != null)
		{
			Params = p;
		}
	}

	private List<SelectListItem> GetSelectListItems()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		if (Params != null)
		{
			if (Params.AddBefore_SelectListItem != null)
			{
				list.Add(Params.AddBefore_SelectListItem);
			}
			if (Params.AddBefore_SelectListItems != null)
			{
				list.AddRange(Params.AddBefore_SelectListItems);
			}
		}
		return list;
	}

	public List<string> RobotsArray()
	{
		return new List<string> { Robots_Value_Index, Robots_Value_NoIndex, Robots_Value_Follow, Robots_Value_NoFollow, Robots_Value_NoSnippet, Robots_Value_NoArchive, Robots_Value_MaxSnippet, Robots_Value_MaxImagePreview, Robots_Value_MaxVideoPreview, Robots_Value_None };
	}

	public List<SelectListItem> Robots(bool autoSelectDefault = false, string selectedValue = "")
	{
		List<SelectListItem> selectListItems = GetSelectListItems();
		if (string.IsNullOrWhiteSpace(selectedValue) && autoSelectDefault)
		{
			selectedValue = Robots_DefaultValue;
		}
		List<string> arrSel = new List<string>();
		if (selectedValue != "")
		{
			arrSel.AddRange(Enumerable.ToList<string>(Enumerable.Select<string, string>((IEnumerable<string>)selectedValue.Split(new char[1] { ',' }), (Func<string, string>)((string x) => x))));
		}
		selectListItems.AddRange(Enumerable.Select<string, SelectListItem>((IEnumerable<string>)RobotsArray(), (Func<string, SelectListItem>)((string x) => new SelectListItem
		{
			Text = x,
			Value = x,
			Selected = (Enumerable.FirstOrDefault<string>((IEnumerable<string>)arrSel, (Func<string, bool>)((string a) => a == x)) != null)
		})));
		return selectListItems;
	}

	public List<string> HttpEquivArray()
	{
		return new List<string> { HttpEquiv_Value_Content_Type, HttpEquiv_Value_Default_Style, HttpEquiv_Value_Refresh, HttpEquiv_Value_x_ua_Compatible };
	}

	public List<SelectListItem> HttpEquiv(bool autoSelectDefault = false, string selectedValue = "")
	{
		List<SelectListItem> selectListItems = GetSelectListItems();
		if (string.IsNullOrWhiteSpace(selectedValue) && autoSelectDefault)
		{
			selectedValue = HttpEquiv_DefaultValue;
		}
		selectListItems.AddRange(Enumerable.Select<string, SelectListItem>((IEnumerable<string>)HttpEquivArray(), (Func<string, SelectListItem>)((string x) => new SelectListItem
		{
			Text = x,
			Value = x,
			Selected = (x == selectedValue)
		})));
		return selectListItems;
	}

	public List<string> ExpiresArray()
	{
		return new List<string> { Expires_Value_Never, Expires_Value_0 };
	}

	public List<SelectListItem> Expires(bool autoSelectDefault = false, string selectedValue = "")
	{
		List<SelectListItem> selectListItems = GetSelectListItems();
		if (string.IsNullOrWhiteSpace(selectedValue) && autoSelectDefault)
		{
			selectedValue = Expires_Value_0;
		}
		selectListItems.AddRange(Enumerable.ToList<SelectListItem>(Enumerable.Select<string, SelectListItem>((IEnumerable<string>)ExpiresArray(), (Func<string, SelectListItem>)((string x) => new SelectListItem
		{
			Text = x,
			Value = x,
			Selected = (x == selectedValue)
		}))));
		return selectListItems;
	}

	public List<string> DistributionArray()
	{
		return new List<string> { Distribution_Value_Global, Distribution_Value_Local };
	}

	public List<SelectListItem> Distribution(bool autoSelectDefault = false, string selectedValue = "")
	{
		List<SelectListItem> selectListItems = GetSelectListItems();
		if (string.IsNullOrWhiteSpace(selectedValue) && autoSelectDefault)
		{
			selectedValue = Distribution_DefaultValue;
		}
		selectListItems.AddRange(Enumerable.Select<string, SelectListItem>((IEnumerable<string>)DistributionArray(), (Func<string, SelectListItem>)((string x) => new SelectListItem
		{
			Text = x,
			Value = x,
			Selected = (x == selectedValue)
		})));
		return selectListItems;
	}

	public List<string> RatingArray()
	{
		return new List<string> { Rating_Value_General, Rating_Value_Mature, Rating_Value_Adult };
	}

	public List<SelectListItem> Rating(bool autoSelectDefault = false, string selectedValue = "")
	{
		List<SelectListItem> selectListItems = GetSelectListItems();
		if (string.IsNullOrWhiteSpace(selectedValue) && autoSelectDefault)
		{
			selectedValue = Rating_DefaultValue;
		}
		selectListItems.AddRange(Enumerable.Select<string, SelectListItem>((IEnumerable<string>)RatingArray(), (Func<string, SelectListItem>)((string x) => new SelectListItem
		{
			Text = x,
			Value = x,
			Selected = (x == selectedValue)
		})));
		return selectListItems;
	}

	public List<SelectListItem> MobileOptimized(bool autoSelectDefault = false, string selectedValue = "")
	{
		List<SelectListItem> selectListItems = GetSelectListItems();
		selectListItems.Add(MobileOptimized_No);
		selectListItems.Add(MobileOptimized_Yes);
		selectListItems.Add(MobileOptimized_Responsive);
		if (string.IsNullOrWhiteSpace(selectedValue) && autoSelectDefault)
		{
			selectedValue = MobileOptimized_DefaultValue;
			Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)selectListItems, (Func<SelectListItem, bool>)((SelectListItem x) => x.Value == selectedValue)).Selected = true;
		}
		return selectListItems;
	}
}
