using System;

namespace Mobile.Models;

public class MobspSelectLastSmsReceive_Result
{
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

	public int? CompanyPersonId { get; set; }

	public int? CompanyId { get; set; }

	public string ReceiveDay { get; set; }

	public string ReceiveTime { get; set; }

	public int? UserId { get; set; }

	public short? Year1 { get; set; }

	public short? Month1 { get; set; }

	public DateTime? RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public bool? IsDeleted { get; set; }

	public int? ReceiveType { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }
}
