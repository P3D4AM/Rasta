using System;

namespace CRM.Models;

public class WSspSelectCostSheetDyFieldTitleForFormula_Result
{
	public int CostSheetDyFieldTitleId { get; set; }

	public int CostSheetDyFieldGroupId { get; set; }

	public string ctshDyFieldGroupName { get; set; }

	public string ctshDyFieldTitle { get; set; }

	public string ctshDyFieldTitleForFormula { get; set; }

	public int ctshDyFieldType { get; set; }

	public string ctshDyFieldTypeTitle { get; set; }

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

	public string FirstRegisterUser { get; set; }

	public string EditUser { get; set; }
}
