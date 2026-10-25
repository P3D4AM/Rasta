using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmDyFormsMetadata))]
public class CrmDyForms
{
	public int FormId { get; set; }

	public string FormName { get; set; }

	public string FormTitle { get; set; }

	public string FormTitleColor { get; set; }

	public string FormBgColor { get; set; }

	public string FormHeader { get; set; }

	public string FormBody { get; set; }

	public string FormFooter { get; set; }

	public bool? HaveUploadFile { get; set; }

	public string UploadFileDescription { get; set; }

	public int? UploadFileCount { get; set; }

	public int? UploadFileMaxSize { get; set; }

	public int? ColumnCount { get; set; }

	public bool? IsActive { get; set; }

	public int? OrderView { get; set; }

	public int? ParentFormId { get; set; }

	public int? CrmSysPartId { get; set; }

	public int? FOSysPartId { get; set; }

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

	public string UploadFileExtension { get; set; }

	public int? PrintFormatId { get; set; }

	public bool? FOIsVisible { get; set; }

	public bool? FOIsEnable { get; set; }

	public bool? FOCanInsertMulti { get; set; }

	public string EnableForUsersId { get; set; }

	public int? EnableForRollId { get; set; }

	public string CheckerUsersId { get; set; }

	public int? WorkflowId { get; set; }

	public string CrmSysPartShow { get; set; }

	public string FOSysPartShow { get; set; }

	public bool? SetSysPartFieldByUser { get; set; }

	public bool? EnableForResponsibleUserChecker { get; set; }

	public int? VerificationWorkFlowId { get; set; }

	public int? CheckerRollId { get; set; }

	public string FormCIds { get; set; }

	public string FormCenterInfoJs { get; set; }

	public virtual ICollection<CrmCmsMenus> CrmCmsMenus { get; set; }

	public virtual ICollection<CrmCmsPages> CrmCmsPages { get; set; }

	public virtual ICollection<CrmDyFormFieldMasterValueDetails> CrmDyFormFieldMasterValueDetails { get; set; }

	public virtual ICollection<CrmDyFormFieldMasterValues> CrmDyFormFieldMasterValues { get; set; }

	public virtual ICollection<CrmDyFormFieldValues> CrmDyFormFieldValues { get; set; }

	public virtual CrmDyFormWorkflows CrmDyFormWorkflows { get; set; }

	public virtual CrmsysRolls CrmsysRolls { get; set; }

	public virtual CrmSystemParts CrmSystemParts { get; set; }

	public virtual CrmSystemParts CrmSystemParts1 { get; set; }

	public virtual ICollection<CrmDyForms_Lang> CrmDyForms_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual PrintFormat PrintFormat { get; set; }

	public virtual ICollection<CrmDyFormUserAccess> CrmDyFormUserAccess { get; set; }

	public virtual ICollection<CrmDyFormWorkflows> CrmDyFormWorkflows1 { get; set; }

	public virtual ICollection<CrmDyFormWorkflowSteps> CrmDyFormWorkflowSteps { get; set; }

	public virtual ICollection<CrmDyFormFields> CrmDyFormFields { get; set; }

	public virtual WSVerificationWorkFlows WSVerificationWorkFlows { get; set; }

	public virtual ICollection<CrmFoSetting> CrmFoSetting { get; set; }

	public virtual CrmsysRolls CrmsysRolls1 { get; set; }

	public virtual ICollection<CrmConversationStatusResult> CrmConversationStatusResult { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public CrmDyForms()
	{
		CrmCmsMenus = (ICollection<CrmCmsMenus>)new HashSet<CrmCmsMenus>();
		CrmCmsPages = (ICollection<CrmCmsPages>)new HashSet<CrmCmsPages>();
		CrmDyFormFieldMasterValueDetails = (ICollection<CrmDyFormFieldMasterValueDetails>)new HashSet<CrmDyFormFieldMasterValueDetails>();
		CrmDyFormFieldMasterValues = (ICollection<CrmDyFormFieldMasterValues>)new HashSet<CrmDyFormFieldMasterValues>();
		CrmDyFormFieldValues = (ICollection<CrmDyFormFieldValues>)new HashSet<CrmDyFormFieldValues>();
		CrmDyForms_Lang = (ICollection<CrmDyForms_Lang>)new HashSet<CrmDyForms_Lang>();
		CrmDyFormUserAccess = (ICollection<CrmDyFormUserAccess>)new HashSet<CrmDyFormUserAccess>();
		CrmDyFormWorkflows1 = (ICollection<CrmDyFormWorkflows>)new HashSet<CrmDyFormWorkflows>();
		CrmDyFormWorkflowSteps = (ICollection<CrmDyFormWorkflowSteps>)new HashSet<CrmDyFormWorkflowSteps>();
		CrmDyFormFields = (ICollection<CrmDyFormFields>)new HashSet<CrmDyFormFields>();
		CrmFoSetting = (ICollection<CrmFoSetting>)new HashSet<CrmFoSetting>();
		CrmConversationStatusResult = (ICollection<CrmConversationStatusResult>)new HashSet<CrmConversationStatusResult>();
	}
}
