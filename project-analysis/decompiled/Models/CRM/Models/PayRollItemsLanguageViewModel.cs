using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class PayRollItemsLanguageViewModel
{
	[Key]
	public int PayRollItemId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PayRollItemName")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ItemName { get; set; }

	public int ItemKind { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PayRollItemType")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int ItemTypeId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PayRollItemDefaultValue")]
	public decimal? ItemDefaultValue { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PayRollItemFormulaTag")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ItemFormulaTag { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PayRollItemFormula")]
	public string ItemFormula { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PayRollItemJustForShow")]
	public bool? ItemJustForShow { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PayRollItemIsActive")]
	public bool? ItemIsActive { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PayRollItemOrderView")]
	public int? ItemOrderView { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PayRollItemNotVisiblePrint")]
	public bool? ItemNotVisiblePrint { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }

	public string ItemKindName { get; set; }

	public string ItemType { get; set; }

	public string FirstRegisterUser { get; set; }

	public string EditUser { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PayRollItemDurStartDay")]
	public int? ItemDurStartDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PayRollItemDurStartMonth")]
	public int? ItemDurStartMonth { get; set; }

	public string ItemDurStartMonthName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PayRollItemCopyInCycle")]
	public bool? ItemCopyInCycle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PayRollItemDescCopyInCycle")]
	public bool? ItemDescCopyInCycle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PayRollItemDurEndDay")]
	public int? ItemDurEndDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PayRollItemDurEndMonth")]
	public int? ItemDurEndMonth { get; set; }

	public string ItemDurEndMonthName { get; set; }

	public string ItemName_Lang { get; set; }
}
