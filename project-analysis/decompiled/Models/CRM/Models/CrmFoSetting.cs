using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmFoSettingMetadata))]
public class CrmFoSetting
{
	public int FoSettingId { get; set; }

	public int? CmpDefaultGroupId { get; set; }

	public int? CmpDefaultSubGroupId { get; set; }

	public int? CmpDefaultGroupIdII { get; set; }

	public int? CmpDefaultGroupIdIII { get; set; }

	public int? CmpDefaultGroupIdIV { get; set; }

	public int? CmpDefaultTypeId { get; set; }

	public int? CmpDefaultPresentationId { get; set; }

	public int CmpDefaultReferUserId { get; set; }

	public string PrjDefaultTitle { get; set; }

	public int PrjDefaultStarterUserId { get; set; }

	public int? PrjDefaultGradeId { get; set; }

	public int? PrjDefaultPriorityId { get; set; }

	public int? PrjDefaultGroupId { get; set; }

	public int PrjDefaultCnvsStatusGroupId { get; set; }

	public string PrjDefaultPostFix { get; set; }

	public bool? PrjDefaultFOCmpCanSee { get; set; }

	public bool? PrjInsertCrmProjectsForbiddenFUFDPActive { get; set; }

	public bool? PrjInsertProjectInformationsDefualtFieldActive { get; set; }

	public int CnvsDefaultTopicId { get; set; }

	public string CnvsDefaultDesc { get; set; }

	public int CnvsDefaultUserId { get; set; }

	public int CnvsDefaultReferUserId { get; set; }

	public string CnvsDefaultReferDesc { get; set; }

	public int CnvsDefaultStatusId { get; set; }

	public int? CnvsDefaultPriorityId { get; set; }

	public bool? EmailSendingIsActive { get; set; }

	public int? EmailSettingId { get; set; }

	public int? EmailUserInfoId { get; set; }

	public string EmailSubjectPatternFormula { get; set; }

	public string EmailBodyPatternFormula { get; set; }

	public bool? SmsSendingIsActive { get; set; }

	public string SmsWebServiceUserName { get; set; }

	public string SmsWebServicePassword { get; set; }

	public string SmsWebServiceNumber { get; set; }

	public string SmsWebServiceUrl { get; set; }

	public string SmsBodyPatternFormula { get; set; }

	public string FoLogEmailAdminI { get; set; }

	public string FoLogEmailAdminII { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }

	public string CnvsDescTooltip { get; set; }

	public string TicketDescTooltip { get; set; }

	public bool? PrdPriceVisible { get; set; }

	public int? PrdDisplayType { get; set; }

	public bool? TicketSubjSelectLoadDefaultContext { get; set; }

	public string TicketSubjectDefaultContext { get; set; }

	public string LoginTitle { get; set; }

	public string LoginFormTitle { get; set; }

	public string LoginBgImagePath { get; set; }

	public string LoginBgColor { get; set; }

	public string LoginBtnBgColor { get; set; }

	public string LoginBtnFontColor { get; set; }

	public string LoginLinkColor { get; set; }

	public string LoginRegLinkTitle { get; set; }

	public int? LoginPosition { get; set; }

	public string LoginTextBorderFColor { get; set; }

	public string LoginTextBorderTColor { get; set; }

	public string RegTitle { get; set; }

	public string RegFormTitle { get; set; }

	public string RegBgImagePath { get; set; }

	public string RegBgColor { get; set; }

	public string RegBtnBgColor { get; set; }

	public string RegBtnFontColor { get; set; }

	public string RegLinkColor { get; set; }

	public string RegLoginLinkTitle { get; set; }

	public int? RegPosition { get; set; }

	public string RegTextBorderFColor { get; set; }

	public string RegTextBorderTColor { get; set; }

	public int? RegDyFormId { get; set; }

	public bool? ShpSidebarMenuVisible { get; set; }

	public string ShpLogoPathWidth110 { get; set; }

	public string ShpLogoPathWidth215 { get; set; }

	public bool? PrdFCRVisible { get; set; }

	public bool? PrdPriceWithFCRVisible { get; set; }

	public int? ShpHomeGalleryIdI { get; set; }

	public int? ShpHomeGalleryIdII { get; set; }

	public int? ShpHomeGalleryIdIII { get; set; }

