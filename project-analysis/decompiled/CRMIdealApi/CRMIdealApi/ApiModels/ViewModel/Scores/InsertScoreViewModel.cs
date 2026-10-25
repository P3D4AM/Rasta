namespace CRMIdealApi.ApiModels.ViewModel.Scores;

public class InsertScoreViewModel : PublicParameters
{
	public string ApiScoreDate { get; set; }

	public double ApiScore { get; set; }

	public int? ApiScoreRuleId { get; set; }

	public int? ApiScoreOrderId { get; set; }

	public int? ApiScoreCmpId { get; set; }

	public int? ApiOrderView { get; set; }

	public int? ApiScoreSysPartId { get; set; }

	public int? ApiScoreObjectId { get; set; }

	public int? ApiScoreOprType { get; set; }

	public string ApiScoreExpireDate { get; set; }

	public int? ApiScoreExpireDay { get; set; }

	public bool? ApiScoreIsExpired { get; set; }

	public string ApiScoreDescription { get; set; }

	public decimal ApiPrice { get; set; }

	public int? ApiCompanyId { get; set; }

	public float? ApiScoreRuleRate { get; set; }

	public int ApiScoreKind { get; set; }
}
