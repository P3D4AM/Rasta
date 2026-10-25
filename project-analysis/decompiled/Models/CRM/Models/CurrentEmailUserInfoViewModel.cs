using System.Collections.Generic;

namespace CRM.Models;

public class CurrentEmailUserInfoViewModel
{
	public CRMspSelectUsersInMode_Result CurrUser { get; set; }

	public int UserCurrentId { get; set; }

	public int UserNextId { get; set; }

	public int UserPreviousId { get; set; }

	public bool IsFind { get; set; }

	public string Message { get; set; }

	public int UserFirstId { get; set; }

	public int UserLastId { get; set; }

	public List<EmailspSelectEmailUsersInfoByUser_Result> EmailUselList { get; set; }
}
