using System;

namespace CRM.Models;

public class CRMspSelectProjectInformationTop1_Result
{
	public int ProjectInformationId { get; set; }

	public int ProjectId { get; set; }

	public int FieldTitleId { get; set; }

	public string FieldValue { get; set; }

	public string Description { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }
}
