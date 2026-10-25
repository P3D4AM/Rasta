namespace Mobile.Models;

public class FOMobspSelectCrmFoSetting_Result
{
	public int FoSettingId { get; set; }

	public int? EmailUserInfoId { get; set; }

	public bool? EmailSendingIsActive { get; set; }

	public bool? SmsSendingIsActive { get; set; }

	public int? EmailSettingId { get; set; }

	public bool? SmsIsSendedVerification { get; set; }

	public bool? EmailSmtpUseDefaultCredentials { get; set; }

	public bool? EmailSmtpEnableSSL { get; set; }

	public int? EmailSmtpPort { get; set; }

	public string FoLogEmailAdminI { get; set; }

	public string FoLogEmailAdminII { get; set; }

	public bool? TicketSubjSelectLoadDefaultContext { get; set; }

	public bool? TicketCanAddNewSubject { get; set; }

	public bool? SmsSendByWeb { get; set; }

	public bool? SmsSendByGSM { get; set; }

	public string SmsWebServiceUserName { get; set; }

	public string SmsWebServicePassword { get; set; }

	public string SmsWebServiceNumber { get; set; }

	public int? SmsVerificationId { get; set; }

	public int? TicketFileAttachCount { get; set; }

	public string TicketDescTooltip { get; set; }

	public int? TicketAddProjectTypeId { get; set; }

	public bool? FoCanInsCnvs { get; set; }

	public string CnvsDescTooltip { get; set; }

	public int? FoOrdListShowType { get; set; }

	public string FoSalesOrderLbl { get; set; }

	public string FoSalesReturnOrderLbl { get; set; }

	public string FoCmpInfoTabTitle { get; set; }

	public string FoLinkedCmpInfoTabTitle { get; set; }

	public string FoCmpPrjInfoTabTitle { get; set; }

	public bool? FoShowCmpPrjInfoTab { get; set; }

	public string FoLinkedCmpPrjInfoTabTitle { get; set; }

	public bool? FoShowLinkedCmpPrjInfoTab { get; set; }

	public string FoCmpPordInfoTabTitle { get; set; }

	public bool? FoShowCmpPordInfoTab { get; set; }

	public string FoLinkedCmpPordInfoTabTitle { get; set; }

	public bool? FoShowLinkedCmpPordInfoTab { get; set; }

	public string FoCmpOrdInfoTabTitle { get; set; }

	public bool? FoShowCmpOrdInfoTab { get; set; }

	public string FoLinkedCmpOrdInfoTabTitle { get; set; }

	public bool? FoShowLinkedCmpOrdInfoTab { get; set; }

	public string FoCmpDraftInfoTabTitle { get; set; }

	public bool? FoShowCmpDraftInfoTab { get; set; }

	public string FoLinkedCmpDraftInfoTabTitle { get; set; }

	public bool? FoShowLinkedCmpDraftInfoTab { get; set; }

	public string FoCmpTicketInfoTabTitle { get; set; }

	public bool? FoShowCmpTicketInfoTab { get; set; }

	public string FoDyFormInfoTabTitle { get; set; }

	public bool? FoShowDyFormInfoTab { get; set; }

	public string FoCmpLinkedInfoTabTitle { get; set; }

	public bool? FoShowCmpLinkedInfoTab { get; set; }

	public bool? FoShowBParsianTabs { get; set; }

	public string FoCmpLetterInfoTabTitle { get; set; }

	public bool? FoShowCmpLetterInfoTab { get; set; }

	public string FoCmpFileInfoTabTitle { get; set; }

	public bool? FoShowCmpFileInfoTab { get; set; }

	public string FoSurveyInfoTabTitle { get; set; }

	public bool? FoShowSurveyInfoTab { get; set; }

	public bool? FoShowControlPrdValidity { get; set; }

	public bool? FoCanEditPayAmount { get; set; }

	public bool? PrdPriceInDecimalVisible { get; set; }

	public string FoMobLogoTitle { get; set; }

	public string FoMobEntryLogoPath { get; set; }

	public bool? FoShowDiscountCodeInfoTab { get; set; }

	public string FoDiscountCodeInfoTabTitle { get; set; }

	public string LoginAuthenticationType { get; set; }

	public string LoginType { get; set; }

	public bool? LoginSendOTPSms { get; set; }

	public string LoginSendOTPSmsBodyPatternFormula { get; set; }

	public int? TicketDescMaxLen { get; set; }

	public int? ShpDefLinkAccSettingDBId { get; set; }

	public bool? LoginByPassword { get; set; }

	public bool? LoginByOTP { get; set; }

	public string LoginByOTPSmsBodyPatternFormula { get; set; }

	public bool? LoginAndFoActive { get; set; }
}
