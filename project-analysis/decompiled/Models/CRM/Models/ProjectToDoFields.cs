using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class ProjectToDoFields
{
	public int ProjectId { get; set; }

	public int ConversationId { get; set; }

	public int? ToDoYear { get; set; }

	public int? ToDoMonth { get; set; }

	public int? ToDoDay { get; set; }

	public int? ToDoHour { get; set; }

	public int? ToDoMinute { get; set; }

	public DateTime? ToDoTime { get; set; }

	public DateTime? ToDoTimeRegister { get; set; }

	public DateTime? ToDoTimeDone { get; set; }

	public int Mode { get; set; }

	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	public string cnvsReferUserDesc { get; set; }

	public int? CnvsPriorityId { get; set; }

	public int? cnvsReferUserId { get; set; }
}
