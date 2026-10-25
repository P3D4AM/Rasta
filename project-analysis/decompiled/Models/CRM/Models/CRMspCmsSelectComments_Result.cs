using System;

namespace CRM.Models;

public class CRMspCmsSelectComments_Result
{
	public int? CommentId { get; set; }

	public int? ObjectTypeId { get; set; }

	public int? ObjectId { get; set; }

	public int? ParentId { get; set; }

	public int? CrmCompanyId { get; set; }

	public string CrmCompany { get; set; }

	public string IPAddress { get; set; }

	public string FName { get; set; }

	public string LName { get; set; }

	public string Mobile { get; set; }

	public string Tel { get; set; }

	public string Email { get; set; }

	public string Description { get; set; }

	public bool? IsVerified { get; set; }

	public int? VerifiedUserId { get; set; }

	public string VerifiedUser { get; set; }

	public DateTime? VerifiedDateTime { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int? UserId { get; set; }

	public short? Year1 { get; set; }

	public short? Month1 { get; set; }

	public DateTime? RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public string FirstRegisterUser { get; set; }

	public string EditUser { get; set; }

	public int? Level { get; set; }

	public string Path { get; set; }

	public string CrmCompanyPersons { get; set; }

	public long? RowNumber { get; set; }

	public long? AllPage { get; set; }
}
