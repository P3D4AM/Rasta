using System;

namespace CRM.Models;

public class CrmCompanyLoGoMetadata
{
	public int CompanyLoGoID { get; set; }

	public int? CompanyId { get; set; }

	public byte[] CompanyLogo { get; set; }

	public string LogoDesc { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }
}
