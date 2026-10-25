using System;

namespace CRM.Models;

public class CrmSCUspFormActionPermission_Result
{
	public int ID { get; set; }

	public int RollId { get; set; }

	public int FormId { get; set; }

	public int? FormActionId { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public string ActionName { get; set; }
}
