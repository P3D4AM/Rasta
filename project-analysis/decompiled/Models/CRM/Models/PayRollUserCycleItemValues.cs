using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(PayRollUserCycleItemValuesMetadata))]
public class PayRollUserCycleItemValues
{
	public int PayRollUserCycleItemValueId { get; set; }

	public int CycleId { get; set; }

	public int CrmUserId { get; set; }

	public int ItemId { get; set; }

	public decimal? Value { get; set; }

	public bool? ValueNotValid { get; set; }

	public string UsefulIds { get; set; }

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

	public string ItemValueDesc { get; set; }

	public string ValueStr { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual PayRollUserCycle PayRollUserCycle { get; set; }

	public virtual ICollection<WSOrderCommissions> WSOrderCommissions { get; set; }

	public virtual PayRollItems PayRollItems { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual Users Users2 { get; set; }

	public PayRollUserCycleItemValues()
	{
		WSOrderCommissions = (ICollection<WSOrderCommissions>)new HashSet<WSOrderCommissions>();
	}
}
