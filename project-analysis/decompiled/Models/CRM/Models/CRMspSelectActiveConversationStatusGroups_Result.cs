using System;

namespace CRM.Models;

public class CRMspSelectActiveConversationStatusGroups_Result
{
	public int ConversationStatusGroupID { get; set; }

	public string ConversationStatusGroup { get; set; }

	public string ConversationStatusGroupDesc { get; set; }

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

	public string FirstRegisterUser { get; set; }

	public string EditUser { get; set; }

	public int? FOCnvsReferUserId { get; set; }

	public string FOCnvsReferMultiUser { get; set; }

	public string FOCnvsReferUser { get; set; }
}
