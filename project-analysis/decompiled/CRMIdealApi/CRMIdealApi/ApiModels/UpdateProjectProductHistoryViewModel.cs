using System;

namespace CRMIdealApi.ApiModels;

public class UpdateProjectProductHistoryViewModel
{
	public string UserName { get; set; }

	public string Password { get; set; }

	public int UserId { get; set; }

	public int ApiProjectProductHistoryId { get; set; }

	public DateTime? ApiPrjPrdHSetDate { get; set; }

	public int? ApiPrjPrdHDoneStatus { get; set; }

	public int? ApiPrjPrdHDoneStatusUserId { get; set; }

	public DateTime? ApiPrjPrdHDoneStatusDate { get; set; }

	public string ApiPrjPrdHDesc { get; set; }

	public double? ApiPrjPrdHScore { get; set; }

	public int? ApiPrjPrdHCount { get; set; }

	public int? ApiPrjPrdHDurationMin { get; set; }

	public bool? PrjPrdHNoCalc { get; set; }

	public int? LanguageId { get; set; }
}
