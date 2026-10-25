namespace CRMIdealApi.ApiModels.ViewModel.DiscountCodes;

public class InsertDiscountCodeRuleViewModel : PublicParametersWithOutCenter
{
	public string ApiDisRTitle { get; set; }

	public string ApiDisRPreCode { get; set; }

	public decimal? ApiDisRAmount { get; set; }

	public decimal? ApiDisRAmountPercent { get; set; }

	public string ApiDisRExpDate { get; set; }

	public int? ApiDisRExpDay { get; set; }

	public int? ApiDisRUseCnt { get; set; }

	public bool? ApiDisRInActive { get; set; }

	public bool? ApiDisRCanChangeToScore { get; set; }

	public float? ApiDisRScoreRate { get; set; }
}
