using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmCompanyMetadata))]
public class CrmCompany
{
	public int CompanyID { get; set; }

	public string ImportDate { get; set; }

	public DateTime? ImportDateTime { get; set; }

	public int? cmpNumber { get; set; }

	public string cmpName { get; set; }

	public string cmpNameEng { get; set; }

	public int? cmpTitleId { get; set; }

	public string cmpFame { get; set; }

	public string cmpActivityType { get; set; }

	public int? cmpGroupId { get; set; }

	public int? cmpSubGroupId { get; set; }

	public int? cmpGroupIdII { get; set; }

	public int? cmpGroupIdIII { get; set; }

	public int? cmpGroupIdIV { get; set; }

	public int? cmpTypeId { get; set; }

	public int? cmpPresentationId { get; set; }

	public string cmpPreTel { get; set; }

	public string cmpTel { get; set; }

	public string cmpTelUpTo { get; set; }

	public string cmpTelDesc { get; set; }

	public string cmpPreTelII { get; set; }

	public string cmpTelII { get; set; }

	public string cmpTelUpToII { get; set; }

	public string cmpTelIIDesc { get; set; }

	public string cmpMobile { get; set; }

	public string cmpFax { get; set; }

	public string cmpFaxDesc { get; set; }

	public int? cmpCountryId { get; set; }

	public int? cmpProvinceId { get; set; }

	public int? cmpCityId { get; set; }

	public string cmpAddress { get; set; }

	public string cmpAddressDesc { get; set; }

	public string cmpZipCode { get; set; }

	public string cmpPostBox { get; set; }

	public string cmpWebSite { get; set; }

	public string cmpEmail { get; set; }

	public string cmpInteresting { get; set; }

	public string cmpSpecialPoint { get; set; }

	public string cmpDescription { get; set; }

	public string cmpUserName { get; set; }

	public string cmpPassword { get; set; }

