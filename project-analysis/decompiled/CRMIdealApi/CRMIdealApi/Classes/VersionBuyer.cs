using System;
using System.Collections.Generic;
using CRMIdealApi.Classes.Helper;
using Elmah;

namespace CRMIdealApi.Classes;

public static class VersionBuyer
{
	public static bool Customers => Versions.Get()["U"];

	public static bool PreOrders => Versions.Get()["P"];

	public static bool Order => Versions.Get()["O"];

	public static bool WareHouse => Versions.Get()["W"];

	public static bool GSM => Versions.Get()["G"];

	public static bool BuyOrders => Versions.Get()["B"];

	public static bool SMS => Versions.Get()["S"];

	public static bool CallerId => Versions.Get()["C"];

	public static bool Recorder => Versions.Get()["R"];

	public static bool Emails => Versions.Get()["E"];

	public static bool AttachFiles => Versions.Get()["F"];

	public static bool Letters => Versions.Get()["L"];

	public static bool Products => Versions.Get()["K"];

	public static bool ProductImportExcel => Versions.Get()["I"];

	public static bool ProductExportExcel => Versions.Get()["X"];

	public static bool DyForm => Versions.Get()["D"];

	public static bool Telegram
	{
		get
		{
			try
			{
				return Versions.Get()["T"];
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
				return false;
			}
		}
	}

	public static bool PayRoll => Versions.Get()["H"];

	public static bool LinkAcc => Versions.Get()["A"];

	public static bool UserPosition => Versions.Get()["URP"];

	public static bool Fund => Versions.Get()["FUD"];

	public static bool ClickToCall => Versions.Get()["CTC"];

	public static bool Costsheet => Versions.Get()["CST"];

	public static bool IsDecimal => Versions.Get()["DEC"];

	public static bool CmpImportExcel => Versions.Get()["CIE"];

	public static bool OrdImportExcel => Versions.Get()["OIE"];

	public static bool DiscountCode => Versions.Get()["DC"];

	public static bool WareHouseUserPermission => Versions.Get()["WHUP"];

	public static bool IssueMultiDraftFromOrd => Versions.Get()["IMDocOrd"];

	public static bool VerificationWorkFlow => Versions.Get()["VerifyWrkflw"];

	public static bool MobAccessCmpDistance => Versions.Get()["MobAccCmpDistance"];

	public static bool Survey => Versions.Get()["SUR"];

	public static bool MobFinancial => Versions.Get()["MobFinancial"];

	public static bool FoClub => Versions.Get()["FoClub"];

	public static bool FoShop => Versions.Get()["FoShop"];

	public static bool FoCmsPage => Versions.Get()["FoCmsPage"];

	public static bool FoCmsNews => Versions.Get()["FoCmsNews"];

	public static bool Score => Versions.Get()["SCO"];

	public static bool Commissions => Versions.Get()["COM"];

	public static bool WhatsApp => Versions.Get()["WhtApp"];

	public static bool DyMenu => Versions.Get()["DyMenu"];

	public static bool PrdValidity => Versions.Get()["PrdValid"];

	public static bool PrdIVRLink => Versions.Get()["PrdIVR"];

	public static bool TicketPlus => Versions.Get()["TicketPlus"];

	public static bool LetterNumberCounter => Versions.Get()["LtrNumCounter"];

	public static bool SmartTimeAttendance => Versions.Get()["SmartTmAttend"];

	public static bool CRMApi => Versions.Get()["CrmApi"];

	public static bool PordPlus => Versions.Get()["PordPlus"];

	public static bool BordPlus => Versions.Get()["BordPlus"];

	public static bool MobDyForm => Versions.Get()["MobDyForm"];

	public static bool CnvsStatusResult => Versions.Get()["CnvsStatusResult"];

	public static bool APIVoip => Versions.Get()["APIVoip"];

	public static bool SimpleTicket => Versions.Get()["SimpleTicket"];

	public static bool ProjectProductHistory => Versions.Get()["PrjPrdHis"];

	public static bool Leave => Versions.Get()["Leave"];

	public static bool Tsp => Versions.Get()["Tsp"];

	public static bool MoneyBag => Versions.Get()["MoneyBag"];

	public static bool OnlinePay => Versions.Get()["OnlinePay"];

	public static bool AutoCalcIssueBill => Versions.Get()["AutoCalcIssueBill"];

	public static bool StockSupply => Versions.Get()["Stsup"];

	public static bool ADLogin => Versions.Get()["ADLog"];

	public static bool UserImportExcel => Versions.Get()["UIE"];

	public static bool DiscountStrategy => Versions.Get()["DisSt"];

	public static bool Outlook => Versions.Get()["Outlook"];

	public static bool OrdProfit => Versions.Get()["OrdProfit"];

	public static bool Center => Versions.Get()["Center"];

	public static bool PrdSpec => Versions.Get()["PrdSpec"];

	public static bool PrdAutoCalcPrice => Versions.Get()["PrdAutoCalcPrice"];

	public static bool DiscountPolicy => Versions.Get()["DisPol"];

	public static bool AI => Versions.Get()["AI"];

	public static bool Enterprise => Versions.Get()["ENT"];

	public static bool CrmApiFRL => Versions.Get()["CrmApiFRL"];

	public static string VersionName
	{
		get
		{
			string result = "";
			Dictionary<string, bool> dictionary = Versions.Get();
			foreach (KeyValuePair<string, bool> item in dictionary)
			{
				if (item.Key.Contains("name:"))
				{
					result = item.Key.Replace("name:", "");
					break;
				}
			}
			return result;
		}
	}
}
