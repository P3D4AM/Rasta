namespace CRM.Models;

public class CRMspDySelectCompanySubGroup_Result
{
	public int CompanySubGroupID { get; set; }

	public int GroupId { get; set; }

	public string GroupName { get; set; }

	public string SubGroupName { get; set; }

	public string SubGroupDesc { get; set; }

	public double? ScoreRate { get; set; }
}
