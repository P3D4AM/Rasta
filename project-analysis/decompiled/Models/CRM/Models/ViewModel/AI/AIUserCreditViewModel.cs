using System;

namespace CRM.Models.ViewModel.AI;

public class AIUserCreditViewModel
{
	public int UserCreditId { get; set; }

	public int CreditUserId { get; set; }

	public string CreditUser { get; set; }

	public int CreditToken { get; set; }

	public string Description { get; set; }

	public int? ExpiryDay { get; set; }

	public DateTime? ExpiryDate { get; set; }

	public string ExpiryDateStr { get; set; }

	public int? TotalCount { get; set; }

	public long? RowNumber { get; set; }

	public string FirstRegisterUser { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public string FirstRegisterDateStr { get; set; }

	public string RegisterUser { get; set; }

	public int RegisterUserId { get; set; }

	public DateTime? RegisterDate { get; set; }

	public string RegisterDateStr { get; set; }
}
