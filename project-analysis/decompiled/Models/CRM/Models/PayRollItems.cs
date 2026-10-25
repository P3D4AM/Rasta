using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(PayRollItemsMetadata))]
public class PayRollItems
{
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

	public bool? ItemNotVisiblePrint { get; set; }

	public int? ItemDurStartDay { get; set; }

	public int? ItemDurStartMonth { get; set; }

	public bool? ItemCopyInCycle { get; set; }

	public bool? ItemDescCopyInCycle { get; set; }

	public int? ItemDurEndDay { get; set; }

	public int? ItemDurEndMonth { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<PayRollItems_Lang> PayRollItems_Lang { get; set; }

	public virtual PayRollItemTypes PayRollItemTypes { get; set; }

	public virtual ICollection<PayRollUserCycleItemValues> PayRollUserCycleItemValues { get; set; }

	public virtual ICollection<PayRollUserDefaultItems> PayRollUserDefaultItems { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public PayRollItems()
	{
		PayRollItems_Lang = (ICollection<PayRollItems_Lang>)new HashSet<PayRollItems_Lang>();
		PayRollUserCycleItemValues = (ICollection<PayRollUserCycleItemValues>)new HashSet<PayRollUserCycleItemValues>();
		PayRollUserDefaultItems = (ICollection<PayRollUserDefaultItems>)new HashSet<PayRollUserDefaultItems>();
	}
}
