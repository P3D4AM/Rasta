using System;

namespace CRM.Models;

public class EmailspSelectEmailUserTempTankByUser_Result
{
	public long EmailUserTempTankId { get; set; }

	public int UserId { get; set; }

	public string EmailAddress { get; set; }

	public int? EmailCmpId { get; set; }

	public int? EmailCmpPrsId { get; set; }

	public string EmailCmpPrsName { get; set; }

	public int? EmailCmpPrjId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string FilePath { get; set; }

	public string FilePathII { get; set; }

	public string FilePathIII { get; set; }

	public string FilePathIV { get; set; }

	public string FilePathV { get; set; }

	public string EmailCmpName { get; set; }

	public string EmailPrsJob { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }
}
