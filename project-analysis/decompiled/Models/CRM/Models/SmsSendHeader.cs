using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(SmsSendHeaderMetadata))]
public class SmsSendHeader
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

	public int? CMessage { get; set; }

	public DateTime? SchedulDate { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public int? smsProviderId { get; set; }

	public int? smsCId { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual SmsProviders SmsProviders { get; set; }

	public virtual ICollection<SmsReceive> SmsReceive { get; set; }

	public virtual Centers Centers { get; set; }

	public virtual ICollection<SmsSendDetail> SmsSendDetail { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual Users Users2 { get; set; }

	public SmsSendHeader()
	{
		SmsReceive = (ICollection<SmsReceive>)new HashSet<SmsReceive>();
		SmsSendDetail = (ICollection<SmsSendDetail>)new HashSet<SmsSendDetail>();
	}
}
