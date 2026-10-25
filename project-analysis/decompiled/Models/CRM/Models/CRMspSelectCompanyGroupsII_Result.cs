using System;

namespace CRM.Models;

public class CRMspSelectCompanyGroupsII_Result
{
	public int CompanyGroupIIID { get; set; }

	public string GroupIIName { get; set; }

	public string GroupIIDesc { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? OrderView { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public string FirstRegisterUser { get; set; }

	public string EditUser { get; set; }

	public double? Rate { get; set; }

	public string LinkAccCmpGroupIIIdStr { get; set; }

	public double? ScoreRate { get; set; }
}
