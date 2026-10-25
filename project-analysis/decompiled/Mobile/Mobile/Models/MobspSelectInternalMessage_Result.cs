using System;

namespace Mobile.Models;

public class MobspSelectInternalMessage_Result
{
	public int InternalMessageID { get; set; }

	public int? msgMasterId { get; set; }

	public string msgSubject { get; set; }

	public string msgBody { get; set; }

	public int msgFromUserId { get; set; }

	public int? msgAttachRecId { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public int? msgTypeId { get; set; }

	public Guid? GUId { get; set; }

	public bool? msgActiveInCycle { get; set; }

	public int? msgLastGroupId { get; set; }

	public int? msgIsFinalised { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }
}
