using System;

namespace CRM.Models;

public class SmsSendHeaderMetadata
{
	public int ID { get; set; }

	public int SendType { get; set; }

	public string SendTopic { get; set; }

	public long? SID { get; set; }

	public string FromNumber { get; set; }

	public string smsBody { get; set; }

	public int? smsBodyCount { get; set; }

	public string smsBodyLangType { get; set; }

	public decimal? smsBodyCost { get; set; }

	public int? NumberCount { get; set; }

	public string Numbers { get; set; }

	public string RefNumbers { get; set; }

	public int? AllsmsCount { get; set; }

	public decimal? UserCost { get; set; }

	public int SendUserId { get; set; }

	public string SendDay { get; set; }

	public string SendDate { get; set; }

	public string SendTime { get; set; }

	public DateTime? SendDateTime { get; set; }

	public string CompaniesId { get; set; }

	public string CompanyPersonsId { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }
}
