using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmProjectsMetadata))]
public class CrmProjects
{
	public int ProjectID { get; set; }

	public int prjCompanyId { get; set; }

	public string prjTitle { get; set; }

	public string prjDesc { get; set; }

	public string prjStartDate { get; set; }

	public string prjStartDay { get; set; }

	public string prjStartTime { get; set; }

	public DateTime? prjStartDateTime { get; set; }

	public int? prjStarterUserId { get; set; }

	public int? prjFinishedStatusId { get; set; }

	public bool? prjIsFinished { get; set; }

	public string prjFinishedDate { get; set; }

	public string prjFinishedDay { get; set; }

	public string prjFinishedTime { get; set; }

	public DateTime? prjFinishedDateTime { get; set; }

	public int? prjFinishedUserId { get; set; }

	public int? prjGradeId { get; set; }

	public int? prjPriorityId { get; set; }

	public string prjFirstRegisterDate { get; set; }

	public int prjFirstRegisterUserId { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public int? prjGroupId { get; set; }

	public int? prjcnvsStatusGroupId { get; set; }

	public int? prjOrderView { get; set; }

	public string AppType { get; set; }

	public string prjPostFix { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public DateTime? FirstRegisterDateTime { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? prjFirstRegisterDateTime { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public string prjRemindDate { get; set; }

	public DateTime? prjRemindDateTime { get; set; }

	public bool? prjFOCmpCanSee { get; set; }

	public bool? prjIsTicket { get; set; }

	public int? prjUserDepartmentId { get; set; }

	public bool? prjHaveSms { get; set; }

	public string prjSmsPrsIds { get; set; }

	public string prjSmsText { get; set; }

	public DateTime? prjSmsSendDate { get; set; }

	public string prjSmsSendDatePersian { get; set; }

	public string prjInquiryNum { get; set; }

	public string prjSubject { get; set; }

	public string prjTitleGroup { get; set; }

	public int? prjCategoryId { get; set; }

	public string prjDescI { get; set; }

	public string prjNumRef { get; set; }

	public long? prjNumR { get; set; }

	public DateTime? prjToDoTime { get; set; }

	public DateTime? prjToDoTimeRegister { get; set; }

	public DateTime? prjToDoTimeDone { get; set; }

	public bool? prjFOCmpCanInsCnvs { get; set; }

	public bool? prjFOCmpCanNotInsCnvs { get; set; }

	public bool? prjTicketStop { get; set; }

	public bool? prjIsTicketNew { get; set; }

	public long? prjToDoTimeSec { get; set; }

	public DateTime? prjReadDate { get; set; }

	public int? prjReadUserId { get; set; }

	public long? prjReadDuration { get; set; }

	public DateTime? prjResponseDate { get; set; }

	public int? prjResponseUserId { get; set; }

	public long? prjResponseDuration { get; set; }

	public DateTime? prjFirstDoingDate { get; set; }

	public int? prjFirstDoingUserId { get; set; }

	public long? prjFirstDoingDuration { get; set; }

	public long? prjFinishedDuration { get; set; }

	public string prjToDoTimeRegisterHistory { get; set; }

	public int? prjTicketStopUserId { get; set; }

	public DateTime? prjTicketStopRegisterDate { get; set; }

	public string prjTicketStopRegisterDatePersian { get; set; }

	public int? prjcmpPresentationId { get; set; }

	public string prjcmpCampaignIds { get; set; }

	public int? prjcmpQuickRegisterDefSettingId { get; set; }

	public int? prjValidityPrdId { get; set; }

	public int? prjValidityOrdItemId { get; set; }

	public int? prjCId { get; set; }

	public virtual Centers Centers { get; set; }

	public virtual CrmCompany CrmCompany { get; set; }

	public virtual CrmCompanyPresentation CrmCompanyPresentation { get; set; }

	public virtual ICollection<CrmConversation> CrmConversation { get; set; }

	public virtual CrmConversationStatus CrmConversationStatus { get; set; }

	public virtual CrmConversationStatusGroups CrmConversationStatusGroups { get; set; }

	public virtual ICollection<CrmDyFormFieldMasterValues> CrmDyFormFieldMasterValues { get; set; }

	public virtual ICollection<CrmFilesDirectory> CrmFilesDirectory { get; set; }

	public virtual ICollection<CrmInternalMessage> CrmInternalMessage { get; set; }

	public virtual ICollection<CrmLeave> CrmLeave { get; set; }

	public virtual CrmProjectCategory CrmProjectCategory { get; set; }

	public virtual ICollection<CrmProjectFieldTitle> CrmProjectFieldTitle { get; set; }

	public virtual CrmProjectGrade CrmProjectGrade { get; set; }

	public virtual CrmProjectGroups CrmProjectGroups { get; set; }

	public virtual ICollection<CrmProjectInformations> CrmProjectInformations { get; set; }

	public virtual CrmProjectPriority CrmProjectPriority { get; set; }

	public virtual ICollection<CrmProjects_Lang> CrmProjects_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSOrderItems WSOrderItems { get; set; }

	public virtual WSProducts WSProducts { get; set; }

	public virtual UserDepartments UserDepartments { get; set; }

	public virtual ICollection<EmailReceive> EmailReceive { get; set; }

	public virtual ICollection<EmailReceiveAttachments> EmailReceiveAttachments { get; set; }

	public virtual ICollection<EmailSendDetail> EmailSendDetail { get; set; }

	public virtual ICollection<EmailUserTempTank> EmailUserTempTank { get; set; }

	public virtual ICollection<SecLetters> SecLetters { get; set; }

	public virtual ICollection<WSBuyOrder> WSBuyOrder { get; set; }

	public virtual ICollection<WSBuyOrder> WSBuyOrder1 { get; set; }

	public virtual ICollection<WSBuyOrder> WSBuyOrder2 { get; set; }

	public virtual ICollection<WSCostSheetProducts> WSCostSheetProducts { get; set; }

	public virtual ICollection<WSCostSheets> WSCostSheets { get; set; }

	public virtual ICollection<WSDoc> WSDoc { get; set; }

	public virtual ICollection<WSOrder> WSOrder { get; set; }

	public virtual ICollection<WSPreOrder> WSPreOrder { get; set; }

	public virtual ICollection<WSPreOrderPrdGroupMustExistReasons> WSPreOrderPrdGroupMustExistReasons { get; set; }

	public virtual ICollection<WSStockSupply> WSStockSupply { get; set; }

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

	public virtual Users Users9 { get; set; }

	public CrmProjects()
	{
		CrmConversation = (ICollection<CrmConversation>)new HashSet<CrmConversation>();
		CrmDyFormFieldMasterValues = (ICollection<CrmDyFormFieldMasterValues>)new HashSet<CrmDyFormFieldMasterValues>();
		CrmFilesDirectory = (ICollection<CrmFilesDirectory>)new HashSet<CrmFilesDirectory>();
		CrmInternalMessage = (ICollection<CrmInternalMessage>)new HashSet<CrmInternalMessage>();
		CrmLeave = (ICollection<CrmLeave>)new HashSet<CrmLeave>();
		CrmProjectFieldTitle = (ICollection<CrmProjectFieldTitle>)new HashSet<CrmProjectFieldTitle>();
		CrmProjectInformations = (ICollection<CrmProjectInformations>)new HashSet<CrmProjectInformations>();
		CrmProjects_Lang = (ICollection<CrmProjects_Lang>)new HashSet<CrmProjects_Lang>();
		EmailReceive = (ICollection<EmailReceive>)new HashSet<EmailReceive>();
		EmailReceiveAttachments = (ICollection<EmailReceiveAttachments>)new HashSet<EmailReceiveAttachments>();
		EmailSendDetail = (ICollection<EmailSendDetail>)new HashSet<EmailSendDetail>();
		EmailUserTempTank = (ICollection<EmailUserTempTank>)new HashSet<EmailUserTempTank>();
		SecLetters = (ICollection<SecLetters>)new HashSet<SecLetters>();
		WSBuyOrder = (ICollection<WSBuyOrder>)new HashSet<WSBuyOrder>();
		WSBuyOrder1 = (ICollection<WSBuyOrder>)new HashSet<WSBuyOrder>();
		WSBuyOrder2 = (ICollection<WSBuyOrder>)new HashSet<WSBuyOrder>();
		WSCostSheetProducts = (ICollection<WSCostSheetProducts>)new HashSet<WSCostSheetProducts>();
		WSCostSheets = (ICollection<WSCostSheets>)new HashSet<WSCostSheets>();
		WSDoc = (ICollection<WSDoc>)new HashSet<WSDoc>();
		WSOrder = (ICollection<WSOrder>)new HashSet<WSOrder>();
		WSPreOrder = (ICollection<WSPreOrder>)new HashSet<WSPreOrder>();
		WSPreOrderPrdGroupMustExistReasons = (ICollection<WSPreOrderPrdGroupMustExistReasons>)new HashSet<WSPreOrderPrdGroupMustExistReasons>();
		WSStockSupply = (ICollection<WSStockSupply>)new HashSet<WSStockSupply>();
	}
}
