using System;

namespace CRM.Models;

public class spSelectPrintFormat_Result
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

	public int? CId { get; set; }

	public string CenterName { get; set; }

	public int? SysPartId { get; set; }

	public string SysPartTitle { get; set; }

	public int? SysPartObjectId { get; set; }

	public bool? IsDefault { get; set; }
}
