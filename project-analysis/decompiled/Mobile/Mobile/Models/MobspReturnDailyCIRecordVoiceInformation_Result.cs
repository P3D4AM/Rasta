using System;

namespace Mobile.Models;

public class MobspReturnDailyCIRecordVoiceInformation_Result
{
	public int? CompanyID { get; set; }

	public int? CompanyPersonID { get; set; }

	public string PhoneName { get; set; }

	public int CallTypeId { get; set; }

	public string CallType { get; set; }

	public string CallTime { get; set; }

	public string CallDate { get; set; }

	public string CallDay { get; set; }

	public int? LineNumber { get; set; }

	public int CallHistoryid { get; set; }

	public DateTime RegisterDate { get; set; }

	public string PhoneNumber { get; set; }

	public int PersonId { get; set; }

	public string NoteWithRegEdt { get; set; }

	public string EditedUser { get; set; }

	public int? NoteRegisterUserId { get; set; }

	public int? NoteEditedUserId { get; set; }

	public int? NumberEditedUserId { get; set; }

	public string Tamas { get; set; }

	public string Length { get; set; }

	public string FilePath { get; set; }

	public string FilePathWeb { get; set; }

	public string UserName { get; set; }

	public string internalDial { get; set; }

	public string internalName { get; set; }

	public int? DevType { get; set; }

	public long? RowNumber { get; set; }

	public int? AllPage { get; set; }
}
