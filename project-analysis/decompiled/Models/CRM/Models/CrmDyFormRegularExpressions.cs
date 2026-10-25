using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmDyFormRegularExpressionsMetadata))]
public class CrmDyFormRegularExpressions
{
	public int FormRegularExpressionId { get; set; }

	public int FieldTypeId { get; set; }

	public string Title { get; set; }

	public string RegularExpression { get; set; }

	public string RegularExpressionOther { get; set; }

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

	public virtual CrmDyFormFieldTypes CrmDyFormFieldTypes { get; set; }

	public virtual ICollection<CrmDyFormRegularExpressions_Lang> CrmDyFormRegularExpressions_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<CrmDyFormFields> CrmDyFormFields { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public CrmDyFormRegularExpressions()
	{
		CrmDyFormRegularExpressions_Lang = (ICollection<CrmDyFormRegularExpressions_Lang>)new HashSet<CrmDyFormRegularExpressions_Lang>();
		CrmDyFormFields = (ICollection<CrmDyFormFields>)new HashSet<CrmDyFormFields>();
	}
}
