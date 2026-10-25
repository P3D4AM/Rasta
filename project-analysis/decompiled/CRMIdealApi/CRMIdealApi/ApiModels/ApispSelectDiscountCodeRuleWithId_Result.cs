using System;

namespace CRMIdealApi.ApiModels;

public class ApispSelectDiscountCodeRuleWithId_Result
{
	public int DiscountCodeRuleId { get; set; }

	public string DisRTitle { get; set; }

	public string DisRPreCode { get; set; }

	public decimal? DisRAmount { get; set; }

	public decimal? DisRAmountPercent { get; set; }

	public int? DisRExpDay { get; set; }

	public DateTime? DisRExpDate { get; set; }

	public string DisRExpDatePersian { get; set; }

	public int? DisRUseCnt { get; set; }

	public double? DisRScoreRate { get; set; }

	public bool? DisRCanChangeToScore { get; set; }

	public bool? DisRInActive { get; set; }

	public int FirstRegisterUserId { get; set; }

	public string FirstRegisterUser { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public string EditUser { get; set; }

	public int FPId { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }
}
