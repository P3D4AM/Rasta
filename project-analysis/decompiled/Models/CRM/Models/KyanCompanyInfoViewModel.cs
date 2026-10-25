using System;

namespace CRM.Models;

public class KyanCompanyInfoViewModel
{
	public int customerID { get; set; }

	public string MemberID { get; set; }

	public string customerFirstName { get; set; }

	public string customerLastName { get; set; }

	public string SocialSecurityNumber { get; set; }

	public string Phone { get; set; }

	public int? Gender { get; set; }

	public string BirthDayDate { get; set; }

	public string Email { get; set; }

	public int? GroupID { get; set; }

	public string GroupName { get; set; }

	public decimal? Point { get; set; }

	public string Address { get; set; }

	public string Note { get; set; }

	public decimal? Credit { get; set; }

	public DateTime? BirthDate_DateTime { get; set; }

	public string BirthDate_Persian { get; set; }

	public long RowNumber { get; set; }

	public int CompanyId { get; set; }
}
