using System;

namespace CRM.Models;

public class SmsspGetSMSTankRequestWeb_Result
{
	public int? ID { get; set; }

	public int? HeadId { get; set; }

	public int? SendType { get; set; }

	public long? SID { get; set; }

	public string Body { get; set; }

	public string Number { get; set; }

	public string RefID { get; set; }

	public int? StatusId { get; set; }

	public int? UserId { get; set; }

	public string StatusChangeDate { get; set; }

	public string StatusChangeTime { get; set; }

	public DateTime? StatusChangeDateTime { get; set; }

	public string BodyLangType { get; set; }

	public string SendDate { get; set; }

	public DateTime? SendDateTime { get; set; }

	public string FromNumber { get; set; }

	public int? CMessage { get; set; }

	public DateTime? SchedulDate { get; set; }

	public int? smsProviderId { get; set; }

	public DateTime? RegisterDate { get; set; }

	public int? SendPriority { get; set; }

	public string OTP { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public decimal? BodyCost { get; set; }

	public long? RowNumber { get; set; }
}
