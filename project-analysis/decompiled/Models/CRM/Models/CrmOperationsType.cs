using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmOperationsTypeMetadata))]
public class CrmOperationsType
{
	public int OperationsTypeID { get; set; }

	public string Type { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public virtual ICollection<CrmOperationsType_Lang> CrmOperationsType_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public CrmOperationsType()
	{
		CrmOperationsType_Lang = (ICollection<CrmOperationsType_Lang>)new HashSet<CrmOperationsType_Lang>();
	}
}
