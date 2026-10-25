using System;

namespace CRM.Models.ViewModel.AI;

public class AIProviderViewModel
{
	public int ProviderId { get; set; }

	public string ProviderName { get; set; }

	public string ApiKey { get; set; }

	public string ApiBaseUrl { get; set; }

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
