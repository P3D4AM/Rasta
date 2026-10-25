using System;

namespace CRM.Models;

public class EmailspSelectEmailReceiveAttachments_Result
{
	public int EmailReceiveAttachmentId { get; set; }

	public int EmailReceiveId { get; set; }

	public string ContentId { get; set; }

	public string FileName { get; set; }

	public string SaveFilePath { get; set; }

	public string FileType { get; set; }

	public int? CompanyId { get; set; }

	public string CompanyName { get; set; }

	public int? CompanyPersonId { get; set; }

	public string PersonName { get; set; }

	public int? ProjectId { get; set; }

	public string Project { get; set; }

	public int FirstRegisterUserId { get; set; }

	public string FirstRegisterUser { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public string EditUser { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }
}
