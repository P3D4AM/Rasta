using System;

namespace CRM.Models;

public class SmsspGetSMSTankInfo_Result
{
	public int SmsSendHeaderId { get; set; }

	public int SendType { get; set; }

	public string SendTypeTitle { get; set; }

	public string SendTopic { get; set; }

	public string FromNumber { get; set; }

	public int? smsProviderId { get; set; }

	public string smsProvider { get; set; }

	public int SmsSendDetailId { get; set; }

	public long? SID { get; set; }

	public string Body { get; set; }

	public string Number { get; set; }

	public string RefID { get; set; }

	public int? StatusId { get; set; }

	public int? CompanyId { get; set; }

	public string CompanyName { get; set; }

	public int? CompanyPersonId { get; set; }

	public string PersonName { get; set; }

	public int? CompanyProjectId { get; set; }

	public int EditUserId { get; set; }

	public string EditUserName { get; set; }

	public string SendDate { get; set; }

	public string SendTime { get; set; }

	public DateTime? SendDateTime { get; set; }

	public string StatusChangeDate { get; set; }

	public string StatusChangeTime { get; set; }

	public DateTime? StatusChangeDateTime { get; set; }

	public int? SendPriority { get; set; }

	public string BodyLangType { get; set; }

	public int? SendUserId { get; set; }

	public string SendUserName { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterUserName { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public string ProjectTitle { get; set; }
}
