using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmCallTypeMetadata))]
public class CrmCallType
{
	public int CallTypeID { get; set; }

	public string CallType { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? UserId { get; set; }

	public short? Year1 { get; set; }

	public short? Month1 { get; set; }

	public DateTime? RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public virtual ICollection<CrmCallHistory> CrmCallHistory { get; set; }

	public virtual ICollection<CrmCallType_Lang> CrmCallType_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual Users Users2 { get; set; }

	public CrmCallType()
	{
		CrmCallHistory = (ICollection<CrmCallHistory>)new HashSet<CrmCallHistory>();
		CrmCallType_Lang = (ICollection<CrmCallType_Lang>)new HashSet<CrmCallType_Lang>();
	}
}
