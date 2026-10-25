using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSCostSheetDyFieldTitleMetadata))]
public class WSCostSheetDyFieldTitle
{
	public int CostSheetDyFieldTitleId { get; set; }

	public int CostSheetDyFieldGroupId { get; set; }

	public string ctshDyFieldTitle { get; set; }

	public string ctshDyFieldTitleForFormula { get; set; }

	public int ctshDyFieldType { get; set; }

	public string ctshDyFieldFormula { get; set; }

	public decimal? ctshDyFieldDefaultValue { get; set; }

	public int? OrderView { get; set; }

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

	public bool? ctshDyFieldIsMarkup { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSCostSheetDyFieldGroups WSCostSheetDyFieldGroups { get; set; }

	public virtual ICollection<WSCostSheetDyFieldTitle_Lang> WSCostSheetDyFieldTitle_Lang { get; set; }

	public virtual WSFinancialPeriod WSFinancialPeriod { get; set; }

	public virtual ICollection<WSCostSheetDyFieldValues> WSCostSheetDyFieldValues { get; set; }

	public WSCostSheetDyFieldTitle()
	{
		WSCostSheetDyFieldTitle_Lang = (ICollection<WSCostSheetDyFieldTitle_Lang>)new HashSet<WSCostSheetDyFieldTitle_Lang>();
		WSCostSheetDyFieldValues = (ICollection<WSCostSheetDyFieldValues>)new HashSet<WSCostSheetDyFieldValues>();
	}
}
