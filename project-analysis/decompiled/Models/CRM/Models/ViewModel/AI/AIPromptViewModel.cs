using System;

namespace CRM.Models.ViewModel.AI;

public class AIPromptViewModel
{
	public int PromptId { get; set; }

	public string PrTitle { get; set; }

	public string PrDesc { get; set; }

	public string PrSystemRole { get; set; }

	public string PrData { get; set; }

	public bool? PrIsDisabled { get; set; }

	public int PromptGroupId { get; set; }

	public string PromptGroup { get; set; }

	public int? OrderView { get; set; }

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
