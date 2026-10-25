using System;

namespace CRM.Models;

public class CRMspSelectCompanyJustAccessCityForUser_Result
{
	public int ID { get; set; }

	public int CrmUserId { get; set; }

	public int JustAccessCityId { get; set; }

	public string JustAccessCityName { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public int? CId { get; set; }
}
