using System;

namespace CRM.Models;

public class CRMspLkSepSelectCompanyFromSep_Result
{
	public int? PartyId { get; set; }

	public int? Type { get; set; }

	public string Name { get; set; }

	public string LastName { get; set; }

	public string FullName { get; set; }

	public string EconomicCode { get; set; }

	public string IdentificationCode { get; set; }

	public string RegistrationCode { get; set; }

	public string Website { get; set; }

	public string Email { get; set; }

	public int? DLRef { get; set; }

	public DateTime? BirthDate { get; set; }

	public DateTime? MarriageDate { get; set; }

	public DateTime? CreationDate { get; set; }

	public DateTime? LastModificationDate { get; set; }

	public string DLCode { get; set; }

	public string Phone { get; set; }

	public string Address { get; set; }

	public int? CompanyId { get; set; }

	public long? RowNumber { get; set; }

	public int? AllPage { get; set; }
}
