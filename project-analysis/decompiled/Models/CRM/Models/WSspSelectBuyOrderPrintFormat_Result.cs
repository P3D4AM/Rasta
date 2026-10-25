using System;

namespace CRM.Models;

public class WSspSelectBuyOrderPrintFormat_Result
{
	public int PrintFormatID { get; set; }

	public int PrintFormatTypeId { get; set; }

	public string Title { get; set; }

	public string FileName { get; set; }

	public int UserId { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public string FileNameWeb { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }
}
