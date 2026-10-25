using System;

namespace CRMIdealApi.ApiModels.ViewModel.Scores;

public class UpdateScoreViewModel : PublicParameters
{
	public int ApiScoreId { get; set; }

	public DateTime? ApiScoreDateTime { get; set; }

	public string ApiScoreDate { get; set; }

	public double? ApiScore { get; set; }

	public int? ApiScoreRuleId { get; set; }

	public int? ApiOrderView { get; set; }

	public int? ApiScoreSysPartId { get; set; }

	public int? ApiScoreObjectId { get; set; }

	public int? ApiScoreOprType { get; set; }

	public string ApiScoreExpireDate { get; set; }

	public DateTime? ApiScoreExpireDateTime { get; set; }

	public bool? ApiScoreIsExpired { get; set; }

	public string ApiScoreDescription { get; set; }

	public decimal ApiPrice { get; set; }

	public int? ApiCompanyId { get; set; }

	public float? ApiScoreRuleRate { get; set; }

	public int? ApiScoreKind { get; set; }
}
