using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmCmsNewsGroupsMetadata))]
public class CrmCmsNewsGroups
{
	public int NewsGroupId { get; set; }

	public string GroupName { get; set; }

	public bool? IsActive { get; set; }

	public int? OrderView { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }

	public virtual ICollection<CrmCmsNews> CrmCmsNews { get; set; }

	public virtual ICollection<CrmCmsNewsGroups_Lang> CrmCmsNewsGroups_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public CrmCmsNewsGroups()
	{
		CrmCmsNews = (ICollection<CrmCmsNews>)new HashSet<CrmCmsNews>();
		CrmCmsNewsGroups_Lang = (ICollection<CrmCmsNewsGroups_Lang>)new HashSet<CrmCmsNewsGroups_Lang>();
	}
}
