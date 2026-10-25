using System;

namespace CRM.Models;

public class CRMspCmsSelectLikes_Result
{
	public int LikeId { get; set; }

	public int ObjectTypeId { get; set; }

	public int ObjectId { get; set; }

	public int Value { get; set; }

	public int? CrmCompanyId { get; set; }

	public string CrmCompany { get; set; }

	public string IPAddress { get; set; }

	public int FirstRegisterUserId { get; set; }

	public string FirstRegisterUser { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public string EditUser { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }

	public string CrmCompanyPersons { get; set; }
}
