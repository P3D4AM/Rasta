using System;

namespace CRM.Models;

public class WSspSelectCostSheetProducts_Result
{
	public int CostSheetProductId { get; set; }

	public string ctshPrdName { get; set; }

	public double ctshPrdQuantity { get; set; }

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

	public int? ctshPrdGroupId { get; set; }

	public string ctshPrdGroup { get; set; }

	public int? ctshPrdCmpProjectId { get; set; }

	public string ctshPrdCmpProject { get; set; }

	public int? CostSheetId { get; set; }

	public string ctshTitle { get; set; }
}
