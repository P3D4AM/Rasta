using System;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class PayRollItemsMetadata
{
	[Key]
	public int PayRollItemId { get; set; }

	public string ItemName { get; set; }

	public int ItemKind { get; set; }

	public int ItemTypeId { get; set; }

	public decimal? ItemDefaultValue { get; set; }

	public string ItemFormulaTag { get; set; }

	public string ItemFormula { get; set; }

	public bool? ItemJustForShow { get; set; }

	public bool? ItemIsActive { get; set; }

	public int? ItemOrderView { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }
}