	public string ShpHomeTopHeaderBgColor { get; set; }

	public string ShpHomePrdPartTitle { get; set; }

	public string ShpHomeTopHeaderFontColor { get; set; }

	public bool? PrdPriceInDecimalVisible { get; set; }

	public bool? SmsSendByWeb { get; set; }

	public bool? SmsSendByGSM { get; set; }

	public decimal? ShpTransportationDefValue { get; set; }

	public decimal? ShpTransportationFreeMinValue { get; set; }

	public int? ShpDefPrjcnvsStatusGroupId { get; set; }

	public int? ShpDefWHId { get; set; }

	public int? ShpDefCurrencyUnitId { get; set; }

	public int? ShpDefPordVerifierRequestId { get; set; }

	public string ShpDefPordVerifierRequestMsg { get; set; }

	public int? ShpDefPordExpireDay { get; set; }

	public int? ShpDefPordCnvsTopicId { get; set; }

	public string ShpDefPordCnvsDesc { get; set; }

	public int? ShpDefPordCnvsReferUserId { get; set; }

	public string ShpDefPordCnvsReferMultiUser { get; set; }

	public int? ShpDefPordCnvsStatusId { get; set; }

	public int? ShpDefPordCnvsPriorityId { get; set; }

	public int? ShpDefOrderOprId { get; set; }

	public int? ShpDefOrdVerifierRequestId { get; set; }

	public string ShpDefOrdVerifierRequestMsg { get; set; }

	public int? ShpDefOrdpayTypeId { get; set; }

	public int? ShpDefOrdCnvsTopicId { get; set; }

	public string ShpDefOrdCnvsDesc { get; set; }

	public int? ShpDefOrdCnvsReferUserId { get; set; }

	public string ShpDefOrdCnvsReferMultiUser { get; set; }

	public int? ShpDefOrdCnvsStatusId { get; set; }

	public int? ShpDefOrdCnvsPriorityId { get; set; }

	public int? PrdStockControlType { get; set; }

	public int? PrdStockControlDefWhId { get; set; }

	public int? CmpDefUsernameType { get; set; }

	public int? CmpDefPasswordType { get; set; }

	public bool? EmailSmtpUseDefaultCredentials { get; set; }

	public bool? EmailSmtpEnableSSL { get; set; }

	public int? EmailSmtpPort { get; set; }

	public bool? FoActAddProductToOrder { get; set; }

	public bool? ShpStartWithShop { get; set; }

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

	public string FoSalesOrderLbl { get; set; }

	public string FoSalesReturnOrderLbl { get; set; }

	public bool? SmsIsSendedVerification { get; set; }

	public int? SmsVerificationId { get; set; }

	public bool? ShpShowPayOnLineRdoBtn { get; set; }

	public string ShpCartDescriptionLbl { get; set; }

	public string ShpCartDescriptionPlaceholder { get; set; }

	public string ShpDefPrjTitle { get; set; }

	public bool? FoShowBParsianTabs { get; set; }

	public string FoCmpLetterInfoTabTitle { get; set; }

	public bool? FoShowCmpLetterInfoTab { get; set; }

	public string FoCmpFileInfoTabTitle { get; set; }

	public bool? FoShowCmpFileInfoTab { get; set; }

	public string ShpCartPayTypeIds { get; set; }

	public string FoSurveyInfoTabTitle { get; set; }

	public bool? FoShowSurveyInfoTab { get; set; }

	public bool? FoCanEditPayAmount { get; set; }

	public bool? BParsianShahkarActive { get; set; }

	public bool? ShpSeoIsActive { get; set; }

	public bool? FoShowShopBtn { get; set; }

	public bool? TicketCanAddNewSubject { get; set; }

	public int? TicketAllowInCurrntCount { get; set; }

	public int? TicketAllowAddBeforeAnswerCount { get; set; }

	public int? TicketAutoCloseAfterDay { get; set; }

	public int? TicketAddProjectTypeId { get; set; }

	public string TicketProjectTitleAndTitleGroup { get; set; }

	public int? FoHomeGalleryIdI { get; set; }

	public int? FoHomeGalleryIdII { get; set; }

	public int? FoHomeGalleryIdIII { get; set; }

	public int? MobFoHomeGalleryId { get; set; }

	public string EmailSubjectPatternFormulaSendFoInfo { get; set; }

