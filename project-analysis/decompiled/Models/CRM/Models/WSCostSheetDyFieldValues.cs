using System;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSCostSheetDyFieldValuesMetadata))]
public class WSCostSheetDyFieldValues
{
	public int CostSheetDyFieldValueId { get; set; }

	public int CostSheetId { get; set; }

	public int CostSheetDyFieldTitleId { get; set; }

	public decimal? ctshDyFieldValue { get; set; }

	public string ctshDyFieldFormula { get; set; }

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

	public int? CId { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSCostSheetDyFieldTitle WSCostSheetDyFieldTitle { get; set; }

	public virtual WSCostSheets WSCostSheets { get; set; }

	public virtual WSFinancialPeriod WSFinancialPeriod { get; set; }

	public virtual Centers Centers { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }
}
