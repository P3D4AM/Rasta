using System;

namespace CRM.Models;

public class CrmspSelectLinkedCompany_Result
{
	public string CompanyTitle { get; set; }

	public string RegUser { get; set; }

	public int CompanyId { get; set; }

	public int LinkedCompanyId { get; set; }

	public int? CompanyIdForLoad { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public string AppType { get; set; }
}
