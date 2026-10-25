using System;

namespace CRM.Models;

public class CRMspSelectCrmCompanySubGroups_Result
{
	public int CompanySubGroupID { get; set; }

	public int GroupId { get; set; }

	public string SubGroupName { get; set; }

	public string SubGroupDesc { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? OrderView { get; set; }

	public int? LanguageID { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }
}
