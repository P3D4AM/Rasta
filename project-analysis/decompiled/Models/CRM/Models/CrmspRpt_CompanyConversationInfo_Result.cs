using System;

namespace CRM.Models;

public class CrmspRpt_CompanyConversationInfo_Result
{
	public string rptDate { get; set; }

	public string rptDay { get; set; }

	public int? rptUserId { get; set; }

	public string rptUserName { get; set; }

	public int cnvsCompanyId { get; set; }

	public int? cnvsProjectId { get; set; }

	public int ConversationID { get; set; }

	public string cnvsDate { get; set; }

	public string cnvsDateWS { get; set; }

	public string cnvsDay { get; set; }

	public string cnvsDayName { get; set; }

	public string cnvsTime { get; set; }

	public string cnvsPersonTitle { get; set; }

	public string cnvsTopic { get; set; }

	public string cnvsDesc { get; set; }

	public string cnvsPerson { get; set; }

	public string cnvsUser { get; set; }

	public string cnvsReferUser { get; set; }

	public string cnvsReferDesc { get; set; }

	public string cnvsStatus { get; set; }

	public string cnvsPriority { get; set; }

	public string cnvsRemindDate { get; set; }

	public string cnvsRemindTime { get; set; }

	public bool? cnvsIsBookMark { get; set; }

	public int? cnvsFirstRegisterUserId { get; set; }

	public string cnvsFirstRegisterUser { get; set; }

	public string cnvsFirstRegisterDate { get; set; }

	public int cnvsUserId { get; set; }

	public string cnvsUser2 { get; set; }

	public DateTime cnvsRegisterDate { get; set; }

	public string cnvsRegisterDatePersian { get; set; }
}
