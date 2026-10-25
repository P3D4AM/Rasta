using System;
using System.Collections.Generic;

namespace CRM.Models.ViewModel.AI;

public class AIResponseViewModel
{
	public int ResponseId { get; set; }

	public DateTime ResponseDate { get; set; }

	public string ResponseDateStr { get; set; }

	public string TrackingId { get; set; }

	public int ResponseTypeId { get; set; }

	public string ResponseType { get; set; }

	public List<AIResponsePromptViewModel> InputPrompts { get; set; }

	public int? MaxTokens { get; set; }

	public int ModelId { get; set; }

	public string Model { get; set; }

	public int? ProviderId { get; set; }

	public string Provider { get; set; }

	public string SystemPrompt { get; set; }

	public decimal Temperature { get; set; }

	public int? CompanyId { get; set; }

	public List<AIResponseInputDataViewModel> InputData { get; set; }

	public string InputInfoJs { get; set; }

	public int InputUsedToken { get; set; }

	public int OutputUsedToken { get; set; }

	public int TotalUsedToken { get; set; }

	public string TokenInfoJs { get; set; }

	public List<AIResponseOutputContentViewModel> OutputContents { get; set; }

	public string Desc { get; set; }

	public decimal? CostExchRate { get; set; }

	public decimal? CostIrt { get; set; }

	public decimal? CostUnit { get; set; }

	public int RowNumber { get; set; }

	public int TotalCount { get; set; }
}
