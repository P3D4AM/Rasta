using System;

namespace CRM.Models;

public class CRMspSelectInternalMessageType_Result
{
	public int InternalMessageTypeID { get; set; }

	public string MessageType { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? UserId { get; set; }

	public short? Year1 { get; set; }

	public short? Month1 { get; set; }

	public DateTime? RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }
}
