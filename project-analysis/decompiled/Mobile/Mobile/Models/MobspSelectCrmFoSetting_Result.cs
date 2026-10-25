namespace Mobile.Models;

public class MobspSelectCrmFoSetting_Result
{
	public int FoSettingId { get; set; }

	public bool? TicketAutoReplyAfterSetDoingTime { get; set; }

	public bool? ShpPrdDeliveryScheduleActive { get; set; }

	public int? ShpDeliveryScheduleLimitMoveDay { get; set; }

	public bool? TicketColorAllarm { get; set; }

	public string TicketColorAllarmJs { get; set; }

	public bool? shpUniqueSaleCenterParentInOrd { get; set; }

	public bool? ShpDefItemCalculateTax { get; set; }

	public decimal? ShpDefItemTaxIndex { get; set; }

	public int? ShpDefWHId { get; set; }

	public int? PrdStockControlType { get; set; }

	public bool? ShpPrdDoneTimeScheduleActive { get; set; }

	public bool? ShpCartIssuePordAfterPayOnLine { get; set; }

	public int? ShpDefPordVerifierRequestId { get; set; }

	public int? ShpDefPordPayTypeId { get; set; }

	public int? ShpDefPordCnvsTopicId { get; set; }

	public string ShpDefPordCnvsDesc { get; set; }

	public int? ShpDefPordCnvsReferUserId { get; set; }

	public int? ShpDefPordCnvsStatusId { get; set; }

	public string ShpDefPrjTitle { get; set; }

	public int? ShpDefPrjcnvsStatusGroupId { get; set; }

	public bool? ShpCartIssueOrdAfterPayOnLine { get; set; }

	public int? ShpDefOrderOprId { get; set; }

	public int? ShpDefCurrencyUnitId { get; set; }

	public int? ShpDefPordExpireDay { get; set; }

	public int? ShpDefPordCreditDurationId { get; set; }

	public int? ShpDefPordPrintFormatId { get; set; }

	public int? SHPDefItemTaxType { get; set; }

	public bool? ShpCanSaveOnlinePaymentAfterVerify { get; set; }

	public string LoginAuthenticationInfoJson { get; set; }

	public int? CId { get; set; }

	public string CenterName { get; set; }

	public string PrdCardInfoHTML { get; set; }

	public int? ShpDefPrjStarterUserId { get; set; }

	public string ShpDefPrjStarterUser { get; set; }

	public bool? ShpDefPrjNewProjectOnCart { get; set; }

	public int? ShpFooterId { get; set; }

	public string ShpFooterTitle { get; set; }

	public string ShpHomeTopHeaderContent { get; set; }

	public string ShpLinkedPrdLbl { get; set; }

	public decimal? ShpTolerancePercent { get; set; }

	public int? ShpToleranceLinkedPrdId { get; set; }

	public string ShpToleranceLinkedPrd { get; set; }

	public string RegNullableFields { get; set; }

	public string FoPordListShowType { get; set; }

	public bool? ShpPrsAddressNotNull { get; set; }

	public int? ShpDefPordCnvsStatusResultId { get; set; }

	public int? ShpDefOrdCnvsStatusResultId { get; set; }

	public string ShpDefPordCnvsStatusResult { get; set; }

	public string ShpDefOrdCnvsStatusResult { get; set; }

	public bool? ShpDeliveryScheduleActive { get; set; }

	public bool? ShpPrdDeliveryScheduleActiveInBox { get; set; }

	public bool? ShpPrdDeliveryScheduleActiveInDetail { get; set; }

	public string ShpCartPayTypeIds { get; set; }

	public string ShpPrdDefPhotoAdd { get; set; }

	public string LoginAuthenticationType { get; set; }

	public bool? LoginByOTP { get; set; }

	public bool? LoginByPassword { get; internal set; }

	public string LoginType { get; set; }

	public bool? LoginSendOTPSms { get; internal set; }

	public bool? SmsSendingIsActive { get; set; }

	public string LoginByOtpSmsBodyPatternFormula { get; set; }

	public string LoginSendOTPSmsBodyPatternFormula { get; set; }
}
