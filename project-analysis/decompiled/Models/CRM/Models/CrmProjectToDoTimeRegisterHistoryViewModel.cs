using System;

namespace CRM.Models;

public class CrmProjectToDoTimeRegisterHistoryViewModel
{
	public int? UserId { get; set; }

	public string UserName { get; set; }

	public DateTime? prjToDoTimeRegister { get; set; }

	public string prjToDoTimeRegisterStr { get; set; }
}
