using System;

namespace Mobile.Models;

public class MobspResultsReminderCartable_Result
{
	public long? RowNumber { get; set; }

	public int companyId { get; set; }

	public string companyName { get; set; }

	public string personName { get; set; }

	public string projectTitle { get; set; }

	public int projectId { get; set; }

	public int? prjcnvsStatusGroupId { get; set; }

	public int conversationId { get; set; }

	public string cnvsDesc { get; set; }

	public int? cnvsStatusId { get; set; }

	public string cnvsStatus { get; set; }

	public int? progressPercent { get; set; }

	public string progressPercentWD { get; set; }

	public DateTime? remindDateTime { get; set; }

	public DateTime? cnvsDateTime { get; set; }

	public DateTime registerDate { get; set; }

	public string priority { get; set; }

	public string priorityColor { get; set; }

	public int? priorityId { get; set; }

	public string cnvsUserName { get; set; }

	public string cnvsReferName { get; set; }

	public int UserId { get; set; }

	public int? cnvsReferUserId { get; set; }

	public int? cnvsPersonId { get; set; }

	public DateTime? firstRegisterDate { get; set; }

	public DateTime? cnvsRemindDateTimeForAllarm { get; set; }

	public string cnvsRemindTime { get; set; }

	public bool? cnvsRemindOk { get; set; }

	public int? AllPage { get; set; }
}
