using System;

namespace CRM.Models;

public class CrmCompanyGroupsIIMetadata
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
}
