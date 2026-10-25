using System;

namespace CRMIdealApi.ApiModels;

public class ApispSelectConversationStatusGroups_Result
{
	public int ApiConversationStatusGroupID { get; set; }

	public string ApiConversationStatusGroup { get; set; }

	public string ApiConversationStatusGroupDesc { get; set; }

	public int ApiUserId { get; set; }

	public DateTime ApiRegisterDate { get; set; }

	public int? ApiFirstRegisterUserId { get; set; }

	public DateTime? ApiFirstRegisterDate { get; set; }

	public string ApiFirstRegisterUser { get; set; }

	public string ApiEditUser { get; set; }

	public int? ApiFOCnvsReferUserId { get; set; }

	public string ApiFOCnvsReferMultiUser { get; set; }

	public string ApiFOCnvsReferUser { get; set; }
}
