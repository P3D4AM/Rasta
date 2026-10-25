using System;
using System.Collections.Generic;
using CRM.General.Security;
using CRM.General.Utilities;
using CRMIdealApi.ApiModels;
using Elmah;

namespace CRMIdealApi.Classes.Helper;

public static class Versions
{
	public static Dictionary<string, bool> Get()
	{
		Dictionary<string, bool> dictionary = new Dictionary<string, bool>();
		CRMEntities cRMEntities = new CRMEntities();
		try
		{
			dictionary = new Dictionary<string, bool>();
			string text = "I|U1|P0|O1|W0|G0|B0|S0|C0|R0|E0|F1|L0|K0|X0|I0|T0|D0|H0|A0|URP0|FUD0|CTC0|CST0|DEC0|CIE0|OIE0|DC0|WHUP0|IMDocOrd0|VerifyWrkflw0|MobAccCmpDistance0|SUR0|MobFinancial0|FoClub0|FoShop0|FoCmsPage0|FoCmsNews0|SCO0|COM0|WhtApp0|DyMenu0|PrdValid0|PrdIVR0|TicketPlus0|LtrNumCounter0|SmartTmAttend0|CrmApi0|PordPlus0|BordPlus0|MobDyForm0|CnvsStatusResult0|APIVoip0|SimpleTicket0|PrjPrdHis0|Leave0|Tsp0|MoneyBag0|OnlinePay0|AutoCalcIssueBill0|Stsup0|ADLog0|UIE0|DisSt0|Outlook0|OrdProfit0|Center0|PrdSpec0|PrdAutoCalcPrice0|DisPol0|AI0|ENT0|CrmApiFRL0";
			string value = ApplicationSettings.GetValue("RegisterCode");
			if (value != null)
			{
				string text2 = CodeDecode.RegDeCodding(value);
				string[] array = text2.Split(new char[1] { '|' });
				text = array[1];
				string[] array2 = CodeDecode.RegDeCodding(text).Split(new char[1] { '|' });
				string[] array3 = array2;
				foreach (string text3 in array3)
				{
					if (text3.EndsWith("0"))
					{
						if (text3.Length == 2)
						{
							dictionary.Add(text3.Substring(0, 1), value: false);
						}
						else
						{
							dictionary.Add(text3.Substring(0, text3.Length - 1), value: false);
						}
					}
					else if (text3.EndsWith("1"))
					{
						if (text3.Length == 2)
						{
							dictionary.Add(text3.Substring(0, 1), value: true);
						}
						else
						{
							dictionary.Add(text3.Substring(0, text3.Length - 1), value: true);
						}
					}
					else
					{
						dictionary.Add("name:" + text3, value: true);
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
			cRMEntities.Dispose();
		}
		return dictionary;
	}
}
