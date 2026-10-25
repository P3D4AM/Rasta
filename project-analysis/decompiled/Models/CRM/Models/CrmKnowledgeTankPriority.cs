using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmKnowledgeTankPriorityMetadata))]
public class CrmKnowledgeTankPriority
{
	public int KnowledgeTankPriorityId { get; set; }

	public string KnowledgeTankPriorityTitle { get; set; }

	public string KnowledgeTankPriorityDesc { get; set; }

	public int? KnowledgeTankPriorityOrderView { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int FirstRegisterUserId { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public virtual ICollection<CrmKnowledgeTank> CrmKnowledgeTank { get; set; }

	public virtual ICollection<CrmKnowledgeTankPriority_Lang> CrmKnowledgeTankPriority_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual Users Users2 { get; set; }

	public CrmKnowledgeTankPriority()
	{
		CrmKnowledgeTank = (ICollection<CrmKnowledgeTank>)new HashSet<CrmKnowledgeTank>();
		CrmKnowledgeTankPriority_Lang = (ICollection<CrmKnowledgeTankPriority_Lang>)new HashSet<CrmKnowledgeTankPriority_Lang>();
	}
}
