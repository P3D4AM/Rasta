using System;

namespace CRM.Models;

public class CRMspSelectCompanyJustAccessGroupForUser_Result
{
	public int ID { get; set; }

	public int CrmUserId { get; set; }

	public int JustAccessGroupId { get; set; }

	public string JustAccessGroupName { get; set; }

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
