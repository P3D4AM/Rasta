using System;

namespace CRM.Models;

public class PayRollspSelectUserCycleItemValuesInMonth_Result
{
	public int PayRollUserCycleItemValueId { get; set; }

	public int CycleId { get; set; }

	public string CycleTitle { get; set; }

	public int ItemId { get; set; }

	public decimal? Value { get; set; }

	public string UsefulIds { get; set; }

	public bool? ValueNotValid { get; set; }

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

	public string FirstRegisterUser { get; set; }

	public string EditUser { get; set; }
}
