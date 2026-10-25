using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmInternalMessageGroupMetadata))]
public class CrmInternalMessageGroup
{
	public int InternalMessageGroupID { get; set; }

	public string InternalMessageGroup { get; set; }

	public int? InternalMessageGroupOrder { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public virtual ICollection<CrmInternalMessageDetails> CrmInternalMessageDetails { get; set; }

	public virtual ICollection<CrmInternalMessageGroup_Lang> CrmInternalMessageGroup_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual Users Users2 { get; set; }

	public CrmInternalMessageGroup()
	{
		CrmInternalMessageDetails = (ICollection<CrmInternalMessageDetails>)new HashSet<CrmInternalMessageDetails>();
		CrmInternalMessageGroup_Lang = (ICollection<CrmInternalMessageGroup_Lang>)new HashSet<CrmInternalMessageGroup_Lang>();
	}
}