	public string EmailBodyPatternFormulaSendFoInfo { get; set; }

	public string SmsBodyPatternFormulaSendFoInfo { get; set; }

	public bool? LoginRegBtnHide { get; set; }

	public bool? FoCanInsCnvs { get; set; }

	public int? FoFileAttachCount { get; set; }

	public int? TicketFileAttachCount { get; set; }

	public bool? TicketSendIntMsg { get; set; }

	public bool? TicketFullRemindDate { get; set; }

	public bool? TicketCountCurrentWithStop { get; set; }

	public bool? TicketAutoReplyAfterSetDoingTime { get; set; }

	public int? TicketAutoReplyAfterSetDoingTimeTopicId { get; set; }

	public string TicketAutoReplyAfterSetDoingTimeDesc { get; set; }

	public int? FoOrdListShowType { get; set; }

	public bool? ShpPrsAddressNotNull { get; set; }

	public bool? ShpDeliveryScheduleActive { get; set; }

	public bool? ShpPrdDeliveryScheduleActive { get; set; }

	public bool? ShpPrdDeliveryScheduleActiveInBox { get; set; }

	public bool? ShpPrdDeliveryScheduleActiveInDetail { get; set; }

	public int? ShpDeliveryScheduleLimitMoveDay { get; set; }

	public bool? ShpCartIssuePordAfterPayOnLine { get; set; }

	public int? ShpDefPordReferUserId { get; set; }

	public bool? ShpPordVerifyAfterIssue { get; set; }

	public int? ShpDefPordVerifyWorkFlowId { get; set; }

	public bool? ShpPordVerifyWorkFlowStartAfterIssue { get; set; }

	public bool? ShpPordSendSmsAfterIssue { get; set; }

	public bool? ShpPordSendSmsAfterIssueGSM { get; set; }

	public int? ShpDefPordSendSmsAfterIssueGSMSetId { get; set; }

	public bool? ShpPordSendSmsAfterIssueWeb { get; set; }

	public int? ShpDefPordSendSmsAfterIssueProviderId { get; set; }

	public string ShpDefPordSendSmsAfterIssueNumber { get; set; }

	public string ShpDefPordSendSmsAfterIssueBodyPatternFormula { get; set; }

	public bool? ShpPordSendEmailAfterIssue { get; set; }

	public int? ShpDefPordSendEmailAfterIssueSettingId { get; set; }

	public int? ShpDefPordSendEmailAfterIssueUserInfoId { get; set; }

	public string ShpDefPordSendEmailAfterIssueSubjectPatternFormula { get; set; }

	public string ShpDefPordSendEmailAfterIssueBodyPatternFormula { get; set; }

	public bool? ShpCartIssueOrdAfterPayOnLine { get; set; }

	public int? ShpDefOrdReferUserId { get; set; }

	public bool? ShpOrdVerifyAfterIssue { get; set; }

	public int? ShpDefOrdVerifyWorkFlowId { get; set; }

	public bool? ShpOrdVerifyWorkFlowStartAfterIssue { get; set; }

	public bool? ShpOrdSendSmsAfterIssue { get; set; }

	public bool? ShpOrdSendSmsAfterIssueGSM { get; set; }

	public int? ShpDefOrdSendSmsAfterIssueGSMSetId { get; set; }

	public bool? ShpOrdSendSmsAfterIssueWeb { get; set; }

	public int? ShpDefOrdSendSmsAfterIssueProviderId { get; set; }

	public string ShpDefOrdSendSmsAfterIssueNumber { get; set; }

	public string ShpDefOrdSendSmsAfterIssueBodyPatternFormula { get; set; }

	public bool? ShpOrdSendEmailAfterIssue { get; set; }

	public int? ShpDefOrdSendEmailAfterIssueSettingId { get; set; }

	public int? ShpDefOrdSendEmailAfterIssueUserInfoId { get; set; }

	public string ShpDefOrdSendEmailAfterIssueSubjectPatternFormula { get; set; }

	public string ShpDefOrdSendEmailAfterIssueBodyPatternFormula { get; set; }

	public bool? ShpOrdSendLinkAccAfterIssue { get; set; }

	public string SmsBodyPatternFormulaForgetPassword { get; set; }

	public bool? FoShowControlPrdValidity { get; set; }

