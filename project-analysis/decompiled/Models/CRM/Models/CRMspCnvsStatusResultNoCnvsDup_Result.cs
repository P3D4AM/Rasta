using System;

namespace CRM.Models;

public class CRMspCnvsStatusResultNoCnvsDup_Result
{
	public int ConversationID { get; set; }

	public int? cnvsProjectId { get; set; }

	public int cnvsCompanyId { get; set; }

	public string cnvsDate { get; set; }

	public DateTime? cnvsDateTime { get; set; }

	public int? cnvsStatusId { get; set; }

	public string cnvsStatus { get; set; }

	public int? cnvsStatusResultId { get; set; }

	public string cnvsStatusResult { get; set; }
}
