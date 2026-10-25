using System;

namespace CRM.Models;

public class CRMspSelectsysRolls_Result
{
	public int ID { get; set; }

	public string RollName { get; set; }

	public string Description { get; set; }

	public Guid? GUId { get; set; }

	public bool? LimitPreOrderDiscountActive { get; set; }

	public decimal? LimitPreOrderDiscountPercent { get; set; }

	public bool? LimitOrderDiscountActive { get; set; }

	public decimal? LimitOrderDiscountPercent { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public string FirstRegisterUser { get; set; }
}