	public int? ShpDefPordPayTypeId { get; set; }

	public string FoMobLogoTitle { get; set; }

	public string FoMobEntryLogoPath { get; set; }

	public bool? ShpShowDeliveryTerm { get; set; }

	public bool? TicketDelayAllarm { get; set; }

	public int? TicketDelayAllarmDay { get; set; }

	public string TicketDelayAllarmTime { get; set; }

	public string TicketDelayAllarmReceivers { get; set; }

	public string TicketDelayAllarmMessage { get; set; }

	public bool? TicketDelayAllarmSendSMS { get; set; }

	public int? TicketDelayAllarmSendSMSProviderId { get; set; }

	public string TicketDelayAllarmSendSMSNumber { get; set; }

	public bool? TicketBusyAllarm { get; set; }

	public int? TicketBusyAllarmAllMsgCnt { get; set; }

	public int? TicketBusyAllarmUserRepCnt { get; set; }

	public string TicketBusyAllarmReceivers { get; set; }

	public string TicketBusyAllarmMessage { get; set; }

	public bool? TicketBusyAllarmSendSMS { get; set; }

	public int? TicketBusyAllarmSendSMSProviderId { get; set; }

	public string TicketBusyAllarmSendSMSNumber { get; set; }

	public bool? TicketUnhappyAllarm { get; set; }

	public int? TicketUnhappyAllarmMinVote { get; set; }

	public string TicketUnhappyAllarmReceivers { get; set; }

	public string TicketUnhappyAllarmMessage { get; set; }

	public bool? TicketUnhappyAllarmSendSMS { get; set; }

	public int? TicketUnhappyAllarmSendSMSProviderId { get; set; }

	public string TicketUnhappyAllarmSendSMSNumber { get; set; }

	public bool? TicketColorAllarm { get; set; }

	public string TicketColorAllarmJs { get; set; }

	public int? TicketClosedCanReplayAfterDays { get; set; }

	public string FoDiscountCodeInfoTabTitle { get; set; }

	public bool? FoShowDiscountCodeInfoTab { get; set; }

	public bool? FoShowPordByTspMethod { get; set; }

	public bool? FoShowOrdByTspMethod { get; set; }

	public bool? ShpPrdDoneTimeScheduleActive { get; set; }

	public bool? ShpUniqueSaleCenterParentInOrd { get; set; }

	public bool? ShpCartSettlementCreditActive { get; set; }

	public bool? ShpDefItemCalculateTax { get; set; }

	public decimal? ShpDefItemTaxIndex { get; set; }

	public int? CmpDefFOActiveType { get; set; }

	public string SmsBodyPatternFormulaOTP { get; set; }

	public int? ShpDefItemTaxType { get; set; }

	public int? ShpDefPordCreditDurationId { get; set; }

	public int? ShpDefPordPrintFormatId { get; set; }

	public bool? ShpPordSendSmsAfterVerify { get; set; }

	public bool? ShpPordSendSmsAfterVerifyGSM { get; set; }

	public int? ShpDefPordSendSmsAfterVerifyGSMSetId { get; set; }

	public bool? ShpPordSendSmsAfterVerifyWeb { get; set; }

	public int? ShpDefPordSendSmsAfterVerifyProviderId { get; set; }

	public string ShpDefPordSendSmsAfterVerifyNumber { get; set; }

	public string ShpDefPordSendSmsAfterVerifyBodyPatternFormula { get; set; }

	public int? ShpDefOrdPrintFormatId { get; set; }

	public bool? ShpOrdSendSmsAfterVerify { get; set; }

	public bool? ShpOrdSendSmsAfterVerifyGSM { get; set; }

	public int? ShpDefOrdSendSmsAfterVerifyGSMSetId { get; set; }

	public bool? ShpOrdSendSmsAfterVerifyWeb { get; set; }

	public int? ShpDefOrdSendSmsAfterVerifyProviderId { get; set; }

	public string ShpDefOrdSendSmsAfterVerifyNumber { get; set; }

	public string ShpDefOrdSendSmsAfterVerifyBodyPatternFormula { get; set; }

	public bool? ShpCanSaveOnlinePaymentAfterVerify { get; set; }

	public string FoAdminUserIds { get; set; }

	public string LoginAuthenticationType { get; set; }

