using System;

namespace CRM.Models;

public class CrmCompanyGroupsIIIMetadata
{
	public int CompanyGroupIIIID { get; set; }

	public string GroupIIIName { get; set; }

	public string GroupIIIDesc { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }
}
