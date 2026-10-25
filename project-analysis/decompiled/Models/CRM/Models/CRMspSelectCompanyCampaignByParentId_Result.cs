using System;

namespace CRM.Models;

public class CRMspSelectCompanyCampaignByParentId_Result
{
	public int CompanyCampaignId { get; set; }

	public int ParentId { get; set; }

	public string ParentName { get; set; }

	public string ParentPath { get; set; }

	public string CampaignName { get; set; }

	public string CampaignFullName { get; set; }

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

	public string FirstRegisterUser { get; set; }

	public string EditUser { get; set; }
}
