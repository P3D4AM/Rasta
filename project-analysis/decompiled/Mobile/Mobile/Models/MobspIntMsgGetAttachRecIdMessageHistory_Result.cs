using System;

namespace Mobile.Models;

public class MobspIntMsgGetAttachRecIdMessageHistory_Result
{
	public int InternalMessageID { get; set; }

	public int? msgMasterId { get; set; }

	public string msgSubject { get; set; }

	public string msgBody { get; set; }

	public int msgFromUserId { get; set; }

	public string msgFromUser { get; set; }

	public int? msgAttachRecId { get; set; }

	public int UserId { get; set; }

	public string EditUser { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public int? msgTypeId { get; set; }

	public bool? msgActiveInCycle { get; set; }

	public int? msgLastGroupId { get; set; }

	public int? msgIsFinalised { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterUser { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public string ApiId { get; set; }

	public int? msgCompanyId { get; set; }

	public int? msgProjectId { get; set; }

	public int? msgAttachFileCount { get; set; }

	public string MessageDetails { get; set; }
}