	public int? cmpFirstRegisterUserId { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public int AddType { get; set; }

	public string cmpRegistrationNumber { get; set; }

	public string cmpEconomicCode { get; set; }

	public string cmpNationalCode { get; set; }

	public Guid? GUId { get; set; }

	public string cmpBuyLimit { get; set; }

	public string cmpAccountNumber { get; set; }

	public string cmpAccInquiry { get; set; }

	public string cmpFreight { get; set; }

	public string cmpInquiry { get; set; }

	public int cmpReferUserId { get; set; }

	public string AppType { get; set; }

	public string cmpSpecialWordForCI { get; set; }

	public string cmpCode { get; set; }

	public string cmpEffectiveDatePersian { get; set; }

	public DateTime? cmpEffectiveDateTime { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public string cmpCoordinateLatitude { get; set; }

	public string cmpCoordinateLongitude { get; set; }

	public DateTime? cmpCoordinateLastDate { get; set; }

	public string cmpCoordinateLastDatePersian { get; set; }

	public int? cmpCoordinateZoomLevel { get; set; }

	public int? cmpCoordinateLastUserId { get; set; }

	public bool? cmpFOAccessLinkedCompany { get; set; }

	public int? cmpLinkAccCodeId { get; set; }

	public string cmpLinkAccCode { get; set; }

	public int? cmpLinkAccCustomerId { get; set; }

	public string cmpLinkAccCustomerIdStr { get; set; }

	public bool? cmpIsDraft { get; set; }

	public int? cmpKind { get; set; }

	public int? cmpMainPersonId { get; set; }

	public string cmpNameOfficial { get; set; }

	public int? cmpTicketAllowInCurrntCount { get; set; }

	public int? cmpTicketAllowAddBeforeAnswerCount { get; set; }

	public string cmpIVRLinkRule { get; set; }

	public string cmpCampaignIds { get; set; }

	public bool? cmpTicketCountCurrentWithStop { get; set; }

	public string cmpFOManagers { get; set; }

	public int? cmpSuppUserId { get; set; }

	public int? cmpOfficialCityId { get; set; }

	public string cmpOfficialAddress { get; set; }

	public string cmpOfficialZipCode { get; set; }

	public string cmpOfficialDesc { get; set; }

	public string cmpOfficialTel { get; set; }

	public int? TspCmpTob { get; set; }

	public string TspCmpBbc { get; set; }

	public string TspCmpBpn { get; set; }

	public int? cmpShpSettlementTypeId { get; set; }

	public int? cmpShpSettlementCreditIssueType { get; set; }

	public decimal? cmpShpSettlementCreditPerBuy { get; set; }

	public decimal? cmpShpSettlementTotalCredit { get; set; }

	public bool? cmpShpSettlementCreditRemainShow { get; set; }

	public DateTime? cmpLinkAccFirstTransferDate { get; set; }

	public DateTime? cmpLinkAccLastTransferDate { get; set; }

	public bool? cmpCRMShopIsActive { get; set; }

	public DateTime? cmpCRMShopActiveDate { get; set; }

	public DateTime? cmpIVRCallBlockDateTime { get; set; }

	public int? cmpIVRCallBlockUserId { get; set; }

	public DateTime? cmpIVRCallBlockRegisterDate { get; set; }

	public string cmpIVRCallBlockRegisterDatePersian { get; set; }

	public string cmpLinkAccData { get; set; }

	public bool? cmpFOIsActive { get; set; }

	public DateTime? cmpFOActiveDate { get; set; }

	public int? cmpFOActiveUserId { get; set; }

	public DateTime? cmpFOLoginExpireDate { get; set; }

	public int? cmpFOLoginExpireUserId { get; set; }

	public string cmpCIds { get; set; }

	public string cmpFOInfo { get; set; }

	public int? cmpLastCId { get; set; }

	public int? cmpQuickRegisterDefSettingId { get; set; }

	public virtual City City { get; set; }

	public virtual City City1 { get; set; }

	public virtual Country Country { get; set; }

	public virtual ICollection<CrmBankingAccounts> CrmBankingAccounts { get; set; }

	public virtual ICollection<CrmCallHistory> CrmCallHistory { get; set; }

	public virtual ICollection<CrmCmsComments> CrmCmsComments { get; set; }

	public virtual ICollection<CrmCmsLikes> CrmCmsLikes { get; set; }

	public virtual CrmCompanyGroups CrmCompanyGroups { get; set; }

	public virtual CrmCompanyGroupsII CrmCompanyGroupsII { get; set; }

	public virtual CrmCompanyGroupsIII CrmCompanyGroupsIII { get; set; }

	public virtual CrmCompanyGroupsIV CrmCompanyGroupsIV { get; set; }

	public virtual CrmCompanyPersons CrmCompanyPersons { get; set; }

	public virtual CrmCompanyPresentation CrmCompanyPresentation { get; set; }

	public virtual CrmCompanySubGroups CrmCompanySubGroups { get; set; }

	public virtual CrmCompanyTitle CrmCompanyTitle { get; set; }

	public virtual CrmCompanyType CrmCompanyType { get; set; }

	public virtual ICollection<CrmCompany_Lang> CrmCompany_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual Province Province { get; set; }

	public virtual ICollection<CrmCompanyAddresses> CrmCompanyAddresses { get; set; }

	public virtual ICollection<CrmCompanyForbiddenCompany> CrmCompanyForbiddenCompany { get; set; }

	public virtual ICollection<CrmCompanyJustAccessCompany> CrmCompanyJustAccessCompany { get; set; }

	public virtual ICollection<CrmCompanyLoGo> CrmCompanyLoGo { get; set; }

	public virtual ICollection<CrmCompanyMoneyBag> CrmCompanyMoneyBag { get; set; }

	public virtual ICollection<CrmCompanyMultiGroups> CrmCompanyMultiGroups { get; set; }

	public virtual ICollection<CrmCompanyPersons> CrmCompanyPersons1 { get; set; }

	public virtual ICollection<CrmCompanyPictureAlbums> CrmCompanyPictureAlbums { get; set; }

	public virtual ICollection<CrmCompanyUserForbidden> CrmCompanyUserForbidden { get; set; }

	public virtual ICollection<CrmConversation> CrmConversation { get; set; }

	public virtual ICollection<CrmDyFormFieldMasterValues> CrmDyFormFieldMasterValues { get; set; }

	public virtual ICollection<CrmFilesDirectory> CrmFilesDirectory { get; set; }

	public virtual ICollection<CrmInternalMessage> CrmInternalMessage { get; set; }

	public virtual ICollection<CrmLeave> CrmLeave { get; set; }

	public virtual ICollection<CrmLinkedCompany> CrmLinkedCompany { get; set; }

	public virtual ICollection<CrmLinkedCompany> CrmLinkedCompany1 { get; set; }

	public virtual ICollection<CrmSurveyAnswerCategoryDetailValues> CrmSurveyAnswerCategoryDetailValues { get; set; }

	public virtual ICollection<CrmSurveyAnswerValue> CrmSurveyAnswerValue { get; set; }

	public virtual ICollection<CrmSurveyHistory> CrmSurveyHistory { get; set; }

	public virtual ICollection<CrmTelegBotContacts> CrmTelegBotContacts { get; set; }

	public virtual ICollection<CrmTelegContacts> CrmTelegContacts { get; set; }

	public virtual ICollection<CrmTempEmails> CrmTempEmails { get; set; }

	public virtual ICollection<EmailReceive> EmailReceive { get; set; }

	public virtual ICollection<EmailReceiveAttachments> EmailReceiveAttachments { get; set; }

	public virtual ICollection<EmailSendDetail> EmailSendDetail { get; set; }

	public virtual ICollection<EmailUserTempTank> EmailUserTempTank { get; set; }

	public virtual ICollection<SecLetters> SecLetters { get; set; }

	public virtual ICollection<SmsReceive> SmsReceive { get; set; }

	public virtual ICollection<SmsTempMobileNumbers> SmsTempMobileNumbers { get; set; }

	public virtual ICollection<WSBuyOrder> WSBuyOrder { get; set; }

	public virtual ICollection<WSBuyOrder> WSBuyOrder1 { get; set; }

	public virtual ICollection<WSBuyOrder> WSBuyOrder2 { get; set; }

	public virtual ICollection<WSDiscountCode> WSDiscountCode { get; set; }

	public virtual ICollection<WSDiscountCodeHistory> WSDiscountCodeHistory { get; set; }

	public virtual ICollection<WSPreOrder> WSPreOrder { get; set; }

	public virtual ICollection<WSPreOrderCommissions> WSPreOrderCommissions { get; set; }

	public virtual ICollection<WSPreOrderPrdGroupMustExistReasons> WSPreOrderPrdGroupMustExistReasons { get; set; }

	public virtual ICollection<WSProductsRate> WSProductsRate { get; set; }

	public virtual ICollection<WSStockSupply> WSStockSupply { get; set; }

	public virtual ICollection<WSOrderCommissions> WSOrderCommissions { get; set; }

	public virtual ICollection<WSOrderCommissions> WSOrderCommissions1 { get; set; }

	public virtual ICollection<WSOrder> WSOrder { get; set; }

	public virtual Centers Centers { get; set; }

	public virtual ICollection<WSProductShpException> WSProductShpException { get; set; }

	public virtual ICollection<SmsSendDetail> SmsSendDetail { get; set; }

	public virtual ICollection<WSProducts> WSProducts { get; set; }

	public virtual ICollection<WSDoc> WSDoc { get; set; }

	public virtual ICollection<Scores> Scores { get; set; }

	public virtual ICollection<CrmProjects> CrmProjects { get; set; }

	public virtual CrmCompanyQuickRegisterDefSetting CrmCompanyQuickRegisterDefSetting { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual Users Users2 { get; set; }

	public virtual Users Users3 { get; set; }

	public virtual Users Users4 { get; set; }

	public virtual Users Users5 { get; set; }

	public virtual Users Users6 { get; set; }

	public virtual Users Users7 { get; set; }

	public virtual Users Users8 { get; set; }

	public CrmCompany()
	{
		CrmBankingAccounts = (ICollection<CrmBankingAccounts>)new HashSet<CrmBankingAccounts>();
		CrmCallHistory = (ICollection<CrmCallHistory>)new HashSet<CrmCallHistory>();
		CrmCmsComments = (ICollection<CrmCmsComments>)new HashSet<CrmCmsComments>();
		CrmCmsLikes = (ICollection<CrmCmsLikes>)new HashSet<CrmCmsLikes>();
		CrmCompany_Lang = (ICollection<CrmCompany_Lang>)new HashSet<CrmCompany_Lang>();
		CrmCompanyAddresses = (ICollection<CrmCompanyAddresses>)new HashSet<CrmCompanyAddresses>();
		CrmCompanyForbiddenCompany = (ICollection<CrmCompanyForbiddenCompany>)new HashSet<CrmCompanyForbiddenCompany>();
		CrmCompanyJustAccessCompany = (ICollection<CrmCompanyJustAccessCompany>)new HashSet<CrmCompanyJustAccessCompany>();
		CrmCompanyLoGo = (ICollection<CrmCompanyLoGo>)new HashSet<CrmCompanyLoGo>();
		CrmCompanyMoneyBag = (ICollection<CrmCompanyMoneyBag>)new HashSet<CrmCompanyMoneyBag>();
		CrmCompanyMultiGroups = (ICollection<CrmCompanyMultiGroups>)new HashSet<CrmCompanyMultiGroups>();
		CrmCompanyPersons1 = (ICollection<CrmCompanyPersons>)new HashSet<CrmCompanyPersons>();
		CrmCompanyPictureAlbums = (ICollection<CrmCompanyPictureAlbums>)new HashSet<CrmCompanyPictureAlbums>();
		CrmCompanyUserForbidden = (ICollection<CrmCompanyUserForbidden>)new HashSet<CrmCompanyUserForbidden>();
		CrmConversation = (ICollection<CrmConversation>)new HashSet<CrmConversation>();
		CrmDyFormFieldMasterValues = (ICollection<CrmDyFormFieldMasterValues>)new HashSet<CrmDyFormFieldMasterValues>();
		CrmFilesDirectory = (ICollection<CrmFilesDirectory>)new HashSet<CrmFilesDirectory>();
		CrmInternalMessage = (ICollection<CrmInternalMessage>)new HashSet<CrmInternalMessage>();
		CrmLeave = (ICollection<CrmLeave>)new HashSet<CrmLeave>();
		CrmLinkedCompany = (ICollection<CrmLinkedCompany>)new HashSet<CrmLinkedCompany>();
		CrmLinkedCompany1 = (ICollection<CrmLinkedCompany>)new HashSet<CrmLinkedCompany>();
		CrmSurveyAnswerCategoryDetailValues = (ICollection<CrmSurveyAnswerCategoryDetailValues>)new HashSet<CrmSurveyAnswerCategoryDetailValues>();
		CrmSurveyAnswerValue = (ICollection<CrmSurveyAnswerValue>)new HashSet<CrmSurveyAnswerValue>();
		CrmSurveyHistory = (ICollection<CrmSurveyHistory>)new HashSet<CrmSurveyHistory>();
		CrmTelegBotContacts = (ICollection<CrmTelegBotContacts>)new HashSet<CrmTelegBotContacts>();
		CrmTelegContacts = (ICollection<CrmTelegContacts>)new HashSet<CrmTelegContacts>();
		CrmTempEmails = (ICollection<CrmTempEmails>)new HashSet<CrmTempEmails>();
		EmailReceive = (ICollection<EmailReceive>)new HashSet<EmailReceive>();
		EmailReceiveAttachments = (ICollection<EmailReceiveAttachments>)new HashSet<EmailReceiveAttachments>();
		EmailSendDetail = (ICollection<EmailSendDetail>)new HashSet<EmailSendDetail>();
		EmailUserTempTank = (ICollection<EmailUserTempTank>)new HashSet<EmailUserTempTank>();
		SecLetters = (ICollection<SecLetters>)new HashSet<SecLetters>();
		SmsReceive = (ICollection<SmsReceive>)new HashSet<SmsReceive>();
		SmsTempMobileNumbers = (ICollection<SmsTempMobileNumbers>)new HashSet<SmsTempMobileNumbers>();
		WSBuyOrder = (ICollection<WSBuyOrder>)new HashSet<WSBuyOrder>();
		WSBuyOrder1 = (ICollection<WSBuyOrder>)new HashSet<WSBuyOrder>();
		WSBuyOrder2 = (ICollection<WSBuyOrder>)new HashSet<WSBuyOrder>();
		WSDiscountCode = (ICollection<WSDiscountCode>)new HashSet<WSDiscountCode>();
		WSDiscountCodeHistory = (ICollection<WSDiscountCodeHistory>)new HashSet<WSDiscountCodeHistory>();
		WSPreOrder = (ICollection<WSPreOrder>)new HashSet<WSPreOrder>();
		WSPreOrderCommissions = (ICollection<WSPreOrderCommissions>)new HashSet<WSPreOrderCommissions>();
		WSPreOrderPrdGroupMustExistReasons = (ICollection<WSPreOrderPrdGroupMustExistReasons>)new HashSet<WSPreOrderPrdGroupMustExistReasons>();
		WSProductsRate = (ICollection<WSProductsRate>)new HashSet<WSProductsRate>();
		WSStockSupply = (ICollection<WSStockSupply>)new HashSet<WSStockSupply>();
		WSOrderCommissions = (ICollection<WSOrderCommissions>)new HashSet<WSOrderCommissions>();
		WSOrderCommissions1 = (ICollection<WSOrderCommissions>)new HashSet<WSOrderCommissions>();
		WSOrder = (ICollection<WSOrder>)new HashSet<WSOrder>();
		WSProductShpException = (ICollection<WSProductShpException>)new HashSet<WSProductShpException>();
		SmsSendDetail = (ICollection<SmsSendDetail>)new HashSet<SmsSendDetail>();
		WSProducts = (ICollection<WSProducts>)new HashSet<WSProducts>();
		WSDoc = (ICollection<WSDoc>)new HashSet<WSDoc>();
		Scores = (ICollection<Scores>)new HashSet<Scores>();
		CrmProjects = (ICollection<CrmProjects>)new HashSet<CrmProjects>();
	}
}
