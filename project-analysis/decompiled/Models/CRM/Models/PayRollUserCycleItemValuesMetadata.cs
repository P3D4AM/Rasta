using System;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class PayRollUserCycleItemValuesMetadata
{
	[Key]
	public int PayRollUserCycleItemValueId { get; set; }

	public int CrmUserId { get; set; }

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
}
