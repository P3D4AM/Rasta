using System;

namespace CRM.Models;

public class DyFormChartPrintFormFieldValues
{
	public int? FormId { get; set; }

	public int? FormFieldId { get; set; }

	public int CompanyId { get; set; }

	public string CmpNameWithTitle { get; set; }

	public int CompanyPersonId { get; set; }

	public string PrsName { get; set; }

	public int ProjectId { get; set; }

	public int ConversationId { get; set; }

	public int FirstRegisterUserId { get; set; }

	public string FirstRegisterUser { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public string EditUser { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public string ItemValue { get; set; }
}
