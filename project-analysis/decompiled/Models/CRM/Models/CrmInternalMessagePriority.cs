using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmInternalMessagePriorityMetadata))]
public class CrmInternalMessagePriority
{
	public int InternalMessagePriorityID { get; set; }

	public string InternalMessagePriority { get; set; }

	public int? UserId { get; set; }

	public short? Year1 { get; set; }

	public short? Month1 { get; set; }

	public DateTime? RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public string AppType { get; set; }

	public Guid? GUId { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public virtual ICollection<CrmInternalMessagePriority_Lang> CrmInternalMessagePriority_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual Users Users2 { get; set; }

	public CrmInternalMessagePriority()
	{
		CrmInternalMessagePriority_Lang = (ICollection<CrmInternalMessagePriority_Lang>)new HashSet<CrmInternalMessagePriority_Lang>();
	}
}
