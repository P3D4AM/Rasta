using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using CRM.General.Web;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Cache.User;
using Elmah;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json;
using RtfPipe;
using SautinSoft;

namespace CRMIdeal.Classes.Common;

public class Public
{
	[CompilerGenerated]
	private static class _003C_003Eo__0
	{
		public static CallSite<Func<CallSite, object, object, object>> _003C_003Ep__0;

		public static CallSite<Func<CallSite, object, bool>> _003C_003Ep__1;

		public static CallSite<Func<CallSite, object, object>> _003C_003Ep__2;

		public static CallSite<Func<CallSite, object, string, object>> _003C_003Ep__3;

		public static CallSite<Func<CallSite, object, bool>> _003C_003Ep__4;

		public static CallSite<Func<CallSite, object, string, object>> _003C_003Ep__5;

		public static CallSite<Func<CallSite, object, bool>> _003C_003Ep__6;

		public static CallSite<Func<CallSite, Type, object, object>> _003C_003Ep__7;

		public static CallSite<Func<CallSite, object, bool>> _003C_003Ep__8;
	}

	public static bool IsNull(dynamic val)
	{
		bool? flag = null;
		try
		{
			if (_003C_003Eo__0._003C_003Ep__1 == null)
			{
				_003C_003Eo__0._003C_003Ep__1 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, (ExpressionType)83, typeof(Public), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			Func<CallSite, object, bool> target = _003C_003Eo__0._003C_003Ep__1.Target;
			CallSite<Func<CallSite, object, bool>> _003C_003Ep__ = _003C_003Eo__0._003C_003Ep__1;
			if (_003C_003Eo__0._003C_003Ep__0 == null)
			{
				_003C_003Eo__0._003C_003Ep__0 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, (ExpressionType)13, typeof(Public), new CSharpArgumentInfo[2]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.Constant, null)
				}));
			}
			if (target((CallSite)(object)_003C_003Ep__, _003C_003Eo__0._003C_003Ep__0.Target((CallSite)(object)_003C_003Eo__0._003C_003Ep__0, (object)val, null)))
			{
				flag = true;
			}
			else if (val is string)
			{
				if (_003C_003Eo__0._003C_003Ep__4 == null)
				{
					_003C_003Eo__0._003C_003Ep__4 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, (ExpressionType)83, typeof(Public), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				Func<CallSite, object, bool> target2 = _003C_003Eo__0._003C_003Ep__4.Target;
				CallSite<Func<CallSite, object, bool>> _003C_003Ep__2 = _003C_003Eo__0._003C_003Ep__4;
				if (_003C_003Eo__0._003C_003Ep__3 == null)
				{
					_003C_003Eo__0._003C_003Ep__3 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, (ExpressionType)13, typeof(Public), new CSharpArgumentInfo[2]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
					}));
				}
				if (target2((CallSite)(object)_003C_003Ep__2, _003C_003Eo__0._003C_003Ep__3.Target((CallSite)(object)_003C_003Eo__0._003C_003Ep__3, (object)val.ToLower(), "null")))
				{
					flag = true;
				}
				else
				{
					if (_003C_003Eo__0._003C_003Ep__6 == null)
					{
						_003C_003Eo__0._003C_003Ep__6 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, (ExpressionType)83, typeof(Public), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
					}
					Func<CallSite, object, bool> target3 = _003C_003Eo__0._003C_003Ep__6.Target;
					CallSite<Func<CallSite, object, bool>> _003C_003Ep__3 = _003C_003Eo__0._003C_003Ep__6;
					if (_003C_003Eo__0._003C_003Ep__5 == null)
					{
						_003C_003Eo__0._003C_003Ep__5 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, (ExpressionType)13, typeof(Public), new CSharpArgumentInfo[2]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
						}));
					}
					if (target3((CallSite)(object)_003C_003Ep__3, _003C_003Eo__0._003C_003Ep__5.Target((CallSite)(object)_003C_003Eo__0._003C_003Ep__5, (object)val, "undefined")))
					{
						flag = true;
					}
					else
					{
						if (_003C_003Eo__0._003C_003Ep__8 == null)
						{
							_003C_003Eo__0._003C_003Ep__8 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, (ExpressionType)83, typeof(Public), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						if (_003C_003Eo__0._003C_003Ep__8.Target((CallSite)(object)_003C_003Eo__0._003C_003Ep__8, (object)string.IsNullOrWhiteSpace(val)))
						{
							flag = true;
						}
					}
				}
			}
			else if (!(val is long) && !(val is short) && !(val is int) && !(val is long))
			{
				_ = val is bool;
			}
		}
		catch (Exception ex)
		{
			flag = true;
			InsExceptToElmah(ex);
		}
		return flag.GetValueOrDefault();
	}

	public static string HexToColor(string value = null)
	{
		string result = value;
		try
		{
			if (!string.IsNullOrWhiteSpace(value) && value.Contains("#"))
			{
				if (value.IndexOf('#') != -1)
				{
					value = value.Replace("#", "");
				}
				string text = "00";
				string text2 = "00";
				string text3 = "00";
				if (value.Length == 6)
				{
					text = value.Substring(0, 2);
					text2 = value.Substring(2, 2);
					text3 = value.Substring(4, 2);
				}
				else if (value.Length == 3)
				{
					text = value[0].ToString() + value[0];
					text2 = value[1].ToString() + value[1];
					text3 = value[2].ToString() + value[2];
				}
				result = "$00" + text3.ToString() + text2.ToString() + text.ToString();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public static string TColorToHex(string value = null)
	{
		string result = value;
		try
		{
			if (!string.IsNullOrWhiteSpace(value) && value.Contains("$"))
			{
				if (value.Length == 7)
				{
					value += "00";
				}
				string text = value.Substring(3, 2);
				string text2 = value.Substring(5, 2);
				string text3 = value.Substring(7, 2);
				result = "#" + text3 + text2 + text;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public static Color HexToColorObject(string value = null)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		if (!string.IsNullOrWhiteSpace(value) && value.Length == 6)
		{
			int num = Convert.ToInt32(value.Substring(0, 2), 16);
			int num2 = Convert.ToInt32(value.Substring(2, 2), 16);
			int num3 = Convert.ToInt32(value.Substring(4, 2), 16);
			return Color.FromArgb(num, num2, num3);
		}
		return Color.Black;
	}

	public static string RtfToHtml(string value = "")
	{
		string result = "";
		try
		{
			result = ((!string.IsNullOrWhiteSpace(value)) ? Rtf.ToHtml(value.Replace("\\\\", "\\").Replace("////", "//")) : "");
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public static string HtmlToRtf(string value = "")
	{
		string result = "";
		try
		{
			if (!string.IsNullOrWhiteSpace(value))
			{
				HtmlToRtf htmlToRtf = new HtmlToRtf();
				htmlToRtf.TableFitWidthByPage = true;
				if (htmlToRtf.OpenHtml(value))
				{
					result = htmlToRtf.ToRtf();
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = "";
		}
		return result;
	}

	public static void InsExceptToElmah(Exception ex)
	{
		try
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		catch (Exception)
		{
		}
	}

	public static void InsExceptToElmah(Exception ex, HttpContext context)
	{
		try
		{
			if (context != null)
			{
				ErrorSignal.FromContext(context).Raise(ex);
			}
		}
		catch (Exception)
		{
		}
	}

	public static void InsTextToElmah(string ex = "")
	{
		if (!string.IsNullOrWhiteSpace(ex))
		{
			ErrorSignal.FromCurrentContext().Raise(new Exception(ex));
		}
	}

	public static List<SelectListItem> ComboPaging(string customeNumbers = "", string selectedValue = "")
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			if (!string.IsNullOrWhiteSpace(customeNumbers))
			{
				List<string> list2 = Enumerable.ToList<string>((IEnumerable<string>)customeNumbers.Split(new char[1] { ',' }));
				list.AddRange(Enumerable.Select<string, SelectListItem>((IEnumerable<string>)list2, (Func<string, SelectListItem>)((string x) => new SelectListItem
				{
					Text = x,
					Value = x,
					Selected = (x == selectedValue)
				})));
			}
		}
		catch (Exception ex)
		{
			InsExceptToElmah(ex);
		}
		if (list.Count <= 0)
		{
			list.Add(new SelectListItem
			{
				Text = "10",
				Value = "10"
			});
			list.Add(new SelectListItem
			{
				Text = "50",
				Value = "50"
			});
			list.Add(new SelectListItem
			{
				Text = "100",
				Value = "100",
				Selected = (selectedValue == "")
			});
			list.Add(new SelectListItem
			{
				Text = "200",
				Value = "200"
			});
			list.Add(new SelectListItem
			{
				Text = "500",
				Value = "500"
			});
			list.Add(new SelectListItem
			{
				Text = "1000",
				Value = "1000"
			});
			if (selectedValue != "")
			{
				if (Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)list, (Func<SelectListItem, bool>)((SelectListItem x) => x.Value == selectedValue)) == null)
				{
					Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)list).Selected = true;
				}
				else
				{
					Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)list, (Func<SelectListItem, bool>)((SelectListItem x) => x.Value == selectedValue)).Selected = true;
				}
			}
		}
		else if (Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)list, (Func<SelectListItem, bool>)((SelectListItem x) => x.Selected)) == null)
		{
			Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)list).Selected = true;
		}
		return list;
	}

	public static double GetDistance(double longitude, double latitude, double otherLongitude, double otherLatitude)
	{
		double num = latitude * (Math.PI / 180.0);
		double num2 = longitude * (Math.PI / 180.0);
		double num3 = otherLatitude * (Math.PI / 180.0);
		double num4 = otherLongitude * (Math.PI / 180.0) - num2;
		double num5 = Math.Pow(Math.Sin((num3 - num) / 2.0), 2.0) + Math.Cos(num) * Math.Cos(num3) * Math.Pow(Math.Sin(num4 / 2.0), 2.0);
		return 6376500.0 * (2.0 * Math.Atan2(Math.Sqrt(num5), Math.Sqrt(1.0 - num5)));
	}

	public static string CheckMobileFormat(string mobile = "")
	{
		string result = "";
		try
		{
			if (!string.IsNullOrWhiteSpace(mobile) && !Regex.IsMatch(mobile, "09([0-9])\\d{8}"))
			{
				result = string.Format(Messages.msgErrorMobileFormat, mobile);
			}
		}
		catch (Exception ex)
		{
			InsExceptToElmah(ex);
		}
		return result;
	}

	public static bool CheckMultiLanguage(string defaultValue, List<CommonMultiLanguageViewModel> list)
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

	public static ParamViewModel GetParamObject(ParamViewModel p = null)
	{
		p = p ?? new ParamViewModel();
		p.GUId = UserLogin.CurrentUser.UserId;
		p.GDT = DateTime.Now;
		Uri url = HttpContext.Current.Request.Url;
		p.SDomain = url.Scheme + "://" + url.Authority;
		return p;
	}

	public static List<dynamic> nComponentGetCultures(bool returnCurrLangAsItems = false)
	{
		int currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		List<Languages> list = new List<Languages>();
		if (returnCurrLangAsItems)
		{
			list.Add(Enumerable.FirstOrDefault<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages x) => x.LanguageID == currLangID))));
		}
		list.AddRange(Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages x) => x.LanguageID != currLangID))));
		List<object> list2 = new List<object>();
		foreach (Languages item in list)
		{
			list2.Add(new
			{
				LCID = item.LanguageID,
				Name = item.LanguageName,
				Collation = item.LanguageCollation,
				IsRtl = ((item.LanguageDirection ?? "").ToLower().Trim() == "rtl"),
				IsCurrent = (item.LanguageID == currLangID)
			});
		}
		return list2;
	}

	public static string nComponentGetCulturesJs(bool returnCurrLangAsItems = false)
	{
		return JsonConvert.SerializeObject(nComponentGetCultures(returnCurrLangAsItems));
	}

	public static SEOParamsViewModel GetSEOParams(bool addDefValue = false)
	{
		SEOParamsViewModel sEOParamsViewModel = new SEOParamsViewModel();
		if (addDefValue)
		{
			sEOParamsViewModel.AddBefore_SelectListItems = new List<SelectListItem>();
			sEOParamsViewModel.AddBefore_SelectListItems.Add(new SelectListItem
			{
				Text = Labels.SelectedListDefValue,
				Value = ""
			});
		}
		return sEOParamsViewModel;
	}
}
