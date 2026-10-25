using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSCostSheetsMetadata))]
public class WSCostSheets
{
	public int CostSheetId { get; set; }

	public int? PreOrderId { get; set; }

	public long ctshNumber { get; set; }

	public DateTime ctshDate { get; set; }

	public string ctshDatePersian { get; set; }

	public string ctshTitle { get; set; }

	public int ctshSrcCurrencyUnitId { get; set; }

	public int ctshDestCurrencyUnitId { get; set; }

	public double ctshCurrencyRate { get; set; }

	public double ctshRoundRate { get; set; }

	public decimal? ctshSumAmount { get; set; }

	public decimal? ctshTaxIndex { get; set; }

	public decimal? ctshTax { get; set; }

	public decimal? ctshTotalAmount { get; set; }

	public double? ctshMarkup { get; set; }

	public string ctshMarkupFormula { get; set; }

	public bool? ctshIsVerified { get; set; }

	public int? ctshVerifierId { get; set; }

	public DateTime? ctshVerifiedDate { get; set; }

	public string ctshVerifiedDatePersian { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public int FPId { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }

	public int? ctshCmpProjectId { get; set; }

	public string ctshNumRef { get; set; }

	public decimal? ctshMarkupSum { get; set; }

	public string ctshMarkupSumFormula { get; set; }

	public int? ctshCId { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<WSBuyOrder> WSBuyOrder { get; set; }

	public virtual ICollection<WSCostSheetDyFieldValues> WSCostSheetDyFieldValues { get; set; }

	public virtual ICollection<WSCostSheetItems> WSCostSheetItems { get; set; }

	public virtual ICollection<WSCostSheets_Lang> WSCostSheets_Lang { get; set; }

	public virtual WSCurrencyUnits WSCurrencyUnits { get; set; }

	public virtual WSFinancialPeriod WSFinancialPeriod { get; set; }

	public virtual WSCurrencyUnits WSCurrencyUnits1 { get; set; }

	public virtual WSPreOrder WSPreOrder { get; set; }

	public virtual Centers Centers { get; set; }

	public virtual CrmProjects CrmProjects { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual Users Users2 { get; set; }

	public WSCostSheets()
	{
		WSBuyOrder = (ICollection<WSBuyOrder>)new HashSet<WSBuyOrder>();
		WSCostSheetDyFieldValues = (ICollection<WSCostSheetDyFieldValues>)new HashSet<WSCostSheetDyFieldValues>();
		WSCostSheetItems = (ICollection<WSCostSheetItems>)new HashSet<WSCostSheetItems>();
		WSCostSheets_Lang = (ICollection<WSCostSheets_Lang>)new HashSet<WSCostSheets_Lang>();
	}
}
