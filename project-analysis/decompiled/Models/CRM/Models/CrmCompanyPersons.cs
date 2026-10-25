using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmCompanyPersonsMetadata))]
public class CrmCompanyPersons
{
	public int CompanyPersonID { get; set; }

	public int prsCompanyId { get; set; }

	public string prsLName { get; set; }

	public string prsFName { get; set; }

	public int? prsTitleId { get; set; }

	public int? prsJobId { get; set; }

	public int? prsTypeId { get; set; }

	public int? prsGroupId { get; set; }

	public int? prsSexId { get; set; }

	public int? prsEducationId { get; set; }

	public string prsPreTel { get; set; }

	public string prsTel { get; set; }

	public string prsTelUpTo { get; set; }

	public string prsTelDesc { get; set; }

	public string prsTelII { get; set; }

	public string prsFax { get; set; }

	public string prsFaxDesc { get; set; }

	public string prsMobile { get; set; }

	public string prsWebSite { get; set; }

	public string prsEmail { get; set; }

	public string prsEmailII { get; set; }

	public int? prsCountryId { get; set; }

	public int? prsProvinceId { get; set; }

	public int? prsCityId { get; set; }

	public string prsAddress { get; set; }

	public string prsAddressDesc { get; set; }

	public string prsZipCode { get; set; }

	public string prsPostBox { get; set; }

	public string prsNationalCode { get; set; }

	public string prsIdentityNumber { get; set; }

	public string prsFatherName { get; set; }

	public string prsBirthDate { get; set; }

	public string prsBirthPlace { get; set; }

	public bool? prsIsMarried { get; set; }

	public string prsMarriageDate { get; set; }

	public string prsEducationField { get; set; }

	public string prsSkill { get; set; }

	public string prsStudyField { get; set; }

	public string prsInteresting { get; set; }

	public string prsSpecialPoint { get; set; }