	public string LoginType { get; set; }

	public bool? LoginSendOTPSms { get; set; }

	public string LoginSendOTPSmsBodyPatternFormula { get; set; }

	public int? CId { get; set; }

	public string PrdCardInfoHTML { get; set; }

	public string LoginAuthenticationInfoJson { get; set; }

	public int? ShpDefPrjStarterUserId { get; set; }

	public bool? ShpDefPrjNewProjectOnCart { get; set; }

	public int? ShpFooterId { get; set; }

	public string ShpHomeTopHeaderContent { get; set; }

	public string ShpLinkedPrdLbl { get; set; }

	public bool? ShpTransportationVisible { get; set; }

	public bool? ShpToleranceVisible { get; set; }

	public decimal? ShpTolerancePercent { get; set; }

	public int? ShpToleranceLinkedPrdId { get; set; }

	public string RegNullableFields { get; set; }

	public string FoPordListShowType { get; set; }

	public int? ShpDefPordCnvsStatusResultId { get; set; }

	public int? ShpDefOrdCnvsStatusResultId { get; set; }

	public string FoCmpMnBgInfoTabTitle { get; set; }

	public bool? FoShowCmpMnBgInfoTab { get; set; }

	public bool? LoginByPassword { get; set; }

	public bool? LoginByOTP { get; set; }

	public string LoginByOTPSmsBodyPatternFormula { get; set; }

	public bool? LoginAndFoActive { get; set; }

	public bool? LoginAndShpActive { get; set; }

	public int? TicketDescMaxLen { get; set; }

	public int? ShpDefLinkAccSettingDBId { get; set; }

	public string ShpHomeSeoTitle { get; set; }

	public string ShpHomeSeoDescription { get; set; }

	public string ShpHomeSeoHttpEquiv { get; set; }

	public string ShpHomeSeoExpires { get; set; }

	public bool? ShpHomeSeoGoogleNotranslate { get; set; }

	public string ShpHomeSeoDistribution { get; set; }

	public string ShpHomeSeoRobots { get; set; }

	public string ShpHomeSeoRating { get; set; }

	public string ShpHomeSeoAuthor { get; set; }

	public bool? ShpHomeSeoIsUseSocialNetwork { get; set; }

	public int? ShpHomeSeoMobileOptimized { get; set; }

	public string ShpHomeSeoCopyright { get; set; }

	public bool? ShpHomeSeoUseDefault { get; set; }

	public string ShpHomeSeoKeywords { get; set; }

	public string ShpHomeSeoFAQ { get; set; }

	public bool? ShpHomeSeoIsActive { get; set; }

	public string ShpSeoGoogleAnalytics { get; set; }

	public string ShpPrdDefPhotoAdd { get; set; }

	public virtual CrmCmsGallery CrmCmsGallery { get; set; }

	public virtual CrmCmsGallery CrmCmsGallery1 { get; set; }

	public virtual CrmCmsGallery CrmCmsGallery2 { get; set; }

	public virtual CrmCmsGallery CrmCmsGallery3 { get; set; }

	public virtual CrmCmsGallery CrmCmsGallery4 { get; set; }

	public virtual CrmCmsGallery CrmCmsGallery5 { get; set; }

	public virtual CrmCmsGallery CrmCmsGallery6 { get; set; }

	public virtual CrmCompanyGroups CrmCompanyGroups { get; set; }

	public virtual CrmCompanyGroupsII CrmCompanyGroupsII { get; set; }

	public virtual CrmCompanyGroupsIII CrmCompanyGroupsIII { get; set; }

	public virtual CrmCompanyGroupsIV CrmCompanyGroupsIV { get; set; }

	public virtual CrmCompanyPresentation CrmCompanyPresentation { get; set; }

	public virtual CrmCompanySubGroups CrmCompanySubGroups { get; set; }

	public virtual CrmCompanyType CrmCompanyType { get; set; }

	public virtual CrmConversationPriority CrmConversationPriority { get; set; }

	public virtual CrmConversationPriority CrmConversationPriority1 { get; set; }

	public virtual CrmConversationPriority CrmConversationPriority2 { get; set; }

	public virtual CrmConversationStatusGroups CrmConversationStatusGroups { get; set; }

	public virtual CrmConversationStatusGroups CrmConversationStatusGroups1 { get; set; }

