using System;

namespace CRM.Models;

public class CRMspSelectAssignedFormActionsToRoll_Result
{
	public int ID { get; set; }

	public int FormId { get; set; }

	public string ActionPersianName { get; set; }

	public string ActionName { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }
}
