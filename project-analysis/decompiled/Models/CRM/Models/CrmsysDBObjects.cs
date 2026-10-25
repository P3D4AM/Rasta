using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmsysDBObjectsMetadata))]
public class CrmsysDBObjects
{
	public int DBObjectId { get; set; }

	public string DBObjectName { get; set; }

	public string FieldName { get; set; }

	public string FieldTitle { get; set; }

	public bool? NotNull { get; set; }

	public int? OrderView { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public int? FieldDataTypeId { get; set; }

	public string FieldElementTypeWeb { get; set; }

	public string FieldRegEx { get; set; }

	public string FieldTitleCustom { get; set; }

	public string EventsJson { get; set; }

	public string AdditionalButtonsJson { get; set; }

	public string FieldDescription { get; set; }

	public bool? InActive { get; set; }

	public int? FieldClass { get; set; }

	public string FieldGroupBoxName { get; set; }

	public string FieldUsedType { get; set; }

	public bool? FieldFromTo { get; set; }

	public bool? FieldMulti { get; set; }

	public bool? DbNotNull { get; set; }

	public bool? VisibleLinkDyForm { get; set; }

	public string FieldNameRefs { get; set; }

	public virtual ICollection<CrmsysDBObjects_Lang> CrmsysDBObjects_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<CrmDyFormFields> CrmDyFormFields { get; set; }

	public virtual Users Users { get; set; }

	public CrmsysDBObjects()
	{
		CrmsysDBObjects_Lang = (ICollection<CrmsysDBObjects_Lang>)new HashSet<CrmsysDBObjects_Lang>();
		CrmDyFormFields = (ICollection<CrmDyFormFields>)new HashSet<CrmDyFormFields>();
	}
}
