using System;

namespace Mobile.Models;

public class HRMMobPayRollspSelectUserCycle_Result
{
	public int PayRollUserCycleId { get; set; }

	public int CrmUserId { get; set; }

	public string CycleTitle { get; set; }

	public int? CycleDuration { get; set; }

	public DateTime CycleDate { get; set; }

	public string CycleDatePersian { get; set; }

	public bool? CycleIsVerified { get; set; }

	public int? CycleVerifierUserId { get; set; }

	public DateTime? CycleVerifiedDate { get; set; }

	public string CycleVerifiedDatePersian { get; set; }

	public int? CyclePrintFormatId { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public string CrmUser { get; set; }

	public string CycleVerifierUser { get; set; }

	public string FirstRegisterUser { get; set; }

	public string EditUser { get; set; }

	public string CyclePrintFormat { get; set; }

	public decimal? FinalAmount { get; set; }
}
