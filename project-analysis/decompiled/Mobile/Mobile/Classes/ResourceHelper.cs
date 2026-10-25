using System;
using System.Reflection;
using System.Threading;
using CRM.General.Utilities;
using CRM.Resources;
using Elmah;
using Mobile.Cache.Setting;

namespace Mobile.Classes;

public static class ResourceHelper
{
	public static string OrderMessages(this string key)
	{
		string text = "";
		try
		{
			if (string.IsNullOrEmpty(key))
			{
				return text;
			}
			string name = Thread.CurrentThread.CurrentCulture.Name;
			text = MyResource.GetResourceString(key, name, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
			string text2 = "";
			string text3 = "";
			if (SysSeting.Get() != null)
			{
				text2 = SysSeting.Get().SaleOrderLbl ?? "";
				text3 = SysSeting.Get().SaleReturnOrderLbl ?? "";
			}
			if (!string.IsNullOrEmpty(text))
			{
				if (Thread.CurrentThread.CurrentCulture.LCID == 1065)
				{
					string[] array = new string[4] { "فاکتور فروش", "فاکتورفروش", "فاکتوری", "فاکتور" };
					string[] array2 = new string[3] { "فاکتور برگشت از فروش", "فاکتور فروش برگشتی", "فاکتور برگشتی" };
					if (!string.IsNullOrEmpty(text3))
					{
						string[] array3 = array2;
						foreach (string oldValue in array3)
						{
							text = text.Replace(oldValue, text3);
						}
					}
					if (!string.IsNullOrEmpty(text2))
					{
						string[] array3 = array;
						foreach (string oldValue2 in array3)
						{
							text = text.Replace(oldValue2, text2);
						}
					}
				}
				else if (Thread.CurrentThread.CurrentCulture.LCID == 1025)
				{
					string[] array4 = new string[6] { "فاتورة المبيعات", "الفاتورة المبيعات", "فاتورة المبيع", "فاتورة مبيع", "الفاتورة", "فاتورة" };
					string[] array5 = new string[8] { "عودة فاتورة المبيعات", "عودةالفاتورة المبيعات", "عودة فاتورة المبيع", "عودة فاتورة مبيع", "يعودة فاتورة المبيعات", "يعودةالفاتورة المبيعات", "يعودة فاتورة المبيع", "يعودة فاتورة مبيع" };
					if (!string.IsNullOrEmpty(text3))
					{
						string[] array3 = array5;
						foreach (string oldValue3 in array3)
						{
							text = text.Replace(oldValue3, text3);
						}
					}
					if (!string.IsNullOrEmpty(text2))
					{
						string[] array3 = array4;
						foreach (string oldValue4 in array3)
						{
							text = text.Replace(oldValue4, text2);
						}
					}
				}
				else if (Thread.CurrentThread.CurrentCulture.LCID == 1033)
				{
					string[] array6 = new string[9] { "Sale order", "Sale Order", "sale order", "order", "Order", "invoice", "Invoice", "Sale invoice", "Sale Invoice" };
					string[] array7 = new string[10] { "Return sale order", "Return Sale Order", "return sale order", "Return order", "Return Order", "return order", "Return invoice", "Return Invoice", "Return sale invoice", "Return Sale Invoice" };
					if (!string.IsNullOrEmpty(text3))
					{
						string[] array3 = array7;
						foreach (string oldValue5 in array3)
						{
							text = text.Replace(oldValue5, text3);
						}
					}
					if (!string.IsNullOrEmpty(text2))
					{
						string[] array3 = array6;
						foreach (string oldValue6 in array3)
						{
							text = text.Replace(oldValue6, text2);
						}
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return text;
	}

	public static string OrderLabels(this string key)
	{
		string text = "";
		try
		{
			if (string.IsNullOrEmpty(key))
			{
				return text;
			}
			string name = Thread.CurrentThread.CurrentCulture.Name;
			text = MyResource.GetResourceString(key, name, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
			string text2 = "";
			string text3 = "";
			if (SysSeting.Get() != null)
			{
				text2 = SysSeting.Get().SaleOrderLbl ?? "";
				text3 = SysSeting.Get().SaleReturnOrderLbl ?? "";
			}
			if (!string.IsNullOrEmpty(text))
			{
				if (Thread.CurrentThread.CurrentCulture.LCID == 1065)
				{
					string[] array = new string[3] { "فاکتور فروش", "فاکتورفروش", "فاکتور" };
					string[] array2 = new string[5] { "فاکتور برگشت از فروش", "فاکتور فروش برگشتی", "فاکتور برگشتی", "فاکتوربرگشتی", "فاکتورفروش برگشتی" };
					if (!string.IsNullOrEmpty(text3))
					{
						string[] array3 = array2;
						foreach (string oldValue in array3)
						{
							text = text.Replace(oldValue, text3);
						}
					}
					if (!string.IsNullOrEmpty(text2))
					{
						string[] array3 = array;
						foreach (string oldValue2 in array3)
						{
							text = text.Replace(oldValue2, text2);
						}
					}
				}
				else if (Thread.CurrentThread.CurrentCulture.LCID == 1025)
				{
					string[] array4 = new string[6] { "فاتورة المبيعات", "الفاتورة المبيعات", "فاتورة المبيع", "فاتورة مبيع", "الفاتورة", "فاتورة" };
					string[] array5 = new string[8] { "عودة فاتورة المبيعات", "عودةالفاتورة المبيعات", "عودة فاتورة المبيع", "عودة فاتورة مبيع", "يعودة فاتورة المبيعات", "يعودةالفاتورة المبيعات", "يعودة فاتورة المبيع", "يعودة فاتورة مبيع" };
					if (!string.IsNullOrEmpty(text3))
					{
						string[] array3 = array5;
						foreach (string oldValue3 in array3)
						{
							text = text.Replace(oldValue3, text3);
						}
					}
					if (!string.IsNullOrEmpty(text2))
					{
						string[] array3 = array4;
						foreach (string oldValue4 in array3)
						{
							text = text.Replace(oldValue4, text2);
						}
					}
				}
				else if (Thread.CurrentThread.CurrentCulture.LCID == 1033)
				{
					string[] array6 = new string[9] { "Sale order", "Sale Order", "sale order", "order", "Order", "invoice", "Invoice", "Sale invoice", "Sale Invoice" };
					string[] array7 = new string[10] { "Return sale order", "Return Sale Order", "return sale order", "Return order", "Return Order", "return order", "Return invoice", "Return Invoice", "Return sale invoice", "Return Sale Invoice" };
					if (!string.IsNullOrEmpty(text3))
					{
						string[] array3 = array7;
						foreach (string oldValue5 in array3)
						{
							text = text.Replace(oldValue5, text3);
						}
					}
					if (!string.IsNullOrEmpty(text2))
					{
						string[] array3 = array6;
						foreach (string oldValue6 in array3)
						{
							text = text.Replace(oldValue6, text2);
						}
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return text;
	}
}
