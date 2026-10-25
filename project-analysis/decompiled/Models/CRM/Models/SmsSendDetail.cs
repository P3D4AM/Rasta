using System;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(SmsSendDetailMetadata))]
public class SmsSendDetail
{
	public int ID { get; set; }

	public int HeadId { get; set; }

	public long? SID { get; set; }

	public string Body { get; set; }

	public string Number { get; set; }

	public string RefID { get; set; }

	public int? StatusId { get; set; }

	public int? CompanyId { get; set; }

	public int? CompanyPersonId { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

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

	public Guid? GUId { get; set; }

	public DateTime? StatusChangeDateTime { get; set; }

	public string AppType { get; set; }

	public int? SendPriority { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public bool? SendNeedCheck { get; set; }

	public int? CompanyProjectId { get; set; }

	public int? ObjectId { get; set; }

	public string ObjectIdType { get; set; }

	public string OTP { get; set; }

	public int? smsdCId { get; set; }

	public virtual Centers Centers { get; set; }

	public virtual CrmCompany CrmCompany { get; set; }

	public virtual CrmCompanyPersons CrmCompanyPersons { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual SmsSendHeader SmsSendHeader { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual Users Users2 { get; set; }
}
