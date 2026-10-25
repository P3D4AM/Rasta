using System;

namespace CRM.Models;

public class CRMspSerachsysFormByName_Result
{
	public int ID { get; set; }

	public string FormPersianName { get; set; }

	public string FormName { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }
}