	public string prsDescription { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public int AddType { get; set; }

	public string ImportDate { get; set; }

	public int? prsFirstRegisterUserId { get; set; }

	public int? prsDepartmentId { get; set; }

	public bool? prsStopSendSms { get; set; }

	public int? prsOrderView { get; set; }

	public bool? prsWorkingOut { get; set; }

	public Guid? GUId { get; set; }

	public int? CompanyPersonTemplateID { get; set; }

	public string AppType { get; set; }

	public DateTime? prsBirthDateTime { get; set; }

	public DateTime? prsMarriageDateTime { get; set; }

	public DateTime? ImportDateTime { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int? prsTelegramId { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public string prsCoordinateLatitude { get; set; }

	public string prsCoordinateLongitude { get; set; }

	public DateTime? prsCoordinateLastDate { get; set; }

	public string prsCoordinateLastDatePersian { get; set; }

	public int? prsCoordinateZoomLevel { get; set; }

	public int? prsCoordinateLastUserId { get; set; }

	public string prsUserName { get; set; }

	public string prsPassword { get; set; }

	public bool? prsFOIsActive { get; set; }

	public DateTime? prsFOActiveDate { get; set; }

	public int? prsFOActiveUserId { get; set; }

	public DateTime? prsFOLoginExpireDate { get; set; }

	public int? prsFOLoginExpireUserId { get; set; }

	public string prsCIds { get; set; }

	public string prsFOInfo { get; set; }

	public int? prsLastCId { get; set; }

	public virtual City City { get; set; }

	public virtual Country Country { get; set; }

	public virtual ICollection<CrmCallHistory> CrmCallHistory { get; set; }

	public virtual CrmCompanyPersonsTemplate CrmCompanyPersonsTemplate { get; set; }

	public virtual CrmPersonDepartments CrmPersonDepartments { get; set; }

	public virtual CrmPersonGroups CrmPersonGroups { get; set; }

	public virtual CrmPersonJobs CrmPersonJobs { get; set; }

	public virtual CrmPersonTitle CrmPersonTitle { get; set; }

	public virtual CrmPersonType CrmPersonType { get; set; }

	public virtual Education Education { get; set; }

	public virtual ICollection<CrmCompanyPersons_Lang> CrmCompanyPersons_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual Province Province { get; set; }

	public virtual Sex Sex { get; set; }

	public virtual ICollection<CrmConversation> CrmConversation { get; set; }

	public virtual ICollection<CrmDyFormFieldMasterValues> CrmDyFormFieldMasterValues { get; set; }

	public virtual ICollection<CrmDyFormFieldValues> CrmDyFormFieldValues { get; set; }

	public virtual ICollection<CrmPersonPicture> CrmPersonPicture { get; set; }

	public virtual ICollection<CrmSurveyHistory> CrmSurveyHistory { get; set; }

	public virtual ICollection<CrmTelegBotContacts> CrmTelegBotContacts { get; set; }

	public virtual ICollection<CrmTelegContacts> CrmTelegContacts { get; set; }

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

	public virtual ICollection<CrmTempEmails> CrmTempEmails { get; set; }

	public virtual ICollection<CrmBankingAccounts> CrmBankingAccounts { get; set; }

	public virtual ICollection<WSPreOrder> WSPreOrder { get; set; }

	public virtual ICollection<CrmCompany> CrmCompany { get; set; }

	public virtual CrmCompany CrmCompany1 { get; set; }

	public virtual ICollection<WSStockSupply> WSStockSupply { get; set; }

	public virtual ICollection<WSOrderCommissions> WSOrderCommissions { get; set; }

	public virtual ICollection<WSOrder> WSOrder { get; set; }

	public virtual Centers Centers { get; set; }

	public virtual ICollection<SmsSendDetail> SmsSendDetail { get; set; }

	public virtual ICollection<WSDoc> WSDoc { get; set; }

	public virtual ICollection<CrmLeave> CrmLeave { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual Users Users2 { get; set; }

	public virtual Users Users3 { get; set; }

	public virtual Users Users4 { get; set; }

	public virtual Users Users5 { get; set; }

	public virtual Users Users6 { get; set; }

	public CrmCompanyPersons()
	{
		CrmCallHistory = (ICollection<CrmCallHistory>)new HashSet<CrmCallHistory>();
		CrmCompanyPersons_Lang = (ICollection<CrmCompanyPersons_Lang>)new HashSet<CrmCompanyPersons_Lang>();
		CrmConversation = (ICollection<CrmConversation>)new HashSet<CrmConversation>();
		CrmDyFormFieldMasterValues = (ICollection<CrmDyFormFieldMasterValues>)new HashSet<CrmDyFormFieldMasterValues>();
		CrmDyFormFieldValues = (ICollection<CrmDyFormFieldValues>)new HashSet<CrmDyFormFieldValues>();
		CrmPersonPicture = (ICollection<CrmPersonPicture>)new HashSet<CrmPersonPicture>();
		CrmSurveyHistory = (ICollection<CrmSurveyHistory>)new HashSet<CrmSurveyHistory>();
		CrmTelegBotContacts = (ICollection<CrmTelegBotContacts>)new HashSet<CrmTelegBotContacts>();
		CrmTelegContacts = (ICollection<CrmTelegContacts>)new HashSet<CrmTelegContacts>();
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
		CrmTempEmails = (ICollection<CrmTempEmails>)new HashSet<CrmTempEmails>();
		CrmBankingAccounts = (ICollection<CrmBankingAccounts>)new HashSet<CrmBankingAccounts>();
		WSPreOrder = (ICollection<WSPreOrder>)new HashSet<WSPreOrder>();
		CrmCompany = (ICollection<CrmCompany>)new HashSet<CrmCompany>();
		WSStockSupply = (ICollection<WSStockSupply>)new HashSet<WSStockSupply>();
		WSOrderCommissions = (ICollection<WSOrderCommissions>)new HashSet<WSOrderCommissions>();
		WSOrder = (ICollection<WSOrder>)new HashSet<WSOrder>();
		SmsSendDetail = (ICollection<SmsSendDetail>)new HashSet<SmsSendDetail>();
		WSDoc = (ICollection<WSDoc>)new HashSet<WSDoc>();
		CrmLeave = (ICollection<CrmLeave>)new HashSet<CrmLeave>();
	}
}
