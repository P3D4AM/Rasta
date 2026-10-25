using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmDyFormFieldValuesMetadata))]
public class CrmDyFormFieldValues
{
	public int FormFieldValueId { get; set; }

	public int FormId { get; set; }

	public int? FieldId { get; set; }

	public string Value { get; set; }

	public bool? IsDeleted { get; set; }

	public int? CompanyId { get; set; }

	public int? CompanyPersonId { get; set; }

	public int? ProjectId { get; set; }

	public int? ConversationId { get; set; }

	public int? MasterObjectId { get; set; }

	public int? DetailObjectId { get; set; }

	public int? SubDetailObjectId { get; set; }

	public int MasterValueId { get; set; }

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

	public int? CId { get; set; }

	public string ChangeHistory { get; set; }

	public int? DeletedUserId { get; set; }

	public DateTime? DeletedDate { get; set; }

	public string DeletedDatePersian { get; set; }

	public virtual CrmCompanyPersons CrmCompanyPersons { get; set; }

	public virtual CrmConversation CrmConversation { get; set; }

	public virtual CrmDyFormFieldMasterValues CrmDyFormFieldMasterValues { get; set; }

	public virtual CrmDyForms CrmDyForms { get; set; }

	public virtual ICollection<CrmDyFormFieldValues_Lang> CrmDyFormFieldValues_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual Centers Centers { get; set; }

	public virtual Users Users { get; set; }

	public CrmDyFormFieldValues()
	{
		CrmDyFormFieldValues_Lang = (ICollection<CrmDyFormFieldValues_Lang>)new HashSet<CrmDyFormFieldValues_Lang>();
	}
}
