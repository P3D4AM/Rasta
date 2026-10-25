using System;

namespace CRMIdealApi.ApiModels;

public class SelectCReminderViewModel
{
	public string UserName { get; set; }

	public string Password { get; set; }

	public DateTime Date { get; set; }

	public int CrmUserId { get; set; }

	public bool? SelectWithCnvs { get; set; }

	public int? SelectedUserId { get; set; }

	public int? LanguageId { get; set; }

	public int? DefaultLangId { get; set; }
}
