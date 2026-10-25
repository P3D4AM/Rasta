namespace Mobile.Models;

public class HrmTimeAttendanceEditReqViewModel
{
	public string tmDatePersian { get; set; }

	public int tmUserId { get; set; }

	public string tmEntryTime { get; set; }

	public string tmEntryRegisterIP { get; set; }

	public string tmExitTime { get; set; }

	public string tmExitRegisterIP { get; set; }

	public string tmDescription { get; set; }

	public string UserLat { get; set; }

	public string UserLng { get; set; }

	public bool? IsEntryRequest { get; set; }

	public bool? IsExitRequest { get; set; }

	public bool? IsEntryRequestDuplicate { get; set; }

	public bool? IsExitRequestDuplicate { get; set; }

	public int? ResendEntryRequestId { get; set; }

	public int? ResendExitRequestId { get; set; }

	public int? LanguageId { get; set; }

	public int? CenterId { get; set; }
}
