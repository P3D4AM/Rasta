using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmDyFormFieldTypesMetadata))]
public class CrmDyFormFieldTypes
{
	public int FormFieldTypeId { get; set; }

	public string TypeName { get; set; }

	public string TypeInWeb { get; set; }

	public string TypeInWindows { get; set; }

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

	public virtual ICollection<CrmDyFormFieldTypes_Lang> CrmDyFormFieldTypes_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<CrmDyFormRegularExpressions> CrmDyFormRegularExpressions { get; set; }

	public virtual ICollection<CrmDyFormFields> CrmDyFormFields { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public CrmDyFormFieldTypes()
	{
		CrmDyFormFieldTypes_Lang = (ICollection<CrmDyFormFieldTypes_Lang>)new HashSet<CrmDyFormFieldTypes_Lang>();
		CrmDyFormRegularExpressions = (ICollection<CrmDyFormRegularExpressions>)new HashSet<CrmDyFormRegularExpressions>();
		CrmDyFormFields = (ICollection<CrmDyFormFields>)new HashSet<CrmDyFormFields>();
	}
}
