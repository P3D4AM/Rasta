using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmKnowledgeTankGroupMetadata))]
public class CrmKnowledgeTankGroup
{
	public int KnowledgeTankGroupId { get; set; }

	public string KnowledgeTankGroupTitle { get; set; }

	public string KnowledgeTankGroupDesc { get; set; }

	public int? KnowledgeTankGroupOrderView { get; set; }

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

	public bool? KnowledgeTankGroupFOCmpCanSee { get; set; }

	public virtual ICollection<CrmKnowledgeTank> CrmKnowledgeTank { get; set; }

	public virtual ICollection<CrmKnowledgeTankGroup_Lang> CrmKnowledgeTankGroup_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<CrmKnowledgeTankGroupPermission> CrmKnowledgeTankGroupPermission { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual Users Users2 { get; set; }

	public CrmKnowledgeTankGroup()
	{
		CrmKnowledgeTank = (ICollection<CrmKnowledgeTank>)new HashSet<CrmKnowledgeTank>();
		CrmKnowledgeTankGroup_Lang = (ICollection<CrmKnowledgeTankGroup_Lang>)new HashSet<CrmKnowledgeTankGroup_Lang>();
		CrmKnowledgeTankGroupPermission = (ICollection<CrmKnowledgeTankGroupPermission>)new HashSet<CrmKnowledgeTankGroupPermission>();
	}
}
