using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmDyFormFieldMasterValuesMetadata))]
public class CrmDyFormFieldMasterValues
{
	public int FormFieldMasterValueId { get; set; }

	public int FormId { get; set; }

	public int? CompanyId { get; set; }

	public int? CompanyPersonId { get; set; }

	public int? ProjectId { get; set; }

	public int? ConversationId { get; set; }

	public int? MasterObjectId { get; set; }

	public int? DetailObjectId { get; set; }

	public int? SubDetailObjectId { get; set; }

	public bool? IsDeleted { get; set; }

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

	public bool? IsChecked { get; set; }

	public int? CheckerUserId { get; set; }

	public DateTime? CheckedDate { get; set; }

	public string CheckedDatePersian { get; set; }

	public int? WorkflowId { get; set; }

	public int? WorkflowStepId { get; set; }

	public long? DyFormNumber { get; set; }

	public int? VerificationWorkFlowId { get; set; }

	public int? TableVersion { get; set; }

	public bool? IsFixed { get; set; }

	public string EditAfterFixInfoJs { get; set; }

	public int? CId { get; set; }

	public int? DeletedUserId { get; set; }

	public DateTime? DeletedDate { get; set; }

	public string DeletedDatePersian { get; set; }

	public virtual CrmCompanyPersons CrmCompanyPersons { get; set; }

	public virtual CrmConversation CrmConversation { get; set; }

	public virtual ICollection<CrmDyFormFieldMasterValueDetails> CrmDyFormFieldMasterValueDetails { get; set; }

	public virtual CrmDyForms CrmDyForms { get; set; }

	public virtual CrmDyFormWorkflows CrmDyFormWorkflows { get; set; }

	public virtual CrmDyFormWorkflowSteps CrmDyFormWorkflowSteps { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<CrmDyFormFieldValues> CrmDyFormFieldValues { get; set; }

	public virtual WSVerificationWorkFlows WSVerificationWorkFlows { get; set; }

	public virtual CrmCompany CrmCompany { get; set; }

	public virtual Centers Centers { get; set; }

	public virtual CrmProjects CrmProjects { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual Users Users2 { get; set; }

	public virtual Users Users3 { get; set; }

	public CrmDyFormFieldMasterValues()
	{
		CrmDyFormFieldMasterValueDetails = (ICollection<CrmDyFormFieldMasterValueDetails>)new HashSet<CrmDyFormFieldMasterValueDetails>();
		CrmDyFormFieldValues = (ICollection<CrmDyFormFieldValues>)new HashSet<CrmDyFormFieldValues>();
	}
}
