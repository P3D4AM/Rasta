using System;

namespace CRM.Models;

public class CRMspSmsSelectReceiveSMS_Result
{
	public string rptDate { get; set; }

	public string rptDay { get; set; }

	public int? rptUserId { get; set; }

	public string rptUserName { get; set; }

	public DateTime? FDate { get; set; }

	public DateTime? TDate { get; set; }

	public string FDateFa { get; set; }

	public string TDateFa { get; set; }

	public long Id { get; set; }

	public long? OrderNum { get; set; }

	public string SmsNumber { get; set; }

	public string SmsDesc { get; set; }

	public string GetId { get; set; }

	public string FromNumber { get; set; }

	public DateTime? ReceiveDate { get; set; }

	public string ReceiveDatePersian { get; set; }

	public string ReceiveDatePersianPreview { get; set; }

	public DateTime? SendDate { get; set; }

	public string SendDatePersian { get; set; }

	public string SendDatePersianPreview { get; set; }

	public DateTime? RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public int? CompanyPersonId { get; set; }

	public int? CompanyId { get; set; }

	public string ReceiveDay { get; set; }

	public string ReceiveTime { get; set; }

	public int? UserId { get; set; }

	public short? Year1 { get; set; }

	public short? Month1 { get; set; }

	public string PersonInfo { get; set; }

	public string CompanyInfo { get; set; }
}