	public virtual CrmConversationTopics CrmConversationTopics { get; set; }

	public virtual CrmConversationTopics CrmConversationTopics1 { get; set; }

	public virtual CrmConversationTopics CrmConversationTopics2 { get; set; }

	public virtual CrmConversationTopics CrmConversationTopics3 { get; set; }

	public virtual CrmDyForms CrmDyForms { get; set; }

	public virtual CrmProjectGrade CrmProjectGrade { get; set; }

	public virtual CrmProjectGroups CrmProjectGroups { get; set; }

	public virtual CrmProjectPriority CrmProjectPriority { get; set; }

	public virtual EmailSetting EmailSetting { get; set; }

	public virtual EmailUsersInfo EmailUsersInfo { get; set; }

	public virtual ICollection<CrmFoSetting_Lang> CrmFoSetting_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WsWareHouse WsWareHouse { get; set; }

	public virtual WSCurrencyUnits WSCurrencyUnits { get; set; }

	public virtual WSOrderOpr WSOrderOpr { get; set; }

	public virtual WSOrderPaymentTypes WSOrderPaymentTypes { get; set; }

	public virtual EmailSetting EmailSetting1 { get; set; }

	public virtual EmailUsersInfo EmailUsersInfo1 { get; set; }

	public virtual SmsGSMModemSetting SmsGSMModemSetting { get; set; }

	public virtual SmsProviders SmsProviders { get; set; }

	public virtual WSVerificationWorkFlows WSVerificationWorkFlows { get; set; }

	public virtual WSOrderPaymentTypes WSOrderPaymentTypes1 { get; set; }

	public virtual EmailSetting EmailSetting2 { get; set; }

	public virtual EmailUsersInfo EmailUsersInfo2 { get; set; }

	public virtual SmsGSMModemSetting SmsGSMModemSetting1 { get; set; }

	public virtual SmsProviders SmsProviders1 { get; set; }

	public virtual WSVerificationWorkFlows WSVerificationWorkFlows1 { get; set; }

	public virtual WsWareHouse WsWareHouse1 { get; set; }

	public virtual PrintFormat PrintFormat { get; set; }

	public virtual SmsGSMModemSetting SmsGSMModemSetting11 { get; set; }

	public virtual SmsProviders SmsProviders11 { get; set; }

	public virtual PrintFormat PrintFormat1 { get; set; }

	public virtual SmsGSMModemSetting SmsGSMModemSetting3 { get; set; }

	public virtual SmsProviders SmsProviders3 { get; set; }

	public virtual WSCreditDuration WSCreditDuration { get; set; }

	public virtual Centers Centers { get; set; }

	public virtual ICollection<CrmsysSetting> CrmsysSetting { get; set; }

	public virtual ICollection<CrmFoSettingRegister> CrmFoSettingRegister { get; set; }

	public virtual CrmCmsFooter CrmCmsFooter { get; set; }

	public virtual WSProducts WSProducts { get; set; }

	public virtual CrmConversationStatusResult CrmConversationStatusResult { get; set; }

	public virtual CrmConversationStatusResult CrmConversationStatusResult1 { get; set; }

	public virtual CrmConversationStatus CrmConversationStatus { get; set; }

	public virtual CrmConversationStatus CrmConversationStatus1 { get; set; }

	public virtual CrmConversationStatus CrmConversationStatus2 { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual Users Users2 { get; set; }

	public virtual Users Users3 { get; set; }

	public virtual Users Users4 { get; set; }

	public virtual Users Users5 { get; set; }

	public virtual Users Users6 { get; set; }

	public virtual Users Users7 { get; set; }

	public virtual Users Users8 { get; set; }

	public virtual Users Users9 { get; set; }

	public virtual Users Users10 { get; set; }

	public virtual Users Users11 { get; set; }

	public virtual Users Users12 { get; set; }

	public CrmFoSetting()
	{
		CrmFoSetting_Lang = (ICollection<CrmFoSetting_Lang>)new HashSet<CrmFoSetting_Lang>();
		CrmsysSetting = (ICollection<CrmsysSetting>)new HashSet<CrmsysSetting>();
		CrmFoSettingRegister = (ICollection<CrmFoSettingRegister>)new HashSet<CrmFoSettingRegister>();
	}
}
