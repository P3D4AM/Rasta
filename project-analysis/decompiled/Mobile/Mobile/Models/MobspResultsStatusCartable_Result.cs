using System;

namespace Mobile.Models;

public class MobspResultsStatusCartable_Result
{
	public long? Rownum { get; set; }

	public int CompanyID { get; set; }

	public string CompanyName { get; set; }

	public int? cnvsPersonId { get; set; }

	public string PersonName { get; set; }

	public string prsPreTel { get; set; }

	public string prsTel { get; set; }

	public string prsTelDesc { get; set; }

	public string prjTitle { get; set; }

	public int ProjectID { get; set; }

	public int ConversationId { get; set; }

	public string cnvsDesc { get; set; }

	public int? cnvsStatusId { get; set; }

	public string cnvsStatus { get; set; }

	public string cnvsStatusGroup { get; set; }

	public int? cnvsProgressPercent { get; set; }

	public DateTime? cnvsRemindDateTime { get; set; }

	public DateTime? cnvsDateTime { get; set; }

	public DateTime RegisterDate { get; set; }

	public string cnvsPriority { get; set; }

	public int? cnvsPriorityId { get; set; }

	public string cnvsUserName { get; set; }

	public string cnvsReferName { get; set; }

	public int UserId { get; set; }

	public int? cnvsReferUserId { get; set; }

	public string cmpCountry { get; set; }

	public string cmpProvince { get; set; }

	public string cmpCity { get; set; }

	public string cmpPresentation { get; set; }

	public DateTime? cnvsRemindDateTimeForAllarm { get; set; }

	public bool? cnvsRemindOk { get; set; }

	public int? AllPage { get; set; }

	public string cnvsPriorityColor { get; set; }
}
