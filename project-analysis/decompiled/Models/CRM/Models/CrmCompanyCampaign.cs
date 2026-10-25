using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmCompanyCampaignMetadata))]
public class CrmCompanyCampaign
{
	public int CompanyCampaignId { get; set; }

	public int ParentId { get; set; }

	public string ParentPath { get; set; }

	public string CampaignName { get; set; }

	public int? CampaignDepth { get; set; }

	public bool? CampaignIsLeaf { get; set; }

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

	public virtual ICollection<CrmCompanyCampaign_Lang> CrmCompanyCampaign_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public CrmCompanyCampaign()
	{
		CrmCompanyCampaign_Lang = (ICollection<CrmCompanyCampaign_Lang>)new HashSet<CrmCompanyCampaign_Lang>();
	}
}
