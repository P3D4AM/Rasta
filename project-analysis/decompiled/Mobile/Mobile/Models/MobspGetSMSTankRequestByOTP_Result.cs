using System;

namespace Mobile.Models;

public class MobspGetSMSTankRequestByOTP_Result
{
	public int ID { get; set; }

	public int HeadId { get; set; }

	public int SendType { get; set; }

	public string FromNumber { get; set; }

	public int? smsProviderId { get; set; }

	public int? CMessage { get; set; }

	public DateTime? SchedulDate { get; set; }

	public long? SID { get; set; }

	public string Body { get; set; }

	public string Number { get; set; }

	public string RefID { get; set; }

	public int? StatusId { get; set; }

	public int UserId { get; set; }

	public int? CompanyId { get; set; }

	public int? CompanyPersonId { get; set; }

	public string StatusChangeDate { get; set; }

	public string StatusChangeTime { get; set; }

	public int? BodyCount { get; set; }

	public string BodyLangType { get; set; }

	public decimal? BodyCost { get; set; }

	public int? SendUserId { get; set; }

	public string SendDay { get; set; }

	public string SendDate { get; set; }

	public string SendTime { get; set; }

	public DateTime? SendDateTime { get; set; }

	public DateTime? StatusChangeDateTime { get; set; }

	public int? SendPriority { get; set; }

	public bool? SendNeedCheck { get; set; }

	public int? CompanyProjectId { get; set; }

	public int? ObjectId { get; set; }

	public string ObjectIdType { get; set; }

	public string OTP { get; set; }
}
